# Notifique SDK Example em Elixir

client = Notifique.new("your_api_key_here")
phone_id = "your_phone_id_here"
recipient = "5511999999999"

IO.puts("--- Notifique Elixir SDK Example ---")

IO.puts("\n1. Sending text...")
case Notifique.Whatsapp.send_text(client, phone_id, [recipient], "Hello from Elixir! 💧") do
  {:ok, body} -> IO.inspect(body, label: "Success")
  {:error, reason} -> IO.puts("Error: #{inspect(reason)}")
end

IO.puts("\n2. Sending with params...")
params = %{
  "to" => [recipient],
  "type" => "text",
  "payload" => %{"message" => "Hello from Notifique!"}
}
case Notifique.Whatsapp.send(client, phone_id, params) do
  {:ok, body} -> IO.inspect(body, label: "Success")
  {:error, reason} -> IO.puts("Error: #{inspect(reason)}")
end
