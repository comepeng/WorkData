using System.Collections.Generic;
using Compeng.Rpc.Client.Model;

namespace Compeng.Rpc.Client.Discovery
{
    /// <summary>
    /// 服务发现
    /// </summary>
    internal interface IServiceDiscovery
    {
        /// <summary>
        /// 获取服务地址列表
        /// </summary>
        /// <param name="serviceName">服务名称，各系统应不同</param>
        /// <param name="version">版本号，不同注册中心实现可不一样。nacos使用group，zk使用其他</param>
        /// <returns></returns>
        List<HostAndPort> GetEndpoints(string serviceName);
    }
}