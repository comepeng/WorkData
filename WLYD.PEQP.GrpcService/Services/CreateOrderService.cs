using AutoMapper;
using Compeng.PEQP.Service.ServiceResolvers;
using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Compeng.PEQP.GrpcService.Services
{
    public class CreateOrderService : CreateOrder.CreateOrderBase
    {
        private readonly CreateOrderServiceResolver _serviceResolver;
        private readonly IMapper _mapper;

        public CreateOrderService(CreateOrderServiceResolver serviceResolver, IMapper mapper)
        {
            _serviceResolver = serviceResolver;
            _mapper = mapper;
        }

        public override async Task<CreateOrderResponse> Create(CreateOrderRequest request, ServerCallContext context)
        {
            var validateOrderResponse = await GetValidateOrderResponse(request);

            if (!validateOrderResponse.Success) return validateOrderResponse;

            var internalRequest = _mapper.Map<CreateOrderRequest, ExpressGetElectronicsurfaceRequest>(request);

            var internalResponse =
                await _serviceResolver(internalRequest.ShipperCode).CreateExpressOrderAsync(internalRequest);
            CreateOrderResponse response = new CreateOrderResponse()
            {
                Success = internalResponse.Success,
                Reason = internalResponse.Reason ?? string.Empty,
                ResultCode = (int) internalResponse.ResultCode,
                EstimateDeliveryTime = internalResponse.EstimatedDeliveryTime ?? string.Empty,
                UniquerRequestNumber = internalResponse.UniquerRequestNumber ?? string.Empty,
                EBusinessID = internalResponse.EBusinessID ?? string.Empty,
            };
            if (null != internalResponse.Order)
            {
                var tempOrder = new ExpressOrder()
                {
                    ShipperCode = internalResponse.Order.ShipperCode ?? string.Empty,
                    SignWaybillCode = internalResponse.Order.SignWaybillCode ?? string.Empty,
                    SortingCode = internalResponse.Order.SortingCode ?? string.Empty,
                    LogisticCode = internalResponse.Order.LogisticCode ?? string.Empty,
                    DestinationName = internalResponse.Order.DestinatioName ?? string.Empty,
                    MarkDestination = internalResponse.Order.MarkDestination ?? string.Empty,
                    DestinationCode = internalResponse.Order.DestinatioCode ?? string.Empty,
                    DestinationAllocationCentre = internalResponse.Order.DestinationAllocationCentre ?? string.Empty
                };
                if (null != internalResponse.Order.ShipperInfo)
                {
                    var tempShipperInfo = internalResponse.Order.ShipperInfo;
                    tempOrder.ShipperInfo = new ExpressShipperInfo()
                    {
                        LogisticCode = tempShipperInfo.LogisticCode ?? string.Empty,
                        DestCityCode = tempShipperInfo.DestCityCode ?? string.Empty,
                        DestRouteLabel = tempShipperInfo.DestRouteLabel ?? string.Empty,
                        DestDeptCode = tempShipperInfo.DestDeptCode ?? string.Empty,
                        DestTeamCode = tempShipperInfo.DestTeamCode ?? string.Empty,
                        DestTransferCode = tempShipperInfo.DestTransferCode ?? string.Empty,
                        OriginTransferCode = tempShipperInfo.OriginTransferCode ?? string.Empty,
                        TwoDimensionCode = tempShipperInfo.TwoDimensionCode ?? string.Empty,
                        DestDeptCodeMapping = tempShipperInfo.DestDeptCodeMapping ?? string.Empty,
                        DestTeamCodeMapping = tempShipperInfo.DestTeamCodeMapping ?? string.Empty
                    };
                }
                response.Order = tempOrder;
            }

            return await Task.FromResult(response);
        }

        /// <summary>
        /// 参数检验
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        private static async Task<CreateOrderResponse> GetValidateOrderResponse(CreateOrderRequest request)
        {
            var validateResponse = new CreateOrderResponse()
            {
                EBusinessID = string.Empty,
                Success = true,
                ResultCode = (int) ExpressInterfaceResponseStatusCode.MissNecessaryParameters,
            };

            if (string.IsNullOrEmpty(request.ShipperCode))
            {
                validateResponse.Reason = "快递公司编码不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (string.IsNullOrEmpty(request.OrderCode))
            {
                validateResponse.Reason = "订单编号不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (request.PayType == 0)
            {
                validateResponse.Reason = "运费支付方式不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (request.Receiver == null)
            {
                validateResponse.Reason = "收件人信息不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (string.IsNullOrEmpty(request.Receiver.Name) || (string.IsNullOrEmpty(request.Receiver.Tel) &&
                                                                string.IsNullOrEmpty(request.Receiver.Mobile))
                                                            || string.IsNullOrEmpty(request.Receiver.ProvinceName) ||
                                                            string.IsNullOrEmpty(request.Receiver.CityName)
                                                            || string.IsNullOrEmpty(request.Receiver.ExpAreaName) ||
                                                            string.IsNullOrEmpty(request.Receiver.Address))
            {
                validateResponse.Reason = "收件人信息不完整，请对照接口文档检查";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (request.Sender == null)
            {
                validateResponse.Reason = "发件人信息不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (string.IsNullOrEmpty(request.Sender.Name) || (string.IsNullOrEmpty(request.Sender.Tel) &&
                                                              string.IsNullOrEmpty(request.Sender.Mobile))
                                                          || string.IsNullOrEmpty(request.Sender.ProvinceName) ||
                                                          string.IsNullOrEmpty(request.Sender.CityName)
                                                          || string.IsNullOrEmpty(request.Sender.ExpAreaName) ||
                                                          string.IsNullOrEmpty(request.Sender.Address))
            {
                validateResponse.Reason = "发件人信息不完整，请对照接口文档检查";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (request.Commodity == null || request.Commodity.Count == 0)
            {
                validateResponse.Reason = "货物信息不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (request.Commodity.Any(x => string.IsNullOrEmpty(x.GoodsName)))
            {
                validateResponse.Reason = "货物名称不能为空";
                validateResponse.Success = false;
                return await Task.FromResult(validateResponse);
            }

            if (string.IsNullOrEmpty(request.ExpType))
            {
                request.ExpType = "1";
            }

            return await Task.FromResult(validateResponse);
        }
    }
}