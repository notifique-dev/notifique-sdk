package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class PushDeviceItem {
    private String id;
    private String appId;
    private String platform;
    private String externalUserId;
    private String createdAt;

    public String getId() { return id; }
    public void setId(String id) { this.id = id; }
    @com.fasterxml.jackson.annotation.JsonProperty("app_id") public String getAppId() { return appId; }
    @com.fasterxml.jackson.annotation.JsonProperty("app_id") public void setAppId(String v) { this.appId = v; }
    public String getPlatform() { return platform; }
    public void setPlatform(String platform) { this.platform = platform; }
    @com.fasterxml.jackson.annotation.JsonProperty("external_user_id") public String getExternalUserId() { return externalUserId; }
    @com.fasterxml.jackson.annotation.JsonProperty("external_user_id") public void setExternalUserId(String v) { this.externalUserId = v; }
    @com.fasterxml.jackson.annotation.JsonProperty("created_at") public String getCreatedAt() { return createdAt; }
    @com.fasterxml.jackson.annotation.JsonProperty("created_at") public void setCreatedAt(String v) { this.createdAt = v; }
}
