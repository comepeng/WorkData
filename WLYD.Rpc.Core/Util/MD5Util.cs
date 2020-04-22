using System.Security.Cryptography;
using System.Text;

namespace Compeng.Rpc.Core.Util
{
    /// <summary>
    /// md5加密工具类
    /// </summary>
    public static class MD5Util
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encrypt(this string str)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] bytHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                var builder = new StringBuilder();
                foreach (var t in bytHash)
                {
                    builder.Append(t.ToString("X").PadLeft(2, '0'));
                }

                str = builder.ToString().ToLower();
                return str;
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] Md5EncryptToBytes(this string str)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var bytHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                return bytHash;
            }
        }
    }
}