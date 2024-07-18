using Bogus;
using FluentAssertions;
using Haseroz.TestKit.FluentAssertions.Extensions;
using Haseroz.TestKit.Sample.Core.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;

namespace Haseroz.TestKit.Sample.FunctionalTests.Endpoints;

public class CreateSkuEndpointTests(WebApplicationFactory<IWebMarker> factory): IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Skus";

    private readonly HttpClient _client = factory.CreateClient();
    private readonly Faker _faker = new();

    [Fact]
    public async Task ReturnsCreatedGivenValidRequest()
    {
        var requestDto = new CreateSkuRequestDto()
        {
            Code = _faker.Random.Word(),
            Name = _faker.Commerce.ProductName(),
            Price = _faker.Random.Decimal(min: 0),
            Stock = _faker.Random.Int(min: 0)
        };

        var jsonContent = new StringContent(JsonConvert.SerializeObject(requestDto), Encoding.Default, MediaTypeNames.Application.Json);
        var response = await _client.PostAsync(ENDPOINT, jsonContent);
        response.Should().BeCreated();
    }

    [Fact]
    public async Task ReturnsBadRequestGivenEmptyCode()
    {
        var requestDto = new CreateSkuRequestDto()
        {
            Code = string.Empty,
            Name = _faker.Commerce.ProductName(),
            Price = _faker.Random.Decimal(min: 0),
            Stock = _faker.Random.Int(min: 0)
        };

        var jsonContent = new StringContent(JsonConvert.SerializeObject(requestDto), Encoding.Default, MediaTypeNames.Application.Json);
        var response = await _client.PostAsync(ENDPOINT, jsonContent);
        response.Should().BeBadRequest();
    }

    [Fact]
    public async Task ReturnsConflictGivenExistingCode()
    {
        var requestDto = new CreateSkuRequestDto()
        {
            Code = "SKU001",
            Name = _faker.Commerce.ProductName(),
            Price = _faker.Random.Decimal(min: 0),
            Stock = _faker.Random.Int(min: 0)
        };

        var jsonContent = new StringContent(JsonConvert.SerializeObject(requestDto), Encoding.Default, MediaTypeNames.Application.Json);
        var response = await _client.PostAsync(ENDPOINT, jsonContent);
        response.Should().BeConflict();
    }
}
