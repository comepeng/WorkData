namespace Compeng.OMS.BusinessModel.InterfaceModels.SF.SFQiao
{
    /// <summary>
    /// 顺丰申请子单号响应
    /// </summary>
    public class ShunFengQiaoChilrenOrderResponse
    {
        /// <summary>
        /// 订单号
        /// </summary>        
        public string Orderid { get; set; }

        /// <summary>
        /// 顺丰母运单号
        /// </summary>

        public string MainMailno { get; set; }

        /// <summary>
        /// 新增的子运单号,可多个单号,以逗号分隔
        /// </summary>
        public string ZdMailno { get; set; }
    }
}
