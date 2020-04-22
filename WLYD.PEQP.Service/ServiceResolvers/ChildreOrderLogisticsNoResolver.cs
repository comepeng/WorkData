using Microsoft.Extensions.DependencyInjection;
using System;
using Compeng.PEQP.Model.Enums;
using Compeng.PEQP.Service.IServices.IExpressGetChildrenOrderService;
using Compeng.PEQP.Service.Serices.ExpressGetChildrenOrderService;
using Compeng.PEQP.Util.Extensions;
namespace Compeng.PEQP.Service.ServiceResolvers
{


    public delegate IExpressGetChildrenOrderLogisticsNo ChildrenOrderLogisticsNoResolver(ExpressCompanyCode expressCompanyCode);
    public static class ChildreOrderLogisticsNoResolve
    {
        private static Func<IServiceProvider, ChildrenOrderLogisticsNoResolver> GetChildrenOrderService = serviceProvider => expressCompanyCode =>
        {
            switch (expressCompanyCode)
            {
                case ExpressCompanyCode.SF:
                    return serviceProvider.GetRequiredService<ShunFengGetChildrenOrderService>();             
                default:
                    throw new ArgumentException("此快递公司不支持获取子单号");

            }
        };
        public static IServiceCollection RegistryChildrenOrderService(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            services
                .Add<ShunFengGetChildrenOrderService>(serviceLifetime)               
               .Add<ChildrenOrderLogisticsNoResolver>(serviceLifetime, GetChildrenOrderService);
            return services;
        }
        
    }
}
