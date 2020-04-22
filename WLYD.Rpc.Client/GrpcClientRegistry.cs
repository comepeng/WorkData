using System;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Compeng.Rpc.Client.Config;
using Compeng.Rpc.Client.Discovery;
using Compeng.Rpc.Client.LoadBanlance;

namespace Compeng.Rpc.Client
{
    public static class GrpcClientRegistry
    {
        /// <summary>
        /// 配置客户端grpc服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigGrpc(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddSingleton<ChannelManager>()
                .AddSingleton<CallInvoker, RpcCallInvoker>()
                .AddSingleton<ILoadBanlance, RoundRobin>();
            var discovery = configuration["Service:Discovery"];
            switch (discovery)
            {
                case "local":
                    services.AddSingleton<IServiceDiscovery, LocalDiscovery>()
                        .AddOptions().Configure<LocalConfig>(configuration.GetSection("Service:LocalConfig"));
                    break;
                case "nacos":
                    services.AddNacos(configuration.GetSection("Service"))
                        .AddSingleton<IServiceDiscovery, NacosDiscovery>();
                    break;
                default:
                    throw new ArgumentException("服务发现必须为，local或者nacos");
            }

            return services;
        }

        /// <summary>
        /// 注册grpc服务
        /// </summary>
        /// <param name="services"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IServiceCollection AddGrpcClient<T>(this IServiceCollection services) where T : ClientBase<T>
        {
            return services.AddSingleton<T>();
        }
    }
}