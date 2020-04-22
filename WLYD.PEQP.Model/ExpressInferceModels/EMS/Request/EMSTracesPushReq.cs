﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Compeng.OMS.BusinessModel.InterfaceModels.EMS.Request
{
    /// <summary>
    /// EMS反馈路由
    /// </summary>
    [Serializable]
    [XmlRoot("request")]
    public class EMSTracesPushReq
    {
        /// <summary>
        /// 路由信息
        /// </summary>
        [XmlArray("listexpressmail")]
        [XmlArrayItem("expressmail")]
        public List<EMSExpressmail> ExpressmailList { get; set; } = new List<EMSExpressmail>();
    }

    public class EMSExpressmail
    {
        /// <summary>
        /// 状态的顺序号
        /// </summary>
        [XmlElement("serialnumber")]
        public string Serialnumber { get; set; }

        /// <summary>
        /// 邮件号
        /// </summary>
        [XmlElement("mailnum")]
        public string Mailnum { get; set; }

        /// <summary>
        /// 日期 YYYYMMDD
        /// </summary>
        [XmlElement("procdate")]
        public string Procdate { get; set; }

        /// <summary>
        /// 时间 HHMMSS
        /// </summary>
        [XmlElement("proctime")]
        public string Proctime { get; set; }

        /// <summary>
        /// 所在地名称
        /// </summary>
        [XmlElement("orgfullname")]
        public string Orgfullname { get; set; }

        /// <summary>
        /// 业务动作，00：收寄、10：妥投、20: 未妥投、30：经转过程中、40：离开处理中心、41：到达处理中心、
        /// 50安排投递、51：正在投递、60：揽收
        /// </summary>
        [XmlElement("action")]
        public string Action { get; set; }

        /// <summary>
        /// 妥投,只有当action=10时该字段才有值，参见附录中签收情况代码表
        /// </summary>
        [XmlElement("properdelivery")]
        public string Properdelivery { get; set; }

        /// <summary>
        /// 未妥投,只有当action=20的时候该字段才有值，参见附录中未妥投原因代码表
        /// </summary>
        [XmlElement("notproperdelivery")]
        public string Notproperdelivery { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// 0：表示无效(表示该邮件当前这个状态标识为无效的状态，判断依据邮件号、日期、时间、动作)，1：表示有效
        /// </summary>
        [XmlElement("effect")]
        public string Effect { get; set; }
    }

}
