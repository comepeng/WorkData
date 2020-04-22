using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Compeng.Rpc.Client.Config;
using Compeng.Rpc.Client.Model;

namespace Compeng.Rpc.Client.Discovery
{
    /// <summary>
    /// 本地注册中心，服务规模小的时候使用。
    /// </summary>
    internal class LocalDiscovery : IServiceDiscovery
    {
        private readonly IOptions<LocalConfig> _config;

        public LocalDiscovery(IOptions<LocalConfig> config)
        {
            _config = config;
        }

        public List<HostAndPort> GetEndpoints(string serviceName)
        {
            //todo: 此处使用缓存，增强性能
            var list = new List<HostAndPort>();
            if (_config.Value != null)
            {
                foreach (var serviceConfig in _config.Value.List)
                {
                    if (serviceConfig.ServiceName == serviceName)
                    {
                        list.Add(new HostAndPort
                        {
                            Ip = serviceConfig.Ip,
                            Port = serviceConfig.Port
                        });
                    }
                }
            }

            return list;
        }
    }
}