package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.util.List;
import java.util.Map;

@JsonIgnoreProperties(ignoreUnknown = true)
public class PushAppListResponse {
    private boolean success;
    private List<PushAppItem> data;
    private Map<String, Integer> pagination;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public List<PushAppItem> getData() { return data; }
    public void setData(List<PushAppItem> data) { this.data = data; }
    public Map<String, Integer> getPagination() { return pagination; }
    public void setPagination(Map<String, Integer> pagination) { this.pagination = pagination; }
}
