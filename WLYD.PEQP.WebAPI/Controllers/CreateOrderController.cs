using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Compeng.PEQP.Dto.Express.Request;

namespace Compeng.PEQP.WebAPI.Controllers
{
    [ApiController]
    public class CreateOrderController : ControllerBase
    {
        private readonly CreateOrder.CreateOrderClient _createOrderClient;
        private readonly IMapper _mapper;

        public CreateOrderController(CreateOrder.CreateOrderClient createOrderClient, IMapper mapper)
        {
            _mapper = mapper;
            _createOrderClient = createOrderClient;
        }


        /// <summary>
        /// 创建电子面单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("peqpapi/wlydexpressapi/createorder")]
        public async Task<CreateOrderResponse> CreateElectronicSufaceOrder(ElectronicsurfaceRequestDto request)
        {
            //CreateOrderRequest request
            CreateOrderRequest grpcRequest = new CreateOrderRequest()
            {
                ShipperCode = request.ShipperCode,
                SendSite = request.SendSite??string.Empty,
                StartDate = request.StartDate??string.Empty,
                Cost = request.Cost?.ToString() ?? String.Empty,
                CustomArea = request.CustomArea ?? string.Empty,
                CustomerName = request.CustomerName ?? string.Empty,
                CustomerPwd = request.CustomerPwd ?? string.Empty,
                IsNotice = request.IsNotice ?? 1,
                LogisticCode = request.LogisticCode ?? string.Empty,
                OtherCost = request.OtherCost?.ToString() ?? string.Empty,
                TransType = request.TransType ?? 1,
                IsReturnSignBill = request.IsReturnSignBill ?? 0,
                WareHouseID = request.WareHouseID ?? string.Empty,
                Callback = request.Callback ?? string.Empty,
                MonthCode = request.MonthCode ?? string.Empty,
                ThOrderCode = request.ThrOrderCode ?? string.Empty,
                OrderCode = request.OrderCode ?? string.Empty,
                EndDate = request.EndDate ?? string.Empty,
                ExpType = request.ExpType ?? string.Empty,
                Quantity = request.Quantity ?? 0,
                OperateRequire = request.OperateRequire ?? string.Empty,
                Weight = request.Weight?.ToString() ?? "0",
                PayType = request.PayType,
                Remark = request.Remark ?? string.Empty,
                MemberID = request.MemberID ?? string.Empty,
                Volume = request.Volume?.ToString() ?? string.Empty,
            };
            //发件人信息
            if (null != request.Sender)
            {
                var tempSender = request.Sender;
                grpcRequest.Sender = new ExpressSender()
                {
                    Address = tempSender.Address ?? string.Empty,
                    ExpAreaName = tempSender.ExpAreaName ?? string.Empty,
                    PostCode = tempSender.PostCode ?? string.Empty,
                    Company = tempSender.Company ?? string.Empty,
                    CityName = tempSender.CityName,
                    ProvinceName = tempSender.ProvinceName ?? string.Empty,
                    Name = tempSender.Name ?? string.Empty,
                    Tel = tempSender.Tel ?? string.Empty,
                    Mobile = tempSender.Mobile ?? string.Empty,
                };
            }

            //收件人信息
            if (null != request.Receiver)
            {
                var tempReceiver = request.Receiver;
                grpcRequest.Receiver = new ExpressReceiver()
                {
                    Address = tempReceiver.Address ?? string.Empty,
                    ExpAreaName = tempReceiver.ExpAreaName ?? string.Empty,
                    PostCode = tempReceiver.PostCode ?? string.Empty,
                    Company = tempReceiver.Company ?? string.Empty,
                    CityName = tempReceiver.CityName ?? string.Empty,
                    ProvinceName = tempReceiver.ProvinceName ?? string.Empty,
                    Name = tempReceiver.Name ?? string.Empty,
                    Tel = tempReceiver.Tel ?? string.Empty,
                    Mobile = tempReceiver.Mobile ?? string.Empty,
                };
            }

            //物品信息
            if (null != request.Commodity && request.Commodity.Any())
            {
                foreach (var item in request.Commodity)
                {
                    var com = new ExpressCommodity()
                    {
                        GoodsName = item.GoodsName ?? string.Empty,
                        GoodsPrice = item.GoodsPrice?.ToString() ?? string.Empty,
                        GoodsCode = item.GoodsCode ?? string.Empty,
                        GoodsQuantity = item.GoodsQuantity ?? 0,
                        GoodsDesc = item.GoodsDesc ?? string.Empty,
                        GoodsVol = item.GoodsVol?.ToString() ?? "",
                        GoodsWeight = item.GoodsWeight?.ToString() ?? "",
                    };
                    grpcRequest.Commodity.Add(com);
                }
            }

            if (null != request.AddService && request.AddService.Any())
            {
                foreach (var addService in request.AddService)
                {
                    ExpressAddService expressAddService = new ExpressAddService()
                    {
                        Name = addService.Name ?? string.Empty,
                        CustomerID = addService.CustomerId ?? string.Empty,
                        Value = addService.Value ?? string.Empty
                    };
                    grpcRequest.AddService.Add(expressAddService);
                }
            }

            return await _createOrderClient.CreateAsync(grpcRequest);
        }
    }
}