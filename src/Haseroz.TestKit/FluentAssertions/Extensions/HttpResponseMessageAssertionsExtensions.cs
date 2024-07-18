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
    public static AndConstraint<HttpResponseMessageAssertions> HaveLocation(
        this HttpResponseMessageAssertions parent,
        string expected,
        string because = "",
        params object[] becauseArgs)
    {
        var success = Execute.Assertion
            .ForCondition(parent.Subject is not null)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected Location to be {0}{reason}, but HttpResponseMessage was <null>.", expected);

        if (success)
            Execute.Assertion
                .ForCondition(parent.Subject!.Headers.Location?.OriginalString == expected)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected Location to be {0}{reason}, but found {1}.", expected, parent.Subject.Headers.Location);

        return new AndConstraint<HttpResponseMessageAssertions>(parent);
    }
}
