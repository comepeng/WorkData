namespace Compeng.PEQP.Model.ExpressInferceModels.ZTO
{
    /// <summary>
    /// 中通Api配置
    /// </summary>
    public  class ZhongTongApiConfig
    {
        /// <summary>
        /// 电子面单下单地址
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// 物流回调地址
        /// </summary>
        public string LogisticsPushBackUrl { get;  set; }

        /// <summary>
        /// 合作商编码
        /// </summary>
        public string CompanyID { get;  set; }

        /// <summary>
        /// 合作商密钥
        /// </summary>
        public string AppKey { get;  set; }

        /// <summary>
        /// 订阅快件轨迹地址
        /// </summary>
        public string SubBillLogApiUrl { get;  set; }

        /// <summary>
        /// 订阅人
        /// </summary>
        public string Subscriber { get;  set; }
    }
}
