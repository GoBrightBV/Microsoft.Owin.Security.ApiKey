using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.ApiKey.Contexts;

namespace Microsoft.Owin.Security.ApiKey
{
    /// <summary>
    /// Default implementation of ApiKeyAuthenticationProvider used by the API key authentication
    /// middleware to communicate with the web application while processing requests.
    /// ApiKeyAuthenticationProvider provides some default behaviour, may be used as a virtual base
    /// class, and offers delegate properties which may be used to handle individual calls without
    /// declaring a new class type.
    /// </summary>
    public class ApiKeyAuthenticationProvider
    {
        /// <summary>
        /// Called to generate a set of claims to represent the user to whom the provided API key belongs.
        /// </summary>
        public Func<ApiKeyGenerateClaimsContext, Task<IEnumerable<Claim>>> OnGenerateClaims { get; set; }

        /// <summary>
        /// Called to validate that the API key supplied with the request is considered by your
        /// application to be a valid API key. The application MUST implement this call.
        /// </summary>
        public Func<ApiKeyValidateIdentityContext, Task> OnValidateIdentity { get; set; }

        /// <summary>
        /// Implements the interface method by invoking the related delegate method.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Claim>> GenerateClaims(ApiKeyGenerateClaimsContext context)
        {
            var claims = new Collection<Claim>();

            claims.Add(new Claim(ClaimTypes.AuthenticationMethod, context.Options.AuthenticationType));

            if (this.OnGenerateClaims != null)
            {
                foreach (var claim in await this.OnGenerateClaims(context))
                {
                    claims.Add(claim);
                }
            }

            return claims;
        }

        /// <summary>
        /// Implements the interface method by invoking the related delegate method.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual async Task ValidateIdentity(ApiKeyValidateIdentityContext context)
        {
            if (this.OnValidateIdentity == null)
            {
                throw new ArgumentNullException(nameof(this.OnValidateIdentity), "You must pass a delegate to OnValidateIdentity in order to validate your incoming API keys.");
            }

            await this.OnValidateIdentity(context);
        }
    }
}
