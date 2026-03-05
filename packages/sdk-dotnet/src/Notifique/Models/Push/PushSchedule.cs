using System.Text.Json.Serialization;

namespace Notifique.Models.Push;

/// <summary>OpenAPI Push: agendamento usa sendAt (camelCase).</summary>
public class PushSchedule
{
    [JsonPropertyName("sendAt")]
    public string? SendAt { get; set; }
}
