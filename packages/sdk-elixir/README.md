# Notifique Elixir SDK

SDK oficial Notifique para Elixir — WhatsApp, SMS, Email, Push e envio por template.

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

## Messages (template)

- `Notifique.Messages.send(client, params)` — canais whatsapp, sms, email

## Retornos

- `{:ok, body}` ou `{:error, %{status: code, body: body}}`.
- Elixir ~> 1.14, Req ~> 0.4, Jason ~> 1.4
