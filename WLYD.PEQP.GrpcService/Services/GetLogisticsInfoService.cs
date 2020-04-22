using AutoMapper;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compeng.PEQP.Model.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Service.ServiceResolvers;

namespace Compeng.PEQP.GrpcService.Services
{
    public class GetLogisticsInfoService : GetLogistics.GetLogisticsBase
    {
        private readonly LogisticsQueryServiceResolver _serviceResolver;
        private readonly IMapper _mapper;

        public GetLogisticsInfoService(LogisticsQueryServiceResolver serviceResolver, IMapper mapper)
        {
            _serviceResolver = serviceResolver;
            _mapper = mapper;
        }

        public override async Task<GetLogisticsResponse> GetLogisticsInfo(GetLogisticsRequest request,
            ServerCallContext context)
        {
            var validateResponse = await GetLogisticsResponse(request);
            if (!validateResponse.Success) return validateResponse;
            var internalRequest = _mapper.Map<GetLogisticsRequest, ExpressQueryLogisticInfoRequest>(request);
            var internalResponse =
                await _serviceResolver(internalRequest.ShipperCode).QueryLogisticInfoAsync(internalRequest);
            GetLogisticsResponse externalResponse = new GetLogisticsResponse();
            externalResponse.Reason = internalResponse.Reason ?? string.Empty;
            externalResponse.Success = internalResponse.Success;
            externalResponse.LogisticCode = internalResponse.LogisticCode ?? string.Empty;
            externalResponse.ResultCode = (int) internalResponse.ResultCode;
            externalResponse.EBusinessID = internalResponse.EBusinessID ?? string.Empty;
            externalResponse.OrderCode = internalResponse.OrderCode ?? string.Empty;
            if (internalResponse.Traces == null || !internalResponse.Traces.Any())
                return await Task.FromResult(externalResponse);
            foreach (var tranceItem in internalResponse.Traces)
            {
                ExpressTraceInfo expressTraceInfo = new ExpressTraceInfo();
                expressTraceInfo.AcceptTime = tranceItem.AcceptTime;
                expressTraceInfo.AcceptStation = tranceItem.AcceptStation ?? string.Empty;
                expressTraceInfo.Location = tranceItem.Location ?? string.Empty;
                expressTraceInfo.Status = tranceItem.Status ?? string.Empty;
                expressTraceInfo.Remark = tranceItem.Remark ?? string.Empty;
                externalResponse.Traces.Add(expressTraceInfo);
            }
            return await Task.FromResult(externalResponse);
        }

        private  async Task<GetLogisticsResponse> GetLogisticsResponse(GetLogisticsRequest request)
        {
            var validateResponse = new GetLogisticsResponse()
            {
                EBusinessID = string.Empty,
                Success = true,
                ResultCode = (int) ExpressInterfaceResponseStatusCode.MissNecessaryParameters,
            };
            if (string.IsNullOrEmpty(request.ShipperCode))
            {
                validateResponse.Success = false;
                validateResponse.Reason = "快递公司编码不能为空";

                return await Task.FromResult(validateResponse);
            }

            if (string.IsNullOrEmpty(request.LogisticCode))
            {
                validateResponse.Success = false;
                validateResponse.Reason = "快递单号不能为空";

                return await Task.FromResult(validateResponse);
            }

            if (request.ShipperCode == "SF" && string.IsNullOrEmpty(request.CustomerName))
            {
                validateResponse.Success = false;
                validateResponse.Reason = "快递为SF时，CustomerName不能为空";
                return await Task.FromResult(validateResponse);
            }

            return await Task.FromResult(validateResponse);
        }
    }
}