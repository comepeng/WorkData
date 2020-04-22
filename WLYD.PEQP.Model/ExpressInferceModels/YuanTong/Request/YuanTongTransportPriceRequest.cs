using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YTO.Request
{
    /// <summary>
    /// 标准运价查询接口
    /// </summary>
    [Serializable]
    [XmlRoot("TransportInfo")]
    public class YuanTongTransportPriceRequest
    {
        /// <summary>
        /// 快件的始发省份
        /// </summary>
        [XmlElement("StartProvince")]
        public string StartProvince { get; set; }

        /// <summary>
        /// 快件的始发城市
        /// </summary>
        [XmlElement("StartCity")]
        public string StartCity { get; set; }

        /// <summary>
        /// 	快件的目的省份
        /// </summary>
        [XmlElement("EndProvince")]
        public string EndProvince { get; set; }

        /// <summary>
        /// 	快件的目的城市
        /// </summary>
        [XmlElement("EndCity")]
        public string EndCity { get; set; }

        /// <summary>
        /// 	快件的重量
        /// </summary>
        [XmlElement("GoodsWeight")]
        public string GoodsWeight { get; set; }

        /// <summary>
        /// 	快件的长度
        /// </summary>
        [XmlElement("GoodsLength")]
        public string GoodsLength { get; set; }

        /// <summary>
        /// 快件的宽度
        /// </summary>
        [XmlElement("GoodsWidth")]
        public string GoodsWidth { get; set; }

        /// <summary>
        /// 快件的高度
        /// </summary>
        [XmlElement("GoodsHeight")]
        public string GoodsHeight { get; set; }
    }
}
