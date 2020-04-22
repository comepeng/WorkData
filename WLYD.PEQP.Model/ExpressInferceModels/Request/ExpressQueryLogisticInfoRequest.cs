using System.ComponentModel.DataAnnotations;
using Compeng.PEQP.Model.Enums;

namespace Compeng.PEQP.Model.ExpressInferceModels.Request
{
    /// <summary>
    /// 查询物流轨迹请求实体
    /// </summary>
    public class ExpressQueryLogisticInfoRequest
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// ShipperCode 
        /// </summary>
        /// <value>为 JD和SF时必填；ShipperCode 为其他快递时，不填.</value>
        public string CustomerName { get; set; }

        /// <summary>
        /// 快递公司编码必填,填写范围:YTO(圆通),SF(顺丰),STO(申通),ZTO(中通)
        /// </summary>
        [Required]
        public ExpressCompanyCode ShipperCode { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        [Required]
        public string LogisticCode { get; set; }
    }
}
