using System.Text.Json;

namespace Notifique.Generated;

internal static class OperationsRegistry
{
    public static OperationsFile Load()
    {
        var assembly = typeof(OperationsRegistry).Assembly;
        const string resourceName = "Notifique.operations.json";
        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Missing embedded resource {resourceName}");
        using var reader = new StreamReader(stream);
        var json = reader.ReadToEnd();
        return JsonSerializer.Deserialize<OperationsFile>(json)
               ?? throw new InvalidOperationException("Failed to deserialize operations.json");
    }
}
