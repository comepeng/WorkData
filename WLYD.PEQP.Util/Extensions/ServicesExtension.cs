using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compeng.PEQP.Util.Extensions
{
    /// <summary>
    /// IServiceCollection扩展
    /// </summary>
    public static class ServicesExtension
    {

        public static IServiceCollection Add<TService>(this IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(typeof(TService));
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient(typeof(TService));
                    break;
                default:
                    services.AddScoped(typeof(TService));
                    break;
            }
            return services;
        }
        public static IServiceCollection Add<TService>(this IServiceCollection services, ServiceLifetime serviceLifetime, Func<IServiceProvider, TService> func) where TService : Delegate
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<TService>(func);
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient<TService>(func);
                    break;
                default:
                    services.AddScoped<TService>(func);
                    break;
            }
            return services;
        }
    }
}
