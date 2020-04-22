using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Request
{
    /// <summary>
    /// 中通订阅快件轨迹服务请求DTO
    /// </summary>
    [Serializable]
    public class ZhongTongSubBillLogRequest
    {
        /// <summary>
        /// 订阅ID,唯一
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [JsonProperty("billCode")]
        public string BillCode { get; set; }

        /// <summary>
        /// callBack（固定参数,注意大小写）
        /// </summary>
        [JsonProperty("pushCategory")]
        public string PushCategory { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        [JsonProperty("pushTarget")]
        public string PushTarget { get; set; }

        /// <summary>
        /// 1 （固定参数)
        /// </summary>
        [JsonProperty("pushTime")]
        public int PushTime { get; set; }

        /// <summary>
        /// 1-收件、2-发件、4-到件、8-派送、16-签收、32-问题件，订阅阅多种状态 状态码相加即可，如全量订阅则为 63
        /// </summary>
        [JsonProperty("subscriptionCategory")]
        public int SubscriptionCategory { get; set; }

        /// <summary>
        /// 订阅人（ 测试环境统一为：test，生产环境在联调通过后分配。）
        /// </summary>
        [JsonProperty("createBy")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 如果回调地址为HTTPS ，入参 ssl=1 且必填
        /// </summary>
        [JsonProperty("ssl")]
        public string Ssl { get; set; }
    }
}
