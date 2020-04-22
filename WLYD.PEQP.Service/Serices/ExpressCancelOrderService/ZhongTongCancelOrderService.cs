using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Service.IServices.IExpressCancelOrderService;

namespace Compeng.PEQP.Service.Serices.ExpressCancelOrderService
{
    /// <summary>
    /// 中通取消订单服务
    /// </summary>
    public class ZhongTongCancelOrderService : IExpressCancelOrderService
    {
        public Task<ExpressBackResponse> CancelOrderAsync(ExpressCancelOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
