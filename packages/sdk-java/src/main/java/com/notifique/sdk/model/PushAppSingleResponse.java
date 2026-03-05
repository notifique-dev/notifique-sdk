package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class PushAppSingleResponse {
    private boolean success;
    private PushAppItem data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public PushAppItem getData() { return data; }
    public void setData(PushAppItem data) { this.data = data; }
}
