using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Compeng.PEQP.Model.ExpressInferceModels.Enums
{
    public enum ExpressInterfaceResponseStatusCode
    {
        [Description("成功")] Success = 100,

        [Description("缺少必要参数")] MissNecessaryParameters = 101,

        [Description("校验问题")] ValidationFail = 102,

        [Description("用户问题")] UserProblem = 103,

        [Description("重复下单问题")] RepeatOrder = 104,

        [Description("其他问题")] Other = 105
    }
}