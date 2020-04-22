using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YTO.Response
{
    /// <summary>
    /// 圆通物流信息查询
    /// </summary>
    [Serializable]
    [XmlRoot("ufinterface")]
    public class YuanTongQueryLogisticsResponse
    {
        [XmlArray("Result")]
        [XmlArrayItem("WaybillProcessInfo")]
        public List<YTOWaybillProcessInfo> WaybillProcessInfos { get; set; }
    }

    [Serializable]
    public class YTOWaybillProcessInfo
    {
        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("Waybill_No")]
        public string WaybillNo { get; set; }

        /// <summary>
        /// 走件产生时间
        /// </summary>
        [XmlElement("Upload_Time")]
        public string UploadTime { get; set; }

        /// <summary>
        /// 物流信息
        /// </summary>
        [XmlElement("ProcessInfo")]
        public string ProcessInfo { get; set; }

        /// <summary>
        /// 物流状态
        /// 100-揽件；200-在途；300-派件；400-签收
        /// </summary>       
        public string ProcessStatus { get; set; }
    }
}
