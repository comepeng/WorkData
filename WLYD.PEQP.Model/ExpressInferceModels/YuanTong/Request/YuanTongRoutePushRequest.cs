using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YTO.Request
{
    /// <summary>
    /// 圆通路由推送接口
    /// </summary>
    [XmlRoot("UpdateInfo")]
    public class YuanTongRoutePushRequest
    {
        /// <summary>
        /// 物流公司ID 必须为YTO
        /// </summary>
        [XmlElement("logisticProviderID")]
        public string LogisticProviderID { get; set; }

        /// <summary>
        /// vip客户标识(客户编号)
        /// </summary>
        [XmlElement("clientID")]
        public string ClientID { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mailNo")]
        public string MailNo { get; set; }

        /// <summary>
        /// 物流号
        /// </summary>
        [XmlElement("txLogisticID")]
        public string TxLogisticID { get; set; }

        /// <summary>
        /// 通知类型STATUS：物流状态
        /// </summary>
        [XmlElement("infoType")]
        public string InfoType { get; set; }

        /// <summary>
        /// ACCEPT 接单；UNACCEPT 不接单；GOT 已收件；NOT_SEND 揽收失败；ARRIVAL 已收入；DEPARTURE 已发出；PACKAGE 已打包；UNPACK 已拆包；
        /// SENT_SCAN 派件；SIGNED 签收成功；FAILED 签收失败
        /// </summary>
        [XmlElement("infoContent")]
        public string InfoContent { get; set; }

        /// <summary>
        /// 备注或失败原因（值为中文原因或备注）
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 揽收重量
        /// </summary>
        [XmlElement("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// 签收人
        /// </summary>
        [XmlElement("signedName")]
        public string SignedName { get; set; }

        /// <summary>
        /// 该状态操作人员，签收、派送、揽件
        /// </summary>
        [XmlElement("deliveryName")]
        public string DeliveryName { get; set; }

        /// <summary>
        /// 事件发生时间
        /// </summary>
        [XmlElement("acceptTime")]
        public string AcceptTime { get; set; }

        /// <summary>
        /// 联系方式（包括手机，电话等）
        /// </summary>
        [XmlElement("contactInfo")]
        public string ContactInfo { get; set; }
    }
}
