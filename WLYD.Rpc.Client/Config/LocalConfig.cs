using System.Collections.Generic;

namespace Compeng.Rpc.Client.Config
{
    /// <summary>
    /// 本地服务
    /// </summary>
    internal class LocalConfig
    {
        /// <summary>
        /// 服务列表
        /// </summary>
        public List<ServiceConfig> List { get; set; }
    }
}