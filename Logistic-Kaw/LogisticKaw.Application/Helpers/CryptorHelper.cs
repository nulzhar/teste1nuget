using System;
using System.Security.Cryptography;
using System.Text;

namespace LogisticKaw.Application.Helpers
{
    /// <summary>
    /// Cryptor Helper to protect password.
    /// </summary>
    public static class CryptorHelper
    {
        /// <summary>
        /// Encrypt password to secure the information on database.
        /// </summary>
        /// <param name="password">Password to encrypt</param>
        /// <param name="key">Key of Cryptor</param>
        /// <returns></returns>
        public static string EncryptPassword(string password, string key)
        {
            try
            {
                byte[] KeyArray;
                byte[] ToEncryptArray = Encoding.UTF8.GetBytes(password);

                MD5CryptoServiceProvider HashMd5 = new MD5CryptoServiceProvider();
                KeyArray = HashMd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                HashMd5.Clear();

                TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
                TDES.Key = KeyArray;
                TDES.Mode = CipherMode.ECB;
                TDES.Padding = PaddingMode.PKCS7;

                ICryptoTransform CryptoTransform = TDES.CreateEncryptor();
                byte[] ResultArray = CryptoTransform.TransformFinalBlock(ToEncryptArray, 0, ToEncryptArray.Length);
                TDES.Clear();
                return Convert.ToBase64String(ResultArray, 0, ResultArray.Length);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Decrypt password to read the information.
        /// </summary>
        /// <param name="password">Password to encrypt</param>
        /// <param name="key">Key of Cryptor</param>
        /// <returns></returns>
        public static string DecryptPassword(string password, string key)
        {
            try
            {
                byte[] KeyArray;
                byte[] ToEncryptArray = Convert.FromBase64String(password);
                
                MD5CryptoServiceProvider HashMd5 = new MD5CryptoServiceProvider();
                KeyArray = HashMd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                HashMd5.Clear();

                TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
                TDES.Key = KeyArray;
                TDES.Mode = CipherMode.ECB;
                TDES.Padding = PaddingMode.PKCS7;

                ICryptoTransform cryptoTransform = TDES.CreateDecryptor();
                byte[] ResultArray = cryptoTransform.TransformFinalBlock(ToEncryptArray, 0, ToEncryptArray.Length);
                TDES.Clear();
                return Encoding.UTF8.GetString(ResultArray);
            }
            catch
            {
                throw;
            }
        }
    }
}
