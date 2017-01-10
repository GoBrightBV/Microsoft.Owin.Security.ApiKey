# Microsoft.Owin.Security.ApiKey [![Build status](https://ci.appveyor.com/api/projects/status/uxemt6d3ygjronab/branch/master?svg=true)](https://ci.appveyor.com/project/jamesharling/microsoft-owin-security-apikey/branch/master)
Lets an OWIN-enabled application use API keys for authentication. 

## Getting started
Grab the package from NuGet, which will install all dependencies.

`Install-Package Microsoft.Owin.Security.ApiKey`

## Usage
Extension methods for `IAppBuilder` will enable the middleware. Your custom delegates can be passed to `ApiKeyAuthenticationProvider`; at a minimum, you must implement `OnValidateIdentity` to validate the incoming API keys.
`OnGenerateClaims` is optional; the middleware will always construct an identity with a claim denoting the authentication type, but you have the option of fleshing out the identity with further custom claims if you wish.

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
