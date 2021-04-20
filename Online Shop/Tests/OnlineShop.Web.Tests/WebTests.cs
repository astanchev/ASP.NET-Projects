namespace OnlineShop.Web.Tests
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Testing;

    using Xunit;

    public class WebTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        public WebTests()
        {
        }
    }
}
