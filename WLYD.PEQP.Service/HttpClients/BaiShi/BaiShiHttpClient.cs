using Compeng.PEQP.Model.ExpressInferceModels.YTO.Response;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Compeng.PEQP.Service.HttpClients.BaiShi
{
    public class BaiShiHttpClient
    {
        private readonly ILogger<BaiShiHttpClient> _logger;
        private readonly HttpClient _httpClient;
        public BaiShiHttpClient(HttpClient httpClient, ILoggerFactory loggerFactory)
        {
            _httpClient = httpClient;
            _logger = loggerFactory.CreateLogger<BaiShiHttpClient>();
        }
        /// <summary>
        ///  创建电子订单
        /// </summary>
        /// <param name="xmlDataStr">要发送的数据</param>
        /// <returns></returns>
        public YuanTongOrderResponse CreateOrder(string xmlDataStr)
        {

            throw new System.NotImplementedException();
        }



    }
}
