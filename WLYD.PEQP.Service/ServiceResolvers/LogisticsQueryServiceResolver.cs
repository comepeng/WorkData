using System;
using Microsoft.Extensions.DependencyInjection;
using Compeng.PEQP.Model.Enums;
using Compeng.PEQP.Service.IServices.IExpressLogisticsQueryService;
using Compeng.PEQP.Service.Serices.ExpressLogisticsQueryService;
using Compeng.PEQP.Util.Extensions;
namespace Compeng.PEQP.Service.ServiceResolvers
{
    public delegate IExpressLogisiticsQueryService LogisticsQueryServiceResolver(ExpressCompanyCode expressCompanyCode);
    public static class LogisticsQueryServiceResolve
    {

        private static Func<IServiceProvider, LogisticsQueryServiceResolver> GetLogisticsQueryService = serviceProvider => expressCompanyCode =>
        {
            switch (expressCompanyCode)
            {
                case ExpressCompanyCode.DEBANG:
                    return serviceProvider.GetRequiredService<DeBangLogisticsQueryService>();
                case ExpressCompanyCode.ZTO:
                    return serviceProvider.GetRequiredService<ZhongTongLogisticsQueryService>();
                case ExpressCompanyCode.YTO:
                    return serviceProvider.GetRequiredService<YuanTongLogisticsQueryService>();
                case ExpressCompanyCode.YUNDA:
                    return serviceProvider.GetRequiredService<YunDaLogisticsQueryService>();
                case ExpressCompanyCode.SF:
                    return serviceProvider.GetRequiredService<ShunFengLogisticsQueryService>();
                default:
                    throw new ArgumentException("此快递公司不支持查询物流信息");

            }
        };
        public static IServiceCollection RegistryLogisticsQueryService(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            services
               .Add<YuanTongLogisticsQueryService>(serviceLifetime)
               .Add<ZhongTongLogisticsQueryService>(serviceLifetime)
               .Add<DeBangLogisticsQueryService>(serviceLifetime)
               .Add<YunDaLogisticsQueryService>(serviceLifetime)
               .Add<ShunFengLogisticsQueryService>(serviceLifetime)
               .Add<LogisticsQueryServiceResolver>(serviceLifetime, GetLogisticsQueryService);
            return services;
        }
       
    }
}
