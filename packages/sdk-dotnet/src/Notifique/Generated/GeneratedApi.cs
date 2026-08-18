using System.Dynamic;

namespace Notifique.Generated;

/// <summary>
/// Full OpenAPI coverage (353 operations) built dynamically from operations.json.
/// </summary>
public sealed class GeneratedApi : DynamicObject
{
    private readonly Dictionary<string, ApiNamespace> _namespaces = new(StringComparer.Ordinal);

    private GeneratedApi(Dictionary<string, ApiNamespace> namespaces, int operationCount)
    {
        foreach (var entry in namespaces)
        {
            _namespaces[entry.Key] = entry.Value;
        }

        OperationCount = operationCount;
    }

    public int OperationCount { get; }

    public static GeneratedApi Create(string? apiKey, string baseUrl, HttpClient httpClient)
    {
        var registry = OperationsRegistry.Load();
        var transport = new GeneratedApiTransport(apiKey, GeneratedApiTransport.NormalizeApiBaseUrl(baseUrl), httpClient);
        var roots = new Dictionary<string, ApiNamespace>(StringComparer.Ordinal);

        foreach (var operation in registry.Operations)
        {
            if (operation.Namespaces.Count == 0)
            {
                continue;
            }

            if (!roots.TryGetValue(operation.Namespaces[0], out var node))
            {
                node = new ApiNamespace(transport);
                roots[operation.Namespaces[0]] = node;
            }

            var current = node;
            for (var i = 1; i < operation.Namespaces.Count; i++)
            {
                var childName = operation.Namespaces[i];
                if (!current.Children.TryGetValue(childName, out var child))
                {
                    child = new ApiNamespace(transport);
                    current.AddChild(childName, child);
                }

                current = child;
            }

            current.AddOperation(operation);
        }

        return new GeneratedApi(roots, registry.Count);
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        if (_namespaces.TryGetValue(binder.Name, out var ns))
        {
            result = ns;
            return true;
        }

        result = null;
        return false;
    }

    public IReadOnlyList<string> ListOperationPaths()
    {
        var output = new List<string>();
        foreach (var entry in _namespaces)
        {
            foreach (var path in entry.Value.CollectOperationPaths())
            {
                output.Add($"{entry.Key}.{path}");
            }
        }

        output.Sort(StringComparer.Ordinal);
        return output;
    }
}
