namespace Compeng.PEQP.Model.ExpressInferceModels.ShunFeng
{
    /// <summary>
    /// 顺丰api配置
    /// </summary>
    public class ShunFengApiConfig
    {

        /// <summary>
        /// 客户编码
        /// </summary>
        public string ClientCode { get;   set; }

        /// <summary>
        /// 校验码
        /// </summary>
        public string CheckWord { get;   set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        public string ApiUrl { get;   set; }

        /// <summary>
        /// 测试专用，是否自动生成运单号
        /// </summary>
        public string IsTestQueryLogisticsInfo { get;   set; }
    }
}
