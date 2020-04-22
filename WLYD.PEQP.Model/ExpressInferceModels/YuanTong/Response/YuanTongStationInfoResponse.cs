using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YTO.Response
{
    /// <summary>
    /// 根据网点ID查询网点服务信息接口
    /// </summary>
    [Serializable]
    [XmlRoot("StationDetailsInfo")]
    public class YuanTongStationInfoResponse
    {
        /// <summary>
        /// 网点编号
        /// </summary>
        [XmlElement("Station_Code")]
        public string StationCode { get; set; }

        /// <summary>
        /// 官网显示网点名称
        /// </summary>
        [XmlElement("Station_OutName")]
        public string StationOutName { get; set; }

        /// <summary>
        /// 服务电话
        /// </summary>
        [XmlElement("Query_Tel")]
        public string QueryTel { get; set; }

        /// <summary>
        /// 服务范围
        /// </summary>
        [XmlElement("Serve_Area")]
        public string ServeArea { get; set; }

        /// <summary>
        /// 非派送范围
        /// </summary>
        [XmlElement("Stop_Area")]
        public string StopArea { get; set; }

        /// <summary>
        /// 服务时效
        /// </summary>
        [XmlElement("Serve_Date")]
        public string ServeDate { get; set; }

        /// <summary>
        /// 服务范围
        /// </summary>
        [XmlElement("Especial_Serve")]
        public string EspecialServe { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        [XmlElement("Remark")]
        public string Remark { get; set; }
    }
}
