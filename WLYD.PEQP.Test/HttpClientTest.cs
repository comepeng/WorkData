using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

using Compeng.PEQP.WebAPI;
using Xunit;
using Xunit.Abstractions;

namespace Compeng.PEQP.Test
{
    public class HttpClientTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _httpClient;

        public HttpClientTest(ITestOutputHelper testOutputHelper, WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
            _testOutputHelper = testOutputHelper;
            _factory = factory;
        }

        [Fact(Skip = "验证相同类型httpClient的handler共享")]
        public void TestHttpClient_not_equal()
        {
//            var deBangHttpClient = _factory.Services.GetRequiredService<DeBangHttpClient>();
//            var baiShiHttpClient = _factory.Services.GetRequiredService<BaiShiHttpClient>();
//            var deBangHttpClient2 = _factory.Services.GetRequiredService<DeBangHttpClient>(); 
//            var baiShiHttpClient2 = _factory.Services.GetRequiredService<BaiShiHttpClient>();
//            Assert.NotEqual(deBangHttpClient.GetHashCode(),baiShiHttpClient.GetHashCode());
        }
    }
}