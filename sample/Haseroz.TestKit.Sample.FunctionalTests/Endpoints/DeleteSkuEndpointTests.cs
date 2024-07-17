using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.TestKit.Sample.FunctionalTests.Endpoints;

public class DeleteSkuEndpointTests(WebApplicationFactory<IWebMarker> factory): IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Skus/{0}";
    
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsOkGivenKnowId()
    {
        var id = Guid.Parse("d2e5817a-361a-4c41-bf5b-f3795748b794");
        var response = await _client.DeleteAsync(string.Format(ENDPOINT, id));
        response.Should().BeOK();
    }

    [Fact]
    public async Task ReturnsNotFoundGivenUnknownId()
    {
        var id = Guid.NewGuid();
        var response = await _client.DeleteAsync(string.Format(ENDPOINT, id));
        response.Should().BeNotFound();
    }
}
