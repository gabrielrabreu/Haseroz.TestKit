using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Net;

namespace Haseroz.TestKit.FluentAssertions.Extensions;

public static class HttpResponseMessageAssertionsExtensions
{
    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeOK(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.OK, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeCreated(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.Created, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeBadRequest(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.BadRequest, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeUnauthorized(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.Unauthorized, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeForbidden(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.Forbidden, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeNotFound(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.NotFound, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeConflict(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.Conflict, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeUnprocessableEntity(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.UnprocessableEntity, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeInternalServerError(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.InternalServerError, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> BeServiceUnavailable(
        this HttpResponseMessageAssertions parent,
        string because = "",
        params object[] becauseArgs)
    {
        parent.HaveStatusCode(HttpStatusCode.ServiceUnavailable, because, becauseArgs);
        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }

    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageAssertions> HaveLocation(
        this HttpResponseMessageAssertions parent,
        string location,
        string because = "",
        params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(parent.Subject is not null)
            .FailWith("Expected Location to be {0}{reason}, but HttpResponseMessage was <null>.", location)
            .Then
            .ForCondition(parent.Subject!.Headers.Location?.OriginalString == location)
            .FailWith("Expected Location to be {0}{reason}, but found {1}.", location, parent.Subject.Headers.Location);

        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }
}
