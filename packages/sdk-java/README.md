# Notifique Java SDK

Official Notifique SDK for Java — **v0.2.1** with full OpenAPI v1 coverage (353 operations, 23 specs).

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-java) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Client-side push**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

---

SDK oficial Notifique para Java — **v0.2.1** com cobertura completa da API v1 OpenAPI (353 operações, 23 specs).

Repositório: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk/tree/main/packages/sdk-java) · Docs: [docs.notifique.dev](https://docs.notifique.dev)

**Push no dispositivo**: [notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). Este pacote cobre a **API server-side**.

## Installation

### Maven

```xml
<dependency>
    <groupId>com.notifique</groupId>
    <artifactId>notifique-sdk</artifactId>
    <version>0.2.1</version>
</dependency>
```

### Gradle

```gradle
implementation 'com.notifique:notifique-sdk:0.2.1'
```

## Instalação

### Maven

```xml
<dependency>
    <groupId>com.notifique</groupId>
    <artifactId>notifique-sdk</artifactId>
    <version>0.2.1</version>
</dependency>
```

### Gradle

```gradle
implementation 'com.notifique:notifique-sdk:0.2.1'
```

## Quick start

```java
import com.notifique.sdk.Notifique;

Notifique client = new Notifique("your-api-key");
var res = client.whatsapp.sendText("instance-id", "5511999999999", "Hello!");
res.getData().getMessageIds();
```

## Início rápido

```java
import com.notifique.sdk.Notifique;

Notifique client = new Notifique("sua-api-key");
var res = client.whatsapp.sendText("instance-id", "5511999999999", "Olá!");
res.getData().getMessageIds();
```

## Send SMS

```java
import com.notifique.sdk.model.SmsSendParams;
import java.util.List;

client.sms.send(new SmsSendParams(List.of("5511999999999"), "Hello via SMS!"));
client.sms.get("sms-id");
client.sms.cancel("sms-id");
```

## Enviar SMS

```java
client.sms.send(new SmsSendParams(List.of("5511999999999"), "Olá via SMS!"));
client.sms.get("sms-id");
client.sms.cancel("sms-id");
```

## Send messages by channel

### WhatsApp

```java
client.whatsapp.sendText("instance-id", "5511999999999", "Hello!");
```

### SMS

```java
client.sms.send(new SmsSendParams(List.of("5511999999999"), "SMS text"));
```

### Email

```java
import com.notifique.sdk.model.EmailSendParams;

EmailSendParams email = new EmailSendParams();
email.setFrom("noreply@yourdomain.com");
email.setTo(List.of("user@example.com"));
email.setSubject("Welcome");
email.setHtml("<p>Hello!</p>");
client.email.send(email);
```

### Push

```java
import com.notifique.sdk.model.PushSendParams;
import java.util.Map;

PushSendParams push = new PushSendParams();
push.setTo(List.of("device-id"));
push.setType("push");
push.setPayload(Map.of("title", "Title", "body", "Body"));
client.push.messages.send(push);
```

### Telegram

```java
import com.notifique.sdk.openapi.models.NtfTgSendTelegramMessageRequest;
import com.notifique.sdk.openapi.models.NtfTgSendTelegramMessageRequestPayload;

NtfTgSendTelegramMessageRequest req = new NtfTgSendTelegramMessageRequest();
req.setInstanceId("inst_abc");
req.setTo(List.of("@username"));
req.setType("text");
NtfTgSendTelegramMessageRequestPayload payload = new NtfTgSendTelegramMessageRequestPayload();
payload.setMessage("Hello!");
req.setPayload(payload);
client.api.telegram.postV1TelegramSend(req, null);
```

### Instagram

```java
import com.notifique.sdk.openapi.models.NtfIgSendMessageBody;
import java.util.Map;

NtfIgSendMessageBody ig = new NtfIgSendMessageBody();
ig.setInstanceId("inst_abc");
ig.setTo(List.of("target_user"));
ig.setType("text");
ig.setPayload(Map.of("message", "Hello!"));
client.api.instagram.sendMessage(ig, null);
```

### RCS

```java
import com.notifique.sdk.openapi.models.NtfRcsSendRcsRequest;

NtfRcsSendRcsRequest rcs = new NtfRcsSendRcsRequest();
rcs.setTo(List.of("5511999999999"));
rcs.setType("basic");
rcs.setPayload(Map.of("message", "Hello RCS!"));
client.api.rcs.postV1RcsSend(rcs, null);
```

### Voice

```java
import com.notifique.sdk.openapi.models.NtfVoiceCreateBody;

NtfVoiceCreateBody voice = new NtfVoiceCreateBody();
voice.setFrom("5511987654321");
voice.setTo(List.of("5511999887766"));
voice.setType("speak");
voice.setPayload(Map.of("text", "Hello! Test call.", "voice", "female-natural"));
client.api.voice.postV1VoiceCalls(voice, null);
```

## Enviar mensagens por canal

### WhatsApp

```java
client.whatsapp.sendText("instance-id", "5511999999999", "Olá!");
```

### SMS

```java
client.sms.send(new SmsSendParams(List.of("5511999999999"), "Texto SMS"));
```

### Email

```java
EmailSendParams email = new EmailSendParams();
email.setFrom("noreply@seudominio.com");
email.setTo(List.of("usuario@example.com"));
email.setSubject("Bem-vindo");
email.setHtml("<p>Olá!</p>");
client.email.send(email);
```

### Push

```java
PushSendParams push = new PushSendParams();
push.setTo(List.of("device-id"));
push.setType("push");
push.setPayload(Map.of("title", "Título", "body", "Corpo"));
client.push.messages.send(push);
```

### Telegram

```java
NtfTgSendTelegramMessageRequest req = new NtfTgSendTelegramMessageRequest();
req.setInstanceId("inst_abc");
req.setTo(List.of("@usuario"));
req.setType("text");
NtfTgSendTelegramMessageRequestPayload payload = new NtfTgSendTelegramMessageRequestPayload();
payload.setMessage("Olá!");
req.setPayload(payload);
client.api.telegram.postV1TelegramSend(req, null);
```

### Instagram

```java
NtfIgSendMessageBody ig = new NtfIgSendMessageBody();
ig.setInstanceId("inst_abc");
ig.setTo(List.of("usuario_alvo"));
ig.setType("text");
ig.setPayload(Map.of("message", "Olá!"));
client.api.instagram.sendMessage(ig, null);
```

### RCS

```java
NtfRcsSendRcsRequest rcs = new NtfRcsSendRcsRequest();
rcs.setTo(List.of("5511999999999"));
rcs.setType("basic");
rcs.setPayload(Map.of("message", "Olá RCS!"));
client.api.rcs.postV1RcsSend(rcs, null);
```

### Voz

```java
NtfVoiceCreateBody voice = new NtfVoiceCreateBody();
voice.setFrom("5511987654321");
voice.setTo(List.of("5511999887766"));
voice.setType("speak");
voice.setPayload(Map.of("text", "Olá! Ligação de teste.", "voice", "female-natural"));
client.api.voice.postV1VoiceCalls(voice, null);
```

## Webhooks & logs

```java
import com.notifique.sdk.generated.ApiRequestOptions;
import java.util.Map;

client.api.webhooks.listWebhooks(ApiRequestOptions.builder().query(Map.of("page", "1", "limit", "20")).build());
client.api.logs.getV1Logs(ApiRequestOptions.builder().query(Map.of("page", "1", "limit", "50")).build());
client.api.logs.getV1LogsById("log-id", null);
client.api.webhooks.listDeliveries(ApiRequestOptions.builder().query(Map.of("limit", "20")).build());
```

## Webhooks e logs

```java
client.api.webhooks.listWebhooks(ApiRequestOptions.builder().query(Map.of("page", "1", "limit", "20")).build());
client.api.logs.getV1Logs(ApiRequestOptions.builder().query(Map.of("page", "1", "limit", "50")).build());
client.api.logs.getV1LogsById("log-id", null);
client.api.webhooks.listDeliveries(ApiRequestOptions.builder().query(Map.of("limit", "20")).build());
```

## Full API

- **353 operations**, legacy `whatsapp`, `sms`, `email`, `push`, `messages`
- **Typed**: `client.api.telegram`, `client.api.webhooks`, …
- Java 11+, Jackson Databind

Regenerate: `npm run generate` in monorepo root.

## API completa

- **353 operações**, legado `whatsapp`, `sms`, `email`, `push`, `messages`
- **Tipado**: `client.api.telegram`, `client.api.webhooks`, …
- Java 11+, Jackson Databind

Regenerar: `npm run generate` na raiz do monorepo.
