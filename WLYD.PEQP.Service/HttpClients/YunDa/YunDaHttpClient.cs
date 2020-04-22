using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Compeng.PEQP.Model.ExpressInferceModels.YTO.Response;

namespace Compeng.PEQP.Service.HttpClients.YunDa
{
    public class YunDaHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<YunDaHttpClient> _logger;
        public YunDaHttpClient(HttpClient httpClient, ILoggerFactory loggerFactory)
        {
            _httpClient = httpClient;
            _logger = loggerFactory.CreateLogger<YunDaHttpClient>();
           
        }
        /// <summary>
        ///  创建电子订单
        /// </summary>
        /// <param name="xmlDataStr">要发送的数据</param>
        /// <returns></returns>
        public async Task<YuanTongOrderResponse> CreateOrder(string xmlDataStr)
        {
            throw new System.Exception();
        }



    }
}
