using System;
using Compeng.PEQP.Util.KeyGen;

namespace Compeng.PEQP.Util.Extensions
{

    public static class GuidExtension
    {
       

        
        public static bool IsEmpty(this Guid target)
        {
            return target == Guid.Empty;
        }

        /// <summary>
        /// 由连字符分隔的32位数字
        /// </summary>
        /// <returns></returns>
        private static string GetGuid()
        {
            System.Guid guid  = GuidHelper.NewGuid();
            return guid.ToString();
        }

        /// <summary>  
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>  
        /// <param name=\"guid\"></param>  
        /// <returns></returns>  
        public static string GuidTo16String(this Guid target)
        {
            long i = 1;
            foreach (byte b in target.ToByteArray())
                i *= ((int)b + 1);

            return string.Format("{0:x}", i - DateTime.Now.LocalToLocalZoneDateTime().Ticks);
        }

        /// <summary>  
        /// 根据GUID获取19位的唯一数字序列  
        /// </summary>  
        /// <returns></returns>  
        public static long GuidToLongID(this Guid target)
        {
            byte[] buffer = target.ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

    }
}