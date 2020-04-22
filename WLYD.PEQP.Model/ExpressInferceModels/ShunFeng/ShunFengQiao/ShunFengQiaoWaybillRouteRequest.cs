using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.OMS.BusinessModel.InterfaceModels.SF.SFQiao
{
    /// <summary>
    /// 路由推送接口
    /// </summary>
    [XmlRoot("RouteList")]
    public class ShunFengQiaoWaybillRouteRequest
    {
        /// <summary>
        /// 路由数据
        /// </summary>
        [XmlElement("WaybillRoute")]
        public List<BPSRoute> RouteList { get; set; }
    }

    [XmlRoot("WaybillRoute")]
    public class BPSRoute
    {
        /// <summary>
        /// 路由节点信息编号，每一个 id 代表一条不同的路由节点信息。
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// 顺丰运单号
        /// </summary>
        [XmlAttribute("mailno")]
        public string MailNo { get; set; }

        /// <summary>
        /// 客户订单号
        /// </summary>
        [XmlAttribute("orderid")]
        public string OrderId { get; set; }

        /// <summary>
        /// 路由节点产生的时间，格式：YYYY-MM-DD HH24:MM:SS，示例：2012-7-30 09:30:00。
        /// </summary>
        [XmlAttribute("acceptTime")]
        public string AcceptTime { get; set; }

        /// <summary>
        /// 路由节点发生的城市
        /// </summary>
        [XmlAttribute("acceptAddress")]
        public string AcceptAddress { get; set; }

        /// <summary>
        /// 路由节点具体描述
        /// </summary>
        [XmlAttribute("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 路由节点操作码
        /// </summary>
        [XmlAttribute("opCode")]
        public string OpCode { get; set; }
    }
}
