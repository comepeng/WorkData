using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Response
{
    /// <summary>
    /// 订单查询返回
    /// </summary>
    [Serializable]
    [XmlRoot("response")]
    public class YunDaLogisticsOrderQueryResponse 
    {
        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mailno")]
        public string MailNo { get; set; }

        /// <summary>
        /// 返回请求状态，成功为true，失败为false
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

        /// <summary>
        /// 错误时错误提示
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 物流状态(got已揽收；transite 运输中；signed签收/妥投；signfail 异常签收，异常妥投)
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 重量信息
        /// </summary>
        [XmlElement("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// 物流信息
        /// </summary>
        [XmlArray("traces")]
        [XmlArrayItem("trace")]
        public List<Trace> Trace { get; set; }

        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime SystemCreateTime { get; set; }
    }

    [Serializable]
    public class Trace
    {
        /// <summary>
        /// 时间
        /// </summary>
        [XmlElement("time")]
        public string Time { get; set; }

        /// <summary>
        /// 站点
        /// </summary>
        [XmlElement("station")]
        public string Station { get; set; }

        /// <summary>
        /// 物流状态(got已揽收；transite 运输中；signed签收/妥投；signfail 异常签收，异常妥投)
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
    }
}
