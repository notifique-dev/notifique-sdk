namespace Notifique.Generated;

public sealed class ApiRequestOptions
{
    public IReadOnlyDictionary<string, string>? Query { get; init; }
    public object? Body { get; init; }
    public string? IdempotencyKey { get; init; }

    public static ApiRequestOptions Empty { get; } = new();
}
