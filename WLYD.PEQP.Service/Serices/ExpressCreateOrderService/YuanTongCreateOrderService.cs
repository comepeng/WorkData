using System;
using System.Linq;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Model.ExpressInferceModels.YTO.Request;
using Compeng.PEQP.Service.HttpClients.YuanTong;
using Compeng.PEQP.Service.IServices.IExpressCreateOrderService;
using Compeng.PEQP.Util.Extensions;
using Compeng.PEQP.Util.KeyGen;
using Compeng.PEQP.Util.Xml;

namespace Compeng.PEQP.Service.Serices.ExpressCreateOrderService
{
    /// <summary>
    /// 圆通电子面单下单接口服务
    /// </summary>
    public class YuanTongCreateOrderService : IExpressCreateOrderService
    {
        private readonly YuanTongHttpClient _yuanTongHttpClient;//客户端
        /// <summary>
        /// 圆通电子面单下单接口
        /// </summary>
        /// <param name="yuanTongHttpClient">客户端</param>
        public YuanTongCreateOrderService(YuanTongHttpClient yuanTongHttpClient)
        {
            _yuanTongHttpClient = yuanTongHttpClient;
        }
        public async Task<ExpressGetElectronicsurfaceResponse> CreateExpressOrderAsync(ExpressGetElectronicsurfaceRequest request)
        {
            var expressResponse =  BuildYuantongRequest(request, out var ytoRequest);
            if (!expressResponse.Success) return expressResponse;           
            var xmlStr = XmlParser.Serializer(ytoRequest);
            var clientId = request.CustomerName;
            var partnerId = request.CustomerPwd;
            var orderResponse = await _yuanTongHttpClient.CreateOrderAsync(xmlStr,clientId,partnerId);
            if (orderResponse.Success)
            {
                expressResponse.Order = new ExpressOrder()
                {
                    LogisticCode = orderResponse.MailNo,
                    MarkDestination = orderResponse.DistributeInfo?.ShortAddress,
                    OriginCode = orderResponse.OriginateOrgCode,
                    DestinatioCode = orderResponse.DistributeInfo?.ConsigneeBranchCode,
                    ShipperCode = request.ShipperCode.ToString(),
                    OrderCode = request.OrderCode,
                    PackageCode = orderResponse.DistributeInfo?.PackageCenterCode,
                    PackageName = orderResponse.DistributeInfo?.PackageCenterName,
                    QRCode = orderResponse.QrCode
                };
            }
            else
            {
                expressResponse.Success = false;
                expressResponse.Reason = orderResponse.Reason;
                expressResponse.ResultCode =  ExpressInterfaceResponseStatusCode.Other;               
            }
            return expressResponse;
        }
        /// <summary>
        /// 构建圆通请求对象
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ytoRequest"></param>
        /// <returns></returns>
        private ExpressGetElectronicsurfaceResponse BuildYuantongRequest(ExpressGetElectronicsurfaceRequest request, out YuanTongOrderRequest ytoRequest)
        {
            var expressResponse = new ExpressGetElectronicsurfaceResponse()
            {
                EBusinessID = string.Empty,
                Success = true,
                ResultCode = ExpressInterfaceResponseStatusCode.Success,
                UniquerRequestNumber = GuidHelper.NewGuid().GuidTo16String(),
            };

            if (string.IsNullOrEmpty(request.CustomerName) || string.IsNullOrEmpty(request.CustomerPwd))
            {
                expressResponse.Success = false;
                expressResponse.Reason = "圆通快递申请电子面单客户账号或密钥不能为空";
                expressResponse.ResultCode = ExpressInterfaceResponseStatusCode.MissNecessaryParameters;
                ytoRequest = null;
                return expressResponse;
            }
            var clientId = request.CustomerName;          
            string agencyFund = string.Empty;
            string insuranceValue = string.Empty;
            if (request.AddService != null)
            {
                agencyFund = request.AddService?.Where(x => x.Name == "COD").Select(x => x.Value).FirstOrDefault();
                insuranceValue = request.AddService?.Where(x => x.Name == "INSURE").Select(x => x.Value).FirstOrDefault();
            }
            var tempRequest = new YuanTongOrderRequest()
            {
                ClientID = clientId,
                LogisticProviderID = "YTO",
                CustomerId = clientId,
                TradeNo = clientId,
                TxLogisticID = request.OrderCode,
                OrderType = request.PayType == 4 ? request.PayType : 1,
                ServiceType = 0,
                Flag = Convert.ToInt32(request.ExpType),
                AgencyFund = !string.IsNullOrEmpty(agencyFund) ? Convert.ToInt32(agencyFund) : 0,
                InsuranceValue = !string.IsNullOrEmpty(insuranceValue) ? Convert.ToInt32(insuranceValue) : 0,
                ItemsWeight = request.Weight.HasValue ? request.Weight.Value : 0,
                Remark = request.Remark
            };
            if (request.IsNotice.HasValue && request.IsNotice == 0)
            {

                tempRequest.ServiceType = 1;
                tempRequest.SendStartTime = request.StartDate;
                tempRequest.SendEndTime = request.EndDate;


            }
            tempRequest.Sender = new YTOSender()
            {
                Name = request.Sender?.Name,
                PostCode = request.Sender?.PostCode,
                Mobile = request.Sender?.Mobile,
                Phone = request.Sender?.Tel,
                Prov = request.Sender?.ProvinceName,
                City = request.Sender?.CityName + "," + request.Sender?.ExpAreaName,
                Address = request.Sender?.Address
            };
            tempRequest.Receiver = new YTOReceiver()
            {
                Name = request.Receiver?.Name,
                PostCode = request.Receiver?.PostCode,
                Mobile = request.Receiver?.Mobile,
                Phone = request.Receiver?.Tel,
                Prov = request.Receiver?.ProvinceName,
                City = request.Receiver?.CityName + "," + request.Receiver?.ExpAreaName,
                Address = request.Receiver?.Address
            };
            if (request.Commodity != null)
            {
                tempRequest.Items = request.Commodity.Select(c => new YuanTongItem()
                {
                    ItemName = c.GoodsName,
                    Number = c.GoodsQuantity.HasValue ? c.GoodsQuantity.Value : 0,
                    ItemValue = c.GoodsPrice.HasValue ? c.GoodsPrice.Value : 0,
                }).ToList();
            }
            ytoRequest = tempRequest;
            return expressResponse;
        }
   
      
    }
}
