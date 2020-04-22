using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YTO.Response
{
    /// <summary>
    /// 圆通目的中心信息接口
    /// </summary>
    [Serializable]
    [XmlRoot("SendTransferInfo")]
    public class YuanTongTransferInfoResponse
    {
        /// <summary>
        /// 目的中心条码
        /// </summary>
        [XmlElement("TransferCenterCode")]
        public string TransferCenterCode { get; set; }

        /// <summary>
        /// 目的中心名称
        /// </summary>
        [XmlElement("TransferCenterName")]
        public string TransferCenterName { get; set; }
    }
}
