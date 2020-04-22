using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.DBL.Request
{
    /// <summary>
    /// 德邦标准轨迹订阅
    /// </summary>
    [Serializable]
    public class DeBangSubOrderRequest
    {
        /// <summary>
        /// 运单号
        /// </summary>
        [JsonProperty("tracking_number")]
        public string Tracking_number { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty("order_number")]
        public string Order_number { get; set; }
    }
}
