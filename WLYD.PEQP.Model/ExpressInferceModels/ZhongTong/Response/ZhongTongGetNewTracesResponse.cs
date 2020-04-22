using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO.Response
{
    /// <summary>
    /// 中通获取快件轨迹DTO，持续化MONGODB
    /// </summary>
    [Serializable]
    public class ZhongTongGetNewTracesResponse 
    {
        /// <summary>
        /// 运单号
        /// </summary>
        [JsonProperty("billCode")]
        public string BillCode { get; set; }

        /// <summary>
        /// 快件物流信息
        /// </summary>
        [JsonProperty("traces")]
        public List<TraceInfo> TraceInfos { get; set; }

        public DateTime SystemCreateTime { get; set; }
    }

    [Serializable]
    public class GetNewTracesResponse
    {
        /// <summary>
        /// 返回的数据
        /// </summary>
        [JsonProperty("data")]
        public List<ZhongTongGetNewTracesResponse> Data { get; set; }

        /// <summary>
        /// 返回的消息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

        /// <summary>
        /// 返回的结果（TRUE\FALSE）
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    [Serializable]
    public class TraceInfo
    {
        /// <summary>
        /// 路由详细描述
        /// </summary>
        [JsonProperty("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// 派件或收件员
        /// </summary>
        [JsonProperty("dispOrRecMan")]
        public string DispOrRecMan { get; set; }

        /// <summary>
        /// 派件或收件员编号
        /// </summary>
        [JsonProperty("dispOrRecManCode")]
        public string DispOrRecManCode { get; set; }

        /// <summary>
        /// 派件或收件员电话
        /// </summary>
        [JsonProperty("dispOrRecManPhone")]
        public string DispOrRecManPhone { get; set; }

        /// <summary>
        /// 扫描网点是否中心("T" or "F")
        /// </summary>
        [JsonProperty("isCenter")]
        public string IsCenter { get; set; }

        /// <summary>
        /// 上一站或下一站城市
        /// </summary>
        [JsonProperty("preOrNextCity")]
        public string PreOrNextCity { get; set; }

        /// <summary>
        /// 上一站或下一站省份
        /// </summary>
        [JsonProperty("preOrNextProv")]
        public string PreOrNextProv { get; set; }

        /// <summary>
        /// 上一站或下一站网点
        /// </summary>
        [JsonProperty("preOrNextSite")]
        public string PreOrNextSite { get; set; }

        /// <summary>
        /// 上一站或下一站网点编号
        /// </summary>
        [JsonProperty("PreOrNextSiteCode")]
        public string PreOrNextSiteCode { get; set; }

        /// <summary>
        /// 上一站或下一站网点联系方式
        /// </summary>
        [JsonProperty("preOrNextSitePhone")]
        public string PreOrNextSitePhone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 扫描网点所在城市
        /// </summary>
        [JsonProperty("scanCity")]
        public string ScanCity { get; set; }

        /// <summary>
        /// 扫描时间
        /// </summary>
        [JsonProperty("scanDate")]
        public string ScanDate { get; set; }

        /// <summary>
        /// 扫描网点所在省份
        /// </summary>
        [JsonProperty("scanProv")]
        public string ScanProv { get; set; }

        /// <summary>
        /// 扫描网点
        /// </summary>
        [JsonProperty("scanSite")]
        public string ScanSite { get; set; }

        /// <summary>
        /// 扫描网点编号
        /// </summary>
        [JsonProperty("scanSiteCode")]
        public string ScanSiteCode { get; set; }

        /// <summary>
        /// 扫描网点联系方式
        /// </summary>
        [JsonProperty("scanSitePhone")]
        public string ScanSitePhone { get; set; }

        /// <summary>
        /// 扫描类型
        /// </summary>
        [JsonProperty("scanType")]
        public string ScanType { get; set; }

        /// <summary>
        /// 签收人
        /// </summary>
        [JsonProperty("signMan")]
        public string SignMan { get; set; }
    }
}
