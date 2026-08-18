/**
 * Adiciona `success: boolean` em schemas de resposta vazios (OpenAPI generator ignora objetos sem properties).
 */
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const root = path.join(path.dirname(fileURLToPath(import.meta.url)), '..');
const manifest = JSON.parse(fs.readFileSync(path.join(root, 'openapi/spec-manifest.json'), 'utf8'));
const docsRoot = path.resolve(root, manifest.docsRoot);

const SUCCESS_PROP = {
  success: { type: 'boolean', example: true },
};

function isEmptyObjectSchema(schema) {
  return (
    schema?.type === 'object' &&
    !schema.properties &&
    !schema.allOf &&
    !schema.oneOf &&
    !schema.anyOf
  );
}

function fixSpec(filePath) {
  const spec = JSON.parse(fs.readFileSync(filePath, 'utf8'));
  const schemas = spec.components?.schemas ?? {};
  let fixed = 0;
  for (const schema of Object.values(schemas)) {
    if (isEmptyObjectSchema(schema)) {
      schema.properties = { ...SUCCESS_PROP };
      fixed += 1;
    }
  }
  if (fixed > 0) {
    fs.writeFileSync(filePath, JSON.stringify(spec, null, 2) + '\n');
  }
  return fixed;
}

let total = 0;
for (const locale of ['', 'en/', 'es/']) {
  for (const rel of manifest.specs) {
    const filePath = path.join(docsRoot, locale, rel);
    if (!fs.existsSync(filePath)) continue;
    const n = fixSpec(filePath);
    if (n > 0) console.log(`Fixed ${n} empty schemas in ${locale}${rel}`);
    total += n;
  }
}
console.log(`Total empty schemas fixed: ${total}`);
