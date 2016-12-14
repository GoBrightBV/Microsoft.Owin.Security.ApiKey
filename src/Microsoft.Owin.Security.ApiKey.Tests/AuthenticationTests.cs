using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Owin.Security.ApiKey.Web;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Owin.Security.ApiKey.Tests
{
    [TestClass]
    public class AuthenticationTests
    {
        private TestServer api;

        [TestInitialize]
        public void Initialize()
        {
            this.api = TestServer.Create<Startup>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.api.Dispose();
        }

        [TestMethod]
        public async Task WebRequest_Anonymous_Authentication_Should_Yield_401()
        {
            var response = await this.api.HttpClient.GetAsync("/api/values");

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task WebRequest_ApiKey_Authentication_Should_Yield_200()
        {
            var response = await this.api.CreateRequest("/api/values").AddHeader("Authorization", "ApiKey 123").GetAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
