using System.Text.Json.Serialization;

namespace Compeng.PEQP.Dto.SfPartner
{
    /// <summary>
    /// 运单信息查询返回类 获取 用户联系电话、用户姓名等。视顺丰公司信息安全风险控制需要，寄件人、收件人信息字段信息可能不完整
    /// </summary>
    public class WaybillInfoResponse
    {
        /// <summary>
        /// 接口函数名
        /// </summary>
        [JsonPropertyName("api")]
        public string Api { get; set; }

        /// <summary>
        /// 合作伙伴id
        /// </summary>
        [JsonPropertyName("partner_id")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 返回结果，正常返回结果为 "0"
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; } = "1";

        [JsonPropertyName("object")] public ResultObject ResultObject { get; set; }

        public override string ToString()
        {
            return $"{nameof(Api)}: {Api}, {nameof(PartnerId)}: {PartnerId}, {nameof(Result)}: {Result}, {nameof(ResultObject)}: {ResultObject}";
        }
    }

    /// <summary>
    /// 返回详情
    /// </summary>
    public class ResultObject
    {
        /// <summary>
        /// 异常返回消息
        /// </summary>
        [JsonPropertyName("msg")]
        public string Message { get; set; }

        /// <summary>
        /// 发货人姓名
        /// </summary>
        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// 发货人电话
        /// </summary>
        [JsonPropertyName("sender_phone")]
        public string SenderPhone { get; set; }

        /// <summary>
        /// 发货人手机号
        /// </summary>
        [JsonPropertyName("sender_mobile")]
        public string SenderMobile { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("receiver_phone")]
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// 收货人手机
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("receiver_mobile")]
        public string ReceiverMobile { get; set; }

        /// <summary>
        /// 运费付款人，payer=receiver 时表明是到付件
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("payer")]
        public string Payer { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Message)}: {Message}, {nameof(Sender)}: {Sender}, {nameof(SenderPhone)}: {SenderPhone}, {nameof(SenderMobile)}: {SenderMobile}, {nameof(Receiver)}: {Receiver}, {nameof(ReceiverPhone)}: {ReceiverPhone}, {nameof(ReceiverMobile)}: {ReceiverMobile}, {nameof(Payer)}: {Payer}";
        }
    }
}