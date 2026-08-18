# @notifique/sdk-node

**[English](#english)** · **[Português](#português)** · Docs: [docs.notifique.dev](https://docs.notifique.dev)

---

## English

Server-side Notifique SDK for Node.js and TypeScript (v0.2.1).

### Install

```bash
npm install @notifique/sdk-node
```

### Quick start

```typescript
import { Notifique } from '@notifique/sdk-node';

const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });
const result = await client.whatsapp.sendText('instance-id', '5511999999999', 'Hello!');
console.log(result.data.messageIds);
```

Create the client once and reuse it (do not create one per HTTP request).

### Send SMS

```typescript
await client.sms.send({ to: ['5511999999999'], message: 'Hello via SMS!' });
```

### Send by channel

| Channel | Example |
|---------|---------|
| WhatsApp | `client.whatsapp.sendText('instance-id', '5511999999999', 'Hello!')` |
| SMS | `client.sms.send({ to: ['5511999999999'], message: '...' })` |
| Email | `client.email.send({ from: 'noreply@domain.com', to: ['user@example.com'], subject: 'Hi', html: '<p>Hi</p>' })` |
| Push | `client.push.messages.send({ to: ['device-id'], type: 'push', payload: { title: 'T', body: 'B' } })` |
| Telegram | `client.api.telegram.postV1TelegramSend({ body: { instanceId, to, type: 'text', payload: { message: 'Hi' } } })` |
| Instagram | `client.api.instagram.sendMessage({ body: { instanceId, to, type: 'text', payload: { message: 'Hi' } } })` |
| RCS | `client.api.rcs.postV1RcsSend({ body: { to: ['5511...'], type: 'basic', payload: { message: 'Hi' } } })` |
| Voice | `client.api.voice.postV1VoiceCalls({ body: { from: '5511...', to: ['5511...'], type: 'speak', payload: { text: 'Hi' } } })` |

### Webhooks & logs

```typescript
await client.api.webhooks.listWebhooks({ query: { limit: 20 } });
await client.api.webhooks.createWebhook({ body: { url: 'https://your.app/hooks', events: ['message.sent'] } });
await client.api.webhooks.listDeliveries({ query: { limit: 20 } });
await client.api.logs.getV1Logs({ query: { page: 1, limit: 50 } });
```

### Errors

```typescript
import { NotifiqueApiError } from '@notifique/sdk-node';
```

API errors throw `NotifiqueApiError` with `statusCode` and `responseData`.

---

## Português

SDK server-side Notifique para Node.js e TypeScript (v0.2.1).

### Instalação

```bash
npm install @notifique/sdk-node
```

### Início rápido

```typescript
import { Notifique } from '@notifique/sdk-node';

const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });
const result = await client.whatsapp.sendText('instance-id', '5511999999999', 'Olá!');
console.log(result.data.messageIds);
```

Crie o client uma vez e reutilize (não crie um por requisição).

### Enviar SMS

```typescript
await client.sms.send({ to: ['5511999999999'], message: 'Olá via SMS!' });
```

### Enviar por canal

| Canal | Exemplo |
|-------|---------|
| WhatsApp | `client.whatsapp.sendText('instance-id', '5511999999999', 'Olá!')` |
| SMS | `client.sms.send({ to: ['5511999999999'], message: '...' })` |
| Email | `client.email.send({ from: 'noreply@dominio.com', to: ['user@example.com'], subject: 'Oi', html: '<p>Oi</p>' })` |
| Push | `client.push.messages.send({ to: ['device-id'], type: 'push', payload: { title: 'T', body: 'B' } })` |
| Telegram | `client.api.telegram.postV1TelegramSend({ body: { instanceId, to, type: 'text', payload: { message: 'Oi' } } })` |
| Instagram | `client.api.instagram.sendMessage({ body: { instanceId, to, type: 'text', payload: { message: 'Oi' } } })` |
| RCS | `client.api.rcs.postV1RcsSend({ body: { to: ['5511...'], type: 'basic', payload: { message: 'Oi' } } })` |
| Voz | `client.api.voice.postV1VoiceCalls({ body: { from: '5511...', to: ['5511...'], type: 'speak', payload: { text: 'Oi' } } })` |

### Webhooks e logs

```typescript
await client.api.webhooks.listWebhooks({ query: { limit: 20 } });
await client.api.webhooks.createWebhook({ body: { url: 'https://seu.app/hooks', events: ['message.sent'] } });
await client.api.webhooks.listDeliveries({ query: { limit: 20 } });
await client.api.logs.getV1Logs({ query: { page: 1, limit: 50 } });
```

### Erros

```typescript
import { NotifiqueApiError } from '@notifique/sdk-node';
```

Erros da API lançam `NotifiqueApiError` com `statusCode` e `responseData`.
