package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.util.List;
import java.util.Map;

@JsonIgnoreProperties(ignoreUnknown = true)
public class PushAppItem {
    private String id;
    private String name;
    private String workspaceId;
    private String vapidPublicKey;
    private Boolean hasVapidPrivate;
    private Boolean hasFcm;
    private Boolean hasApns;
    private List<String> allowedOrigins;
    private Map<String, Object> promptConfig;
    private String createdAt;
    private String updatedAt;

    public String getId() { return id; }
    public void setId(String id) { this.id = id; }
    public String getName() { return name; }
    public void setName(String name) { this.name = name; }
    @com.fasterxml.jackson.annotation.JsonProperty("workspaceId") public String getWorkspaceId() { return workspaceId; }
    @com.fasterxml.jackson.annotation.JsonProperty("workspaceId") public void setWorkspaceId(String v) { this.workspaceId = v; }
    @com.fasterxml.jackson.annotation.JsonProperty("vapidPublicKey") public String getVapidPublicKey() { return vapidPublicKey; }
    @com.fasterxml.jackson.annotation.JsonProperty("vapidPublicKey") public void setVapidPublicKey(String v) { this.vapidPublicKey = v; }
    @com.fasterxml.jackson.annotation.JsonProperty("hasVapidPrivate") public Boolean getHasVapidPrivate() { return hasVapidPrivate; }
    @com.fasterxml.jackson.annotation.JsonProperty("hasVapidPrivate") public void setHasVapidPrivate(Boolean v) { this.hasVapidPrivate = v; }
    @com.fasterxml.jackson.annotation.JsonProperty("hasFcm") public Boolean getHasFcm() { return hasFcm; }
    @com.fasterxml.jackson.annotation.JsonProperty("hasFcm") public void setHasFcm(Boolean v) { this.hasFcm = v; }
    @com.fasterxml.jackson.annotation.JsonProperty("hasApns") public Boolean getHasApns() { return hasApns; }
    @com.fasterxml.jackson.annotation.JsonProperty("hasApns") public void setHasApns(Boolean v) { this.hasApns = v; }
    @com.fasterxml.jackson.annotation.JsonProperty("allowedOrigins") public List<String> getAllowedOrigins() { return allowedOrigins; }
    @com.fasterxml.jackson.annotation.JsonProperty("allowedOrigins") public void setAllowedOrigins(List<String> v) { this.allowedOrigins = v; }
    @com.fasterxml.jackson.annotation.JsonProperty("promptConfig") public Map<String, Object> getPromptConfig() { return promptConfig; }
    @com.fasterxml.jackson.annotation.JsonProperty("promptConfig") public void setPromptConfig(Map<String, Object> v) { this.promptConfig = v; }
    @com.fasterxml.jackson.annotation.JsonProperty("createdAt") public String getCreatedAt() { return createdAt; }
    @com.fasterxml.jackson.annotation.JsonProperty("createdAt") public void setCreatedAt(String v) { this.createdAt = v; }
    @com.fasterxml.jackson.annotation.JsonProperty("updatedAt") public String getUpdatedAt() { return updatedAt; }
    @com.fasterxml.jackson.annotation.JsonProperty("updatedAt") public void setUpdatedAt(String v) { this.updatedAt = v; }
}
