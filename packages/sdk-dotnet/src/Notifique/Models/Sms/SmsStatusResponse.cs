using System.Text.Json.Serialization;

namespace Notifique.Models.Sms;

/// <summary>OpenAPI SmsStatusResponse — GET /v1/sms/messages/{id}</summary>
public record SmsStatusResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] SmsStatusData Data
);

/// <summary>data do SmsStatusResponse — apenas campos do OpenAPI</summary>
public record SmsStatusData(
    [property: JsonPropertyName("smsId")] string SmsId,
    [property: JsonPropertyName("to")] string? To,
    [property: JsonPropertyName("message")] string? Message,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("sent_at")] string? SentAt = null,
    [property: JsonPropertyName("delivered_at")] string? DeliveredAt = null,
    [property: JsonPropertyName("failed_at")] string? FailedAt = null,
    [property: JsonPropertyName("scheduled_for")] string? ScheduledFor = null,
    [property: JsonPropertyName("error_message")] string? ErrorMessage = null,
    [property: JsonPropertyName("created_at")] string? CreatedAt = null
);
