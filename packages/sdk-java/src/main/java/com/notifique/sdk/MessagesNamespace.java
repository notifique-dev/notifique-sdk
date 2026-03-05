package com.notifique.sdk;

import com.notifique.sdk.model.MessagesSendParams;
import com.notifique.sdk.model.MessagesSendResponse;

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
