using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Service.IServices.IExpressLogisticsQueryService;

namespace Compeng.PEQP.Service.Serices.ExpressLogisticsQueryService
{
    public class BaiShiLogisticsQueryService : IExpressLogisiticsQueryService
    {
        public Task<ExpressQueryLogisticInfoResponse> QueryLogisticInfoAsync(ExpressQueryLogisticInfoRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
