using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YTO.Response
{
    /// <summary>
    /// 圆通电子面单下单
    /// </summary>
    [Serializable]
    [XmlRoot("Response")]
    public class YuanTongOrderResponse
    {
        /// <summary>
        /// 请求结果
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 成功或失败编码 200-成功
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 物流公司ID
        /// </summary>
        [XmlElement("logisticProviderID")]
        public string LogisticProviderID { get; set; }

        /// <summary>
        /// 成功绑定的面单号
        /// </summary>
        [XmlElement("mailNo")]
        public string MailNo { get; set; }

        /// <summary>
        /// 物流订单号
        /// </summary>
        [XmlElement("txLogisticID")]
        public string TxLogisticID { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        [XmlElement("clientID")]
        public string ClientID { get; set; }

        /// <summary>
        /// 始发网点
        /// </summary>
        [XmlElement("originateOrgCode")]
        public string OriginateOrgCode { get; set; }

        /// <summary>
        /// 时效类型
        /// </summary>
        [XmlElement("EffectType")]
        public string EffectType { get; set; }

        /// <summary>
        /// 承诺送达时间
        /// </summary>
        [XmlElement("estimatedTrrivalTime")]
        public string EstimatedTrrivalTime { get; set; }

        /// <summary>
        /// 失败原因	
        /// </summary>
        [XmlElement("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 二维码信息	
        /// </summary>
        [XmlElement("qrCode")]
        public string QrCode { get; set; }

        /// <summary>
        /// 集包地信息	
        /// </summary>
        [XmlElement("distributeInfo")]
        public YTODistributeInfo DistributeInfo { get; set; }
    }

    /// <summary>
    /// 集包地信息
    /// </summary>
    public class YTODistributeInfo
    {
        /// <summary>
        /// 三段码	
        /// </summary>
        [XmlElement("shortAddress")]
        public string ShortAddress { get; set; }

        /// <summary>
        /// 末端网点代码	
        /// </summary>
        [XmlElement("consigneeBranchCode")]
        public string ConsigneeBranchCode { get; set; }

        /// <summary>
        /// 集包地中心代码
        /// </summary>
        [XmlElement("packageCenterCode")]
        public string PackageCenterCode { get; set; }

        /// <summary>
        /// 集包地中心名称	
        /// </summary>
        [XmlElement("packageCenterName")]
        public string PackageCenterName { get; set; }

        /// <summary>
        /// 五级地址
        /// </summary>
        [XmlElement("printKeyWord")]
        public string PrintKeyWord { get; set; }
    }
}
