# @notifique/core

Shared types, DTOs, and OpenAPI-generated schemas for Notifique SDKs — **v0.2.0**.

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk)

## What it provides

- **Legacy DTOs** — `SendPushParams`, `WhatsAppSendParams`, `SmsSendParams`, etc. (hand-written, aligned with OpenAPI)
- **OpenAPI registry** — `packages/core/src/generated/operations.json` (353 operations, 23 specs)
- **OpenAPI typed schemas** — `components` from all specs, exported as TypeScript modules:

```typescript
import type { PushComponents, WhatsAppComponents } from '@notifique/core';
// Per-spec: paths, components, operations from each of the 23 OpenAPI specs
// (generated into packages/core/src/generated/schemas/)
```

Specs covered include: whatsapp, sms, email, push, telegram, instagram, platform, oauth, contacts, automations, voice, rcs, and more (**23 total**, all generated).

## Typed `client.api` (Node / TypeScript)

Every generated method on `client.api` is wired to OpenAPI via `ApiPaths`:

```typescript
import { Notifique } from '@notifique/sdk-node';
import type { OpResponse } from '@notifique/core';

const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });
const res = await client.api.contacts.getV1Contacts({ query: { limit: 20 } });
type ContactsList = OpResponse<'/v1/contacts', 'get'>;
```

`options.query`, `options.body`, and `pathParams` are inferred per operation. Regenerate after spec changes: `npm run generate`.

## Push canonical contract

`SendPushParams` uses **`to` + `type` + `payload`** (not `title`/`body` at root). Responses use **`data.messageIds`** (not `pushIds`):

```typescript
import type { SendPushParams, SendPushResponse } from '@notifique/core';

const params: SendPushParams = {
  to: ['device-id'],
  type: 'push',
  payload: { title: 'Hi', body: 'There' },
};
// SendPushResponse.data.messageIds
```

## Regeneration

Bindings are generated from OpenAPI specs in [notifique-docs](https://github.com/notifique-dev/notifique-docs):

```bash
# from notifique-sdk root (requires ../notifique-docs)
npm run generate
npm test
```

Artifacts:

- `src/generated/operations.json` — operation registry (353 ops)
- `src/generated/schemas/*.ts` — typed `components` per spec
- `packages/sdk-node/src/generated/api.ts` — TypeScript client (reference implementation)

## Used by

| Package | Role |
|---------|------|
| `@notifique/sdk-node` | Re-exports all types + generated `api` client |
| Other language SDKs | Copy `operations.json`; legacy DTOs mirrored per language |

**Client-side push** SDKs live in [notifique-dev/notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks).
