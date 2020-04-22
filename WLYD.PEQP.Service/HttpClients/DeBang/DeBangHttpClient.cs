using Microsoft.Extensions.Logging;
using System.Net.Http;
using Compeng.PEQP.Model.ExpressInferceModels.YTO.Response;
using Compeng.PEQP.Service.HttpClients.YuanTong;

namespace Compeng.PEQP.Service.HttpClients.DeBang
{
    public class DeBangHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<YuanTongHttpClient> _logger;
        public DeBangHttpClient(HttpClient httpClient, ILoggerFactory loggerFactory)
        {
            _httpClient = httpClient;
             _logger = loggerFactory.CreateLogger<YuanTongHttpClient>();
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
