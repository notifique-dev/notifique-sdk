using System.Text.Json.Serialization;

namespace Notifique.Models.Push;

/// <summary>OpenAPI NtfPush_SendPushRequest — POST /v1/push/messages (to + type + payload).</summary>
public class SendPushRequest
{
    [JsonPropertyName("to")]
    public List<string> To { get; init; } = default!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = "push";

    [JsonPropertyName("payload")]
    public Dictionary<string, object> Payload { get; set; } = default!;

    [JsonPropertyName("schedule")]
    public PushSchedule? Schedule { get; set; }

    [JsonPropertyName("options")]
    public PushSendOptions? Options { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object>? Metadata { get; set; }
}
