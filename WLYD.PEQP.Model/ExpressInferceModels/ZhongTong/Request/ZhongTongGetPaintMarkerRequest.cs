using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Request
{
    /// <summary>
    /// 中通获取集包地大头笔接口请求DTO
    /// </summary>
    [Serializable]
    public class ZhongTongGetPaintMarkerRequest
    {
        /// <summary>
        /// 唯一标示（建议使用运单号作为标识,方面出现异常的时候,通过运单查询日志定位问题）
        /// </summary>
        [JsonProperty("unionCode")]
        public string UnionCode { get; set; }

        /// <summary>
        /// 发件省份
        /// </summary>
        [JsonProperty("send_province")]
        public string SendProvince { get; set; }

        /// <summary>
        /// 发件城市
        /// </summary>
        [JsonProperty("send_city")]
        public string SendCity { get; set; }

        /// <summary>
        /// 发件区县
        /// </summary>
        [JsonProperty("send_district")]
        public string SendDistrict { get; set; }

        /// <summary>
        /// 发件详细地址
        /// </summary>
        [JsonProperty("send_address")]
        public string SendAddress { get; set; }

        /// <summary>
        /// 收件省份
        /// </summary>
        [JsonProperty("receive_province")]
        public string ReceiveProvince { get; set; }

        /// <summary>
        /// 收件城市
        /// </summary>
        [JsonProperty("receive_city")]
        public string ReceiveCity { get; set; }

        /// <summary>
        /// 收件区县
        /// </summary>
        [JsonProperty("receive_district")]
        public string ReceiveDistrict { get; set; }

        /// <summary>
        /// 收件地址
        /// </summary>
        [JsonProperty("receive_address")]
        public string ReceiveAddress { get; set; }
    }
}
