using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.KDN.Response
{
    /// <summary>
    /// KDN订单跟踪信息下发
    /// </summary>
    [Serializable]
    public class KuaiDiNiaoOrderTrackResponse
    {
        /// <summary>
        /// 电商用户ID
        /// </summary>
        [JsonProperty("ebusinessid")]
        public string EBusinessID { get; set; }

        /// <summary>
        /// 推送轨迹的快递单号个数
        /// </summary>
        [JsonProperty("count")]
        public string Count { get; set; }

        /// <summary>
        /// 推送时间
        /// </summary>
        [JsonProperty("pushtime")]
        public string PushTime { get; set; }

        /// <summary>
        /// 推送轨迹的轨迹数据集合
        /// </summary>
        [JsonProperty("data")]
        public List<KDNOrderTrackInfo> Data { get; set; }
    }

    public class KDNOrderTrackInfo
    {
        /// <summary>
        /// 电商用户ID
        /// </summary>
        [JsonProperty("ebusinessid")]
        public string EBusinessID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [JsonProperty("ordercode")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 快递公司编码
        /// </summary>
        [JsonProperty("shippercode")]
        public string ShipperCode { get; set; }

        /// <summary>
        /// 物流运单号
        /// </summary>
        [JsonProperty("logisticcode")]
        public string LogisticCode { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        [JsonProperty("callback")]
        public string CallBack { get; set; }

        /// <summary>
        /// 成功与否
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 预计到达时间
        /// </summary>
        public DateTime? EstimatedDeliveryTime { get; set; }

        /// <summary>
        /// 物流状态(无轨迹 = 0, 已揽收 = 1, 在途中 = 2, 签收 = 3, 问题件 = 4)
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// 增值物流状态：
        /// 1-已揽收 2-在途中 201-到达派件城市 202-派件中 211-已放入快递柜或驿站
        /// 3-已签收 311-已取出快递柜或驿站
        /// 4-问题件 401-发货无信息 402-超时未签收 403-超时未更新 404-拒收（退件） 412-快递柜或驿站超时未取
        /// </summary>
        [JsonProperty("stateex")]
        public string StateEx { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// 物流轨迹详情
        /// </summary>
        [JsonProperty("traces")]
        public List<Trace> Traces { get; set; }
    }

    [Serializable]
    public class Trace
    {
        /// <summary>
        /// 时间
        /// </summary>
        [JsonProperty("accepttime")]
        public string AcceptTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("acceptstation")]
        public string AcceptStation { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 当前城市
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }
    }

    public class KDNResponseMessage
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string EBusinessID { get; set; }


        /// <summary>
        /// 时间
        /// </summary>
        public string UpdateTime { get; set; }

        /// <summary>
        /// 成功与否
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }
    }
}
