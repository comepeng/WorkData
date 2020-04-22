using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Request
{
    /// <summary>
    /// 订单状态通知接口
    /// </summary>
    public class YunDaNoticeStatusDataRequest
    {
        [XmlArray("Orders")]
        [XmlArrayItem("Order")]
        public List<NoticeOrder> Orders { get; set; }
    }

    [Serializable]
    public class NoticeOrder
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [XmlElement("orderid")]
        public string OrderID { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mailno")]
        public string MailNo { get; set; }

        /// <summary>
        /// 指令
        /// </summary>
        [XmlElement("command")]
        public string Command { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        [XmlElement("parameter")]
        public string Parameter { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        [XmlElement("callback")]
        public string Callback { get; set; }
    }

}
