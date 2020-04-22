using System;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Request
{
    /// <summary>
    /// 中通物流信息推送请求DTO
    /// </summary>
    [Serializable]
    public class ZhongTongTracesInfoRequest
    {
        /// <summary>
        /// 运单号
        /// </summary>
        [JsonProperty("billCode")]
        public string BillCode { get; set; }

        /// <summary>
        /// 扫描类型，事件/操作，详情参见scanType编码规范
        /// </summary>
        [JsonProperty("scanType")]
        public string ScanType { get; set; }

        /// <summary>
        /// 扫描网点
        /// </summary>
        [JsonProperty("scanSite")]
        public string ScanSite { get; set; }

        /// <summary>
        /// 扫描城市
        /// </summary>
        [JsonProperty("scanCity")]
        public string ScanCity { get; set; }

        /// <summary>
        /// 扫描时间（yyyy-MM-dd HH:mm:ss）
        /// </summary>
        [JsonProperty("scanDate")]
        public string ScanDate { get; set; }

        /// <summary>
        /// 物流信息描述
        /// </summary>
        [JsonProperty("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// 收\派件业务员姓名 或 签收客户姓名 或 代理点名称
        /// </summary>
        [JsonProperty("contacts")]
        public string Contacts { get; set; }

        /// <summary>
        /// 收\派件业务电话 或 代理点联系电话
        /// </summary>
        [JsonProperty("contactsTel")]
        public string ContactsTel { get; set; }

        /// <summary>
        /// 值为[THIRD_PARTY_SIGN] 时，为代理点信息
        /// </summary>
        [JsonProperty("remark1")]
        public string Remark1 { get; set; }

        /// <summary>
        /// 代理点地址
        /// </summary>
        [JsonProperty("remark2")]
        public string Remark2 { get; set; }

        /// <summary>
        /// 问题件二级编码
        /// </summary>
        [JsonProperty("remark3")]
        public string Remark3 { get; set; }

        /// <summary>
        /// 备注信息，后期约定，未用到的可以忽略
        /// </summary>
        [JsonProperty("remark4")]
        public string Remark4 { get; set; }

        /// <summary>
        /// 备注信息，后期约定，未用到的可以忽略
        /// </summary>
        [JsonProperty("remark5")]
        public string Remark5 { get; set; }

        /// <summary>
        /// 备注信息，后期约定，未用到的可以忽略
        /// </summary>
        [JsonProperty("remark6")]
        public string Remark6 { get; set; }
    }
}
