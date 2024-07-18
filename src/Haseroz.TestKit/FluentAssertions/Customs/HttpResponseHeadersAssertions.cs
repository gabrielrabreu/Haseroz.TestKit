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
        string location,
        string because = "",
        params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject is not null)
            .FailWith("Expected Location to be {0}{reason}, but HttpResponseHeaders was <null>.", location)
            .Then
            .ForCondition(Subject!.Location?.OriginalString == location)
            .FailWith("Expected Location to be {0}{reason}, but found {1}.", location, Subject!.Location);

        return new AndConstraint<HttpResponseHeadersAssertions>(this);
    }
}
