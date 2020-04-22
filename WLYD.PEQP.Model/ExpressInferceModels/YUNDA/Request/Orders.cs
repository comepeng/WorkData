using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YUNDA.Request
{
    /// <summary>
    /// 下单及修改订单接口
    /// </summary>
    public class Orders
    {
        [XmlElement("order")]
        public List<WayBillOrder> WayBillOrders { get; set; }
    }

    /// <summary>
    /// 发件人信息
    /// </summary>
    [Serializable]
    public class Sender
    {
        /// <summary>
        /// 发件人
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 发件人公司名称
        /// </summary>
        [XmlElement("company")]
        public string Company { get; set; }

        /// <summary>
        /// 发件人所在区域
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 发件人详细地址
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 发件人邮编
        /// </summary>
        [XmlElement("postcode")]
        public string Postcode { get; set; }

        /// <summary>
        /// 发件人电话
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 发件人手机
        /// </summary>
        [XmlElement("mobile")]
        public string Mobile { get; set; }
    }

    /// <summary>
    /// 收件人信息
    /// </summary>
    [Serializable]
    public class Receiver
    {
        /// <summary>
        /// 收件人
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 收件人公司名称
        /// </summary>
        [XmlElement("company")]
        public string Company { get; set; }

        /// <summary>
        /// 收件人所在区域
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 收件人详细地址
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 收件人邮编
        /// </summary>
        [XmlElement("postcode")]
        public string Postcode { get; set; }

        /// <summary>
        /// 收件人电话
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 收件人手机
        /// </summary>
        [XmlElement("mobile")]
        public string Mobile { get; set; }
    }

    /// <summary>
    /// 商品信息
    /// </summary>
    [Serializable]
    public class Item
    {
        /// <summary>
        /// 货品名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 货品数量
        /// </summary>
        [XmlElement("number")]
        public string Number { get; set; }

        /// <summary>
        /// 货品备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
    }
}
