# Notifique PHP SDK

SDK oficial Notifique para PHP — **v0.2.0** com cobertura completa da API v1 OpenAPI.

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk)

## Cobertura completa da API (v0.2.0)

- **353 operações** em **23 specs** OpenAPI
- **Namespaces legados** (atalhos tipados): `$client->whatsapp`, `$client->sms`, `$client->email`, `$client->push`, `$client->messages`
- **Cliente gerado**: `$client->api` — árvore dinâmica a partir de `operations.json`
- **Namespaces na raiz**: `$client->oauth`, `$client->contacts`, `$client->automations`, … (via `__get`)

```php
<?php
use Notifique\Notifique;

$client = new Notifique('sua-api-key');

// API completa
$client->api->contacts->getV1Contacts(['query' => ['limit' => 20]]);
$client->contacts->getV1Contacts(['query' => ['limit' => 20]]); // atalho na raiz

// OAuth aninhado
$client->oauth->apps->rotateWorkspaceAppSecret(
    ['id' => 'app-id'],
    ['body' => null]
);
```

Regenerar bindings a partir de [notifique-docs](https://github.com/notifique-dev/notifique-docs): `npm run generate` (na raiz do monorepo).

**Push no dispositivo** (Web/RN/Flutter/Android/iOS): [notifique-dev/notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Instalação

```bash
composer require notifique/notifique-sdk-php
```

## Uso rápido

```php
<?php
require_once 'vendor/autoload.php';

use Notifique\Notifique;
use Notifique\Exception\NotifiqueApiException;

$notifique = new Notifique('sua-api-key'); // baseUrl padrão: https://api.notifique.dev/v1
$instanceId = 'sua-instancia-whatsapp';

try {
    $resp = $notifique->whatsapp->sendText($instanceId, ['5511999999999'], 'Olá!');
    // API retorna envelope: $resp['success'], $resp['data']['messageIds']
    print_r($resp['data']['messageIds']);
} catch (NotifiqueApiException $e) {
    echo "API erro {$e->statusCode}: {$e->responseBody}";
}
```

## WhatsApp

- `send($instanceId, $params)`, `sendText($instanceId, $to, $text)` — retornam envelope `success`/`data`
- `listMessages($params)` — GET /v1/whatsapp/messages
- `getMessage($id)` — retorna envelope `data` com status da mensagem
- `getInstanceQr($instanceId)` — GET /v1/whatsapp/instances/:id/qr
- `deleteMessage`, `editMessage`, `cancelMessage`
- `listInstances`, `getInstance`, `createInstance`, `disconnectInstance`, `deleteInstance`

## SMS

- `send($params)`, `get($id)`, `cancel($id)`

## Email

- `send($params)`, `get($id)`, `cancel($id)`
- **Domínios** — `$notifique->email->domains()->list()`, `create(['domain' => '...'])`, `get($id)`, `verify($id)`

## Push

- **Apps** — `$notifique->push->apps->list()`, `get($id)`, `create(['name' => '...'])`, `update($id, $params)`, `delete($id)`
- **Devices** — `$notifique->push->devices->register($params)`, `list()`, `get($id)`, `delete($id)`
- **Messages** — `$notifique->push->messages->send($params)`, `list()`, `get($id)`, `cancel($id)`

Contrato canônico de envio: `to` + `type` + `payload` → `data.messageIds` (não `pushIds`, não `title`/`body` na raiz):

```php
$resp = $notifique->push->messages->send([
    'to' => [$deviceId],
    'type' => 'push',
    'payload' => ['title' => 'Título', 'body' => 'Corpo'],
]);
print_r($resp['data']['messageIds']);
```

## Messages (template)

- `$notifique->messages->send($params)` — canais whatsapp, sms, email

## Requisitos

- PHP 8.1+, Guzzle ^7.8.
- Em 4xx/5xx: `Notifique\Exception\NotifiqueApiException` com `statusCode` e `responseBody`.
