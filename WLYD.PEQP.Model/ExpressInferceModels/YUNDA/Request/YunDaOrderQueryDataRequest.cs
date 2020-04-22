using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Request
{
    /// <summary>
    /// 订单查询请求DTO
    /// </summary>
    public class YunDaOrderQueryDataRequest
    {
        [XmlArray("orders")]
        [XmlArrayItem("order")]
        public List<QueryOrder> Orders { get; set; }

        public YunDaOrderQueryDataRequest()
        {
            Orders = new List<QueryOrder>();
        }

    }

    [Serializable]
    public class QueryOrder
    {
        /// <summary>
        /// 订单唯一序列号
        /// </summary>
        [XmlElement("order_serial_no")]
        public string OrderSerialNo { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mailno")]
        public string MailNo { get; set; }

        /// <summary>
        /// 是否需要pdf文件：1需要，0不需要
        /// </summary>
        [XmlElement("print_file")]
        public string IsPrintFile { get; set; }

        /// <summary>
        /// 是否需要打印文件的json数据，用于直接生成打印图片：1需要，0不需要
        /// </summary>
        [XmlElement("json_data")]
        public string IsJsonData { get; set; }

        /// <summary>
        /// 强制加密参数，1加密
        /// </summary>
        [XmlElement("json_encrypt")]
        public string JsonEncrypt { get; set; }
    }
}
