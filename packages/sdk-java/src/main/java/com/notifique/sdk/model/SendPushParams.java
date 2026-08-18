package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;
import java.util.List;
import java.util.Map;

/** Body para POST /v1/push/messages — OpenAPI NtfPush_SendPushRequest (to + type + payload). */
@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_NULL)
public class SendPushParams {
    private List<String> to;
    private String type;
    private Map<String, Object> payload;
    private Schedule schedule;
    private Options options;
    private Map<String, Object> metadata;

    public List<String> getTo() { return to; }
    public void setTo(List<String> to) { this.to = to; }
    public String getType() { return type; }
    public void setType(String type) { this.type = type; }
    public Map<String, Object> getPayload() { return payload; }
    public void setPayload(Map<String, Object> payload) { this.payload = payload; }
    public Schedule getSchedule() { return schedule; }
    public void setSchedule(Schedule schedule) { this.schedule = schedule; }
    public Options getOptions() { return options; }
    public void setOptions(Options options) { this.options = options; }
    public Map<String, Object> getMetadata() { return metadata; }
    public void setMetadata(Map<String, Object> metadata) { this.metadata = metadata; }

    @JsonInclude(JsonInclude.Include.NON_NULL)
    public static class Schedule {
        private String sendAt;
        @com.fasterxml.jackson.annotation.JsonProperty("sendAt")
        public String getSendAt() { return sendAt; }
        @com.fasterxml.jackson.annotation.JsonProperty("sendAt")
        public void setSendAt(String sendAt) { this.sendAt = sendAt; }
    }

    @JsonInclude(JsonInclude.Include.NON_NULL)
    public static class Options {
        private String priority;
        private Map<String, Object> notification;
        private Map<String, Object> webhook;
        public String getPriority() { return priority; }
        public void setPriority(String priority) { this.priority = priority; }
        public Map<String, Object> getNotification() { return notification; }
        public void setNotification(Map<String, Object> notification) { this.notification = notification; }
        public Map<String, Object> getWebhook() { return webhook; }
        public void setWebhook(Map<String, Object> webhook) { this.webhook = webhook; }
    }
}
