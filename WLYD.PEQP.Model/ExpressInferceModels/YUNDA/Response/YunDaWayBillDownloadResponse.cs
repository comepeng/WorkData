using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Response
{
    /// <summary>
    /// 韵达电子面单下单响应DTO，持久化到MongoDB
    /// </summary>
    [Serializable]
    [XmlRoot("response")]
    public class YunDaWayBillDownloadResponse 
    {
        /// <summary>
        /// 订单唯一序列号
        /// </summary>
        [XmlElement("order_serial_no")]
        public string OrderSerialNo { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mail_no")]
        public string MailNo { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        [XmlElement("pdf_info")]
        public string PDFInfo { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime SystemCreateTime { get; set; }
    }
}
