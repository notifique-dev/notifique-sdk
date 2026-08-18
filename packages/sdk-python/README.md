# Notifique Python SDK

Official Notifique SDK for Python — **v0.2.1** with full OpenAPI v1 coverage (353 operations, 23 specs).

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-python) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Client-side push**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

---

SDK oficial Notifique para Python — **v0.2.1** com cobertura completa da API v1 OpenAPI (353 operações, 23 specs).

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-python) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Push no dispositivo**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Installation

```bash
pip install notifique-sdk
```

## Instalação

```bash
pip install notifique-sdk
```

## Quick start

```python
from notifique import Notifique

with Notifique(api_key="your-api-key") as client:
    result = client.whatsapp.send_text("instance-id", "5511999999999", "Hello!")
print(result["data"]["messageIds"])
```

## Início rápido

```python
from notifique import Notifique

with Notifique(api_key="sua-api-key") as client:
    result = client.whatsapp.send_text("instance-id", "5511999999999", "Olá!")
print(result["data"]["messageIds"])
```

## Send SMS

```python
client.sms.send({"to": ["5511999999999"], "message": "Hello via SMS!"})
client.sms.get("sms-id")
client.sms.cancel("sms-id")
```

## Enviar SMS

```python
client.sms.send({"to": ["5511999999999"], "message": "Olá via SMS!"})
client.sms.get("sms-id")
client.sms.cancel("sms-id")
```

## Send messages by channel

### WhatsApp

```python
client.whatsapp.send_text("instance-id", "5511999999999", "Hello!")
```

### SMS

```python
client.sms.send({"to": ["5511999999999"], "message": "SMS text"})
```

### Email

```python
client.email.send({
    "from": "noreply@yourdomain.com",
    "to": ["user@example.com"],
    "subject": "Welcome",
    "html": "<p>Hello!</p>",
})
```

### Push

```python
client.push.messages.send({
    "to": ["device-id"],
    "type": "push",
    "payload": {"title": "Title", "body": "Body"},
})
```

### Telegram

```python
client.api.telegram.post_v1_telegram_send(body={
    "instanceId": "inst_abc",
    "to": ["@username"],
    "type": "text",
    "payload": {"message": "Hello!"},
})
```

### Instagram

```python
client.api.instagram.send_message(body={
    "instanceId": "inst_abc",
    "to": ["target_user"],
    "type": "text",
    "payload": {"message": "Hello!"},
})
```

### RCS

```python
client.api.rcs.post_v1_rcs_send(body={
    "to": ["5511999999999"],
    "type": "basic",
    "payload": {"message": "Hello RCS!"},
})
```

### Voice

```python
client.api.voice.post_v1_voice_calls(body={
    "from": "5511987654321",
    "to": ["5511999887766"],
    "type": "speak",
    "payload": {"text": "Hello! Test call.", "voice": "female-natural"},
})
```

## Enviar mensagens por canal

### WhatsApp

```python
client.whatsapp.send_text("instance-id", "5511999999999", "Olá!")
```

### SMS

```python
client.sms.send({"to": ["5511999999999"], "message": "Texto SMS"})
```

### Email

```python
client.email.send({
    "from": "noreply@seudominio.com",
    "to": ["usuario@example.com"],
    "subject": "Bem-vindo",
    "html": "<p>Olá!</p>",
})
```

### Push

```python
client.push.messages.send({
    "to": ["device-id"],
    "type": "push",
    "payload": {"title": "Título", "body": "Corpo"},
})
```

### Telegram

```python
client.api.telegram.post_v1_telegram_send(body={
    "instanceId": "inst_abc",
    "to": ["@usuario"],
    "type": "text",
    "payload": {"message": "Olá!"},
})
```

### Instagram

```python
client.api.instagram.send_message(body={
    "instanceId": "inst_abc",
    "to": ["usuario_alvo"],
    "type": "text",
    "payload": {"message": "Olá!"},
})
```

### RCS

```python
client.api.rcs.post_v1_rcs_send(body={
    "to": ["5511999999999"],
    "type": "basic",
    "payload": {"message": "Olá RCS!"},
})
```

### Voz

```python
client.api.voice.post_v1_voice_calls(body={
    "from": "5511987654321",
    "to": ["5511999887766"],
    "type": "speak",
    "payload": {"text": "Olá! Ligação de teste.", "voice": "female-natural"},
})
```

## Webhooks & logs

```python
client.api.webhooks.list_webhooks(query={"page": 1, "limit": 20})
client.api.webhooks.create_webhook(body={
    "url": "https://your-domain.com/hooks/notifique",
    "events": ["message.sent", "sms.delivered"],
})
client.api.webhooks.list_deliveries(query={"limit": 20})
client.api.logs.get_v1_logs(query={"page": 1, "limit": 50})
client.api.logs.get_v1_logs_by_id("log-id")
```

## Webhooks e logs

```python
client.api.webhooks.list_webhooks(query={"page": 1, "limit": 20})
client.api.webhooks.create_webhook(body={
    "url": "https://seudominio.com/hooks/notifique",
    "events": ["message.sent", "sms.delivered"],
})
client.api.webhooks.list_deliveries(query={"limit": 20})
client.api.logs.get_v1_logs(query={"page": 1, "limit": 50})
client.api.logs.get_v1_logs_by_id("log-id")
```

## Full API

- **353 operations**, legacy `whatsapp` / `sms` / `email` / `push` / `messages`
- **Generated**: `client.api.*` (snake_case methods)
- **Public**: `create_public_client()`
- Python 3.8+, `requests >= 2.31.0`

Regenerate: `npm run generate` in monorepo root.

## API completa

- **353 operações**, legado `whatsapp` / `sms` / `email` / `push` / `messages`
- **Gerado**: `client.api.*` (métodos snake_case)
- **Público**: `create_public_client()`
- Python 3.8+, `requests >= 2.31.0`

Regenerar: `npm run generate` na raiz do monorepo.

## Error handling

```python
from notifique import NotifiqueApiError

try:
    client.whatsapp.send_text("instance-id", "5511999999999", "Hello")
except NotifiqueApiError as e:
    print(e.status_code, e.response_data)
```

## Tratamento de erros

```python
from notifique import NotifiqueApiError

try:
    client.whatsapp.send_text("instance-id", "5511999999999", "Olá")
except NotifiqueApiError as e:
    print(e.status_code, e.response_data)
```
