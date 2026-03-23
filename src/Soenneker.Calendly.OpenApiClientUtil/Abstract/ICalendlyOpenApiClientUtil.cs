using Soenneker.Calendly.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Calendly.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ICalendlyOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<CalendlyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
