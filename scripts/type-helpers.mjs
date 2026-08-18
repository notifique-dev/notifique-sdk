/**
 * OpenAPI schema → language type helpers for typed client.api generation.
 */
import fs from 'node:fs';
import path from 'node:path';

export function safeParamName(name) {
  const reserved = new Set(['type', 'class', 'public', 'default', 'end', 'after', 'new', 'return', 'event']);
  if (reserved.has(name)) return `${name}Param`;
  return name;
}

export function refName(ref) {
  if (!ref || typeof ref !== 'string') return null;
  const m = ref.match(/#\/components\/schemas\/(.+)$/);
  return m ? m[1] : null;
}

export function schemaToModelName(schemaRef) {
  if (!schemaRef) return null;
  const joined = schemaRef.split('_').join('');
  let name = joined;
  if (name.startsWith('ntf') && name.length > 3) {
    name = `Ntf${name.slice(3)}`;
  }
  if (name.length > 0 && name[0] >= 'a' && name[0] <= 'z') {
    name = name[0].toUpperCase() + name.slice(1);
  }
  return name;
}

export function discoverPythonModels(modelsDir) {
  const byClass = new Map();
  if (!fs.existsSync(modelsDir)) return byClass;
  for (const file of fs.readdirSync(modelsDir)) {
    if (!file.endsWith('.py') || file === '__init__.py') continue;
    const content = fs.readFileSync(path.join(modelsDir, file), 'utf8');
    const m = content.match(/^class (\w+)\(/m);
    if (m) byClass.set(m[1], file.replace(/\.py$/, ''));
  }
  return byClass;
}

function readFirstMatch(filePath, pattern) {
  const content = fs.readFileSync(filePath, 'utf8');
  const m = content.match(pattern);
  return m ? m[1] : null;
}

export function discoverGoModels(modelsDir) {
  const set = new Set();
  if (!fs.existsSync(modelsDir)) return set;
  for (const file of fs.readdirSync(modelsDir)) {
    if (!file.endsWith('.go') || file === 'utils.go') continue;
    const name = readFirstMatch(path.join(modelsDir, file), /^type (\w+) struct/m);
    if (name) set.add(name);
  }
  return set;
}

export function discoverJavaModels(modelsDir) {
  const set = new Set();
  if (!fs.existsSync(modelsDir)) return set;
  for (const file of fs.readdirSync(modelsDir)) {
    if (!file.endsWith('.java')) continue;
    const name = readFirstMatch(path.join(modelsDir, file), /^public class (\w+)/m);
    if (name) set.add(name);
  }
  return set;
}

export function discoverCsharpModels(modelsDir) {
  const set = new Set();
  if (!fs.existsSync(modelsDir)) return set;
  for (const file of fs.readdirSync(modelsDir)) {
    if (!file.endsWith('.cs')) continue;
    set.add(file.replace(/\.cs$/, ''));
  }
  return set;
}

export function getSchemaByModelName(schemas, modelName) {
  if (!schemas || !modelName) return null;
  if (schemas[modelName]) return schemas[modelName];
  for (const [key, schema] of Object.entries(schemas)) {
    if (schemaToModelName(key) === modelName) return schema;
  }
  return null;
}

export function responseKindFromSchema(schema) {
  if (!schema) return 'json';
  if (schema.type === 'string' && schema.format === 'binary') return 'binary';
  if (schema.type === 'string') return 'text';
  return 'json';
}

function unwrapSchema(schema) {
  if (!schema) return schema;
  if (schema.$ref) return { $ref: schema.$ref };
  if (schema.allOf?.length === 1) return unwrapSchema(schema.allOf[0]);
  return schema;
}

export function extractQueryParams(op) {
  const seen = new Set();
  const params = [];
  for (const p of op.parameters ?? []) {
    if (p.in !== 'query') continue;
    const key = p.name.replace(/([A-Z])/g, '_$1').replace(/-/g, '_').toLowerCase().replace(/^_/, '');
    if (seen.has(key)) continue;
    seen.add(key);
    params.push({
      name: p.name,
      required: Boolean(p.required),
      schema: unwrapSchema(p.schema),
    });
  }
  return params;
}

export function pyType(schema, optional = true) {
  const s = unwrapSchema(schema);
  if (!s) return optional ? 'Optional[Any]' : 'Any';
  if (s.$ref) {
    const name = schemaToModelName(refName(s.$ref));
    return optional ? `Optional[${name}]` : name;
  }
  if (s.type === 'integer') return optional ? 'Optional[int]' : 'int';
  if (s.type === 'number') return optional ? 'Optional[float]' : 'float';
  if (s.type === 'boolean') return optional ? 'Optional[bool]' : 'bool';
  if (s.type === 'string') return optional ? 'Optional[str]' : 'str';
  if (s.type === 'array') {
    const inner = pyType(s.items, false);
    return optional ? `Optional[List[${inner}]]` : `List[${inner}]`;
  }
  return optional ? 'Optional[Any]' : 'Any';
}

export function goType(schema) {
  const s = unwrapSchema(schema);
  if (!s) return 'interface{}';
  if (s.$ref) return `*openapimodels.${schemaToModelName(refName(s.$ref))}`;
  if (s.type === 'integer') return 'int';
  if (s.type === 'number') return 'float64';
  if (s.type === 'boolean') return 'bool';
  if (s.type === 'string') return 'string';
  if (s.type === 'array') return `[]${goType(s.items)}`;
  return 'interface{}';
}

export function javaType(schema) {
  const s = unwrapSchema(schema);
  if (!s) return 'JsonNode';
  if (s.$ref) return schemaToModelName(refName(s.$ref));
  if (s.type === 'integer') return 'Integer';
  if (s.type === 'number') return 'Double';
  if (s.type === 'boolean') return 'Boolean';
  if (s.type === 'string') return 'String';
  if (s.type === 'array') return 'JsonNode';
  return 'JsonNode';
}

export function csharpType(schema) {
  const s = unwrapSchema(schema);
  if (!s) return 'JsonElement';
  if (s.$ref) return `Notifique.OpenApi.Models.Model.${schemaToModelName(refName(s.$ref))}`;
  if (s.type === 'integer') return 'int?';
  if (s.type === 'number') return 'double?';
  if (s.type === 'boolean') return 'bool?';
  if (s.type === 'string') return 'string?';
  if (s.type === 'array') return 'JsonElement';
  return 'JsonElement';
}

export function phpType(schema) {
  const s = unwrapSchema(schema);
  if (!s) return 'array';
  if (s.$ref) return `\\Notifique\\OpenApi\\Model\\${schemaToModelName(refName(s.$ref))}`;
  if (s.type === 'integer') return '?int';
  if (s.type === 'number') return '?float';
  if (s.type === 'boolean') return '?bool';
  if (s.type === 'string') return '?string';
  return 'array';
}

export function elixirType(schema) {
  const s = unwrapSchema(schema);
  if (!s) return 'term()';
  if (s.$ref) {
    const mod = schemaToModelName(refName(s.$ref));
    return `Notifique.OpenApi.Model.${mod}.t()`;
  }
  if (s.type === 'integer') return 'integer()';
  if (s.type === 'number') return 'float()';
  if (s.type === 'boolean') return 'boolean()';
  if (s.type === 'string') return 'String.t()';
  if (s.type === 'array') return 'list()';
  return 'term()';
}

export function elixirModelModule(schemaRef) {
  return `Notifique.OpenApi.Model.${schemaToModelName(schemaRef)}`;
}
