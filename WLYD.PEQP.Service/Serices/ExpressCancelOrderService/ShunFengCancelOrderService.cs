using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Model.ExpressInferceModels.ShunFeng;
using Compeng.PEQP.Service.HttpClients.ShunFeng;
using Compeng.PEQP.Service.IServices.IExpressCancelOrderService;

namespace Compeng.PEQP.Service.Serices.ExpressCancelOrderService
{
    /// <summary>
    /// 顺丰取消订单服务
    /// </summary>
    public class ShunFengCancelOrderService : IExpressCancelOrderService
    {
        private readonly ShunFengHttpClient _shunFengHttpClient;
        private readonly ILogger<ShunFengCancelOrderService> _logger;
        private readonly ShunFengApiConfig _shufengApiConfig;

        public ShunFengCancelOrderService(ShunFengHttpClient shunFengHttpClient,
            ILogger<ShunFengCancelOrderService> logger, ShunFengApiConfig shunFengApiConfig)
        {
            _shunFengHttpClient = shunFengHttpClient;
            _logger = logger;
            _shufengApiConfig = shunFengApiConfig;
        }

        public async Task<ExpressBackResponse> CancelOrderAsync(ExpressCancelOrderRequest request)
        {
            string requestStr = BuildShunfengCancelOrderRequest(request);
            return await _shunFengHttpClient.CancelOrderAsync(requestStr);
        }

        private string BuildShunfengCancelOrderRequest(ExpressCancelOrderRequest request, int dealType = 2)
        {
            string orderCode = request.OrderCode;
            string logisticsCode = request.LogisticCode;
            string clientCode = _shufengApiConfig.ClientCode;
            string[] xmls =
            {
                "<Request service='OrderConfirmService' lang='zh-CN'>",
                $"<Head>{clientCode}</Head>",
                "<Body>",
                "<OrderConfirm",
                $" orderid='{orderCode}'",
                $" mailno='{logisticsCode}'",
                $" dealtype='{dealType}'>",
                "</OrderConfirm>",
                "</Body>",
                "</Request>"
            };
            var reqXml = "";
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var s in xmls)
            {
                if (reqXml == "")
                {
                    reqXml = s;
                    stringBuilder.Append(s);
                }
                else
                {
                    stringBuilder.Append(Environment.NewLine)
                        .Append(s);
                    // reqXml += "\r\n" + s;
                }
            }

            return stringBuilder.ToString();
        }
    }
}