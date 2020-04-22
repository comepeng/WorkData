using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;
using Compeng.OMS.BusinessModel.InterfaceModels.SF.SFQiao;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Model.ExpressInferceModels.ShunFeng;
using Compeng.PEQP.Service.HttpClients.ShunFeng;
using Compeng.PEQP.Service.IServices.IExpressCreateOrderService;
using Compeng.PEQP.Util.Extensions;
using Compeng.PEQP.Util.KeyGen;

namespace Compeng.PEQP.Service.Serices.ExpressCreateOrderService
{/// <summary>
 /// 顺丰电子面单下单接口服务
 /// </summary>
    public class ShunFengCreateOrderService : IExpressCreateOrderService
    {
        private readonly ShunFengHttpClient _shunFengHttpClient;
        private readonly ILogger<ShunFengCreateOrderService> _logger;
        private readonly ShunFengApiConfig _shunFengApiConfig;

        public ShunFengCreateOrderService(ShunFengHttpClient shunFengHttpClient, ILogger<ShunFengCreateOrderService> logger, ShunFengApiConfig shunFengApiConfig)
        {
            _shunFengHttpClient = shunFengHttpClient;
            _shunFengApiConfig = shunFengApiConfig;
            _logger = logger;
        }
        /// <summary>
        /// 顺丰创建电子面单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ExpressGetElectronicsurfaceResponse> CreateExpressOrderAsync(ExpressGetElectronicsurfaceRequest request)
        {

            ExpressGetElectronicsurfaceResponse expressResponse = BuildShunFengRequest(request, out string requestStr);
            if (!expressResponse.Success) return expressResponse;
            ShunFengQiaoOrderResponse sfQiaoResponse = await _shunFengHttpClient.CreateOrderAsync(requestStr);
            if (!sfQiaoResponse.Success)
            {
                expressResponse.Success = false;
                expressResponse.Reason = sfQiaoResponse.Reason;
                expressResponse.ResultCode = ExpressInterfaceResponseStatusCode.Other;
                return expressResponse;
            }
            expressResponse.Order = new ExpressOrder()
            {
                LogisticCode = sfQiaoResponse.Mailno,
                SignWaybillCode = sfQiaoResponse.Return_tracking_no,
                OriginCode = sfQiaoResponse.Origincode,
                DestinatioCode = sfQiaoResponse.Destcode,
                ShipperCode = request.ShipperCode.ToString(),
                OrderCode = request.OrderCode
            };
            if (!sfQiaoResponse.HasDetail) return expressResponse;
            expressResponse.Order.ShipperInfo = new ExpressShipperInfo()
            {
                LogisticCode = sfQiaoResponse.LogisticCode,
                OriginTransferCode = sfQiaoResponse.OriginTransferCode,
                OriginCityCode = sfQiaoResponse.OriginCityCode,
                OriginDeptCode = sfQiaoResponse.OriginDeptCode,
                OriginTeamCode = sfQiaoResponse.OriginTeamCode,
                DestCityCode = sfQiaoResponse.DestCityCode,
                DestDeptCode = sfQiaoResponse.DestDeptCode,
                DestDeptCodeMapping = sfQiaoResponse.DestDeptCodeMapping,
                DestTeamCode = sfQiaoResponse.DestTeamCode,
                DestTeamCodeMapping = sfQiaoResponse.DestTeamCodeMapping,
                DestTransferCode = sfQiaoResponse.DestTransferCode,
                DestRouteLabel = sfQiaoResponse.DestRouteLabel,
                CodingMapping = sfQiaoResponse.CodingMapping,
                CodingMappingOut = sfQiaoResponse.CodingMappingOut,
                XbFlag = sfQiaoResponse.XbFlag,
                PrintFlag = sfQiaoResponse.PrintFlag,
                TwoDimensionCode = sfQiaoResponse.TwoDimensionCode,
                ProCode = sfQiaoResponse.ProCode,
                PrintIcon = sfQiaoResponse.PrintIcon,
                AbFlag = sfQiaoResponse.AbFlag,
            };
            return expressResponse;





        }

        private ExpressGetElectronicsurfaceResponse BuildShunFengRequest(ExpressGetElectronicsurfaceRequest request, out string requestStr)
        {
            var expressResponse = new ExpressGetElectronicsurfaceResponse()
            {
                EBusinessID = string.Empty,
                Success = true,
                ResultCode = ExpressInterfaceResponseStatusCode.Success,
                UniquerRequestNumber = GuidHelper.NewGuid().GuidTo16String(),
            };
            if (string.IsNullOrEmpty(request.MonthCode))
            {
                expressResponse.Success = false;
                expressResponse.Reason = "顺丰快递申请电子面单号月结卡号不能为空";
                requestStr = string.Empty;
                expressResponse.ResultCode = ExpressInterfaceResponseStatusCode.MissNecessaryParameters;
                return expressResponse;
            }


            StringBuilder stringBuilder = new StringBuilder();
            string addServiceString = string.Empty;
            //商品信息
            if (request.Commodity != null)
            {
                foreach (var orderProduct in request.Commodity)
                {
                    stringBuilder.Append($"<Cargo name='{orderProduct.GoodsName}'")
                        .Append($" count='{orderProduct.GoodsQuantity}'")
                        .Append($" weight='{orderProduct.GoodsWeight}'")
                        .Append($" amount='{orderProduct.GoodsPrice}'></Cargo>");
                }
            }
            string productString = stringBuilder.ToString();
            stringBuilder.Clear();
            //增值服务
            if (request.AddService != null)
            {
                foreach (var addItem in request.AddService)
                {
                    stringBuilder.Append($"<AddedService name='{ addItem.Name}'")
                        .Append($"value='{addItem.Value}'></AddedService>");
                }
                addServiceString = stringBuilder.ToString();
                stringBuilder.Clear();
            }
            //string payMethod = string.Empty;
            //if (request.PayType ==1 || request.PayType == 2 || request.PayType == 4)
            //{
            //    payMethod = request.PayType.ToString();
            //}
            //订单信息
            string clientCode = _shunFengApiConfig.ClientCode;
            string[] xmls =
            {
                    "<Request service='OrderService' lang='zh-CN'>",
                    $"<Head>{clientCode}</Head>",
                    "<Body>",
                    "<Order",
                    $" orderid='{request.OrderCode}'",

                    //寄件人信息
                    $" j_company='{request.Sender?.Company}'",
                    $" j_contact='{request.Sender?.Name }'",
                    $" j_tel='{request.Sender?.Tel}'",
                    $" j_mobile='{request.Sender?.Mobile}'",
                    $" j_province='{request.Sender?.ProvinceName}'",
                    $" j_city='{request.Sender?.CityName}'",
                    $" j_county='{request.Sender?.ExpAreaName}'",
                    $" j_address='{ request.Sender?.ProvinceName}{ request.Sender?.CityName}{ request.Sender?.ExpAreaName}{ request.Sender?.Address}'",
                    $" j_post_code='{request.Sender?.PostCode}'",
                    //到件人信息
                    $" d_company='{request.Receiver?.Company}'",
                    $" d_contact='{request.Receiver?.Name}'",
                    $" d_tel='{ request.Receiver?.Tel}'",
                    $" d_mobile='{request.Receiver?.Mobile}'",
                    $" d_address='{request.Receiver?.ProvinceName}{request.Receiver?.CityName}{request.Receiver?.ExpAreaName}{request.Receiver?.Address }'",
                    $" d_province='{request.Receiver?.ProvinceName}'",
                    $" d_city='{request.Receiver?.CityName}'",
                    $" d_county='{request.Receiver?.ExpAreaName}'",
                    $" d_post_code='{request.Receiver?.PostCode}'",
                    //月结卡号
                    $" custid='{request.MonthCode}'",
                    //路由标签查询服务
                    $" routelabelService='{1}'",
                    $" is_unified_waybill_no='{1}'",
                    $" express_type='{request.ExpType}'",
                    $" cargo_total_weight='{request.Weight}'",
                    $" volume='{request.Volume }'",
                    $" remark='{request.Remark}'>",
                    productString,
                    addServiceString,
                    "</Order>",
                    "</Body>",
                    "</Request>",
                };
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
            requestStr = stringBuilder.ToString();
            return expressResponse;
        }
    }
}
