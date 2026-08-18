# Notifique SDK

Monorepo oficial dos SDKs multilíngues da [Notifique](https://notifique.dev) — **cobertura completa da API v1** (353 operações, 23 specs OpenAPI).

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk)

Documentação: [docs.notifique.dev](https://docs.notifique.dev)

## Pacotes

| Linguagem | Pacote | Cobertura OpenAPI |
|-----------|--------|-------------------|
| Node.js / TypeScript | `@notifique/core`, `@notifique/sdk-node` | 353 ops (`client.api` + namespaces) |
| Python | `notifique-sdk` | 353 ops (`client.api`) |
| Go | `github.com/notifique/notifique-sdk-go` | 353 ops (`client.API()`) |
| Java | `com.notifique:notifique-sdk` | 353 ops (`client.api`) |
| .NET | `Notifique` | 353 ops (`client.Api`) |
| PHP | `notifique/notifique-sdk-php` | 353 ops (`$client->api`) |
| Elixir | `:notifique` | 353 ops (`client.api`) |

**Push no dispositivo** (Web/RN/Flutter/Android/iOS) fica em [notifique-dev/notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este repo cobre a **API server-side** (envio, contatos, automações, platform, etc.).

## Namespaces legados

Atalhos tipados para os canais mais usados — continuam disponíveis em todos os SDKs:

- `whatsapp`, `sms`, `email`, `push`, `messages` (template multicanal)

Para o restante da API (OAuth, contatos, automações, platform, voice, RCS, etc.), use o cliente gerado (`client.api`, `client.Api`, `$client->api`, etc.) — ver README de cada pacote.

## Tipos OpenAPI (`@notifique/core`)

Schemas tipados gerados a partir dos **23 specs** OpenAPI (`components`, `paths`, `operations`) são exportados por `@notifique/core`:

```typescript
import type { PushComponents, WhatsappComponents, ApiPaths, OpResponse } from '@notifique/core';
// 23 specs → WhatsappPaths, PushComponents, OauthOperations, etc.
```

`client.api` no Node SDK usa **`OpResponse` / `OpRequestBody` / `OpQuery` / `OpPathParams`** por operação — autocomplete completo no IDE.

## Smoke test (produção)

```bash
npm run smoke:prod                    # público (.well-known)
NOTIFIQUE_API_KEY=sk_test_... npm run smoke:prod  # + contacts, oauth, push
```

## Início rápido (Node)

```typescript
import { Notifique, createPublicClient } from '@notifique/sdk-node';

const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });

// Legado (atalhos tipados)
await client.whatsapp.sendText('instance-id', '5511999999999', 'Olá!');

// API completa (353 operações, 23 specs OpenAPI)
await client.api.contacts.getV1Contacts({ query: { limit: 20 } });
await client.automations.listAutomations({ query: { page: 1 } });

// Público (sem API key) — widget, OAuth metadata, report
const publicApi = createPublicClient();
await publicApi.public.aiWidget.getConfig({ publicKey: 'pk_...' });
```

## Geração a partir do OpenAPI

Specs canônicas em `notifique-docs` (PT). O script sincroniza e gera bindings:

```bash
# requer ../notifique-docs (clone sibling)
npm run generate
npm test
```

Artefatos:

- `packages/core/src/generated/operations.json` — registry de 353 operações
- `packages/sdk-node/src/generated/api.ts` — cliente TypeScript
- `operations.json` copiado em cada SDK para API dinâmica

## Estrutura

```
packages/
  core/           # tipos + registry OpenAPI
  sdk-node/       # referência TypeScript
  sdk-python/     # ...
  sdk-go/
  sdk-java/
  sdk-dotnet/
  sdk-php/
  sdk-elixir/
openapi/          # manifest de specs
scripts/          # generate-from-openapi.mjs
```

## Testes

```bash
npm test                    # Node + contrato OpenAPI
cd packages/sdk-go && go test ./...
cd packages/sdk-python && pytest
cd packages/sdk-java && mvn test   # JDK 17
dotnet test packages/sdk-dotnet/tests/Notifique.Tests/Notifique.Tests.csproj
cd packages/sdk-php && composer test
cd packages/sdk-elixir && mix test
```

## Versão

Monorepo alinhado em **0.2.0** (mesma linha dos push SDKs).

## Segurança

[SECURITY.md](SECURITY.md) · security@notifique.dev
