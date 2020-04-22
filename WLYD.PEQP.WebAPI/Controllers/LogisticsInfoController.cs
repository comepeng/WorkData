using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Compeng.PEQP.Dto.Express.Request;

namespace Compeng.PEQP.WebAPI.Controllers
{
    [ApiController]
    public class LogisticsInfoController: ControllerBase
    {
     
        private readonly GetLogistics.GetLogisticsClient _getLogisticsClient;
        private readonly IMapper _mapper;
        private readonly ILogger<LogisticsInfoController> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="getLogisticsClient">grpc客户端</param>
        /// <param name="mapper">对象映射mapper</param>
        public LogisticsInfoController(GetLogistics.GetLogisticsClient getLogisticsClient,IMapper mapper,ILogger<LogisticsInfoController> logger)
        {
            _getLogisticsClient = getLogisticsClient;
            _mapper = mapper;
            _logger = logger;
        }


        /// <summary>
        /// 物流轨迹查询
        /// </summary>
        ///<example>
        ///圆通请求示例：
        ///<code>
        ///{
        ///    "OrderCode": "",
        ///    "ShipperCode": 0,
        ///    "LogisticCode": "YT2027195948210"
        ///}
        /// </code>
        ///顺丰请求示例：注意此时CustomerName是必须的
        ///<code>
        ///{
        ///"OrderCode": "",
        /// "ShipperCode": 2,
        ///"LogisticCode": "SF1014450814126",
        ///"CustomerName":"11"
        ///}
        ///</code>
        ///中通请求示例：
        /// </example>
        /// <param name="request">查询物流信息请求实体</param>
        /// <returns></returns>
        [HttpPost]
        [Route("peqpapi/wlydexpressapi/QueryLogisticInfo")]
        public async Task<GetLogisticsResponse> QueryLogisticInfo(LogisticInfoRequestDto request)
        {
            var grpcRequest = _mapper.Map<LogisticInfoRequestDto, GetLogisticsRequest>(request);
            var result =await _getLogisticsClient.GetLogisticsInfoAsync(grpcRequest);
            _logger.LogInformation(result.ToString());
            return await Task.FromResult(result);
        }
    }
}
