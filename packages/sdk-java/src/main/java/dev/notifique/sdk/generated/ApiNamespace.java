package dev.notifique.sdk.generated;

import com.fasterxml.jackson.databind.JsonNode;

import java.util.ArrayList;
import java.util.Collections;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/**
 * Nested namespace node for the generated OpenAPI client.
 */
public class ApiNamespace {
    private final Map<String, ApiNamespace> children = new LinkedHashMap<>();
    private final Map<String, OperationRecord> operations = new LinkedHashMap<>();
    private final GeneratedApiTransport transport;

    ApiNamespace(GeneratedApiTransport transport) {
        this.transport = transport;
    }

    void addChild(String name, ApiNamespace child) {
        children.put(name, child);
    }

    void addOperation(OperationRecord operation) {
        operations.put(operation.methodName, operation);
    }

    /**
     * Navigate to a child namespace (e.g. {@code api.namespace("oauth").namespace("apps")}).
     */
    public ApiNamespace namespace(String name) {
        ApiNamespace child = children.get(name);
        if (child == null) {
            throw new IllegalArgumentException("Unknown API namespace: " + name);
        }
        return child;
    }

    /**
     * Invoke an operation in this namespace.
     */
    public JsonNode invoke(String methodName, Map<String, String> pathParams, ApiRequestOptions options) {
        OperationRecord operation = operations.get(methodName);
        if (operation == null) {
            throw new IllegalArgumentException("Unknown API operation: " + methodName);
        }
        return transport.request(
                operation.httpMethod,
                operation.urlTemplate,
                pathParams,
                options
        );
    }

    public JsonNode invoke(String methodName, ApiRequestOptions options) {
        return invoke(methodName, Collections.emptyMap(), options);
    }

    Map<String, ApiNamespace> getChildren() {
        return Collections.unmodifiableMap(children);
    }

    Map<String, OperationRecord> getOperations() {
        return Collections.unmodifiableMap(operations);
    }

    void collectOperationPaths(String prefix, List<String> out) {
        for (Map.Entry<String, OperationRecord> entry : operations.entrySet()) {
            out.add(prefix.isEmpty() ? entry.getKey() : prefix + "." + entry.getKey());
        }
        for (Map.Entry<String, ApiNamespace> entry : children.entrySet()) {
            String childPrefix = prefix.isEmpty() ? entry.getKey() : prefix + "." + entry.getKey();
            entry.getValue().collectOperationPaths(childPrefix, out);
        }
    }

    List<String> collectOperationPaths() {
        List<String> out = new ArrayList<>();
        collectOperationPaths("", out);
        return out;
    }
}
