using System.Text.Json.Serialization;

namespace Notifique.Models.Sms;

public record SmsCancelResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] SmsCancelData Data
);

public record SmsCancelData(
    [property: JsonPropertyName("smsId")] string SmsId,
    [property: JsonPropertyName("status")] string Status
);
