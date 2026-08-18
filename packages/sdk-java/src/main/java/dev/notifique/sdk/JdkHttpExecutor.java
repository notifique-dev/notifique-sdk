package dev.notifique.sdk;

import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public final class JdkHttpExecutor implements HttpExecutor {
    private final HttpClient client;

    public JdkHttpExecutor(HttpClient client) {
        this.client = client;
    }

    @Override
    public HttpResponse<String> send(HttpRequest request) throws Exception {
        return client.send(request, HttpResponse.BodyHandlers.ofString());
    }
}
