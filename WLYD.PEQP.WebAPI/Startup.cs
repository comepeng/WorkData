using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Compeng.PEQP.Util.Converter;
using Compeng.Swagger;
using Compeng.PEQP.WebAPI.Filters;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Compeng.Rpc.Client;
using Compeng.PEQP.Model.ExpressInferceModels.ApiAccessControl;
using System.Collections.Generic;
using AutoMapper;
using Compeng.MongoDB;

namespace Compeng.PEQP.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(c => { c.AddProfile(new MappingProfile()); });
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper).AddLogging();
            services.Configure<List<ApiAccessControlConfig>>(Configuration.GetSection(nameof(ApiAccessControlConfig)));
            services.ConfigGrpc(Configuration).AddGrpcClient<CancelOrder.CancelOrderClient>()
                .AddGrpcClient<CreateOrder.CreateOrderClient>()
                .AddGrpcClient<GetChildOrder.GetChildOrderClient>()
                .AddGrpcClient<GetLogistics.GetLogisticsClient>()
                .AddGrpcClient<GetWaybillInfo.GetWaybillInfoClient>()
                ;
            services.AddMvc(opt =>
            {
                opt.Filters.Add<GlobalExceptionHandlerAttribute>();
                opt.Filters.Add<AuthAttribute>();
                opt.OutputFormatters.RemoveType<TextOutputFormatter>();
            });
            services .AddHttpClient()
                .RegistryMongo(Configuration)
                .AddSwaggerGen(Configuration)
                .AddControllers().AddJsonOptions(options =>
                {
                    // <see cref="Compeng.PEQP.Util.Json.JsonUtil"/>
                    options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.Encoder =JavaScriptEncoder.UnsafeRelaxedJsonEscaping;//.UnsafeRelaxedJsonEscaping//JavaScriptEncoder.Create(UnicodeRanges.All)（解决中文会出现unicode字符，但部分符号仍会有问题）解决方案：https://my.oschina.net/taadis/blog/3111677
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(next => context =>
            {
                //详见 https://stackoverflow.com/questions/31389781/read-request-body-twice#
                //框架默认只让body读取一次
                context.Request.EnableBuffering();
                return next(context);
            });
            //app.UseHttpsRedirection();

            app.UseRouting().RegisterSwagger(Configuration);
            //app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}