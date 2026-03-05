using System.Text.Json.Serialization;

namespace Notifique.Models.Push;

/// <summary>OpenAPI SendPushResponse — POST /v1/push/messages (200/202)</summary>
public record SendPushResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] SendPushData Data
);

/// <summary>data do SendPushResponse</summary>
public record SendPushData(
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("pushIds")] List<string> PushIds,
    [property: JsonPropertyName("scheduled_at")] string? ScheduledAt = null
);
