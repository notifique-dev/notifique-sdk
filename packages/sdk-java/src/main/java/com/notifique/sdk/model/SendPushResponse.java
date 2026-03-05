package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.util.List;

@JsonIgnoreProperties(ignoreUnknown = true)
public class SendPushResponse {
    private boolean success;
    private SendPushResponseData data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public SendPushResponseData getData() { return data; }
    public void setData(SendPushResponseData data) { this.data = data; }

    @JsonIgnoreProperties(ignoreUnknown = true)
    public static class SendPushResponseData {
        private String status;
        private Integer count;
        private List<String> pushIds;
        private String scheduledAt;

        public String getStatus() { return status; }
        public void setStatus(String status) { this.status = status; }
        public Integer getCount() { return count; }
        public void setCount(Integer count) { this.count = count; }
        @com.fasterxml.jackson.annotation.JsonProperty("pushIds") public List<String> getPushIds() { return pushIds; }
        @com.fasterxml.jackson.annotation.JsonProperty("pushIds") public void setPushIds(List<String> v) { this.pushIds = v; }
        @com.fasterxml.jackson.annotation.JsonProperty("scheduled_at") public String getScheduledAt() { return scheduledAt; }
        @com.fasterxml.jackson.annotation.JsonProperty("scheduled_at") public void setScheduledAt(String v) { this.scheduledAt = v; }
    }
}
