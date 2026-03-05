package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.util.Map;

@JsonIgnoreProperties(ignoreUnknown = true)
public class WhatsAppInstanceQrResponse {
    private boolean success;
    private Map<String, Object> data; // status, base64

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public Map<String, Object> getData() { return data; }
    public void setData(Map<String, Object> data) { this.data = data; }
}
