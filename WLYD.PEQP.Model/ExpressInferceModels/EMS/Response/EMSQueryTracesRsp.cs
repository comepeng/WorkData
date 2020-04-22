﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compeng.OMS.BusinessModel.InterfaceModels.EMS.Response
{
    /// <summary>
    /// 路由查询响应
    /// </summary>
    public class EMSQueryTracesRsp
    {
        /// <summary>
        /// 路由信息
        /// </summary>
        [JsonProperty("traces")]
        public List<EMSQueryTraceInfo> TraceInfos { get; set; }
    }

    /// <summary>
    /// 路由节点详情
    /// </summary>
    public class EMSQueryTraceInfo
    {
        /// <summary>
        /// 发生时间
        /// </summary>
        [JsonProperty("acceptTime")]
        public string AcceptTime { get; set; }

        /// <summary>
        /// 节点城市
        /// </summary>
        [JsonProperty("acceptAddress")]
        public string AcceptAddress { get; set; }

        /// <summary>
        /// 路由描述
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }
    }
}
