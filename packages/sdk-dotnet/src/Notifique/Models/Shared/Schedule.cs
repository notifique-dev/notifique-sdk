using System.Text.Json.Serialization;

namespace Notifique.Models.Shared;

public class Schedule
{
    [JsonPropertyName("sendAt")]
    public string SendAt { get; set; } = default!;
}
