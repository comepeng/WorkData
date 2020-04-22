using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Response
{
    /// <summary>
    /// 中通订阅快件轨迹服务响应DTO
    /// </summary>
    [Serializable]
    public class ZhongTongSubBillLogResponse
    {
        /// <summary>
        /// 订阅id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 订阅状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 状态描述 
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }
    }
}
