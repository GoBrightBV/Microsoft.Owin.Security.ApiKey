using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.ApiKey.Contexts
{
    /// <summary>
    /// Contains data about the API key provided with the request.
    /// </summary>
    public abstract class ApiKeyContextBase : BaseContext<ApiKeyAuthenticationOptions>
    {
        internal ApiKeyContextBase(IOwinContext context, ApiKeyAuthenticationOptions options, string apiKey)
            : base(context, options)
        {
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// The API key supplied with the request.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Should be set to true if any errors have been generated when building the context.
        /// </summary>
        protected bool HasError { get; set; }
    }
}
