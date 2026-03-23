using Soenneker.Calendly.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Calendly.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class CalendlyOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly ICalendlyOpenApiClientUtil _openapiclientutil;

    public CalendlyOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<ICalendlyOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
