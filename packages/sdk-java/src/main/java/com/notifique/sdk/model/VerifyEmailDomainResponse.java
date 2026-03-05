package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class VerifyEmailDomainResponse {
    private boolean success;
    private EmailDomainItem data;
    private boolean verified;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public EmailDomainItem getData() { return data; }
    public void setData(EmailDomainItem data) { this.data = data; }
    public boolean isVerified() { return verified; }
    public void setVerified(boolean verified) { this.verified = verified; }
}
