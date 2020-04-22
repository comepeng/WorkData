using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Compeng.PEQP.GrpcService.Services;
using Compeng.PEQP.Service.ServiceRegistry;
using Compeng.Rpc.Server;

namespace Compeng.PEQP.GrpcService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(c => { c.AddProfile(new MappingProfile()); });
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper)
                .RegistryService(Configuration);
            services.AddLogging().AddGrpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //服务注册
            app.ApplicationServices.UseGrpcService(Configuration, typeof(CancelOrderService),
                typeof(CreateOrderService), typeof(GetChildOrderService), typeof(GetLogisticsInfoService),typeof(GetWaybillInfoService));

            //注册到服务路由
            app.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGrpcService<CancelOrderService>();
                    endpoints.MapGrpcService<CreateOrderService>();
                    endpoints.MapGrpcService<GetChildOrderService>();
                    endpoints.MapGrpcService<GetLogisticsInfoService>();
                    endpoints.MapGrpcService<GetWaybillInfoService>();
                    endpoints.MapGet("/",
                        async context =>
                        {
                            await context.Response.WriteAsync(
                                "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                        });
                });
        }
    }
}