using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Service.IServices.IExpressCreateOrderService;

namespace Compeng.PEQP.Service.Serices.ExpressCreateOrderService
{
    /// <summary>
    /// /// <summary>
    /// 韵达电子面单下单接口服务
    /// </summary>
    /// </summary>
    public class YunDaCreateOrderService : IExpressCreateOrderService
    {
        public Task<ExpressGetElectronicsurfaceResponse> CreateExpressOrderAsync(ExpressGetElectronicsurfaceRequest request)
        {
            throw new System.NotImplementedException("韵达平台未接入");
        }
    }
}
