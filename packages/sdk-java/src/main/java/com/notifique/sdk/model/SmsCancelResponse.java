package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class SmsCancelResponse {
    private boolean success;
    private Data data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public Data getData() { return data; }
    public void setData(Data data) { this.data = data; }

    @JsonIgnoreProperties(ignoreUnknown = true)
    public static class Data {
        private String smsId;
        private String status;

        @com.fasterxml.jackson.annotation.JsonProperty("smsId")
        public String getSmsId() { return smsId; }
        @com.fasterxml.jackson.annotation.JsonProperty("smsId")
        public void setSmsId(String smsId) { this.smsId = smsId; }
        public String getStatus() { return status; }
        public void setStatus(String status) { this.status = status; }
    }
}
