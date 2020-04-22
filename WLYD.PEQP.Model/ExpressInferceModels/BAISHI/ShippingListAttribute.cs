using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.BAISHI
{

    /// <summary>
    /// 特殊业务（请根据业务需求选择，不同业务对应不同面单模板）
    /// </summary>
    [Serializable]
    public class ShippingListAttribute
    {

        /// <summary>
        /// 特殊业务代码(BEST-FREIGHT:货到付款、BEST-COD：代收 货款)
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 特殊业务属性
        /// </summary>
        [XmlElement("shippingListAttributeValue")]
        public List<ShippingListAttributeValue> shippingListAttributeValue { get; set; }
    }
}
