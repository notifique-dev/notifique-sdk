package dev.notifique.sdk.generated;

import com.fasterxml.jackson.databind.JsonNode;
import dev.notifique.sdk.openapi.models.*;
import java.util.Map;

public final class TypedGeneratedApi {
    private final GeneratedApiTransport transport;
    private final com.fasterxml.jackson.databind.ObjectMapper objectMapper;

    public TypedGeneratedApi(String apiKey, String baseUrl, dev.notifique.sdk.HttpExecutor httpExecutor, com.fasterxml.jackson.databind.ObjectMapper objectMapper) {
        this.transport = new GeneratedApiTransport(apiKey, GeneratedApiTransport.normalizeApiBaseUrl(baseUrl), httpExecutor, objectMapper);
        this.objectMapper = objectMapper;
    }

    public final WellKnownApi wellKnown = new WellKnownApi(this);
    public static final class WellKnownApi {
        private final TypedGeneratedApi root;
        WellKnownApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfOauthGetJwksResponse getJwks(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/.well-known/jwks.json", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthGetJwksResponse.class);
        }
        public NtfOauthGetAuthorizationServerMetadataResponse getAuthorizationServerMetadata(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/.well-known/oauth-authorization-server", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthGetAuthorizationServerMetadataResponse.class);
        }
        public NtfOauthGetProtectedResourceMetadataResponse getProtectedResourceMetadata(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/.well-known/oauth-protected-resource", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthGetProtectedResourceMetadataResponse.class);
        }
    }

    public final OauthApi oauth = new OauthApi(this);
    public static final class OauthApi {
        private final TypedGeneratedApi root;
        public final OauthAppsApi apps;
        public final OauthConnectionsApi connections;
        OauthApi(TypedGeneratedApi root) {
            this.root = root;
            this.apps = new OauthAppsApi(root);
            this.connections = new OauthConnectionsApi(root);
        }
        public static final class OauthAppsApi {
            private final TypedGeneratedApi root;
            OauthAppsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfOauthRotateWorkspaceAppSecretResponse rotateWorkspaceAppSecret(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/oauth/apps/{id}/rotate-secret", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfOauthRotateWorkspaceAppSecretResponse.class);
            }
        }

        public static final class OauthConnectionsApi {
            private final TypedGeneratedApi root;
            OauthConnectionsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfOauthRevokeConnectionResponse revokeConnection(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/oauth/connections/{id}/revoke", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfOauthRevokeConnectionResponse.class);
            }
        }

        public NtfOauthAuthorizeResponse authorize(String client_id, String response_type, String redirect_uri, String scope, String state, String code_challenge, String code_challenge_method, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (client_id != null) { query.put("client_id", String.valueOf(client_id)); }
            if (response_type != null) { query.put("response_type", String.valueOf(response_type)); }
            if (redirect_uri != null) { query.put("redirect_uri", String.valueOf(redirect_uri)); }
            if (scope != null) { query.put("scope", String.valueOf(scope)); }
            if (state != null) { query.put("state", String.valueOf(state)); }
            if (code_challenge != null) { query.put("code_challenge", String.valueOf(code_challenge)); }
            if (code_challenge_method != null) { query.put("code_challenge_method", String.valueOf(code_challenge_method)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/oauth/authorize", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthAuthorizeResponse.class);
        }
        public NtfOauthRegisterClientResponse registerClient(NtfOauthClientRegistration body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/oauth/register", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthRegisterClientResponse.class);
        }
        public NtfOauthRevokeResponse revoke(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/oauth/revoke", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthRevokeResponse.class);
        }
        public NtfOauthTokenResponse token(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/oauth/token", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthTokenResponse.class);
        }
        public NtfOauthListWorkspaceAppsResponse listWorkspaceApps(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/oauth/apps", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthListWorkspaceAppsResponse.class);
        }
        public NtfOauthCreateWorkspaceAppResponse createWorkspaceApp(NtfOauthWorkspaceAppCreate body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/oauth/apps", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthCreateWorkspaceAppResponse.class);
        }
        public NtfOauthDeleteWorkspaceAppResponse deleteWorkspaceApp(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/oauth/apps/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfOauthDeleteWorkspaceAppResponse.class);
        }
        public NtfOauthGetWorkspaceAppResponse getWorkspaceApp(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/oauth/apps/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfOauthGetWorkspaceAppResponse.class);
        }
        public NtfOauthUpdateWorkspaceAppResponse updateWorkspaceApp(String id, NtfOauthWorkspaceAppPatch body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/oauth/apps/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfOauthUpdateWorkspaceAppResponse.class);
        }
        public NtfOauthListConnectionsResponse listConnections(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/oauth/connections", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfOauthListConnectionsResponse.class);
        }
    }

    public final PublicApi publicNs = new PublicApi(this);
    public static final class PublicApi {
        private final TypedGeneratedApi root;
        public final PublicAiWidgetApi aiWidget;
        PublicApi(TypedGeneratedApi root) {
            this.root = root;
            this.aiWidget = new PublicAiWidgetApi(root);
        }
        public static final class PublicAiWidgetApi {
            private final TypedGeneratedApi root;
            PublicAiWidgetApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public WidgetConfigResponse getConfig(String publicKey, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/public/ai-widget/{publicKey}/config", Map.of("publicKey", publicKey), options);
                return root.objectMapper.treeToValue(node, WidgetConfigResponse.class);
            }
            public MessageResponse sendMessage(String publicKey, SendMessageBody body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/public/ai-widget/{publicKey}/message", Map.of("publicKey", publicKey), options);
                return root.objectMapper.treeToValue(node, MessageResponse.class);
            }
            public PollMessagesResponse pollMessages(String publicKey, String sessionToken, String afterParam, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (sessionToken != null) { query.put("sessionToken", String.valueOf(sessionToken)); }
                if (afterParam != null) { query.put("after", String.valueOf(afterParam)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/public/ai-widget/{publicKey}/messages", Map.of("publicKey", publicKey), options);
                return root.objectMapper.treeToValue(node, PollMessagesResponse.class);
            }
            public SessionResponse createSession(String publicKey, CreateSessionBody body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/public/ai-widget/{publicKey}/session", Map.of("publicKey", publicKey), options);
                return root.objectMapper.treeToValue(node, SessionResponse.class);
            }
            public NtfWidgetRequestOtpResponse requestOtp(String publicKey, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/public/ai-widget/{publicKey}/session/otp/request", Map.of("publicKey", publicKey), options);
                return root.objectMapper.treeToValue(node, NtfWidgetRequestOtpResponse.class);
            }
            public NtfWidgetVerifyOtpResponse verifyOtp(String publicKey, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/public/ai-widget/{publicKey}/session/otp/verify", Map.of("publicKey", publicKey), options);
                return root.objectMapper.treeToValue(node, NtfWidgetVerifyOtpResponse.class);
            }
        }

    }

    public final AiWebWidgetApi aiWebWidget = new AiWebWidgetApi(this);
    public static final class AiWebWidgetApi {
        private final TypedGeneratedApi root;
        public final AiWebWidgetWidgetsApi widgets;
        AiWebWidgetApi(TypedGeneratedApi root) {
            this.root = root;
            this.widgets = new AiWebWidgetWidgetsApi(root);
        }
        public static final class AiWebWidgetWidgetsApi {
            private final TypedGeneratedApi root;
            AiWebWidgetWidgetsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfWidgetAdminDuplicateResponse duplicate(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/ai-web-widget/widgets/{id}/duplicate", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfWidgetAdminDuplicateResponse.class);
            }
            public NtfWidgetAdminRotateHmacResponse rotateHmac(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/ai-web-widget/widgets/{id}/rotate-identity-signing-secret", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfWidgetAdminRotateHmacResponse.class);
            }
            public NtfWidgetAdminRotateKeyResponse rotateKey(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/ai-web-widget/widgets/{id}/rotate-key", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfWidgetAdminRotateKeyResponse.class);
            }
        }

        public NtfWidgetAdminMessagesResponse messages(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/ai-web-widget/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWidgetAdminMessagesResponse.class);
        }
        public NtfWidgetAdminListResponse list(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/ai-web-widget/widgets", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWidgetAdminListResponse.class);
        }
        public NtfWidgetAdminCreateResponse create(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/ai-web-widget/widgets", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWidgetAdminCreateResponse.class);
        }
        public NtfWidgetAdminDeleteResponse delete(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/ai-web-widget/widgets/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfWidgetAdminDeleteResponse.class);
        }
        public NtfWidgetAdminGetResponse get(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/ai-web-widget/widgets/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfWidgetAdminGetResponse.class);
        }
        public NtfWidgetAdminPatchResponse patch(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/ai-web-widget/widgets/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfWidgetAdminPatchResponse.class);
        }
    }

    public final AssistantsApi assistants = new AssistantsApi(this);
    public static final class AssistantsApi {
        private final TypedGeneratedApi root;
        public final AssistantsInvokeApi invoke;
        AssistantsApi(TypedGeneratedApi root) {
            this.root = root;
            this.invoke = new AssistantsInvokeApi(root);
        }
        public static final class AssistantsInvokeApi {
            private final TypedGeneratedApi root;
            AssistantsInvokeApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfAutoAssistantsInvokeMessagesResponse assistantsInvokeMessages(String id, String threadId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (threadId != null) { query.put("threadId", String.valueOf(threadId)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/assistants/{id}/invoke/messages", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfAutoAssistantsInvokeMessagesResponse.class);
            }
        }

        public NtfAutoAssistantsListResponse assistantsList(String page, String limit, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/assistants", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsListResponse.class);
        }
        public NtfAutoAssistantsCreateResponse assistantsCreate(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/assistants", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsCreateResponse.class);
        }
        public NtfAutoAssistantsDeleteResponse assistantsDelete(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/assistants/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsDeleteResponse.class);
        }
        public NtfAutoAssistantsGetResponse assistantsGet(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/assistants/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsGetResponse.class);
        }
        public NtfAutoAssistantsUpdateResponse assistantsUpdate(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/assistants/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsUpdateResponse.class);
        }
        public NtfAutoAssistantsListHttpBindingsResponse assistantsListHttpBindings(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/assistants/{id}/http-tool-bindings", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsListHttpBindingsResponse.class);
        }
        public NtfAutoAssistantsCreateHttpBindingResponse assistantsCreateHttpBinding(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/assistants/{id}/http-tool-bindings", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsCreateHttpBindingResponse.class);
        }
        public NtfAutoAssistantsDeleteHttpBindingResponse assistantsDeleteHttpBinding(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/assistants/{id}/http-tool-bindings/{bindingId}", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsDeleteHttpBindingResponse.class);
        }
        public NtfAutoAssistantsInvokeResponse assistantsInvoke(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/assistants/{id}/invoke", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsInvokeResponse.class);
        }
        public NtfAutoAssistantsListMcpBindingsResponse assistantsListMcpBindings(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/assistants/{id}/mcp-bindings", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsListMcpBindingsResponse.class);
        }
        public NtfAutoAssistantsCreateMcpBindingResponse assistantsCreateMcpBinding(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/assistants/{id}/mcp-bindings", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsCreateMcpBindingResponse.class);
        }
        public NtfAutoAssistantsDeleteMcpBindingResponse assistantsDeleteMcpBinding(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/assistants/{id}/mcp-bindings/{bindingId}", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsDeleteMcpBindingResponse.class);
        }
        public NtfAutoAssistantsUpdateMcpBindingResponse assistantsUpdateMcpBinding(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/assistants/{id}/mcp-bindings/{bindingId}", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoAssistantsUpdateMcpBindingResponse.class);
        }
    }

    public final AutomationsApi automations = new AutomationsApi(this);
    public static final class AutomationsApi {
        private final TypedGeneratedApi root;
        public final AutomationsBatchApi batch;
        AutomationsApi(TypedGeneratedApi root) {
            this.root = root;
            this.batch = new AutomationsBatchApi(root);
        }
        public static final class AutomationsBatchApi {
            private final TypedGeneratedApi root;
            AutomationsBatchApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfAutoBatchDeleteResponse batchDelete(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/automations/batch/delete", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfAutoBatchDeleteResponse.class);
            }
        }

        public NtfAutoListAutomationsResponse listAutomations(String page, String limit, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/automations", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoListAutomationsResponse.class);
        }
        public NtfAutoCreateAutomationResponse createAutomation(NtfAutoAutomationCreateBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/automations", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoCreateAutomationResponse.class);
        }
        public NtfAutoDeleteAutomationResponse deleteAutomation(String automationId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/automations/{automationId}", Map.of("automationId", automationId), options);
            return root.objectMapper.treeToValue(node, NtfAutoDeleteAutomationResponse.class);
        }
        public NtfAutoGetAutomationResponse getAutomation(String automationId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/automations/{automationId}", Map.of("automationId", automationId), options);
            return root.objectMapper.treeToValue(node, NtfAutoGetAutomationResponse.class);
        }
        public NtfAutoPatchAutomationResponse patchAutomation(String automationId, NtfAutoAutomationPatchBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/automations/{automationId}", Map.of("automationId", automationId), options);
            return root.objectMapper.treeToValue(node, NtfAutoPatchAutomationResponse.class);
        }
        public NtfAutoDuplicateResponse duplicate(String automationId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/automations/{automationId}/duplicate", Map.of("automationId", automationId), options);
            return root.objectMapper.treeToValue(node, NtfAutoDuplicateResponse.class);
        }
        public NtfAutoListRunsResponse listRuns(String automationId, String page, String limit, String status, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/automations/{automationId}/runs", Map.of("automationId", automationId), options);
            return root.objectMapper.treeToValue(node, NtfAutoListRunsResponse.class);
        }
        public NtfAutoGetRunResponse getRun(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/automations/{automationId}/runs/{runId}", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoGetRunResponse.class);
        }
        public NtfAutoStopAutomationResponse stopAutomation(String automationId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/automations/{automationId}/stop", Map.of("automationId", automationId), options);
            return root.objectMapper.treeToValue(node, NtfAutoStopAutomationResponse.class);
        }
        public NtfAutoTestTriggerResponse testTrigger(String automationId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/automations/{automationId}/test-trigger", Map.of("automationId", automationId), options);
            return root.objectMapper.treeToValue(node, NtfAutoTestTriggerResponse.class);
        }
        public NtfAutoWebhookSecretResponse webhookSecret(String automationId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/automations/{automationId}/webhook-secret", Map.of("automationId", automationId), options);
            return root.objectMapper.treeToValue(node, NtfAutoWebhookSecretResponse.class);
        }
        public NtfAutoAiComposeResponse aiCompose(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/automations/ai-compose", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoAiComposeResponse.class);
        }
        public NtfAutoPostCampaignAgentResponse postCampaignAgent(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/automations/post-campaign-agent", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoPostCampaignAgentResponse.class);
        }
        public NtfAutoQuickChatbotResponse quickChatbot(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/automations/quick-chatbot", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoQuickChatbotResponse.class);
        }
    }

    public final CampaignsApi campaigns = new CampaignsApi(this);
    public static final class CampaignsApi {
        private final TypedGeneratedApi root;
        CampaignsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfContactCampaignListResponse getV1Campaigns(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/campaigns", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactCampaignListResponse.class);
        }
        public NtfContactCampaignOneResponse postV1Campaigns(NtfContactCampaignCreate body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/campaigns", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactCampaignOneResponse.class);
        }
        public NtfContactDeleteV1CampaignResponse deleteV1Campaign(String campaignId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/campaigns/{campaignId}", Map.of("campaignId", campaignId), options);
            return root.objectMapper.treeToValue(node, NtfContactDeleteV1CampaignResponse.class);
        }
        public NtfContactCampaignOneResponse getV1CampaignById(String campaignId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/campaigns/{campaignId}", Map.of("campaignId", campaignId), options);
            return root.objectMapper.treeToValue(node, NtfContactCampaignOneResponse.class);
        }
        public NtfContactCampaignOneResponse patchV1Campaign(String campaignId, NtfContactCampaignPatch body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/campaigns/{campaignId}", Map.of("campaignId", campaignId), options);
            return root.objectMapper.treeToValue(node, NtfContactCampaignOneResponse.class);
        }
        public NtfContactCampaignCancelResponse postV1CampaignCancel(String campaignId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/campaigns/{campaignId}/cancel", Map.of("campaignId", campaignId), options);
            return root.objectMapper.treeToValue(node, NtfContactCampaignCancelResponse.class);
        }
        public NtfContactCampaignRecipientsResponse getV1CampaignRecipients(String campaignId, String channel, String status, String runId, Integer page, Integer pageSize, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (channel != null) { query.put("channel", String.valueOf(channel)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (runId != null) { query.put("runId", String.valueOf(runId)); }
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (pageSize != null) { query.put("pageSize", String.valueOf(pageSize)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/campaigns/{campaignId}/recipients", Map.of("campaignId", campaignId), options);
            return root.objectMapper.treeToValue(node, NtfContactCampaignRecipientsResponse.class);
        }
        public NtfContactCampaignRunResponse postV1CampaignRun(String campaignId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/campaigns/{campaignId}/run", Map.of("campaignId", campaignId), options);
            return root.objectMapper.treeToValue(node, NtfContactCampaignRunResponse.class);
        }
        public NtfContactCampaignRunPreviewResponse getV1CampaignRunPreview(String campaignId, String channels, String excludeAlreadySent, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (channels != null) { query.put("channels", String.valueOf(channels)); }
            if (excludeAlreadySent != null) { query.put("excludeAlreadySent", String.valueOf(excludeAlreadySent)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/campaigns/{campaignId}/run-preview", Map.of("campaignId", campaignId), options);
            return root.objectMapper.treeToValue(node, NtfContactCampaignRunPreviewResponse.class);
        }
        public NtfContactCampaignStatsResponse getV1CampaignStats(String campaignId, String runId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (runId != null) { query.put("runId", String.valueOf(runId)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/campaigns/{campaignId}/stats", Map.of("campaignId", campaignId), options);
            return root.objectMapper.treeToValue(node, NtfContactCampaignStatsResponse.class);
        }
    }

    public final ContactsApi contacts = new ContactsApi(this);
    public static final class ContactsApi {
        private final TypedGeneratedApi root;
        ContactsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfContactGetV1ContactsResponse getV1Contacts(String page, String limit, String search, String tagId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (search != null) { query.put("search", String.valueOf(search)); }
            if (tagId != null) { query.put("tagId", String.valueOf(tagId)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/contacts", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactGetV1ContactsResponse.class);
        }
        public NtfContactPostV1ContactsResponse postV1Contacts(NtfContactContactCreate body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/contacts", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactPostV1ContactsResponse.class);
        }
        public NtfContactDeleteV1ContactResponse deleteV1Contact(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/contacts/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfContactDeleteV1ContactResponse.class);
        }
        public NtfContactGetV1ContactResponse getV1Contact(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/contacts/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfContactGetV1ContactResponse.class);
        }
        public NtfContactPutV1ContactResponse putV1Contact(String id, NtfContactContactUpdate body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PUT", "/v1/contacts/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfContactPutV1ContactResponse.class);
        }
    }

    public final ConversionsApi conversions = new ConversionsApi(this);
    public static final class ConversionsApi {
        private final TypedGeneratedApi root;
        ConversionsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfConversionsPostV1ConversionsResponse postV1Conversions(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/conversions", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfConversionsPostV1ConversionsResponse.class);
        }
    }

    public final EmailApi email = new EmailApi(this);
    public static final class EmailApi {
        private final TypedGeneratedApi root;
        public final EmailDomainsApi domains;
        public final EmailMessagesApi messages;
        EmailApi(TypedGeneratedApi root) {
            this.root = root;
            this.domains = new EmailDomainsApi(root);
            this.messages = new EmailMessagesApi(root);
        }
        public static final class EmailDomainsApi {
            private final TypedGeneratedApi root;
            EmailDomainsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfEmailExpandEmailDomainProvidersResponse postV1EmailDomainExpandProviders(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/email/domains/{id}/expand-providers", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfEmailExpandEmailDomainProvidersResponse.class);
            }
            public NtfEmailVerifyEmailDomainResponse postV1EmailDomainVerify(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/email/domains/{id}/verify", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfEmailVerifyEmailDomainResponse.class);
            }
        }

        public static final class EmailMessagesApi {
            private final TypedGeneratedApi root;
            EmailMessagesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfEmailCancelEmailResponse postV1EmailCancel(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/email/messages/{id}/cancel", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfEmailCancelEmailResponse.class);
            }
        }

        public NtfEmailListEmailDomainsResponse getV1EmailDomains(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/email/domains", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfEmailListEmailDomainsResponse.class);
        }
        public NtfEmailCreateEmailDomainResponse postV1EmailDomains(NtfEmailCreateEmailDomainRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/email/domains", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfEmailCreateEmailDomainResponse.class);
        }
        public NtfEmailEmailDomainResponse getV1EmailDomainById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/email/domains/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfEmailEmailDomainResponse.class);
        }
        public NtfEmailGetV1EmailInboundResponse getV1EmailInbound(String page, String limit, String q, String domainId, String dateFrom, String dateTo, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (q != null) { query.put("q", String.valueOf(q)); }
            if (domainId != null) { query.put("domainId", String.valueOf(domainId)); }
            if (dateFrom != null) { query.put("dateFrom", String.valueOf(dateFrom)); }
            if (dateTo != null) { query.put("dateTo", String.valueOf(dateTo)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/email/inbound", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfEmailGetV1EmailInboundResponse.class);
        }
        public NtfEmailGetV1EmailInboundByIdResponse getV1EmailInboundById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/email/inbound/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfEmailGetV1EmailInboundByIdResponse.class);
        }
        public NtfEmailGetV1EmailMessagesResponse getV1EmailMessages(String page, String limit, String fromDate, String toDate, String status, String emailDomainId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (fromDate != null) { query.put("fromDate", String.valueOf(fromDate)); }
            if (toDate != null) { query.put("toDate", String.valueOf(toDate)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (emailDomainId != null) { query.put("emailDomainId", String.valueOf(emailDomainId)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/email/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfEmailGetV1EmailMessagesResponse.class);
        }
        public NtfEmailSendEmailResponse postV1EmailSend(NtfEmailSendEmailRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/email/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfEmailSendEmailResponse.class);
        }
        public NtfEmailEmailStatusResponse getV1EmailById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/email/messages/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfEmailEmailStatusResponse.class);
        }
    }

    public final EventsApi events = new EventsApi(this);
    public static final class EventsApi {
        private final TypedGeneratedApi root;
        public final EventsBatchApi batch;
        EventsApi(TypedGeneratedApi root) {
            this.root = root;
            this.batch = new EventsBatchApi(root);
        }
        public static final class EventsBatchApi {
            private final TypedGeneratedApi root;
            EventsBatchApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfAutoBatchDeleteEventsResponse batchDeleteEvents(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/events/batch/delete", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfAutoBatchDeleteEventsResponse.class);
            }
        }

        public NtfAutoListEventsResponse listEvents(String page, String limit, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/events", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoListEventsResponse.class);
        }
        public NtfAutoCreateEventResponse createEvent(NtfAutoEventCreateBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/events", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoCreateEventResponse.class);
        }
        public NtfAutoDeleteEventResponse deleteEvent(String eventId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/events/{eventId}", Map.of("eventId", eventId), options);
            return root.objectMapper.treeToValue(node, NtfAutoDeleteEventResponse.class);
        }
        public NtfAutoGetEventResponse getEvent(String eventId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/events/{eventId}", Map.of("eventId", eventId), options);
            return root.objectMapper.treeToValue(node, NtfAutoGetEventResponse.class);
        }
        public NtfAutoPatchEventResponse patchEvent(String eventId, NtfAutoEventPatchBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/events/{eventId}", Map.of("eventId", eventId), options);
            return root.objectMapper.treeToValue(node, NtfAutoPatchEventResponse.class);
        }
        public NtfAutoSendEventResponse sendEvent(NtfAutoEventSendBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/events/send", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoSendEventResponse.class);
        }
    }

    public final FormsApi forms = new FormsApi(this);
    public static final class FormsApi {
        private final TypedGeneratedApi root;
        public final FormsListsApi lists;
        public final FormsSubscriptionsApi subscriptions;
        FormsApi(TypedGeneratedApi root) {
            this.root = root;
            this.lists = new FormsListsApi(root);
            this.subscriptions = new FormsSubscriptionsApi(root);
        }
        public static final class FormsListsApi {
            private final TypedGeneratedApi root;
            FormsListsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfAddonsFormSubscriptionCollectionEnvelope getV1FormsListSubscriptions(String id, String page, String limit, String status, String search, String subscribedFrom, String subscribedTo, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (page != null) { query.put("page", String.valueOf(page)); }
                if (limit != null) { query.put("limit", String.valueOf(limit)); }
                if (status != null) { query.put("status", String.valueOf(status)); }
                if (search != null) { query.put("search", String.valueOf(search)); }
                if (subscribedFrom != null) { query.put("subscribedFrom", String.valueOf(subscribedFrom)); }
                if (subscribedTo != null) { query.put("subscribedTo", String.valueOf(subscribedTo)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/forms/lists/{id}/subscriptions", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfAddonsFormSubscriptionCollectionEnvelope.class);
            }
            public NtfAddonsDeleteV1FormsSubscriptionResponse deleteV1FormsSubscription(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("DELETE", "/v1/forms/lists/{id}/subscriptions/{subscriptionId}", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfAddonsDeleteV1FormsSubscriptionResponse.class);
            }
            public String getV1FormsSubscriptionExport(String id, String status, String search, String subscribedFrom, String subscribedTo, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (status != null) { query.put("status", String.valueOf(status)); }
                if (search != null) { query.put("search", String.valueOf(search)); }
                if (subscribedFrom != null) { query.put("subscribedFrom", String.valueOf(subscribedFrom)); }
                if (subscribedTo != null) { query.put("subscribedTo", String.valueOf(subscribedTo)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                return root.transport.requestRaw("GET", "/v1/forms/lists/{id}/subscriptions/export", Map.of("id", id), options);
            }
            public NtfAddonsGetV1FormsSubscriptionStatsResponse getV1FormsSubscriptionStats(String id, Integer trendDays, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (trendDays != null) { query.put("trendDays", String.valueOf(trendDays)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/forms/lists/{id}/subscriptions/stats", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfAddonsGetV1FormsSubscriptionStatsResponse.class);
            }
        }

        public static final class FormsSubscriptionsApi {
            private final TypedGeneratedApi root;
            FormsSubscriptionsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfAddonsNewsletterCancelEnvelope postV1FormsSubscriptionCancel(String id, NtfAddonsNewsletterCancelRequest body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/forms/subscriptions/{id}/cancel", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfAddonsNewsletterCancelEnvelope.class);
            }
            public NtfAddonsFormConfirmEnvelope postV1FormsSubscriptionsConfirm(NtfAddonsFormConfirmRequest body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/forms/subscriptions/confirm", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfAddonsFormConfirmEnvelope.class);
            }
        }

        public NtfAddonsFormListCollectionEnvelope getV1FormsLists(String page, String limit, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/forms/lists", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAddonsFormListCollectionEnvelope.class);
        }
        public NtfAddonsFormListEnvelope postV1FormsLists(NtfAddonsCreateFormListRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/forms/lists", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAddonsFormListEnvelope.class);
        }
        public NtfAddonsFormDeleteEnvelope deleteV1FormsList(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/forms/lists/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAddonsFormDeleteEnvelope.class);
        }
        public NtfAddonsFormListEnvelope getV1FormsList(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/forms/lists/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAddonsFormListEnvelope.class);
        }
        public NtfAddonsFormListPatchEnvelope patchV1FormsList(String id, NtfAddonsPatchFormListRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/forms/lists/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAddonsFormListPatchEnvelope.class);
        }
        public NtfAddonsGetV1FormsSubscriptionsAllResponse getV1FormsSubscriptionsAll(String page, String limit, String listId, String status, String search, String subscribedFrom, String subscribedTo, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (listId != null) { query.put("listId", String.valueOf(listId)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (search != null) { query.put("search", String.valueOf(search)); }
            if (subscribedFrom != null) { query.put("subscribedFrom", String.valueOf(subscribedFrom)); }
            if (subscribedTo != null) { query.put("subscribedTo", String.valueOf(subscribedTo)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/forms/subscriptions", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAddonsGetV1FormsSubscriptionsAllResponse.class);
        }
        public NtfAddonsFormSubscribeEnvelope postV1FormsSubscriptions(NtfAddonsFormSubscribeRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/forms/subscriptions", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAddonsFormSubscribeEnvelope.class);
        }
    }

    public final HttpToolsApi httpTools = new HttpToolsApi(this);
    public static final class HttpToolsApi {
        private final TypedGeneratedApi root;
        HttpToolsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfAutoHttpListResponse httpList(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/http-tools", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoHttpListResponse.class);
        }
        public NtfAutoHttpCreateResponse httpCreate(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/http-tools", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoHttpCreateResponse.class);
        }
        public NtfAutoHttpDeleteResponse httpDelete(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/http-tools/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoHttpDeleteResponse.class);
        }
        public NtfAutoHttpGetResponse httpGet(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/http-tools/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoHttpGetResponse.class);
        }
        public NtfAutoHttpUpdateResponse httpUpdate(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/http-tools/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoHttpUpdateResponse.class);
        }
    }

    public final InstagramApi instagram = new InstagramApi(this);
    public static final class InstagramApi {
        private final TypedGeneratedApi root;
        public final InstagramCommentsApi comments;
        public final InstagramInstancesApi instances;
        public final InstagramMessagesApi messages;
        InstagramApi(TypedGeneratedApi root) {
            this.root = root;
            this.comments = new InstagramCommentsApi(root);
            this.instances = new InstagramInstancesApi(root);
            this.messages = new InstagramMessagesApi(root);
        }
        public static final class InstagramCommentsApi {
            private final TypedGeneratedApi root;
            InstagramCommentsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfIgHideCommentResponse hideComment(String commentId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/instagram/comments/{commentId}/hide", Map.of("commentId", commentId), options);
                return root.objectMapper.treeToValue(node, NtfIgHideCommentResponse.class);
            }
            public NtfIgReplyCommentResponse replyComment(String commentId, NtfIgReplyCommentBody body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/instagram/comments/{commentId}/reply", Map.of("commentId", commentId), options);
                return root.objectMapper.treeToValue(node, NtfIgReplyCommentResponse.class);
            }
        }

        public static final class InstagramInstancesApi {
            private final TypedGeneratedApi root;
            InstagramInstancesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfIgResolveChallengeResponse resolveChallenge(String instanceId, NtfIgResolveChallengeBody body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/instagram/instances/{instanceId}/challenge/resolve", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfIgResolveChallengeResponse.class);
            }
            public NtfIgConnectPageStatusResponse getConnectPage(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/instagram/instances/{instanceId}/connect-page", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfIgConnectPageStatusResponse.class);
            }
            public NtfIgConnectPageDisableResponse disableConnectPage(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/instagram/instances/{instanceId}/connect-page/disable", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfIgConnectPageDisableResponse.class);
            }
            public NtfIgConnectPageEnableResponse enableConnectPage(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/instagram/instances/{instanceId}/connect-page/enable", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfIgConnectPageEnableResponse.class);
            }
            public NtfIgConnectPageEnableResponse rotateConnectPage(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/instagram/instances/{instanceId}/connect-page/rotate-secret", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfIgConnectPageEnableResponse.class);
            }
            public NtfIgConnectionStatus getConnection(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/instagram/instances/{instanceId}/connection", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfIgConnectionStatus.class);
            }
            public NtfIgDisconnectInstanceResponse disconnectInstance(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/instagram/instances/{instanceId}/disconnect", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfIgDisconnectInstanceResponse.class);
            }
        }

        public static final class InstagramMessagesApi {
            private final TypedGeneratedApi root;
            InstagramMessagesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfIgCancelMessageResponse cancelMessage(String messageId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/instagram/messages/{messageId}/cancel", Map.of("messageId", messageId), options);
                return root.objectMapper.treeToValue(node, NtfIgCancelMessageResponse.class);
            }
            public NtfIgEditMessageResponse editMessage(String messageId, NtfIgEditMessageBody body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("PATCH", "/v1/instagram/messages/{messageId}/edit", Map.of("messageId", messageId), options);
                return root.objectMapper.treeToValue(node, NtfIgEditMessageResponse.class);
            }
            public NtfIgListInboundResponse listInbound(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/instagram/messages/inbound", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfIgListInboundResponse.class);
            }
            public NtfIgGetInboundResponse getInbound(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/instagram/messages/inbound/{id}", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfIgGetInboundResponse.class);
            }
            public NtfIgPostInboundMediaResponse postInboundMedia(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/instagram/messages/inbound/{id}/media", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfIgPostInboundMediaResponse.class);
            }
            public String getInboundMediaDownload(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                return root.transport.requestRaw("GET", "/v1/instagram/messages/inbound/{id}/media/download", Map.of("id", id), options);
            }
        }

        public NtfIgListCommentsResponse listComments(String instanceId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (instanceId != null) { query.put("instanceId", String.valueOf(instanceId)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/instagram/comments", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfIgListCommentsResponse.class);
        }
        public NtfIgDeleteCommentResponse deleteComment(String commentId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/instagram/comments/{commentId}", Map.of("commentId", commentId), options);
            return root.objectMapper.treeToValue(node, NtfIgDeleteCommentResponse.class);
        }
        public NtfIgGetCommentResponse getComment(String commentId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/instagram/comments/{commentId}", Map.of("commentId", commentId), options);
            return root.objectMapper.treeToValue(node, NtfIgGetCommentResponse.class);
        }
        public NtfIgListInstancesResponse listInstances(String page, String limit, String status, String search, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (search != null) { query.put("search", String.valueOf(search)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/instagram/instances", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfIgListInstancesResponse.class);
        }
        public NtfIgCreateInstanceResponse createInstance(NtfIgCreateInstanceBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/instagram/instances", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfIgCreateInstanceResponse.class);
        }
        public NtfIgDeleteInstanceResponse deleteInstance(String instanceId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/instagram/instances/{instanceId}", Map.of("instanceId", instanceId), options);
            return root.objectMapper.treeToValue(node, NtfIgDeleteInstanceResponse.class);
        }
        public NtfIgInstanceDetail getInstance(String instanceId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/instagram/instances/{instanceId}", Map.of("instanceId", instanceId), options);
            return root.objectMapper.treeToValue(node, NtfIgInstanceDetail.class);
        }
        public NtfIgListMessagesResponse listMessages(String page, String limit, String instanceIds, String status, String typeParam, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (instanceIds != null) { query.put("instanceIds", String.valueOf(instanceIds)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (typeParam != null) { query.put("type", String.valueOf(typeParam)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/instagram/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfIgListMessagesResponse.class);
        }
        public NtfIgSendMessageResponse sendMessage(NtfIgSendMessageBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/instagram/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfIgSendMessageResponse.class);
        }
        public NtfIgDeleteMessageResponse deleteMessage(String messageId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/instagram/messages/{messageId}", Map.of("messageId", messageId), options);
            return root.objectMapper.treeToValue(node, NtfIgDeleteMessageResponse.class);
        }
        public NtfIgGetMessageResponse getMessage(String messageId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/instagram/messages/{messageId}", Map.of("messageId", messageId), options);
            return root.objectMapper.treeToValue(node, NtfIgGetMessageResponse.class);
        }
    }

    public final KnowledgeBasesApi knowledgeBases = new KnowledgeBasesApi(this);
    public static final class KnowledgeBasesApi {
        private final TypedGeneratedApi root;
        KnowledgeBasesApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfAutoKbListResponse kbList(String page, String limit, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/knowledge-bases", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbListResponse.class);
        }
        public NtfAutoKbCreateResponse kbCreate(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/knowledge-bases", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbCreateResponse.class);
        }
        public NtfAutoKbDeleteResponse kbDelete(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/knowledge-bases/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbDeleteResponse.class);
        }
        public NtfAutoKbGetResponse kbGet(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/knowledge-bases/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbGetResponse.class);
        }
        public NtfAutoKbUpdateResponse kbUpdate(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/knowledge-bases/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbUpdateResponse.class);
        }
        public NtfAutoKbListDocsResponse kbListDocs(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/knowledge-bases/{id}/documents", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbListDocsResponse.class);
        }
        public NtfAutoKbCreateDocResponse kbCreateDoc(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/knowledge-bases/{id}/documents", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbCreateDocResponse.class);
        }
        public NtfAutoKbDeleteDocResponse kbDeleteDoc(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/knowledge-bases/{id}/documents/{docId}", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbDeleteDocResponse.class);
        }
        public NtfAutoKbGetDocResponse kbGetDoc(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/knowledge-bases/{id}/documents/{docId}", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbGetDocResponse.class);
        }
        public NtfAutoKbUpdateDocResponse kbUpdateDoc(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/knowledge-bases/{id}/documents/{docId}", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoKbUpdateDocResponse.class);
        }
    }

    public final LogsApi logs = new LogsApi(this);
    public static final class LogsApi {
        private final TypedGeneratedApi root;
        LogsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public LogsListResponse getV1Logs(Integer page, Integer limit, String status, String startDate, String endDate, String method, String apiKeyId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (startDate != null) { query.put("startDate", String.valueOf(startDate)); }
            if (endDate != null) { query.put("endDate", String.valueOf(endDate)); }
            if (method != null) { query.put("method", String.valueOf(method)); }
            if (apiKeyId != null) { query.put("apiKeyId", String.valueOf(apiKeyId)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/logs", Map.of(), options);
            return root.objectMapper.treeToValue(node, LogsListResponse.class);
        }
        public GetV1LogsByIdResponse getV1LogsById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/logs/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, GetV1LogsByIdResponse.class);
        }
    }

    public final McpConnectionsApi mcpConnections = new McpConnectionsApi(this);
    public static final class McpConnectionsApi {
        private final TypedGeneratedApi root;
        McpConnectionsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfAutoMcpListResponse mcpList(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/mcp-connections", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoMcpListResponse.class);
        }
        public NtfAutoMcpCreateResponse mcpCreate(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/mcp-connections", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfAutoMcpCreateResponse.class);
        }
        public NtfAutoMcpDeleteResponse mcpDelete(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/mcp-connections/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoMcpDeleteResponse.class);
        }
        public NtfAutoMcpGetResponse mcpGet(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/mcp-connections/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoMcpGetResponse.class);
        }
        public NtfAutoMcpUpdateResponse mcpUpdate(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/mcp-connections/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoMcpUpdateResponse.class);
        }
        public NtfAutoMcpRefreshManifestResponse mcpRefreshManifest(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/mcp-connections/{id}/refresh-manifest", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfAutoMcpRefreshManifestResponse.class);
        }
    }

    public final MetaApi meta = new MetaApi(this);
    public static final class MetaApi {
        private final TypedGeneratedApi root;
        MetaApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfContactGetV1MetaContactLocalesResponse getV1MetaContactLocales(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/meta/contact-locales", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactGetV1MetaContactLocalesResponse.class);
        }
    }

    public final MetricsApi metrics = new MetricsApi(this);
    public static final class MetricsApi {
        private final TypedGeneratedApi root;
        MetricsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfPlatformGetMetricsOverviewResponse getMetricsOverview(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/metrics/overview", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformGetMetricsOverviewResponse.class);
        }
    }

    public final NotifyApi notify = new NotifyApi(this);
    public static final class NotifyApi {
        private final TypedGeneratedApi root;
        NotifyApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfPlatformPostNotifyResponse postNotify(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/notify", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformPostNotifyResponse.class);
        }
    }

    public final PhoneNumbersApi phoneNumbers = new PhoneNumbersApi(this);
    public static final class PhoneNumbersApi {
        private final TypedGeneratedApi root;
        public final PhoneNumbersOrdersApi orders;
        public final PhoneNumbersRegulatoryApi regulatory;
        PhoneNumbersApi(TypedGeneratedApi root) {
            this.root = root;
            this.orders = new PhoneNumbersOrdersApi(root);
            this.regulatory = new PhoneNumbersRegulatoryApi(root);
        }
        public static final class PhoneNumbersOrdersApi {
            private final TypedGeneratedApi root;
            PhoneNumbersOrdersApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfPhoneRegDocumentResponse regDocument(String orderId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/phone-numbers/orders/{orderId}/regulatory/documents", Map.of("orderId", orderId), options);
                return root.objectMapper.treeToValue(node, NtfPhoneRegDocumentResponse.class);
            }
            public NtfPhoneRegStatusResponse regStatus(String orderId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/phone-numbers/orders/{orderId}/regulatory/status", Map.of("orderId", orderId), options);
                return root.objectMapper.treeToValue(node, NtfPhoneRegStatusResponse.class);
            }
            public NtfPhoneRegSubmitResponse regSubmit(String orderId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/phone-numbers/orders/{orderId}/regulatory/submit", Map.of("orderId", orderId), options);
                return root.objectMapper.treeToValue(node, NtfPhoneRegSubmitResponse.class);
            }
            public NtfPhoneReplacementOptionsResponse replacementOptions(String orderId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/phone-numbers/orders/{orderId}/replacement-options", Map.of("orderId", orderId), options);
                return root.objectMapper.treeToValue(node, NtfPhoneReplacementOptionsResponse.class);
            }
            public NtfPhoneSelectReplacementResponse selectReplacement(String orderId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/phone-numbers/orders/{orderId}/select-replacement-number", Map.of("orderId", orderId), options);
                return root.objectMapper.treeToValue(node, NtfPhoneSelectReplacementResponse.class);
            }
        }

        public static final class PhoneNumbersRegulatoryApi {
            private final TypedGeneratedApi root;
            PhoneNumbersRegulatoryApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfPhoneRegProfileResponse regProfile(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("PUT", "/v1/phone-numbers/regulatory/profile", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfPhoneRegProfileResponse.class);
            }
            public NtfPhoneRegRequirementsResponse regRequirements(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/phone-numbers/regulatory/requirements", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfPhoneRegRequirementsResponse.class);
            }
        }

        public NtfPhoneListEnvelope getV1PhoneNumbers(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/phone-numbers", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPhoneListEnvelope.class);
        }
        public NtfPhoneSingleEnvelope getV1PhoneNumbersById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/phone-numbers/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPhoneSingleEnvelope.class);
        }
        public NtfPhoneSingleEnvelope patchV1PhoneNumbersById(String id, NtfPhoneUpdateBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/phone-numbers/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPhoneSingleEnvelope.class);
        }
        public NtfPhoneGetV1PhoneNumbersAvailableResponse getV1PhoneNumbersAvailable(String countryCode, String phoneNumberType, String areaCode, String contains, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (countryCode != null) { query.put("countryCode", String.valueOf(countryCode)); }
            if (phoneNumberType != null) { query.put("phoneNumberType", String.valueOf(phoneNumberType)); }
            if (areaCode != null) { query.put("areaCode", String.valueOf(areaCode)); }
            if (contains != null) { query.put("contains", String.valueOf(contains)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/phone-numbers/available", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPhoneGetV1PhoneNumbersAvailableResponse.class);
        }
        public NtfPhoneConfigResponse config(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/phone-numbers/config", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPhoneConfigResponse.class);
        }
        public NtfPhoneCreateOrderResponse createOrder(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/phone-numbers/orders", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPhoneCreateOrderResponse.class);
        }
        public NtfPhoneGetOrderResponse getOrder(String orderId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/phone-numbers/orders/{orderId}", Map.of("orderId", orderId), options);
            return root.objectMapper.treeToValue(node, NtfPhoneGetOrderResponse.class);
        }
    }

    public final PipelinesApi pipelines = new PipelinesApi(this);
    public static final class PipelinesApi {
        private final TypedGeneratedApi root;
        public final PipelinesBoardsApi boards;
        public final PipelinesCardsApi cards;
        public final PipelinesContactsApi contacts;
        PipelinesApi(TypedGeneratedApi root) {
            this.root = root;
            this.boards = new PipelinesBoardsApi(root);
            this.cards = new PipelinesCardsApi(root);
            this.contacts = new PipelinesContactsApi(root);
        }
        public static final class PipelinesBoardsApi {
            private final TypedGeneratedApi root;
            PipelinesBoardsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfPipeCreateCardResponse createCard(String boardId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/pipelines/boards/{boardId}/cards", Map.of("boardId", boardId), options);
                return root.objectMapper.treeToValue(node, NtfPipeCreateCardResponse.class);
            }
            public NtfPipeReplaceColumnsResponse replaceColumns(String boardId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("PUT", "/v1/pipelines/boards/{boardId}/columns", Map.of("boardId", boardId), options);
                return root.objectMapper.treeToValue(node, NtfPipeReplaceColumnsResponse.class);
            }
            public NtfPipeBoardOverviewResponse boardOverview(String boardId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/pipelines/boards/{boardId}/overview", Map.of("boardId", boardId), options);
                return root.objectMapper.treeToValue(node, NtfPipeBoardOverviewResponse.class);
            }
        }

        public static final class PipelinesCardsApi {
            private final TypedGeneratedApi root;
            PipelinesCardsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfPipeMoveCardResponse moveCard(String cardId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/pipelines/cards/{cardId}/move", Map.of("cardId", cardId), options);
                return root.objectMapper.treeToValue(node, NtfPipeMoveCardResponse.class);
            }
        }

        public static final class PipelinesContactsApi {
            private final TypedGeneratedApi root;
            PipelinesContactsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfPipeContactCardsResponse contactCards(String contactId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/pipelines/contacts/{contactId}/cards", Map.of("contactId", contactId), options);
                return root.objectMapper.treeToValue(node, NtfPipeContactCardsResponse.class);
            }
        }

        public NtfPipeListBoardsResponse listBoards(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/pipelines/boards", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPipeListBoardsResponse.class);
        }
        public NtfPipeCreateBoardResponse createBoard(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/pipelines/boards", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPipeCreateBoardResponse.class);
        }
        public NtfPipeGetBoardResponse getBoard(String boardId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/pipelines/boards/{boardId}", Map.of("boardId", boardId), options);
            return root.objectMapper.treeToValue(node, NtfPipeGetBoardResponse.class);
        }
        public NtfPipePatchBoardResponse patchBoard(String boardId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/pipelines/boards/{boardId}", Map.of("boardId", boardId), options);
            return root.objectMapper.treeToValue(node, NtfPipePatchBoardResponse.class);
        }
        public NtfPipePatchCardResponse patchCard(String cardId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/pipelines/cards/{cardId}", Map.of("cardId", cardId), options);
            return root.objectMapper.treeToValue(node, NtfPipePatchCardResponse.class);
        }
    }

    public final PlatformApi platform = new PlatformApi(this);
    public static final class PlatformApi {
        private final TypedGeneratedApi root;
        public final PlatformApiKeysApi apiKeys;
        public final PlatformWorkspacesApi workspaces;
        PlatformApi(TypedGeneratedApi root) {
            this.root = root;
            this.apiKeys = new PlatformApiKeysApi(root);
            this.workspaces = new PlatformWorkspacesApi(root);
        }
        public static final class PlatformApiKeysApi {
            private final TypedGeneratedApi root;
            PlatformApiKeysApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfPlatformRevokeApiKeyResponse revokeApiKey(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/platform/api-keys/{id}/revoke", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformRevokeApiKeyResponse.class);
            }
        }

        public static final class PlatformWorkspacesApi {
            private final TypedGeneratedApi root;
            PlatformWorkspacesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfPlatformGetBalanceResponse getBalance(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/platform/workspaces/{id}/balance", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformGetBalanceResponse.class);
            }
            public NtfPlatformRechargeBalanceResponse rechargeBalance(String id, NtfPlatformRechargeBody body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/platform/workspaces/{id}/balance/recharge", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformRechargeBalanceResponse.class);
            }
            public NtfPlatformCreditsUsageResponse getCreditsUsage(String id, String page, String limit, String chargedAs, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (page != null) { query.put("page", String.valueOf(page)); }
                if (limit != null) { query.put("limit", String.valueOf(limit)); }
                if (chargedAs != null) { query.put("chargedAs", String.valueOf(chargedAs)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/platform/workspaces/{id}/credits/usage", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformCreditsUsageResponse.class);
            }
            public NtfPlatformInvitesListResponse listInvites(String id, String page, String limit, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (page != null) { query.put("page", String.valueOf(page)); }
                if (limit != null) { query.put("limit", String.valueOf(limit)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/platform/workspaces/{id}/invites", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformInvitesListResponse.class);
            }
            public NtfPlatformCreateInviteResponse createInvite(String id, NtfPlatformInviteBody body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/platform/workspaces/{id}/invites", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformCreateInviteResponse.class);
            }
            public NtfPlatformCancelInviteResponse cancelInvite(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("DELETE", "/v1/platform/workspaces/{id}/invites/{inviteId}", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfPlatformCancelInviteResponse.class);
            }
            public NtfPlatformMembersListResponse listMembers(String id, String page, String limit, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (page != null) { query.put("page", String.valueOf(page)); }
                if (limit != null) { query.put("limit", String.valueOf(limit)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/platform/workspaces/{id}/members", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformMembersListResponse.class);
            }
            public NtfPlatformRemoveMemberResponse removeMember(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("DELETE", "/v1/platform/workspaces/{id}/members/{userId}", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfPlatformRemoveMemberResponse.class);
            }
            public NtfPlatformListPaymentMethodsResponse listPaymentMethods(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/platform/workspaces/{id}/payment-methods", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformListPaymentMethodsResponse.class);
            }
            public NtfPlatformCreatePaymentMethodResponse createPaymentMethod(String id, NtfPlatformPaymentMethodCreate body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/platform/workspaces/{id}/payment-methods", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformCreatePaymentMethodResponse.class);
            }
            public NtfPlatformDeletePaymentMethodResponse deletePaymentMethod(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("DELETE", "/v1/platform/workspaces/{id}/payment-methods/{pmId}", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfPlatformDeletePaymentMethodResponse.class);
            }
            public NtfPlatformUpdatePaymentMethodResponse updatePaymentMethod(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("PATCH", "/v1/platform/workspaces/{id}/payment-methods/{pmId}", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfPlatformUpdatePaymentMethodResponse.class);
            }
            public NtfPlatformCancelSubscriptionResponse cancelSubscription(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("DELETE", "/v1/platform/workspaces/{id}/subscription", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformCancelSubscriptionResponse.class);
            }
            public NtfPlatformSubscriptionResponse getWorkspaceSubscription(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/platform/workspaces/{id}/subscription", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformSubscriptionResponse.class);
            }
            public NtfPlatformSubscribeWorkspaceResponse subscribeWorkspace(String id, NtfPlatformSubscribeBody body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/platform/workspaces/{id}/subscription", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPlatformSubscribeWorkspaceResponse.class);
            }
        }

        public NtfPlatformListApiKeysResponse listApiKeys(Boolean includeRevoked, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (includeRevoked != null) { query.put("includeRevoked", String.valueOf(includeRevoked)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/platform/api-keys", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformListApiKeysResponse.class);
        }
        public NtfPlatformCreateApiKeyResponse createApiKey(NtfPlatformApiKeyCreate body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/platform/api-keys", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformCreateApiKeyResponse.class);
        }
        public NtfPlatformGetApiKeyResponse getApiKey(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/platform/api-keys/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPlatformGetApiKeyResponse.class);
        }
        public NtfPlatformPatchApiKeyResponse patchApiKey(String id, NtfPlatformApiKeyPatch body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/platform/api-keys/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPlatformPatchApiKeyResponse.class);
        }
        public NtfPlatformLoginResponse postLogin(NtfPlatformLoginBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/platform/login", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformLoginResponse.class);
        }
        public NtfPlatformGetMeResponse getMe(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/platform/me", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformGetMeResponse.class);
        }
        public NtfPlatformRegisterResponse postRegister(NtfPlatformRegisterBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/platform/register", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformRegisterResponse.class);
        }
        public NtfPlatformVerifyResponse postVerify(NtfPlatformVerifyBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/platform/verify", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformVerifyResponse.class);
        }
        public NtfPlatformListUserWorkspacesResponse listUserWorkspaces(String include, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (include != null) { query.put("include", String.valueOf(include)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/platform/workspaces", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformListUserWorkspacesResponse.class);
        }
    }

    public final PricingApi pricing = new PricingApi(this);
    public static final class PricingApi {
        private final TypedGeneratedApi root;
        PricingApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfPlatformGetPricingResponse getPricing(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/pricing", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPlatformGetPricingResponse.class);
        }
    }

    public final PushApi push = new PushApi(this);
    public static final class PushApi {
        private final TypedGeneratedApi root;
        public final PushMessagesApi messages;
        PushApi(TypedGeneratedApi root) {
            this.root = root;
            this.messages = new PushMessagesApi(root);
        }
        public static final class PushMessagesApi {
            private final TypedGeneratedApi root;
            PushMessagesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfPushCancelPushResponse postV1PushMessagesCancel(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/push/messages/{id}/cancel", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfPushCancelPushResponse.class);
            }
        }

        public NtfPushPushAppListResponse getV1PushApps(Integer page, Integer limit, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/push/apps", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPushPushAppListResponse.class);
        }
        public NtfPushPushAppSingleResponse postV1PushApps(NtfPushPushAppCreateRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/push/apps", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPushPushAppSingleResponse.class);
        }
        public NtfPushDeleteV1PushAppsByIdResponse deleteV1PushAppsById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/push/apps/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPushDeleteV1PushAppsByIdResponse.class);
        }
        public NtfPushPushAppSingleResponse getV1PushAppsById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/push/apps/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPushPushAppSingleResponse.class);
        }
        public NtfPushPushAppSingleResponse putV1PushAppsById(String id, NtfPushPushAppUpdateRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PUT", "/v1/push/apps/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPushPushAppSingleResponse.class);
        }
        public NtfPushPushDeviceListResponse getV1PushDevices(Integer page, Integer limit, String appId, String platform, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (appId != null) { query.put("appId", String.valueOf(appId)); }
            if (platform != null) { query.put("platform", String.valueOf(platform)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/push/devices", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPushPushDeviceListResponse.class);
        }
        public NtfPushPushDeviceSingleResponse postV1PushDevices(NtfPushPushDeviceRegisterRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/push/devices", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPushPushDeviceSingleResponse.class);
        }
        public NtfPushDeleteV1PushDevicesByIdResponse deleteV1PushDevicesById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/push/devices/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPushDeleteV1PushDevicesByIdResponse.class);
        }
        public NtfPushPushDeviceSingleResponse getV1PushDevicesById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/push/devices/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPushPushDeviceSingleResponse.class);
        }
        public NtfPushPushMessageListResponse getV1PushMessages(Integer page, Integer limit, String status, String appId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (appId != null) { query.put("appId", String.valueOf(appId)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/push/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPushPushMessageListResponse.class);
        }
        public NtfPushSendPushResponse postV1PushMessages(NtfPushSendPushRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/push/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPushSendPushResponse.class);
        }
        public NtfPushPushMessageSingleResponse getV1PushMessagesById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/push/messages/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPushPushMessageSingleResponse.class);
        }
    }

    public final RcsApi rcs = new RcsApi(this);
    public static final class RcsApi {
        private final TypedGeneratedApi root;
        public final RcsMessagesApi messages;
        RcsApi(TypedGeneratedApi root) {
            this.root = root;
            this.messages = new RcsMessagesApi(root);
        }
        public static final class RcsMessagesApi {
            private final TypedGeneratedApi root;
            RcsMessagesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfRcsCancelRcsResponse postV1RcsCancel(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/rcs/messages/{id}/cancel", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfRcsCancelRcsResponse.class);
            }
        }

        public NtfRcsGetV1RcsMessagesResponse getV1RcsMessages(String page, String limit, String fromDate, String toDate, String status, String to, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (fromDate != null) { query.put("fromDate", String.valueOf(fromDate)); }
            if (toDate != null) { query.put("toDate", String.valueOf(toDate)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (to != null) { query.put("to", String.valueOf(to)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/rcs/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfRcsGetV1RcsMessagesResponse.class);
        }
        public NtfRcsSendRcsResponse postV1RcsSend(NtfRcsSendRcsRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/rcs/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfRcsSendRcsResponse.class);
        }
        public NtfRcsRcsStatusResponse getV1RcsById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/rcs/messages/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfRcsRcsStatusResponse.class);
        }
    }

    public final ReportApi report = new ReportApi(this);
    public static final class ReportApi {
        private final TypedGeneratedApi root;
        ReportApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public ReportOkResponse postV1Report(ReportRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/report", Map.of(), options);
            return root.objectMapper.treeToValue(node, ReportOkResponse.class);
        }
    }

    public final SegmentsApi segments = new SegmentsApi(this);
    public static final class SegmentsApi {
        private final TypedGeneratedApi root;
        SegmentsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfContactSegmentListResponse getV1Segments(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/segments", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactSegmentListResponse.class);
        }
        public NtfContactSegmentOneResponse postV1Segments(NtfContactSegmentCreate body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/segments", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactSegmentOneResponse.class);
        }
        public NtfContactDeleteV1SegmentResponse deleteV1Segment(String segmentId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/segments/{segmentId}", Map.of("segmentId", segmentId), options);
            return root.objectMapper.treeToValue(node, NtfContactDeleteV1SegmentResponse.class);
        }
        public NtfContactSegmentOneResponse getV1SegmentById(String segmentId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/segments/{segmentId}", Map.of("segmentId", segmentId), options);
            return root.objectMapper.treeToValue(node, NtfContactSegmentOneResponse.class);
        }
        public NtfContactSegmentOneResponse patchV1Segment(String segmentId, NtfContactSegmentPatch body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/segments/{segmentId}", Map.of("segmentId", segmentId), options);
            return root.objectMapper.treeToValue(node, NtfContactSegmentOneResponse.class);
        }
        public NtfContactSegmentPreviewResponse getV1SegmentPreview(String segmentId, String page, String limit, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/segments/{segmentId}/preview", Map.of("segmentId", segmentId), options);
            return root.objectMapper.treeToValue(node, NtfContactSegmentPreviewResponse.class);
        }
    }

    public final SendingPoolsApi sendingPools = new SendingPoolsApi(this);
    public static final class SendingPoolsApi {
        private final TypedGeneratedApi root;
        SendingPoolsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfPoolListResponse list(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/sending-pools", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPoolListResponse.class);
        }
        public NtfPoolCreateResponse create(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/sending-pools", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPoolCreateResponse.class);
        }
        public NtfPoolDeleteResponse delete(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/sending-pools/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPoolDeleteResponse.class);
        }
        public NtfPoolGetResponse get(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/sending-pools/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPoolGetResponse.class);
        }
        public NtfPoolUpdateResponse update(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PUT", "/v1/sending-pools/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPoolUpdateResponse.class);
        }
        public NtfPoolAddMemberResponse addMember(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/sending-pools/{id}/members", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPoolAddMemberResponse.class);
        }
        public NtfPoolDeleteMemberResponse deleteMember(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/sending-pools/{id}/members/{memberId}", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPoolDeleteMemberResponse.class);
        }
        public NtfPoolUpdateMemberResponse updateMember(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PUT", "/v1/sending-pools/{id}/members/{memberId}", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfPoolUpdateMemberResponse.class);
        }
        public NtfPoolStatsResponse stats(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/sending-pools/{id}/stats", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfPoolStatsResponse.class);
        }
    }

    public final ShortLinksApi shortLinks = new ShortLinksApi(this);
    public static final class ShortLinksApi {
        private final TypedGeneratedApi root;
        ShortLinksApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfShortLinksListResponse getV1ShortLinks(String page, String limit, String source, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (source != null) { query.put("source", String.valueOf(source)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/short-links", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfShortLinksListResponse.class);
        }
        public NtfShortLinksCreateResponse postV1ShortLinks(NtfShortLinksCreateRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/short-links", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfShortLinksCreateResponse.class);
        }
        public NtfShortLinksDeleteResponse deleteV1ShortLinksById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/short-links/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfShortLinksDeleteResponse.class);
        }
        public NtfShortLinksDetailResponse getV1ShortLinksById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/short-links/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfShortLinksDetailResponse.class);
        }
        public NtfShortLinksDetailResponse patchV1ShortLinksById(String id, NtfShortLinksPatchRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/short-links/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfShortLinksDetailResponse.class);
        }
        public NtfShortLinksAnalyticsResponse getV1ShortLinksAnalytics(String id, String granularity, String start, String endParam, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (granularity != null) { query.put("granularity", String.valueOf(granularity)); }
            if (start != null) { query.put("start", String.valueOf(start)); }
            if (endParam != null) { query.put("end", String.valueOf(endParam)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/short-links/{id}/analytics", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfShortLinksAnalyticsResponse.class);
        }
        public NtfShortLinksClicksListResponse getV1ShortLinksClicks(String id, String page, String limit, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/short-links/{id}/clicks", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfShortLinksClicksListResponse.class);
        }
    }

    public final SmsApi sms = new SmsApi(this);
    public static final class SmsApi {
        private final TypedGeneratedApi root;
        public final SmsMessagesApi messages;
        SmsApi(TypedGeneratedApi root) {
            this.root = root;
            this.messages = new SmsMessagesApi(root);
        }
        public static final class SmsMessagesApi {
            private final TypedGeneratedApi root;
            SmsMessagesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfSmsCancelSmsResponse postV1SmsCancel(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/sms/messages/{id}/cancel", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfSmsCancelSmsResponse.class);
            }
        }

        public NtfSmsGetV1SmsInboundResponse getV1SmsInbound(String page, String limit, String q, String provider, String linked, String dateFrom, String dateTo, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (q != null) { query.put("q", String.valueOf(q)); }
            if (provider != null) { query.put("provider", String.valueOf(provider)); }
            if (linked != null) { query.put("linked", String.valueOf(linked)); }
            if (dateFrom != null) { query.put("dateFrom", String.valueOf(dateFrom)); }
            if (dateTo != null) { query.put("dateTo", String.valueOf(dateTo)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/sms/inbound", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfSmsGetV1SmsInboundResponse.class);
        }
        public NtfSmsGetV1SmsInboundByIdResponse getV1SmsInboundById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/sms/inbound/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfSmsGetV1SmsInboundByIdResponse.class);
        }
        public NtfSmsGetV1SmsMessagesResponse getV1SmsMessages(String page, String limit, String fromDate, String toDate, String status, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (fromDate != null) { query.put("fromDate", String.valueOf(fromDate)); }
            if (toDate != null) { query.put("toDate", String.valueOf(toDate)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/sms/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfSmsGetV1SmsMessagesResponse.class);
        }
        public NtfSmsSendSmsResponse postV1SmsSend(NtfSmsSendSmsRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/sms/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfSmsSendSmsResponse.class);
        }
        public NtfSmsSmsStatusResponse getV1SmsById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/sms/messages/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfSmsSmsStatusResponse.class);
        }
    }

    public final SuppressionsApi suppressions = new SuppressionsApi(this);
    public static final class SuppressionsApi {
        private final TypedGeneratedApi root;
        public final SuppressionsBatchApi batch;
        SuppressionsApi(TypedGeneratedApi root) {
            this.root = root;
            this.batch = new SuppressionsBatchApi(root);
        }
        public static final class SuppressionsBatchApi {
            private final TypedGeneratedApi root;
            SuppressionsBatchApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfSuppBatchAddResponse batchAddSuppressions(NtfSuppBatchAddRequest body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/suppressions/batch/add", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfSuppBatchAddResponse.class);
            }
            public NtfSuppBatchRemoveResponse batchRemoveSuppressions(NtfSuppBatchRemoveRequest body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/suppressions/batch/remove", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfSuppBatchRemoveResponse.class);
            }
        }

        public NtfSuppListResponse listSuppressions(NtfSuppSuppressionType typeParam, NtfSuppSuppressionReason reason, NtfSuppSuppressionOrigin origin, String channel, String search, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (typeParam != null) { query.put("type", String.valueOf(typeParam)); }
            if (reason != null) { query.put("reason", String.valueOf(reason)); }
            if (origin != null) { query.put("origin", String.valueOf(origin)); }
            if (channel != null) { query.put("channel", String.valueOf(channel)); }
            if (search != null) { query.put("search", String.valueOf(search)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/suppressions", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfSuppListResponse.class);
        }
        public NtfSuppSingleResponse createSuppression(NtfSuppSuppressionInput body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/suppressions", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfSuppSingleResponse.class);
        }
        public NtfSuppRemoveResponse removeSuppression(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/suppressions/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfSuppRemoveResponse.class);
        }
        public NtfSuppSingleResponse getSuppression(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/suppressions/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfSuppSingleResponse.class);
        }
        public NtfSuppRemoveResponse removeSuppressionByIdentity(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/suppressions/by-identity", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfSuppRemoveResponse.class);
        }
    }

    public final TagsApi tags = new TagsApi(this);
    public static final class TagsApi {
        private final TypedGeneratedApi root;
        TagsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfContactGetV1TagsResponse getV1Tags(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/tags", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactGetV1TagsResponse.class);
        }
        public NtfContactPostV1TagsResponse postV1Tags(NtfContactTagCreate body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/tags", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactPostV1TagsResponse.class);
        }
        public NtfContactDeleteV1TagResponse deleteV1Tag(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/tags/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfContactDeleteV1TagResponse.class);
        }
        public NtfContactGetV1TagResponse getV1Tag(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/tags/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfContactGetV1TagResponse.class);
        }
        public NtfContactPutV1TagResponse putV1Tag(String id, NtfContactTagUpdate body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PUT", "/v1/tags/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfContactPutV1TagResponse.class);
        }
    }

    public final TelegramApi telegram = new TelegramApi(this);
    public static final class TelegramApi {
        private final TypedGeneratedApi root;
        public final TelegramInstancesApi instances;
        public final TelegramMessagesApi messages;
        TelegramApi(TypedGeneratedApi root) {
            this.root = root;
            this.instances = new TelegramInstancesApi(root);
            this.messages = new TelegramMessagesApi(root);
        }
        public static final class TelegramInstancesApi {
            private final TypedGeneratedApi root;
            TelegramInstancesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfTgConnectPageStatusResponse ntfTelegramGetConnectPage(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/telegram/instances/{instanceId}/connect-page", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfTgConnectPageStatusResponse.class);
            }
            public NtfTgConnectPageDisableResponse ntfTelegramDisableConnectPage(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/telegram/instances/{instanceId}/connect-page/disable", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfTgConnectPageDisableResponse.class);
            }
            public NtfTgConnectPageEnableResponse ntfTelegramEnableConnectPage(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/telegram/instances/{instanceId}/connect-page/enable", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfTgConnectPageEnableResponse.class);
            }
            public NtfTgConnectPageEnableResponse ntfTelegramRotateConnectPage(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/telegram/instances/{instanceId}/connect-page/rotate-secret", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfTgConnectPageEnableResponse.class);
            }
            public NtfTgQrEnvelope getV1TelegramInstanceQr(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/telegram/instances/{instanceId}/qr", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfTgQrEnvelope.class);
            }
            public NtfTgQrCancelSuccess postV1TelegramInstanceQrCancel(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/telegram/instances/{instanceId}/qr/cancel", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfTgQrCancelSuccess.class);
            }
            public NtfTgSessionSaveResponse postV1TelegramInstanceSession(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/telegram/instances/{instanceId}/session", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfTgSessionSaveResponse.class);
            }
        }

        public static final class TelegramMessagesApi {
            private final TypedGeneratedApi root;
            TelegramMessagesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfTgMessageIdStatusResponse postV1TelegramMessageCancel(String messageId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/telegram/messages/{messageId}/cancel", Map.of("messageId", messageId), options);
                return root.objectMapper.treeToValue(node, NtfTgMessageIdStatusResponse.class);
            }
            public NtfTgMessageIdStatusResponse patchV1TelegramMessageEdit(String messageId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("PATCH", "/v1/telegram/messages/{messageId}/edit", Map.of("messageId", messageId), options);
                return root.objectMapper.treeToValue(node, NtfTgMessageIdStatusResponse.class);
            }
            public NtfTgInboundListEnvelope getV1TelegramInbound(String page, String limit, String q, String instanceId, String dateFrom, String dateTo, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (page != null) { query.put("page", String.valueOf(page)); }
                if (limit != null) { query.put("limit", String.valueOf(limit)); }
                if (q != null) { query.put("q", String.valueOf(q)); }
                if (instanceId != null) { query.put("instanceId", String.valueOf(instanceId)); }
                if (dateFrom != null) { query.put("dateFrom", String.valueOf(dateFrom)); }
                if (dateTo != null) { query.put("dateTo", String.valueOf(dateTo)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/telegram/messages/inbound", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfTgInboundListEnvelope.class);
            }
            public NtfTgInboundDetailEnvelope getV1TelegramInboundById(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/telegram/messages/inbound/{id}", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfTgInboundDetailEnvelope.class);
            }
            public NtfTgPostV1TelegramInboundMediaResponse postV1TelegramInboundMedia(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/telegram/messages/inbound/{id}/media", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfTgPostV1TelegramInboundMediaResponse.class);
            }
            public String getV1TelegramInboundMediaDownload(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                return root.transport.requestRaw("GET", "/v1/telegram/messages/inbound/{id}/media/download", Map.of("id", id), options);
            }
        }

        public NtfTgChatSubscriptionListEnvelope getV1TelegramChats(String page, String limit, String q, String instanceId, String status, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (q != null) { query.put("q", String.valueOf(q)); }
            if (instanceId != null) { query.put("instanceId", String.valueOf(instanceId)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/telegram/chats", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfTgChatSubscriptionListEnvelope.class);
        }
        public NtfTgTelegramInstanceListEnvelope getV1TelegramInstances(String page, String limit, String status, String search, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (search != null) { query.put("search", String.valueOf(search)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/telegram/instances", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfTgTelegramInstanceListEnvelope.class);
        }
        public NtfTgCreateTelegramInstanceResponse postV1TelegramInstances(NtfTgCreateTelegramInstanceRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/telegram/instances", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfTgCreateTelegramInstanceResponse.class);
        }
        public NtfTgInstanceDeletedResponse deleteV1TelegramInstance(String instanceId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/telegram/instances/{instanceId}", Map.of("instanceId", instanceId), options);
            return root.objectMapper.treeToValue(node, NtfTgInstanceDeletedResponse.class);
        }
        public NtfTgInstanceDetailEnvelope getV1TelegramInstance(String instanceId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/telegram/instances/{instanceId}", Map.of("instanceId", instanceId), options);
            return root.objectMapper.treeToValue(node, NtfTgInstanceDetailEnvelope.class);
        }
        public NtfTgMessageListEnvelope getV1TelegramMessages(String page, String limit, String fromDate, String toDate, String instanceIds, String status, String typeParam, String includeEvents, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (fromDate != null) { query.put("fromDate", String.valueOf(fromDate)); }
            if (toDate != null) { query.put("toDate", String.valueOf(toDate)); }
            if (instanceIds != null) { query.put("instanceIds", String.valueOf(instanceIds)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (typeParam != null) { query.put("type", String.valueOf(typeParam)); }
            if (includeEvents != null) { query.put("includeEvents", String.valueOf(includeEvents)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/telegram/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfTgMessageListEnvelope.class);
        }
        public NtfTgSendTelegramMessageAccepted postV1TelegramSend(NtfTgSendTelegramMessageRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/telegram/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfTgSendTelegramMessageAccepted.class);
        }
        public NtfTgMessageIdStatusResponse deleteV1TelegramMessage(String messageId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/telegram/messages/{messageId}", Map.of("messageId", messageId), options);
            return root.objectMapper.treeToValue(node, NtfTgMessageIdStatusResponse.class);
        }
        public NtfTgMessageDetailEnvelope getV1TelegramMessageById(String messageId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/telegram/messages/{messageId}", Map.of("messageId", messageId), options);
            return root.objectMapper.treeToValue(node, NtfTgMessageDetailEnvelope.class);
        }
    }

    public final TemplatesApi templates = new TemplatesApi(this);
    public static final class TemplatesApi {
        private final TypedGeneratedApi root;
        TemplatesApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public TemplateListResponse listTemplates(Integer page, Integer limit, String search, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (search != null) { query.put("search", String.valueOf(search)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/templates", Map.of(), options);
            return root.objectMapper.treeToValue(node, TemplateListResponse.class);
        }
        public TemplateResponse createTemplates(TemplateCreateRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/templates", Map.of(), options);
            return root.objectMapper.treeToValue(node, TemplateResponse.class);
        }
        public TemplateDeleteResponse deleteTemplates(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/templates/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, TemplateDeleteResponse.class);
        }
        public TemplateResponse getTemplates(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/templates/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, TemplateResponse.class);
        }
        public TemplateResponse updateTemplates(String id, TemplatePatchRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/templates/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, TemplateResponse.class);
        }
        public TemplateSendResponse createSend(TemplateSendRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/templates/send", Map.of(), options);
            return root.objectMapper.treeToValue(node, TemplateSendResponse.class);
        }
    }

    public final TopicsApi topics = new TopicsApi(this);
    public static final class TopicsApi {
        private final TypedGeneratedApi root;
        TopicsApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public NtfContactTopicListResponse getV1Topics(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/topics", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactTopicListResponse.class);
        }
        public NtfContactTopicOneResponse postV1Topics(NtfContactTopicCreate body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/topics", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfContactTopicOneResponse.class);
        }
        public NtfContactDeleteV1TopicResponse deleteV1Topic(String topicId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/topics/{topicId}", Map.of("topicId", topicId), options);
            return root.objectMapper.treeToValue(node, NtfContactDeleteV1TopicResponse.class);
        }
        public NtfContactTopicOneResponse getV1TopicById(String topicId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/topics/{topicId}", Map.of("topicId", topicId), options);
            return root.objectMapper.treeToValue(node, NtfContactTopicOneResponse.class);
        }
        public NtfContactTopicOneResponse patchV1Topic(String topicId, NtfContactTopicPatch body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PATCH", "/v1/topics/{topicId}", Map.of("topicId", topicId), options);
            return root.objectMapper.treeToValue(node, NtfContactTopicOneResponse.class);
        }
    }

    public final VoiceApi voice = new VoiceApi(this);
    public static final class VoiceApi {
        private final TypedGeneratedApi root;
        public final VoiceCallsApi calls;
        VoiceApi(TypedGeneratedApi root) {
            this.root = root;
            this.calls = new VoiceCallsApi(root);
        }
        public static final class VoiceCallsApi {
            private final TypedGeneratedApi root;
            VoiceCallsApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfVoicePostV1VoiceCallsActionResponse postV1VoiceCallsAction(NtfVoiceActionBody body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/voice/calls/{id}/actions/{action}", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfVoicePostV1VoiceCallsActionResponse.class);
            }
            public String getV1VoiceRecordingDownload(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                return root.transport.requestRaw("GET", "/v1/voice/calls/{id}/recordings/{recordingId}/download", Map.of(), options);
            }
        }

        public NtfVoiceListEnvelope getV1VoiceCalls(String page, String limit, String direction, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (direction != null) { query.put("direction", String.valueOf(direction)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/voice/calls", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfVoiceListEnvelope.class);
        }
        public NtfVoiceSendSuccessEnvelope postV1VoiceCalls(NtfVoiceCreateBody body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/voice/calls", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfVoiceSendSuccessEnvelope.class);
        }
        public NtfVoiceDetailEnvelope getV1VoiceCallsById(String id, String includeEvents, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (includeEvents != null) { query.put("includeEvents", String.valueOf(includeEvents)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/voice/calls/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfVoiceDetailEnvelope.class);
        }
    }

    public final WebhooksApi webhooks = new WebhooksApi(this);
    public static final class WebhooksApi {
        private final TypedGeneratedApi root;
        public final WebhooksDeliveriesApi deliveries;
        WebhooksApi(TypedGeneratedApi root) {
            this.root = root;
            this.deliveries = new WebhooksDeliveriesApi(root);
        }
        public static final class WebhooksDeliveriesApi {
            private final TypedGeneratedApi root;
            WebhooksDeliveriesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfWhResendDeliveryResponse resendDelivery(String deliveryId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/webhooks/deliveries/{deliveryId}/resend", Map.of("deliveryId", deliveryId), options);
                return root.objectMapper.treeToValue(node, NtfWhResendDeliveryResponse.class);
            }
        }

        public NtfWhListWebhooksResponse listWebhooks(Integer page, Integer limit, String eventParam, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (eventParam != null) { query.put("event", String.valueOf(eventParam)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/webhooks", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWhListWebhooksResponse.class);
        }
        public NtfWhCreateWebhookResponse createWebhook(NtfWhWebhookInput body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/webhooks", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWhCreateWebhookResponse.class);
        }
        public NtfWhDeleteWebhookResponse deleteWebhook(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/webhooks/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfWhDeleteWebhookResponse.class);
        }
        public NtfWhGetWebhookResponse getWebhook(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/webhooks/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfWhGetWebhookResponse.class);
        }
        public NtfWhUpdateWebhookResponse updateWebhook(String id, NtfWhWebhookInput body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PUT", "/v1/webhooks/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfWhUpdateWebhookResponse.class);
        }
        public NtfWhRotateWebhookSecretResponse rotateWebhookSecret(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/webhooks/{id}/rotate-secret", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfWhRotateWebhookSecretResponse.class);
        }
        public NtfWhListDeliveriesResponse listDeliveries(Integer page, Integer limit, Boolean success, String eventParam, String webhook_id, String messageId, String search, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (success != null) { query.put("success", String.valueOf(success)); }
            if (eventParam != null) { query.put("event", String.valueOf(eventParam)); }
            if (webhook_id != null) { query.put("webhook_id", String.valueOf(webhook_id)); }
            if (messageId != null) { query.put("messageId", String.valueOf(messageId)); }
            if (search != null) { query.put("search", String.valueOf(search)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/webhooks/deliveries", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWhListDeliveriesResponse.class);
        }
        public NtfWhGetDeliveryResponse getDelivery(String deliveryId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/webhooks/deliveries/{deliveryId}", Map.of("deliveryId", deliveryId), options);
            return root.objectMapper.treeToValue(node, NtfWhGetDeliveryResponse.class);
        }
    }

    public final WhatsappApi whatsapp = new WhatsappApi(this);
    public static final class WhatsappApi {
        private final TypedGeneratedApi root;
        public final WhatsappInstancesApi instances;
        public final WhatsappMessagesApi messages;
        WhatsappApi(TypedGeneratedApi root) {
            this.root = root;
            this.instances = new WhatsappInstancesApi(root);
            this.messages = new WhatsappMessagesApi(root);
        }
        public static final class WhatsappInstancesApi {
            private final TypedGeneratedApi root;
            WhatsappInstancesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfWaCallPermGetResponse callPermGet(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances/{instanceId}/calling/permissions", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaCallPermGetResponse.class);
            }
            public NtfWaCallPermRequestResponse callPermRequest(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/instances/{instanceId}/calling/permissions/request", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaCallPermRequestResponse.class);
            }
            public NtfWaCallSettingsGetResponse callSettingsGet(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances/{instanceId}/calling/settings", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaCallSettingsGetResponse.class);
            }
            public NtfWaCallSettingsPatchResponse callSettingsPatch(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("PATCH", "/v1/whatsapp/instances/{instanceId}/calling/settings", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaCallSettingsPatchResponse.class);
            }
            public NtfWaConnectPageStatusResponse getV1WhatsappInstanceConnectPage(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances/{instanceId}/connect-page", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaConnectPageStatusResponse.class);
            }
            public NtfWaConnectPageDisableResponse postV1WhatsappInstanceConnectPageDisable(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/instances/{instanceId}/connect-page/disable", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaConnectPageDisableResponse.class);
            }
            public NtfWaConnectPageEnableResponse postV1WhatsappInstanceConnectPageEnable(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/instances/{instanceId}/connect-page/enable", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaConnectPageEnableResponse.class);
            }
            public NtfWaConnectPageEnableResponse postV1WhatsappInstanceConnectPageRotate(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/instances/{instanceId}/connect-page/rotate-secret", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaConnectPageEnableResponse.class);
            }
            public NtfWaInstanceActionResponse postV1WhatsappInstanceDisconnect(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/instances/{instanceId}/disconnect", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaInstanceActionResponse.class);
            }
            public NtfWaGetV1WhatsappInstancesInstanceIdGroupsResponse getV1WhatsappInstancesInstanceIdGroups(String instanceId, Integer page, Integer limit, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (page != null) { query.put("page", String.valueOf(page)); }
                if (limit != null) { query.put("limit", String.valueOf(limit)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances/{instanceId}/groups", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaGetV1WhatsappInstancesInstanceIdGroupsResponse.class);
            }
            public NtfWaGetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsResponse getV1WhatsappInstancesInstanceIdGroupsGroupIdParticipants(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances/{instanceId}/groups/{groupId}/participants", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfWaGetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsResponse.class);
            }
            public NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteResponse postV1WhatsappInstancesInstanceIdGroupsInvite(String instanceId, NtfWaGroupInviteSendRequest body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/instances/{instanceId}/groups/invite", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteResponse.class);
            }
            public NtfWaGetV1WhatsappInstancesInstanceIdGroupsInviteCodeResponse getV1WhatsappInstancesInstanceIdGroupsInviteCode(String instanceId, String groupJid, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (groupJid != null) { query.put("groupJid", String.valueOf(groupJid)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances/{instanceId}/groups/invite-code", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaGetV1WhatsappInstancesInstanceIdGroupsInviteCodeResponse.class);
            }
            public NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteRevokeResponse postV1WhatsappInstancesInstanceIdGroupsInviteRevoke(String instanceId, NtfWaGroupInviteRevokeRequest body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/instances/{instanceId}/groups/invite/revoke", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteRevokeResponse.class);
            }
            public NtfWaPostV1WhatsappInstancesInstanceIdGroupsParticipantsResponse postV1WhatsappInstancesInstanceIdGroupsParticipants(String instanceId, NtfWaGroupParticipantsRequest body, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = body;
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/instances/{instanceId}/groups/participants", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaPostV1WhatsappInstancesInstanceIdGroupsParticipantsResponse.class);
            }
            public NtfWaGetV1WhatsappInstancePairingCodeResponse getV1WhatsappInstancePairingCode(String instanceId, String phoneNumber, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (phoneNumber != null) { query.put("phoneNumber", String.valueOf(phoneNumber)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances/{instanceId}/pairing-code", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaGetV1WhatsappInstancePairingCodeResponse.class);
            }
            public NtfWaGetV1WhatsappInstanceQrResponse getV1WhatsappInstanceQr(String instanceId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances/{instanceId}/qr", Map.of("instanceId", instanceId), options);
                return root.objectMapper.treeToValue(node, NtfWaGetV1WhatsappInstanceQrResponse.class);
            }
        }

        public static final class WhatsappMessagesApi {
            private final TypedGeneratedApi root;
            WhatsappMessagesApi(TypedGeneratedApi root) {
                this.root = root;
            }
            public NtfWaPostV1WhatsappMessageCancelResponse postV1WhatsappMessageCancel(String messageId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/messages/{messageId}/cancel", Map.of("messageId", messageId), options);
                return root.objectMapper.treeToValue(node, NtfWaPostV1WhatsappMessageCancelResponse.class);
            }
            public NtfWaMessageActionResponse patchV1WhatsappMessageEdit(String messageId, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("PATCH", "/v1/whatsapp/messages/{messageId}/edit", Map.of("messageId", messageId), options);
                return root.objectMapper.treeToValue(node, NtfWaMessageActionResponse.class);
            }
            public NtfWaGetV1WhatsappMessagesInboundResponse getV1WhatsappMessagesInbound(String page, String limit, String q, String instanceId, String dateFrom, String dateTo, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                if (page != null) { query.put("page", String.valueOf(page)); }
                if (limit != null) { query.put("limit", String.valueOf(limit)); }
                if (q != null) { query.put("q", String.valueOf(q)); }
                if (instanceId != null) { query.put("instanceId", String.valueOf(instanceId)); }
                if (dateFrom != null) { query.put("dateFrom", String.valueOf(dateFrom)); }
                if (dateTo != null) { query.put("dateTo", String.valueOf(dateTo)); }
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/messages/inbound", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfWaGetV1WhatsappMessagesInboundResponse.class);
            }
            public NtfWaGetV1WhatsappMessageInboundByIdResponse getV1WhatsappMessageInboundById(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("GET", "/v1/whatsapp/messages/inbound/{id}", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfWaGetV1WhatsappMessageInboundByIdResponse.class);
            }
            public NtfWaPostV1WhatsappMessageInboundMediaResponse postV1WhatsappMessageInboundMedia(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/messages/inbound/{id}/media", Map.of("id", id), options);
                return root.objectMapper.treeToValue(node, NtfWaPostV1WhatsappMessageInboundMediaResponse.class);
            }
            public String getV1WhatsappMessageInboundMediaDownload(String id, ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                return root.transport.requestRaw("GET", "/v1/whatsapp/messages/inbound/{id}/media/download", Map.of("id", id), options);
            }
            public NtfWaPostV1WhatsappMessagePresenceResponse postV1WhatsappMessagePresence(ApiRequestOptions options) throws java.io.IOException {
                options = options != null ? options : ApiRequestOptions.empty();
                java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
                Object reqBody = options.getBody();
                options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
                JsonNode node = root.transport.request("POST", "/v1/whatsapp/messages/presence", Map.of(), options);
                return root.objectMapper.treeToValue(node, NtfWaPostV1WhatsappMessagePresenceResponse.class);
            }
        }

        public NtfWaWhatsAppCallListEnvelope getV1WhatsappCalls(String page, String limit, String instanceId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (instanceId != null) { query.put("instanceId", String.valueOf(instanceId)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/whatsapp/calls", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWaWhatsAppCallListEnvelope.class);
        }
        public NtfWaWhatsAppCallCreateEnvelope postV1WhatsappCalls(NtfWaCreateWhatsAppCallRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/whatsapp/calls", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWaWhatsAppCallCreateEnvelope.class);
        }
        public NtfWaWhatsAppCallDetailEnvelope getV1WhatsappCallById(String id, String includeEvents, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (includeEvents != null) { query.put("includeEvents", String.valueOf(includeEvents)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/whatsapp/calls/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, NtfWaWhatsAppCallDetailEnvelope.class);
        }
        public NtfWaInstanceListResponse getV1WhatsappInstances(String page, String limit, String status, String search, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (search != null) { query.put("search", String.valueOf(search)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWaInstanceListResponse.class);
        }
        public NtfWaCreateInstanceResponse postV1WhatsappInstances(ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/whatsapp/instances", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWaCreateInstanceResponse.class);
        }
        public NtfWaInstanceActionResponse deleteV1WhatsappInstance(String instanceId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/whatsapp/instances/{instanceId}", Map.of("instanceId", instanceId), options);
            return root.objectMapper.treeToValue(node, NtfWaInstanceActionResponse.class);
        }
        public NtfWaInstanceResponse getV1WhatsappInstance(String instanceId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/whatsapp/instances/{instanceId}", Map.of("instanceId", instanceId), options);
            return root.objectMapper.treeToValue(node, NtfWaInstanceResponse.class);
        }
        public NtfWaGetV1WhatsappMessagesResponse getV1WhatsappMessages(String page, String limit, String fromDate, String toDate, String instanceIds, String status, String typeParam, String includeEvents, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (page != null) { query.put("page", String.valueOf(page)); }
            if (limit != null) { query.put("limit", String.valueOf(limit)); }
            if (fromDate != null) { query.put("fromDate", String.valueOf(fromDate)); }
            if (toDate != null) { query.put("toDate", String.valueOf(toDate)); }
            if (instanceIds != null) { query.put("instanceIds", String.valueOf(instanceIds)); }
            if (status != null) { query.put("status", String.valueOf(status)); }
            if (typeParam != null) { query.put("type", String.valueOf(typeParam)); }
            if (includeEvents != null) { query.put("includeEvents", String.valueOf(includeEvents)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/whatsapp/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWaGetV1WhatsappMessagesResponse.class);
        }
        public NtfWaPostV1WhatsappSendResponse postV1WhatsappSend(NtfWaSendWhatsAppMessageRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/whatsapp/messages", Map.of(), options);
            return root.objectMapper.treeToValue(node, NtfWaPostV1WhatsappSendResponse.class);
        }
        public NtfWaMessageActionResponse deleteV1WhatsappMessage(String messageId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/whatsapp/messages/{messageId}", Map.of("messageId", messageId), options);
            return root.objectMapper.treeToValue(node, NtfWaMessageActionResponse.class);
        }
        public NtfWaGetV1WhatsappMessageResponse getV1WhatsappMessage(String messageId, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/whatsapp/messages/{messageId}", Map.of("messageId", messageId), options);
            return root.objectMapper.treeToValue(node, NtfWaGetV1WhatsappMessageResponse.class);
        }
    }

    public final WorkspacesApi workspaces = new WorkspacesApi(this);
    public static final class WorkspacesApi {
        private final TypedGeneratedApi root;
        WorkspacesApi(TypedGeneratedApi root) {
            this.root = root;
        }
        public GetV1WorkspacesResponse getV1Workspaces(String include, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            if (include != null) { query.put("include", String.valueOf(include)); }
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/workspaces", Map.of(), options);
            return root.objectMapper.treeToValue(node, GetV1WorkspacesResponse.class);
        }
        public WorkspaceSingleResponse postV1Workspaces(WorkspaceCreateRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("POST", "/v1/workspaces", Map.of(), options);
            return root.objectMapper.treeToValue(node, WorkspaceSingleResponse.class);
        }
        public DeleteV1WorkspacesByIdResponse deleteV1WorkspacesById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("DELETE", "/v1/workspaces/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, DeleteV1WorkspacesByIdResponse.class);
        }
        public WorkspaceGetResponse getV1WorkspacesById(String id, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = options.getBody();
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("GET", "/v1/workspaces/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, WorkspaceGetResponse.class);
        }
        public WorkspaceUpdateResponse putV1WorkspacesById(String id, WorkspaceUpdateRequest body, ApiRequestOptions options) throws java.io.IOException {
            options = options != null ? options : ApiRequestOptions.empty();
            java.util.Map<String, String> query = new java.util.HashMap<>(options.getQuery());
            Object reqBody = body;
            options = ApiRequestOptions.builder().query(query).body(reqBody).idempotencyKey(options.getIdempotencyKey()).build();
            JsonNode node = root.transport.request("PUT", "/v1/workspaces/{id}", Map.of("id", id), options);
            return root.objectMapper.treeToValue(node, WorkspaceUpdateResponse.class);
        }
    }

}