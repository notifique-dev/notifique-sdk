# Notifique Python SDK

Official Notifique SDK for Python — **v0.2.0** with full OpenAPI v1 coverage.

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk)

## Full API coverage (v0.2.0)

- **353 operations** across **23 OpenAPI specs**
- **Legacy namespaces** (typed shortcuts): `whatsapp`, `sms`, `email`, `push`, `messages`
- **Generated client**: `client.api` — dynamic namespace tree from `operations.json` (snake_case method names)
- **Root namespaces** on the client: `client.contacts`, `client.automations`, `client.oauth`, …
- **Public endpoints** (no API key): `create_public_client()`

```python
from notifique import Notifique, create_public_client

client = Notifique(api_key="your-api-key")

# Full API (methods use snake_case)
client.api.contacts.get_v1_contacts(query={"limit": 20})
client.api.automations.list_automations(query={"page": 1})

# Root namespace shortcuts
client.contacts.get_v1_contacts(query={"limit": 20})

# Public / unauthenticated
public_api = create_public_client()
public_api.public.ai_widget.get_config(path_params={"publicKey": "pk_..."})
```

Regenerate bindings from [notifique-docs](https://github.com/notifique-dev/notifique-docs): `npm run generate` (in the monorepo root).

**Client-side push**: [notifique-dev/notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

## Installation

```bash
pip install notifique-sdk
```

## Quick Start

```python
from notifique import Notifique

# Create once and reuse — the client holds a persistent HTTP session.
with Notifique(api_key="your-api-key") as client:
    result = client.whatsapp.send_text("instance-id", "5511999999999", "Hello!")

print(result["data"]["messageIds"])
```

### Constructor options

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `api_key` | `str` | required | Your Notifique API key |
| `base_url` | `str` | `https://api.notifique.dev/v1` | API base URL (HTTPS only) |
| `timeout` | `int` | `30` | Request timeout in seconds |

## WhatsApp

```python
# Text (shortcut)
client.whatsapp.send_text(instance_id, "5511999999999", "Hello!")

# Full send (text, image, video, audio, document, location, contact)
client.whatsapp.send(instance_id, {
    "to": ["5511999999999"],
    "type": "text",
    "payload": {"message": "Hello!"},
    "options": {
        "webhook": {"url": "https://your-domain.com/hooks/notifique"},
        "fallback": {"channel": "sms"},
    },
})

# Image
client.whatsapp.send(instance_id, {
    "to": ["5511999999999"],
    "type": "image",
    "payload": {"mediaUrl": "https://example.com/img.png", "fileName": "img.png", "mimetype": "image/png"},
})

# Message management
client.whatsapp.list_messages(params={"page": "1", "limit": "20"})
client.whatsapp.get_message(message_id)
client.whatsapp.edit_message(message_id, "New text")
client.whatsapp.delete_message(message_id)
client.whatsapp.cancel_message(message_id)  # cancel scheduled

# Instance management
client.whatsapp.list_instances()
client.whatsapp.get_instance(instance_id)
client.whatsapp.get_instance_qr(instance_id)
client.whatsapp.create_instance({"name": "My Instance"})
client.whatsapp.disconnect_instance(instance_id)
client.whatsapp.delete_instance(instance_id)
```

## SMS

```python
client.sms.send({"to": ["5511999999999"], "message": "SMS text"})
client.sms.get(sms_id)
client.sms.cancel(sms_id)
```

## Email

```python
# The `from` key is a Python reserved word — use it as a string key in a dict.
# Alternatively, `from_address` is accepted as an alias and translated automatically.
client.email.send({
    "from": "noreply@yourdomain.com",
    "to": ["user@example.com"],
    "subject": "Subject",
    "html": "<p>HTML body</p>",
})

client.email.get(email_id)
client.email.cancel(email_id)

# Domain management
client.email.domains.list()
client.email.domains.create({"domain": "yourdomain.com"})
client.email.domains.get(domain_id)
client.email.domains.verify(domain_id)
```

## Push

```python
# Apps
client.push.apps.list()
client.push.apps.get(app_id)
client.push.apps.create({"name": "My App"})
client.push.apps.update(app_id, {"name": "New name"})
client.push.apps.delete(app_id)

# Devices
client.push.devices.register({"appId": app_id, "platform": "web", "subscription": {
    "endpoint": "https://...", "keys": {"p256dh": "...", "auth": "..."}
}})
client.push.devices.list(params={"appId": app_id})
client.push.devices.get(device_id)
client.push.devices.delete(device_id)

# Messages — canonical contract: to + type + payload → messageIds
result = client.push.messages.send({
    "to": [device_id],
    "type": "push",
    "payload": {"title": "Title", "body": "Body"},
})
print(result["data"]["messageIds"])  # NOT pushIds
client.push.messages.list()
client.push.messages.get(message_id)
client.push.messages.cancel(message_id)
```

## Multi-channel Template Send

```python
client.messages.send({
    "to": ["5511999999999", "user@example.com"],
    "template": "welcome",
    "variables": {"name": "Alice", "credits": 300},
    "channels": ["whatsapp", "sms", "email"],
    "instanceId": "your-instance-id",    # or "instance_id" — both accepted
    "from": "noreply@yourdomain.com",    # or "from_address" — both accepted
})
```

## Error Handling

```python
from notifique import Notifique, NotifiqueApiError

try:
    client.whatsapp.send_text(instance_id, "5511999999999", "Hello")
except NotifiqueApiError as e:
    print(e.status_code, e.message, e.response_data)
```

## Requirements

- Python 3.8+
- `requests >= 2.31.0`
