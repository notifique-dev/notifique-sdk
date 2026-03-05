package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class SmsStatusResponse {
    private boolean success;
    private SmsStatus data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public SmsStatus getData() { return data; }
    public void setData(SmsStatus data) { this.data = data; }

    @JsonIgnoreProperties(ignoreUnknown = true)
    public static class SmsStatus {
        private String smsId;
        private String to;
        private String message;
        private String status;
        private String sentAt;
        private String deliveredAt;
        private String failedAt;
        private String scheduledFor;
        private String errorMessage;
        private String createdAt;

        @com.fasterxml.jackson.annotation.JsonProperty("smsId")
        public String getSmsId() { return smsId; }
        @com.fasterxml.jackson.annotation.JsonProperty("smsId")
        public void setSmsId(String smsId) { this.smsId = smsId; }
        public String getTo() { return to; }
        public void setTo(String to) { this.to = to; }
        public String getMessage() { return message; }
        public void setMessage(String message) { this.message = message; }
        public String getStatus() { return status; }
        public void setStatus(String status) { this.status = status; }

        @com.fasterxml.jackson.annotation.JsonProperty("sentAt")
        public String getSentAt() { return sentAt; }
        @com.fasterxml.jackson.annotation.JsonProperty("sentAt")
        public void setSentAt(String sentAt) { this.sentAt = sentAt; }

        @com.fasterxml.jackson.annotation.JsonProperty("deliveredAt")
        public String getDeliveredAt() { return deliveredAt; }
        @com.fasterxml.jackson.annotation.JsonProperty("deliveredAt")
        public void setDeliveredAt(String deliveredAt) { this.deliveredAt = deliveredAt; }

        @com.fasterxml.jackson.annotation.JsonProperty("failedAt")
        public String getFailedAt() { return failedAt; }
        @com.fasterxml.jackson.annotation.JsonProperty("failedAt")
        public void setFailedAt(String failedAt) { this.failedAt = failedAt; }

        @com.fasterxml.jackson.annotation.JsonProperty("scheduledFor")
        public String getScheduledFor() { return scheduledFor; }
        @com.fasterxml.jackson.annotation.JsonProperty("scheduledFor")
        public void setScheduledFor(String scheduledFor) { this.scheduledFor = scheduledFor; }

        @com.fasterxml.jackson.annotation.JsonProperty("errorMessage")
        public String getErrorMessage() { return errorMessage; }
        @com.fasterxml.jackson.annotation.JsonProperty("errorMessage")
        public void setErrorMessage(String errorMessage) { this.errorMessage = errorMessage; }

        @com.fasterxml.jackson.annotation.JsonProperty("createdAt")
        public String getCreatedAt() { return createdAt; }
        @com.fasterxml.jackson.annotation.JsonProperty("createdAt")
        public void setCreatedAt(String createdAt) { this.createdAt = createdAt; }
    }
}
