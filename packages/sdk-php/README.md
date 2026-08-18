# Notifique PHP SDK

Official Notifique SDK for PHP — **v0.2.1** with full OpenAPI v1 coverage (353 operations, 23 specs).

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-php) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Client-side push**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

---

SDK oficial Notifique para PHP — **v0.2.1** com cobertura completa da API v1 OpenAPI (353 operações, 23 specs).

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-php) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Push no dispositivo**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Installation

```bash
composer require notifique/notifique-sdk-php
```

Package lives in the monorepo at `packages/sdk-php`. Packagist registers `notifique/notifique-sdk-php` from [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk).

Before Packagist, add the VCS repository:

```json
{
  "repositories": [
    { "type": "vcs", "url": "https://github.com/notifique-dev/notifique-sdk" }
  ]
}
```

## Instalação

```bash
composer require notifique/notifique-sdk-php
```

Pacote no monorepo em `packages/sdk-php`. Packagist registra `notifique/notifique-sdk-php` a partir de [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk).

Antes do Packagist, adicione o repositório VCS:

```json
{
  "repositories": [
    { "type": "vcs", "url": "https://github.com/notifique-dev/notifique-sdk" }
  ]
}
```

## Quick start

```php
use Notifique\Notifique;

$client = new Notifique('your-api-key');
$resp = $client->whatsapp->sendText('instance-id', ['5511999999999'], 'Hello!');
print_r($resp['data']['messageIds']);
```

## Início rápido

```php
use Notifique\Notifique;

$client = new Notifique('sua-api-key');
$resp = $client->whatsapp->sendText('instance-id', ['5511999999999'], 'Olá!');
print_r($resp['data']['messageIds']);
```

## Send SMS

```php
$client->sms->send(['to' => ['5511999999999'], 'message' => 'Hello via SMS!']);
$client->sms->get('sms-id');
$client->sms->cancel('sms-id');
```

## Enviar SMS

```php
$client->sms->send(['to' => ['5511999999999'], 'message' => 'Olá via SMS!']);
$client->sms->get('sms-id');
$client->sms->cancel('sms-id');
```

## Send messages by channel

### WhatsApp

```php
$client->whatsapp->sendText('instance-id', ['5511999999999'], 'Hello!');
```

### SMS

```php
$client->sms->send(['to' => ['5511999999999'], 'message' => 'SMS text']);
```

### Email

```php
$client->email->send([
    'from' => 'noreply@yourdomain.com',
    'to' => ['user@example.com'],
    'subject' => 'Welcome',
    'html' => '<p>Hello!</p>',
]);
```

### Push

```php
$client->push->messages->send([
    'to' => ['device-id'],
    'type' => 'push',
    'payload' => ['title' => 'Title', 'body' => 'Body'],
]);
```

### Telegram

```php
$client->api->telegram()->postV1TelegramSend(null, [
    'body' => [
        'instanceId' => 'inst_abc',
        'to' => ['@username'],
        'type' => 'text',
        'payload' => ['message' => 'Hello!'],
    ],
]);
```

### Instagram

```php
$client->api->instagram()->sendMessage(null, [
    'body' => [
        'instanceId' => 'inst_abc',
        'to' => ['target_user'],
        'type' => 'text',
        'payload' => ['message' => 'Hello!'],
    ],
]);
```

### RCS

```php
$client->api->rcs()->postV1RcsSend(null, [
    'body' => [
        'to' => ['5511999999999'],
        'type' => 'basic',
        'payload' => ['message' => 'Hello RCS!'],
    ],
]);
```

### Voice

```php
$client->api->voice()->postV1VoiceCalls(null, [
    'body' => [
        'from' => '5511987654321',
        'to' => ['5511999887766'],
        'type' => 'speak',
        'payload' => ['text' => 'Hello! Test call.', 'voice' => 'female-natural'],
    ],
]);
```

## Enviar mensagens por canal

### WhatsApp

```php
$client->whatsapp->sendText('instance-id', ['5511999999999'], 'Olá!');
```

### SMS

```php
$client->sms->send(['to' => ['5511999999999'], 'message' => 'Texto SMS']);
```

### Email

```php
$client->email->send([
    'from' => 'noreply@seudominio.com',
    'to' => ['usuario@example.com'],
    'subject' => 'Bem-vindo',
    'html' => '<p>Olá!</p>',
]);
```

### Push

```php
$client->push->messages->send([
    'to' => ['device-id'],
    'type' => 'push',
    'payload' => ['title' => 'Título', 'body' => 'Corpo'],
]);
```

### Telegram

```php
$client->api->telegram()->postV1TelegramSend(null, [
    'body' => [
        'instanceId' => 'inst_abc',
        'to' => ['@usuario'],
        'type' => 'text',
        'payload' => ['message' => 'Olá!'],
    ],
]);
```

### Instagram

```php
$client->api->instagram()->sendMessage(null, [
    'body' => [
        'instanceId' => 'inst_abc',
        'to' => ['usuario_alvo'],
        'type' => 'text',
        'payload' => ['message' => 'Olá!'],
    ],
]);
```

### RCS

```php
$client->api->rcs()->postV1RcsSend(null, [
    'body' => [
        'to' => ['5511999999999'],
        'type' => 'basic',
        'payload' => ['message' => 'Olá RCS!'],
    ],
]);
```

### Voz

```php
$client->api->voice()->postV1VoiceCalls(null, [
    'body' => [
        'from' => '5511987654321',
        'to' => ['5511999887766'],
        'type' => 'speak',
        'payload' => ['text' => 'Olá! Ligação de teste.', 'voice' => 'female-natural'],
    ],
]);
```

## Webhooks & logs

```php
$client->api->webhooks()->listWebhooks(null, null, ['query' => ['page' => 1, 'limit' => 20]]);
$client->api->webhooks()->createWebhook(null, [
    'body' => [
        'url' => 'https://your-domain.com/hooks/notifique',
        'events' => ['message.sent', 'sms.delivered'],
    ],
]);
$client->api->webhooks()->listDeliveries(null, null, null, null, null, ['query' => ['limit' => 20]]);
$client->api->logs()->getV1Logs(null, null, null, null, null, null, null, ['query' => ['page' => 1, 'limit' => 50]]);
$client->api->logs()->getV1LogsById('log-id');
```

## Webhooks e logs

```php
$client->api->webhooks()->listWebhooks(null, null, ['query' => ['page' => 1, 'limit' => 20]]);
$client->api->webhooks()->createWebhook(null, [
    'body' => [
        'url' => 'https://seudominio.com/hooks/notifique',
        'events' => ['message.sent', 'sms.delivered'],
    ],
]);
$client->api->webhooks()->listDeliveries(null, null, null, null, null, ['query' => ['limit' => 20]]);
$client->api->logs()->getV1Logs(null, null, null, null, null, null, null, ['query' => ['page' => 1, 'limit' => 50]]);
$client->api->logs()->getV1LogsById('log-id');
```

## Full API

- **353 operations**, legacy `$client->whatsapp`, `$client->sms`, …
- **Typed**: `$client->api->telegram()`, `$client->api->webhooks()`, …
- PHP 8.1+, Guzzle ^7.8
- Errors: `Notifique\Exception\NotifiqueApiException`

Regenerate: `npm run generate` in monorepo root.

## API completa

- **353 operações**, legado `$client->whatsapp`, `$client->sms`, …
- **Tipado**: `$client->api->telegram()`, `$client->api->webhooks()`, …
- PHP 8.1+, Guzzle ^7.8
- Erros: `Notifique\Exception\NotifiqueApiException`

Regenerar: `npm run generate` na raiz do monorepo.
