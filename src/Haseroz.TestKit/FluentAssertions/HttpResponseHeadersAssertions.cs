using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Net.Http.Headers;

namespace Haseroz.TestKit.FluentAssertions;

public class HttpResponseHeadersAssertions(HttpResponseHeaders subject) :
    ObjectAssertions<HttpResponseHeaders, HttpResponseHeadersAssertions>(subject)
{
    protected override string Identifier => nameof(HttpResponseHeadersAssertions);

    [CustomAssertion]
    public AndConstraint<HttpResponseHeadersAssertions> HaveLocation(
        string expectedLocation,
        string because = "",
        params object[] becauseArgs)
    {
        Execute.Assertion
            .WithDefaultIdentifier(Identifier)
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject.Location?.OriginalString)
            .ForCondition(location => location == expectedLocation)
            .FailWith("Expected {context} to have Location header with value {0}{reason}, but found {1}.", _ => expectedLocation, location => location);

        return new AndConstraint<HttpResponseHeadersAssertions>(this);
    }
}
