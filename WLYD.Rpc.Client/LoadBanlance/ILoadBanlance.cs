using System.Collections.Generic;
using Compeng.Rpc.Client.Model;

namespace Compeng.Rpc.Client.LoadBanlance
{
    /// <summary>
    /// 负载均衡
    /// </summary>
    public interface ILoadBanlance
    {
        HostAndPort Select(string serviceName,List<HostAndPort> list);
    }
}