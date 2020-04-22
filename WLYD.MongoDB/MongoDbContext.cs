using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Compeng.MongoDB
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        // private readonly IMongoDatabase _mongoDatabase;
        public MongoDbContext(IMongoClient mongoClient, IOptions<MongoDbSetting> mongodbSetting)
        {
            _mongoDatabase = mongoClient.GetDatabase(mongodbSetting.Value.DataBaseName);
        }

        public async Task Insert<TEntity>(TEntity entity) where TEntity : LogBase
        {
            var collection = await GetCollectionAsync<TEntity>();
            await collection.InsertOneAsync(entity);
        }

        public async Task Update<TEntity>(TEntity entity) where TEntity : LogBase
        {
            var collection = await GetCollectionAsync<TEntity>();
            await collection.ReplaceOneAsync((c => c.Id == entity.Id), entity);
        }

        /// <summary>
        /// 异步获取表（集合）
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="datetime"></param>
        /// <returns></returns>
        private async Task<IMongoCollection<TEntity>> GetCollectionAsync<TEntity>()
            where TEntity : LogBase
        {
            // 获取集合名称
            var collectionName = typeof(TEntity).Name + DateTime.Now.ToString("yyyy-MM-dd");

            // 如果集合不存在，那么创建集合
            if (false == await IsCollectionExistsAsync<TEntity>(collectionName))
            {
                await _mongoDatabase.CreateCollectionAsync(collectionName);
            }

            return _mongoDatabase.GetCollection<TEntity>(collectionName);
        }

        /// <summary>
        /// 集合是否存在
        /// </summary>
        /// <param name="dataBaseName">数据库名</param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        private async Task<bool> IsCollectionExistsAsync<TEntity>(string name)
        {
            var filter = new BsonDocument("name", name);
            // 通过集合名称过滤
            var collections = await _mongoDatabase.ListCollectionsAsync(new ListCollectionsOptions {Filter = filter});
            // 检查是否存在
            return await collections.AnyAsync();
        }
    }
}