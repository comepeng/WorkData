using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Response
{
    /// <summary>
    /// 韵达物流信息查询DTO，持久化到MongoDB
    /// </summary>
    [Serializable]
    public class YunDaLogisticsOrderQueryJsonResponse 
    {
        /// <summary>
        /// 运单号
        /// </summary>
        [JsonProperty("mailno")]
        public string Mailno { get; set; }

        /// <summary>
        /// 查询结果TRUE/FALSE
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }

        /// <summary>
        /// 查询时间
        /// </summary>
        [JsonProperty("time")]
        public string QueryTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        [JsonProperty("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// 物流信息列表
        /// </summary>
        [JsonProperty("steps")]
        public List<LogisticsOrderStep> Steps { get; set; }
    }

    [Serializable]
    public class LogisticsOrderStep
    {
        /// <summary>
        /// 时间
        /// </summary>
        [JsonProperty("time")]
        public string OrderTime { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// 网点代码
        /// </summary>
        [JsonProperty("station")]
        public string Station { get; set; }

        /// <summary>
        /// 网点电话
        /// </summary>
        [JsonProperty("station_phone")]
        public string StationPhone { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 物流详情
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("next")]
        public string NextContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("next_name")]
        public string NextName { get; set; }
    }
}
