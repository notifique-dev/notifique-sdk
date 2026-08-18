# Notifique Python SDK

**[English](#english)** · **[Português](#português)** · Docs: [docs.notifique.dev](https://docs.notifique.dev)

---

## English

Server-side Notifique SDK for Python (v0.2.1).

### Install

```bash
pip install notifique-sdk
```

### Quick start

```python
from notifique import Notifique

with Notifique(api_key="your-api-key") as client:
    result = client.whatsapp.send_text("instance-id", "5511999999999", "Hello!")
print(result["data"]["messageIds"])
```

### Send SMS

```python
client.sms.send({"to": ["5511999999999"], "message": "Hello SMS!"})
```

### Send by channel

| Channel | Example |
|---------|---------|
| WhatsApp | `client.whatsapp.send_text(instance_id, "5511...", "Hello!")` |
| SMS | `client.sms.send({"to": [...], "message": "..."})` |
| Email | `client.email.send({"from": "...", "to": [...], "subject": "...", "html": "..."})` |
| Push | `client.push.messages.send({"to": [...], "type": "push", "payload": {...}})` |
| Telegram | `client.api.telegram.post_v1_telegram_send(body={...})` |
| Instagram | `client.api.instagram.send_message(body={...})` |
| RCS | `client.api.rcs.post_v1_rcs_send(body={...})` |
| Voice | `client.api.voice.post_v1_voice_calls(body={...})` |

### Webhooks & logs

```python
client.api.webhooks.list_webhooks(query={"limit": 20})
client.api.webhooks.create_webhook(body={"url": "https://your.app/hooks", "events": ["message.sent"]})
client.api.logs.get_v1_logs(query={"page": 1, "limit": 50})
```

### Errors

```python
from notifique import NotifiqueApiError
```

---

## Português

SDK server-side Notifique para Python (v0.2.1).

### Instalação

```bash
pip install notifique-sdk
```

### Início rápido

```python
from notifique import Notifique

with Notifique(api_key="sua-api-key") as client:
    result = client.whatsapp.send_text("instance-id", "5511999999999", "Olá!")
print(result["data"]["messageIds"])
```

### Enviar SMS

```python
client.sms.send({"to": ["5511999999999"], "message": "Olá SMS!"})
```

### Enviar por canal

| Canal | Exemplo |
|-------|---------|
| WhatsApp | `client.whatsapp.send_text(instance_id, "5511...", "Olá!")` |
| SMS | `client.sms.send({"to": [...], "message": "..."})` |
| Email | `client.email.send({"from": "...", "to": [...], "subject": "...", "html": "..."})` |
| Push | `client.push.messages.send({"to": [...], "type": "push", "payload": {...}})` |
| Telegram | `client.api.telegram.post_v1_telegram_send(body={...})` |
| Instagram | `client.api.instagram.send_message(body={...})` |
| RCS | `client.api.rcs.post_v1_rcs_send(body={...})` |
| Voz | `client.api.voice.post_v1_voice_calls(body={...})` |

### Webhooks e logs

```python
client.api.webhooks.list_webhooks(query={"limit": 20})
client.api.webhooks.create_webhook(body={"url": "https://seu.app/hooks", "events": ["message.sent"]})
client.api.logs.get_v1_logs(query={"page": 1, "limit": 50})
```

### Erros

```python
from notifique import NotifiqueApiError
```
