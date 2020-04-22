using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;

namespace Compeng.Swagger
{
    public static class SwaggerExtensions
    {
        public static IApplicationBuilder RegisterSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "{documentName}/swagger.json";
                //这个很重要，目前bootstrap swagger ui只支持2.0版本
                //todo: 待ui支持3.0协议以后替换为最新版本的注解
                c.SerializeAsV2 = true;
            });
//            .UseSwaggerUI(s =>
//            {
//                s.SwaggerEndpoint($"/{configuration["Service:Name"]}/swagger.json",
//                    $"{configuration["Service:Name"]} {configuration["Service:Version"]}");
//                //s.RoutePrefix = string.Empty;
//            });
            return app;
        }

        public static IServiceCollection AddSwaggerGen(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(configuration["Service:Name"], new OpenApiInfo
                {
                    Title = configuration["Service:Title"],
                    Version = configuration["Service:Version"],
                    Description = configuration["Service:Description"],
                    Contact = new OpenApiContact
                    {
                        Name = configuration["Service:Contact:Name"],
                        Email = configuration["Service:Contact:Email"]
                    }
                });
                //options.SchemaFilter<EnumFilter>();
                options.OperationFilter<HeaderFilter>();
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var pathStrs = configuration["Service:XmlFile"];
                if (!string.IsNullOrWhiteSpace(pathStrs))
                {
                    var xmlPaths = pathStrs.Split(',');
                    foreach (var path in xmlPaths)
                    {
                        var xmlPath = Path.Combine(basePath, path);
                        options.IncludeXmlComments(xmlPath, true);
                    }
                }
            });
            return services;
        }

        public static IServiceCollection AddSwaggerGen<T>(this IServiceCollection services,
            IConfiguration configuration, params T[] types) where T : IOperationFilter
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(configuration["Service:Name"], new OpenApiInfo
                {
                    Title = configuration["Service:Title"],
                    Version = configuration["Service:Version"],
                    Description = configuration["Service:Description"],
                    Contact = new OpenApiContact
                    {
                        Name = configuration["Service:Contact:Name"],
                        Email = configuration["Service:Contact:Email"]
                    }
                });
                foreach (var filter in types)
                {
                    options.OperationFilterDescriptors.Add(new FilterDescriptor
                    {
                        Type = filter.GetType()
                    });
                }

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var pathStrs = configuration["Service:XmlFile"];
                if (!string.IsNullOrWhiteSpace(pathStrs))
                {
                    var xmlPaths = pathStrs.Split(',');
                    foreach (var path in xmlPaths)
                    {
                        var xmlPath = Path.Combine(basePath, path);
                        options.IncludeXmlComments(xmlPath, true);
                    }
                }
            });
            return services;
        }
    }
}