using System;
using System.Security.Cryptography;
using System.Text;

namespace RavePay.Net.SDK.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class EncryptionUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encrypt(string source, string key, bool useHashing = false)
        {
            var desCryptoProvider = new TripleDESCryptoServiceProvider();


            byte[] byteHash;
            byte[] byteBuff;

            byteHash = Encoding.UTF8.GetBytes(key);

            if (useHashing)
            {
                var hashMD5Provider = new MD5CryptoServiceProvider();
                byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            }


            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            desCryptoProvider.Padding = PaddingMode.PKCS7;
            byteBuff = Encoding.UTF8.GetBytes(source);

            string encoded =
                Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return encoded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encodedText"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string encodedText, string key, bool useHashing = false)
        {
            var desCryptoProvider = new TripleDESCryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = Encoding.UTF8.GetBytes(key);

            if (useHashing)
            {
                var hashMD5Provider = new MD5CryptoServiceProvider();
                byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            }


            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            desCryptoProvider.Padding = PaddingMode.PKCS7;
            byteBuff = Convert.FromBase64String(encodedText);

            return Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));

        }
    }
}
