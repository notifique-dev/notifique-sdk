using System.Net;
using Xunit;
using Notifique.Models.Email;
using Notifique.Tests.Helpers;

namespace Notifique.Tests;

public class EmailApiTests
{
    private readonly MockHttpMessageHandler _handler = new();
    private readonly NotifiqueClient _client;

    public EmailApiTests()
    {
        _client = new NotifiqueClient("test-api-key", "https://api.notifique.dev/v1", new HttpClient(_handler));
    }

    [Fact]
    public async Task SendAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"emailIds\":[\"email-1\"],\"status\":\"queued\",\"count\":1}}");

        var parameters = new EmailSendParams
        {
            From = "noreply@example.com",
            To = new List<string> { "user@example.com" },
            Subject = "Test",
            Text = "Body"
        };

        var response = await _client.Email.SendAsync(parameters);

        Assert.True(response.Success);
        Assert.Equal(new List<string> { "email-1" }, response.Data.EmailIds);
        Assert.Equal("queued", response.Data.Status);
        Assert.Equal(HttpMethod.Post, _handler.LastRequest?.Method);
        Assert.Equal("https://api.notifique.dev/v1/email/messages", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task GetAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"id\":\"email-1\",\"to\":\"user@example.com\",\"from\":\"noreply@example.com\",\"subject\":\"Test\",\"status\":\"delivered\"}}");

        var response = await _client.Email.GetAsync("email-1");

        Assert.Equal("email-1", response.Data.Id);
        Assert.Equal("delivered", response.Data.Status);
    }

    [Fact]
    public async Task CancelAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"emailId\":\"email-1\",\"status\":\"cancelled\"}}");

        var response = await _client.Email.CancelAsync("email-1");

        Assert.True(response.Success);
        Assert.Equal("email-1", response.Data.EmailId);
        Assert.Equal("cancelled", response.Data.Status);
    }

    [Fact]
    public async Task SendAsync_ApiError_ThrowsException()
    {
        _handler.SetResponse(HttpStatusCode.TooManyRequests, "{\"error\":\"Rate limit exceeded\"}");

        var parameters = new EmailSendParams
        {
            From = "noreply@example.com",
            To = new List<string> { "user@example.com" },
            Subject = "Test",
            Text = "Body"
        };

        var ex = await Assert.ThrowsAsync<NotifiqueApiException>(() => _client.Email.SendAsync(parameters));

        Assert.Equal(429, ex.StatusCode);
    }
}
