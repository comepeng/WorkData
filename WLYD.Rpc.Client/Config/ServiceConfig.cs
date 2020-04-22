using Compeng.Rpc.Client.Model;

namespace Compeng.Rpc.Client.Config
{
    internal class ServiceConfig : HostAndPort
    {
        public string ServiceName { get; set; }
    }
}