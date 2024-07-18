using Bogus;
using FluentAssertions;
using Haseroz.TestKit.FluentAssertions.Extensions;
using System.Net;
using Xunit.Sdk;

namespace Haseroz.TestKit.UnitTests.FluentAssertions.Customs;

public class HttpResponseHeadersAssertionsTests
{
    private readonly Faker _faker = new();

    #region HaveLocation
    [Fact]
    public void HaveLocation_WhenHeaderLocationMatch_ShouldPass()
    {
        // Arrange
        var location = _faker.Internet.Url();
        var headers = new HttpResponseMessage(_faker.PickRandom<HttpStatusCode>()).Headers;
        headers.Location = new Uri(location);

        // Act & Assert
        headers.Invoking(h => h.Should().HaveLocation(location)).Should().NotThrow();
    }

    [Fact]
    public void HaveLocation_WhenHeaderLocationIsNull_ShouldFail()
    {
        // Arrange
        var headers = new HttpResponseMessage(_faker.PickRandom<HttpStatusCode>()).Headers;
        headers.Location = null;

        // Act & Assert
        headers.Invoking(h => h.Should().HaveLocation(_faker.Internet.Url())).Should().Throw<XunitException>();
    }

    [Fact]
    public void HaveLocation_WhenHeaderLocationDoesNotMatch_ShouldFail()
    {
        // Arrange
        var headers = new HttpResponseMessage(_faker.PickRandom<HttpStatusCode>()).Headers;
        headers.Location = new Uri(_faker.Internet.Url());

        // Act & Assert
        headers.Invoking(h => h.Should().HaveLocation(_faker.Internet.Url())).Should().Throw<XunitException>();
    }
    #endregion
}
