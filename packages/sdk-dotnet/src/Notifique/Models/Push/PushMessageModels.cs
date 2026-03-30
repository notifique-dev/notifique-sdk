using System.Text.Json.Serialization;
using Notifique.Models.Shared;

namespace Notifique.Models.Push;

/// <summary>OpenAPI PushMessageItem</summary>
public record PushMessageItem(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("device_id")] string DeviceId,
    [property: JsonPropertyName("app_id")] string AppId,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("title")] string? Title = null,
    [property: JsonPropertyName("body")] string? Body = null,
    [property: JsonPropertyName("scheduled_for")] string? ScheduledFor = null,
    [property: JsonPropertyName("sent_at")] string? SentAt = null,
    [property: JsonPropertyName("delivered_at")] string? DeliveredAt = null,
    [property: JsonPropertyName("failed_at")] string? FailedAt = null,
    [property: JsonPropertyName("error_message")] string? ErrorMessage = null,
    [property: JsonPropertyName("clicked_at")] string? ClickedAt = null,
    [property: JsonPropertyName("created_at")] string? CreatedAt = null
);

/// <summary>OpenAPI PushMessageListResponse — GET /v1/push/messages</summary>
public record PushMessageListResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] List<PushMessageItem> Data,
    [property: JsonPropertyName("pagination")] Pagination Pagination
);

/// <summary>OpenAPI PushMessageSingleResponse — GET /v1/push/messages/{id}</summary>
public record PushMessageSingleResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] PushMessageItem Data
);
