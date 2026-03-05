using System.Text.Json.Serialization;
using Notifique.Models.Shared;

namespace Notifique.Models.Push;

/// <summary>OpenAPI PushAppItem</summary>
public record PushAppItem(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("workspace_id")] string? WorkspaceId = null,
    [property: JsonPropertyName("vapid_public_key")] string? VapidPublicKey = null,
    [property: JsonPropertyName("has_vapid_private")] bool HasVapidPrivate = false,
    [property: JsonPropertyName("has_fcm")] bool HasFcm = false,
    [property: JsonPropertyName("has_apns")] bool HasApns = false,
    [property: JsonPropertyName("allowed_origins")] List<string>? AllowedOrigins = null,
    [property: JsonPropertyName("prompt_config")] Dictionary<string, object>? PromptConfig = null,
    [property: JsonPropertyName("created_at")] string? CreatedAt = null,
    [property: JsonPropertyName("updated_at")] string? UpdatedAt = null
);

/// <summary>OpenAPI PushAppCreateRequest — POST /v1/push/apps</summary>
public class PushAppCreateRequest
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;
}

/// <summary>OpenAPI PushAppUpdateRequest — PUT /v1/push/apps/{id}</summary>
public class PushAppUpdateRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("vapid_public_key")]
    public string? VapidPublicKey { get; set; }

    [JsonPropertyName("vapid_private_key")]
    public string? VapidPrivateKey { get; set; }

    [JsonPropertyName("allowed_origins")]
    public List<string>? AllowedOrigins { get; set; }

    [JsonPropertyName("prompt_config")]
    public Dictionary<string, object>? PromptConfig { get; set; }

    [JsonPropertyName("fcm_project_id")]
    public string? FcmProjectId { get; set; }

    [JsonPropertyName("fcm_service_account_json")]
    public string? FcmServiceAccountJson { get; set; }

    [JsonPropertyName("apns_key_id")]
    public string? ApnsKeyId { get; set; }

    [JsonPropertyName("apns_team_id")]
    public string? ApnsTeamId { get; set; }

    [JsonPropertyName("apns_bundle_id")]
    public string? ApnsBundleId { get; set; }

    [JsonPropertyName("apns_key_p8")]
    public string? ApnsKeyP8 { get; set; }
}

/// <summary>OpenAPI PushAppListResponse — GET /v1/push/apps</summary>
public record PushAppListResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] List<PushAppItem> Data,
    [property: JsonPropertyName("pagination")] Pagination Pagination
);

/// <summary>OpenAPI PushAppSingleResponse — GET/POST/PUT /v1/push/apps/{id}</summary>
public record PushAppSingleResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] PushAppItem Data
);
