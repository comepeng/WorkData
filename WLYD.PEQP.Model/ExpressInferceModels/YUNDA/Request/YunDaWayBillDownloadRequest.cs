using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Request
{
    /// <summary>
    /// 韵达电子面单下单接口
    /// </summary>
    public class YunDaWayBillDownloadRequest
    {
        [XmlArray("orders")]
        [XmlArrayItem("order")]
        public List<WayBillOrder> WayBillOrders { get; set; }

        public YunDaWayBillDownloadRequest()
        {
            WayBillOrders = new List<WayBillOrder>();
        }
    }

    [Serializable]
    public class WayBillOrder
    {
        /// <summary>
        /// 订单唯一序列号
        /// </summary>
        [XmlElement("order_serial_no")]
        public string OrderSerialNo { get; set; }

        /// <summary>
        /// 客户订单号
        /// </summary>
        [XmlElement("khddh")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 内部参考号，供大客户自己使用，可以是客户的客户编号
        /// </summary>
        [XmlElement("nbckh")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 订单类型(common:普通；support_value:报价；cod:COD代收贷款；df:到付；inner:内件)为空时默认为common
        /// </summary>
        [XmlElement("order_type")]
        public string OrderType { get; set; }

        /// <summary>
        /// 发件人信息
        /// </summary>
        [XmlElement("sender")]
        public Sender sender { get; set; }

        /// <summary>
        /// 收件人信息
        /// </summary>
        [XmlElement("receiver")]
        public Receiver receiver { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        [XmlElement("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// 用半角的逗号来分隔长宽高,单位cm
        /// </summary>
        [XmlElement("size")]
        public string Size { get; set; }

        /// <summary>
        /// 货物价值
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }

        /// <summary>
        /// 代收货款金额
        /// </summary>
        [XmlElement("collection_value")]
        public string Collection_Value { get; set; }

        /// <summary>
        /// 货品性质
        /// </summary>
        [XmlElement("special")]
        public string Special { get; set; }

        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<Item> Items { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 可以自定义显示信息1，打印在客户自定义区域1，换行请用\n
        /// </summary>
        [XmlElement("cus_area1")]
        public string CusArea1 { get; set; }

        /// <summary>
        /// 可以自定义显示信息2，打印在客户自定义区域2，换行请用\n
        /// </summary>
        [XmlElement("cus_area2")]
        public string CusArea2 { get; set; }

        /// <summary>
        /// 接口异步回传的时候返回的ID，客户方系统使用，此ID是客户需求，可以不填，默认为空
        /// </summary>
        [XmlElement("callback_id")]
        public string CallbackID { get; set; }

        /// <summary>
        /// 客户自定义条码，支持字母和数字
        /// </summary>
        [XmlElement("cus_area3")]
        public string CusArea3 { get; set; }

        /// <summary>
        /// 客户波次号，按照此号进行批量打印校验
        /// </summary>
        [XmlElement("wave_no")]
        public string WaveNo { get; set; }

        /// <summary>
        /// 人工强制下单(系统筛单不送达的情况下,会验证此标签,为1的话会强制标记为可送达，使用此参数需要和网点协商，否则不要使用此参数)
        /// </summary>
        //[XmlElement("receiver_force")]
        //public string ReceiverForce { get; set; }

    }

    
}
