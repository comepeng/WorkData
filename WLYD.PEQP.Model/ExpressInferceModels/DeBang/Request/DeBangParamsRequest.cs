using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.DBL.Request
{
    /// <summary>
    /// 德邦请求参数
    /// </summary>
    [Serializable]
    public class DeBangParamsRequest
    {
        /// <summary>
        /// 核算请求参数
        /// </summary>
        [JsonProperty("params")]
        public string DBLParams { get; set; }

        /// <summary>
        /// 区域密文摘要
        /// </summary>
        [JsonProperty("digest")]
        public string Digest { get; set; }

        /// <summary>
        /// 核算当前时间戳 ,当前时间毫秒数
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// 核算第三方接入商的公司编码(双方约定,建议公司简拼或者代码,字母大写)
        /// </summary>
        [JsonProperty("companyCode")]
        public string CompanyCode { get; set; }
    }
}
