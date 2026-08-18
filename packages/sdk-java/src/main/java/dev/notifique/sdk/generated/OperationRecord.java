package dev.notifique.sdk.generated;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import java.util.List;

@JsonIgnoreProperties(ignoreUnknown = true)
class OperationRecord {
    public String spec;
    public String operationId;
    public String httpMethod;
    public String path;
    public String urlTemplate;
    public List<String> namespaces;
    public String methodName;
    public List<String> pathParams;
    public boolean requiresAuth;
    public boolean idempotent;
    public String summary;
}

@JsonIgnoreProperties(ignoreUnknown = true)
class OperationsFile {
    public int count;
    public List<OperationRecord> operations;
}
