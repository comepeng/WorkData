using System;

namespace Compeng.PEQP.Model.ExpressInferceModels.Request
{
    /// <summary>
    /// 请求头内容
    /// </summary>
    public  class RequestHeader
    {
        /// <summary>
        /// 申请的app唯一标识
        /// </summary>
        // public string AppId { get; set; }
        /// <summary>
        /// app密钥
        /// </summary>

        public string AppKey { get; set; }

        /// <summary>
        /// 时间戳单位为秒
        /// </summary>
        // public double RequestTimestamp { get; set; }

        /// <summary>
        /// 请求唯一标识 GUID
        /// </summary>
        // public Guid RequestId { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }
    }
}
