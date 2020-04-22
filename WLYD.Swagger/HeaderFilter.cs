using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Compeng.Swagger
{
    /// <summary>
    /// swagger header生成器
    /// </summary>
    public class HeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            /*var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);
            
            if (isAuthorized && !allowAnonymous)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter 
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "access token",
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "String",
                        Default = new OpenApiString("Bearer ")
                    }
                });
            }*/
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "AppKey",
                In = ParameterLocation.Header,
                Required = true,
                Style = ParameterStyle.Simple,
                Description = "AppKey头",
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
            // operation.Parameters.Add(new OpenApiParameter
            // {
            //     Name = "AppId",
            //     In = ParameterLocation.Header,
            //     Required = true,
            //     Style = ParameterStyle.Simple,
            //     Description = "AppId",
            //     Schema = new OpenApiSchema
            //     {
            //         Type = "string"
            //     }
            // });
            // operation.Parameters.Add(new OpenApiParameter
            // {
            //     Name = "RequestTimeStamp",
            //     In = ParameterLocation.Header,
            //     Required = true,
            //     Style = ParameterStyle.Simple,
            //     Description = "请求时间戳，单位（秒）",
            //     Schema = new OpenApiSchema
            //     {
            //         Type = "string"
            //     }
            // });
            // operation.Parameters.Add(new OpenApiParameter
            // {
            //     Name = "RequestId",
            //     In = ParameterLocation.Header,
            //     Required = true,
            //     Style = ParameterStyle.Simple,
            //     Description = "RequestId一个guid",
            //     Schema = new OpenApiSchema
            //     {
            //         Type = "string"
            //     }
            // });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Signature",
                In = ParameterLocation.Header,
                Required = true,
                Style = ParameterStyle.Simple,
                Description = "数字签名，签名方式为：md5(key+body)",
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });

        }
    }
}