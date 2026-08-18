package com.notifique.sdk.generated;

import com.fasterxml.jackson.databind.ObjectMapper;

import com.notifique.sdk.HttpExecutor;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/**
 * Full OpenAPI coverage (353 operations) built dynamically from operations.json.
 */
public class GeneratedApi {
    private final Map<String, ApiNamespace> namespaces = new LinkedHashMap<>();
    private final int operationCount;

    GeneratedApi(Map<String, ApiNamespace> namespaces, int operationCount) {
        this.namespaces.putAll(namespaces);
        this.operationCount = operationCount;
    }

    public static GeneratedApi create(String apiKey, String baseUrl, HttpExecutor httpExecutor, ObjectMapper objectMapper) {
        OperationsRegistry registry = OperationsRegistry.load(objectMapper);
        String apiBase = GeneratedApiTransport.normalizeApiBaseUrl(baseUrl);
        GeneratedApiTransport transport = new GeneratedApiTransport(apiKey, apiBase, httpExecutor, objectMapper);

        Map<String, ApiNamespace> roots = new LinkedHashMap<>();
        for (OperationRecord operation : registry.operations()) {
            ApiNamespace node = roots.computeIfAbsent(operation.namespaces.get(0), key -> new ApiNamespace(transport));
            ApiNamespace current = node;
            for (int i = 1; i < operation.namespaces.size(); i++) {
                String childName = operation.namespaces.get(i);
                ApiNamespace existing = current.getChildren().get(childName);
                if (existing == null) {
                    ApiNamespace child = new ApiNamespace(transport);
                    current.addChild(childName, child);
                    current = child;
                } else {
                    current = existing;
                }
            }
            current.addOperation(operation);
        }

        return new GeneratedApi(roots, registry.count());
    }

    /**
     * Top-level namespace access (e.g. {@code api.namespace("wellKnown")}).
     */
    public ApiNamespace namespace(String name) {
        ApiNamespace ns = namespaces.get(name);
        if (ns == null) {
            throw new IllegalArgumentException("Unknown API namespace: " + name);
        }
        return ns;
    }

    public Map<String, ApiNamespace> getNamespaces() {
        return Map.copyOf(namespaces);
    }

    public int getOperationCount() {
        return operationCount;
    }

    /**
     * All dotted operation paths exposed by this client (for coverage tests).
     */
    public List<String> listOperationPaths() {
        List<String> out = new java.util.ArrayList<>();
        for (Map.Entry<String, ApiNamespace> entry : namespaces.entrySet()) {
            for (String path : entry.getValue().collectOperationPaths()) {
                out.add(entry.getKey() + "." + path);
            }
        }
        java.util.Collections.sort(out);
        return out;
    }
}
