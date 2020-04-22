
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Compeng.MongoDB
{

    public class InterfaceLog : LogBase
    {
        /// <summary>
        /// 请求开始时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime RequestTime { get; set; }

        /// <summary>
        /// 请求结束时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? ResponseTime { get; set; }

        /// <summary>
        /// 请求内容
        /// </summary>
        [BsonElement("RequestContent")]
        public string RequestContent { get; set; }

        /// <summary>
        /// 请求url
        /// </summary>
        [BsonElement("RequestUrl")]
        public string RequestUrl { get; set; }

        /// <summary>
        /// 响应内容，若有异常则是异常message
        /// </summary>
        [BsonElement("ResponseContent")]
        public string ResponseContent { get; set; }
    }
}