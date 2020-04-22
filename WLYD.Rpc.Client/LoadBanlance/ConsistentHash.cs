using Compeng.Rpc.Client.Model;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Compeng.Rpc.Client.LoadBanlance
{
    /// <summary>
    /// 一致性hash算法，经压测，比轮询算法慢200倍
    /// </summary>
    public class ConsistentHash : ILoadBanlance
    {
        private readonly ConcurrentDictionary<string, ConsistentHashSelector> _selectorCache =
            new ConcurrentDictionary<string, ConsistentHashSelector>();

        public HostAndPort Select(string serviceName, List<HostAndPort> list)
        {
            var hashCode = list.GetHashCode();
            var selector = _selectorCache.GetOrAdd(serviceName,
                _ => new ConsistentHashSelector(list, hashCode));

            return selector.Select(serviceName);
        }
    }

    /// <summary>
    /// 一致性hash选择器
    /// </summary>
    internal class ConsistentHashSelector
    {
        private readonly int _hashCode;

        /// <summary>
        /// 虚拟节点
        /// </summary>
        private readonly SortedDictionary<long, HostAndPort> _virtualNodes;

        /// <summary>
        /// 初始化一个选择器
        /// </summary>
        /// <param name="actualNodes">真实节点</param>
        /// <param name="hashCode">hash值</param>
        public ConsistentHashSelector(IEnumerable<HostAndPort> actualNodes, int hashCode)
        {
            _hashCode = hashCode;
            _virtualNodes = new SortedDictionary<long, HostAndPort>();
            // 设置越大越慢，精度越高 todo: 后续根据情况增大或者减少，要求此值必须为2的N次方
            const int num = 32;
            foreach (var hostAndPort in actualNodes)
            {
                for (var i = 0; i < num / 4; i++)
                {
                    var digest = (hostAndPort.Ip + hostAndPort.Port + i).Md5EncryptToBytes();
                    for (var h = 0; h < 4; h++)
                    {
                        var hash = digest.Hash(h);
                        _virtualNodes.Add(hash, hostAndPort);
                    }
                }
            }
        }

        public HostAndPort Select(string key)
        {
            return selectForKey(key.Md5EncryptToBytes().Hash(0));
        }

        private HostAndPort selectForKey(long hash)
        {
            //默认找>=hash值的节点
            var node = _virtualNodes.FirstOrDefault(k => k.Key >= hash);
            //如果没有找到，则取第一个
            if (node.Key == 0)
            {
                node = _virtualNodes.First();
            }

            return node.Value;
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }
    }
}