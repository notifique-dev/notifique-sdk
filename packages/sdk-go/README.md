# Notifique Go SDK

Official Notifique SDK for Go — **v0.2.1** with full OpenAPI v1 coverage (353 operations, 23 specs).

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-go) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Client-side push**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

---

SDK oficial Notifique para Go — **v0.2.1** com cobertura completa da API v1 OpenAPI (353 operações, 23 specs).

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-go) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Push no dispositivo**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Installation

```bash
go get github.com/notifique-dev/notifique-sdk/packages/sdk-go@v0.2.1
```

Module path: `github.com/notifique-dev/notifique-sdk/packages/sdk-go`

## Instalação

```bash
go get github.com/notifique-dev/notifique-sdk/packages/sdk-go@v0.2.1
```

Módulo: `github.com/notifique-dev/notifique-sdk/packages/sdk-go`

## Quick start

```go
import (
	"fmt"
	notifique "github.com/notifique-dev/notifique-sdk/packages/sdk-go"
)

client := notifique.NewClient("your-api-key")

resp, err := client.WhatsApp.SendText("instance-id", []string{"5511999999999"}, "Hello!")
if err != nil {
	panic(err)
}
fmt.Println(resp.Data.MessageIDs)
```

## Início rápido

```go
import (
	"fmt"
	notifique "github.com/notifique-dev/notifique-sdk/packages/sdk-go"
)

client := notifique.NewClient("sua-api-key")

resp, err := client.WhatsApp.SendText("instance-id", []string{"5511999999999"}, "Olá!")
if err != nil {
	panic(err)
}
fmt.Println(resp.Data.MessageIDs)
```

## Send SMS

```go
resp, err := client.Sms.Send(notifique.SmsSendParams{
	To:      []string{"5511999999999"},
	Message: "Hello via SMS!",
})
```

## Enviar SMS

```go
resp, err := client.Sms.Send(notifique.SmsSendParams{
	To:      []string{"5511999999999"},
	Message: "Olá via SMS!",
})
```

## Send messages by channel

Eight channels. Legacy shortcuts plus typed `client.Api.*` for all OpenAPI operations.

### WhatsApp

```go
client.WhatsApp.SendText("instance-id", []string{"5511999999999"}, "Hello!")
```

### SMS

```go
client.Sms.Send(notifique.SmsSendParams{To: []string{"5511999999999"}, Message: "SMS text"})
```

### Email

```go
client.Email.Send(notifique.EmailSendParams{
	From:    "noreply@yourdomain.com",
	To:      []string{"user@example.com"},
	Subject: "Welcome",
	Html:    "<p>Hello!</p>",
})
```

### Push

```go
client.Push.Messages.Send(notifique.SendPushParams{
	To:      []string{"device-id"},
	Type:    "push",
	Payload: map[string]any{"title": "Title", "body": "Body"},
})
```

### Telegram

```go
import "github.com/notifique-dev/notifique-sdk/packages/sdk-go/openapimodels"

msg := "Hello!"
client.Api.Telegram().PostV1TelegramSend(&openapimodels.NtfTgSendTelegramMessageRequest{
	InstanceId: "inst_abc",
	To:         []string{"@username"},
	Type:       "text",
	Payload:    openapimodels.NtfTgSendTelegramMessageRequestPayload{Message: &msg},
}, nil)
```

### Instagram

```go
client.Api.Instagram().SendMessage(&openapimodels.NtfIgSendMessageBody{
	InstanceId: "inst_abc",
	To:         []string{"target_user"},
	Type:       "text",
	Payload:    map[string]any{"message": "Hello!"},
}, nil)
```

### RCS

```go
client.Api.Rcs().PostV1RcsSend(&openapimodels.NtfRcsSendRcsRequest{
	To:      []string{"5511999999999"},
	Type:    "basic",
	Payload: map[string]any{"message": "Hello RCS!"},
}, nil)
```

### Voice

```go
client.Api.Voice().PostV1VoiceCalls(&openapimodels.NtfVoiceCreateBody{
	From:    "5511987654321",
	To:      []string{"5511999887766"},
	Type:    "speak",
	Payload: map[string]any{"text": "Hello! Test call.", "voice": "female-natural"},
}, nil)
```

## Enviar mensagens por canal

Oito canais. Atalhos legados e `client.Api.*` tipado para todas as operações OpenAPI.

### WhatsApp

```go
client.WhatsApp.SendText("instance-id", []string{"5511999999999"}, "Olá!")
```

### SMS

```go
client.Sms.Send(notifique.SmsSendParams{To: []string{"5511999999999"}, Message: "Texto SMS"})
```

### Email

```go
client.Email.Send(notifique.EmailSendParams{
	From:    "noreply@seudominio.com",
	To:      []string{"usuario@example.com"},
	Subject: "Bem-vindo",
	Html:    "<p>Olá!</p>",
})
```

### Push

```go
client.Push.Messages.Send(notifique.SendPushParams{
	To:      []string{"device-id"},
	Type:    "push",
	Payload: map[string]any{"title": "Título", "body": "Corpo"},
})
```

### Telegram

```go
msg := "Olá!"
client.Api.Telegram().PostV1TelegramSend(&openapimodels.NtfTgSendTelegramMessageRequest{
	InstanceId: "inst_abc",
	To:         []string{"@usuario"},
	Type:       "text",
	Payload:    openapimodels.NtfTgSendTelegramMessageRequestPayload{Message: &msg},
}, nil)
```

### Instagram

```go
client.Api.Instagram().SendMessage(&openapimodels.NtfIgSendMessageBody{
	InstanceId: "inst_abc",
	To:         []string{"usuario_alvo"},
	Type:       "text",
	Payload:    map[string]any{"message": "Olá!"},
}, nil)
```

### RCS

```go
client.Api.Rcs().PostV1RcsSend(&openapimodels.NtfRcsSendRcsRequest{
	To:      []string{"5511999999999"},
	Type:    "basic",
	Payload: map[string]any{"message": "Olá RCS!"},
}, nil)
```

### Voz

```go
client.Api.Voice().PostV1VoiceCalls(&openapimodels.NtfVoiceCreateBody{
	From:    "5511987654321",
	To:      []string{"5511999887766"},
	Type:    "speak",
	Payload: map[string]any{"text": "Olá! Ligação de teste.", "voice": "female-natural"},
}, nil)
```

## Webhooks & logs

```go
client.Api.Webhooks().ListWebhooks(nil, nil, nil) // page, limit
client.Api.Logs().GetV1Logs(nil, nil, nil, nil, nil, nil, nil, nil)
client.Api.Logs().GetV1LogsById("log-id", nil)
client.Api.Webhooks().ListDeliveries(nil, nil, nil, nil, nil, nil)
```

## Webhooks e logs

```go
client.Api.Webhooks().ListWebhooks(nil, nil, nil)
client.Api.Logs().GetV1Logs(nil, nil, nil, nil, nil, nil, nil, nil)
client.Api.Logs().GetV1LogsById("log-id", nil)
client.Api.Webhooks().ListDeliveries(nil, nil, nil, nil, nil, nil)
```

## Full API

- `client.Api` — typed tree (353 ops)
- `client.API()` / `client.DynamicAPI()` — dynamic `Call("telegram.postV1TelegramSend", opts)`
- Legacy: `WhatsApp`, `Sms`, `Email`, `Push`, `Messages`
- Go 1.20+

Regenerate: `npm run generate` in monorepo root (requires [notifique-docs](https://github.com/notifique-dev/notifique-docs)).

## API completa

- `client.Api` — árvore tipada (353 ops)
- `client.API()` / `client.DynamicAPI()` — dinâmico `Call("telegram.postV1TelegramSend", opts)`
- Legado: `WhatsApp`, `Sms`, `Email`, `Push`, `Messages`
- Go 1.20+

Regenerar: `npm run generate` na raiz do monorepo (requer [notifique-docs](https://github.com/notifique-dev/notifique-docs)).

## Errors

On 4xx/5xx the SDK returns `*notifique.APIError` with `Code` and `Body`.

## Erros

Em 4xx/5xx o SDK retorna `*notifique.APIError` com `Code` e `Body`.
