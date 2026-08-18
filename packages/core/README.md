# @notifique/core

Shared types, DTOs, and OpenAPI-generated schemas for Notifique SDKs — **v0.2.1**.

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/core) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

---

Tipos compartilhados, DTOs e schemas OpenAPI gerados para os SDKs Notifique — **v0.2.1**.

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/core) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

## Installation

```bash
npm install @notifique/core
```

Used by `@notifique/sdk-node` and as the schema source for all language SDKs.

## Instalação

```bash
npm install @notifique/core
```

Usado por `@notifique/sdk-node` e como fonte de schemas para todos os SDKs.

## What it provides

- **Legacy DTOs** — `SendPushParams`, `WhatsAppSendParams`, `SmsSendParams`, etc.
- **OpenAPI registry** — 353 operations, 23 specs (`operations.json`)
- **Typed schemas** — `components` per spec, `OpResponse`, `OpRequestBody`, `OpQuery`, `OpPathParams`

## O que oferece

- **DTOs legados** — `SendPushParams`, `WhatsAppSendParams`, `SmsSendParams`, etc.
- **Registry OpenAPI** — 353 operações, 23 specs (`operations.json`)
- **Schemas tipados** — `components` por spec, `OpResponse`, `OpRequestBody`, `OpQuery`, `OpPathParams`

## Channel contracts (examples)

These DTOs mirror the eight messaging channels. Use `@notifique/sdk-node` to call the API.

### SMS

```typescript
import type { SmsSendParams } from '@notifique/core';

const sms: SmsSendParams = { to: ['5511999999999'], message: 'Hello SMS!' };
```

### Enviar SMS

```typescript
const sms: SmsSendParams = { to: ['5511999999999'], message: 'Olá SMS!' };
```

### Push (canonical)

`to` + `type` + `payload` → `data.messageIds` (not `pushIds`).

```typescript
import type { SendPushParams, SendPushResponse } from '@notifique/core';

const params: SendPushParams = {
  to: ['device-id'],
  type: 'push',
  payload: { title: 'Hi', body: 'There' },
};
```

### Push (canônico)

`to` + `type` + `payload` → `data.messageIds` (não `pushIds`).

## All eight channels via sdk-node

| Channel | sdk-node call |
|---------|---------------|
| WhatsApp | `client.whatsapp.sendText(...)` |
| SMS | `client.sms.send({ to, message })` |
| Email | `client.email.send({ from, to, subject, html })` |
| Push | `client.push.messages.send({ to, type, payload })` |
| Telegram | `client.api.telegram.postV1TelegramSend({ body })` |
| Instagram | `client.api.instagram.sendMessage({ body })` |
| RCS | `client.api.rcs.postV1RcsSend({ body })` |
| Voice | `client.api.voice.postV1VoiceCalls({ body })` |

## Os oito canais via sdk-node

| Canal | Chamada sdk-node |
|-------|------------------|
| WhatsApp | `client.whatsapp.sendText(...)` |
| SMS | `client.sms.send({ to, message })` |
| Email | `client.email.send({ from, to, subject, html })` |
| Push | `client.push.messages.send({ to, type, payload })` |
| Telegram | `client.api.telegram.postV1TelegramSend({ body })` |
| Instagram | `client.api.instagram.sendMessage({ body })` |
| RCS | `client.api.rcs.postV1RcsSend({ body })` |
| Voz | `client.api.voice.postV1VoiceCalls({ body })` |

## Webhooks & logs (sdk-node)

```typescript
import { Notifique } from '@notifique/sdk-node';

const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });
await client.api.webhooks.listWebhooks({ query: { limit: 20 } });
await client.api.logs.getV1Logs({ query: { page: 1, limit: 50 } });
```

## Webhooks e logs (sdk-node)

```typescript
await client.api.webhooks.listWebhooks({ query: { limit: 20 } });
await client.api.logs.getV1Logs({ query: { page: 1, limit: 50 } });
```

## Regeneration

```bash
# from notifique-sdk root (requires ../notifique-docs)
npm run generate
npm test
```

## Regeneração

```bash
npm run generate
npm test
```

**Client-side push** SDKs: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks).

**Push no dispositivo**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks).
