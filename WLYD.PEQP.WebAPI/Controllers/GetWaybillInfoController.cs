using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Compeng.PEQP.Dto.Dtos;
using Compeng.PEQP.Dto.Enums;

namespace Compeng.PEQP.WebAPI.Controllers
{
    [ApiController]
    public class GetWaybillInfoController : ControllerBase
    {
        private readonly GetWaybillInfo.GetWaybillInfoClient _client;

        public GetWaybillInfoController(GetWaybillInfo.GetWaybillInfoClient client)
        {
            _client = client;
        }

        /// <summary>
        /// 根据运单信息获取发货人信息，收货人信息等
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("peqpapi/wlydexpressapi/getwaybillinfo")]
        public async Task<GetWaybillInfoResponseDto> Get(GetWaybillInfoRequestDto dto)
        {
            GetWaybillInfoResponseDto result;
            if (Enum.TryParse<ExpressEnum>( dto.Express.ToString(), out var resultEnum))
            {
                switch (resultEnum)
                {
                    case ExpressEnum.Sf:
                        var request = new GetWaybillInfoRequest
                        {
                            WaybillNo = dto.WaybillNo
                        };
                        var response = await _client.GetAsync(request);
                        result = new GetWaybillInfoResponseDto
                        {
                            Success = response.Success,
                            Reason = response.Reason,
                            ResultCode = response.ResultCode,
                            Result = new ResultDetail
                            {
                                Receiver = response.Receiver,
                                ReceiverMobile = response.ReceiverMobile,
                                ReceiverPhone = response.ReceiverPhone,
                                Sender = response.Sender,
                                SenderMobile = response.SenderMobile,
                                SenderPhone = response.SenderPhone
                            }
                        };
                        break;
                    default:
                        result = new GetWaybillInfoResponseDto {Reason = "参数错误", Success = false, ResultCode = 101};
                        break;
                }
            }
            else
            {
                result = new GetWaybillInfoResponseDto {Reason = "参数错误", Success = false, ResultCode = 101};
            }
            

            return await Task.FromResult(result);
        }
    }
}