using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;

namespace JXTPortal.Common
{
    public static class GoogleReCaptcha
    {
        private static string _SiteKey = ConfigurationManager.AppSettings["GoogleReCaptchaSiteKey"];
        private static string _SiteSecret = ConfigurationManager.AppSettings["GoogleReCaptchaSiteSecret"];

        public static string SiteKey { get { return _SiteKey; } }

        public static bool Validate(int siteID, string captchaResponse)
        {
            //ignore siteID for now, in the future maybe needed

            //send REST API request
            WebRequest webRequest = null;
            StreamReader responseStreamReader = null;
            string strTokenResponse = "";

            string restContactsQuery = "https://www.google.com/recaptcha/api/siteverify";

            string postData = ("secret=" + _SiteSecret + "&response=" + captchaResponse);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restContactsQuery);
            webRequest.Method = "POST";

            webRequest.ContentLength = byteArray.Length;
            webRequest.ContentType = "application/x-www-form-urlencoded";

            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            System.Net.WebResponse response = null;
            try
            {
                response = webRequest.GetResponse();
                Stream postStream = response.GetResponseStream();
                responseStreamReader = new StreamReader(postStream);

                strTokenResponse = responseStreamReader.ReadToEnd();

                GoogleReCaptchaResponse validateResult;
                using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(strTokenResponse)))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GoogleReCaptchaResponse));
                    validateResult = (GoogleReCaptchaResponse)serializer.ReadObject(ms);
                }

                if( validateResult != null )
                    return validateResult.success;

                return false;
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();
                }
                return false;
            }
        }

        public static string SecureTokenGet()
        {
            //Example: {"session_id": e6e9c56e-a7da-43b8-89fa-8e668cc0b86f,"ts_ms":1421774317718}
            string jsonToken = "{" + string.Format("\"session_id\": {0},\"ts_ms\":{1}", Guid.NewGuid(), CurrentTimeMillis()) + "}";

            string base64SecureToken = EncryptJsonToken(jsonToken);
            return base64SecureToken;
        }
        
        
        private static string EncryptJsonToken(string jsonToken)
        {
            byte[] encrypted = EncryptStringToBytes_Aes(jsonToken, getKey(_SiteSecret), getKey(_SiteSecret));

            //Base64 encode the encrypted data
            //Also applys the URL variant of base64 encoding, unfortunately the HttpServerUtility.UrlTokenEncode(encrypted) seems to truncate the last value from the string so we can't use it?
            return Convert.ToBase64String(encrypted, Base64FormattingOptions.None).Replace("=", String.Empty).Replace('+', '-').Replace('/', '_');
        }

        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an AesManaged object 
            // with the specified key and IV. 
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Mode = CipherMode.ECB;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream. 
            return encrypted;
        }

        /// <summary>
        /// Gets the first 16 bytes of the SHA1 version of the SecretKey. (This is not documented ANYWHERE on googles dev site, you have to READ the java code to figure this out!!!!)
        /// </summary>
        /// <param name="secretKey">Googles recaptcha SecretKey</param>
        /// <returns>First 16 bytes of the SHA1 hash of the SecretKey</returns>
        private static byte[] getKey(string secretKey)
        {
          SHA1 sha = SHA1.Create();
          byte[] dataToHash = Encoding.UTF8.GetBytes(secretKey);
          byte[] shaHash = sha.ComputeHash(dataToHash);
          byte[] first16OfHash = new byte[16];
          Array.Copy(shaHash, first16OfHash, 16);
          return first16OfHash;
        }

        private static readonly DateTime Jan1st1970 = new DateTime
(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Implementation of Java's currentTimeMillis
        /// </summary>
        /// <returns></returns>
        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        #region Models

        [DataContract]
        private class GoogleReCaptchaResponse
        {
            [DataMember(Name="success")]
            public bool success { get; set; }
            [DataMember(Name="error-codes")]
            public List<string> errors { get; set; }
        }


        #endregion

    }
}
