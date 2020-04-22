using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Service.IServices.IExpressCancelOrderService;

namespace Compeng.PEQP.Service.Serices.ExpressCancelOrderService
{
    public class YunDaCancelOrderService : IExpressCancelOrderService
    {
        public Task<ExpressBackResponse> CancelOrderAsync(ExpressCancelOrderRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
