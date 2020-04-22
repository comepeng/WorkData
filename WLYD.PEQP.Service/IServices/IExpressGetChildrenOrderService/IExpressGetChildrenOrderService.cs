using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;

namespace Compeng.PEQP.Service.IServices.IExpressGetChildrenOrderService
{
    /// <summary>
    /// 获取子单号服务接口
    /// </summary>
    public interface IExpressGetChildrenOrderLogisticsNo
    {
        Task<ExpressGetChildrenOrderLogisticsNoResponse> GetChildrenOrderLogisticsNoAsync(ExpressGetChildrenOrderLogisticsNoRequest request);

    }
}
