using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Compeng.PEQP.Model.Constants;
using Compeng.PEQP.Util.Security;

namespace Compeng.PEQP.Repository.RegistryRepository
{
    public static class RegistryRepository
    {

        /// <summary>
        /// 注册仓储的地方
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration">配置文件</param>
        /// <param name="serviceLifetime"></param>
        /// <returns></returns>
        public static IServiceCollection RegistryRepositories(this IServiceCollection services, IConfiguration configuration,
            ServiceLifetime serviceLifetime)
        {
          
            var builder = new MySqlConnectionStringBuilder(configuration.GetConnectionString(DbConstants.DbName));
             builder.Password = TripleDESEncryption.Decrypt(builder.Password);
            var connectionString = builder.ConnectionString;//"server=localhost;port=3306;database=titan;uid=root;passwoord=QQhao@weixin.com;Allow User Variables=True;Charset=utf8;";//builder.ConnectionString;
            switch (serviceLifetime)
            {
                //特殊用途
                case ServiceLifetime.Singleton:
                    services
                        .AddSingleton<IDbConnection>(_ =>
                             new MySqlConnection(connectionString));
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient<IDbConnection>(_ =>
                    new MySqlConnection(connectionString)
                    );
                    break;
                default:
                    services
                        .AddScoped<IDbConnection>(_ =>
                         // new SqlConnection(connectionString)
                         new MySqlConnection(connectionString)
                        );
                    break;
            }
            services.Add<ApiInfoRepository>(serviceLifetime);
            return services;
        }
        public static IServiceCollection Add<TService>(this IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(typeof(TService));
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient(typeof(TService));
                    break;
                default:
                    services.AddScoped(typeof(TService));
                    break;
            }
            return services;
        }
    }
}
