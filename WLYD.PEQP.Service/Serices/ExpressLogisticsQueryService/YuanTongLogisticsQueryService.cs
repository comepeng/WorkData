using System.Collections.Generic;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Model.ExpressInferceModels.YTO.Response;
using Compeng.PEQP.Service.HttpClients.YuanTong;
using Compeng.PEQP.Service.IServices.IExpressLogisticsQueryService;

namespace Compeng.PEQP.Service.Serices.ExpressLogisticsQueryService
{
    public class YuanTongLogisticsQueryService : IExpressLogisiticsQueryService
    {
        private readonly YuanTongHttpClient _yuanTongHttpClient;
        public YuanTongLogisticsQueryService(YuanTongHttpClient yuanTongHttpClient)
        {
            _yuanTongHttpClient = yuanTongHttpClient;
        }
       
        public async Task<ExpressQueryLogisticInfoResponse> QueryLogisticInfoAsync(ExpressQueryLogisticInfoRequest request)
        
        {
            var queryResponse = new ExpressQueryLogisticInfoResponse()
            {
                Success = true,
                ResultCode =ExpressInterfaceResponseStatusCode.Success
            };
            var xmlStr = $"<?xml version=\"1.0\" ?><ufinterface><Result><WaybillCode><Number>{request.LogisticCode}</Number></WaybillCode></Result></ufinterface>";
            YuanTongLogisticsResponse yuanTongLogisticsResponse = await _yuanTongHttpClient.GetLogisticInfoAsync(xmlStr);
            if (yuanTongLogisticsResponse.Success)
            {
                if (yuanTongLogisticsResponse.WaybillProcessInfos == null) return queryResponse;
                queryResponse.OrderCode = request.OrderCode;
                queryResponse.ShipperCode = request.ShipperCode.ToString();
                queryResponse.LogisticCode = request.LogisticCode;
                queryResponse.Traces = new List<ExpressTraceInfo>();
                foreach (var waybillProcessInfo in yuanTongLogisticsResponse.WaybillProcessInfos)
                {
                    var processInfo = waybillProcessInfo.ProcessInfo;
                    var processStatus = string.Empty;
                    if (processInfo.Contains("揽件") || processInfo.Contains("收件") || processInfo.Contains("揽收"))
                    {
                        processStatus = "1";
                    }
                    else if (processInfo.Contains("已打包"))
                    {
                        processStatus = "101";
                    }
                    else if (processInfo.Contains("已收入") || processInfo.Contains("已发出"))
                    {
                        processStatus = "2";
                    }
                    else if (processInfo.Contains("派件"))
                    {
                        processStatus = "202";
                    }
                    else if (processInfo.Contains("签收"))
                    {
                        processStatus = "3";
                    }
                    else if (processInfo.Contains("问题件"))
                    {
                        processStatus = "4";
                    }
                    if (!string.IsNullOrEmpty(processStatus))
                    {
                        var newTrace = new ExpressTraceInfo()
                        {
                            AcceptTime = waybillProcessInfo.UploadTime,
                            AcceptStation = waybillProcessInfo.ProcessInfo,
                            Status = processStatus,
                        };
                        queryResponse.Traces.Add(newTrace);
                    }
                }
            }
            else
            {
                queryResponse.Reason = yuanTongLogisticsResponse.Reason;
                queryResponse.ResultCode = yuanTongLogisticsResponse.ResultCode;
                queryResponse.Success = false;
            }

            return queryResponse;
        }
    }
}
