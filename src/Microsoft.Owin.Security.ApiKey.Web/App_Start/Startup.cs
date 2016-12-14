using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.ApiKey.Contexts;
using Owin;

[assembly: OwinStartup(typeof(Microsoft.Owin.Security.ApiKey.Web.Startup))]

namespace Microsoft.Owin.Security.ApiKey.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseApiKeyAuthentication(new ApiKeyAuthenticationOptions()
            {
                Provider = new ApiKeyAuthenticationProvider()
                {
                    OnValidateIdentity = this.ValidateApiKey,
                    OnGenerateClaims = this.GenerateClaims
                }
            });

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }

        private async Task<IEnumerable<Claim>> GenerateClaims(ApiKeyGenerateClaimsContext context)
            => new[] { new Claim(ClaimTypes.Name, "Fred") };

        private async Task ValidateApiKey(ApiKeyValidateIdentityContext context)
        {
            if (context.ApiKey == "123")
            {
                context.Validate();
            }
        }
    }
}
