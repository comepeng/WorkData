using System;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.BAISHI
{

    //// <summary>
    /// 电子面单账户信息
    /// </summary>
    [Serializable]
    public class Auth
    {
        /// <summary>
        /// 站点信息
        /// </summary>
        [XmlElement("username")]
        public string UserName { get; set; }


        /// <summary>
        /// 站点密码
        /// </summary>
        [XmlElement("pass")]
        public string Pass { get; set; }
    }
}
