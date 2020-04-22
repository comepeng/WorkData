using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YTO.Response
{
    /// <summary>
    /// 圆通错误信息响应
    /// </summary>
    [Serializable]
    [XmlRoot("Response")]
    public class YuanTongErrorResponse
    {
        /// <summary>
        /// 成功与否
        /// </summary>
        [XmlElement("success")]
        public string Success { get; set; }

        /// <summary>
        /// 错误原由
        /// </summary>
        [XmlElement("reason")]
        public string Reason { get; set; }
    }
}
