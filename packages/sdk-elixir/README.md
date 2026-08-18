# Notifique Elixir SDK

Official Notifique SDK for Elixir — **v0.2.1** with full OpenAPI v1 coverage (353 operations, 23 specs).

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-elixir) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Client-side push**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

---

SDK oficial Notifique para Elixir — **v0.2.1** com cobertura completa da API v1 OpenAPI (353 operações, 23 specs).

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-elixir) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Push no dispositivo**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Installation

```elixir
def deps do
  [{:notifique, "~> 0.2.1"}]
end
```

## Instalação

```elixir
def deps do
  [{:notifique, "~> 0.2.1"}]
end
```

## Quick start

```elixir
client = Notifique.new("your-api-key")

{:ok, body} = Notifique.Whatsapp.send_text(client, "instance-id", ["5511999999999"], "Hello!")
IO.inspect(body["data"]["messageIds"])
```

## Início rápido

```elixir
client = Notifique.new("sua-api-key")

{:ok, body} = Notifique.Whatsapp.send_text(client, "instance-id", ["5511999999999"], "Olá!")
IO.inspect(body["data"]["messageIds"])
```

## Send SMS

```elixir
Notifique.Sms.send(client, %{"to" => ["5511999999999"], "message" => "Hello via SMS!"})
Notifique.Sms.get(client, "sms-id")
Notifique.Sms.cancel(client, "sms-id")
```

## Enviar SMS

```elixir
Notifique.Sms.send(client, %{"to" => ["5511999999999"], "message" => "Olá via SMS!"})
Notifique.Sms.get(client, "sms-id")
Notifique.Sms.cancel(client, "sms-id")
```

## Send messages by channel

Typed API: `api = Notifique.api(client)` then `Notifique.TypedApi.*`.

### WhatsApp

```elixir
Notifique.Whatsapp.send_text(client, "instance-id", ["5511999999999"], "Hello!")
```

### SMS

```elixir
Notifique.Sms.send(client, %{"to" => ["5511999999999"], "message" => "SMS text"})
```

### Email

```elixir
Notifique.Email.send(client, %{
  "from" => "noreply@yourdomain.com",
  "to" => ["user@example.com"],
  "subject" => "Welcome",
  "html" => "<p>Hello!</p>"
})
```

### Push

```elixir
Notifique.Push.send_message(client, %{
  "to" => ["device-id"],
  "type" => "push",
  "payload" => %{"title" => "Title", "body" => "Body"}
})
```

### Telegram

```elixir
api = Notifique.api(client)
telegram = Notifique.TypedApi.telegram(api)

Notifique.TypedApi.Telegram.post_v1_telegram_send(telegram, body: %{
  "instanceId" => "inst_abc",
  "to" => ["@username"],
  "type" => "text",
  "payload" => %{"message" => "Hello!"}
})
```

### Instagram

```elixir
instagram = Notifique.TypedApi.instagram(api)

Notifique.TypedApi.Instagram.send_message(instagram, body: %{
  "instanceId" => "inst_abc",
  "to" => ["target_user"],
  "type" => "text",
  "payload" => %{"message" => "Hello!"}
})
```

### RCS

```elixir
rcs = Notifique.TypedApi.rcs(api)

Notifique.TypedApi.Rcs.post_v1_rcs_send(rcs, body: %{
  "to" => ["5511999999999"],
  "type" => "basic",
  "payload" => %{"message" => "Hello RCS!"}
})
```

### Voice

```elixir
voice = Notifique.TypedApi.voice(api)

Notifique.TypedApi.Voice.post_v1_voice_calls(voice, body: %{
  "from" => "5511987654321",
  "to" => ["5511999887766"],
  "type" => "speak",
  "payload" => %{"text" => "Hello! Test call.", "voice" => "female-natural"}
})
```

## Enviar mensagens por canal

API tipada: `api = Notifique.api(client)` e `Notifique.TypedApi.*`.

### WhatsApp

```elixir
Notifique.Whatsapp.send_text(client, "instance-id", ["5511999999999"], "Olá!")
```

### SMS

```elixir
Notifique.Sms.send(client, %{"to" => ["5511999999999"], "message" => "Texto SMS"})
```

### Email

```elixir
Notifique.Email.send(client, %{
  "from" => "noreply@seudominio.com",
  "to" => ["usuario@example.com"],
  "subject" => "Bem-vindo",
  "html" => "<p>Olá!</p>"
})
```

### Push

```elixir
Notifique.Push.send_message(client, %{
  "to" => ["device-id"],
  "type" => "push",
  "payload" => %{"title" => "Título", "body" => "Corpo"}
})
```

### Telegram

```elixir
telegram = Notifique.TypedApi.telegram(api)

Notifique.TypedApi.Telegram.post_v1_telegram_send(telegram, body: %{
  "instanceId" => "inst_abc",
  "to" => ["@usuario"],
  "type" => "text",
  "payload" => %{"message" => "Olá!"}
})
```

### Instagram

```elixir
instagram = Notifique.TypedApi.instagram(api)

Notifique.TypedApi.Instagram.send_message(instagram, body: %{
  "instanceId" => "inst_abc",
  "to" => ["usuario_alvo"],
  "type" => "text",
  "payload" => %{"message" => "Olá!"}
})
```

### RCS

```elixir
rcs = Notifique.TypedApi.rcs(api)

Notifique.TypedApi.Rcs.post_v1_rcs_send(rcs, body: %{
  "to" => ["5511999999999"],
  "type" => "basic",
  "payload" => %{"message" => "Olá RCS!"}
})
```

### Voz

```elixir
voice = Notifique.TypedApi.voice(api)

Notifique.TypedApi.Voice.post_v1_voice_calls(voice, body: %{
  "from" => "5511987654321",
  "to" => ["5511999887766"],
  "type" => "speak",
  "payload" => %{"text" => "Olá! Ligação de teste.", "voice" => "female-natural"}
})
```

## Webhooks & logs

```elixir
webhooks = Notifique.TypedApi.webhooks(api)
logs = Notifique.TypedApi.logs(api)

Notifique.TypedApi.Webhooks.list_webhooks(webhooks, opts: [query: %{"page" => "1", "limit" => "20"}])
Notifique.TypedApi.Logs.get_v1_logs(logs, opts: [query: %{"page" => "1", "limit" => "50"}])
Notifique.TypedApi.Logs.get_v1_logs_by_id(logs, "log-id")
Notifique.TypedApi.Webhooks.list_deliveries(webhooks, opts: [query: %{"limit" => "20"}])
```

## Webhooks e logs

```elixir
webhooks = Notifique.TypedApi.webhooks(api)
logs = Notifique.TypedApi.logs(api)

Notifique.TypedApi.Webhooks.list_webhooks(webhooks, opts: [query: %{"page" => "1", "limit" => "20"}])
Notifique.TypedApi.Logs.get_v1_logs(logs, opts: [query: %{"page" => "1", "limit" => "50"}])
Notifique.TypedApi.Logs.get_v1_logs_by_id(logs, "log-id")
Notifique.TypedApi.Webhooks.list_deliveries(webhooks, opts: [query: %{"limit" => "20"}])
```

## Full API

- **353 operations**, legacy `Notifique.Whatsapp`, `Notifique.Sms`, …
- **Typed**: `Notifique.TypedApi` (Dialyzer-friendly)
- Elixir ~> 1.14, Req ~> 0.4, Jason ~> 1.4
- Returns `{:ok, body}` or `{:error, %{status: code, body: body}}`

Regenerate: `npm run generate` in monorepo root.

## API completa

- **353 operações**, legado `Notifique.Whatsapp`, `Notifique.Sms`, …
- **Tipado**: `Notifique.TypedApi` (Dialyzer)
- Elixir ~> 1.14, Req ~> 0.4, Jason ~> 1.4
- Retorno `{:ok, body}` ou `{:error, %{status: code, body: body}}`

Regenerar: `npm run generate` na raiz do monorepo.
