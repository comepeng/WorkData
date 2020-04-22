using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Compeng.PEQP.Service.ServiceResolvers;

namespace Compeng.PEQP.Service.ServiceRegistry
{
    public static class RegistryServices
    {
        public static IServiceCollection RegistryService(this IServiceCollection service, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            service.RegistryApiConfigs(configuration)
            // .RegistryRepositories(configuration, serviceLifetime)           
            .RegistryHttpClients()            
            .RegistryCreateOrderService(serviceLifetime)
            .RegistryLogisticsQueryService(serviceLifetime)
            .RegistryCancelOrderService(serviceLifetime)
            .RegistryChildrenOrderService(serviceLifetime)
            ;
            return service;
        }

    }
}
