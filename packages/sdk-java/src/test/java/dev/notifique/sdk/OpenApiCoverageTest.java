package dev.notifique.sdk;

import com.fasterxml.jackson.databind.ObjectMapper;
import dev.notifique.sdk.generated.GeneratedApi;
import org.junit.jupiter.api.Test;

import dev.notifique.sdk.HttpExecutor;
import dev.notifique.sdk.JdkHttpExecutor;
import java.net.http.HttpClient;
import java.util.List;
import java.util.stream.Collectors;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

class OpenApiCoverageTest {
    @Test
    void registryHas353Operations() throws Exception {
        ObjectMapper mapper = new ObjectMapper();
        try (var in = getClass().getResourceAsStream("/notifique/operations.json")) {
            var root = mapper.readTree(in);
            assertEquals(353, root.get("count").asInt());
            assertEquals(353, root.get("operations").size());
        }
    }

    @Test
    void generatedClientExposesEveryRegistryOperation() throws Exception {
        ObjectMapper mapper = new ObjectMapper();
        List<String> expected;
        try (var in = getClass().getResourceAsStream("/notifique/operations.json")) {
            var root = mapper.readTree(in);
            expected = java.util.stream.StreamSupport.stream(root.get("operations").spliterator(), false)
                    .map(op -> {
                        var namespaces = op.get("namespaces");
                        StringBuilder path = new StringBuilder();
                        for (int i = 0; i < namespaces.size(); i++) {
                            if (i > 0) {
                                path.append('.');
                            }
                            path.append(namespaces.get(i).asText());
                        }
                        path.append('.').append(op.get("methodName").asText());
                        return path.toString();
                    })
                    .sorted()
                    .collect(Collectors.toList());
        }

        GeneratedApi api = GeneratedApi.create(
                "test-key",
                "https://api.notifique.dev/v1",
                new JdkHttpExecutor(HttpClient.newBuilder().build()),
                mapper
        );

        assertEquals(353, api.getOperationCount());
        List<String> available = api.listOperationPaths();
        List<String> missing = expected.stream()
                .filter(op -> !available.contains(op))
                .collect(Collectors.toList());

        assertEquals(List.of(), missing, () -> "Missing operations: " + missing);
        assertEquals(353, available.size());
        assertTrue(available.contains("wellKnown.getJwks"));
        assertTrue(available.contains("oauth.apps.rotateWorkspaceAppSecret"));
    }
}
