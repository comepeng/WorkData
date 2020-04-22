using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Request
{

    [Serializable]
    public class ZTOJsonContent
    {

        /// <summary>
        /// 电子面单账号，由合作网点提供(测试环境请用test)
        /// </summary>
        [JsonProperty("partner")]
        public string Partner { get; set; }


        /// <summary>
        /// 24小时制的请求时间，和网络时间间隔不能超过2小时，示例：2013-09-01 13:25:33	
        /// </summary>
        [JsonProperty("datetime")]
        public string Datetime { get; set; }

        /// <summary>
        /// 业务数据
        /// </summary>
        [JsonProperty("content")]
        public ZhongTongSubmitOrderCodeRequest Content { get; set; }


        /// <summary>
        /// 电子面单账号验证码，由合作网点提供(测试环境请用ZTO123）
        /// </summary>
        [JsonProperty("verify")]
        public string Verify { get; set; }

    }





    /// <summary>
    /// 获取运单号（中通）
    /// </summary>
    [Serializable]
    public class ZhongTongSubmitOrderCodeRequest
    {

        /// <summary>
        /// 网点编码，客户购买电子面单的网点
        /// </summary>
        [JsonProperty("branchId")]
        public string BranchId { get; set; }


        /// <summary>
        /// 买家，最好是买家ID
        /// </summary>
        [JsonProperty("buyer")]
        public string Buyer { get; set; }


        /// <summary>
        /// 到达收取币种
        /// </summary>
        [JsonProperty("collectMoneytype")]
        public string CollectMoneytype { get; set; }

        /// <summary>
        /// 到达收取金额，一般代收货款或者到付件才需指定
        /// </summary>
        [JsonProperty("collectSum")]
        public string CollectSum { get; set; }


        /// <summary>
        /// 运输费
        /// </summary>
        [JsonProperty("freight")]
        public string Freight { get; set; }


        /// <summary>
        /// 订单号由合作商平台产生，具有平台唯一性。(测试的id一律使用xfs101100111011)
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }


        /// <summary>
        /// 订单总金额
        /// </summary>
        [JsonProperty("orderSum")]
        public string OrderSum { get; set; }


        /// <summary>
        /// 订单类型：0标准；1代收；2到付
        /// </summary>
        [JsonProperty("orderType")]
        public string OrderType { get; set; }


        /// <summary>
        /// 其他费用
        /// </summary>
        [JsonProperty("otherCharges")]
        public string OtherCharges { get; set; }

        /// <summary>
        /// 包装费
        /// </summary>
        [JsonProperty("pack_charges")]
        public string PackCharges { get; set; }


        /// <summary>
        /// 保险费
        /// </summary>
        [JsonProperty("premium")]
        public string Premium { get; set; }


        /// <summary>
        /// 订单包裹中商品总价值
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }


        /// <summary>
        /// 订单包裹内货物总数量
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; set; }


        /// <summary>
        /// 收件人信息
        /// </summary>
        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }


        /// <summary>
        /// 订单备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }


        /// <summary>
        /// 卖家，最好是卖家ID
        /// </summary>
        [JsonProperty("seller")]
        public string Seller { get; set; }


        /// <summary>
        /// 发件人信息
        /// </summary>
        [JsonProperty("sender")]
        public Sender Sender { get; set; }


        /// <summary>
        /// 订单包裹大小（厘米）, 用半角的逗号来分隔长宽高
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }



        /// <summary>
        /// 交易号，由合作商平台产生。
        /// </summary>
        [JsonProperty("tradeId")]
        public string TradeId { get; set; }

        
        [JsonProperty("type")]
        public string Type { get; set; }


        /// <summary>
        /// 1:为电子面单类 （其他类型具体可调用获取类型接口）
        /// </summary>
        [JsonProperty("typeId")]
        public string TypeId { get; set; }


        /// <summary>
        /// 订单总重量 （千克）
        /// </summary>
        [JsonProperty("weight")]
        public string Weight { get; set; }

    }

}
