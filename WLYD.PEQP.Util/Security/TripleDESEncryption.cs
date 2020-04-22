using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Compeng.PEQP.Util.Security
{
    /// <summary>
    /// TripleDES 加密 解密
    /// </summary>
    public static class TripleDESEncryption
    {
        /// <summary>
        /// 3DES加密KEY
        /// </summary>
        private static byte[] KEY
        {
            get
            {
                var key = new byte[24];
                for (int i = 0; i < key.Length; i++)
                {
                    key[i] = (byte)(i + new Random(60).Next());
                }
                return key;
            }
        }

        /// <summary>
        /// 3DES加密IV
        /// </summary>
        private static byte[] IV
        {
            get
            {
                var iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                return iv;
            }
        }

        //private static readonly string _DESKEY = "SCDESKEY";

        //private static readonly string _DESIV = "SCDES_IV";
        private static readonly string _TripleDESKey = "Z6GmLqFUdOCHZ09V9QdV7Q+=";

        public static string Encrypt(string plainText,Encoding encode=null)   // 加密
        {
            encode = encode ?? Encoding.UTF8;

            try
            {
                var des = TripleDES.Create();
                des.Key = encode.GetBytes(_TripleDESKey);
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.Zeros;
                MemoryStream ms = new MemoryStream();
                byte[] inData = encode.GetBytes(plainText);

                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);

                        cs.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
                catch
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static string Decrypt(string cipherText, Encoding encode = null)
        {
            encode = encode ?? Encoding.UTF8;
            try
            {
                var des = TripleDES.Create();
                des.Key = encode.GetBytes(_TripleDESKey);
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.Zeros;
                byte[] inData = Convert.FromBase64String(cipherText);

                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inData, 0, inData.Length);

                    cs.FlushFinalBlock();
                }

                var recordString = Encoding.UTF8.GetString(ms.ToArray());
                int indexOfLastChar = recordString.IndexOf('\0');
                if (indexOfLastChar > 0)
                {
                    recordString = recordString.Substring(0, indexOfLastChar);
                }

                return recordString;
            }
            catch (Exception ex)
            {
                var str = ex.Message;
                return null;
            }

        }

        public const string PdaRgbKey = "0535YANTAIJIANWANZHONG99";
        public const string PdaRgbIv = "12345678";

        /// <summary>  
        /// DES3 CBC模式加密  
        /// </summary>  
        /// <param name="key">密钥</param>  
        /// <param name="iv">IV</param>  
        /// <param name="data">明文</param>  
        /// <returns>密文</returns>  
        public static string Des3EncodeCBC(string key, string iv, string data)
        {
            try
            {
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                byte[] byteKey = utf8.GetBytes(key);
                byte[] byteIv = utf8.GetBytes(iv);
                byte[] byteData = utf8.GetBytes(data);
                // Create a MemoryStream.  
                MemoryStream mStream = new MemoryStream();
                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;             //默认值  
                tdsp.Padding = PaddingMode.PKCS7;       //默认值  
                                                        // Create a CryptoStream using the MemoryStream   
                                                        // and the passed key and initialization vector (IV).  
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(byteKey, byteIv),
                    CryptoStreamMode.Write);
                // Write the byte array to the crypto stream and flush it.  
                cStream.Write(byteData, 0, data.Length);
                cStream.FlushFinalBlock();
                // Get an array of bytes from the   
                // MemoryStream that holds the   
                // encrypted data.  
                byte[] ret = mStream.ToArray();
                // Close the streams.  
                cStream.Close();
                mStream.Close();
                // Return the encrypted buffer.  
                return Convert.ToBase64String(ret);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>  
        /// DES3 CBC模式解密  
        /// </summary>  
        /// <param name="key">密钥</param>  
        /// <param name="iv">IV</param>  
        /// <param name="data">密文</param>  
        /// <returns>明文</returns>  
        public static string Des3DecodeCBC(string key, string iv, string data)
        {
            try
            {
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                byte[] byteKey = utf8.GetBytes(key);
                byte[] byteIv = utf8.GetBytes(iv);
                byte[] byteData = Convert.FromBase64String(data);
                // Create a new MemoryStream using the passed   
                // array of encrypted data.  
                using (MemoryStream msDecrypt = new MemoryStream(byteData))
                {
                    TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                    tdsp.Mode = CipherMode.CBC;
                    tdsp.Padding = PaddingMode.PKCS7;
                    // Create a CryptoStream using the MemoryStream   
                    // and the passed key and initialization vector (IV).  
                    CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                        tdsp.CreateDecryptor(byteKey, byteIv),
                        CryptoStreamMode.Read);
                    // Create buffer to hold the decrypted data.  
                    byte[] fromEncrypt = new byte[byteData.Length];
                    // Read the decrypted data out of the crypto stream  
                    // and place it into the temporary buffer.  
                    csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                    //Convert the buffer into a string and return it.  
                    return utf8.GetString(fromEncrypt).TrimEnd('\0');
                }
            }
            catch
            {

                return null;
            }
        }
    }
}
