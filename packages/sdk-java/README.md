# Notifique Java SDK

Official Notifique SDK for Java — **v0.2.0** with full OpenAPI v1 coverage.

Repository: [notifique-dev/notifique-sdk](https://github.com/notifique-dev/notifique-sdk)

## Full API coverage (v0.2.0)

- **353 operations** across **23 OpenAPI specs**
- **Legacy namespaces** (typed shortcuts): `whatsapp`, `sms`, `email`, `push`, `messages`
- **Generated client**: `client.api` — nested namespaces from `operations.json`
- **Invoke pattern**: `client.api.namespace("oauth").invoke("listWorkspaceApps", options)`

```java
import com.fasterxml.jackson.databind.JsonNode;
import com.notifique.sdk.Notifique;
import com.notifique.sdk.generated.ApiRequestOptions;

Notifique client = new Notifique("your-api-key");

// Full API via generated namespaces
JsonNode contacts = client.api
    .namespace("contacts")
    .invoke("getV1Contacts", ApiRequestOptions.builder().query(Map.of("limit", "20")).build());

JsonNode apps = client.api
    .namespace("oauth")
    .namespace("apps")
    .invoke("rotateWorkspaceAppSecret", Map.of("id", "app-id"), ApiRequestOptions.builder().build());
```

Regenerate bindings from [notifique-docs](https://github.com/notifique-dev/notifique-docs): `npm run generate` (monorepo root).

**Client-side push**: [notifique-dev/notifique-push-sdks](https://github.com/notifique-dev/notifique-push-sdks). This package is the **server-side** API.

## Installation

### Maven
```xml
<dependency>
    <groupId>com.notifique</groupId>
    <artifactId>notifique-sdk</artifactId>
    <version>0.2.0</version>
</dependency>
```

### Gradle
```gradle
implementation 'com.notifique:notifique-sdk:0.2.0'
```

## Quick Start (legacy namespaces)

```java
import com.notifique.sdk.Notifique;
import com.notifique.sdk.model.*;

Notifique notifique = new Notifique("sua-api-key");
// baseUrl padrão: https://api.notifique.dev/v1

// WhatsApp — envelope getData() para send/sendText e getMessage()
WhatsAppSendEnvelope sendRes = notifique.whatsapp.sendText("instance-id", "5511999999999", "Olá!");
sendRes.getData().getMessageIds();

WhatsAppMessageEnvelope msg = notifique.whatsapp.getMessage("message-id");
msg.getData().getStatus();

notifique.whatsapp.listMessages();
notifique.whatsapp.getInstanceQr("instance-id");
notifique.whatsapp.listInstances();
notifique.whatsapp.createInstance("Nome");

// SMS
notifique.sms.send(new SmsSendParams(List.of("5511999999999"), "SMS de teste"));
notifique.sms.get("sms-id");
notifique.sms.cancel("sms-id");

// Email
notifique.email.send(params);
notifique.email.get("email-id");
notifique.email.cancel("email-id");
notifique.email.domains().list();
notifique.email.domains().create("seudominio.com");
notifique.email.domains().verify("domain-id");

// Push — canonical contract: to + type + payload → messageIds
PushSendParams pushParams = new PushSendParams();
pushParams.setTo(List.of("device-id"));
pushParams.setType("push");
pushParams.setPayload(Map.of("title", "Título", "body", "Corpo"));
notifique.push.messages.send(pushParams); // response data.messageIds, NOT pushIds
notifique.push.apps.list();
notifique.push.devices.register(deviceParams);

// Templates
notifique.messages.send(messagesParams);
```

## Compatibility

- Java 11+.
- Jackson Databind.
