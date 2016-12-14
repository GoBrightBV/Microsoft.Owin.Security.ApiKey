namespace Microsoft.Owin.Security.ApiKey.Contexts
{
    /// <summary>
    /// Contains data about the API key provided with the request in order to construct an identity
    /// for the requester.
    /// </summary>

    public sealed class ApiKeyGenerateClaimsContext : ApiKeyContextBase
    {
        internal ApiKeyGenerateClaimsContext(IOwinContext context, ApiKeyAuthenticationOptions options, string apiKey)
            : base(context, options, apiKey)
        { }
    }
}
