using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Net.Http.Headers;

namespace Haseroz.TestKit.FluentAssertions.Customs;

public class HttpResponseHeadersAssertions(HttpResponseHeaders subject) :
    ObjectAssertions<HttpResponseHeaders, HttpResponseHeadersAssertions>(subject)
{
    protected override string Identifier => "HTTP response headers";

    [CustomAssertion]
    public AndConstraint<HttpResponseHeadersAssertions> HaveLocation(
        string expectedLocation,
        string because = "",
        params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject.Location?.OriginalString)
            .ForCondition(location => location == expectedLocation)
            .FailWith("Expected {context} to have Location header with value {0}{reason}, but found {1}.", _ => expectedLocation, location => location);

        return new AndConstraint<HttpResponseHeadersAssertions>(this);
    }
}
