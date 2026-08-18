# Notifique Elixir SDK

SDK oficial Notifique para Elixir — **v0.2.0** com cobertura completa da API v1 OpenAPI.

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk)

## Cobertura completa da API (v0.2.0)

- **353 operações** em **23 specs** OpenAPI
- **Namespaces legados** (atalhos tipados): `Notifique.Whatsapp`, `Notifique.Sms`, `Notifique.Email`, `Notifique.Push`, `Notifique.Messages`
- **Cliente gerado**: `client.api` — mapa dinâmico a partir de `operations.json`
- **Namespaces na raiz**: `Notifique.namespace(client, "oauth")`, `Notifique.namespace(client, "contacts")`, …

```elixir
client = Notifique.new("sua-api-key")
api = Notifique.api(client)

# API completa (chaves string, métodos camelCase do OpenAPI)
{:ok, body} = get_in(api, ["contacts", "getV1Contacts"]).(%{query: %{"limit" => "20"}})

# Namespace OAuth aninhado
oauth = Notifique.namespace(client, "oauth")
{:ok, _} = get_in(oauth, ["apps", "rotateWorkspaceAppSecret"]).(%{"id" => "app-id"}, %{})
```

Regenerar bindings a partir de [notifique-docs](https://github.com/notifique-dev/notifique-docs): `npm run generate` (na raiz do monorepo).

**Push no dispositivo** (Web/RN/Flutter/Android/iOS): [notifique-dev/notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Instalação

No `mix.exs`:

```elixir
def deps do
  [
    {:notifique, "~> 0.2.0"}
  ]
end
```

## Uso rápido

```elixir
client = Notifique.new("sua-api-key")
instance_id = "sua-instancia-whatsapp"

case Notifique.Whatsapp.send_text(client, instance_id, ["5511999999999"], "Olá!") do
  {:ok, body} -> IO.inspect(body["data"]["messageIds"])
  {:error, %{status: code, body: body}} -> IO.puts("API erro #{code}: #{inspect(body)}")
  {:error, reason} -> IO.puts("Erro: #{inspect(reason)}")
end
```

## WhatsApp

- `send`, `send_text` — retornam envelope `success`/`data`
- `list_messages(client, params)` — GET /v1/whatsapp/messages
- `get_message`, `get_instance_qr(client, instance_id)`
- `delete_message`, `edit_message`, `cancel_message`
- `list_instances`, `get_instance`, `create_instance`, `disconnect_instance`, `delete_instance`

## SMS

- `Notifique.Sms.send(client, params)`, `get(client, id)`, `cancel(client, id)`

## Email

- `Notifique.Email.send(client, params)`, `get(client, id)`, `cancel(client, id)`
- **Domínios** — `Notifique.EmailDomains.list(client)`, `create(client, %{"domain" => "..."})`, `get(client, id)`, `verify(client, id)`

## Push

- **Apps** — `Notifique.Push.list_apps`, `get_app`, `create_app`, `update_app`, `delete_app`
- **Devices** — `Notifique.Push.register_device`, `list_devices`, `get_device`, `delete_device`
- **Messages** — `Notifique.Push.send_message`, `list_messages`, `get_message`, `cancel_message`

Contrato canônico de envio: `to` + `type` + `payload` → `data.messageIds` (não `pushIds`):

```elixir
{:ok, body} = Notifique.Push.send_message(client, %{
  "to" => [device_id],
  "type" => "push",
  "payload" => %{"title" => "Título", "body" => "Corpo"}
})
IO.inspect(body["data"]["messageIds"])
```

## Messages (template)

- `Notifique.Messages.send(client, params)` — canais whatsapp, sms, email

## Retornos

- `{:ok, body}` ou `{:error, %{status: code, body: body}}`.
- Elixir ~> 1.14, Req ~> 0.4, Jason ~> 1.4
