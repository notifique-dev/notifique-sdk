# Notifique Java SDK

**[English](#english)** · **[Português](#português)** · Docs: [docs.notifique.dev](https://docs.notifique.dev)

---

## English

Server-side Notifique SDK for Java (v0.2.1).

Maven `groupId` is **`dev.notifique`** (matches [notifique.dev](https://notifique.dev) — not `com.*`).

### Install — Maven

```xml
<dependency>
    <groupId>dev.notifique</groupId>
    <artifactId>notifique-sdk</artifactId>
    <version>0.2.1</version>
</dependency>
```

### Install — Gradle

```gradle
implementation 'dev.notifique:notifique-sdk:0.2.1'
```

### Quick start

```java
import dev.notifique.sdk.Notifique;

Notifique client = new Notifique("your-api-key");
var res = client.whatsapp.sendText("instance-id", "5511999999999", "Hello!");
res.getData().getMessageIds();
```

### Send SMS

```java
import dev.notifique.sdk.model.SmsSendParams;
import java.util.List;

client.sms.send(new SmsSendParams(List.of("5511999999999"), "Hello SMS!"));
```

### Send by channel

| Channel | Example |
|---------|---------|
| WhatsApp | `client.whatsapp.sendText(instanceId, phone, "Hello!")` |
| SMS | `client.sms.send(new SmsSendParams(...))` |
| Email | `client.email.send(emailParams)` |
| Push | `client.push.messages.send(pushParams)` |
| Telegram | `client.api.telegram.postV1TelegramSend(body, null)` |
| Instagram | `client.api.instagram.sendMessage(body, null)` |
| RCS | `client.api.rcs.postV1RcsSend(body, null)` |
| Voice | `client.api.voice.postV1VoiceCalls(body, null)` |

### Webhooks & logs

```java
import dev.notifique.sdk.generated.ApiRequestOptions;
import java.util.Map;

client.api.webhooks.listWebhooks(ApiRequestOptions.builder().query(Map.of("limit", "20")).build());
client.api.logs.getV1Logs(ApiRequestOptions.builder().query(Map.of("page", "1")).build());
```

---

## Português

SDK server-side Notifique para Java (v0.2.1).

O `groupId` Maven é **`dev.notifique`** (alinhado a [notifique.dev](https://notifique.dev) — não `com.*`).

### Instalação — Maven

```xml
<dependency>
    <groupId>dev.notifique</groupId>
    <artifactId>notifique-sdk</artifactId>
    <version>0.2.1</version>
</dependency>
```

### Instalação — Gradle

```gradle
implementation 'dev.notifique:notifique-sdk:0.2.1'
```

### Início rápido

```java
import dev.notifique.sdk.Notifique;

Notifique client = new Notifique("sua-api-key");
var res = client.whatsapp.sendText("instance-id", "5511999999999", "Olá!");
res.getData().getMessageIds();
```

### Enviar SMS

```java
client.sms.send(new SmsSendParams(List.of("5511999999999"), "Olá SMS!"));
```

### Enviar por canal

| Canal | Exemplo |
|-------|---------|
| WhatsApp | `client.whatsapp.sendText(instanceId, telefone, "Olá!")` |
| SMS | `client.sms.send(new SmsSendParams(...))` |
| Email | `client.email.send(emailParams)` |
| Push | `client.push.messages.send(pushParams)` |
| Telegram | `client.api.telegram.postV1TelegramSend(body, null)` |
| Instagram | `client.api.instagram.sendMessage(body, null)` |
| RCS | `client.api.rcs.postV1RcsSend(body, null)` |
| Voz | `client.api.voice.postV1VoiceCalls(body, null)` |

### Webhooks e logs

```java
client.api.webhooks.listWebhooks(ApiRequestOptions.builder().query(Map.of("limit", "20")).build());
client.api.logs.getV1Logs(ApiRequestOptions.builder().query(Map.of("page", "1")).build());
```
