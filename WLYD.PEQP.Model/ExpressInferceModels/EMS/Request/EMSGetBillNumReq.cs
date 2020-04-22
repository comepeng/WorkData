﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Compeng.OMS.BusinessModel.InterfaceModels.EMS.Request
{
    /// <summary>
    /// 通过大客户号，业务类型获取详情单号
    /// </summary>
    [Serializable]
    [XmlRoot("XMLInfo")]
    public class EMSGetBillNumReq
    {
        /// <summary>
        /// 账号（大客户号）,测试账号：A1234567890Z
        /// </summary>
        [XmlElement("sysAccount")]
        public string SysAccount { get; set; }

        /// <summary>
        /// 密码（对接密码）,测试密码：Test123456 用md5加密
        /// </summary>
        [XmlElement("passWord")]
        public string PassWord { get; set; }

        /// <summary>
        /// 单号量,1-100之间数字
        /// </summary>
        [XmlElement("billNoAmount")]
        public string BillNoAmount { get; set; }

        /// <summary>
        /// 对接授权码
        /// </summary>
        [XmlElement("appKey")]
        public string AppKey { get; set; }

        /// <summary>
        /// 业务类型,1:标准快递;8:代收到付;9:快递包裹
        /// </summary>
        [XmlElement("businessType")]
        public string BusinessType { get; set; }
    }
}
