using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;

namespace Compeng.PEQP.Service.IServices.IExpressLogisticsQueryService
{
    /// <summary>
    /// 快递公司物流查询接口
    /// </summary>
    public  interface IExpressLogisiticsQueryService
    {
        Task<ExpressQueryLogisticInfoResponse> QueryLogisticInfoAsync(ExpressQueryLogisticInfoRequest request);
    }
}
