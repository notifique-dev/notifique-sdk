# Notifique Go SDK

**[English](#english)** · **[Português](#português)** · Docs: [docs.notifique.dev](https://docs.notifique.dev)

---

## English

Server-side Notifique SDK for Go (v0.2.1).

### Install

```bash
go get github.com/notifique-dev/notifique-sdk/packages/sdk-go@v0.2.1
```

```go
import notifique "github.com/notifique-dev/notifique-sdk/packages/sdk-go"
```

### Quick start

```go
client := notifique.NewClient("your-api-key")
resp, err := client.WhatsApp.SendText("instance-id", []string{"5511999999999"}, "Hello!")
fmt.Println(resp.Data.MessageIDs)
```

### Send SMS

```go
client.Sms.Send(notifique.SmsSendParams{To: []string{"5511999999999"}, Message: "Hello SMS!"})
```

### Send by channel

| Channel | Example |
|---------|---------|
| WhatsApp | `client.WhatsApp.SendText(instanceID, to, "Hello!")` |
| SMS | `client.Sms.Send(notifique.SmsSendParams{...})` |
| Email | `client.Email.Send(notifique.EmailSendParams{...})` |
| Push | `client.Push.Messages.Send(notifique.SendPushParams{To, Type, Payload})` |
| Telegram | `client.Api.Telegram().PostV1TelegramSend(body, nil)` |
| Instagram | `client.Api.Instagram().SendMessage(body, nil)` |
| RCS | `client.Api.Rcs().PostV1RcsSend(body, nil)` |
| Voice | `client.Api.Voice().PostV1VoiceCalls(body, nil)` |

### Webhooks & logs

```go
client.Api.Webhooks().ListWebhooks(nil, nil, nil)
client.Api.Logs().GetV1Logs(nil, nil, nil, nil, nil, nil, nil, nil)
client.Api.Webhooks().ListDeliveries(nil, nil, nil, nil, nil, nil)
```

### Errors

On 4xx/5xx, errors are `*notifique.APIError` with `Code` and `Body`.

---

## Português

SDK server-side Notifique para Go (v0.2.1).

### Instalação

```bash
go get github.com/notifique-dev/notifique-sdk/packages/sdk-go@v0.2.1
```

```go
import notifique "github.com/notifique-dev/notifique-sdk/packages/sdk-go"
```

### Início rápido

```go
client := notifique.NewClient("sua-api-key")
resp, err := client.WhatsApp.SendText("instance-id", []string{"5511999999999"}, "Olá!")
fmt.Println(resp.Data.MessageIDs)
```

### Enviar SMS

```go
client.Sms.Send(notifique.SmsSendParams{To: []string{"5511999999999"}, Message: "Olá SMS!"})
```

### Enviar por canal

| Canal | Exemplo |
|-------|---------|
| WhatsApp | `client.WhatsApp.SendText(instanceID, to, "Olá!")` |
| SMS | `client.Sms.Send(notifique.SmsSendParams{...})` |
| Email | `client.Email.Send(notifique.EmailSendParams{...})` |
| Push | `client.Push.Messages.Send(notifique.SendPushParams{...})` |
| Telegram | `client.Api.Telegram().PostV1TelegramSend(body, nil)` |
| Instagram | `client.Api.Instagram().SendMessage(body, nil)` |
| RCS | `client.Api.Rcs().PostV1RcsSend(body, nil)` |
| Voz | `client.Api.Voice().PostV1VoiceCalls(body, nil)` |

### Webhooks e logs

```go
client.Api.Webhooks().ListWebhooks(nil, nil, nil)
client.Api.Logs().GetV1Logs(nil, nil, nil, nil, nil, nil, nil, nil)
client.Api.Webhooks().ListDeliveries(nil, nil, nil, nil, nil, nil)
```

### Erros

Em 4xx/5xx, o erro é `*notifique.APIError` com `Code` e `Body`.
