using AutoMapper;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Compeng.PEQP.Model.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Service.ServiceResolvers;

namespace Compeng.PEQP.GrpcService.Services
{
    public class GetChildOrderService : GetChildOrder.GetChildOrderBase
    {
        private readonly ChildrenOrderLogisticsNoResolver _serviceResolver;
        private readonly IMapper _mapper;

        public GetChildOrderService(ChildrenOrderLogisticsNoResolver serviceResolver, IMapper mapper)
        {
            _serviceResolver = serviceResolver;
            _mapper = mapper;
        }

        public override async Task<GetChildOrderResponse> GetChildOrderInfo(GetChildOrderRequest request,
            ServerCallContext context)
        {
            var validateResponse = await GetValidateChildOrderResponse(request);
            if (!validateResponse.Success) return validateResponse;
            var internalRequest = _mapper.Map<GetChildOrderRequest, ExpressGetChildrenOrderLogisticsNoRequest>(request);
            var internalResponse = await _serviceResolver(internalRequest.ShipperCode)
                .GetChildrenOrderLogisticsNoAsync(internalRequest);
            var response = new GetChildOrderResponse()
            {
                Success = internalResponse.Success,
                Reason = internalResponse.Reason ?? string.Empty,
                ResultCode = (int) internalResponse.ResultCode,
                MainLogisticCode = internalResponse.MainLogisticCode ?? string.Empty,
                EBusinessID = internalResponse.EBusinessID ?? string.Empty,
                ZDLogisticCodes = internalResponse.ZDLogisticCodes ?? string.Empty
            };

            return await Task.FromResult(response);
        }

        /// <summary>
        /// 参数校验
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private  async Task<GetChildOrderResponse> GetValidateChildOrderResponse(GetChildOrderRequest request)
        {
            var validateResponse = new GetChildOrderResponse()
            {
                Success = true,
                ResultCode = (int) Model.ExpressInferceModels.Enums.ExpressInterfaceResponseStatusCode
                    .MissNecessaryParameters,
            };
            if (request.ParcelQuantity < 1)
            {
                validateResponse.Reason = "包裹数量不能小于1";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (string.IsNullOrEmpty(request.OrderCode))
            {
                validateResponse.Reason = "订单编号不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }
            return await Task.FromResult(validateResponse);
        }
    }
}