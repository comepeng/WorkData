using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Response
{
    /// <summary>
    /// 中通电子面单下单DTO，持续化MONGODB
    /// </summary>
    [Serializable]
    public class ZhongTongWaybillDownloadResponse 
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// 单号
        /// </summary>
        [JsonProperty("billCode")]
        public string BillCode { get; set; }

        /// <summary>
        /// 是否更新 
        /// </summary>
        [JsonProperty("update")]
        public string Update { get; set; }

        /// <summary>
        /// 网点编号
        /// </summary>
        [JsonProperty("siteCode")]
        public string SiteCode { get; set; }

        /// <summary>
        /// 网点名称
        /// </summary>
        [JsonProperty("siteName")]
        public string SiteName { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        public DateTime SystemCreateTime { get; set; }
    }

    public class WaybillResultResponse
    {
        /// <summary>
        /// 返回的数据
        /// </summary>
        [JsonProperty("data")]
        public ZhongTongWaybillDownloadResponse Data { get; set; }

        /// <summary>
        /// 返回的消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 返回的结果（TRUE\FALSE）
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
