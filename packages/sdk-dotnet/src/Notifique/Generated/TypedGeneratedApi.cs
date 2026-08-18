using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Notifique.OpenApi.Models.Model;

namespace Notifique.Generated;

public sealed class TypedGeneratedApi
{
    internal readonly GeneratedApiTransport _transport;

    public TypedGeneratedApi(string? apiKey, string baseUrl, System.Net.Http.HttpClient httpClient)
    {
        _transport = new GeneratedApiTransport(apiKey, GeneratedApiTransport.NormalizeApiBaseUrl(baseUrl), httpClient);
        wellKnown = new WellKnownApi(this);
        oauth = new OauthApi(this);
        publicNs = new PublicApi(this);
        aiWebWidget = new AiWebWidgetApi(this);
        assistants = new AssistantsApi(this);
        automations = new AutomationsApi(this);
        campaigns = new CampaignsApi(this);
        contacts = new ContactsApi(this);
        conversions = new ConversionsApi(this);
        email = new EmailApi(this);
        events = new EventsApi(this);
        forms = new FormsApi(this);
        httpTools = new HttpToolsApi(this);
        instagram = new InstagramApi(this);
        knowledgeBases = new KnowledgeBasesApi(this);
        logs = new LogsApi(this);
        mcpConnections = new McpConnectionsApi(this);
        meta = new MetaApi(this);
        metrics = new MetricsApi(this);
        notify = new NotifyApi(this);
        phoneNumbers = new PhoneNumbersApi(this);
        pipelines = new PipelinesApi(this);
        platform = new PlatformApi(this);
        pricing = new PricingApi(this);
        push = new PushApi(this);
        rcs = new RcsApi(this);
        report = new ReportApi(this);
        segments = new SegmentsApi(this);
        sendingPools = new SendingPoolsApi(this);
        shortLinks = new ShortLinksApi(this);
        sms = new SmsApi(this);
        suppressions = new SuppressionsApi(this);
        tags = new TagsApi(this);
        telegram = new TelegramApi(this);
        templates = new TemplatesApi(this);
        topics = new TopicsApi(this);
        voice = new VoiceApi(this);
        webhooks = new WebhooksApi(this);
        whatsapp = new WhatsappApi(this);
        workspaces = new WorkspacesApi(this);
    }
    public WellKnownApi wellKnown { get; }
    public OauthApi oauth { get; }
    public PublicApi publicNs { get; }
    public AiWebWidgetApi aiWebWidget { get; }
    public AssistantsApi assistants { get; }
    public AutomationsApi automations { get; }
    public CampaignsApi campaigns { get; }
    public ContactsApi contacts { get; }
    public ConversionsApi conversions { get; }
    public EmailApi email { get; }
    public EventsApi events { get; }
    public FormsApi forms { get; }
    public HttpToolsApi httpTools { get; }
    public InstagramApi instagram { get; }
    public KnowledgeBasesApi knowledgeBases { get; }
    public LogsApi logs { get; }
    public McpConnectionsApi mcpConnections { get; }
    public MetaApi meta { get; }
    public MetricsApi metrics { get; }
    public NotifyApi notify { get; }
    public PhoneNumbersApi phoneNumbers { get; }
    public PipelinesApi pipelines { get; }
    public PlatformApi platform { get; }
    public PricingApi pricing { get; }
    public PushApi push { get; }
    public RcsApi rcs { get; }
    public ReportApi report { get; }
    public SegmentsApi segments { get; }
    public SendingPoolsApi sendingPools { get; }
    public ShortLinksApi shortLinks { get; }
    public SmsApi sms { get; }
    public SuppressionsApi suppressions { get; }
    public TagsApi tags { get; }
    public TelegramApi telegram { get; }
    public TemplatesApi templates { get; }
    public TopicsApi topics { get; }
    public VoiceApi voice { get; }
    public WebhooksApi webhooks { get; }
    public WhatsappApi whatsapp { get; }
    public WorkspacesApi workspaces { get; }

public sealed class WellKnownApi
{
    private readonly TypedGeneratedApi _root;
    internal WellKnownApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfOauthGetJwksResponse> GetJwksAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/.well-known/jwks.json", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthGetJwksResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthGetAuthorizationServerMetadataResponse> GetAuthorizationServerMetadataAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/.well-known/oauth-authorization-server", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthGetAuthorizationServerMetadataResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthGetProtectedResourceMetadataResponse> GetProtectedResourceMetadataAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/.well-known/oauth-protected-resource", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthGetProtectedResourceMetadataResponse>(json.GetRawText())!;
    }
}

public sealed class OauthApi
{
    private readonly TypedGeneratedApi _root;
    internal OauthApi(TypedGeneratedApi root) => _root = root;
    public OauthAppsApi apps() => new OauthAppsApi(_root);
public sealed class OauthAppsApi
{
    private readonly TypedGeneratedApi _root;
    internal OauthAppsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfOauthRotateWorkspaceAppSecretResponse> RotateWorkspaceAppSecretAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/oauth/apps/{id}/rotate-secret", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthRotateWorkspaceAppSecretResponse>(json.GetRawText())!;
    }
}

    public OauthConnectionsApi connections() => new OauthConnectionsApi(_root);
public sealed class OauthConnectionsApi
{
    private readonly TypedGeneratedApi _root;
    internal OauthConnectionsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfOauthRevokeConnectionResponse> RevokeConnectionAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/oauth/connections/{id}/revoke", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthRevokeConnectionResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfOauthAuthorizeResponse> AuthorizeAsync(string? client_id = null, string? response_type = null, string? redirect_uri = null, string? scope = null, string? state = null, string? code_challenge = null, string? code_challenge_method = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (client_id != null) query["client_id"] = client_id.ToString()!;
        if (response_type != null) query["response_type"] = response_type.ToString()!;
        if (redirect_uri != null) query["redirect_uri"] = redirect_uri.ToString()!;
        if (scope != null) query["scope"] = scope.ToString()!;
        if (state != null) query["state"] = state.ToString()!;
        if (code_challenge != null) query["code_challenge"] = code_challenge.ToString()!;
        if (code_challenge_method != null) query["code_challenge_method"] = code_challenge_method.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/oauth/authorize", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthAuthorizeResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthRegisterClientResponse> RegisterClientAsync(Notifique.OpenApi.Models.Model.NtfOauthClientRegistration? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/oauth/register", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthRegisterClientResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthRevokeResponse> RevokeAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/oauth/revoke", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthRevokeResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthTokenResponse> TokenAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/oauth/token", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthTokenResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthListWorkspaceAppsResponse> ListWorkspaceAppsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/oauth/apps", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthListWorkspaceAppsResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthCreateWorkspaceAppResponse> CreateWorkspaceAppAsync(Notifique.OpenApi.Models.Model.NtfOauthWorkspaceAppCreate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/oauth/apps", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthCreateWorkspaceAppResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthDeleteWorkspaceAppResponse> DeleteWorkspaceAppAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/oauth/apps/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthDeleteWorkspaceAppResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthGetWorkspaceAppResponse> GetWorkspaceAppAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/oauth/apps/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthGetWorkspaceAppResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthUpdateWorkspaceAppResponse> UpdateWorkspaceAppAsync(string id, Notifique.OpenApi.Models.Model.NtfOauthWorkspaceAppPatch? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/oauth/apps/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthUpdateWorkspaceAppResponse>(json.GetRawText())!;
    }
    public async Task<NtfOauthListConnectionsResponse> ListConnectionsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/oauth/connections", pathParams, options);
        return JsonSerializer.Deserialize<NtfOauthListConnectionsResponse>(json.GetRawText())!;
    }
}

public sealed class PublicApi
{
    private readonly TypedGeneratedApi _root;
    internal PublicApi(TypedGeneratedApi root) => _root = root;
    public PublicAiWidgetApi aiWidget() => new PublicAiWidgetApi(_root);
public sealed class PublicAiWidgetApi
{
    private readonly TypedGeneratedApi _root;
    internal PublicAiWidgetApi(TypedGeneratedApi root) => _root = root;
    public async Task<WidgetConfigResponse> GetConfigAsync(string publicKey, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["publicKey"] = publicKey };
        var json = await _root._transport.RequestAsync("GET", "/public/ai-widget/{publicKey}/config", pathParams, options);
        return JsonSerializer.Deserialize<WidgetConfigResponse>(json.GetRawText())!;
    }
    public async Task<MessageResponse> SendMessageAsync(string publicKey, Notifique.OpenApi.Models.Model.SendMessageBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["publicKey"] = publicKey };
        var json = await _root._transport.RequestAsync("POST", "/public/ai-widget/{publicKey}/message", pathParams, options);
        return JsonSerializer.Deserialize<MessageResponse>(json.GetRawText())!;
    }
    public async Task<PollMessagesResponse> PollMessagesAsync(string publicKey, string? sessionToken = null, string? afterParam = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (sessionToken != null) query["sessionToken"] = sessionToken.ToString()!;
        if (afterParam != null) query["after"] = afterParam.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["publicKey"] = publicKey };
        var json = await _root._transport.RequestAsync("GET", "/public/ai-widget/{publicKey}/messages", pathParams, options);
        return JsonSerializer.Deserialize<PollMessagesResponse>(json.GetRawText())!;
    }
    public async Task<SessionResponse> CreateSessionAsync(string publicKey, Notifique.OpenApi.Models.Model.CreateSessionBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["publicKey"] = publicKey };
        var json = await _root._transport.RequestAsync("POST", "/public/ai-widget/{publicKey}/session", pathParams, options);
        return JsonSerializer.Deserialize<SessionResponse>(json.GetRawText())!;
    }
    public async Task<NtfWidgetRequestOtpResponse> RequestOtpAsync(string publicKey, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["publicKey"] = publicKey };
        var json = await _root._transport.RequestAsync("POST", "/public/ai-widget/{publicKey}/session/otp/request", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetRequestOtpResponse>(json.GetRawText())!;
    }
    public async Task<NtfWidgetVerifyOtpResponse> VerifyOtpAsync(string publicKey, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["publicKey"] = publicKey };
        var json = await _root._transport.RequestAsync("POST", "/public/ai-widget/{publicKey}/session/otp/verify", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetVerifyOtpResponse>(json.GetRawText())!;
    }
}

}

public sealed class AiWebWidgetApi
{
    private readonly TypedGeneratedApi _root;
    internal AiWebWidgetApi(TypedGeneratedApi root) => _root = root;
    public AiWebWidgetWidgetsApi widgets() => new AiWebWidgetWidgetsApi(_root);
public sealed class AiWebWidgetWidgetsApi
{
    private readonly TypedGeneratedApi _root;
    internal AiWebWidgetWidgetsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfWidgetAdminDuplicateResponse> DuplicateAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/ai-web-widget/widgets/{id}/duplicate", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetAdminDuplicateResponse>(json.GetRawText())!;
    }
    public async Task<NtfWidgetAdminRotateHmacResponse> RotateHmacAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/ai-web-widget/widgets/{id}/rotate-identity-signing-secret", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetAdminRotateHmacResponse>(json.GetRawText())!;
    }
    public async Task<NtfWidgetAdminRotateKeyResponse> RotateKeyAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/ai-web-widget/widgets/{id}/rotate-key", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetAdminRotateKeyResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfWidgetAdminMessagesResponse> MessagesAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/ai-web-widget/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetAdminMessagesResponse>(json.GetRawText())!;
    }
    public async Task<NtfWidgetAdminListResponse> ListAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/ai-web-widget/widgets", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetAdminListResponse>(json.GetRawText())!;
    }
    public async Task<NtfWidgetAdminCreateResponse> CreateAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/ai-web-widget/widgets", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetAdminCreateResponse>(json.GetRawText())!;
    }
    public async Task<NtfWidgetAdminDeleteResponse> DeleteAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/ai-web-widget/widgets/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetAdminDeleteResponse>(json.GetRawText())!;
    }
    public async Task<NtfWidgetAdminGetResponse> GetAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/ai-web-widget/widgets/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetAdminGetResponse>(json.GetRawText())!;
    }
    public async Task<NtfWidgetAdminPatchResponse> PatchAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/ai-web-widget/widgets/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWidgetAdminPatchResponse>(json.GetRawText())!;
    }
}

public sealed class AssistantsApi
{
    private readonly TypedGeneratedApi _root;
    internal AssistantsApi(TypedGeneratedApi root) => _root = root;
    public AssistantsInvokeApi invoke() => new AssistantsInvokeApi(_root);
public sealed class AssistantsInvokeApi
{
    private readonly TypedGeneratedApi _root;
    internal AssistantsInvokeApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfAutoAssistantsInvokeMessagesResponse> AssistantsInvokeMessagesAsync(string id, string? threadId = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (threadId != null) query["threadId"] = threadId.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/assistants/{id}/invoke/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsInvokeMessagesResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfAutoAssistantsListResponse> AssistantsListAsync(string? page = null, string? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/assistants", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsListResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsCreateResponse> AssistantsCreateAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/assistants", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsCreateResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsDeleteResponse> AssistantsDeleteAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/assistants/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsDeleteResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsGetResponse> AssistantsGetAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/assistants/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsGetResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsUpdateResponse> AssistantsUpdateAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/assistants/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsUpdateResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsListHttpBindingsResponse> AssistantsListHttpBindingsAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/assistants/{id}/http-tool-bindings", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsListHttpBindingsResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsCreateHttpBindingResponse> AssistantsCreateHttpBindingAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/assistants/{id}/http-tool-bindings", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsCreateHttpBindingResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsDeleteHttpBindingResponse> AssistantsDeleteHttpBindingAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("DELETE", "/v1/assistants/{id}/http-tool-bindings/{bindingId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsDeleteHttpBindingResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsInvokeResponse> AssistantsInvokeAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/assistants/{id}/invoke", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsInvokeResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsListMcpBindingsResponse> AssistantsListMcpBindingsAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/assistants/{id}/mcp-bindings", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsListMcpBindingsResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsCreateMcpBindingResponse> AssistantsCreateMcpBindingAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/assistants/{id}/mcp-bindings", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsCreateMcpBindingResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsDeleteMcpBindingResponse> AssistantsDeleteMcpBindingAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("DELETE", "/v1/assistants/{id}/mcp-bindings/{bindingId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsDeleteMcpBindingResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAssistantsUpdateMcpBindingResponse> AssistantsUpdateMcpBindingAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("PATCH", "/v1/assistants/{id}/mcp-bindings/{bindingId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAssistantsUpdateMcpBindingResponse>(json.GetRawText())!;
    }
}

public sealed class AutomationsApi
{
    private readonly TypedGeneratedApi _root;
    internal AutomationsApi(TypedGeneratedApi root) => _root = root;
    public AutomationsBatchApi batch() => new AutomationsBatchApi(_root);
public sealed class AutomationsBatchApi
{
    private readonly TypedGeneratedApi _root;
    internal AutomationsBatchApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfAutoBatchDeleteResponse> BatchDeleteAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/automations/batch/delete", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoBatchDeleteResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfAutoListAutomationsResponse> ListAutomationsAsync(string? page = null, string? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/automations", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoListAutomationsResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoCreateAutomationResponse> CreateAutomationAsync(Notifique.OpenApi.Models.Model.NtfAutoAutomationCreateBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/automations", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoCreateAutomationResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoDeleteAutomationResponse> DeleteAutomationAsync(string automationId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["automationId"] = automationId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/automations/{automationId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoDeleteAutomationResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoGetAutomationResponse> GetAutomationAsync(string automationId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["automationId"] = automationId };
        var json = await _root._transport.RequestAsync("GET", "/v1/automations/{automationId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoGetAutomationResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoPatchAutomationResponse> PatchAutomationAsync(string automationId, Notifique.OpenApi.Models.Model.NtfAutoAutomationPatchBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["automationId"] = automationId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/automations/{automationId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoPatchAutomationResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoDuplicateResponse> DuplicateAsync(string automationId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["automationId"] = automationId };
        var json = await _root._transport.RequestAsync("POST", "/v1/automations/{automationId}/duplicate", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoDuplicateResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoListRunsResponse> ListRunsAsync(string automationId, string? page = null, string? limit = null, string? status = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["automationId"] = automationId };
        var json = await _root._transport.RequestAsync("GET", "/v1/automations/{automationId}/runs", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoListRunsResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoGetRunResponse> GetRunAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/automations/{automationId}/runs/{runId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoGetRunResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoStopAutomationResponse> StopAutomationAsync(string automationId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["automationId"] = automationId };
        var json = await _root._transport.RequestAsync("POST", "/v1/automations/{automationId}/stop", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoStopAutomationResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoTestTriggerResponse> TestTriggerAsync(string automationId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["automationId"] = automationId };
        var json = await _root._transport.RequestAsync("POST", "/v1/automations/{automationId}/test-trigger", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoTestTriggerResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoWebhookSecretResponse> WebhookSecretAsync(string automationId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["automationId"] = automationId };
        var json = await _root._transport.RequestAsync("POST", "/v1/automations/{automationId}/webhook-secret", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoWebhookSecretResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoAiComposeResponse> AiComposeAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/automations/ai-compose", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoAiComposeResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoPostCampaignAgentResponse> PostCampaignAgentAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/automations/post-campaign-agent", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoPostCampaignAgentResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoQuickChatbotResponse> QuickChatbotAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/automations/quick-chatbot", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoQuickChatbotResponse>(json.GetRawText())!;
    }
}

public sealed class CampaignsApi
{
    private readonly TypedGeneratedApi _root;
    internal CampaignsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfContactCampaignListResponse> GetV1CampaignsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/campaigns", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactCampaignListResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactCampaignOneResponse> PostV1CampaignsAsync(Notifique.OpenApi.Models.Model.NtfContactCampaignCreate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/campaigns", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactCampaignOneResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactDeleteV1CampaignResponse> DeleteV1CampaignAsync(string campaignId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["campaignId"] = campaignId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/campaigns/{campaignId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactDeleteV1CampaignResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactCampaignOneResponse> GetV1CampaignByIdAsync(string campaignId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["campaignId"] = campaignId };
        var json = await _root._transport.RequestAsync("GET", "/v1/campaigns/{campaignId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactCampaignOneResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactCampaignOneResponse> PatchV1CampaignAsync(string campaignId, Notifique.OpenApi.Models.Model.NtfContactCampaignPatch? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["campaignId"] = campaignId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/campaigns/{campaignId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactCampaignOneResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactCampaignCancelResponse> PostV1CampaignCancelAsync(string campaignId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["campaignId"] = campaignId };
        var json = await _root._transport.RequestAsync("POST", "/v1/campaigns/{campaignId}/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactCampaignCancelResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactCampaignRecipientsResponse> GetV1CampaignRecipientsAsync(string campaignId, string? channel = null, string? status = null, string? runId = null, int? page = null, int? pageSize = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (channel != null) query["channel"] = channel.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (runId != null) query["runId"] = runId.ToString()!;
        if (page != null) query["page"] = page.ToString()!;
        if (pageSize != null) query["pageSize"] = pageSize.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["campaignId"] = campaignId };
        var json = await _root._transport.RequestAsync("GET", "/v1/campaigns/{campaignId}/recipients", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactCampaignRecipientsResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactCampaignRunResponse> PostV1CampaignRunAsync(string campaignId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["campaignId"] = campaignId };
        var json = await _root._transport.RequestAsync("POST", "/v1/campaigns/{campaignId}/run", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactCampaignRunResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactCampaignRunPreviewResponse> GetV1CampaignRunPreviewAsync(string campaignId, string? channels = null, string? excludeAlreadySent = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (channels != null) query["channels"] = channels.ToString()!;
        if (excludeAlreadySent != null) query["excludeAlreadySent"] = excludeAlreadySent.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["campaignId"] = campaignId };
        var json = await _root._transport.RequestAsync("GET", "/v1/campaigns/{campaignId}/run-preview", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactCampaignRunPreviewResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactCampaignStatsResponse> GetV1CampaignStatsAsync(string campaignId, string? runId = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (runId != null) query["runId"] = runId.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["campaignId"] = campaignId };
        var json = await _root._transport.RequestAsync("GET", "/v1/campaigns/{campaignId}/stats", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactCampaignStatsResponse>(json.GetRawText())!;
    }
}

public sealed class ContactsApi
{
    private readonly TypedGeneratedApi _root;
    internal ContactsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfContactGetV1ContactsResponse> GetV1ContactsAsync(string? page = null, string? limit = null, string? search = null, string? tagId = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        if (tagId != null) query["tagId"] = tagId.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/contacts", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactGetV1ContactsResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactPostV1ContactsResponse> PostV1ContactsAsync(Notifique.OpenApi.Models.Model.NtfContactContactCreate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/contacts", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactPostV1ContactsResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactDeleteV1ContactResponse> DeleteV1ContactAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/contacts/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactDeleteV1ContactResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactGetV1ContactResponse> GetV1ContactAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/contacts/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactGetV1ContactResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactPutV1ContactResponse> PutV1ContactAsync(string id, Notifique.OpenApi.Models.Model.NtfContactContactUpdate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PUT", "/v1/contacts/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactPutV1ContactResponse>(json.GetRawText())!;
    }
}

public sealed class ConversionsApi
{
    private readonly TypedGeneratedApi _root;
    internal ConversionsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfConversionsPostV1ConversionsResponse> PostV1ConversionsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/conversions", pathParams, options);
        return JsonSerializer.Deserialize<NtfConversionsPostV1ConversionsResponse>(json.GetRawText())!;
    }
}

public sealed class EmailApi
{
    private readonly TypedGeneratedApi _root;
    internal EmailApi(TypedGeneratedApi root) => _root = root;
    public EmailDomainsApi domains() => new EmailDomainsApi(_root);
public sealed class EmailDomainsApi
{
    private readonly TypedGeneratedApi _root;
    internal EmailDomainsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfEmailExpandEmailDomainProvidersResponse> PostV1EmailDomainExpandProvidersAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/email/domains/{id}/expand-providers", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailExpandEmailDomainProvidersResponse>(json.GetRawText())!;
    }
    public async Task<NtfEmailVerifyEmailDomainResponse> PostV1EmailDomainVerifyAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/email/domains/{id}/verify", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailVerifyEmailDomainResponse>(json.GetRawText())!;
    }
}

    public EmailMessagesApi messages() => new EmailMessagesApi(_root);
public sealed class EmailMessagesApi
{
    private readonly TypedGeneratedApi _root;
    internal EmailMessagesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfEmailCancelEmailResponse> PostV1EmailCancelAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/email/messages/{id}/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailCancelEmailResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfEmailListEmailDomainsResponse> GetV1EmailDomainsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/email/domains", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailListEmailDomainsResponse>(json.GetRawText())!;
    }
    public async Task<NtfEmailCreateEmailDomainResponse> PostV1EmailDomainsAsync(Notifique.OpenApi.Models.Model.NtfEmailCreateEmailDomainRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/email/domains", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailCreateEmailDomainResponse>(json.GetRawText())!;
    }
    public async Task<NtfEmailEmailDomainResponse> GetV1EmailDomainByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/email/domains/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailEmailDomainResponse>(json.GetRawText())!;
    }
    public async Task<NtfEmailGetV1EmailInboundResponse> GetV1EmailInboundAsync(string? page = null, string? limit = null, string? q = null, string? domainId = null, string? dateFrom = null, string? dateTo = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (q != null) query["q"] = q.ToString()!;
        if (domainId != null) query["domainId"] = domainId.ToString()!;
        if (dateFrom != null) query["dateFrom"] = dateFrom.ToString()!;
        if (dateTo != null) query["dateTo"] = dateTo.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/email/inbound", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailGetV1EmailInboundResponse>(json.GetRawText())!;
    }
    public async Task<NtfEmailGetV1EmailInboundByIdResponse> GetV1EmailInboundByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/email/inbound/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailGetV1EmailInboundByIdResponse>(json.GetRawText())!;
    }
    public async Task<NtfEmailGetV1EmailMessagesResponse> GetV1EmailMessagesAsync(string? page = null, string? limit = null, string? fromDate = null, string? toDate = null, string? status = null, string? emailDomainId = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (fromDate != null) query["fromDate"] = fromDate.ToString()!;
        if (toDate != null) query["toDate"] = toDate.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (emailDomainId != null) query["emailDomainId"] = emailDomainId.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/email/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailGetV1EmailMessagesResponse>(json.GetRawText())!;
    }
    public async Task<NtfEmailSendEmailResponse> PostV1EmailSendAsync(Notifique.OpenApi.Models.Model.NtfEmailSendEmailRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/email/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailSendEmailResponse>(json.GetRawText())!;
    }
    public async Task<NtfEmailEmailStatusResponse> GetV1EmailByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/email/messages/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfEmailEmailStatusResponse>(json.GetRawText())!;
    }
}

public sealed class EventsApi
{
    private readonly TypedGeneratedApi _root;
    internal EventsApi(TypedGeneratedApi root) => _root = root;
    public EventsBatchApi batch() => new EventsBatchApi(_root);
public sealed class EventsBatchApi
{
    private readonly TypedGeneratedApi _root;
    internal EventsBatchApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfAutoBatchDeleteEventsResponse> BatchDeleteEventsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/events/batch/delete", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoBatchDeleteEventsResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfAutoListEventsResponse> ListEventsAsync(string? page = null, string? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/events", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoListEventsResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoCreateEventResponse> CreateEventAsync(Notifique.OpenApi.Models.Model.NtfAutoEventCreateBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/events", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoCreateEventResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoDeleteEventResponse> DeleteEventAsync(string eventId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["eventId"] = eventId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/events/{eventId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoDeleteEventResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoGetEventResponse> GetEventAsync(string eventId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["eventId"] = eventId };
        var json = await _root._transport.RequestAsync("GET", "/v1/events/{eventId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoGetEventResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoPatchEventResponse> PatchEventAsync(string eventId, Notifique.OpenApi.Models.Model.NtfAutoEventPatchBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["eventId"] = eventId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/events/{eventId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoPatchEventResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoSendEventResponse> SendEventAsync(Notifique.OpenApi.Models.Model.NtfAutoEventSendBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/events/send", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoSendEventResponse>(json.GetRawText())!;
    }
}

public sealed class FormsApi
{
    private readonly TypedGeneratedApi _root;
    internal FormsApi(TypedGeneratedApi root) => _root = root;
    public FormsListsApi lists() => new FormsListsApi(_root);
public sealed class FormsListsApi
{
    private readonly TypedGeneratedApi _root;
    internal FormsListsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfAddonsFormSubscriptionCollectionEnvelope> GetV1FormsListSubscriptionsAsync(string id, string? page = null, string? limit = null, string? status = null, string? search = null, string? subscribedFrom = null, string? subscribedTo = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        if (subscribedFrom != null) query["subscribedFrom"] = subscribedFrom.ToString()!;
        if (subscribedTo != null) query["subscribedTo"] = subscribedTo.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/forms/lists/{id}/subscriptions", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsFormSubscriptionCollectionEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfAddonsDeleteV1FormsSubscriptionResponse> DeleteV1FormsSubscriptionAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("DELETE", "/v1/forms/lists/{id}/subscriptions/{subscriptionId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsDeleteV1FormsSubscriptionResponse>(json.GetRawText())!;
    }
    public async Task<string> GetV1FormsSubscriptionExportAsync(string id, string? status = null, string? search = null, string? subscribedFrom = null, string? subscribedTo = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (status != null) query["status"] = status.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        if (subscribedFrom != null) query["subscribedFrom"] = subscribedFrom.ToString()!;
        if (subscribedTo != null) query["subscribedTo"] = subscribedTo.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        return await _root._transport.RequestRawAsync("GET", "/v1/forms/lists/{id}/subscriptions/export", pathParams, options);
    }
    public async Task<NtfAddonsGetV1FormsSubscriptionStatsResponse> GetV1FormsSubscriptionStatsAsync(string id, int? trendDays = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (trendDays != null) query["trendDays"] = trendDays.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/forms/lists/{id}/subscriptions/stats", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsGetV1FormsSubscriptionStatsResponse>(json.GetRawText())!;
    }
}

    public FormsSubscriptionsApi subscriptions() => new FormsSubscriptionsApi(_root);
public sealed class FormsSubscriptionsApi
{
    private readonly TypedGeneratedApi _root;
    internal FormsSubscriptionsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfAddonsNewsletterCancelEnvelope> PostV1FormsSubscriptionCancelAsync(string id, Notifique.OpenApi.Models.Model.NtfAddonsNewsletterCancelRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/forms/subscriptions/{id}/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsNewsletterCancelEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfAddonsFormConfirmEnvelope> PostV1FormsSubscriptionsConfirmAsync(Notifique.OpenApi.Models.Model.NtfAddonsFormConfirmRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/forms/subscriptions/confirm", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsFormConfirmEnvelope>(json.GetRawText())!;
    }
}

    public async Task<NtfAddonsFormListCollectionEnvelope> GetV1FormsListsAsync(string? page = null, string? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/forms/lists", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsFormListCollectionEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfAddonsFormListEnvelope> PostV1FormsListsAsync(Notifique.OpenApi.Models.Model.NtfAddonsCreateFormListRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/forms/lists", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsFormListEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfAddonsFormDeleteEnvelope> DeleteV1FormsListAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/forms/lists/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsFormDeleteEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfAddonsFormListEnvelope> GetV1FormsListAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/forms/lists/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsFormListEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfAddonsFormListPatchEnvelope> PatchV1FormsListAsync(string id, Notifique.OpenApi.Models.Model.NtfAddonsPatchFormListRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/forms/lists/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsFormListPatchEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfAddonsGetV1FormsSubscriptionsAllResponse> GetV1FormsSubscriptionsAllAsync(string? page = null, string? limit = null, string? listId = null, string? status = null, string? search = null, string? subscribedFrom = null, string? subscribedTo = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (listId != null) query["listId"] = listId.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        if (subscribedFrom != null) query["subscribedFrom"] = subscribedFrom.ToString()!;
        if (subscribedTo != null) query["subscribedTo"] = subscribedTo.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/forms/subscriptions", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsGetV1FormsSubscriptionsAllResponse>(json.GetRawText())!;
    }
    public async Task<NtfAddonsFormSubscribeEnvelope> PostV1FormsSubscriptionsAsync(Notifique.OpenApi.Models.Model.NtfAddonsFormSubscribeRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/forms/subscriptions", pathParams, options);
        return JsonSerializer.Deserialize<NtfAddonsFormSubscribeEnvelope>(json.GetRawText())!;
    }
}

public sealed class HttpToolsApi
{
    private readonly TypedGeneratedApi _root;
    internal HttpToolsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfAutoHttpListResponse> HttpListAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/http-tools", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoHttpListResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoHttpCreateResponse> HttpCreateAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/http-tools", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoHttpCreateResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoHttpDeleteResponse> HttpDeleteAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/http-tools/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoHttpDeleteResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoHttpGetResponse> HttpGetAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/http-tools/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoHttpGetResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoHttpUpdateResponse> HttpUpdateAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/http-tools/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoHttpUpdateResponse>(json.GetRawText())!;
    }
}

public sealed class InstagramApi
{
    private readonly TypedGeneratedApi _root;
    internal InstagramApi(TypedGeneratedApi root) => _root = root;
    public InstagramCommentsApi comments() => new InstagramCommentsApi(_root);
public sealed class InstagramCommentsApi
{
    private readonly TypedGeneratedApi _root;
    internal InstagramCommentsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfIgHideCommentResponse> HideCommentAsync(string commentId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["commentId"] = commentId };
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/comments/{commentId}/hide", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgHideCommentResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgReplyCommentResponse> ReplyCommentAsync(string commentId, Notifique.OpenApi.Models.Model.NtfIgReplyCommentBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["commentId"] = commentId };
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/comments/{commentId}/reply", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgReplyCommentResponse>(json.GetRawText())!;
    }
}

    public InstagramInstancesApi instances() => new InstagramInstancesApi(_root);
public sealed class InstagramInstancesApi
{
    private readonly TypedGeneratedApi _root;
    internal InstagramInstancesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfIgResolveChallengeResponse> ResolveChallengeAsync(string instanceId, Notifique.OpenApi.Models.Model.NtfIgResolveChallengeBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/instances/{instanceId}/challenge/resolve", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgResolveChallengeResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgConnectPageStatusResponse> GetConnectPageAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/instances/{instanceId}/connect-page", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgConnectPageStatusResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgConnectPageDisableResponse> DisableConnectPageAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/instances/{instanceId}/connect-page/disable", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgConnectPageDisableResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgConnectPageEnableResponse> EnableConnectPageAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/instances/{instanceId}/connect-page/enable", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgConnectPageEnableResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgConnectPageEnableResponse> RotateConnectPageAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/instances/{instanceId}/connect-page/rotate-secret", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgConnectPageEnableResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgConnectionStatus> GetConnectionAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/instances/{instanceId}/connection", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgConnectionStatus>(json.GetRawText())!;
    }
    public async Task<NtfIgDisconnectInstanceResponse> DisconnectInstanceAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/instances/{instanceId}/disconnect", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgDisconnectInstanceResponse>(json.GetRawText())!;
    }
}

    public InstagramMessagesApi messages() => new InstagramMessagesApi(_root);
public sealed class InstagramMessagesApi
{
    private readonly TypedGeneratedApi _root;
    internal InstagramMessagesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfIgCancelMessageResponse> CancelMessageAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/messages/{messageId}/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgCancelMessageResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgEditMessageResponse> EditMessageAsync(string messageId, Notifique.OpenApi.Models.Model.NtfIgEditMessageBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/instagram/messages/{messageId}/edit", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgEditMessageResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgListInboundResponse> ListInboundAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/messages/inbound", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgListInboundResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgGetInboundResponse> GetInboundAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/messages/inbound/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgGetInboundResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgPostInboundMediaResponse> PostInboundMediaAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/messages/inbound/{id}/media", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgPostInboundMediaResponse>(json.GetRawText())!;
    }
    public async Task<byte[]> GetInboundMediaDownloadAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        return await _root._transport.RequestBytesAsync("GET", "/v1/instagram/messages/inbound/{id}/media/download", pathParams, options);
    }
}

    public async Task<NtfIgListCommentsResponse> ListCommentsAsync(string? instanceId = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (instanceId != null) query["instanceId"] = instanceId.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/comments", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgListCommentsResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgDeleteCommentResponse> DeleteCommentAsync(string commentId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["commentId"] = commentId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/instagram/comments/{commentId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgDeleteCommentResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgGetCommentResponse> GetCommentAsync(string commentId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["commentId"] = commentId };
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/comments/{commentId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgGetCommentResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgListInstancesResponse> ListInstancesAsync(string? page = null, string? limit = null, string? status = null, string? search = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/instances", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgListInstancesResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgCreateInstanceResponse> CreateInstanceAsync(Notifique.OpenApi.Models.Model.NtfIgCreateInstanceBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/instances", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgCreateInstanceResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgDeleteInstanceResponse> DeleteInstanceAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/instagram/instances/{instanceId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgDeleteInstanceResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgInstanceDetail> GetInstanceAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/instances/{instanceId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgInstanceDetail>(json.GetRawText())!;
    }
    public async Task<NtfIgListMessagesResponse> ListMessagesAsync(string? page = null, string? limit = null, string? instanceIds = null, string? status = null, string? typeParam = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (instanceIds != null) query["instanceIds"] = instanceIds.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (typeParam != null) query["type"] = typeParam.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgListMessagesResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgSendMessageResponse> SendMessageAsync(Notifique.OpenApi.Models.Model.NtfIgSendMessageBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/instagram/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgSendMessageResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgDeleteMessageResponse> DeleteMessageAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/instagram/messages/{messageId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgDeleteMessageResponse>(json.GetRawText())!;
    }
    public async Task<NtfIgGetMessageResponse> GetMessageAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("GET", "/v1/instagram/messages/{messageId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfIgGetMessageResponse>(json.GetRawText())!;
    }
}

public sealed class KnowledgeBasesApi
{
    private readonly TypedGeneratedApi _root;
    internal KnowledgeBasesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfAutoKbListResponse> KbListAsync(string? page = null, string? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/knowledge-bases", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbListResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoKbCreateResponse> KbCreateAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/knowledge-bases", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbCreateResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoKbDeleteResponse> KbDeleteAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/knowledge-bases/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbDeleteResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoKbGetResponse> KbGetAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/knowledge-bases/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbGetResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoKbUpdateResponse> KbUpdateAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/knowledge-bases/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbUpdateResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoKbListDocsResponse> KbListDocsAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/knowledge-bases/{id}/documents", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbListDocsResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoKbCreateDocResponse> KbCreateDocAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/knowledge-bases/{id}/documents", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbCreateDocResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoKbDeleteDocResponse> KbDeleteDocAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("DELETE", "/v1/knowledge-bases/{id}/documents/{docId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbDeleteDocResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoKbGetDocResponse> KbGetDocAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/knowledge-bases/{id}/documents/{docId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbGetDocResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoKbUpdateDocResponse> KbUpdateDocAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("PATCH", "/v1/knowledge-bases/{id}/documents/{docId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoKbUpdateDocResponse>(json.GetRawText())!;
    }
}

public sealed class LogsApi
{
    private readonly TypedGeneratedApi _root;
    internal LogsApi(TypedGeneratedApi root) => _root = root;
    public async Task<LogsListResponse> GetV1LogsAsync(int? page = null, int? limit = null, string? status = null, string? startDate = null, string? endDate = null, string? method = null, string? apiKeyId = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (startDate != null) query["startDate"] = startDate.ToString()!;
        if (endDate != null) query["endDate"] = endDate.ToString()!;
        if (method != null) query["method"] = method.ToString()!;
        if (apiKeyId != null) query["apiKeyId"] = apiKeyId.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/logs", pathParams, options);
        return JsonSerializer.Deserialize<LogsListResponse>(json.GetRawText())!;
    }
    public async Task<GetV1LogsByIdResponse> GetV1LogsByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/logs/{id}", pathParams, options);
        return JsonSerializer.Deserialize<GetV1LogsByIdResponse>(json.GetRawText())!;
    }
}

public sealed class McpConnectionsApi
{
    private readonly TypedGeneratedApi _root;
    internal McpConnectionsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfAutoMcpListResponse> McpListAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/mcp-connections", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoMcpListResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoMcpCreateResponse> McpCreateAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/mcp-connections", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoMcpCreateResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoMcpDeleteResponse> McpDeleteAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/mcp-connections/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoMcpDeleteResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoMcpGetResponse> McpGetAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/mcp-connections/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoMcpGetResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoMcpUpdateResponse> McpUpdateAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/mcp-connections/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoMcpUpdateResponse>(json.GetRawText())!;
    }
    public async Task<NtfAutoMcpRefreshManifestResponse> McpRefreshManifestAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/mcp-connections/{id}/refresh-manifest", pathParams, options);
        return JsonSerializer.Deserialize<NtfAutoMcpRefreshManifestResponse>(json.GetRawText())!;
    }
}

public sealed class MetaApi
{
    private readonly TypedGeneratedApi _root;
    internal MetaApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfContactGetV1MetaContactLocalesResponse> GetV1MetaContactLocalesAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/meta/contact-locales", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactGetV1MetaContactLocalesResponse>(json.GetRawText())!;
    }
}

public sealed class MetricsApi
{
    private readonly TypedGeneratedApi _root;
    internal MetricsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPlatformGetMetricsOverviewResponse> GetMetricsOverviewAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/metrics/overview", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformGetMetricsOverviewResponse>(json.GetRawText())!;
    }
}

public sealed class NotifyApi
{
    private readonly TypedGeneratedApi _root;
    internal NotifyApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPlatformPostNotifyResponse> PostNotifyAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/notify", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformPostNotifyResponse>(json.GetRawText())!;
    }
}

public sealed class PhoneNumbersApi
{
    private readonly TypedGeneratedApi _root;
    internal PhoneNumbersApi(TypedGeneratedApi root) => _root = root;
    public PhoneNumbersOrdersApi orders() => new PhoneNumbersOrdersApi(_root);
public sealed class PhoneNumbersOrdersApi
{
    private readonly TypedGeneratedApi _root;
    internal PhoneNumbersOrdersApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPhoneRegDocumentResponse> RegDocumentAsync(string orderId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["orderId"] = orderId };
        var json = await _root._transport.RequestAsync("POST", "/v1/phone-numbers/orders/{orderId}/regulatory/documents", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneRegDocumentResponse>(json.GetRawText())!;
    }
    public async Task<NtfPhoneRegStatusResponse> RegStatusAsync(string orderId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["orderId"] = orderId };
        var json = await _root._transport.RequestAsync("GET", "/v1/phone-numbers/orders/{orderId}/regulatory/status", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneRegStatusResponse>(json.GetRawText())!;
    }
    public async Task<NtfPhoneRegSubmitResponse> RegSubmitAsync(string orderId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["orderId"] = orderId };
        var json = await _root._transport.RequestAsync("POST", "/v1/phone-numbers/orders/{orderId}/regulatory/submit", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneRegSubmitResponse>(json.GetRawText())!;
    }
    public async Task<NtfPhoneReplacementOptionsResponse> ReplacementOptionsAsync(string orderId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["orderId"] = orderId };
        var json = await _root._transport.RequestAsync("GET", "/v1/phone-numbers/orders/{orderId}/replacement-options", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneReplacementOptionsResponse>(json.GetRawText())!;
    }
    public async Task<NtfPhoneSelectReplacementResponse> SelectReplacementAsync(string orderId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["orderId"] = orderId };
        var json = await _root._transport.RequestAsync("POST", "/v1/phone-numbers/orders/{orderId}/select-replacement-number", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneSelectReplacementResponse>(json.GetRawText())!;
    }
}

    public PhoneNumbersRegulatoryApi regulatory() => new PhoneNumbersRegulatoryApi(_root);
public sealed class PhoneNumbersRegulatoryApi
{
    private readonly TypedGeneratedApi _root;
    internal PhoneNumbersRegulatoryApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPhoneRegProfileResponse> RegProfileAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("PUT", "/v1/phone-numbers/regulatory/profile", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneRegProfileResponse>(json.GetRawText())!;
    }
    public async Task<NtfPhoneRegRequirementsResponse> RegRequirementsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/phone-numbers/regulatory/requirements", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneRegRequirementsResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfPhoneListEnvelope> GetV1PhoneNumbersAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/phone-numbers", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneListEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfPhoneSingleEnvelope> GetV1PhoneNumbersByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/phone-numbers/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneSingleEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfPhoneSingleEnvelope> PatchV1PhoneNumbersByIdAsync(string id, Notifique.OpenApi.Models.Model.NtfPhoneUpdateBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/phone-numbers/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneSingleEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfPhoneGetV1PhoneNumbersAvailableResponse> GetV1PhoneNumbersAvailableAsync(string? countryCode = null, string? phoneNumberType = null, string? areaCode = null, string? contains = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (countryCode != null) query["countryCode"] = countryCode.ToString()!;
        if (phoneNumberType != null) query["phoneNumberType"] = phoneNumberType.ToString()!;
        if (areaCode != null) query["areaCode"] = areaCode.ToString()!;
        if (contains != null) query["contains"] = contains.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/phone-numbers/available", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneGetV1PhoneNumbersAvailableResponse>(json.GetRawText())!;
    }
    public async Task<NtfPhoneConfigResponse> ConfigAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/phone-numbers/config", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneConfigResponse>(json.GetRawText())!;
    }
    public async Task<NtfPhoneCreateOrderResponse> CreateOrderAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/phone-numbers/orders", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneCreateOrderResponse>(json.GetRawText())!;
    }
    public async Task<NtfPhoneGetOrderResponse> GetOrderAsync(string orderId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["orderId"] = orderId };
        var json = await _root._transport.RequestAsync("GET", "/v1/phone-numbers/orders/{orderId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPhoneGetOrderResponse>(json.GetRawText())!;
    }
}

public sealed class PipelinesApi
{
    private readonly TypedGeneratedApi _root;
    internal PipelinesApi(TypedGeneratedApi root) => _root = root;
    public PipelinesBoardsApi boards() => new PipelinesBoardsApi(_root);
public sealed class PipelinesBoardsApi
{
    private readonly TypedGeneratedApi _root;
    internal PipelinesBoardsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPipeCreateCardResponse> CreateCardAsync(string boardId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["boardId"] = boardId };
        var json = await _root._transport.RequestAsync("POST", "/v1/pipelines/boards/{boardId}/cards", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipeCreateCardResponse>(json.GetRawText())!;
    }
    public async Task<NtfPipeReplaceColumnsResponse> ReplaceColumnsAsync(string boardId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["boardId"] = boardId };
        var json = await _root._transport.RequestAsync("PUT", "/v1/pipelines/boards/{boardId}/columns", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipeReplaceColumnsResponse>(json.GetRawText())!;
    }
    public async Task<NtfPipeBoardOverviewResponse> BoardOverviewAsync(string boardId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["boardId"] = boardId };
        var json = await _root._transport.RequestAsync("GET", "/v1/pipelines/boards/{boardId}/overview", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipeBoardOverviewResponse>(json.GetRawText())!;
    }
}

    public PipelinesCardsApi cards() => new PipelinesCardsApi(_root);
public sealed class PipelinesCardsApi
{
    private readonly TypedGeneratedApi _root;
    internal PipelinesCardsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPipeMoveCardResponse> MoveCardAsync(string cardId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["cardId"] = cardId };
        var json = await _root._transport.RequestAsync("POST", "/v1/pipelines/cards/{cardId}/move", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipeMoveCardResponse>(json.GetRawText())!;
    }
}

    public PipelinesContactsApi contacts() => new PipelinesContactsApi(_root);
public sealed class PipelinesContactsApi
{
    private readonly TypedGeneratedApi _root;
    internal PipelinesContactsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPipeContactCardsResponse> ContactCardsAsync(string contactId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["contactId"] = contactId };
        var json = await _root._transport.RequestAsync("GET", "/v1/pipelines/contacts/{contactId}/cards", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipeContactCardsResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfPipeListBoardsResponse> ListBoardsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/pipelines/boards", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipeListBoardsResponse>(json.GetRawText())!;
    }
    public async Task<NtfPipeCreateBoardResponse> CreateBoardAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/pipelines/boards", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipeCreateBoardResponse>(json.GetRawText())!;
    }
    public async Task<NtfPipeGetBoardResponse> GetBoardAsync(string boardId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["boardId"] = boardId };
        var json = await _root._transport.RequestAsync("GET", "/v1/pipelines/boards/{boardId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipeGetBoardResponse>(json.GetRawText())!;
    }
    public async Task<NtfPipePatchBoardResponse> PatchBoardAsync(string boardId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["boardId"] = boardId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/pipelines/boards/{boardId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipePatchBoardResponse>(json.GetRawText())!;
    }
    public async Task<NtfPipePatchCardResponse> PatchCardAsync(string cardId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["cardId"] = cardId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/pipelines/cards/{cardId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPipePatchCardResponse>(json.GetRawText())!;
    }
}

public sealed class PlatformApi
{
    private readonly TypedGeneratedApi _root;
    internal PlatformApi(TypedGeneratedApi root) => _root = root;
    public PlatformApiKeysApi apiKeys() => new PlatformApiKeysApi(_root);
public sealed class PlatformApiKeysApi
{
    private readonly TypedGeneratedApi _root;
    internal PlatformApiKeysApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPlatformRevokeApiKeyResponse> RevokeApiKeyAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/platform/api-keys/{id}/revoke", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformRevokeApiKeyResponse>(json.GetRawText())!;
    }
}

    public PlatformWorkspacesApi workspaces() => new PlatformWorkspacesApi(_root);
public sealed class PlatformWorkspacesApi
{
    private readonly TypedGeneratedApi _root;
    internal PlatformWorkspacesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPlatformGetBalanceResponse> GetBalanceAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/workspaces/{id}/balance", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformGetBalanceResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformRechargeBalanceResponse> RechargeBalanceAsync(string id, Notifique.OpenApi.Models.Model.NtfPlatformRechargeBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/platform/workspaces/{id}/balance/recharge", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformRechargeBalanceResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformCreditsUsageResponse> GetCreditsUsageAsync(string id, string? page = null, string? limit = null, string? chargedAs = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (chargedAs != null) query["chargedAs"] = chargedAs.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/workspaces/{id}/credits/usage", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformCreditsUsageResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformInvitesListResponse> ListInvitesAsync(string id, string? page = null, string? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/workspaces/{id}/invites", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformInvitesListResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformCreateInviteResponse> CreateInviteAsync(string id, Notifique.OpenApi.Models.Model.NtfPlatformInviteBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/platform/workspaces/{id}/invites", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformCreateInviteResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformCancelInviteResponse> CancelInviteAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("DELETE", "/v1/platform/workspaces/{id}/invites/{inviteId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformCancelInviteResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformMembersListResponse> ListMembersAsync(string id, string? page = null, string? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/workspaces/{id}/members", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformMembersListResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformRemoveMemberResponse> RemoveMemberAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("DELETE", "/v1/platform/workspaces/{id}/members/{userId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformRemoveMemberResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformListPaymentMethodsResponse> ListPaymentMethodsAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/workspaces/{id}/payment-methods", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformListPaymentMethodsResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformCreatePaymentMethodResponse> CreatePaymentMethodAsync(string id, Notifique.OpenApi.Models.Model.NtfPlatformPaymentMethodCreate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/platform/workspaces/{id}/payment-methods", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformCreatePaymentMethodResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformDeletePaymentMethodResponse> DeletePaymentMethodAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("DELETE", "/v1/platform/workspaces/{id}/payment-methods/{pmId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformDeletePaymentMethodResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformUpdatePaymentMethodResponse> UpdatePaymentMethodAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("PATCH", "/v1/platform/workspaces/{id}/payment-methods/{pmId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformUpdatePaymentMethodResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformCancelSubscriptionResponse> CancelSubscriptionAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/platform/workspaces/{id}/subscription", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformCancelSubscriptionResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformSubscriptionResponse> GetWorkspaceSubscriptionAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/workspaces/{id}/subscription", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformSubscriptionResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformSubscribeWorkspaceResponse> SubscribeWorkspaceAsync(string id, Notifique.OpenApi.Models.Model.NtfPlatformSubscribeBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/platform/workspaces/{id}/subscription", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformSubscribeWorkspaceResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfPlatformListApiKeysResponse> ListApiKeysAsync(bool? includeRevoked = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (includeRevoked != null) query["includeRevoked"] = includeRevoked.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/api-keys", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformListApiKeysResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformCreateApiKeyResponse> CreateApiKeyAsync(Notifique.OpenApi.Models.Model.NtfPlatformApiKeyCreate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/platform/api-keys", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformCreateApiKeyResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformGetApiKeyResponse> GetApiKeyAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/api-keys/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformGetApiKeyResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformPatchApiKeyResponse> PatchApiKeyAsync(string id, Notifique.OpenApi.Models.Model.NtfPlatformApiKeyPatch? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/platform/api-keys/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformPatchApiKeyResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformLoginResponse> PostLoginAsync(Notifique.OpenApi.Models.Model.NtfPlatformLoginBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/platform/login", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformLoginResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformGetMeResponse> GetMeAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/me", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformGetMeResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformRegisterResponse> PostRegisterAsync(Notifique.OpenApi.Models.Model.NtfPlatformRegisterBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/platform/register", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformRegisterResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformVerifyResponse> PostVerifyAsync(Notifique.OpenApi.Models.Model.NtfPlatformVerifyBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/platform/verify", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformVerifyResponse>(json.GetRawText())!;
    }
    public async Task<NtfPlatformListUserWorkspacesResponse> ListUserWorkspacesAsync(string? include = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (include != null) query["include"] = include.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/platform/workspaces", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformListUserWorkspacesResponse>(json.GetRawText())!;
    }
}

public sealed class PricingApi
{
    private readonly TypedGeneratedApi _root;
    internal PricingApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPlatformGetPricingResponse> GetPricingAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/pricing", pathParams, options);
        return JsonSerializer.Deserialize<NtfPlatformGetPricingResponse>(json.GetRawText())!;
    }
}

public sealed class PushApi
{
    private readonly TypedGeneratedApi _root;
    internal PushApi(TypedGeneratedApi root) => _root = root;
    public PushMessagesApi messages() => new PushMessagesApi(_root);
public sealed class PushMessagesApi
{
    private readonly TypedGeneratedApi _root;
    internal PushMessagesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPushCancelPushResponse> PostV1PushMessagesCancelAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/push/messages/{id}/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushCancelPushResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfPushPushAppListResponse> GetV1PushAppsAsync(int? page = null, int? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/push/apps", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushPushAppListResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushPushAppSingleResponse> PostV1PushAppsAsync(Notifique.OpenApi.Models.Model.NtfPushPushAppCreateRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/push/apps", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushPushAppSingleResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushDeleteV1PushAppsByIdResponse> DeleteV1PushAppsByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/push/apps/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushDeleteV1PushAppsByIdResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushPushAppSingleResponse> GetV1PushAppsByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/push/apps/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushPushAppSingleResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushPushAppSingleResponse> PutV1PushAppsByIdAsync(string id, Notifique.OpenApi.Models.Model.NtfPushPushAppUpdateRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PUT", "/v1/push/apps/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushPushAppSingleResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushPushDeviceListResponse> GetV1PushDevicesAsync(int? page = null, int? limit = null, string? appId = null, string? platform = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (appId != null) query["appId"] = appId.ToString()!;
        if (platform != null) query["platform"] = platform.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/push/devices", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushPushDeviceListResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushPushDeviceSingleResponse> PostV1PushDevicesAsync(Notifique.OpenApi.Models.Model.NtfPushPushDeviceRegisterRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/push/devices", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushPushDeviceSingleResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushDeleteV1PushDevicesByIdResponse> DeleteV1PushDevicesByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/push/devices/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushDeleteV1PushDevicesByIdResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushPushDeviceSingleResponse> GetV1PushDevicesByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/push/devices/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushPushDeviceSingleResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushPushMessageListResponse> GetV1PushMessagesAsync(int? page = null, int? limit = null, string? status = null, string? appId = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (appId != null) query["appId"] = appId.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/push/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushPushMessageListResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushSendPushResponse> PostV1PushMessagesAsync(Notifique.OpenApi.Models.Model.NtfPushSendPushRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/push/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushSendPushResponse>(json.GetRawText())!;
    }
    public async Task<NtfPushPushMessageSingleResponse> GetV1PushMessagesByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/push/messages/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPushPushMessageSingleResponse>(json.GetRawText())!;
    }
}

public sealed class RcsApi
{
    private readonly TypedGeneratedApi _root;
    internal RcsApi(TypedGeneratedApi root) => _root = root;
    public RcsMessagesApi messages() => new RcsMessagesApi(_root);
public sealed class RcsMessagesApi
{
    private readonly TypedGeneratedApi _root;
    internal RcsMessagesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfRcsCancelRcsResponse> PostV1RcsCancelAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/rcs/messages/{id}/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfRcsCancelRcsResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfRcsGetV1RcsMessagesResponse> GetV1RcsMessagesAsync(string? page = null, string? limit = null, string? fromDate = null, string? toDate = null, string? status = null, string? to = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (fromDate != null) query["fromDate"] = fromDate.ToString()!;
        if (toDate != null) query["toDate"] = toDate.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (to != null) query["to"] = to.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/rcs/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfRcsGetV1RcsMessagesResponse>(json.GetRawText())!;
    }
    public async Task<NtfRcsSendRcsResponse> PostV1RcsSendAsync(Notifique.OpenApi.Models.Model.NtfRcsSendRcsRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/rcs/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfRcsSendRcsResponse>(json.GetRawText())!;
    }
    public async Task<NtfRcsRcsStatusResponse> GetV1RcsByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/rcs/messages/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfRcsRcsStatusResponse>(json.GetRawText())!;
    }
}

public sealed class ReportApi
{
    private readonly TypedGeneratedApi _root;
    internal ReportApi(TypedGeneratedApi root) => _root = root;
    public async Task<ReportOkResponse> PostV1ReportAsync(Notifique.OpenApi.Models.Model.ReportRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/report", pathParams, options);
        return JsonSerializer.Deserialize<ReportOkResponse>(json.GetRawText())!;
    }
}

public sealed class SegmentsApi
{
    private readonly TypedGeneratedApi _root;
    internal SegmentsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfContactSegmentListResponse> GetV1SegmentsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/segments", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactSegmentListResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactSegmentOneResponse> PostV1SegmentsAsync(Notifique.OpenApi.Models.Model.NtfContactSegmentCreate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/segments", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactSegmentOneResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactDeleteV1SegmentResponse> DeleteV1SegmentAsync(string segmentId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["segmentId"] = segmentId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/segments/{segmentId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactDeleteV1SegmentResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactSegmentOneResponse> GetV1SegmentByIdAsync(string segmentId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["segmentId"] = segmentId };
        var json = await _root._transport.RequestAsync("GET", "/v1/segments/{segmentId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactSegmentOneResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactSegmentOneResponse> PatchV1SegmentAsync(string segmentId, Notifique.OpenApi.Models.Model.NtfContactSegmentPatch? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["segmentId"] = segmentId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/segments/{segmentId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactSegmentOneResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactSegmentPreviewResponse> GetV1SegmentPreviewAsync(string segmentId, string? page = null, string? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["segmentId"] = segmentId };
        var json = await _root._transport.RequestAsync("GET", "/v1/segments/{segmentId}/preview", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactSegmentPreviewResponse>(json.GetRawText())!;
    }
}

public sealed class SendingPoolsApi
{
    private readonly TypedGeneratedApi _root;
    internal SendingPoolsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfPoolListResponse> ListAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/sending-pools", pathParams, options);
        return JsonSerializer.Deserialize<NtfPoolListResponse>(json.GetRawText())!;
    }
    public async Task<NtfPoolCreateResponse> CreateAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/sending-pools", pathParams, options);
        return JsonSerializer.Deserialize<NtfPoolCreateResponse>(json.GetRawText())!;
    }
    public async Task<NtfPoolDeleteResponse> DeleteAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/sending-pools/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPoolDeleteResponse>(json.GetRawText())!;
    }
    public async Task<NtfPoolGetResponse> GetAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/sending-pools/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPoolGetResponse>(json.GetRawText())!;
    }
    public async Task<NtfPoolUpdateResponse> UpdateAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PUT", "/v1/sending-pools/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPoolUpdateResponse>(json.GetRawText())!;
    }
    public async Task<NtfPoolAddMemberResponse> AddMemberAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/sending-pools/{id}/members", pathParams, options);
        return JsonSerializer.Deserialize<NtfPoolAddMemberResponse>(json.GetRawText())!;
    }
    public async Task<NtfPoolDeleteMemberResponse> DeleteMemberAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("DELETE", "/v1/sending-pools/{id}/members/{memberId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPoolDeleteMemberResponse>(json.GetRawText())!;
    }
    public async Task<NtfPoolUpdateMemberResponse> UpdateMemberAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("PUT", "/v1/sending-pools/{id}/members/{memberId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfPoolUpdateMemberResponse>(json.GetRawText())!;
    }
    public async Task<NtfPoolStatsResponse> StatsAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/sending-pools/{id}/stats", pathParams, options);
        return JsonSerializer.Deserialize<NtfPoolStatsResponse>(json.GetRawText())!;
    }
}

public sealed class ShortLinksApi
{
    private readonly TypedGeneratedApi _root;
    internal ShortLinksApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfShortLinksListResponse> GetV1ShortLinksAsync(string? page = null, string? limit = null, string? source = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (source != null) query["source"] = source.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/short-links", pathParams, options);
        return JsonSerializer.Deserialize<NtfShortLinksListResponse>(json.GetRawText())!;
    }
    public async Task<NtfShortLinksCreateResponse> PostV1ShortLinksAsync(Notifique.OpenApi.Models.Model.NtfShortLinksCreateRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/short-links", pathParams, options);
        return JsonSerializer.Deserialize<NtfShortLinksCreateResponse>(json.GetRawText())!;
    }
    public async Task<NtfShortLinksDeleteResponse> DeleteV1ShortLinksByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/short-links/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfShortLinksDeleteResponse>(json.GetRawText())!;
    }
    public async Task<NtfShortLinksDetailResponse> GetV1ShortLinksByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/short-links/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfShortLinksDetailResponse>(json.GetRawText())!;
    }
    public async Task<NtfShortLinksDetailResponse> PatchV1ShortLinksByIdAsync(string id, Notifique.OpenApi.Models.Model.NtfShortLinksPatchRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/short-links/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfShortLinksDetailResponse>(json.GetRawText())!;
    }
    public async Task<NtfShortLinksAnalyticsResponse> GetV1ShortLinksAnalyticsAsync(string id, string? granularity = null, string? start = null, string? endParam = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (granularity != null) query["granularity"] = granularity.ToString()!;
        if (start != null) query["start"] = start.ToString()!;
        if (endParam != null) query["end"] = endParam.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/short-links/{id}/analytics", pathParams, options);
        return JsonSerializer.Deserialize<NtfShortLinksAnalyticsResponse>(json.GetRawText())!;
    }
    public async Task<NtfShortLinksClicksListResponse> GetV1ShortLinksClicksAsync(string id, string? page = null, string? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/short-links/{id}/clicks", pathParams, options);
        return JsonSerializer.Deserialize<NtfShortLinksClicksListResponse>(json.GetRawText())!;
    }
}

public sealed class SmsApi
{
    private readonly TypedGeneratedApi _root;
    internal SmsApi(TypedGeneratedApi root) => _root = root;
    public SmsMessagesApi messages() => new SmsMessagesApi(_root);
public sealed class SmsMessagesApi
{
    private readonly TypedGeneratedApi _root;
    internal SmsMessagesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfSmsCancelSmsResponse> PostV1SmsCancelAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/sms/messages/{id}/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfSmsCancelSmsResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfSmsGetV1SmsInboundResponse> GetV1SmsInboundAsync(string? page = null, string? limit = null, string? q = null, string? provider = null, string? linked = null, string? dateFrom = null, string? dateTo = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (q != null) query["q"] = q.ToString()!;
        if (provider != null) query["provider"] = provider.ToString()!;
        if (linked != null) query["linked"] = linked.ToString()!;
        if (dateFrom != null) query["dateFrom"] = dateFrom.ToString()!;
        if (dateTo != null) query["dateTo"] = dateTo.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/sms/inbound", pathParams, options);
        return JsonSerializer.Deserialize<NtfSmsGetV1SmsInboundResponse>(json.GetRawText())!;
    }
    public async Task<NtfSmsGetV1SmsInboundByIdResponse> GetV1SmsInboundByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/sms/inbound/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfSmsGetV1SmsInboundByIdResponse>(json.GetRawText())!;
    }
    public async Task<NtfSmsGetV1SmsMessagesResponse> GetV1SmsMessagesAsync(string? page = null, string? limit = null, string? fromDate = null, string? toDate = null, string? status = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (fromDate != null) query["fromDate"] = fromDate.ToString()!;
        if (toDate != null) query["toDate"] = toDate.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/sms/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfSmsGetV1SmsMessagesResponse>(json.GetRawText())!;
    }
    public async Task<NtfSmsSendSmsResponse> PostV1SmsSendAsync(Notifique.OpenApi.Models.Model.NtfSmsSendSmsRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/sms/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfSmsSendSmsResponse>(json.GetRawText())!;
    }
    public async Task<NtfSmsSmsStatusResponse> GetV1SmsByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/sms/messages/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfSmsSmsStatusResponse>(json.GetRawText())!;
    }
}

public sealed class SuppressionsApi
{
    private readonly TypedGeneratedApi _root;
    internal SuppressionsApi(TypedGeneratedApi root) => _root = root;
    public SuppressionsBatchApi batch() => new SuppressionsBatchApi(_root);
public sealed class SuppressionsBatchApi
{
    private readonly TypedGeneratedApi _root;
    internal SuppressionsBatchApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfSuppBatchAddResponse> BatchAddSuppressionsAsync(Notifique.OpenApi.Models.Model.NtfSuppBatchAddRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/suppressions/batch/add", pathParams, options);
        return JsonSerializer.Deserialize<NtfSuppBatchAddResponse>(json.GetRawText())!;
    }
    public async Task<NtfSuppBatchRemoveResponse> BatchRemoveSuppressionsAsync(Notifique.OpenApi.Models.Model.NtfSuppBatchRemoveRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/suppressions/batch/remove", pathParams, options);
        return JsonSerializer.Deserialize<NtfSuppBatchRemoveResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfSuppListResponse> ListSuppressionsAsync(Notifique.OpenApi.Models.Model.NtfSuppSuppressionType? typeParam = null, Notifique.OpenApi.Models.Model.NtfSuppSuppressionReason? reason = null, Notifique.OpenApi.Models.Model.NtfSuppSuppressionOrigin? origin = null, string? channel = null, string? search = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (typeParam != null) query["type"] = typeParam.ToString()!;
        if (reason != null) query["reason"] = reason.ToString()!;
        if (origin != null) query["origin"] = origin.ToString()!;
        if (channel != null) query["channel"] = channel.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/suppressions", pathParams, options);
        return JsonSerializer.Deserialize<NtfSuppListResponse>(json.GetRawText())!;
    }
    public async Task<NtfSuppSingleResponse> CreateSuppressionAsync(Notifique.OpenApi.Models.Model.NtfSuppSuppressionInput? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/suppressions", pathParams, options);
        return JsonSerializer.Deserialize<NtfSuppSingleResponse>(json.GetRawText())!;
    }
    public async Task<NtfSuppRemoveResponse> RemoveSuppressionAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/suppressions/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfSuppRemoveResponse>(json.GetRawText())!;
    }
    public async Task<NtfSuppSingleResponse> GetSuppressionAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/suppressions/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfSuppSingleResponse>(json.GetRawText())!;
    }
    public async Task<NtfSuppRemoveResponse> RemoveSuppressionByIdentityAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("DELETE", "/v1/suppressions/by-identity", pathParams, options);
        return JsonSerializer.Deserialize<NtfSuppRemoveResponse>(json.GetRawText())!;
    }
}

public sealed class TagsApi
{
    private readonly TypedGeneratedApi _root;
    internal TagsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfContactGetV1TagsResponse> GetV1TagsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/tags", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactGetV1TagsResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactPostV1TagsResponse> PostV1TagsAsync(Notifique.OpenApi.Models.Model.NtfContactTagCreate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/tags", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactPostV1TagsResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactDeleteV1TagResponse> DeleteV1TagAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/tags/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactDeleteV1TagResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactGetV1TagResponse> GetV1TagAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/tags/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactGetV1TagResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactPutV1TagResponse> PutV1TagAsync(string id, Notifique.OpenApi.Models.Model.NtfContactTagUpdate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PUT", "/v1/tags/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactPutV1TagResponse>(json.GetRawText())!;
    }
}

public sealed class TelegramApi
{
    private readonly TypedGeneratedApi _root;
    internal TelegramApi(TypedGeneratedApi root) => _root = root;
    public TelegramInstancesApi instances() => new TelegramInstancesApi(_root);
public sealed class TelegramInstancesApi
{
    private readonly TypedGeneratedApi _root;
    internal TelegramInstancesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfTgConnectPageStatusResponse> NtfTelegramGetConnectPageAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/telegram/instances/{instanceId}/connect-page", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgConnectPageStatusResponse>(json.GetRawText())!;
    }
    public async Task<NtfTgConnectPageDisableResponse> NtfTelegramDisableConnectPageAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/telegram/instances/{instanceId}/connect-page/disable", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgConnectPageDisableResponse>(json.GetRawText())!;
    }
    public async Task<NtfTgConnectPageEnableResponse> NtfTelegramEnableConnectPageAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/telegram/instances/{instanceId}/connect-page/enable", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgConnectPageEnableResponse>(json.GetRawText())!;
    }
    public async Task<NtfTgConnectPageEnableResponse> NtfTelegramRotateConnectPageAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/telegram/instances/{instanceId}/connect-page/rotate-secret", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgConnectPageEnableResponse>(json.GetRawText())!;
    }
    public async Task<NtfTgQrEnvelope> GetV1TelegramInstanceQrAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/telegram/instances/{instanceId}/qr", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgQrEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfTgQrCancelSuccess> PostV1TelegramInstanceQrCancelAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/telegram/instances/{instanceId}/qr/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgQrCancelSuccess>(json.GetRawText())!;
    }
    public async Task<NtfTgSessionSaveResponse> PostV1TelegramInstanceSessionAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/telegram/instances/{instanceId}/session", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgSessionSaveResponse>(json.GetRawText())!;
    }
}

    public TelegramMessagesApi messages() => new TelegramMessagesApi(_root);
public sealed class TelegramMessagesApi
{
    private readonly TypedGeneratedApi _root;
    internal TelegramMessagesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfTgMessageIdStatusResponse> PostV1TelegramMessageCancelAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("POST", "/v1/telegram/messages/{messageId}/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgMessageIdStatusResponse>(json.GetRawText())!;
    }
    public async Task<NtfTgMessageIdStatusResponse> PatchV1TelegramMessageEditAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/telegram/messages/{messageId}/edit", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgMessageIdStatusResponse>(json.GetRawText())!;
    }
    public async Task<NtfTgInboundListEnvelope> GetV1TelegramInboundAsync(string? page = null, string? limit = null, string? q = null, string? instanceId = null, string? dateFrom = null, string? dateTo = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (q != null) query["q"] = q.ToString()!;
        if (instanceId != null) query["instanceId"] = instanceId.ToString()!;
        if (dateFrom != null) query["dateFrom"] = dateFrom.ToString()!;
        if (dateTo != null) query["dateTo"] = dateTo.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/telegram/messages/inbound", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgInboundListEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfTgInboundDetailEnvelope> GetV1TelegramInboundByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/telegram/messages/inbound/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgInboundDetailEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfTgPostV1TelegramInboundMediaResponse> PostV1TelegramInboundMediaAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/telegram/messages/inbound/{id}/media", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgPostV1TelegramInboundMediaResponse>(json.GetRawText())!;
    }
    public async Task<byte[]> GetV1TelegramInboundMediaDownloadAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        return await _root._transport.RequestBytesAsync("GET", "/v1/telegram/messages/inbound/{id}/media/download", pathParams, options);
    }
}

    public async Task<NtfTgChatSubscriptionListEnvelope> GetV1TelegramChatsAsync(string? page = null, string? limit = null, string? q = null, string? instanceId = null, string? status = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (q != null) query["q"] = q.ToString()!;
        if (instanceId != null) query["instanceId"] = instanceId.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/telegram/chats", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgChatSubscriptionListEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfTgTelegramInstanceListEnvelope> GetV1TelegramInstancesAsync(string? page = null, string? limit = null, string? status = null, string? search = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/telegram/instances", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgTelegramInstanceListEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfTgCreateTelegramInstanceResponse> PostV1TelegramInstancesAsync(Notifique.OpenApi.Models.Model.NtfTgCreateTelegramInstanceRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/telegram/instances", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgCreateTelegramInstanceResponse>(json.GetRawText())!;
    }
    public async Task<NtfTgInstanceDeletedResponse> DeleteV1TelegramInstanceAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/telegram/instances/{instanceId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgInstanceDeletedResponse>(json.GetRawText())!;
    }
    public async Task<NtfTgInstanceDetailEnvelope> GetV1TelegramInstanceAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/telegram/instances/{instanceId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgInstanceDetailEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfTgMessageListEnvelope> GetV1TelegramMessagesAsync(string? page = null, string? limit = null, string? fromDate = null, string? toDate = null, string? instanceIds = null, string? status = null, string? typeParam = null, string? includeEvents = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (fromDate != null) query["fromDate"] = fromDate.ToString()!;
        if (toDate != null) query["toDate"] = toDate.ToString()!;
        if (instanceIds != null) query["instanceIds"] = instanceIds.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (typeParam != null) query["type"] = typeParam.ToString()!;
        if (includeEvents != null) query["includeEvents"] = includeEvents.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/telegram/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgMessageListEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfTgSendTelegramMessageAccepted> PostV1TelegramSendAsync(Notifique.OpenApi.Models.Model.NtfTgSendTelegramMessageRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/telegram/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgSendTelegramMessageAccepted>(json.GetRawText())!;
    }
    public async Task<NtfTgMessageIdStatusResponse> DeleteV1TelegramMessageAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/telegram/messages/{messageId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgMessageIdStatusResponse>(json.GetRawText())!;
    }
    public async Task<NtfTgMessageDetailEnvelope> GetV1TelegramMessageByIdAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("GET", "/v1/telegram/messages/{messageId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfTgMessageDetailEnvelope>(json.GetRawText())!;
    }
}

public sealed class TemplatesApi
{
    private readonly TypedGeneratedApi _root;
    internal TemplatesApi(TypedGeneratedApi root) => _root = root;
    public async Task<TemplateListResponse> ListTemplatesAsync(int? page = null, int? limit = null, string? search = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/templates", pathParams, options);
        return JsonSerializer.Deserialize<TemplateListResponse>(json.GetRawText())!;
    }
    public async Task<TemplateResponse> CreateTemplatesAsync(Notifique.OpenApi.Models.Model.TemplateCreateRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/templates", pathParams, options);
        return JsonSerializer.Deserialize<TemplateResponse>(json.GetRawText())!;
    }
    public async Task<TemplateDeleteResponse> DeleteTemplatesAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/templates/{id}", pathParams, options);
        return JsonSerializer.Deserialize<TemplateDeleteResponse>(json.GetRawText())!;
    }
    public async Task<TemplateResponse> GetTemplatesAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/templates/{id}", pathParams, options);
        return JsonSerializer.Deserialize<TemplateResponse>(json.GetRawText())!;
    }
    public async Task<TemplateResponse> UpdateTemplatesAsync(string id, Notifique.OpenApi.Models.Model.TemplatePatchRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/templates/{id}", pathParams, options);
        return JsonSerializer.Deserialize<TemplateResponse>(json.GetRawText())!;
    }
    public async Task<TemplateSendResponse> CreateSendAsync(Notifique.OpenApi.Models.Model.TemplateSendRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/templates/send", pathParams, options);
        return JsonSerializer.Deserialize<TemplateSendResponse>(json.GetRawText())!;
    }
}

public sealed class TopicsApi
{
    private readonly TypedGeneratedApi _root;
    internal TopicsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfContactTopicListResponse> GetV1TopicsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/topics", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactTopicListResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactTopicOneResponse> PostV1TopicsAsync(Notifique.OpenApi.Models.Model.NtfContactTopicCreate? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/topics", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactTopicOneResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactDeleteV1TopicResponse> DeleteV1TopicAsync(string topicId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["topicId"] = topicId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/topics/{topicId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactDeleteV1TopicResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactTopicOneResponse> GetV1TopicByIdAsync(string topicId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["topicId"] = topicId };
        var json = await _root._transport.RequestAsync("GET", "/v1/topics/{topicId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactTopicOneResponse>(json.GetRawText())!;
    }
    public async Task<NtfContactTopicOneResponse> PatchV1TopicAsync(string topicId, Notifique.OpenApi.Models.Model.NtfContactTopicPatch? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["topicId"] = topicId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/topics/{topicId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfContactTopicOneResponse>(json.GetRawText())!;
    }
}

public sealed class VoiceApi
{
    private readonly TypedGeneratedApi _root;
    internal VoiceApi(TypedGeneratedApi root) => _root = root;
    public VoiceCallsApi calls() => new VoiceCallsApi(_root);
public sealed class VoiceCallsApi
{
    private readonly TypedGeneratedApi _root;
    internal VoiceCallsApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfVoicePostV1VoiceCallsActionResponse> PostV1VoiceCallsActionAsync(Notifique.OpenApi.Models.Model.NtfVoiceActionBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/voice/calls/{id}/actions/{action}", pathParams, options);
        return JsonSerializer.Deserialize<NtfVoicePostV1VoiceCallsActionResponse>(json.GetRawText())!;
    }
    public async Task<byte[]> GetV1VoiceRecordingDownloadAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        return await _root._transport.RequestBytesAsync("GET", "/v1/voice/calls/{id}/recordings/{recordingId}/download", pathParams, options);
    }
}

    public async Task<NtfVoiceListEnvelope> GetV1VoiceCallsAsync(string? page = null, string? limit = null, string? direction = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (direction != null) query["direction"] = direction.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/voice/calls", pathParams, options);
        return JsonSerializer.Deserialize<NtfVoiceListEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfVoiceSendSuccessEnvelope> PostV1VoiceCallsAsync(Notifique.OpenApi.Models.Model.NtfVoiceCreateBody? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/voice/calls", pathParams, options);
        return JsonSerializer.Deserialize<NtfVoiceSendSuccessEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfVoiceDetailEnvelope> GetV1VoiceCallsByIdAsync(string id, string? includeEvents = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (includeEvents != null) query["includeEvents"] = includeEvents.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/voice/calls/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfVoiceDetailEnvelope>(json.GetRawText())!;
    }
}

public sealed class WebhooksApi
{
    private readonly TypedGeneratedApi _root;
    internal WebhooksApi(TypedGeneratedApi root) => _root = root;
    public WebhooksDeliveriesApi deliveries() => new WebhooksDeliveriesApi(_root);
public sealed class WebhooksDeliveriesApi
{
    private readonly TypedGeneratedApi _root;
    internal WebhooksDeliveriesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfWhResendDeliveryResponse> ResendDeliveryAsync(string deliveryId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["deliveryId"] = deliveryId };
        var json = await _root._transport.RequestAsync("POST", "/v1/webhooks/deliveries/{deliveryId}/resend", pathParams, options);
        return JsonSerializer.Deserialize<NtfWhResendDeliveryResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfWhListWebhooksResponse> ListWebhooksAsync(int? page = null, int? limit = null, string? eventParam = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (eventParam != null) query["event"] = eventParam.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/webhooks", pathParams, options);
        return JsonSerializer.Deserialize<NtfWhListWebhooksResponse>(json.GetRawText())!;
    }
    public async Task<NtfWhCreateWebhookResponse> CreateWebhookAsync(Notifique.OpenApi.Models.Model.NtfWhWebhookInput? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/webhooks", pathParams, options);
        return JsonSerializer.Deserialize<NtfWhCreateWebhookResponse>(json.GetRawText())!;
    }
    public async Task<NtfWhDeleteWebhookResponse> DeleteWebhookAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/webhooks/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWhDeleteWebhookResponse>(json.GetRawText())!;
    }
    public async Task<NtfWhGetWebhookResponse> GetWebhookAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/webhooks/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWhGetWebhookResponse>(json.GetRawText())!;
    }
    public async Task<NtfWhUpdateWebhookResponse> UpdateWebhookAsync(string id, Notifique.OpenApi.Models.Model.NtfWhWebhookInput? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PUT", "/v1/webhooks/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWhUpdateWebhookResponse>(json.GetRawText())!;
    }
    public async Task<NtfWhRotateWebhookSecretResponse> RotateWebhookSecretAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/webhooks/{id}/rotate-secret", pathParams, options);
        return JsonSerializer.Deserialize<NtfWhRotateWebhookSecretResponse>(json.GetRawText())!;
    }
    public async Task<NtfWhListDeliveriesResponse> ListDeliveriesAsync(int? page = null, int? limit = null, bool? success = null, string? eventParam = null, string? webhook_id = null, string? messageId = null, string? search = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (success != null) query["success"] = success.ToString()!;
        if (eventParam != null) query["event"] = eventParam.ToString()!;
        if (webhook_id != null) query["webhook_id"] = webhook_id.ToString()!;
        if (messageId != null) query["messageId"] = messageId.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/webhooks/deliveries", pathParams, options);
        return JsonSerializer.Deserialize<NtfWhListDeliveriesResponse>(json.GetRawText())!;
    }
    public async Task<NtfWhGetDeliveryResponse> GetDeliveryAsync(string deliveryId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["deliveryId"] = deliveryId };
        var json = await _root._transport.RequestAsync("GET", "/v1/webhooks/deliveries/{deliveryId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWhGetDeliveryResponse>(json.GetRawText())!;
    }
}

public sealed class WhatsappApi
{
    private readonly TypedGeneratedApi _root;
    internal WhatsappApi(TypedGeneratedApi root) => _root = root;
    public WhatsappInstancesApi instances() => new WhatsappInstancesApi(_root);
public sealed class WhatsappInstancesApi
{
    private readonly TypedGeneratedApi _root;
    internal WhatsappInstancesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfWaCallPermGetResponse> CallPermGetAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances/{instanceId}/calling/permissions", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaCallPermGetResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaCallPermRequestResponse> CallPermRequestAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/instances/{instanceId}/calling/permissions/request", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaCallPermRequestResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaCallSettingsGetResponse> CallSettingsGetAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances/{instanceId}/calling/settings", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaCallSettingsGetResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaCallSettingsPatchResponse> CallSettingsPatchAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/whatsapp/instances/{instanceId}/calling/settings", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaCallSettingsPatchResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaConnectPageStatusResponse> GetV1WhatsappInstanceConnectPageAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances/{instanceId}/connect-page", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaConnectPageStatusResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaConnectPageDisableResponse> PostV1WhatsappInstanceConnectPageDisableAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/instances/{instanceId}/connect-page/disable", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaConnectPageDisableResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaConnectPageEnableResponse> PostV1WhatsappInstanceConnectPageEnableAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/instances/{instanceId}/connect-page/enable", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaConnectPageEnableResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaConnectPageEnableResponse> PostV1WhatsappInstanceConnectPageRotateAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/instances/{instanceId}/connect-page/rotate-secret", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaConnectPageEnableResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaInstanceActionResponse> PostV1WhatsappInstanceDisconnectAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/instances/{instanceId}/disconnect", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaInstanceActionResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaGetV1WhatsappInstancesInstanceIdGroupsResponse> GetV1WhatsappInstancesInstanceIdGroupsAsync(string instanceId, int? page = null, int? limit = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances/{instanceId}/groups", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaGetV1WhatsappInstancesInstanceIdGroupsResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaGetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsResponse> GetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances/{instanceId}/groups/{groupId}/participants", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaGetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteResponse> PostV1WhatsappInstancesInstanceIdGroupsInviteAsync(string instanceId, Notifique.OpenApi.Models.Model.NtfWaGroupInviteSendRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/instances/{instanceId}/groups/invite", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaGetV1WhatsappInstancesInstanceIdGroupsInviteCodeResponse> GetV1WhatsappInstancesInstanceIdGroupsInviteCodeAsync(string instanceId, string? groupJid = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (groupJid != null) query["groupJid"] = groupJid.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances/{instanceId}/groups/invite-code", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaGetV1WhatsappInstancesInstanceIdGroupsInviteCodeResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteRevokeResponse> PostV1WhatsappInstancesInstanceIdGroupsInviteRevokeAsync(string instanceId, Notifique.OpenApi.Models.Model.NtfWaGroupInviteRevokeRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/instances/{instanceId}/groups/invite/revoke", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteRevokeResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaPostV1WhatsappInstancesInstanceIdGroupsParticipantsResponse> PostV1WhatsappInstancesInstanceIdGroupsParticipantsAsync(string instanceId, Notifique.OpenApi.Models.Model.NtfWaGroupParticipantsRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/instances/{instanceId}/groups/participants", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaPostV1WhatsappInstancesInstanceIdGroupsParticipantsResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaGetV1WhatsappInstancePairingCodeResponse> GetV1WhatsappInstancePairingCodeAsync(string instanceId, string? phoneNumber = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (phoneNumber != null) query["phoneNumber"] = phoneNumber.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances/{instanceId}/pairing-code", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaGetV1WhatsappInstancePairingCodeResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaGetV1WhatsappInstanceQrResponse> GetV1WhatsappInstanceQrAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances/{instanceId}/qr", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaGetV1WhatsappInstanceQrResponse>(json.GetRawText())!;
    }
}

    public WhatsappMessagesApi messages() => new WhatsappMessagesApi(_root);
public sealed class WhatsappMessagesApi
{
    private readonly TypedGeneratedApi _root;
    internal WhatsappMessagesApi(TypedGeneratedApi root) => _root = root;
    public async Task<NtfWaPostV1WhatsappMessageCancelResponse> PostV1WhatsappMessageCancelAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/messages/{messageId}/cancel", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaPostV1WhatsappMessageCancelResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaMessageActionResponse> PatchV1WhatsappMessageEditAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("PATCH", "/v1/whatsapp/messages/{messageId}/edit", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaMessageActionResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaGetV1WhatsappMessagesInboundResponse> GetV1WhatsappMessagesInboundAsync(string? page = null, string? limit = null, string? q = null, string? instanceId = null, string? dateFrom = null, string? dateTo = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (q != null) query["q"] = q.ToString()!;
        if (instanceId != null) query["instanceId"] = instanceId.ToString()!;
        if (dateFrom != null) query["dateFrom"] = dateFrom.ToString()!;
        if (dateTo != null) query["dateTo"] = dateTo.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/messages/inbound", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaGetV1WhatsappMessagesInboundResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaGetV1WhatsappMessageInboundByIdResponse> GetV1WhatsappMessageInboundByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/messages/inbound/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaGetV1WhatsappMessageInboundByIdResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaPostV1WhatsappMessageInboundMediaResponse> PostV1WhatsappMessageInboundMediaAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/messages/inbound/{id}/media", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaPostV1WhatsappMessageInboundMediaResponse>(json.GetRawText())!;
    }
    public async Task<byte[]> GetV1WhatsappMessageInboundMediaDownloadAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        return await _root._transport.RequestBytesAsync("GET", "/v1/whatsapp/messages/inbound/{id}/media/download", pathParams, options);
    }
    public async Task<NtfWaPostV1WhatsappMessagePresenceResponse> PostV1WhatsappMessagePresenceAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/messages/presence", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaPostV1WhatsappMessagePresenceResponse>(json.GetRawText())!;
    }
}

    public async Task<NtfWaWhatsAppCallListEnvelope> GetV1WhatsappCallsAsync(string? page = null, string? limit = null, string? instanceId = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (instanceId != null) query["instanceId"] = instanceId.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/calls", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaWhatsAppCallListEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfWaWhatsAppCallCreateEnvelope> PostV1WhatsappCallsAsync(Notifique.OpenApi.Models.Model.NtfWaCreateWhatsAppCallRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/calls", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaWhatsAppCallCreateEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfWaWhatsAppCallDetailEnvelope> GetV1WhatsappCallByIdAsync(string id, string? includeEvents = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (includeEvents != null) query["includeEvents"] = includeEvents.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/calls/{id}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaWhatsAppCallDetailEnvelope>(json.GetRawText())!;
    }
    public async Task<NtfWaInstanceListResponse> GetV1WhatsappInstancesAsync(string? page = null, string? limit = null, string? status = null, string? search = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (search != null) query["search"] = search.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaInstanceListResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaCreateInstanceResponse> PostV1WhatsappInstancesAsync(ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/instances", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaCreateInstanceResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaInstanceActionResponse> DeleteV1WhatsappInstanceAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/whatsapp/instances/{instanceId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaInstanceActionResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaInstanceResponse> GetV1WhatsappInstanceAsync(string instanceId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["instanceId"] = instanceId };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/instances/{instanceId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaInstanceResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaGetV1WhatsappMessagesResponse> GetV1WhatsappMessagesAsync(string? page = null, string? limit = null, string? fromDate = null, string? toDate = null, string? instanceIds = null, string? status = null, string? typeParam = null, string? includeEvents = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (page != null) query["page"] = page.ToString()!;
        if (limit != null) query["limit"] = limit.ToString()!;
        if (fromDate != null) query["fromDate"] = fromDate.ToString()!;
        if (toDate != null) query["toDate"] = toDate.ToString()!;
        if (instanceIds != null) query["instanceIds"] = instanceIds.ToString()!;
        if (status != null) query["status"] = status.ToString()!;
        if (typeParam != null) query["type"] = typeParam.ToString()!;
        if (includeEvents != null) query["includeEvents"] = includeEvents.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaGetV1WhatsappMessagesResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaPostV1WhatsappSendResponse> PostV1WhatsappSendAsync(Notifique.OpenApi.Models.Model.NtfWaSendWhatsAppMessageRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/whatsapp/messages", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaPostV1WhatsappSendResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaMessageActionResponse> DeleteV1WhatsappMessageAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/whatsapp/messages/{messageId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaMessageActionResponse>(json.GetRawText())!;
    }
    public async Task<NtfWaGetV1WhatsappMessageResponse> GetV1WhatsappMessageAsync(string messageId, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["messageId"] = messageId };
        var json = await _root._transport.RequestAsync("GET", "/v1/whatsapp/messages/{messageId}", pathParams, options);
        return JsonSerializer.Deserialize<NtfWaGetV1WhatsappMessageResponse>(json.GetRawText())!;
    }
}

public sealed class WorkspacesApi
{
    private readonly TypedGeneratedApi _root;
    internal WorkspacesApi(TypedGeneratedApi root) => _root = root;
    public async Task<GetV1WorkspacesResponse> GetV1WorkspacesAsync(string? include = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        if (include != null) query["include"] = include.ToString()!;
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("GET", "/v1/workspaces", pathParams, options);
        return JsonSerializer.Deserialize<GetV1WorkspacesResponse>(json.GetRawText())!;
    }
    public async Task<WorkspaceSingleResponse> PostV1WorkspacesAsync(Notifique.OpenApi.Models.Model.WorkspaceCreateRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        IReadOnlyDictionary<string, string>? pathParams = null;
        var json = await _root._transport.RequestAsync("POST", "/v1/workspaces", pathParams, options);
        return JsonSerializer.Deserialize<WorkspaceSingleResponse>(json.GetRawText())!;
    }
    public async Task<DeleteV1WorkspacesByIdResponse> DeleteV1WorkspacesByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("DELETE", "/v1/workspaces/{id}", pathParams, options);
        return JsonSerializer.Deserialize<DeleteV1WorkspacesByIdResponse>(json.GetRawText())!;
    }
    public async Task<WorkspaceGetResponse> GetV1WorkspacesByIdAsync(string id, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = options.Body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("GET", "/v1/workspaces/{id}", pathParams, options);
        return JsonSerializer.Deserialize<WorkspaceGetResponse>(json.GetRawText())!;
    }
    public async Task<WorkspaceUpdateResponse> PutV1WorkspacesByIdAsync(string id, Notifique.OpenApi.Models.Model.WorkspaceUpdateRequest? body = null, ApiRequestOptions? options = null)
    {
        options ??= new ApiRequestOptions();
        var query = options.Query != null ? new Dictionary<string, string>(options.Query) : new Dictionary<string, string>();
        options = new ApiRequestOptions { Query = query, Body = body, IdempotencyKey = options.IdempotencyKey };
        var pathParams = new Dictionary<string, string> { ["id"] = id };
        var json = await _root._transport.RequestAsync("PUT", "/v1/workspaces/{id}", pathParams, options);
        return JsonSerializer.Deserialize<WorkspaceUpdateResponse>(json.GetRawText())!;
    }
}

}