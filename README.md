# Microsoft.Owin.Security.ApiKey
Lets an OWIN-enabled application use API keys for authentication. 

## Getting started
Grab the package from NuGet, which will install all dependencies.

`Install-Package Microsoft.Owin.Security.ApiKey`

## Usage
Extension methods for `IAppBuilder` will enable the middleware. Your custom delegates can be passed to `ApiKeyAuthenticationProvider`; at a minimum, you must implement `OnValidateIdentity` to validate the incoming API keys.

```csharp
public void Configuration(IAppBuilder app)
{
    app.UseApiKeyAuthentication(new ApiKeyAuthenticationOptions()
    {
        Provider = new ApiKeyAuthenticationProvider()
        {
            OnValidateIdentity = ValidateIdentity,
            OnGenerateClaims = GenerateClaims
        }
    });
}

private async Task ValidateIdentity(ApiKeyValidateIdentityContext context)
{
    if (context.ApiKey == "123")
    {
        context.Validate();
    }
}

private async Task<IEnumerable<Claim>> GenerateClaims(ApiKeyGenerateClaimsContext context)
{
    return new[] { new Claim(ClaimTypes.Name, "Fred") };
}
```
