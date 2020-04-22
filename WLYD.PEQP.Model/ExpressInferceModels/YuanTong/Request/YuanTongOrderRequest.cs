using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.YTO.Request
{
    /// <summary>
    /// 圆通电子面单下单
    /// </summary>
    [Serializable]
    [XmlRoot("RequestOrder")]
    public class YuanTongOrderRequest
    {
        /// <summary>
        /// 商家代码（必须与customerId一致）
        /// </summary>
        [XmlElement("clientID")]
        public string ClientID { get; set; }

        /// <summary>
        /// 物流公司ID 必须为YTO
        /// </summary>
        [XmlElement("logisticProviderID")]
        public string LogisticProviderID { get; set; }

        /// <summary>
        /// 商家代码 (由商家设置， 必须与clientID一致)
        /// </summary>
        [XmlElement("customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// 物流订单号
        /// </summary>
        [XmlElement("txLogisticID")]
        public string TxLogisticID { get; set; }

        /// <summary>
        /// 业务交易号（可选）
        /// </summary>
        [XmlElement("tradeNo")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 物流运单号
        /// </summary>
        [XmlElement("mailNo")]
        public string MailNo { get; set; }

        /// <summary>
        /// 订单类型（该字段是为向下兼容预留）
        /// </summary>
        [XmlElement("type")]
        public int Type { get; set; }

        /// <summary>
        /// 订单类型(0-COD,1-普通订单,2-便携式订单,3-退货单,4-到付)
        /// </summary>
        [XmlElement("orderType")]
        public int OrderType { get; set; }

        /// <summary>
        /// 服务类型(1-上门揽收, 2-次日达 4-次晨达 8-当日达,0-自己联系)。默认为0
        /// </summary>
        [XmlElement("serviceType")]
        public int ServiceType { get; set; }

        /// <summary>
        /// 产品类型(默认为0)
        /// </summary>
        [XmlElement("flag")]
        public int Flag { get; set; }

        /// <summary>
        /// 寄件人信息
        /// </summary>
        [XmlElement("sender")]
        public YTOSender Sender { get; set; }

        /// <summary>
        /// 收件人信息
        /// </summary>
        [XmlElement("receiver")]
        public YTOReceiver Receiver { get; set; }

        /// <summary>
        /// 物流公司上门取货时间段，通过”yyyy-MM-dd HH:mm:ss”格式化，本文中所有时间格式相同。
        /// </summary>
        [XmlElement("sendStartTime")]
        public string SendStartTime { get; set; }

        [XmlElement("sendEndTime")]
        public string SendEndTime { get; set; }

        /// <summary>
        ///	商品金额，包括优惠和运费，但无服务费
        /// </summary>
        [XmlElement("goodsValue")]
        public decimal GoodsValue { get; set; }

        /// <summary>
        /// goodsValue+总服务费
        /// </summary>
        [XmlElement("totalValue")]
        public decimal TotalValue { get; set; }

        /// <summary>
        /// 代收金额，如果是代收订单， 必须大于0；非代收设置为0.0
        /// </summary>
        [XmlElement("agencyFund")]
        public decimal AgencyFund { get; set; }

        /// <summary>
        ///	货物价值
        /// </summary>
        [XmlElement("itemsValue")]
        public decimal ItemsValue { get; set; }

        /// <summary>
        /// 货物总重量
        /// </summary>
        [XmlElement("itemsWeight")]
        public decimal ItemsWeight { get; set; }

        /// <summary>
        /// 商品信息
        /// </summary>
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<YuanTongItem> Items { get; set; }

        /// <summary>
        /// 商品类型（保留字段，暂时不用）
        /// </summary>
        [XmlElement("special")]
        public int Special { get; set; }

        /// <summary>
        ///	备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 保值金额 （保价金额为货品价值（大于等于100少于3w），默认为0.0）
        /// </summary>
        [XmlElement("insuranceValue")]
        public decimal InsuranceValue { get; set; }

        /// <summary>
        ///	保值金额=insuranceValue*货品数量(默认为0.0）
        /// </summary>
        [XmlElement("totalServiceFee")]
        public decimal TotalServiceFee { get; set; }

        /// <summary>
        /// 物流公司分润[COD] （暂时没有使用，默认为0.0）
        /// </summary>
        [XmlElement("codSplitFee")]
        public decimal CodSplitFee { get; set; }
    }

    [Serializable]
    public class YTOSender
    {
        /// <summary>
        /// 用户姓名 
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 用户邮编
        /// </summary>
        [XmlElement("postCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// 用户电话，包括区号、电话号码及分机号，中间用“-”分隔；
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 用户移动电话， 手机和电话至少填一项 
        /// </summary>
        [XmlElement("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [XmlElement("prov")]
        public string Prov { get; set; }

        /// <summary>
        /// 城市与区县， 城市与区县用英文逗号隔开
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 详细地址（注：不包含省市区）
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }
    }

    [Serializable]
    public class YTOReceiver
    {
        /// <summary>
        /// 用户姓名 
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 用户邮编
        /// </summary>
        [XmlElement("postCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// 用户电话，包括区号、电话号码及分机号，中间用“-”分隔；
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 用户移动电话， 手机和电话至少填一项 
        /// </summary>
        [XmlElement("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [XmlElement("prov")]
        public string Prov { get; set; }

        /// <summary>
        /// 城市与区县， 城市与区县用英文逗号隔开
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 详细地址（注：不包含省市区）
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }
    }

    [Serializable]
    public class YuanTongItem
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("itemName")]
        public string ItemName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [XmlElement("number")]
        public int Number { get; set; }

        /// <summary>
        /// 商品单价（两位小数）
        /// </summary>
        [XmlElement("itemValue")]
        public decimal ItemValue { get; set; }
    }

}
