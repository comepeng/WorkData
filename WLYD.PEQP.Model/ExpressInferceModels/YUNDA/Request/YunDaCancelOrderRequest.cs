using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Request
{
    /// <summary>
    /// 订单取消接口
    /// </summary>
    public class YunDaCancelOrderRequest
    {
        [XmlArray("Orders")]
        [XmlArrayItem("Order")]
        public List<CancelOrder> CancelOrders { get; set; }
    }

    [Serializable]
    public class CancelOrder
    {
        /// <summary>
        /// 订单唯一序列号
        /// </summary>
        [XmlElement("order_serial_no")]
        public string OrderSerialNo { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mailno")]
        public string MailNo { get; set; }
    }
}
