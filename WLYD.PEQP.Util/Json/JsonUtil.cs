using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Compeng.PEQP.Util.Converter;

namespace Compeng.PEQP.Util.Json
{
    /// <summary>
    /// json操作类
    /// </summary>
    public static class JsonUtil
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            Converters = { new JsonDateTimeConverter() },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping//JavaScriptEncoder.Create(UnicodeRanges.All)（解决中文会出现unicode字符，但部分符号仍会有问题）解决方案：https://my.oschina.net/taadis/blog/3111677
        };

        /// <summary>
        /// 将对象序列化为json字符串
        /// </summary>
        /// <param name="value">将要转换的对象</param>
        /// <typeparam name="T">转换的对应类型</typeparam>
        /// <returns>json字符串</returns>
        public static string ToJson<T>(this T value)
        {
            return JsonSerializer.Serialize(value, Options);
        }

        /// <summary>
        /// 将json字符串序列化为对象
        /// </summary>
        /// <param name="value">将要转换的json文本</param>
        /// <typeparam name="T">转换的目标类型</typeparam>
        /// <returns>对应的类型</returns>
        public static T ToObj<T>(this string value)
        {
            return JsonSerializer.Deserialize<T>(value, Options);
        }
    }
}