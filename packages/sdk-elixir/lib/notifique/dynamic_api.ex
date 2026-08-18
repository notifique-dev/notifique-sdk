defmodule Notifique.DynamicApi do
  @moduledoc """
  Dynamic OpenAPI client built from `priv/operations.json` at runtime.
  """

  @legacy_namespaces ~w(whatsapp sms email messages push)
  @operations_path Path.join(:code.priv_dir(:notifique), "operations.json")
  @external_resource @operations_path

  @doc """
  Builds a nested map of namespaces where leaf values are callable functions.
  """
  @spec build(Notifique.t()) :: map()
  def build(client) do
    operations()
    |> Enum.reduce(%{}, fn operation, acc ->
      put_operation(acc, client, operation)
    end)
  end

  @doc """
  Returns all operation paths as dot-separated strings (e.g. `"wellKnown.getJwks"`).
  """
  @spec operation_paths() :: [String.t()]
  def operation_paths do
    Enum.map(operations(), fn operation ->
      (operation["namespaces"] ++ [operation["methodName"]])
      |> Enum.join(".")
    end)
  end

  @doc """
  Returns the number of registered operations.
  """
  @spec count() :: non_neg_integer()
  def count, do: length(operations())

  @doc """
  Top-level namespace keys from the registry.
  """
  @spec top_level_namespaces() :: [String.t()]
  def top_level_namespaces do
    operations()
    |> Enum.map(fn operation -> List.first(operation["namespaces"]) end)
    |> Enum.reject(&is_nil/1)
    |> Enum.uniq()
  end

  @doc """
  Invokes a registered operation by dotted path (e.g. `"push.getV1PushApps"`).
  Used by the typed `Notifique.Generated.Api` modules.
  """
  @spec call_operation(Notifique.t(), String.t(), keyword()) :: {:ok, term()} | {:error, term()}
  def call_operation(client, dotted_path, opts \\ []) do
    parts = String.split(dotted_path, ".")
    method_name = List.last(parts)
    namespaces = Enum.drop(parts, -1)

    operation =
      Enum.find(operations(), fn op ->
        op["namespaces"] == namespaces && op["methodName"] == method_name
      end)

    case operation do
      nil ->
        {:error, {:unknown_operation, dotted_path}}

      op ->
        path_params = Keyword.get(opts, :path_params, %{})
        execute_opts =
          opts
          |> Keyword.drop([:path_params])
          |> normalize_opts()

        try do
          execute(client, op, path_params, execute_opts)
        rescue
          e -> {:error, e}
        end
    end
  end

  @doc false
  def legacy_namespaces, do: @legacy_namespaces

  defp operations do
    @operations_path
    |> File.read!()
    |> Jason.decode!()
    |> Map.fetch!("operations")
  end

  defp put_operation(tree, client, operation) do
    namespaces = operation["namespaces"]
    method = operation["methodName"]
    fun = build_fun(client, operation)
    insert_operation(tree, namespaces, method, fun)
  end

  defp insert_operation(tree, namespaces, method, fun) do
    case namespaces do
      [] ->
        Map.put(tree, method, fun)

      [head | rest] ->
        child =
          case Map.get(tree, head) do
            %{} = existing -> existing
            nil -> %{}
            other ->
              raise ArgumentError,
                    "namespace conflict at #{head}: expected map, got #{inspect(other)}"
          end

        Map.put(tree, head, insert_operation(child, rest, method, fun))
    end
  end

  defp build_fun(client, operation) do
    path_params = operation["pathParams"] || []

    if path_params == [] do
      fn opts ->
        execute(client, operation, %{}, normalize_opts(opts))
      end
    else
      fn path_params, opts ->
        execute(client, operation, path_params, normalize_opts(opts))
      end
    end
  end

  defp normalize_opts(nil), do: %{}
  defp normalize_opts(opts) when is_map(opts), do: opts
  defp normalize_opts(_), do: %{}

  defp execute(client, operation, path_params, opts) do
    url = build_url(operation["urlTemplate"], path_params)
    query = Map.get(opts, :query) || Map.get(opts, "query")

    url =
      case query do
        nil -> url
        %{} = q when map_size(q) == 0 -> url
        %{} = q -> url <> "?" <> URI.encode_query(q)
        _ -> url
      end

    body = Map.get(opts, :body) || Map.get(opts, "body")
    idempotency_key = Map.get(opts, :idempotency_key) || Map.get(opts, "idempotencyKey")

    headers =
      case idempotency_key do
        nil -> []
        key -> [{"idempotency-key", key}]
      end

    method =
      case String.downcase(operation["httpMethod"]) do
        "get" -> :get
        "post" -> :post
        "put" -> :put
        "patch" -> :patch
        "delete" -> :delete
        "head" -> :head
        "options" -> :options
        other -> raise ArgumentError, "unsupported HTTP method #{other}"
      end

    request_body =
      if method in [:get, :delete], do: nil, else: body

    Notifique.request_api(client, method, url, request_body, headers: headers)
  end

  defp build_url(template, path_params) do
    Enum.reduce(path_params, template, fn {key, value}, acc ->
      String.replace(acc, "{#{key}}", URI.encode(to_string(value)))
    end)
  end
end
