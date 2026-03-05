using System.Text.Json.Serialization;

namespace Notifique.Models.Push;

/// <summary>OpenAPI SendPushRequest.options</summary>
public class PushSendOptions
{
    [JsonPropertyName("priority")]
    public string? Priority { get; set; }
}
