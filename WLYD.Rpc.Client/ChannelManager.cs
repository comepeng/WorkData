using System;
using System.Collections.Concurrent;
using System.Linq;
using Grpc.Core;
using Compeng.Rpc.Client.Discovery;
using Compeng.Rpc.Client.LoadBanlance;
using Compeng.Rpc.Client.Model;

namespace Compeng.Rpc.Client
{
    /// <summary>
    /// 连接管理器
    /// </summary>
    internal class ChannelManager
    {
        private readonly IServiceDiscovery _serviceDiscovery;
        private readonly ILoadBanlance _loadBanlance;

        private readonly ConcurrentDictionary<HostAndPort, Channel> _channels =
            new ConcurrentDictionary<HostAndPort, Channel>();

        static ChannelManager()
        {
            //确保使用tlc连接
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        }

        public ChannelManager(IServiceDiscovery serviceDiscovery, ILoadBanlance loadBanlance)
        {
            _serviceDiscovery = serviceDiscovery;
            _loadBanlance = loadBanlance;
        }

        public Channel GetChannel(string grpcServiceName)
        {
            var serviceAddressPorts = _serviceDiscovery.GetEndpoints(grpcServiceName);
            if (!serviceAddressPorts.Any())
            {
                throw new ArgumentException($"{grpcServiceName} 没有可用的服务列表");
            }

            var addressPort = _loadBanlance.Select(grpcServiceName, serviceAddressPorts);
            var channel = _channels.GetOrAdd(addressPort, s => new Channel(s.Ip, s.Port, ChannelCredentials.Insecure));
            //todo: 比较默认Channel和Grpc.net.client中的GrpcChannel.ForAddress
            return channel;
        }
    }
}