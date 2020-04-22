using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.BAISHI.Request
{
    /// <summary>
    /// 订单状态信息推送接口
    /// </summary>
    [Serializable]
    [XmlRoot("KDOrderStatusPushReq")]
    public class KDOrderStatusPushReq
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [XmlElement("txLogisticID")]
        public string TxLogisticID { get; set; }

        /// <summary>
        /// 物流状态,取值:创建成功(CREATE_SUCCESS)、创建失败(CREATE_FAIL);接单(ACCEPT)、不接单(UNACCEPT);揽收成功(GOT)、揽收失败(GOT_FAILED);
        /// 签收成功(SIGNED)、派件扫描(SENT_SCAN);流转信息(TRACKING)
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mailNo")]
        public string MailNo { get; set; }

        /// <summary>
        /// 到达时间 (格式化为“yyyy-MM-dd HH:mm:ss.0 CST”的形式)
        /// </summary>
        [XmlElement("acceptTime")]
        public string AcceptTime { get; set; }

        /// <summary>
        /// 现在所在城市
        /// </summary>
        [XmlElement("currentCity")]
        public string CurrentCity { get; set; }

        /// <summary>
        /// 目标城市
        /// </summary>
        [XmlElement("nextCity")]
        public string NextCity { get; set; }

        /// <summary>
        /// 网点
        /// </summary>
        [XmlElement("facility")]
        public string Facility { get; set; }

        /// <summary>
        /// 联系方式（包括手机，电话等）
        /// </summary>
        [XmlElement("contactInfo")]
        public string ContactInfo { get; set; }

        /// <summary>
        /// 称重信息
        /// </summary>
        [XmlElement("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// 流转信息
        /// </summary>
        [XmlElement("trackingInfo")]
        public string TrackingInfo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
    }
}
