using System.ComponentModel.DataAnnotations;
using Compeng.PEQP.Model.Enums;

namespace Compeng.PEQP.Model.ExpressInferceModels.Request
{
    /// <summary>
    /// 电子面单取消请求实体
    /// </summary>
    public class ExpressCancelOrderRequest
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [Required(ErrorMessage = "订单编号不能为空", AllowEmptyStrings = false)]
        public string OrderCode { get; set; }

        /// <summary>
        /// 快递公司编码必填,填写范围:YTO(圆通),SF(顺丰),STO(申通),ZTO(中通)
        /// </summary>
        [Required(ErrorMessage = "快递公司编码不能为空", AllowEmptyStrings = false)]
        public ExpressCompanyCode ShipperCode { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        [Required(ErrorMessage = "快递单号不能为空", AllowEmptyStrings = false)]
        public string LogisticCode { get; set; }

        /// <summary>
        /// 电子面单客户号
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 电子面单密码
        /// </summary>
        public string CustomerPwd { get; set; }
    }
}