/**
 * Enriquece respostas OpenAPI em notifique-docs (PT + EN + ES) com $ref em components/schemas.
 * Run: node scripts/enrich-openapi-responses.mjs
 */
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { extractOpTypes } from './typed-bindings.mjs';

const root = path.join(path.dirname(fileURLToPath(import.meta.url)), '..');
const manifest = JSON.parse(fs.readFileSync(path.join(root, 'openapi/spec-manifest.json'), 'utf8'));
const docsRoot = path.resolve(root, manifest.docsRoot);
const opsPath = path.join(root, 'packages/core/src/generated/operations.json');
const { operations } = JSON.parse(fs.readFileSync(opsPath, 'utf8'));

const SUCCESS_CODES = ['200', '201', '202'];
const SHARED_SCHEMAS = {
  NtfBinaryFileResponse: {
    type: 'string',
    format: 'binary',
    description: 'Conteúdo binário (download de arquivo ou mídia).',
  },
  NtfCsvExportResponse: {
    type: 'string',
    description: 'Conteúdo CSV (exportação).',
  },
  NtfEmptyJsonResponse: {
    type: 'object',
    additionalProperties: false,
    description: 'Resposta JSON vazia (sucesso sem payload).',
    properties: { success: { type: 'boolean', example: true } },
  },
};

function operationSchemaPrefix(operationId) {
  if (!operationId) return 'Ntf';
  const first = operationId.split('_')[0];
  if (first.startsWith('ntf') && first.length > 3) return `Ntf${first.slice(3)}`;
  return first;
}

function responseSchemaName(operationId) {
  if (!operationId) return null;
  const parts = operationId.split('_');
  if (parts.length < 2) return `${operationId}Response`;
  const prefix = operationSchemaPrefix(operationId);
  const rest = parts
    .slice(1)
    .map((s) => s.charAt(0).toUpperCase() + s.slice(1))
    .join('');
  return `${prefix}_${rest}Response`;
}

function schemaFromExample(example) {
  if (example === null) return { nullable: true };
  if (Array.isArray(example)) {
    return {
      type: 'array',
      items: example.length > 0 ? schemaFromExample(example[0]) : { type: 'object' },
    };
  }
  if (typeof example === 'object') {
    const properties = {};
    for (const [key, value] of Object.entries(example)) {
      properties[key] = schemaFromExample(value);
    }
    return { type: 'object', properties };
  }
  if (typeof example === 'boolean') return { type: 'boolean' };
  if (typeof example === 'number') {
    return Number.isInteger(example) ? { type: 'integer' } : { type: 'number' };
  }
  return { type: 'string' };
}

function ensureComponents(spec) {
  if (!spec.components) spec.components = {};
  if (!spec.components.schemas) spec.components.schemas = {};
  return spec.components.schemas;
}

function addSchema(schemas, name, schema) {
  if (!schemas[name]) {
    schemas[name] = schema;
    return name;
  }
  if (JSON.stringify(schemas[name]) === JSON.stringify(schema)) return name;
  let i = 2;
  while (schemas[`${name}_${i}`]) i += 1;
  const alt = `${name}_${i}`;
  schemas[alt] = schema;
  return alt;
}

function pickSuccessResponse(responses) {
  for (const code of SUCCESS_CODES) {
    if (responses?.[code]) return { code, response: responses[code] };
  }
  return null;
}

function enrichSuccessResponse(spec, op, operationId) {
  const picked = pickSuccessResponse(op.responses);
  if (!picked) return false;

  const { code, response } = picked;
  const schemas = ensureComponents(spec);
  const baseName = responseSchemaName(operationId);
  if (!baseName) return false;

  const content = response.content ?? {};
  const contentTypes = Object.keys(content);

  if (contentTypes.length === 0) {
    const name = addSchema(schemas, baseName, { ...SHARED_SCHEMAS.NtfEmptyJsonResponse });
    response.content = {
      'application/json': {
        schema: { $ref: `#/components/schemas/${name}` },
      },
    };
    return true;
  }

  const jsonBlock = content['application/json'] ?? content['application/problem+json'];
  const mediaType = content['application/json'] ? 'application/json' : 'application/problem+json';

  if (jsonBlock) {
    let schema = jsonBlock.schema;
    if (!schema) {
      const example =
        jsonBlock.example ??
        (jsonBlock.examples
          ? Object.values(jsonBlock.examples)[0]?.value ?? Object.values(jsonBlock.examples)[0]
          : null);
      if (example) schema = schemaFromExample(example);
    }
    if (schema) {
      if (schema.$ref) return false;
      const name = addSchema(schemas, baseName, JSON.parse(JSON.stringify(schema)));
      jsonBlock.schema = { $ref: `#/components/schemas/${name}` };
      if (!response.content[mediaType]) {
        response.content[mediaType] = jsonBlock;
      }
      return true;
    }
  }

  if (contentTypes.includes('text/csv')) {
    const name = addSchema(schemas, baseName, { ...SHARED_SCHEMAS.NtfCsvExportResponse });
    content['text/csv'] = {
      ...(content['text/csv'] ?? {}),
      schema: { $ref: `#/components/schemas/${name}` },
    };
    return true;
  }

  if (contentTypes.some((t) => t === 'application/octet-stream' || t.startsWith('image/') || t.startsWith('audio/'))) {
    const name = addSchema(schemas, baseName, { ...SHARED_SCHEMAS.NtfBinaryFileResponse });
    const binType = contentTypes.find(
      (t) => t === 'application/octet-stream' || t.startsWith('image/') || t.startsWith('audio/'),
    );
    content[binType] = {
      ...(content[binType] ?? {}),
      schema: { $ref: `#/components/schemas/${name}` },
    };
    return true;
  }

  for (const [mediaType, block] of Object.entries(content)) {
    if (!block?.schema || block.schema.$ref) continue;
    const name = addSchema(schemas, baseName, JSON.parse(JSON.stringify(block.schema)));
    block.schema = { $ref: `#/components/schemas/${name}` };
    return true;
  }

  return false;
}

function findSpecRel(apiPath) {
  for (const rel of manifest.specs) {
    const specPath = path.join(docsRoot, rel);
    if (!fs.existsSync(specPath)) continue;
    const spec = JSON.parse(fs.readFileSync(specPath, 'utf8'));
    if (spec.paths?.[apiPath]) return rel;
  }
  return null;
}

function enrichSpecFile(filePath) {
  if (!fs.existsSync(filePath)) return { updated: 0 };
  const spec = JSON.parse(fs.readFileSync(filePath, 'utf8'));
  const schemas = ensureComponents(spec);
  for (const [name, schema] of Object.entries(SHARED_SCHEMAS)) {
    if (!schemas[name]) schemas[name] = { ...schema };
  }

  let updated = 0;
  for (const op of operations) {
    if (op.responseSchema) continue;
    const pathItem = spec.paths?.[op.path];
    if (!pathItem) continue;
    const openapiOp = pathItem[op.httpMethod.toLowerCase()];
    if (!openapiOp || openapiOp.operationId !== op.operationId) continue;

    const before = JSON.stringify(openapiOp.responses);
    if (enrichSuccessResponse(spec, openapiOp, op.operationId)) {
      if (JSON.stringify(openapiOp.responses) !== before) updated += 1;
    }
  }

  if (updated > 0) {
    fs.writeFileSync(filePath, JSON.stringify(spec, null, 2) + '\n');
  }
  return { updated };
}

let totalUpdated = 0;
const locales = ['', 'en/', 'es/'];

for (const locale of locales) {
  for (const rel of manifest.specs) {
    const filePath = path.join(docsRoot, locale, rel);
    const { updated } = enrichSpecFile(filePath);
    if (updated > 0) {
      console.log(`Updated ${updated} ops in ${locale}${rel}`);
      totalUpdated += updated;
    }
  }
}

console.log(`Total operations enriched: ${totalUpdated}`);

// Verify remaining gaps (PT specs only)
let stillMissing = 0;
for (const op of operations) {
  for (const rel of manifest.specs) {
    const spec = JSON.parse(fs.readFileSync(path.join(docsRoot, rel), 'utf8'));
    const pathItem = spec.paths?.[op.path];
    if (!pathItem) continue;
    const openapiOp = pathItem[op.httpMethod.toLowerCase()];
    if (!openapiOp || openapiOp.operationId !== op.operationId) continue;
    const { responseSchema } = extractOpTypes(openapiOp);
    if (!responseSchema) stillMissing += 1;
    break;
  }
}
console.log(`Operations still without extractable responseSchema (PT): ${stillMissing}`);
