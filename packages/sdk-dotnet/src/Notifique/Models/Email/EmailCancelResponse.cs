using System.Text.Json.Serialization;

namespace Notifique.Models.Email;

public record EmailCancelResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("data")] EmailCancelData Data
);

public record EmailCancelData(
    [property: JsonPropertyName("emailId")] string EmailId,
    [property: JsonPropertyName("status")] string Status
);
