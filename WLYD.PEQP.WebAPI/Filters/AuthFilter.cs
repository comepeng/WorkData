using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Nacos.Utilities;
using Compeng.MongoDB;
using Compeng.PEQP.Model.Constants;
using Compeng.PEQP.Model.ExpressInferceModels.ApiAccessControl;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Util.Extensions;
using Compeng.PEQP.Util.Json;
using Compeng.PEQP.Util.Security;
using Compeng.PEQP.WebAPI.Extentions;

namespace Compeng.PEQP.WebAPI.Filters
{
    /// <summary>
    /// 接口签名认证
    /// </summary>
    public class AuthAttribute : IAsyncActionFilter, IAsyncAlwaysRunResultFilter
    {
        //aop统一处理接口日志
        private InterfaceLog _log = null;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var mongoDbContext = context.HttpContext.RequestServices.GetRequiredService<IMongoDbContext>();
            RequestHeader requestHeader = context.GetRequestHead(out ExpressBackResponse expressBackResponse);
            if (!expressBackResponse.Success)
            {
                context.Result = new ContentResult()
                {
                    Content = expressBackResponse.ToJson(),
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ContentType = "application/json"
                };
                return;
            }
            //当走到此处，header和body必然符合条件。可以进行日志记录
            string requestData = context.GetRequestContent();
            _log = new InterfaceLog
            {
                RequestUrl = context.HttpContext.Request.Path,
                RequestContent = "{\"header\":" + requestHeader.ToJson() + ",\"body\":" + requestData + "}",
                RequestTime = DateTime.Now
            };
            await mongoDbContext.Insert(_log);
            
            if (ValidateDataSign(requestHeader, context, requestData))
            {
                await next();
            }
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            //当log为空，说明请求的时候过滤器就直接拦截了请求
            //没有进到OnActionExecutionAsync方法去初始化
            if (_log != null)
            {
                var mongoDbContext = context.HttpContext.RequestServices.GetRequiredService<IMongoDbContext>();
                if (context.Result is ContentResult contentResult)
                {
                    _log.ResponseContent = contentResult.Content;
                }
                else
                {
                    try
                    {
                        //确定其他返回都为ObjectResult，若不是则会有异常
                        var contextResult = (ObjectResult)context.Result;
                        _log.ResponseContent = contextResult.Value.ToJson();
                    }
                    catch (Exception e)
                    {
                        _log.ResponseContent = e.Message;
                    }
                }

                _log.ResponseTime = DateTime.Now;
                await mongoDbContext.Update(_log);
            }

            await next();
        }

        /// <summary>
        /// 生成数据前面
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        private string GetDataSign(string appKey, string requestData)
        {
            return MD5Encryption.MD5(appKey + requestData);
        }

        private bool ValidateDataSign(RequestHeader requestHeader, ActionExecutingContext context, string requestData)
        {
            var accesList = context.HttpContext.RequestServices
                .GetRequiredService<IOptions<List<ApiAccessControlConfig>>>()
                .Value;
            ApiAccessControlConfig apiAccessControlConfig =
                accesList.FirstOrDefault(c => c.AppKey == requestHeader.AppKey);
            if (null == apiAccessControlConfig)
            {
                var backRes = new ExpressBackResponse()
                {
                    Success = false,
                    EBusinessID = string.Empty,
                    ResultCode = Model.ExpressInferceModels.Enums.ExpressInterfaceResponseStatusCode.ValidationFail,
                    Reason = "该用户未授权,AppKey是否填写正确，或联系相关人员申请！"
                };

                context.Result = new ContentResult()
                {
                    Content = backRes.ToJson(),
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ContentType = "application/json",
                };
                return false;
            }

            string dataSign = GetDataSign(requestHeader.AppKey, requestData);
            if (!dataSign.Equals(requestHeader.Signature))
            {
                var backRes = new ExpressBackResponse()
                {
                    Success = false,
                    EBusinessID = string.Empty,
                    ResultCode = Model.ExpressInferceModels.Enums.ExpressInterfaceResponseStatusCode.ValidationFail,
                    Reason = "无效的数字签名"
                };
                context.Result = new ContentResult()
                {
                    Content = backRes.ToJson(),
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ContentType = "application/json"
                };
                return false;
            }

            return true;
        }
    }
}