using System.Net;
using System.Text.Json;
using Xunit;
using Notifique.Models.Email;
using Notifique.Tests.Helpers;

namespace Notifique.Tests;

public class EmailDomainsApiTests
{
    private readonly MockHttpMessageHandler _handler = new();
    private readonly NotifiqueClient _client;

    public EmailDomainsApiTests()
    {
        _client = new NotifiqueClient("test-api-key", "https://api.notifique.dev/v1", new HttpClient(_handler));
    }

    [Fact]
    public async Task ListAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":[{\"id\":\"dom-1\",\"domain\":\"example.com\",\"status\":\"VERIFIED\",\"dnsRecords\":[],\"verifiedAt\":\"2025-01-01T00:00:00Z\",\"createdAt\":\"2025-01-01T00:00:00Z\",\"updatedAt\":\"2025-01-01T00:00:00Z\"}]}");
        var response = await _client.EmailDomains.ListAsync();
        Assert.True(response.Success);
        Assert.Single(response.Data);
        Assert.Equal("dom-1", response.Data[0].Id);
        Assert.Equal("example.com", response.Data[0].Domain);
        Assert.Equal("VERIFIED", response.Data[0].Status);
        Assert.Equal(HttpMethod.Get, _handler.LastRequest?.Method);
        Assert.Equal("https://api.notifique.dev/v1/email/domains", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task CreateAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"id\":\"dom-1\",\"domain\":\"example.com\",\"status\":\"PENDING\",\"dnsRecords\":[{\"type\":\"TXT\",\"name\":\"_dmarc.example.com\",\"value\":\"v=DMARC1\"}],\"createdAt\":\"2025-01-01T00:00:00Z\"},\"message\":\"Add DNS records and verify.\"}");
        var request = new CreateEmailDomainRequest { Domain = "example.com" };
        var response = await _client.EmailDomains.CreateAsync(request);
        Assert.True(response.Success);
        Assert.Equal("example.com", response.Data.Domain);
        Assert.Equal("PENDING", response.Data.Status);
        Assert.NotNull(response.Message);
        Assert.NotNull(_handler.LastRequestBody);
        using var doc = JsonDocument.Parse(_handler.LastRequestBody!);
        Assert.Equal("example.com", doc.RootElement.GetProperty("domain").GetString());
    }

    [Fact]
    public async Task GetAsync_Success()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"id\":\"dom-1\",\"domain\":\"example.com\",\"status\":\"VERIFIED\",\"dnsRecords\":[],\"verifiedAt\":\"2025-01-01T00:00:00Z\",\"createdAt\":\"2025-01-01T00:00:00Z\",\"updatedAt\":\"2025-01-01T00:00:00Z\"}}");
        var response = await _client.EmailDomains.GetAsync("dom-1");
        Assert.True(response.Success);
        Assert.Equal("dom-1", response.Data.Id);
        Assert.Equal("example.com", response.Data.Domain);
    }

    [Fact]
    public async Task VerifyAsync_Success_AndVerifiedTrue()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"id\":\"dom-1\",\"domain\":\"example.com\",\"status\":\"VERIFIED\",\"dnsRecords\":[],\"verifiedAt\":\"2025-01-01T00:00:00Z\"},\"verified\":true}");
        var response = await _client.EmailDomains.VerifyAsync("dom-1");
        Assert.True(response.Success);
        Assert.True(response.Verified);
        Assert.Equal("VERIFIED", response.Data?.Status);
        Assert.Equal(HttpMethod.Post, _handler.LastRequest?.Method);
        Assert.Equal("https://api.notifique.dev/v1/email/domains/dom-1/verify", _handler.LastRequest?.RequestUri?.ToString());
    }

    [Fact]
    public async Task VerifyAsync_NotYetVerified()
    {
        _handler.SetResponse(HttpStatusCode.OK, "{\"success\":true,\"data\":{\"id\":\"dom-1\",\"domain\":\"example.com\",\"status\":\"PENDING\",\"dnsRecords\":[{\"type\":\"TXT\",\"name\":\"_dmarc.example.com\",\"value\":\"v=DMARC1\"}]},\"verified\":false}");
        var response = await _client.EmailDomains.VerifyAsync("dom-1");
        Assert.True(response.Success);
        Assert.False(response.Verified);
    }
}
