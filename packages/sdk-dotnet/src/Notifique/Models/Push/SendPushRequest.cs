using System.Text.Json.Serialization;

namespace Notifique.Models.Push;

/// <summary>OpenAPI SendPushRequest — POST /v1/push/messages body. Agendamento: schedule.sendAt</summary>
public class SendPushRequest
{
    [JsonPropertyName("to")]
    public List<string> To { get; init; } = default!;

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; set; }

    [JsonPropertyName("schedule")]
    public PushSchedule? Schedule { get; set; }

    [JsonPropertyName("options")]
    public PushSendOptions? Options { get; set; }
}
