﻿using Bogus;
using FluentAssertions;
using Haseroz.TestKit.FluentAssertions;
using System.Net;
using Xunit.Sdk;

namespace Haseroz.TestKit.UnitTests.FluentAssertions;

public class HttpResponseMessageAssertionsExtensionsTests
{
    private readonly Faker _faker = new();

    #region BeOk
    [Fact]
    public void BeOk_WhenStatusCodeIsOk_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.OK);

        // Act & Assert
        response.Invoking(r => r.Should().BeOk()).Should().NotThrow();
    }

    [Fact]
    public void BeOk_WhenStatusCodeIsNotOk_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.OK));

        // Act & Assert
        response.Invoking(r => r.Should().BeOk()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeCreated
    [Fact]
    public void BeCreated_WhenStatusCodeIsCreated_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.Created);

        // Act & Assert
        response.Invoking(r => r.Should().BeCreated()).Should().NotThrow();
    }

    [Fact]
    public void BeCreated_WhenStatusCodeIsNotCreated_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.Created));

        // Act & Assert
        response.Invoking(r => r.Should().BeCreated()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeNoContent
    [Fact]
    public void BeNoContent_WhenStatusCodeIsCreated_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.NoContent);

        // Act & Assert
        response.Invoking(r => r.Should().BeNoContent()).Should().NotThrow();
    }

    [Fact]
    public void BeNoContent_WhenStatusCodeIsNotCreated_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.NoContent));

        // Act & Assert
        response.Invoking(r => r.Should().BeNoContent()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeBadRequest
    [Fact]
    public void BeBadRequest_WhenStatusCodeIsBadRequest_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

        // Act & Assert
        response.Invoking(r => r.Should().BeBadRequest()).Should().NotThrow();
    }

    [Fact]
    public void BeBadRequest_WhenStatusCodeIsNotBadRequest_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.BadRequest));

        // Act & Assert
        response.Invoking(r => r.Should().BeBadRequest()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeNotFound
    [Fact]
    public void BeNotFound_WhenStatusCodeIsNotFound_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.NotFound);

        // Act & Assert
        response.Invoking(r => r.Should().BeNotFound()).Should().NotThrow();
    }

    [Fact]
    public void BeNotFound_WhenStatusCodeIsNotNotFound_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.NotFound));

        // Act & Assert
        response.Invoking(r => r.Should().BeNotFound()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeUnauthorized
    [Fact]
    public void BeUnauthorized_WhenStatusCodeIsUnauthorized_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);

        // Act & Assert
        response.Invoking(r => r.Should().BeUnauthorized()).Should().NotThrow();
    }

    [Fact]
    public void BeUnauthorized_WhenStatusCodeIsNotUnauthorized_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.Unauthorized));

        // Act & Assert
        response.Invoking(r => r.Should().BeUnauthorized()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeForbidden
    [Fact]
    public void BeForbidden_WhenStatusCodeIsForbidden_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.Forbidden);

        // Act & Assert
        response.Invoking(r => r.Should().BeForbidden()).Should().NotThrow();
    }

    [Fact]
    public void BeForbidden_WhenStatusCodeIsNotForbidden_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.Forbidden));

        // Act & Assert
        response.Invoking(r => r.Should().BeForbidden()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeConflict
    [Fact]
    public void BeConflict_WhenStatusCodeIsConflict_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.Conflict);

        // Act & Assert
        response.Invoking(r => r.Should().BeConflict()).Should().NotThrow();
    }

    [Fact]
    public void BeConflict_WhenStatusCodeIsNotConflict_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.Conflict));

        // Act & Assert
        response.Invoking(r => r.Should().BeConflict()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeUnprocessableEntity
    [Fact]
    public void BeUnprocessableEntity_WhenStatusCodeIsUnprocessableEntity_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.UnprocessableEntity);

        // Act & Assert
        response.Invoking(r => r.Should().BeUnprocessableEntity()).Should().NotThrow();
    }

    [Fact]
    public void BeUnprocessableEntity_WhenStatusCodeIsNotUnprocessableEntity_ShouldFail()
    {
        // Arrange
        var items = Enum.GetValues(typeof(HttpStatusCode)).Cast<HttpStatusCode>()
            .Where(code => code != HttpStatusCode.UnprocessableEntity && code != HttpStatusCode.UnprocessableContent);
        var response = new HttpResponseMessage(_faker.PickRandom(items));

        // Act & Assert
        response.Invoking(r => r.Should().BeUnprocessableEntity()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeInternalServerError
    [Fact]
    public void BeInternalServerError_WhenStatusCodeIsInternalServerError_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

        // Act & Assert
        response.Invoking(r => r.Should().BeInternalServerError()).Should().NotThrow();
    }

    [Fact]
    public void BeInternalServerError_WhenStatusCodeIsNotInternalServerError_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.InternalServerError));

        // Act & Assert
        response.Invoking(r => r.Should().BeInternalServerError()).Should().Throw<XunitException>();
    }
    #endregion

    #region BeServiceUnavailable
    [Fact]
    public void BeServiceUnavailable_WhenStatusCodeIsServiceUnavailable_ShouldPass()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);

        // Act & Assert
        response.Invoking(r => r.Should().BeServiceUnavailable()).Should().NotThrow();
    }

    [Fact]
    public void BeServiceUnavailable_WhenStatusCodeIsNotServiceUnavailable_ShouldFail()
    {
        // Arrange
        var response = new HttpResponseMessage(_faker.PickRandomWithout(HttpStatusCode.ServiceUnavailable));

        // Act & Assert
        response.Invoking(r => r.Should().BeServiceUnavailable()).Should().Throw<XunitException>();
    }
    #endregion
}
