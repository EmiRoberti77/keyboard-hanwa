using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CommaBoard.Store.Static
{
    public static class Cipher
    {
        /// <summary>
        /// Take a string value and encrypt it
        /// </summary>
        /// <param name="textToEncrypt">Take a string value and encrypt it</param>
        /// <param name="publicKey">public key</param>
        /// <param name="privateKey">private key</param>
        /// <returns>Encrypted value</returns>
        public static string Encrypt(string stringToEncrypt, string publicKey, string privateKey)
        {
            try
            {
                string ToReturn = "";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(privateKey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publicKey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(stringToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Take an encrypted string and decrypt it
        /// </summary>
        /// <param name="stringToDecrypt">Encrypted value</param>
        /// <param name="publicKey">public key</param>
        /// <param name="privateKey">private key</param>
        /// <returns>Decrypted value</returns>
        public static string Decrypt(string stringToDecrypt, string publicKey, string privateKey)
        {
            try
            {
                string ToReturn = "";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(privateKey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publicKey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[stringToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(stringToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }
}
