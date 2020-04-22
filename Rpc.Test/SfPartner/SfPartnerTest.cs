using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Compeng.PEQP.Dto.SfPartner;
using Compeng.PEQP.GrpcService;
using Compeng.PEQP.Service.HttpClients.SfPartner;
using Compeng.PEQP.Util.Security;
using Xunit;
using Xunit.Abstractions;

namespace Compeng.PEQP.Test.SfPartner
{
    public class SfPartnerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _testOutputHelper;

        public SfPartnerTest(WebApplicationFactory<Startup> factory, ITestOutputHelper testOutputHelper)
        {
            _factory = factory;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task TestGetWaybillInfoAsync()
        {
            var sfPartnerHttpClient = _factory.Services.GetRequiredService<SfPartnerHttpClient>();
            var waybillInfoAsync = await sfPartnerHttpClient.GetWaybillInfoAsync(new WaybillInfoRequest
            {
                WaybillNo = "190559581174"
            });
            _testOutputHelper.WriteLine(waybillInfoAsync.ToString());
        }

        [Fact]
        public void TestAes()
        {
            var s = "{'api':'get_waybill_info','partner_id':'WLYCUXX2','waybill_no':'992220289901','lang_code':'1'}";
            var encrpt = s.Encrypt();

            var s1 = "bKSiRF6DEd6yoA0SBM7F0zIP74xREnLHYzXQNH7QwkgncvViSBZR9dUykvnGGIuhzXD33Apsycyw\r\nSIX4hxOKLWa978CqfnuLR4QzKfYfY6xDqEiat7mlT/kWgpvOxT0W";
            var decrpt = s1.Decrypt();
           
            Assert.Equal(s, decrpt);
        }
    }
}