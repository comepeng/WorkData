using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Request
{
    /// <summary>
    /// 获取运单号请求实体（可传保价金额服务）
    /// </summary>
    [Serializable]
    public class ZhongTongWayBillVasRequest
    {
        /// <summary>
        /// 合作商订单号
        /// </summary>
        [JsonProperty("partnerOrderCode")]
        public string PartnerOrderCode { get; set; }

        /// <summary>
        /// 渠道
        /// </summary>
        [JsonProperty("partnerId")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// 发件人信息
        /// </summary>
        [JsonProperty("senderInfoDto")]
        public ZhongTongSenderInfoDto SenderInfoDto { get; set; }

        /// <summary>
        /// 收件人信息
        /// </summary>
        [JsonProperty("receiverInfoDto")]
        public ZhongTongReceiverInfoDto ReceiverInfoDto { get; set; }

        /// <summary>
        /// 电子面单账号信息
        /// </summary>
        [JsonProperty("wayBillAccountDto")]
        public ZhongTongWayBillAccountDto WayBillAccountDto { get; set; }

        /// <summary>
        /// 增值类型，vip:尊享，cod:代收，insured:保价
        /// </summary>
        [JsonProperty("vasTypes")]
        public List<string> VasTypes { get; set; }

        /// <summary>
        /// 商品信息
        /// </summary>
        [JsonProperty("itemDtos")]
        public List<ZhongTongItemDto> ItemDtos { get; set; }

        /// <summary>
        /// 增值类型有代收必须要有代收金额并且不为0
        /// </summary>
        [JsonProperty("collectSum")]
        public long? CollectSum { get; set; }

        /// <summary>
        /// 单位：克
        /// </summary>
        [JsonProperty("weight")]
        public long? Weight { get; set; }

        /// <summary>
        /// 包裹尺寸
        /// </summary>
        [JsonProperty("bagSize")]
        public string BagSize { get; set; }

        /// <summary>
        /// 保价类型，如果增值类型有保价，必填
        /// </summary>
        [JsonProperty("insuredType")]
        public int? InsuredType { get; set; }

        /// <summary>
        /// 保价金额（分），如果增值类型有保价，必填
        /// </summary>
        [JsonProperty("insuredSum")]
        public long? InsuredSum { get; set; }
    }

    /// <summary>
    /// 寄件人信息
    /// </summary>
    public class ZhongTongSenderInfoDto
    {
        /// <summary>
        /// 寄件人ID
        /// </summary>
        [JsonProperty("senderId")]
        public string SenderId { get; set; }

        /// <summary>
        /// 寄件人姓名
        /// </summary>
        [JsonProperty("senderName")]
        public string SenderName { get; set; }

        /// <summary>
        /// 寄件人号码
        /// </summary>
        [JsonProperty("senderPhone")]
        public string SenderPhone { get; set; }

        /// <summary>
        /// 寄件人手机号
        /// </summary>
        [JsonProperty("senderMobile")]
        public string SenderMobile { get; set; }

        /// <summary>
        /// 寄件人省
        /// </summary>
        [JsonProperty("senderProvince")]
        public string SenderProvince { get; set; }

        /// <summary>
        /// 寄件人市
        /// </summary>
        [JsonProperty("senderCity")]
        public string SenderCity { get; set; }

        /// <summary>
        /// 寄件人区
        /// </summary>
        [JsonProperty("senderDistrict")]
        public string SenderDistrict { get; set; }

        /// <summary>
        /// 寄件人详细地址
        /// </summary>
        [JsonProperty("senderAddress")]
        public string SenderAddress { get; set; }
    }

    /// <summary>
    /// 收件人信息
    /// </summary>
    public class ZhongTongReceiverInfoDto
    {
        /// <summary>
        /// 收件人ID
        /// </summary>
        [JsonProperty("receiverId")]
        public string ReceiverId { get; set; }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        [JsonProperty("receiverName")]
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收件人手机号
        /// </summary>
        [JsonProperty("receiverMobile")]
        public string ReceiverMobile { get; set; }

        /// <summary>
        /// 收件人号码
        /// </summary>
        [JsonProperty("receiverPhone")]
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// 收件人省
        /// </summary>
        [JsonProperty("receiverProvince")]
        public string ReceiverProvince { get; set; }

        /// <summary>
        /// 收件人市
        /// </summary>
        [JsonProperty("receiverCity")]
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 收件人区
        /// </summary>
        [JsonProperty("receiverDistrict")]
        public string ReceiverDistrict { get; set; }

        /// <summary>
        /// 收件人详细地址
        /// </summary>
        [JsonProperty("receiverAddress")]
        public string ReceiverAddress { get; set; }
    }

    /// <summary>
    /// 电子面单信息
    /// </summary>
    public class ZhongTongWayBillAccountDto
    {
        /// <summary>
        /// 电子面单账号
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// 电子面单密码
        /// </summary>
        [JsonProperty("accountPassword")]
        public string AccountPassword { get; set; }
    }

    /// <summary>
    /// 商品信息
    /// </summary>
    public class ZhongTongItemDto
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        /// <summary>
        /// 商品材质
        /// </summary>
        [JsonProperty("material")]
        public string Material { get; set; }

        /// <summary>
        /// （长,宽,高）(单位：厘米), 用半角的逗号来分隔长宽高
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// 重量（单位：克)
        /// </summary>
        [JsonProperty("weight")]
        public int? Weight { get; set; }

        /// <summary>
        /// 单价(单位:分)
        /// </summary>
        [JsonProperty("unitprice")]
        public int? Unitprice { get; set; }

        /// <summary>
        /// 重量（单位：克)
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 货品数量
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
