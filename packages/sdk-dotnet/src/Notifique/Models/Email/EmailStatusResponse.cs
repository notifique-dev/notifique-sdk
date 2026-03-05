using System.Text.Json.Serialization;

namespace Notifique.Models.Email;

/// <summary>GET /v1/email/messages/{id} — OpenAPI EmailStatusResponse</summary>
public record EmailStatusResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] EmailStatusData Data
);

/// <summary>data do EmailStatusResponse — apenas campos do OpenAPI</summary>
public record EmailStatusData(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("to")] string? To,
    [property: JsonPropertyName("from")] string? From,
    [property: JsonPropertyName("fromName")] string? FromName,
    [property: JsonPropertyName("subject")] string? Subject,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("scheduledFor")] string? ScheduledFor = null,
    [property: JsonPropertyName("sentAt")] string? SentAt = null,
    [property: JsonPropertyName("deliveredAt")] string? DeliveredAt = null,
    [property: JsonPropertyName("failedAt")] string? FailedAt = null,
    [property: JsonPropertyName("errorMessage")] string? ErrorMessage = null,
    [property: JsonPropertyName("createdAt")] string? CreatedAt = null
);
