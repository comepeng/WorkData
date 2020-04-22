using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.BAISHI.Request
{


    /// <summary>
    /// 业务参数
    /// </summary>
    [Serializable]
    public class EDIPrintDetailList
    {
        /// <summary>
        /// 预留字段7
        /// </summary>
        [XmlElement("udf7")]
        public string Udf7 { get; set; }


        /// <summary>
        /// 预留字段8
        /// </summary>
        [XmlElement("udf8")]
        public string Udf8 { get; set; }


        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mailNo")]
        public string MailNo { get; set; }


        /// <summary>
        /// 寄件人姓名
        /// </summary>
        [XmlElement("sendMan")]
        public string SendMan { get; set; }


        /// <summary>
        /// 寄件人电话
        /// </summary>
        [XmlElement("sendManPhone")]
        public string SendManPhone { get; set; }


        /// <summary>
        /// 寄件人地址
        /// </summary>
        [XmlElement("sendManAddress")]
        public string SendManAddress { get; set; }


        /// <summary>
        /// 寄件人邮编
        /// </summary>
        [XmlElement("sendPostcode")]
        public string SendPostcode { get; set; }


        /// <summary>
        /// 寄件人省
        /// </summary>
        [XmlElement("sendProvince")]
        public string SendProvince { get; set; }


        /// <summary>
        /// 寄件人市
        /// </summary>
        [XmlElement("sendCity")]
        public string SendCity { get; set; }


        /// <summary>
        /// 寄件人区县
        /// </summary>
        [XmlElement("sendCounty")]
        public string SendCounty { get; set; }


        /// <summary>
        /// 收件人姓名
        /// </summary>
        [XmlElement("receiveMan")]
        public string ReceiveMan { get; set; }


        /// <summary>
        /// 收件人电话
        /// </summary>
        [XmlElement("receiveManPhone")]
        public string ReceiveManPhone { get; set; }


        /// <summary>
        /// 收件人地址
        /// </summary>
        [XmlElement("receiveManAddress")]
        public string ReceiveManAddress { get; set; }


        /// <summary>
        /// 收件人邮编
        /// </summary>
        [XmlElement("receivePostcode")]
        public string ReceivePostcode { get; set; }


        /// <summary>
        /// 收件人省
        /// </summary>
        [XmlElement("receiveProvince")]
        public string ReceiveProvince { get; set; }


        /// <summary>
        /// 收件人市
        /// </summary>
        [XmlElement("receiveCity")]
        public string ReceiveCity { get; set; }


        /// <summary>
        /// 收件人区县
        /// </summary>
        [XmlElement("receiveCounty")]
        public string ReceiveCounty { get; set; }


        /// <summary>
        /// 客户订单号
        /// </summary>
        [XmlElement("txLogisticID")]
        public string TxLogisticID { get; set; }


        /// <summary>
        /// 品名
        /// </summary>
        [XmlElement("itemName")]
        public string ItemName { get; set; }


        /// <summary>
        /// 重量
        /// </summary>
        [XmlElement("itemWeight")]
        public string ItemWeight { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        [XmlElement("itemCount")]
        public string ItemCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }



        /// <summary>
        /// 备注1
        /// </summary>
        [XmlElement("remark1")]
        public string Remark1 { get; set; }


        /// <summary>
        /// 备注2
        /// </summary>
        [XmlElement("remark2")]
        public string Remark2 { get; set; }



        /// <summary>
        /// 备注3
        /// </summary>
        [XmlElement("remark3")]
        public string Remark3 { get; set; }



        /// <summary>
        /// 预留字段1
        /// </summary>
        [XmlElement("udf1")]
        public string Udf1 { get; set; }


        /// <summary>
        /// 预留字段2
        /// </summary>
        [XmlElement("udf2")]
        public string Udf2 { get; set; }



        /// <summary>
        /// 预留字段3
        /// </summary>
        [XmlElement("udf3")]
        public string Udf3 { get; set; }




        /// <summary>
        /// 预留字段4
        /// </summary>
        [XmlElement("udf4")]
        public string Udf4 { get; set; }




        /// <summary>
        /// 预留字段5
        /// </summary>
        [XmlElement("udf5")]
        public string Udf5 { get; set; }


        /// <summary>
        /// 	特殊业务（请根据业务需求选择，不同业务对应不同面单模板）
        /// </summary>
        [XmlElement("shippingListAttribute")]
        public List<ShippingListAttribute> ShippingListAttribute { get; set; }



        /// <summary>
        /// 预留字段6
        /// </summary>
        [XmlElement("udf6")]
        public string Udf6 { get; set; }

    }
}
