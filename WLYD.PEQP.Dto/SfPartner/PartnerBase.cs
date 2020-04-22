using System.Text.Json.Serialization;

namespace Compeng.PEQP.Dto.SfPartner
{
    /// <summary>
    /// 合作伙伴基类
    /// </summary>
    public class PartnerBase
    {
        /// <summary>
        /// 合作伙伴id
        /// </summary>
        [JsonPropertyName("partner_id")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 语言编码 1位简体
        /// </summary>
        [JsonPropertyName("lang_code")]
        public string LangCode { get; } = "1";
    }
}