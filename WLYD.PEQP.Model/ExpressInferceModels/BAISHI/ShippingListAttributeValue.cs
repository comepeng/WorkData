using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.BAISHI
{

    /// <summary>
    /// 特殊业务属性
    /// </summary>
    [Serializable]
    public class ShippingListAttributeValue
    {
        /// <summary>
        /// 特殊业务 属性名称(MONEY)
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }


        /// <summary>
        /// 特殊业务属性值
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }
    }
}
