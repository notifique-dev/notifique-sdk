# Notifique Java SDK

SDK oficial Notifique para Java — WhatsApp, SMS, Email, Push e envio por template.

## Instalação

### Maven
```xml
<dependency>
    <groupId>com.notifique</groupId>
    <artifactId>notifique-sdk</artifactId>
    <version>0.1.0</version>
</dependency>
```

### Gradle
```gradle
implementation 'com.notifique:notifique-sdk:0.1.0'
```

## Uso

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

// Push
notifique.push.apps.list();
notifique.push.apps.create("Meu App");
notifique.push.devices.register(deviceParams);
notifique.push.messages.send(pushParams);

// Templates
notifique.messages.send(messagesParams);
```

## Compatibilidade

- Java 11+.
- Jackson Databind.
