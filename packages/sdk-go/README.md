# Notifique Go SDK

SDK oficial Notifique para Go — **v0.2.0** com cobertura completa da API v1 OpenAPI.

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk)

## Cobertura completa da API (v0.2.0)

- **353 operações** em **23 specs** OpenAPI
- **Namespaces legados** (atalhos tipados): `WhatsApp`, `Sms`, `Email`, `Push`, `Messages`
- **Cliente gerado**: `client.API()` — árvore dinâmica a partir de `operations.json`
- **Chamada por ID**: `client.API().Call("whatsapp.getV1WhatsappMessages", opts)`
- **Navegação**: `ns, _ := client.API().Navigate("oauth", "apps"); ns.Call("rotateWorkspaceAppSecret", opts)`

```go
api := client.API()

// Por operation path
_, err := api.Call("whatsapp.getV1WhatsappMessages", notifique.DynamicRequestOptions{
    Query: map[string]string{"page": "1", "limit": "20"},
})

// Por namespace
oauthApps, err := api.Navigate("oauth", "apps")
_, err = oauthApps.Call("rotateWorkspaceAppSecret", notifique.DynamicRequestOptions{
    PathParams: map[string]string{"id": "app-id"},
})
```

Regenerar bindings a partir de [notifique-docs](https://github.com/notifique-dev/notifique-docs): `npm run generate` (na raiz do monorepo).

**Push no dispositivo** (Web/RN/Flutter/Android/iOS): [notifique-dev/notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Instalação

```bash
go get github.com/notifique/notifique-sdk-go
```

## Uso rápido

```go
package main

import (
	"fmt"
	"github.com/notifique/notifique-sdk-go"
)

func main() {
	// NewClient panics on empty key; use NewClientWithConfig for error-returning variant.
	client := notifique.NewClient("your-api-key") // default base URL: https://api.notifique.dev/v1

	// Or with explicit error handling:
	// client, err := notifique.NewClientWithConfig(notifique.Config{APIKey: "...", BaseURL: "..."})
	// if err != nil { log.Fatal(err) }
	instanceID := "sua-instancia-whatsapp"
	to := []string{"5511999999999"}

	// WhatsApp — Send/SendText retornam envelope; use .Data para message_ids
	resp, err := client.WhatsApp.SendText(instanceID, to, "Olá!")
	if err != nil {
		if apiErr, ok := err.(*notifique.APIError); ok {
			fmt.Printf("API erro %d: %s\n", apiErr.Code, apiErr.Body)
			return
		}
		panic(err)
	}
	fmt.Printf("Enviado: %v\n", resp.Data.MessageIDs)
}
```

## WhatsApp

- **POST /v1/whatsapp/messages** — `Send(instanceID, params)` / `SendText(instanceID, to, text)` → `*WhatsAppSendEnvelope` (use `.Data`)
- **GET /v1/whatsapp/messages** — `ListMessages(params)`
- **GET /v1/whatsapp/messages/:id** — `GetMessage(id)` → `*WhatsAppMessageEnvelope` (use `.Data`)
- **GET /v1/whatsapp/instances/:id/qr** — `GetInstanceQr(instanceID)`
- Delete, Edit, Cancel, ListInstances, GetInstance, CreateInstance, Disconnect, DeleteInstance

## SMS

- `Send(params)`, `Get(id)`, `Cancel(id)`

## Email

- `Send(params)`, `Get(id)`, `Cancel(id)`
- **Domínios** — `client.Email.Domains().List()`, `Create(req)`, `Get(id)`, `Verify(id)`

## Push

- **Apps** — `client.Push.Apps.List(params)`, `Get(id)`, `Create(name)`, `Update(id, body)`, `Delete(id)`
- **Devices** — `client.Push.Devices.Register(params)`, `List(params)`, `Get(id)`, `Delete(id)`
- **Messages** — `client.Push.Messages.Send(params)`, `List(params)`, `Get(id)`, `Cancel(id)`

Contrato canônico de envio (`SendPushParams`): `to` + `type` (`push` ou `template`) + `payload` → resposta com `data.messageIds` (não `pushIds`):

```go
resp, err := client.Push.Messages.Send(notifique.SendPushParams{
    To:   []string{deviceID},
    Type: "push",
    Payload: map[string]any{"title": "Título", "body": "Corpo"},
})
fmt.Println(resp.Data.MessageIDs)
```

## Messages (template)

- `client.Messages.Send(params)` — canais whatsapp, sms, email

## Compatibilidade

- `notifique.Client` é alias de `notifique.Notifique`; `NewClient` retorna `*Notifique`.
- Em 4xx/5xx o SDK retorna `*notifique.APIError` com `Code` e `Body`.
- `NewClientWithConfig` exige `BaseURL` HTTPS por padrão (`AllowInsecureHTTP` existe apenas para cenários controlados de teste/local).
- Go 1.20+
