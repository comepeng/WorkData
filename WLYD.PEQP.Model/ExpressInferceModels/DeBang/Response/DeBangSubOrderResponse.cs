using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.DBL.Response
{
    /// <summary>
    /// 标准轨迹订阅响应DTO
    /// </summary>
    [Serializable]
    public class DeBangSubOrderResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 同success	
        /// </summary>
        [JsonProperty("result")]
        public bool Result { get; set; }
    }
}
