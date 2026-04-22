using Soenneker.Calendly.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Calendly.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CalendlyOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ICalendlyOpenApiClientUtil _openapiclientutil;

    public CalendlyOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ICalendlyOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
