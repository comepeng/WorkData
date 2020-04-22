using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.BAISHI.Response
{

    /// <summary>
    /// 业务参数
    /// </summary>
    [Serializable]
    public class EDIPrintDetailList
    {

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
        /// 预留字段6
        /// </summary>
        [XmlElement("udf6")]
        public string Udf6 { get; set; }

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
        /// 面单号
        /// </summary>
        [XmlElement("mailNo")]
        public string MailNo { get; set; }


        /// <summary>
        /// 大头笔
        /// </summary>
        [XmlElement("markDestination")]
        public string MarkDestination { get; set; }


        /// <summary>
        /// 末端分拣站点
        /// </summary>
        [XmlElement("sortingSiteName")]
        public string SortingSiteName { get; set; }


        /// <summary>
        /// 末端分拣站点编码
        /// </summary>
        [XmlElement("sortingSiteCode")]
        public string SortingSiteCode { get; set; }


        /// <summary>
        /// 末端分拣编码
        /// </summary>
        [XmlElement("sortingCode")]
        public string SortingCode { get; set; }


        /// <summary>
        /// 集包编码
        /// </summary>
        [XmlElement("pkgCode")]
        public string PkgCode { get; set; }


        /// <summary>
        /// 运单发放站点
        /// </summary>
        [XmlElement("billProvideSiteName")]
        public string BillProvideSiteName { get; set; }


        /// <summary>
        /// 运单发放站点编码
        /// </summary>
        [XmlElement("billProvideSiteCode")]
        public string BillProvideSiteCode { get; set; }


        /// <summary>
        /// 寄件人姓名
        /// </summary>
        [XmlElement("sendMan")]
        public string SendMan { get; set; }


        /// <summary>
        /// codMoney
        /// </summary>
        [XmlElement("codMoney")]
        public double CodMoney { get; set; }

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
        /// 寄件邮编
        /// </summary>
        [XmlElement("sendPostcode")]
        public string SendPostcode { get; set; }

        /// <summary>
        /// 寄件省
        /// </summary>
        [XmlElement("sendProvince")]
        public string SendProvince { get; set; }

        /// <summary>
        /// 寄件市
        /// </summary>
        [XmlElement("sendCity")]
        public string SendCity { get; set; }


        /// <summary>
        /// 寄件区县
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
        /// 收件邮编
        /// </summary>
        [XmlElement("receivePostcode")]
        public string ReceivePostcode { get; set; }


        /// <summary>
        /// 收件省
        /// </summary>
        [XmlElement("receiveProvince")]
        public string ReceiveProvince { get; set; }


        /// <summary>
        /// 收件市
        /// </summary>
        [XmlElement("receiveCity")]
        public string ReceiveCity { get; set; }


        /// <summary>
        /// 收件区县
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
        public double? ItemWeight { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [XmlElement("itemCount")]
        public long? ItemCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("emark")]
        public string Remark { get; set; }



        /// <summary>
        /// 特殊业务
        /// </summary>
        [XmlElement("shippingListAttribute")]
        public List<ShippingListAttribute> ShippingListAttribute { get; set; }


        
    }
}
