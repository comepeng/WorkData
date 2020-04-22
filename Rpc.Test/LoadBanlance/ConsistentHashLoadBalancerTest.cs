using System.Collections.Generic;
using System.Diagnostics;
using Compeng.Rpc.Client.LoadBanlance;
using Xunit;
using Xunit.Abstractions;

namespace Rpc.Test.LoadBanlance
{
    public class ConsistentHashLoadBalancerTestHelper 
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ConsistentHashLoadBalancerTestHelper(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestConsistentHash()
        {
            var loadBalancer = new ConsistentHash();
            var cnt = new Dictionary<int, int>();
            const int size = 20;
            const int total = 100000;
            const string serviceName = "嘿嘿";
            for (var i = 0; i < size; i++)
            {
                cnt.Add(9000 + i, 0);
            }

            var list = LoadBalancerTestHelper.BuildList(size);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < total; i++)
            {
                var hostAndPort = loadBalancer.Select(serviceName, list);
                var port = hostAndPort.Port;
                cnt[port]++;
            }

            stopwatch.Stop();
            _testOutputHelper.WriteLine("执行耗时：" + stopwatch.ElapsedMilliseconds);

            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (cnt[9000 + i] > 0)
                {
                    count++;
                }
            }

            //始终落在一台机器上
            Assert.Equal(1, count);
        }
    }
}