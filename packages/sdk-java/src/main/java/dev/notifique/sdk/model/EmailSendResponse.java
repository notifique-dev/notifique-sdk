package dev.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.util.List;

@JsonIgnoreProperties(ignoreUnknown = true)
public class EmailSendResponse {
    private boolean success;
    private Data data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public Data getData() { return data; }
    public void setData(Data data) { this.data = data; }

    @JsonIgnoreProperties(ignoreUnknown = true)
    public static class Data {
        private List<String> messageIds;
        private String status;
        private int count;
        private String scheduledAt;

        @com.fasterxml.jackson.annotation.JsonProperty("messageIds")
        public List<String> getMessageIds() { return messageIds; }
        @com.fasterxml.jackson.annotation.JsonProperty("messageIds")
        public void setMessageIds(List<String> messageIds) { this.messageIds = messageIds; }
        public String getStatus() { return status; }
        public void setStatus(String status) { this.status = status; }
        public int getCount() { return count; }
        public void setCount(int count) { this.count = count; }

        @com.fasterxml.jackson.annotation.JsonProperty("scheduled_at")
        public String getScheduledAt() { return scheduledAt; }
        @com.fasterxml.jackson.annotation.JsonProperty("scheduled_at")
        public void setScheduledAt(String scheduledAt) { this.scheduledAt = scheduledAt; }
    }
}
