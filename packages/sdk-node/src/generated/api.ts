/** Auto-generated from OpenAPI — do not edit manually */
import type { OpPathParams, OpQuery, OpRequestBody, OpResponse } from "@notifique/core";
import type { HttpTransport } from "../http";

export function createGeneratedApi(http: HttpTransport) {
  return {
    http,
    wellKnown: {
      /** Chaves públicas (JWKS) */
      getJwks: async (options?: { query?: OpQuery<'/.well-known/jwks.json', 'get'> }) => http.request<OpResponse<'/.well-known/jwks.json', 'get'>>('GET', '/.well-known/jwks.json', { query: options?.query }),
      /** Metadados do Authorization Server */
      getAuthorizationServerMetadata: async (options?: { query?: OpQuery<'/.well-known/oauth-authorization-server', 'get'> }) => http.request<OpResponse<'/.well-known/oauth-authorization-server', 'get'>>('GET', '/.well-known/oauth-authorization-server', { query: options?.query }),
      /** Metadados do recurso MCP */
      getProtectedResourceMetadata: async (options?: { query?: OpQuery<'/.well-known/oauth-protected-resource', 'get'> }) => http.request<OpResponse<'/.well-known/oauth-protected-resource', 'get'>>('GET', '/.well-known/oauth-protected-resource', { query: options?.query }),
    },
    oauth: {
      /** Autorizar (browser) */
      authorize: async (options?: { query?: OpQuery<'/oauth/authorize', 'get'> }) => http.request<OpResponse<'/oauth/authorize', 'get'>>('GET', '/oauth/authorize', { query: options?.query }),
      /** Registrar cliente (DCR) */
      registerClient: async (options?: { query?: OpQuery<'/oauth/register', 'post'>; body?: OpRequestBody<'/oauth/register', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/oauth/register', 'post'>>('POST', '/oauth/register', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Revogar token */
      revoke: async (options?: { query?: OpQuery<'/oauth/revoke', 'post'>; body?: OpRequestBody<'/oauth/revoke', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/oauth/revoke', 'post'>>('POST', '/oauth/revoke', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Obter ou renovar tokens */
      token: async (options?: { query?: OpQuery<'/oauth/token', 'post'>; body?: OpRequestBody<'/oauth/token', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/oauth/token', 'post'>>('POST', '/oauth/token', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar OAuth apps do workspace */
      listWorkspaceApps: async (options?: { query?: OpQuery<'/v1/oauth/apps', 'get'> }) => http.request<OpResponse<'/v1/oauth/apps', 'get'>>('GET', '/v1/oauth/apps', { query: options?.query }),
      /** Criar OAuth app */
      createWorkspaceApp: async (options?: { query?: OpQuery<'/v1/oauth/apps', 'post'>; body?: OpRequestBody<'/v1/oauth/apps', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/oauth/apps', 'post'>>('POST', '/v1/oauth/apps', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir OAuth app */
      deleteWorkspaceApp: async (pathParams: OpPathParams<'/v1/oauth/apps/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/oauth/apps/{id}', 'delete'> }) => http.request<OpResponse<'/v1/oauth/apps/{id}', 'delete'>>('DELETE', '/v1/oauth/apps/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Consultar OAuth app */
      getWorkspaceApp: async (pathParams: OpPathParams<'/v1/oauth/apps/{id}', 'get'>, options?: { query?: OpQuery<'/v1/oauth/apps/{id}', 'get'> }) => http.request<OpResponse<'/v1/oauth/apps/{id}', 'get'>>('GET', '/v1/oauth/apps/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar OAuth app */
      updateWorkspaceApp: async (pathParams: OpPathParams<'/v1/oauth/apps/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/oauth/apps/{id}', 'patch'>; body?: OpRequestBody<'/v1/oauth/apps/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/oauth/apps/{id}', 'patch'>>('PATCH', '/v1/oauth/apps/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar apps conectados */
      listConnections: async (options?: { query?: OpQuery<'/v1/oauth/connections', 'get'> }) => http.request<OpResponse<'/v1/oauth/connections', 'get'>>('GET', '/v1/oauth/connections', { query: options?.query }),
      apps: {
        /** Rotacionar client secret */
        rotateWorkspaceAppSecret: async (pathParams: OpPathParams<'/v1/oauth/apps/{id}/rotate-secret', 'post'>, options?: { query?: OpQuery<'/v1/oauth/apps/{id}/rotate-secret', 'post'>; body?: OpRequestBody<'/v1/oauth/apps/{id}/rotate-secret', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/oauth/apps/{id}/rotate-secret', 'post'>>('POST', '/v1/oauth/apps/' + encodeURIComponent(String(pathParams.id)) + '/rotate-secret', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
      connections: {
        /** Revogar conexão */
        revokeConnection: async (pathParams: OpPathParams<'/v1/oauth/connections/{id}/revoke', 'post'>, options?: { query?: OpQuery<'/v1/oauth/connections/{id}/revoke', 'post'>; body?: OpRequestBody<'/v1/oauth/connections/{id}/revoke', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/oauth/connections/{id}/revoke', 'post'>>('POST', '/v1/oauth/connections/' + encodeURIComponent(String(pathParams.id)) + '/revoke', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    public: {
      aiWidget: {
        /** Configuração do widget */
        getConfig: async (pathParams: OpPathParams<'/public/ai-widget/{publicKey}/config', 'get'>, options?: { query?: OpQuery<'/public/ai-widget/{publicKey}/config', 'get'> }) => http.request<OpResponse<'/public/ai-widget/{publicKey}/config', 'get'>>('GET', '/public/ai-widget/' + encodeURIComponent(String(pathParams.publicKey)) + '/config', { query: options?.query }),
        /** Enviar mensagem no widget */
        sendMessage: async (pathParams: OpPathParams<'/public/ai-widget/{publicKey}/message', 'post'>, options?: { query?: OpQuery<'/public/ai-widget/{publicKey}/message', 'post'>; body?: OpRequestBody<'/public/ai-widget/{publicKey}/message', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/public/ai-widget/{publicKey}/message', 'post'>>('POST', '/public/ai-widget/' + encodeURIComponent(String(pathParams.publicKey)) + '/message', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Buscar mensagens novas */
        pollMessages: async (pathParams: OpPathParams<'/public/ai-widget/{publicKey}/messages', 'get'>, options?: { query?: OpQuery<'/public/ai-widget/{publicKey}/messages', 'get'> }) => http.request<OpResponse<'/public/ai-widget/{publicKey}/messages', 'get'>>('GET', '/public/ai-widget/' + encodeURIComponent(String(pathParams.publicKey)) + '/messages', { query: options?.query }),
        /** Criar ou retomar sessão do visitante */
        createSession: async (pathParams: OpPathParams<'/public/ai-widget/{publicKey}/session', 'post'>, options?: { query?: OpQuery<'/public/ai-widget/{publicKey}/session', 'post'>; body?: OpRequestBody<'/public/ai-widget/{publicKey}/session', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/public/ai-widget/{publicKey}/session', 'post'>>('POST', '/public/ai-widget/' + encodeURIComponent(String(pathParams.publicKey)) + '/session', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Solicitar código OTP */
        requestOtp: async (pathParams: OpPathParams<'/public/ai-widget/{publicKey}/session/otp/request', 'post'>, options?: { query?: OpQuery<'/public/ai-widget/{publicKey}/session/otp/request', 'post'>; body?: OpRequestBody<'/public/ai-widget/{publicKey}/session/otp/request', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/public/ai-widget/{publicKey}/session/otp/request', 'post'>>('POST', '/public/ai-widget/' + encodeURIComponent(String(pathParams.publicKey)) + '/session/otp/request', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Verificar OTP de identidade */
        verifyOtp: async (pathParams: OpPathParams<'/public/ai-widget/{publicKey}/session/otp/verify', 'post'>, options?: { query?: OpQuery<'/public/ai-widget/{publicKey}/session/otp/verify', 'post'>; body?: OpRequestBody<'/public/ai-widget/{publicKey}/session/otp/verify', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/public/ai-widget/{publicKey}/session/otp/verify', 'post'>>('POST', '/public/ai-widget/' + encodeURIComponent(String(pathParams.publicKey)) + '/session/otp/verify', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    aiWebWidget: {
      /** Listar mensagens */
      messages: async (options?: { query?: OpQuery<'/v1/ai-web-widget/messages', 'get'> }) => http.request<OpResponse<'/v1/ai-web-widget/messages', 'get'>>('GET', '/v1/ai-web-widget/messages', { query: options?.query }),
      /** Listar widgets */
      list: async (options?: { query?: OpQuery<'/v1/ai-web-widget/widgets', 'get'> }) => http.request<OpResponse<'/v1/ai-web-widget/widgets', 'get'>>('GET', '/v1/ai-web-widget/widgets', { query: options?.query }),
      /** Criar widget */
      create: async (options?: { query?: OpQuery<'/v1/ai-web-widget/widgets', 'post'>; body?: OpRequestBody<'/v1/ai-web-widget/widgets', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/ai-web-widget/widgets', 'post'>>('POST', '/v1/ai-web-widget/widgets', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir widget */
      delete: async (pathParams: OpPathParams<'/v1/ai-web-widget/widgets/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/ai-web-widget/widgets/{id}', 'delete'> }) => http.request<OpResponse<'/v1/ai-web-widget/widgets/{id}', 'delete'>>('DELETE', '/v1/ai-web-widget/widgets/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Obter widget */
      get: async (pathParams: OpPathParams<'/v1/ai-web-widget/widgets/{id}', 'get'>, options?: { query?: OpQuery<'/v1/ai-web-widget/widgets/{id}', 'get'> }) => http.request<OpResponse<'/v1/ai-web-widget/widgets/{id}', 'get'>>('GET', '/v1/ai-web-widget/widgets/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar widget */
      patch: async (pathParams: OpPathParams<'/v1/ai-web-widget/widgets/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/ai-web-widget/widgets/{id}', 'patch'>; body?: OpRequestBody<'/v1/ai-web-widget/widgets/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/ai-web-widget/widgets/{id}', 'patch'>>('PATCH', '/v1/ai-web-widget/widgets/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      widgets: {
        /** Duplicar widget */
        duplicate: async (pathParams: OpPathParams<'/v1/ai-web-widget/widgets/{id}/duplicate', 'post'>, options?: { query?: OpQuery<'/v1/ai-web-widget/widgets/{id}/duplicate', 'post'>; body?: OpRequestBody<'/v1/ai-web-widget/widgets/{id}/duplicate', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/ai-web-widget/widgets/{id}/duplicate', 'post'>>('POST', '/v1/ai-web-widget/widgets/' + encodeURIComponent(String(pathParams.id)) + '/duplicate', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Rotacionar HMAC secret */
        rotateHmac: async (pathParams: OpPathParams<'/v1/ai-web-widget/widgets/{id}/rotate-identity-signing-secret', 'post'>, options?: { query?: OpQuery<'/v1/ai-web-widget/widgets/{id}/rotate-identity-signing-secret', 'post'>; body?: OpRequestBody<'/v1/ai-web-widget/widgets/{id}/rotate-identity-signing-secret', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/ai-web-widget/widgets/{id}/rotate-identity-signing-secret', 'post'>>('POST', '/v1/ai-web-widget/widgets/' + encodeURIComponent(String(pathParams.id)) + '/rotate-identity-signing-secret', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Rotacionar public key */
        rotateKey: async (pathParams: OpPathParams<'/v1/ai-web-widget/widgets/{id}/rotate-key', 'post'>, options?: { query?: OpQuery<'/v1/ai-web-widget/widgets/{id}/rotate-key', 'post'>; body?: OpRequestBody<'/v1/ai-web-widget/widgets/{id}/rotate-key', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/ai-web-widget/widgets/{id}/rotate-key', 'post'>>('POST', '/v1/ai-web-widget/widgets/' + encodeURIComponent(String(pathParams.id)) + '/rotate-key', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    assistants: {
      /** Listar assistentes */
      assistantsList: async (options?: { query?: OpQuery<'/v1/assistants', 'get'> }) => http.request<OpResponse<'/v1/assistants', 'get'>>('GET', '/v1/assistants', { query: options?.query }),
      /** Criar assistente */
      assistantsCreate: async (options?: { query?: OpQuery<'/v1/assistants', 'post'>; body?: OpRequestBody<'/v1/assistants', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/assistants', 'post'>>('POST', '/v1/assistants', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir assistente */
      assistantsDelete: async (pathParams: OpPathParams<'/v1/assistants/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/assistants/{id}', 'delete'> }) => http.request<OpResponse<'/v1/assistants/{id}', 'delete'>>('DELETE', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Obter assistente */
      assistantsGet: async (pathParams: OpPathParams<'/v1/assistants/{id}', 'get'>, options?: { query?: OpQuery<'/v1/assistants/{id}', 'get'> }) => http.request<OpResponse<'/v1/assistants/{id}', 'get'>>('GET', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar assistente */
      assistantsUpdate: async (pathParams: OpPathParams<'/v1/assistants/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/assistants/{id}', 'patch'>; body?: OpRequestBody<'/v1/assistants/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/assistants/{id}', 'patch'>>('PATCH', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar bindings HTTP tool */
      assistantsListHttpBindings: async (pathParams: OpPathParams<'/v1/assistants/{id}/http-tool-bindings', 'get'>, options?: { query?: OpQuery<'/v1/assistants/{id}/http-tool-bindings', 'get'> }) => http.request<OpResponse<'/v1/assistants/{id}/http-tool-bindings', 'get'>>('GET', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) + '/http-tool-bindings', { query: options?.query }),
      /** Vincular HTTP tool */
      assistantsCreateHttpBinding: async (pathParams: OpPathParams<'/v1/assistants/{id}/http-tool-bindings', 'post'>, options?: { query?: OpQuery<'/v1/assistants/{id}/http-tool-bindings', 'post'>; body?: OpRequestBody<'/v1/assistants/{id}/http-tool-bindings', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/assistants/{id}/http-tool-bindings', 'post'>>('POST', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) + '/http-tool-bindings', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover binding HTTP tool */
      assistantsDeleteHttpBinding: async (pathParams: OpPathParams<'/v1/assistants/{id}/http-tool-bindings/{bindingId}', 'delete'>, options?: { query?: OpQuery<'/v1/assistants/{id}/http-tool-bindings/{bindingId}', 'delete'> }) => http.request<OpResponse<'/v1/assistants/{id}/http-tool-bindings/{bindingId}', 'delete'>>('DELETE', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) + '/http-tool-bindings/' + encodeURIComponent(String(pathParams.bindingId)) , { query: options?.query }),
      /** Invocar assistente (teste) */
      assistantsInvoke: async (pathParams: OpPathParams<'/v1/assistants/{id}/invoke', 'post'>, options?: { query?: OpQuery<'/v1/assistants/{id}/invoke', 'post'>; body?: OpRequestBody<'/v1/assistants/{id}/invoke', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/assistants/{id}/invoke', 'post'>>('POST', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) + '/invoke', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar bindings MCP */
      assistantsListMcpBindings: async (pathParams: OpPathParams<'/v1/assistants/{id}/mcp-bindings', 'get'>, options?: { query?: OpQuery<'/v1/assistants/{id}/mcp-bindings', 'get'> }) => http.request<OpResponse<'/v1/assistants/{id}/mcp-bindings', 'get'>>('GET', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) + '/mcp-bindings', { query: options?.query }),
      /** Vincular conexão MCP */
      assistantsCreateMcpBinding: async (pathParams: OpPathParams<'/v1/assistants/{id}/mcp-bindings', 'post'>, options?: { query?: OpQuery<'/v1/assistants/{id}/mcp-bindings', 'post'>; body?: OpRequestBody<'/v1/assistants/{id}/mcp-bindings', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/assistants/{id}/mcp-bindings', 'post'>>('POST', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) + '/mcp-bindings', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover binding MCP */
      assistantsDeleteMcpBinding: async (pathParams: OpPathParams<'/v1/assistants/{id}/mcp-bindings/{bindingId}', 'delete'>, options?: { query?: OpQuery<'/v1/assistants/{id}/mcp-bindings/{bindingId}', 'delete'> }) => http.request<OpResponse<'/v1/assistants/{id}/mcp-bindings/{bindingId}', 'delete'>>('DELETE', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) + '/mcp-bindings/' + encodeURIComponent(String(pathParams.bindingId)) , { query: options?.query }),
      /** Atualizar binding MCP */
      assistantsUpdateMcpBinding: async (pathParams: OpPathParams<'/v1/assistants/{id}/mcp-bindings/{bindingId}', 'patch'>, options?: { query?: OpQuery<'/v1/assistants/{id}/mcp-bindings/{bindingId}', 'patch'>; body?: OpRequestBody<'/v1/assistants/{id}/mcp-bindings/{bindingId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/assistants/{id}/mcp-bindings/{bindingId}', 'patch'>>('PATCH', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) + '/mcp-bindings/' + encodeURIComponent(String(pathParams.bindingId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      invoke: {
        /** Histórico do thread de teste */
        assistantsInvokeMessages: async (pathParams: OpPathParams<'/v1/assistants/{id}/invoke/messages', 'get'>, options?: { query?: OpQuery<'/v1/assistants/{id}/invoke/messages', 'get'> }) => http.request<OpResponse<'/v1/assistants/{id}/invoke/messages', 'get'>>('GET', '/v1/assistants/' + encodeURIComponent(String(pathParams.id)) + '/invoke/messages', { query: options?.query }),
      },
    },
    automations: {
      /** Listar automações */
      listAutomations: async (options?: { query?: OpQuery<'/v1/automations', 'get'> }) => http.request<OpResponse<'/v1/automations', 'get'>>('GET', '/v1/automations', { query: options?.query }),
      /** Criar automação */
      createAutomation: async (options?: { query?: OpQuery<'/v1/automations', 'post'>; body?: OpRequestBody<'/v1/automations', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations', 'post'>>('POST', '/v1/automations', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir automação */
      deleteAutomation: async (pathParams: OpPathParams<'/v1/automations/{automationId}', 'delete'>, options?: { query?: OpQuery<'/v1/automations/{automationId}', 'delete'> }) => http.request<OpResponse<'/v1/automations/{automationId}', 'delete'>>('DELETE', '/v1/automations/' + encodeURIComponent(String(pathParams.automationId)) , { query: options?.query }),
      /** Consultar automação */
      getAutomation: async (pathParams: OpPathParams<'/v1/automations/{automationId}', 'get'>, options?: { query?: OpQuery<'/v1/automations/{automationId}', 'get'> }) => http.request<OpResponse<'/v1/automations/{automationId}', 'get'>>('GET', '/v1/automations/' + encodeURIComponent(String(pathParams.automationId)) , { query: options?.query }),
      /** Atualizar automação */
      patchAutomation: async (pathParams: OpPathParams<'/v1/automations/{automationId}', 'patch'>, options?: { query?: OpQuery<'/v1/automations/{automationId}', 'patch'>; body?: OpRequestBody<'/v1/automations/{automationId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations/{automationId}', 'patch'>>('PATCH', '/v1/automations/' + encodeURIComponent(String(pathParams.automationId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Duplicar automação */
      duplicate: async (pathParams: OpPathParams<'/v1/automations/{automationId}/duplicate', 'post'>, options?: { query?: OpQuery<'/v1/automations/{automationId}/duplicate', 'post'>; body?: OpRequestBody<'/v1/automations/{automationId}/duplicate', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations/{automationId}/duplicate', 'post'>>('POST', '/v1/automations/' + encodeURIComponent(String(pathParams.automationId)) + '/duplicate', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar execuções */
      listRuns: async (pathParams: OpPathParams<'/v1/automations/{automationId}/runs', 'get'>, options?: { query?: OpQuery<'/v1/automations/{automationId}/runs', 'get'> }) => http.request<OpResponse<'/v1/automations/{automationId}/runs', 'get'>>('GET', '/v1/automations/' + encodeURIComponent(String(pathParams.automationId)) + '/runs', { query: options?.query }),
      /** Detalhe da execução */
      getRun: async (pathParams: OpPathParams<'/v1/automations/{automationId}/runs/{runId}', 'get'>, options?: { query?: OpQuery<'/v1/automations/{automationId}/runs/{runId}', 'get'> }) => http.request<OpResponse<'/v1/automations/{automationId}/runs/{runId}', 'get'>>('GET', '/v1/automations/' + encodeURIComponent(String(pathParams.automationId)) + '/runs/' + encodeURIComponent(String(pathParams.runId)) , { query: options?.query }),
      /** Parar automação */
      stopAutomation: async (pathParams: OpPathParams<'/v1/automations/{automationId}/stop', 'post'>, options?: { query?: OpQuery<'/v1/automations/{automationId}/stop', 'post'>; body?: OpRequestBody<'/v1/automations/{automationId}/stop', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations/{automationId}/stop', 'post'>>('POST', '/v1/automations/' + encodeURIComponent(String(pathParams.automationId)) + '/stop', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Disparar teste da automação */
      testTrigger: async (pathParams: OpPathParams<'/v1/automations/{automationId}/test-trigger', 'post'>, options?: { query?: OpQuery<'/v1/automations/{automationId}/test-trigger', 'post'>; body?: OpRequestBody<'/v1/automations/{automationId}/test-trigger', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations/{automationId}/test-trigger', 'post'>>('POST', '/v1/automations/' + encodeURIComponent(String(pathParams.automationId)) + '/test-trigger', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Gerar ou revogar secret de webhook */
      webhookSecret: async (pathParams: OpPathParams<'/v1/automations/{automationId}/webhook-secret', 'post'>, options?: { query?: OpQuery<'/v1/automations/{automationId}/webhook-secret', 'post'>; body?: OpRequestBody<'/v1/automations/{automationId}/webhook-secret', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations/{automationId}/webhook-secret', 'post'>>('POST', '/v1/automations/' + encodeURIComponent(String(pathParams.automationId)) + '/webhook-secret', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Compor automação com IA */
      aiCompose: async (options?: { query?: OpQuery<'/v1/automations/ai-compose', 'post'>; body?: OpRequestBody<'/v1/automations/ai-compose', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations/ai-compose', 'post'>>('POST', '/v1/automations/ai-compose', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Criar agente pós-disparo */
      postCampaignAgent: async (options?: { query?: OpQuery<'/v1/automations/post-campaign-agent', 'post'>; body?: OpRequestBody<'/v1/automations/post-campaign-agent', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations/post-campaign-agent', 'post'>>('POST', '/v1/automations/post-campaign-agent', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Criar chatbot rápido WhatsApp */
      quickChatbot: async (options?: { query?: OpQuery<'/v1/automations/quick-chatbot', 'post'>; body?: OpRequestBody<'/v1/automations/quick-chatbot', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations/quick-chatbot', 'post'>>('POST', '/v1/automations/quick-chatbot', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      batch: {
        /** Excluir automações em lote */
        batchDelete: async (options?: { query?: OpQuery<'/v1/automations/batch/delete', 'post'>; body?: OpRequestBody<'/v1/automations/batch/delete', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/automations/batch/delete', 'post'>>('POST', '/v1/automations/batch/delete', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    campaigns: {
      /** Listar campanhas */
      getV1Campaigns: async (options?: { query?: OpQuery<'/v1/campaigns', 'get'> }) => http.request<OpResponse<'/v1/campaigns', 'get'>>('GET', '/v1/campaigns', { query: options?.query }),
      /** Criar campanha */
      postV1Campaigns: async (options?: { query?: OpQuery<'/v1/campaigns', 'post'>; body?: OpRequestBody<'/v1/campaigns', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/campaigns', 'post'>>('POST', '/v1/campaigns', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir campanha */
      deleteV1Campaign: async (pathParams: OpPathParams<'/v1/campaigns/{campaignId}', 'delete'>, options?: { query?: OpQuery<'/v1/campaigns/{campaignId}', 'delete'> }) => http.request<OpResponse<'/v1/campaigns/{campaignId}', 'delete'>>('DELETE', '/v1/campaigns/' + encodeURIComponent(String(pathParams.campaignId)) , { query: options?.query }),
      /** Consultar campanha */
      getV1CampaignById: async (pathParams: OpPathParams<'/v1/campaigns/{campaignId}', 'get'>, options?: { query?: OpQuery<'/v1/campaigns/{campaignId}', 'get'> }) => http.request<OpResponse<'/v1/campaigns/{campaignId}', 'get'>>('GET', '/v1/campaigns/' + encodeURIComponent(String(pathParams.campaignId)) , { query: options?.query }),
      /** Atualizar campanha */
      patchV1Campaign: async (pathParams: OpPathParams<'/v1/campaigns/{campaignId}', 'patch'>, options?: { query?: OpQuery<'/v1/campaigns/{campaignId}', 'patch'>; body?: OpRequestBody<'/v1/campaigns/{campaignId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/campaigns/{campaignId}', 'patch'>>('PATCH', '/v1/campaigns/' + encodeURIComponent(String(pathParams.campaignId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Cancelar mensagem agendado */
      postV1CampaignCancel: async (pathParams: OpPathParams<'/v1/campaigns/{campaignId}/cancel', 'post'>, options?: { query?: OpQuery<'/v1/campaigns/{campaignId}/cancel', 'post'>; body?: OpRequestBody<'/v1/campaigns/{campaignId}/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/campaigns/{campaignId}/cancel', 'post'>>('POST', '/v1/campaigns/' + encodeURIComponent(String(pathParams.campaignId)) + '/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Destinatários da campanha */
      getV1CampaignRecipients: async (pathParams: OpPathParams<'/v1/campaigns/{campaignId}/recipients', 'get'>, options?: { query?: OpQuery<'/v1/campaigns/{campaignId}/recipients', 'get'> }) => http.request<OpResponse<'/v1/campaigns/{campaignId}/recipients', 'get'>>('GET', '/v1/campaigns/' + encodeURIComponent(String(pathParams.campaignId)) + '/recipients', { query: options?.query }),
      /** Executar campanha */
      postV1CampaignRun: async (pathParams: OpPathParams<'/v1/campaigns/{campaignId}/run', 'post'>, options?: { query?: OpQuery<'/v1/campaigns/{campaignId}/run', 'post'>; body?: OpRequestBody<'/v1/campaigns/{campaignId}/run', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/campaigns/{campaignId}/run', 'post'>>('POST', '/v1/campaigns/' + encodeURIComponent(String(pathParams.campaignId)) + '/run', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Preview de execução da campanha */
      getV1CampaignRunPreview: async (pathParams: OpPathParams<'/v1/campaigns/{campaignId}/run-preview', 'get'>, options?: { query?: OpQuery<'/v1/campaigns/{campaignId}/run-preview', 'get'> }) => http.request<OpResponse<'/v1/campaigns/{campaignId}/run-preview', 'get'>>('GET', '/v1/campaigns/' + encodeURIComponent(String(pathParams.campaignId)) + '/run-preview', { query: options?.query }),
      /** Estatísticas da campanha */
      getV1CampaignStats: async (pathParams: OpPathParams<'/v1/campaigns/{campaignId}/stats', 'get'>, options?: { query?: OpQuery<'/v1/campaigns/{campaignId}/stats', 'get'> }) => http.request<OpResponse<'/v1/campaigns/{campaignId}/stats', 'get'>>('GET', '/v1/campaigns/' + encodeURIComponent(String(pathParams.campaignId)) + '/stats', { query: options?.query }),
    },
    contacts: {
      /** Listar contatos */
      getV1Contacts: async (options?: { query?: OpQuery<'/v1/contacts', 'get'> }) => http.request<OpResponse<'/v1/contacts', 'get'>>('GET', '/v1/contacts', { query: options?.query }),
      /** Criar contato */
      postV1Contacts: async (options?: { query?: OpQuery<'/v1/contacts', 'post'>; body?: OpRequestBody<'/v1/contacts', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/contacts', 'post'>>('POST', '/v1/contacts', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir contato */
      deleteV1Contact: async (pathParams: OpPathParams<'/v1/contacts/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/contacts/{id}', 'delete'> }) => http.request<OpResponse<'/v1/contacts/{id}', 'delete'>>('DELETE', '/v1/contacts/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Consultar contato */
      getV1Contact: async (pathParams: OpPathParams<'/v1/contacts/{id}', 'get'>, options?: { query?: OpQuery<'/v1/contacts/{id}', 'get'> }) => http.request<OpResponse<'/v1/contacts/{id}', 'get'>>('GET', '/v1/contacts/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar contato */
      putV1Contact: async (pathParams: OpPathParams<'/v1/contacts/{id}', 'put'>, options?: { query?: OpQuery<'/v1/contacts/{id}', 'put'>; body?: OpRequestBody<'/v1/contacts/{id}', 'put'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/contacts/{id}', 'put'>>('PUT', '/v1/contacts/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    conversions: {
      /** Registrar conversão */
      postV1Conversions: async (options?: { query?: OpQuery<'/v1/conversions', 'post'>; body?: OpRequestBody<'/v1/conversions', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/conversions', 'post'>>('POST', '/v1/conversions', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    email: {
      /** Listar domínios de e-mail */
      getV1EmailDomains: async (options?: { query?: OpQuery<'/v1/email/domains', 'get'> }) => http.request<OpResponse<'/v1/email/domains', 'get'>>('GET', '/v1/email/domains', { query: options?.query }),
      /** Cadastrar domínio de e-mail */
      postV1EmailDomains: async (options?: { query?: OpQuery<'/v1/email/domains', 'post'>; body?: OpRequestBody<'/v1/email/domains', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/email/domains', 'post'>>('POST', '/v1/email/domains', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Consultar domínio de e-mail */
      getV1EmailDomainById: async (pathParams: OpPathParams<'/v1/email/domains/{id}', 'get'>, options?: { query?: OpQuery<'/v1/email/domains/{id}', 'get'> }) => http.request<OpResponse<'/v1/email/domains/{id}', 'get'>>('GET', '/v1/email/domains/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Listar e-mails recebidos */
      getV1EmailInbound: async (options?: { query?: OpQuery<'/v1/email/inbound', 'get'> }) => http.request<OpResponse<'/v1/email/inbound', 'get'>>('GET', '/v1/email/inbound', { query: options?.query }),
      /** Detalhe do e-mail recebido */
      getV1EmailInboundById: async (pathParams: OpPathParams<'/v1/email/inbound/{id}', 'get'>, options?: { query?: OpQuery<'/v1/email/inbound/{id}', 'get'> }) => http.request<OpResponse<'/v1/email/inbound/{id}', 'get'>>('GET', '/v1/email/inbound/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Listar mensagens e-mail */
      getV1EmailMessages: async (options?: { query?: OpQuery<'/v1/email/messages', 'get'> }) => http.request<OpResponse<'/v1/email/messages', 'get'>>('GET', '/v1/email/messages', { query: options?.query }),
      /** Enviar e-mail */
      postV1EmailSend: async (options?: { query?: OpQuery<'/v1/email/messages', 'post'>; body?: OpRequestBody<'/v1/email/messages', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/email/messages', 'post'>>('POST', '/v1/email/messages', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Consultar envio e-mail */
      getV1EmailById: async (pathParams: OpPathParams<'/v1/email/messages/{id}', 'get'>, options?: { query?: OpQuery<'/v1/email/messages/{id}', 'get'> }) => http.request<OpResponse<'/v1/email/messages/{id}', 'get'>>('GET', '/v1/email/messages/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      domains: {
        /** Expandir provedores do domínio */
        postV1EmailDomainExpandProviders: async (pathParams: OpPathParams<'/v1/email/domains/{id}/expand-providers', 'post'>, options?: { query?: OpQuery<'/v1/email/domains/{id}/expand-providers', 'post'>; body?: OpRequestBody<'/v1/email/domains/{id}/expand-providers', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/email/domains/{id}/expand-providers', 'post'>>('POST', '/v1/email/domains/' + encodeURIComponent(String(pathParams.id)) + '/expand-providers', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Verificar domínio de e-mail */
        postV1EmailDomainVerify: async (pathParams: OpPathParams<'/v1/email/domains/{id}/verify', 'post'>, options?: { query?: OpQuery<'/v1/email/domains/{id}/verify', 'post'>; body?: OpRequestBody<'/v1/email/domains/{id}/verify', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/email/domains/{id}/verify', 'post'>>('POST', '/v1/email/domains/' + encodeURIComponent(String(pathParams.id)) + '/verify', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
      messages: {
        /** Cancelar e-mail agendado */
        postV1EmailCancel: async (pathParams: OpPathParams<'/v1/email/messages/{id}/cancel', 'post'>, options?: { query?: OpQuery<'/v1/email/messages/{id}/cancel', 'post'>; body?: OpRequestBody<'/v1/email/messages/{id}/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/email/messages/{id}/cancel', 'post'>>('POST', '/v1/email/messages/' + encodeURIComponent(String(pathParams.id)) + '/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    events: {
      /** Listar eventos */
      listEvents: async (options?: { query?: OpQuery<'/v1/events', 'get'> }) => http.request<OpResponse<'/v1/events', 'get'>>('GET', '/v1/events', { query: options?.query }),
      /** Cadastrar evento */
      createEvent: async (options?: { query?: OpQuery<'/v1/events', 'post'>; body?: OpRequestBody<'/v1/events', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/events', 'post'>>('POST', '/v1/events', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir evento */
      deleteEvent: async (pathParams: OpPathParams<'/v1/events/{eventId}', 'delete'>, options?: { query?: OpQuery<'/v1/events/{eventId}', 'delete'> }) => http.request<OpResponse<'/v1/events/{eventId}', 'delete'>>('DELETE', '/v1/events/' + encodeURIComponent(String(pathParams.eventId)) , { query: options?.query }),
      /** Consultar evento */
      getEvent: async (pathParams: OpPathParams<'/v1/events/{eventId}', 'get'>, options?: { query?: OpQuery<'/v1/events/{eventId}', 'get'> }) => http.request<OpResponse<'/v1/events/{eventId}', 'get'>>('GET', '/v1/events/' + encodeURIComponent(String(pathParams.eventId)) , { query: options?.query }),
      /** Atualizar evento */
      patchEvent: async (pathParams: OpPathParams<'/v1/events/{eventId}', 'patch'>, options?: { query?: OpQuery<'/v1/events/{eventId}', 'patch'>; body?: OpRequestBody<'/v1/events/{eventId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/events/{eventId}', 'patch'>>('PATCH', '/v1/events/' + encodeURIComponent(String(pathParams.eventId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Disparar evento */
      sendEvent: async (options?: { query?: OpQuery<'/v1/events/send', 'post'>; body?: OpRequestBody<'/v1/events/send', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/events/send', 'post'>>('POST', '/v1/events/send', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      batch: {
        /** Excluir eventos em lote */
        batchDeleteEvents: async (options?: { query?: OpQuery<'/v1/events/batch/delete', 'post'>; body?: OpRequestBody<'/v1/events/batch/delete', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/events/batch/delete', 'post'>>('POST', '/v1/events/batch/delete', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    forms: {
      /** Listar formulários */
      getV1FormsLists: async (options?: { query?: OpQuery<'/v1/forms/lists', 'get'> }) => http.request<OpResponse<'/v1/forms/lists', 'get'>>('GET', '/v1/forms/lists', { query: options?.query }),
      /** Criar formulário */
      postV1FormsLists: async (options?: { query?: OpQuery<'/v1/forms/lists', 'post'>; body?: OpRequestBody<'/v1/forms/lists', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/forms/lists', 'post'>>('POST', '/v1/forms/lists', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir formulário */
      deleteV1FormsList: async (pathParams: OpPathParams<'/v1/forms/lists/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/forms/lists/{id}', 'delete'> }) => http.request<OpResponse<'/v1/forms/lists/{id}', 'delete'>>('DELETE', '/v1/forms/lists/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Consultar formulário */
      getV1FormsList: async (pathParams: OpPathParams<'/v1/forms/lists/{id}', 'get'>, options?: { query?: OpQuery<'/v1/forms/lists/{id}', 'get'> }) => http.request<OpResponse<'/v1/forms/lists/{id}', 'get'>>('GET', '/v1/forms/lists/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar formulário */
      patchV1FormsList: async (pathParams: OpPathParams<'/v1/forms/lists/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/forms/lists/{id}', 'patch'>; body?: OpRequestBody<'/v1/forms/lists/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/forms/lists/{id}', 'patch'>>('PATCH', '/v1/forms/lists/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar inscrições (workspace) */
      getV1FormsSubscriptionsAll: async (options?: { query?: OpQuery<'/v1/forms/subscriptions', 'get'> }) => http.request<OpResponse<'/v1/forms/subscriptions', 'get'>>('GET', '/v1/forms/subscriptions', { query: options?.query }),
      /** Criar inscrição */
      postV1FormsSubscriptions: async (options?: { query?: OpQuery<'/v1/forms/subscriptions', 'post'>; body?: OpRequestBody<'/v1/forms/subscriptions', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/forms/subscriptions', 'post'>>('POST', '/v1/forms/subscriptions', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      lists: {
        /** Listar inscrições */
        getV1FormsListSubscriptions: async (pathParams: OpPathParams<'/v1/forms/lists/{id}/subscriptions', 'get'>, options?: { query?: OpQuery<'/v1/forms/lists/{id}/subscriptions', 'get'> }) => http.request<OpResponse<'/v1/forms/lists/{id}/subscriptions', 'get'>>('GET', '/v1/forms/lists/' + encodeURIComponent(String(pathParams.id)) + '/subscriptions', { query: options?.query }),
        /** Remover inscrição */
        deleteV1FormsSubscription: async (pathParams: OpPathParams<'/v1/forms/lists/{id}/subscriptions/{subscriptionId}', 'delete'>, options?: { query?: OpQuery<'/v1/forms/lists/{id}/subscriptions/{subscriptionId}', 'delete'> }) => http.request<OpResponse<'/v1/forms/lists/{id}/subscriptions/{subscriptionId}', 'delete'>>('DELETE', '/v1/forms/lists/' + encodeURIComponent(String(pathParams.id)) + '/subscriptions/' + encodeURIComponent(String(pathParams.subscriptionId)) , { query: options?.query }),
        /** Exportar inscrições (CSV) */
        getV1FormsSubscriptionExport: async (pathParams: OpPathParams<'/v1/forms/lists/{id}/subscriptions/export', 'get'>, options?: { query?: OpQuery<'/v1/forms/lists/{id}/subscriptions/export', 'get'> }) => http.request<OpResponse<'/v1/forms/lists/{id}/subscriptions/export', 'get'>>('GET', '/v1/forms/lists/' + encodeURIComponent(String(pathParams.id)) + '/subscriptions/export', { query: options?.query }),
        /** Estatísticas de inscrições */
        getV1FormsSubscriptionStats: async (pathParams: OpPathParams<'/v1/forms/lists/{id}/subscriptions/stats', 'get'>, options?: { query?: OpQuery<'/v1/forms/lists/{id}/subscriptions/stats', 'get'> }) => http.request<OpResponse<'/v1/forms/lists/{id}/subscriptions/stats', 'get'>>('GET', '/v1/forms/lists/' + encodeURIComponent(String(pathParams.id)) + '/subscriptions/stats', { query: options?.query }),
      },
      subscriptions: {
        /** Cancelar inscrição (unsubscribe) */
        postV1FormsSubscriptionCancel: async (pathParams: OpPathParams<'/v1/forms/subscriptions/{id}/cancel', 'post'>, options?: { query?: OpQuery<'/v1/forms/subscriptions/{id}/cancel', 'post'>; body?: OpRequestBody<'/v1/forms/subscriptions/{id}/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/forms/subscriptions/{id}/cancel', 'post'>>('POST', '/v1/forms/subscriptions/' + encodeURIComponent(String(pathParams.id)) + '/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Confirmar inscrição */
        postV1FormsSubscriptionsConfirm: async (options?: { query?: OpQuery<'/v1/forms/subscriptions/confirm', 'post'>; body?: OpRequestBody<'/v1/forms/subscriptions/confirm', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/forms/subscriptions/confirm', 'post'>>('POST', '/v1/forms/subscriptions/confirm', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    httpTools: {
      /** Listar HTTP tools */
      httpList: async (options?: { query?: OpQuery<'/v1/http-tools', 'get'> }) => http.request<OpResponse<'/v1/http-tools', 'get'>>('GET', '/v1/http-tools', { query: options?.query }),
      /** Criar HTTP tool */
      httpCreate: async (options?: { query?: OpQuery<'/v1/http-tools', 'post'>; body?: OpRequestBody<'/v1/http-tools', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/http-tools', 'post'>>('POST', '/v1/http-tools', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir HTTP tool */
      httpDelete: async (pathParams: OpPathParams<'/v1/http-tools/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/http-tools/{id}', 'delete'> }) => http.request<OpResponse<'/v1/http-tools/{id}', 'delete'>>('DELETE', '/v1/http-tools/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Obter HTTP tool */
      httpGet: async (pathParams: OpPathParams<'/v1/http-tools/{id}', 'get'>, options?: { query?: OpQuery<'/v1/http-tools/{id}', 'get'> }) => http.request<OpResponse<'/v1/http-tools/{id}', 'get'>>('GET', '/v1/http-tools/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar HTTP tool */
      httpUpdate: async (pathParams: OpPathParams<'/v1/http-tools/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/http-tools/{id}', 'patch'>; body?: OpRequestBody<'/v1/http-tools/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/http-tools/{id}', 'patch'>>('PATCH', '/v1/http-tools/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    instagram: {
      /** Listar comentários Instagram */
      listComments: async (options?: { query?: OpQuery<'/v1/instagram/comments', 'get'> }) => http.request<OpResponse<'/v1/instagram/comments', 'get'>>('GET', '/v1/instagram/comments', { query: options?.query }),
      /** Apagar comentário Instagram */
      deleteComment: async (pathParams: OpPathParams<'/v1/instagram/comments/{commentId}', 'delete'>, options?: { query?: OpQuery<'/v1/instagram/comments/{commentId}', 'delete'> }) => http.request<OpResponse<'/v1/instagram/comments/{commentId}', 'delete'>>('DELETE', '/v1/instagram/comments/' + encodeURIComponent(String(pathParams.commentId)) , { query: options?.query }),
      /** Consultar comentário Instagram */
      getComment: async (pathParams: OpPathParams<'/v1/instagram/comments/{commentId}', 'get'>, options?: { query?: OpQuery<'/v1/instagram/comments/{commentId}', 'get'> }) => http.request<OpResponse<'/v1/instagram/comments/{commentId}', 'get'>>('GET', '/v1/instagram/comments/' + encodeURIComponent(String(pathParams.commentId)) , { query: options?.query }),
      /** Listar conexões Instagram */
      listInstances: async (options?: { query?: OpQuery<'/v1/instagram/instances', 'get'> }) => http.request<OpResponse<'/v1/instagram/instances', 'get'>>('GET', '/v1/instagram/instances', { query: options?.query }),
      /** Criar instância Instagram */
      createInstance: async (options?: { query?: OpQuery<'/v1/instagram/instances', 'post'>; body?: OpRequestBody<'/v1/instagram/instances', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/instances', 'post'>>('POST', '/v1/instagram/instances', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover conexão Instagram */
      deleteInstance: async (pathParams: OpPathParams<'/v1/instagram/instances/{instanceId}', 'delete'>, options?: { query?: OpQuery<'/v1/instagram/instances/{instanceId}', 'delete'> }) => http.request<OpResponse<'/v1/instagram/instances/{instanceId}', 'delete'>>('DELETE', '/v1/instagram/instances/' + encodeURIComponent(String(pathParams.instanceId)) , { query: options?.query }),
      /** Consultar conexão Instagram */
      getInstance: async (pathParams: OpPathParams<'/v1/instagram/instances/{instanceId}', 'get'>, options?: { query?: OpQuery<'/v1/instagram/instances/{instanceId}', 'get'> }) => http.request<OpResponse<'/v1/instagram/instances/{instanceId}', 'get'>>('GET', '/v1/instagram/instances/' + encodeURIComponent(String(pathParams.instanceId)) , { query: options?.query }),
      /** Listar mensagens Instagram */
      listMessages: async (options?: { query?: OpQuery<'/v1/instagram/messages', 'get'> }) => http.request<OpResponse<'/v1/instagram/messages', 'get'>>('GET', '/v1/instagram/messages', { query: options?.query }),
      /** Enviar mensagem no Instagram */
      sendMessage: async (options?: { query?: OpQuery<'/v1/instagram/messages', 'post'>; body?: OpRequestBody<'/v1/instagram/messages', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/messages', 'post'>>('POST', '/v1/instagram/messages', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Apagar mensagem Instagram */
      deleteMessage: async (pathParams: OpPathParams<'/v1/instagram/messages/{messageId}', 'delete'>, options?: { query?: OpQuery<'/v1/instagram/messages/{messageId}', 'delete'> }) => http.request<OpResponse<'/v1/instagram/messages/{messageId}', 'delete'>>('DELETE', '/v1/instagram/messages/' + encodeURIComponent(String(pathParams.messageId)) , { query: options?.query }),
      /** Consultar envio Instagram */
      getMessage: async (pathParams: OpPathParams<'/v1/instagram/messages/{messageId}', 'get'>, options?: { query?: OpQuery<'/v1/instagram/messages/{messageId}', 'get'> }) => http.request<OpResponse<'/v1/instagram/messages/{messageId}', 'get'>>('GET', '/v1/instagram/messages/' + encodeURIComponent(String(pathParams.messageId)) , { query: options?.query }),
      comments: {
        /** Ocultar comentário Instagram */
        hideComment: async (pathParams: OpPathParams<'/v1/instagram/comments/{commentId}/hide', 'post'>, options?: { query?: OpQuery<'/v1/instagram/comments/{commentId}/hide', 'post'>; body?: OpRequestBody<'/v1/instagram/comments/{commentId}/hide', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/comments/{commentId}/hide', 'post'>>('POST', '/v1/instagram/comments/' + encodeURIComponent(String(pathParams.commentId)) + '/hide', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Responder comentário Instagram */
        replyComment: async (pathParams: OpPathParams<'/v1/instagram/comments/{commentId}/reply', 'post'>, options?: { query?: OpQuery<'/v1/instagram/comments/{commentId}/reply', 'post'>; body?: OpRequestBody<'/v1/instagram/comments/{commentId}/reply', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/comments/{commentId}/reply', 'post'>>('POST', '/v1/instagram/comments/' + encodeURIComponent(String(pathParams.commentId)) + '/reply', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
      instances: {
        /** Resolver verificação Instagram */
        resolveChallenge: async (pathParams: OpPathParams<'/v1/instagram/instances/{instanceId}/challenge/resolve', 'post'>, options?: { query?: OpQuery<'/v1/instagram/instances/{instanceId}/challenge/resolve', 'post'>; body?: OpRequestBody<'/v1/instagram/instances/{instanceId}/challenge/resolve', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/instances/{instanceId}/challenge/resolve', 'post'>>('POST', '/v1/instagram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/challenge/resolve', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Status do link Instagram */
        getConnectPage: async (pathParams: OpPathParams<'/v1/instagram/instances/{instanceId}/connect-page', 'get'>, options?: { query?: OpQuery<'/v1/instagram/instances/{instanceId}/connect-page', 'get'> }) => http.request<OpResponse<'/v1/instagram/instances/{instanceId}/connect-page', 'get'>>('GET', '/v1/instagram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page', { query: options?.query }),
        /** Desativar link Instagram */
        disableConnectPage: async (pathParams: OpPathParams<'/v1/instagram/instances/{instanceId}/connect-page/disable', 'post'>, options?: { query?: OpQuery<'/v1/instagram/instances/{instanceId}/connect-page/disable', 'post'>; body?: OpRequestBody<'/v1/instagram/instances/{instanceId}/connect-page/disable', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/instances/{instanceId}/connect-page/disable', 'post'>>('POST', '/v1/instagram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page/disable', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Ativar link Instagram */
        enableConnectPage: async (pathParams: OpPathParams<'/v1/instagram/instances/{instanceId}/connect-page/enable', 'post'>, options?: { query?: OpQuery<'/v1/instagram/instances/{instanceId}/connect-page/enable', 'post'>; body?: OpRequestBody<'/v1/instagram/instances/{instanceId}/connect-page/enable', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/instances/{instanceId}/connect-page/enable', 'post'>>('POST', '/v1/instagram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page/enable', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Renovar secret do link Instagram */
        rotateConnectPage: async (pathParams: OpPathParams<'/v1/instagram/instances/{instanceId}/connect-page/rotate-secret', 'post'>, options?: { query?: OpQuery<'/v1/instagram/instances/{instanceId}/connect-page/rotate-secret', 'post'>; body?: OpRequestBody<'/v1/instagram/instances/{instanceId}/connect-page/rotate-secret', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/instances/{instanceId}/connect-page/rotate-secret', 'post'>>('POST', '/v1/instagram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page/rotate-secret', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Status da conexão Instagram */
        getConnection: async (pathParams: OpPathParams<'/v1/instagram/instances/{instanceId}/connection', 'get'>, options?: { query?: OpQuery<'/v1/instagram/instances/{instanceId}/connection', 'get'> }) => http.request<OpResponse<'/v1/instagram/instances/{instanceId}/connection', 'get'>>('GET', '/v1/instagram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connection', { query: options?.query }),
        /** Desconectar Instagram */
        disconnectInstance: async (pathParams: OpPathParams<'/v1/instagram/instances/{instanceId}/disconnect', 'post'>, options?: { query?: OpQuery<'/v1/instagram/instances/{instanceId}/disconnect', 'post'>; body?: OpRequestBody<'/v1/instagram/instances/{instanceId}/disconnect', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/instances/{instanceId}/disconnect', 'post'>>('POST', '/v1/instagram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/disconnect', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
      messages: {
        /** Cancelar Instagram agendado */
        cancelMessage: async (pathParams: OpPathParams<'/v1/instagram/messages/{messageId}/cancel', 'post'>, options?: { query?: OpQuery<'/v1/instagram/messages/{messageId}/cancel', 'post'>; body?: OpRequestBody<'/v1/instagram/messages/{messageId}/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/messages/{messageId}/cancel', 'post'>>('POST', '/v1/instagram/messages/' + encodeURIComponent(String(pathParams.messageId)) + '/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Editar mensagem Instagram */
        editMessage: async (pathParams: OpPathParams<'/v1/instagram/messages/{messageId}/edit', 'patch'>, options?: { query?: OpQuery<'/v1/instagram/messages/{messageId}/edit', 'patch'>; body?: OpRequestBody<'/v1/instagram/messages/{messageId}/edit', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/messages/{messageId}/edit', 'patch'>>('PATCH', '/v1/instagram/messages/' + encodeURIComponent(String(pathParams.messageId)) + '/edit', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Listar recebidos Instagram */
        listInbound: async (options?: { query?: OpQuery<'/v1/instagram/messages/inbound', 'get'> }) => http.request<OpResponse<'/v1/instagram/messages/inbound', 'get'>>('GET', '/v1/instagram/messages/inbound', { query: options?.query }),
        /** Consultar recebido Instagram */
        getInbound: async (pathParams: OpPathParams<'/v1/instagram/messages/inbound/{id}', 'get'>, options?: { query?: OpQuery<'/v1/instagram/messages/inbound/{id}', 'get'> }) => http.request<OpResponse<'/v1/instagram/messages/inbound/{id}', 'get'>>('GET', '/v1/instagram/messages/inbound/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
        /** Baixar mídia recebida (base64) */
        postInboundMedia: async (pathParams: OpPathParams<'/v1/instagram/messages/inbound/{id}/media', 'post'>, options?: { query?: OpQuery<'/v1/instagram/messages/inbound/{id}/media', 'post'>; body?: OpRequestBody<'/v1/instagram/messages/inbound/{id}/media', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/instagram/messages/inbound/{id}/media', 'post'>>('POST', '/v1/instagram/messages/inbound/' + encodeURIComponent(String(pathParams.id)) + '/media', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Baixar mídia recebida (arquivo) */
        getInboundMediaDownload: async (pathParams: OpPathParams<'/v1/instagram/messages/inbound/{id}/media/download', 'get'>, options?: { query?: OpQuery<'/v1/instagram/messages/inbound/{id}/media/download', 'get'> }) => http.request<OpResponse<'/v1/instagram/messages/inbound/{id}/media/download', 'get'>>('GET', '/v1/instagram/messages/inbound/' + encodeURIComponent(String(pathParams.id)) + '/media/download', { query: options?.query }),
      },
    },
    knowledgeBases: {
      /** Listar bases */
      kbList: async (options?: { query?: OpQuery<'/v1/knowledge-bases', 'get'> }) => http.request<OpResponse<'/v1/knowledge-bases', 'get'>>('GET', '/v1/knowledge-bases', { query: options?.query }),
      /** Criar base */
      kbCreate: async (options?: { query?: OpQuery<'/v1/knowledge-bases', 'post'>; body?: OpRequestBody<'/v1/knowledge-bases', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/knowledge-bases', 'post'>>('POST', '/v1/knowledge-bases', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir base */
      kbDelete: async (pathParams: OpPathParams<'/v1/knowledge-bases/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/knowledge-bases/{id}', 'delete'> }) => http.request<OpResponse<'/v1/knowledge-bases/{id}', 'delete'>>('DELETE', '/v1/knowledge-bases/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Obter base */
      kbGet: async (pathParams: OpPathParams<'/v1/knowledge-bases/{id}', 'get'>, options?: { query?: OpQuery<'/v1/knowledge-bases/{id}', 'get'> }) => http.request<OpResponse<'/v1/knowledge-bases/{id}', 'get'>>('GET', '/v1/knowledge-bases/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar base */
      kbUpdate: async (pathParams: OpPathParams<'/v1/knowledge-bases/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/knowledge-bases/{id}', 'patch'>; body?: OpRequestBody<'/v1/knowledge-bases/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/knowledge-bases/{id}', 'patch'>>('PATCH', '/v1/knowledge-bases/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar documentos */
      kbListDocs: async (pathParams: OpPathParams<'/v1/knowledge-bases/{id}/documents', 'get'>, options?: { query?: OpQuery<'/v1/knowledge-bases/{id}/documents', 'get'> }) => http.request<OpResponse<'/v1/knowledge-bases/{id}/documents', 'get'>>('GET', '/v1/knowledge-bases/' + encodeURIComponent(String(pathParams.id)) + '/documents', { query: options?.query }),
      /** Criar documento */
      kbCreateDoc: async (pathParams: OpPathParams<'/v1/knowledge-bases/{id}/documents', 'post'>, options?: { query?: OpQuery<'/v1/knowledge-bases/{id}/documents', 'post'>; body?: OpRequestBody<'/v1/knowledge-bases/{id}/documents', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/knowledge-bases/{id}/documents', 'post'>>('POST', '/v1/knowledge-bases/' + encodeURIComponent(String(pathParams.id)) + '/documents', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir documento */
      kbDeleteDoc: async (pathParams: OpPathParams<'/v1/knowledge-bases/{id}/documents/{docId}', 'delete'>, options?: { query?: OpQuery<'/v1/knowledge-bases/{id}/documents/{docId}', 'delete'> }) => http.request<OpResponse<'/v1/knowledge-bases/{id}/documents/{docId}', 'delete'>>('DELETE', '/v1/knowledge-bases/' + encodeURIComponent(String(pathParams.id)) + '/documents/' + encodeURIComponent(String(pathParams.docId)) , { query: options?.query }),
      /** Obter documento */
      kbGetDoc: async (pathParams: OpPathParams<'/v1/knowledge-bases/{id}/documents/{docId}', 'get'>, options?: { query?: OpQuery<'/v1/knowledge-bases/{id}/documents/{docId}', 'get'> }) => http.request<OpResponse<'/v1/knowledge-bases/{id}/documents/{docId}', 'get'>>('GET', '/v1/knowledge-bases/' + encodeURIComponent(String(pathParams.id)) + '/documents/' + encodeURIComponent(String(pathParams.docId)) , { query: options?.query }),
      /** Atualizar documento */
      kbUpdateDoc: async (pathParams: OpPathParams<'/v1/knowledge-bases/{id}/documents/{docId}', 'patch'>, options?: { query?: OpQuery<'/v1/knowledge-bases/{id}/documents/{docId}', 'patch'>; body?: OpRequestBody<'/v1/knowledge-bases/{id}/documents/{docId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/knowledge-bases/{id}/documents/{docId}', 'patch'>>('PATCH', '/v1/knowledge-bases/' + encodeURIComponent(String(pathParams.id)) + '/documents/' + encodeURIComponent(String(pathParams.docId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    logs: {
      /** Listar logs */
      getV1Logs: async (options?: { query?: OpQuery<'/v1/logs', 'get'> }) => http.request<OpResponse<'/v1/logs', 'get'>>('GET', '/v1/logs', { query: options?.query }),
      /** Detalhe do log */
      getV1LogsById: async (pathParams: OpPathParams<'/v1/logs/{id}', 'get'>, options?: { query?: OpQuery<'/v1/logs/{id}', 'get'> }) => http.request<OpResponse<'/v1/logs/{id}', 'get'>>('GET', '/v1/logs/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
    },
    mcpConnections: {
      /** Listar conexões MCP */
      mcpList: async (options?: { query?: OpQuery<'/v1/mcp-connections', 'get'> }) => http.request<OpResponse<'/v1/mcp-connections', 'get'>>('GET', '/v1/mcp-connections', { query: options?.query }),
      /** Criar conexão MCP */
      mcpCreate: async (options?: { query?: OpQuery<'/v1/mcp-connections', 'post'>; body?: OpRequestBody<'/v1/mcp-connections', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/mcp-connections', 'post'>>('POST', '/v1/mcp-connections', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir conexão */
      mcpDelete: async (pathParams: OpPathParams<'/v1/mcp-connections/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/mcp-connections/{id}', 'delete'> }) => http.request<OpResponse<'/v1/mcp-connections/{id}', 'delete'>>('DELETE', '/v1/mcp-connections/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Obter conexão */
      mcpGet: async (pathParams: OpPathParams<'/v1/mcp-connections/{id}', 'get'>, options?: { query?: OpQuery<'/v1/mcp-connections/{id}', 'get'> }) => http.request<OpResponse<'/v1/mcp-connections/{id}', 'get'>>('GET', '/v1/mcp-connections/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar conexão */
      mcpUpdate: async (pathParams: OpPathParams<'/v1/mcp-connections/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/mcp-connections/{id}', 'patch'>; body?: OpRequestBody<'/v1/mcp-connections/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/mcp-connections/{id}', 'patch'>>('PATCH', '/v1/mcp-connections/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Atualizar manifest de tools (CUSTOM_URL) */
      mcpRefreshManifest: async (pathParams: OpPathParams<'/v1/mcp-connections/{id}/refresh-manifest', 'post'>, options?: { query?: OpQuery<'/v1/mcp-connections/{id}/refresh-manifest', 'post'>; body?: OpRequestBody<'/v1/mcp-connections/{id}/refresh-manifest', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/mcp-connections/{id}/refresh-manifest', 'post'>>('POST', '/v1/mcp-connections/' + encodeURIComponent(String(pathParams.id)) + '/refresh-manifest', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    meta: {
      /** Listar idiomas de contato */
      getV1MetaContactLocales: async (options?: { query?: OpQuery<'/v1/meta/contact-locales', 'get'> }) => http.request<OpResponse<'/v1/meta/contact-locales', 'get'>>('GET', '/v1/meta/contact-locales', { query: options?.query }),
    },
    metrics: {
      /** Overview de API, webhooks e deliverability */
      getMetricsOverview: async (options?: { query?: OpQuery<'/v1/metrics/overview', 'get'> }) => http.request<OpResponse<'/v1/metrics/overview', 'get'>>('GET', '/v1/metrics/overview', { query: options?.query }),
    },
    notify: {
      /** Envio com cascata fallback */
      postNotify: async (options?: { query?: OpQuery<'/v1/notify', 'post'>; body?: OpRequestBody<'/v1/notify', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/notify', 'post'>>('POST', '/v1/notify', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    phoneNumbers: {
      /** Listar números */
      getV1PhoneNumbers: async (options?: { query?: OpQuery<'/v1/phone-numbers', 'get'> }) => http.request<OpResponse<'/v1/phone-numbers', 'get'>>('GET', '/v1/phone-numbers', { query: options?.query }),
      /** Consultar número */
      getV1PhoneNumbersById: async (pathParams: OpPathParams<'/v1/phone-numbers/{id}', 'get'>, options?: { query?: OpQuery<'/v1/phone-numbers/{id}', 'get'> }) => http.request<OpResponse<'/v1/phone-numbers/{id}', 'get'>>('GET', '/v1/phone-numbers/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar número */
      patchV1PhoneNumbersById: async (pathParams: OpPathParams<'/v1/phone-numbers/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/phone-numbers/{id}', 'patch'>; body?: OpRequestBody<'/v1/phone-numbers/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/phone-numbers/{id}', 'patch'>>('PATCH', '/v1/phone-numbers/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Buscar números disponíveis */
      getV1PhoneNumbersAvailable: async (options?: { query?: OpQuery<'/v1/phone-numbers/available', 'get'> }) => http.request<OpResponse<'/v1/phone-numbers/available', 'get'>>('GET', '/v1/phone-numbers/available', { query: options?.query }),
      /** Configuração e preço */
      config: async (options?: { query?: OpQuery<'/v1/phone-numbers/config', 'get'> }) => http.request<OpResponse<'/v1/phone-numbers/config', 'get'>>('GET', '/v1/phone-numbers/config', { query: options?.query }),
      /** Criar pedido de número */
      createOrder: async (options?: { query?: OpQuery<'/v1/phone-numbers/orders', 'post'>; body?: OpRequestBody<'/v1/phone-numbers/orders', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/phone-numbers/orders', 'post'>>('POST', '/v1/phone-numbers/orders', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Detalhe do pedido */
      getOrder: async (pathParams: OpPathParams<'/v1/phone-numbers/orders/{orderId}', 'get'>, options?: { query?: OpQuery<'/v1/phone-numbers/orders/{orderId}', 'get'> }) => http.request<OpResponse<'/v1/phone-numbers/orders/{orderId}', 'get'>>('GET', '/v1/phone-numbers/orders/' + encodeURIComponent(String(pathParams.orderId)) , { query: options?.query }),
      orders: {
        /** Upload documento regulatório */
        regDocument: async (pathParams: OpPathParams<'/v1/phone-numbers/orders/{orderId}/regulatory/documents', 'post'>, options?: { query?: OpQuery<'/v1/phone-numbers/orders/{orderId}/regulatory/documents', 'post'>; body?: OpRequestBody<'/v1/phone-numbers/orders/{orderId}/regulatory/documents', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/phone-numbers/orders/{orderId}/regulatory/documents', 'post'>>('POST', '/v1/phone-numbers/orders/' + encodeURIComponent(String(pathParams.orderId)) + '/regulatory/documents', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Status regulatório do pedido */
        regStatus: async (pathParams: OpPathParams<'/v1/phone-numbers/orders/{orderId}/regulatory/status', 'get'>, options?: { query?: OpQuery<'/v1/phone-numbers/orders/{orderId}/regulatory/status', 'get'> }) => http.request<OpResponse<'/v1/phone-numbers/orders/{orderId}/regulatory/status', 'get'>>('GET', '/v1/phone-numbers/orders/' + encodeURIComponent(String(pathParams.orderId)) + '/regulatory/status', { query: options?.query }),
        /** Submeter regulatório */
        regSubmit: async (pathParams: OpPathParams<'/v1/phone-numbers/orders/{orderId}/regulatory/submit', 'post'>, options?: { query?: OpQuery<'/v1/phone-numbers/orders/{orderId}/regulatory/submit', 'post'>; body?: OpRequestBody<'/v1/phone-numbers/orders/{orderId}/regulatory/submit', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/phone-numbers/orders/{orderId}/regulatory/submit', 'post'>>('POST', '/v1/phone-numbers/orders/' + encodeURIComponent(String(pathParams.orderId)) + '/regulatory/submit', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Opções de número substituto */
        replacementOptions: async (pathParams: OpPathParams<'/v1/phone-numbers/orders/{orderId}/replacement-options', 'get'>, options?: { query?: OpQuery<'/v1/phone-numbers/orders/{orderId}/replacement-options', 'get'> }) => http.request<OpResponse<'/v1/phone-numbers/orders/{orderId}/replacement-options', 'get'>>('GET', '/v1/phone-numbers/orders/' + encodeURIComponent(String(pathParams.orderId)) + '/replacement-options', { query: options?.query }),
        /** Selecionar número substituto */
        selectReplacement: async (pathParams: OpPathParams<'/v1/phone-numbers/orders/{orderId}/select-replacement-number', 'post'>, options?: { query?: OpQuery<'/v1/phone-numbers/orders/{orderId}/select-replacement-number', 'post'>; body?: OpRequestBody<'/v1/phone-numbers/orders/{orderId}/select-replacement-number', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/phone-numbers/orders/{orderId}/select-replacement-number', 'post'>>('POST', '/v1/phone-numbers/orders/' + encodeURIComponent(String(pathParams.orderId)) + '/select-replacement-number', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
      regulatory: {
        /** Salvar perfil regulatório */
        regProfile: async (options?: { query?: OpQuery<'/v1/phone-numbers/regulatory/profile', 'put'>; body?: OpRequestBody<'/v1/phone-numbers/regulatory/profile', 'put'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/phone-numbers/regulatory/profile', 'put'>>('PUT', '/v1/phone-numbers/regulatory/profile', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Requisitos regulatórios */
        regRequirements: async (options?: { query?: OpQuery<'/v1/phone-numbers/regulatory/requirements', 'get'> }) => http.request<OpResponse<'/v1/phone-numbers/regulatory/requirements', 'get'>>('GET', '/v1/phone-numbers/regulatory/requirements', { query: options?.query }),
      },
    },
    pipelines: {
      /** Listar boards */
      listBoards: async (options?: { query?: OpQuery<'/v1/pipelines/boards', 'get'> }) => http.request<OpResponse<'/v1/pipelines/boards', 'get'>>('GET', '/v1/pipelines/boards', { query: options?.query }),
      /** Criar board */
      createBoard: async (options?: { query?: OpQuery<'/v1/pipelines/boards', 'post'>; body?: OpRequestBody<'/v1/pipelines/boards', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/pipelines/boards', 'post'>>('POST', '/v1/pipelines/boards', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Board completo */
      getBoard: async (pathParams: OpPathParams<'/v1/pipelines/boards/{boardId}', 'get'>, options?: { query?: OpQuery<'/v1/pipelines/boards/{boardId}', 'get'> }) => http.request<OpResponse<'/v1/pipelines/boards/{boardId}', 'get'>>('GET', '/v1/pipelines/boards/' + encodeURIComponent(String(pathParams.boardId)) , { query: options?.query }),
      /** Atualizar board */
      patchBoard: async (pathParams: OpPathParams<'/v1/pipelines/boards/{boardId}', 'patch'>, options?: { query?: OpQuery<'/v1/pipelines/boards/{boardId}', 'patch'>; body?: OpRequestBody<'/v1/pipelines/boards/{boardId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/pipelines/boards/{boardId}', 'patch'>>('PATCH', '/v1/pipelines/boards/' + encodeURIComponent(String(pathParams.boardId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Atualizar card */
      patchCard: async (pathParams: OpPathParams<'/v1/pipelines/cards/{cardId}', 'patch'>, options?: { query?: OpQuery<'/v1/pipelines/cards/{cardId}', 'patch'>; body?: OpRequestBody<'/v1/pipelines/cards/{cardId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/pipelines/cards/{cardId}', 'patch'>>('PATCH', '/v1/pipelines/cards/' + encodeURIComponent(String(pathParams.cardId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      boards: {
        /** Criar card */
        createCard: async (pathParams: OpPathParams<'/v1/pipelines/boards/{boardId}/cards', 'post'>, options?: { query?: OpQuery<'/v1/pipelines/boards/{boardId}/cards', 'post'>; body?: OpRequestBody<'/v1/pipelines/boards/{boardId}/cards', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/pipelines/boards/{boardId}/cards', 'post'>>('POST', '/v1/pipelines/boards/' + encodeURIComponent(String(pathParams.boardId)) + '/cards', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Substituir colunas */
        replaceColumns: async (pathParams: OpPathParams<'/v1/pipelines/boards/{boardId}/columns', 'put'>, options?: { query?: OpQuery<'/v1/pipelines/boards/{boardId}/columns', 'put'>; body?: OpRequestBody<'/v1/pipelines/boards/{boardId}/columns', 'put'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/pipelines/boards/{boardId}/columns', 'put'>>('PUT', '/v1/pipelines/boards/' + encodeURIComponent(String(pathParams.boardId)) + '/columns', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Overview do board */
        boardOverview: async (pathParams: OpPathParams<'/v1/pipelines/boards/{boardId}/overview', 'get'>, options?: { query?: OpQuery<'/v1/pipelines/boards/{boardId}/overview', 'get'> }) => http.request<OpResponse<'/v1/pipelines/boards/{boardId}/overview', 'get'>>('GET', '/v1/pipelines/boards/' + encodeURIComponent(String(pathParams.boardId)) + '/overview', { query: options?.query }),
      },
      cards: {
        /** Mover card */
        moveCard: async (pathParams: OpPathParams<'/v1/pipelines/cards/{cardId}/move', 'post'>, options?: { query?: OpQuery<'/v1/pipelines/cards/{cardId}/move', 'post'>; body?: OpRequestBody<'/v1/pipelines/cards/{cardId}/move', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/pipelines/cards/{cardId}/move', 'post'>>('POST', '/v1/pipelines/cards/' + encodeURIComponent(String(pathParams.cardId)) + '/move', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
      contacts: {
        /** Cards do contato */
        contactCards: async (pathParams: OpPathParams<'/v1/pipelines/contacts/{contactId}/cards', 'get'>, options?: { query?: OpQuery<'/v1/pipelines/contacts/{contactId}/cards', 'get'> }) => http.request<OpResponse<'/v1/pipelines/contacts/{contactId}/cards', 'get'>>('GET', '/v1/pipelines/contacts/' + encodeURIComponent(String(pathParams.contactId)) + '/cards', { query: options?.query }),
      },
    },
    platform: {
      /** Listar API keys */
      listApiKeys: async (options?: { query?: OpQuery<'/v1/platform/api-keys', 'get'> }) => http.request<OpResponse<'/v1/platform/api-keys', 'get'>>('GET', '/v1/platform/api-keys', { query: options?.query }),
      /** Criar API key */
      createApiKey: async (options?: { query?: OpQuery<'/v1/platform/api-keys', 'post'>; body?: OpRequestBody<'/v1/platform/api-keys', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/api-keys', 'post'>>('POST', '/v1/platform/api-keys', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Consultar API key */
      getApiKey: async (pathParams: OpPathParams<'/v1/platform/api-keys/{id}', 'get'>, options?: { query?: OpQuery<'/v1/platform/api-keys/{id}', 'get'> }) => http.request<OpResponse<'/v1/platform/api-keys/{id}', 'get'>>('GET', '/v1/platform/api-keys/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Editar API key */
      patchApiKey: async (pathParams: OpPathParams<'/v1/platform/api-keys/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/platform/api-keys/{id}', 'patch'>; body?: OpRequestBody<'/v1/platform/api-keys/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/api-keys/{id}', 'patch'>>('PATCH', '/v1/platform/api-keys/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Login */
      postLogin: async (options?: { query?: OpQuery<'/v1/platform/login', 'post'>; body?: OpRequestBody<'/v1/platform/login', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/login', 'post'>>('POST', '/v1/platform/login', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Perfil da sessão */
      getMe: async (options?: { query?: OpQuery<'/v1/platform/me', 'get'> }) => http.request<OpResponse<'/v1/platform/me', 'get'>>('GET', '/v1/platform/me', { query: options?.query }),
      /** Registrar conta */
      postRegister: async (options?: { query?: OpQuery<'/v1/platform/register', 'post'>; body?: OpRequestBody<'/v1/platform/register', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/register', 'post'>>('POST', '/v1/platform/register', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Verificar telefone */
      postVerify: async (options?: { query?: OpQuery<'/v1/platform/verify', 'post'>; body?: OpRequestBody<'/v1/platform/verify', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/verify', 'post'>>('POST', '/v1/platform/verify', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar workspaces do usuário */
      listUserWorkspaces: async (options?: { query?: OpQuery<'/v1/platform/workspaces', 'get'> }) => http.request<OpResponse<'/v1/platform/workspaces', 'get'>>('GET', '/v1/platform/workspaces', { query: options?.query }),
      apiKeys: {
        /** Revogar API key */
        revokeApiKey: async (pathParams: OpPathParams<'/v1/platform/api-keys/{id}/revoke', 'post'>, options?: { query?: OpQuery<'/v1/platform/api-keys/{id}/revoke', 'post'>; body?: OpRequestBody<'/v1/platform/api-keys/{id}/revoke', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/api-keys/{id}/revoke', 'post'>>('POST', '/v1/platform/api-keys/' + encodeURIComponent(String(pathParams.id)) + '/revoke', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
      workspaces: {
        /** Consultar saldo */
        getBalance: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/balance', 'get'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/balance', 'get'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/balance', 'get'>>('GET', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/balance', { query: options?.query }),
        /** Recarregar saldo */
        rechargeBalance: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/balance/recharge', 'post'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/balance/recharge', 'post'>; body?: OpRequestBody<'/v1/platform/workspaces/{id}/balance/recharge', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/balance/recharge', 'post'>>('POST', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/balance/recharge', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Histórico detalhado de uso de créditos */
        getCreditsUsage: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/credits/usage', 'get'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/credits/usage', 'get'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/credits/usage', 'get'>>('GET', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/credits/usage', { query: options?.query }),
        /** Listar convites pendentes */
        listInvites: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/invites', 'get'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/invites', 'get'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/invites', 'get'>>('GET', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/invites', { query: options?.query }),
        /** Convidar membro */
        createInvite: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/invites', 'post'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/invites', 'post'>; body?: OpRequestBody<'/v1/platform/workspaces/{id}/invites', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/invites', 'post'>>('POST', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/invites', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Cancelar convite */
        cancelInvite: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/invites/{inviteId}', 'delete'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/invites/{inviteId}', 'delete'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/invites/{inviteId}', 'delete'>>('DELETE', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/invites/' + encodeURIComponent(String(pathParams.inviteId)) , { query: options?.query }),
        /** Listar membros */
        listMembers: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/members', 'get'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/members', 'get'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/members', 'get'>>('GET', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/members', { query: options?.query }),
        /** Remover membro */
        removeMember: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/members/{userId}', 'delete'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/members/{userId}', 'delete'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/members/{userId}', 'delete'>>('DELETE', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/members/' + encodeURIComponent(String(pathParams.userId)) , { query: options?.query }),
        /** Listar cartões */
        listPaymentMethods: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/payment-methods', 'get'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/payment-methods', 'get'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/payment-methods', 'get'>>('GET', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/payment-methods', { query: options?.query }),
        /** Cadastrar cartão */
        createPaymentMethod: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/payment-methods', 'post'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/payment-methods', 'post'>; body?: OpRequestBody<'/v1/platform/workspaces/{id}/payment-methods', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/payment-methods', 'post'>>('POST', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/payment-methods', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Remover cartão */
        deletePaymentMethod: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/payment-methods/{pmId}', 'delete'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/payment-methods/{pmId}', 'delete'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/payment-methods/{pmId}', 'delete'>>('DELETE', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/payment-methods/' + encodeURIComponent(String(pathParams.pmId)) , { query: options?.query }),
        /** Atualizar cartão */
        updatePaymentMethod: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/payment-methods/{pmId}', 'patch'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/payment-methods/{pmId}', 'patch'>; body?: OpRequestBody<'/v1/platform/workspaces/{id}/payment-methods/{pmId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/payment-methods/{pmId}', 'patch'>>('PATCH', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/payment-methods/' + encodeURIComponent(String(pathParams.pmId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Cancelar assinatura */
        cancelSubscription: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/subscription', 'delete'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/subscription', 'delete'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/subscription', 'delete'>>('DELETE', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/subscription', { query: options?.query }),
        /** Consultar assinatura */
        getWorkspaceSubscription: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/subscription', 'get'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/subscription', 'get'> }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/subscription', 'get'>>('GET', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/subscription', { query: options?.query }),
        /** Assinar ou mudar plano */
        subscribeWorkspace: async (pathParams: OpPathParams<'/v1/platform/workspaces/{id}/subscription', 'post'>, options?: { query?: OpQuery<'/v1/platform/workspaces/{id}/subscription', 'post'>; body?: OpRequestBody<'/v1/platform/workspaces/{id}/subscription', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/platform/workspaces/{id}/subscription', 'post'>>('POST', '/v1/platform/workspaces/' + encodeURIComponent(String(pathParams.id)) + '/subscription', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    pricing: {
      /** Catálogo público de preços */
      getPricing: async (options?: { query?: OpQuery<'/v1/pricing', 'get'> }) => http.request<OpResponse<'/v1/pricing', 'get'>>('GET', '/v1/pricing', { query: options?.query }),
    },
    push: {
      /** Listar apps push */
      getV1PushApps: async (options?: { query?: OpQuery<'/v1/push/apps', 'get'> }) => http.request<OpResponse<'/v1/push/apps', 'get'>>('GET', '/v1/push/apps', { query: options?.query }),
      /** Criar app push */
      postV1PushApps: async (options?: { query?: OpQuery<'/v1/push/apps', 'post'>; body?: OpRequestBody<'/v1/push/apps', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/push/apps', 'post'>>('POST', '/v1/push/apps', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover app push */
      deleteV1PushAppsById: async (pathParams: OpPathParams<'/v1/push/apps/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/push/apps/{id}', 'delete'> }) => http.request<OpResponse<'/v1/push/apps/{id}', 'delete'>>('DELETE', '/v1/push/apps/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Consultar app push */
      getV1PushAppsById: async (pathParams: OpPathParams<'/v1/push/apps/{id}', 'get'>, options?: { query?: OpQuery<'/v1/push/apps/{id}', 'get'> }) => http.request<OpResponse<'/v1/push/apps/{id}', 'get'>>('GET', '/v1/push/apps/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar app push */
      putV1PushAppsById: async (pathParams: OpPathParams<'/v1/push/apps/{id}', 'put'>, options?: { query?: OpQuery<'/v1/push/apps/{id}', 'put'>; body?: OpRequestBody<'/v1/push/apps/{id}', 'put'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/push/apps/{id}', 'put'>>('PUT', '/v1/push/apps/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar dispositivos push */
      getV1PushDevices: async (options?: { query?: OpQuery<'/v1/push/devices', 'get'> }) => http.request<OpResponse<'/v1/push/devices', 'get'>>('GET', '/v1/push/devices', { query: options?.query }),
      /** Registrar dispositivo push */
      postV1PushDevices: async (options?: { query?: OpQuery<'/v1/push/devices', 'post'>; body?: OpRequestBody<'/v1/push/devices', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/push/devices', 'post'>>('POST', '/v1/push/devices', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover dispositivo push */
      deleteV1PushDevicesById: async (pathParams: OpPathParams<'/v1/push/devices/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/push/devices/{id}', 'delete'> }) => http.request<OpResponse<'/v1/push/devices/{id}', 'delete'>>('DELETE', '/v1/push/devices/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Consultar dispositivo push */
      getV1PushDevicesById: async (pathParams: OpPathParams<'/v1/push/devices/{id}', 'get'>, options?: { query?: OpQuery<'/v1/push/devices/{id}', 'get'> }) => http.request<OpResponse<'/v1/push/devices/{id}', 'get'>>('GET', '/v1/push/devices/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Listar mensagens push */
      getV1PushMessages: async (options?: { query?: OpQuery<'/v1/push/messages', 'get'> }) => http.request<OpResponse<'/v1/push/messages', 'get'>>('GET', '/v1/push/messages', { query: options?.query }),
      /** Enviar push */
      postV1PushMessages: async (options?: { query?: OpQuery<'/v1/push/messages', 'post'>; body?: OpRequestBody<'/v1/push/messages', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/push/messages', 'post'>>('POST', '/v1/push/messages', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Consultar envio push */
      getV1PushMessagesById: async (pathParams: OpPathParams<'/v1/push/messages/{id}', 'get'>, options?: { query?: OpQuery<'/v1/push/messages/{id}', 'get'> }) => http.request<OpResponse<'/v1/push/messages/{id}', 'get'>>('GET', '/v1/push/messages/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      messages: {
        /** Cancelar push agendado */
        postV1PushMessagesCancel: async (pathParams: OpPathParams<'/v1/push/messages/{id}/cancel', 'post'>, options?: { query?: OpQuery<'/v1/push/messages/{id}/cancel', 'post'>; body?: OpRequestBody<'/v1/push/messages/{id}/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/push/messages/{id}/cancel', 'post'>>('POST', '/v1/push/messages/' + encodeURIComponent(String(pathParams.id)) + '/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    rcs: {
      /** Listar mensagens RCS */
      getV1RcsMessages: async (options?: { query?: OpQuery<'/v1/rcs/messages', 'get'> }) => http.request<OpResponse<'/v1/rcs/messages', 'get'>>('GET', '/v1/rcs/messages', { query: options?.query }),
      /** Enviar RCS */
      postV1RcsSend: async (options?: { query?: OpQuery<'/v1/rcs/messages', 'post'>; body?: OpRequestBody<'/v1/rcs/messages', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/rcs/messages', 'post'>>('POST', '/v1/rcs/messages', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Consultar envio RCS */
      getV1RcsById: async (pathParams: OpPathParams<'/v1/rcs/messages/{id}', 'get'>, options?: { query?: OpQuery<'/v1/rcs/messages/{id}', 'get'> }) => http.request<OpResponse<'/v1/rcs/messages/{id}', 'get'>>('GET', '/v1/rcs/messages/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      messages: {
        /** Cancelar RCS agendado */
        postV1RcsCancel: async (pathParams: OpPathParams<'/v1/rcs/messages/{id}/cancel', 'post'>, options?: { query?: OpQuery<'/v1/rcs/messages/{id}/cancel', 'post'>; body?: OpRequestBody<'/v1/rcs/messages/{id}/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/rcs/messages/{id}/cancel', 'post'>>('POST', '/v1/rcs/messages/' + encodeURIComponent(String(pathParams.id)) + '/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    report: {
      /** Registrar denúncia */
      postV1Report: async (options?: { query?: OpQuery<'/v1/report', 'post'>; body?: OpRequestBody<'/v1/report', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/report', 'post'>>('POST', '/v1/report', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    segments: {
      /** Listar segmentos */
      getV1Segments: async (options?: { query?: OpQuery<'/v1/segments', 'get'> }) => http.request<OpResponse<'/v1/segments', 'get'>>('GET', '/v1/segments', { query: options?.query }),
      /** Criar segmento */
      postV1Segments: async (options?: { query?: OpQuery<'/v1/segments', 'post'>; body?: OpRequestBody<'/v1/segments', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/segments', 'post'>>('POST', '/v1/segments', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir segmento */
      deleteV1Segment: async (pathParams: OpPathParams<'/v1/segments/{segmentId}', 'delete'>, options?: { query?: OpQuery<'/v1/segments/{segmentId}', 'delete'> }) => http.request<OpResponse<'/v1/segments/{segmentId}', 'delete'>>('DELETE', '/v1/segments/' + encodeURIComponent(String(pathParams.segmentId)) , { query: options?.query }),
      /** Consultar segmento */
      getV1SegmentById: async (pathParams: OpPathParams<'/v1/segments/{segmentId}', 'get'>, options?: { query?: OpQuery<'/v1/segments/{segmentId}', 'get'> }) => http.request<OpResponse<'/v1/segments/{segmentId}', 'get'>>('GET', '/v1/segments/' + encodeURIComponent(String(pathParams.segmentId)) , { query: options?.query }),
      /** Atualizar segmento */
      patchV1Segment: async (pathParams: OpPathParams<'/v1/segments/{segmentId}', 'patch'>, options?: { query?: OpQuery<'/v1/segments/{segmentId}', 'patch'>; body?: OpRequestBody<'/v1/segments/{segmentId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/segments/{segmentId}', 'patch'>>('PATCH', '/v1/segments/' + encodeURIComponent(String(pathParams.segmentId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Pré-visualizar segmento */
      getV1SegmentPreview: async (pathParams: OpPathParams<'/v1/segments/{segmentId}/preview', 'get'>, options?: { query?: OpQuery<'/v1/segments/{segmentId}/preview', 'get'> }) => http.request<OpResponse<'/v1/segments/{segmentId}/preview', 'get'>>('GET', '/v1/segments/' + encodeURIComponent(String(pathParams.segmentId)) + '/preview', { query: options?.query }),
    },
    sendingPools: {
      /** Listar pools */
      list: async (options?: { query?: OpQuery<'/v1/sending-pools', 'get'> }) => http.request<OpResponse<'/v1/sending-pools', 'get'>>('GET', '/v1/sending-pools', { query: options?.query }),
      /** Criar pool */
      create: async (options?: { query?: OpQuery<'/v1/sending-pools', 'post'>; body?: OpRequestBody<'/v1/sending-pools', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/sending-pools', 'post'>>('POST', '/v1/sending-pools', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir pool */
      delete: async (pathParams: OpPathParams<'/v1/sending-pools/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/sending-pools/{id}', 'delete'> }) => http.request<OpResponse<'/v1/sending-pools/{id}', 'delete'>>('DELETE', '/v1/sending-pools/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Obter pool */
      get: async (pathParams: OpPathParams<'/v1/sending-pools/{id}', 'get'>, options?: { query?: OpQuery<'/v1/sending-pools/{id}', 'get'> }) => http.request<OpResponse<'/v1/sending-pools/{id}', 'get'>>('GET', '/v1/sending-pools/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar pool */
      update: async (pathParams: OpPathParams<'/v1/sending-pools/{id}', 'put'>, options?: { query?: OpQuery<'/v1/sending-pools/{id}', 'put'>; body?: OpRequestBody<'/v1/sending-pools/{id}', 'put'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/sending-pools/{id}', 'put'>>('PUT', '/v1/sending-pools/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Adicionar membro */
      addMember: async (pathParams: OpPathParams<'/v1/sending-pools/{id}/members', 'post'>, options?: { query?: OpQuery<'/v1/sending-pools/{id}/members', 'post'>; body?: OpRequestBody<'/v1/sending-pools/{id}/members', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/sending-pools/{id}/members', 'post'>>('POST', '/v1/sending-pools/' + encodeURIComponent(String(pathParams.id)) + '/members', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover membro */
      deleteMember: async (pathParams: OpPathParams<'/v1/sending-pools/{id}/members/{memberId}', 'delete'>, options?: { query?: OpQuery<'/v1/sending-pools/{id}/members/{memberId}', 'delete'> }) => http.request<OpResponse<'/v1/sending-pools/{id}/members/{memberId}', 'delete'>>('DELETE', '/v1/sending-pools/' + encodeURIComponent(String(pathParams.id)) + '/members/' + encodeURIComponent(String(pathParams.memberId)) , { query: options?.query }),
      /** Atualizar membro */
      updateMember: async (pathParams: OpPathParams<'/v1/sending-pools/{id}/members/{memberId}', 'put'>, options?: { query?: OpQuery<'/v1/sending-pools/{id}/members/{memberId}', 'put'>; body?: OpRequestBody<'/v1/sending-pools/{id}/members/{memberId}', 'put'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/sending-pools/{id}/members/{memberId}', 'put'>>('PUT', '/v1/sending-pools/' + encodeURIComponent(String(pathParams.id)) + '/members/' + encodeURIComponent(String(pathParams.memberId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Stats do pool */
      stats: async (pathParams: OpPathParams<'/v1/sending-pools/{id}/stats', 'get'>, options?: { query?: OpQuery<'/v1/sending-pools/{id}/stats', 'get'> }) => http.request<OpResponse<'/v1/sending-pools/{id}/stats', 'get'>>('GET', '/v1/sending-pools/' + encodeURIComponent(String(pathParams.id)) + '/stats', { query: options?.query }),
    },
    shortLinks: {
      /** Listar links curtos */
      getV1ShortLinks: async (options?: { query?: OpQuery<'/v1/short-links', 'get'> }) => http.request<OpResponse<'/v1/short-links', 'get'>>('GET', '/v1/short-links', { query: options?.query }),
      /** Criar link curto */
      postV1ShortLinks: async (options?: { query?: OpQuery<'/v1/short-links', 'post'>; body?: OpRequestBody<'/v1/short-links', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/short-links', 'post'>>('POST', '/v1/short-links', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover link curto */
      deleteV1ShortLinksById: async (pathParams: OpPathParams<'/v1/short-links/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/short-links/{id}', 'delete'> }) => http.request<OpResponse<'/v1/short-links/{id}', 'delete'>>('DELETE', '/v1/short-links/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Consultar link curto */
      getV1ShortLinksById: async (pathParams: OpPathParams<'/v1/short-links/{id}', 'get'>, options?: { query?: OpQuery<'/v1/short-links/{id}', 'get'> }) => http.request<OpResponse<'/v1/short-links/{id}', 'get'>>('GET', '/v1/short-links/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar link curto */
      patchV1ShortLinksById: async (pathParams: OpPathParams<'/v1/short-links/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/short-links/{id}', 'patch'>; body?: OpRequestBody<'/v1/short-links/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/short-links/{id}', 'patch'>>('PATCH', '/v1/short-links/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Ver estatísticas do link */
      getV1ShortLinksAnalytics: async (pathParams: OpPathParams<'/v1/short-links/{id}/analytics', 'get'>, options?: { query?: OpQuery<'/v1/short-links/{id}/analytics', 'get'> }) => http.request<OpResponse<'/v1/short-links/{id}/analytics', 'get'>>('GET', '/v1/short-links/' + encodeURIComponent(String(pathParams.id)) + '/analytics', { query: options?.query }),
      /** Listar cliques do link */
      getV1ShortLinksClicks: async (pathParams: OpPathParams<'/v1/short-links/{id}/clicks', 'get'>, options?: { query?: OpQuery<'/v1/short-links/{id}/clicks', 'get'> }) => http.request<OpResponse<'/v1/short-links/{id}/clicks', 'get'>>('GET', '/v1/short-links/' + encodeURIComponent(String(pathParams.id)) + '/clicks', { query: options?.query }),
    },
    sms: {
      /** Listar SMS recebidos */
      getV1SmsInbound: async (options?: { query?: OpQuery<'/v1/sms/inbound', 'get'> }) => http.request<OpResponse<'/v1/sms/inbound', 'get'>>('GET', '/v1/sms/inbound', { query: options?.query }),
      /** Consultar SMS recebido */
      getV1SmsInboundById: async (pathParams: OpPathParams<'/v1/sms/inbound/{id}', 'get'>, options?: { query?: OpQuery<'/v1/sms/inbound/{id}', 'get'> }) => http.request<OpResponse<'/v1/sms/inbound/{id}', 'get'>>('GET', '/v1/sms/inbound/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Listar SMS */
      getV1SmsMessages: async (options?: { query?: OpQuery<'/v1/sms/messages', 'get'> }) => http.request<OpResponse<'/v1/sms/messages', 'get'>>('GET', '/v1/sms/messages', { query: options?.query }),
      /** Enviar SMS */
      postV1SmsSend: async (options?: { query?: OpQuery<'/v1/sms/messages', 'post'>; body?: OpRequestBody<'/v1/sms/messages', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/sms/messages', 'post'>>('POST', '/v1/sms/messages', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Consultar status de um SMS */
      getV1SmsById: async (pathParams: OpPathParams<'/v1/sms/messages/{id}', 'get'>, options?: { query?: OpQuery<'/v1/sms/messages/{id}', 'get'> }) => http.request<OpResponse<'/v1/sms/messages/{id}', 'get'>>('GET', '/v1/sms/messages/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      messages: {
        /** Cancelar SMS agendado */
        postV1SmsCancel: async (pathParams: OpPathParams<'/v1/sms/messages/{id}/cancel', 'post'>, options?: { query?: OpQuery<'/v1/sms/messages/{id}/cancel', 'post'>; body?: OpRequestBody<'/v1/sms/messages/{id}/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/sms/messages/{id}/cancel', 'post'>>('POST', '/v1/sms/messages/' + encodeURIComponent(String(pathParams.id)) + '/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    suppressions: {
      /** Listar supressões */
      listSuppressions: async (options?: { query?: OpQuery<'/v1/suppressions', 'get'> }) => http.request<OpResponse<'/v1/suppressions', 'get'>>('GET', '/v1/suppressions', { query: options?.query }),
      /** Adicionar supressão */
      createSuppression: async (options?: { query?: OpQuery<'/v1/suppressions', 'post'>; body?: OpRequestBody<'/v1/suppressions', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/suppressions', 'post'>>('POST', '/v1/suppressions', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover supressão */
      removeSuppression: async (pathParams: OpPathParams<'/v1/suppressions/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/suppressions/{id}', 'delete'> }) => http.request<OpResponse<'/v1/suppressions/{id}', 'delete'>>('DELETE', '/v1/suppressions/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Consultar supressão */
      getSuppression: async (pathParams: OpPathParams<'/v1/suppressions/{id}', 'get'>, options?: { query?: OpQuery<'/v1/suppressions/{id}', 'get'> }) => http.request<OpResponse<'/v1/suppressions/{id}', 'get'>>('GET', '/v1/suppressions/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Remover por identidade */
      removeSuppressionByIdentity: async (options?: { query?: OpQuery<'/v1/suppressions/by-identity', 'delete'> }) => http.request<OpResponse<'/v1/suppressions/by-identity', 'delete'>>('DELETE', '/v1/suppressions/by-identity', { query: options?.query }),
      batch: {
        /** Adicionar em lote */
        batchAddSuppressions: async (options?: { query?: OpQuery<'/v1/suppressions/batch/add', 'post'>; body?: OpRequestBody<'/v1/suppressions/batch/add', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/suppressions/batch/add', 'post'>>('POST', '/v1/suppressions/batch/add', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Remover em lote */
        batchRemoveSuppressions: async (options?: { query?: OpQuery<'/v1/suppressions/batch/remove', 'post'>; body?: OpRequestBody<'/v1/suppressions/batch/remove', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/suppressions/batch/remove', 'post'>>('POST', '/v1/suppressions/batch/remove', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    tags: {
      /** Listar tags */
      getV1Tags: async (options?: { query?: OpQuery<'/v1/tags', 'get'> }) => http.request<OpResponse<'/v1/tags', 'get'>>('GET', '/v1/tags', { query: options?.query }),
      /** Criar tag */
      postV1Tags: async (options?: { query?: OpQuery<'/v1/tags', 'post'>; body?: OpRequestBody<'/v1/tags', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/tags', 'post'>>('POST', '/v1/tags', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir tag */
      deleteV1Tag: async (pathParams: OpPathParams<'/v1/tags/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/tags/{id}', 'delete'> }) => http.request<OpResponse<'/v1/tags/{id}', 'delete'>>('DELETE', '/v1/tags/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Consultar tag */
      getV1Tag: async (pathParams: OpPathParams<'/v1/tags/{id}', 'get'>, options?: { query?: OpQuery<'/v1/tags/{id}', 'get'> }) => http.request<OpResponse<'/v1/tags/{id}', 'get'>>('GET', '/v1/tags/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar tag */
      putV1Tag: async (pathParams: OpPathParams<'/v1/tags/{id}', 'put'>, options?: { query?: OpQuery<'/v1/tags/{id}', 'put'>; body?: OpRequestBody<'/v1/tags/{id}', 'put'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/tags/{id}', 'put'>>('PUT', '/v1/tags/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    telegram: {
      /** Listar chats Telegram */
      getV1TelegramChats: async (options?: { query?: OpQuery<'/v1/telegram/chats', 'get'> }) => http.request<OpResponse<'/v1/telegram/chats', 'get'>>('GET', '/v1/telegram/chats', { query: options?.query }),
      /** Listar conexões Telegram */
      getV1TelegramInstances: async (options?: { query?: OpQuery<'/v1/telegram/instances', 'get'> }) => http.request<OpResponse<'/v1/telegram/instances', 'get'>>('GET', '/v1/telegram/instances', { query: options?.query }),
      /** Criar instância Telegram */
      postV1TelegramInstances: async (options?: { query?: OpQuery<'/v1/telegram/instances', 'post'>; body?: OpRequestBody<'/v1/telegram/instances', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/instances', 'post'>>('POST', '/v1/telegram/instances', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover conexão Telegram */
      deleteV1TelegramInstance: async (pathParams: OpPathParams<'/v1/telegram/instances/{instanceId}', 'delete'>, options?: { query?: OpQuery<'/v1/telegram/instances/{instanceId}', 'delete'> }) => http.request<OpResponse<'/v1/telegram/instances/{instanceId}', 'delete'>>('DELETE', '/v1/telegram/instances/' + encodeURIComponent(String(pathParams.instanceId)) , { query: options?.query }),
      /** Consultar conexão Telegram */
      getV1TelegramInstance: async (pathParams: OpPathParams<'/v1/telegram/instances/{instanceId}', 'get'>, options?: { query?: OpQuery<'/v1/telegram/instances/{instanceId}', 'get'> }) => http.request<OpResponse<'/v1/telegram/instances/{instanceId}', 'get'>>('GET', '/v1/telegram/instances/' + encodeURIComponent(String(pathParams.instanceId)) , { query: options?.query }),
      /** Listar mensagens Telegram */
      getV1TelegramMessages: async (options?: { query?: OpQuery<'/v1/telegram/messages', 'get'> }) => http.request<OpResponse<'/v1/telegram/messages', 'get'>>('GET', '/v1/telegram/messages', { query: options?.query }),
      /** Enviar mensagem no Telegram */
      postV1TelegramSend: async (options?: { query?: OpQuery<'/v1/telegram/messages', 'post'>; body?: OpRequestBody<'/v1/telegram/messages', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/messages', 'post'>>('POST', '/v1/telegram/messages', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Apagar mensagem Telegram */
      deleteV1TelegramMessage: async (pathParams: OpPathParams<'/v1/telegram/messages/{messageId}', 'delete'>, options?: { query?: OpQuery<'/v1/telegram/messages/{messageId}', 'delete'> }) => http.request<OpResponse<'/v1/telegram/messages/{messageId}', 'delete'>>('DELETE', '/v1/telegram/messages/' + encodeURIComponent(String(pathParams.messageId)) , { query: options?.query }),
      /** Consultar envio Telegram */
      getV1TelegramMessageById: async (pathParams: OpPathParams<'/v1/telegram/messages/{messageId}', 'get'>, options?: { query?: OpQuery<'/v1/telegram/messages/{messageId}', 'get'> }) => http.request<OpResponse<'/v1/telegram/messages/{messageId}', 'get'>>('GET', '/v1/telegram/messages/' + encodeURIComponent(String(pathParams.messageId)) , { query: options?.query }),
      instances: {
        /** Status do link Telegram */
        ntfTelegramGetConnectPage: async (pathParams: OpPathParams<'/v1/telegram/instances/{instanceId}/connect-page', 'get'>, options?: { query?: OpQuery<'/v1/telegram/instances/{instanceId}/connect-page', 'get'> }) => http.request<OpResponse<'/v1/telegram/instances/{instanceId}/connect-page', 'get'>>('GET', '/v1/telegram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page', { query: options?.query }),
        /** Desativar link Telegram */
        ntfTelegramDisableConnectPage: async (pathParams: OpPathParams<'/v1/telegram/instances/{instanceId}/connect-page/disable', 'post'>, options?: { query?: OpQuery<'/v1/telegram/instances/{instanceId}/connect-page/disable', 'post'>; body?: OpRequestBody<'/v1/telegram/instances/{instanceId}/connect-page/disable', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/instances/{instanceId}/connect-page/disable', 'post'>>('POST', '/v1/telegram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page/disable', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Ativar link Telegram */
        ntfTelegramEnableConnectPage: async (pathParams: OpPathParams<'/v1/telegram/instances/{instanceId}/connect-page/enable', 'post'>, options?: { query?: OpQuery<'/v1/telegram/instances/{instanceId}/connect-page/enable', 'post'>; body?: OpRequestBody<'/v1/telegram/instances/{instanceId}/connect-page/enable', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/instances/{instanceId}/connect-page/enable', 'post'>>('POST', '/v1/telegram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page/enable', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Renovar secret do link Telegram */
        ntfTelegramRotateConnectPage: async (pathParams: OpPathParams<'/v1/telegram/instances/{instanceId}/connect-page/rotate-secret', 'post'>, options?: { query?: OpQuery<'/v1/telegram/instances/{instanceId}/connect-page/rotate-secret', 'post'>; body?: OpRequestBody<'/v1/telegram/instances/{instanceId}/connect-page/rotate-secret', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/instances/{instanceId}/connect-page/rotate-secret', 'post'>>('POST', '/v1/telegram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page/rotate-secret', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Obter QR Telegram */
        getV1TelegramInstanceQr: async (pathParams: OpPathParams<'/v1/telegram/instances/{instanceId}/qr', 'get'>, options?: { query?: OpQuery<'/v1/telegram/instances/{instanceId}/qr', 'get'> }) => http.request<OpResponse<'/v1/telegram/instances/{instanceId}/qr', 'get'>>('GET', '/v1/telegram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/qr', { query: options?.query }),
        /** Cancelar Telegram agendado */
        postV1TelegramInstanceQrCancel: async (pathParams: OpPathParams<'/v1/telegram/instances/{instanceId}/qr/cancel', 'post'>, options?: { query?: OpQuery<'/v1/telegram/instances/{instanceId}/qr/cancel', 'post'>; body?: OpRequestBody<'/v1/telegram/instances/{instanceId}/qr/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/instances/{instanceId}/qr/cancel', 'post'>>('POST', '/v1/telegram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/qr/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Salvar sessão Telegram */
        postV1TelegramInstanceSession: async (pathParams: OpPathParams<'/v1/telegram/instances/{instanceId}/session', 'post'>, options?: { query?: OpQuery<'/v1/telegram/instances/{instanceId}/session', 'post'>; body?: OpRequestBody<'/v1/telegram/instances/{instanceId}/session', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/instances/{instanceId}/session', 'post'>>('POST', '/v1/telegram/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/session', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
      messages: {
        /** Cancelar Telegram agendado */
        postV1TelegramMessageCancel: async (pathParams: OpPathParams<'/v1/telegram/messages/{messageId}/cancel', 'post'>, options?: { query?: OpQuery<'/v1/telegram/messages/{messageId}/cancel', 'post'>; body?: OpRequestBody<'/v1/telegram/messages/{messageId}/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/messages/{messageId}/cancel', 'post'>>('POST', '/v1/telegram/messages/' + encodeURIComponent(String(pathParams.messageId)) + '/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Editar mensagem Telegram */
        patchV1TelegramMessageEdit: async (pathParams: OpPathParams<'/v1/telegram/messages/{messageId}/edit', 'patch'>, options?: { query?: OpQuery<'/v1/telegram/messages/{messageId}/edit', 'patch'>; body?: OpRequestBody<'/v1/telegram/messages/{messageId}/edit', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/messages/{messageId}/edit', 'patch'>>('PATCH', '/v1/telegram/messages/' + encodeURIComponent(String(pathParams.messageId)) + '/edit', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Listar recebidos Telegram */
        getV1TelegramInbound: async (options?: { query?: OpQuery<'/v1/telegram/messages/inbound', 'get'> }) => http.request<OpResponse<'/v1/telegram/messages/inbound', 'get'>>('GET', '/v1/telegram/messages/inbound', { query: options?.query }),
        /** Consultar recebido Telegram */
        getV1TelegramInboundById: async (pathParams: OpPathParams<'/v1/telegram/messages/inbound/{id}', 'get'>, options?: { query?: OpQuery<'/v1/telegram/messages/inbound/{id}', 'get'> }) => http.request<OpResponse<'/v1/telegram/messages/inbound/{id}', 'get'>>('GET', '/v1/telegram/messages/inbound/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
        /** Baixar mídia recebida (base64) */
        postV1TelegramInboundMedia: async (pathParams: OpPathParams<'/v1/telegram/messages/inbound/{id}/media', 'post'>, options?: { query?: OpQuery<'/v1/telegram/messages/inbound/{id}/media', 'post'>; body?: OpRequestBody<'/v1/telegram/messages/inbound/{id}/media', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/telegram/messages/inbound/{id}/media', 'post'>>('POST', '/v1/telegram/messages/inbound/' + encodeURIComponent(String(pathParams.id)) + '/media', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Baixar mídia recebida (arquivo) */
        getV1TelegramInboundMediaDownload: async (pathParams: OpPathParams<'/v1/telegram/messages/inbound/{id}/media/download', 'get'>, options?: { query?: OpQuery<'/v1/telegram/messages/inbound/{id}/media/download', 'get'> }) => http.request<OpResponse<'/v1/telegram/messages/inbound/{id}/media/download', 'get'>>('GET', '/v1/telegram/messages/inbound/' + encodeURIComponent(String(pathParams.id)) + '/media/download', { query: options?.query }),
      },
    },
    templates: {
      /** Listar templates */
      listTemplates: async (options?: { query?: OpQuery<'/v1/templates', 'get'> }) => http.request<OpResponse<'/v1/templates', 'get'>>('GET', '/v1/templates', { query: options?.query }),
      /** Criar template */
      createTemplates: async (options?: { query?: OpQuery<'/v1/templates', 'post'>; body?: OpRequestBody<'/v1/templates', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/templates', 'post'>>('POST', '/v1/templates', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir template */
      deleteTemplates: async (pathParams: OpPathParams<'/v1/templates/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/templates/{id}', 'delete'> }) => http.request<OpResponse<'/v1/templates/{id}', 'delete'>>('DELETE', '/v1/templates/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Obter template */
      getTemplates: async (pathParams: OpPathParams<'/v1/templates/{id}', 'get'>, options?: { query?: OpQuery<'/v1/templates/{id}', 'get'> }) => http.request<OpResponse<'/v1/templates/{id}', 'get'>>('GET', '/v1/templates/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar template */
      updateTemplates: async (pathParams: OpPathParams<'/v1/templates/{id}', 'patch'>, options?: { query?: OpQuery<'/v1/templates/{id}', 'patch'>; body?: OpRequestBody<'/v1/templates/{id}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/templates/{id}', 'patch'>>('PATCH', '/v1/templates/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Enviar template */
      createSend: async (options?: { query?: OpQuery<'/v1/templates/send', 'post'>; body?: OpRequestBody<'/v1/templates/send', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/templates/send', 'post'>>('POST', '/v1/templates/send', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    topics: {
      /** Listar tópicos */
      getV1Topics: async (options?: { query?: OpQuery<'/v1/topics', 'get'> }) => http.request<OpResponse<'/v1/topics', 'get'>>('GET', '/v1/topics', { query: options?.query }),
      /** Criar tópico */
      postV1Topics: async (options?: { query?: OpQuery<'/v1/topics', 'post'>; body?: OpRequestBody<'/v1/topics', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/topics', 'post'>>('POST', '/v1/topics', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir tópico */
      deleteV1Topic: async (pathParams: OpPathParams<'/v1/topics/{topicId}', 'delete'>, options?: { query?: OpQuery<'/v1/topics/{topicId}', 'delete'> }) => http.request<OpResponse<'/v1/topics/{topicId}', 'delete'>>('DELETE', '/v1/topics/' + encodeURIComponent(String(pathParams.topicId)) , { query: options?.query }),
      /** Consultar tópico */
      getV1TopicById: async (pathParams: OpPathParams<'/v1/topics/{topicId}', 'get'>, options?: { query?: OpQuery<'/v1/topics/{topicId}', 'get'> }) => http.request<OpResponse<'/v1/topics/{topicId}', 'get'>>('GET', '/v1/topics/' + encodeURIComponent(String(pathParams.topicId)) , { query: options?.query }),
      /** Atualizar tópico */
      patchV1Topic: async (pathParams: OpPathParams<'/v1/topics/{topicId}', 'patch'>, options?: { query?: OpQuery<'/v1/topics/{topicId}', 'patch'>; body?: OpRequestBody<'/v1/topics/{topicId}', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/topics/{topicId}', 'patch'>>('PATCH', '/v1/topics/' + encodeURIComponent(String(pathParams.topicId)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
    voice: {
      /** Listar ligações */
      getV1VoiceCalls: async (options?: { query?: OpQuery<'/v1/voice/calls', 'get'> }) => http.request<OpResponse<'/v1/voice/calls', 'get'>>('GET', '/v1/voice/calls', { query: options?.query }),
      /** Iniciar ligação */
      postV1VoiceCalls: async (options?: { query?: OpQuery<'/v1/voice/calls', 'post'>; body?: OpRequestBody<'/v1/voice/calls', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/voice/calls', 'post'>>('POST', '/v1/voice/calls', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Consultar ligação */
      getV1VoiceCallsById: async (pathParams: OpPathParams<'/v1/voice/calls/{id}', 'get'>, options?: { query?: OpQuery<'/v1/voice/calls/{id}', 'get'> }) => http.request<OpResponse<'/v1/voice/calls/{id}', 'get'>>('GET', '/v1/voice/calls/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      calls: {
        /** Controlar ligação em andamento */
        postV1VoiceCallsAction: async (pathParams: OpPathParams<'/v1/voice/calls/{id}/actions/{action}', 'post'>, options?: { query?: OpQuery<'/v1/voice/calls/{id}/actions/{action}', 'post'>; body?: OpRequestBody<'/v1/voice/calls/{id}/actions/{action}', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/voice/calls/{id}/actions/{action}', 'post'>>('POST', '/v1/voice/calls/' + encodeURIComponent(String(pathParams.id)) + '/actions/' + encodeURIComponent(String(pathParams.action)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Baixar gravação */
        getV1VoiceRecordingDownload: async (pathParams: OpPathParams<'/v1/voice/calls/{id}/recordings/{recordingId}/download', 'get'>, options?: { query?: OpQuery<'/v1/voice/calls/{id}/recordings/{recordingId}/download', 'get'> }) => http.request<OpResponse<'/v1/voice/calls/{id}/recordings/{recordingId}/download', 'get'>>('GET', '/v1/voice/calls/' + encodeURIComponent(String(pathParams.id)) + '/recordings/' + encodeURIComponent(String(pathParams.recordingId)) + '/download', { query: options?.query }),
      },
    },
    webhooks: {
      /** Listar webhooks */
      listWebhooks: async (options?: { query?: OpQuery<'/v1/webhooks', 'get'> }) => http.request<OpResponse<'/v1/webhooks', 'get'>>('GET', '/v1/webhooks', { query: options?.query }),
      /** Criar webhook */
      createWebhook: async (options?: { query?: OpQuery<'/v1/webhooks', 'post'>; body?: OpRequestBody<'/v1/webhooks', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/webhooks', 'post'>>('POST', '/v1/webhooks', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Excluir webhook */
      deleteWebhook: async (pathParams: OpPathParams<'/v1/webhooks/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/webhooks/{id}', 'delete'> }) => http.request<OpResponse<'/v1/webhooks/{id}', 'delete'>>('DELETE', '/v1/webhooks/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Consultar webhook */
      getWebhook: async (pathParams: OpPathParams<'/v1/webhooks/{id}', 'get'>, options?: { query?: OpQuery<'/v1/webhooks/{id}', 'get'> }) => http.request<OpResponse<'/v1/webhooks/{id}', 'get'>>('GET', '/v1/webhooks/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Atualizar webhook */
      updateWebhook: async (pathParams: OpPathParams<'/v1/webhooks/{id}', 'put'>, options?: { query?: OpQuery<'/v1/webhooks/{id}', 'put'>; body?: OpRequestBody<'/v1/webhooks/{id}', 'put'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/webhooks/{id}', 'put'>>('PUT', '/v1/webhooks/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Rotacionar secret do webhook */
      rotateWebhookSecret: async (pathParams: OpPathParams<'/v1/webhooks/{id}/rotate-secret', 'post'>, options?: { query?: OpQuery<'/v1/webhooks/{id}/rotate-secret', 'post'>; body?: OpRequestBody<'/v1/webhooks/{id}/rotate-secret', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/webhooks/{id}/rotate-secret', 'post'>>('POST', '/v1/webhooks/' + encodeURIComponent(String(pathParams.id)) + '/rotate-secret', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Listar entregas */
      listDeliveries: async (options?: { query?: OpQuery<'/v1/webhooks/deliveries', 'get'> }) => http.request<OpResponse<'/v1/webhooks/deliveries', 'get'>>('GET', '/v1/webhooks/deliveries', { query: options?.query }),
      /** Detalhe da entrega */
      getDelivery: async (pathParams: OpPathParams<'/v1/webhooks/deliveries/{deliveryId}', 'get'>, options?: { query?: OpQuery<'/v1/webhooks/deliveries/{deliveryId}', 'get'> }) => http.request<OpResponse<'/v1/webhooks/deliveries/{deliveryId}', 'get'>>('GET', '/v1/webhooks/deliveries/' + encodeURIComponent(String(pathParams.deliveryId)) , { query: options?.query }),
      deliveries: {
        /** Reenviar entrega */
        resendDelivery: async (pathParams: OpPathParams<'/v1/webhooks/deliveries/{deliveryId}/resend', 'post'>, options?: { query?: OpQuery<'/v1/webhooks/deliveries/{deliveryId}/resend', 'post'>; body?: OpRequestBody<'/v1/webhooks/deliveries/{deliveryId}/resend', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/webhooks/deliveries/{deliveryId}/resend', 'post'>>('POST', '/v1/webhooks/deliveries/' + encodeURIComponent(String(pathParams.deliveryId)) + '/resend', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    whatsapp: {
      /** Listar chamadas WhatsApp */
      getV1WhatsappCalls: async (options?: { query?: OpQuery<'/v1/whatsapp/calls', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/calls', 'get'>>('GET', '/v1/whatsapp/calls', { query: options?.query }),
      /** Iniciar chamada WhatsApp */
      postV1WhatsappCalls: async (options?: { query?: OpQuery<'/v1/whatsapp/calls', 'post'>; body?: OpRequestBody<'/v1/whatsapp/calls', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/calls', 'post'>>('POST', '/v1/whatsapp/calls', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Consultar chamada WhatsApp */
      getV1WhatsappCallById: async (pathParams: OpPathParams<'/v1/whatsapp/calls/{id}', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/calls/{id}', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/calls/{id}', 'get'>>('GET', '/v1/whatsapp/calls/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Listar conexões WhatsApp */
      getV1WhatsappInstances: async (options?: { query?: OpQuery<'/v1/whatsapp/instances', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances', 'get'>>('GET', '/v1/whatsapp/instances', { query: options?.query }),
      /** Criar instância WhatsApp */
      postV1WhatsappInstances: async (options?: { query?: OpQuery<'/v1/whatsapp/instances', 'post'>; body?: OpRequestBody<'/v1/whatsapp/instances', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances', 'post'>>('POST', '/v1/whatsapp/instances', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Remover conexão WhatsApp */
      deleteV1WhatsappInstance: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}', 'delete'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}', 'delete'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}', 'delete'>>('DELETE', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) , { query: options?.query }),
      /** Consultar conexão WhatsApp */
      getV1WhatsappInstance: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}', 'get'>>('GET', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) , { query: options?.query }),
      /** Listar mensagens WhatsApp */
      getV1WhatsappMessages: async (options?: { query?: OpQuery<'/v1/whatsapp/messages', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/messages', 'get'>>('GET', '/v1/whatsapp/messages', { query: options?.query }),
      /** Enviar mensagem WhatsApp */
      postV1WhatsappSend: async (options?: { query?: OpQuery<'/v1/whatsapp/messages', 'post'>; body?: OpRequestBody<'/v1/whatsapp/messages', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/messages', 'post'>>('POST', '/v1/whatsapp/messages', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Apagar mensagem WhatsApp */
      deleteV1WhatsappMessage: async (pathParams: OpPathParams<'/v1/whatsapp/messages/{messageId}', 'delete'>, options?: { query?: OpQuery<'/v1/whatsapp/messages/{messageId}', 'delete'> }) => http.request<OpResponse<'/v1/whatsapp/messages/{messageId}', 'delete'>>('DELETE', '/v1/whatsapp/messages/' + encodeURIComponent(String(pathParams.messageId)) , { query: options?.query }),
      /** Consultar envio WhatsApp */
      getV1WhatsappMessage: async (pathParams: OpPathParams<'/v1/whatsapp/messages/{messageId}', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/messages/{messageId}', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/messages/{messageId}', 'get'>>('GET', '/v1/whatsapp/messages/' + encodeURIComponent(String(pathParams.messageId)) , { query: options?.query }),
      instances: {
        /** Permissão de chamada */
        callPermGet: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/calling/permissions', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/calling/permissions', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/calling/permissions', 'get'>>('GET', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/calling/permissions', { query: options?.query }),
        /** Solicitar permissão */
        callPermRequest: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/calling/permissions/request', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/calling/permissions/request', 'post'>; body?: OpRequestBody<'/v1/whatsapp/instances/{instanceId}/calling/permissions/request', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/calling/permissions/request', 'post'>>('POST', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/calling/permissions/request', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Settings de chamada */
        callSettingsGet: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/calling/settings', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/calling/settings', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/calling/settings', 'get'>>('GET', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/calling/settings', { query: options?.query }),
        /** Atualizar settings */
        callSettingsPatch: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/calling/settings', 'patch'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/calling/settings', 'patch'>; body?: OpRequestBody<'/v1/whatsapp/instances/{instanceId}/calling/settings', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/calling/settings', 'patch'>>('PATCH', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/calling/settings', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Status do link WhatsApp */
        getV1WhatsappInstanceConnectPage: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/connect-page', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/connect-page', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/connect-page', 'get'>>('GET', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page', { query: options?.query }),
        /** Desativar link WhatsApp */
        postV1WhatsappInstanceConnectPageDisable: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/connect-page/disable', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/connect-page/disable', 'post'>; body?: OpRequestBody<'/v1/whatsapp/instances/{instanceId}/connect-page/disable', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/connect-page/disable', 'post'>>('POST', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page/disable', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Ativar link WhatsApp */
        postV1WhatsappInstanceConnectPageEnable: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/connect-page/enable', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/connect-page/enable', 'post'>; body?: OpRequestBody<'/v1/whatsapp/instances/{instanceId}/connect-page/enable', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/connect-page/enable', 'post'>>('POST', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page/enable', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Renovar secret do link WhatsApp */
        postV1WhatsappInstanceConnectPageRotate: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/connect-page/rotate-secret', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/connect-page/rotate-secret', 'post'>; body?: OpRequestBody<'/v1/whatsapp/instances/{instanceId}/connect-page/rotate-secret', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/connect-page/rotate-secret', 'post'>>('POST', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/connect-page/rotate-secret', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Desconectar WhatsApp */
        postV1WhatsappInstanceDisconnect: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/disconnect', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/disconnect', 'post'>; body?: OpRequestBody<'/v1/whatsapp/instances/{instanceId}/disconnect', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/disconnect', 'post'>>('POST', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/disconnect', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Listar grupos WhatsApp */
        getV1WhatsappInstancesInstanceIdGroups: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/groups', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/groups', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/groups', 'get'>>('GET', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/groups', { query: options?.query }),
        /** Listar participantes do grupo */
        getV1WhatsappInstancesInstanceIdGroupsGroupIdParticipants: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/groups/{groupId}/participants', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/groups/{groupId}/participants', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/groups/{groupId}/participants', 'get'>>('GET', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/groups/' + encodeURIComponent(String(pathParams.groupId)) + '/participants', { query: options?.query }),
        /** Enviar convite de grupo */
        postV1WhatsappInstancesInstanceIdGroupsInvite: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/groups/invite', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/groups/invite', 'post'>; body?: OpRequestBody<'/v1/whatsapp/instances/{instanceId}/groups/invite', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/groups/invite', 'post'>>('POST', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/groups/invite', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Obter código de convite */
        getV1WhatsappInstancesInstanceIdGroupsInviteCode: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/groups/invite-code', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/groups/invite-code', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/groups/invite-code', 'get'>>('GET', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/groups/invite-code', { query: options?.query }),
        /** Revogar convite de grupo */
        postV1WhatsappInstancesInstanceIdGroupsInviteRevoke: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/groups/invite/revoke', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/groups/invite/revoke', 'post'>; body?: OpRequestBody<'/v1/whatsapp/instances/{instanceId}/groups/invite/revoke', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/groups/invite/revoke', 'post'>>('POST', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/groups/invite/revoke', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Atualizar participantes do grupo */
        postV1WhatsappInstancesInstanceIdGroupsParticipants: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/groups/participants', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/groups/participants', 'post'>; body?: OpRequestBody<'/v1/whatsapp/instances/{instanceId}/groups/participants', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/groups/participants', 'post'>>('POST', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/groups/participants', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Obter código de pareamento */
        getV1WhatsappInstancePairingCode: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/pairing-code', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/pairing-code', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/pairing-code', 'get'>>('GET', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/pairing-code', { query: options?.query }),
        /** Obter QR WhatsApp */
        getV1WhatsappInstanceQr: async (pathParams: OpPathParams<'/v1/whatsapp/instances/{instanceId}/qr', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/instances/{instanceId}/qr', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/instances/{instanceId}/qr', 'get'>>('GET', '/v1/whatsapp/instances/' + encodeURIComponent(String(pathParams.instanceId)) + '/qr', { query: options?.query }),
      },
      messages: {
        /** Cancelar WhatsApp agendado */
        postV1WhatsappMessageCancel: async (pathParams: OpPathParams<'/v1/whatsapp/messages/{messageId}/cancel', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/messages/{messageId}/cancel', 'post'>; body?: OpRequestBody<'/v1/whatsapp/messages/{messageId}/cancel', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/messages/{messageId}/cancel', 'post'>>('POST', '/v1/whatsapp/messages/' + encodeURIComponent(String(pathParams.messageId)) + '/cancel', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Editar mensagem WhatsApp */
        patchV1WhatsappMessageEdit: async (pathParams: OpPathParams<'/v1/whatsapp/messages/{messageId}/edit', 'patch'>, options?: { query?: OpQuery<'/v1/whatsapp/messages/{messageId}/edit', 'patch'>; body?: OpRequestBody<'/v1/whatsapp/messages/{messageId}/edit', 'patch'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/messages/{messageId}/edit', 'patch'>>('PATCH', '/v1/whatsapp/messages/' + encodeURIComponent(String(pathParams.messageId)) + '/edit', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Listar recebidos WhatsApp */
        getV1WhatsappMessagesInbound: async (options?: { query?: OpQuery<'/v1/whatsapp/messages/inbound', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/messages/inbound', 'get'>>('GET', '/v1/whatsapp/messages/inbound', { query: options?.query }),
        /** Consultar recebido WhatsApp */
        getV1WhatsappMessageInboundById: async (pathParams: OpPathParams<'/v1/whatsapp/messages/inbound/{id}', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/messages/inbound/{id}', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/messages/inbound/{id}', 'get'>>('GET', '/v1/whatsapp/messages/inbound/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
        /** Baixar mídia recebida (base64) */
        postV1WhatsappMessageInboundMedia: async (pathParams: OpPathParams<'/v1/whatsapp/messages/inbound/{id}/media', 'post'>, options?: { query?: OpQuery<'/v1/whatsapp/messages/inbound/{id}/media', 'post'>; body?: OpRequestBody<'/v1/whatsapp/messages/inbound/{id}/media', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/messages/inbound/{id}/media', 'post'>>('POST', '/v1/whatsapp/messages/inbound/' + encodeURIComponent(String(pathParams.id)) + '/media', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
        /** Baixar mídia recebida (arquivo) */
        getV1WhatsappMessageInboundMediaDownload: async (pathParams: OpPathParams<'/v1/whatsapp/messages/inbound/{id}/media/download', 'get'>, options?: { query?: OpQuery<'/v1/whatsapp/messages/inbound/{id}/media/download', 'get'> }) => http.request<OpResponse<'/v1/whatsapp/messages/inbound/{id}/media/download', 'get'>>('GET', '/v1/whatsapp/messages/inbound/' + encodeURIComponent(String(pathParams.id)) + '/media/download', { query: options?.query }),
        /** Enviar presença no chat WhatsApp */
        postV1WhatsappMessagePresence: async (options?: { query?: OpQuery<'/v1/whatsapp/messages/presence', 'post'>; body?: OpRequestBody<'/v1/whatsapp/messages/presence', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/whatsapp/messages/presence', 'post'>>('POST', '/v1/whatsapp/messages/presence', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      },
    },
    workspaces: {
      /** Listar workspace da chave */
      getV1Workspaces: async (options?: { query?: OpQuery<'/v1/workspaces', 'get'> }) => http.request<OpResponse<'/v1/workspaces', 'get'>>('GET', '/v1/workspaces', { query: options?.query }),
      /** Criar workspace */
      postV1Workspaces: async (options?: { query?: OpQuery<'/v1/workspaces', 'post'>; body?: OpRequestBody<'/v1/workspaces', 'post'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/workspaces', 'post'>>('POST', '/v1/workspaces', { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
      /** Deletar workspace */
      deleteV1WorkspacesById: async (pathParams: OpPathParams<'/v1/workspaces/{id}', 'delete'>, options?: { query?: OpQuery<'/v1/workspaces/{id}', 'delete'> }) => http.request<OpResponse<'/v1/workspaces/{id}', 'delete'>>('DELETE', '/v1/workspaces/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Obter workspace */
      getV1WorkspacesById: async (pathParams: OpPathParams<'/v1/workspaces/{id}', 'get'>, options?: { query?: OpQuery<'/v1/workspaces/{id}', 'get'> }) => http.request<OpResponse<'/v1/workspaces/{id}', 'get'>>('GET', '/v1/workspaces/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query }),
      /** Editar workspace */
      putV1WorkspacesById: async (pathParams: OpPathParams<'/v1/workspaces/{id}', 'put'>, options?: { query?: OpQuery<'/v1/workspaces/{id}', 'put'>; body?: OpRequestBody<'/v1/workspaces/{id}', 'put'>; idempotencyKey?: string }) => http.request<OpResponse<'/v1/workspaces/{id}', 'put'>>('PUT', '/v1/workspaces/' + encodeURIComponent(String(pathParams.id)) , { query: options?.query, body: options?.body, idempotencyKey: options?.idempotencyKey }),
    },
  };
}

export type GeneratedApi = ReturnType<typeof createGeneratedApi>;