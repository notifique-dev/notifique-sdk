using System.Text.Json.Serialization;

namespace Notifique.Models.WhatsApp;

public record WhatsAppInstanceQrResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] WhatsAppInstanceQrData Data
);

public record WhatsAppInstanceQrData(
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("base64")] string? Base64
);
