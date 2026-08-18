package dev.notifique.sdk;

import dev.notifique.sdk.model.MessagesSendParams;
import dev.notifique.sdk.model.MessagesSendResponse;

/**
 * POST /v1/templates/send — envio por template (whatsapp, sms, email).
 */
public class MessagesNamespace {
    private final Notifique client;

    public MessagesNamespace(Notifique client) {
        this.client = client;
    }

    public MessagesSendResponse send(MessagesSendParams params) {
        return client.request("POST", "/templates/send", params, MessagesSendResponse.class);
    }
}
