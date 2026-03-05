package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;
import java.util.List;
import java.util.Map;

/** Body para POST /v1/push/messages — alinhado ao OpenAPI SendPushRequest */
@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_NULL)
public class SendPushParams {
    private List<String> to;
    private String title;
    private String body;
    private String url;
    private String icon;
    private String image;
    private Map<String, Object> data;
    private Schedule schedule;
    private Options options;

    public List<String> getTo() { return to; }
    public void setTo(List<String> to) { this.to = to; }
    public String getTitle() { return title; }
    public void setTitle(String title) { this.title = title; }
    public String getBody() { return body; }
    public void setBody(String body) { this.body = body; }
    public String getUrl() { return url; }
    public void setUrl(String url) { this.url = url; }
    public String getIcon() { return icon; }
    public void setIcon(String icon) { this.icon = icon; }
    public String getImage() { return image; }
    public void setImage(String image) { this.image = image; }
    public Map<String, Object> getData() { return data; }
    public void setData(Map<String, Object> data) { this.data = data; }
    public Schedule getSchedule() { return schedule; }
    public void setSchedule(Schedule schedule) { this.schedule = schedule; }
    public Options getOptions() { return options; }
    public void setOptions(Options options) { this.options = options; }

    /** OpenAPI: schedule.sendAt (ISO 8601) */
    @JsonInclude(JsonInclude.Include.NON_NULL)
    public static class Schedule {
        private String sendAt;
        @com.fasterxml.jackson.annotation.JsonProperty("sendAt")
        public String getSendAt() { return sendAt; }
        @com.fasterxml.jackson.annotation.JsonProperty("sendAt")
        public void setSendAt(String sendAt) { this.sendAt = sendAt; }
    }

    /** OpenAPI: options.priority (high, normal, low) */
    @JsonInclude(JsonInclude.Include.NON_NULL)
    public static class Options {
        private String priority;
        public String getPriority() { return priority; }
        public void setPriority(String priority) { this.priority = priority; }
    }
}
