using Compeng.PEQP.Model.ExpressInferceModels.Enums;

namespace Compeng.PEQP.Model.ExpressInferceModels.Response
{
    /// <summary>
    /// 物联快递接口通用返回响应类
    /// </summary>
    public class ExpressBackResponse
    {
        /// <summary>
        /// 用户 ID
        /// </summary>
        public string EBusinessID { get; set; }

        /// <summary>
        /// 返回编码
        /// </summary>
        public ExpressInterfaceResponseStatusCode ResultCode { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 成功与否(true/false)
        /// </summary>
        public bool Success { get; set; }
    }
}