namespace Compeng.OMS.BusinessModel.InterfaceModels.SF.SFQiao
{
    /// <summary>
    /// 丰桥路由推送接口
    /// </summary>
    public class ShunFengQiaoRoutePushRequest
    {
        /// <summary>
        /// 路由节点信息编号，每一个id代表一条不同的路由节点信息
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 顺丰运单号
        /// </summary>
        public string Mailno { get; set; }

        /// <summary>
        /// 客户订单号
        /// </summary>
        public string Orderid { get; set; }

        /// <summary>
        /// 路由节点产生的时间，格式：YYYY-MM-DD HH24:MM:SS，示例：2012-7-30 09:30:00
        /// </summary>
        public string AcceptTime { get; set; }

        /// <summary>
        /// 路由节点发生的城市
        /// </summary>
        public string AcceptAddress { get; set; }

        /// <summary>
        /// 路由节点具体描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 路由节点操作码
        /// </summary>
        public string OpCode { get; set; }

    }
}
