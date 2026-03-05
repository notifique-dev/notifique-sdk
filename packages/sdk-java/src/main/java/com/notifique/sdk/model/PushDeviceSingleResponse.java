package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class PushDeviceSingleResponse {
    private boolean success;
    private PushDeviceItem data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public PushDeviceItem getData() { return data; }
    public void setData(PushDeviceItem data) { this.data = data; }
}
