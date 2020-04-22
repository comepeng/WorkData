using System;
using System.Xml.Serialization;

namespace Compeng.OMS.BusinessModel.Messages.SF.OMS.Request
{
    [Serializable]
    [XmlRoot("Request")]
    public class RequestBase
    {
        /// <summary>
        /// 接口名
        /// </summary>
        [XmlAttribute("service")]
        public string Service { get; set; }

        /// <summary>
        /// 语言类型
        /// </summary>
        [XmlAttribute("lang")]
        public string Lang { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("Head")]
        public Head Head { get; set; }
    }

    [Serializable]
    public class Head
    {
        /// <summary>
        /// 接入编码
        /// </summary>
        [XmlElement("AccessCode")]
        public string AccessCode { get; set; }

        /// <summary>
        /// 校验码
        /// </summary>
        [XmlElement("Checkword")]
        public string Checkword { get; set; }

    }

    //[Serializable]
    //public class RequestModel
    //{
    //    /// <summary>
    //    /// MongoDB主键
    //    /// </summary>

    //    [XmlIgnore]
    //    public ObjectId _id { get; set; }

    //}

    [Serializable]
    public class UploadRequestModel
    {
        ///// <summary>
        ///// MongoDB主键
        ///// </summary>

        //[XmlIgnore]
        //public ObjectId _id { get; set; }

        /// <summary>
        /// WMS系统编码
        /// </summary>
        [XmlElement("SysCode")]
        public string SysCode { get; set; }
    }
}
