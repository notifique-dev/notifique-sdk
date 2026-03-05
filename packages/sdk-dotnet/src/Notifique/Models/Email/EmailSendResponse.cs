using System.Text.Json.Serialization;

namespace Notifique.Models.Email;

public record EmailSendResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] EmailSendData Data
);

public record EmailSendData(
    [property: JsonPropertyName("emailIds")] List<string> EmailIds,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("count")] int? Count,
    [property: JsonPropertyName("scheduledAt")] string? ScheduledAt = null
);
