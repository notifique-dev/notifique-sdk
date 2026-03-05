using System.Text.Json.Serialization;

namespace Notifique.Models.WhatsApp;

public record WhatsAppSendResponse(
    [property: JsonPropertyName("messageIds")] List<string> MessageIds,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("scheduled_at")] string? ScheduledAt = null
);
