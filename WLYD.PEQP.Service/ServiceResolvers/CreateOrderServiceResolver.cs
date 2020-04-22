using System;
using Microsoft.Extensions.DependencyInjection;
using Compeng.PEQP.Model.Enums;
using Compeng.PEQP.Service.IServices.IExpressCreateOrderService;
using Compeng.PEQP.Service.Serices.ExpressCreateOrderService;
using Compeng.PEQP.Util.Extensions;
namespace Compeng.PEQP.Service.ServiceResolvers
{
    public delegate IExpressCreateOrderService CreateOrderServiceResolver(ExpressCompanyCode expressCompanyCode);
    public static class CreateOrderServiceResolve
    {
        private static Func<IServiceProvider, CreateOrderServiceResolver> GetCreateOrderService = serviceProvider => expressCompanyCode =>
        {
            switch (expressCompanyCode)
            {
                case ExpressCompanyCode.DEBANG:
                    return serviceProvider.GetRequiredService<DeBangCreateOrderService>();
                case ExpressCompanyCode.ZTO:
                    return serviceProvider.GetRequiredService<ZhongTongCreateOrderService>();
                case ExpressCompanyCode.YTO:
                    return serviceProvider.GetRequiredService<YuanTongCreateOrderService>();
                case ExpressCompanyCode.YUNDA:
                    return serviceProvider.GetRequiredService<YunDaCreateOrderService>();
                case ExpressCompanyCode.SF:
                    return serviceProvider.GetRequiredService<ShunFengCreateOrderService>();
                default:
                    throw new ArgumentException("此快递公司不支持获取电子面单");

            }
        };
        public static IServiceCollection RegistryCreateOrderService(this IServiceCollection services,ServiceLifetime serviceLifetime= ServiceLifetime.Singleton)
        {
            services
                .Add<YuanTongCreateOrderService>(serviceLifetime)
               .Add<ZhongTongCreateOrderService>(serviceLifetime)
               .Add<YunDaCreateOrderService>(serviceLifetime)
               .Add<DeBangCreateOrderService>(serviceLifetime)
               .Add<ShunFengCreateOrderService>(serviceLifetime)
               .Add<CreateOrderServiceResolver>(serviceLifetime, GetCreateOrderService)
               ;
            return services;
        }
       
    }
}
