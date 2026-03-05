# Notifique Python SDK

SDK oficial Notifique para Python — **WhatsApp**, **SMS**, **Email**, **Push** e envio por **template**. Tipado com `TypedDict`.

## Instalação

```bash
pip install notifique-sdk
```

## Uso

```python
from notifique import Notifique

notifique = Notifique(api_key="sua_api_key")
# base_url padrão: https://api.notifique.dev/v1
```

### WhatsApp

- **POST /v1/whatsapp/messages** — `instance_id` no body.
- Texto: `payload.message`. Mídia: `payload.mediaUrl`, `fileName`, `mimetype`.

```python
# Texto
r = notifique.whatsapp.send_text(instance_id, "5511999999999", "Olá!")

# Envio completo (text, image, video, audio, document, location, contact)
r = notifique.whatsapp.send(instance_id, {
    "to": ["5511999999999"],
    "type": "text",
    "payload": {"message": "Oi"},
})

# Listar mensagens, status, apagar, editar, cancelar
lista = notifique.whatsapp.list_messages(params={"page": "1", "limit": "20"})
status = notifique.whatsapp.get_message(message_id)  # retorna envelope success/data
notifique.whatsapp.delete_message(message_id)
notifique.whatsapp.edit_message(message_id, "Novo texto")
notifique.whatsapp.cancel_message(message_id)

# Instâncias e QR
instances = notifique.whatsapp.list_instances()
one = notifique.whatsapp.get_instance(instance_id)
qr = notifique.whatsapp.get_instance_qr(instance_id)
notifique.whatsapp.create_instance({"name": "Minha Instância"})
notifique.whatsapp.disconnect_instance(instance_id)
notifique.whatsapp.delete_instance(instance_id)
```

### SMS

```python
r = notifique.sms.send({"to": ["5511999999999"], "message": "SMS de teste"})
status = notifique.sms.get(sms_id)
notifique.sms.cancel(sms_id)
```

### Email

- Use **`from`** (camelCase). Alternativa: `from_address` é convertido para `from`.

```python
r = notifique.email.send({
    "from": "noreply@seudominio.com",
    "to": ["user@example.com"],
    "subject": "Assunto",
    "html": "<p>Corpo</p>",
})
status = notifique.email.get(email_id)
notifique.email.cancel(email_id)

# Domínios
domains = notifique.email.domains.list()
notifique.email.domains.create({"domain": "seudominio.com"})
notifique.email.domains.get(domain_id)
notifique.email.domains.verify(domain_id)
```

### Push

```python
# Apps
notifique.push.apps.list()
notifique.push.apps.get(app_id)
notifique.push.apps.create({"name": "Meu App"})
notifique.push.apps.update(app_id, {"name": "Novo nome"})
notifique.push.apps.delete(app_id)

# Dispositivos
notifique.push.devices.register({"appId": app_id, "platform": "web", "subscription": {...}})
notifique.push.devices.list(params={"appId": app_id})
notifique.push.devices.get(device_id)
notifique.push.devices.delete(device_id)

# Mensagens
notifique.push.messages.send({"to": [device_id], "title": "Título", "body": "Corpo"})
notifique.push.messages.list()
notifique.push.messages.get(message_id)
notifique.push.messages.cancel(message_id)
```

### Mensagens por template (whatsapp + sms + email)

```python
r = notifique.messages.send({
    "to": ["5511999999999", "user@example.com"],
    "template": "welcome",
    "variables": {"name": "Trial", "credits": 300},
    "channels": ["whatsapp", "sms", "email"],
    "instanceId": "sua_instancia_id",
    "from": "noreply@seudominio.com",
})
```

## Tipos

Tipos em `notifique.types` (reexportados em `notifique`): WhatsApp, SMS, Email, Email Domains, Push (apps, devices, messages), Messages.

## Erros

Em 4xx/5xx o cliente chama `response.raise_for_status()`; use `try/except requests.HTTPError`.

## Requisitos

- Python 3.8+
- `requests`
