defmodule Notifique.Messages do
  @moduledoc """
  Messages (templates) — POST /v1/templates/send
  Envio por template em múltiplos canais (whatsapp, sms, email).
  """

  def send(client, params, opts \\ []) do
    params = normalize_params(params)
    Notifique.request(client, :post, "/templates/send", params, opts)
  end

  defp normalize_params(params) when is_map(params) do
    params
    |> maybe_put_instance_id()
    |> maybe_put_from_name()
  end

  defp maybe_put_instance_id(params) do
    case Map.get(params, "instance_id") || Map.get(params, :instance_id) do
      nil -> params
      id ->
        params
        |> Map.delete("instance_id")
        |> Map.delete(:instance_id)
        |> Map.put("instanceId", id)
    end
  end

  defp maybe_put_from_name(params) do
    from_name = Map.get(params, "from_name") || Map.get(params, :from_name)
    from_name_api = Map.get(params, "fromName") || Map.get(params, :fromName)
    cond do
      is_binary(from_name) and is_nil(from_name_api) ->
        params
        |> Map.delete("from_name")
        |> Map.delete(:from_name)
        |> Map.put("fromName", from_name)
      true ->
        params
    end
  end
end
