using System.Text.Json.Serialization;

namespace Notifique.Generated;

internal sealed class OperationRecord
{
    [JsonPropertyName("spec")]
    public string Spec { get; set; } = string.Empty;

    [JsonPropertyName("operationId")]
    public string? OperationId { get; set; }

    [JsonPropertyName("httpMethod")]
    public string HttpMethod { get; set; } = "GET";

    [JsonPropertyName("path")]
    public string Path { get; set; } = string.Empty;

    [JsonPropertyName("urlTemplate")]
    public string UrlTemplate { get; set; } = string.Empty;

    [JsonPropertyName("namespaces")]
    public List<string> Namespaces { get; set; } = new();

    [JsonPropertyName("methodName")]
    public string MethodName { get; set; } = string.Empty;

    [JsonPropertyName("pathParams")]
    public List<string> PathParams { get; set; } = new();

    [JsonPropertyName("requiresAuth")]
    public bool RequiresAuth { get; set; }

    [JsonPropertyName("idempotent")]
    public bool Idempotent { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;
}

internal sealed class OperationsFile
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("operations")]
    public List<OperationRecord> Operations { get; set; } = new();
}
