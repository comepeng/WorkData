using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Compeng.PEQP.Dto.Express.Request;

namespace Compeng.PEQP.WebAPI.Controllers
{
    [ApiController]
    public class GetChilrenOrderController: ControllerBase
    {
        private readonly GetChildOrder.GetChildOrderClient _getChildOrderClient;
        private readonly IMapper _mapper;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="getChildOrderClient"></param>
        /// <param name="mapper"></param>
        public GetChilrenOrderController(GetChildOrder.GetChildOrderClient getChildOrderClient,IMapper mapper)
        {
            _mapper = mapper;
            _getChildOrderClient = getChildOrderClient;
        }

        /// <summary>
        /// 取消订单接口
        /// </summary>
        /// <param name="request">取消订单请求实体</param>
        /// <returns></returns>
        [HttpPost]
        [Route("peqpapi/wlydexpressapi/getzdlogisticsno")]
        public async Task<GetChildOrderResponse> QueryChildrenOrderLogisticNumber(ChildrenOrderLogisticsNoRequestDto request)
        {
            //GetChildOrderRequest request
            var grpcRequest = _mapper.Map<ChildrenOrderLogisticsNoRequestDto, GetChildOrderRequest>(request);
            return await _getChildOrderClient.GetChildOrderInfoAsync(grpcRequest);
        }
    }
}