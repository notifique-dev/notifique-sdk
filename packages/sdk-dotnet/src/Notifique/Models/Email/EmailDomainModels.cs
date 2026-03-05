using System.Text.Json.Serialization;

namespace Notifique.Models.Email;

/// <summary>OpenAPI EmailDomainItem — item de domínio (listagem ou detalhe)</summary>
public record EmailDomainItem(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("domain")] string Domain,
    [property: JsonPropertyName("status")] string? Status,
    [property: JsonPropertyName("dnsRecords")] List<EmailDnsRecord>? DnsRecords = null,
    [property: JsonPropertyName("verifiedAt")] string? VerifiedAt = null,
    [property: JsonPropertyName("createdAt")] string? CreatedAt = null,
    [property: JsonPropertyName("updatedAt")] string? UpdatedAt = null
);

/// <summary>Registro DNS para verificação do domínio</summary>
public record EmailDnsRecord(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("value")] string Value
);

/// <summary>OpenAPI ListEmailDomainsResponse — GET /v1/email/domains</summary>
public record EmailDomainListResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] List<EmailDomainItem> Data
);

/// <summary>OpenAPI EmailDomainResponse — GET /v1/email/domains/{id}</summary>
public record EmailDomainGetResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] EmailDomainItem Data
);

/// <summary>OpenAPI CreateEmailDomainResponse — POST /v1/email/domains</summary>
public record EmailDomainCreateResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] EmailDomainItem Data,
    [property: JsonPropertyName("message")] string? Message = null
);

/// <summary>OpenAPI VerifyEmailDomainResponse — POST /v1/email/domains/{id}/verify</summary>
public record EmailDomainVerifyResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] EmailDomainItem? Data,
    [property: JsonPropertyName("verified")] bool Verified
);
