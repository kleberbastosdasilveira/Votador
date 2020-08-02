using System;
using System.Security.Cryptography;
using System.Text;

namespace Date.Security
{
    internal class Cryptography
    {
        internal string EncryptCardData(string data)
        {
            return Encrypt(Constant.SecurityCardDataCryptographyKey, data);
        }
        protected string Encrypt(string key, string data)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(data);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        internal string DecryptCardData(string data)
        {
            return Decrypt(Constant.SecurityCardDataCryptographyKey, data);
        }

        protected string Decrypt(string key, string data)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(data);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            string retorno = UTF8Encoding.UTF8.GetString(resultArray).ToString();
            return retorno;
        }
    }
}
