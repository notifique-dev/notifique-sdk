package notifique

import (
	"encoding/json"
	"fmt"

	"github.com/notifique/notifique-sdk-go/openapimodels"
)
type TypedAPI struct { client *Notifique }

func newTypedAPI(c *Notifique) *TypedAPI { return &TypedAPI{client: c} }

func ensureOpts(opts *DynamicRequestOptions) *DynamicRequestOptions {
	if opts == nil { return &DynamicRequestOptions{} }
	return opts
}

type WellKnownAPI struct { api *TypedAPI }
func (t *TypedAPI) WellKnown() *WellKnownAPI { return &WellKnownAPI{api: t} }
func (n *WellKnownAPI) GetJwks(opts *DynamicRequestOptions) (*openapimodels.NtfOauthGetJwksResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("wellKnown.getJwks", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthGetJwksResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WellKnownAPI) GetAuthorizationServerMetadata(opts *DynamicRequestOptions) (*openapimodels.NtfOauthGetAuthorizationServerMetadataResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("wellKnown.getAuthorizationServerMetadata", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthGetAuthorizationServerMetadataResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WellKnownAPI) GetProtectedResourceMetadata(opts *DynamicRequestOptions) (*openapimodels.NtfOauthGetProtectedResourceMetadataResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("wellKnown.getProtectedResourceMetadata", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthGetProtectedResourceMetadataResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type OauthAPI struct { api *TypedAPI }
func (t *TypedAPI) Oauth() *OauthAPI { return &OauthAPI{api: t} }
func (n *OauthAPI) Authorize(client_id *string, response_type *string, redirect_uri *string, scope *string, state *string, code_challenge *string, code_challenge_method *string, opts *DynamicRequestOptions) (*openapimodels.NtfOauthAuthorizeResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if client_id != nil { opts.Query["client_id"] = fmt.Sprint(*client_id) }
	if response_type != nil { opts.Query["response_type"] = fmt.Sprint(*response_type) }
	if redirect_uri != nil { opts.Query["redirect_uri"] = fmt.Sprint(*redirect_uri) }
	if scope != nil { opts.Query["scope"] = fmt.Sprint(*scope) }
	if state != nil { opts.Query["state"] = fmt.Sprint(*state) }
	if code_challenge != nil { opts.Query["code_challenge"] = fmt.Sprint(*code_challenge) }
	if code_challenge_method != nil { opts.Query["code_challenge_method"] = fmt.Sprint(*code_challenge_method) }
	raw, err := n.api.client.DynamicApi.Call("oauth.authorize", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthAuthorizeResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) RegisterClient(body *openapimodels.NtfOauthClientRegistration, opts *DynamicRequestOptions) (*openapimodels.NtfOauthRegisterClientResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("oauth.registerClient", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthRegisterClientResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) Revoke(opts *DynamicRequestOptions) (*openapimodels.NtfOauthRevokeResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("oauth.revoke", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthRevokeResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) Token(opts *DynamicRequestOptions) (*openapimodels.NtfOauthTokenResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("oauth.token", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthTokenResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) ListWorkspaceApps(opts *DynamicRequestOptions) (*openapimodels.NtfOauthListWorkspaceAppsResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("oauth.listWorkspaceApps", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthListWorkspaceAppsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) CreateWorkspaceApp(body *openapimodels.NtfOauthWorkspaceAppCreate, opts *DynamicRequestOptions) (*openapimodels.NtfOauthCreateWorkspaceAppResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("oauth.createWorkspaceApp", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthCreateWorkspaceAppResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) DeleteWorkspaceApp(id string, opts *DynamicRequestOptions) (*openapimodels.NtfOauthDeleteWorkspaceAppResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("oauth.deleteWorkspaceApp", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthDeleteWorkspaceAppResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) GetWorkspaceApp(id string, opts *DynamicRequestOptions) (*openapimodels.NtfOauthGetWorkspaceAppResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("oauth.getWorkspaceApp", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthGetWorkspaceAppResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) UpdateWorkspaceApp(id string, body *openapimodels.NtfOauthWorkspaceAppPatch, opts *DynamicRequestOptions) (*openapimodels.NtfOauthUpdateWorkspaceAppResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("oauth.updateWorkspaceApp", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthUpdateWorkspaceAppResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) ListConnections(opts *DynamicRequestOptions) (*openapimodels.NtfOauthListConnectionsResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("oauth.listConnections", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthListConnectionsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) Apps() *OauthAppsAPI { return &OauthAppsAPI{api: n.api} }
type OauthAppsAPI struct { api *TypedAPI }
func (n *OauthAppsAPI) RotateWorkspaceAppSecret(id string, opts *DynamicRequestOptions) (*openapimodels.NtfOauthRotateWorkspaceAppSecretResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("oauth.apps.rotateWorkspaceAppSecret", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthRotateWorkspaceAppSecretResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *OauthAPI) Connections() *OauthConnectionsAPI { return &OauthConnectionsAPI{api: n.api} }
type OauthConnectionsAPI struct { api *TypedAPI }
func (n *OauthConnectionsAPI) RevokeConnection(id string, opts *DynamicRequestOptions) (*openapimodels.NtfOauthRevokeConnectionResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("oauth.connections.revokeConnection", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfOauthRevokeConnectionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type PublicAPI struct { api *TypedAPI }
func (t *TypedAPI) Public() *PublicAPI { return &PublicAPI{api: t} }
func (n *PublicAPI) AiWidget() *PublicAiWidgetAPI { return &PublicAiWidgetAPI{api: n.api} }
type PublicAiWidgetAPI struct { api *TypedAPI }
func (n *PublicAiWidgetAPI) GetConfig(publicKey string, opts *DynamicRequestOptions) (*openapimodels.WidgetConfigResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"publicKey": publicKey}
	raw, err := n.api.client.DynamicApi.Call("public.aiWidget.getConfig", *opts)
	if err != nil { return nil, err }
	var out openapimodels.WidgetConfigResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PublicAiWidgetAPI) SendMessage(publicKey string, body *openapimodels.SendMessageBody, opts *DynamicRequestOptions) (*openapimodels.MessageResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"publicKey": publicKey}
	raw, err := n.api.client.DynamicApi.Call("public.aiWidget.sendMessage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.MessageResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PublicAiWidgetAPI) PollMessages(publicKey string, sessionToken *string, afterParam *string, opts *DynamicRequestOptions) (*openapimodels.PollMessagesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if sessionToken != nil { opts.Query["sessionToken"] = fmt.Sprint(*sessionToken) }
	if afterParam != nil { opts.Query["after"] = fmt.Sprint(*afterParam) }
	opts.PathParams = map[string]string{"publicKey": publicKey}
	raw, err := n.api.client.DynamicApi.Call("public.aiWidget.pollMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.PollMessagesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PublicAiWidgetAPI) CreateSession(publicKey string, body *openapimodels.CreateSessionBody, opts *DynamicRequestOptions) (*openapimodels.SessionResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"publicKey": publicKey}
	raw, err := n.api.client.DynamicApi.Call("public.aiWidget.createSession", *opts)
	if err != nil { return nil, err }
	var out openapimodels.SessionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PublicAiWidgetAPI) RequestOtp(publicKey string, opts *DynamicRequestOptions) (*openapimodels.NtfWidgetRequestOtpResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"publicKey": publicKey}
	raw, err := n.api.client.DynamicApi.Call("public.aiWidget.requestOtp", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetRequestOtpResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PublicAiWidgetAPI) VerifyOtp(publicKey string, opts *DynamicRequestOptions) (*openapimodels.NtfWidgetVerifyOtpResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"publicKey": publicKey}
	raw, err := n.api.client.DynamicApi.Call("public.aiWidget.verifyOtp", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetVerifyOtpResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type AiWebWidgetAPI struct { api *TypedAPI }
func (t *TypedAPI) AiWebWidget() *AiWebWidgetAPI { return &AiWebWidgetAPI{api: t} }
func (n *AiWebWidgetAPI) Messages(opts *DynamicRequestOptions) (*openapimodels.NtfWidgetAdminMessagesResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("aiWebWidget.messages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetAdminMessagesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AiWebWidgetAPI) List(opts *DynamicRequestOptions) (*openapimodels.NtfWidgetAdminListResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("aiWebWidget.list", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetAdminListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AiWebWidgetAPI) Create(opts *DynamicRequestOptions) (*openapimodels.NtfWidgetAdminCreateResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("aiWebWidget.create", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetAdminCreateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AiWebWidgetAPI) Delete(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWidgetAdminDeleteResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("aiWebWidget.delete", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetAdminDeleteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AiWebWidgetAPI) Get(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWidgetAdminGetResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("aiWebWidget.get", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetAdminGetResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AiWebWidgetAPI) Patch(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWidgetAdminPatchResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("aiWebWidget.patch", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetAdminPatchResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AiWebWidgetAPI) Widgets() *AiWebWidgetWidgetsAPI { return &AiWebWidgetWidgetsAPI{api: n.api} }
type AiWebWidgetWidgetsAPI struct { api *TypedAPI }
func (n *AiWebWidgetWidgetsAPI) Duplicate(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWidgetAdminDuplicateResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("aiWebWidget.widgets.duplicate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetAdminDuplicateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AiWebWidgetWidgetsAPI) RotateHmac(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWidgetAdminRotateHmacResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("aiWebWidget.widgets.rotateHmac", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetAdminRotateHmacResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AiWebWidgetWidgetsAPI) RotateKey(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWidgetAdminRotateKeyResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("aiWebWidget.widgets.rotateKey", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWidgetAdminRotateKeyResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type AssistantsAPI struct { api *TypedAPI }
func (t *TypedAPI) Assistants() *AssistantsAPI { return &AssistantsAPI{api: t} }
func (n *AssistantsAPI) AssistantsList(page *string, limit *string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsList", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsCreate(opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsCreateResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsCreate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsCreateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsDelete(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsDeleteResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsDelete", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsDeleteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsGet(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsGetResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsGet", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsGetResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsUpdate(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsUpdateResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsUpdate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsUpdateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsListHttpBindings(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsListHttpBindingsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsListHttpBindings", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsListHttpBindingsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsCreateHttpBinding(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsCreateHttpBindingResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsCreateHttpBinding", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsCreateHttpBindingResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsDeleteHttpBinding(opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsDeleteHttpBindingResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsDeleteHttpBinding", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsDeleteHttpBindingResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsInvoke(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsInvokeResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsInvoke", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsInvokeResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsListMcpBindings(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsListMcpBindingsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsListMcpBindings", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsListMcpBindingsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsCreateMcpBinding(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsCreateMcpBindingResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsCreateMcpBinding", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsCreateMcpBindingResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsDeleteMcpBinding(opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsDeleteMcpBindingResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsDeleteMcpBinding", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsDeleteMcpBindingResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) AssistantsUpdateMcpBinding(opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsUpdateMcpBindingResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("assistants.assistantsUpdateMcpBinding", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsUpdateMcpBindingResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AssistantsAPI) Invoke() *AssistantsInvokeAPI { return &AssistantsInvokeAPI{api: n.api} }
type AssistantsInvokeAPI struct { api *TypedAPI }
func (n *AssistantsInvokeAPI) AssistantsInvokeMessages(id string, threadId *string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoAssistantsInvokeMessagesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if threadId != nil { opts.Query["threadId"] = fmt.Sprint(*threadId) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("assistants.invoke.assistantsInvokeMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAssistantsInvokeMessagesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type AutomationsAPI struct { api *TypedAPI }
func (t *TypedAPI) Automations() *AutomationsAPI { return &AutomationsAPI{api: t} }
func (n *AutomationsAPI) ListAutomations(page *string, limit *string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoListAutomationsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	raw, err := n.api.client.DynamicApi.Call("automations.listAutomations", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoListAutomationsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) CreateAutomation(body *openapimodels.NtfAutoAutomationCreateBody, opts *DynamicRequestOptions) (*openapimodels.NtfAutoCreateAutomationResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("automations.createAutomation", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoCreateAutomationResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) DeleteAutomation(automationId string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoDeleteAutomationResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"automationId": automationId}
	raw, err := n.api.client.DynamicApi.Call("automations.deleteAutomation", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoDeleteAutomationResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) GetAutomation(automationId string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoGetAutomationResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"automationId": automationId}
	raw, err := n.api.client.DynamicApi.Call("automations.getAutomation", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoGetAutomationResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) PatchAutomation(automationId string, body *openapimodels.NtfAutoAutomationPatchBody, opts *DynamicRequestOptions) (*openapimodels.NtfAutoPatchAutomationResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"automationId": automationId}
	raw, err := n.api.client.DynamicApi.Call("automations.patchAutomation", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoPatchAutomationResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) Duplicate(automationId string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoDuplicateResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"automationId": automationId}
	raw, err := n.api.client.DynamicApi.Call("automations.duplicate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoDuplicateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) ListRuns(automationId string, page *string, limit *string, status *string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoListRunsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	opts.PathParams = map[string]string{"automationId": automationId}
	raw, err := n.api.client.DynamicApi.Call("automations.listRuns", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoListRunsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) GetRun(opts *DynamicRequestOptions) (*openapimodels.NtfAutoGetRunResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("automations.getRun", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoGetRunResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) StopAutomation(automationId string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoStopAutomationResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"automationId": automationId}
	raw, err := n.api.client.DynamicApi.Call("automations.stopAutomation", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoStopAutomationResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) TestTrigger(automationId string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoTestTriggerResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"automationId": automationId}
	raw, err := n.api.client.DynamicApi.Call("automations.testTrigger", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoTestTriggerResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) WebhookSecret(automationId string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoWebhookSecretResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"automationId": automationId}
	raw, err := n.api.client.DynamicApi.Call("automations.webhookSecret", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoWebhookSecretResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) AiCompose(opts *DynamicRequestOptions) (*openapimodels.NtfAutoAiComposeResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("automations.aiCompose", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoAiComposeResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) PostCampaignAgent(opts *DynamicRequestOptions) (*openapimodels.NtfAutoPostCampaignAgentResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("automations.postCampaignAgent", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoPostCampaignAgentResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) QuickChatbot(opts *DynamicRequestOptions) (*openapimodels.NtfAutoQuickChatbotResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("automations.quickChatbot", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoQuickChatbotResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *AutomationsAPI) Batch() *AutomationsBatchAPI { return &AutomationsBatchAPI{api: n.api} }
type AutomationsBatchAPI struct { api *TypedAPI }
func (n *AutomationsBatchAPI) BatchDelete(opts *DynamicRequestOptions) (*openapimodels.NtfAutoBatchDeleteResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("automations.batch.batchDelete", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoBatchDeleteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type CampaignsAPI struct { api *TypedAPI }
func (t *TypedAPI) Campaigns() *CampaignsAPI { return &CampaignsAPI{api: t} }
func (n *CampaignsAPI) GetV1Campaigns(opts *DynamicRequestOptions) (*openapimodels.NtfContactCampaignListResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("campaigns.getV1Campaigns", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactCampaignListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *CampaignsAPI) PostV1Campaigns(body *openapimodels.NtfContactCampaignCreate, opts *DynamicRequestOptions) (*openapimodels.NtfContactCampaignOneResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("campaigns.postV1Campaigns", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactCampaignOneResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *CampaignsAPI) DeleteV1Campaign(campaignId string, opts *DynamicRequestOptions) (*openapimodels.NtfContactDeleteV1CampaignResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"campaignId": campaignId}
	raw, err := n.api.client.DynamicApi.Call("campaigns.deleteV1Campaign", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactDeleteV1CampaignResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *CampaignsAPI) GetV1CampaignById(campaignId string, opts *DynamicRequestOptions) (*openapimodels.NtfContactCampaignOneResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"campaignId": campaignId}
	raw, err := n.api.client.DynamicApi.Call("campaigns.getV1CampaignById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactCampaignOneResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *CampaignsAPI) PatchV1Campaign(campaignId string, body *openapimodels.NtfContactCampaignPatch, opts *DynamicRequestOptions) (*openapimodels.NtfContactCampaignOneResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"campaignId": campaignId}
	raw, err := n.api.client.DynamicApi.Call("campaigns.patchV1Campaign", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactCampaignOneResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *CampaignsAPI) PostV1CampaignCancel(campaignId string, opts *DynamicRequestOptions) (*openapimodels.NtfContactCampaignCancelResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"campaignId": campaignId}
	raw, err := n.api.client.DynamicApi.Call("campaigns.postV1CampaignCancel", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactCampaignCancelResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *CampaignsAPI) GetV1CampaignRecipients(campaignId string, channel *string, status *string, runId *string, page *int, pageSize *int, opts *DynamicRequestOptions) (*openapimodels.NtfContactCampaignRecipientsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if channel != nil { opts.Query["channel"] = fmt.Sprint(*channel) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if runId != nil { opts.Query["runId"] = fmt.Sprint(*runId) }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if pageSize != nil { opts.Query["pageSize"] = fmt.Sprint(*pageSize) }
	opts.PathParams = map[string]string{"campaignId": campaignId}
	raw, err := n.api.client.DynamicApi.Call("campaigns.getV1CampaignRecipients", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactCampaignRecipientsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *CampaignsAPI) PostV1CampaignRun(campaignId string, opts *DynamicRequestOptions) (*openapimodels.NtfContactCampaignRunResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"campaignId": campaignId}
	raw, err := n.api.client.DynamicApi.Call("campaigns.postV1CampaignRun", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactCampaignRunResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *CampaignsAPI) GetV1CampaignRunPreview(campaignId string, channels *string, excludeAlreadySent *string, opts *DynamicRequestOptions) (*openapimodels.NtfContactCampaignRunPreviewResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if channels != nil { opts.Query["channels"] = fmt.Sprint(*channels) }
	if excludeAlreadySent != nil { opts.Query["excludeAlreadySent"] = fmt.Sprint(*excludeAlreadySent) }
	opts.PathParams = map[string]string{"campaignId": campaignId}
	raw, err := n.api.client.DynamicApi.Call("campaigns.getV1CampaignRunPreview", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactCampaignRunPreviewResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *CampaignsAPI) GetV1CampaignStats(campaignId string, runId *string, opts *DynamicRequestOptions) (*openapimodels.NtfContactCampaignStatsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if runId != nil { opts.Query["runId"] = fmt.Sprint(*runId) }
	opts.PathParams = map[string]string{"campaignId": campaignId}
	raw, err := n.api.client.DynamicApi.Call("campaigns.getV1CampaignStats", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactCampaignStatsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type ContactsAPI struct { api *TypedAPI }
func (t *TypedAPI) Contacts() *ContactsAPI { return &ContactsAPI{api: t} }
func (n *ContactsAPI) GetV1Contacts(page *string, limit *string, search *string, tagId *string, opts *DynamicRequestOptions) (*openapimodels.NtfContactGetV1ContactsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	if tagId != nil { opts.Query["tagId"] = fmt.Sprint(*tagId) }
	raw, err := n.api.client.DynamicApi.Call("contacts.getV1Contacts", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactGetV1ContactsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ContactsAPI) PostV1Contacts(body *openapimodels.NtfContactContactCreate, opts *DynamicRequestOptions) (*openapimodels.NtfContactPostV1ContactsResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("contacts.postV1Contacts", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactPostV1ContactsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ContactsAPI) DeleteV1Contact(id string, opts *DynamicRequestOptions) (*openapimodels.NtfContactDeleteV1ContactResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("contacts.deleteV1Contact", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactDeleteV1ContactResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ContactsAPI) GetV1Contact(id string, opts *DynamicRequestOptions) (*openapimodels.NtfContactGetV1ContactResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("contacts.getV1Contact", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactGetV1ContactResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ContactsAPI) PutV1Contact(id string, body *openapimodels.NtfContactContactUpdate, opts *DynamicRequestOptions) (*openapimodels.NtfContactPutV1ContactResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("contacts.putV1Contact", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactPutV1ContactResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type ConversionsAPI struct { api *TypedAPI }
func (t *TypedAPI) Conversions() *ConversionsAPI { return &ConversionsAPI{api: t} }
func (n *ConversionsAPI) PostV1Conversions(opts *DynamicRequestOptions) (*openapimodels.NtfConversionsPostV1ConversionsResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("conversions.postV1Conversions", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfConversionsPostV1ConversionsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type EmailAPI struct { api *TypedAPI }
func (t *TypedAPI) Email() *EmailAPI { return &EmailAPI{api: t} }
func (n *EmailAPI) GetV1EmailDomains(opts *DynamicRequestOptions) (*openapimodels.NtfEmailListEmailDomainsResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("email.getV1EmailDomains", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailListEmailDomainsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailAPI) PostV1EmailDomains(body *openapimodels.NtfEmailCreateEmailDomainRequest, opts *DynamicRequestOptions) (*openapimodels.NtfEmailCreateEmailDomainResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("email.postV1EmailDomains", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailCreateEmailDomainResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailAPI) GetV1EmailDomainById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfEmailEmailDomainResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("email.getV1EmailDomainById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailEmailDomainResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailAPI) GetV1EmailInbound(page *string, limit *string, q *string, domainId *string, dateFrom *string, dateTo *string, opts *DynamicRequestOptions) (*openapimodels.NtfEmailGetV1EmailInboundResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if q != nil { opts.Query["q"] = fmt.Sprint(*q) }
	if domainId != nil { opts.Query["domainId"] = fmt.Sprint(*domainId) }
	if dateFrom != nil { opts.Query["dateFrom"] = fmt.Sprint(*dateFrom) }
	if dateTo != nil { opts.Query["dateTo"] = fmt.Sprint(*dateTo) }
	raw, err := n.api.client.DynamicApi.Call("email.getV1EmailInbound", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailGetV1EmailInboundResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailAPI) GetV1EmailInboundById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfEmailGetV1EmailInboundByIdResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("email.getV1EmailInboundById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailGetV1EmailInboundByIdResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailAPI) GetV1EmailMessages(page *string, limit *string, fromDate *string, toDate *string, status *string, emailDomainId *string, opts *DynamicRequestOptions) (*openapimodels.NtfEmailGetV1EmailMessagesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if fromDate != nil { opts.Query["fromDate"] = fmt.Sprint(*fromDate) }
	if toDate != nil { opts.Query["toDate"] = fmt.Sprint(*toDate) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if emailDomainId != nil { opts.Query["emailDomainId"] = fmt.Sprint(*emailDomainId) }
	raw, err := n.api.client.DynamicApi.Call("email.getV1EmailMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailGetV1EmailMessagesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailAPI) PostV1EmailSend(body *openapimodels.NtfEmailSendEmailRequest, opts *DynamicRequestOptions) (*openapimodels.NtfEmailSendEmailResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("email.postV1EmailSend", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailSendEmailResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailAPI) GetV1EmailById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfEmailEmailStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("email.getV1EmailById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailEmailStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailAPI) Domains() *EmailDomainsAPI { return &EmailDomainsAPI{api: n.api} }
type EmailDomainsAPI struct { api *TypedAPI }
func (n *EmailDomainsAPI) PostV1EmailDomainExpandProviders(id string, opts *DynamicRequestOptions) (*openapimodels.NtfEmailExpandEmailDomainProvidersResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("email.domains.postV1EmailDomainExpandProviders", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailExpandEmailDomainProvidersResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailDomainsAPI) PostV1EmailDomainVerify(id string, opts *DynamicRequestOptions) (*openapimodels.NtfEmailVerifyEmailDomainResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("email.domains.postV1EmailDomainVerify", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailVerifyEmailDomainResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EmailAPI) Messages() *EmailMessagesAPI { return &EmailMessagesAPI{api: n.api} }
type EmailMessagesAPI struct { api *TypedAPI }
func (n *EmailMessagesAPI) PostV1EmailCancel(id string, opts *DynamicRequestOptions) (*openapimodels.NtfEmailCancelEmailResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("email.messages.postV1EmailCancel", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfEmailCancelEmailResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type EventsAPI struct { api *TypedAPI }
func (t *TypedAPI) Events() *EventsAPI { return &EventsAPI{api: t} }
func (n *EventsAPI) ListEvents(page *string, limit *string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoListEventsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	raw, err := n.api.client.DynamicApi.Call("events.listEvents", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoListEventsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EventsAPI) CreateEvent(body *openapimodels.NtfAutoEventCreateBody, opts *DynamicRequestOptions) (*openapimodels.NtfAutoCreateEventResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("events.createEvent", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoCreateEventResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EventsAPI) DeleteEvent(eventId string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoDeleteEventResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"eventId": eventId}
	raw, err := n.api.client.DynamicApi.Call("events.deleteEvent", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoDeleteEventResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EventsAPI) GetEvent(eventId string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoGetEventResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"eventId": eventId}
	raw, err := n.api.client.DynamicApi.Call("events.getEvent", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoGetEventResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EventsAPI) PatchEvent(eventId string, body *openapimodels.NtfAutoEventPatchBody, opts *DynamicRequestOptions) (*openapimodels.NtfAutoPatchEventResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"eventId": eventId}
	raw, err := n.api.client.DynamicApi.Call("events.patchEvent", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoPatchEventResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EventsAPI) SendEvent(body *openapimodels.NtfAutoEventSendBody, opts *DynamicRequestOptions) (*openapimodels.NtfAutoSendEventResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("events.sendEvent", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoSendEventResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *EventsAPI) Batch() *EventsBatchAPI { return &EventsBatchAPI{api: n.api} }
type EventsBatchAPI struct { api *TypedAPI }
func (n *EventsBatchAPI) BatchDeleteEvents(opts *DynamicRequestOptions) (*openapimodels.NtfAutoBatchDeleteEventsResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("events.batch.batchDeleteEvents", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoBatchDeleteEventsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type FormsAPI struct { api *TypedAPI }
func (t *TypedAPI) Forms() *FormsAPI { return &FormsAPI{api: t} }
func (n *FormsAPI) GetV1FormsLists(page *string, limit *string, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsFormListCollectionEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	raw, err := n.api.client.DynamicApi.Call("forms.getV1FormsLists", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsFormListCollectionEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsAPI) PostV1FormsLists(body *openapimodels.NtfAddonsCreateFormListRequest, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsFormListEnvelope, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("forms.postV1FormsLists", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsFormListEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsAPI) DeleteV1FormsList(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsFormDeleteEnvelope, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("forms.deleteV1FormsList", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsFormDeleteEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsAPI) GetV1FormsList(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsFormListEnvelope, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("forms.getV1FormsList", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsFormListEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsAPI) PatchV1FormsList(id string, body *openapimodels.NtfAddonsPatchFormListRequest, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsFormListPatchEnvelope, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("forms.patchV1FormsList", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsFormListPatchEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsAPI) GetV1FormsSubscriptionsAll(page *string, limit *string, listId *string, status *string, search *string, subscribedFrom *string, subscribedTo *string, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsGetV1FormsSubscriptionsAllResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if listId != nil { opts.Query["listId"] = fmt.Sprint(*listId) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	if subscribedFrom != nil { opts.Query["subscribedFrom"] = fmt.Sprint(*subscribedFrom) }
	if subscribedTo != nil { opts.Query["subscribedTo"] = fmt.Sprint(*subscribedTo) }
	raw, err := n.api.client.DynamicApi.Call("forms.getV1FormsSubscriptionsAll", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsGetV1FormsSubscriptionsAllResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsAPI) PostV1FormsSubscriptions(body *openapimodels.NtfAddonsFormSubscribeRequest, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsFormSubscribeEnvelope, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("forms.postV1FormsSubscriptions", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsFormSubscribeEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsAPI) Lists() *FormsListsAPI { return &FormsListsAPI{api: n.api} }
type FormsListsAPI struct { api *TypedAPI }
func (n *FormsListsAPI) GetV1FormsListSubscriptions(id string, page *string, limit *string, status *string, search *string, subscribedFrom *string, subscribedTo *string, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsFormSubscriptionCollectionEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	if subscribedFrom != nil { opts.Query["subscribedFrom"] = fmt.Sprint(*subscribedFrom) }
	if subscribedTo != nil { opts.Query["subscribedTo"] = fmt.Sprint(*subscribedTo) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("forms.lists.getV1FormsListSubscriptions", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsFormSubscriptionCollectionEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsListsAPI) DeleteV1FormsSubscription(opts *DynamicRequestOptions) (*openapimodels.NtfAddonsDeleteV1FormsSubscriptionResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("forms.lists.deleteV1FormsSubscription", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsDeleteV1FormsSubscriptionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsListsAPI) GetV1FormsSubscriptionExport(id string, status *string, search *string, subscribedFrom *string, subscribedTo *string, opts *DynamicRequestOptions) (string, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	if subscribedFrom != nil { opts.Query["subscribedFrom"] = fmt.Sprint(*subscribedFrom) }
	if subscribedTo != nil { opts.Query["subscribedTo"] = fmt.Sprint(*subscribedTo) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("forms.lists.getV1FormsSubscriptionExport", *opts)
	if err != nil { return "", err }
	return string(raw), nil
}

func (n *FormsListsAPI) GetV1FormsSubscriptionStats(id string, trendDays *int, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsGetV1FormsSubscriptionStatsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if trendDays != nil { opts.Query["trendDays"] = fmt.Sprint(*trendDays) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("forms.lists.getV1FormsSubscriptionStats", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsGetV1FormsSubscriptionStatsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsAPI) Subscriptions() *FormsSubscriptionsAPI { return &FormsSubscriptionsAPI{api: n.api} }
type FormsSubscriptionsAPI struct { api *TypedAPI }
func (n *FormsSubscriptionsAPI) PostV1FormsSubscriptionCancel(id string, body *openapimodels.NtfAddonsNewsletterCancelRequest, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsNewsletterCancelEnvelope, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("forms.subscriptions.postV1FormsSubscriptionCancel", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsNewsletterCancelEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *FormsSubscriptionsAPI) PostV1FormsSubscriptionsConfirm(body *openapimodels.NtfAddonsFormConfirmRequest, opts *DynamicRequestOptions) (*openapimodels.NtfAddonsFormConfirmEnvelope, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("forms.subscriptions.postV1FormsSubscriptionsConfirm", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAddonsFormConfirmEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type HttpToolsAPI struct { api *TypedAPI }
func (t *TypedAPI) HttpTools() *HttpToolsAPI { return &HttpToolsAPI{api: t} }
func (n *HttpToolsAPI) HttpList(opts *DynamicRequestOptions) (*openapimodels.NtfAutoHttpListResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("httpTools.httpList", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoHttpListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *HttpToolsAPI) HttpCreate(opts *DynamicRequestOptions) (*openapimodels.NtfAutoHttpCreateResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("httpTools.httpCreate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoHttpCreateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *HttpToolsAPI) HttpDelete(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoHttpDeleteResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("httpTools.httpDelete", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoHttpDeleteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *HttpToolsAPI) HttpGet(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoHttpGetResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("httpTools.httpGet", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoHttpGetResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *HttpToolsAPI) HttpUpdate(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoHttpUpdateResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("httpTools.httpUpdate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoHttpUpdateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type InstagramAPI struct { api *TypedAPI }
func (t *TypedAPI) Instagram() *InstagramAPI { return &InstagramAPI{api: t} }
func (n *InstagramAPI) ListComments(instanceId *string, opts *DynamicRequestOptions) (*openapimodels.NtfIgListCommentsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if instanceId != nil { opts.Query["instanceId"] = fmt.Sprint(*instanceId) }
	raw, err := n.api.client.DynamicApi.Call("instagram.listComments", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgListCommentsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) DeleteComment(commentId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgDeleteCommentResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"commentId": commentId}
	raw, err := n.api.client.DynamicApi.Call("instagram.deleteComment", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgDeleteCommentResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) GetComment(commentId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgGetCommentResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"commentId": commentId}
	raw, err := n.api.client.DynamicApi.Call("instagram.getComment", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgGetCommentResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) ListInstances(page *string, limit *string, status *string, search *string, opts *DynamicRequestOptions) (*openapimodels.NtfIgListInstancesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	raw, err := n.api.client.DynamicApi.Call("instagram.listInstances", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgListInstancesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) CreateInstance(body *openapimodels.NtfIgCreateInstanceBody, opts *DynamicRequestOptions) (*openapimodels.NtfIgCreateInstanceResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("instagram.createInstance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgCreateInstanceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) DeleteInstance(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgDeleteInstanceResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("instagram.deleteInstance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgDeleteInstanceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) GetInstance(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgInstanceDetail, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("instagram.getInstance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgInstanceDetail
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) ListMessages(page *string, limit *string, instanceIds *string, status *string, typeParam *string, opts *DynamicRequestOptions) (*openapimodels.NtfIgListMessagesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if instanceIds != nil { opts.Query["instanceIds"] = fmt.Sprint(*instanceIds) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if typeParam != nil { opts.Query["type"] = fmt.Sprint(*typeParam) }
	raw, err := n.api.client.DynamicApi.Call("instagram.listMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgListMessagesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) SendMessage(body *openapimodels.NtfIgSendMessageBody, opts *DynamicRequestOptions) (*openapimodels.NtfIgSendMessageResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("instagram.sendMessage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgSendMessageResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) DeleteMessage(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgDeleteMessageResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("instagram.deleteMessage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgDeleteMessageResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) GetMessage(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgGetMessageResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("instagram.getMessage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgGetMessageResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) Comments() *InstagramCommentsAPI { return &InstagramCommentsAPI{api: n.api} }
type InstagramCommentsAPI struct { api *TypedAPI }
func (n *InstagramCommentsAPI) HideComment(commentId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgHideCommentResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"commentId": commentId}
	raw, err := n.api.client.DynamicApi.Call("instagram.comments.hideComment", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgHideCommentResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramCommentsAPI) ReplyComment(commentId string, body *openapimodels.NtfIgReplyCommentBody, opts *DynamicRequestOptions) (*openapimodels.NtfIgReplyCommentResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"commentId": commentId}
	raw, err := n.api.client.DynamicApi.Call("instagram.comments.replyComment", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgReplyCommentResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) Instances() *InstagramInstancesAPI { return &InstagramInstancesAPI{api: n.api} }
type InstagramInstancesAPI struct { api *TypedAPI }
func (n *InstagramInstancesAPI) ResolveChallenge(instanceId string, body *openapimodels.NtfIgResolveChallengeBody, opts *DynamicRequestOptions) (*openapimodels.NtfIgResolveChallengeResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("instagram.instances.resolveChallenge", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgResolveChallengeResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramInstancesAPI) GetConnectPage(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgConnectPageStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("instagram.instances.getConnectPage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgConnectPageStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramInstancesAPI) DisableConnectPage(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgConnectPageDisableResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("instagram.instances.disableConnectPage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgConnectPageDisableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramInstancesAPI) EnableConnectPage(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgConnectPageEnableResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("instagram.instances.enableConnectPage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgConnectPageEnableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramInstancesAPI) RotateConnectPage(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgConnectPageEnableResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("instagram.instances.rotateConnectPage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgConnectPageEnableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramInstancesAPI) GetConnection(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgConnectionStatus, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("instagram.instances.getConnection", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgConnectionStatus
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramInstancesAPI) DisconnectInstance(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgDisconnectInstanceResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("instagram.instances.disconnectInstance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgDisconnectInstanceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramAPI) Messages() *InstagramMessagesAPI { return &InstagramMessagesAPI{api: n.api} }
type InstagramMessagesAPI struct { api *TypedAPI }
func (n *InstagramMessagesAPI) CancelMessage(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfIgCancelMessageResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("instagram.messages.cancelMessage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgCancelMessageResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramMessagesAPI) EditMessage(messageId string, body *openapimodels.NtfIgEditMessageBody, opts *DynamicRequestOptions) (*openapimodels.NtfIgEditMessageResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("instagram.messages.editMessage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgEditMessageResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramMessagesAPI) ListInbound(opts *DynamicRequestOptions) (*openapimodels.NtfIgListInboundResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("instagram.messages.listInbound", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgListInboundResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramMessagesAPI) GetInbound(id string, opts *DynamicRequestOptions) (*openapimodels.NtfIgGetInboundResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("instagram.messages.getInbound", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgGetInboundResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramMessagesAPI) PostInboundMedia(id string, opts *DynamicRequestOptions) (*openapimodels.NtfIgPostInboundMediaResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("instagram.messages.postInboundMedia", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfIgPostInboundMediaResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *InstagramMessagesAPI) GetInboundMediaDownload(id string, opts *DynamicRequestOptions) ([]byte, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("instagram.messages.getInboundMediaDownload", *opts)
	if err != nil { return nil, err }
	return []byte(raw), nil
}

type KnowledgeBasesAPI struct { api *TypedAPI }
func (t *TypedAPI) KnowledgeBases() *KnowledgeBasesAPI { return &KnowledgeBasesAPI{api: t} }
func (n *KnowledgeBasesAPI) KbList(page *string, limit *string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbList", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *KnowledgeBasesAPI) KbCreate(opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbCreateResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbCreate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbCreateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *KnowledgeBasesAPI) KbDelete(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbDeleteResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbDelete", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbDeleteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *KnowledgeBasesAPI) KbGet(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbGetResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbGet", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbGetResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *KnowledgeBasesAPI) KbUpdate(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbUpdateResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbUpdate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbUpdateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *KnowledgeBasesAPI) KbListDocs(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbListDocsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbListDocs", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbListDocsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *KnowledgeBasesAPI) KbCreateDoc(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbCreateDocResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbCreateDoc", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbCreateDocResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *KnowledgeBasesAPI) KbDeleteDoc(opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbDeleteDocResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbDeleteDoc", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbDeleteDocResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *KnowledgeBasesAPI) KbGetDoc(opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbGetDocResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbGetDoc", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbGetDocResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *KnowledgeBasesAPI) KbUpdateDoc(opts *DynamicRequestOptions) (*openapimodels.NtfAutoKbUpdateDocResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("knowledgeBases.kbUpdateDoc", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoKbUpdateDocResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type LogsAPI struct { api *TypedAPI }
func (t *TypedAPI) Logs() *LogsAPI { return &LogsAPI{api: t} }
func (n *LogsAPI) GetV1Logs(page *int, limit *int, status *string, startDate *string, endDate *string, method *string, apiKeyId *string, opts *DynamicRequestOptions) (*openapimodels.LogsListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if startDate != nil { opts.Query["startDate"] = fmt.Sprint(*startDate) }
	if endDate != nil { opts.Query["endDate"] = fmt.Sprint(*endDate) }
	if method != nil { opts.Query["method"] = fmt.Sprint(*method) }
	if apiKeyId != nil { opts.Query["apiKeyId"] = fmt.Sprint(*apiKeyId) }
	raw, err := n.api.client.DynamicApi.Call("logs.getV1Logs", *opts)
	if err != nil { return nil, err }
	var out openapimodels.LogsListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *LogsAPI) GetV1LogsById(id string, opts *DynamicRequestOptions) (*openapimodels.GetV1LogsByIdResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("logs.getV1LogsById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.GetV1LogsByIdResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type McpConnectionsAPI struct { api *TypedAPI }
func (t *TypedAPI) McpConnections() *McpConnectionsAPI { return &McpConnectionsAPI{api: t} }
func (n *McpConnectionsAPI) McpList(opts *DynamicRequestOptions) (*openapimodels.NtfAutoMcpListResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("mcpConnections.mcpList", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoMcpListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *McpConnectionsAPI) McpCreate(opts *DynamicRequestOptions) (*openapimodels.NtfAutoMcpCreateResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("mcpConnections.mcpCreate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoMcpCreateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *McpConnectionsAPI) McpDelete(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoMcpDeleteResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("mcpConnections.mcpDelete", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoMcpDeleteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *McpConnectionsAPI) McpGet(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoMcpGetResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("mcpConnections.mcpGet", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoMcpGetResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *McpConnectionsAPI) McpUpdate(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoMcpUpdateResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("mcpConnections.mcpUpdate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoMcpUpdateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *McpConnectionsAPI) McpRefreshManifest(id string, opts *DynamicRequestOptions) (*openapimodels.NtfAutoMcpRefreshManifestResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("mcpConnections.mcpRefreshManifest", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfAutoMcpRefreshManifestResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type MetaAPI struct { api *TypedAPI }
func (t *TypedAPI) Meta() *MetaAPI { return &MetaAPI{api: t} }
func (n *MetaAPI) GetV1MetaContactLocales(opts *DynamicRequestOptions) (*openapimodels.NtfContactGetV1MetaContactLocalesResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("meta.getV1MetaContactLocales", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactGetV1MetaContactLocalesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type MetricsAPI struct { api *TypedAPI }
func (t *TypedAPI) Metrics() *MetricsAPI { return &MetricsAPI{api: t} }
func (n *MetricsAPI) GetMetricsOverview(opts *DynamicRequestOptions) (*openapimodels.NtfPlatformGetMetricsOverviewResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("metrics.getMetricsOverview", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformGetMetricsOverviewResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type NotifyAPI struct { api *TypedAPI }
func (t *TypedAPI) Notify() *NotifyAPI { return &NotifyAPI{api: t} }
func (n *NotifyAPI) PostNotify(opts *DynamicRequestOptions) (*openapimodels.NtfPlatformPostNotifyResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("notify.postNotify", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformPostNotifyResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type PhoneNumbersAPI struct { api *TypedAPI }
func (t *TypedAPI) PhoneNumbers() *PhoneNumbersAPI { return &PhoneNumbersAPI{api: t} }
func (n *PhoneNumbersAPI) GetV1PhoneNumbers(opts *DynamicRequestOptions) (*openapimodels.NtfPhoneListEnvelope, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.getV1PhoneNumbers", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneListEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersAPI) GetV1PhoneNumbersById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPhoneSingleEnvelope, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.getV1PhoneNumbersById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneSingleEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersAPI) PatchV1PhoneNumbersById(id string, body *openapimodels.NtfPhoneUpdateBody, opts *DynamicRequestOptions) (*openapimodels.NtfPhoneSingleEnvelope, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.patchV1PhoneNumbersById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneSingleEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersAPI) GetV1PhoneNumbersAvailable(countryCode *string, phoneNumberType *string, areaCode *string, contains *string, opts *DynamicRequestOptions) (*openapimodels.NtfPhoneGetV1PhoneNumbersAvailableResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if countryCode != nil { opts.Query["countryCode"] = fmt.Sprint(*countryCode) }
	if phoneNumberType != nil { opts.Query["phoneNumberType"] = fmt.Sprint(*phoneNumberType) }
	if areaCode != nil { opts.Query["areaCode"] = fmt.Sprint(*areaCode) }
	if contains != nil { opts.Query["contains"] = fmt.Sprint(*contains) }
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.getV1PhoneNumbersAvailable", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneGetV1PhoneNumbersAvailableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersAPI) Config(opts *DynamicRequestOptions) (*openapimodels.NtfPhoneConfigResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.config", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneConfigResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersAPI) CreateOrder(opts *DynamicRequestOptions) (*openapimodels.NtfPhoneCreateOrderResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.createOrder", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneCreateOrderResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersAPI) GetOrder(orderId string, opts *DynamicRequestOptions) (*openapimodels.NtfPhoneGetOrderResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"orderId": orderId}
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.getOrder", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneGetOrderResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersAPI) Orders() *PhoneNumbersOrdersAPI { return &PhoneNumbersOrdersAPI{api: n.api} }
type PhoneNumbersOrdersAPI struct { api *TypedAPI }
func (n *PhoneNumbersOrdersAPI) RegDocument(orderId string, opts *DynamicRequestOptions) (*openapimodels.NtfPhoneRegDocumentResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"orderId": orderId}
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.orders.regDocument", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneRegDocumentResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersOrdersAPI) RegStatus(orderId string, opts *DynamicRequestOptions) (*openapimodels.NtfPhoneRegStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"orderId": orderId}
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.orders.regStatus", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneRegStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersOrdersAPI) RegSubmit(orderId string, opts *DynamicRequestOptions) (*openapimodels.NtfPhoneRegSubmitResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"orderId": orderId}
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.orders.regSubmit", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneRegSubmitResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersOrdersAPI) ReplacementOptions(orderId string, opts *DynamicRequestOptions) (*openapimodels.NtfPhoneReplacementOptionsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"orderId": orderId}
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.orders.replacementOptions", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneReplacementOptionsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersOrdersAPI) SelectReplacement(orderId string, opts *DynamicRequestOptions) (*openapimodels.NtfPhoneSelectReplacementResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"orderId": orderId}
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.orders.selectReplacement", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneSelectReplacementResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersAPI) Regulatory() *PhoneNumbersRegulatoryAPI { return &PhoneNumbersRegulatoryAPI{api: n.api} }
type PhoneNumbersRegulatoryAPI struct { api *TypedAPI }
func (n *PhoneNumbersRegulatoryAPI) RegProfile(opts *DynamicRequestOptions) (*openapimodels.NtfPhoneRegProfileResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.regulatory.regProfile", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneRegProfileResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PhoneNumbersRegulatoryAPI) RegRequirements(opts *DynamicRequestOptions) (*openapimodels.NtfPhoneRegRequirementsResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("phoneNumbers.regulatory.regRequirements", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPhoneRegRequirementsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type PipelinesAPI struct { api *TypedAPI }
func (t *TypedAPI) Pipelines() *PipelinesAPI { return &PipelinesAPI{api: t} }
func (n *PipelinesAPI) ListBoards(opts *DynamicRequestOptions) (*openapimodels.NtfPipeListBoardsResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("pipelines.listBoards", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipeListBoardsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PipelinesAPI) CreateBoard(opts *DynamicRequestOptions) (*openapimodels.NtfPipeCreateBoardResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("pipelines.createBoard", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipeCreateBoardResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PipelinesAPI) GetBoard(boardId string, opts *DynamicRequestOptions) (*openapimodels.NtfPipeGetBoardResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"boardId": boardId}
	raw, err := n.api.client.DynamicApi.Call("pipelines.getBoard", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipeGetBoardResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PipelinesAPI) PatchBoard(boardId string, opts *DynamicRequestOptions) (*openapimodels.NtfPipePatchBoardResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"boardId": boardId}
	raw, err := n.api.client.DynamicApi.Call("pipelines.patchBoard", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipePatchBoardResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PipelinesAPI) PatchCard(cardId string, opts *DynamicRequestOptions) (*openapimodels.NtfPipePatchCardResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"cardId": cardId}
	raw, err := n.api.client.DynamicApi.Call("pipelines.patchCard", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipePatchCardResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PipelinesAPI) Boards() *PipelinesBoardsAPI { return &PipelinesBoardsAPI{api: n.api} }
type PipelinesBoardsAPI struct { api *TypedAPI }
func (n *PipelinesBoardsAPI) CreateCard(boardId string, opts *DynamicRequestOptions) (*openapimodels.NtfPipeCreateCardResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"boardId": boardId}
	raw, err := n.api.client.DynamicApi.Call("pipelines.boards.createCard", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipeCreateCardResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PipelinesBoardsAPI) ReplaceColumns(boardId string, opts *DynamicRequestOptions) (*openapimodels.NtfPipeReplaceColumnsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"boardId": boardId}
	raw, err := n.api.client.DynamicApi.Call("pipelines.boards.replaceColumns", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipeReplaceColumnsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PipelinesBoardsAPI) BoardOverview(boardId string, opts *DynamicRequestOptions) (*openapimodels.NtfPipeBoardOverviewResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"boardId": boardId}
	raw, err := n.api.client.DynamicApi.Call("pipelines.boards.boardOverview", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipeBoardOverviewResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PipelinesAPI) Cards() *PipelinesCardsAPI { return &PipelinesCardsAPI{api: n.api} }
type PipelinesCardsAPI struct { api *TypedAPI }
func (n *PipelinesCardsAPI) MoveCard(cardId string, opts *DynamicRequestOptions) (*openapimodels.NtfPipeMoveCardResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"cardId": cardId}
	raw, err := n.api.client.DynamicApi.Call("pipelines.cards.moveCard", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipeMoveCardResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PipelinesAPI) Contacts() *PipelinesContactsAPI { return &PipelinesContactsAPI{api: n.api} }
type PipelinesContactsAPI struct { api *TypedAPI }
func (n *PipelinesContactsAPI) ContactCards(contactId string, opts *DynamicRequestOptions) (*openapimodels.NtfPipeContactCardsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"contactId": contactId}
	raw, err := n.api.client.DynamicApi.Call("pipelines.contacts.contactCards", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPipeContactCardsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type PlatformAPI struct { api *TypedAPI }
func (t *TypedAPI) Platform() *PlatformAPI { return &PlatformAPI{api: t} }
func (n *PlatformAPI) ListApiKeys(includeRevoked *bool, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformListApiKeysResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if includeRevoked != nil { opts.Query["includeRevoked"] = fmt.Sprint(*includeRevoked) }
	raw, err := n.api.client.DynamicApi.Call("platform.listApiKeys", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformListApiKeysResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) CreateApiKey(body *openapimodels.NtfPlatformApiKeyCreate, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformCreateApiKeyResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("platform.createApiKey", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformCreateApiKeyResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) GetApiKey(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformGetApiKeyResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.getApiKey", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformGetApiKeyResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) PatchApiKey(id string, body *openapimodels.NtfPlatformApiKeyPatch, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformPatchApiKeyResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.patchApiKey", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformPatchApiKeyResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) PostLogin(body *openapimodels.NtfPlatformLoginBody, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformLoginResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("platform.postLogin", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformLoginResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) GetMe(opts *DynamicRequestOptions) (*openapimodels.NtfPlatformGetMeResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("platform.getMe", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformGetMeResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) PostRegister(body *openapimodels.NtfPlatformRegisterBody, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformRegisterResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("platform.postRegister", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformRegisterResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) PostVerify(body *openapimodels.NtfPlatformVerifyBody, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformVerifyResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("platform.postVerify", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformVerifyResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) ListUserWorkspaces(include *string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformListUserWorkspacesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if include != nil { opts.Query["include"] = fmt.Sprint(*include) }
	raw, err := n.api.client.DynamicApi.Call("platform.listUserWorkspaces", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformListUserWorkspacesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) ApiKeys() *PlatformApiKeysAPI { return &PlatformApiKeysAPI{api: n.api} }
type PlatformApiKeysAPI struct { api *TypedAPI }
func (n *PlatformApiKeysAPI) RevokeApiKey(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformRevokeApiKeyResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.apiKeys.revokeApiKey", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformRevokeApiKeyResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformAPI) Workspaces() *PlatformWorkspacesAPI { return &PlatformWorkspacesAPI{api: n.api} }
type PlatformWorkspacesAPI struct { api *TypedAPI }
func (n *PlatformWorkspacesAPI) GetBalance(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformGetBalanceResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.getBalance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformGetBalanceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) RechargeBalance(id string, body *openapimodels.NtfPlatformRechargeBody, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformRechargeBalanceResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.rechargeBalance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformRechargeBalanceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) GetCreditsUsage(id string, page *string, limit *string, chargedAs *string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformCreditsUsageResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if chargedAs != nil { opts.Query["chargedAs"] = fmt.Sprint(*chargedAs) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.getCreditsUsage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformCreditsUsageResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) ListInvites(id string, page *string, limit *string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformInvitesListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.listInvites", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformInvitesListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) CreateInvite(id string, body *openapimodels.NtfPlatformInviteBody, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformCreateInviteResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.createInvite", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformCreateInviteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) CancelInvite(opts *DynamicRequestOptions) (*openapimodels.NtfPlatformCancelInviteResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.cancelInvite", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformCancelInviteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) ListMembers(id string, page *string, limit *string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformMembersListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.listMembers", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformMembersListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) RemoveMember(opts *DynamicRequestOptions) (*openapimodels.NtfPlatformRemoveMemberResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.removeMember", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformRemoveMemberResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) ListPaymentMethods(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformListPaymentMethodsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.listPaymentMethods", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformListPaymentMethodsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) CreatePaymentMethod(id string, body *openapimodels.NtfPlatformPaymentMethodCreate, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformCreatePaymentMethodResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.createPaymentMethod", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformCreatePaymentMethodResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) DeletePaymentMethod(opts *DynamicRequestOptions) (*openapimodels.NtfPlatformDeletePaymentMethodResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.deletePaymentMethod", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformDeletePaymentMethodResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) UpdatePaymentMethod(opts *DynamicRequestOptions) (*openapimodels.NtfPlatformUpdatePaymentMethodResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.updatePaymentMethod", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformUpdatePaymentMethodResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) CancelSubscription(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformCancelSubscriptionResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.cancelSubscription", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformCancelSubscriptionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) GetWorkspaceSubscription(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformSubscriptionResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.getWorkspaceSubscription", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformSubscriptionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PlatformWorkspacesAPI) SubscribeWorkspace(id string, body *openapimodels.NtfPlatformSubscribeBody, opts *DynamicRequestOptions) (*openapimodels.NtfPlatformSubscribeWorkspaceResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("platform.workspaces.subscribeWorkspace", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformSubscribeWorkspaceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type PricingAPI struct { api *TypedAPI }
func (t *TypedAPI) Pricing() *PricingAPI { return &PricingAPI{api: t} }
func (n *PricingAPI) GetPricing(opts *DynamicRequestOptions) (*openapimodels.NtfPlatformGetPricingResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("pricing.getPricing", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPlatformGetPricingResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type PushAPI struct { api *TypedAPI }
func (t *TypedAPI) Push() *PushAPI { return &PushAPI{api: t} }
func (n *PushAPI) GetV1PushApps(page *int, limit *int, opts *DynamicRequestOptions) (*openapimodels.NtfPushPushAppListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	raw, err := n.api.client.DynamicApi.Call("push.getV1PushApps", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushPushAppListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) PostV1PushApps(body *openapimodels.NtfPushPushAppCreateRequest, opts *DynamicRequestOptions) (*openapimodels.NtfPushPushAppSingleResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("push.postV1PushApps", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushPushAppSingleResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) DeleteV1PushAppsById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPushDeleteV1PushAppsByIdResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("push.deleteV1PushAppsById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushDeleteV1PushAppsByIdResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) GetV1PushAppsById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPushPushAppSingleResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("push.getV1PushAppsById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushPushAppSingleResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) PutV1PushAppsById(id string, body *openapimodels.NtfPushPushAppUpdateRequest, opts *DynamicRequestOptions) (*openapimodels.NtfPushPushAppSingleResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("push.putV1PushAppsById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushPushAppSingleResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) GetV1PushDevices(page *int, limit *int, appId *string, platform *string, opts *DynamicRequestOptions) (*openapimodels.NtfPushPushDeviceListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if appId != nil { opts.Query["appId"] = fmt.Sprint(*appId) }
	if platform != nil { opts.Query["platform"] = fmt.Sprint(*platform) }
	raw, err := n.api.client.DynamicApi.Call("push.getV1PushDevices", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushPushDeviceListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) PostV1PushDevices(body *openapimodels.NtfPushPushDeviceRegisterRequest, opts *DynamicRequestOptions) (*openapimodels.NtfPushPushDeviceSingleResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("push.postV1PushDevices", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushPushDeviceSingleResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) DeleteV1PushDevicesById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPushDeleteV1PushDevicesByIdResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("push.deleteV1PushDevicesById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushDeleteV1PushDevicesByIdResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) GetV1PushDevicesById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPushPushDeviceSingleResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("push.getV1PushDevicesById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushPushDeviceSingleResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) GetV1PushMessages(page *int, limit *int, status *string, appId *string, opts *DynamicRequestOptions) (*openapimodels.NtfPushPushMessageListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if appId != nil { opts.Query["appId"] = fmt.Sprint(*appId) }
	raw, err := n.api.client.DynamicApi.Call("push.getV1PushMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushPushMessageListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) PostV1PushMessages(body *openapimodels.NtfPushSendPushRequest, opts *DynamicRequestOptions) (*openapimodels.NtfPushSendPushResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("push.postV1PushMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushSendPushResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) GetV1PushMessagesById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPushPushMessageSingleResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("push.getV1PushMessagesById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushPushMessageSingleResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *PushAPI) Messages() *PushMessagesAPI { return &PushMessagesAPI{api: n.api} }
type PushMessagesAPI struct { api *TypedAPI }
func (n *PushMessagesAPI) PostV1PushMessagesCancel(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPushCancelPushResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("push.messages.postV1PushMessagesCancel", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPushCancelPushResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type RcsAPI struct { api *TypedAPI }
func (t *TypedAPI) Rcs() *RcsAPI { return &RcsAPI{api: t} }
func (n *RcsAPI) GetV1RcsMessages(page *string, limit *string, fromDate *string, toDate *string, status *string, to *string, opts *DynamicRequestOptions) (*openapimodels.NtfRcsGetV1RcsMessagesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if fromDate != nil { opts.Query["fromDate"] = fmt.Sprint(*fromDate) }
	if toDate != nil { opts.Query["toDate"] = fmt.Sprint(*toDate) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if to != nil { opts.Query["to"] = fmt.Sprint(*to) }
	raw, err := n.api.client.DynamicApi.Call("rcs.getV1RcsMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfRcsGetV1RcsMessagesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *RcsAPI) PostV1RcsSend(body *openapimodels.NtfRcsSendRcsRequest, opts *DynamicRequestOptions) (*openapimodels.NtfRcsSendRcsResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("rcs.postV1RcsSend", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfRcsSendRcsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *RcsAPI) GetV1RcsById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfRcsRcsStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("rcs.getV1RcsById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfRcsRcsStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *RcsAPI) Messages() *RcsMessagesAPI { return &RcsMessagesAPI{api: n.api} }
type RcsMessagesAPI struct { api *TypedAPI }
func (n *RcsMessagesAPI) PostV1RcsCancel(id string, opts *DynamicRequestOptions) (*openapimodels.NtfRcsCancelRcsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("rcs.messages.postV1RcsCancel", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfRcsCancelRcsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type ReportAPI struct { api *TypedAPI }
func (t *TypedAPI) Report() *ReportAPI { return &ReportAPI{api: t} }
func (n *ReportAPI) PostV1Report(body *openapimodels.ReportRequest, opts *DynamicRequestOptions) (*openapimodels.ReportOkResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("report.postV1Report", *opts)
	if err != nil { return nil, err }
	var out openapimodels.ReportOkResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type SegmentsAPI struct { api *TypedAPI }
func (t *TypedAPI) Segments() *SegmentsAPI { return &SegmentsAPI{api: t} }
func (n *SegmentsAPI) GetV1Segments(opts *DynamicRequestOptions) (*openapimodels.NtfContactSegmentListResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("segments.getV1Segments", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactSegmentListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SegmentsAPI) PostV1Segments(body *openapimodels.NtfContactSegmentCreate, opts *DynamicRequestOptions) (*openapimodels.NtfContactSegmentOneResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("segments.postV1Segments", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactSegmentOneResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SegmentsAPI) DeleteV1Segment(segmentId string, opts *DynamicRequestOptions) (*openapimodels.NtfContactDeleteV1SegmentResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"segmentId": segmentId}
	raw, err := n.api.client.DynamicApi.Call("segments.deleteV1Segment", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactDeleteV1SegmentResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SegmentsAPI) GetV1SegmentById(segmentId string, opts *DynamicRequestOptions) (*openapimodels.NtfContactSegmentOneResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"segmentId": segmentId}
	raw, err := n.api.client.DynamicApi.Call("segments.getV1SegmentById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactSegmentOneResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SegmentsAPI) PatchV1Segment(segmentId string, body *openapimodels.NtfContactSegmentPatch, opts *DynamicRequestOptions) (*openapimodels.NtfContactSegmentOneResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"segmentId": segmentId}
	raw, err := n.api.client.DynamicApi.Call("segments.patchV1Segment", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactSegmentOneResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SegmentsAPI) GetV1SegmentPreview(segmentId string, page *string, limit *string, opts *DynamicRequestOptions) (*openapimodels.NtfContactSegmentPreviewResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	opts.PathParams = map[string]string{"segmentId": segmentId}
	raw, err := n.api.client.DynamicApi.Call("segments.getV1SegmentPreview", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactSegmentPreviewResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type SendingPoolsAPI struct { api *TypedAPI }
func (t *TypedAPI) SendingPools() *SendingPoolsAPI { return &SendingPoolsAPI{api: t} }
func (n *SendingPoolsAPI) List(opts *DynamicRequestOptions) (*openapimodels.NtfPoolListResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("sendingPools.list", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPoolListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SendingPoolsAPI) Create(opts *DynamicRequestOptions) (*openapimodels.NtfPoolCreateResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("sendingPools.create", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPoolCreateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SendingPoolsAPI) Delete(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPoolDeleteResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("sendingPools.delete", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPoolDeleteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SendingPoolsAPI) Get(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPoolGetResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("sendingPools.get", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPoolGetResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SendingPoolsAPI) Update(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPoolUpdateResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("sendingPools.update", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPoolUpdateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SendingPoolsAPI) AddMember(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPoolAddMemberResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("sendingPools.addMember", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPoolAddMemberResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SendingPoolsAPI) DeleteMember(opts *DynamicRequestOptions) (*openapimodels.NtfPoolDeleteMemberResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("sendingPools.deleteMember", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPoolDeleteMemberResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SendingPoolsAPI) UpdateMember(opts *DynamicRequestOptions) (*openapimodels.NtfPoolUpdateMemberResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("sendingPools.updateMember", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPoolUpdateMemberResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SendingPoolsAPI) Stats(id string, opts *DynamicRequestOptions) (*openapimodels.NtfPoolStatsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("sendingPools.stats", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfPoolStatsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type ShortLinksAPI struct { api *TypedAPI }
func (t *TypedAPI) ShortLinks() *ShortLinksAPI { return &ShortLinksAPI{api: t} }
func (n *ShortLinksAPI) GetV1ShortLinks(page *string, limit *string, source *string, opts *DynamicRequestOptions) (*openapimodels.NtfShortLinksListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if source != nil { opts.Query["source"] = fmt.Sprint(*source) }
	raw, err := n.api.client.DynamicApi.Call("shortLinks.getV1ShortLinks", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfShortLinksListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ShortLinksAPI) PostV1ShortLinks(body *openapimodels.NtfShortLinksCreateRequest, opts *DynamicRequestOptions) (*openapimodels.NtfShortLinksCreateResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("shortLinks.postV1ShortLinks", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfShortLinksCreateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ShortLinksAPI) DeleteV1ShortLinksById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfShortLinksDeleteResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("shortLinks.deleteV1ShortLinksById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfShortLinksDeleteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ShortLinksAPI) GetV1ShortLinksById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfShortLinksDetailResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("shortLinks.getV1ShortLinksById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfShortLinksDetailResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ShortLinksAPI) PatchV1ShortLinksById(id string, body *openapimodels.NtfShortLinksPatchRequest, opts *DynamicRequestOptions) (*openapimodels.NtfShortLinksDetailResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("shortLinks.patchV1ShortLinksById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfShortLinksDetailResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ShortLinksAPI) GetV1ShortLinksAnalytics(id string, granularity *string, start *string, endParam *string, opts *DynamicRequestOptions) (*openapimodels.NtfShortLinksAnalyticsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if granularity != nil { opts.Query["granularity"] = fmt.Sprint(*granularity) }
	if start != nil { opts.Query["start"] = fmt.Sprint(*start) }
	if endParam != nil { opts.Query["end"] = fmt.Sprint(*endParam) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("shortLinks.getV1ShortLinksAnalytics", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfShortLinksAnalyticsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *ShortLinksAPI) GetV1ShortLinksClicks(id string, page *string, limit *string, opts *DynamicRequestOptions) (*openapimodels.NtfShortLinksClicksListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("shortLinks.getV1ShortLinksClicks", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfShortLinksClicksListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type SmsAPI struct { api *TypedAPI }
func (t *TypedAPI) Sms() *SmsAPI { return &SmsAPI{api: t} }
func (n *SmsAPI) GetV1SmsInbound(page *string, limit *string, q *string, provider *string, linked *string, dateFrom *string, dateTo *string, opts *DynamicRequestOptions) (*openapimodels.NtfSmsGetV1SmsInboundResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if q != nil { opts.Query["q"] = fmt.Sprint(*q) }
	if provider != nil { opts.Query["provider"] = fmt.Sprint(*provider) }
	if linked != nil { opts.Query["linked"] = fmt.Sprint(*linked) }
	if dateFrom != nil { opts.Query["dateFrom"] = fmt.Sprint(*dateFrom) }
	if dateTo != nil { opts.Query["dateTo"] = fmt.Sprint(*dateTo) }
	raw, err := n.api.client.DynamicApi.Call("sms.getV1SmsInbound", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSmsGetV1SmsInboundResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SmsAPI) GetV1SmsInboundById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfSmsGetV1SmsInboundByIdResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("sms.getV1SmsInboundById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSmsGetV1SmsInboundByIdResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SmsAPI) GetV1SmsMessages(page *string, limit *string, fromDate *string, toDate *string, status *string, opts *DynamicRequestOptions) (*openapimodels.NtfSmsGetV1SmsMessagesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if fromDate != nil { opts.Query["fromDate"] = fmt.Sprint(*fromDate) }
	if toDate != nil { opts.Query["toDate"] = fmt.Sprint(*toDate) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	raw, err := n.api.client.DynamicApi.Call("sms.getV1SmsMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSmsGetV1SmsMessagesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SmsAPI) PostV1SmsSend(body *openapimodels.NtfSmsSendSmsRequest, opts *DynamicRequestOptions) (*openapimodels.NtfSmsSendSmsResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("sms.postV1SmsSend", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSmsSendSmsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SmsAPI) GetV1SmsById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfSmsSmsStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("sms.getV1SmsById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSmsSmsStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SmsAPI) Messages() *SmsMessagesAPI { return &SmsMessagesAPI{api: n.api} }
type SmsMessagesAPI struct { api *TypedAPI }
func (n *SmsMessagesAPI) PostV1SmsCancel(id string, opts *DynamicRequestOptions) (*openapimodels.NtfSmsCancelSmsResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("sms.messages.postV1SmsCancel", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSmsCancelSmsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type SuppressionsAPI struct { api *TypedAPI }
func (t *TypedAPI) Suppressions() *SuppressionsAPI { return &SuppressionsAPI{api: t} }
func (n *SuppressionsAPI) ListSuppressions(typeParam *string, reason *string, origin *string, channel *string, search *string, opts *DynamicRequestOptions) (*openapimodels.NtfSuppListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if typeParam != nil { opts.Query["type"] = fmt.Sprint(*typeParam) }
	if reason != nil { opts.Query["reason"] = fmt.Sprint(*reason) }
	if origin != nil { opts.Query["origin"] = fmt.Sprint(*origin) }
	if channel != nil { opts.Query["channel"] = fmt.Sprint(*channel) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	raw, err := n.api.client.DynamicApi.Call("suppressions.listSuppressions", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSuppListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SuppressionsAPI) CreateSuppression(body *openapimodels.NtfSuppSuppressionInput, opts *DynamicRequestOptions) (*openapimodels.NtfSuppSingleResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("suppressions.createSuppression", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSuppSingleResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SuppressionsAPI) RemoveSuppression(id string, opts *DynamicRequestOptions) (*openapimodels.NtfSuppRemoveResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("suppressions.removeSuppression", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSuppRemoveResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SuppressionsAPI) GetSuppression(id string, opts *DynamicRequestOptions) (*openapimodels.NtfSuppSingleResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("suppressions.getSuppression", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSuppSingleResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SuppressionsAPI) RemoveSuppressionByIdentity(opts *DynamicRequestOptions) (*openapimodels.NtfSuppRemoveResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("suppressions.removeSuppressionByIdentity", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSuppRemoveResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SuppressionsAPI) Batch() *SuppressionsBatchAPI { return &SuppressionsBatchAPI{api: n.api} }
type SuppressionsBatchAPI struct { api *TypedAPI }
func (n *SuppressionsBatchAPI) BatchAddSuppressions(body *openapimodels.NtfSuppBatchAddRequest, opts *DynamicRequestOptions) (*openapimodels.NtfSuppBatchAddResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("suppressions.batch.batchAddSuppressions", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSuppBatchAddResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *SuppressionsBatchAPI) BatchRemoveSuppressions(body *openapimodels.NtfSuppBatchRemoveRequest, opts *DynamicRequestOptions) (*openapimodels.NtfSuppBatchRemoveResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("suppressions.batch.batchRemoveSuppressions", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfSuppBatchRemoveResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type TagsAPI struct { api *TypedAPI }
func (t *TypedAPI) Tags() *TagsAPI { return &TagsAPI{api: t} }
func (n *TagsAPI) GetV1Tags(opts *DynamicRequestOptions) (*openapimodels.NtfContactGetV1TagsResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("tags.getV1Tags", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactGetV1TagsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TagsAPI) PostV1Tags(body *openapimodels.NtfContactTagCreate, opts *DynamicRequestOptions) (*openapimodels.NtfContactPostV1TagsResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("tags.postV1Tags", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactPostV1TagsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TagsAPI) DeleteV1Tag(id string, opts *DynamicRequestOptions) (*openapimodels.NtfContactDeleteV1TagResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("tags.deleteV1Tag", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactDeleteV1TagResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TagsAPI) GetV1Tag(id string, opts *DynamicRequestOptions) (*openapimodels.NtfContactGetV1TagResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("tags.getV1Tag", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactGetV1TagResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TagsAPI) PutV1Tag(id string, body *openapimodels.NtfContactTagUpdate, opts *DynamicRequestOptions) (*openapimodels.NtfContactPutV1TagResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("tags.putV1Tag", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactPutV1TagResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type TelegramAPI struct { api *TypedAPI }
func (t *TypedAPI) Telegram() *TelegramAPI { return &TelegramAPI{api: t} }
func (n *TelegramAPI) GetV1TelegramChats(page *string, limit *string, q *string, instanceId *string, status *string, opts *DynamicRequestOptions) (*openapimodels.NtfTgChatSubscriptionListEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if q != nil { opts.Query["q"] = fmt.Sprint(*q) }
	if instanceId != nil { opts.Query["instanceId"] = fmt.Sprint(*instanceId) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	raw, err := n.api.client.DynamicApi.Call("telegram.getV1TelegramChats", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgChatSubscriptionListEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) GetV1TelegramInstances(page *string, limit *string, status *string, search *string, opts *DynamicRequestOptions) (*openapimodels.NtfTgTelegramInstanceListEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	raw, err := n.api.client.DynamicApi.Call("telegram.getV1TelegramInstances", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgTelegramInstanceListEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) PostV1TelegramInstances(body *openapimodels.NtfTgCreateTelegramInstanceRequest, opts *DynamicRequestOptions) (*openapimodels.NtfTgCreateTelegramInstanceResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("telegram.postV1TelegramInstances", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgCreateTelegramInstanceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) DeleteV1TelegramInstance(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgInstanceDeletedResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("telegram.deleteV1TelegramInstance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgInstanceDeletedResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) GetV1TelegramInstance(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgInstanceDetailEnvelope, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("telegram.getV1TelegramInstance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgInstanceDetailEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) GetV1TelegramMessages(page *string, limit *string, fromDate *string, toDate *string, instanceIds *string, status *string, typeParam *string, includeEvents *string, opts *DynamicRequestOptions) (*openapimodels.NtfTgMessageListEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if fromDate != nil { opts.Query["fromDate"] = fmt.Sprint(*fromDate) }
	if toDate != nil { opts.Query["toDate"] = fmt.Sprint(*toDate) }
	if instanceIds != nil { opts.Query["instanceIds"] = fmt.Sprint(*instanceIds) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if typeParam != nil { opts.Query["type"] = fmt.Sprint(*typeParam) }
	if includeEvents != nil { opts.Query["includeEvents"] = fmt.Sprint(*includeEvents) }
	raw, err := n.api.client.DynamicApi.Call("telegram.getV1TelegramMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgMessageListEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) PostV1TelegramSend(body *openapimodels.NtfTgSendTelegramMessageRequest, opts *DynamicRequestOptions) (*openapimodels.NtfTgSendTelegramMessageAccepted, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("telegram.postV1TelegramSend", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgSendTelegramMessageAccepted
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) DeleteV1TelegramMessage(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgMessageIdStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("telegram.deleteV1TelegramMessage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgMessageIdStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) GetV1TelegramMessageById(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgMessageDetailEnvelope, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("telegram.getV1TelegramMessageById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgMessageDetailEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) Instances() *TelegramInstancesAPI { return &TelegramInstancesAPI{api: n.api} }
type TelegramInstancesAPI struct { api *TypedAPI }
func (n *TelegramInstancesAPI) NtfTelegramGetConnectPage(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgConnectPageStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("telegram.instances.ntfTelegramGetConnectPage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgConnectPageStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramInstancesAPI) NtfTelegramDisableConnectPage(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgConnectPageDisableResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("telegram.instances.ntfTelegramDisableConnectPage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgConnectPageDisableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramInstancesAPI) NtfTelegramEnableConnectPage(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgConnectPageEnableResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("telegram.instances.ntfTelegramEnableConnectPage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgConnectPageEnableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramInstancesAPI) NtfTelegramRotateConnectPage(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgConnectPageEnableResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("telegram.instances.ntfTelegramRotateConnectPage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgConnectPageEnableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramInstancesAPI) GetV1TelegramInstanceQr(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgQrEnvelope, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("telegram.instances.getV1TelegramInstanceQr", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgQrEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramInstancesAPI) PostV1TelegramInstanceQrCancel(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgQrCancelSuccess, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("telegram.instances.postV1TelegramInstanceQrCancel", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgQrCancelSuccess
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramInstancesAPI) PostV1TelegramInstanceSession(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgSessionSaveResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("telegram.instances.postV1TelegramInstanceSession", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgSessionSaveResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramAPI) Messages() *TelegramMessagesAPI { return &TelegramMessagesAPI{api: n.api} }
type TelegramMessagesAPI struct { api *TypedAPI }
func (n *TelegramMessagesAPI) PostV1TelegramMessageCancel(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgMessageIdStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("telegram.messages.postV1TelegramMessageCancel", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgMessageIdStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramMessagesAPI) PatchV1TelegramMessageEdit(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfTgMessageIdStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("telegram.messages.patchV1TelegramMessageEdit", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgMessageIdStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramMessagesAPI) GetV1TelegramInbound(page *string, limit *string, q *string, instanceId *string, dateFrom *string, dateTo *string, opts *DynamicRequestOptions) (*openapimodels.NtfTgInboundListEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if q != nil { opts.Query["q"] = fmt.Sprint(*q) }
	if instanceId != nil { opts.Query["instanceId"] = fmt.Sprint(*instanceId) }
	if dateFrom != nil { opts.Query["dateFrom"] = fmt.Sprint(*dateFrom) }
	if dateTo != nil { opts.Query["dateTo"] = fmt.Sprint(*dateTo) }
	raw, err := n.api.client.DynamicApi.Call("telegram.messages.getV1TelegramInbound", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgInboundListEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramMessagesAPI) GetV1TelegramInboundById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfTgInboundDetailEnvelope, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("telegram.messages.getV1TelegramInboundById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgInboundDetailEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramMessagesAPI) PostV1TelegramInboundMedia(id string, opts *DynamicRequestOptions) (*openapimodels.NtfTgPostV1TelegramInboundMediaResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("telegram.messages.postV1TelegramInboundMedia", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfTgPostV1TelegramInboundMediaResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TelegramMessagesAPI) GetV1TelegramInboundMediaDownload(id string, opts *DynamicRequestOptions) ([]byte, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("telegram.messages.getV1TelegramInboundMediaDownload", *opts)
	if err != nil { return nil, err }
	return []byte(raw), nil
}

type TemplatesAPI struct { api *TypedAPI }
func (t *TypedAPI) Templates() *TemplatesAPI { return &TemplatesAPI{api: t} }
func (n *TemplatesAPI) ListTemplates(page *int, limit *int, search *string, opts *DynamicRequestOptions) (*openapimodels.TemplateListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	raw, err := n.api.client.DynamicApi.Call("templates.listTemplates", *opts)
	if err != nil { return nil, err }
	var out openapimodels.TemplateListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TemplatesAPI) CreateTemplates(body *openapimodels.TemplateCreateRequest, opts *DynamicRequestOptions) (*openapimodels.TemplateResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("templates.createTemplates", *opts)
	if err != nil { return nil, err }
	var out openapimodels.TemplateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TemplatesAPI) DeleteTemplates(id string, opts *DynamicRequestOptions) (*openapimodels.TemplateDeleteResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("templates.deleteTemplates", *opts)
	if err != nil { return nil, err }
	var out openapimodels.TemplateDeleteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TemplatesAPI) GetTemplates(id string, opts *DynamicRequestOptions) (*openapimodels.TemplateResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("templates.getTemplates", *opts)
	if err != nil { return nil, err }
	var out openapimodels.TemplateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TemplatesAPI) UpdateTemplates(id string, body *openapimodels.TemplatePatchRequest, opts *DynamicRequestOptions) (*openapimodels.TemplateResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("templates.updateTemplates", *opts)
	if err != nil { return nil, err }
	var out openapimodels.TemplateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TemplatesAPI) CreateSend(body *openapimodels.TemplateSendRequest, opts *DynamicRequestOptions) (*openapimodels.TemplateSendResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("templates.createSend", *opts)
	if err != nil { return nil, err }
	var out openapimodels.TemplateSendResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type TopicsAPI struct { api *TypedAPI }
func (t *TypedAPI) Topics() *TopicsAPI { return &TopicsAPI{api: t} }
func (n *TopicsAPI) GetV1Topics(opts *DynamicRequestOptions) (*openapimodels.NtfContactTopicListResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("topics.getV1Topics", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactTopicListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TopicsAPI) PostV1Topics(body *openapimodels.NtfContactTopicCreate, opts *DynamicRequestOptions) (*openapimodels.NtfContactTopicOneResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("topics.postV1Topics", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactTopicOneResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TopicsAPI) DeleteV1Topic(topicId string, opts *DynamicRequestOptions) (*openapimodels.NtfContactDeleteV1TopicResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"topicId": topicId}
	raw, err := n.api.client.DynamicApi.Call("topics.deleteV1Topic", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactDeleteV1TopicResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TopicsAPI) GetV1TopicById(topicId string, opts *DynamicRequestOptions) (*openapimodels.NtfContactTopicOneResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"topicId": topicId}
	raw, err := n.api.client.DynamicApi.Call("topics.getV1TopicById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactTopicOneResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *TopicsAPI) PatchV1Topic(topicId string, body *openapimodels.NtfContactTopicPatch, opts *DynamicRequestOptions) (*openapimodels.NtfContactTopicOneResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"topicId": topicId}
	raw, err := n.api.client.DynamicApi.Call("topics.patchV1Topic", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfContactTopicOneResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type VoiceAPI struct { api *TypedAPI }
func (t *TypedAPI) Voice() *VoiceAPI { return &VoiceAPI{api: t} }
func (n *VoiceAPI) GetV1VoiceCalls(page *string, limit *string, direction *string, opts *DynamicRequestOptions) (*openapimodels.NtfVoiceListEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if direction != nil { opts.Query["direction"] = fmt.Sprint(*direction) }
	raw, err := n.api.client.DynamicApi.Call("voice.getV1VoiceCalls", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfVoiceListEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *VoiceAPI) PostV1VoiceCalls(body *openapimodels.NtfVoiceCreateBody, opts *DynamicRequestOptions) (*openapimodels.NtfVoiceSendSuccessEnvelope, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("voice.postV1VoiceCalls", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfVoiceSendSuccessEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *VoiceAPI) GetV1VoiceCallsById(id string, includeEvents *string, opts *DynamicRequestOptions) (*openapimodels.NtfVoiceDetailEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if includeEvents != nil { opts.Query["includeEvents"] = fmt.Sprint(*includeEvents) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("voice.getV1VoiceCallsById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfVoiceDetailEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *VoiceAPI) Calls() *VoiceCallsAPI { return &VoiceCallsAPI{api: n.api} }
type VoiceCallsAPI struct { api *TypedAPI }
func (n *VoiceCallsAPI) PostV1VoiceCallsAction(body *openapimodels.NtfVoiceActionBody, opts *DynamicRequestOptions) (*openapimodels.NtfVoicePostV1VoiceCallsActionResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("voice.calls.postV1VoiceCallsAction", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfVoicePostV1VoiceCallsActionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *VoiceCallsAPI) GetV1VoiceRecordingDownload(opts *DynamicRequestOptions) ([]byte, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("voice.calls.getV1VoiceRecordingDownload", *opts)
	if err != nil { return nil, err }
	return []byte(raw), nil
}

type WebhooksAPI struct { api *TypedAPI }
func (t *TypedAPI) Webhooks() *WebhooksAPI { return &WebhooksAPI{api: t} }
func (n *WebhooksAPI) ListWebhooks(page *int, limit *int, eventParam *string, opts *DynamicRequestOptions) (*openapimodels.NtfWhListWebhooksResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if eventParam != nil { opts.Query["event"] = fmt.Sprint(*eventParam) }
	raw, err := n.api.client.DynamicApi.Call("webhooks.listWebhooks", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWhListWebhooksResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WebhooksAPI) CreateWebhook(body *openapimodels.NtfWhWebhookInput, opts *DynamicRequestOptions) (*openapimodels.NtfWhCreateWebhookResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("webhooks.createWebhook", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWhCreateWebhookResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WebhooksAPI) DeleteWebhook(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWhDeleteWebhookResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("webhooks.deleteWebhook", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWhDeleteWebhookResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WebhooksAPI) GetWebhook(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWhGetWebhookResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("webhooks.getWebhook", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWhGetWebhookResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WebhooksAPI) UpdateWebhook(id string, body *openapimodels.NtfWhWebhookInput, opts *DynamicRequestOptions) (*openapimodels.NtfWhUpdateWebhookResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("webhooks.updateWebhook", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWhUpdateWebhookResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WebhooksAPI) RotateWebhookSecret(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWhRotateWebhookSecretResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("webhooks.rotateWebhookSecret", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWhRotateWebhookSecretResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WebhooksAPI) ListDeliveries(page *int, limit *int, success *bool, eventParam *string, webhook_id *string, messageId *string, search *string, opts *DynamicRequestOptions) (*openapimodels.NtfWhListDeliveriesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if success != nil { opts.Query["success"] = fmt.Sprint(*success) }
	if eventParam != nil { opts.Query["event"] = fmt.Sprint(*eventParam) }
	if webhook_id != nil { opts.Query["webhook_id"] = fmt.Sprint(*webhook_id) }
	if messageId != nil { opts.Query["messageId"] = fmt.Sprint(*messageId) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	raw, err := n.api.client.DynamicApi.Call("webhooks.listDeliveries", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWhListDeliveriesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WebhooksAPI) GetDelivery(deliveryId string, opts *DynamicRequestOptions) (*openapimodels.NtfWhGetDeliveryResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"deliveryId": deliveryId}
	raw, err := n.api.client.DynamicApi.Call("webhooks.getDelivery", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWhGetDeliveryResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WebhooksAPI) Deliveries() *WebhooksDeliveriesAPI { return &WebhooksDeliveriesAPI{api: n.api} }
type WebhooksDeliveriesAPI struct { api *TypedAPI }
func (n *WebhooksDeliveriesAPI) ResendDelivery(deliveryId string, opts *DynamicRequestOptions) (*openapimodels.NtfWhResendDeliveryResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"deliveryId": deliveryId}
	raw, err := n.api.client.DynamicApi.Call("webhooks.deliveries.resendDelivery", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWhResendDeliveryResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type WhatsappAPI struct { api *TypedAPI }
func (t *TypedAPI) Whatsapp() *WhatsappAPI { return &WhatsappAPI{api: t} }
func (n *WhatsappAPI) GetV1WhatsappCalls(page *string, limit *string, instanceId *string, opts *DynamicRequestOptions) (*openapimodels.NtfWaWhatsAppCallListEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if instanceId != nil { opts.Query["instanceId"] = fmt.Sprint(*instanceId) }
	raw, err := n.api.client.DynamicApi.Call("whatsapp.getV1WhatsappCalls", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaWhatsAppCallListEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) PostV1WhatsappCalls(body *openapimodels.NtfWaCreateWhatsAppCallRequest, opts *DynamicRequestOptions) (*openapimodels.NtfWaWhatsAppCallCreateEnvelope, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("whatsapp.postV1WhatsappCalls", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaWhatsAppCallCreateEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) GetV1WhatsappCallById(id string, includeEvents *string, opts *DynamicRequestOptions) (*openapimodels.NtfWaWhatsAppCallDetailEnvelope, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if includeEvents != nil { opts.Query["includeEvents"] = fmt.Sprint(*includeEvents) }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.getV1WhatsappCallById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaWhatsAppCallDetailEnvelope
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) GetV1WhatsappInstances(page *string, limit *string, status *string, search *string, opts *DynamicRequestOptions) (*openapimodels.NtfWaInstanceListResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if search != nil { opts.Query["search"] = fmt.Sprint(*search) }
	raw, err := n.api.client.DynamicApi.Call("whatsapp.getV1WhatsappInstances", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaInstanceListResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) PostV1WhatsappInstances(opts *DynamicRequestOptions) (*openapimodels.NtfWaCreateInstanceResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("whatsapp.postV1WhatsappInstances", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaCreateInstanceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) DeleteV1WhatsappInstance(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaInstanceActionResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.deleteV1WhatsappInstance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaInstanceActionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) GetV1WhatsappInstance(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaInstanceResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.getV1WhatsappInstance", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaInstanceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) GetV1WhatsappMessages(page *string, limit *string, fromDate *string, toDate *string, instanceIds *string, status *string, typeParam *string, includeEvents *string, opts *DynamicRequestOptions) (*openapimodels.NtfWaGetV1WhatsappMessagesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if fromDate != nil { opts.Query["fromDate"] = fmt.Sprint(*fromDate) }
	if toDate != nil { opts.Query["toDate"] = fmt.Sprint(*toDate) }
	if instanceIds != nil { opts.Query["instanceIds"] = fmt.Sprint(*instanceIds) }
	if status != nil { opts.Query["status"] = fmt.Sprint(*status) }
	if typeParam != nil { opts.Query["type"] = fmt.Sprint(*typeParam) }
	if includeEvents != nil { opts.Query["includeEvents"] = fmt.Sprint(*includeEvents) }
	raw, err := n.api.client.DynamicApi.Call("whatsapp.getV1WhatsappMessages", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaGetV1WhatsappMessagesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) PostV1WhatsappSend(body *openapimodels.NtfWaSendWhatsAppMessageRequest, opts *DynamicRequestOptions) (*openapimodels.NtfWaPostV1WhatsappSendResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("whatsapp.postV1WhatsappSend", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaPostV1WhatsappSendResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) DeleteV1WhatsappMessage(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaMessageActionResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.deleteV1WhatsappMessage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaMessageActionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) GetV1WhatsappMessage(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaGetV1WhatsappMessageResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.getV1WhatsappMessage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaGetV1WhatsappMessageResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) Instances() *WhatsappInstancesAPI { return &WhatsappInstancesAPI{api: n.api} }
type WhatsappInstancesAPI struct { api *TypedAPI }
func (n *WhatsappInstancesAPI) CallPermGet(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaCallPermGetResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.callPermGet", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaCallPermGetResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) CallPermRequest(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaCallPermRequestResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.callPermRequest", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaCallPermRequestResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) CallSettingsGet(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaCallSettingsGetResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.callSettingsGet", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaCallSettingsGetResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) CallSettingsPatch(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaCallSettingsPatchResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.callSettingsPatch", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaCallSettingsPatchResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) GetV1WhatsappInstanceConnectPage(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaConnectPageStatusResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.getV1WhatsappInstanceConnectPage", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaConnectPageStatusResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) PostV1WhatsappInstanceConnectPageDisable(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaConnectPageDisableResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.postV1WhatsappInstanceConnectPageDisable", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaConnectPageDisableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) PostV1WhatsappInstanceConnectPageEnable(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaConnectPageEnableResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.postV1WhatsappInstanceConnectPageEnable", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaConnectPageEnableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) PostV1WhatsappInstanceConnectPageRotate(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaConnectPageEnableResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.postV1WhatsappInstanceConnectPageRotate", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaConnectPageEnableResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) PostV1WhatsappInstanceDisconnect(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaInstanceActionResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.postV1WhatsappInstanceDisconnect", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaInstanceActionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) GetV1WhatsappInstancesInstanceIdGroups(instanceId string, page *int, limit *int, opts *DynamicRequestOptions) (*openapimodels.NtfWaGetV1WhatsappInstancesInstanceIdGroupsResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.getV1WhatsappInstancesInstanceIdGroups", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaGetV1WhatsappInstancesInstanceIdGroupsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) GetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipants(opts *DynamicRequestOptions) (*openapimodels.NtfWaGetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.getV1WhatsappInstancesInstanceIdGroupsGroupIdParticipants", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaGetV1WhatsappInstancesInstanceIdGroupsGroupIdParticipantsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) PostV1WhatsappInstancesInstanceIdGroupsInvite(instanceId string, body *openapimodels.NtfWaGroupInviteSendRequest, opts *DynamicRequestOptions) (*openapimodels.NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.postV1WhatsappInstancesInstanceIdGroupsInvite", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) GetV1WhatsappInstancesInstanceIdGroupsInviteCode(instanceId string, groupJid *string, opts *DynamicRequestOptions) (*openapimodels.NtfWaGetV1WhatsappInstancesInstanceIdGroupsInviteCodeResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if groupJid != nil { opts.Query["groupJid"] = fmt.Sprint(*groupJid) }
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.getV1WhatsappInstancesInstanceIdGroupsInviteCode", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaGetV1WhatsappInstancesInstanceIdGroupsInviteCodeResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) PostV1WhatsappInstancesInstanceIdGroupsInviteRevoke(instanceId string, body *openapimodels.NtfWaGroupInviteRevokeRequest, opts *DynamicRequestOptions) (*openapimodels.NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteRevokeResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.postV1WhatsappInstancesInstanceIdGroupsInviteRevoke", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaPostV1WhatsappInstancesInstanceIdGroupsInviteRevokeResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) PostV1WhatsappInstancesInstanceIdGroupsParticipants(instanceId string, body *openapimodels.NtfWaGroupParticipantsRequest, opts *DynamicRequestOptions) (*openapimodels.NtfWaPostV1WhatsappInstancesInstanceIdGroupsParticipantsResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.postV1WhatsappInstancesInstanceIdGroupsParticipants", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaPostV1WhatsappInstancesInstanceIdGroupsParticipantsResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) GetV1WhatsappInstancePairingCode(instanceId string, phoneNumber *string, opts *DynamicRequestOptions) (*openapimodels.NtfWaGetV1WhatsappInstancePairingCodeResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if phoneNumber != nil { opts.Query["phoneNumber"] = fmt.Sprint(*phoneNumber) }
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.getV1WhatsappInstancePairingCode", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaGetV1WhatsappInstancePairingCodeResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappInstancesAPI) GetV1WhatsappInstanceQr(instanceId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaGetV1WhatsappInstanceQrResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"instanceId": instanceId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.instances.getV1WhatsappInstanceQr", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaGetV1WhatsappInstanceQrResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappAPI) Messages() *WhatsappMessagesAPI { return &WhatsappMessagesAPI{api: n.api} }
type WhatsappMessagesAPI struct { api *TypedAPI }
func (n *WhatsappMessagesAPI) PostV1WhatsappMessageCancel(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaPostV1WhatsappMessageCancelResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.messages.postV1WhatsappMessageCancel", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaPostV1WhatsappMessageCancelResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappMessagesAPI) PatchV1WhatsappMessageEdit(messageId string, opts *DynamicRequestOptions) (*openapimodels.NtfWaMessageActionResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"messageId": messageId}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.messages.patchV1WhatsappMessageEdit", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaMessageActionResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappMessagesAPI) GetV1WhatsappMessagesInbound(page *string, limit *string, q *string, instanceId *string, dateFrom *string, dateTo *string, opts *DynamicRequestOptions) (*openapimodels.NtfWaGetV1WhatsappMessagesInboundResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if page != nil { opts.Query["page"] = fmt.Sprint(*page) }
	if limit != nil { opts.Query["limit"] = fmt.Sprint(*limit) }
	if q != nil { opts.Query["q"] = fmt.Sprint(*q) }
	if instanceId != nil { opts.Query["instanceId"] = fmt.Sprint(*instanceId) }
	if dateFrom != nil { opts.Query["dateFrom"] = fmt.Sprint(*dateFrom) }
	if dateTo != nil { opts.Query["dateTo"] = fmt.Sprint(*dateTo) }
	raw, err := n.api.client.DynamicApi.Call("whatsapp.messages.getV1WhatsappMessagesInbound", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaGetV1WhatsappMessagesInboundResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappMessagesAPI) GetV1WhatsappMessageInboundById(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWaGetV1WhatsappMessageInboundByIdResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.messages.getV1WhatsappMessageInboundById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaGetV1WhatsappMessageInboundByIdResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappMessagesAPI) PostV1WhatsappMessageInboundMedia(id string, opts *DynamicRequestOptions) (*openapimodels.NtfWaPostV1WhatsappMessageInboundMediaResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.messages.postV1WhatsappMessageInboundMedia", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaPostV1WhatsappMessageInboundMediaResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WhatsappMessagesAPI) GetV1WhatsappMessageInboundMediaDownload(id string, opts *DynamicRequestOptions) ([]byte, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("whatsapp.messages.getV1WhatsappMessageInboundMediaDownload", *opts)
	if err != nil { return nil, err }
	return []byte(raw), nil
}

func (n *WhatsappMessagesAPI) PostV1WhatsappMessagePresence(opts *DynamicRequestOptions) (*openapimodels.NtfWaPostV1WhatsappMessagePresenceResponse, error) {
	opts = ensureOpts(opts)
	raw, err := n.api.client.DynamicApi.Call("whatsapp.messages.postV1WhatsappMessagePresence", *opts)
	if err != nil { return nil, err }
	var out openapimodels.NtfWaPostV1WhatsappMessagePresenceResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

type WorkspacesAPI struct { api *TypedAPI }
func (t *TypedAPI) Workspaces() *WorkspacesAPI { return &WorkspacesAPI{api: t} }
func (n *WorkspacesAPI) GetV1Workspaces(include *string, opts *DynamicRequestOptions) (*openapimodels.GetV1WorkspacesResponse, error) {
	opts = ensureOpts(opts)
	if opts.Query == nil { opts.Query = map[string]string{} }
	if include != nil { opts.Query["include"] = fmt.Sprint(*include) }
	raw, err := n.api.client.DynamicApi.Call("workspaces.getV1Workspaces", *opts)
	if err != nil { return nil, err }
	var out openapimodels.GetV1WorkspacesResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WorkspacesAPI) PostV1Workspaces(body *openapimodels.WorkspaceCreateRequest, opts *DynamicRequestOptions) (*openapimodels.WorkspaceSingleResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	raw, err := n.api.client.DynamicApi.Call("workspaces.postV1Workspaces", *opts)
	if err != nil { return nil, err }
	var out openapimodels.WorkspaceSingleResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WorkspacesAPI) DeleteV1WorkspacesById(id string, opts *DynamicRequestOptions) (*openapimodels.DeleteV1WorkspacesByIdResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("workspaces.deleteV1WorkspacesById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.DeleteV1WorkspacesByIdResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WorkspacesAPI) GetV1WorkspacesById(id string, opts *DynamicRequestOptions) (*openapimodels.WorkspaceGetResponse, error) {
	opts = ensureOpts(opts)
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("workspaces.getV1WorkspacesById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.WorkspaceGetResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}

func (n *WorkspacesAPI) PutV1WorkspacesById(id string, body *openapimodels.WorkspaceUpdateRequest, opts *DynamicRequestOptions) (*openapimodels.WorkspaceUpdateResponse, error) {
	opts = ensureOpts(opts)
	if body != nil { opts.Body = body }
	opts.PathParams = map[string]string{"id": id}
	raw, err := n.api.client.DynamicApi.Call("workspaces.putV1WorkspacesById", *opts)
	if err != nil { return nil, err }
	var out openapimodels.WorkspaceUpdateResponse
	if err := json.Unmarshal(raw, &out); err != nil { return nil, err }
	return &out, nil
}
