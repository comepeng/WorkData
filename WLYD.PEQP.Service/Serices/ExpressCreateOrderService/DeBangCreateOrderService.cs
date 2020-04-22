using System;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Service.IServices.IExpressCreateOrderService;

namespace Compeng.PEQP.Service.Serices.ExpressCreateOrderService
{/// <summary>
 /// 德邦电子面单下单接口服务
 /// </summary>
    public class DeBangCreateOrderService : IExpressCreateOrderService
    {
        public Task<ExpressGetElectronicsurfaceResponse> CreateExpressOrderAsync(ExpressGetElectronicsurfaceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
