using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Notifique;

public class NotifiqueClient : IDisposable
{
    protected const string DefaultBaseUrl = "https://api.notifique.dev/v1";
    private const string UserAgent = "Notifique-DotNet-SDK/0.1.0";

    protected readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;
    protected readonly string _baseUrl;
    protected readonly string _apiKey;

    protected static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true
    };

    public WhatsAppApi WhatsApp { get; }
    public SmsApi Sms { get; }
    public EmailApi Email { get; }
    public MessagesApi Messages { get; }
    public EmailDomainsApi EmailDomains { get; }
    public PushApi Push { get; }

    public NotifiqueClient(string apiKey) : this(apiKey, DefaultBaseUrl)
    {
    }

    public NotifiqueClient(string apiKey, string baseUrl) : this(apiKey, baseUrl, null)
    {
    }

    public NotifiqueClient(string apiKey, string baseUrl, HttpClient? httpClient)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        _baseUrl = (baseUrl ?? DefaultBaseUrl).TrimEnd('/');

        if (httpClient is not null)
        {
            _httpClient = httpClient;
            _ownsHttpClient = false;
        }
        else
        {
            _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
            _ownsHttpClient = true;
        }

        WhatsApp = new WhatsAppApi(this);
        Sms = new SmsApi(this);
        Email = new EmailApi(this);
        Messages = new MessagesApi(this);
        EmailDomains = new EmailDomainsApi(this);
        Push = new PushApi(this);
    }

    internal async Task<T> RequestAsync<T>(HttpMethod method, string path, object? body = null, CancellationToken cancellationToken = default)
    {
        var responseBody = await SendAsync(method, path, body, cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<T>(responseBody, JsonOptions)
               ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    internal async Task RequestAsync(HttpMethod method, string path, object? body = null, CancellationToken cancellationToken = default)
    {
        await SendAsync(method, path, body, cancellationToken).ConfigureAwait(false);
    }

    private async Task<string> SendAsync(HttpMethod method, string path, object? body, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(method, _baseUrl + path);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        request.Headers.UserAgent.ParseAdd(UserAgent);

        if (body is not null && method != HttpMethod.Get && method != HttpMethod.Delete)
        {
            var json = JsonSerializer.Serialize(body, JsonOptions);
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

    public virtual void Dispose()
    {
        if (_ownsHttpClient)
        {
            _httpClient.Dispose();
        }
    }
}
