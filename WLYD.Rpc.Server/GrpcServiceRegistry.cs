using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nacos;
using Compeng.Rpc.Core.Util;

namespace Compeng.Rpc.Server
{
    public static class GrpcServiceRegistry
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="configuration">配置</param>
        /// <param name="types">grpc服务的类型</param>
        /// <returns></returns>
        public static IServiceProvider UseGrpcService(this IServiceProvider provider, IConfiguration configuration,
            params Type[] types) //where T : class, new()
        {
            // 1、获取配置文件中的
            var discovery = configuration["Service:Discovery"];
            if (discovery == "nacos")
            {
                var ip = configuration["Service:IP"];
                var port = Convert.ToInt32(configuration["Service:Port"]);
//                IServiceCollection services=provider.
//                .AddNacos(_configuration);
                var list = new HashSet<RegisterInstanceRequest>();
                foreach (var type in types)
                {
                    list.Add(new RegisterInstanceRequest
                    {
                        Ip = ip, Port = port, Enable = true, ServiceName = GrpcUtil.GetGrpcServiceName(type),
                        Ephemeral = false //, GroupName = groupName
                    });
                }

                var lifetime = provider.GetRequiredService<IHostApplicationLifetime>();
                var nacosNamingClient = provider.GetRequiredService<INacosNamingClient>();
                // 2、订阅注册与反注册
                lifetime.ApplicationStarted.Register(() =>
                {
                    foreach (var registerInstanceRequest in list)
                    {
                        nacosNamingClient.RegisterInstanceAsync(registerInstanceRequest).ConfigureAwait(false)
                            .GetAwaiter();
                    }
                });
                lifetime.ApplicationStopping.Register(() =>
                {
                    foreach (var registerInstanceRequest in list)
                    {
                        nacosNamingClient.RemoveInstanceAsync(new RemoveInstanceRequest
                        {
                            Ip = registerInstanceRequest.Ip,
                            Port = registerInstanceRequest.Port,
                            ServiceName = registerInstanceRequest.ServiceName,
                            Ephemeral = registerInstanceRequest.Ephemeral,
                            GroupName = registerInstanceRequest.GroupName
                        }).ConfigureAwait(false).GetAwaiter();
                    }
                });
            }

            return provider;
        }
    }
}