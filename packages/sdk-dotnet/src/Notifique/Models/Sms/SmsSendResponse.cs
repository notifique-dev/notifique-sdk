using System.Text.Json.Serialization;

namespace Notifique.Models.Sms;

public record SmsSendResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] SmsSendData Data
);

public record SmsSendData(
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("count")] int? Count,
    [property: JsonPropertyName("smsIds")] List<string> SmsIds,
    [property: JsonPropertyName("scheduledAt")] string? ScheduledAt = null
);
