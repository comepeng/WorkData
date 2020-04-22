using System;
using System.Xml.Serialization;

namespace Compeng.OMS.BusinessModel.Messages.SF.OMS.Response
{
    [Serializable]
    [XmlRoot("Response")]
    public class ResponseBase
    {
        /// <summary>
        /// 接口名
        /// </summary>
        [XmlAttribute("service")]
        public string Service { get; set; }

        /// <summary>
        /// 语言类型
        /// </summary>
        [XmlAttribute("lang")]
        public string Lang { get; set; } = "zh-CN";

        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("Head")]
        public string Head { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        [XmlIgnore]
        public bool IsSuccess
        {
            get
            {
                return string.Compare(Head, "OK", true) == 0;
            }
        }
    }

    [Serializable]
    [XmlRoot("Response")]
    public class ErrorResponse
    {
        /// <summary>
        /// 接口名
        /// </summary>
        [XmlAttribute("service")]
        public string Service { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("Head")]
        public string Head { get; set; }

        /// <summary>
        /// 子错误码
        /// </summary>
        [XmlElement("Error")]
        public ErrorModelResponse Error { get; set; }
    }

    public class ErrorModelResponse
    {

        /// <summary>
        /// 错误码
        /// </summary>
        [XmlAttribute("code")]
        public string Code { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [XmlText]
        public string Note { get; set; }
    }

    [Serializable]
    public class TransactionsResponse
    {
        /// <summary>
        /// 处理成功条数
        /// </summary>
        [XmlElement("AcceptedTransactions")]
        public int AcceptedTransactions { get; set; }

        /// <summary>
        /// 处理失败条数
        /// </summary>
        [XmlElement("RejectedTransactions")]
        public int RejectedTransactions { get; set; }

        /// <summary>
        /// 处理结果信息描述
        /// </summary>
        [XmlElement("Message")]
        public string Message { get; set; }
    }

    [Serializable]
    public class TransactionItemResponse : ResultResponse
    {
        /// <summary>
        /// 事务ID
        /// </summary>
        [XmlElement("TransactionId")]
        public string TransactionId { get; set; }
    }

    [Serializable]
    public class ResultResponse
    {
        /// <summary>
        /// 处理结果
        /// </summary>
        [XmlElement("Result")]
        public int Result { get; set; }

        /// <summary>
        /// 备注，如处理失败，此处可备注原因
        /// </summary>
        [XmlElement("Note")]
        public string Note { get; set; }
    }

}
