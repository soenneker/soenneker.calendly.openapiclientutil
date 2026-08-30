[![](https://img.shields.io/nuget/v/soenneker.calendly.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.calendly.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.calendly.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.calendly.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.calendly.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.calendly.openapiclientutil/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.calendly.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.calendly.openapiclientutil/)

# Soenneker.Calendly.OpenApiClientUtil

Provides a lazily created Calendly Kiota client backed by the configured cached `HttpClient`.

## Installation

```bash
dotnet add package Soenneker.Calendly.OpenApiClientUtil
```

## Configuration

```json
{
  "Calendly": {
    "ApiKey": "your-personal-access-token"
  }
}
```

The default authorization value is `Bearer {token}`. `Calendly:ClientBaseUrl`, `Calendly:AuthHeaderName`, and `Calendly:AuthHeaderValueTemplate` are available for compatible gateways or alternate credentials.

## Registration and usage

```csharp
using Soenneker.Calendly.OpenApiClient;
using Soenneker.Calendly.OpenApiClient.Models;
using Soenneker.Calendly.OpenApiClientUtil.Abstract;
using Soenneker.Calendly.OpenApiClientUtil.Registrars;

services.AddCalendlyOpenApiClientUtilAsScoped();

public sealed class CalendlyService(ICalendlyOpenApiClientUtil clientUtil)
{
    public async Task<GetCurrentUser200Response?> GetCurrentUser(CancellationToken cancellationToken)
    {
        CalendlyOpenApiClient client = await clientUtil.Get(cancellationToken);
        return await client.Users.Me.GetAsync(cancellationToken: cancellationToken);
    }
}
```

The scoped utility releases its own cached generated client with the consuming scope. Its registered HTTP provider is singleton and remains alive until application shutdown. Use singleton utility registration when one utility instance should be shared application-wide.
