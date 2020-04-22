using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Response
{
    [Serializable]
    public class ZhongTongResponse
    {

    }

    [Serializable]
    public class ZhonTongResultStatusReponse
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
        public object Result { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("data")]
        public object ResultData { get; set; }

        /// <summary>
        /// 返回的状态（TRUE\FALSE）
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; set; }

        /// <summary>
        /// 返回的状态码
        /// </summary>
        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }
    }

    /// <summary>
    /// 物流回推接口响应实体
    /// </summary>
    public class ZTOLogisticsBackResponse
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误代码说明
        /// </summary>
        [JsonProperty("errorMsg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
