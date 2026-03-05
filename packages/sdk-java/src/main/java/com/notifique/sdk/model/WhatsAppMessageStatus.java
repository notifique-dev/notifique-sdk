package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class WhatsAppMessageStatus {
    private String messageId;
    private String to;
    private String type;
    private String status;
    private String scheduledAt;
    private String sentAt;
    private String deliveredAt;
    private String readAt;
    private String failedAt;
    private String errorMessage;
    private String createdAt;

    @com.fasterxml.jackson.annotation.JsonProperty("messageId")
    public String getMessageId() { return messageId; }
    @com.fasterxml.jackson.annotation.JsonProperty("messageId")
    public void setMessageId(String messageId) { this.messageId = messageId; }

    public String getTo() { return to; }
    public void setTo(String to) { this.to = to; }
    public String getType() { return type; }
    public void setType(String type) { this.type = type; }
    public String getStatus() { return status; }
    public void setStatus(String status) { this.status = status; }

    @com.fasterxml.jackson.annotation.JsonProperty("scheduledAt")
    public String getScheduledAt() { return scheduledAt; }
    @com.fasterxml.jackson.annotation.JsonProperty("scheduledAt")
    public void setScheduledAt(String scheduledAt) { this.scheduledAt = scheduledAt; }

    @com.fasterxml.jackson.annotation.JsonProperty("sentAt")
    public String getSentAt() { return sentAt; }
    @com.fasterxml.jackson.annotation.JsonProperty("sentAt")
    public void setSentAt(String sentAt) { this.sentAt = sentAt; }

    @com.fasterxml.jackson.annotation.JsonProperty("deliveredAt")
    public String getDeliveredAt() { return deliveredAt; }
    @com.fasterxml.jackson.annotation.JsonProperty("deliveredAt")
    public void setDeliveredAt(String deliveredAt) { this.deliveredAt = deliveredAt; }

    @com.fasterxml.jackson.annotation.JsonProperty("readAt")
    public String getReadAt() { return readAt; }
    @com.fasterxml.jackson.annotation.JsonProperty("readAt")
    public void setReadAt(String readAt) { this.readAt = readAt; }

    @com.fasterxml.jackson.annotation.JsonProperty("failedAt")
    public String getFailedAt() { return failedAt; }
    @com.fasterxml.jackson.annotation.JsonProperty("failedAt")
    public void setFailedAt(String failedAt) { this.failedAt = failedAt; }

    @com.fasterxml.jackson.annotation.JsonProperty("errorMessage")
    public String getErrorMessage() { return errorMessage; }
    @com.fasterxml.jackson.annotation.JsonProperty("errorMessage")
    public void setErrorMessage(String errorMessage) { this.errorMessage = errorMessage; }

    @com.fasterxml.jackson.annotation.JsonProperty("createdAt")
    public String getCreatedAt() { return createdAt; }
    @com.fasterxml.jackson.annotation.JsonProperty("createdAt")
    public void setCreatedAt(String createdAt) { this.createdAt = createdAt; }
}
