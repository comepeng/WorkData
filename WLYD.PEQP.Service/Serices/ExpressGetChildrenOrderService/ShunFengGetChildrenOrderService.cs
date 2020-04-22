using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Model.ExpressInferceModels.ShunFeng;
using Compeng.PEQP.Service.HttpClients.ShunFeng;
using Compeng.PEQP.Service.IServices.IExpressGetChildrenOrderService;

namespace Compeng.PEQP.Service.Serices.ExpressGetChildrenOrderService
{
    public class ShunFengGetChildrenOrderService : IExpressGetChildrenOrderLogisticsNo
    {
        private readonly ShunFengApiConfig _shunFengApiConfig;
        private readonly ShunFengHttpClient _shunFengHttpClient;
        private readonly ILogger<ShunFengGetChildrenOrderService> _loger;

        public ShunFengGetChildrenOrderService(ShunFengApiConfig shunFengApiConfig, ShunFengHttpClient shunFengHttpClient, ILogger<ShunFengGetChildrenOrderService> loger)
        {
            _shunFengApiConfig = shunFengApiConfig;
            _shunFengHttpClient = shunFengHttpClient;
            _loger = loger;
        }

        public async Task<ExpressGetChildrenOrderLogisticsNoResponse> GetChildrenOrderLogisticsNoAsync(ExpressGetChildrenOrderLogisticsNoRequest request)
        {

            var response = buildChildrenOrderRequestStr(request, out string requestXml);
            if (!response.Success) return response;
            return await _shunFengHttpClient.GetChildrenOrderLogisticsNoAsync(requestXml);

        }

        private ExpressGetChildrenOrderLogisticsNoResponse buildChildrenOrderRequestStr(ExpressGetChildrenOrderLogisticsNoRequest request, out string requestXml)
        {
            var response = new ExpressGetChildrenOrderLogisticsNoResponse();
            if (request.ParcelQuantity < 1)
            {
                response.Success = false;
                response.Reason = "申请包裹数须大于0";
                response.ResultCode = Model.ExpressInferceModels.Enums.ExpressInterfaceResponseStatusCode.ValidationFail;
                requestXml = string.Empty;
                return response;
            }
            string clientCode = _shunFengApiConfig.ClientCode;
            string[] xmls =
                {
                    "<Request service='OrderZDService' lang='zh-CN'>",
                   $"<Head>{clientCode}</Head>",
                    "<Body>",
                    "<OrderZD",
                    $" orderid='{request.OrderCode}'",
                    $" parcel_quantity='{request.ParcelQuantity}'",
                    " />",
                    "</Body>",
                    "</Request>"
                };
            StringBuilder stringBuilder = new StringBuilder();
            var reqXml = "";
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
                }
            }
            response.Success = true;
            requestXml = stringBuilder.ToString();
            return response;            
        }
    }
}
