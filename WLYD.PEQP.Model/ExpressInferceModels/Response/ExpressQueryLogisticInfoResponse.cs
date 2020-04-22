using System.Collections.Generic;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;

namespace Compeng.PEQP.Model.ExpressInferceModels.Response
{
    /// <summary>
    /// 查询物流轨迹响应实体
    /// </summary>
    public class ExpressQueryLogisticInfoResponse
    {
        /// <summary>
        /// 用户 ID
        /// </summary>
        public string EBusinessID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        public string LogisticCode { get; set; }

        /// <summary>
        /// 成功与否(true/false)
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 返回编码
        /// </summary>
        public ExpressInterfaceResponseStatusCode ResultCode { get; set; }

        /// <summary>
        /// 物流轨迹详情
        /// </summary>
        public List<ExpressTraceInfo> Traces { get; set; }
    }

    /// <summary>
    /// 物流轨迹详情
    /// </summary>
    public class ExpressTraceInfo
    {
        /// <summary>
        /// 轨迹发生时间
        /// </summary>
        public string AcceptTime { get; set; }

        /// <summary>
        /// 轨迹描述
        /// </summary>
        public string AcceptStation { get; set; }

        /// <summary>
        /// 当前城市
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 物流状态：无轨迹 = 0, 已揽收 = 1, 在途中 = 2, 签收 = 3, 问题件 = 4, 派件=202
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
