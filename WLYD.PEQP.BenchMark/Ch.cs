using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using Compeng.Rpc.Client.LoadBanlance;
using Compeng.Rpc.Client.Model;
using System.Collections.Generic;

namespace Compeng.PEQP.BenchMark
{
    [SimpleJob(RuntimeMoniker.CoreRt31)]
    [Config(typeof(Config))]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class Ch
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                Add(Job.MediumRun.WithGcServer(true).WithGcForce(true).WithId("ServerForce"));
                Add(Job.MediumRun.WithGcServer(true).WithGcForce(false).WithId("Server"));
                Add(Job.MediumRun.WithGcServer(false).WithGcForce(true).WithId("Workstation"));
                Add(Job.MediumRun.WithGcServer(false).WithGcForce(false).WithId("WorkstationForce"));
            }
        }
        [Params(10, 1000)] public int N;
        private int size = 20;
        private ILoadBanlance _loadBanlance;
        private List<HostAndPort> hostAndPorts;
        private string serviceName = "哈哈哈，嘿嘿。呵呵呵";

        [GlobalSetup]
        public void Setup()
        {
            hostAndPorts = LoadBalancerTestHelper.BuildList(size);
            _loadBanlance = new ConsistentHash();
        }

        [Benchmark]
        public void TestRoundRobin()
        {
            for (var i = 0; i < N; i++)
            {
                var hostAndPort = _loadBanlance.Select(serviceName, hostAndPorts);
            }
        }
    }
}