/**
 * Smoke test against production API (https://api.notifique.dev).
 * Public endpoints always run. Authenticated checks require NOTIFIQUE_API_KEY.
 *
 * Usage:
 *   NOTIFIQUE_API_KEY=sk_test_... npm run smoke:prod
 */
const BASE = process.env.NOTIFIQUE_BASE_URL ?? 'https://api.notifique.dev';
const API_KEY = process.env.NOTIFIQUE_API_KEY?.trim();

const results = [];

async function check(name, fn) {
  try {
    await fn();
    results.push({ name, ok: true });
    console.log(`✓ ${name}`);
  } catch (err) {
    const message = err instanceof Error ? err.message : String(err);
    results.push({ name, ok: false, message });
    console.error(`✗ ${name}: ${message}`);
  }
}

async function fetchJson(url, options = {}) {
  const res = await fetch(url, options);
  const text = await res.text();
  let body;
  try {
    body = text ? JSON.parse(text) : null;
  } catch {
    body = text;
  }
  if (!res.ok) {
    throw new Error(`${res.status} ${res.statusText} — ${typeof body === 'object' ? JSON.stringify(body) : body}`);
  }
  return body;
}

await check('GET /.well-known/jwks.json', async () => {
  const data = await fetchJson(`${BASE}/.well-known/jwks.json`);
  if (!data || typeof data !== 'object') throw new Error('invalid JSON');
});

await check('GET /.well-known/oauth-authorization-server', async () => {
  const data = await fetchJson(`${BASE}/.well-known/oauth-authorization-server`);
  if (!data?.issuer) throw new Error('missing issuer');
});

await check('GET /.well-known/oauth-protected-resource', async () => {
  const data = await fetchJson(`${BASE}/.well-known/oauth-protected-resource`);
  if (!data || typeof data !== 'object') throw new Error('invalid JSON');
});

if (API_KEY) {
  const auth = { Authorization: `Bearer ${API_KEY}` };

  await check('GET /v1/contacts (auth)', async () => {
    const data = await fetchJson(`${BASE}/v1/contacts?limit=1`, { headers: auth });
    if (data?.success !== true) throw new Error('expected success:true');
  });

  await check('GET /v1/oauth/apps (auth)', async () => {
    const data = await fetchJson(`${BASE}/v1/oauth/apps`, { headers: auth });
    if (data?.success !== true) throw new Error('expected success:true');
  });

  await check('GET /v1/push/apps (auth)', async () => {
    const data = await fetchJson(`${BASE}/v1/push/apps`, { headers: auth });
    if (data?.success !== true) throw new Error('expected success:true');
  });
} else {
  console.log('— Skipping authenticated checks (set NOTIFIQUE_API_KEY for full smoke)');
}

const failed = results.filter((r) => !r.ok);
if (failed.length) {
  console.error(`\nSmoke failed: ${failed.length}/${results.length}`);
  process.exit(1);
}
console.log(`\nSmoke passed: ${results.length}/${results.length}`);
