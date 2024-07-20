using FluentAssertions;
using Haseroz.TestKit.FluentAssertions;
using Haseroz.TestKit.Sample.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Haseroz.TestKit.Sample.FunctionalTests.Endpoints;

public class StatusOKEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/OK";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsOK()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeOK();

        var content = await response.Content.ReadFromJsonAsync<ModelExample>();
        content.Should().NotBeNull().And.Satisfy<ModelExample>(x => x.Name.Should().Be("Name1"));
    }
}
