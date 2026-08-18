<?php
namespace Notifique\Generated;
use Notifique\Notifique;

final class TypedGeneratedApi {
    public function __construct(private Notifique $client) {}
    public function wellKnown(): WellKnownApi { return new WellKnownApi($this->client); }
    public function oauth(): OauthApi { return new OauthApi($this->client); }
    public function public(): PublicApi { return new PublicApi($this->client); }
    public function aiWebWidget(): AiWebWidgetApi { return new AiWebWidgetApi($this->client); }
    public function assistants(): AssistantsApi { return new AssistantsApi($this->client); }
    public function automations(): AutomationsApi { return new AutomationsApi($this->client); }
    public function campaigns(): CampaignsApi { return new CampaignsApi($this->client); }
    public function contacts(): ContactsApi { return new ContactsApi($this->client); }
    public function conversions(): ConversionsApi { return new ConversionsApi($this->client); }
    public function email(): EmailApi { return new EmailApi($this->client); }
    public function events(): EventsApi { return new EventsApi($this->client); }
    public function forms(): FormsApi { return new FormsApi($this->client); }
    public function httpTools(): HttpToolsApi { return new HttpToolsApi($this->client); }
    public function instagram(): InstagramApi { return new InstagramApi($this->client); }
    public function knowledgeBases(): KnowledgeBasesApi { return new KnowledgeBasesApi($this->client); }
    public function logs(): LogsApi { return new LogsApi($this->client); }
    public function mcpConnections(): McpConnectionsApi { return new McpConnectionsApi($this->client); }
    public function meta(): MetaApi { return new MetaApi($this->client); }
    public function metrics(): MetricsApi { return new MetricsApi($this->client); }
    public function notify(): NotifyApi { return new NotifyApi($this->client); }
    public function phoneNumbers(): PhoneNumbersApi { return new PhoneNumbersApi($this->client); }
    public function pipelines(): PipelinesApi { return new PipelinesApi($this->client); }
    public function platform(): PlatformApi { return new PlatformApi($this->client); }
    public function pricing(): PricingApi { return new PricingApi($this->client); }
    public function push(): PushApi { return new PushApi($this->client); }
    public function rcs(): RcsApi { return new RcsApi($this->client); }
    public function report(): ReportApi { return new ReportApi($this->client); }
    public function segments(): SegmentsApi { return new SegmentsApi($this->client); }
    public function sendingPools(): SendingPoolsApi { return new SendingPoolsApi($this->client); }
    public function shortLinks(): ShortLinksApi { return new ShortLinksApi($this->client); }
    public function sms(): SmsApi { return new SmsApi($this->client); }
    public function suppressions(): SuppressionsApi { return new SuppressionsApi($this->client); }
    public function tags(): TagsApi { return new TagsApi($this->client); }
    public function telegram(): TelegramApi { return new TelegramApi($this->client); }
    public function templates(): TemplatesApi { return new TemplatesApi($this->client); }
    public function topics(): TopicsApi { return new TopicsApi($this->client); }
    public function voice(): VoiceApi { return new VoiceApi($this->client); }
    public function webhooks(): WebhooksApi { return new WebhooksApi($this->client); }
    public function whatsapp(): WhatsappApi { return new WhatsappApi($this->client); }
    public function workspaces(): WorkspacesApi { return new WorkspacesApi($this->client); }
}

final class WellKnownApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfOauthGetJwksResponse */
    public function getJwks(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/.well-known/jwks.json', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthGetAuthorizationServerMetadataResponse */
    public function getAuthorizationServerMetadata(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/.well-known/oauth-authorization-server', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthGetProtectedResourceMetadataResponse */
    public function getProtectedResourceMetadata(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/.well-known/oauth-protected-resource', $options['body'] ?? null, $options);
    }
}
final class OauthAppsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfOauthRotateWorkspaceAppSecretResponse */
    public function rotateWorkspaceAppSecret(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/oauth/apps/{id}/rotate-secret');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class OauthConnectionsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfOauthRevokeConnectionResponse */
    public function revokeConnection(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/oauth/connections/{id}/revoke');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class OauthApi {
    public function __construct(private Notifique $client) {}
    public function apps(): OauthAppsApi { return new OauthAppsApi($this->client); }
    public function connections(): OauthConnectionsApi { return new OauthConnectionsApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfOauthAuthorizeResponse */
    public function authorize(?string $client_id = null, ?string $response_type = null, ?string $redirect_uri = null, ?string $scope = null, ?string $state = null, ?string $code_challenge = null, ?string $code_challenge_method = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($client_id !== null) { $opts['query']['client_id'] = $client_id; }
        if ($response_type !== null) { $opts['query']['response_type'] = $response_type; }
        if ($redirect_uri !== null) { $opts['query']['redirect_uri'] = $redirect_uri; }
        if ($scope !== null) { $opts['query']['scope'] = $scope; }
        if ($state !== null) { $opts['query']['state'] = $state; }
        if ($code_challenge !== null) { $opts['query']['code_challenge'] = $code_challenge; }
        if ($code_challenge_method !== null) { $opts['query']['code_challenge_method'] = $code_challenge_method; }
        return $this->client->apiRequest('GET', '/oauth/authorize', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthRegisterClientResponse */
    public function registerClient(\Notifique\OpenApi\Model\NtfOauthClientRegistration $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/oauth/register', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthRevokeResponse */
    public function revoke(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/oauth/revoke', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthTokenResponse */
    public function token(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/oauth/token', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthListWorkspaceAppsResponse */
    public function listWorkspaceApps(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/oauth/apps', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthCreateWorkspaceAppResponse */
    public function createWorkspaceApp(\Notifique\OpenApi\Model\NtfOauthWorkspaceAppCreate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/oauth/apps', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthDeleteWorkspaceAppResponse */
    public function deleteWorkspaceApp(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/oauth/apps/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthGetWorkspaceAppResponse */
    public function getWorkspaceApp(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/oauth/apps/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthUpdateWorkspaceAppResponse */
    public function updateWorkspaceApp(string $id, \Notifique\OpenApi\Model\NtfOauthWorkspaceAppPatch $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/oauth/apps/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfOauthListConnectionsResponse */
    public function listConnections(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/oauth/connections', $options['body'] ?? null, $options);
    }
}
final class PublicAiWidgetApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\WidgetConfigResponse */
    public function getConfig(string $publicKey, array $options = []): array {
        $opts = $options;
        $path = str_replace('{publicKey}', Notifique::encodePathSegment($publicKey), '/public/ai-widget/{publicKey}/config');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\MessageResponse */
    public function sendMessage(string $publicKey, \Notifique\OpenApi\Model\SendMessageBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{publicKey}', Notifique::encodePathSegment($publicKey), '/public/ai-widget/{publicKey}/message');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\PollMessagesResponse */
    public function pollMessages(string $publicKey, ?string $sessionToken = null, ?string $afterParam = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($sessionToken !== null) { $opts['query']['sessionToken'] = $sessionToken; }
        if ($afterParam !== null) { $opts['query']['after'] = $afterParam; }
        $path = str_replace('{publicKey}', Notifique::encodePathSegment($publicKey), '/public/ai-widget/{publicKey}/messages');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\SessionResponse */
    public function createSession(string $publicKey, \Notifique\OpenApi\Model\CreateSessionBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{publicKey}', Notifique::encodePathSegment($publicKey), '/public/ai-widget/{publicKey}/session');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWidgetRequestOtpResponse */
    public function requestOtp(string $publicKey, array $options = []): array {
        $opts = $options;
        $path = str_replace('{publicKey}', Notifique::encodePathSegment($publicKey), '/public/ai-widget/{publicKey}/session/otp/request');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWidgetVerifyOtpResponse */
    public function verifyOtp(string $publicKey, array $options = []): array {
        $opts = $options;
        $path = str_replace('{publicKey}', Notifique::encodePathSegment($publicKey), '/public/ai-widget/{publicKey}/session/otp/verify');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class PublicApi {
    public function __construct(private Notifique $client) {}
    public function aiWidget(): PublicAiWidgetApi { return new PublicAiWidgetApi($this->client); }
}
final class AiWebWidgetWidgetsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfWidgetAdminDuplicateResponse */
    public function duplicate(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/ai-web-widget/widgets/{id}/duplicate');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWidgetAdminRotateHmacResponse */
    public function rotateHmac(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/ai-web-widget/widgets/{id}/rotate-identity-signing-secret');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWidgetAdminRotateKeyResponse */
    public function rotateKey(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/ai-web-widget/widgets/{id}/rotate-key');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class AiWebWidgetApi {
    public function __construct(private Notifique $client) {}
    public function widgets(): AiWebWidgetWidgetsApi { return new AiWebWidgetWidgetsApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfWidgetAdminMessagesResponse */
    public function messages(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/ai-web-widget/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWidgetAdminListResponse */
    public function list(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/ai-web-widget/widgets', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWidgetAdminCreateResponse */
    public function create(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/ai-web-widget/widgets', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWidgetAdminDeleteResponse */
    public function delete(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/ai-web-widget/widgets/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWidgetAdminGetResponse */
    public function get(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/ai-web-widget/widgets/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWidgetAdminPatchResponse */
    public function patch(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/ai-web-widget/widgets/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
}
final class AssistantsInvokeApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsInvokeMessagesResponse */
    public function assistantsInvokeMessages(string $id, ?string $threadId = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($threadId !== null) { $opts['query']['threadId'] = $threadId; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/assistants/{id}/invoke/messages');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class AssistantsApi {
    public function __construct(private Notifique $client) {}
    public function invoke(): AssistantsInvokeApi { return new AssistantsInvokeApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsListResponse */
    public function assistantsList(?string $page = null, ?string $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        return $this->client->apiRequest('GET', '/v1/assistants', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsCreateResponse */
    public function assistantsCreate(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/assistants', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsDeleteResponse */
    public function assistantsDelete(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/assistants/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsGetResponse */
    public function assistantsGet(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/assistants/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsUpdateResponse */
    public function assistantsUpdate(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/assistants/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsListHttpBindingsResponse */
    public function assistantsListHttpBindings(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/assistants/{id}/http-tool-bindings');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsCreateHttpBindingResponse */
    public function assistantsCreateHttpBinding(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/assistants/{id}/http-tool-bindings');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsDeleteHttpBindingResponse */
    public function assistantsDeleteHttpBinding(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('DELETE', '/v1/assistants/{id}/http-tool-bindings/{bindingId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsInvokeResponse */
    public function assistantsInvoke(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/assistants/{id}/invoke');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsListMcpBindingsResponse */
    public function assistantsListMcpBindings(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/assistants/{id}/mcp-bindings');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsCreateMcpBindingResponse */
    public function assistantsCreateMcpBinding(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/assistants/{id}/mcp-bindings');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsDeleteMcpBindingResponse */
    public function assistantsDeleteMcpBinding(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('DELETE', '/v1/assistants/{id}/mcp-bindings/{bindingId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAssistantsUpdateMcpBindingResponse */
    public function assistantsUpdateMcpBinding(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('PATCH', '/v1/assistants/{id}/mcp-bindings/{bindingId}', $options['body'] ?? null, $options);
    }
}
final class AutomationsBatchApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfAutoBatchDeleteResponse */
    public function batchDelete(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/automations/batch/delete', $options['body'] ?? null, $options);
    }
}
final class AutomationsApi {
    public function __construct(private Notifique $client) {}
    public function batch(): AutomationsBatchApi { return new AutomationsBatchApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfAutoListAutomationsResponse */
    public function listAutomations(?string $page = null, ?string $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        return $this->client->apiRequest('GET', '/v1/automations', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoCreateAutomationResponse */
    public function createAutomation(\Notifique\OpenApi\Model\NtfAutoAutomationCreateBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/automations', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoDeleteAutomationResponse */
    public function deleteAutomation(string $automationId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{automationId}', Notifique::encodePathSegment($automationId), '/v1/automations/{automationId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoGetAutomationResponse */
    public function getAutomation(string $automationId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{automationId}', Notifique::encodePathSegment($automationId), '/v1/automations/{automationId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoPatchAutomationResponse */
    public function patchAutomation(string $automationId, \Notifique\OpenApi\Model\NtfAutoAutomationPatchBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{automationId}', Notifique::encodePathSegment($automationId), '/v1/automations/{automationId}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoDuplicateResponse */
    public function duplicate(string $automationId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{automationId}', Notifique::encodePathSegment($automationId), '/v1/automations/{automationId}/duplicate');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoListRunsResponse */
    public function listRuns(string $automationId, ?string $page = null, ?string $limit = null, ?string $status = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        $path = str_replace('{automationId}', Notifique::encodePathSegment($automationId), '/v1/automations/{automationId}/runs');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoGetRunResponse */
    public function getRun(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/automations/{automationId}/runs/{runId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoStopAutomationResponse */
    public function stopAutomation(string $automationId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{automationId}', Notifique::encodePathSegment($automationId), '/v1/automations/{automationId}/stop');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoTestTriggerResponse */
    public function testTrigger(string $automationId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{automationId}', Notifique::encodePathSegment($automationId), '/v1/automations/{automationId}/test-trigger');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoWebhookSecretResponse */
    public function webhookSecret(string $automationId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{automationId}', Notifique::encodePathSegment($automationId), '/v1/automations/{automationId}/webhook-secret');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoAiComposeResponse */
    public function aiCompose(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/automations/ai-compose', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoPostCampaignAgentResponse */
    public function postCampaignAgent(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/automations/post-campaign-agent', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoQuickChatbotResponse */
    public function quickChatbot(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/automations/quick-chatbot', $options['body'] ?? null, $options);
    }
}
final class CampaignsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfContactCampaignListResponse */
    public function getV1Campaigns(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/campaigns', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactCampaignOneResponse */
    public function postV1Campaigns(\Notifique\OpenApi\Model\NtfContactCampaignCreate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/campaigns', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactDeleteV1CampaignResponse */
    public function deleteV1Campaign(string $campaignId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{campaignId}', Notifique::encodePathSegment($campaignId), '/v1/campaigns/{campaignId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactCampaignOneResponse */
    public function getV1CampaignById(string $campaignId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{campaignId}', Notifique::encodePathSegment($campaignId), '/v1/campaigns/{campaignId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactCampaignOneResponse */
    public function patchV1Campaign(string $campaignId, \Notifique\OpenApi\Model\NtfContactCampaignPatch $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{campaignId}', Notifique::encodePathSegment($campaignId), '/v1/campaigns/{campaignId}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactCampaignCancelResponse */
    public function postV1CampaignCancel(string $campaignId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{campaignId}', Notifique::encodePathSegment($campaignId), '/v1/campaigns/{campaignId}/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactCampaignRecipientsResponse */
    public function getV1CampaignRecipients(string $campaignId, ?string $channel = null, ?string $status = null, ?string $runId = null, ?int $page = null, ?int $pageSize = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($channel !== null) { $opts['query']['channel'] = $channel; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($runId !== null) { $opts['query']['runId'] = $runId; }
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($pageSize !== null) { $opts['query']['pageSize'] = $pageSize; }
        $path = str_replace('{campaignId}', Notifique::encodePathSegment($campaignId), '/v1/campaigns/{campaignId}/recipients');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactCampaignRunResponse */
    public function postV1CampaignRun(string $campaignId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{campaignId}', Notifique::encodePathSegment($campaignId), '/v1/campaigns/{campaignId}/run');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactCampaignRunPreviewResponse */
    public function getV1CampaignRunPreview(string $campaignId, ?string $channels = null, ?string $excludeAlreadySent = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($channels !== null) { $opts['query']['channels'] = $channels; }
        if ($excludeAlreadySent !== null) { $opts['query']['excludeAlreadySent'] = $excludeAlreadySent; }
        $path = str_replace('{campaignId}', Notifique::encodePathSegment($campaignId), '/v1/campaigns/{campaignId}/run-preview');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactCampaignStatsResponse */
    public function getV1CampaignStats(string $campaignId, ?string $runId = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($runId !== null) { $opts['query']['runId'] = $runId; }
        $path = str_replace('{campaignId}', Notifique::encodePathSegment($campaignId), '/v1/campaigns/{campaignId}/stats');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class ContactsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfContactGetV1ContactsResponse */
    public function getV1Contacts(?string $page = null, ?string $limit = null, ?string $search = null, ?string $tagId = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        if ($tagId !== null) { $opts['query']['tagId'] = $tagId; }
        return $this->client->apiRequest('GET', '/v1/contacts', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactPostV1ContactsResponse */
    public function postV1Contacts(\Notifique\OpenApi\Model\NtfContactContactCreate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/contacts', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactDeleteV1ContactResponse */
    public function deleteV1Contact(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/contacts/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactGetV1ContactResponse */
    public function getV1Contact(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/contacts/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactPutV1ContactResponse */
    public function putV1Contact(string $id, \Notifique\OpenApi\Model\NtfContactContactUpdate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/contacts/{id}');
        return $this->client->apiRequest('PUT', $path, $options['body'] ?? null, $options);
    }
}
final class ConversionsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfConversionsPostV1ConversionsResponse */
    public function postV1Conversions(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/conversions', $options['body'] ?? null, $options);
    }
}
final class EmailDomainsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfEmailExpandEmailDomainProvidersResponse */
    public function postV1EmailDomainExpandProviders(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/email/domains/{id}/expand-providers');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfEmailVerifyEmailDomainResponse */
    public function postV1EmailDomainVerify(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/email/domains/{id}/verify');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class EmailMessagesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfEmailCancelEmailResponse */
    public function postV1EmailCancel(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/email/messages/{id}/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class EmailApi {
    public function __construct(private Notifique $client) {}
    public function domains(): EmailDomainsApi { return new EmailDomainsApi($this->client); }
    public function messages(): EmailMessagesApi { return new EmailMessagesApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfEmailListEmailDomainsResponse */
    public function getV1EmailDomains(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/email/domains', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfEmailCreateEmailDomainResponse */
    public function postV1EmailDomains(\Notifique\OpenApi\Model\NtfEmailCreateEmailDomainRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/email/domains', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfEmailEmailDomainResponse */
    public function getV1EmailDomainById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/email/domains/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfEmailGetV1EmailInboundResponse */
    public function getV1EmailInbound(?string $page = null, ?string $limit = null, ?string $q = null, ?string $domainId = null, ?string $dateFrom = null, ?string $dateTo = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($q !== null) { $opts['query']['q'] = $q; }
        if ($domainId !== null) { $opts['query']['domainId'] = $domainId; }
        if ($dateFrom !== null) { $opts['query']['dateFrom'] = $dateFrom; }
        if ($dateTo !== null) { $opts['query']['dateTo'] = $dateTo; }
        return $this->client->apiRequest('GET', '/v1/email/inbound', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfEmailGetV1EmailInboundByIdResponse */
    public function getV1EmailInboundById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/email/inbound/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfEmailGetV1EmailMessagesResponse */
    public function getV1EmailMessages(?string $page = null, ?string $limit = null, ?string $fromDate = null, ?string $toDate = null, ?string $status = null, ?string $emailDomainId = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($fromDate !== null) { $opts['query']['fromDate'] = $fromDate; }
        if ($toDate !== null) { $opts['query']['toDate'] = $toDate; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($emailDomainId !== null) { $opts['query']['emailDomainId'] = $emailDomainId; }
        return $this->client->apiRequest('GET', '/v1/email/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfEmailSendEmailResponse */
    public function postV1EmailSend(\Notifique\OpenApi\Model\NtfEmailSendEmailRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/email/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfEmailEmailStatusResponse */
    public function getV1EmailById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/email/messages/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class EventsBatchApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfAutoBatchDeleteEventsResponse */
    public function batchDeleteEvents(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/events/batch/delete', $options['body'] ?? null, $options);
    }
}
final class EventsApi {
    public function __construct(private Notifique $client) {}
    public function batch(): EventsBatchApi { return new EventsBatchApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfAutoListEventsResponse */
    public function listEvents(?string $page = null, ?string $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        return $this->client->apiRequest('GET', '/v1/events', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoCreateEventResponse */
    public function createEvent(\Notifique\OpenApi\Model\NtfAutoEventCreateBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/events', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoDeleteEventResponse */
    public function deleteEvent(string $eventId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{eventId}', Notifique::encodePathSegment($eventId), '/v1/events/{eventId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoGetEventResponse */
    public function getEvent(string $eventId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{eventId}', Notifique::encodePathSegment($eventId), '/v1/events/{eventId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoPatchEventResponse */
    public function patchEvent(string $eventId, \Notifique\OpenApi\Model\NtfAutoEventPatchBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{eventId}', Notifique::encodePathSegment($eventId), '/v1/events/{eventId}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoSendEventResponse */
    public function sendEvent(\Notifique\OpenApi\Model\NtfAutoEventSendBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/events/send', $options['body'] ?? null, $options);
    }
}
final class FormsListsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfAddonsFormSubscriptionCollectionEnvelope */
    public function getV1FormsListSubscriptions(string $id, ?string $page = null, ?string $limit = null, ?string $status = null, ?string $search = null, ?string $subscribedFrom = null, ?string $subscribedTo = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        if ($subscribedFrom !== null) { $opts['query']['subscribedFrom'] = $subscribedFrom; }
        if ($subscribedTo !== null) { $opts['query']['subscribedTo'] = $subscribedTo; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/forms/lists/{id}/subscriptions');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsDeleteV1FormsSubscriptionResponse */
    public function deleteV1FormsSubscription(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('DELETE', '/v1/forms/lists/{id}/subscriptions/{subscriptionId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsGetV1FormsSubscriptionExportResponse */
    public function getV1FormsSubscriptionExport(string $id, ?string $status = null, ?string $search = null, ?string $subscribedFrom = null, ?string $subscribedTo = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        if ($subscribedFrom !== null) { $opts['query']['subscribedFrom'] = $subscribedFrom; }
        if ($subscribedTo !== null) { $opts['query']['subscribedTo'] = $subscribedTo; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/forms/lists/{id}/subscriptions/export');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsGetV1FormsSubscriptionStatsResponse */
    public function getV1FormsSubscriptionStats(string $id, ?int $trendDays = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($trendDays !== null) { $opts['query']['trendDays'] = $trendDays; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/forms/lists/{id}/subscriptions/stats');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class FormsSubscriptionsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfAddonsNewsletterCancelEnvelope */
    public function postV1FormsSubscriptionCancel(string $id, \Notifique\OpenApi\Model\NtfAddonsNewsletterCancelRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/forms/subscriptions/{id}/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsFormConfirmEnvelope */
    public function postV1FormsSubscriptionsConfirm(\Notifique\OpenApi\Model\NtfAddonsFormConfirmRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/forms/subscriptions/confirm', $options['body'] ?? null, $options);
    }
}
final class FormsApi {
    public function __construct(private Notifique $client) {}
    public function lists(): FormsListsApi { return new FormsListsApi($this->client); }
    public function subscriptions(): FormsSubscriptionsApi { return new FormsSubscriptionsApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfAddonsFormListCollectionEnvelope */
    public function getV1FormsLists(?string $page = null, ?string $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        return $this->client->apiRequest('GET', '/v1/forms/lists', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsFormListEnvelope */
    public function postV1FormsLists(\Notifique\OpenApi\Model\NtfAddonsCreateFormListRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/forms/lists', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsFormDeleteEnvelope */
    public function deleteV1FormsList(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/forms/lists/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsFormListEnvelope */
    public function getV1FormsList(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/forms/lists/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsFormListPatchEnvelope */
    public function patchV1FormsList(string $id, \Notifique\OpenApi\Model\NtfAddonsPatchFormListRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/forms/lists/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsGetV1FormsSubscriptionsAllResponse */
    public function getV1FormsSubscriptionsAll(?string $page = null, ?string $limit = null, ?string $listId = null, ?string $status = null, ?string $search = null, ?string $subscribedFrom = null, ?string $subscribedTo = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($listId !== null) { $opts['query']['listId'] = $listId; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        if ($subscribedFrom !== null) { $opts['query']['subscribedFrom'] = $subscribedFrom; }
        if ($subscribedTo !== null) { $opts['query']['subscribedTo'] = $subscribedTo; }
        return $this->client->apiRequest('GET', '/v1/forms/subscriptions', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAddonsFormSubscribeEnvelope */
    public function postV1FormsSubscriptions(\Notifique\OpenApi\Model\NtfAddonsFormSubscribeRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/forms/subscriptions', $options['body'] ?? null, $options);
    }
}
final class HttpToolsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfAutoHttpListResponse */
    public function httpList(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/http-tools', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoHttpCreateResponse */
    public function httpCreate(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/http-tools', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoHttpDeleteResponse */
    public function httpDelete(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/http-tools/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoHttpGetResponse */
    public function httpGet(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/http-tools/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoHttpUpdateResponse */
    public function httpUpdate(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/http-tools/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
}
final class InstagramCommentsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfIgHideCommentResponse */
    public function hideComment(string $commentId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{commentId}', Notifique::encodePathSegment($commentId), '/v1/instagram/comments/{commentId}/hide');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgReplyCommentResponse */
    public function replyComment(string $commentId, \Notifique\OpenApi\Model\NtfIgReplyCommentBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{commentId}', Notifique::encodePathSegment($commentId), '/v1/instagram/comments/{commentId}/reply');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class InstagramInstancesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfIgResolveChallengeResponse */
    public function resolveChallenge(string $instanceId, \Notifique\OpenApi\Model\NtfIgResolveChallengeBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/instagram/instances/{instanceId}/challenge/resolve');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgConnectPageStatusResponse */
    public function getConnectPage(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/instagram/instances/{instanceId}/connect-page');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgConnectPageDisableResponse */
    public function disableConnectPage(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/instagram/instances/{instanceId}/connect-page/disable');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgConnectPageEnableResponse */
    public function enableConnectPage(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/instagram/instances/{instanceId}/connect-page/enable');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgConnectPageEnableResponse */
    public function rotateConnectPage(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/instagram/instances/{instanceId}/connect-page/rotate-secret');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgConnectionStatus */
    public function getConnection(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/instagram/instances/{instanceId}/connection');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgDisconnectInstanceResponse */
    public function disconnectInstance(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/instagram/instances/{instanceId}/disconnect');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class InstagramMessagesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfIgCancelMessageResponse */
    public function cancelMessage(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/instagram/messages/{messageId}/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgEditMessageResponse */
    public function editMessage(string $messageId, \Notifique\OpenApi\Model\NtfIgEditMessageBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/instagram/messages/{messageId}/edit');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgListInboundResponse */
    public function listInbound(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/instagram/messages/inbound', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgGetInboundResponse */
    public function getInbound(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/instagram/messages/inbound/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgPostInboundMediaResponse */
    public function postInboundMedia(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/instagram/messages/inbound/{id}/media');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgGetInboundMediaDownloadResponse */
    public function getInboundMediaDownload(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/instagram/messages/inbound/{id}/media/download');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class InstagramApi {
    public function __construct(private Notifique $client) {}
    public function comments(): InstagramCommentsApi { return new InstagramCommentsApi($this->client); }
    public function instances(): InstagramInstancesApi { return new InstagramInstancesApi($this->client); }
    public function messages(): InstagramMessagesApi { return new InstagramMessagesApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfIgListCommentsResponse */
    public function listComments(?string $instanceId = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($instanceId !== null) { $opts['query']['instanceId'] = $instanceId; }
        return $this->client->apiRequest('GET', '/v1/instagram/comments', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgDeleteCommentResponse */
    public function deleteComment(string $commentId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{commentId}', Notifique::encodePathSegment($commentId), '/v1/instagram/comments/{commentId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgGetCommentResponse */
    public function getComment(string $commentId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{commentId}', Notifique::encodePathSegment($commentId), '/v1/instagram/comments/{commentId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgListInstancesResponse */
    public function listInstances(?string $page = null, ?string $limit = null, ?string $status = null, ?string $search = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        return $this->client->apiRequest('GET', '/v1/instagram/instances', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgCreateInstanceResponse */
    public function createInstance(\Notifique\OpenApi\Model\NtfIgCreateInstanceBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/instagram/instances', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgDeleteInstanceResponse */
    public function deleteInstance(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/instagram/instances/{instanceId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgInstanceDetail */
    public function getInstance(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/instagram/instances/{instanceId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgListMessagesResponse */
    public function listMessages(?string $page = null, ?string $limit = null, ?string $instanceIds = null, ?string $status = null, ?string $typeParam = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($instanceIds !== null) { $opts['query']['instanceIds'] = $instanceIds; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($typeParam !== null) { $opts['query']['type'] = $typeParam; }
        return $this->client->apiRequest('GET', '/v1/instagram/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgSendMessageResponse */
    public function sendMessage(\Notifique\OpenApi\Model\NtfIgSendMessageBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/instagram/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgDeleteMessageResponse */
    public function deleteMessage(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/instagram/messages/{messageId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfIgGetMessageResponse */
    public function getMessage(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/instagram/messages/{messageId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class KnowledgeBasesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfAutoKbListResponse */
    public function kbList(?string $page = null, ?string $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        return $this->client->apiRequest('GET', '/v1/knowledge-bases', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoKbCreateResponse */
    public function kbCreate(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/knowledge-bases', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoKbDeleteResponse */
    public function kbDelete(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/knowledge-bases/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoKbGetResponse */
    public function kbGet(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/knowledge-bases/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoKbUpdateResponse */
    public function kbUpdate(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/knowledge-bases/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoKbListDocsResponse */
    public function kbListDocs(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/knowledge-bases/{id}/documents');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoKbCreateDocResponse */
    public function kbCreateDoc(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/knowledge-bases/{id}/documents');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoKbDeleteDocResponse */
    public function kbDeleteDoc(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('DELETE', '/v1/knowledge-bases/{id}/documents/{docId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoKbGetDocResponse */
    public function kbGetDoc(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/knowledge-bases/{id}/documents/{docId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoKbUpdateDocResponse */
    public function kbUpdateDoc(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('PATCH', '/v1/knowledge-bases/{id}/documents/{docId}', $options['body'] ?? null, $options);
    }
}
final class LogsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\LogsListResponse */
    public function getV1Logs(?int $page = null, ?int $limit = null, ?string $status = null, ?string $startDate = null, ?string $endDate = null, ?string $method = null, ?string $apiKeyId = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($startDate !== null) { $opts['query']['startDate'] = $startDate; }
        if ($endDate !== null) { $opts['query']['endDate'] = $endDate; }
        if ($method !== null) { $opts['query']['method'] = $method; }
        if ($apiKeyId !== null) { $opts['query']['apiKeyId'] = $apiKeyId; }
        return $this->client->apiRequest('GET', '/v1/logs', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\GetV1LogsByIdResponse */
    public function getV1LogsById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/logs/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class McpConnectionsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfAutoMcpListResponse */
    public function mcpList(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/mcp-connections', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoMcpCreateResponse */
    public function mcpCreate(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/mcp-connections', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoMcpDeleteResponse */
    public function mcpDelete(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/mcp-connections/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoMcpGetResponse */
    public function mcpGet(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/mcp-connections/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoMcpUpdateResponse */
    public function mcpUpdate(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/mcp-connections/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfAutoMcpRefreshManifestResponse */
    public function mcpRefreshManifest(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/mcp-connections/{id}/refresh-manifest');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class MetaApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfContactGetV1MetaContactLocalesResponse */
    public function getV1MetaContactLocales(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/meta/contact-locales', $options['body'] ?? null, $options);
    }
}
final class MetricsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPlatformGetMetricsOverviewResponse */
    public function getMetricsOverview(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/metrics/overview', $options['body'] ?? null, $options);
    }
}
final class NotifyApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPlatformPostNotifyResponse */
    public function postNotify(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/notify', $options['body'] ?? null, $options);
    }
}
final class PhoneNumbersOrdersApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPhoneRegDocumentResponse */
    public function regDocument(string $orderId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{orderId}', Notifique::encodePathSegment($orderId), '/v1/phone-numbers/orders/{orderId}/regulatory/documents');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneRegStatusResponse */
    public function regStatus(string $orderId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{orderId}', Notifique::encodePathSegment($orderId), '/v1/phone-numbers/orders/{orderId}/regulatory/status');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneRegSubmitResponse */
    public function regSubmit(string $orderId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{orderId}', Notifique::encodePathSegment($orderId), '/v1/phone-numbers/orders/{orderId}/regulatory/submit');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneReplacementOptionsResponse */
    public function replacementOptions(string $orderId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{orderId}', Notifique::encodePathSegment($orderId), '/v1/phone-numbers/orders/{orderId}/replacement-options');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneSelectReplacementResponse */
    public function selectReplacement(string $orderId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{orderId}', Notifique::encodePathSegment($orderId), '/v1/phone-numbers/orders/{orderId}/select-replacement-number');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class PhoneNumbersRegulatoryApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPhoneRegProfileResponse */
    public function regProfile(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('PUT', '/v1/phone-numbers/regulatory/profile', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneRegRequirementsResponse */
    public function regRequirements(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/phone-numbers/regulatory/requirements', $options['body'] ?? null, $options);
    }
}
final class PhoneNumbersApi {
    public function __construct(private Notifique $client) {}
    public function orders(): PhoneNumbersOrdersApi { return new PhoneNumbersOrdersApi($this->client); }
    public function regulatory(): PhoneNumbersRegulatoryApi { return new PhoneNumbersRegulatoryApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfPhoneListEnvelope */
    public function getV1PhoneNumbers(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/phone-numbers', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneSingleEnvelope */
    public function getV1PhoneNumbersById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/phone-numbers/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneSingleEnvelope */
    public function patchV1PhoneNumbersById(string $id, \Notifique\OpenApi\Model\NtfPhoneUpdateBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/phone-numbers/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneGetV1PhoneNumbersAvailableResponse */
    public function getV1PhoneNumbersAvailable(?string $countryCode = null, ?string $phoneNumberType = null, ?string $areaCode = null, ?string $contains = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($countryCode !== null) { $opts['query']['countryCode'] = $countryCode; }
        if ($phoneNumberType !== null) { $opts['query']['phoneNumberType'] = $phoneNumberType; }
        if ($areaCode !== null) { $opts['query']['areaCode'] = $areaCode; }
        if ($contains !== null) { $opts['query']['contains'] = $contains; }
        return $this->client->apiRequest('GET', '/v1/phone-numbers/available', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneConfigResponse */
    public function config(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/phone-numbers/config', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneCreateOrderResponse */
    public function createOrder(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/phone-numbers/orders', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPhoneGetOrderResponse */
    public function getOrder(string $orderId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{orderId}', Notifique::encodePathSegment($orderId), '/v1/phone-numbers/orders/{orderId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class PipelinesBoardsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPipeCreateCardResponse */
    public function createCard(string $boardId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{boardId}', Notifique::encodePathSegment($boardId), '/v1/pipelines/boards/{boardId}/cards');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPipeReplaceColumnsResponse */
    public function replaceColumns(string $boardId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{boardId}', Notifique::encodePathSegment($boardId), '/v1/pipelines/boards/{boardId}/columns');
        return $this->client->apiRequest('PUT', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPipeBoardOverviewResponse */
    public function boardOverview(string $boardId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{boardId}', Notifique::encodePathSegment($boardId), '/v1/pipelines/boards/{boardId}/overview');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class PipelinesCardsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPipeMoveCardResponse */
    public function moveCard(string $cardId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{cardId}', Notifique::encodePathSegment($cardId), '/v1/pipelines/cards/{cardId}/move');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class PipelinesContactsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPipeContactCardsResponse */
    public function contactCards(string $contactId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{contactId}', Notifique::encodePathSegment($contactId), '/v1/pipelines/contacts/{contactId}/cards');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class PipelinesApi {
    public function __construct(private Notifique $client) {}
    public function boards(): PipelinesBoardsApi { return new PipelinesBoardsApi($this->client); }
    public function cards(): PipelinesCardsApi { return new PipelinesCardsApi($this->client); }
    public function contacts(): PipelinesContactsApi { return new PipelinesContactsApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfPipeListBoardsResponse */
    public function listBoards(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/pipelines/boards', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPipeCreateBoardResponse */
    public function createBoard(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/pipelines/boards', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPipeGetBoardResponse */
    public function getBoard(string $boardId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{boardId}', Notifique::encodePathSegment($boardId), '/v1/pipelines/boards/{boardId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPipePatchBoardResponse */
    public function patchBoard(string $boardId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{boardId}', Notifique::encodePathSegment($boardId), '/v1/pipelines/boards/{boardId}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPipePatchCardResponse */
    public function patchCard(string $cardId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{cardId}', Notifique::encodePathSegment($cardId), '/v1/pipelines/cards/{cardId}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
}
final class PlatformApiKeysApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPlatformRevokeApiKeyResponse */
    public function revokeApiKey(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/api-keys/{id}/revoke');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class PlatformWorkspacesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPlatformGetBalanceResponse */
    public function getBalance(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/balance');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformRechargeBalanceResponse */
    public function rechargeBalance(string $id, \Notifique\OpenApi\Model\NtfPlatformRechargeBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/balance/recharge');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformCreditsUsageResponse */
    public function getCreditsUsage(string $id, ?string $page = null, ?string $limit = null, ?string $chargedAs = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($chargedAs !== null) { $opts['query']['chargedAs'] = $chargedAs; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/credits/usage');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformInvitesListResponse */
    public function listInvites(string $id, ?string $page = null, ?string $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/invites');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformCreateInviteResponse */
    public function createInvite(string $id, \Notifique\OpenApi\Model\NtfPlatformInviteBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/invites');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformCancelInviteResponse */
    public function cancelInvite(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('DELETE', '/v1/platform/workspaces/{id}/invites/{inviteId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformMembersListResponse */
    public function listMembers(string $id, ?string $page = null, ?string $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/members');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformRemoveMemberResponse */
    public function removeMember(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('DELETE', '/v1/platform/workspaces/{id}/members/{userId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformListPaymentMethodsResponse */
    public function listPaymentMethods(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/payment-methods');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformCreatePaymentMethodResponse */
    public function createPaymentMethod(string $id, \Notifique\OpenApi\Model\NtfPlatformPaymentMethodCreate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/payment-methods');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformDeletePaymentMethodResponse */
    public function deletePaymentMethod(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('DELETE', '/v1/platform/workspaces/{id}/payment-methods/{pmId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformUpdatePaymentMethodResponse */
    public function updatePaymentMethod(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('PATCH', '/v1/platform/workspaces/{id}/payment-methods/{pmId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformCancelSubscriptionResponse */
    public function cancelSubscription(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/subscription');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformSubscriptionResponse */
    public function getWorkspaceSubscription(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/subscription');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformSubscribeWorkspaceResponse */
    public function subscribeWorkspace(string $id, \Notifique\OpenApi\Model\NtfPlatformSubscribeBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/workspaces/{id}/subscription');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class PlatformApi {
    public function __construct(private Notifique $client) {}
    public function apiKeys(): PlatformApiKeysApi { return new PlatformApiKeysApi($this->client); }
    public function workspaces(): PlatformWorkspacesApi { return new PlatformWorkspacesApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfPlatformListApiKeysResponse */
    public function listApiKeys(?bool $includeRevoked = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($includeRevoked !== null) { $opts['query']['includeRevoked'] = $includeRevoked; }
        return $this->client->apiRequest('GET', '/v1/platform/api-keys', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformCreateApiKeyResponse */
    public function createApiKey(\Notifique\OpenApi\Model\NtfPlatformApiKeyCreate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/platform/api-keys', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformGetApiKeyResponse */
    public function getApiKey(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/api-keys/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformPatchApiKeyResponse */
    public function patchApiKey(string $id, \Notifique\OpenApi\Model\NtfPlatformApiKeyPatch $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/platform/api-keys/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformLoginResponse */
    public function postLogin(\Notifique\OpenApi\Model\NtfPlatformLoginBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/platform/login', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformGetMeResponse */
    public function getMe(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/platform/me', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformRegisterResponse */
    public function postRegister(\Notifique\OpenApi\Model\NtfPlatformRegisterBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/platform/register', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformVerifyResponse */
    public function postVerify(\Notifique\OpenApi\Model\NtfPlatformVerifyBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/platform/verify', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPlatformListUserWorkspacesResponse */
    public function listUserWorkspaces(?string $include = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($include !== null) { $opts['query']['include'] = $include; }
        return $this->client->apiRequest('GET', '/v1/platform/workspaces', $options['body'] ?? null, $options);
    }
}
final class PricingApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPlatformGetPricingResponse */
    public function getPricing(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/pricing', $options['body'] ?? null, $options);
    }
}
final class PushMessagesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPushCancelPushResponse */
    public function postV1PushMessagesCancel(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/push/messages/{id}/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class PushApi {
    public function __construct(private Notifique $client) {}
    public function messages(): PushMessagesApi { return new PushMessagesApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfPushPushAppListResponse */
    public function getV1PushApps(?int $page = null, ?int $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        return $this->client->apiRequest('GET', '/v1/push/apps', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushPushAppSingleResponse */
    public function postV1PushApps(\Notifique\OpenApi\Model\NtfPushPushAppCreateRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/push/apps', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushDeleteV1PushAppsByIdResponse */
    public function deleteV1PushAppsById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/push/apps/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushPushAppSingleResponse */
    public function getV1PushAppsById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/push/apps/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushPushAppSingleResponse */
    public function putV1PushAppsById(string $id, \Notifique\OpenApi\Model\NtfPushPushAppUpdateRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/push/apps/{id}');
        return $this->client->apiRequest('PUT', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushPushDeviceListResponse */
    public function getV1PushDevices(?int $page = null, ?int $limit = null, ?string $appId = null, ?string $platform = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($appId !== null) { $opts['query']['appId'] = $appId; }
        if ($platform !== null) { $opts['query']['platform'] = $platform; }
        return $this->client->apiRequest('GET', '/v1/push/devices', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushPushDeviceSingleResponse */
    public function postV1PushDevices(\Notifique\OpenApi\Model\NtfPushPushDeviceRegisterRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/push/devices', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushDeleteV1PushDevicesByIdResponse */
    public function deleteV1PushDevicesById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/push/devices/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushPushDeviceSingleResponse */
    public function getV1PushDevicesById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/push/devices/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushPushMessageListResponse */
    public function getV1PushMessages(?int $page = null, ?int $limit = null, ?string $status = null, ?string $appId = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($appId !== null) { $opts['query']['appId'] = $appId; }
        return $this->client->apiRequest('GET', '/v1/push/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushSendPushResponse */
    public function postV1PushMessages(\Notifique\OpenApi\Model\NtfPushSendPushRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/push/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPushPushMessageSingleResponse */
    public function getV1PushMessagesById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/push/messages/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class RcsMessagesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfRcsCancelRcsResponse */
    public function postV1RcsCancel(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/rcs/messages/{id}/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class RcsApi {
    public function __construct(private Notifique $client) {}
    public function messages(): RcsMessagesApi { return new RcsMessagesApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfRcsGetV1RcsMessagesResponse */
    public function getV1RcsMessages(?string $page = null, ?string $limit = null, ?string $fromDate = null, ?string $toDate = null, ?string $status = null, ?string $to = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($fromDate !== null) { $opts['query']['fromDate'] = $fromDate; }
        if ($toDate !== null) { $opts['query']['toDate'] = $toDate; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($to !== null) { $opts['query']['to'] = $to; }
        return $this->client->apiRequest('GET', '/v1/rcs/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfRcsSendRcsResponse */
    public function postV1RcsSend(\Notifique\OpenApi\Model\NtfRcsSendRcsRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/rcs/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfRcsRcsStatusResponse */
    public function getV1RcsById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/rcs/messages/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class ReportApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\ReportOkResponse */
    public function postV1Report(\Notifique\OpenApi\Model\ReportRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/report', $options['body'] ?? null, $options);
    }
}
final class SegmentsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfContactSegmentListResponse */
    public function getV1Segments(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/segments', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactSegmentOneResponse */
    public function postV1Segments(\Notifique\OpenApi\Model\NtfContactSegmentCreate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/segments', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactDeleteV1SegmentResponse */
    public function deleteV1Segment(string $segmentId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{segmentId}', Notifique::encodePathSegment($segmentId), '/v1/segments/{segmentId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactSegmentOneResponse */
    public function getV1SegmentById(string $segmentId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{segmentId}', Notifique::encodePathSegment($segmentId), '/v1/segments/{segmentId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactSegmentOneResponse */
    public function patchV1Segment(string $segmentId, \Notifique\OpenApi\Model\NtfContactSegmentPatch $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{segmentId}', Notifique::encodePathSegment($segmentId), '/v1/segments/{segmentId}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactSegmentPreviewResponse */
    public function getV1SegmentPreview(string $segmentId, ?string $page = null, ?string $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        $path = str_replace('{segmentId}', Notifique::encodePathSegment($segmentId), '/v1/segments/{segmentId}/preview');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class SendingPoolsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfPoolListResponse */
    public function list(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/sending-pools', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPoolCreateResponse */
    public function create(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/sending-pools', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPoolDeleteResponse */
    public function delete(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/sending-pools/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPoolGetResponse */
    public function get(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/sending-pools/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPoolUpdateResponse */
    public function update(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/sending-pools/{id}');
        return $this->client->apiRequest('PUT', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPoolAddMemberResponse */
    public function addMember(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/sending-pools/{id}/members');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPoolDeleteMemberResponse */
    public function deleteMember(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('DELETE', '/v1/sending-pools/{id}/members/{memberId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPoolUpdateMemberResponse */
    public function updateMember(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('PUT', '/v1/sending-pools/{id}/members/{memberId}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfPoolStatsResponse */
    public function stats(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/sending-pools/{id}/stats');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class ShortLinksApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfShortLinksListResponse */
    public function getV1ShortLinks(?string $page = null, ?string $limit = null, ?string $source = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($source !== null) { $opts['query']['source'] = $source; }
        return $this->client->apiRequest('GET', '/v1/short-links', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfShortLinksCreateResponse */
    public function postV1ShortLinks(\Notifique\OpenApi\Model\NtfShortLinksCreateRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/short-links', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfShortLinksDeleteResponse */
    public function deleteV1ShortLinksById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/short-links/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfShortLinksDetailResponse */
    public function getV1ShortLinksById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/short-links/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfShortLinksDetailResponse */
    public function patchV1ShortLinksById(string $id, \Notifique\OpenApi\Model\NtfShortLinksPatchRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/short-links/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfShortLinksAnalyticsResponse */
    public function getV1ShortLinksAnalytics(string $id, ?string $granularity = null, ?string $start = null, ?string $endParam = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($granularity !== null) { $opts['query']['granularity'] = $granularity; }
        if ($start !== null) { $opts['query']['start'] = $start; }
        if ($endParam !== null) { $opts['query']['end'] = $endParam; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/short-links/{id}/analytics');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfShortLinksClicksListResponse */
    public function getV1ShortLinksClicks(string $id, ?string $page = null, ?string $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/short-links/{id}/clicks');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class SmsMessagesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfSmsCancelSmsResponse */
    public function postV1SmsCancel(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/sms/messages/{id}/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class SmsApi {
    public function __construct(private Notifique $client) {}
    public function messages(): SmsMessagesApi { return new SmsMessagesApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfSmsGetV1SmsInboundResponse */
    public function getV1SmsInbound(?string $page = null, ?string $limit = null, ?string $q = null, ?string $provider = null, ?string $linked = null, ?string $dateFrom = null, ?string $dateTo = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($q !== null) { $opts['query']['q'] = $q; }
        if ($provider !== null) { $opts['query']['provider'] = $provider; }
        if ($linked !== null) { $opts['query']['linked'] = $linked; }
        if ($dateFrom !== null) { $opts['query']['dateFrom'] = $dateFrom; }
        if ($dateTo !== null) { $opts['query']['dateTo'] = $dateTo; }
        return $this->client->apiRequest('GET', '/v1/sms/inbound', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfSmsGetV1SmsInboundByIdResponse */
    public function getV1SmsInboundById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/sms/inbound/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfSmsGetV1SmsMessagesResponse */
    public function getV1SmsMessages(?string $page = null, ?string $limit = null, ?string $fromDate = null, ?string $toDate = null, ?string $status = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($fromDate !== null) { $opts['query']['fromDate'] = $fromDate; }
        if ($toDate !== null) { $opts['query']['toDate'] = $toDate; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        return $this->client->apiRequest('GET', '/v1/sms/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfSmsSendSmsResponse */
    public function postV1SmsSend(\Notifique\OpenApi\Model\NtfSmsSendSmsRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/sms/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfSmsSmsStatusResponse */
    public function getV1SmsById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/sms/messages/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class SuppressionsBatchApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfSuppBatchAddResponse */
    public function batchAddSuppressions(\Notifique\OpenApi\Model\NtfSuppBatchAddRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/suppressions/batch/add', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfSuppBatchRemoveResponse */
    public function batchRemoveSuppressions(\Notifique\OpenApi\Model\NtfSuppBatchRemoveRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/suppressions/batch/remove', $options['body'] ?? null, $options);
    }
}
final class SuppressionsApi {
    public function __construct(private Notifique $client) {}
    public function batch(): SuppressionsBatchApi { return new SuppressionsBatchApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfSuppListResponse */
    public function listSuppressions(\Notifique\OpenApi\Model\NtfSuppSuppressionType $typeParam = null, \Notifique\OpenApi\Model\NtfSuppSuppressionReason $reason = null, \Notifique\OpenApi\Model\NtfSuppSuppressionOrigin $origin = null, ?string $channel = null, ?string $search = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($typeParam !== null) { $opts['query']['type'] = $typeParam; }
        if ($reason !== null) { $opts['query']['reason'] = $reason; }
        if ($origin !== null) { $opts['query']['origin'] = $origin; }
        if ($channel !== null) { $opts['query']['channel'] = $channel; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        return $this->client->apiRequest('GET', '/v1/suppressions', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfSuppSingleResponse */
    public function createSuppression(\Notifique\OpenApi\Model\NtfSuppSuppressionInput $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/suppressions', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfSuppRemoveResponse */
    public function removeSuppression(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/suppressions/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfSuppSingleResponse */
    public function getSuppression(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/suppressions/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfSuppRemoveResponse */
    public function removeSuppressionByIdentity(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('DELETE', '/v1/suppressions/by-identity', $options['body'] ?? null, $options);
    }
}
final class TagsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfContactGetV1TagsResponse */
    public function getV1Tags(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/tags', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactPostV1TagsResponse */
    public function postV1Tags(\Notifique\OpenApi\Model\NtfContactTagCreate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/tags', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactDeleteV1TagResponse */
    public function deleteV1Tag(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/tags/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactGetV1TagResponse */
    public function getV1Tag(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/tags/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactPutV1TagResponse */
    public function putV1Tag(string $id, \Notifique\OpenApi\Model\NtfContactTagUpdate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/tags/{id}');
        return $this->client->apiRequest('PUT', $path, $options['body'] ?? null, $options);
    }
}
final class TelegramInstancesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfTgConnectPageStatusResponse */
    public function ntfTelegramGetConnectPage(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/telegram/instances/{instanceId}/connect-page');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgConnectPageDisableResponse */
    public function ntfTelegramDisableConnectPage(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/telegram/instances/{instanceId}/connect-page/disable');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgConnectPageEnableResponse */
    public function ntfTelegramEnableConnectPage(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/telegram/instances/{instanceId}/connect-page/enable');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgConnectPageEnableResponse */
    public function ntfTelegramRotateConnectPage(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/telegram/instances/{instanceId}/connect-page/rotate-secret');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgQrEnvelope */
    public function getV1TelegramInstanceQr(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/telegram/instances/{instanceId}/qr');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgQrCancelSuccess */
    public function postV1TelegramInstanceQrCancel(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/telegram/instances/{instanceId}/qr/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgSessionSaveResponse */
    public function postV1TelegramInstanceSession(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/telegram/instances/{instanceId}/session');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class TelegramMessagesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfTgMessageIdStatusResponse */
    public function postV1TelegramMessageCancel(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/telegram/messages/{messageId}/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgMessageIdStatusResponse */
    public function patchV1TelegramMessageEdit(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/telegram/messages/{messageId}/edit');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgInboundListEnvelope */
    public function getV1TelegramInbound(?string $page = null, ?string $limit = null, ?string $q = null, ?string $instanceId = null, ?string $dateFrom = null, ?string $dateTo = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($q !== null) { $opts['query']['q'] = $q; }
        if ($instanceId !== null) { $opts['query']['instanceId'] = $instanceId; }
        if ($dateFrom !== null) { $opts['query']['dateFrom'] = $dateFrom; }
        if ($dateTo !== null) { $opts['query']['dateTo'] = $dateTo; }
        return $this->client->apiRequest('GET', '/v1/telegram/messages/inbound', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgInboundDetailEnvelope */
    public function getV1TelegramInboundById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/telegram/messages/inbound/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgPostV1TelegramInboundMediaResponse */
    public function postV1TelegramInboundMedia(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/telegram/messages/inbound/{id}/media');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgGetV1TelegramInboundMediaDownloadResponse */
    public function getV1TelegramInboundMediaDownload(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/telegram/messages/inbound/{id}/media/download');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class TelegramApi {
    public function __construct(private Notifique $client) {}
    public function instances(): TelegramInstancesApi { return new TelegramInstancesApi($this->client); }
    public function messages(): TelegramMessagesApi { return new TelegramMessagesApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfTgChatSubscriptionListEnvelope */
    public function getV1TelegramChats(?string $page = null, ?string $limit = null, ?string $q = null, ?string $instanceId = null, ?string $status = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($q !== null) { $opts['query']['q'] = $q; }
        if ($instanceId !== null) { $opts['query']['instanceId'] = $instanceId; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        return $this->client->apiRequest('GET', '/v1/telegram/chats', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgTelegramInstanceListEnvelope */
    public function getV1TelegramInstances(?string $page = null, ?string $limit = null, ?string $status = null, ?string $search = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        return $this->client->apiRequest('GET', '/v1/telegram/instances', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgCreateTelegramInstanceResponse */
    public function postV1TelegramInstances(\Notifique\OpenApi\Model\NtfTgCreateTelegramInstanceRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/telegram/instances', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgInstanceDeletedResponse */
    public function deleteV1TelegramInstance(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/telegram/instances/{instanceId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgInstanceDetailEnvelope */
    public function getV1TelegramInstance(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/telegram/instances/{instanceId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgMessageListEnvelope */
    public function getV1TelegramMessages(?string $page = null, ?string $limit = null, ?string $fromDate = null, ?string $toDate = null, ?string $instanceIds = null, ?string $status = null, ?string $typeParam = null, ?string $includeEvents = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($fromDate !== null) { $opts['query']['fromDate'] = $fromDate; }
        if ($toDate !== null) { $opts['query']['toDate'] = $toDate; }
        if ($instanceIds !== null) { $opts['query']['instanceIds'] = $instanceIds; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($typeParam !== null) { $opts['query']['type'] = $typeParam; }
        if ($includeEvents !== null) { $opts['query']['includeEvents'] = $includeEvents; }
        return $this->client->apiRequest('GET', '/v1/telegram/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgSendTelegramMessageAccepted */
    public function postV1TelegramSend(\Notifique\OpenApi\Model\NtfTgSendTelegramMessageRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/telegram/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgMessageIdStatusResponse */
    public function deleteV1TelegramMessage(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/telegram/messages/{messageId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfTgMessageDetailEnvelope */
    public function getV1TelegramMessageById(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/telegram/messages/{messageId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class TemplatesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\TemplateListResponse */
    public function listTemplates(?int $page = null, ?int $limit = null, ?string $search = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        return $this->client->apiRequest('GET', '/v1/templates', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\TemplateResponse */
    public function createTemplates(\Notifique\OpenApi\Model\TemplateCreateRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/templates', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\TemplateDeleteResponse */
    public function deleteTemplates(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/templates/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\TemplateResponse */
    public function getTemplates(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/templates/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\TemplateResponse */
    public function updateTemplates(string $id, \Notifique\OpenApi\Model\TemplatePatchRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/templates/{id}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\TemplateSendResponse */
    public function createSend(\Notifique\OpenApi\Model\TemplateSendRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/templates/send', $options['body'] ?? null, $options);
    }
}
final class TopicsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfContactTopicListResponse */
    public function getV1Topics(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/topics', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactTopicOneResponse */
    public function postV1Topics(\Notifique\OpenApi\Model\NtfContactTopicCreate $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/topics', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactDeleteV1TopicResponse */
    public function deleteV1Topic(string $topicId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{topicId}', Notifique::encodePathSegment($topicId), '/v1/topics/{topicId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactTopicOneResponse */
    public function getV1TopicById(string $topicId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{topicId}', Notifique::encodePathSegment($topicId), '/v1/topics/{topicId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfContactTopicOneResponse */
    public function patchV1Topic(string $topicId, \Notifique\OpenApi\Model\NtfContactTopicPatch $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{topicId}', Notifique::encodePathSegment($topicId), '/v1/topics/{topicId}');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
}
final class VoiceCallsApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfVoicePostV1VoiceCallsActionResponse */
    public function postV1VoiceCallsAction(\Notifique\OpenApi\Model\NtfVoiceActionBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/voice/calls/{id}/actions/{action}', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfVoiceGetV1VoiceRecordingDownloadResponse */
    public function getV1VoiceRecordingDownload(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/voice/calls/{id}/recordings/{recordingId}/download', $options['body'] ?? null, $options);
    }
}
final class VoiceApi {
    public function __construct(private Notifique $client) {}
    public function calls(): VoiceCallsApi { return new VoiceCallsApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfVoiceListEnvelope */
    public function getV1VoiceCalls(?string $page = null, ?string $limit = null, ?string $direction = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($direction !== null) { $opts['query']['direction'] = $direction; }
        return $this->client->apiRequest('GET', '/v1/voice/calls', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfVoiceSendSuccessEnvelope */
    public function postV1VoiceCalls(\Notifique\OpenApi\Model\NtfVoiceCreateBody $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/voice/calls', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfVoiceDetailEnvelope */
    public function getV1VoiceCallsById(string $id, ?string $includeEvents = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($includeEvents !== null) { $opts['query']['includeEvents'] = $includeEvents; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/voice/calls/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class WebhooksDeliveriesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfWhResendDeliveryResponse */
    public function resendDelivery(string $deliveryId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{deliveryId}', Notifique::encodePathSegment($deliveryId), '/v1/webhooks/deliveries/{deliveryId}/resend');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
}
final class WebhooksApi {
    public function __construct(private Notifique $client) {}
    public function deliveries(): WebhooksDeliveriesApi { return new WebhooksDeliveriesApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfWhListWebhooksResponse */
    public function listWebhooks(?int $page = null, ?int $limit = null, ?string $eventParam = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($eventParam !== null) { $opts['query']['event'] = $eventParam; }
        return $this->client->apiRequest('GET', '/v1/webhooks', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWhCreateWebhookResponse */
    public function createWebhook(\Notifique\OpenApi\Model\NtfWhWebhookInput $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/webhooks', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWhDeleteWebhookResponse */
    public function deleteWebhook(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/webhooks/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWhGetWebhookResponse */
    public function getWebhook(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/webhooks/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWhUpdateWebhookResponse */
    public function updateWebhook(string $id, \Notifique\OpenApi\Model\NtfWhWebhookInput $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/webhooks/{id}');
        return $this->client->apiRequest('PUT', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWhRotateWebhookSecretResponse */
    public function rotateWebhookSecret(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/webhooks/{id}/rotate-secret');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWhListDeliveriesResponse */
    public function listDeliveries(?int $page = null, ?int $limit = null, ?bool $success = null, ?string $eventParam = null, ?string $webhook_id = null, ?string $messageId = null, ?string $search = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($success !== null) { $opts['query']['success'] = $success; }
        if ($eventParam !== null) { $opts['query']['event'] = $eventParam; }
        if ($webhook_id !== null) { $opts['query']['webhook_id'] = $webhook_id; }
        if ($messageId !== null) { $opts['query']['messageId'] = $messageId; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        return $this->client->apiRequest('GET', '/v1/webhooks/deliveries', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWhGetDeliveryResponse */
    public function getDelivery(string $deliveryId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{deliveryId}', Notifique::encodePathSegment($deliveryId), '/v1/webhooks/deliveries/{deliveryId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class WhatsappInstancesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfWaCallPermGetResponse */
    public function callPermGet(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/calling/permissions');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaCallPermRequestResponse */
    public function callPermRequest(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/calling/permissions/request');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaCallSettingsGetResponse */
    public function callSettingsGet(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/calling/settings');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaCallSettingsPatchResponse */
    public function callSettingsPatch(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/calling/settings');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaConnectPageStatusResponse */
    public function getV1WhatsappInstanceConnectPage(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/connect-page');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaConnectPageDisableResponse */
    public function postV1WhatsappInstanceConnectPageDisable(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/connect-page/disable');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaConnectPageEnableResponse */
    public function postV1WhatsappInstanceConnectPageEnable(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/connect-page/enable');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaConnectPageEnableResponse */
    public function postV1WhatsappInstanceConnectPageRotate(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/connect-page/rotate-secret');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaInstanceActionResponse */
    public function postV1WhatsappInstanceDisconnect(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/disconnect');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappInstancesInstanceIdGroupsResponse */
    public function getV1WhatsappInstancesInstanceIdGroups(string $instanceId, ?int $page = null, ?int $limit = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/groups');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsResponse */
    public function getV1WhatsappInstancesInstanceIdGroupsGroupIdParticipants(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('GET', '/v1/whatsapp/instances/{instanceId}/groups/{groupId}/participants', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteResponse */
    public function postV1WhatsappInstancesInstanceIdGroupsInvite(string $instanceId, \Notifique\OpenApi\Model\NtfWaGroupInviteSendRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/groups/invite');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappInstancesInstanceIdGroupsInviteCodeResponse */
    public function getV1WhatsappInstancesInstanceIdGroupsInviteCode(string $instanceId, ?string $groupJid = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($groupJid !== null) { $opts['query']['groupJid'] = $groupJid; }
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/groups/invite-code');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteRevokeResponse */
    public function postV1WhatsappInstancesInstanceIdGroupsInviteRevoke(string $instanceId, \Notifique\OpenApi\Model\NtfWaGroupInviteRevokeRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/groups/invite/revoke');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaPostV1WhatsappInstancesInstanceIdGroupsParticipantsResponse */
    public function postV1WhatsappInstancesInstanceIdGroupsParticipants(string $instanceId, \Notifique\OpenApi\Model\NtfWaGroupParticipantsRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/groups/participants');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappInstancePairingCodeResponse */
    public function getV1WhatsappInstancePairingCode(string $instanceId, ?string $phoneNumber = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($phoneNumber !== null) { $opts['query']['phoneNumber'] = $phoneNumber; }
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/pairing-code');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappInstanceQrResponse */
    public function getV1WhatsappInstanceQr(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}/qr');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class WhatsappMessagesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\NtfWaPostV1WhatsappMessageCancelResponse */
    public function postV1WhatsappMessageCancel(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/whatsapp/messages/{messageId}/cancel');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaMessageActionResponse */
    public function patchV1WhatsappMessageEdit(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/whatsapp/messages/{messageId}/edit');
        return $this->client->apiRequest('PATCH', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappMessagesInboundResponse */
    public function getV1WhatsappMessagesInbound(?string $page = null, ?string $limit = null, ?string $q = null, ?string $instanceId = null, ?string $dateFrom = null, ?string $dateTo = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($q !== null) { $opts['query']['q'] = $q; }
        if ($instanceId !== null) { $opts['query']['instanceId'] = $instanceId; }
        if ($dateFrom !== null) { $opts['query']['dateFrom'] = $dateFrom; }
        if ($dateTo !== null) { $opts['query']['dateTo'] = $dateTo; }
        return $this->client->apiRequest('GET', '/v1/whatsapp/messages/inbound', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappMessageInboundByIdResponse */
    public function getV1WhatsappMessageInboundById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/whatsapp/messages/inbound/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaPostV1WhatsappMessageInboundMediaResponse */
    public function postV1WhatsappMessageInboundMedia(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/whatsapp/messages/inbound/{id}/media');
        return $this->client->apiRequest('POST', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappMessageInboundMediaDownloadResponse */
    public function getV1WhatsappMessageInboundMediaDownload(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/whatsapp/messages/inbound/{id}/media/download');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaPostV1WhatsappMessagePresenceResponse */
    public function postV1WhatsappMessagePresence(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/whatsapp/messages/presence', $options['body'] ?? null, $options);
    }
}
final class WhatsappApi {
    public function __construct(private Notifique $client) {}
    public function instances(): WhatsappInstancesApi { return new WhatsappInstancesApi($this->client); }
    public function messages(): WhatsappMessagesApi { return new WhatsappMessagesApi($this->client); }
    /** @return \Notifique\OpenApi\Model\NtfWaWhatsAppCallListEnvelope */
    public function getV1WhatsappCalls(?string $page = null, ?string $limit = null, ?string $instanceId = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($instanceId !== null) { $opts['query']['instanceId'] = $instanceId; }
        return $this->client->apiRequest('GET', '/v1/whatsapp/calls', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaWhatsAppCallCreateEnvelope */
    public function postV1WhatsappCalls(\Notifique\OpenApi\Model\NtfWaCreateWhatsAppCallRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/whatsapp/calls', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaWhatsAppCallDetailEnvelope */
    public function getV1WhatsappCallById(string $id, ?string $includeEvents = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($includeEvents !== null) { $opts['query']['includeEvents'] = $includeEvents; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/whatsapp/calls/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaInstanceListResponse */
    public function getV1WhatsappInstances(?string $page = null, ?string $limit = null, ?string $status = null, ?string $search = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($search !== null) { $opts['query']['search'] = $search; }
        return $this->client->apiRequest('GET', '/v1/whatsapp/instances', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaCreateInstanceResponse */
    public function postV1WhatsappInstances(array $options = []): array {
        $opts = $options;
        return $this->client->apiRequest('POST', '/v1/whatsapp/instances', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaInstanceActionResponse */
    public function deleteV1WhatsappInstance(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaInstanceResponse */
    public function getV1WhatsappInstance(string $instanceId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{instanceId}', Notifique::encodePathSegment($instanceId), '/v1/whatsapp/instances/{instanceId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappMessagesResponse */
    public function getV1WhatsappMessages(?string $page = null, ?string $limit = null, ?string $fromDate = null, ?string $toDate = null, ?string $instanceIds = null, ?string $status = null, ?string $typeParam = null, ?string $includeEvents = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($page !== null) { $opts['query']['page'] = $page; }
        if ($limit !== null) { $opts['query']['limit'] = $limit; }
        if ($fromDate !== null) { $opts['query']['fromDate'] = $fromDate; }
        if ($toDate !== null) { $opts['query']['toDate'] = $toDate; }
        if ($instanceIds !== null) { $opts['query']['instanceIds'] = $instanceIds; }
        if ($status !== null) { $opts['query']['status'] = $status; }
        if ($typeParam !== null) { $opts['query']['type'] = $typeParam; }
        if ($includeEvents !== null) { $opts['query']['includeEvents'] = $includeEvents; }
        return $this->client->apiRequest('GET', '/v1/whatsapp/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaPostV1WhatsappSendResponse */
    public function postV1WhatsappSend(\Notifique\OpenApi\Model\NtfWaSendWhatsAppMessageRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/whatsapp/messages', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaMessageActionResponse */
    public function deleteV1WhatsappMessage(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/whatsapp/messages/{messageId}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\NtfWaGetV1WhatsappMessageResponse */
    public function getV1WhatsappMessage(string $messageId, array $options = []): array {
        $opts = $options;
        $path = str_replace('{messageId}', Notifique::encodePathSegment($messageId), '/v1/whatsapp/messages/{messageId}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
}
final class WorkspacesApi {
    public function __construct(private Notifique $client) {}
    /** @return \Notifique\OpenApi\Model\GetV1WorkspacesResponse */
    public function getV1Workspaces(?string $include = null, array $options = []): array {
        $opts = $options;
        $opts['query'] = $opts['query'] ?? [];
        if ($include !== null) { $opts['query']['include'] = $include; }
        return $this->client->apiRequest('GET', '/v1/workspaces', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\WorkspaceSingleResponse */
    public function postV1Workspaces(\Notifique\OpenApi\Model\WorkspaceCreateRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        return $this->client->apiRequest('POST', '/v1/workspaces', $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\DeleteV1WorkspacesByIdResponse */
    public function deleteV1WorkspacesById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/workspaces/{id}');
        return $this->client->apiRequest('DELETE', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\WorkspaceGetResponse */
    public function getV1WorkspacesById(string $id, array $options = []): array {
        $opts = $options;
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/workspaces/{id}');
        return $this->client->apiRequest('GET', $path, $options['body'] ?? null, $options);
    }
    /** @return \Notifique\OpenApi\Model\WorkspaceUpdateResponse */
    public function putV1WorkspacesById(string $id, \Notifique\OpenApi\Model\WorkspaceUpdateRequest $body = null, array $options = []): array {
        $opts = $options;
        if ($body !== null) { $opts['body'] = $body; }
        $path = str_replace('{id}', Notifique::encodePathSegment($id), '/v1/workspaces/{id}');
        return $this->client->apiRequest('PUT', $path, $options['body'] ?? null, $options);
    }
}