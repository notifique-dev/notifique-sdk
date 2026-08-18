using System.Text.Json.Serialization;

namespace Notifique.Models.Push;

/// <summary>OpenAPI NtfPush_SendPushResponse — POST /v1/push/messages (200/202)</summary>
public record SendPushResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] SendPushData Data
);

public record SendPushData(
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("messageIds")] List<string> MessageIds,
    [property: JsonPropertyName("scheduledAt")] string? ScheduledAt = null
);
