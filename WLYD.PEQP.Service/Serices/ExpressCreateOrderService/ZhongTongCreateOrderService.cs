using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Model.ExpressInferceModels.ZTO.Request;
using Compeng.PEQP.Model.ExpressInferceModels.ZTO.Response;
using Compeng.PEQP.Service.HttpClients.ZhongTong;
using Compeng.PEQP.Service.IServices.IExpressCreateOrderService;
using Compeng.PEQP.Util.Extensions;
using Compeng.PEQP.Util.KeyGen;

namespace Compeng.PEQP.Service.Serices.ExpressCreateOrderService
{
    /// <summary>
    /// 中通电子面单下单接口服务
    /// </summary>
    public class ZhongTongCreateOrderService : IExpressCreateOrderService
    {
        private readonly ZhongTongHttpClient _zhongTongHttpClient;
        private readonly ILogger<ZhongTongCreateOrderService> _logger;

        public ZhongTongCreateOrderService(ZhongTongHttpClient zhongTongHttpClient, ILoggerFactory loggerFactory)
        {
            _zhongTongHttpClient = zhongTongHttpClient;
            _logger = loggerFactory.CreateLogger<ZhongTongCreateOrderService>();
        }

        /// <summary>
        /// 中通创建电子面单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ExpressGetElectronicsurfaceResponse> CreateExpressOrderAsync(
            ExpressGetElectronicsurfaceRequest request)
        {
            ZhongTongWayBillVasRequest zhongtongRequest = null;
            ExpressGetElectronicsurfaceResponse response =
                BuildZhongTongElectronicsurfaceRequest(request, out zhongtongRequest);
            if (!response.Success) return response;
            ZhonTongResultStatusReponse zhongTongResponse =
                await _zhongTongHttpClient.CreateExpressOrderAsync(zhongtongRequest);
            if (zhongTongResponse.Status)
            {
                var resultResponse =
                    JsonConvert.DeserializeObject<ZTOGetWayBillResult>(zhongTongResponse.Result.ToString());
                if (resultResponse != null)
                {
                    response.Order = new ExpressOrder()
                    {
                        LogisticCode = resultResponse.BillCode,
                        MarkDestination = resultResponse.BigMarkInfo?.Mark,
                        ShipperCode = request.ShipperCode.ToString(),
                        OrderCode = request.OrderCode,
                        PackageName = resultResponse.BigMarkInfo?.BagAddr,
                    };
                }
            }
            else
            {
                response.Success = false;
                response.Reason = zhongTongResponse.Message;
                response.ResultCode = ExpressInterfaceResponseStatusCode.Other;
            }

            return response;
        }

        private ExpressGetElectronicsurfaceResponse BuildZhongTongElectronicsurfaceRequest(
            ExpressGetElectronicsurfaceRequest request, out ZhongTongWayBillVasRequest zhongtongRequest)
        {
            var expressResponse = new ExpressGetElectronicsurfaceResponse()
            {
                Success = true,
                ResultCode = ExpressInterfaceResponseStatusCode.Success,
                UniquerRequestNumber = GuidHelper.NewGuid().GuidTo16String(),
            };
            if (string.IsNullOrEmpty(request.CustomerName) || string.IsNullOrEmpty(request.CustomerPwd))
            {
                expressResponse.Success = false;
                expressResponse.Reason = "中通快递申请电子面单客户账号或密钥不能为空";
                expressResponse.ResultCode = ExpressInterfaceResponseStatusCode.MissNecessaryParameters;
                zhongtongRequest = null;
                return expressResponse;
            }

            var ztoRequest = new ZhongTongWayBillVasRequest()
            {
                //  PartnerOrderCode = request.OrderCode,
                //PartnerId = ZTOContext.Instance.CompanyID,
                PartnerOrderCode = request.OrderCode,
                //PartnerId = "d758a25c895c4845a973f5663e4b8134",
            };
            ztoRequest.WayBillAccountDto = new ZhongTongWayBillAccountDto()
            {
                AccountId = request.CustomerName,
                AccountPassword = request.CustomerPwd
            };
            string insuranceValue = string.Empty;
            if (request.AddService != null)
            {
                insuranceValue = request.AddService?.Where(x => x.Name == "INSURE").Select(x => x.Value)
                    .FirstOrDefault();
                if (!string.IsNullOrEmpty(insuranceValue) && decimal.TryParse(insuranceValue, out decimal result))
                {
                    ztoRequest.VasTypes = new List<string> {"insured"};
                    ztoRequest.InsuredType = 1;
                    ztoRequest.InsuredSum = (long) (result * 100);
                }
            }

            ztoRequest.SenderInfoDto = new ZhongTongSenderInfoDto()
            {
                SenderId = "50yc_zto",
                SenderName = request.Sender?.Name,
                SenderPhone = request.Sender?.Tel,
                SenderMobile = request.Sender?.Mobile,
                SenderProvince = request.Sender?.ProvinceName,
                SenderCity = request.Sender?.CityName,
                SenderDistrict = request.Sender?.ExpAreaName,
                SenderAddress = request.Sender?.Address
            };
            ztoRequest.ReceiverInfoDto = new ZhongTongReceiverInfoDto()
            {
                //ReceiverId = string.Empty,
                ReceiverName = request.Receiver?.Name,
                ReceiverPhone = request.Receiver?.Tel,
                ReceiverMobile = request.Receiver?.Mobile,
                ReceiverProvince = request.Receiver?.ProvinceName,
                ReceiverCity = request.Receiver?.CityName,
                ReceiverDistrict = request.Receiver?.ExpAreaName,
                ReceiverAddress = request.Receiver?.Address
            };
            if (request.Commodity != null)
            {
                ztoRequest.ItemDtos = request.Commodity.Select(x =>
                {
                    int? weight = null;
                    if (x.GoodsWeight.HasValue)
                    {
                        weight = (int) (x.GoodsWeight.Value * 1000);
                    }

                    int? unitPrice = null;
                    if (x.GoodsPrice.HasValue)
                    {
                        unitPrice = (int) (x.GoodsPrice.Value * 100);
                    }

                    var rtn = new ZhongTongItemDto()
                    {
                        Name = x.GoodsName,
                        Weight = weight,
                        Unitprice = unitPrice,
                        Remark = x.GoodsDesc,
                        Quantity = x.GoodsQuantity.HasValue ? x.GoodsQuantity.Value : 0
                    };
                    return rtn;
                }).ToList();
            }

            zhongtongRequest = ztoRequest;
            return expressResponse;
        }
    }
}