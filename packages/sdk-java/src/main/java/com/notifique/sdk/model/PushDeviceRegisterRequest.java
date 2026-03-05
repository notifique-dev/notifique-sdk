package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.util.Map;

@JsonIgnoreProperties(ignoreUnknown = true)
public class PushDeviceRegisterRequest {
    private String appId;
    private String platform; // web, android, ios
    private Map<String, Object> subscription;
    private String token;
    private String externalUserId;

    @com.fasterxml.jackson.annotation.JsonProperty("app_id") public String getAppId() { return appId; }
    @com.fasterxml.jackson.annotation.JsonProperty("app_id") public void setAppId(String v) { this.appId = v; }
    public String getPlatform() { return platform; }
    public void setPlatform(String platform) { this.platform = platform; }
    public Map<String, Object> getSubscription() { return subscription; }
    public void setSubscription(Map<String, Object> subscription) { this.subscription = subscription; }
    public String getToken() { return token; }
    public void setToken(String token) { this.token = token; }
    @com.fasterxml.jackson.annotation.JsonProperty("external_user_id") public String getExternalUserId() { return externalUserId; }
    @com.fasterxml.jackson.annotation.JsonProperty("external_user_id") public void setExternalUserId(String v) { this.externalUserId = v; }
}
