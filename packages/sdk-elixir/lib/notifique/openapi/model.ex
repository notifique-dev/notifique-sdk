defmodule Notifique.OpenApi.Model do
  @moduledoc """
  Helpers para resolver módulos de modelos OpenAPI por nome de schema.
  """

  @spec module_for(String.t()) :: module()
  def module_for(schema_name) when is_binary(schema_name) do
    Module.concat(Notifique.OpenApi.Model, schema_name)
  end

  @spec decode_response(String.t() | nil, term()) :: term()
  def decode_response(nil, body), do: body
  def decode_response(_schema, nil), do: nil

  def decode_response(schema_name, body) when is_map(body) do
    Notifique.OpenApi.Deserializer.decode_map(body, module_for(schema_name))
  end

  def decode_response(_schema, body), do: body
end
