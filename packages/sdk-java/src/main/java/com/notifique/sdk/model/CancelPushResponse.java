package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/** Resposta de POST /v1/push/messages/{id}/cancel — OpenAPI CancelPushResponse */
@JsonIgnoreProperties(ignoreUnknown = true)
public class CancelPushResponse {
    private boolean success;
    private Data data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public Data getData() { return data; }
    public void setData(Data data) { this.data = data; }

    @JsonIgnoreProperties(ignoreUnknown = true)
    public static class Data {
        private String pushId;
        private String status;

        @com.fasterxml.jackson.annotation.JsonProperty("pushId")
        public String getPushId() { return pushId; }
        @com.fasterxml.jackson.annotation.JsonProperty("pushId")
        public void setPushId(String pushId) { this.pushId = pushId; }
        public String getStatus() { return status; }
        public void setStatus(String status) { this.status = status; }
    }
}
