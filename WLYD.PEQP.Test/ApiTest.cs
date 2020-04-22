using Compeng.PEQP.Dto.Express.Request;
using Compeng.PEQP.WebAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Compeng.PEQP.Test
{
    public class ApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly string _createOrderUrl = "wlydexpressapi/createorder";
        private readonly string _queryLogisticsInfoUrl = "wlydexpressapi/QueryLogisticInfo";
        private readonly string _getChildrenOrderUrl = "wlydexpressapi/getzdlogisticsno";
        private readonly string _cancelOrderUrl = "wlydexpressapi/cancelorder";
        private readonly string _getWaybillInfo = "wlydexpressapi/getwaybillinfo";
        private readonly HttpClient _httpClient;

        public ApiTest(WebApplicationFactory<Startup> factory, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _httpClient = factory.CreateClient();
        }

        /// <summary>
        /// 创建电子面单接口测试
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [Theory /*(Skip ="测试通过")*/]
        [InlineData("data/YuanTongCreateOrder.json")] //通过
        [InlineData("data/ShunFengCreateOrder.json")] //通过
        [InlineData("data/ZhongTongCreateOrder.json")] //通过
        public async Task Test_CreateOrderAsync(string fileName)
        {
            string data = File.ReadAllText(fileName, Encoding.UTF8);
            var obj = data.ToObj<ElectronicsurfaceRequestDto>();
            obj.OrderCode = RandomNumberStr(10); //注意:当运行多次测试时顺丰会失败,原因是(重复下单)       
            StringContent stringContent = GetRequestContent(obj.ToJson());
            var response = await _httpClient.PostAsync(_createOrderUrl, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            string companyName = fileName.Split('/')[1].Split('.')[0];
            _testOutputHelper.WriteLine($"{companyName}开放平台,===响应内容:{content}");
            bool flag = content.Contains("true");
            Assert.True(flag);
        }

        /// <summary>
        /// 取消订单（支持顺丰）
        /// </summary>
        /// <returns></returns>
        [Fact( /*Skip ="测试通过"*/)]
        public async Task Test_SF_CancelOrder()
        {
            CancelOrderRequestDto request = new CancelOrderRequestDto()
            {
                ShipperCode = "SF",
                OrderCode = "01265701384162",
                LogisticCode = "2323232323"
            };
            StringContent stringContent = GetRequestContent(request.ToJson());
            var response = await _httpClient.PostAsync(_cancelOrderUrl, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine($"{request.ShipperCode}开放平台,****响应内容:{content}");
            bool flag = content.Contains("true");
            Assert.True(flag);
        }

        /// <summary>
        /// 查询物流接口测试
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [Theory /*(Skip = "测试通过")*/]
        [InlineData("YTO", "YT2027606803402")]
        [InlineData("SF", "SF1014613995709", "9046")]
        [InlineData("ZTO", "22222", "")]
        public async Task Test_QueryLogisticsInfo(string expressComanyCode, string logisticscode,
            string customerName = "")
        {
            //顺丰查询物流时客户名不能为空 其实就是手机号
            LogisticInfoRequestDto expressQueryLogisticInfoRequest = new LogisticInfoRequestDto()
            {
                LogisticCode = logisticscode,
                ShipperCode = expressComanyCode,
                CustomerName = customerName
            };
            var str = expressQueryLogisticInfoRequest.ToJson();
            StringContent stringContent = GetRequestContent(str);
            var response = await _httpClient.PostAsync(_queryLogisticsInfoUrl, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine($"{expressComanyCode.ToString()}开放平台,****响应内容:{content}");
            bool flag = content.Contains("true");
            Assert.True(flag);
        }

        /// <summary>
        /// 获取子单号（支持顺丰）
        /// </summary>
        /// <returns></returns>
        [Fact /*(Skip ="通过")*/]
        public async Task Test_Get_SF_ChildrenOrderNo()
        {
            ChildrenOrderLogisticsNoRequestDto request = new ChildrenOrderLogisticsNoRequestDto()
            {
                OrderCode = "01265701384162",
                ParcelQuantity = 2,
                ShipperCode = "SF"
            };
            string requestStr = request.ToJson();
            StringContent stringContent = GetRequestContent(requestStr);
            var response = await _httpClient.PostAsync(_getChildrenOrderUrl, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine($"{request.ShipperCode}开放平台,****响应内容:{content}");
            bool flag = content.Contains("true");
            Assert.True(flag);
        }

        [Fact]
        public async Task Test_getwaybillInfo()
        {
            var request = new GetWaybillInfoRequest
            {
                WaybillNo = 
                    //"387462986456" //失败的情况
                "190559581174" //case 1
                // 191559581174  //case 2
                // 192559581174  //case 3
            };
            var requestStr = request.ToJson();
            var stringContent = GetRequestContent(requestStr);
            
            var response = await _httpClient.PostAsync(_getWaybillInfo, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            var getChildOrderResponse = content.ToObj<GetChildOrderResponse>();
            _testOutputHelper.WriteLine(content);
            _testOutputHelper.WriteLine(getChildOrderResponse.ToString());
        }

        /// <summary>
        /// 添加必要的请求头
        /// </summary>
        /// <param name="dataStr"></param>
        /// <returns></returns>
        private StringContent GetRequestContent(string dataStr)
        {
            StringContent stringContent = new StringContent(dataStr, Encoding.UTF8);
            stringContent.Headers.Add("AppKey", "hello.50yc.com");
            string dataSign = MD5Encryption.MD5("hello.50yc.com" + dataStr);
            stringContent.Headers.Add("Signature", dataSign);
            var headerType = new MediaTypeHeaderValue("application/json");
            headerType.CharSet = "UTF-8";
            stringContent.Headers.ContentType = headerType;
            return stringContent;
        }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="length">随机数字串的长度</param>
        /// <returns></returns>
        public string RandomNumberStr(int length)
        {
            char[] constant =
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            };
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(length);
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(constant[rd.Next(10)]);
            }

            return newRandom.ToString();
        }
    }
}