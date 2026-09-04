using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Calendly.HttpClients.Abstract;
using Soenneker.Calendly.OpenApiClientUtil.Abstract;
using Soenneker.Calendly.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Calendly.OpenApiClientUtil;

/// <inheritdoc cref="ICalendlyOpenApiClientUtil" />
public sealed class CalendlyOpenApiClientUtil : ICalendlyOpenApiClientUtil
{
    private readonly AsyncSingleton<CalendlyOpenApiClient> _client;

    public CalendlyOpenApiClientUtil(ICalendlyOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<CalendlyOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token)
                                                        .NoSync();

            var apiKey = configuration.GetValueStrict<string>("Calendly:ApiKey");
            string authHeaderName = configuration["Calendly:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["Calendly:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(authHeaderName, authHeaderValue), httpClient: httpClient);

            return new CalendlyOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<CalendlyOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
