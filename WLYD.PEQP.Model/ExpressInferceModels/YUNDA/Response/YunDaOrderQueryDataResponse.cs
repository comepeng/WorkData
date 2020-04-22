using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Response
{
    /// <summary>
    /// 订单查询返回
    /// </summary>
    [Serializable]
    [XmlRoot("response")]
    public class YunDaOrderQueryDataResponse
    { 
        /// <summary>
        /// 返回请求状态，成功为1，失败为0
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 订单唯一序列号
        /// </summary>
        [XmlElement("order_serial_no")]
        public string OrderSerialNo { get; set; }

        /// <summary>
        /// 运单号(create订单创建；withdraw订单已取消；accept接单成功；refuse地址不送达)
        /// </summary>
        [XmlElement("mailno")]
        public string MailNo { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [XmlElement("order_status")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// pdf的文件流 ,BASE64编码
        /// </summary>
        [XmlElement("print_file")]
        public string PrintFile { get; set; }

        /// <summary>
        /// pdf的文本，json格式 ,BASE64编码
        /// </summary>
        [XmlElement("json_data")]
        public string JsonData { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime SystemCreateTime { get; set; }
    }
}
