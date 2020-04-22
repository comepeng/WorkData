namespace Compeng.PEQP.Model.ExpressInferceModels.YTO
{
    /// <summary>
    /// api配置对象 从配置文件读取
    /// </summary>
    public  class YuanTongApiConfig
    {
        /// <summary>
        /// 走件流程查询/标准运价查询地址
        /// </summary>
        public string ApiUrl { get;   set; }

        /// <summary>
        /// 根据网点ID查询网点服务信息/目的中心信息地址
        /// </summary>
        public string BaseDataApiUrl { get;   set; }

        /// <summary>
        /// 分配给用户的app_key
        /// </summary>
        public string AppKey { get;   set; }

        /// <summary>
        /// 用户在开放平台注册时填写的客户标识
        /// </summary>
        public string UserID { get;   set; }

        /// <summary>
        /// 	API协议的版本号
        /// </summary>
        public string Version { get;   set; }

        /// <summary>
        /// 由开放平台分配给用户的Secret_Key，生成签名时使用
        /// </summary>
        public string SecretKey { get;   set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string ClientID { get;   set; }

        /// <summary>
        /// 电子面单地址
        /// </summary>
        public string CommonOrderApiUrl { get;   set; }
    }
}
