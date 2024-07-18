using Haseroz.TestKit.FluentAssertions.Customs;
using System.Net.Http.Headers;

namespace Haseroz.TestKit.FluentAssertions.Extensions;

public static class HttpResponseHeadersAssertionsExtensions
{
    public static HttpResponseHeadersAssertions Should(this HttpResponseHeaders instance)
    {
        return new(instance);
    }
}
