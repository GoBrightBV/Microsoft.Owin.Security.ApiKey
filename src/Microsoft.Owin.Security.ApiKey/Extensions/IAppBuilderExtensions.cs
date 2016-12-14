using System;
using Microsoft.Owin.Extensions;
using Owin;

namespace Microsoft.Owin.Security.ApiKey
{
    /// <summary>
    /// Extension methods to add API key authentication capabilities to an OWIN pipeline.
    /// </summary>
    public static class IAppBuilderExtensions
    {
        /// <summary>
        /// Configures an Owin application to use API key authentication; the API key should be
        /// provided in the authorization header on every request, e.g. <c>'Authorization: ApiKey 123'</c>.
        /// </summary>
        /// <param name="app">The web application builder</param>
        /// <param name="options">Options which control the behaviour of the authentication middleware</param>
        /// <returns></returns>
        public static IAppBuilder UseApiKeyAuthentication(this IAppBuilder app, ApiKeyAuthenticationOptions options = null)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                options = new ApiKeyAuthenticationOptions();
            }

            app.Use<ApiKeyAuthenticationMiddleware>(app, options);
            app.UseStageMarker(PipelineStage.Authenticate);

            return app;
        }
    }
}
