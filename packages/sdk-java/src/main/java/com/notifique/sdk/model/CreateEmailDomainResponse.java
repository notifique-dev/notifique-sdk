package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class CreateEmailDomainResponse {
    private boolean success;
    private EmailDomainItem data;
    private String message;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public EmailDomainItem getData() { return data; }
    public void setData(EmailDomainItem data) { this.data = data; }
    public String getMessage() { return message; }
    public void setMessage(String message) { this.message = message; }
}
