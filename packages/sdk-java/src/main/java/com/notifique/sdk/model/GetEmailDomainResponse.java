package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class GetEmailDomainResponse {
    private boolean success;
    private EmailDomainItem data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public EmailDomainItem getData() { return data; }
    public void setData(EmailDomainItem data) { this.data = data; }
}
