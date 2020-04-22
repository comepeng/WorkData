using System.Threading.Tasks;
using Grpc.Core;
using Compeng.PEQP.Dto.SfPartner;
using Compeng.PEQP.Service.HttpClients.SfPartner;

namespace Compeng.PEQP.GrpcService.Services
{
    public class GetWaybillInfoService :GetWaybillInfo.GetWaybillInfoBase
    {
        private readonly SfPartnerHttpClient _client;

        public GetWaybillInfoService(SfPartnerHttpClient client)
        {
            _client = client;
        }

        public override async Task<GetWaybillInfoResponse> Get(GetWaybillInfoRequest request, ServerCallContext context)
        {
            var waybillInfoAsync = await _client.GetWaybillInfoAsync(new WaybillInfoRequest { WaybillNo = request.WaybillNo });
            var response = new GetWaybillInfoResponse();
            if (waybillInfoAsync.Result=="0")
            {
                response.Success = true;
                response.ResultCode = 100;
                response.Receiver = waybillInfoAsync.ResultObject.Receiver;
                response.ReceiverMobile = waybillInfoAsync.ResultObject.ReceiverMobile;
                response.ReceiverPhone = waybillInfoAsync.ResultObject.ReceiverPhone;
                response.Sender = waybillInfoAsync.ResultObject.Sender;
                response.SenderMobile = waybillInfoAsync.ResultObject.SenderMobile;
                response.SenderPhone = waybillInfoAsync.ResultObject.SenderPhone;
            }
            else
            {
                response.ResultCode = 105;
                response.Success = false;
                response.Reason = waybillInfoAsync.ResultObject.Message;
            }
            return await Task.FromResult(response);
        }
    }
}