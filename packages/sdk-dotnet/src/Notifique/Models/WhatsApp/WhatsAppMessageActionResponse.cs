using System.Text.Json.Serialization;

namespace Notifique.Models.WhatsApp;

/// <summary>OpenAPI MessageActionResponse — cancel, delete, edit: envelope success/data com messageId e status.</summary>
public record WhatsAppMessageActionResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] WhatsAppMessageActionData Data
);

/// <summary>data do MessageActionResponse</summary>
public record WhatsAppMessageActionData(
    [property: JsonPropertyName("messageId")] string MessageId,
    [property: JsonPropertyName("status")] string Status
);
