using Compeng.Rpc.Client.Model;
using Compeng.Rpc.Core.Util;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Compeng.Rpc.Client.LoadBanlance
{
    /// <summary>
    /// 轮询
    /// </summary>
    public class RoundRobin : ILoadBanlance
    {
        private readonly ConcurrentDictionary<string, AtomicInteger> _sequences =
            new ConcurrentDictionary<string, AtomicInteger>();

        public HostAndPort Select(string serviceName, List<HostAndPort> list)
        {
            var integer = _sequences.GetOrAdd(serviceName, (s) => new AtomicInteger(0));
            var length = list.Count;
            //return list[i++%length];
            return list[integer.GetAndIncrement() % length];
        }
    }
}