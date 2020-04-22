using System.Collections.Generic;

namespace Compeng.PEQP.Model.ExpressInferceModels.ApiInfo
{
    /// <summary>
    /// api的基本信息
    /// </summary>
    public class ApiInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        public string CompanyCode { get; set; }
       
       
        /// <summary>
        /// api密钥
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// app key
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 用户在开放平台注册用户名
        /// </summary>
        public string UserId { get; set; }

        public List<ApiItemInfo> ApiItemInfoList { get; set; } = new List<ApiItemInfo>();
        
    }

    public class ApiItemInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 标识该api属于哪个平台
        /// </summary>
        public long ApiInfoId { get; set; }
        /// <summary>
        /// api名称
        /// </summary>
        public string ApiName { get; set; }
        /// <summary>
        /// api代码
        /// </summary>
        public string ApiCode { get; set; }
        /// <summary>
        /// api的版本
        /// </summary>
        public string ApiVersion { get; set; }
        /// <summary>
        /// api地址
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallBackUrl { get; set; }
    }
}
