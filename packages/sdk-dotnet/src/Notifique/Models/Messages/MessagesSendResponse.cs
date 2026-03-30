using System.Text.Json.Serialization;

namespace Notifique.Models.Messages;

public record MessagesSendResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] MessagesSendData Data
);

public record MessagesSendData(
    [property: JsonPropertyName("messageIds")] List<string>? MessageIds,
    [property: JsonPropertyName("smsIds")] List<string>? SmsIds,
    [property: JsonPropertyName("emailIds")] List<string>? EmailIds,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("count")] int? Count
);
