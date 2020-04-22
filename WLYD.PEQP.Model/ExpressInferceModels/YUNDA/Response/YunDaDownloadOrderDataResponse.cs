using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Response
{
    /// <summary>
    /// 韵达下单及修改响应DTO，持久化到MongoDB
    /// </summary>
    [Serializable]
    public class YunDaDownloadOrderDataResponse 
    {
        /// <summary>
        /// 响应信息列表
        /// </summary>
        [JsonProperty("order")]
        public List<DownloadOrderResponse> order { get; set; }
    }

    [Serializable]
    public class DownloadOrderResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("callback")]
        public string Callback { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [JsonProperty("orderid")]
        public string OrderID { get; set; }

        /// <summary>
        /// 下单结果
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }
    }
}
