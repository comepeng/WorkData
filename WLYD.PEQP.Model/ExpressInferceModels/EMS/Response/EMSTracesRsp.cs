﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Compeng.OMS.BusinessModel.InterfaceModels.EMS.Response
{
    /// <summary>
    /// EMS反馈路由响应
    /// </summary>
    [Serializable]
    [XmlRoot("response")]
    public class EMSTracesRsp
    {
        /// <summary>
        /// 0:表示失败，失败的时候failmailnums保存的是失败的邮件号，1：表示成功
        /// </summary>
        [XmlElement("success")]
        public string Success { get; set; }

        /// <summary>
        /// 如果success=0，该字段保存的是失败的邮件号，考虑到后面的批量反馈，可以使用英文的逗号分隔失败的邮件号
        /// </summary>
        [XmlElement("failmailnums")]
        public string Failmailnums { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
    }
}
