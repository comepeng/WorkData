using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.BAISHI.Response
{

    /// <summary>
    /// 响应业务参数
    /// </summary>
    [Serializable]
    [XmlRoot("response")]
    public class KdWaybillApplyNotifyRsp
    {
        /// <summary>
        /// 错误编码
        /// </summary>
        [XmlElement("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement("errorDescription")]
        public string ErrorDescription { get; set; }


        /// <summary>
        /// 结果描述，结果:true成功，false失败
        /// </summary>

        [XmlElement("result")]
        public bool Result { get; set; }


        /// <summary>
        /// 返回业务参数
        /// </summary>
        [XmlElement("EDIPrintDetailList")]
        public List<EDIPrintDetailList> EDIPrintDetailList { get; set; }
    }

}
