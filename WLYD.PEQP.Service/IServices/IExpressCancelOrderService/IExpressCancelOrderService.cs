using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;

namespace Compeng.PEQP.Service.IServices.IExpressCancelOrderService
{
    public  interface IExpressCancelOrderService
    {
        Task<ExpressBackResponse> CancelOrderAsync(ExpressCancelOrderRequest request);
    }
}
