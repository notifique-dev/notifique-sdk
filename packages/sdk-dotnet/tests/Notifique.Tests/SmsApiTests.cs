using System.Net;
using Xunit;
using Notifique.Models.Sms;
using Notifique.Tests.Helpers;

namespace Notifique.Tests;

public class SmsApiTests
{
    private readonly MockHttpMessageHandler _handler = new();
    private readonly NotifiqueClient _client;

    public SmsApiTests()
    {
        _client = new NotifiqueClient("test-api-key", "https://api.notifique.dev/v1", new HttpClient(_handler));
    }

    [Fact]
    public async Task SendAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"status\":\"queued\",\"count\":1,\"smsIds\":[\"sms-1\"]}}");

        var parameters = new SmsSendParams
        {
            To = new List<string> { "5511999999999" },
            Message = "Test SMS"
        };

        var response = await _client.Sms.SendAsync(parameters);

        Assert.True(response.Success);
        Assert.Equal(new List<string> { "sms-1" }, response.Data.SmsIds);
        Assert.Equal("queued", response.Data.Status);
        Assert.Equal(HttpMethod.Post, _handler.LastRequest?.Method);
        Assert.Equal("https://api.notifique.dev/v1/sms/messages", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task GetAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"smsId\":\"sms-1\",\"status\":\"delivered\"}}");

        var response = await _client.Sms.GetAsync("sms-1");

        Assert.Equal("sms-1", response.Data.SmsId);
        Assert.Equal("delivered", response.Data.Status);
    }

    [Fact]
    public async Task CancelAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"smsId\":\"sms-1\",\"status\":\"cancelled\"}}");

        var response = await _client.Sms.CancelAsync("sms-1");

        Assert.True(response.Success);
        Assert.Equal("sms-1", response.Data.SmsId);
        Assert.Equal("cancelled", response.Data.Status);
    }

    [Fact]
    public async Task SendAsync_ApiError_ThrowsException()
    {
        _handler.SetResponse(HttpStatusCode.Unauthorized, "{\"error\":\"Unauthorized\"}");

        var parameters = new SmsSendParams
        {
            To = new List<string> { "123" },
            Message = "Test"
        };

        var ex = await Assert.ThrowsAsync<NotifiqueApiException>(() => _client.Sms.SendAsync(parameters));

        Assert.Equal(401, ex.StatusCode);
    }
}
