namespace Microsoft.Owin.Security.ApiKey.Contexts
{
    /// <summary>
    /// Contains data about the API key provided with the request.
    /// </summary>
    public sealed class ApiKeyValidateIdentityContext : ApiKeyContextBase
    {
        internal ApiKeyValidateIdentityContext(IOwinContext context, ApiKeyAuthenticationOptions options, string apiKey)
            : base(context, options, apiKey)
        { }

        /// <summary>
        /// True if application code has called any of the Validate methods on this context.
        /// </summary>
        public bool IsValidated { get; private set; }

        /// <summary>
        /// Marks this context as validated by the application. IsValidated becomes true and HasError
        /// becomes false as a result of calling.
        /// </summary>
        public void Validate()
        {
            this.IsValidated = true;
            this.HasError = false;
        }
    }
}
