using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.BAISHI.Request
{
    /// <summary>
    /// 构建请求参数
    /// </summary>
    [Serializable]
    [XmlRoot("request")]
    public class KdWaybillApplyNotifyReq
    {

        /// <summary>
        /// 发货模式固定值：false
        /// </summary>
        [XmlElement("deliveryConfirm")]
        public bool DeliveryConfirm { get; set; }


        /// <summary>
        /// 消息ID: 消息的唯一标识（msgId保持唯一，则每次返回新的单号，否则返回这个msgId之前的结果）
        /// </summary>
        [XmlElement("msgId")]
        public string MsgId { get; set; }


        /// <summary>
        /// 电子面单账户信息
        /// </summary>
        [XmlElement("auth")]
        public List<Auth> Auth { get; set; }


        /// <summary>
        /// 业务参数
        /// </summary>
        [XmlElement("EDIPrintDetailList")]
        public List<EDIPrintDetailList> EDIPrintDetailList { get; set; }


        /// <summary>
        /// 门店编码
        /// </summary>
        [XmlElement("storeCode")]
        public string StoreCode { get; set; }

    }
}
