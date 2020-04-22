using System.ComponentModel;

namespace Compeng.PEQP.Model.ExpressInferceModels.Enums
{
    /// <summary>
    /// 订单跟踪状态
    /// </summary>
    public enum OrderTrackStatuCode
    {
        [Description("无轨迹")]
        NoTrack = 0,
        [Description("已揽收")]
        HadLanShou = 1,
        [Description("在途中")]
        OnWay = 2,
        [Description("签收")]
        Sign = 3,
        [Description("问题件")]
        ProblemShipment = 4,
        [Description("取消")]
        Cancel = 5,
        [Description("派件")]
        Delivery = 202
    }
}
