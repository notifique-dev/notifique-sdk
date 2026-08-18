# Notifique PHP SDK

**[English](#english)** · **[Português](#português)** · Docs: [docs.notifique.dev](https://docs.notifique.dev)

---

## English

Server-side Notifique SDK for PHP (v0.2.1).

### Install

```bash
composer require notifique/notifique-sdk-php
```

### Quick start

```php
use Notifique\Notifique;

$client = new Notifique('your-api-key');
$resp = $client->whatsapp->sendText('instance-id', ['5511999999999'], 'Hello!');
print_r($resp['data']['messageIds']);
```

### Send SMS

```php
$client->sms->send(['to' => ['5511999999999'], 'message' => 'Hello SMS!']);
```

### Send by channel

| Channel | Example |
|---------|---------|
| WhatsApp | `$client->whatsapp->sendText($instanceId, $to, 'Hello!')` |
| SMS | `$client->sms->send(['to' => [...], 'message' => '...'])` |
| Email | `$client->email->send([...])` |
| Push | `$client->push->messages->send([...])` |
| Telegram | `$client->api->telegram()->postV1TelegramSend(null, ['body' => [...]])` |
| Instagram | `$client->api->instagram()->sendMessage(null, ['body' => [...]])` |
| RCS | `$client->api->rcs()->postV1RcsSend(null, ['body' => [...]])` |
| Voice | `$client->api->voice()->postV1VoiceCalls(null, ['body' => [...]])` |

### Webhooks & logs

```php
$client->api->webhooks()->listWebhooks(null, null, ['query' => ['limit' => 20]]);
$client->api->logs()->getV1Logs(null, null, null, null, null, null, null, ['query' => ['page' => 1]]);
```

### Errors

`Notifique\Exception\NotifiqueApiException` on API errors (4xx/5xx).

---

## Português

SDK server-side Notifique para PHP (v0.2.1).

### Instalação

```bash
composer require notifique/notifique-sdk-php
```

### Início rápido

```php
use Notifique\Notifique;

$client = new Notifique('sua-api-key');
$resp = $client->whatsapp->sendText('instance-id', ['5511999999999'], 'Olá!');
print_r($resp['data']['messageIds']);
```

### Enviar SMS

```php
$client->sms->send(['to' => ['5511999999999'], 'message' => 'Olá SMS!']);
```

### Enviar por canal

| Canal | Exemplo |
|-------|---------|
| WhatsApp | `$client->whatsapp->sendText($instanceId, $to, 'Olá!')` |
| SMS | `$client->sms->send(['to' => [...], 'message' => '...'])` |
| Email | `$client->email->send([...])` |
| Push | `$client->push->messages->send([...])` |
| Telegram | `$client->api->telegram()->postV1TelegramSend(null, ['body' => [...]])` |
| Instagram | `$client->api->instagram()->sendMessage(null, ['body' => [...]])` |
| RCS | `$client->api->rcs()->postV1RcsSend(null, ['body' => [...]])` |
| Voz | `$client->api->voice()->postV1VoiceCalls(null, ['body' => [...]])` |

### Webhooks e logs

```php
$client->api->webhooks()->listWebhooks(null, null, ['query' => ['limit' => 20]]);
$client->api->logs()->getV1Logs(null, null, null, null, null, null, null, ['query' => ['page' => 1]]);
```

### Erros

`Notifique\Exception\NotifiqueApiException` em erros da API (4xx/5xx).
