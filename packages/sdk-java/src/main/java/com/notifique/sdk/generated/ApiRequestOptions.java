package com.notifique.sdk.generated;

import java.util.Collections;
import java.util.Map;

/**
 * Optional query, body and idempotency key for generated OpenAPI operations.
 */
public class ApiRequestOptions {
    private final Map<String, String> query;
    private final Object body;
    private final String idempotencyKey;

    public ApiRequestOptions(Map<String, String> query, Object body, String idempotencyKey) {
        this.query = query != null ? query : Collections.emptyMap();
        this.body = body;
        this.idempotencyKey = idempotencyKey;
    }

    public static ApiRequestOptions empty() {
        return new ApiRequestOptions(null, null, null);
    }

    public static Builder builder() {
        return new Builder();
    }

    public Map<String, String> getQuery() {
        return query;
    }

    public Object getBody() {
        return body;
    }

    public String getIdempotencyKey() {
        return idempotencyKey;
    }

    public static final class Builder {
        private Map<String, String> query;
        private Object body;
        private String idempotencyKey;

        public Builder query(Map<String, String> query) {
            this.query = query;
            return this;
        }

        public Builder body(Object body) {
            this.body = body;
            return this;
        }

        public Builder idempotencyKey(String idempotencyKey) {
            this.idempotencyKey = idempotencyKey;
            return this;
        }

        public ApiRequestOptions build() {
            return new ApiRequestOptions(query, body, idempotencyKey);
        }
    }
}
