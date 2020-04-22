using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Compeng.PEQP.Dto.Express.Request;

namespace Compeng.PEQP.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    // [Auth()]
    [ApiController]
    public class CancelOrderController : ControllerBase
    {
        private readonly CancelOrder.CancelOrderClient _client;
        private readonly IMapper _mapper;

        public CancelOrderController(CancelOrder.CancelOrderClient client,IMapper mapper)
        {
            _mapper = mapper;
            _client = client;
        }

        /// <summary>
        /// 取消订单接口
        /// </summary>
        /// <param name="request">取消订单请求实体</param>
        /// <returns></returns>
        [HttpPost]
        [Route("peqpapi/wlydexpressapi/cancelorder")]
        public async Task<CancelExpressBackResponse> CancelOrder(CancelOrderRequestDto request)
        {
            var grpcRequest = _mapper.Map<CancelOrderRequestDto, CancelOrderRequest>(request);
            return await _client.CancelAsync(grpcRequest);
        }
    }
}