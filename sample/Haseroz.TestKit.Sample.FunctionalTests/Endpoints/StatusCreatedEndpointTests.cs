using FluentAssertions;
using Haseroz.TestKit.FluentAssertions.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.TestKit.Sample.FunctionalTests.Endpoints;

public class StatusCreatedEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/Created";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsCreated()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeCreated();
        response.Headers.Should().HaveLocation("/Status/Created/1");
    }
}
