using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Compeng.PEQP.Model.ExpressInferceModels.SfPartner;
using Compeng.PEQP.Model.ExpressInferceModels.ShunFeng;
using Compeng.PEQP.Model.ExpressInferceModels.YTO;
using Compeng.PEQP.Model.ExpressInferceModels.ZTO;

namespace Compeng.PEQP.Service.ServiceRegistry
{
    public static class RegistryApiConfig
    {
        public static IServiceCollection RegistryApiConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions()
                    .Configure<YuanTongApiConfig>(configuration.GetSection(nameof(YuanTongApiConfig)))
                    .Configure<ZhongTongApiConfig>(configuration.GetSection(nameof(ZhongTongApiConfig)))
                    .Configure<ShunFengApiConfig>(configuration.GetSection(nameof(ShunFengApiConfig)))
                    .Configure<SfPartnerAPIConfig>(configuration.GetSection(nameof(SfPartnerAPIConfig)))
                    ;

            services.AddTransient(provider => provider.GetRequiredService<IOptions<YuanTongApiConfig>>().Value);
            services.AddTransient(provider => provider.GetRequiredService<IOptions<ZhongTongApiConfig>>().Value);
            services.AddTransient(provider => provider.GetRequiredService<IOptions<ShunFengApiConfig>>().Value);
            services.AddTransient(provider => provider.GetRequiredService<IOptions<SfPartnerAPIConfig>>().Value);
            return services;
        }
    }
}
