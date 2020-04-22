using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.DBL.Response
{
    /// <summary>
    /// 德邦电子运单下单（C模式）
    /// </summary>
    [Serializable]
    public class DeBangDownloadOrderResponse
    {
        /// <summary>
        /// 订单号	
        /// </summary>
        [JsonProperty("logisticID")]
        public string LogisticID { get; set; }

        /// <summary>
        /// 	运单号
        /// </summary>
        [JsonProperty("mailNo")]
        public string MailNo { get; set; }

        /// <summary>
        /// 	请求成功标识，true or false
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }

        /// <summary>
        /// 	结果代码
        /// </summary>
        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 	错误原因
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 请求唯一编号
        /// </summary>
        [JsonProperty("uniquerRequestNumber")]
        public string UniquerRequestNumber { get; set; }

        /// <summary>
        /// 分拣参数
        /// </summary>
        [JsonProperty("sortingParam")]
        public DBLSortingParam SortingParam { get; set; }

        /// <summary>
        /// 返回运单号集合(针对子母件)
        /// </summary>
        [JsonProperty("mailNos")]
        public List<string> MailNos { get; set; }
    }

    /// <summary>
    /// 分拣参数
    /// </summary>
    [Serializable]
    public class DBLSortingParam
    {
        /// <summary>
        ///	集包地
        /// </summary>
        [JsonProperty("packageSite")]
        public string PackageSite { get; set; }

        /// <summary>
        /// 集包地编码
        /// </summary>
        [JsonProperty("packageSiteName")]
        public string PackageSiteName { get; set; }

        /// <summary>
        /// 原寄地
        /// </summary>
        [JsonProperty("sendSite")]
        public string SendSite { get; set; }

        /// <summary>
        ///	大头笔
        /// </summary>
        [JsonProperty("bigPen")]
        public string BigPen { get; set; }

        /// <summary>
        /// 始发网点
        /// </summary>
        [JsonProperty("sendOrgName")]
        public string SendOrgName { get; set; }

        /// <summary>
        /// 到达网点
        /// </summary>
        [JsonProperty("receiveOrgName")]
        public string ReceiveOrgName { get; set; }

    }
}
