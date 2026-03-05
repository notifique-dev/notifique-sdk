using System.Net;
using Xunit;
using Notifique.Models.Messages;
using Notifique.Tests.Helpers;

namespace Notifique.Tests;

public class MessagesApiTests
{
    private readonly MockHttpMessageHandler _handler = new();
    private readonly NotifiqueClient _client;

    public MessagesApiTests()
    {
        _client = new NotifiqueClient("test-api-key", "https://api.notifique.dev/v1", new HttpClient(_handler));
    }

    [Fact]
    public async Task SendAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"messageIds\":[\"m1\",\"m2\"],\"status\":\"queued\",\"count\":2}}");

        var parameters = new MessagesSendParams
        {
            To = new List<string> { "5511999999999" },
            Template = "welcome",
            Variables = new Dictionary<string, object> { { "name", "User" } },
            Channels = new List<string> { "whatsapp", "sms" },
            InstanceId = "inst-1"
        };

        var response = await _client.Messages.SendAsync(parameters);

        Assert.True(response.Success);
        Assert.Equal(new List<string> { "m1", "m2" }, response.Data.MessageIds);
        Assert.Equal("queued", response.Data.Status);
        Assert.Equal(HttpMethod.Post, _handler.LastRequest?.Method);
        Assert.Equal("https://api.notifique.dev/v1/templates/send", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task SendAsync_ApiError_ThrowsException()
    {
        _handler.SetResponse(HttpStatusCode.BadRequest, "{\"error\":\"Template not found\"}");

        var parameters = new MessagesSendParams
        {
            To = new List<string> { "5511999999999" },
            Template = "nonexistent",
            Channels = new List<string> { "whatsapp" },
            InstanceId = "inst-1"
        };

        var ex = await Assert.ThrowsAsync<NotifiqueApiException>(() => _client.Messages.SendAsync(parameters));

        Assert.Equal(400, ex.StatusCode);
        Assert.Contains("Template not found", ex.ResponseBody);
    }
}
