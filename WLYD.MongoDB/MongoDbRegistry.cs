using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Compeng.MongoDB
{
    public static class MongoDbRegistry
    {
        public static IServiceCollection RegistryMongo(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddOptions().Configure<MongoDbSetting>(setting =>
            {
                setting.ConnectionString = configuration["MongoDbSetting:ConnectionString"];
                setting.DataBaseName = configuration["MongoDbSetting:DataBaseName"];
            });
            service.AddTransient<IMongoDbContext, MongoDbContext>()
                .AddSingleton<IMongoClient>(provider =>
                {
                    var mongoDbSetting = provider.GetRequiredService<IOptions<MongoDbSetting>>();
                    return new MongoClient(mongoDbSetting.Value.ConnectionString);
                });
            return service;
        }
    }
}