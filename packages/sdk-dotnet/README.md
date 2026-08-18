# Notifique .NET SDK

**[English](#english)** · **[Português](#português)** · Docs: [docs.notifique.dev](https://docs.notifique.dev)

---

## English

Server-side Notifique SDK for .NET 8+ (v0.2.1).

### Install

```bash
dotnet add package Notifique
```

### Quick start

```csharp
using Notifique;

var client = new NotifiqueClient("your-api-key");
var response = await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Hello!");
```

### Send SMS

```csharp
using Notifique.Models.Sms;

await client.Sms.SendAsync(new SmsSendParams { To = new List<string> { "5511999999999" }, Message = "Hello SMS!" });
```

### Send by channel

| Channel | Example |
|---------|---------|
| WhatsApp | `await client.WhatsApp.SendTextAsync(instanceId, phone, "Hello!")` |
| SMS | `await client.Sms.SendAsync(new SmsSendParams { ... })` |
| Email | `await client.Email.SendAsync(new EmailSendParams { ... })` |
| Push | `await client.Push.SendMessageAsync(new SendPushRequest { ... })` |
| Telegram | `await client.Api.Telegram.PostV1TelegramSendAsync(body)` |
| Instagram | `await client.Api.Instagram.SendMessageAsync(body)` |
| RCS | `await client.Api.Rcs.PostV1RcsSendAsync(body)` |
| Voice | `await client.Api.Voice.PostV1VoiceCallsAsync(body)` |

### Webhooks & logs

```csharp
using Notifique.Generated;

await client.Api.Webhooks.ListWebhooksAsync(new ApiRequestOptions { Query = new Dictionary<string, string> { ["limit"] = "20" } });
await client.Api.Logs.GetV1LogsAsync(new ApiRequestOptions { Query = new Dictionary<string, string> { ["page"] = "1" } });
```

### Errors

`NotifiqueApiException` on API errors (4xx/5xx).

---

## Português

SDK server-side Notifique para .NET 8+ (v0.2.1).

### Instalação

```bash
dotnet add package Notifique
```

### Início rápido

```csharp
var client = new NotifiqueClient("sua-api-key");
var response = await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Olá!");
```

### Enviar SMS

```csharp
await client.Sms.SendAsync(new SmsSendParams { To = new List<string> { "5511999999999" }, Message = "Olá SMS!" });
```

### Enviar por canal

| Canal | Exemplo |
|-------|---------|
| WhatsApp | `await client.WhatsApp.SendTextAsync(instanceId, telefone, "Olá!")` |
| SMS | `await client.Sms.SendAsync(new SmsSendParams { ... })` |
| Email | `await client.Email.SendAsync(new EmailSendParams { ... })` |
| Push | `await client.Push.SendMessageAsync(new SendPushRequest { ... })` |
| Telegram | `await client.Api.Telegram.PostV1TelegramSendAsync(body)` |
| Instagram | `await client.Api.Instagram.SendMessageAsync(body)` |
| RCS | `await client.Api.Rcs.PostV1RcsSendAsync(body)` |
| Voz | `await client.Api.Voice.PostV1VoiceCallsAsync(body)` |

### Webhooks e logs

```csharp
await client.Api.Webhooks.ListWebhooksAsync(new ApiRequestOptions { Query = new Dictionary<string, string> { ["limit"] = "20" } });
await client.Api.Logs.GetV1LogsAsync(new ApiRequestOptions { Query = new Dictionary<string, string> { ["page"] = "1" } });
```

### Erros

`NotifiqueApiException` em erros da API (4xx/5xx).
