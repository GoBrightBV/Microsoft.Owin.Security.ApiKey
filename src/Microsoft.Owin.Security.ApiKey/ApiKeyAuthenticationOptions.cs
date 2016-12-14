namespace Microsoft.Owin.Security.ApiKey
{
    /// <summary>
    /// Options which control the behaviour of the authentication middleware.
    /// </summary>
    public sealed class ApiKeyAuthenticationOptions : AuthenticationOptions
    {
        /// <summary>
        /// The object provided by the application to process events raised by the API key
        /// authentication middleware. The application must create an instance of
        /// <c>ApiKeyAuthenticationProvider</c> and assign delegates to the mandatory events.
        /// </summary>
        public ApiKeyAuthenticationProvider Provider;

        /// <summary>
        /// Creates an instance of API key authentication options with default values.
        /// </summary>
        public ApiKeyAuthenticationOptions() : base("API Key")
        { }

        /// <summary>
        /// The header that shall contain the authentication data. Defaults to "Authorization".
        /// <para>
        /// An example header using the <see cref="ApiKeyAuthenticationOptions"/> defaults would be:
        /// </para>
        /// <para>Authorization: ApiKey 4fb4e33c83e5d026e8745102b72f10590f48e94af107db15074c799589a4753d</para>
        /// </summary>
        public string Header { get; set; } = "Authorization";

        /// <summary>
        /// The key of the key/value pair that represents the authentication type and its data.
        /// Defaults to "ApiKey".
        /// <para>
        /// An example header using the <see cref="ApiKeyAuthenticationOptions"/> defaults would be:
        /// </para>
        /// <para>Authorization: ApiKey 4fb4e33c83e5d026e8745102b72f10590f48e94af107db15074c799589a4753d</para>
        /// </summary>
        public string HeaderKey { get; set; } = "ApiKey";
    }
}
