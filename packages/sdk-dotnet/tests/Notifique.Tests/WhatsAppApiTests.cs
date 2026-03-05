using System.Net;
using System.Text.Json;
using Xunit;
using Notifique.Models.WhatsApp;
using Notifique.Tests.Helpers;

namespace Notifique.Tests;

public class WhatsAppApiTests
{
    private readonly MockHttpMessageHandler _handler = new();
    private readonly NotifiqueClient _client;

    public WhatsAppApiTests()
    {
        _client = new NotifiqueClient("test-api-key", "https://api.notifique.dev/v1", new HttpClient(_handler));
    }

    [Fact]
    public async Task SendTextAsync_SingleRecipient_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"messageIds\":[\"msg-123\"],\"status\":\"queued\"}}");

        var response = await _client.WhatsApp.SendTextAsync("instance-1", "5511999999999", "Hello");

        Assert.True(response.Success);
        Assert.Equal(new List<string> { "msg-123" }, response.Data.MessageIds);
        Assert.Equal("queued", response.Data.Status);
        Assert.NotNull(_handler.LastRequest);
        Assert.Equal(HttpMethod.Post, _handler.LastRequest.Method);
        Assert.Equal("https://api.notifique.dev/v1/whatsapp/messages", _handler.LastRequest.RequestUri?.ToString());
    }

    [Fact]
    public async Task SendTextAsync_MultipleRecipients_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"messageIds\":[\"m1\",\"m2\"],\"status\":\"queued\"}}");

        var response = await _client.WhatsApp.SendTextAsync("instance-1", new List<string> { "5511111111111", "5522222222222" }, "Hello all");

        Assert.True(response.Success);
        Assert.Equal(2, response.Data.MessageIds.Count);
    }

    [Fact]
    public async Task SendAsync_WithParams_SetsInstanceId()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"messageIds\":[\"m1\"],\"status\":\"queued\"}}");

        var parameters = new WhatsAppSendParams
        {
            To = new List<string> { "5511888888888" },
            Type = "text",
            Payload = new TextPayload("Hi")
        };

        await _client.WhatsApp.SendAsync("instance-1", parameters);

        Assert.NotNull(_handler.LastRequestBody);
        using var doc = JsonDocument.Parse(_handler.LastRequestBody);
        Assert.Equal("instance-1", doc.RootElement.GetProperty("instanceId").GetString());
    }

    [Fact]
    public async Task GetMessageAsync_ReturnsStatus()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"messageId\":\"msg-1\",\"status\":\"delivered\"}}");

        var response = await _client.WhatsApp.GetMessageAsync("msg-1");
        var status = response.Data;

        Assert.True(response.Success);
        Assert.Equal("msg-1", status.MessageId);
        Assert.Equal("delivered", status.Status);
        Assert.Equal(HttpMethod.Get, _handler.LastRequest?.Method);
        Assert.Equal("https://api.notifique.dev/v1/whatsapp/messages/msg-1", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task ListInstancesAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":[],\"pagination\":{\"total\":0,\"page\":1,\"limit\":10,\"totalPages\":0}}");

        var response = await _client.WhatsApp.ListInstancesAsync();

        Assert.True(response.Success);
        Assert.Empty(response.Data);
        Assert.NotNull(response.Pagination);
        Assert.Equal(0, response.Pagination.Total);
    }

    [Fact]
    public async Task ListInstancesAsync_WithQueryParams()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":[],\"pagination\":{\"total\":0,\"page\":1,\"limit\":5,\"totalPages\":0}}");

        await _client.WhatsApp.ListInstancesAsync(new Dictionary<string, string> { { "page", "1" }, { "limit", "5" } });

        Assert.Contains("page=1", _handler.LastRequest?.RequestUri?.ToString());
        Assert.Contains("limit=5", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task EditMessageAsync_SendsPatchRequest()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"messageId\":\"msg-1\",\"status\":\"EDITED\"}}");

        var response = await _client.WhatsApp.EditMessageAsync("msg-1", "Updated text");

        Assert.True(response.Success);
        Assert.Equal("msg-1", response.Data.MessageId);
        Assert.Equal("EDITED", response.Data.Status);
        Assert.Equal(HttpMethod.Patch, _handler.LastRequest?.Method);
        Assert.Contains("edit", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task CancelMessageAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"messageId\":\"msg-1\",\"status\":\"CANCELLED\"}}");

        var response = await _client.WhatsApp.CancelMessageAsync("msg-1");

        Assert.True(response.Success);
        Assert.Equal("msg-1", response.Data.MessageId);
        Assert.Equal("CANCELLED", response.Data.Status);
    }

    [Fact]
    public async Task DeleteMessageAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"messageId\":\"msg-1\",\"status\":\"DELETED\"}}");

        var response = await _client.WhatsApp.DeleteMessageAsync("msg-1");

        Assert.True(response.Success);
        Assert.Equal("msg-1", response.Data.MessageId);
        Assert.Equal("DELETED", response.Data.Status);
        Assert.Equal(HttpMethod.Delete, _handler.LastRequest?.Method);
    }

    [Fact]
    public async Task SendAsync_ApiError_ThrowsException()
    {
        _handler.SetResponse(HttpStatusCode.BadRequest, "{\"error\":\"Invalid instance\"}");

        var ex = await Assert.ThrowsAsync<NotifiqueApiException>(() =>
            _client.WhatsApp.SendTextAsync("wrong", "123", "hi"));

        Assert.Equal(400, ex.StatusCode);
    }
}
