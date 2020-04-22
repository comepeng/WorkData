using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Request
{
    /// <summary>
    /// 中通电子面单下单请求DTO
    /// </summary>
    [Serializable]
    public class ZhongTongWaybillDownloadRequest
    {
        /// <summary>
        /// 商家ID(正式环境由中通合作网点提供，测试环境使用test)
        /// </summary>
        [JsonProperty("partner")]
        public string Partner { get; set; }

        /// <summary>
        /// 订单号由合作商平台产生，具有平台唯一性。(测试的id一律使用xfs101100111011)
        /// </summary>
        [JsonProperty("id")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 1:为电子面单类 （其他类型具体可调用获取类型接口）  
        /// </summary>
        [JsonProperty("typeid")]
        public string TypeId { get; set; }

        /// <summary>
        /// 订单类型名称
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 交易号，由合作商平台产生。
        /// </summary>
        [JsonProperty("tradeid")]
        public string TradeId { get; set; }

        /// <summary>
        /// 网点编码，客户购买电子面单的网点
        /// </summary>
        [JsonProperty("branch_id")]
        public string BranchId { get; set; }

        /// <summary>
        /// 卖家，最好是卖家ID
        /// </summary>
        [JsonProperty("seller")]
        public string Seller { get; set; }

        /// <summary>
        /// 买家，最好是买家ID
        /// </summary>
        [JsonProperty("buyer")]
        public string Buyer { get; set; }

        /// <summary>
        /// 发件人信息
        /// </summary>
        [JsonProperty("sender")]
        public Sender Sender { get; set; }

        /// <summary>
        /// 收件人信息
        /// </summary>
        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }

        /// <summary>
        /// 商品列表
        /// </summary>
        [JsonProperty("items")]
        public List<ZTOProductItem> ZTOProductItems { get; set; }

        /// <summary>
        /// 订单总重量 （千克）
        /// </summary>
        [JsonProperty("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// 订单包裹大小（厘米）, 用半角的逗号来分隔长宽高
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// 订单包裹内货物总数量
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// 订单包裹中商品总价值
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// 运输费
        /// </summary>
        [JsonProperty("freight")]
        public string Freight { get; set; }

        /// <summary>
        /// 保险费
        /// </summary>
        [JsonProperty("premium")]
        public string Premium { get; set; }

        /// <summary>
        /// 包装费
        /// </summary>
        [JsonProperty("pack_charges")]
        public string PackCharges { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [JsonProperty("other_charges")]
        public string OtherCharges { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        [JsonProperty("order_sum")]
        public string OrderSum { get; set; }

        /// <summary>
        /// 到达收取币种
        /// </summary>
        [JsonProperty("collect_moneytype")]
        public string CollectMoneytype { get; set; }

        /// <summary>
        /// 到达收取金额，一般代收货款或者到付件才需指定
        /// </summary>
        [JsonProperty("collect_sum")]
        public string CollectSum { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// true(默认为需要获取大头笔信息)
        /// </summary>
        [JsonProperty("isremarkk")]
        public string IsRemarkk { get; set; }

        /// <summary>
        /// 订单类型：0标准；1代收；2到付
        /// </summary>
        [JsonProperty("order_type")]
        public string OrderType { get; set; }
    }

    [Serializable]
    public class Sender
    {
        /// <summary>
        /// 发件人在合作商平台中的ID号
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 发件人姓名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 发件公司名
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// 发件人手机号码
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 发件人电话号码
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 发件人区域ID，如提供区域ID，请参考中通速递提供的国家行政区划代码
        /// </summary>
        [JsonProperty("area")]
        public string Area { get; set; }

        /// <summary>
        /// 发件人所在城市，必须逐级指定，用英文半角逗号分隔，目前至少需要指定到区县级，如能往下精确更好，如“上海市,上海市,青浦区,华新镇,华志路,123号”
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 发件人路名门牌等地址信息
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// 发件人邮政编码
        /// </summary>
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        /// <summary>
        /// 发件人电子邮件
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// 发件人即时通讯工具
        /// </summary>
        [JsonProperty("im")]
        public string Im { get; set; }

        /// <summary>
        /// 取件起始时间
        /// </summary>
        [JsonProperty("starttime")]
        public string StartTime { get; set; }

        /// <summary>
        /// 取件截至时间
        /// </summary>
        [JsonProperty("endtime")]
        public string EndTime { get; set; }
    }

    [Serializable]
    public class Receiver
    {
        /// <summary>
        /// 收件人在合作商平台中的ID号
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 收件公司名
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// 收件人手机号码
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 收件人电话号码
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 收件人区域ID，如提供区域ID，请参考中通速递提供的国家行政区划代码
        /// </summary>
        [JsonProperty("area")]
        public string Area { get; set; }

        /// <summary>
        /// 收件人所在城市，必须逐级指定，用英文半角逗号分隔，目前至少需要指定到区县级，如能往下精确更好，如“上海市,上海市,青浦区,华新镇,华志路,123号”
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 收件人路名门牌等地址信息
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// 收件人邮政编码
        /// </summary>
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        /// <summary>
        /// 收件人电子邮件
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// 收件人即时通讯工具
        /// </summary>
        [JsonProperty("im")]
        public string Im { get; set; }
    }

    [Serializable]
    public class ZTOProductItem
    {
        /// <summary>
        /// 商品号
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 商品类别
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        /// <summary>
        /// 商品主要材质
        /// </summary>
        [JsonProperty("material")]
        public string Material { get; set; }

        /// <summary>
        /// 长，宽，高
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        [JsonProperty("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [JsonProperty("unitprice")]
        public string UnitPrice { get; set; }

        /// <summary>
        /// 商品链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// 商品备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }
    }

}
