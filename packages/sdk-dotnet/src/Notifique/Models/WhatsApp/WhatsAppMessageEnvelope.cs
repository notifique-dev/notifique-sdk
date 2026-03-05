using System.Text.Json.Serialization;

namespace Notifique.Models.WhatsApp;

public record WhatsAppMessageEnvelope(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] WhatsAppMessageStatus Data
);
