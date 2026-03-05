package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.util.List;
import java.util.Map;

@JsonIgnoreProperties(ignoreUnknown = true)
public class EmailDomainItem {
    private String id;
    private String domain;
    private String status;
    private List<Map<String, String>> dnsRecords;
    private String verifiedAt;
    private String createdAt;
    private String updatedAt;

    public String getId() { return id; }
    public void setId(String id) { this.id = id; }
    public String getDomain() { return domain; }
    public void setDomain(String domain) { this.domain = domain; }
    public String getStatus() { return status; }
    public void setStatus(String status) { this.status = status; }
    public List<Map<String, String>> getDnsRecords() { return dnsRecords; }
    public void setDnsRecords(List<Map<String, String>> dnsRecords) { this.dnsRecords = dnsRecords; }
    public String getVerifiedAt() { return verifiedAt; }
    public void setVerifiedAt(String verifiedAt) { this.verifiedAt = verifiedAt; }
    public String getCreatedAt() { return createdAt; }
    public void setCreatedAt(String createdAt) { this.createdAt = createdAt; }
    public String getUpdatedAt() { return updatedAt; }
    public void setUpdatedAt(String updatedAt) { this.updatedAt = updatedAt; }
}
