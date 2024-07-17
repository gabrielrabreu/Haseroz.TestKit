using Bogus;
using FluentAssertions;
using System.Net;

namespace Haseroz.TestKit.UnitTests.FluentAssertions.Extensions;

public class HttpResponseMessageAssertionsExtensionsTests
{
    private readonly Faker _faker;

    public HttpResponseMessageAssertionsExtensionsTests()
    {
        _faker = new Faker();
    }

    #region BeOK
    [Fact]
    public void BeOK_WhenStatusCodeIsOK_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.OK);

        // Act & Assert
        response.Invoking(r => r.Should().BeOK()).Should().NotThrow();
    }

    [Fact]
    public void BeOK_WhenStatusCodeIsNotOK_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.OK));

        // Act & Assert
        response.Invoking(r => r.Should().BeOK()).Should().Throw<Exception>();
    }
    #endregion
}
