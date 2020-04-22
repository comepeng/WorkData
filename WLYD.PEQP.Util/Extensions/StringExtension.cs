using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using Compeng.PEQP.Util.KeyGen;

namespace Compeng.PEQP.Util.Extensions
{
    public static class StringExtension
    {
        private static readonly Regex WebUrlExpression = new Regex(
            @"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Singleline | RegexOptions.Compiled);

        private static readonly Regex EmailExpression =
            new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$",
                RegexOptions.Singleline | RegexOptions.Compiled);

        private static readonly Regex StripHTMLExpression = new Regex("<\\S[^><]*>",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant |
            RegexOptions.Compiled);

        private static readonly char[] IllegalUrlCharacters =
        {
            ';', '/', '\\', '?', ':', '@', '&', '=', '+', '$', ',',
            '<', '>', '#', '%', '.', '!', '*', '\'', '"', '(', ')', '[', ']', '{', '}', '|', '^', '`', '~', '–', '‘',
            '’', '“', '”', '»', '«'
        };

        public static bool IsWebUrl(this string target)
        {
            return !string.IsNullOrEmpty(target) && WebUrlExpression.IsMatch(target);
        }

        public static bool IsEmail(this string target)
        {
            return !string.IsNullOrEmpty(target) && EmailExpression.IsMatch(target);
        }

        public static string NullSafe(this string target)
        {
            return (target ?? string.Empty).Trim();
        }

        public static bool IsEmpty(this string target)
        {
            return string.IsNullOrEmpty(target.NullSafe());
        }

        public static bool IsGuid(this string target)
        {
            bool succeed = Guid.TryParse(target.NullSafe(), out Guid guid);

            return succeed;
        }


        public static string GetValue(this string target, string defaultValue = "")
        {
            if (target.IsEmpty())
                return defaultValue;
            else
                return target;
        }


        public static string StripHtml(this string target)
        {
            return StripHTMLExpression.Replace(target, string.Empty);
        }


        public static string ToLegalUrl(this string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                return target;
            }

            target = target.Trim();

            if (target.IndexOfAny(IllegalUrlCharacters) > -1)
            {
                foreach (char character in IllegalUrlCharacters)
                {
                    target = target.Replace(character, ' ');
                }
            }

            target = target.Replace(" ", "-");

            while (target.Contains("--"))
            {
                target = target.Replace("--", "-");
            }

            return target;
        }

        public static string UrlEncode(this string target, Encoding encode = null)
        {
            return System.Web.HttpUtility.UrlEncode(target, Encoding.UTF8);
        }

        public static string UrlDecode(this string target, Encoding encode = null)
        {
            return System.Web.HttpUtility.UrlDecode(target, Encoding.UTF8);
        }

        public static bool IsPic(this string target)
        {
            if (!string.IsNullOrEmpty(target))
            {
                string pic = target.ToUpper();
                if (pic.EndsWith(".PNG") ||
                    pic.EndsWith(".JPG") ||
                    pic.EndsWith(".JPEG") ||
                    pic.EndsWith(".BMP") ||
                    pic.EndsWith(".GIF")
                )
                {
                    return true;
                }
            }

            return false;
        }

        public static string Replace(this string target, ICollection<string> oldValues, string newValue)
        {
            oldValues.ForEach(oldValue => target = target.Replace(oldValue, newValue));
            return target;
        }

        /// <summary>
        ///     去除HTML标记
        /// </summary>
        /// <param name="NoHTML">包括HTML的源码   </param>
        /// <returns>已经去除后的文字</returns>
        public static string FilterHtml(this string target)
        {
            //删除脚本
            target = Regex.Replace(target, @"<script[^>]*?>.*?</script>", "",
                RegexOptions.IgnoreCase);
            //删除HTML
            target = Regex.Replace(target, @"<(.[^>]*)>", "",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"([\r\n])[\s]+", "",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"-->", "", RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"<!--.*", "", RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&(quot|#34);", "\"",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&(amp|#38);", "&",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&(lt|#60);", "<",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&(gt|#62);", ">",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&(nbsp|#160);", "   ",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&(iexcl|#161);", "\xa1",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&(cent|#162);", "\xa2",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&(pound|#163);", "\xa3",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&(copy|#169);", "\xa9",
                RegexOptions.IgnoreCase);
            target = Regex.Replace(target, @"&#(\d+);", "",
                RegexOptions.IgnoreCase);
            target = target.Replace("<", "")
                .Replace(">", "")
                .Replace("\r\n", "");


            return target;
        }

        public static int TryParseIntOrDefault(this string val)
        {
            int rtn;
            return int.TryParse(val, out rtn) ? rtn : default(int);
        }

        public static decimal TryParseDecimalOrDefault(this string val)
        {
            decimal rtn;
            return decimal.TryParse(val, out rtn) ? rtn : default(decimal);
        }

        public static T ConvertTo<T>(this string value)
        {
            try
            {
                if (null == value) return default(T);

                Type type = typeof(T);

                return (T) TypeDescriptor.GetConverter(type).ConvertFromInvariantString(value);
            }
            catch
            {
                return default(T);
            }
        }

        public static object FromTo(this object value, Type _type)
        {
            try
            {
                if (null == value) return null;
                //Convert.ChangeType(dic[key], property.PropertyType, CultureInfo.InvariantCulture);

                return TypeDescriptor.GetConverter(_type).ConvertFromInvariantString(value.ToString());
            }
            catch
            {
                return null;
            }
        }

        public static bool IsBoolean(this string obj)
        {
            if (obj == null)
                return false;

            if (bool.TryParse(obj, out bool result))
                return true;
            else
                return false;
        }

        /// <summary>  
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>  
        /// <param name=\"guid\"></param>  
        /// <returns></returns>  
        public static string GuidTo16String(this string str)
        {
            long i = 1;
            foreach (byte b in GuidHelper.NewGuid().ToByteArray())
                i *= ((int) b + 1);
            return string.Format(@"{0:x}", i - DateTime.Now.LocalToLocalZoneDateTime().Ticks);
        }

        /// <summary>
        /// 是否是有效的编码--编码只能是字母(大写或小写),数字,_,-,@
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static bool IsValidCode(this string Str)
        {
            string result = Str;

            if (result.IsEmpty()) return false;

            return new Regex(@"^[_\-@a-zA-Z0-9]+",
                           RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.ExplicitCapture)
                       .Replace(result, string.Empty).Length == 0;
        }


        /// <summary>
        /// 字符串哈希成数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long Time33Hash(this String str)
        {
            int len = str.Length;
            long hash = 0;
            for (int i = 0; i < len; i++) hash = (hash << 5) + hash + str[i];
            return hash;
        }

        /// <summary>
        ///获取字符串长度(包含中文的)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CnLength(this string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            return System.Text.Encoding.Default.GetBytes(str.ToCharArray()).Length;
        }
    }
}