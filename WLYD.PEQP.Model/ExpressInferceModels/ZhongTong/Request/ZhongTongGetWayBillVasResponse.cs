using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Request
{
    /// <summary>
    /// 获取运单号响应实体（可传保价金额服务）
    /// </summary>
    [Serializable]
    public class ZhongTongGetWayBillVasResponse
    {
        /// <summary>
        /// 信息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// true：调用成功，false：调用失败
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("result")]
        public ZTOGetWayBillResult Result { get; set; }
    }

    /// <summary>
    /// 返回结果信息
    /// </summary>
    public class ZTOGetWayBillResult
    {
        /// <summary>
        /// 运单号
        /// </summary>
        [JsonProperty("billCode")]
        public string BillCode { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty("orderCode")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 合作商订单号
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 大头笔信息
        /// </summary>
        [JsonProperty("bigMarkInfo")]
        public ZTOBigMarkInfo BigMarkInfo { get; set; }
    }

    /// <summary>
    /// 大头笔信息
    /// </summary>
    public class ZTOBigMarkInfo
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
