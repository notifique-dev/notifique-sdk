using System.Text.Json.Serialization;
using Notifique.Models.Shared;

namespace Notifique.Models.WhatsApp;

public record WhatsAppInstanceListResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] List<WhatsAppInstance> Data,
    [property: JsonPropertyName("pagination")] Pagination? Pagination
);

public record WhatsAppInstanceResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] WhatsAppInstance Data
);

public record WhatsAppCreateInstanceResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] WhatsAppCreateInstanceData Data
);

public record WhatsAppCreateInstanceData(
    [property: JsonPropertyName("instance")] WhatsAppInstance Instance,
    [property: JsonPropertyName("connection")] Dictionary<string, object>? Connection
);

public record WhatsAppInstanceActionResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] WhatsAppInstanceActionData Data,
    [property: JsonPropertyName("message")] string? Message = null
);

public record WhatsAppInstanceActionData(
    [property: JsonPropertyName("instanceId")] string InstanceId,
    [property: JsonPropertyName("status")] string Status
);
