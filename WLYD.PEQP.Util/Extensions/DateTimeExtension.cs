using System;
using Compeng.PEQP.Util.KeyGen;

namespace Compeng.PEQP.Util.Extensions
{

    /// <summary>
    /// 日期扩展
    /// </summary>
    public static class DateTimeExtension
    {
        private static readonly DateTime MinDate = new DateTime(1900, 1, 1);
        private static readonly DateTime MaxDate = new DateTime(9999, 12, 31, 23, 59, 59, 999);
        public static Guid ToGuid(this DateTime time)
        {
            //系统生存GUID
            byte[] guidArray = GuidHelper.NewGuid().ToByteArray();

            DateTime baseDate = new DateTime(1900, 1, 1);

            TimeSpan days = new TimeSpan(time.Ticks - baseDate.Ticks);
            TimeSpan msecs = time.TimeOfDay;//获取现在距1900/1/1/的总天数

            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds)); //获取今天的总毫秒数

            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);

            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            byte[] newGuid = new byte[guidArray.Length];
            Array.Copy(guidArray, guidArray.Length - 6, newGuid, 0, 6);
            Array.Copy(guidArray, 0, newGuid, 6, guidArray.Length - 6);

            return new Guid(newGuid);
        }
        /// <summary>
        /// 是否为日期
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsValid(this DateTime target)
        {
            return (target >= MinDate) && (target <= MaxDate);
        }

        /// <summary>
        /// 本地时间格式化显示
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDisplayDate(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 本地时间格式化显示
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDisplayDateTime(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 本地时间格式化显示
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDisplayDateStart(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd 00:00:00");
        }
        public static string ToDisplayDateEnd(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd 23:59:59");
        }
        /// <summary>
        /// 本地时间格式化显示
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDisplayDateTime(this DateTime? dt)
        {
            if (dt.HasValue && dt.Value != DateTime.MinValue)
                return dt.Value.ToString("yyyy-MM-dd HH:mm:ss");
            return string.Empty;
        }

        public static string ToDisplayDate(this DateTime? dt)
        {
            if (dt.HasValue && dt.Value != DateTime.MinValue)
                return dt.Value.ToString("yyyy-MM-dd");
            return string.Empty;
        }



        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static string ToUnixTimestamp(this System.DateTime time)
        {

            System.DateTime startTime = TimeZoneInfo.ConvertTimeFromUtc(new System.DateTime(1970, 1, 1, 0, 0, 0, 0), TimeZoneInfo.Local);
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t.ToString();
        }

        public static double ToUnixTimestamplong(this System.DateTime time)
        {

            System.DateTime startTime = TimeZoneInfo.ConvertTimeFromUtc(new System.DateTime(1970, 1, 1, 0, 0, 0, 0), TimeZoneInfo.Local);
            double t = (time - startTime).TotalSeconds;   //除10000调整为13位      
            return t;
        }

        /// <summary>
        /// 本地时间转换为UTC时间（数据从数据库加载到VUE日期控件时转换）
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LocalToUTCZoneDateTime(this DateTime dt)
        {
            dt = DateTime.SpecifyKind(dt, DateTimeKind.Local);
            return dt.ToUniversalTime();
        }

        /// <summary>
        /// VUE日期保存到数据库时使用
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime UTCToLocalZoneDateTime(this DateTime dt)
        {
            dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
            return dt.ToLocalTime();
        }

        /// <summary>
        /// 保留，用于后期国际化，租户市区与本地市区的转换
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LocalToLocalZoneDateTime(this DateTime dt)
        {
            dt = DateTime.SpecifyKind(dt, DateTimeKind.Local);
            return dt.ToLocalTime();
        }

        /// <summary>
        /// Converts a Unix Timestamp in to a DateTime
        /// </summary>
        /// <param name="unixTime">This Unix Timestamp</param>
        /// <returns></returns>
        public static DateTime FromUnixTimestamp(this double unixTime)
        {

            // var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var epoch =TimeZoneInfo.ConvertTimeFromUtc(new System.DateTime(1970, 1, 1, 0, 0, 0, 0), TimeZoneInfo.Local);
            return epoch.AddSeconds(unixTime);
        }
    }
}
