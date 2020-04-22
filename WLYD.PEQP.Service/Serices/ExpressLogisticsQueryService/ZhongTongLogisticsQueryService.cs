using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Model.ExpressInferceModels.ZTO.Response;
using Compeng.PEQP.Service.HttpClients.ZhongTong;
using Compeng.PEQP.Service.IServices.IExpressLogisticsQueryService;

namespace Compeng.PEQP.Service.Serices.ExpressLogisticsQueryService
{
    public class ZhongTongLogisticsQueryService : IExpressLogisiticsQueryService
    {
        private readonly ZhongTongHttpClient _zhongTongHttpClient;
        private readonly ILogger<ZhongTongLogisticsQueryService> _loger;

        public ZhongTongLogisticsQueryService(ZhongTongHttpClient zhongTongHttpClient, ILogger<ZhongTongLogisticsQueryService> loger)
        {
            _zhongTongHttpClient = zhongTongHttpClient;
            _loger = loger;
        }

        public async Task<ExpressQueryLogisticInfoResponse> QueryLogisticInfoAsync(ExpressQueryLogisticInfoRequest request)
        {
            var queryResponse = new ExpressQueryLogisticInfoResponse()
            {
                Success = true,
                ResultCode = ExpressInterfaceResponseStatusCode.Success
            };
            var resultCodes = new List<string>() { request.LogisticCode };
            var data = JsonConvert.SerializeObject(resultCodes);
            ZhonTongResultStatusReponse zhonTongResult = await _zhongTongHttpClient.GetLogisticsInfoAsync(data);
            if (!zhonTongResult.Status)
            {
                queryResponse.Success = false;
                queryResponse.Reason = zhonTongResult.Message;
                queryResponse.ResultCode = ExpressInterfaceResponseStatusCode.Other;
                return queryResponse;
            }

            if (null != zhonTongResult.ResultData)
            {
                var resultResponseList = JsonConvert.DeserializeObject<List<ZhongTongGetNewTracesResponse>>(zhonTongResult.ResultData.ToString());
                var traceResult = resultResponseList?.Where(x => x.BillCode == request.LogisticCode)?.FirstOrDefault();
                if (traceResult?.TraceInfos != null)
                {

                    queryResponse.OrderCode = request.OrderCode;
                    queryResponse.ShipperCode = request.ShipperCode.ToString();
                    queryResponse.LogisticCode = request.LogisticCode;
                    queryResponse.Traces = new List<ExpressTraceInfo>();
                    foreach (var ztoTraceInfo in traceResult.TraceInfos)
                    {
                        var status = string.Empty;
                        switch (ztoTraceInfo.ScanType.Trim())
                        {
                            case "收件":
                                status = "1";
                                break;
                            case "发件":
                            case "到件":
                                status = "2";
                                break;
                            case "派件":
                                status = "202";
                                break;
                            case "ARRIVAL":
                                status = "203";
                                break;
                            case "签收":
                            case "第三方签收":
                            case "退件":
                            case "退件签收":
                            case "SIGNED":
                                status = "3";
                                break;
                            case "问题件":
                                status = "4";
                                break;
                            default:
                                break;
                        }
                        if (!string.IsNullOrEmpty(status))
                        {
                            var newTrace = new ExpressTraceInfo()
                            {
                                AcceptTime = ztoTraceInfo.ScanDate,
                                AcceptStation = ztoTraceInfo.Desc,
                                Status = status,
                                Location = ztoTraceInfo.ScanCity,
                                Remark = ztoTraceInfo.Remark
                            };
                            queryResponse.Traces.Add(newTrace);
                        }
                    }

                }
            }

            return queryResponse;
        }
    }
}
