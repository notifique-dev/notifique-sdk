package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/** Resposta 202 de POST /v1/whatsapp/messages — success e data. */
@JsonIgnoreProperties(ignoreUnknown = true)
public class WhatsAppSendEnvelope {
    private boolean success;
    private WhatsAppSendResponse data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public WhatsAppSendResponse getData() { return data; }
    public void setData(WhatsAppSendResponse data) { this.data = data; }
}
