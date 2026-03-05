using System.Text.Json.Serialization;
using Notifique.Models.Shared;

namespace Notifique.Models.Sms;

public class SmsSendParams
{
    [JsonPropertyName("to")]
    public List<string> To { get; init; } = default!;

    [JsonPropertyName("message")]
    public string Message { get; init; } = default!;

    [JsonPropertyName("schedule")]
    public Schedule? Schedule { get; init; }

    [JsonPropertyName("options")]
    public SendOptions? Options { get; init; }
}
