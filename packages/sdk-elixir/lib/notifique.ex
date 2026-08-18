defmodule Notifique do
  @moduledoc """
  Cliente Notifique — WhatsApp, SMS, Email, Push e envio por template (messages).
  """

  defstruct [:api_key, :base_url, :api, :dynamic_api]

  @type t :: %__MODULE__{
          api_key: String.t(),
          base_url: String.t(),
          api: Notifique.TypedApi.t() | nil,
          dynamic_api: map() | nil
        }

  @doc """
  Inicializa um novo cliente Notifique.
  base_url padrão: https://api.notifique.dev/v1
  """
  def new(api_key, base_url \\ "https://api.notifique.dev/v1") do
    if !is_binary(api_key) or String.trim(api_key) == "" do
      raise ArgumentError, "api_key must be a non-empty string"
    end

    uri = URI.parse(base_url)
    if uri.scheme != "https" or is_nil(uri.host) do
      raise ArgumentError, "base_url must be an absolute HTTPS URL"
    end

    client = %__MODULE__{
      api_key: api_key,
      base_url: String.trim_trailing(base_url, "/")
    }

    typed = Notifique.TypedApi.new(client)

    %{
      client
      | api: typed,
        dynamic_api: Notifique.DynamicApi.build(client)
    }
  end

  @doc """
  Returns the typed OpenAPI API (`Notifique.TypedApi`) for IDE/Dialyzer autocomplete.
  """
  @spec api(t()) :: Notifique.TypedApi.t()
  def api(%__MODULE__{api: api}) when not is_nil(api), do: api

  @doc """
  Returns the dynamic OpenAPI map (353 operações) para introspect ou testes de cobertura.
  """
  @spec dynamic_api(t()) :: map()
  def dynamic_api(%__MODULE__{dynamic_api: dynamic_api}) when is_map(dynamic_api), do: dynamic_api

  @doc """
  Returns a top-level namespace from the dynamic API (non-legacy namespaces).
  """
  @spec namespace(t(), String.t()) :: map() | nil
  def namespace(client, name) do
    get_in(dynamic_api(client), [name])
  end

  @doc """
  Executa a requisição HTTP.
  Em status >= 400 retorna `{:error, %{status: code, body: body}}`.
  Caso contrário retorna `{:ok, body}` (body é o JSON decodificado).
  """
  def request(client, method, path, body \\ nil, opts \\ []) do
    url =
      if Keyword.get(opts, :absolute, false) do
        path
      else
        client.base_url <> path
      end

    opts = Keyword.delete(opts, :absolute)
    {adapter, opts} = Keyword.pop(opts, :adapter)
    extra_headers = Keyword.get(opts, :headers, [])
    opts = Keyword.delete(opts, :headers)

    base = [
      method: method,
      url: url,
      receive_timeout: 30_000,
      headers: [
        {"content-type", "application/json"},
        {"user-agent", "Notifique-Elixir-SDK/0.2.0"}
      ] ++ extra_headers
    ]

    options =
      base
      |> Keyword.put(:auth, {:bearer, client.api_key})
      |> maybe_put_json(body)
      |> Keyword.merge(opts)

    if adapter do
      req = %Req.Request{method: method, url: url, options: Keyword.put(options, :json, body)}
      {_req, %Req.Response{} = resp} = adapter.(req)
      case resp.status do
        status when status >= 200 and status < 300 -> {:ok, resp.body}
        status when status >= 400 -> {:error, %{status: status, body: resp.body}}
      end
    else
      case Req.request(options) do
        {:ok, %{status: status, body: resp_body}} when status >= 200 and status < 300 ->
          {:ok, resp_body}

        {:ok, %{status: status, body: resp_body}} when status >= 400 ->
          {:error, %{status: status, body: resp_body}}

        {:error, reason} ->
          {:error, reason}
      end
    end
  end

  @doc """
  Executes a request using an absolute OpenAPI path (e.g. `/v1/oauth/apps`).
  """
  @spec request_api(t(), atom(), String.t(), term(), keyword()) ::
          {:ok, term()} | {:error, term()}
  def request_api(client, method, path, body \\ nil, opts \\ []) do
    api_base =
      client.base_url
      |> String.trim_trailing("/")
      |> String.replace_suffix("/v1", "")

    full_url = api_base <> path
    request(client, method, full_url, body, Keyword.put(opts, :absolute, true))
  end

  defp maybe_put_json(opts, nil), do: opts
  defp maybe_put_json(opts, body), do: Keyword.put(opts, :json, body)

  def encode_path_segment(segment), do: URI.encode(segment, &URI.char_unreserved?/1)
end
