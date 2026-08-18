package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;
import java.util.List;

/** Resposta POST /v1/push/messages — OpenAPI NtfPush_SendPushResponse */
@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_NULL)
public class SendPushResponse {
    private boolean success;
    private SendPushResponseData data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public SendPushResponseData getData() { return data; }
    public void setData(SendPushResponseData data) { this.data = data; }

    @JsonInclude(JsonInclude.Include.NON_NULL)
    public static class SendPushResponseData {
        private String status;
        private int count;
        private List<String> messageIds;
        private String scheduledAt;

        public String getStatus() { return status; }
        public void setStatus(String status) { this.status = status; }
        public int getCount() { return count; }
        public void setCount(int count) { this.count = count; }
        @com.fasterxml.jackson.annotation.JsonProperty("messageIds")
        public List<String> getMessageIds() { return messageIds; }
        @com.fasterxml.jackson.annotation.JsonProperty("messageIds")
        public void setMessageIds(List<String> messageIds) { this.messageIds = messageIds; }
        @com.fasterxml.jackson.annotation.JsonProperty("scheduledAt")
        public String getScheduledAt() { return scheduledAt; }
        @com.fasterxml.jackson.annotation.JsonProperty("scheduledAt")
        public void setScheduledAt(String scheduledAt) { this.scheduledAt = scheduledAt; }
    }
}
