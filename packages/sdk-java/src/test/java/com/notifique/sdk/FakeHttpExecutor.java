package com.notifique.sdk;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpHeaders;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;
import java.util.Optional;

/**
 * Test double for {@link HttpExecutor} — avoids Mockito on JDK 21+ final/sealed HTTP types.
 */
public final class FakeHttpExecutor implements HttpExecutor {
    private int statusCode = 200;
    private String body = "{}";
    public HttpRequest lastRequest;

    public void setResponse(int statusCode, String body) {
        this.statusCode = statusCode;
        this.body = body;
    }

    @Override
    public HttpResponse<String> send(HttpRequest request) throws Exception {
        this.lastRequest = request;
        return new SimpleHttpResponse(statusCode, body, request);
    }

    private static final class SimpleHttpResponse implements HttpResponse<String> {
        private final int status;
        private final String body;
        private final HttpRequest request;

        SimpleHttpResponse(int status, String body, HttpRequest request) {
            this.status = status;
            this.body = body;
            this.request = request;
        }

        @Override
        public int statusCode() {
            return status;
        }

        @Override
        public HttpRequest request() {
            return request;
        }

        @Override
        public Optional<HttpResponse<String>> previousResponse() {
            return Optional.empty();
        }

        @Override
        public HttpHeaders headers() {
            return HttpHeaders.of(Map.of(), (a, b) -> true);
        }

        @Override
        public String body() {
            return body;
        }

        @Override
        public Optional<javax.net.ssl.SSLSession> sslSession() {
            return Optional.empty();
        }

        @Override
        public URI uri() {
            return request.uri();
        }

        @Override
        public HttpClient.Version version() {
            return HttpClient.Version.HTTP_1_1;
        }
    }
}
