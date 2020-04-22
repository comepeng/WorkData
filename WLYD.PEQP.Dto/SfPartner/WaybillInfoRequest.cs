using System.Text.Json.Serialization;

namespace Compeng.PEQP.Dto.SfPartner
{
    /// <summary>
    /// 运单信息查询 请求类
    /// </summary>
    public class WaybillInfoRequest : PartnerBase
    {
        /// <summary>
        /// 接口函数名
        /// </summary>
        [JsonPropertyName("api")]
        public string Api { get; } = "get_waybill_info";


        /// <summary>
        /// 顺丰运单号
        /// </summary>
        [JsonPropertyName("waybill_no")]
        public string WaybillNo { get; set; }

        
    }
}