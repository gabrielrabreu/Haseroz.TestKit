using FluentAssertions;
using Haseroz.TestKit.FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.TestKit.Sample.FunctionalTests.Endpoints;

public class StatusUnprocessableEntityEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/UnprocessableEntity";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsUnprocessableEntity()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeUnprocessableEntity();
    }
}
