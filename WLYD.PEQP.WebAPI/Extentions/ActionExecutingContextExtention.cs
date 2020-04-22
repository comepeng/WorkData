using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Compeng.PEQP.Model.Constants;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;

namespace Compeng.PEQP.WebAPI.Extentions
{
    /// <summary>
    /// ActionExecutingContext扩展
    /// </summary>
    public static class ActionExecutingContextExtention
    {
        /// <summary>
        /// 获取head
        /// </summary>
        /// <param name="context"></param>
        /// <param name="expressBackResponse"></param>
        /// <returns></returns>
        public static RequestHeader GetRequestHead(this ActionExecutingContext context,
            out ExpressBackResponse expressBackResponse)
        {
            ExpressBackResponse expressBack = new ExpressBackResponse();
            string appKey = context.HttpContext.Request.Headers[ApiConstants.AppKeyName];
            string signature = context.HttpContext.Request.Headers[ApiConstants.Signature];

            if (string.IsNullOrEmpty(signature))
            {
                expressBack.Success = false;
                expressBack.Reason = "缺少signature";
                expressBack.ResultCode = ExpressInterfaceResponseStatusCode.ValidationFail;
                expressBackResponse = expressBack;
                return null;
            }

            expressBack.Success = true;
            expressBackResponse = expressBack;
            return new RequestHeader
            {
                Signature = signature,
                AppKey = appKey,
            };
        }

        /// <summary>
        /// 获取客户端传入的原始内容
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetRequestContent(this ActionExecutingContext context)
        {
            var stream = context.HttpContext.Request.Body;
            stream.Position = 0; //需要重置
            string requestContent;
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                requestContent = reader.ReadToEnd();
            }

            return requestContent;
        }
    }
}