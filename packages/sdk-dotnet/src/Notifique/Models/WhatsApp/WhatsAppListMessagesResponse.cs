using System.Text.Json.Serialization;
using Notifique.Models.Shared;

namespace Notifique.Models.WhatsApp;

public record WhatsAppListMessagesResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] List<Dictionary<string, object>> Data,
    [property: JsonPropertyName("pagination")] Pagination? Pagination
);
