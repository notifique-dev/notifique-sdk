# @notifique/sdk-node

Official Notifique SDK for Node.js and TypeScript — **v0.2.0** with full OpenAPI v1 coverage.

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk)

## Full API coverage (v0.2.0)

- **353 operations** across **23 OpenAPI specs** (contacts, automations, oauth, platform, voice, RCS, etc.)
- **Legacy namespaces** (typed shortcuts): `whatsapp`, `sms`, `email`, `push`, `messages`
- **Generated client**: `client.api.*` — every operation from `operations.json`
- **Root namespaces** on the client instance: `client.contacts`, `client.automations`, `client.oauth`, … (all non-legacy top-level namespaces)
- **Public endpoints** (no API key): `createPublicClient()` — widget, OAuth metadata, report

```typescript
import { Notifique, createPublicClient } from '@notifique/sdk-node';

const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });

// Full API
await client.api.contacts.getV1Contacts({ query: { limit: 20 } });
await client.automations.listAutomations({ query: { page: 1 } });
await client.oauth.listWorkspaceApps();

// Root namespace shortcuts (same as client.api.*)
await client.contacts.getV1Contacts({ query: { limit: 20 } });

// Public / unauthenticated
const publicApi = createPublicClient();
await publicApi.public.aiWidget.getConfig({ publicKey: 'pk_...' });
```

OpenAPI schemas are exported from `@notifique/core` (re-exported by this package). **`client.api` methods are fully typed** — `options.query`, `options.body`, `pathParams`, and return types come from the OpenAPI specs (`OpResponse`, `OpRequestBody`, `OpQuery`, `OpPathParams`).

```typescript
import type { OpResponse } from '@notifique/core';

const res = await client.api.push.getV1PushApps({ query: { limit: 10 } });
type AppsList = OpResponse<'/v1/push/apps', 'get'>;
```

Regenerate bindings from [notifique-docs](https://github.com/notifique-dev/notifique-docs):

```bash
# clone notifique-docs as sibling, then:
npm run generate
```

**Client-side push** (Web/RN/Flutter/Android/iOS): [notifique-dev/notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

## Installation

```bash
npm install @notifique/sdk-node
```

## Quick Start

```typescript
import { Notifique } from '@notifique/sdk-node';

// Create once and reuse — do NOT create a new instance per request.
const notifique = new Notifique({ apiKey: 'your-api-key' });
const instanceId = 'your-whatsapp-instance-id';

// Send a text message
const result = await notifique.whatsapp.sendText(instanceId, '5511999999999', 'Hello!');
console.log(result.data.messageIds);
```

> **Singleton pattern:** Axios creates a persistent HTTP connection pool. Instantiating `Notifique` per request will accumulate interceptors and exhaust memory. Create it once at application startup.

## WhatsApp

```typescript
// Text (shortcut)
await notifique.whatsapp.sendText(instanceId, '5511999999999', 'Hello!');

// Full send — text, image, video, audio, document, location, contact
await notifique.whatsapp.send(instanceId, {
  to: ['5511999999999'],
  type: 'text',
  payload: { message: 'Hello!' },
  options: {
    webhook: { url: 'https://your-domain.com/hooks/notifique', secret: 'optional' },
    autoReplyText: 'Thanks! We will get back to you soon.',
    fallback: { channel: 'sms' },
  },
});

// Image
await notifique.whatsapp.send(instanceId, {
  to: ['5511999999999'],
  type: 'image',
  payload: { mediaUrl: 'https://example.com/image.png', fileName: 'image.png', mimetype: 'image/png', caption: 'Optional caption' },
});

// Idempotency key (prevents duplicate sends on retry)
await notifique.whatsapp.sendText(instanceId, '5511999999999', 'Hello!', { idempotencyKey: 'unique-key-123' });

// Message management
await notifique.whatsapp.listMessages({ page: '1', limit: '20' });
await notifique.whatsapp.getMessage(messageId);
await notifique.whatsapp.editMessage(messageId, { text: 'Updated text' });
await notifique.whatsapp.deleteMessage(messageId);
await notifique.whatsapp.cancelMessage(messageId);  // cancel scheduled

// Instance management
await notifique.whatsapp.listInstances();
await notifique.whatsapp.getInstance(instanceId);
await notifique.whatsapp.getInstanceQr(instanceId);
await notifique.whatsapp.createInstance({ name: 'My Instance' });
await notifique.whatsapp.disconnectInstance(instanceId);
await notifique.whatsapp.deleteInstance(instanceId);
```

## SMS

```typescript
await notifique.sms.send({ to: ['5511999999999'], message: 'SMS text' });
await notifique.sms.send({ to: ['5511999999999'], message: 'SMS text' }, { idempotencyKey: 'key' });
await notifique.sms.get(smsId);
await notifique.sms.cancel(smsId);
```

## Email

```typescript
await notifique.email.send({
  from: 'noreply@yourdomain.com',
  to: ['user@example.com'],
  subject: 'Subject',
  html: '<p>HTML body</p>',
});
await notifique.email.send({ ... }, { idempotencyKey: 'key' });
await notifique.email.get(emailId);
await notifique.email.cancel(emailId);

// Domain management
await notifique.email.domains.list();
await notifique.email.domains.create({ domain: 'yourdomain.com' });
await notifique.email.domains.get(domainId);
await notifique.email.domains.verify(domainId);
```

## Push

```typescript
// Apps
await notifique.push.apps.list();
await notifique.push.apps.get(appId);
await notifique.push.apps.create({ name: 'My App' });
await notifique.push.apps.update(appId, { name: 'New name' });
await notifique.push.apps.delete(appId);

// Devices
await notifique.push.devices.register({ appId, platform: 'web', subscription: { endpoint, keys: { p256dh, auth } } });
await notifique.push.devices.list({ appId });
await notifique.push.devices.get(deviceId);
await notifique.push.devices.delete(deviceId);

// Messages — canonical contract: to + type + payload → messageIds
await notifique.push.messages.send({
  to: [deviceId],
  type: 'push',
  payload: { title: 'Title', body: 'Body' },
});
console.log(result.data.messageIds); // NOT pushIds
await notifique.push.messages.send({ ... }, { idempotencyKey: 'key' });
await notifique.push.messages.list({ status: 'SENT' });
await notifique.push.messages.get(messageId);
await notifique.push.messages.cancel(messageId);
```

## Multi-channel Template Send

```typescript
await notifique.messages.send({
  to: ['5511999999999', 'user@example.com'],
  template: 'welcome',
  variables: { name: 'Alice', credits: 300 },
  channels: ['whatsapp', 'sms', 'email'],
  instanceId: 'your-instance-id',
  from: 'noreply@yourdomain.com',
});
```

## Error Handling

```typescript
import { NotifiqueApiError } from '@notifique/sdk-node';

try {
  await notifique.whatsapp.sendText(instanceId, '5511999999999', 'Hello');
} catch (err) {
  if (err instanceof NotifiqueApiError) {
    console.error(err.statusCode, err.message, err.responseData);
  }
}
```

## TypeScript

All methods are fully typed via `@notifique/core`. Generic payload types are inferred from the `type` discriminator:

```typescript
// TypeScript infers the correct payload type for 'image'
await notifique.whatsapp.send(instanceId, {
  to: ['5511999999999'],
  type: 'image',
  payload: { mediaUrl: '...', fileName: '...', mimetype: 'image/png' }, // ✅ typed
});
```
