package dev.notifique.sdk.generated;

import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import dev.notifique.sdk.NotifiqueApiException;

import java.net.URI;
import java.net.URLEncoder;
import dev.notifique.sdk.HttpExecutor;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.nio.charset.StandardCharsets;
import java.time.Duration;
import java.util.Map;
import java.util.StringJoiner;

final class GeneratedApiTransport {
    private final String apiKey;
    private final String baseUrl;
    private final HttpExecutor httpExecutor;
    private final ObjectMapper objectMapper;

    GeneratedApiTransport(String apiKey, String baseUrl, HttpExecutor httpExecutor, ObjectMapper objectMapper) {
        this.apiKey = apiKey;
        this.baseUrl = baseUrl;
        this.httpExecutor = httpExecutor;
        this.objectMapper = objectMapper;
    }

    static String normalizeApiBaseUrl(String baseUrl) {
        String effective = (baseUrl == null || baseUrl.isBlank())
                ? "https://api.notifique.dev/v1"
                : baseUrl;
        String trimmed = effective.endsWith("/")
                ? effective.substring(0, effective.length() - 1)
                : effective;
        if (trimmed.endsWith("/v1")) {
            return trimmed.substring(0, trimmed.length() - 3);
        }
        return trimmed;
    }

    JsonNode request(
            String method,
            String urlTemplate,
            Map<String, String> pathParams,
            ApiRequestOptions options
    ) {
        ApiRequestOptions opts = options != null ? options : ApiRequestOptions.empty();
        String path = buildPath(urlTemplate, pathParams);
        String url = appendQuery(baseUrl + path, opts.getQuery());

        try {
            String jsonBody = opts.getBody() != null ? objectMapper.writeValueAsString(opts.getBody()) : "";

            HttpRequest.Builder builder = HttpRequest.newBuilder()
                    .uri(URI.create(url))
                    .header("Content-Type", "application/json")
                    .header("User-Agent", "Notifique-Java-SDK/0.2.0")
                    .timeout(Duration.ofSeconds(30));

            if (apiKey != null && !apiKey.isBlank()) {
                builder.header("Authorization", "Bearer " + apiKey);
            }

            if (opts.getIdempotencyKey() != null && !opts.getIdempotencyKey().isBlank()) {
                builder.header("Idempotency-Key", opts.getIdempotencyKey());
                builder.header("x-idempotency-key", opts.getIdempotencyKey());
            }

            if ("GET".equals(method) || "DELETE".equals(method)) {
                builder.method(method, HttpRequest.BodyPublishers.noBody());
            } else {
                builder.method(method, HttpRequest.BodyPublishers.ofString(jsonBody));
            }

            HttpResponse<String> response = httpExecutor.send(builder.build());
            if (response.statusCode() >= 400) {
                throw new NotifiqueApiException(response.statusCode(), response.body());
            }

            if (response.body() == null || response.body().isEmpty()) {
                return objectMapper.nullNode();
            }
            return objectMapper.readTree(response.body());
        } catch (NotifiqueApiException e) {
            throw e;
        } catch (Exception e) {
            throw new RuntimeException("Generated API request failed: " + e.getMessage(), e);
        }
    }

    String requestRaw(
            String method,
            String urlTemplate,
            Map<String, String> pathParams,
            ApiRequestOptions options
    ) {
        ApiRequestOptions opts = options != null ? options : ApiRequestOptions.empty();
        String path = buildPath(urlTemplate, pathParams);
        String url = appendQuery(baseUrl + path, opts.getQuery());

        try {
            String jsonBody = opts.getBody() != null ? objectMapper.writeValueAsString(opts.getBody()) : "";

            HttpRequest.Builder builder = HttpRequest.newBuilder()
                    .uri(URI.create(url))
                    .header("Content-Type", "application/json")
                    .header("User-Agent", "Notifique-Java-SDK/0.2.0")
                    .timeout(Duration.ofSeconds(30));

            if (apiKey != null && !apiKey.isBlank()) {
                builder.header("Authorization", "Bearer " + apiKey);
            }

            if (opts.getIdempotencyKey() != null && !opts.getIdempotencyKey().isBlank()) {
                builder.header("Idempotency-Key", opts.getIdempotencyKey());
                builder.header("x-idempotency-key", opts.getIdempotencyKey());
            }

            if ("GET".equals(method) || "DELETE".equals(method)) {
                builder.method(method, HttpRequest.BodyPublishers.noBody());
            } else {
                builder.method(method, HttpRequest.BodyPublishers.ofString(jsonBody));
            }

            HttpResponse<String> response = httpExecutor.send(builder.build());
            if (response.statusCode() >= 400) {
                throw new NotifiqueApiException(response.statusCode(), response.body());
            }
            return response.body() != null ? response.body() : "";
        } catch (NotifiqueApiException e) {
            throw e;
        } catch (Exception e) {
            throw new RuntimeException("Generated API request failed: " + e.getMessage(), e);
        }
    }

    private static String buildPath(String template, Map<String, String> pathParams) {
        String path = template;
        if (pathParams != null) {
            for (Map.Entry<String, String> entry : pathParams.entrySet()) {
                String encoded = URLEncoder.encode(String.valueOf(entry.getValue()), StandardCharsets.UTF_8)
                        .replace("+", "%20");
                path = path.replace("{" + entry.getKey() + "}", encoded);
            }
        }
        return path;
    }

    private static String appendQuery(String url, Map<String, String> query) {
        if (query == null || query.isEmpty()) {
            return url;
        }
        StringJoiner joiner = new StringJoiner("&");
        for (Map.Entry<String, String> entry : query.entrySet()) {
            joiner.add(URLEncoder.encode(entry.getKey(), StandardCharsets.UTF_8)
                    + "="
                    + URLEncoder.encode(String.valueOf(entry.getValue()), StandardCharsets.UTF_8));
        }
        return url + "?" + joiner;
    }
}
