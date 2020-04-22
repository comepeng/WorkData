using Compeng.PEQP.Model.ExpressInferceModels.Enums;

namespace Compeng.PEQP.Model.ExpressInferceModels.Response
{
    /// <summary>
    /// 获取子单号响应实体
    /// </summary>
    public class ExpressGetChildrenOrderLogisticsNoResponse
    {
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 用户 ID
        /// </summary>
        public string EBusinessID { get; set; }

        /// <summary>
        /// 母运单号
        /// </summary>
        public string MainLogisticCode { get; set; }

        /// <summary>
        /// 新增的子运单号，可以多个，以英文逗号隔开
        /// </summary>
        public string ZDLogisticCodes { get; set; }

        /// <summary>
        /// 成功与否(true/false)
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 返回编码
        /// </summary>
        public ExpressInterfaceResponseStatusCode ResultCode { get; set; }
    }
}
