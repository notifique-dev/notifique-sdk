using System.Text.Json;
using Notifique.Generated;
using Xunit;

namespace Notifique.Tests;

public class OpenApiCoverageTests
{
    [Fact]
    public void RegistryHas353Operations()
    {
        var registry = OperationsRegistry.Load();
        Assert.Equal(353, registry.Count);
        Assert.Equal(353, registry.Operations.Count);
    }

    [Fact]
    public void GeneratedClientExposesEveryRegistryOperation()
    {
        var registry = OperationsRegistry.Load();
        var expected = registry.Operations
            .Select(op => string.Join('.', op.Namespaces.Concat(new[] { op.MethodName })))
            .OrderBy(path => path, StringComparer.Ordinal)
            .ToList();

        var api = GeneratedApi.Create("test-key", "https://api.notifique.dev/v1", new HttpClient());
        var available = api.ListOperationPaths().ToList();
        var missing = expected.Where(path => !available.Contains(path)).ToList();

        Assert.Equal(353, api.OperationCount);
        Assert.Empty(missing);
        Assert.Equal(353, available.Count);
        Assert.Contains("wellKnown.getJwks", available);
        Assert.Contains("oauth.apps.rotateWorkspaceAppSecret", available);
    }

    [Fact]
    public async Task DynamicNamespaceCanInvokeOperation()
    {
        var handler = new Helpers.MockHttpMessageHandler();
        handler.SetResponse(System.Net.HttpStatusCode.OK, "{\"success\":true}");
        var httpClient = new HttpClient(handler);
        dynamic api = GeneratedApi.Create("test-key", "https://api.notifique.dev/v1", httpClient);

        JsonElement result = await api.wellKnown.getJwks();

        Assert.True(result.TryGetProperty("success", out var success));
        Assert.True(success.GetBoolean());
        Assert.NotNull(handler.LastRequest);
        Assert.Equal("https://api.notifique.dev/.well-known/jwks.json", handler.LastRequest.RequestUri?.ToString());
    }

    [Fact]
    public void TypedClientExposesPushNamespace()
    {
        var client = new NotifiqueClient("test-key", "https://api.notifique.dev/v1", new HttpClient());
        Assert.NotNull(client.Api.push);
    }
}
