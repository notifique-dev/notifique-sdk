using System.Net;
using System.Text.Json;
using Xunit;
using Notifique.Models.Push;
using Notifique.Tests.Helpers;

namespace Notifique.Tests;

public class PushApiTests
{
    private readonly MockHttpMessageHandler _handler = new();
    private readonly NotifiqueClient _client;

    private const string ListAppsJson = "{\"success\":true,\"data\":[{\"id\":\"app-1\",\"name\":\"My App\",\"workspace_id\":\"ws-1\",\"created_at\":\"2025-01-01T00:00:00Z\",\"updated_at\":\"2025-01-01T00:00:00Z\"}],\"pagination\":{\"total\":1,\"page\":1,\"limit\":20,\"totalPages\":1}}";
    private const string SingleAppJson = "{\"success\":true,\"data\":{\"id\":\"app-1\",\"name\":\"My App\",\"workspace_id\":\"ws-1\",\"created_at\":\"2025-01-01T00:00:00Z\",\"updated_at\":\"2025-01-01T00:00:00Z\"}}";
    private const string ListDevicesJson = "{\"success\":true,\"data\":[{\"id\":\"dev-1\",\"app_id\":\"app-1\",\"platform\":\"web\",\"created_at\":\"2025-01-01T00:00:00Z\"}],\"pagination\":{\"total\":1,\"page\":1,\"limit\":20,\"totalPages\":1}}";
    private const string SingleDeviceJson = "{\"success\":true,\"data\":{\"id\":\"dev-1\",\"app_id\":\"app-1\",\"platform\":\"web\",\"created_at\":\"2025-01-01T00:00:00Z\"}}";
    private const string SendPushJson = "{\"success\":true,\"data\":{\"status\":\"QUEUED\",\"count\":2,\"pushIds\":[\"push-1\",\"push-2\"]}}";
    private const string ListMessagesJson = "{\"success\":true,\"data\":[{\"id\":\"push-1\",\"device_id\":\"dev-1\",\"app_id\":\"app-1\",\"title\":\"Hi\",\"body\":\"Body\",\"status\":\"SENT\",\"created_at\":\"2025-01-01T00:00:00Z\"}],\"pagination\":{\"total\":1,\"page\":1,\"limit\":20,\"totalPages\":1}}";
    private const string SingleMessageJson = "{\"success\":true,\"data\":{\"id\":\"push-1\",\"device_id\":\"dev-1\",\"app_id\":\"app-1\",\"title\":\"Hi\",\"body\":\"Body\",\"status\":\"SENT\",\"created_at\":\"2025-01-01T00:00:00Z\"}}";
    private const string CancelPushJson = "{\"success\":true,\"data\":{\"pushId\":\"push-1\",\"status\":\"CANCELLED\"}}";

    public PushApiTests()
    {
        _client = new NotifiqueClient("test-api-key", "https://api.notifique.dev/v1", new HttpClient(_handler));
    }

    [Fact]
    public async Task ListAppsAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, ListAppsJson);
        var response = await _client.Push.ListAppsAsync();
        Assert.True(response.Success);
        Assert.Single(response.Data);
        Assert.Equal("app-1", response.Data[0].Id);
        Assert.Equal("My App", response.Data[0].Name);
        Assert.Equal(1, response.Pagination.Total);
    }

    [Fact]
    public async Task GetAppAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, SingleAppJson);
        var response = await _client.Push.GetAppAsync("app-1");
        Assert.True(response.Success);
        Assert.Equal("app-1", response.Data.Id);
        Assert.Equal("My App", response.Data.Name);
    }

    [Fact]
    public async Task CreateAppAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, SingleAppJson);
        var request = new PushAppCreateRequest { Name = "My App" };
        var response = await _client.Push.CreateAppAsync(request);
        Assert.True(response.Success);
        Assert.Equal("My App", response.Data.Name);
        Assert.NotNull(_handler.LastRequestBody);
        using var doc = JsonDocument.Parse(_handler.LastRequestBody!);
        Assert.Equal("My App", doc.RootElement.GetProperty("name").GetString());
    }

    [Fact]
    public async Task UpdateAppAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, SingleAppJson);
        var request = new PushAppUpdateRequest { Name = "Updated App" };
        var response = await _client.Push.UpdateAppAsync("app-1", request);
        Assert.True(response.Success);
        Assert.Equal(HttpMethod.Put, _handler.LastRequest?.Method);
        Assert.Equal("https://api.notifique.dev/v1/push/apps/app-1", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task RegisterDeviceAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, SingleDeviceJson);
        var request = new PushDeviceRegisterRequest
        {
            AppId = "app-1",
            Platform = "web",
            Subscription = new PushDeviceSubscription
            {
                Endpoint = "https://fcm.googleapis.com/...",
                Keys = new PushSubscriptionKeys { P256dh = "k", Auth = "a" }
            }
        };
        var response = await _client.Push.RegisterDeviceAsync(request);
        Assert.True(response.Success);
        Assert.Equal("dev-1", response.Data.Id);
        Assert.Equal("web", response.Data.Platform);
    }

    [Fact]
    public async Task SendMessageAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, SendPushJson);
        var request = new SendPushRequest
        {
            To = new List<string> { "dev-1", "dev-2" },
            Title = "Hello",
            Body = "World"
        };
        var response = await _client.Push.SendMessageAsync(request);
        Assert.True(response.Success);
        Assert.Equal("QUEUED", response.Data.Status);
        Assert.Equal(2, response.Data.Count);
        Assert.Equal(new[] { "push-1", "push-2" }, response.Data.PushIds);
    }

    [Fact]
    public async Task SendMessageAsync_WithSchedule_SendsSendAt()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"status\":\"SCHEDULED\",\"count\":1,\"pushIds\":[\"p1\"],\"scheduledAt\":\"2025-12-31T14:00:00.000Z\"}}");
        var request = new SendPushRequest
        {
            To = new List<string> { "dev-1" },
            Title = "Scheduled",
            Schedule = new PushSchedule { SendAt = "2025-12-31T14:00:00.000Z" }
        };
        var response = await _client.Push.SendMessageAsync(request);
        Assert.True(response.Success);
        Assert.Equal("SCHEDULED", response.Data.Status);
        Assert.NotNull(_handler.LastRequestBody);
        using var doc = JsonDocument.Parse(_handler.LastRequestBody!);
        Assert.True(doc.RootElement.TryGetProperty("schedule", out var s));
        Assert.True(s.TryGetProperty("sendAt", out _));
    }

    [Fact]
    public async Task ListMessagesAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, ListMessagesJson);
        var response = await _client.Push.ListMessagesAsync();
        Assert.True(response.Success);
        Assert.Single(response.Data);
        Assert.Equal("push-1", response.Data[0].Id);
        Assert.Equal("SENT", response.Data[0].Status);
    }

    [Fact]
    public async Task GetMessageAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, SingleMessageJson);
        var response = await _client.Push.GetMessageAsync("push-1");
        Assert.True(response.Success);
        Assert.Equal("push-1", response.Data.Id);
        Assert.Equal("Hi", response.Data.Title);
        Assert.Equal("SENT", response.Data.Status);
    }

    [Fact]
    public async Task CancelMessageAsync_ReturnsTypedResponse()
    {
        _handler.SetResponse(HttpStatusCode.OK, CancelPushJson);
        var response = await _client.Push.CancelMessageAsync("push-1");
        Assert.True(response.Success);
        Assert.Equal("push-1", response.Data.PushId);
        Assert.Equal("CANCELLED", response.Data.Status);
        Assert.Equal(HttpMethod.Post, _handler.LastRequest?.Method);
        Assert.Equal("https://api.notifique.dev/v1/push/messages/push-1/cancel", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task DeleteAppAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{}");
        await _client.Push.DeleteAppAsync("app-1");
        Assert.Equal(HttpMethod.Delete, _handler.LastRequest?.Method);
        Assert.Equal("https://api.notifique.dev/v1/push/apps/app-1", _handler.LastRequest?.RequestUri?.ToString());
    }
}
