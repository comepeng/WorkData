using System;
using System.Text;

namespace Compeng.PEQP.Util.Security
{
    public static class Base64Encode
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string EncodeToBase64(string plainText, Encoding encode = null)
        {
            encode = encode ?? Encoding.UTF8;
            byte[] bytes = encode.GetBytes(plainText);

            return Convert.ToBase64String(bytes);
        }

        public static string EncodeToBase64(byte[] source)
        {
            return Convert.ToBase64String(source);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string DecodeFromBase64(string cipherText, Encoding encode = null)
        {
            encode = encode ?? Encoding.UTF8;
            var bytes = Convert.FromBase64String(cipherText);

            var decode = encode.GetString(bytes);

            return decode;
        }
    }
}