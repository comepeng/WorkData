using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Compeng.PEQP.Model.ExpressInferceModels.DBL.Request
{
    /// <summary>
    /// 德邦标准轨迹推送
    /// </summary>
    [Serializable]
    public class DeBangRoutePushRequest
    {
        /// <summary>
        /// 运单列表
        /// </summary>
        [JsonProperty("track_list")]
        public List<DeBangTrackInfo> TrackList { get; set; }
    }

    [Serializable]
    public class DeBangTrackInfo
    {
        /// <summary>
        /// 轨迹列表
        /// </summary>
        [JsonProperty("track_list")]
        public List<DeBangTrace> TraceList { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [JsonProperty("tracking_number")]
        public string TrackingNo { get; set; }
    }

    [Serializable]
    public class DeBangTrace
    {
        /// <summary>
        /// 操作时间，时间格式如：2018-07-17 15:40:18
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// 当前操作城市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 当前操作站点
        /// </summary>
        [JsonProperty("site")]
        public string Site { get; set; }

        /// <summary>
        /// 当前操作状态，GOT：开单；ARRIVAL：进站；DEPARTURE：出站；SENT_SCAN：派送；SIGNED：签收；ERROR：滞留,延时派送；FAILED：客户拒签
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 轨迹点描述
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
