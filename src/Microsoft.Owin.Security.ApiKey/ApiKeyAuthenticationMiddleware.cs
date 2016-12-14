using Microsoft.Owin.Security.Infrastructure;
using Owin;

namespace Microsoft.Owin.Security.ApiKey
{
    /// <summary>
    /// OWIN authentication middleware to enable authentication of requests using an API key in the
    /// request's header.
    /// </summary>
    public sealed class ApiKeyAuthenticationMiddleware : AuthenticationMiddleware<ApiKeyAuthenticationOptions>
    {
        /// <summary>
        /// API key authentication middleware component which is added to an OWIN pipeline. This
        /// constructor is not called by application code directly, instead it is added by calling
        /// the IAppBuilder UseApiKeyAuthentication extension method.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="app"></param>
        /// <param name="options"></param>
        public ApiKeyAuthenticationMiddleware(OwinMiddleware next, IAppBuilder app, ApiKeyAuthenticationOptions options)
            : base(next, options)
        { }

        /// <summary>
        /// Called by the AuthenticationMiddleware base class to create a per-request handler.
        /// </summary>
        /// <returns>A new instance of the request handler</returns>
        protected override AuthenticationHandler<ApiKeyAuthenticationOptions> CreateHandler()
            => new ApiKeyAuthenticationHandler();
    }
}
