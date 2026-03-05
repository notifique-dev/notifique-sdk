using System.Text.Json.Serialization;

namespace Notifique.Models.Push;

/// <summary>OpenAPI CancelPushResponse — POST /v1/push/messages/{id}/cancel</summary>
public record CancelPushResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] CancelPushData Data
);

/// <summary>data do CancelPushResponse</summary>
public record CancelPushData(
    [property: JsonPropertyName("pushId")] string PushId,
    [property: JsonPropertyName("status")] string Status
);
