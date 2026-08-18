defmodule Notifique.TypedApi do
  @moduledoc """
  API OpenAPI tipada — namespaces, query, body e retorno com `@spec` para Dialyzer/IDE.
  Acesse via `Notifique.api(client)` após `Notifique.new/2`.
  """

  defstruct [:client]

  @type t :: %__MODULE__{client: Notifique.t()}

  @spec new(Notifique.t()) :: t()
  def new(client), do: %__MODULE__{client: client}

  @spec well_known(t()) :: WellKnown.t()
  def well_known(%__MODULE__{} = api), do: Notifique.TypedApi.WellKnown.new(api)

  defmodule WellKnown do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_jwks(WellKnown.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthGetJwksResponse.t()} | {:error, term()}
    def get_jwks(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "wellKnown.getJwks", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthGetJwksResponse", body)}
        error -> error
      end
    end

    @spec get_authorization_server_metadata(WellKnown.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthGetAuthorizationServerMetadataResponse.t()} | {:error, term()}
    def get_authorization_server_metadata(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "wellKnown.getAuthorizationServerMetadata", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthGetAuthorizationServerMetadataResponse", body)}
        error -> error
      end
    end

    @spec get_protected_resource_metadata(WellKnown.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthGetProtectedResourceMetadataResponse.t()} | {:error, term()}
    def get_protected_resource_metadata(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "wellKnown.getProtectedResourceMetadata", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthGetProtectedResourceMetadataResponse", body)}
        error -> error
      end
    end

  end

  @spec oauth(t()) :: Oauth.t()
  def oauth(%__MODULE__{} = api), do: Notifique.TypedApi.Oauth.new(api)

  defmodule Oauth do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec authorize(Oauth.t(), client_id: String.t() | nil, response_type: String.t() | nil, redirect_uri: String.t() | nil, scope: String.t() | nil, state: String.t() | nil, code_challenge: String.t() | nil, code_challenge_method: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthAuthorizeResponse.t()} | {:error, term()}
    def authorize(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :client_id), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "client_id", Keyword.get(opts, :client_id))), else: opts
      opts = if Keyword.has_key?(opts, :response_type), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "response_type", Keyword.get(opts, :response_type))), else: opts
      opts = if Keyword.has_key?(opts, :redirect_uri), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "redirect_uri", Keyword.get(opts, :redirect_uri))), else: opts
      opts = if Keyword.has_key?(opts, :scope), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "scope", Keyword.get(opts, :scope))), else: opts
      opts = if Keyword.has_key?(opts, :state), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "state", Keyword.get(opts, :state))), else: opts
      opts = if Keyword.has_key?(opts, :code_challenge), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "code_challenge", Keyword.get(opts, :code_challenge))), else: opts
      opts = if Keyword.has_key?(opts, :code_challenge_method), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "code_challenge_method", Keyword.get(opts, :code_challenge_method))), else: opts
      case Notifique.DynamicApi.call_operation(client, "oauth.authorize", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthAuthorizeResponse", body)}
        error -> error
      end
    end

    @spec register_client(Oauth.t(), body: Notifique.OpenApi.Model.NtfOauthClientRegistration.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthRegisterClientResponse.t()} | {:error, term()}
    def register_client(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "oauth.registerClient", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthRegisterClientResponse", body)}
        error -> error
      end
    end

    @spec revoke(Oauth.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthRevokeResponse.t()} | {:error, term()}
    def revoke(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "oauth.revoke", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthRevokeResponse", body)}
        error -> error
      end
    end

    @spec token(Oauth.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthTokenResponse.t()} | {:error, term()}
    def token(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "oauth.token", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthTokenResponse", body)}
        error -> error
      end
    end

    @spec list_workspace_apps(Oauth.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthListWorkspaceAppsResponse.t()} | {:error, term()}
    def list_workspace_apps(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "oauth.listWorkspaceApps", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthListWorkspaceAppsResponse", body)}
        error -> error
      end
    end

    @spec create_workspace_app(Oauth.t(), body: Notifique.OpenApi.Model.NtfOauthWorkspaceAppCreate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthCreateWorkspaceAppResponse.t()} | {:error, term()}
    def create_workspace_app(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "oauth.createWorkspaceApp", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthCreateWorkspaceAppResponse", body)}
        error -> error
      end
    end

    @spec delete_workspace_app(Oauth.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthDeleteWorkspaceAppResponse.t()} | {:error, term()}
    def delete_workspace_app(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "oauth.deleteWorkspaceApp", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthDeleteWorkspaceAppResponse", body)}
        error -> error
      end
    end

    @spec get_workspace_app(Oauth.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthGetWorkspaceAppResponse.t()} | {:error, term()}
    def get_workspace_app(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "oauth.getWorkspaceApp", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthGetWorkspaceAppResponse", body)}
        error -> error
      end
    end

    @spec update_workspace_app(Oauth.t(), String.t(), body: Notifique.OpenApi.Model.NtfOauthWorkspaceAppPatch.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthUpdateWorkspaceAppResponse.t()} | {:error, term()}
    def update_workspace_app(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "oauth.updateWorkspaceApp", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthUpdateWorkspaceAppResponse", body)}
        error -> error
      end
    end

    @spec list_connections(Oauth.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthListConnectionsResponse.t()} | {:error, term()}
    def list_connections(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "oauth.listConnections", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthListConnectionsResponse", body)}
        error -> error
      end
    end

    @spec apps(t()) :: Apps.t()
    def apps(%__MODULE__{api: api}), do: Notifique.TypedApi.Oauth.Apps.new(api)

    defmodule Apps do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec rotate_workspace_app_secret(Apps.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthRotateWorkspaceAppSecretResponse.t()} | {:error, term()}
      def rotate_workspace_app_secret(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "oauth.apps.rotateWorkspaceAppSecret", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthRotateWorkspaceAppSecretResponse", body)}
          error -> error
        end
      end

    end

    @spec connections(t()) :: Connections.t()
    def connections(%__MODULE__{api: api}), do: Notifique.TypedApi.Oauth.Connections.new(api)

    defmodule Connections do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec revoke_connection(Connections.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfOauthRevokeConnectionResponse.t()} | {:error, term()}
      def revoke_connection(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "oauth.connections.revokeConnection", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfOauthRevokeConnectionResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec public(t()) :: Public.t()
  def public(%__MODULE__{} = api), do: Notifique.TypedApi.Public.new(api)

  defmodule Public do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec ai_widget(t()) :: AiWidget.t()
    def ai_widget(%__MODULE__{api: api}), do: Notifique.TypedApi.Public.AiWidget.new(api)

    defmodule AiWidget do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec get_config(AiWidget.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.WidgetConfigResponse.t()} | {:error, term()}
      def get_config(%__MODULE__{api: %Notifique.TypedApi{client: client}}, publicKey, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"publicKey" => publicKey})
        case Notifique.DynamicApi.call_operation(client, "public.aiWidget.getConfig", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("WidgetConfigResponse", body)}
          error -> error
        end
      end

      @spec send_message(AiWidget.t(), String.t(), body: Notifique.OpenApi.Model.SendMessageBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.MessageResponse.t()} | {:error, term()}
      def send_message(%__MODULE__{api: %Notifique.TypedApi{client: client}}, publicKey, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"publicKey" => publicKey})
        case Notifique.DynamicApi.call_operation(client, "public.aiWidget.sendMessage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("MessageResponse", body)}
          error -> error
        end
      end

      @spec poll_messages(AiWidget.t(), String.t(), sessionToken: String.t() | nil, afterParam: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.PollMessagesResponse.t()} | {:error, term()}
      def poll_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, publicKey, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"publicKey" => publicKey})
        opts = if Keyword.has_key?(opts, :sessionToken), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "sessionToken", Keyword.get(opts, :sessionToken))), else: opts
        opts = if Keyword.has_key?(opts, :afterParam), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "after", Keyword.get(opts, :afterParam))), else: opts
        case Notifique.DynamicApi.call_operation(client, "public.aiWidget.pollMessages", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("PollMessagesResponse", body)}
          error -> error
        end
      end

      @spec create_session(AiWidget.t(), String.t(), body: Notifique.OpenApi.Model.CreateSessionBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.SessionResponse.t()} | {:error, term()}
      def create_session(%__MODULE__{api: %Notifique.TypedApi{client: client}}, publicKey, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"publicKey" => publicKey})
        case Notifique.DynamicApi.call_operation(client, "public.aiWidget.createSession", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("SessionResponse", body)}
          error -> error
        end
      end

      @spec request_otp(AiWidget.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetRequestOtpResponse.t()} | {:error, term()}
      def request_otp(%__MODULE__{api: %Notifique.TypedApi{client: client}}, publicKey, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"publicKey" => publicKey})
        case Notifique.DynamicApi.call_operation(client, "public.aiWidget.requestOtp", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetRequestOtpResponse", body)}
          error -> error
        end
      end

      @spec verify_otp(AiWidget.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetVerifyOtpResponse.t()} | {:error, term()}
      def verify_otp(%__MODULE__{api: %Notifique.TypedApi{client: client}}, publicKey, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"publicKey" => publicKey})
        case Notifique.DynamicApi.call_operation(client, "public.aiWidget.verifyOtp", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetVerifyOtpResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec ai_web_widget(t()) :: AiWebWidget.t()
  def ai_web_widget(%__MODULE__{} = api), do: Notifique.TypedApi.AiWebWidget.new(api)

  defmodule AiWebWidget do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec messages(AiWebWidget.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetAdminMessagesResponse.t()} | {:error, term()}
    def messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "aiWebWidget.messages", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetAdminMessagesResponse", body)}
        error -> error
      end
    end

    @spec list(AiWebWidget.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetAdminListResponse.t()} | {:error, term()}
    def list(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "aiWebWidget.list", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetAdminListResponse", body)}
        error -> error
      end
    end

    @spec create(AiWebWidget.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetAdminCreateResponse.t()} | {:error, term()}
    def create(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "aiWebWidget.create", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetAdminCreateResponse", body)}
        error -> error
      end
    end

    @spec delete(AiWebWidget.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetAdminDeleteResponse.t()} | {:error, term()}
    def delete(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "aiWebWidget.delete", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetAdminDeleteResponse", body)}
        error -> error
      end
    end

    @spec get(AiWebWidget.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetAdminGetResponse.t()} | {:error, term()}
    def get(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "aiWebWidget.get", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetAdminGetResponse", body)}
        error -> error
      end
    end

    @spec patch(AiWebWidget.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetAdminPatchResponse.t()} | {:error, term()}
    def patch(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "aiWebWidget.patch", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetAdminPatchResponse", body)}
        error -> error
      end
    end

    @spec widgets(t()) :: Widgets.t()
    def widgets(%__MODULE__{api: api}), do: Notifique.TypedApi.AiWebWidget.Widgets.new(api)

    defmodule Widgets do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec duplicate(Widgets.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetAdminDuplicateResponse.t()} | {:error, term()}
      def duplicate(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "aiWebWidget.widgets.duplicate", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetAdminDuplicateResponse", body)}
          error -> error
        end
      end

      @spec rotate_hmac(Widgets.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetAdminRotateHmacResponse.t()} | {:error, term()}
      def rotate_hmac(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "aiWebWidget.widgets.rotateHmac", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetAdminRotateHmacResponse", body)}
          error -> error
        end
      end

      @spec rotate_key(Widgets.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWidgetAdminRotateKeyResponse.t()} | {:error, term()}
      def rotate_key(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "aiWebWidget.widgets.rotateKey", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWidgetAdminRotateKeyResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec assistants(t()) :: Assistants.t()
  def assistants(%__MODULE__{} = api), do: Notifique.TypedApi.Assistants.new(api)

  defmodule Assistants do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec assistants_list(Assistants.t(), page: String.t() | nil, limit: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsListResponse.t()} | {:error, term()}
    def assistants_list(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsList", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsListResponse", body)}
        error -> error
      end
    end

    @spec assistants_create(Assistants.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsCreateResponse.t()} | {:error, term()}
    def assistants_create(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsCreate", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsCreateResponse", body)}
        error -> error
      end
    end

    @spec assistants_delete(Assistants.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsDeleteResponse.t()} | {:error, term()}
    def assistants_delete(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsDelete", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsDeleteResponse", body)}
        error -> error
      end
    end

    @spec assistants_get(Assistants.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsGetResponse.t()} | {:error, term()}
    def assistants_get(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsGet", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsGetResponse", body)}
        error -> error
      end
    end

    @spec assistants_update(Assistants.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsUpdateResponse.t()} | {:error, term()}
    def assistants_update(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsUpdate", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsUpdateResponse", body)}
        error -> error
      end
    end

    @spec assistants_list_http_bindings(Assistants.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsListHttpBindingsResponse.t()} | {:error, term()}
    def assistants_list_http_bindings(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsListHttpBindings", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsListHttpBindingsResponse", body)}
        error -> error
      end
    end

    @spec assistants_create_http_binding(Assistants.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsCreateHttpBindingResponse.t()} | {:error, term()}
    def assistants_create_http_binding(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsCreateHttpBinding", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsCreateHttpBindingResponse", body)}
        error -> error
      end
    end

    @spec assistants_delete_http_binding(Assistants.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsDeleteHttpBindingResponse.t()} | {:error, term()}
    def assistants_delete_http_binding(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, bindingId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsDeleteHttpBinding", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsDeleteHttpBindingResponse", body)}
        error -> error
      end
    end

    @spec assistants_invoke(Assistants.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsInvokeResponse.t()} | {:error, term()}
    def assistants_invoke(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsInvoke", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsInvokeResponse", body)}
        error -> error
      end
    end

    @spec assistants_list_mcp_bindings(Assistants.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsListMcpBindingsResponse.t()} | {:error, term()}
    def assistants_list_mcp_bindings(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsListMcpBindings", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsListMcpBindingsResponse", body)}
        error -> error
      end
    end

    @spec assistants_create_mcp_binding(Assistants.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsCreateMcpBindingResponse.t()} | {:error, term()}
    def assistants_create_mcp_binding(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsCreateMcpBinding", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsCreateMcpBindingResponse", body)}
        error -> error
      end
    end

    @spec assistants_delete_mcp_binding(Assistants.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsDeleteMcpBindingResponse.t()} | {:error, term()}
    def assistants_delete_mcp_binding(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, bindingId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsDeleteMcpBinding", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsDeleteMcpBindingResponse", body)}
        error -> error
      end
    end

    @spec assistants_update_mcp_binding(Assistants.t(), String.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsUpdateMcpBindingResponse.t()} | {:error, term()}
    def assistants_update_mcp_binding(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, bindingId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
      case Notifique.DynamicApi.call_operation(client, "assistants.assistantsUpdateMcpBinding", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsUpdateMcpBindingResponse", body)}
        error -> error
      end
    end

    @spec invoke(t()) :: Invoke.t()
    def invoke(%__MODULE__{api: api}), do: Notifique.TypedApi.Assistants.Invoke.new(api)

    defmodule Invoke do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec assistants_invoke_messages(Invoke.t(), String.t(), threadId: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAssistantsInvokeMessagesResponse.t()} | {:error, term()}
      def assistants_invoke_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        opts = if Keyword.has_key?(opts, :threadId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "threadId", Keyword.get(opts, :threadId))), else: opts
        case Notifique.DynamicApi.call_operation(client, "assistants.invoke.assistantsInvokeMessages", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAssistantsInvokeMessagesResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec automations(t()) :: Automations.t()
  def automations(%__MODULE__{} = api), do: Notifique.TypedApi.Automations.new(api)

  defmodule Automations do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec list_automations(Automations.t(), page: String.t() | nil, limit: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoListAutomationsResponse.t()} | {:error, term()}
    def list_automations(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      case Notifique.DynamicApi.call_operation(client, "automations.listAutomations", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoListAutomationsResponse", body)}
        error -> error
      end
    end

    @spec create_automation(Automations.t(), body: Notifique.OpenApi.Model.NtfAutoAutomationCreateBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoCreateAutomationResponse.t()} | {:error, term()}
    def create_automation(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "automations.createAutomation", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoCreateAutomationResponse", body)}
        error -> error
      end
    end

    @spec delete_automation(Automations.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoDeleteAutomationResponse.t()} | {:error, term()}
    def delete_automation(%__MODULE__{api: %Notifique.TypedApi{client: client}}, automationId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"automationId" => automationId})
      case Notifique.DynamicApi.call_operation(client, "automations.deleteAutomation", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoDeleteAutomationResponse", body)}
        error -> error
      end
    end

    @spec get_automation(Automations.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoGetAutomationResponse.t()} | {:error, term()}
    def get_automation(%__MODULE__{api: %Notifique.TypedApi{client: client}}, automationId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"automationId" => automationId})
      case Notifique.DynamicApi.call_operation(client, "automations.getAutomation", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoGetAutomationResponse", body)}
        error -> error
      end
    end

    @spec patch_automation(Automations.t(), String.t(), body: Notifique.OpenApi.Model.NtfAutoAutomationPatchBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoPatchAutomationResponse.t()} | {:error, term()}
    def patch_automation(%__MODULE__{api: %Notifique.TypedApi{client: client}}, automationId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"automationId" => automationId})
      case Notifique.DynamicApi.call_operation(client, "automations.patchAutomation", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoPatchAutomationResponse", body)}
        error -> error
      end
    end

    @spec duplicate(Automations.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoDuplicateResponse.t()} | {:error, term()}
    def duplicate(%__MODULE__{api: %Notifique.TypedApi{client: client}}, automationId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"automationId" => automationId})
      case Notifique.DynamicApi.call_operation(client, "automations.duplicate", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoDuplicateResponse", body)}
        error -> error
      end
    end

    @spec list_runs(Automations.t(), String.t(), page: String.t() | nil, limit: String.t() | nil, status: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoListRunsResponse.t()} | {:error, term()}
    def list_runs(%__MODULE__{api: %Notifique.TypedApi{client: client}}, automationId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"automationId" => automationId})
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      case Notifique.DynamicApi.call_operation(client, "automations.listRuns", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoListRunsResponse", body)}
        error -> error
      end
    end

    @spec get_run(Automations.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoGetRunResponse.t()} | {:error, term()}
    def get_run(%__MODULE__{api: %Notifique.TypedApi{client: client}}, automationId, runId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
      case Notifique.DynamicApi.call_operation(client, "automations.getRun", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoGetRunResponse", body)}
        error -> error
      end
    end

    @spec stop_automation(Automations.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoStopAutomationResponse.t()} | {:error, term()}
    def stop_automation(%__MODULE__{api: %Notifique.TypedApi{client: client}}, automationId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"automationId" => automationId})
      case Notifique.DynamicApi.call_operation(client, "automations.stopAutomation", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoStopAutomationResponse", body)}
        error -> error
      end
    end

    @spec test_trigger(Automations.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoTestTriggerResponse.t()} | {:error, term()}
    def test_trigger(%__MODULE__{api: %Notifique.TypedApi{client: client}}, automationId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"automationId" => automationId})
      case Notifique.DynamicApi.call_operation(client, "automations.testTrigger", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoTestTriggerResponse", body)}
        error -> error
      end
    end

    @spec webhook_secret(Automations.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoWebhookSecretResponse.t()} | {:error, term()}
    def webhook_secret(%__MODULE__{api: %Notifique.TypedApi{client: client}}, automationId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"automationId" => automationId})
      case Notifique.DynamicApi.call_operation(client, "automations.webhookSecret", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoWebhookSecretResponse", body)}
        error -> error
      end
    end

    @spec ai_compose(Automations.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoAiComposeResponse.t()} | {:error, term()}
    def ai_compose(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "automations.aiCompose", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoAiComposeResponse", body)}
        error -> error
      end
    end

    @spec post_campaign_agent(Automations.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoPostCampaignAgentResponse.t()} | {:error, term()}
    def post_campaign_agent(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "automations.postCampaignAgent", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoPostCampaignAgentResponse", body)}
        error -> error
      end
    end

    @spec quick_chatbot(Automations.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoQuickChatbotResponse.t()} | {:error, term()}
    def quick_chatbot(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "automations.quickChatbot", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoQuickChatbotResponse", body)}
        error -> error
      end
    end

    @spec batch(t()) :: Batch.t()
    def batch(%__MODULE__{api: api}), do: Notifique.TypedApi.Automations.Batch.new(api)

    defmodule Batch do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec batch_delete(Batch.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoBatchDeleteResponse.t()} | {:error, term()}
      def batch_delete(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        case Notifique.DynamicApi.call_operation(client, "automations.batch.batchDelete", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoBatchDeleteResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec campaigns(t()) :: Campaigns.t()
  def campaigns(%__MODULE__{} = api), do: Notifique.TypedApi.Campaigns.new(api)

  defmodule Campaigns do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_campaigns(Campaigns.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactCampaignListResponse.t()} | {:error, term()}
    def get_v1_campaigns(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "campaigns.getV1Campaigns", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactCampaignListResponse", body)}
        error -> error
      end
    end

    @spec post_v1_campaigns(Campaigns.t(), body: Notifique.OpenApi.Model.NtfContactCampaignCreate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactCampaignOneResponse.t()} | {:error, term()}
    def post_v1_campaigns(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "campaigns.postV1Campaigns", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactCampaignOneResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_campaign(Campaigns.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactDeleteV1CampaignResponse.t()} | {:error, term()}
    def delete_v1_campaign(%__MODULE__{api: %Notifique.TypedApi{client: client}}, campaignId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"campaignId" => campaignId})
      case Notifique.DynamicApi.call_operation(client, "campaigns.deleteV1Campaign", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactDeleteV1CampaignResponse", body)}
        error -> error
      end
    end

    @spec get_v1_campaign_by_id(Campaigns.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactCampaignOneResponse.t()} | {:error, term()}
    def get_v1_campaign_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, campaignId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"campaignId" => campaignId})
      case Notifique.DynamicApi.call_operation(client, "campaigns.getV1CampaignById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactCampaignOneResponse", body)}
        error -> error
      end
    end

    @spec patch_v1_campaign(Campaigns.t(), String.t(), body: Notifique.OpenApi.Model.NtfContactCampaignPatch.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactCampaignOneResponse.t()} | {:error, term()}
    def patch_v1_campaign(%__MODULE__{api: %Notifique.TypedApi{client: client}}, campaignId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"campaignId" => campaignId})
      case Notifique.DynamicApi.call_operation(client, "campaigns.patchV1Campaign", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactCampaignOneResponse", body)}
        error -> error
      end
    end

    @spec post_v1_campaign_cancel(Campaigns.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactCampaignCancelResponse.t()} | {:error, term()}
    def post_v1_campaign_cancel(%__MODULE__{api: %Notifique.TypedApi{client: client}}, campaignId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"campaignId" => campaignId})
      case Notifique.DynamicApi.call_operation(client, "campaigns.postV1CampaignCancel", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactCampaignCancelResponse", body)}
        error -> error
      end
    end

    @spec get_v1_campaign_recipients(Campaigns.t(), String.t(), channel: String.t() | nil, status: String.t() | nil, runId: String.t() | nil, page: integer() | nil, pageSize: integer() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactCampaignRecipientsResponse.t()} | {:error, term()}
    def get_v1_campaign_recipients(%__MODULE__{api: %Notifique.TypedApi{client: client}}, campaignId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"campaignId" => campaignId})
      opts = if Keyword.has_key?(opts, :channel), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "channel", Keyword.get(opts, :channel))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :runId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "runId", Keyword.get(opts, :runId))), else: opts
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :pageSize), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "pageSize", Keyword.get(opts, :pageSize))), else: opts
      case Notifique.DynamicApi.call_operation(client, "campaigns.getV1CampaignRecipients", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactCampaignRecipientsResponse", body)}
        error -> error
      end
    end

    @spec post_v1_campaign_run(Campaigns.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactCampaignRunResponse.t()} | {:error, term()}
    def post_v1_campaign_run(%__MODULE__{api: %Notifique.TypedApi{client: client}}, campaignId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"campaignId" => campaignId})
      case Notifique.DynamicApi.call_operation(client, "campaigns.postV1CampaignRun", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactCampaignRunResponse", body)}
        error -> error
      end
    end

    @spec get_v1_campaign_run_preview(Campaigns.t(), String.t(), channels: String.t() | nil, excludeAlreadySent: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactCampaignRunPreviewResponse.t()} | {:error, term()}
    def get_v1_campaign_run_preview(%__MODULE__{api: %Notifique.TypedApi{client: client}}, campaignId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"campaignId" => campaignId})
      opts = if Keyword.has_key?(opts, :channels), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "channels", Keyword.get(opts, :channels))), else: opts
      opts = if Keyword.has_key?(opts, :excludeAlreadySent), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "excludeAlreadySent", Keyword.get(opts, :excludeAlreadySent))), else: opts
      case Notifique.DynamicApi.call_operation(client, "campaigns.getV1CampaignRunPreview", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactCampaignRunPreviewResponse", body)}
        error -> error
      end
    end

    @spec get_v1_campaign_stats(Campaigns.t(), String.t(), runId: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactCampaignStatsResponse.t()} | {:error, term()}
    def get_v1_campaign_stats(%__MODULE__{api: %Notifique.TypedApi{client: client}}, campaignId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"campaignId" => campaignId})
      opts = if Keyword.has_key?(opts, :runId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "runId", Keyword.get(opts, :runId))), else: opts
      case Notifique.DynamicApi.call_operation(client, "campaigns.getV1CampaignStats", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactCampaignStatsResponse", body)}
        error -> error
      end
    end

  end

  @spec contacts(t()) :: Contacts.t()
  def contacts(%__MODULE__{} = api), do: Notifique.TypedApi.Contacts.new(api)

  defmodule Contacts do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_contacts(Contacts.t(), page: String.t() | nil, limit: String.t() | nil, search: String.t() | nil, tagId: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactGetV1ContactsResponse.t()} | {:error, term()}
    def get_v1_contacts(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
      opts = if Keyword.has_key?(opts, :tagId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "tagId", Keyword.get(opts, :tagId))), else: opts
      case Notifique.DynamicApi.call_operation(client, "contacts.getV1Contacts", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactGetV1ContactsResponse", body)}
        error -> error
      end
    end

    @spec post_v1_contacts(Contacts.t(), body: Notifique.OpenApi.Model.NtfContactContactCreate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactPostV1ContactsResponse.t()} | {:error, term()}
    def post_v1_contacts(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "contacts.postV1Contacts", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactPostV1ContactsResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_contact(Contacts.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactDeleteV1ContactResponse.t()} | {:error, term()}
    def delete_v1_contact(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "contacts.deleteV1Contact", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactDeleteV1ContactResponse", body)}
        error -> error
      end
    end

    @spec get_v1_contact(Contacts.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactGetV1ContactResponse.t()} | {:error, term()}
    def get_v1_contact(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "contacts.getV1Contact", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactGetV1ContactResponse", body)}
        error -> error
      end
    end

    @spec put_v1_contact(Contacts.t(), String.t(), body: Notifique.OpenApi.Model.NtfContactContactUpdate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactPutV1ContactResponse.t()} | {:error, term()}
    def put_v1_contact(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "contacts.putV1Contact", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactPutV1ContactResponse", body)}
        error -> error
      end
    end

  end

  @spec conversions(t()) :: Conversions.t()
  def conversions(%__MODULE__{} = api), do: Notifique.TypedApi.Conversions.new(api)

  defmodule Conversions do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec post_v1_conversions(Conversions.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfConversionsPostV1ConversionsResponse.t()} | {:error, term()}
    def post_v1_conversions(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "conversions.postV1Conversions", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfConversionsPostV1ConversionsResponse", body)}
        error -> error
      end
    end

  end

  @spec email(t()) :: Email.t()
  def email(%__MODULE__{} = api), do: Notifique.TypedApi.Email.new(api)

  defmodule Email do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_email_domains(Email.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailListEmailDomainsResponse.t()} | {:error, term()}
    def get_v1_email_domains(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "email.getV1EmailDomains", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailListEmailDomainsResponse", body)}
        error -> error
      end
    end

    @spec post_v1_email_domains(Email.t(), body: Notifique.OpenApi.Model.NtfEmailCreateEmailDomainRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailCreateEmailDomainResponse.t()} | {:error, term()}
    def post_v1_email_domains(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "email.postV1EmailDomains", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailCreateEmailDomainResponse", body)}
        error -> error
      end
    end

    @spec get_v1_email_domain_by_id(Email.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailEmailDomainResponse.t()} | {:error, term()}
    def get_v1_email_domain_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "email.getV1EmailDomainById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailEmailDomainResponse", body)}
        error -> error
      end
    end

    @spec get_v1_email_inbound(Email.t(), page: String.t() | nil, limit: String.t() | nil, q: String.t() | nil, domainId: String.t() | nil, dateFrom: String.t() | nil, dateTo: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailGetV1EmailInboundResponse.t()} | {:error, term()}
    def get_v1_email_inbound(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :q), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "q", Keyword.get(opts, :q))), else: opts
      opts = if Keyword.has_key?(opts, :domainId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "domainId", Keyword.get(opts, :domainId))), else: opts
      opts = if Keyword.has_key?(opts, :dateFrom), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "dateFrom", Keyword.get(opts, :dateFrom))), else: opts
      opts = if Keyword.has_key?(opts, :dateTo), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "dateTo", Keyword.get(opts, :dateTo))), else: opts
      case Notifique.DynamicApi.call_operation(client, "email.getV1EmailInbound", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailGetV1EmailInboundResponse", body)}
        error -> error
      end
    end

    @spec get_v1_email_inbound_by_id(Email.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailGetV1EmailInboundByIdResponse.t()} | {:error, term()}
    def get_v1_email_inbound_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "email.getV1EmailInboundById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailGetV1EmailInboundByIdResponse", body)}
        error -> error
      end
    end

    @spec get_v1_email_messages(Email.t(), page: String.t() | nil, limit: String.t() | nil, fromDate: String.t() | nil, toDate: String.t() | nil, status: String.t() | nil, emailDomainId: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailGetV1EmailMessagesResponse.t()} | {:error, term()}
    def get_v1_email_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :fromDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "fromDate", Keyword.get(opts, :fromDate))), else: opts
      opts = if Keyword.has_key?(opts, :toDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "toDate", Keyword.get(opts, :toDate))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :emailDomainId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "emailDomainId", Keyword.get(opts, :emailDomainId))), else: opts
      case Notifique.DynamicApi.call_operation(client, "email.getV1EmailMessages", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailGetV1EmailMessagesResponse", body)}
        error -> error
      end
    end

    @spec post_v1_email_send(Email.t(), body: Notifique.OpenApi.Model.NtfEmailSendEmailRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailSendEmailResponse.t()} | {:error, term()}
    def post_v1_email_send(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "email.postV1EmailSend", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailSendEmailResponse", body)}
        error -> error
      end
    end

    @spec get_v1_email_by_id(Email.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailEmailStatusResponse.t()} | {:error, term()}
    def get_v1_email_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "email.getV1EmailById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailEmailStatusResponse", body)}
        error -> error
      end
    end

    @spec domains(t()) :: Domains.t()
    def domains(%__MODULE__{api: api}), do: Notifique.TypedApi.Email.Domains.new(api)

    defmodule Domains do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec post_v1_email_domain_expand_providers(Domains.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailExpandEmailDomainProvidersResponse.t()} | {:error, term()}
      def post_v1_email_domain_expand_providers(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "email.domains.postV1EmailDomainExpandProviders", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailExpandEmailDomainProvidersResponse", body)}
          error -> error
        end
      end

      @spec post_v1_email_domain_verify(Domains.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailVerifyEmailDomainResponse.t()} | {:error, term()}
      def post_v1_email_domain_verify(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "email.domains.postV1EmailDomainVerify", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailVerifyEmailDomainResponse", body)}
          error -> error
        end
      end

    end

    @spec messages(t()) :: Messages.t()
    def messages(%__MODULE__{api: api}), do: Notifique.TypedApi.Email.Messages.new(api)

    defmodule Messages do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec post_v1_email_cancel(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfEmailCancelEmailResponse.t()} | {:error, term()}
      def post_v1_email_cancel(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "email.messages.postV1EmailCancel", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfEmailCancelEmailResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec events(t()) :: Events.t()
  def events(%__MODULE__{} = api), do: Notifique.TypedApi.Events.new(api)

  defmodule Events do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec list_events(Events.t(), page: String.t() | nil, limit: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoListEventsResponse.t()} | {:error, term()}
    def list_events(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      case Notifique.DynamicApi.call_operation(client, "events.listEvents", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoListEventsResponse", body)}
        error -> error
      end
    end

    @spec create_event(Events.t(), body: Notifique.OpenApi.Model.NtfAutoEventCreateBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoCreateEventResponse.t()} | {:error, term()}
    def create_event(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "events.createEvent", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoCreateEventResponse", body)}
        error -> error
      end
    end

    @spec delete_event(Events.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoDeleteEventResponse.t()} | {:error, term()}
    def delete_event(%__MODULE__{api: %Notifique.TypedApi{client: client}}, eventId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"eventId" => eventId})
      case Notifique.DynamicApi.call_operation(client, "events.deleteEvent", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoDeleteEventResponse", body)}
        error -> error
      end
    end

    @spec get_event(Events.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoGetEventResponse.t()} | {:error, term()}
    def get_event(%__MODULE__{api: %Notifique.TypedApi{client: client}}, eventId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"eventId" => eventId})
      case Notifique.DynamicApi.call_operation(client, "events.getEvent", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoGetEventResponse", body)}
        error -> error
      end
    end

    @spec patch_event(Events.t(), String.t(), body: Notifique.OpenApi.Model.NtfAutoEventPatchBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoPatchEventResponse.t()} | {:error, term()}
    def patch_event(%__MODULE__{api: %Notifique.TypedApi{client: client}}, eventId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"eventId" => eventId})
      case Notifique.DynamicApi.call_operation(client, "events.patchEvent", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoPatchEventResponse", body)}
        error -> error
      end
    end

    @spec send_event(Events.t(), body: Notifique.OpenApi.Model.NtfAutoEventSendBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoSendEventResponse.t()} | {:error, term()}
    def send_event(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "events.sendEvent", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoSendEventResponse", body)}
        error -> error
      end
    end

    @spec batch(t()) :: Batch.t()
    def batch(%__MODULE__{api: api}), do: Notifique.TypedApi.Events.Batch.new(api)

    defmodule Batch do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec batch_delete_events(Batch.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoBatchDeleteEventsResponse.t()} | {:error, term()}
      def batch_delete_events(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        case Notifique.DynamicApi.call_operation(client, "events.batch.batchDeleteEvents", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoBatchDeleteEventsResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec forms(t()) :: Forms.t()
  def forms(%__MODULE__{} = api), do: Notifique.TypedApi.Forms.new(api)

  defmodule Forms do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_forms_lists(Forms.t(), page: String.t() | nil, limit: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsFormListCollectionEnvelope.t()} | {:error, term()}
    def get_v1_forms_lists(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      case Notifique.DynamicApi.call_operation(client, "forms.getV1FormsLists", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsFormListCollectionEnvelope", body)}
        error -> error
      end
    end

    @spec post_v1_forms_lists(Forms.t(), body: Notifique.OpenApi.Model.NtfAddonsCreateFormListRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsFormListEnvelope.t()} | {:error, term()}
    def post_v1_forms_lists(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "forms.postV1FormsLists", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsFormListEnvelope", body)}
        error -> error
      end
    end

    @spec delete_v1_forms_list(Forms.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsFormDeleteEnvelope.t()} | {:error, term()}
    def delete_v1_forms_list(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "forms.deleteV1FormsList", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsFormDeleteEnvelope", body)}
        error -> error
      end
    end

    @spec get_v1_forms_list(Forms.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsFormListEnvelope.t()} | {:error, term()}
    def get_v1_forms_list(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "forms.getV1FormsList", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsFormListEnvelope", body)}
        error -> error
      end
    end

    @spec patch_v1_forms_list(Forms.t(), String.t(), body: Notifique.OpenApi.Model.NtfAddonsPatchFormListRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsFormListPatchEnvelope.t()} | {:error, term()}
    def patch_v1_forms_list(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "forms.patchV1FormsList", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsFormListPatchEnvelope", body)}
        error -> error
      end
    end

    @spec get_v1_forms_subscriptions_all(Forms.t(), page: String.t() | nil, limit: String.t() | nil, listId: String.t() | nil, status: String.t() | nil, search: String.t() | nil, subscribedFrom: String.t() | nil, subscribedTo: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsGetV1FormsSubscriptionsAllResponse.t()} | {:error, term()}
    def get_v1_forms_subscriptions_all(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :listId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "listId", Keyword.get(opts, :listId))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
      opts = if Keyword.has_key?(opts, :subscribedFrom), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "subscribedFrom", Keyword.get(opts, :subscribedFrom))), else: opts
      opts = if Keyword.has_key?(opts, :subscribedTo), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "subscribedTo", Keyword.get(opts, :subscribedTo))), else: opts
      case Notifique.DynamicApi.call_operation(client, "forms.getV1FormsSubscriptionsAll", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsGetV1FormsSubscriptionsAllResponse", body)}
        error -> error
      end
    end

    @spec post_v1_forms_subscriptions(Forms.t(), body: Notifique.OpenApi.Model.NtfAddonsFormSubscribeRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsFormSubscribeEnvelope.t()} | {:error, term()}
    def post_v1_forms_subscriptions(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "forms.postV1FormsSubscriptions", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsFormSubscribeEnvelope", body)}
        error -> error
      end
    end

    @spec lists(t()) :: Lists.t()
    def lists(%__MODULE__{api: api}), do: Notifique.TypedApi.Forms.Lists.new(api)

    defmodule Lists do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec get_v1_forms_list_subscriptions(Lists.t(), String.t(), page: String.t() | nil, limit: String.t() | nil, status: String.t() | nil, search: String.t() | nil, subscribedFrom: String.t() | nil, subscribedTo: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsFormSubscriptionCollectionEnvelope.t()} | {:error, term()}
      def get_v1_forms_list_subscriptions(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
        opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
        opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
        opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
        opts = if Keyword.has_key?(opts, :subscribedFrom), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "subscribedFrom", Keyword.get(opts, :subscribedFrom))), else: opts
        opts = if Keyword.has_key?(opts, :subscribedTo), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "subscribedTo", Keyword.get(opts, :subscribedTo))), else: opts
        case Notifique.DynamicApi.call_operation(client, "forms.lists.getV1FormsListSubscriptions", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsFormSubscriptionCollectionEnvelope", body)}
          error -> error
        end
      end

      @spec delete_v1_forms_subscription(Lists.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsDeleteV1FormsSubscriptionResponse.t()} | {:error, term()}
      def delete_v1_forms_subscription(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, subscriptionId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
        case Notifique.DynamicApi.call_operation(client, "forms.lists.deleteV1FormsSubscription", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsDeleteV1FormsSubscriptionResponse", body)}
          error -> error
        end
      end

      @spec get_v1_forms_subscription_export(Lists.t(), String.t(), status: String.t() | nil, search: String.t() | nil, subscribedFrom: String.t() | nil, subscribedTo: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsGetV1FormsSubscriptionExportResponse.t()} | {:error, term()}
      def get_v1_forms_subscription_export(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
        opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
        opts = if Keyword.has_key?(opts, :subscribedFrom), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "subscribedFrom", Keyword.get(opts, :subscribedFrom))), else: opts
        opts = if Keyword.has_key?(opts, :subscribedTo), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "subscribedTo", Keyword.get(opts, :subscribedTo))), else: opts
        case Notifique.DynamicApi.call_operation(client, "forms.lists.getV1FormsSubscriptionExport", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsGetV1FormsSubscriptionExportResponse", body)}
          error -> error
        end
      end

      @spec get_v1_forms_subscription_stats(Lists.t(), String.t(), trendDays: integer() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsGetV1FormsSubscriptionStatsResponse.t()} | {:error, term()}
      def get_v1_forms_subscription_stats(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        opts = if Keyword.has_key?(opts, :trendDays), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "trendDays", Keyword.get(opts, :trendDays))), else: opts
        case Notifique.DynamicApi.call_operation(client, "forms.lists.getV1FormsSubscriptionStats", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsGetV1FormsSubscriptionStatsResponse", body)}
          error -> error
        end
      end

    end

    @spec subscriptions(t()) :: Subscriptions.t()
    def subscriptions(%__MODULE__{api: api}), do: Notifique.TypedApi.Forms.Subscriptions.new(api)

    defmodule Subscriptions do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec post_v1_forms_subscription_cancel(Subscriptions.t(), String.t(), body: Notifique.OpenApi.Model.NtfAddonsNewsletterCancelRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsNewsletterCancelEnvelope.t()} | {:error, term()}
      def post_v1_forms_subscription_cancel(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "forms.subscriptions.postV1FormsSubscriptionCancel", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsNewsletterCancelEnvelope", body)}
          error -> error
        end
      end

      @spec post_v1_forms_subscriptions_confirm(Subscriptions.t(), body: Notifique.OpenApi.Model.NtfAddonsFormConfirmRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAddonsFormConfirmEnvelope.t()} | {:error, term()}
      def post_v1_forms_subscriptions_confirm(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        case Notifique.DynamicApi.call_operation(client, "forms.subscriptions.postV1FormsSubscriptionsConfirm", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAddonsFormConfirmEnvelope", body)}
          error -> error
        end
      end

    end

  end

  @spec http_tools(t()) :: HttpTools.t()
  def http_tools(%__MODULE__{} = api), do: Notifique.TypedApi.HttpTools.new(api)

  defmodule HttpTools do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec http_list(HttpTools.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoHttpListResponse.t()} | {:error, term()}
    def http_list(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "httpTools.httpList", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoHttpListResponse", body)}
        error -> error
      end
    end

    @spec http_create(HttpTools.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoHttpCreateResponse.t()} | {:error, term()}
    def http_create(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "httpTools.httpCreate", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoHttpCreateResponse", body)}
        error -> error
      end
    end

    @spec http_delete(HttpTools.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoHttpDeleteResponse.t()} | {:error, term()}
    def http_delete(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "httpTools.httpDelete", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoHttpDeleteResponse", body)}
        error -> error
      end
    end

    @spec http_get(HttpTools.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoHttpGetResponse.t()} | {:error, term()}
    def http_get(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "httpTools.httpGet", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoHttpGetResponse", body)}
        error -> error
      end
    end

    @spec http_update(HttpTools.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoHttpUpdateResponse.t()} | {:error, term()}
    def http_update(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "httpTools.httpUpdate", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoHttpUpdateResponse", body)}
        error -> error
      end
    end

  end

  @spec instagram(t()) :: Instagram.t()
  def instagram(%__MODULE__{} = api), do: Notifique.TypedApi.Instagram.new(api)

  defmodule Instagram do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec list_comments(Instagram.t(), instanceId: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgListCommentsResponse.t()} | {:error, term()}
    def list_comments(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :instanceId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "instanceId", Keyword.get(opts, :instanceId))), else: opts
      case Notifique.DynamicApi.call_operation(client, "instagram.listComments", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgListCommentsResponse", body)}
        error -> error
      end
    end

    @spec delete_comment(Instagram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgDeleteCommentResponse.t()} | {:error, term()}
    def delete_comment(%__MODULE__{api: %Notifique.TypedApi{client: client}}, commentId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"commentId" => commentId})
      case Notifique.DynamicApi.call_operation(client, "instagram.deleteComment", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgDeleteCommentResponse", body)}
        error -> error
      end
    end

    @spec get_comment(Instagram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgGetCommentResponse.t()} | {:error, term()}
    def get_comment(%__MODULE__{api: %Notifique.TypedApi{client: client}}, commentId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"commentId" => commentId})
      case Notifique.DynamicApi.call_operation(client, "instagram.getComment", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgGetCommentResponse", body)}
        error -> error
      end
    end

    @spec list_instances(Instagram.t(), page: String.t() | nil, limit: String.t() | nil, status: String.t() | nil, search: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgListInstancesResponse.t()} | {:error, term()}
    def list_instances(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
      case Notifique.DynamicApi.call_operation(client, "instagram.listInstances", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgListInstancesResponse", body)}
        error -> error
      end
    end

    @spec create_instance(Instagram.t(), body: Notifique.OpenApi.Model.NtfIgCreateInstanceBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgCreateInstanceResponse.t()} | {:error, term()}
    def create_instance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "instagram.createInstance", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgCreateInstanceResponse", body)}
        error -> error
      end
    end

    @spec delete_instance(Instagram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgDeleteInstanceResponse.t()} | {:error, term()}
    def delete_instance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
      case Notifique.DynamicApi.call_operation(client, "instagram.deleteInstance", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgDeleteInstanceResponse", body)}
        error -> error
      end
    end

    @spec get_instance(Instagram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgInstanceDetail.t()} | {:error, term()}
    def get_instance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
      case Notifique.DynamicApi.call_operation(client, "instagram.getInstance", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgInstanceDetail", body)}
        error -> error
      end
    end

    @spec list_messages(Instagram.t(), page: String.t() | nil, limit: String.t() | nil, instanceIds: String.t() | nil, status: String.t() | nil, typeParam: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgListMessagesResponse.t()} | {:error, term()}
    def list_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :instanceIds), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "instanceIds", Keyword.get(opts, :instanceIds))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :typeParam), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "type", Keyword.get(opts, :typeParam))), else: opts
      case Notifique.DynamicApi.call_operation(client, "instagram.listMessages", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgListMessagesResponse", body)}
        error -> error
      end
    end

    @spec send_message(Instagram.t(), body: Notifique.OpenApi.Model.NtfIgSendMessageBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgSendMessageResponse.t()} | {:error, term()}
    def send_message(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "instagram.sendMessage", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgSendMessageResponse", body)}
        error -> error
      end
    end

    @spec delete_message(Instagram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgDeleteMessageResponse.t()} | {:error, term()}
    def delete_message(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
      case Notifique.DynamicApi.call_operation(client, "instagram.deleteMessage", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgDeleteMessageResponse", body)}
        error -> error
      end
    end

    @spec get_message(Instagram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgGetMessageResponse.t()} | {:error, term()}
    def get_message(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
      case Notifique.DynamicApi.call_operation(client, "instagram.getMessage", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgGetMessageResponse", body)}
        error -> error
      end
    end

    @spec comments(t()) :: Comments.t()
    def comments(%__MODULE__{api: api}), do: Notifique.TypedApi.Instagram.Comments.new(api)

    defmodule Comments do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec hide_comment(Comments.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgHideCommentResponse.t()} | {:error, term()}
      def hide_comment(%__MODULE__{api: %Notifique.TypedApi{client: client}}, commentId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"commentId" => commentId})
        case Notifique.DynamicApi.call_operation(client, "instagram.comments.hideComment", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgHideCommentResponse", body)}
          error -> error
        end
      end

      @spec reply_comment(Comments.t(), String.t(), body: Notifique.OpenApi.Model.NtfIgReplyCommentBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgReplyCommentResponse.t()} | {:error, term()}
      def reply_comment(%__MODULE__{api: %Notifique.TypedApi{client: client}}, commentId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"commentId" => commentId})
        case Notifique.DynamicApi.call_operation(client, "instagram.comments.replyComment", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgReplyCommentResponse", body)}
          error -> error
        end
      end

    end

    @spec instances(t()) :: Instances.t()
    def instances(%__MODULE__{api: api}), do: Notifique.TypedApi.Instagram.Instances.new(api)

    defmodule Instances do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec resolve_challenge(Instances.t(), String.t(), body: Notifique.OpenApi.Model.NtfIgResolveChallengeBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgResolveChallengeResponse.t()} | {:error, term()}
      def resolve_challenge(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "instagram.instances.resolveChallenge", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgResolveChallengeResponse", body)}
          error -> error
        end
      end

      @spec get_connect_page(Instances.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgConnectPageStatusResponse.t()} | {:error, term()}
      def get_connect_page(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "instagram.instances.getConnectPage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgConnectPageStatusResponse", body)}
          error -> error
        end
      end

      @spec disable_connect_page(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgConnectPageDisableResponse.t()} | {:error, term()}
      def disable_connect_page(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "instagram.instances.disableConnectPage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgConnectPageDisableResponse", body)}
          error -> error
        end
      end

      @spec enable_connect_page(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgConnectPageEnableResponse.t()} | {:error, term()}
      def enable_connect_page(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "instagram.instances.enableConnectPage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgConnectPageEnableResponse", body)}
          error -> error
        end
      end

      @spec rotate_connect_page(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgConnectPageEnableResponse.t()} | {:error, term()}
      def rotate_connect_page(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "instagram.instances.rotateConnectPage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgConnectPageEnableResponse", body)}
          error -> error
        end
      end

      @spec get_connection(Instances.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgConnectionStatus.t()} | {:error, term()}
      def get_connection(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "instagram.instances.getConnection", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgConnectionStatus", body)}
          error -> error
        end
      end

      @spec disconnect_instance(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgDisconnectInstanceResponse.t()} | {:error, term()}
      def disconnect_instance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "instagram.instances.disconnectInstance", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgDisconnectInstanceResponse", body)}
          error -> error
        end
      end

    end

    @spec messages(t()) :: Messages.t()
    def messages(%__MODULE__{api: api}), do: Notifique.TypedApi.Instagram.Messages.new(api)

    defmodule Messages do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec cancel_message(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgCancelMessageResponse.t()} | {:error, term()}
      def cancel_message(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
        case Notifique.DynamicApi.call_operation(client, "instagram.messages.cancelMessage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgCancelMessageResponse", body)}
          error -> error
        end
      end

      @spec edit_message(Messages.t(), String.t(), body: Notifique.OpenApi.Model.NtfIgEditMessageBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgEditMessageResponse.t()} | {:error, term()}
      def edit_message(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
        case Notifique.DynamicApi.call_operation(client, "instagram.messages.editMessage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgEditMessageResponse", body)}
          error -> error
        end
      end

      @spec list_inbound(Messages.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgListInboundResponse.t()} | {:error, term()}
      def list_inbound(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        case Notifique.DynamicApi.call_operation(client, "instagram.messages.listInbound", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgListInboundResponse", body)}
          error -> error
        end
      end

      @spec get_inbound(Messages.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgGetInboundResponse.t()} | {:error, term()}
      def get_inbound(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "instagram.messages.getInbound", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgGetInboundResponse", body)}
          error -> error
        end
      end

      @spec post_inbound_media(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgPostInboundMediaResponse.t()} | {:error, term()}
      def post_inbound_media(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "instagram.messages.postInboundMedia", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgPostInboundMediaResponse", body)}
          error -> error
        end
      end

      @spec get_inbound_media_download(Messages.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfIgGetInboundMediaDownloadResponse.t()} | {:error, term()}
      def get_inbound_media_download(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "instagram.messages.getInboundMediaDownload", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfIgGetInboundMediaDownloadResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec knowledge_bases(t()) :: KnowledgeBases.t()
  def knowledge_bases(%__MODULE__{} = api), do: Notifique.TypedApi.KnowledgeBases.new(api)

  defmodule KnowledgeBases do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec kb_list(KnowledgeBases.t(), page: String.t() | nil, limit: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbListResponse.t()} | {:error, term()}
    def kb_list(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbList", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbListResponse", body)}
        error -> error
      end
    end

    @spec kb_create(KnowledgeBases.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbCreateResponse.t()} | {:error, term()}
    def kb_create(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbCreate", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbCreateResponse", body)}
        error -> error
      end
    end

    @spec kb_delete(KnowledgeBases.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbDeleteResponse.t()} | {:error, term()}
    def kb_delete(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbDelete", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbDeleteResponse", body)}
        error -> error
      end
    end

    @spec kb_get(KnowledgeBases.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbGetResponse.t()} | {:error, term()}
    def kb_get(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbGet", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbGetResponse", body)}
        error -> error
      end
    end

    @spec kb_update(KnowledgeBases.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbUpdateResponse.t()} | {:error, term()}
    def kb_update(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbUpdate", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbUpdateResponse", body)}
        error -> error
      end
    end

    @spec kb_list_docs(KnowledgeBases.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbListDocsResponse.t()} | {:error, term()}
    def kb_list_docs(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbListDocs", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbListDocsResponse", body)}
        error -> error
      end
    end

    @spec kb_create_doc(KnowledgeBases.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbCreateDocResponse.t()} | {:error, term()}
    def kb_create_doc(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbCreateDoc", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbCreateDocResponse", body)}
        error -> error
      end
    end

    @spec kb_delete_doc(KnowledgeBases.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbDeleteDocResponse.t()} | {:error, term()}
    def kb_delete_doc(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, docId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbDeleteDoc", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbDeleteDocResponse", body)}
        error -> error
      end
    end

    @spec kb_get_doc(KnowledgeBases.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbGetDocResponse.t()} | {:error, term()}
    def kb_get_doc(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, docId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbGetDoc", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbGetDocResponse", body)}
        error -> error
      end
    end

    @spec kb_update_doc(KnowledgeBases.t(), String.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoKbUpdateDocResponse.t()} | {:error, term()}
    def kb_update_doc(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, docId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
      case Notifique.DynamicApi.call_operation(client, "knowledgeBases.kbUpdateDoc", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoKbUpdateDocResponse", body)}
        error -> error
      end
    end

  end

  @spec logs(t()) :: Logs.t()
  def logs(%__MODULE__{} = api), do: Notifique.TypedApi.Logs.new(api)

  defmodule Logs do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_logs(Logs.t(), page: integer() | nil, limit: integer() | nil, status: String.t() | nil, startDate: String.t() | nil, endDate: String.t() | nil, method: String.t() | nil, apiKeyId: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.LogsListResponse.t()} | {:error, term()}
    def get_v1_logs(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :startDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "startDate", Keyword.get(opts, :startDate))), else: opts
      opts = if Keyword.has_key?(opts, :endDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "endDate", Keyword.get(opts, :endDate))), else: opts
      opts = if Keyword.has_key?(opts, :method), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "method", Keyword.get(opts, :method))), else: opts
      opts = if Keyword.has_key?(opts, :apiKeyId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "apiKeyId", Keyword.get(opts, :apiKeyId))), else: opts
      case Notifique.DynamicApi.call_operation(client, "logs.getV1Logs", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("LogsListResponse", body)}
        error -> error
      end
    end

    @spec get_v1_logs_by_id(Logs.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.GetV1LogsByIdResponse.t()} | {:error, term()}
    def get_v1_logs_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "logs.getV1LogsById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("GetV1LogsByIdResponse", body)}
        error -> error
      end
    end

  end

  @spec mcp_connections(t()) :: McpConnections.t()
  def mcp_connections(%__MODULE__{} = api), do: Notifique.TypedApi.McpConnections.new(api)

  defmodule McpConnections do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec mcp_list(McpConnections.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoMcpListResponse.t()} | {:error, term()}
    def mcp_list(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "mcpConnections.mcpList", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoMcpListResponse", body)}
        error -> error
      end
    end

    @spec mcp_create(McpConnections.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoMcpCreateResponse.t()} | {:error, term()}
    def mcp_create(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "mcpConnections.mcpCreate", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoMcpCreateResponse", body)}
        error -> error
      end
    end

    @spec mcp_delete(McpConnections.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoMcpDeleteResponse.t()} | {:error, term()}
    def mcp_delete(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "mcpConnections.mcpDelete", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoMcpDeleteResponse", body)}
        error -> error
      end
    end

    @spec mcp_get(McpConnections.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoMcpGetResponse.t()} | {:error, term()}
    def mcp_get(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "mcpConnections.mcpGet", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoMcpGetResponse", body)}
        error -> error
      end
    end

    @spec mcp_update(McpConnections.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoMcpUpdateResponse.t()} | {:error, term()}
    def mcp_update(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "mcpConnections.mcpUpdate", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoMcpUpdateResponse", body)}
        error -> error
      end
    end

    @spec mcp_refresh_manifest(McpConnections.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfAutoMcpRefreshManifestResponse.t()} | {:error, term()}
    def mcp_refresh_manifest(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "mcpConnections.mcpRefreshManifest", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfAutoMcpRefreshManifestResponse", body)}
        error -> error
      end
    end

  end

  @spec meta(t()) :: Meta.t()
  def meta(%__MODULE__{} = api), do: Notifique.TypedApi.Meta.new(api)

  defmodule Meta do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_meta_contact_locales(Meta.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactGetV1MetaContactLocalesResponse.t()} | {:error, term()}
    def get_v1_meta_contact_locales(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "meta.getV1MetaContactLocales", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactGetV1MetaContactLocalesResponse", body)}
        error -> error
      end
    end

  end

  @spec metrics(t()) :: Metrics.t()
  def metrics(%__MODULE__{} = api), do: Notifique.TypedApi.Metrics.new(api)

  defmodule Metrics do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_metrics_overview(Metrics.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformGetMetricsOverviewResponse.t()} | {:error, term()}
    def get_metrics_overview(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "metrics.getMetricsOverview", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformGetMetricsOverviewResponse", body)}
        error -> error
      end
    end

  end

  @spec notify(t()) :: Notify.t()
  def notify(%__MODULE__{} = api), do: Notifique.TypedApi.Notify.new(api)

  defmodule Notify do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec post_notify(Notify.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformPostNotifyResponse.t()} | {:error, term()}
    def post_notify(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "notify.postNotify", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformPostNotifyResponse", body)}
        error -> error
      end
    end

  end

  @spec phone_numbers(t()) :: PhoneNumbers.t()
  def phone_numbers(%__MODULE__{} = api), do: Notifique.TypedApi.PhoneNumbers.new(api)

  defmodule PhoneNumbers do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_phone_numbers(PhoneNumbers.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneListEnvelope.t()} | {:error, term()}
    def get_v1_phone_numbers(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "phoneNumbers.getV1PhoneNumbers", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneListEnvelope", body)}
        error -> error
      end
    end

    @spec get_v1_phone_numbers_by_id(PhoneNumbers.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneSingleEnvelope.t()} | {:error, term()}
    def get_v1_phone_numbers_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "phoneNumbers.getV1PhoneNumbersById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneSingleEnvelope", body)}
        error -> error
      end
    end

    @spec patch_v1_phone_numbers_by_id(PhoneNumbers.t(), String.t(), body: Notifique.OpenApi.Model.NtfPhoneUpdateBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneSingleEnvelope.t()} | {:error, term()}
    def patch_v1_phone_numbers_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "phoneNumbers.patchV1PhoneNumbersById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneSingleEnvelope", body)}
        error -> error
      end
    end

    @spec get_v1_phone_numbers_available(PhoneNumbers.t(), countryCode: String.t() | nil, phoneNumberType: String.t() | nil, areaCode: String.t() | nil, contains: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneGetV1PhoneNumbersAvailableResponse.t()} | {:error, term()}
    def get_v1_phone_numbers_available(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :countryCode), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "countryCode", Keyword.get(opts, :countryCode))), else: opts
      opts = if Keyword.has_key?(opts, :phoneNumberType), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "phoneNumberType", Keyword.get(opts, :phoneNumberType))), else: opts
      opts = if Keyword.has_key?(opts, :areaCode), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "areaCode", Keyword.get(opts, :areaCode))), else: opts
      opts = if Keyword.has_key?(opts, :contains), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "contains", Keyword.get(opts, :contains))), else: opts
      case Notifique.DynamicApi.call_operation(client, "phoneNumbers.getV1PhoneNumbersAvailable", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneGetV1PhoneNumbersAvailableResponse", body)}
        error -> error
      end
    end

    @spec config(PhoneNumbers.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneConfigResponse.t()} | {:error, term()}
    def config(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "phoneNumbers.config", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneConfigResponse", body)}
        error -> error
      end
    end

    @spec create_order(PhoneNumbers.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneCreateOrderResponse.t()} | {:error, term()}
    def create_order(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "phoneNumbers.createOrder", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneCreateOrderResponse", body)}
        error -> error
      end
    end

    @spec get_order(PhoneNumbers.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneGetOrderResponse.t()} | {:error, term()}
    def get_order(%__MODULE__{api: %Notifique.TypedApi{client: client}}, orderId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"orderId" => orderId})
      case Notifique.DynamicApi.call_operation(client, "phoneNumbers.getOrder", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneGetOrderResponse", body)}
        error -> error
      end
    end

    @spec orders(t()) :: Orders.t()
    def orders(%__MODULE__{api: api}), do: Notifique.TypedApi.PhoneNumbers.Orders.new(api)

    defmodule Orders do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec reg_document(Orders.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneRegDocumentResponse.t()} | {:error, term()}
      def reg_document(%__MODULE__{api: %Notifique.TypedApi{client: client}}, orderId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"orderId" => orderId})
        case Notifique.DynamicApi.call_operation(client, "phoneNumbers.orders.regDocument", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneRegDocumentResponse", body)}
          error -> error
        end
      end

      @spec reg_status(Orders.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneRegStatusResponse.t()} | {:error, term()}
      def reg_status(%__MODULE__{api: %Notifique.TypedApi{client: client}}, orderId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"orderId" => orderId})
        case Notifique.DynamicApi.call_operation(client, "phoneNumbers.orders.regStatus", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneRegStatusResponse", body)}
          error -> error
        end
      end

      @spec reg_submit(Orders.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneRegSubmitResponse.t()} | {:error, term()}
      def reg_submit(%__MODULE__{api: %Notifique.TypedApi{client: client}}, orderId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"orderId" => orderId})
        case Notifique.DynamicApi.call_operation(client, "phoneNumbers.orders.regSubmit", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneRegSubmitResponse", body)}
          error -> error
        end
      end

      @spec replacement_options(Orders.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneReplacementOptionsResponse.t()} | {:error, term()}
      def replacement_options(%__MODULE__{api: %Notifique.TypedApi{client: client}}, orderId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"orderId" => orderId})
        case Notifique.DynamicApi.call_operation(client, "phoneNumbers.orders.replacementOptions", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneReplacementOptionsResponse", body)}
          error -> error
        end
      end

      @spec select_replacement(Orders.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneSelectReplacementResponse.t()} | {:error, term()}
      def select_replacement(%__MODULE__{api: %Notifique.TypedApi{client: client}}, orderId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"orderId" => orderId})
        case Notifique.DynamicApi.call_operation(client, "phoneNumbers.orders.selectReplacement", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneSelectReplacementResponse", body)}
          error -> error
        end
      end

    end

    @spec regulatory(t()) :: Regulatory.t()
    def regulatory(%__MODULE__{api: api}), do: Notifique.TypedApi.PhoneNumbers.Regulatory.new(api)

    defmodule Regulatory do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec reg_profile(Regulatory.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneRegProfileResponse.t()} | {:error, term()}
      def reg_profile(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        case Notifique.DynamicApi.call_operation(client, "phoneNumbers.regulatory.regProfile", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneRegProfileResponse", body)}
          error -> error
        end
      end

      @spec reg_requirements(Regulatory.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPhoneRegRequirementsResponse.t()} | {:error, term()}
      def reg_requirements(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        case Notifique.DynamicApi.call_operation(client, "phoneNumbers.regulatory.regRequirements", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPhoneRegRequirementsResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec pipelines(t()) :: Pipelines.t()
  def pipelines(%__MODULE__{} = api), do: Notifique.TypedApi.Pipelines.new(api)

  defmodule Pipelines do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec list_boards(Pipelines.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipeListBoardsResponse.t()} | {:error, term()}
    def list_boards(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "pipelines.listBoards", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipeListBoardsResponse", body)}
        error -> error
      end
    end

    @spec create_board(Pipelines.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipeCreateBoardResponse.t()} | {:error, term()}
    def create_board(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "pipelines.createBoard", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipeCreateBoardResponse", body)}
        error -> error
      end
    end

    @spec get_board(Pipelines.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipeGetBoardResponse.t()} | {:error, term()}
    def get_board(%__MODULE__{api: %Notifique.TypedApi{client: client}}, boardId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"boardId" => boardId})
      case Notifique.DynamicApi.call_operation(client, "pipelines.getBoard", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipeGetBoardResponse", body)}
        error -> error
      end
    end

    @spec patch_board(Pipelines.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipePatchBoardResponse.t()} | {:error, term()}
    def patch_board(%__MODULE__{api: %Notifique.TypedApi{client: client}}, boardId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"boardId" => boardId})
      case Notifique.DynamicApi.call_operation(client, "pipelines.patchBoard", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipePatchBoardResponse", body)}
        error -> error
      end
    end

    @spec patch_card(Pipelines.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipePatchCardResponse.t()} | {:error, term()}
    def patch_card(%__MODULE__{api: %Notifique.TypedApi{client: client}}, cardId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"cardId" => cardId})
      case Notifique.DynamicApi.call_operation(client, "pipelines.patchCard", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipePatchCardResponse", body)}
        error -> error
      end
    end

    @spec boards(t()) :: Boards.t()
    def boards(%__MODULE__{api: api}), do: Notifique.TypedApi.Pipelines.Boards.new(api)

    defmodule Boards do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec create_card(Boards.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipeCreateCardResponse.t()} | {:error, term()}
      def create_card(%__MODULE__{api: %Notifique.TypedApi{client: client}}, boardId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"boardId" => boardId})
        case Notifique.DynamicApi.call_operation(client, "pipelines.boards.createCard", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipeCreateCardResponse", body)}
          error -> error
        end
      end

      @spec replace_columns(Boards.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipeReplaceColumnsResponse.t()} | {:error, term()}
      def replace_columns(%__MODULE__{api: %Notifique.TypedApi{client: client}}, boardId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"boardId" => boardId})
        case Notifique.DynamicApi.call_operation(client, "pipelines.boards.replaceColumns", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipeReplaceColumnsResponse", body)}
          error -> error
        end
      end

      @spec board_overview(Boards.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipeBoardOverviewResponse.t()} | {:error, term()}
      def board_overview(%__MODULE__{api: %Notifique.TypedApi{client: client}}, boardId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"boardId" => boardId})
        case Notifique.DynamicApi.call_operation(client, "pipelines.boards.boardOverview", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipeBoardOverviewResponse", body)}
          error -> error
        end
      end

    end

    @spec cards(t()) :: Cards.t()
    def cards(%__MODULE__{api: api}), do: Notifique.TypedApi.Pipelines.Cards.new(api)

    defmodule Cards do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec move_card(Cards.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipeMoveCardResponse.t()} | {:error, term()}
      def move_card(%__MODULE__{api: %Notifique.TypedApi{client: client}}, cardId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"cardId" => cardId})
        case Notifique.DynamicApi.call_operation(client, "pipelines.cards.moveCard", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipeMoveCardResponse", body)}
          error -> error
        end
      end

    end

    @spec contacts(t()) :: Contacts.t()
    def contacts(%__MODULE__{api: api}), do: Notifique.TypedApi.Pipelines.Contacts.new(api)

    defmodule Contacts do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec contact_cards(Contacts.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPipeContactCardsResponse.t()} | {:error, term()}
      def contact_cards(%__MODULE__{api: %Notifique.TypedApi{client: client}}, contactId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"contactId" => contactId})
        case Notifique.DynamicApi.call_operation(client, "pipelines.contacts.contactCards", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPipeContactCardsResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec platform(t()) :: Platform.t()
  def platform(%__MODULE__{} = api), do: Notifique.TypedApi.Platform.new(api)

  defmodule Platform do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec list_api_keys(Platform.t(), includeRevoked: boolean() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformListApiKeysResponse.t()} | {:error, term()}
    def list_api_keys(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :includeRevoked), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "includeRevoked", Keyword.get(opts, :includeRevoked))), else: opts
      case Notifique.DynamicApi.call_operation(client, "platform.listApiKeys", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformListApiKeysResponse", body)}
        error -> error
      end
    end

    @spec create_api_key(Platform.t(), body: Notifique.OpenApi.Model.NtfPlatformApiKeyCreate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformCreateApiKeyResponse.t()} | {:error, term()}
    def create_api_key(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "platform.createApiKey", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformCreateApiKeyResponse", body)}
        error -> error
      end
    end

    @spec get_api_key(Platform.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformGetApiKeyResponse.t()} | {:error, term()}
    def get_api_key(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "platform.getApiKey", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformGetApiKeyResponse", body)}
        error -> error
      end
    end

    @spec patch_api_key(Platform.t(), String.t(), body: Notifique.OpenApi.Model.NtfPlatformApiKeyPatch.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformPatchApiKeyResponse.t()} | {:error, term()}
    def patch_api_key(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "platform.patchApiKey", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformPatchApiKeyResponse", body)}
        error -> error
      end
    end

    @spec post_login(Platform.t(), body: Notifique.OpenApi.Model.NtfPlatformLoginBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformLoginResponse.t()} | {:error, term()}
    def post_login(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "platform.postLogin", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformLoginResponse", body)}
        error -> error
      end
    end

    @spec get_me(Platform.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformGetMeResponse.t()} | {:error, term()}
    def get_me(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "platform.getMe", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformGetMeResponse", body)}
        error -> error
      end
    end

    @spec post_register(Platform.t(), body: Notifique.OpenApi.Model.NtfPlatformRegisterBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformRegisterResponse.t()} | {:error, term()}
    def post_register(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "platform.postRegister", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformRegisterResponse", body)}
        error -> error
      end
    end

    @spec post_verify(Platform.t(), body: Notifique.OpenApi.Model.NtfPlatformVerifyBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformVerifyResponse.t()} | {:error, term()}
    def post_verify(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "platform.postVerify", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformVerifyResponse", body)}
        error -> error
      end
    end

    @spec list_user_workspaces(Platform.t(), include: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformListUserWorkspacesResponse.t()} | {:error, term()}
    def list_user_workspaces(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :include), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "include", Keyword.get(opts, :include))), else: opts
      case Notifique.DynamicApi.call_operation(client, "platform.listUserWorkspaces", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformListUserWorkspacesResponse", body)}
        error -> error
      end
    end

    @spec api_keys(t()) :: ApiKeys.t()
    def api_keys(%__MODULE__{api: api}), do: Notifique.TypedApi.Platform.ApiKeys.new(api)

    defmodule ApiKeys do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec revoke_api_key(ApiKeys.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformRevokeApiKeyResponse.t()} | {:error, term()}
      def revoke_api_key(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "platform.apiKeys.revokeApiKey", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformRevokeApiKeyResponse", body)}
          error -> error
        end
      end

    end

    @spec workspaces(t()) :: Workspaces.t()
    def workspaces(%__MODULE__{api: api}), do: Notifique.TypedApi.Platform.Workspaces.new(api)

    defmodule Workspaces do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec get_balance(Workspaces.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformGetBalanceResponse.t()} | {:error, term()}
      def get_balance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.getBalance", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformGetBalanceResponse", body)}
          error -> error
        end
      end

      @spec recharge_balance(Workspaces.t(), String.t(), body: Notifique.OpenApi.Model.NtfPlatformRechargeBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformRechargeBalanceResponse.t()} | {:error, term()}
      def recharge_balance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.rechargeBalance", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformRechargeBalanceResponse", body)}
          error -> error
        end
      end

      @spec get_credits_usage(Workspaces.t(), String.t(), page: String.t() | nil, limit: String.t() | nil, chargedAs: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformCreditsUsageResponse.t()} | {:error, term()}
      def get_credits_usage(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
        opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
        opts = if Keyword.has_key?(opts, :chargedAs), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "chargedAs", Keyword.get(opts, :chargedAs))), else: opts
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.getCreditsUsage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformCreditsUsageResponse", body)}
          error -> error
        end
      end

      @spec list_invites(Workspaces.t(), String.t(), page: String.t() | nil, limit: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformInvitesListResponse.t()} | {:error, term()}
      def list_invites(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
        opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.listInvites", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformInvitesListResponse", body)}
          error -> error
        end
      end

      @spec create_invite(Workspaces.t(), String.t(), body: Notifique.OpenApi.Model.NtfPlatformInviteBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformCreateInviteResponse.t()} | {:error, term()}
      def create_invite(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.createInvite", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformCreateInviteResponse", body)}
          error -> error
        end
      end

      @spec cancel_invite(Workspaces.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformCancelInviteResponse.t()} | {:error, term()}
      def cancel_invite(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, inviteId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.cancelInvite", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformCancelInviteResponse", body)}
          error -> error
        end
      end

      @spec list_members(Workspaces.t(), String.t(), page: String.t() | nil, limit: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformMembersListResponse.t()} | {:error, term()}
      def list_members(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
        opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.listMembers", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformMembersListResponse", body)}
          error -> error
        end
      end

      @spec remove_member(Workspaces.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformRemoveMemberResponse.t()} | {:error, term()}
      def remove_member(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, userId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.removeMember", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformRemoveMemberResponse", body)}
          error -> error
        end
      end

      @spec list_payment_methods(Workspaces.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformListPaymentMethodsResponse.t()} | {:error, term()}
      def list_payment_methods(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.listPaymentMethods", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformListPaymentMethodsResponse", body)}
          error -> error
        end
      end

      @spec create_payment_method(Workspaces.t(), String.t(), body: Notifique.OpenApi.Model.NtfPlatformPaymentMethodCreate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformCreatePaymentMethodResponse.t()} | {:error, term()}
      def create_payment_method(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.createPaymentMethod", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformCreatePaymentMethodResponse", body)}
          error -> error
        end
      end

      @spec delete_payment_method(Workspaces.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformDeletePaymentMethodResponse.t()} | {:error, term()}
      def delete_payment_method(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, pmId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.deletePaymentMethod", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformDeletePaymentMethodResponse", body)}
          error -> error
        end
      end

      @spec update_payment_method(Workspaces.t(), String.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformUpdatePaymentMethodResponse.t()} | {:error, term()}
      def update_payment_method(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, pmId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.updatePaymentMethod", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformUpdatePaymentMethodResponse", body)}
          error -> error
        end
      end

      @spec cancel_subscription(Workspaces.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformCancelSubscriptionResponse.t()} | {:error, term()}
      def cancel_subscription(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.cancelSubscription", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformCancelSubscriptionResponse", body)}
          error -> error
        end
      end

      @spec get_workspace_subscription(Workspaces.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformSubscriptionResponse.t()} | {:error, term()}
      def get_workspace_subscription(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.getWorkspaceSubscription", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformSubscriptionResponse", body)}
          error -> error
        end
      end

      @spec subscribe_workspace(Workspaces.t(), String.t(), body: Notifique.OpenApi.Model.NtfPlatformSubscribeBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformSubscribeWorkspaceResponse.t()} | {:error, term()}
      def subscribe_workspace(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "platform.workspaces.subscribeWorkspace", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformSubscribeWorkspaceResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec pricing(t()) :: Pricing.t()
  def pricing(%__MODULE__{} = api), do: Notifique.TypedApi.Pricing.new(api)

  defmodule Pricing do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_pricing(Pricing.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPlatformGetPricingResponse.t()} | {:error, term()}
    def get_pricing(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "pricing.getPricing", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPlatformGetPricingResponse", body)}
        error -> error
      end
    end

  end

  @spec push(t()) :: Push.t()
  def push(%__MODULE__{} = api), do: Notifique.TypedApi.Push.new(api)

  defmodule Push do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_push_apps(Push.t(), page: integer() | nil, limit: integer() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushPushAppListResponse.t()} | {:error, term()}
    def get_v1_push_apps(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      case Notifique.DynamicApi.call_operation(client, "push.getV1PushApps", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushPushAppListResponse", body)}
        error -> error
      end
    end

    @spec post_v1_push_apps(Push.t(), body: Notifique.OpenApi.Model.NtfPushPushAppCreateRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushPushAppSingleResponse.t()} | {:error, term()}
    def post_v1_push_apps(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "push.postV1PushApps", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushPushAppSingleResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_push_apps_by_id(Push.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushDeleteV1PushAppsByIdResponse.t()} | {:error, term()}
    def delete_v1_push_apps_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "push.deleteV1PushAppsById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushDeleteV1PushAppsByIdResponse", body)}
        error -> error
      end
    end

    @spec get_v1_push_apps_by_id(Push.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushPushAppSingleResponse.t()} | {:error, term()}
    def get_v1_push_apps_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "push.getV1PushAppsById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushPushAppSingleResponse", body)}
        error -> error
      end
    end

    @spec put_v1_push_apps_by_id(Push.t(), String.t(), body: Notifique.OpenApi.Model.NtfPushPushAppUpdateRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushPushAppSingleResponse.t()} | {:error, term()}
    def put_v1_push_apps_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "push.putV1PushAppsById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushPushAppSingleResponse", body)}
        error -> error
      end
    end

    @spec get_v1_push_devices(Push.t(), page: integer() | nil, limit: integer() | nil, appId: String.t() | nil, platform: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushPushDeviceListResponse.t()} | {:error, term()}
    def get_v1_push_devices(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :appId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "appId", Keyword.get(opts, :appId))), else: opts
      opts = if Keyword.has_key?(opts, :platform), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "platform", Keyword.get(opts, :platform))), else: opts
      case Notifique.DynamicApi.call_operation(client, "push.getV1PushDevices", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushPushDeviceListResponse", body)}
        error -> error
      end
    end

    @spec post_v1_push_devices(Push.t(), body: Notifique.OpenApi.Model.NtfPushPushDeviceRegisterRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushPushDeviceSingleResponse.t()} | {:error, term()}
    def post_v1_push_devices(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "push.postV1PushDevices", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushPushDeviceSingleResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_push_devices_by_id(Push.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushDeleteV1PushDevicesByIdResponse.t()} | {:error, term()}
    def delete_v1_push_devices_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "push.deleteV1PushDevicesById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushDeleteV1PushDevicesByIdResponse", body)}
        error -> error
      end
    end

    @spec get_v1_push_devices_by_id(Push.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushPushDeviceSingleResponse.t()} | {:error, term()}
    def get_v1_push_devices_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "push.getV1PushDevicesById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushPushDeviceSingleResponse", body)}
        error -> error
      end
    end

    @spec get_v1_push_messages(Push.t(), page: integer() | nil, limit: integer() | nil, status: String.t() | nil, appId: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushPushMessageListResponse.t()} | {:error, term()}
    def get_v1_push_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :appId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "appId", Keyword.get(opts, :appId))), else: opts
      case Notifique.DynamicApi.call_operation(client, "push.getV1PushMessages", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushPushMessageListResponse", body)}
        error -> error
      end
    end

    @spec post_v1_push_messages(Push.t(), body: Notifique.OpenApi.Model.NtfPushSendPushRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushSendPushResponse.t()} | {:error, term()}
    def post_v1_push_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "push.postV1PushMessages", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushSendPushResponse", body)}
        error -> error
      end
    end

    @spec get_v1_push_messages_by_id(Push.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushPushMessageSingleResponse.t()} | {:error, term()}
    def get_v1_push_messages_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "push.getV1PushMessagesById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushPushMessageSingleResponse", body)}
        error -> error
      end
    end

    @spec messages(t()) :: Messages.t()
    def messages(%__MODULE__{api: api}), do: Notifique.TypedApi.Push.Messages.new(api)

    defmodule Messages do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec post_v1_push_messages_cancel(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPushCancelPushResponse.t()} | {:error, term()}
      def post_v1_push_messages_cancel(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "push.messages.postV1PushMessagesCancel", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPushCancelPushResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec rcs(t()) :: Rcs.t()
  def rcs(%__MODULE__{} = api), do: Notifique.TypedApi.Rcs.new(api)

  defmodule Rcs do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_rcs_messages(Rcs.t(), page: String.t() | nil, limit: String.t() | nil, fromDate: String.t() | nil, toDate: String.t() | nil, status: String.t() | nil, to: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfRcsGetV1RcsMessagesResponse.t()} | {:error, term()}
    def get_v1_rcs_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :fromDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "fromDate", Keyword.get(opts, :fromDate))), else: opts
      opts = if Keyword.has_key?(opts, :toDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "toDate", Keyword.get(opts, :toDate))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :to), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "to", Keyword.get(opts, :to))), else: opts
      case Notifique.DynamicApi.call_operation(client, "rcs.getV1RcsMessages", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfRcsGetV1RcsMessagesResponse", body)}
        error -> error
      end
    end

    @spec post_v1_rcs_send(Rcs.t(), body: Notifique.OpenApi.Model.NtfRcsSendRcsRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfRcsSendRcsResponse.t()} | {:error, term()}
    def post_v1_rcs_send(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "rcs.postV1RcsSend", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfRcsSendRcsResponse", body)}
        error -> error
      end
    end

    @spec get_v1_rcs_by_id(Rcs.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfRcsRcsStatusResponse.t()} | {:error, term()}
    def get_v1_rcs_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "rcs.getV1RcsById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfRcsRcsStatusResponse", body)}
        error -> error
      end
    end

    @spec messages(t()) :: Messages.t()
    def messages(%__MODULE__{api: api}), do: Notifique.TypedApi.Rcs.Messages.new(api)

    defmodule Messages do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec post_v1_rcs_cancel(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfRcsCancelRcsResponse.t()} | {:error, term()}
      def post_v1_rcs_cancel(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "rcs.messages.postV1RcsCancel", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfRcsCancelRcsResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec report(t()) :: Report.t()
  def report(%__MODULE__{} = api), do: Notifique.TypedApi.Report.new(api)

  defmodule Report do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec post_v1_report(Report.t(), body: Notifique.OpenApi.Model.ReportRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.ReportOkResponse.t()} | {:error, term()}
    def post_v1_report(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "report.postV1Report", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("ReportOkResponse", body)}
        error -> error
      end
    end

  end

  @spec segments(t()) :: Segments.t()
  def segments(%__MODULE__{} = api), do: Notifique.TypedApi.Segments.new(api)

  defmodule Segments do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_segments(Segments.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactSegmentListResponse.t()} | {:error, term()}
    def get_v1_segments(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "segments.getV1Segments", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactSegmentListResponse", body)}
        error -> error
      end
    end

    @spec post_v1_segments(Segments.t(), body: Notifique.OpenApi.Model.NtfContactSegmentCreate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactSegmentOneResponse.t()} | {:error, term()}
    def post_v1_segments(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "segments.postV1Segments", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactSegmentOneResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_segment(Segments.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactDeleteV1SegmentResponse.t()} | {:error, term()}
    def delete_v1_segment(%__MODULE__{api: %Notifique.TypedApi{client: client}}, segmentId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"segmentId" => segmentId})
      case Notifique.DynamicApi.call_operation(client, "segments.deleteV1Segment", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactDeleteV1SegmentResponse", body)}
        error -> error
      end
    end

    @spec get_v1_segment_by_id(Segments.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactSegmentOneResponse.t()} | {:error, term()}
    def get_v1_segment_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, segmentId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"segmentId" => segmentId})
      case Notifique.DynamicApi.call_operation(client, "segments.getV1SegmentById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactSegmentOneResponse", body)}
        error -> error
      end
    end

    @spec patch_v1_segment(Segments.t(), String.t(), body: Notifique.OpenApi.Model.NtfContactSegmentPatch.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactSegmentOneResponse.t()} | {:error, term()}
    def patch_v1_segment(%__MODULE__{api: %Notifique.TypedApi{client: client}}, segmentId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"segmentId" => segmentId})
      case Notifique.DynamicApi.call_operation(client, "segments.patchV1Segment", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactSegmentOneResponse", body)}
        error -> error
      end
    end

    @spec get_v1_segment_preview(Segments.t(), String.t(), page: String.t() | nil, limit: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactSegmentPreviewResponse.t()} | {:error, term()}
    def get_v1_segment_preview(%__MODULE__{api: %Notifique.TypedApi{client: client}}, segmentId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"segmentId" => segmentId})
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      case Notifique.DynamicApi.call_operation(client, "segments.getV1SegmentPreview", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactSegmentPreviewResponse", body)}
        error -> error
      end
    end

  end

  @spec sending_pools(t()) :: SendingPools.t()
  def sending_pools(%__MODULE__{} = api), do: Notifique.TypedApi.SendingPools.new(api)

  defmodule SendingPools do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec list(SendingPools.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPoolListResponse.t()} | {:error, term()}
    def list(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "sendingPools.list", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPoolListResponse", body)}
        error -> error
      end
    end

    @spec create(SendingPools.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPoolCreateResponse.t()} | {:error, term()}
    def create(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "sendingPools.create", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPoolCreateResponse", body)}
        error -> error
      end
    end

    @spec delete(SendingPools.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPoolDeleteResponse.t()} | {:error, term()}
    def delete(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "sendingPools.delete", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPoolDeleteResponse", body)}
        error -> error
      end
    end

    @spec get(SendingPools.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPoolGetResponse.t()} | {:error, term()}
    def get(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "sendingPools.get", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPoolGetResponse", body)}
        error -> error
      end
    end

    @spec update(SendingPools.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPoolUpdateResponse.t()} | {:error, term()}
    def update(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "sendingPools.update", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPoolUpdateResponse", body)}
        error -> error
      end
    end

    @spec add_member(SendingPools.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPoolAddMemberResponse.t()} | {:error, term()}
    def add_member(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "sendingPools.addMember", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPoolAddMemberResponse", body)}
        error -> error
      end
    end

    @spec delete_member(SendingPools.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPoolDeleteMemberResponse.t()} | {:error, term()}
    def delete_member(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, memberId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
      case Notifique.DynamicApi.call_operation(client, "sendingPools.deleteMember", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPoolDeleteMemberResponse", body)}
        error -> error
      end
    end

    @spec update_member(SendingPools.t(), String.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPoolUpdateMemberResponse.t()} | {:error, term()}
    def update_member(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, memberId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
      case Notifique.DynamicApi.call_operation(client, "sendingPools.updateMember", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPoolUpdateMemberResponse", body)}
        error -> error
      end
    end

    @spec stats(SendingPools.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfPoolStatsResponse.t()} | {:error, term()}
    def stats(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "sendingPools.stats", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfPoolStatsResponse", body)}
        error -> error
      end
    end

  end

  @spec short_links(t()) :: ShortLinks.t()
  def short_links(%__MODULE__{} = api), do: Notifique.TypedApi.ShortLinks.new(api)

  defmodule ShortLinks do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_short_links(ShortLinks.t(), page: String.t() | nil, limit: String.t() | nil, source: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfShortLinksListResponse.t()} | {:error, term()}
    def get_v1_short_links(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :source), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "source", Keyword.get(opts, :source))), else: opts
      case Notifique.DynamicApi.call_operation(client, "shortLinks.getV1ShortLinks", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfShortLinksListResponse", body)}
        error -> error
      end
    end

    @spec post_v1_short_links(ShortLinks.t(), body: Notifique.OpenApi.Model.NtfShortLinksCreateRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfShortLinksCreateResponse.t()} | {:error, term()}
    def post_v1_short_links(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "shortLinks.postV1ShortLinks", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfShortLinksCreateResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_short_links_by_id(ShortLinks.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfShortLinksDeleteResponse.t()} | {:error, term()}
    def delete_v1_short_links_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "shortLinks.deleteV1ShortLinksById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfShortLinksDeleteResponse", body)}
        error -> error
      end
    end

    @spec get_v1_short_links_by_id(ShortLinks.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfShortLinksDetailResponse.t()} | {:error, term()}
    def get_v1_short_links_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "shortLinks.getV1ShortLinksById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfShortLinksDetailResponse", body)}
        error -> error
      end
    end

    @spec patch_v1_short_links_by_id(ShortLinks.t(), String.t(), body: Notifique.OpenApi.Model.NtfShortLinksPatchRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfShortLinksDetailResponse.t()} | {:error, term()}
    def patch_v1_short_links_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "shortLinks.patchV1ShortLinksById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfShortLinksDetailResponse", body)}
        error -> error
      end
    end

    @spec get_v1_short_links_analytics(ShortLinks.t(), String.t(), granularity: String.t() | nil, start: String.t() | nil, endParam: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfShortLinksAnalyticsResponse.t()} | {:error, term()}
    def get_v1_short_links_analytics(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      opts = if Keyword.has_key?(opts, :granularity), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "granularity", Keyword.get(opts, :granularity))), else: opts
      opts = if Keyword.has_key?(opts, :start), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "start", Keyword.get(opts, :start))), else: opts
      opts = if Keyword.has_key?(opts, :endParam), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "end", Keyword.get(opts, :endParam))), else: opts
      case Notifique.DynamicApi.call_operation(client, "shortLinks.getV1ShortLinksAnalytics", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfShortLinksAnalyticsResponse", body)}
        error -> error
      end
    end

    @spec get_v1_short_links_clicks(ShortLinks.t(), String.t(), page: String.t() | nil, limit: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfShortLinksClicksListResponse.t()} | {:error, term()}
    def get_v1_short_links_clicks(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      case Notifique.DynamicApi.call_operation(client, "shortLinks.getV1ShortLinksClicks", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfShortLinksClicksListResponse", body)}
        error -> error
      end
    end

  end

  @spec sms(t()) :: Sms.t()
  def sms(%__MODULE__{} = api), do: Notifique.TypedApi.Sms.new(api)

  defmodule Sms do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_sms_inbound(Sms.t(), page: String.t() | nil, limit: String.t() | nil, q: String.t() | nil, provider: String.t() | nil, linked: String.t() | nil, dateFrom: String.t() | nil, dateTo: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSmsGetV1SmsInboundResponse.t()} | {:error, term()}
    def get_v1_sms_inbound(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :q), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "q", Keyword.get(opts, :q))), else: opts
      opts = if Keyword.has_key?(opts, :provider), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "provider", Keyword.get(opts, :provider))), else: opts
      opts = if Keyword.has_key?(opts, :linked), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "linked", Keyword.get(opts, :linked))), else: opts
      opts = if Keyword.has_key?(opts, :dateFrom), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "dateFrom", Keyword.get(opts, :dateFrom))), else: opts
      opts = if Keyword.has_key?(opts, :dateTo), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "dateTo", Keyword.get(opts, :dateTo))), else: opts
      case Notifique.DynamicApi.call_operation(client, "sms.getV1SmsInbound", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSmsGetV1SmsInboundResponse", body)}
        error -> error
      end
    end

    @spec get_v1_sms_inbound_by_id(Sms.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSmsGetV1SmsInboundByIdResponse.t()} | {:error, term()}
    def get_v1_sms_inbound_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "sms.getV1SmsInboundById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSmsGetV1SmsInboundByIdResponse", body)}
        error -> error
      end
    end

    @spec get_v1_sms_messages(Sms.t(), page: String.t() | nil, limit: String.t() | nil, fromDate: String.t() | nil, toDate: String.t() | nil, status: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSmsGetV1SmsMessagesResponse.t()} | {:error, term()}
    def get_v1_sms_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :fromDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "fromDate", Keyword.get(opts, :fromDate))), else: opts
      opts = if Keyword.has_key?(opts, :toDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "toDate", Keyword.get(opts, :toDate))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      case Notifique.DynamicApi.call_operation(client, "sms.getV1SmsMessages", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSmsGetV1SmsMessagesResponse", body)}
        error -> error
      end
    end

    @spec post_v1_sms_send(Sms.t(), body: Notifique.OpenApi.Model.NtfSmsSendSmsRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSmsSendSmsResponse.t()} | {:error, term()}
    def post_v1_sms_send(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "sms.postV1SmsSend", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSmsSendSmsResponse", body)}
        error -> error
      end
    end

    @spec get_v1_sms_by_id(Sms.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSmsSmsStatusResponse.t()} | {:error, term()}
    def get_v1_sms_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "sms.getV1SmsById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSmsSmsStatusResponse", body)}
        error -> error
      end
    end

    @spec messages(t()) :: Messages.t()
    def messages(%__MODULE__{api: api}), do: Notifique.TypedApi.Sms.Messages.new(api)

    defmodule Messages do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec post_v1_sms_cancel(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSmsCancelSmsResponse.t()} | {:error, term()}
      def post_v1_sms_cancel(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "sms.messages.postV1SmsCancel", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSmsCancelSmsResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec suppressions(t()) :: Suppressions.t()
  def suppressions(%__MODULE__{} = api), do: Notifique.TypedApi.Suppressions.new(api)

  defmodule Suppressions do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec list_suppressions(Suppressions.t(), typeParam: Notifique.OpenApi.Model.NtfSuppSuppressionType.t() | nil, reason: Notifique.OpenApi.Model.NtfSuppSuppressionReason.t() | nil, origin: Notifique.OpenApi.Model.NtfSuppSuppressionOrigin.t() | nil, channel: String.t() | nil, search: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSuppListResponse.t()} | {:error, term()}
    def list_suppressions(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :typeParam), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "type", Keyword.get(opts, :typeParam))), else: opts
      opts = if Keyword.has_key?(opts, :reason), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "reason", Keyword.get(opts, :reason))), else: opts
      opts = if Keyword.has_key?(opts, :origin), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "origin", Keyword.get(opts, :origin))), else: opts
      opts = if Keyword.has_key?(opts, :channel), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "channel", Keyword.get(opts, :channel))), else: opts
      opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
      case Notifique.DynamicApi.call_operation(client, "suppressions.listSuppressions", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSuppListResponse", body)}
        error -> error
      end
    end

    @spec create_suppression(Suppressions.t(), body: Notifique.OpenApi.Model.NtfSuppSuppressionInput.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSuppSingleResponse.t()} | {:error, term()}
    def create_suppression(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "suppressions.createSuppression", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSuppSingleResponse", body)}
        error -> error
      end
    end

    @spec remove_suppression(Suppressions.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSuppRemoveResponse.t()} | {:error, term()}
    def remove_suppression(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "suppressions.removeSuppression", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSuppRemoveResponse", body)}
        error -> error
      end
    end

    @spec get_suppression(Suppressions.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSuppSingleResponse.t()} | {:error, term()}
    def get_suppression(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "suppressions.getSuppression", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSuppSingleResponse", body)}
        error -> error
      end
    end

    @spec remove_suppression_by_identity(Suppressions.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSuppRemoveResponse.t()} | {:error, term()}
    def remove_suppression_by_identity(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "suppressions.removeSuppressionByIdentity", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSuppRemoveResponse", body)}
        error -> error
      end
    end

    @spec batch(t()) :: Batch.t()
    def batch(%__MODULE__{api: api}), do: Notifique.TypedApi.Suppressions.Batch.new(api)

    defmodule Batch do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec batch_add_suppressions(Batch.t(), body: Notifique.OpenApi.Model.NtfSuppBatchAddRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSuppBatchAddResponse.t()} | {:error, term()}
      def batch_add_suppressions(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        case Notifique.DynamicApi.call_operation(client, "suppressions.batch.batchAddSuppressions", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSuppBatchAddResponse", body)}
          error -> error
        end
      end

      @spec batch_remove_suppressions(Batch.t(), body: Notifique.OpenApi.Model.NtfSuppBatchRemoveRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfSuppBatchRemoveResponse.t()} | {:error, term()}
      def batch_remove_suppressions(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        case Notifique.DynamicApi.call_operation(client, "suppressions.batch.batchRemoveSuppressions", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfSuppBatchRemoveResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec tags(t()) :: Tags.t()
  def tags(%__MODULE__{} = api), do: Notifique.TypedApi.Tags.new(api)

  defmodule Tags do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_tags(Tags.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactGetV1TagsResponse.t()} | {:error, term()}
    def get_v1_tags(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "tags.getV1Tags", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactGetV1TagsResponse", body)}
        error -> error
      end
    end

    @spec post_v1_tags(Tags.t(), body: Notifique.OpenApi.Model.NtfContactTagCreate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactPostV1TagsResponse.t()} | {:error, term()}
    def post_v1_tags(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "tags.postV1Tags", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactPostV1TagsResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_tag(Tags.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactDeleteV1TagResponse.t()} | {:error, term()}
    def delete_v1_tag(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "tags.deleteV1Tag", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactDeleteV1TagResponse", body)}
        error -> error
      end
    end

    @spec get_v1_tag(Tags.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactGetV1TagResponse.t()} | {:error, term()}
    def get_v1_tag(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "tags.getV1Tag", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactGetV1TagResponse", body)}
        error -> error
      end
    end

    @spec put_v1_tag(Tags.t(), String.t(), body: Notifique.OpenApi.Model.NtfContactTagUpdate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactPutV1TagResponse.t()} | {:error, term()}
    def put_v1_tag(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "tags.putV1Tag", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactPutV1TagResponse", body)}
        error -> error
      end
    end

  end

  @spec telegram(t()) :: Telegram.t()
  def telegram(%__MODULE__{} = api), do: Notifique.TypedApi.Telegram.new(api)

  defmodule Telegram do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_telegram_chats(Telegram.t(), page: String.t() | nil, limit: String.t() | nil, q: String.t() | nil, instanceId: String.t() | nil, status: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgChatSubscriptionListEnvelope.t()} | {:error, term()}
    def get_v1_telegram_chats(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :q), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "q", Keyword.get(opts, :q))), else: opts
      opts = if Keyword.has_key?(opts, :instanceId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "instanceId", Keyword.get(opts, :instanceId))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      case Notifique.DynamicApi.call_operation(client, "telegram.getV1TelegramChats", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgChatSubscriptionListEnvelope", body)}
        error -> error
      end
    end

    @spec get_v1_telegram_instances(Telegram.t(), page: String.t() | nil, limit: String.t() | nil, status: String.t() | nil, search: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgTelegramInstanceListEnvelope.t()} | {:error, term()}
    def get_v1_telegram_instances(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
      case Notifique.DynamicApi.call_operation(client, "telegram.getV1TelegramInstances", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgTelegramInstanceListEnvelope", body)}
        error -> error
      end
    end

    @spec post_v1_telegram_instances(Telegram.t(), body: Notifique.OpenApi.Model.NtfTgCreateTelegramInstanceRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgCreateTelegramInstanceResponse.t()} | {:error, term()}
    def post_v1_telegram_instances(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "telegram.postV1TelegramInstances", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgCreateTelegramInstanceResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_telegram_instance(Telegram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgInstanceDeletedResponse.t()} | {:error, term()}
    def delete_v1_telegram_instance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
      case Notifique.DynamicApi.call_operation(client, "telegram.deleteV1TelegramInstance", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgInstanceDeletedResponse", body)}
        error -> error
      end
    end

    @spec get_v1_telegram_instance(Telegram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgInstanceDetailEnvelope.t()} | {:error, term()}
    def get_v1_telegram_instance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
      case Notifique.DynamicApi.call_operation(client, "telegram.getV1TelegramInstance", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgInstanceDetailEnvelope", body)}
        error -> error
      end
    end

    @spec get_v1_telegram_messages(Telegram.t(), page: String.t() | nil, limit: String.t() | nil, fromDate: String.t() | nil, toDate: String.t() | nil, instanceIds: String.t() | nil, status: String.t() | nil, typeParam: String.t() | nil, includeEvents: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgMessageListEnvelope.t()} | {:error, term()}
    def get_v1_telegram_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :fromDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "fromDate", Keyword.get(opts, :fromDate))), else: opts
      opts = if Keyword.has_key?(opts, :toDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "toDate", Keyword.get(opts, :toDate))), else: opts
      opts = if Keyword.has_key?(opts, :instanceIds), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "instanceIds", Keyword.get(opts, :instanceIds))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :typeParam), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "type", Keyword.get(opts, :typeParam))), else: opts
      opts = if Keyword.has_key?(opts, :includeEvents), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "includeEvents", Keyword.get(opts, :includeEvents))), else: opts
      case Notifique.DynamicApi.call_operation(client, "telegram.getV1TelegramMessages", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgMessageListEnvelope", body)}
        error -> error
      end
    end

    @spec post_v1_telegram_send(Telegram.t(), body: Notifique.OpenApi.Model.NtfTgSendTelegramMessageRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgSendTelegramMessageAccepted.t()} | {:error, term()}
    def post_v1_telegram_send(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "telegram.postV1TelegramSend", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgSendTelegramMessageAccepted", body)}
        error -> error
      end
    end

    @spec delete_v1_telegram_message(Telegram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgMessageIdStatusResponse.t()} | {:error, term()}
    def delete_v1_telegram_message(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
      case Notifique.DynamicApi.call_operation(client, "telegram.deleteV1TelegramMessage", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgMessageIdStatusResponse", body)}
        error -> error
      end
    end

    @spec get_v1_telegram_message_by_id(Telegram.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgMessageDetailEnvelope.t()} | {:error, term()}
    def get_v1_telegram_message_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
      case Notifique.DynamicApi.call_operation(client, "telegram.getV1TelegramMessageById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgMessageDetailEnvelope", body)}
        error -> error
      end
    end

    @spec instances(t()) :: Instances.t()
    def instances(%__MODULE__{api: api}), do: Notifique.TypedApi.Telegram.Instances.new(api)

    defmodule Instances do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec ntf_telegram_get_connect_page(Instances.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgConnectPageStatusResponse.t()} | {:error, term()}
      def ntf_telegram_get_connect_page(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "telegram.instances.ntfTelegramGetConnectPage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgConnectPageStatusResponse", body)}
          error -> error
        end
      end

      @spec ntf_telegram_disable_connect_page(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgConnectPageDisableResponse.t()} | {:error, term()}
      def ntf_telegram_disable_connect_page(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "telegram.instances.ntfTelegramDisableConnectPage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgConnectPageDisableResponse", body)}
          error -> error
        end
      end

      @spec ntf_telegram_enable_connect_page(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgConnectPageEnableResponse.t()} | {:error, term()}
      def ntf_telegram_enable_connect_page(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "telegram.instances.ntfTelegramEnableConnectPage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgConnectPageEnableResponse", body)}
          error -> error
        end
      end

      @spec ntf_telegram_rotate_connect_page(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgConnectPageEnableResponse.t()} | {:error, term()}
      def ntf_telegram_rotate_connect_page(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "telegram.instances.ntfTelegramRotateConnectPage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgConnectPageEnableResponse", body)}
          error -> error
        end
      end

      @spec get_v1_telegram_instance_qr(Instances.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgQrEnvelope.t()} | {:error, term()}
      def get_v1_telegram_instance_qr(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "telegram.instances.getV1TelegramInstanceQr", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgQrEnvelope", body)}
          error -> error
        end
      end

      @spec post_v1_telegram_instance_qr_cancel(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgQrCancelSuccess.t()} | {:error, term()}
      def post_v1_telegram_instance_qr_cancel(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "telegram.instances.postV1TelegramInstanceQrCancel", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgQrCancelSuccess", body)}
          error -> error
        end
      end

      @spec post_v1_telegram_instance_session(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgSessionSaveResponse.t()} | {:error, term()}
      def post_v1_telegram_instance_session(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "telegram.instances.postV1TelegramInstanceSession", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgSessionSaveResponse", body)}
          error -> error
        end
      end

    end

    @spec messages(t()) :: Messages.t()
    def messages(%__MODULE__{api: api}), do: Notifique.TypedApi.Telegram.Messages.new(api)

    defmodule Messages do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec post_v1_telegram_message_cancel(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgMessageIdStatusResponse.t()} | {:error, term()}
      def post_v1_telegram_message_cancel(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
        case Notifique.DynamicApi.call_operation(client, "telegram.messages.postV1TelegramMessageCancel", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgMessageIdStatusResponse", body)}
          error -> error
        end
      end

      @spec patch_v1_telegram_message_edit(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgMessageIdStatusResponse.t()} | {:error, term()}
      def patch_v1_telegram_message_edit(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
        case Notifique.DynamicApi.call_operation(client, "telegram.messages.patchV1TelegramMessageEdit", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgMessageIdStatusResponse", body)}
          error -> error
        end
      end

      @spec get_v1_telegram_inbound(Messages.t(), page: String.t() | nil, limit: String.t() | nil, q: String.t() | nil, instanceId: String.t() | nil, dateFrom: String.t() | nil, dateTo: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgInboundListEnvelope.t()} | {:error, term()}
      def get_v1_telegram_inbound(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
        opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
        opts = if Keyword.has_key?(opts, :q), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "q", Keyword.get(opts, :q))), else: opts
        opts = if Keyword.has_key?(opts, :instanceId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "instanceId", Keyword.get(opts, :instanceId))), else: opts
        opts = if Keyword.has_key?(opts, :dateFrom), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "dateFrom", Keyword.get(opts, :dateFrom))), else: opts
        opts = if Keyword.has_key?(opts, :dateTo), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "dateTo", Keyword.get(opts, :dateTo))), else: opts
        case Notifique.DynamicApi.call_operation(client, "telegram.messages.getV1TelegramInbound", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgInboundListEnvelope", body)}
          error -> error
        end
      end

      @spec get_v1_telegram_inbound_by_id(Messages.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgInboundDetailEnvelope.t()} | {:error, term()}
      def get_v1_telegram_inbound_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "telegram.messages.getV1TelegramInboundById", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgInboundDetailEnvelope", body)}
          error -> error
        end
      end

      @spec post_v1_telegram_inbound_media(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgPostV1TelegramInboundMediaResponse.t()} | {:error, term()}
      def post_v1_telegram_inbound_media(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "telegram.messages.postV1TelegramInboundMedia", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgPostV1TelegramInboundMediaResponse", body)}
          error -> error
        end
      end

      @spec get_v1_telegram_inbound_media_download(Messages.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfTgGetV1TelegramInboundMediaDownloadResponse.t()} | {:error, term()}
      def get_v1_telegram_inbound_media_download(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "telegram.messages.getV1TelegramInboundMediaDownload", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfTgGetV1TelegramInboundMediaDownloadResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec templates(t()) :: Templates.t()
  def templates(%__MODULE__{} = api), do: Notifique.TypedApi.Templates.new(api)

  defmodule Templates do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec list_templates(Templates.t(), page: integer() | nil, limit: integer() | nil, search: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.TemplateListResponse.t()} | {:error, term()}
    def list_templates(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
      case Notifique.DynamicApi.call_operation(client, "templates.listTemplates", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("TemplateListResponse", body)}
        error -> error
      end
    end

    @spec create_templates(Templates.t(), body: Notifique.OpenApi.Model.TemplateCreateRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.TemplateResponse.t()} | {:error, term()}
    def create_templates(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "templates.createTemplates", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("TemplateResponse", body)}
        error -> error
      end
    end

    @spec delete_templates(Templates.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.TemplateDeleteResponse.t()} | {:error, term()}
    def delete_templates(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "templates.deleteTemplates", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("TemplateDeleteResponse", body)}
        error -> error
      end
    end

    @spec get_templates(Templates.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.TemplateResponse.t()} | {:error, term()}
    def get_templates(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "templates.getTemplates", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("TemplateResponse", body)}
        error -> error
      end
    end

    @spec update_templates(Templates.t(), String.t(), body: Notifique.OpenApi.Model.TemplatePatchRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.TemplateResponse.t()} | {:error, term()}
    def update_templates(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "templates.updateTemplates", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("TemplateResponse", body)}
        error -> error
      end
    end

    @spec create_send(Templates.t(), body: Notifique.OpenApi.Model.TemplateSendRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.TemplateSendResponse.t()} | {:error, term()}
    def create_send(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "templates.createSend", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("TemplateSendResponse", body)}
        error -> error
      end
    end

  end

  @spec topics(t()) :: Topics.t()
  def topics(%__MODULE__{} = api), do: Notifique.TypedApi.Topics.new(api)

  defmodule Topics do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_topics(Topics.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactTopicListResponse.t()} | {:error, term()}
    def get_v1_topics(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "topics.getV1Topics", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactTopicListResponse", body)}
        error -> error
      end
    end

    @spec post_v1_topics(Topics.t(), body: Notifique.OpenApi.Model.NtfContactTopicCreate.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactTopicOneResponse.t()} | {:error, term()}
    def post_v1_topics(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "topics.postV1Topics", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactTopicOneResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_topic(Topics.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactDeleteV1TopicResponse.t()} | {:error, term()}
    def delete_v1_topic(%__MODULE__{api: %Notifique.TypedApi{client: client}}, topicId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"topicId" => topicId})
      case Notifique.DynamicApi.call_operation(client, "topics.deleteV1Topic", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactDeleteV1TopicResponse", body)}
        error -> error
      end
    end

    @spec get_v1_topic_by_id(Topics.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactTopicOneResponse.t()} | {:error, term()}
    def get_v1_topic_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, topicId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"topicId" => topicId})
      case Notifique.DynamicApi.call_operation(client, "topics.getV1TopicById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactTopicOneResponse", body)}
        error -> error
      end
    end

    @spec patch_v1_topic(Topics.t(), String.t(), body: Notifique.OpenApi.Model.NtfContactTopicPatch.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfContactTopicOneResponse.t()} | {:error, term()}
    def patch_v1_topic(%__MODULE__{api: %Notifique.TypedApi{client: client}}, topicId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"topicId" => topicId})
      case Notifique.DynamicApi.call_operation(client, "topics.patchV1Topic", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfContactTopicOneResponse", body)}
        error -> error
      end
    end

  end

  @spec voice(t()) :: Voice.t()
  def voice(%__MODULE__{} = api), do: Notifique.TypedApi.Voice.new(api)

  defmodule Voice do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_voice_calls(Voice.t(), page: String.t() | nil, limit: String.t() | nil, direction: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfVoiceListEnvelope.t()} | {:error, term()}
    def get_v1_voice_calls(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :direction), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "direction", Keyword.get(opts, :direction))), else: opts
      case Notifique.DynamicApi.call_operation(client, "voice.getV1VoiceCalls", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfVoiceListEnvelope", body)}
        error -> error
      end
    end

    @spec post_v1_voice_calls(Voice.t(), body: Notifique.OpenApi.Model.NtfVoiceCreateBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfVoiceSendSuccessEnvelope.t()} | {:error, term()}
    def post_v1_voice_calls(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "voice.postV1VoiceCalls", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfVoiceSendSuccessEnvelope", body)}
        error -> error
      end
    end

    @spec get_v1_voice_calls_by_id(Voice.t(), String.t(), includeEvents: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfVoiceDetailEnvelope.t()} | {:error, term()}
    def get_v1_voice_calls_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      opts = if Keyword.has_key?(opts, :includeEvents), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "includeEvents", Keyword.get(opts, :includeEvents))), else: opts
      case Notifique.DynamicApi.call_operation(client, "voice.getV1VoiceCallsById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfVoiceDetailEnvelope", body)}
        error -> error
      end
    end

    @spec calls(t()) :: Calls.t()
    def calls(%__MODULE__{api: api}), do: Notifique.TypedApi.Voice.Calls.new(api)

    defmodule Calls do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec post_v1_voice_calls_action(Calls.t(), String.t(), String.t(), body: Notifique.OpenApi.Model.NtfVoiceActionBody.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfVoicePostV1VoiceCallsActionResponse.t()} | {:error, term()}
      def post_v1_voice_calls_action(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, action, opts \\ []) do
        opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
        case Notifique.DynamicApi.call_operation(client, "voice.calls.postV1VoiceCallsAction", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfVoicePostV1VoiceCallsActionResponse", body)}
          error -> error
        end
      end

      @spec get_v1_voice_recording_download(Calls.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfVoiceGetV1VoiceRecordingDownloadResponse.t()} | {:error, term()}
      def get_v1_voice_recording_download(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, recordingId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
        case Notifique.DynamicApi.call_operation(client, "voice.calls.getV1VoiceRecordingDownload", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfVoiceGetV1VoiceRecordingDownloadResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec webhooks(t()) :: Webhooks.t()
  def webhooks(%__MODULE__{} = api), do: Notifique.TypedApi.Webhooks.new(api)

  defmodule Webhooks do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec list_webhooks(Webhooks.t(), page: integer() | nil, limit: integer() | nil, eventParam: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWhListWebhooksResponse.t()} | {:error, term()}
    def list_webhooks(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :eventParam), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "event", Keyword.get(opts, :eventParam))), else: opts
      case Notifique.DynamicApi.call_operation(client, "webhooks.listWebhooks", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWhListWebhooksResponse", body)}
        error -> error
      end
    end

    @spec create_webhook(Webhooks.t(), body: Notifique.OpenApi.Model.NtfWhWebhookInput.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWhCreateWebhookResponse.t()} | {:error, term()}
    def create_webhook(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "webhooks.createWebhook", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWhCreateWebhookResponse", body)}
        error -> error
      end
    end

    @spec delete_webhook(Webhooks.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWhDeleteWebhookResponse.t()} | {:error, term()}
    def delete_webhook(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "webhooks.deleteWebhook", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWhDeleteWebhookResponse", body)}
        error -> error
      end
    end

    @spec get_webhook(Webhooks.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWhGetWebhookResponse.t()} | {:error, term()}
    def get_webhook(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "webhooks.getWebhook", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWhGetWebhookResponse", body)}
        error -> error
      end
    end

    @spec update_webhook(Webhooks.t(), String.t(), body: Notifique.OpenApi.Model.NtfWhWebhookInput.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWhUpdateWebhookResponse.t()} | {:error, term()}
    def update_webhook(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "webhooks.updateWebhook", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWhUpdateWebhookResponse", body)}
        error -> error
      end
    end

    @spec rotate_webhook_secret(Webhooks.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWhRotateWebhookSecretResponse.t()} | {:error, term()}
    def rotate_webhook_secret(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "webhooks.rotateWebhookSecret", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWhRotateWebhookSecretResponse", body)}
        error -> error
      end
    end

    @spec list_deliveries(Webhooks.t(), page: integer() | nil, limit: integer() | nil, success: boolean() | nil, eventParam: String.t() | nil, webhook_id: String.t() | nil, messageId: String.t() | nil, search: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWhListDeliveriesResponse.t()} | {:error, term()}
    def list_deliveries(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :success), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "success", Keyword.get(opts, :success))), else: opts
      opts = if Keyword.has_key?(opts, :eventParam), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "event", Keyword.get(opts, :eventParam))), else: opts
      opts = if Keyword.has_key?(opts, :webhook_id), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "webhook_id", Keyword.get(opts, :webhook_id))), else: opts
      opts = if Keyword.has_key?(opts, :messageId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "messageId", Keyword.get(opts, :messageId))), else: opts
      opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
      case Notifique.DynamicApi.call_operation(client, "webhooks.listDeliveries", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWhListDeliveriesResponse", body)}
        error -> error
      end
    end

    @spec get_delivery(Webhooks.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWhGetDeliveryResponse.t()} | {:error, term()}
    def get_delivery(%__MODULE__{api: %Notifique.TypedApi{client: client}}, deliveryId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"deliveryId" => deliveryId})
      case Notifique.DynamicApi.call_operation(client, "webhooks.getDelivery", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWhGetDeliveryResponse", body)}
        error -> error
      end
    end

    @spec deliveries(t()) :: Deliveries.t()
    def deliveries(%__MODULE__{api: api}), do: Notifique.TypedApi.Webhooks.Deliveries.new(api)

    defmodule Deliveries do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec resend_delivery(Deliveries.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWhResendDeliveryResponse.t()} | {:error, term()}
      def resend_delivery(%__MODULE__{api: %Notifique.TypedApi{client: client}}, deliveryId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"deliveryId" => deliveryId})
        case Notifique.DynamicApi.call_operation(client, "webhooks.deliveries.resendDelivery", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWhResendDeliveryResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec whatsapp(t()) :: Whatsapp.t()
  def whatsapp(%__MODULE__{} = api), do: Notifique.TypedApi.Whatsapp.new(api)

  defmodule Whatsapp do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_whatsapp_calls(Whatsapp.t(), page: String.t() | nil, limit: String.t() | nil, instanceId: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaWhatsAppCallListEnvelope.t()} | {:error, term()}
    def get_v1_whatsapp_calls(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :instanceId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "instanceId", Keyword.get(opts, :instanceId))), else: opts
      case Notifique.DynamicApi.call_operation(client, "whatsapp.getV1WhatsappCalls", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaWhatsAppCallListEnvelope", body)}
        error -> error
      end
    end

    @spec post_v1_whatsapp_calls(Whatsapp.t(), body: Notifique.OpenApi.Model.NtfWaCreateWhatsAppCallRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaWhatsAppCallCreateEnvelope.t()} | {:error, term()}
    def post_v1_whatsapp_calls(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "whatsapp.postV1WhatsappCalls", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaWhatsAppCallCreateEnvelope", body)}
        error -> error
      end
    end

    @spec get_v1_whatsapp_call_by_id(Whatsapp.t(), String.t(), includeEvents: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaWhatsAppCallDetailEnvelope.t()} | {:error, term()}
    def get_v1_whatsapp_call_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      opts = if Keyword.has_key?(opts, :includeEvents), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "includeEvents", Keyword.get(opts, :includeEvents))), else: opts
      case Notifique.DynamicApi.call_operation(client, "whatsapp.getV1WhatsappCallById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaWhatsAppCallDetailEnvelope", body)}
        error -> error
      end
    end

    @spec get_v1_whatsapp_instances(Whatsapp.t(), page: String.t() | nil, limit: String.t() | nil, status: String.t() | nil, search: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaInstanceListResponse.t()} | {:error, term()}
    def get_v1_whatsapp_instances(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :search), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "search", Keyword.get(opts, :search))), else: opts
      case Notifique.DynamicApi.call_operation(client, "whatsapp.getV1WhatsappInstances", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaInstanceListResponse", body)}
        error -> error
      end
    end

    @spec post_v1_whatsapp_instances(Whatsapp.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaCreateInstanceResponse.t()} | {:error, term()}
    def post_v1_whatsapp_instances(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "whatsapp.postV1WhatsappInstances", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaCreateInstanceResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_whatsapp_instance(Whatsapp.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaInstanceActionResponse.t()} | {:error, term()}
    def delete_v1_whatsapp_instance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
      case Notifique.DynamicApi.call_operation(client, "whatsapp.deleteV1WhatsappInstance", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaInstanceActionResponse", body)}
        error -> error
      end
    end

    @spec get_v1_whatsapp_instance(Whatsapp.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaInstanceResponse.t()} | {:error, term()}
    def get_v1_whatsapp_instance(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
      case Notifique.DynamicApi.call_operation(client, "whatsapp.getV1WhatsappInstance", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaInstanceResponse", body)}
        error -> error
      end
    end

    @spec get_v1_whatsapp_messages(Whatsapp.t(), page: String.t() | nil, limit: String.t() | nil, fromDate: String.t() | nil, toDate: String.t() | nil, instanceIds: String.t() | nil, status: String.t() | nil, typeParam: String.t() | nil, includeEvents: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappMessagesResponse.t()} | {:error, term()}
    def get_v1_whatsapp_messages(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
      opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
      opts = if Keyword.has_key?(opts, :fromDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "fromDate", Keyword.get(opts, :fromDate))), else: opts
      opts = if Keyword.has_key?(opts, :toDate), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "toDate", Keyword.get(opts, :toDate))), else: opts
      opts = if Keyword.has_key?(opts, :instanceIds), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "instanceIds", Keyword.get(opts, :instanceIds))), else: opts
      opts = if Keyword.has_key?(opts, :status), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "status", Keyword.get(opts, :status))), else: opts
      opts = if Keyword.has_key?(opts, :typeParam), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "type", Keyword.get(opts, :typeParam))), else: opts
      opts = if Keyword.has_key?(opts, :includeEvents), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "includeEvents", Keyword.get(opts, :includeEvents))), else: opts
      case Notifique.DynamicApi.call_operation(client, "whatsapp.getV1WhatsappMessages", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappMessagesResponse", body)}
        error -> error
      end
    end

    @spec post_v1_whatsapp_send(Whatsapp.t(), body: Notifique.OpenApi.Model.NtfWaSendWhatsAppMessageRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaPostV1WhatsappSendResponse.t()} | {:error, term()}
    def post_v1_whatsapp_send(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "whatsapp.postV1WhatsappSend", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaPostV1WhatsappSendResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_whatsapp_message(Whatsapp.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaMessageActionResponse.t()} | {:error, term()}
    def delete_v1_whatsapp_message(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
      case Notifique.DynamicApi.call_operation(client, "whatsapp.deleteV1WhatsappMessage", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaMessageActionResponse", body)}
        error -> error
      end
    end

    @spec get_v1_whatsapp_message(Whatsapp.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappMessageResponse.t()} | {:error, term()}
    def get_v1_whatsapp_message(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
      case Notifique.DynamicApi.call_operation(client, "whatsapp.getV1WhatsappMessage", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappMessageResponse", body)}
        error -> error
      end
    end

    @spec instances(t()) :: Instances.t()
    def instances(%__MODULE__{api: api}), do: Notifique.TypedApi.Whatsapp.Instances.new(api)

    defmodule Instances do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec call_perm_get(Instances.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaCallPermGetResponse.t()} | {:error, term()}
      def call_perm_get(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.callPermGet", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaCallPermGetResponse", body)}
          error -> error
        end
      end

      @spec call_perm_request(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaCallPermRequestResponse.t()} | {:error, term()}
      def call_perm_request(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.callPermRequest", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaCallPermRequestResponse", body)}
          error -> error
        end
      end

      @spec call_settings_get(Instances.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaCallSettingsGetResponse.t()} | {:error, term()}
      def call_settings_get(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.callSettingsGet", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaCallSettingsGetResponse", body)}
          error -> error
        end
      end

      @spec call_settings_patch(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaCallSettingsPatchResponse.t()} | {:error, term()}
      def call_settings_patch(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.callSettingsPatch", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaCallSettingsPatchResponse", body)}
          error -> error
        end
      end

      @spec get_v1_whatsapp_instance_connect_page(Instances.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaConnectPageStatusResponse.t()} | {:error, term()}
      def get_v1_whatsapp_instance_connect_page(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.getV1WhatsappInstanceConnectPage", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaConnectPageStatusResponse", body)}
          error -> error
        end
      end

      @spec post_v1_whatsapp_instance_connect_page_disable(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaConnectPageDisableResponse.t()} | {:error, term()}
      def post_v1_whatsapp_instance_connect_page_disable(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.postV1WhatsappInstanceConnectPageDisable", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaConnectPageDisableResponse", body)}
          error -> error
        end
      end

      @spec post_v1_whatsapp_instance_connect_page_enable(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaConnectPageEnableResponse.t()} | {:error, term()}
      def post_v1_whatsapp_instance_connect_page_enable(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.postV1WhatsappInstanceConnectPageEnable", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaConnectPageEnableResponse", body)}
          error -> error
        end
      end

      @spec post_v1_whatsapp_instance_connect_page_rotate(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaConnectPageEnableResponse.t()} | {:error, term()}
      def post_v1_whatsapp_instance_connect_page_rotate(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.postV1WhatsappInstanceConnectPageRotate", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaConnectPageEnableResponse", body)}
          error -> error
        end
      end

      @spec post_v1_whatsapp_instance_disconnect(Instances.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaInstanceActionResponse.t()} | {:error, term()}
      def post_v1_whatsapp_instance_disconnect(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.postV1WhatsappInstanceDisconnect", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaInstanceActionResponse", body)}
          error -> error
        end
      end

      @spec get_v1_whatsapp_instances_instance_id_groups(Instances.t(), String.t(), page: integer() | nil, limit: integer() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappInstancesInstanceIdGroupsResponse.t()} | {:error, term()}
      def get_v1_whatsapp_instances_instance_id_groups(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
        opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.getV1WhatsappInstancesInstanceIdGroups", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappInstancesInstanceIdGroupsResponse", body)}
          error -> error
        end
      end

      @spec get_v1_whatsapp_instances_instance_id_groups_group_id_participants(Instances.t(), String.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsResponse.t()} | {:error, term()}
      def get_v1_whatsapp_instances_instance_id_groups_group_id_participants(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, groupId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, Keyword.get(opts, :path_params, %{}))
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.getV1WhatsappInstancesInstanceIdGroupsGroupIdParticipants", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsResponse", body)}
          error -> error
        end
      end

      @spec post_v1_whatsapp_instances_instance_id_groups_invite(Instances.t(), String.t(), body: Notifique.OpenApi.Model.NtfWaGroupInviteSendRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteResponse.t()} | {:error, term()}
      def post_v1_whatsapp_instances_instance_id_groups_invite(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.postV1WhatsappInstancesInstanceIdGroupsInvite", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteResponse", body)}
          error -> error
        end
      end

      @spec get_v1_whatsapp_instances_instance_id_groups_invite_code(Instances.t(), String.t(), groupJid: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappInstancesInstanceIdGroupsInviteCodeResponse.t()} | {:error, term()}
      def get_v1_whatsapp_instances_instance_id_groups_invite_code(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        opts = if Keyword.has_key?(opts, :groupJid), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "groupJid", Keyword.get(opts, :groupJid))), else: opts
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.getV1WhatsappInstancesInstanceIdGroupsInviteCode", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappInstancesInstanceIdGroupsInviteCodeResponse", body)}
          error -> error
        end
      end

      @spec post_v1_whatsapp_instances_instance_id_groups_invite_revoke(Instances.t(), String.t(), body: Notifique.OpenApi.Model.NtfWaGroupInviteRevokeRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteRevokeResponse.t()} | {:error, term()}
      def post_v1_whatsapp_instances_instance_id_groups_invite_revoke(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.postV1WhatsappInstancesInstanceIdGroupsInviteRevoke", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteRevokeResponse", body)}
          error -> error
        end
      end

      @spec post_v1_whatsapp_instances_instance_id_groups_participants(Instances.t(), String.t(), body: Notifique.OpenApi.Model.NtfWaGroupParticipantsRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaPostV1WhatsappInstancesInstanceIdGroupsParticipantsResponse.t()} | {:error, term()}
      def post_v1_whatsapp_instances_instance_id_groups_participants(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.postV1WhatsappInstancesInstanceIdGroupsParticipants", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaPostV1WhatsappInstancesInstanceIdGroupsParticipantsResponse", body)}
          error -> error
        end
      end

      @spec get_v1_whatsapp_instance_pairing_code(Instances.t(), String.t(), phoneNumber: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappInstancePairingCodeResponse.t()} | {:error, term()}
      def get_v1_whatsapp_instance_pairing_code(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        opts = if Keyword.has_key?(opts, :phoneNumber), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "phoneNumber", Keyword.get(opts, :phoneNumber))), else: opts
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.getV1WhatsappInstancePairingCode", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappInstancePairingCodeResponse", body)}
          error -> error
        end
      end

      @spec get_v1_whatsapp_instance_qr(Instances.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappInstanceQrResponse.t()} | {:error, term()}
      def get_v1_whatsapp_instance_qr(%__MODULE__{api: %Notifique.TypedApi{client: client}}, instanceId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"instanceId" => instanceId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.instances.getV1WhatsappInstanceQr", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappInstanceQrResponse", body)}
          error -> error
        end
      end

    end

    @spec messages(t()) :: Messages.t()
    def messages(%__MODULE__{api: api}), do: Notifique.TypedApi.Whatsapp.Messages.new(api)

    defmodule Messages do
      @moduledoc false
      @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
      defstruct [:api]
      @spec new(Notifique.TypedApi.t()) :: t()
      def new(api), do: %__MODULE__{api: api}

      @spec post_v1_whatsapp_message_cancel(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaPostV1WhatsappMessageCancelResponse.t()} | {:error, term()}
      def post_v1_whatsapp_message_cancel(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.messages.postV1WhatsappMessageCancel", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaPostV1WhatsappMessageCancelResponse", body)}
          error -> error
        end
      end

      @spec patch_v1_whatsapp_message_edit(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaMessageActionResponse.t()} | {:error, term()}
      def patch_v1_whatsapp_message_edit(%__MODULE__{api: %Notifique.TypedApi{client: client}}, messageId, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"messageId" => messageId})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.messages.patchV1WhatsappMessageEdit", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaMessageActionResponse", body)}
          error -> error
        end
      end

      @spec get_v1_whatsapp_messages_inbound(Messages.t(), page: String.t() | nil, limit: String.t() | nil, q: String.t() | nil, instanceId: String.t() | nil, dateFrom: String.t() | nil, dateTo: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappMessagesInboundResponse.t()} | {:error, term()}
      def get_v1_whatsapp_messages_inbound(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        opts = if Keyword.has_key?(opts, :page), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "page", Keyword.get(opts, :page))), else: opts
        opts = if Keyword.has_key?(opts, :limit), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "limit", Keyword.get(opts, :limit))), else: opts
        opts = if Keyword.has_key?(opts, :q), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "q", Keyword.get(opts, :q))), else: opts
        opts = if Keyword.has_key?(opts, :instanceId), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "instanceId", Keyword.get(opts, :instanceId))), else: opts
        opts = if Keyword.has_key?(opts, :dateFrom), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "dateFrom", Keyword.get(opts, :dateFrom))), else: opts
        opts = if Keyword.has_key?(opts, :dateTo), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "dateTo", Keyword.get(opts, :dateTo))), else: opts
        case Notifique.DynamicApi.call_operation(client, "whatsapp.messages.getV1WhatsappMessagesInbound", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappMessagesInboundResponse", body)}
          error -> error
        end
      end

      @spec get_v1_whatsapp_message_inbound_by_id(Messages.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappMessageInboundByIdResponse.t()} | {:error, term()}
      def get_v1_whatsapp_message_inbound_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.messages.getV1WhatsappMessageInboundById", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappMessageInboundByIdResponse", body)}
          error -> error
        end
      end

      @spec post_v1_whatsapp_message_inbound_media(Messages.t(), String.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaPostV1WhatsappMessageInboundMediaResponse.t()} | {:error, term()}
      def post_v1_whatsapp_message_inbound_media(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.messages.postV1WhatsappMessageInboundMedia", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaPostV1WhatsappMessageInboundMediaResponse", body)}
          error -> error
        end
      end

      @spec get_v1_whatsapp_message_inbound_media_download(Messages.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaGetV1WhatsappMessageInboundMediaDownloadResponse.t()} | {:error, term()}
      def get_v1_whatsapp_message_inbound_media_download(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
        opts = Keyword.put(opts, :path_params, %{"id" => id})
        case Notifique.DynamicApi.call_operation(client, "whatsapp.messages.getV1WhatsappMessageInboundMediaDownload", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaGetV1WhatsappMessageInboundMediaDownloadResponse", body)}
          error -> error
        end
      end

      @spec post_v1_whatsapp_message_presence(Messages.t(), body: term() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.NtfWaPostV1WhatsappMessagePresenceResponse.t()} | {:error, term()}
      def post_v1_whatsapp_message_presence(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
        case Notifique.DynamicApi.call_operation(client, "whatsapp.messages.postV1WhatsappMessagePresence", opts) do
          {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("NtfWaPostV1WhatsappMessagePresenceResponse", body)}
          error -> error
        end
      end

    end

  end

  @spec workspaces(t()) :: Workspaces.t()
  def workspaces(%__MODULE__{} = api), do: Notifique.TypedApi.Workspaces.new(api)

  defmodule Workspaces do
    @moduledoc false
    @type t :: %__MODULE__{api: Notifique.TypedApi.t()}
    defstruct [:api]
    @spec new(Notifique.TypedApi.t()) :: t()
    def new(api), do: %__MODULE__{api: api}

    @spec get_v1_workspaces(Workspaces.t(), include: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.GetV1WorkspacesResponse.t()} | {:error, term()}
    def get_v1_workspaces(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      opts = if Keyword.has_key?(opts, :include), do: Keyword.put(opts, :query, Map.put(Keyword.get(opts, :query, %{}), "include", Keyword.get(opts, :include))), else: opts
      case Notifique.DynamicApi.call_operation(client, "workspaces.getV1Workspaces", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("GetV1WorkspacesResponse", body)}
        error -> error
      end
    end

    @spec post_v1_workspaces(Workspaces.t(), body: Notifique.OpenApi.Model.WorkspaceCreateRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.WorkspaceSingleResponse.t()} | {:error, term()}
    def post_v1_workspaces(%__MODULE__{api: %Notifique.TypedApi{client: client}}, opts \\ []) do
      case Notifique.DynamicApi.call_operation(client, "workspaces.postV1Workspaces", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("WorkspaceSingleResponse", body)}
        error -> error
      end
    end

    @spec delete_v1_workspaces_by_id(Workspaces.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.DeleteV1WorkspacesByIdResponse.t()} | {:error, term()}
    def delete_v1_workspaces_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "workspaces.deleteV1WorkspacesById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("DeleteV1WorkspacesByIdResponse", body)}
        error -> error
      end
    end

    @spec get_v1_workspaces_by_id(Workspaces.t(), String.t(), opts: keyword()) :: {:ok, Notifique.OpenApi.Model.WorkspaceGetResponse.t()} | {:error, term()}
    def get_v1_workspaces_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "workspaces.getV1WorkspacesById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("WorkspaceGetResponse", body)}
        error -> error
      end
    end

    @spec put_v1_workspaces_by_id(Workspaces.t(), String.t(), body: Notifique.OpenApi.Model.WorkspaceUpdateRequest.t() | nil, idempotency_key: String.t() | nil, opts: keyword()) :: {:ok, Notifique.OpenApi.Model.WorkspaceUpdateResponse.t()} | {:error, term()}
    def put_v1_workspaces_by_id(%__MODULE__{api: %Notifique.TypedApi{client: client}}, id, opts \\ []) do
      opts = Keyword.put(opts, :path_params, %{"id" => id})
      case Notifique.DynamicApi.call_operation(client, "workspaces.putV1WorkspacesById", opts) do
        {:ok, body} -> {:ok, Notifique.OpenApi.Model.decode_response("WorkspaceUpdateResponse", body)}
        error -> error
      end
    end

  end

end