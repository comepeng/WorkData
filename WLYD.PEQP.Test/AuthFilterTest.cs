using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Util.Json;
using Compeng.PEQP.Util.Security;
using Compeng.PEQP.WebAPI;
using Xunit;
using Xunit.Abstractions;
using Compeng.PEQP.Util.Extensions;
using System.Threading.Tasks;

namespace Compeng.PEQP.Test
{
    public class AuthFilterTest:IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _httpClient;

        public AuthFilterTest(WebApplicationFactory<Startup> factory, ITestOutputHelper testOutputHelper)
        {
            _factory = factory;
            _testOutputHelper = testOutputHelper;
            _httpClient = factory.CreateClient();
        }
        /// <summary>
        /// 数字签名测试 dataSign = MD5(AppKey+要传输的数据)
        /// </summary>
        /// <returns></returns>
        [Fact/*(Skip ="unix时间戳")*/]
        public async System.Threading.Tasks.Task Test_AuthFilterAsync()
        {
            //"OrderCode": "",
            //            "ShipperCode": 0,
            //"LogisticCode": "14450814126",
            //"CustomerName":"222"
            string url = "wlydexpressapi/QueryLogisticInfo";
            var data = new GetLogisticsRequest();
            data.OrderCode = string.Empty;
            data.LogisticCode = "YT2027429251365";
            data.ShipperCode ="YTO";
            data.CustomerName = string.Empty;
            string dataStr = data.ToJson();
            StringContent stringContent = new StringContent(dataStr, Encoding.UTF8);
            stringContent.Headers.Add("AppId","Compeng");
            stringContent.Headers.Add("AppKey", "hello.50yc.com");
            string dataSign = MD5Encryption.MD5("hello.50yc.com" + dataStr);
            stringContent.Headers.Add("Sinature", dataSign);
            stringContent.Headers.Add("RequestId", Guid.NewGuid().ToString());
            stringContent.Headers.Add("RequestTimestamp", DateTime.Now.ToUnixTimestamplong().ToString());
            var headerType = new MediaTypeHeaderValue("application/json");
            headerType.CharSet = "UTF-8";
            stringContent.Headers.ContentType = headerType;
            var response = await _httpClient.PostAsync(url, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(content);
            bool flag = content.Contains("true");
            Assert.True(flag);
           

        }
   
    }
}
