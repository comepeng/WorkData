using Compeng.PEQP.Dto.SfPartner;

namespace Compeng.PEQP.Dto.Dtos
{
    public class GetWaybillInfoResponseDto
    {
        /// <summary>
        /// 原因
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// (成功true/失败false)
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 返回编码,100成功,101缺少必要参数,102校验问题,103用户问题,104重复下单问题,105其他问题
        /// </summary>
        public int ResultCode { get; set; }

        /// <summary>
        /// 运单信息详情
        /// </summary>
        public ResultDetail Result { get; set; }
    }

    /// <summary>
    /// 结果
    /// </summary>
    public struct ResultDetail
    {
        /// <summary>
        /// 发货人姓名
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// 发货人电话
        /// </summary>
        public string SenderPhone { get; set; }

        /// <summary>
        /// 发货人手机号
        /// </summary>
        public string SenderMobile { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// 收货人手机
        /// </summary>
        public string ReceiverMobile { get; set; }
    }
}