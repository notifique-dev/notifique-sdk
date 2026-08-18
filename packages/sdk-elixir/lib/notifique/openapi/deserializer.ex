defmodule Notifique.OpenApi.Deserializer do
  @moduledoc """
  Deserializa JSON (mapas) em structs dos modelos OpenAPI gerados.
  """

  @spec jason_decode(binary(), module()) :: {:ok, struct()} | {:error, term()}
  def jason_decode(json, module) when is_binary(json) do
    json
    |> Jason.decode()
    |> case do
      {:ok, decoded} -> {:ok, to_struct(decoded, module)}
      {:error, _} = error -> error
    end
  end

  @spec decode_map(map(), module()) :: struct()
  def decode_map(map, module) when is_map(map) do
    to_struct(map, module)
  end

  @doc """
  Atualiza um struct ou mapa com deserialização de campo aninhado.
  """
  @spec deserialize(struct() | map(), atom(), :date | :datetime | :list | :map | :struct, module()) ::
          struct() | map()
  def deserialize(model, field, :struct, module) do
    current = get_field(model, field)

    updated =
      case current do
        nil -> nil
        value -> to_struct_impl(value, module)
      end

    put_field(model, field, updated)
  end

  def deserialize(model, field, :list, module) do
    current = get_field(model, field)

    updated =
      case current do
        nil -> nil
        list -> Enum.map(list, &to_struct_impl(&1, module))
      end

    put_field(model, field, updated)
  end

  defp get_field(model, field) when is_map(model) do
    Map.get(model, field) || Map.get(model, Atom.to_string(field))
  end

  defp put_field(model, field, value) when is_map(model) do
    model
    |> Map.put(field, value)
    |> Map.put(Atom.to_string(field), value)
  end

  def deserialize(model, field, :map, module) do
    maybe_transform_map = fn
      nil ->
        nil

      existing_value ->
        Map.new(existing_value, fn {key, value} -> {key, to_struct(value, module)} end)
    end

    Map.update!(model, field, maybe_transform_map)
  end

  def deserialize(model, field, :date, _) do
    value = Map.get(model, field)

    case is_binary(value) do
      true ->
        case Date.from_iso8601(value) do
          {:ok, date} -> Map.put(model, field, date)
          _ -> model
        end

      false ->
        model
    end
  end

  def deserialize(model, field, :datetime, _) do
    value = Map.get(model, field)

    case is_binary(value) do
      true ->
        case DateTime.from_iso8601(value) do
          {:ok, datetime, _offset} -> Map.put(model, field, datetime)
          _ -> model
        end

      false ->
        model
    end
  end

  @spec to_struct(term(), module()) :: term()
  def to_struct(value, module), do: to_struct_impl(value, module)

  defp to_struct_impl(nil, _), do: nil

  defp to_struct_impl(list, module) when is_list(list) and is_atom(module) do
    Enum.map(list, &to_struct_impl(&1, module))
  end

  defp to_struct_impl(map, module) when is_map(map) and is_atom(module) do
    model = struct(module)

    model
    |> Map.keys()
    |> List.delete(:__struct__)
    |> Enum.reduce(model, fn field, acc ->
      value = Map.get(map, field) || Map.get(map, Atom.to_string(field))
      Map.replace(acc, field, value)
    end)
    |> module.decode()
  end

  defp to_struct_impl(value, module) when is_atom(module) do
    module.decode(value)
  end
end
