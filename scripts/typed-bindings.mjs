/**
 * Generates OpenAPI model classes + typed client.api surfaces for all SDK languages.
 */
import fs from 'node:fs';
import path from 'node:path';
import { generateOpenApiModels } from './schema-codegen.mjs';
import {
  csharpType,
  discoverCsharpModels,
  discoverGoModels,
  discoverJavaModels,
  discoverPythonModels,
  elixirModelModule,
  elixirType,
  goType,
  javaType,
  phpType,
  pyType,
  refName,
  safeParamName,
  schemaToModelName,
} from './type-helpers.mjs';

export { schemaToModelName, refName } from './type-helpers.mjs';

function pickResponseSchemaFromContent(content) {
  if (!content) return null;
  const json =
    content['application/json']?.schema ?? content['application/problem+json']?.schema;
  if (json) {
    const resolved = resolveSchemaName(json);
    if (resolved) return resolved;
  }
  for (const block of Object.values(content)) {
    if (!block?.schema) continue;
    const resolved = resolveSchemaName(block.schema);
    if (resolved) return resolved;
  }
  return null;
}

function operationSchemaPrefix(operationId) {
  if (!operationId) return 'Ntf';
  const first = operationId.split('_')[0];
  if (first.startsWith('ntf') && first.length > 3) return `Ntf${first.slice(3)}`;
  return first;
}

function responseSchemaNameFromOperationId(operationId) {
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

function authorizeRedirectSchemaName(operationId) {
  return responseSchemaNameFromOperationId(operationId);
}

export function extractOpTypes(op) {
  const successCodes = ['200', '201', '202', '204', '302', 'default'];
  let responseSchema = null;
  for (const code of successCodes) {
    const response = op.responses?.[code];
    if (!response) continue;
    if (code === '204' && !response.content) {
      responseSchema = null;
      break;
    }
    const fromContent = pickResponseSchemaFromContent(response.content);
    if (fromContent) {
      responseSchema = fromContent;
      break;
    }
    if (code === '302' && response.headers?.Location?.schema) {
      responseSchema = schemaToModelName(authorizeRedirectSchemaName(op.operationId));
      break;
    }
  }

  const reqBody =
    op.requestBody?.content?.['application/json']?.schema ??
    op.requestBody?.content?.['application/problem+json']?.schema;
  const requestBodySchema = reqBody ? resolveSchemaName(reqBody) : null;

  return { responseSchema, requestBodySchema };
}

function resolveSchemaName(schema) {
  const s = unwrapSchemaForResolve(schema);
  if (!s) return null;
  if (s.$ref) return schemaToModelName(refName(s.$ref));
  if (s.allOf?.length) {
    for (const part of s.allOf) {
      const name = resolveSchemaName(part);
      if (name) return name;
    }
  }
  if (s.oneOf?.length === 1) return resolveSchemaName(s.oneOf[0]);
  if (s.anyOf?.length === 1) return resolveSchemaName(s.anyOf[0]);
  return null;
}

function unwrapSchemaForResolve(schema) {
  if (!schema) return schema;
  if (schema.$ref) return schema;
  if (schema.allOf?.length === 1) return unwrapSchemaForResolve(schema.allOf[0]);
  return schema;
}

export function bundleOpenApi(manifest, docsRoot) {
  const bundled = {
    openapi: '3.1.0',
    info: { title: 'Notifique API', version: '1.0.0' },
    paths: {},
    components: { schemas: {}, responses: {}, parameters: {} },
  };
  for (const rel of manifest.specs) {
    const spec = JSON.parse(fs.readFileSync(path.join(docsRoot, rel), 'utf8'));
    Object.assign(bundled.paths, spec.paths ?? {});
    if (spec.components?.schemas) Object.assign(bundled.components.schemas, spec.components.schemas);
    if (spec.components?.responses) Object.assign(bundled.components.responses, spec.components.responses);
    if (spec.components?.parameters) Object.assign(bundled.components.parameters, spec.components.parameters);
  }
  return bundled;
}

function nsClassName(parts, helpers) {
  return parts.map((p) => helpers.toPascal(p)).join('') + 'Namespace';
}

function opPath(parts, methodName) {
  return [...parts, methodName].join('.');
}

function jsonModelName(op, models) {
  if (!op.responseSchema || op.responseKind === 'binary' || op.responseKind === 'text') return null;
  return models.has(op.responseSchema) ? op.responseSchema : null;
}

function goReturnType(op, goModels) {
  if (op.responseKind === 'binary') return '[]byte';
  if (op.responseKind === 'text') return 'string';
  const model = jsonModelName(op, goModels);
  if (model) return `*openapimodels.${model}`;
  return 'json.RawMessage';
}

function emitPythonApi(tree, operations, helpers) {
  const { toSnake } = helpers;
  const modelMap = discoverPythonModels(helpers.pythonModelsDir);
  const usedModels = new Set();
  for (const op of operations) {
    if (op.responseSchema) usedModels.add(schemaToModelName(op.responseSchema));
    if (op.requestBodySchema) usedModels.add(schemaToModelName(op.requestBodySchema));
  }

  const importLines = [
    '"""Auto-generated typed OpenAPI client — do not edit manually."""',
    'from __future__ import annotations',
    'from typing import Any, Dict, List, Optional',
    'from notifique.http_transport import HttpTransport',
  ];
  for (const className of [...usedModels].sort()) {
    const mod = modelMap.get(className);
    if (mod) importLines.push(`from notifique.generated.models.models.${mod} import ${className}`);
  }

  const classBlocks = [];

  function emitQueryBuild(queryParams, indent = '        ') {
    if (!queryParams?.length) return [];
    const lines = [`${indent}query: Dict[str, Any] = {}`];
    for (const qp of queryParams) {
      const n = toSnake(safeParamName(qp.name));
      lines.push(`${indent}if ${n} is not None: query["${qp.name}"] = ${n}`);
    }
    return lines;
  }

  function emitClass(parts, node) {
    const cls = nsClassName(parts, helpers);
    const lines = [`class ${cls}:`, '    def __init__(self, http: HttpTransport) -> None:', '        self._http = http'];
    for (const child of Object.keys(node.children)) {
      lines.push(`        self.${child} = ${nsClassName([...parts, child], helpers)}(http)`);
    }
    for (const op of node.ops) {
      const method = op.httpMethod.toLowerCase();
      const params = ['self'];
      if (op.pathParams.length === 1) params.push(`${toSnake(op.pathParams[0])}: str`);
      else if (op.pathParams.length > 1) params.push('path_params: Dict[str, str]');
      for (const qp of op.queryParams ?? []) {
        params.push(`${toSnake(safeParamName(qp.name))}: ${pyType(qp.schema)} = None`);
      }
      const bodyType = op.requestBodySchema ? schemaToModelName(op.requestBodySchema) : null;
      if (method !== 'get' && method !== 'delete') {
        if (bodyType) params.push(`body: Optional[${bodyType}] = None`);
        else params.push('body: Optional[Any] = None');
        params.push('idempotency_key: Optional[str] = None');
      }
      const ret = op.responseSchema ? schemaToModelName(op.responseSchema) : 'Any';
      const bodyLines = [];
      bodyLines.push(...emitQueryBuild(op.queryParams));
      const queryArg = op.queryParams?.length ? 'query=query' : 'query=None';
      let call;
      const extra =
        method !== 'get' && method !== 'delete' ? `, body=body, idempotency_key=idempotency_key` : '';
      if (op.pathParams.length === 1) {
        const p = toSnake(op.pathParams[0]);
        const url = op.urlTemplate.replace(`{${op.pathParams[0]}}`, `{${p}}`);
        call = `self._http.request("${op.httpMethod}", f"${url}", path_params={${p}: ${p}}, ${queryArg}${extra})`;
      } else if (op.pathParams.length > 1) {
        call = `self._http.request("${op.httpMethod}", "${op.urlTemplate}", path_params=path_params, ${queryArg}${extra})`;
      } else {
        call = `self._http.request("${op.httpMethod}", "${op.urlTemplate}", ${queryArg}${extra})`;
      }
      lines.push(`    def ${toSnake(op.methodName)}(${params.join(', ')}) -> ${ret}:`, ...bodyLines, `        raw = ${call}`);
      if (ret !== 'Any') {
        lines.push(`        return ${ret}.model_validate(raw)`);
      } else {
        lines.push('        return raw');
      }
    }
    classBlocks.push(lines.join('\n'));
    for (const [child, childNode] of Object.entries(node.children)) {
      emitClass([...parts, child], childNode);
    }
  }

  for (const [ns, node] of Object.entries(tree)) emitClass([ns], node);

  const initLines = Object.keys(tree).map((ns) => `        self.${ns} = ${nsClassName([ns], helpers)}(http)`);
  return [
    ...importLines,
    '',
    ...classBlocks,
    '',
    'class GeneratedApi:',
    '    def __init__(self, http: HttpTransport) -> None:',
    ...initLines,
    '',
    'def create_generated_api(http: HttpTransport) -> GeneratedApi:',
    '    return GeneratedApi(http)',
    '',
  ].join('\n');
}

function emitGoTypedApi(tree, helpers) {
  const { toPascal, goModels } = helpers;
  const lines = [
    'package notifique',
    '',
    'import (',
    '	"encoding/json"',
    '	"fmt"',
    '',
    '	"github.com/notifique-dev/notifique-sdk/packages/sdk-go/openapimodels"',
    ')',
    'type TypedAPI struct { client *Notifique }',
    '',
    'func newTypedAPI(c *Notifique) *TypedAPI { return &TypedAPI{client: c} }',
    '',
    'func ensureOpts(opts *DynamicRequestOptions) *DynamicRequestOptions {',
    '	if opts == nil { return &DynamicRequestOptions{} }',
    '	return opts',
    '}',
    '',
  ];

  function goQueryType(schema) {
    const t = goType(schema);
    if (t === 'int') return '*int';
    if (t === 'float64') return '*float64';
    if (t === 'bool') return '*bool';
    if (t === 'string') return '*string';
    return '*string';
  }

  function emitNamespace(parts, node) {
    const name = nsClassName(parts, helpers).replace('Namespace', 'API');
    lines.push(`type ${name} struct { api *TypedAPI }`);
    if (parts.length === 1) {
      lines.push(`func (t *TypedAPI) ${toPascal(parts[0])}() *${name} { return &${name}{api: t} }`);
    }
    for (const op of node.ops) {
      const retModel = jsonModelName(op, goModels);
      const retType = goReturnType(op, goModels);
      const params = [];
      if (op.pathParams.length === 1) params.push(`${op.pathParams[0]} string`);
      for (const qp of op.queryParams ?? []) {
        const p = safeParamName(qp.name);
        params.push(`${p} ${goQueryType(qp.schema)}`);
      }
      const method = op.httpMethod.toLowerCase();
      if (method !== 'get' && method !== 'delete' && op.requestBodySchema) {
        params.push(`body *openapimodels.${schemaToModelName(op.requestBodySchema)}`);
      }
      params.push('opts *DynamicRequestOptions');
      lines.push(`func (n *${name}) ${toPascal(op.methodName)}(${params.join(', ')}) (${retType}, error) {`);
      lines.push('	opts = ensureOpts(opts)');
      if (op.queryParams?.length) {
        lines.push('	if opts.Query == nil { opts.Query = map[string]string{} }');
        for (const qp of op.queryParams) {
          const p = safeParamName(qp.name);
          lines.push(`	if ${p} != nil { opts.Query["${qp.name}"] = fmt.Sprint(*${p}) }`);
        }
      }
      if (method !== 'get' && method !== 'delete' && op.requestBodySchema) {
        lines.push('	if body != nil { opts.Body = body }');
      }
      if (op.pathParams.length === 1) {
        lines.push(`	opts.PathParams = map[string]string{"${op.pathParams[0]}": ${op.pathParams[0]}}`);
      }
      lines.push(`	raw, err := n.api.client.DynamicApi.Call("${opPath(parts, op.methodName)}", *opts)`);
      if (retType === 'string') {
        lines.push('	if err != nil { return "", err }');
      } else if (retType === '[]byte') {
        lines.push('	if err != nil { return nil, err }');
      } else {
        lines.push('	if err != nil { return nil, err }');
      }
      if (retModel) {
        lines.push(`	var out openapimodels.${retModel}`);
        lines.push('	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }');
        lines.push('	return &out, nil');
      } else if (op.responseKind === 'text') {
        lines.push('	return string(raw), nil');
      } else if (op.responseKind === 'binary') {
        lines.push('	return []byte(raw), nil');
      } else {
        lines.push('	return raw, nil');
      }
      lines.push('}');
      lines.push('');
    }
    for (const [child, childNode] of Object.entries(node.children)) {
      const childName = nsClassName([...parts, child], helpers).replace('Namespace', 'API');
      lines.push(`func (n *${name}) ${toPascal(child)}() *${childName} { return &${childName}{api: n.api} }`);
      emitNamespace([...parts, child], childNode);
    }
  }

  for (const [ns, node] of Object.entries(tree)) emitNamespace([ns], node);
  return lines.join('\n');
}

function javaSafeFieldName(name) {
  const keywords = new Set([
    'public', 'private', 'protected', 'class', 'default', 'int', 'void', 'new',
    'return', 'if', 'else', 'for', 'while', 'do', 'switch', 'case', 'break',
    'continue', 'throw', 'try', 'catch', 'finally', 'this', 'super', 'import',
    'package', 'static', 'final', 'abstract', 'interface', 'extends', 'implements',
    'enum', 'assert', 'goto', 'const', 'true', 'false', 'null',
  ]);
  return keywords.has(name) ? `${name}Ns` : name;
}

function javaReturnType(op, javaModels) {
  if (op.responseKind === 'binary' || op.responseKind === 'text') return 'String';
  const model = jsonModelName(op, javaModels);
  return model ?? 'JsonNode';
}

function csharpReturnType(op, csModels) {
  if (op.responseKind === 'binary') return 'byte[]';
  if (op.responseKind === 'text') return 'string';
  const model = jsonModelName(op, csModels);
  return model ?? 'JsonElement';
}

function emitJavaTypedApi(tree, helpers) {
  const { toPascal, schemaToModelName, javaModels } = helpers;
  const lines = [
    'package dev.notifique.sdk.generated;',
    '',
    'import com.fasterxml.jackson.databind.JsonNode;',
    'import dev.notifique.sdk.openapi.models.*;',
    'import java.util.Map;',
    '',
    'public final class TypedGeneratedApi {',
    '    private final GeneratedApiTransport transport;',
    '    private final com.fasterxml.jackson.databind.ObjectMapper objectMapper;',
    '',
    '    public TypedGeneratedApi(String apiKey, String baseUrl, dev.notifique.sdk.HttpExecutor httpExecutor, com.fasterxml.jackson.databind.ObjectMapper objectMapper) {',
    '        this.transport = new GeneratedApiTransport(apiKey, GeneratedApiTransport.normalizeApiBaseUrl(baseUrl), httpExecutor, objectMapper);',
    '        this.objectMapper = objectMapper;',
    '    }',
    '',
  ];

  function emitClass(parts, node, indent) {
    const sp = ' '.repeat(indent);
    const cls = nsClassName(parts, helpers).replace('Namespace', 'Api');
    lines.push(`${sp}public static final class ${cls} {`);
    lines.push(`${sp}    private final TypedGeneratedApi root;`);
    const childFields = [];
    for (const [child, childNode] of Object.entries(node.children)) {
      const childCls = nsClassName([...parts, child], helpers).replace('Namespace', 'Api');
      childFields.push({ child, childCls, childNode });
      lines.push(`${sp}    public final ${childCls} ${javaSafeFieldName(child)};`);
    }
    lines.push(`${sp}    ${cls}(TypedGeneratedApi root) {`);
    lines.push(`${sp}        this.root = root;`);
    for (const { child, childCls } of childFields) {
      lines.push(`${sp}        this.${javaSafeFieldName(child)} = new ${childCls}(root);`);
    }
    lines.push(`${sp}    }`);
    for (const { childNode, child } of childFields.map((f) => ({ childNode: f.childNode, child: f.child }))) {
      emitClass([...parts, child], childNode, indent + 4);
    }
    for (const op of node.ops) {
      const retModel = jsonModelName(op, javaModels);
      const ret = javaReturnType(op, javaModels);
      const params = [];
      if (op.pathParams.length === 1) params.push(`String ${op.pathParams[0]}`);
      for (const qp of op.queryParams ?? []) {
        const p = safeParamName(qp.name);
        params.push(`${javaType(qp.schema)} ${p}`);
      }
      const method = op.httpMethod.toLowerCase();
      if (method !== 'get' && method !== 'delete' && op.requestBodySchema) {
        params.push(`${schemaToModelName(op.requestBodySchema)} body`);
      }
      params.push('ApiRequestOptions options');
      lines.push(`${sp}    public ${ret} ${op.methodName}(${params.join(', ')}) throws java.io.IOException {`);
      lines.push(`${sp}        options = options != null ? options : ApiRequestOptions.empty();`);
      lines.push(`${sp}        java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());`);
      for (const qp of op.queryParams ?? []) {
        const p = safeParamName(qp.name);
        lines.push(`${sp}        if (${p} != null) { query.put("${qp.name}", String.valueOf(${p})); }`);
      }
      lines.push(`${sp}        Object reqBody = ${method !== 'get' && method !== 'delete' && op.requestBodySchema ? 'body' : 'options.getBody()'};`);
      lines.push(`${sp}        options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();`);
      if (op.responseKind === 'binary' || op.responseKind === 'text') {
        if (op.pathParams.length === 1) {
          lines.push(`${sp}        return root.transport.requestRaw("${op.httpMethod}", "${op.urlTemplate}", Map.of("${op.pathParams[0]}", ${op.pathParams[0]}), options);`);
        } else {
          lines.push(`${sp}        return root.transport.requestRaw("${op.httpMethod}", "${op.urlTemplate}", Map.of(), options);`);
        }
      } else if (op.pathParams.length === 1) {
        lines.push(`${sp}        JsonNode node = root.transport.request("${op.httpMethod}", "${op.urlTemplate}", Map.of("${op.pathParams[0]}", ${op.pathParams[0]}), options);`);
        if (retModel) {
          lines.push(`${sp}        return root.objectMapper.treeToValue(node, ${retModel}.class);`);
        } else {
          lines.push(`${sp}        return node;`);
        }
      } else {
        lines.push(`${sp}        JsonNode node = root.transport.request("${op.httpMethod}", "${op.urlTemplate}", Map.of(), options);`);
        if (retModel) {
          lines.push(`${sp}        return root.objectMapper.treeToValue(node, ${retModel}.class);`);
        } else {
          lines.push(`${sp}        return node;`);
        }
      }
      lines.push(`${sp}    }`);
    }
    lines.push(`${sp}}`);
    lines.push('');
  }

  for (const [ns, node] of Object.entries(tree)) {
    const cls = nsClassName([ns], helpers).replace('Namespace', 'Api');
    lines.push(`    public final ${cls} ${javaSafeFieldName(ns)} = new ${cls}(this);`);
    emitClass([ns], node, 4);
  }
  lines.push('}');
  return lines.join('\n');
}

function csharpSafePropertyName(name) {
  const keywords = new Set(['public', 'private', 'protected', 'internal', 'class', 'default', 'new', 'return']);
  return keywords.has(name) ? `${name}Ns` : name;
}

function emitCSharpTypedApi(tree, helpers) {
  const { toPascal, schemaToModelName, csModels } = helpers;
  const lines = [
    'using System.Collections.Generic;',
    'using System.Text.Json;',
    'using System.Threading.Tasks;',
    'using Notifique.OpenApi.Models.Model;',
    '',
    'namespace Notifique.Generated;',
    '',
    'public sealed class TypedGeneratedApi',
    '{',
    '    internal readonly GeneratedApiTransport _transport;',
    '',
    '    public TypedGeneratedApi(string? apiKey, string baseUrl, System.Net.Http.HttpClient httpClient)',
    '    {',
    '        _transport = new GeneratedApiTransport(apiKey, GeneratedApiTransport.NormalizeApiBaseUrl(baseUrl), httpClient);',
  ];
  for (const ns of Object.keys(tree)) lines.push(`        ${csharpSafePropertyName(ns)} = new ${toPascal(ns)}Api(this);`);
  lines.push('    }');
  for (const ns of Object.keys(tree)) lines.push(`    public ${toPascal(ns)}Api ${csharpSafePropertyName(ns)} { get; }`);
  lines.push('');

  function emitClass(parts, node) {
    const cls = nsClassName(parts, helpers).replace('Namespace', 'Api');
    lines.push(`public sealed class ${cls}`, '{', '    private readonly TypedGeneratedApi _root;', `    internal ${cls}(TypedGeneratedApi root) => _root = root;`);
    for (const [child, childNode] of Object.entries(node.children)) {
      const childCls = nsClassName([...parts, child], helpers).replace('Namespace', 'Api');
      lines.push(`    public ${childCls} ${child}() => new ${childCls}(_root);`);
      emitClass([...parts, child], childNode);
    }
    for (const op of node.ops) {
      const retModel = jsonModelName(op, csModels);
      const ret = csharpReturnType(op, csModels);
      const asyncName = toPascal(op.methodName) + 'Async';
      const params = [];
      if (op.pathParams.length === 1) params.push(`string ${op.pathParams[0]}`);
      for (const qp of op.queryParams ?? []) {
        const p = safeParamName(qp.name);
        params.push(`${csharpType(qp.schema).replace('?', '')}? ${p} = null`);
      }
      const method = op.httpMethod.toLowerCase();
      if (method !== 'get' && method !== 'delete' && op.requestBodySchema) {
        params.push(`${csharpType({ $ref: `#/components/schemas/${op.requestBodySchema}` }).replace('?', '')}? body = null`);
      }
      params.push('ApiRequestOptions? options = null');
      lines.push(`    public async Task<${ret}> ${asyncName}(${params.join(', ')})`);
      lines.push('    {');
      lines.push('        options ??= new ApiRequestOptions();');
      lines.push('        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();');
      for (const qp of op.queryParams ?? []) {
        const p = safeParamName(qp.name);
        lines.push(`        if (${p} != null) query["${qp.name}"] = ${p}.ToString()!;`);
      }
      lines.push(`        options = new ApiRequestOptions { Query = query, Body = ${method !== 'get' && method !== 'delete' && op.requestBodySchema ? 'body' : 'options.Body'}, IdempotencyKey = options.IdempotencyKey };`);
      if (op.pathParams.length === 1) {
        lines.push(`        var pathParams = new Dictionary<string, string> { ["${op.pathParams[0]}"] = ${op.pathParams[0]} };`);
      } else {
        lines.push('        IReadOnlyDictionary<string, string>? pathParams = null;');
      }
      if (op.responseKind === 'binary') {
        lines.push(`        return await _root._transport.RequestBytesAsync("${op.httpMethod}", "${op.urlTemplate}", pathParams, options);`);
      } else if (op.responseKind === 'text') {
        lines.push(`        return await _root._transport.RequestRawAsync("${op.httpMethod}", "${op.urlTemplate}", pathParams, options);`);
      } else if (retModel) {
        lines.push(`        var json = await _root._transport.RequestAsync("${op.httpMethod}", "${op.urlTemplate}", pathParams, options);`);
        lines.push(`        return JsonSerializer.Deserialize<${retModel}>(json.GetRawText())!;`);
      } else {
        lines.push(`        return await _root._transport.RequestAsync("${op.httpMethod}", "${op.urlTemplate}", pathParams, options);`);
      }
      lines.push('    }');
    }
    lines.push('}');
    lines.push('');
  }

  for (const [ns, node] of Object.entries(tree)) emitClass([ns], node);
  lines.push('}');
  return lines.join('\n');
}

function emitPhpTypedApi(tree, helpers) {
  const { toPascal, schemaToModelName } = helpers;
  const classBlocks = [];

  function emitClass(parts, node) {
    const cls = nsClassName(parts, helpers).replace('Namespace', 'Api');
    const lines = [`final class ${cls} {`, '    public function __construct(private Notifique $client) {}'];
    for (const [child, childNode] of Object.entries(node.children)) {
      lines.push(`    public function ${child}(): ${nsClassName([...parts, child], helpers).replace('Namespace', 'Api')} { return new ${nsClassName([...parts, child], helpers).replace('Namespace', 'Api')}($this->client); }`);
      emitClass([...parts, child], childNode);
    }
    for (const op of node.ops) {
      const ret = op.responseSchema ? `\\Notifique\\OpenApi\\Model\\${schemaToModelName(op.responseSchema)}` : 'array';
      const params = [];
      if (op.pathParams.length === 1) params.push(`string $${op.pathParams[0]}`);
      for (const qp of op.queryParams ?? []) {
        const p = safeParamName(qp.name);
        params.push(`${phpType(qp.schema)} $${p} = null`);
      }
      const method = op.httpMethod.toLowerCase();
      if (method !== 'get' && method !== 'delete' && op.requestBodySchema) {
        params.push(`${phpType({ $ref: `#/components/schemas/${op.requestBodySchema}` })} $body = null`);
      }
      params.push('array $options = []');
      lines.push(`    /** @return ${ret} */`);
      lines.push(`    public function ${op.methodName}(${params.join(', ')}): array {`);
      lines.push('        $opts = $options;');
      if (op.queryParams?.length) {
        lines.push('        $opts[\'query\'] = $opts[\'query\'] ?? [];');
        for (const qp of op.queryParams) {
          const p = safeParamName(qp.name);
          lines.push(`        if ($${p} !== null) { $opts['query']['${qp.name}'] = $${p}; }`);
        }
      }
      if (method !== 'get' && method !== 'delete' && op.requestBodySchema) {
        lines.push('        if ($body !== null) { $opts[\'body\'] = $body; }');
      }
      if (op.pathParams.length === 1) {
        const p = op.pathParams[0];
        lines.push(`        $path = str_replace('{${p}}', Notifique::encodePathSegment($${p}), '${op.urlTemplate}');`);
        lines.push(`        return $this->client->apiRequest('${op.httpMethod}', $path, $options['body'] ?? null, $options);`);
      } else {
        lines.push(`        return $this->client->apiRequest('${op.httpMethod}', '${op.urlTemplate}', $options['body'] ?? null, $options);`);
      }
      lines.push('    }');
    }
    lines.push('}');
    classBlocks.push(lines.join('\n'));
  }

  for (const [ns, node] of Object.entries(tree)) emitClass([ns], node);

  const root = [
    '<?php',
    'namespace Notifique\\Generated;',
    'use Notifique\\Notifique;',
    '',
    'final class TypedGeneratedApi {',
    '    public function __construct(private Notifique $client) {}',
  ];
  for (const ns of Object.keys(tree)) {
    const cls = nsClassName([ns], helpers).replace('Namespace', 'Api');
    root.push(`    public function ${ns}(): ${cls} { return new ${cls}($this->client); }`);
  }
  root.push('}');
  return [...root, '', ...classBlocks].join('\n');
}

function emitElixirTypedApi(tree, helpers) {
  const { toPascal, toSnake } = helpers;
  const parts = [
    'defmodule Notifique.TypedApi do',
    '  @moduledoc """',
    '  API OpenAPI tipada — namespaces, query, body e retorno com `@spec` para Dialyzer/IDE.',
    '  Acesse via `Notifique.api(client)` após `Notifique.new/2`.',
    '  """',
    '',
    '  defstruct [:client]',
    '',
    '  @type t :: %__MODULE__{client: Notifique.t()}',
    '',
    '  @spec new(Notifique.t()) :: t()',
    '  def new(client), do: %__MODULE__{client: client}',
    '',
  ];

  function elixirRetType(op) {
    if (!op.responseSchema) return 'term()';
    return `Notifique.OpenApi.Model.${op.responseSchema}.t()`;
  }

  function elixirBodyType(op) {
    if (!op.requestBodySchema) return null;
    return `Notifique.OpenApi.Model.${op.requestBodySchema}.t()`;
  }

  function emitNamespace(node, modPath, indent, structName) {
    const sp = ' '.repeat(indent);

    for (const op of node.ops) {
      const fn = toSnake(op.methodName);
      const method = op.httpMethod.toLowerCase();
      const specParams = [`${structName}.t()`];
      const pathParams = op.pathParams ?? [];

      for (const p of pathParams) {
        specParams.push('String.t()');
      }
      for (const qp of op.queryParams ?? []) {
        const p = safeParamName(qp.name);
        specParams.push(`${p}: ${elixirType(qp.schema)} | nil`);
      }
      if (method !== 'get' && method !== 'delete') {
        const bodyType = elixirBodyType(op);
        if (bodyType) specParams.push(`body: ${bodyType} | nil`);
        else specParams.push('body: term() | nil');
        specParams.push('idempotency_key: String.t() | nil');
      }
      specParams.push('opts: keyword()');

      const recvArgs =
        pathParams.length > 0
          ? `%__MODULE__{api: %Notifique.TypedApi{client: client}}${pathParams.map((p) => ', ' + p).join('')}, opts \\\\ []`
          : '%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\\\ []';

      parts.push(`${sp}@spec ${fn}(${specParams.join(', ')}) :: {:ok, ${elixirRetType(op)}} | {:error, term()}`);
      parts.push(`${sp}def ${fn}(${recvArgs}) do`);

      if (pathParams.length === 1) {
        parts.push(`${sp}  opts = Keyword.put(opts, :path_params, %{"${pathParams[0]}" => ${pathParams[0]}})`);
      } else if (pathParams.length > 1) {
        parts.push(`${sp}  opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))`);
      }

      for (const qp of op.queryParams ?? []) {
        const p = safeParamName(qp.name);
        parts.push(
          `${sp}  opts = if Keyword.has_key?(opts, :${p}), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "${qp.name}", Keyword.get(opts, :${p}))), else: opts`,
        );
      }

      const dotted = `${modPath}.${op.methodName}`;
      parts.push(`${sp}  case Notifique.DynamicApi.call_operation(client, "${dotted}", opts) do`);
      if (op.responseSchema) {
        parts.push(`${sp}    {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("${op.responseSchema}", body)}`);
        parts.push(`${sp}    error -> error`);
      } else {
        parts.push(`${sp}    other -> other`);
      }
      parts.push(`${sp}  end`);
      parts.push(`${sp}end`);
      parts.push('');
    }

    for (const [child, childNode] of Object.entries(node.children)) {
      const childStruct = toPascal(child);
      parts.push(`${sp}@spec ${toSnake(child)}(t()) :: ${childStruct}.t()`);
      parts.push(`${sp}def ${toSnake(child)}(%__MODULE__{api: api}), do: Notifique.TypedApi.${modPath.split('.').map(toPascal).join('.')}.${childStruct}.new(api)`);
      parts.push('');
      parts.push(`${sp}defmodule ${childStruct} do`);
      parts.push(`${sp}  @moduledoc false`);
      parts.push(`${sp}  @type t :: %__MODULE__{api: Notifique.TypedApi.t()}`);
      parts.push(`${sp}  defstruct [:api]`);
      parts.push(`${sp}  @spec new(Notifique.TypedApi.t()) :: t()`);
      parts.push(`${sp}  def new(api), do: %__MODULE__{api: api}`);
      parts.push('');
      emitNamespace(childNode, `${modPath}.${child}`, indent + 2, childStruct);
      parts.push(`${sp}end`);
      parts.push('');
    }
  }

  for (const [ns, node] of Object.entries(tree)) {
    const nsStruct = toPascal(ns);
    parts.push(`  @spec ${toSnake(ns)}(t()) :: ${nsStruct}.t()`);
    parts.push(`  def ${toSnake(ns)}(%__MODULE__{} = api), do: Notifique.TypedApi.${nsStruct}.new(api)`);
    parts.push('');
    parts.push(`  defmodule ${nsStruct} do`);
    parts.push('    @moduledoc false');
    parts.push('    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}');
    parts.push('    defstruct [:api]');
    parts.push('    @spec new(Notifique.TypedApi.t()) :: t()');
    parts.push('    def new(api), do: %__MODULE__{api: api}');
    parts.push('');
    emitNamespace(node, ns, 4, nsStruct);
    parts.push('  end');
    parts.push('');
  }

  parts.push('end');

  return parts.join('\n');
}

export function writeTypedApiSurfaces({ root, tree, operations, helpers }) {
  const pyModelsDir = path.join(root, 'packages/sdk-python/notifique/generated/models/models');
  const goModels = discoverGoModels(path.join(root, 'packages/sdk-go/openapimodels'));
  const javaModels = discoverJavaModels(
    path.join(root, 'packages/sdk-java/src/main/java/com/notifique/sdk/openapi/models'),
  );
  const csModels = discoverCsharpModels(path.join(root, 'packages/sdk-dotnet/src/Notifique/OpenApi/Models'));
  const h = {
    ...helpers,
    pythonModelsDir: pyModelsDir,
    schemaToModelName,
    goModels,
    javaModels,
    csModels,
  };

  fs.writeFileSync(path.join(root, 'packages/sdk-python/notifique/generated/api.py'), emitPythonApi(tree, operations, h));
  fs.writeFileSync(path.join(root, 'packages/sdk-python/notifique/generated/__init__.py'), '');
  fs.writeFileSync(path.join(root, 'packages/sdk-go/typed_api.go'), emitGoTypedApi(tree, h));
  fs.writeFileSync(
    path.join(root, 'packages/sdk-java/src/main/java/com/notifique/sdk/generated/TypedGeneratedApi.java'),
    emitJavaTypedApi(tree, h)
  );
  fs.writeFileSync(
    path.join(root, 'packages/sdk-dotnet/src/Notifique/Generated/TypedGeneratedApi.cs'),
    emitCSharpTypedApi(tree, h)
  );
  fs.writeFileSync(path.join(root, 'packages/sdk-php/src/Generated/TypedGeneratedApi.php'), emitPhpTypedApi(tree, h));
  fs.writeFileSync(path.join(root, 'packages/sdk-elixir/lib/notifique/typed_api.ex'), emitElixirTypedApi(tree, h));
  fs.writeFileSync(
    path.join(root, 'packages/sdk-elixir/lib/notifique/generated_api.ex'),
    '# Auto-generated — conteúdo movido para `lib/notifique/typed_api.ex`.\n' +
      'defmodule Notifique.Generated.Api do\n  defdelegate new(client), to: Notifique.TypedApi\nend\n',
  );
}

export function generateTypedBindings({ root, tree, operations, execSync, helpers }) {
  generateOpenApiModels({ root, execSync });
  writeTypedApiSurfaces({ root, tree, operations, helpers });
  console.log('Generated OpenAPI models + typed client.api bindings for Python, Go, Java, .NET, PHP, Elixir.');
}
