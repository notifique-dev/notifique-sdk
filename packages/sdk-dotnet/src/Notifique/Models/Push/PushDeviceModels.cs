using System.Text.Json.Serialization;
using Notifique.Models.Shared;

namespace Notifique.Models.Push;

/// <summary>OpenAPI PushDeviceRegisterRequest.subscription.keys (Web Push)</summary>
public class PushSubscriptionKeys
{
    [JsonPropertyName("p256dh")]
    public string? P256dh { get; set; }

    [JsonPropertyName("auth")]
    public string? Auth { get; set; }
}

/// <summary>OpenAPI PushDeviceRegisterRequest.subscription (Web Push)</summary>
public class PushDeviceSubscription
{
    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("keys")]
    public PushSubscriptionKeys? Keys { get; set; }
}

/// <summary>OpenAPI PushDeviceRegisterRequest — POST /v1/push/devices</summary>
public class PushDeviceRegisterRequest
{
    [JsonPropertyName("app_id")]
    public string AppId { get; init; } = default!;

    [JsonPropertyName("platform")]
    public string Platform { get; init; } = default!; // "web" | "android" | "ios"

    [JsonPropertyName("subscription")]
    public PushDeviceSubscription? Subscription { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("external_user_id")]
    public string? ExternalUserId { get; set; }
}

/// <summary>OpenAPI PushDeviceItem</summary>
public record PushDeviceItem(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("app_id")] string AppId,
    [property: JsonPropertyName("platform")] string Platform,
    [property: JsonPropertyName("external_user_id")] string? ExternalUserId = null,
    [property: JsonPropertyName("created_at")] string? CreatedAt = null
);

/// <summary>OpenAPI PushDeviceListResponse — GET /v1/push/devices</summary>
public record PushDeviceListResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] List<PushDeviceItem> Data,
    [property: JsonPropertyName("pagination")] Pagination Pagination
);

/// <summary>OpenAPI PushDeviceSingleResponse — GET /v1/push/devices/{id}, POST /v1/push/devices</summary>
public record PushDeviceSingleResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] PushDeviceItem Data
);
