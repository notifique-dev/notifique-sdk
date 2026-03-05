using System.Text.Json.Serialization;

namespace Notifique.Models.Email;

/// <summary>OpenAPI CreateEmailDomainRequest — POST /v1/email/domains body</summary>
public class CreateEmailDomainRequest
{
    [JsonPropertyName("domain")]
    public string Domain { get; init; } = default!;
}
