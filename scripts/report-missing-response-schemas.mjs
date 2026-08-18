/**
 * Inventário de operações sem responseSchema tipado no registry.
 * Run: node scripts/report-missing-response-schemas.mjs
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

const HTTP_METHODS = ['get', 'post', 'put', 'patch', 'delete', 'head', 'options'];

function categorize(op) {
  for (const rel of manifest.specs) {
    const spec = JSON.parse(fs.readFileSync(path.join(docsRoot, rel), 'utf8'));
    const pathItem = spec.paths?.[op.path];
    if (!pathItem) continue;
    const openapiOp = pathItem[op.httpMethod.toLowerCase()];
    if (!openapiOp) continue;

    const codes = Object.keys(openapiOp.responses ?? {});
    const success = codes.filter((c) => c === 'default' || (Number(c) >= 200 && Number(c) < 300));

    if (success.length === 0) return { reason: 'sem_resposta_sucesso', codes };

    for (const code of ['200', '201', '202', '204', 'default']) {
      const resp = openapiOp.responses?.[code];
      if (!resp) continue;
      if (code === '204' && !resp.content) return { reason: '204_sem_body', codes: success };
      const content = resp.content ?? {};
      const types = Object.keys(content);
      if (types.length === 0) return { reason: 'resposta_sem_content', codes: success, code };
      const jsonSchema =
        content['application/json']?.schema ?? content['application/problem+json']?.schema;
      if (!jsonSchema) return { reason: 'content_nao_json', codes: success, code, contentTypes: types };
      const { responseSchema } = extractOpTypes(openapiOp);
      if (!responseSchema) {
        return { reason: 'schema_inline_ou_complexo', codes: success, code, schema: jsonSchema };
      }
      return { reason: 'tipado', codes: success, responseSchema };
    }

    return { reason: 'sem_resposta_mapeada', codes: success };
  }

  return { reason: 'path_nao_encontrado_no_spec' };
}

const missing = operations.filter((op) => !op.responseSchema);
const byReason = {};

for (const op of missing) {
  const cat = categorize(op);
  const key = cat.reason;
  if (!byReason[key]) byReason[key] = [];
  byReason[key].push({
    method: op.httpMethod,
    path: op.path,
    operationId: op.operationId,
    namespaces: op.namespaces.join('.'),
    methodName: op.methodName,
    ...cat,
  });
}

const report = {
  generatedAt: new Date().toISOString(),
  totalOperations: operations.length,
  withResponseSchema: operations.length - missing.length,
  withoutResponseSchema: missing.length,
  byReason: Object.fromEntries(
    Object.entries(byReason).map(([reason, items]) => [reason, { count: items.length, operations: items }]),
  ),
};

const outDir = path.join(root, 'packages/core/src/generated');
fs.writeFileSync(path.join(outDir, 'missing-response-schemas.json'), JSON.stringify(report, null, 2));

console.log(`Operações: ${report.totalOperations}`);
console.log(`Com responseSchema: ${report.withResponseSchema}`);
console.log(`Sem responseSchema: ${report.withoutResponseSchema}`);
for (const [reason, { count }] of Object.entries(report.byReason)) {
  console.log(`  - ${reason}: ${count}`);
}
console.log(`Relatório: packages/core/src/generated/missing-response-schemas.json`);
