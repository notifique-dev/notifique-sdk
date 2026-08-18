# Notifique .NET SDK

Official Notifique SDK for .NET — **v0.2.1** with full OpenAPI v1 coverage (353 operations, 23 specs).

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-dotnet) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Client-side push**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

---

SDK oficial Notifique para .NET — **v0.2.1** com cobertura completa da API v1 OpenAPI (353 operações, 23 specs).

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-dotnet) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Push no dispositivo**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Installation

```bash
dotnet add package Notifique
```

## Instalação

```bash
dotnet add package Notifique
```

Requirements: .NET 8.0+, no external dependencies.

Requisitos: .NET 8.0+, sem dependências externas.

## Quick start

```csharp
using Notifique;

var client = new NotifiqueClient("your-api-key");
var response = await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Hello!");
Console.WriteLine(string.Join(", ", response.Data.MessageIds));
```

## Início rápido

```csharp
using Notifique;

var client = new NotifiqueClient("sua-api-key");
var response = await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Olá!");
Console.WriteLine(string.Join(", ", response.Data.MessageIds));
```

## Send SMS

```csharp
using Notifique.Models.Sms;

await client.Sms.SendAsync(new SmsSendParams
{
    To = new List<string> { "5511999999999" },
    Message = "Hello via SMS!",
});
```

## Enviar SMS

```csharp
await client.Sms.SendAsync(new SmsSendParams
{
    To = new List<string> { "5511999999999" },
    Message = "Olá via SMS!",
});
```

## Send messages by channel

### WhatsApp

```csharp
await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Hello!");
```

### SMS

```csharp
await client.Sms.SendAsync(new SmsSendParams { To = new List<string> { "5511999999999" }, Message = "SMS text" });
```

### Email

```csharp
using Notifique.Models.Email;

await client.Email.SendAsync(new EmailSendParams
{
    From = "noreply@yourdomain.com",
    To = new List<string> { "user@example.com" },
    Subject = "Welcome",
    Html = "<p>Hello!</p>",
});
```

### Push

```csharp
using Notifique.Models.Push;

await client.Push.SendMessageAsync(new SendPushRequest
{
    To = new List<string> { "device-id" },
    Type = "push",
    Payload = new Dictionary<string, object> { ["title"] = "Title", ["body"] = "Body" },
});
```

### Telegram

```csharp
await client.Api.Telegram.PostV1TelegramSendAsync(new Notifique.OpenApi.Models.Model.NtfTgSendTelegramMessageRequest
{
    InstanceId = "inst_abc",
    To = new List<string> { "@username" },
    Type = "text",
    Payload = new Notifique.OpenApi.Models.Model.NtfTgSendTelegramMessageRequestPayload { Message = "Hello!" },
});
```

### Instagram

```csharp
await client.Api.Instagram.SendMessageAsync(new Notifique.OpenApi.Models.Model.NtfIgSendMessageBody
{
    InstanceId = "inst_abc",
    To = new List<string> { "target_user" },
    Type = "text",
    Payload = new Dictionary<string, object> { ["message"] = "Hello!" },
});
```

### RCS

```csharp
await client.Api.Rcs.PostV1RcsSendAsync(new Notifique.OpenApi.Models.Model.NtfRcsSendRcsRequest
{
    To = new List<string> { "5511999999999" },
    Type = "basic",
    Payload = new Dictionary<string, object> { ["message"] = "Hello RCS!" },
});
```

### Voice

```csharp
await client.Api.Voice.PostV1VoiceCallsAsync(new Notifique.OpenApi.Models.Model.NtfVoiceCreateBody
{
    From = "5511987654321",
    To = new List<string> { "5511999887766" },
    Type = "speak",
    Payload = new Dictionary<string, object> { ["text"] = "Hello! Test call.", ["voice"] = "female-natural" },
});
```

## Enviar mensagens por canal

### WhatsApp

```csharp
await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Olá!");
```

### SMS

```csharp
await client.Sms.SendAsync(new SmsSendParams { To = new List<string> { "5511999999999" }, Message = "Texto SMS" });
```

### Email

```csharp
await client.Email.SendAsync(new EmailSendParams
{
    From = "noreply@seudominio.com",
    To = new List<string> { "usuario@example.com" },
    Subject = "Bem-vindo",
    Html = "<p>Olá!</p>",
});
```

### Push

```csharp
await client.Push.SendMessageAsync(new SendPushRequest
{
    To = new List<string> { "device-id" },
    Type = "push",
    Payload = new Dictionary<string, object> { ["title"] = "Título", ["body"] = "Corpo" },
});
```

### Telegram

```csharp
await client.Api.Telegram.PostV1TelegramSendAsync(new Notifique.OpenApi.Models.Model.NtfTgSendTelegramMessageRequest
{
    InstanceId = "inst_abc",
    To = new List<string> { "@usuario" },
    Type = "text",
    Payload = new Notifique.OpenApi.Models.Model.NtfTgSendTelegramMessageRequestPayload { Message = "Olá!" },
});
```

### Instagram

```csharp
await client.Api.Instagram.SendMessageAsync(new Notifique.OpenApi.Models.Model.NtfIgSendMessageBody
{
    InstanceId = "inst_abc",
    To = new List<string> { "usuario_alvo" },
    Type = "text",
    Payload = new Dictionary<string, object> { ["message"] = "Olá!" },
});
```

### RCS

```csharp
await client.Api.Rcs.PostV1RcsSendAsync(new Notifique.OpenApi.Models.Model.NtfRcsSendRcsRequest
{
    To = new List<string> { "5511999999999" },
    Type = "basic",
    Payload = new Dictionary<string, object> { ["message"] = "Olá RCS!" },
});
```

### Voz

```csharp
await client.Api.Voice.PostV1VoiceCallsAsync(new Notifique.OpenApi.Models.Model.NtfVoiceCreateBody
{
    From = "5511987654321",
    To = new List<string> { "5511999887766" },
    Type = "speak",
    Payload = new Dictionary<string, object> { ["text"] = "Olá! Ligação de teste.", ["voice"] = "female-natural" },
});
```

## Webhooks & logs

```csharp
using Notifique.Generated;

await client.Api.Webhooks.ListWebhooksAsync(new ApiRequestOptions
{
    Query = new Dictionary<string, string> { ["page"] = "1", ["limit"] = "20" },
});
await client.Api.Logs.GetV1LogsAsync(new ApiRequestOptions
{
    Query = new Dictionary<string, string> { ["page"] = "1", ["limit"] = "50" },
});
await client.Api.Logs.GetV1LogsByIdAsync("log-id", null);
await client.Api.Webhooks.ListDeliveriesAsync(new ApiRequestOptions
{
    Query = new Dictionary<string, string> { ["limit"] = "20" },
});
```

## Webhooks e logs

```csharp
await client.Api.Webhooks.ListWebhooksAsync(new ApiRequestOptions
{
    Query = new Dictionary<string, string> { ["page"] = "1", ["limit"] = "20" },
});
await client.Api.Logs.GetV1LogsAsync(new ApiRequestOptions
{
    Query = new Dictionary<string, string> { ["page"] = "1", ["limit"] = "50" },
});
await client.Api.Logs.GetV1LogsByIdAsync("log-id", null);
await client.Api.Webhooks.ListDeliveriesAsync(new ApiRequestOptions
{
    Query = new Dictionary<string, string> { ["limit"] = "20" },
});
```

## Full API

- **353 operations**, legacy `WhatsApp`, `Sms`, `Email`, `Push`, `Messages`
- **Typed**: `client.Api.Telegram`, `client.Api.Webhooks`, …
- Errors: `NotifiqueApiException`

Regenerate: `npm run generate` in monorepo root.

## API completa

- **353 operações**, legado `WhatsApp`, `Sms`, `Email`, `Push`, `Messages`
- **Tipado**: `client.Api.Telegram`, `client.Api.Webhooks`, …
- Erros: `NotifiqueApiException`

Regenerar: `npm run generate` na raiz do monorepo.
