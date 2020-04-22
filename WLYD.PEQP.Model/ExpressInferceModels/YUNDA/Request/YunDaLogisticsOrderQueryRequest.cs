using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Request
{
    /// <summary>
    /// 物流信息查询
    /// </summary>
    public class YunDaLogisticsOrderQueryRequest
    {
        [XmlArray("mailnos")]
        public List<MailNoRequest> Mailnos { get; set; }

        public YunDaLogisticsOrderQueryRequest()
        {
            Mailnos = new List<MailNoRequest>();
        }
    }

    [Serializable]
    public class MailNoRequest
    {
        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mailno")]
        public string MailNo { get; set; }
    }
}
