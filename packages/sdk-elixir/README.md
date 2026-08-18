# Notifique Elixir SDK

**[English](#english)** · **[Português](#português)** · Docs: [docs.notifique.dev](https://docs.notifique.dev)

---

## English

Server-side Notifique SDK for Elixir (v0.2.1).

### Install

```elixir
{:notifique, "~> 0.2.1"}
```

Then `mix deps.get`.

### Quick start

```elixir
client = Notifique.new("your-api-key")
{:ok, body} = Notifique.Whatsapp.send_text(client, "instance-id", ["5511999999999"], "Hello!")
IO.inspect(body["data"]["messageIds"])
```

### Send SMS

```elixir
Notifique.Sms.send(client, %{"to" => ["5511999999999"], "message" => "Hello SMS!"})
```

### Send by channel

| Channel | Example |
|---------|---------|
| WhatsApp | `Notifique.Whatsapp.send_text(client, instance_id, to, "Hello!")` |
| SMS | `Notifique.Sms.send(client, %{...})` |
| Email | `Notifique.Email.send(client, %{...})` |
| Push | `Notifique.Push.send_message(client, %{...})` |
| Telegram | `Notifique.TypedApi.Telegram.post_v1_telegram_send(telegram, body: %{...})` |
| Instagram | `Notifique.TypedApi.Instagram.send_message(instagram, body: %{...})` |
| RCS | `Notifique.TypedApi.Rcs.post_v1_rcs_send(rcs, body: %{...})` |
| Voice | `Notifique.TypedApi.Voice.post_v1_voice_calls(voice, body: %{...})` |

Use `api = Notifique.api(client)` then `Notifique.TypedApi.telegram(api)` for typed API namespaces.

### Webhooks & logs

```elixir
api = Notifique.api(client)
Notifique.TypedApi.Webhooks.list_webhooks(Notifique.TypedApi.webhooks(api), opts: [query: %{"limit" => "20"}])
Notifique.TypedApi.Logs.get_v1_logs(Notifique.TypedApi.logs(api), opts: [query: %{"page" => "1"}])
```

### Errors

Returns `{:ok, body}` or `{:error, %{status: code, body: body}}`.

---

## Português

SDK server-side Notifique para Elixir (v0.2.1).

### Instalação

```elixir
{:notifique, "~> 0.2.1"}
```

Depois `mix deps.get`.

### Início rápido

```elixir
client = Notifique.new("sua-api-key")
{:ok, body} = Notifique.Whatsapp.send_text(client, "instance-id", ["5511999999999"], "Olá!")
IO.inspect(body["data"]["messageIds"])
```

### Enviar SMS

```elixir
Notifique.Sms.send(client, %{"to" => ["5511999999999"], "message" => "Olá SMS!"})
```

### Enviar por canal

| Canal | Exemplo |
|-------|---------|
| WhatsApp | `Notifique.Whatsapp.send_text(client, instance_id, to, "Olá!")` |
| SMS | `Notifique.Sms.send(client, %{...})` |
| Email | `Notifique.Email.send(client, %{...})` |
| Push | `Notifique.Push.send_message(client, %{...})` |
| Telegram | `Notifique.TypedApi.Telegram.post_v1_telegram_send(telegram, body: %{...})` |
| Instagram | `Notifique.TypedApi.Instagram.send_message(instagram, body: %{...})` |
| RCS | `Notifique.TypedApi.Rcs.post_v1_rcs_send(rcs, body: %{...})` |
| Voz | `Notifique.TypedApi.Voice.post_v1_voice_calls(voice, body: %{...})` |

Use `api = Notifique.api(client)` e `Notifique.TypedApi.telegram(api)` para namespaces tipados.

### Webhooks e logs

```elixir
api = Notifique.api(client)
Notifique.TypedApi.Webhooks.list_webhooks(Notifique.TypedApi.webhooks(api), opts: [query: %{"limit" => "20"}])
Notifique.TypedApi.Logs.get_v1_logs(Notifique.TypedApi.logs(api), opts: [query: %{"page" => "1"}])
```

### Erros

Retorna `{:ok, body}` ou `{:error, %{status: code, body: body}}`.
