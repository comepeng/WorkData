using System.Collections.Generic;
using Nacos;
using Compeng.Rpc.Client.Model;

namespace Compeng.Rpc.Client.Discovery
{
    internal class NacosDiscovery : IServiceDiscovery
    {
        private readonly INacosNamingClient _namingClient;

        public NacosDiscovery(INacosNamingClient namingClient)
        {
            _namingClient = namingClient;
        }

        public List<HostAndPort> GetEndpoints(string serviceName)
        {
            var task = _namingClient.ListInstancesAsync(new ListInstancesRequest
            {
                ServiceName = serviceName, HealthyOnly = true
            });
            var list = new List<HostAndPort>();

            if (!task.IsCompleted) return list;
            foreach (var resultHost in task.Result.Hosts)
            {
                list.Add(new HostAndPort
                {
                    Ip = resultHost.Ip,
                    Port = resultHost.Port
                });
            }

            return list;
        }
    }
}