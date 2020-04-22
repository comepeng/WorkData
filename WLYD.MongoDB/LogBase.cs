using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Compeng.MongoDB
{
    /// <summary>
    /// MongoDB基类
    /// </summary>
    public abstract class LogBase
    {
        /// <summary>
        /// mongo主键
        /// </summary>
        [BsonId(IdGenerator = typeof(AscendingGuidGenerator))]
        public Guid Id { get; set; }
    }
}