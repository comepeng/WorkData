using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Compeng.PEQP.Util.Security
{
    /// <summary>
    /// 顺丰伙伴api，加密算法
    /// </summary>
    public static class SfPartnerEncryptionUtil
    {
        private static readonly byte[] Iv = Encoding.UTF8.GetBytes("0102030405060708");
        private static readonly byte[] Key = new byte[16] {16, 127, 107, 76, 122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

        /// <summary>
        /// 加密！ 此算法兼容，顺丰伙伴api
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encrypt(this string str)
        {
            if (str == null)
            {
                throw new ArgumentException($"{nameof(str)} 不能为空");
            }

            var toEncryptArray = Encoding.UTF8.GetBytes(str);

            using (var aes = new AesManaged
            {
                Key = Key,
                Padding = PaddingMode.PKCS7,
                IV = Iv
            })
            {
                using (var cTransform = aes.CreateEncryptor())
                {
                    var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                }
            }
        }

        /// <summary>
        /// 解密！ 此算法兼容，顺丰伙伴api
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decrypt(this string str)
        {
            if (str == null)
            {
                throw new ArgumentException($"{nameof(str)} 不能为空");
            }

            var toEncryptArray = Convert.FromBase64String(str);

            using (var aes = new AesManaged
            {
                Key = Key,
                Padding = PaddingMode.PKCS7,
                IV = Iv
            })
            {
                using (var cTransform = aes.CreateDecryptor())
                {
                    var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    return Encoding.UTF8.GetString(resultArray);
                }
            }
        }
        // private static byte[] getKey()
        // {
        //     var strKey = "";
        //     var key = new byte[] {16, 127, 107, 76, 122};
        //     foreach (var t in key)
        //     {
        //         strKey += (char) t;
        //     }
        //
        //     var arrBTmp = Encoding.UTF8.GetBytes(strKey);
        //     var arrB = new byte[16];
        //     for (var i = 0; i < arrBTmp.Length && i < arrB.Length; i++)
        //     {
        //         arrB[i] = arrBTmp[i];
        //     }
        //
        //     return arrB;
        // }
    }
}