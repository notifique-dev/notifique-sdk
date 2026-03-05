package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.util.List;

@JsonIgnoreProperties(ignoreUnknown = true)
public class ListEmailDomainsResponse {
    private boolean success;
    private List<EmailDomainItem> data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public List<EmailDomainItem> getData() { return data; }
    public void setData(List<EmailDomainItem> data) { this.data = data; }
}
