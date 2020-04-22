using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Response
{
    /// <summary>
    /// 中通获取集包地大头笔接口响应DTO
    /// </summary>
    [Serializable]
    public class ZhongTongGetPaintMarkerResponse
    {
        /// <summary>
        /// 返回的消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 返回的结果
        /// </summary>
        [JsonProperty("result")]
        public MarkResult Result { get; set; }

        /// <summary>
        /// 返回的状态（TRUE\FALSE）
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 返回的状态码
        /// </summary>
        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }
        
    }

    [Serializable]
    public class MarkResult
    {
        /// <summary>
        /// 大头笔
        /// </summary>
        [JsonProperty("mark")]
        public string Mark { get; set; }

        /// <summary>
        /// 集包地
        /// </summary>
        [JsonProperty("bagAddr")]
        public string BagAddr { get; set; }
    }
}
