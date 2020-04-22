﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Compeng.OMS.BusinessModel.InterfaceModels.EMS.Response
{
    /// <summary>
    /// EMS响应体
    /// </summary>
    [Serializable]
    [XmlRoot("response")]
    public class EMSResponse
    {
        /// <summary>
        /// 调用结果,1:无错误;0:有错误
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement("errorDesc")]
        public string ErrorDesc { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlElement("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 邮件号集合
        /// </summary>
        [XmlArray("assignIds")]
        [XmlArrayItem("assignId")]
        public List<EMSAssignIdInfo> AssignIds { get; set; }

        /// <summary>
        /// 数据错误（内层）
        /// </summary>
        [XmlElement("ErrorDetail")]
        public EMSErrorDetail EMSErrorDetail { get; set; }
    }

    public class EMSAssignIdInfo
    {
        /// <summary>
        /// 分配的邮件号
        /// </summary>
        [XmlElement("billno")]
        public string Billno { get; set; }
    }

    public class EMSErrorDetail
    {
        /// <summary>
        /// 错误数据ID
        /// </summary>
        [XmlElement("dataID")]
        public string DataID { get; set; }

        /// <summary>
        /// 数据错误描述
        /// </summary>
        [XmlElement("dataError")]
        public string DataError { get; set; }

        /// <summary>
        /// 数据错误代码
        /// </summary>
        [XmlElement("dErrorCode")]
        public string DErrorCode { get; set; }
    }
}
