using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.ApiKey.Contexts;
using Microsoft.Owin.Security.Infrastructure;

namespace Microsoft.Owin.Security.ApiKey
{
    internal class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            string authorizationHeader = this.Request.Headers.Get(this.Options.Header);

            if (!String.IsNullOrWhiteSpace(authorizationHeader))
            {
                if (authorizationHeader.StartsWith(this.Options.HeaderKey, StringComparison.OrdinalIgnoreCase))
                {
                    string apiKey = authorizationHeader.Substring(this.Options.HeaderKey.Length).Trim();

                    var context = new ApiKeyValidateIdentityContext(this.Context, this.Options, apiKey);

                    await this.Options.Provider.ValidateIdentity(context);

                    if (context.IsValidated)
                    {
                        var claims = await this.Options.Provider.GenerateClaims(new ApiKeyGenerateClaimsContext(this.Context, this.Options, apiKey));

                        var identity = new ClaimsIdentity(claims, this.Options.AuthenticationType);

                        return new AuthenticationTicket(identity, new AuthenticationProperties()
                        {
                            IssuedUtc = DateTime.UtcNow
                        });
                    }
                }
            }

            return null;
        }
    }
}
