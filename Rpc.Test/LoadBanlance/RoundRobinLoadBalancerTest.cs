using System.Collections.Generic;
using System.Diagnostics;
using Compeng.Rpc.Client.LoadBanlance;
using Xunit;
using Xunit.Abstractions;

namespace Rpc.Test.LoadBanlance
{
    public class RoundRobinLoadBalancerTest 
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public RoundRobinLoadBalancerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestRoundRobin()
        {
            var loadBalancer = new RoundRobin();
            var cnt = new Dictionary<int, int>();
            const int size = 20;
            const int total = 100000;
            const string serviceName = "嘿嘿";
            {
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
                _testOutputHelper.WriteLine("执行耗时" + stopwatch.ElapsedMilliseconds.ToString());
                var avg = total / size;
                for (var i = 0; i < size; i++)
                {
                    Assert.True(avg == cnt[9000 + i]);
                }
            }
            //todo: 带权重的负载
        }
    }
}