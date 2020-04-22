using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using System.Threading.Tasks;

namespace Compeng.PEQP.Service.IServices.IExpressCreateOrderService
{
    /// <summary>
    /// 快递公司通用接口
    /// </summary>
    public  interface IExpressCreateOrderService
    {
        Task<ExpressGetElectronicsurfaceResponse> CreateExpressOrderAsync(ExpressGetElectronicsurfaceRequest request);
       
    }
}
