using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Service.IServices.IExpressCancelOrderService;

namespace Compeng.PEQP.Service.Serices.ExpressCancelOrderService
{
    public class YuanTongCancelOrderService : IExpressCancelOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<YuanTongCancelOrderService> _loger;
        public YuanTongCancelOrderService(ILoggerFactory loggerFactory, HttpClient httpClient)
        {
            _loger = loggerFactory.CreateLogger<YuanTongCancelOrderService>();
            _httpClient = httpClient;
        }
        public async Task<ExpressBackResponse> CancelOrderAsync(ExpressCancelOrderRequest request)
        {
            var response = new ExpressBackResponse();
            StringBuilder xmlStrBuilder = new StringBuilder();
            xmlStrBuilder.Append($"<?xml version=\"1.0\" ?><UpdateInfo><logisticProviderID>YTO</logisticProviderID>")
                .Append($"<clientID>{request.CustomerName}</clientID><txLogisticID>{request.OrderCode}</txLogisticID>")
                .Append($"<infoType>INSTRUCTION</infoType><infoContent>WITHDRAW</infoContent></UpdateInfo>");
            var xmlStr = xmlStrBuilder.ToString();
            throw new System.NotImplementedException();
        }
    }
}
