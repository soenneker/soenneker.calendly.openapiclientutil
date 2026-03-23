using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Calendly.HttpClients.Registrars;
using Soenneker.Calendly.OpenApiClientUtil.Abstract;

namespace Soenneker.Calendly.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class CalendlyOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="CalendlyOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCalendlyOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddCalendlyOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ICalendlyOpenApiClientUtil, CalendlyOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="CalendlyOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCalendlyOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddCalendlyOpenApiHttpClientAsSingleton()
                .TryAddScoped<ICalendlyOpenApiClientUtil, CalendlyOpenApiClientUtil>();

        return services;
    }
}
