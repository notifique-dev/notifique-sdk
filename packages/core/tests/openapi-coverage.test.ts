import fs from 'node:fs';
import path from 'node:path';

const operations = JSON.parse(
  fs.readFileSync(path.join(__dirname, '../src/generated/operations.json'), 'utf8')
);

function collectMethods(node: Record<string, unknown>, prefix = ''): string[] {
  const out: string[] = [];
  for (const [key, value] of Object.entries(node)) {
    if (key === 'http') continue;
    if (typeof value === 'function') {
      out.push(prefix ? `${prefix}.${key}` : key);
    } else if (value && typeof value === 'object') {
      out.push(...collectMethods(value as Record<string, unknown>, prefix ? `${prefix}.${key}` : key));
    }
  }
  return out;
}

describe('OpenAPI coverage', () => {
  it('registry has 353 operations', () => {
    expect(operations.count).toBe(353);
    expect(operations.operations.length).toBe(353);
  });

  it('generated client exposes every registry operation', () => {
    const { createGeneratedApi } = require('../../sdk-node/src/generated/api');
    const mockHttp = { request: jest.fn() };
    const api = createGeneratedApi(mockHttp);

    const generatedOps = operations.operations.map(
      (op: { namespaces: string[]; methodName: string }) => [...op.namespaces, op.methodName].join('.')
    );

    const available = collectMethods(api as Record<string, unknown>);
    const missing = generatedOps.filter((op: string) => !available.includes(op));
    expect(missing).toEqual([]);
  });
});
