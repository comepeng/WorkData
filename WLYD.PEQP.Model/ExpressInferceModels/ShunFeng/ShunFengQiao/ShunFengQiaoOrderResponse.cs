namespace Compeng.OMS.BusinessModel.InterfaceModels.SF.SFQiao
{
    /// <summary>
    /// 顺丰下单响应模型
    /// </summary>
    public class ShunFengQiaoOrderResponse
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string Orderid { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>

        public string Mailno { get; set; }

        /// <summary>
        /// 顺丰签回单服务运单号
        /// </summary>
        public string Return_tracking_no { get; set; }

        /// <summary>
        /// 原寄地区域代码，可用于顺丰电子运单标签打印。
        /// </summary>
        public string Origincode { get; set; }

        /// <summary>
        /// 目的地区域代码，可用于顺丰电子运单标签打印。
        /// </summary>
        public string Destcode { get; set; }

        /// <summary>
        /// 筛单结果 1 人工确认 2 可收派 3 不可以收派
        /// </summary>
        public string Filter_result { get; set; }

        /// <summary>
        /// 如果filter_result=3时为必填，不可以收派的原因代码：
        /// 1：收方超范围
        /// 2：派方超范围
        /// 3：其它原因
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 代理单号
        /// </summary>
        public string AgentMailno { get; set; }

        /// <summary>
        /// 地址映射码
        /// </summary>
        public string Mapping_mark { get; set; }
        public string OriginTransferCode { get; set; }
        public string LogisticCode { get; set; }
        public string OriginCityCode { get; set; }
        public string OriginDeptCode { get; set; }
        public string OriginTeamCode { get; set; }
        public string DestCityCode { get; set; }
        public string DestDeptCode { get; set; }
        public string DestDeptCodeMapping { get; set; }
        public string DestTeamCode { get; set; }
        public string DestTeamCodeMapping { get; set; }
        public string AbFlag { get; set; }
        public string PrintIcon { get; set; }
        public string ProCode { get; set; }
        public string TwoDimensionCode { get; set; }
        public string PrintFlag { get; set; }
        public string XbFlag { get; set; }
        public string CodingMappingOut { get; set; }
        public string CodingMapping { get; set; }
        public string DestRouteLabel { get; set; }
        public string DestTransferCode { get; set; }
        public bool HasDetail { get; set; }
        public bool Success { get; set; }
        public string Reason { get; set; }
        public string Result { get; set; }
        public string ResultCode { get; set; }
    }
}
