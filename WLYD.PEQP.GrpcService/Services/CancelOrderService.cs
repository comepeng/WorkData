using AutoMapper;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Request;
using Compeng.PEQP.Service.ServiceResolvers;
using Grpc.Core;
using System.Threading.Tasks;

namespace Compeng.PEQP.GrpcService.Services
{
    public class CancelOrderService : CancelOrder.CancelOrderBase
    {
        private readonly CancelOrderServiceResolver _cancelOrderServiceResolver;
        private readonly IMapper _mapper;

        public CancelOrderService(CancelOrderServiceResolver cancelOrderServiceResolver, IMapper mapper)
        {
            _cancelOrderServiceResolver = cancelOrderServiceResolver;
            _mapper = mapper;
        }

        public override async Task<CancelExpressBackResponse> Cancel(CancelOrderRequest request,
            ServerCallContext context)
        {


            var validateResponse = await GetCancelValidateExpressBackResponse(request);
            if (!validateResponse.Success) return validateResponse;
            var mapperRequest = _mapper.Map<CancelOrderRequest, ExpressCancelOrderRequest>(request);
            var internalResponse = await _cancelOrderServiceResolver(mapperRequest.ShipperCode).CancelOrderAsync(mapperRequest);
            var response = new CancelExpressBackResponse()
            {

                Success = internalResponse.Success,
                Reason = internalResponse.Reason??string.Empty,
                EBusinessID = internalResponse.EBusinessID??string.Empty,
                ResultCode = (int)internalResponse.ResultCode
            };
            return await Task.FromResult(response);

        }

        private async Task<CancelExpressBackResponse> GetCancelValidateExpressBackResponse(CancelOrderRequest request)
        {
            var validateResponse = new CancelExpressBackResponse
            {
                EBusinessID = string.Empty,
                Success = true,
                ResultCode = 101
            };
            if (string.IsNullOrEmpty(request.OrderCode))
            {
                validateResponse.Reason = "订单编号不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (string.IsNullOrEmpty(request.LogisticCode))
            {
                validateResponse.Reason = "快递单号不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            return await Task.FromResult(validateResponse);
        }
    }
}
