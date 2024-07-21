using FluentAssertions;
using Haseroz.TestKit.FluentAssertions;
using Haseroz.TestKit.Sample.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Haseroz.TestKit.Sample.FunctionalTests.Endpoints;

public class StatusOkEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/Ok";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsOk()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeOk();

        var content = await response.Content.ReadFromJsonAsync<ModelExample>();
        content.Should().NotBeNull(); 
        content!.Name.Should().Be("Name1");
    }
}
