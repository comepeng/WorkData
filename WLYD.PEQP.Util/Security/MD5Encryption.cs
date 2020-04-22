using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Compeng.PEQP.Util.Security
{
    /// <summary>
    /// md5 加密
    /// </summary>
    public static class MD5Encryption
    {
        /// <summary>
        /// MD5散列加密
        /// </summary>
        /// <param name="plainText">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string plainText, Encoding encode=null)
        {
            encode = encode == null ? Encoding.UTF8 : encode;
           var md5= System.Security.Cryptography.MD5.Create();
            byte[] encryptedBytes = md5.ComputeHash(encode.GetBytes(plainText));
            StringBuilder ret = new StringBuilder();
            foreach (byte b in encryptedBytes.ToArray())
            {
                ret.AppendFormat("{0:x2}", b);
            }
            return ret.ToString();
        }

        /// <summary>
        /// MD5接口加密
        /// </summary>
        /// <param name="pwdToEncryption"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string pwdToEncryption)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var test = Encoding.ASCII.GetBytes(pwdToEncryption);
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(pwdToEncryption));
            StringBuilder ret = new StringBuilder();
            foreach (byte b in encryptedBytes.ToArray())
            {
                ret.AppendFormat("{0:x2}", b);
            }
            return ret.ToString();
        }
        /// <summary>
        /// MD5加密（统一Java和C#。Java如下）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] bytValue, bytHash;
                bytValue = Encoding.UTF8.GetBytes(str);
                bytHash = md5.ComputeHash(bytValue);
                md5.Clear();
                string sTemp = "";
                for (int i = 0; i < bytHash.Length; i++)
                {
                    sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
                }
                str = sTemp.ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return str;
        }
        //java MD5
        //public static String md5(String str)
        //{
        //    try
        //    {
        //        MessageDigest md = MessageDigest.getInstance("MD5");
        //        md.update(str.getBytes());
        //        byte b[] = md.digest();

        //        int i;

        //        StringBuffer buf = new StringBuffer("");
        //        for (int offset = 0; offset < b.length; offset++)
        //        {
        //            i = b[offset];
        //            if (i < 0)
        //                i += 256;
        //            if (i < 16)
        //                buf.append("0");
        //            buf.append(Integer.toHexString(i));
        //        }
        //        str = buf.toString();
        //    }
        //    catch (Exception e)
        //    {
        //        e.printStackTrace();

        //    }
        //    return str;
        //}




    }

    public sealed class MD5Hashing
    {
        private static MD5 md5 = MD5.Create();
        //私有化构造函数 
        private MD5Hashing()
        {
        }
        /// <summary> 
        /// 使用utf8编码将字符串散列 
        /// </summary> 
        /// <param name="sourceString">要散列的字符串</param> 
        /// <returns>散列后的字符串</returns> 
        public static string HashString(string sourceString)
        {
            return HashString(Encoding.UTF8, sourceString);
        }
        /// <summary> 
        /// 使用指定的编码将字符串散列 
        /// </summary> 
        /// <param name="encode">编码</param> 
        /// <param name="sourceString">要散列的字符串</param> 
        /// <returns>散列后的字符串</returns> 
        public static string HashString(Encoding encode, string sourceString)
        {
            byte[] source = md5.ComputeHash(encode.GetBytes(sourceString));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                sBuilder.Append(source[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary> 
        /// 使用指定的编码将字符串散列 
        /// </summary> 
        /// <param name="encode">编码</param> 
        /// <param name="sourceString">要散列的字符串</param> 
        /// <returns>散列后的字符串</returns> 
        public static byte[] HashString2(Encoding encode, string sourceString)
        {
            byte[] source = md5.ComputeHash(encode.GetBytes(sourceString));
            return source;
        }
    }
}
