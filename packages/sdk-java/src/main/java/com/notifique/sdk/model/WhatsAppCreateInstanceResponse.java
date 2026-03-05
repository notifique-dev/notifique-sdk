package com.notifique.sdk.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;
import java.util.Map;

@JsonIgnoreProperties(ignoreUnknown = true)
public class WhatsAppCreateInstanceResponse {
    private boolean success;
    private Data data;

    public boolean isSuccess() { return success; }
    public void setSuccess(boolean success) { this.success = success; }
    public Data getData() { return data; }
    public void setData(Data data) { this.data = data; }

    @JsonIgnoreProperties(ignoreUnknown = true)
    public static class Data {
        private WhatsAppInstance instance;
        @JsonProperty("connection")
        private Map<String, Object> connection;
        public WhatsAppInstance getInstance() { return instance; }
        public void setInstance(WhatsAppInstance instance) { this.instance = instance; }
        public Map<String, Object> getConnection() { return connection; }
        public void setConnection(Map<String, Object> connection) { this.connection = connection; }
    }
}
