using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Response
{
    /// <summary>
    /// 韵达下单及修改订单接口响应
    /// </summary>
    public class YUNDAResponse
    {
        /// <summary>
        /// 响应码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }
    }

    [Serializable]
    public class ResultResponse
    {
        /// <summary>
        /// 结果信息
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("orders")]
        public string Orders { get; set; }
    }

    [Serializable]
    public class ResultQueryResponse
    {

        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("order")]
        public string order { get; set; }
    }

}
