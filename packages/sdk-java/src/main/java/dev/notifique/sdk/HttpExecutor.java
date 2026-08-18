package dev.notifique.sdk;

import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

/**
 * Abstraction for HTTP execution — mockable in tests (JDK 17+ cannot inline-mock {@link java.net.http.HttpClient}).
 */
public interface HttpExecutor {
    HttpResponse<String> send(HttpRequest request) throws Exception;
}
