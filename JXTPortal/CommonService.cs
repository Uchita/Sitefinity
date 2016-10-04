using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace JXTPortal
{
    public class CommonService
    {
        public static string EncryptMD5(string input)
        {
            string strEncrypted = string.Empty;

            using (MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider())
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Byte[] hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(ConfigurationManager.AppSettings["SaltKey"] + input));
                strEncrypted = Convert.ToBase64String(hashedDataBytes);
            }

            return strEncrypted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="blnAllHTMLTags"></param>
        /// <param name="blnStripScriptTags"></param>
        /// <returns></returns>
        public static string EncodeString(string text, bool blnEncode = true, bool blnAllHTMLTags = false, bool blnStripScriptTags = false)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    if (blnAllHTMLTags)
                    {
                        text = Regex.Replace(text, @"<.*?>", String.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    }
                    if (blnStripScriptTags)
                    {
                        //<script[^>]*>[\s\S]*?</script>
                        //(?s)<\s?script.*?(/\s?>|<\s?/\s?script\s?>)
                        text = Regex.Replace(text, @"<script[^>]*>[\s\S]*?</script>", String.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase);                        
                    }

                    if (blnEncode)
                        text = HttpUtility.HtmlEncode(text);

                }
            }
            catch
            {
            }

            return text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="blnAllHTMLTags"></param>
        /// <param name="blnStripScriptTags"></param>
        /// <returns></returns>
        public static string DecodeString(string text, bool blnDecode = true, bool blnAllHTMLTags = false, bool blnStripScriptTags = false)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    if (blnAllHTMLTags)
                    {
                        text = Regex.Replace(text, @"<.*?>", String.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    }
                    if (blnStripScriptTags)
                    {
                        //<script[^>]*>[\s\S]*?</script>
                        //(?s)<\s?script.*?(/\s?>|<\s?/\s?script\s?>)
                        text = Regex.Replace(text, @"<script[^>]*>[\s\S]*?</script>", String.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    }

                    if (blnDecode)
                        text = HttpUtility.HtmlDecode(text);

                }
            }
            catch
            {
            }

            return text;
        }
        public static string EncryptTripleDES(string input, string key)
        {
            try
            {
                byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception e)
            {
                return string.Empty;
            }

        }

        public static string DecryptTripleDES(string input, string key)
        {
            try
            {
                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception e)
            {
                return string.Empty;
            }

        }



    }
}
