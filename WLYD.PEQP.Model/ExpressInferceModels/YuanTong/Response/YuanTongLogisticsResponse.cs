using System.Collections.Generic;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;

namespace Compeng.PEQP.Model.ExpressInferceModels.YTO.Response
{
    public  class YuanTongLogisticsResponse
    {
        /// 成功与否
        /// </summary>
      
        public bool Success { get; set; }

        /// <summary>
        /// 错误原由
        /// </summary>
     
        public string Reason { get; set; }
        /// <summary>
        /// 物流信息
        /// </summary>
        public List<YTOWaybillProcessInfo> WaybillProcessInfos { get; set; }
        /// <summary>
        /// 操作码
        /// </summary>
        public ExpressInterfaceResponseStatusCode ResultCode { get; set; }
    }
}
