package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class CreateEmailDomainRequest {
    private String domain;

    public CreateEmailDomainRequest() {}
    public CreateEmailDomainRequest(String domain) { this.domain = domain; }
    public String getDomain() { return domain; }
    public void setDomain(String domain) { this.domain = domain; }
}
