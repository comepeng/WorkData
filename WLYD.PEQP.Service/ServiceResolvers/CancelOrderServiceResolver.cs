using System;
using Microsoft.Extensions.DependencyInjection;
using Compeng.PEQP.Model.Enums;
using Compeng.PEQP.Service.IServices.IExpressCancelOrderService;
using Compeng.PEQP.Service.Serices.ExpressCancelOrderService;
using Compeng.PEQP.Util.Extensions;
namespace Compeng.PEQP.Service.ServiceResolvers
{
    public delegate IExpressCancelOrderService CancelOrderServiceResolver(ExpressCompanyCode expressCompanyCode);
    public static class CancelOrderServiceResolve
    {
        private static Func<IServiceProvider, CancelOrderServiceResolver> GetCancelOrderService = serviceProvider => expressCompanyCode =>
        {
            switch (expressCompanyCode)
            {
                case ExpressCompanyCode.YTO:
                    return serviceProvider.GetRequiredService<YuanTongCancelOrderService>();
                case ExpressCompanyCode.YUNDA:
                    return serviceProvider.GetRequiredService<YunDaCancelOrderService>();
                case ExpressCompanyCode.SF:
                    return serviceProvider.GetRequiredService<ShunFengCancelOrderService>();
                case ExpressCompanyCode.ZTO:
                    return serviceProvider.GetRequiredService<ZhongTongCancelOrderService>();
                default:
                    throw new ArgumentException("此快递公司不支持获取取消订单");

            }
        };
        public static IServiceCollection RegistryCancelOrderService(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            services
               .Add<YunDaCancelOrderService>(serviceLifetime)
               .Add<YunDaCancelOrderService>(serviceLifetime)
               .Add<ZhongTongCancelOrderService>(serviceLifetime)
               .Add<ShunFengCancelOrderService>(serviceLifetime)
               .Add<CancelOrderServiceResolver>(serviceLifetime, GetCancelOrderService);
            return services;
        }
       
    }
}
