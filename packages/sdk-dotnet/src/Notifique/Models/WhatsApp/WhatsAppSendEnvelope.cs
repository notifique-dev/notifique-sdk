using System.Text.Json.Serialization;

namespace Notifique.Models.WhatsApp;

public record WhatsAppSendEnvelope(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] WhatsAppSendResponse Data
);
