using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.DBL.Request
{
    /// <summary>
    /// 德邦电子运单下单（C模式）
    /// </summary>
    [Serializable]
    public class DeBangDownloadOrderRequest
    {
        /// <summary>
        /// 物流公司ID
        /// 为“DEPPON”
        /// </summary>
        [JsonProperty("logisticCompanyID")]
        public string LogisticCompanyID { get; set; }

        /// <summary>
        /// 渠道单号，由第三方接入商产生的订单号（生成规则为sign+数字，sign值由双方约定）
        /// </summary>
        [JsonProperty("logisticID")]
        public string LogisticID { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [JsonProperty("mailNo")]
        public string MailNo { get; set; }

        /// <summary>
        /// 订单来源，与companyCode保持一致
        /// </summary>
        [JsonProperty("orderSource")]
        public string OrderSource { get; set; }

        /// <summary>
        /// 是否推荐物流，0:否 1:是 可为空，客户未填默认为否
        /// </summary>
        [JsonProperty("isRecommend")]
        public string IsRecommend { get; set; }

        /// <summary>
        /// 服务类型：2．快递在线下单
        /// </summary>
        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        /// <summary>
        /// 客户编码/月结账号
        /// </summary>
        [JsonProperty("customerCode")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// 渠道用户,与companyCode保持一致
        /// </summary>
        [JsonProperty("customerID")]
        public string CustomerID { get; set; }

        /// <summary>
        /// 发货部门编码
        /// </summary>
        [JsonProperty("businessNetworkNo")]
        public string BusinessNetworkNo { get; set; }

        /// <summary>
        /// 到达部门编码
        /// </summary>
        [JsonProperty("toNetworkNo")]
        public string ToNetworkNo { get; set; }

        /// <summary>
        /// 发货人信息
        /// </summary>
        [JsonProperty("sender")]
        public DBLOrderSender Sender { get; set; }

        /// <summary>
        /// 收货人信息
        /// </summary>
        [JsonProperty("receiver")]
        public DBLOrderReceiver Receiver { get; set; }

        /// <summary>
        /// 订单提交时间
        /// </summary>
        [JsonProperty("gmtCommit")]
        public string GmtCommit { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        [JsonProperty("cargoName")]
        public string CargoName { get; set; }

        /// <summary>
        /// 特殊商品性质（普通[0]、易碎[1]、液态[2]、化学品[3]、白色粉末状[4]、香烟[5]）
        /// </summary>
        [JsonProperty("special")]
        public string Special { get; set; }

        /// <summary>
        /// 总件数
        /// </summary>
        [JsonProperty("totalNumber")]
        public int TotalNumber { get; set; }

        /// <summary>
        /// 总重量，单位kg 重量为空默认为1KG，不能超过50kg
        /// </summary>
        [JsonProperty("totalWeight")]
        public decimal? TotalWeight { get; set; }

        /// <summary>
        /// 总体积，单位m3 可为空 单件体积不能超过0.3立方，超过则退回给客户，并提供退回原因
        /// </summary>
        [JsonProperty("totalVolume")]
        public decimal TotalVolume { get; set; }

        /// <summary>
        /// 支付方式，1:收货人付款（到付） 2：发货人付款（月结） （电子运单客户仅支持月结支付）
        /// </summary>
        [JsonProperty("payType")]
        public string PayType { get; set; }

        /// <summary>
        /// 运输方式，PACKAGE:标准快递; RCP:360特惠件; EPEP:电商尊享; DEAP：特准快件 ； ZBRH: 3.60特重件; NZBRH : 重包入户； 同城件：CITYPIECE
        /// </summary>
        [JsonProperty("transportType")]
        public string TransportType { get; set; }

        /// <summary>
        /// 保价金额
        /// </summary>
        [JsonProperty("insuranceValue")]
        public decimal InsuranceValue { get; set; }

        /// <summary>
        /// 代收货款金额，可为空 如为空，则FOSS开单时默认为0
        /// </summary>
        [JsonProperty("codValue")]
        public decimal CodValue { get; set; }

        /// <summary>
        /// 代收货款类型，1：即日退 3：三日退 代收货款金额不为0时，此项客户必填，代收货款金额为0或为空，则代收类型默认为无
        /// </summary>
        [JsonProperty("codType")]
        public string CodType { get; set; }

        /// <summary>
        /// 代收货款客户账号，代收货款金额不为0时，此项客户必填
        /// </summary>
        [JsonProperty("reciveLoanAccount")]
        public string ReciveLoanAccount { get; set; }

        /// <summary>
        /// 代收货款客户开户名，代收货款金额不为0时，此项客户必填
        /// </summary>
        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        /// <summary>
        /// 是否上门接货，是:Y 否：N；如为空，系统默认值为否。 快递客户如需上门接货请传“Y”
        /// </summary>
        [JsonProperty("vistReceive")]
        public string VistReceive { get; set; }

        /// <summary>
        /// 上门接货开始时间
        /// </summary>
        [JsonProperty("sendStartTime")]
        public DateTime? SendStartTime { get; set; }

        /// <summary>
        /// 上门接货结束时间
        /// </summary>
        [JsonProperty("sendEndTime")]
        public DateTime? SendEndTime { get; set; }

        /// <summary>
        /// 送货方式，3:送货上楼
        /// </summary>
        [JsonProperty("deliveryType")]
        public string DeliveryType { get; set; }

        /// <summary>
        /// 签收回单，0:无需返单 1：签收单原件返回 2:客户签收单传真返回 4: 运单到达联传真返回
        /// </summary>
        [JsonProperty("backSignBill")]
        public string BackSignBill { get; set; }

        /// <summary>
        /// 包装（直接用中文）：纸、纤、木箱、木架、托膜、托木
        /// </summary>
        [JsonProperty("packageService")]
        public string PackageService { get; set; }

        /// <summary>
        /// 短信通知，Y：需要 N: 不需要
        /// </summary>
        [JsonProperty("smsNotify")]
        public string SmsNotify { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 是否外发，Y：需要 N: 不需要
        /// </summary>
        [JsonProperty("isOut")]
        public string IsOut { get; set; }
    }

    /// <summary>
    /// 德邦寄件人信息
    /// </summary>
    [Serializable]
    public class DBLOrderSender
    {
        /// <summary>
        /// 发货人公司
        /// </summary>
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 发货人名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 发货人邮编
        /// </summary>
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// 发货人电话
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 发货人手机
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 发货人省份
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 发货人城市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 发货人区县
        /// </summary>
        [JsonProperty("county")]
        public string County { get; set; }

        /// <summary>
        /// 发货人乡镇街道
        /// </summary>
        [JsonProperty("town")]
        public string Town { get; set; }

        /// <summary>
        /// 发货人详细地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
    }

    /// <summary>
    /// 德邦收件人信息
    /// </summary>
    [Serializable]
    public class DBLOrderReceiver
    {
        /// <summary>
        /// 收货人公司
        /// </summary>
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 收货人名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 收货人邮编
        /// </summary>
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 收货人手机
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 收货人省份
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 收货人城市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 收货人区县
        /// </summary>
        [JsonProperty("county")]
        public string County { get; set; }

        /// <summary>
        /// 收货人乡镇街道
        /// </summary>
        [JsonProperty("town")]
        public string Town { get; set; }

        /// <summary>
        /// 收货人详细地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
