# @notifique/sdk-node

Official Notifique SDK for Node.js and TypeScript — **v0.2.1** with full OpenAPI v1 coverage (353 operations, 23 specs).

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Client-side push** (Web/RN/Flutter/Android/iOS): [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

---

SDK oficial Notifique para Node.js e TypeScript — **v0.2.1** com cobertura completa da API v1 OpenAPI (353 operações, 23 specs).

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Push no dispositivo** (Web/RN/Flutter/Android/iOS): [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Installation

```bash
npm install @notifique/sdk-node
```

## Instalação

```bash
npm install @notifique/sdk-node
```

## Quick start

```typescript
import { Notifique } from '@notifique/sdk-node';

// Create once and reuse — do NOT create a new instance per request.
const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });

const result = await client.whatsapp.sendText('instance-id', '5511999999999', 'Hello!');
console.log(result.data.messageIds);
```

## Início rápido

```typescript
import { Notifique } from '@notifique/sdk-node';

// Crie uma vez e reutilize — não instancie por requisição.
const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });

const result = await client.whatsapp.sendText('instance-id', '5511999999999', 'Olá!');
console.log(result.data.messageIds);
```

## Send SMS

```typescript
await client.sms.send({ to: ['5511999999999'], message: 'Hello via SMS!' });
await client.sms.get('sms-id');
await client.sms.cancel('sms-id');
```

## Enviar SMS

```typescript
await client.sms.send({ to: ['5511999999999'], message: 'Olá via SMS!' });
await client.sms.get('sms-id');
await client.sms.cancel('sms-id');
```

## Send messages by channel

Eight messaging channels. Legacy shortcuts (`whatsapp`, `sms`, `email`, `push`) plus `client.api.*` for Telegram, Instagram, RCS and Voice.

### WhatsApp

```typescript
await client.whatsapp.sendText('instance-id', '5511999999999', 'Hello!');
```

### SMS

```typescript
await client.sms.send({ to: ['5511999999999'], message: 'SMS text' });
```

### Email

```typescript
await client.email.send({
  from: 'noreply@yourdomain.com',
  to: ['user@example.com'],
  subject: 'Welcome',
  html: '<p>Hello!</p>',
});
```

### Push

Canonical contract: `to` + `type` + `payload` → `data.messageIds` (not `pushIds`).

```typescript
await client.push.messages.send({
  to: ['device-id'],
  type: 'push',
  payload: { title: 'Title', body: 'Body' },
});
```

### Telegram

```typescript
await client.api.telegram.postV1TelegramSend({
  body: {
    instanceId: 'inst_abc',
    to: ['@username'],
    type: 'text',
    payload: { message: 'Hello!' },
  },
});
```

### Instagram

```typescript
await client.api.instagram.sendMessage({
  body: {
    instanceId: 'inst_abc',
    to: ['target_user'],
    type: 'text',
    payload: { message: 'Hello!' },
  },
});
```

### RCS

```typescript
await client.api.rcs.postV1RcsSend({
  body: {
    to: ['5511999999999'],
    type: 'basic',
    payload: { message: 'Hello RCS!' },
  },
});
```

### Voice

```typescript
await client.api.voice.postV1VoiceCalls({
  body: {
    from: '5511987654321',
    to: ['5511999887766'],
    type: 'speak',
    payload: { text: 'Hello! Test call.', voice: 'female-natural' },
  },
});
```

## Enviar mensagens por canal

Oito canais de mensagem. Atalhos legados (`whatsapp`, `sms`, `email`, `push`) e `client.api.*` para Telegram, Instagram, RCS e Voz.

### WhatsApp

```typescript
await client.whatsapp.sendText('instance-id', '5511999999999', 'Olá!');
```

### SMS

```typescript
await client.sms.send({ to: ['5511999999999'], message: 'Texto SMS' });
```

### Email

```typescript
await client.email.send({
  from: 'noreply@seudominio.com',
  to: ['usuario@example.com'],
  subject: 'Bem-vindo',
  html: '<p>Olá!</p>',
});
```

### Push

Contrato canônico: `to` + `type` + `payload` → `data.messageIds` (não `pushIds`).

```typescript
await client.push.messages.send({
  to: ['device-id'],
  type: 'push',
  payload: { title: 'Título', body: 'Corpo' },
});
```

### Telegram

```typescript
await client.api.telegram.postV1TelegramSend({
  body: {
    instanceId: 'inst_abc',
    to: ['@usuario'],
    type: 'text',
    payload: { message: 'Olá!' },
  },
});
```

### Instagram

```typescript
await client.api.instagram.sendMessage({
  body: {
    instanceId: 'inst_abc',
    to: ['usuario_alvo'],
    type: 'text',
    payload: { message: 'Olá!' },
  },
});
```

### RCS

```typescript
await client.api.rcs.postV1RcsSend({
  body: {
    to: ['5511999999999'],
    type: 'basic',
    payload: { message: 'Olá RCS!' },
  },
});
```

### Voz

```typescript
await client.api.voice.postV1VoiceCalls({
  body: {
    from: '5511987654321',
    to: ['5511999887766'],
    type: 'speak',
    payload: { text: 'Olá! Ligação de teste.', voice: 'female-natural' },
  },
});
```

## Webhooks & logs

```typescript
// List webhooks
await client.api.webhooks.listWebhooks({ query: { page: 1, limit: 20 } });

// Create webhook
await client.api.webhooks.createWebhook({
  body: {
    url: 'https://your-domain.com/hooks/notifique',
    events: ['message.sent', 'sms.delivered'],
    secret: 'optional-secret',
  },
});

// Webhook deliveries (audit)
await client.api.webhooks.listDeliveries({ query: { limit: 20 } });

// API request logs
await client.api.logs.getV1Logs({ query: { page: 1, limit: 50 } });
await client.api.logs.getV1LogsById({ id: 'log-id' });
```

## Webhooks e logs

```typescript
// Listar webhooks
await client.api.webhooks.listWebhooks({ query: { page: 1, limit: 20 } });

// Criar webhook
await client.api.webhooks.createWebhook({
  body: {
    url: 'https://seudominio.com/hooks/notifique',
    events: ['message.sent', 'sms.delivered'],
    secret: 'secret-opcional',
  },
});

// Entregas de webhook (auditoria)
await client.api.webhooks.listDeliveries({ query: { limit: 20 } });

// Logs de requisições da API
await client.api.logs.getV1Logs({ query: { page: 1, limit: 50 } });
await client.api.logs.getV1LogsById({ id: 'log-id' });
```

## Full API coverage

- **353 operations** across **23 OpenAPI specs**
- **Legacy namespaces**: `whatsapp`, `sms`, `email`, `push`, `messages`
- **Generated client**: `client.api.*` — every operation from `operations.json`
- **Root shortcuts**: `client.contacts`, `client.automations`, … (same as `client.api.*`)
- **Public endpoints**: `createPublicClient()` — widget, OAuth metadata, report

Regenerate bindings from [notifique-docs](https://github.com/notifique-dev/notifique-docs): `npm run generate` (monorepo root).

## Cobertura completa da API

- **353 operações** em **23 specs** OpenAPI
- **Namespaces legados**: `whatsapp`, `sms`, `email`, `push`, `messages`
- **Cliente gerado**: `client.api.*` — todas as operações de `operations.json`
- **Atalhos na raiz**: `client.contacts`, `client.automations`, … (equivalente a `client.api.*`)
- **Endpoints públicos**: `createPublicClient()` — widget, OAuth metadata, report

Regenerar bindings a partir de [notifique-docs](https://github.com/notifique-dev/notifique-docs): `npm run generate` (raiz do monorepo).

## Error handling

```typescript
import { NotifiqueApiError } from '@notifique/sdk-node';

try {
  await client.whatsapp.sendText('instance-id', '5511999999999', 'Hello');
} catch (err) {
  if (err instanceof NotifiqueApiError) {
    console.error(err.statusCode, err.message, err.responseData);
  }
}
```

## Tratamento de erros

```typescript
import { NotifiqueApiError } from '@notifique/sdk-node';

try {
  await client.whatsapp.sendText('instance-id', '5511999999999', 'Olá');
} catch (err) {
  if (err instanceof NotifiqueApiError) {
    console.error(err.statusCode, err.message, err.responseData);
  }
}
```
