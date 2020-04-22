using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using Compeng.PEQP.Service.HttpClients.BaiShi;
using Compeng.PEQP.Service.HttpClients.DeBang;
using Compeng.PEQP.Service.HttpClients.SfPartner;
using Compeng.PEQP.Service.HttpClients.ShunFeng;
using Compeng.PEQP.Service.HttpClients.YuanTong;
using Compeng.PEQP.Service.HttpClients.YunDa;
using Compeng.PEQP.Service.HttpClients.ZhongTong;

namespace Compeng.PEQP.Service.ServiceRegistry
{
    public static  class RegistryHttpClient
    {
        public static IServiceCollection  RegistryHttpClients( this IServiceCollection service)
        {
          
            service.AddHttpClient<YuanTongHttpClient>().AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
           {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(10)
          }));
            service.AddHttpClient<YunDaHttpClient>();
            service.AddHttpClient<ZhongTongHttpClient>();
            service.AddHttpClient<DeBangHttpClient>();
            service.AddHttpClient<ShunFengHttpClient>();
            service.AddHttpClient<BaiShiHttpClient>();
            service.AddHttpClient<SfPartnerHttpClient>();
            return service;
        }
    }
}
