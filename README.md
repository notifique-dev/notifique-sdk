# Notifique SDK

Official multilingual SDK monorepo for [Notifique](https://notifique.dev) — **full API v1 coverage** (353 operations, 23 OpenAPI specs).

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

---

Monorepo oficial dos SDKs multilíngues da [Notifique](https://notifique.dev) — **cobertura completa da API v1** (353 operações, 23 specs OpenAPI).

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Client-side push** (Web/RN/Flutter/Android/iOS): [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This repo is the **server-side** API (send, contacts, automations, platform, etc.).

**Push no dispositivo** (Web/RN/Flutter/Android/iOS): [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este repo cobre a **API server-side** (envio, contatos, automações, platform, etc.).

## Packages

| Language | Package | Version | README |
|----------|---------|---------|--------|
| Node.js / TypeScript | `@notifique/core`, `@notifique/sdk-node` | 0.2.1 | [sdk-node](packages/sdk-node/README.md) |
| Python | `notifique-sdk` | 0.2.1 | [sdk-python](packages/sdk-python/README.md) |
| Go | `github.com/notifique-dev/notifique-sdk/packages/sdk-go` | 0.2.1 | [sdk-go](packages/sdk-go/README.md) |
| Java | `com.notifique:notifique-sdk` | 0.2.1 | [sdk-java](packages/sdk-java/README.md) |
| .NET | `Notifique` | 0.2.1 | [sdk-dotnet](packages/sdk-dotnet/README.md) |
| PHP | `notifique/notifique-sdk-php` | 0.2.1 | [sdk-php](packages/sdk-php/README.md) |
| Elixir | `:notifique` | 0.2.1 | [sdk-elixir](packages/sdk-elixir/README.md) |

## Pacotes

| Linguagem | Pacote | Versão | README |
|-----------|--------|--------|--------|
| Node.js / TypeScript | `@notifique/core`, `@notifique/sdk-node` | 0.2.1 | [sdk-node](packages/sdk-node/README.md) |
| Python | `notifique-sdk` | 0.2.1 | [sdk-python](packages/sdk-python/README.md) |
| Go | `github.com/notifique-dev/notifique-sdk/packages/sdk-go` | 0.2.1 | [sdk-go](packages/sdk-go/README.md) |
| Java | `com.notifique:notifique-sdk` | 0.2.1 | [sdk-java](packages/sdk-java/README.md) |
| .NET | `Notifique` | 0.2.1 | [sdk-dotnet](packages/sdk-dotnet/README.md) |
| PHP | `notifique/notifique-sdk-php` | 0.2.1 | [sdk-php](packages/sdk-php/README.md) |
| Elixir | `:notifique` | 0.2.1 | [sdk-elixir](packages/sdk-elixir/README.md) |

## Installation by language

Pick your stack and run the command below. Each package README has bilingual examples (SMS, all 8 channels, webhooks, logs).

### Node.js / TypeScript

```bash
npm install @notifique/sdk-node
```

Types and OpenAPI schemas (optional, re-exported by sdk-node):

```bash
npm install @notifique/core
```

### Python

```bash
pip install notifique-sdk
```

### Go

```bash
go get github.com/notifique-dev/notifique-sdk/packages/sdk-go@v0.2.1
```

Module path: `github.com/notifique-dev/notifique-sdk/packages/sdk-go`

Requires monorepo tag `packages/sdk-go/v0.2.1` (or `@main` for latest).

### Java — Maven

```xml
<dependency>
    <groupId>com.notifique</groupId>
    <artifactId>notifique-sdk</artifactId>
    <version>0.2.1</version>
</dependency>
```

### Java — Gradle

```gradle
implementation 'com.notifique:notifique-sdk:0.2.1'
```

### .NET

```bash
dotnet add package Notifique
```

Or in Visual Studio: `Install-Package Notifique`

### PHP

```bash
composer require notifique/notifique-sdk-php
```

Package lives in this monorepo (`packages/sdk-php`). Before Packagist, add the VCS repo to `composer.json`:

```json
{
  "repositories": [
    { "type": "vcs", "url": "https://github.com/notifique-dev/notifique-sdk" }
  ]
}
```

### Elixir

In `mix.exs`:

```elixir
def deps do
  [
    {:notifique, "~> 0.2.1"}
  ]
end
```

Then:

```bash
mix deps.get
```

## Instalação por linguagem

Escolha sua stack e rode o comando. Cada README de pacote tem exemplos bilíngues (SMS, os 8 canais, webhooks, logs).

### Node.js / TypeScript

```bash
npm install @notifique/sdk-node
```

Tipos e schemas OpenAPI (opcional, reexportados pelo sdk-node):

```bash
npm install @notifique/core
```

### Python

```bash
pip install notifique-sdk
```

### Go

```bash
go get github.com/notifique-dev/notifique-sdk/packages/sdk-go@v0.2.1
```

Módulo: `github.com/notifique-dev/notifique-sdk/packages/sdk-go`

Requer tag de monorepo `packages/sdk-go/v0.2.1` (ou `@main` para o mais recente).

### Java — Maven

```xml
<dependency>
    <groupId>com.notifique</groupId>
    <artifactId>notifique-sdk</artifactId>
    <version>0.2.1</version>
</dependency>
```

### Java — Gradle

```gradle
implementation 'com.notifique:notifique-sdk:0.2.1'
```

### .NET

```bash
dotnet add package Notifique
```

Ou no Visual Studio: `Install-Package Notifique`

### PHP

```bash
composer require notifique/notifique-sdk-php
```

Pacote no monorepo (`packages/sdk-php`). Antes do Packagist, adicione o repositório VCS no `composer.json`:

```json
{
  "repositories": [
    { "type": "vcs", "url": "https://github.com/notifique-dev/notifique-sdk" }
  ]
}
```

### Elixir

No `mix.exs`:

```elixir
def deps do
  [
    {:notifique, "~> 0.2.1"}
  ]
end
```

Depois:

```bash
mix deps.get
```

## Quick start (Node)

```typescript
import { Notifique } from '@notifique/sdk-node';

const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });

await client.whatsapp.sendText('instance-id', '5511999999999', 'Hello!');
await client.sms.send({ to: ['5511999999999'], message: 'Hello SMS!' });
await client.api.contacts.getV1Contacts({ query: { limit: 20 } });
```

## Início rápido (Node)

```typescript
import { Notifique } from '@notifique/sdk-node';

const client = new Notifique({ apiKey: process.env.NOTIFIQUE_API_KEY! });

await client.whatsapp.sendText('instance-id', '5511999999999', 'Olá!');
await client.sms.send({ to: ['5511999999999'], message: 'Olá SMS!' });
await client.api.contacts.getV1Contacts({ query: { limit: 20 } });
```

## Legacy namespaces

Typed shortcuts for the most common channels — available in every SDK:

- `whatsapp`, `sms`, `email`, `push`, `messages` (multi-channel templates)

For the rest of the API (OAuth, contacts, automations, platform, voice, RCS, Telegram, Instagram, webhooks, logs, …), use the generated client (`client.api`, `client.Api`, `$client->api`, etc.) — see each package README.

## Namespaces legados

Atalhos tipados para os canais mais usados — disponíveis em todos os SDKs:

- `whatsapp`, `sms`, `email`, `push`, `messages` (templates multicanal)

Para o restante da API (OAuth, contatos, automações, platform, voz, RCS, Telegram, Instagram, webhooks, logs, …), use o cliente gerado (`client.api`, `client.Api`, `$client->api`, etc.) — ver README de cada pacote.

## OpenAPI types (`@notifique/core`)

Typed schemas from **23 OpenAPI specs** (`components`, `paths`, `operations`):

```typescript
import type { OpResponse, PushComponents, WhatsappComponents } from '@notifique/core';
```

`client.api` in the Node SDK uses **`OpResponse` / `OpRequestBody` / `OpQuery` / `OpPathParams`** per operation — full IDE autocomplete.

## Tipos OpenAPI (`@notifique/core`)

Schemas tipados dos **23 specs** OpenAPI (`components`, `paths`, `operations`):

```typescript
import type { OpResponse, PushComponents, WhatsappComponents } from '@notifique/core';
```

`client.api` no Node SDK usa **`OpResponse` / `OpRequestBody` / `OpQuery` / `OpPathParams`** por operação — autocomplete completo no IDE.

## Smoke test (production)

```bash
npm run smoke:prod
NOTIFIQUE_API_KEY=sk_test_... npm run smoke:prod
```

## Smoke test (produção)

```bash
npm run smoke:prod
NOTIFIQUE_API_KEY=sk_test_... npm run smoke:prod
```

## Generate from OpenAPI

Canonical specs in [notifique-docs](https://github.com/notifique-dev/notifique-docs) (PT). Sync and regenerate bindings:

```bash
# requires ../notifique-docs as sibling clone
npm run generate
npm test
```

Artifacts:

- `packages/core/src/generated/operations.json` — 353-operation registry
- `packages/sdk-node/src/generated/api.ts` — TypeScript client
- `operations.json` copied into each SDK for dynamic API trees

## Geração a partir do OpenAPI

Specs canônicas em [notifique-docs](https://github.com/notifique-dev/notifique-docs) (PT). Sincronizar e regenerar bindings:

```bash
# requer ../notifique-docs (clone sibling)
npm run generate
npm test
```

Artefatos:

- `packages/core/src/generated/operations.json` — registry de 353 operações
- `packages/sdk-node/src/generated/api.ts` — cliente TypeScript
- `operations.json` copiado em cada SDK para API dinâmica

## Repository layout

```
packages/
  core/           # types + OpenAPI registry
  sdk-node/       # TypeScript reference client
  sdk-python/
  sdk-go/
  sdk-java/
  sdk-dotnet/
  sdk-php/
  sdk-elixir/
openapi/          # spec manifest
scripts/          # generate-from-openapi.mjs
```

## Estrutura do repositório

```
packages/
  core/           # tipos + registry OpenAPI
  sdk-node/       # cliente TypeScript de referência
  sdk-python/
  sdk-go/
  sdk-java/
  sdk-dotnet/
  sdk-php/
  sdk-elixir/
openapi/          # manifest de specs
scripts/          # generate-from-openapi.mjs
```

## Tests

```bash
npm test
cd packages/sdk-go && go test ./...
cd packages/sdk-python && pytest
cd packages/sdk-java && mvn test
dotnet test packages/sdk-dotnet/tests/Notifique.Tests/Notifique.Tests.csproj
cd packages/sdk-php && composer test
cd packages/sdk-elixir && mix test
```

## Testes

```bash
npm test
cd packages/sdk-go && go test ./...
cd packages/sdk-python && pytest
cd packages/sdk-java && mvn test
dotnet test packages/sdk-dotnet/tests/Notifique.Tests/Notifique.Tests.csproj
cd packages/sdk-php && composer test
cd packages/sdk-elixir && mix test
```

## Version

Monorepo aligned at **0.2.1** (same line as push SDKs).

## Versão

Monorepo alinhado em **0.2.1** (mesma linha dos push SDKs).

## Security

[SECURITY.md](SECURITY.md) · security@notifique.dev

## Segurança

[SECURITY.md](SECURITY.md) · security@notifique.dev
