/**
 * Generates SDK operation registry + language bindings from notifique-docs OpenAPI specs.
 * Run: node scripts/generate-from-openapi.mjs
 */
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { execSync } from 'node:child_process';
import {
  bundleOpenApi,
  extractOpTypes,
  generateTypedBindings,
} from './typed-bindings.mjs';
import { extractQueryParams, getSchemaByModelName, responseKindFromSchema, schemaToModelName } from './type-helpers.mjs';

const __dirname = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.join(__dirname, '..');
const manifest = JSON.parse(fs.readFileSync(path.join(ROOT, 'openapi/spec-manifest.json'), 'utf8'));
const DOCS_ROOT = path.resolve(ROOT, manifest.docsRoot);

const HTTP_METHODS = ['get', 'post', 'put', 'patch', 'delete', 'head', 'options'];

function toCamel(s) {
  return s.replace(/[-_]([a-z])/g, (_, c) => c.toUpperCase()).replace(/^([A-Z])/, (m) => m.toLowerCase());
}

function toSnake(s) {
  return s.replace(/([A-Z])/g, '_$1').replace(/-/g, '_').toLowerCase().replace(/^_/, '');
}

function toPascal(s) {
  const c = toCamel(s);
  return c.charAt(0).toUpperCase() + c.slice(1);
}

function methodNameFromOperation(operationId, httpMethod, apiPath) {
  if (operationId) {
    const stripped = operationId.replace(/^ntf[A-Za-z0-9]+_/, '');
    if (stripped) return toCamel(stripped);
  }
  const segments = apiPath.replace(/^\/v1\//, '').replace(/^\/public\//, 'public/').split('/').filter(Boolean);
  const last = segments[segments.length - 1];
  const hasParam = last?.startsWith('{');
  const resource = hasParam ? segments[segments.length - 2] ?? 'resource' : last ?? 'resource';
  const map = { get: 'list', post: 'create', put: 'update', patch: 'update', delete: 'delete' };
  if (httpMethod === 'get' && hasParam) return `get${toPascal(resource)}`;
  if (httpMethod === 'delete' && hasParam) return `delete${toPascal(resource)}`;
  return toCamel(`${map[httpMethod] ?? httpMethod}_${resource}`);
}

function sanitizeNamespaceKey(part) {
  if (!part) return 'root';
  const cleaned = part.replace(/^\./, '').replace(/\./g, '_');
  const segmentMap = {
    'well-known': 'wellKnown',
    well_known: 'wellKnown',
    email: 'email',
    emails: 'email',
    templates: 'templates',
    events: 'events',
    automations: 'automations',
    'phone-numbers': 'phoneNumbers',
    phone_numbers: 'phoneNumbers',
    'short-links': 'shortLinks',
    short_links: 'shortLinks',
    'ai-web-widget': 'aiWebWidget',
    ai_web_widget: 'aiWebWidget',
    'ai-widget': 'aiWidget',
    ai_widget: 'aiWidget',
    'marketing-addons': 'marketingAddons',
    forms: 'forms',
    conversions: 'conversions',
    suppressions: 'suppressions',
    report: 'report',
    oauth: 'oauth',
    webhooks: 'webhooks',
    logs: 'logs',
    workspaces: 'workspaces',
    whatsapp: 'whatsapp',
    sms: 'sms',
    push: 'push',
    telegram: 'telegram',
    instagram: 'instagram',
    rcs: 'rcs',
    voice: 'voice',
    contacts: 'contacts',
    platforms: 'platform',
    platform: 'platform',
  };
  const raw = segmentMap[part] ?? segmentMap[cleaned] ?? toCamel(cleaned.replace(/-/g, '_'));
  return /^[a-zA-Z_$][a-zA-Z0-9_$]*$/.test(raw) ? raw : `_${raw}`;
}

function namespaceFromPath(apiPath) {
  if (apiPath.startsWith('/.well-known/')) return ['wellKnown'];
  if (apiPath.startsWith('/oauth/')) return ['oauth'];
  if (apiPath.startsWith('/public/')) {
    const parts = apiPath.slice(1).split('/').filter((p) => !p.startsWith('{'));
    return ['public', sanitizeNamespaceKey(parts[1] ?? 'resource')];
  }
  const withoutV1 = apiPath.replace(/^\/v1\//, '');
  const parts = withoutV1.split('/').filter((p) => !p.startsWith('{'));
  if (parts.length === 0) return ['api'];
  if (parts.length === 1) return [sanitizeNamespaceKey(parts[0])];
  if (parts.length === 2) return [sanitizeNamespaceKey(parts[0])];
  return [sanitizeNamespaceKey(parts[0]), sanitizeNamespaceKey(parts[1])];
}

function buildUrlTemplate(apiPath) {
  return apiPath;
}

function extractPathParams(apiPath) {
  const matches = apiPath.match(/\{([^}]+)\}/g) ?? [];
  return matches.map((m) => m.slice(1, -1));
}

function dedupeMethodNames(ops) {
  const byNs = new Map();
  for (const op of ops) {
    const key = op.namespaces.join('.');
    if (!byNs.has(key)) byNs.set(key, new Set());
    const used = byNs.get(key);
    let name = op.methodName;
    let n = 2;
    while (used.has(name)) {
      name = `${op.methodName}${n++}`;
    }
    used.add(name);
    op.methodName = name;
  }
}

function specTypeAlias(rel) {
  const fileBase = path.basename(rel, '.json');
  if (fileBase.startsWith('openapi-')) {
    return toPascal(fileBase.slice(8).replace(/-/g, '_'));
  }
  const parts = rel.split('/');
  const top = parts[0];
  if (top.endsWith('-api')) {
    return toPascal(top.slice(0, -4).replace(/-/g, '_'));
  }
  if (top === 'guides' && parts[1]) {
    return toPascal(parts[1].replace(/-/g, '_'));
  }
  return toPascal(top.replace(/-/g, '_'));
}

function requiresAuth(op, spec) {
  if (op.security === null) return false;
  const sec = op.security ?? spec.security;
  return Array.isArray(sec) && sec.length > 0;
}

function isIdempotentSend(httpMethod, apiPath) {
  return httpMethod === 'post' && /\/(messages|send|events\/send)/.test(apiPath);
}

const operations = [];
const seenKeys = new Set();

for (const rel of manifest.specs) {
  const filePath = path.join(DOCS_ROOT, rel);
  if (!fs.existsSync(filePath)) {
    console.error('Missing spec:', filePath);
    process.exit(1);
  }
  const spec = JSON.parse(fs.readFileSync(filePath, 'utf8'));
  const specName = rel.split('/')[0];
  for (const [apiPath, pathItem] of Object.entries(spec.paths ?? {})) {
    for (const method of HTTP_METHODS) {
      const op = pathItem[method];
      if (!op) continue;
      const opKey = `${method.toUpperCase()} ${apiPath}`;
      if (seenKeys.has(opKey)) continue;
      seenKeys.add(opKey);
      const namespaces = namespaceFromPath(apiPath);
      const methodName = methodNameFromOperation(op.operationId, method, apiPath);
      const pathParams = extractPathParams(apiPath);
      const urlTemplate = buildUrlTemplate(apiPath);
      const { responseSchema, requestBodySchema } = extractOpTypes(op);
      const queryParams = extractQueryParams(op);
      operations.push({
        spec: specName,
        operationId: op.operationId ?? null,
        httpMethod: method.toUpperCase(),
        path: apiPath,
        urlTemplate,
        namespaces,
        methodName,
        pathParams,
        responseSchema,
        requestBodySchema,
        queryParams,
        requiresAuth: requiresAuth(op, spec),
        idempotent: isIdempotentSend(method, apiPath),
        summary: op.summary ?? '',
      });
    }
  }
}

operations.sort((a, b) => a.path.localeCompare(b.path) || a.httpMethod.localeCompare(b.httpMethod));
dedupeMethodNames(operations);

const bundledForKinds = bundleOpenApi(manifest, DOCS_ROOT);
for (const op of operations) {
  if (!op.responseSchema) {
    op.responseKind = 'none';
  } else {
    op.responseKind = responseKindFromSchema(
      getSchemaByModelName(bundledForKinds.components.schemas, op.responseSchema),
    );
  }
}

const outDir = path.join(ROOT, 'packages/core/src/generated');
fs.mkdirSync(outDir, { recursive: true });
fs.writeFileSync(path.join(outDir, 'operations.json'), JSON.stringify({ count: operations.length, operations }, null, 2));

// --- TypeScript namespaces ---
function tsBuildUrl(pathParams, urlTemplate) {
  if (pathParams.length === 0) return `'${urlTemplate}'`;
  let expr = `'${urlTemplate}'`;
  for (const p of pathParams) {
    expr = expr.replace(`{${p}}`, `' + encodeURIComponent(String(pathParams.${toCamel(p)})) + '`);
    expr = expr.replace(/\+\s*''$/, '');
  }
  return expr;
}

function groupByNamespace(ops) {
  const tree = {};
  for (const op of ops) {
    let node = tree;
    for (let i = 0; i < op.namespaces.length; i++) {
      const ns = op.namespaces[i];
      if (!node[ns]) node[ns] = { ops: [], children: {} };
      if (i === op.namespaces.length - 1) node[ns].ops.push(op);
      else node = node[ns].children;
    }
  }
  return tree;
}

function tsPathLiteral(apiPath) {
  return apiPath.replace(/\\/g, '\\\\').replace(/'/g, "\\'");
}

function emitTsNamespace(node, indent = 2) {
  const sp = ' '.repeat(indent);
  const lines = [];
  for (const op of node.ops) {
    const pathLit = tsPathLiteral(op.path);
    const typePath = `'${pathLit}'`;
    const methodLit = op.httpMethod.toLowerCase();
    const typeMethod = `'${methodLit}'`;
    const params = [];
    if (op.pathParams.length) {
      params.push(`pathParams: OpPathParams<${typePath}, ${typeMethod}>`);
    }
    const optParts = [`query?: OpQuery<${typePath}, ${typeMethod}>`];
    if (methodLit !== 'get' && methodLit !== 'delete') {
      optParts.push(`body?: OpRequestBody<${typePath}, ${typeMethod}>`, 'idempotencyKey?: string');
    }
    params.push(`options?: { ${optParts.join('; ')} }`);
    const url = tsBuildUrl(op.pathParams, op.urlTemplate);
    const responseType = `OpResponse<${typePath}, ${typeMethod}>`;
    let call;
    if (methodLit === 'get' || methodLit === 'delete') {
      call = `http.request<${responseType}>('${op.httpMethod}', ${url}, { query: options?.query })`;
    } else {
      call = `http.request<${responseType}>('${op.httpMethod}', ${url}, { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey })`;
    }
    lines.push(`${sp}/** ${op.summary || op.operationId || op.path} */`);
    lines.push(`${sp}${op.methodName}: async (${params.join(', ')}) => ${call},`);
  }
  for (const [childName, childNode] of Object.entries(node.children)) {
    lines.push(`${sp}${childName}: {`);
    lines.push(emitTsNamespace(childNode, indent + 2));
    lines.push(`${sp}},`);
  }
  return lines.join('\n');
}

function emitTypedApiTs(tree) {
  const tsLines = [
    '/** Auto-generated from OpenAPI — do not edit manually */',
    'import type { OpPathParams, OpQuery, OpRequestBody, OpResponse } from "@notifique/core";',
    'import type { HttpTransport } from "../http";',
    '',
    'export function createGeneratedApi(http: HttpTransport) {',
    '  return {',
    '    http,',
  ];
  for (const [ns, node] of Object.entries(tree)) {
    tsLines.push(`    ${ns}: {`);
    tsLines.push(emitTsNamespace(node, 6));
    tsLines.push('    },');
  }
  tsLines.push('  };');
  tsLines.push('}');
  tsLines.push('');
  tsLines.push('export type GeneratedApi = ReturnType<typeof createGeneratedApi>;');
  return tsLines.join('\n');
}

const tree = groupByNamespace(operations);

const copyTargets = [
  'packages/sdk-python/notifique/operations.json',
  'packages/sdk-go/operations.json',
  'packages/sdk-java/src/main/resources/notifique/operations.json',
  'packages/sdk-php/resources/operations.json',
  'packages/sdk-elixir/priv/operations.json',
  'packages/sdk-dotnet/operations.json',
];
const opsJson = JSON.stringify({ count: operations.length, operations }, null, 2);
for (const rel of copyTargets) {
  const p = path.join(ROOT, rel);
  fs.mkdirSync(path.dirname(p), { recursive: true });
  fs.writeFileSync(p, opsJson);
}

console.log(`Generated ${operations.length} operations across ${manifest.specs.length} specs.`);

// --- OpenAPI TypeScript schemas (openapi-typescript) ---
const schemaDir = path.join(ROOT, 'packages/core/src/generated/schemas');
fs.mkdirSync(schemaDir, { recursive: true });
const schemaExports = [];
const successfulSchemas = [];
let schemaFailures = 0;
for (const rel of manifest.specs) {
  const schemaName = rel.replace(/\//g, '_').replace(/\.json$/, '');
  const inFile = path.join(DOCS_ROOT, rel);
  const outFile = path.join(schemaDir, schemaName + '.ts');
  try {
    execSync(`npx openapi-typescript "${inFile}" -o "${outFile}"`, { cwd: ROOT, stdio: 'pipe' });
    const alias = specTypeAlias(rel);
    schemaExports.push(
      `export type { paths as ${alias}Paths, components as ${alias}Components, operations as ${alias}Operations } from './${schemaName}';`
    );
    successfulSchemas.push({ rel, schemaName });
  } catch (e) {
    schemaFailures += 1;
    console.warn(`openapi-typescript skipped ${rel}:`, e.stderr?.toString().split('\n')[0] || e.message);
  }
}
fs.writeFileSync(
  path.join(schemaDir, 'index.ts'),
  [
    '/** Auto-generated OpenAPI component types — do not edit manually */',
    ...schemaExports,
  ].join('\n')
);
console.log(`Generated ${schemaExports.length} OpenAPI schema modules (${schemaFailures} skipped).`);

if (schemaFailures > 0) {
  console.error(`ERROR: ${schemaFailures} OpenAPI specs failed schema generation — fix specs before release.`);
  process.exit(1);
}

// --- Merged ApiPaths + operation helpers (typed client.api autocomplete) ---
const apiPathsLines = [
  '/** Merged OpenAPI paths and helpers for typed `client.api` — auto-generated */',
  ...successfulSchemas.map(({ schemaName }, i) =>
    `import type { paths as paths${i} } from './schemas/${schemaName}';`
  ),
  '',
  'export type ApiPaths =',
  successfulSchemas.map((_, i) => `  & paths${i}`).join('\n'),
  '',
  'export type HttpMethodLower = \'get\' | \'post\' | \'put\' | \'patch\' | \'delete\';',
  '',
  'export type OpFor<P extends keyof ApiPaths, M extends HttpMethodLower> =',
  '  ApiPaths[P] extends Record<M, infer Op> ? Op : never;',
  '',
  'type JsonMedia<C> = C extends { \'application/json\': infer T } ? T : never;',
  'type ResponseBody<R> = R extends { content: infer C } ? JsonMedia<C> : never;',
  '',
  'type SuccessResponse<Res> =',
  '  ResponseBody<Res extends { 200: infer R0 } ? R0 : never> |',
  '  ResponseBody<Res extends { 201: infer R1 } ? R1 : never> |',
  '  ResponseBody<Res extends { 202: infer R2 } ? R2 : never> |',
  '  ResponseBody<Res extends { 204: infer R3 } ? R3 : never>;',
  '',
  'export type OpResponse<P extends keyof ApiPaths, M extends HttpMethodLower> =',
  '  OpFor<P, M> extends { responses: infer Res } ? SuccessResponse<Res> : unknown;',
  '',
  'export type OpRequestBody<P extends keyof ApiPaths, M extends HttpMethodLower> =',
  '  OpFor<P, M> extends { requestBody?: infer RB }',
  '    ? RB extends { content: infer C } ? JsonMedia<C> : never',
  '    : never;',
  '',
  'export type OpQuery<P extends keyof ApiPaths, M extends HttpMethodLower> =',
  '  OpFor<P, M> extends { parameters: { query?: infer Q } } ? Q : never;',
  '',
  'export type OpPathParams<P extends keyof ApiPaths, M extends HttpMethodLower> =',
  '  OpFor<P, M> extends { parameters: { path: infer Path } } ? Path : never;',
  '',
];
fs.writeFileSync(path.join(outDir, 'api-paths.ts'), apiPathsLines.join('\n'));

fs.mkdirSync(path.join(ROOT, 'packages/sdk-node/src/generated'), { recursive: true });
fs.writeFileSync(
  path.join(ROOT, 'packages/sdk-node/src/generated/api.ts'),
  emitTypedApiTs(tree)
);
console.log('Generated typed client.api (OpResponse / OpRequestBody / OpQuery per operation).');

const bundled = bundleOpenApi(manifest, DOCS_ROOT);
fs.mkdirSync(path.join(ROOT, 'openapi'), { recursive: true });
fs.writeFileSync(path.join(ROOT, 'openapi/bundled.openapi.json'), JSON.stringify(bundled, null, 2));

generateTypedBindings({
  root: ROOT,
  tree,
  operations,
  execSync,
  helpers: { toCamel, toSnake, toPascal },
});
