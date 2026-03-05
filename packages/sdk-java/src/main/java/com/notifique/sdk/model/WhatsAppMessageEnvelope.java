package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/** Resposta envelope de GET /v1/whatsapp/messages/:id — success e data. */
@JsonIgnoreProperties(ignoreUnknown = true)
public class WhatsAppMessageEnvelope {
    private boolean success;
    private WhatsAppMessageStatus data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public WhatsAppMessageStatus getData() { return data; }
    public void setData(WhatsAppMessageStatus data) { this.data = data; }
}
