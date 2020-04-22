using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Model.ExpressInferceModels.ShunFeng;
using Compeng.PEQP.Service.HttpClients.ShunFeng;
using Compeng.PEQP.Service.IServices.IExpressLogisticsQueryService;

namespace Compeng.PEQP.Service.Serices.ExpressLogisticsQueryService
{
    public class ShunFengLogisticsQueryService : IExpressLogisiticsQueryService
    {
        private readonly ShunFengHttpClient _shunFengHttpClient;
        private readonly ILogger<ShunFengLogisticsQueryService> _loger;
        private readonly ShunFengApiConfig _shunFengApiConfig;

        public ShunFengLogisticsQueryService(ShunFengHttpClient shunFengHttpClient, ILogger<ShunFengLogisticsQueryService> loger, ShunFengApiConfig shunFengApiConfig)
        {
            _shunFengApiConfig = shunFengApiConfig;
            _shunFengHttpClient = shunFengHttpClient;
            _loger = loger;
        }

        public async Task<ExpressQueryLogisticInfoResponse> QueryLogisticInfoAsync(ExpressQueryLogisticInfoRequest request)
        {

            var queryResponse = BuildShunFengQueryLogisticRequest(request, out string requestDataStr);
            if (!queryResponse.Success) return queryResponse;
            queryResponse = await _shunFengHttpClient.GetQueryLogisticInfoAsync(requestDataStr);
            if (queryResponse.Success)
            {
                queryResponse.OrderCode = request.OrderCode;
                queryResponse.ShipperCode = request.ShipperCode.ToString();
                queryResponse.LogisticCode = request.LogisticCode;
            }
            return queryResponse;
        }
        private ExpressQueryLogisticInfoResponse BuildShunFengQueryLogisticRequest(ExpressQueryLogisticInfoRequest request, out string requestDataStr)
        {
            var queryResponse = new ExpressQueryLogisticInfoResponse()
            {
                Success = true,
                ResultCode = ExpressInterfaceResponseStatusCode.Success
            };
            string clientCode = _shunFengApiConfig.ClientCode;//SFQiaoContext.Instance.ClientCode
            var trackingType = !string.IsNullOrEmpty(request.LogisticCode) ? 1 : 2;
            var trackingNumber = trackingType == 1 ? request.LogisticCode : request.OrderCode;
            string[] xmls =
            {
                    "<Request service='RouteService' lang='zh-CN'>",
                    $"<Head>{clientCode}</Head>",
                    "<Body>",
                    "<RouteRequest",
                    $" tracking_type='{trackingType}'",
                    " method_type='1'",
                    $" tracking_number='{trackingNumber}'",
                    $" check_phoneNo='{request.CustomerName}'",
                    " />",
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
                    //reqXml += "\r\n" + s;
                }
            }
            requestDataStr = stringBuilder.ToString();
            return queryResponse;
        }
    }


}
