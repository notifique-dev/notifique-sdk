using System.Text;
using System.Text.Json;

namespace Notifique.Generated;

internal sealed class GeneratedApiTransport
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true
    };

    private readonly string? _apiKey;
    private readonly string _baseUrl;
    private readonly HttpClient _httpClient;

    public GeneratedApiTransport(string? apiKey, string baseUrl, HttpClient httpClient)
    {
        _apiKey = apiKey;
        _baseUrl = baseUrl;
        _httpClient = httpClient;
    }

    public static string NormalizeApiBaseUrl(string baseUrl)
    {
        var effective = string.IsNullOrWhiteSpace(baseUrl)
            ? "https://api.notifique.dev/v1"
            : baseUrl.TrimEnd('/');
        return effective.EndsWith("/v1", StringComparison.Ordinal)
            ? effective[..^3]
            : effective;
    }

    public async Task<JsonElement> RequestAsync(
        string method,
        string urlTemplate,
        IReadOnlyDictionary<string, string>? pathParams,
        ApiRequestOptions? options,
        CancellationToken cancellationToken = default)
    {
        options ??= ApiRequestOptions.Empty;
        var path = BuildPath(urlTemplate, pathParams);
        var url = AppendQuery(_baseUrl + path, options.Query);

        using var request = new HttpRequestMessage(new HttpMethod(method), url);
        request.Headers.TryAddWithoutValidation("User-Agent", "Notifique-DotNet-SDK/0.2.0");

        if (!string.IsNullOrWhiteSpace(_apiKey))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
        }

        if (!string.IsNullOrWhiteSpace(options.IdempotencyKey))
        {
            request.Headers.TryAddWithoutValidation("Idempotency-Key", options.IdempotencyKey);
            request.Headers.TryAddWithoutValidation("x-idempotency-key", options.IdempotencyKey);
        }

        if (options.Body is not null && method is not "GET" and not "DELETE")
        {
            var json = JsonSerializer.Serialize(options.Body, JsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if ((int)response.StatusCode >= 400)
        {
            throw new NotifiqueApiException((int)response.StatusCode, responseBody);
        }

        if (string.IsNullOrWhiteSpace(responseBody))
        {
            using var empty = JsonDocument.Parse("null");
            return empty.RootElement.Clone();
        }

        using var document = JsonDocument.Parse(responseBody);
        return document.RootElement.Clone();
    }

    public async Task<string> RequestRawAsync(
        string method,
        string urlTemplate,
        IReadOnlyDictionary<string, string>? pathParams,
        ApiRequestOptions? options,
        CancellationToken cancellationToken = default)
    {
        options ??= ApiRequestOptions.Empty;
        var path = BuildPath(urlTemplate, pathParams);
        var url = AppendQuery(_baseUrl + path, options.Query);

        using var request = new HttpRequestMessage(new HttpMethod(method), url);
        request.Headers.TryAddWithoutValidation("User-Agent", "Notifique-DotNet-SDK/0.2.0");

        if (!string.IsNullOrWhiteSpace(_apiKey))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
        }

        if (!string.IsNullOrWhiteSpace(options.IdempotencyKey))
        {
            request.Headers.TryAddWithoutValidation("Idempotency-Key", options.IdempotencyKey);
            request.Headers.TryAddWithoutValidation("x-idempotency-key", options.IdempotencyKey);
        }

        if (options.Body is not null && method is not "GET" and not "DELETE")
        {
            var json = JsonSerializer.Serialize(options.Body, JsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if ((int)response.StatusCode >= 400)
        {
            throw new NotifiqueApiException((int)response.StatusCode, responseBody);
        }

        return responseBody;
    }

    public async Task<byte[]> RequestBytesAsync(
        string method,
        string urlTemplate,
        IReadOnlyDictionary<string, string>? pathParams,
        ApiRequestOptions? options,
        CancellationToken cancellationToken = default)
    {
        options ??= ApiRequestOptions.Empty;
        var path = BuildPath(urlTemplate, pathParams);
        var url = AppendQuery(_baseUrl + path, options.Query);

        using var request = new HttpRequestMessage(new HttpMethod(method), url);
        request.Headers.TryAddWithoutValidation("User-Agent", "Notifique-DotNet-SDK/0.2.0");

        if (!string.IsNullOrWhiteSpace(_apiKey))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
        }

        if (!string.IsNullOrWhiteSpace(options.IdempotencyKey))
        {
            request.Headers.TryAddWithoutValidation("Idempotency-Key", options.IdempotencyKey);
            request.Headers.TryAddWithoutValidation("x-idempotency-key", options.IdempotencyKey);
        }

        if (options.Body is not null && method is not "GET" and not "DELETE")
        {
            var json = JsonSerializer.Serialize(options.Body, JsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);

        if ((int)response.StatusCode >= 400)
        {
            throw new NotifiqueApiException((int)response.StatusCode, Encoding.UTF8.GetString(bytes));
        }

        return bytes;
    }

    private static string BuildPath(string template, IReadOnlyDictionary<string, string>? pathParams)
    {
        var path = template;
        if (pathParams is null)
        {
            return path;
        }

        foreach (var entry in pathParams)
        {
            path = path.Replace(
                "{" + entry.Key + "}",
                Uri.EscapeDataString(entry.Value),
                StringComparison.Ordinal);
        }

        return path;
    }

    private static string AppendQuery(string url, IReadOnlyDictionary<string, string>? query)
    {
        if (query is null || query.Count == 0)
        {
            return url;
        }

        var builder = new StringBuilder(url);
        builder.Append('?');
        var first = true;
        foreach (var entry in query)
        {
            if (!first)
            {
                builder.Append('&');
            }

            builder.Append(Uri.EscapeDataString(entry.Key));
            builder.Append('=');
            builder.Append(Uri.EscapeDataString(entry.Value));
            first = false;
        }

        return builder.ToString();
    }
}
