using System.Dynamic;
using System.Text.Json;

namespace Notifique.Generated;

/// <summary>
/// Dynamic namespace node for generated OpenAPI operations.
/// Supports nested access like <c>api.wellKnown.getJwks()</c>.
/// </summary>
public sealed class ApiNamespace : DynamicObject
{
    private readonly GeneratedApiTransport _transport;
    private readonly Dictionary<string, ApiNamespace> _children = new(StringComparer.Ordinal);
    private readonly Dictionary<string, OperationRecord> _operations = new(StringComparer.Ordinal);

    internal ApiNamespace(GeneratedApiTransport transport)
    {
        _transport = transport;
    }

    internal void AddChild(string name, ApiNamespace child) => _children[name] = child;

    internal void AddOperation(OperationRecord operation) => _operations[operation.MethodName] = operation;

    internal IReadOnlyDictionary<string, ApiNamespace> Children => _children;

    internal IReadOnlyDictionary<string, OperationRecord> Operations => _operations;

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        if (_children.TryGetValue(binder.Name, out var child))
        {
            result = child;
            return true;
        }

        if (_operations.TryGetValue(binder.Name, out var operation))
        {
            result = new ApiOperationInvoker(_transport, operation);
            return true;
        }

        result = null;
        return false;
    }

    internal void CollectOperationPaths(string prefix, List<string> output)
    {
        foreach (var entry in _operations)
        {
            output.Add(string.IsNullOrEmpty(prefix) ? entry.Key : $"{prefix}.{entry.Key}");
        }

        foreach (var entry in _children)
        {
            var childPrefix = string.IsNullOrEmpty(prefix) ? entry.Key : $"{prefix}.{entry.Key}";
            entry.Value.CollectOperationPaths(childPrefix, output);
        }
    }

    internal List<string> CollectOperationPaths()
    {
        var output = new List<string>();
        CollectOperationPaths(string.Empty, output);
        return output;
    }
}

internal sealed class ApiOperationInvoker : DynamicObject
{
    private readonly GeneratedApiTransport _transport;
    private readonly OperationRecord _operation;

    public ApiOperationInvoker(GeneratedApiTransport transport, OperationRecord operation)
    {
        _transport = transport;
        _operation = operation;
    }

    public override bool TryInvoke(InvokeBinder binder, object?[]? args, out object? result)
    {
        IReadOnlyDictionary<string, string>? pathParams = null;
        ApiRequestOptions? options = null;

        if (args is { Length: > 0 })
        {
            if (args[0] is IReadOnlyDictionary<string, string> dict)
            {
                pathParams = dict;
                if (args.Length > 1 && args[1] is ApiRequestOptions requestOptions)
                {
                    options = requestOptions;
                }
            }
            else if (args[0] is ApiRequestOptions requestOptions)
            {
                options = requestOptions;
            }
        }

        result = InvokeAsync(pathParams, options);
        return true;
    }

    public Task<JsonElement> InvokeAsync(
        IReadOnlyDictionary<string, string>? pathParams = null,
        ApiRequestOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        return _transport.RequestAsync(
            _operation.HttpMethod,
            _operation.UrlTemplate,
            pathParams,
            options,
            cancellationToken);
    }
}
