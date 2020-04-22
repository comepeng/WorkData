using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Util.Json;

namespace Compeng.PEQP.WebAPI.Filters
{
    public class GlobalExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var backRes = new ExpressBackResponse()
            {
                Success = false,
                EBusinessID = string.Empty,
                ResultCode = Model.ExpressInferceModels.Enums.ExpressInterfaceResponseStatusCode.Other,
                Reason = context.Exception.Message + context.Exception.Source
            };
            var result = new ContentResult()
            {
                Content = backRes.ToJson(),
                StatusCode = (int) HttpStatusCode.BadRequest,
                ContentType = "application/json",
            };
            context.Result = result;
            return base.OnExceptionAsync(context);
        }
    }
}