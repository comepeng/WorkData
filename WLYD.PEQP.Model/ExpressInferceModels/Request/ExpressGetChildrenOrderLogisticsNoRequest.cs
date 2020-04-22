using Compeng.PEQP.Model.Enums;

namespace Compeng.PEQP.Model.ExpressInferceModels.Request
{
    /// <summary>
    /// 获取子单号请求实体
    /// </summary>
    public class ExpressGetChildrenOrderLogisticsNoRequest
    {
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 新增加的包裹数，不超过100
        /// </summary>
        public int ParcelQuantity { get; set; }
        /// <summary>
        /// 快递公司编码
        /// </summary>
        public ExpressCompanyCode ShipperCode { get; set; }
    }
}
