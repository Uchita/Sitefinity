using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Web.UI;
using System.Xml.Serialization;
using System.Xml;
using System.Data;
using System.ComponentModel;
using System.Web.UI.WebControls;

using Microsoft.Win32;
using System.Runtime.InteropServices;


namespace JXTPortal.Common
{
    public class Utils
    {
        private enum Language
        {
            English = 1,
            Chinese = 2,
            US = 3,
            Japanese = 4,
            Korean = 5,
            Thai = 6,
            SimplifiedChinese = 7,
            Vietnamese = 8,
            Dutch = 9,
            French = 10,
            German = 11,
            Spanish = 12,
            LatinAmericanSpanish = 13
        };

        public static string GetAppSettings(String str)
        {
            return ConfigurationSettings.AppSettings[str];
        }

        public static int GetAppSettingsInt(String str)
        {
            return Convert.ToInt32(ConfigurationSettings.AppSettings[str]);
        }

        public static bool IsValidInt(String str)
        {
            int myInt = 0;
            if (!string.IsNullOrWhiteSpace(str) && int.TryParse(str, out myInt))
            {
                return true;
            }

            return false;
        }

        public static decimal GetGST(decimal TotalPrice)
        {
            double dblGSTPercent = double.Parse(ConfigurationManager.AppSettings["GST"]);
            decimal decAmountLessGST;
            decAmountLessGST = (decimal)((double)TotalPrice * (dblGSTPercent / 100));
            return (decimal)decAmountLessGST;
        }

        public static string HtmlEncode(string val)
        {
            if (string.IsNullOrEmpty(val))
                return string.Empty;
            else
                return HttpUtility.HtmlEncode(val);
        }

        public static string XmlEncode(string val)
        {
            val = val.Replace("\"", "&quot;").Replace("&", "&amp;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;");

            return val;
        }

        public static string GetHostName()
        {
            return System.Net.Dns.GetHostName();
        }

        public static string GetClientIPAddress()
        {
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
                return HttpContext.Current.Request.UserHostAddress.ToString();

            return string.Empty;
        }

        public static string GetIPAddress()
        {
            return (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null) ?
                    HttpContext.Current.Request.UserHostAddress : HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }

        /// <summary>
        /// Get Url Referrer of the Url
        /// </summary>
        /// <returns></returns>
        public static string GetUrlReferrerDomain()
        {
            if (HttpContext.Current.Request.UrlReferrer != null && !string.IsNullOrWhiteSpace(HttpContext.Current.Request.UrlReferrer.Host))
                return (HttpContext.Current.Request.UrlReferrer.Host.Replace("www.", string.Empty));
            // If the referrer doesn't exists then look for utm_source.
            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request.Params["utm_source"]))
                return HttpContext.Current.Request.Params["utm_source"];
            // If the referrer & utm_source don't exists then its always the domain the user is in.
            return HttpContext.Current.Request.Url.Host.ToLower().Replace("www.", string.Empty);
        }


        public static string GetTrackingUtmTags(string strLink)
        {
            // utm_source=Indeed&utm_medium=organic&utm_campaign=Indeed
            // Get the UTM tags

            string strUtmTags = string.Empty;

            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request.Params["utm_source"]))
                strUtmTags = "utm_source=" + HttpContext.Current.Request.Params["utm_source"];
            /*
            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request.Params["utm_medium"]))
                strUtmTags = strUtmTags + (string.IsNullOrWhiteSpace(strUtmTags) ? string.Empty : "&") + "utm_medium=" + HttpContext.Current.Request.Params["utm_medium"];

            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request.Params["utm_campaign"]))
                strUtmTags = strUtmTags + (string.IsNullOrWhiteSpace(strUtmTags) ? string.Empty : "&") + "utm_campaign=" + HttpContext.Current.Request.Params["utm_campaign"];
            */
            if (strLink.Contains("?") && !string.IsNullOrWhiteSpace(strUtmTags))
                strLink = strLink + "&" + strUtmTags;

            return strLink;
            //strLink
        }


        public static string GetUrlDomain()
        {
            return HttpContext.Current.Request.Url.Host.ToLower().Replace("www.", string.Empty);
        }

        public static string GetCookieDomain(HttpCookie httpCookie, int jobid)
        {
            if (httpCookie != null)
            {
                string jobviewedcookie = httpCookie.Value;
                string[] jobviewed = jobviewedcookie.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] tempjobids = null;
                string tempjobid = string.Empty;
                foreach (string viewed in jobviewed)
                {
                    // Retrieve Job ID
                    tempjobids = viewed.Split(new char[] { '|' });
                    tempjobid = tempjobids[0];

                    // if Job ID matches
                    if (tempjobid == jobid.ToString())
                    {
                        if (tempjobids.Length == 2)
                        {
                            // Retrieve Domain
                            return tempjobids[1];
                        }
                    }
                }
            }

            // If the referrer doesn't exists then its always the domain the user is in.
            return HttpContext.Current.Request.Url.Host.ToLower().Replace("www.", string.Empty);
        }

        public static string GetMD5Password(string password)
        {
            MD5 md5Header = MD5.Create();
            byte[] data = md5Header.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string StripHTML(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                return Regex.Replace(inputString, "<.*?>", "");
            }
            else
                return string.Empty;
        }

        public static string ReplaceNewlineWithBRTags(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                return Regex.Replace(inputString, "\n", "<br />");
            }
            else
                return string.Empty;
        }

        public static string GetContentFromWebUrl(string url)
        {
            string strContent = string.Empty;

            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    var webRequest = System.Net.WebRequest.Create(url);

                    using (var response = webRequest.GetResponse())
                    using (var content = response.GetResponseStream())
                    using (var reader = new StreamReader(content))
                    {
                        strContent = reader.ReadToEnd();
                    }
                }
            }
            catch { }

            return strContent;
        }

        public static string CleanScriptStyleTags(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                inputString = Regex.Replace(inputString, "<script.*?</script>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                inputString = Regex.Replace(inputString, "<style.*?</style>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                return inputString;
            }
            else
                return string.Empty;
        }
        public static string CleanStringSpaces(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                inputString = inputString.Replace("&nbsp;", " ");
                return Regex.Replace(inputString, @"\s+", " ");
            }
            else
                return string.Empty;

        }

        public static string RemoveMetaSpecialCharacters(string str, int languageId = 1)
        {
            // Todo - only these characters - \/:?*" ' <> |
            if (!String.IsNullOrEmpty(str))
            {
                if (languageId == (int)Language.English || languageId == (int)Language.US)
                {
                    return Regex.Replace(str, @"[_""']+", "", RegexOptions.Compiled);
                }
                else
                {
                    return str;
                }
            }

            return string.Empty;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                return Regex.Replace(str, "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled);
            }

            return string.Empty;
        }

        public static string CleanKeywords(string inputString)
        {
            inputString = CleanStringSpaces(inputString);
            if (!String.IsNullOrEmpty(inputString))
            {
                return inputString.Replace(" ", " OR ");
            }

            return string.Empty;
        }

        public static bool VerifyEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                return Regex.IsMatch(email, ConfigurationManager.AppSettings["EmailValidationRegex"], RegexOptions.IgnoreCase);
            }

            return false;
        }

        public static string UrlFriendlyName(string strName)
        {
            if (!String.IsNullOrEmpty(strName))
            {
                strName = strName.Replace("+", "plus").Replace("&", "and").Replace("?", "").Replace("'", "-");

                strName = System.Text.RegularExpressions.Regex.Replace(strName, @"[^a-zA-Z0-9]+", "-");

                strName = System.Text.RegularExpressions.Regex.Replace(strName, @"[-]+", "-").ToLower();

                if (strName.Length > 0 && strName.Substring(0, 1) == "-")
                {
                    strName = strName.Substring(1);
                }

            }

            return strName;

        }

        public static string GetJobBrowseUrl(string purlname, string rurlname, string curlname, string lurlname, string wurlname, int pageno)
        {
            string purl = string.Empty;
            string rurl = string.Empty;
            string curl = string.Empty;
            string lurl = string.Empty;
            string wurl = string.Empty;
            string pn = string.Empty;

            if (!string.IsNullOrEmpty(purlname))
            {
                purl = "/p/" + purlname + "-jobs";
            }

            if (!string.IsNullOrEmpty(rurlname))
            {
                rurl = "/r/" + rurlname + "-jobs";
            }

            if (!string.IsNullOrEmpty(curlname))
            {
                curl = "/c/" + curlname + "-jobs";
            }

            if (!string.IsNullOrEmpty(lurlname))
            {
                lurl = "/l/" + lurlname + "-jobs";
            }

            if (!string.IsNullOrEmpty(wurlname))
            {
                wurl = "/w/" + wurlname + "-jobs";
            }

            if (pageno > 1)
            {
                pn = pageno.ToString();
            }

            if (string.IsNullOrEmpty(purl) && string.IsNullOrEmpty(rurl) && string.IsNullOrEmpty(curl) && string.IsNullOrEmpty(lurl) && string.IsNullOrEmpty(wurl))
            {
                pn = "jobbrowse/" + pn;
            }

            return string.Format("{0}{1}{2}{3}{4}/{5}", curl, lurl, wurl, purl, rurl, pn);
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static string GenerateRandomCode(int length)
        {
            string charPool = "ABCDEFGOPQRSTUVWXY1234567890ZabcdefghijklmHIJKLMNnopqrstuvwxyz";
            StringBuilder rs = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                rs.Append(charPool[(int)(random.NextDouble() * charPool.Length)]);
            }
            return rs.ToString();
        }

        public static System.Drawing.Image ResizeImage(System.Drawing.Image objOriginalImage, int intWidth, int intHeight)
        {
            double dblRatio;
            double dblResizeWidth;
            double dblResizeHeight;

            if (objOriginalImage.Width > intWidth)
            {
                // need to resize width as image is too wide
                dblResizeWidth = (double)intWidth / (double)objOriginalImage.Width;
            }
            else
            {
                dblResizeWidth = 1.0;
            }

            if (objOriginalImage.Height > intHeight)
            {
                dblResizeHeight = (double)intHeight / (double)objOriginalImage.Height;
            }
            else
            {
                dblResizeHeight = 1;
            }

            // choose the smaller of resize height and resize width
            if (dblResizeWidth < dblResizeHeight)
            {
                dblRatio = dblResizeWidth;
            }
            else
            {
                dblRatio = dblResizeHeight;
            }

            // resize the image
            int intNewWidth = (int)((double)objOriginalImage.Width * dblRatio);
            int intNewHeight = (int)((double)objOriginalImage.Height * dblRatio);
            System.Drawing.Image objResizedImage;
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(mThumbnailImageAbort);

            objResizedImage = objOriginalImage.GetThumbnailImage(intNewWidth, intNewHeight, myCallback, IntPtr.Zero);

            return objResizedImage;
        }

        private static bool mThumbnailImageAbort()
        {
            return false;
        }



        public static void ScrollTo(System.Web.UI.Control control)
        {
            control.Page.RegisterClientScriptBlock("ScrollTo", string.Format(@"

        <script type='text/javascript'> 

                $(document).ready(function() {{
                        var element = document.getElementById('{0}');
                        element.scrollIntoView();
                        element.focus();
                }});

        </script>

    ", control.ClientID));
        }

        public static string MessageDisplayWrapper(string text, BootstrapAlertType alertType)
        {
            string wrapperClass = string.Empty;

            switch (alertType)
            {
                case BootstrapAlertType.Success:
                    wrapperClass = "alert-success";
                    break;
                case BootstrapAlertType.Info:
                    wrapperClass = "alert-info";
                    break;
                case BootstrapAlertType.Warning:
                    wrapperClass = "alert-warning";
                    break;
                case BootstrapAlertType.Danger:
                    wrapperClass = "alert-danger";
                    break;
            }

            return string.Format(@"<div class=""alert {0}"">{1}</div>", wrapperClass, text);
        }


        #region "Security Functions"

        public static byte[] DecryptFile(string inputFile)
        {
            try
            {
                string password = System.Configuration.ConfigurationManager.AppSettings["EncryptionKey"];
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                byte[] encryptedFile = File.ReadAllBytes(inputFile);

                RijndaelManaged myRijndael = new RijndaelManaged();
                myRijndael.Mode = CipherMode.CBC;
                myRijndael.Padding = PaddingMode.None;

                ICryptoTransform decryptor = myRijndael.CreateDecryptor(key, key);

                MemoryStream msDecrypt = new MemoryStream(encryptedFile);

                CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

                byte[] fromEncrypt = new byte[encryptedFile.Length];

                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                return fromEncrypt;
            }
            catch (Exception ex)
            {
                return File.ReadAllBytes(inputFile);
            }
        }

        public static void EncryptFile(byte[] stream, string filepath)
        {
            EncryptFile(new MemoryStream(stream), filepath);
        }

        public static void EncryptFile(Stream stream, string filepath)
        {
            //    string password = System.Configuration.ConfigurationManager.AppSettings["EncryptionKey"]; // Your Key Here

            //    UnicodeEncoding UE = new UnicodeEncoding();
            //    byte[] key = UE.GetBytes(password);

            //    RijndaelManaged RMCrypto = new RijndaelManaged();

            //    CryptoStream cs = new CryptoStream(stream,
            //        RMCrypto.CreateEncryptor(key, key),
            //        CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(filepath, FileMode.Create);

            int data;
            while ((data = stream.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            //cs.Close();
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = ConfigurationManager.AppSettings["EncryptionKey"];
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = ConfigurationManager.AppSettings["EncryptionKey"];

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        #endregion

        #region "Job Functions"

        public static void UpdateJobsViewedCookie(int jobid, string domain, out bool counterupdaterequired)
        {
            counterupdaterequired = false;
            // Update the Job Views
            if (HttpContext.Current.Request.Cookies["JobsViewed"] == null)
            {
                //JobViewsService.UpdateCounter(ucJobPreview.JobId, SessionData.Site.SiteId, domain, DateTime.Now.Date);
                counterupdaterequired = true;

                HttpCookie aCookie = new HttpCookie("JobsViewed");
                aCookie.HttpOnly = true;
                // Secure the cookie
                if (HttpContext.Current.Request.IsSecureConnection == true)
                    aCookie.Secure = true;

                aCookie.Value = string.Format("{0}|{1}", jobid, domain);
                aCookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(aCookie);
            }
            else
            {
                string strCookie = HttpContext.Current.Request.Cookies["JobsViewed"].Value;

                if (strCookie.Contains(string.Format("{0}|", jobid)))
                {
                    foreach (string cookie in strCookie.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (cookie.StartsWith(string.Format("{0}|", jobid)))
                        {
                            string value = HttpContext.Current.Request.Cookies["JobsViewed"].Value.Replace(cookie, string.Empty).Replace(",,", ",") + string.Format(",{0}|{1}", jobid.ToString(), domain);
                            DateTime expirydate = HttpContext.Current.Request.Cookies["JobsViewed"].Expires;

                            HttpContext.Current.Response.Cookies.Remove("JobsViewed");

                            HttpCookie aCookie = new HttpCookie("JobsViewed");
                            aCookie.HttpOnly = true;
                            // Secure the cookie
                            if (HttpContext.Current.Request.IsSecureConnection == true)
                                aCookie.Secure = true;

                            aCookie.Value = value;
                            aCookie.Expires = expirydate;
                            HttpContext.Current.Response.Cookies.Add(aCookie);

                            break;
                        }
                    }
                }
                else
                {
                    // Insert to JobsViewed Cookie
                    counterupdaterequired = true;
                    //JobViewsService.UpdateCounter(ucJobPreview.JobId, SessionData.Site.SiteId, domain, DateTime.Now.Date);
                    string value = HttpContext.Current.Request.Cookies["JobsViewed"].Value + string.Format(",{0}|{1}", jobid, domain);
                    DateTime expirydate = HttpContext.Current.Request.Cookies["JobsViewed"].Expires;

                    HttpContext.Current.Response.Cookies.Remove("JobsViewed");

                    HttpCookie aCookie = new HttpCookie("JobsViewed");
                    aCookie.HttpOnly = true;
                    // Secure the cookie
                    if (HttpContext.Current.Request.IsSecureConnection == true)
                        aCookie.Secure = true;

                    aCookie.Value = value;
                    aCookie.Expires = expirydate;
                    HttpContext.Current.Response.Cookies.Add(aCookie);
                }
            }
        }

        public static string GetJobUrl(int JobID, string strPageFriendlyName)
        {
            //return string.Format("/{0}-jobs/{1}/{2}", UrlFriendlyName(strProfessionName), strPageFriendlyName, JobID);
            return string.Format("{0}/{1}", strPageFriendlyName, JobID);
        }

        public static string GetJobUrl(int JobID, string strPageFriendlyName, string strProfessionName)
        {
            return string.Format("/{0}-jobs/{1}/{2}", UrlFriendlyName(strProfessionName), strPageFriendlyName, JobID);
        }

        public static string GetApplyJobUrl(int JobID, string strPageFriendlyName, string strProfessionName)
        {
            return string.Format("/applyjob/{0}-jobs/{1}/{2}", UrlFriendlyName(strProfessionName), strPageFriendlyName, JobID);
        }

        public static string GetEmailMeUrl(string professionFriendlyName, int JobID)
        {
            professionFriendlyName = professionFriendlyName.Split(new char[] { '/' },
                StringSplitOptions.RemoveEmptyEntries)[0].TrimEnd(new char[] { 'j', 'o', 'b', 's' }).TrimEnd(new char[] { '-' });

            return string.Format("/job/emailme/{0}/{1}/", JobID, professionFriendlyName);
        }

        public static string GetEmailFriendUrl(string professionFriendlyName, int JobID)
        {
            return string.Format("/job/emailfriend/{0}/{1}/", JobID, professionFriendlyName.ToLower());
        }


        public static string SpecialCharsSearchField(string text)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    foreach (char c in text.ToCharArray())
                    {
                        System.Globalization.UnicodeCategory cat = Char.GetUnicodeCategory(c);

                        if (cat == System.Globalization.UnicodeCategory.OtherLetter)
                        {
                            text = text.Replace(c.ToString(), c.ToString() + " ");
                        }
                    }

                    text = text.Replace("  ", " ");
                }
            }
            catch { }

            return text;
        }


        public static bool CheckIDArray(string ids)
        {
            Regex regex = new Regex("^[0-9]+([,][0-9]+)*$");

            return regex.IsMatch(ids);
        }

        #endregion

        #region "Templates Function"

        public static List<string> TokenExtract(string html)
        {
            List<string> tokens = new List<string>();

            // Create a new Regex object and define the regular expression.
            Regex r = new Regex(@"\{(\s*?.*?)*?\}", RegexOptions.Compiled);

            // Use the Matches method to find all matches in the input string.
            MatchCollection mc = r.Matches(html);

            // Loop through the match collection to retrieve all 
            // matches and positions.
            for (int i = 0; i < mc.Count; i++)
            {
                // Add the match string to the string array.   
                tokens.Add(mc[i].Value);
            }

            return tokens;
        }

        public static string TokenReplace<T>(T dataSource, string html)
        {
            string strHtml = html;

            foreach (string token in TokenExtract(html))
            {
                if (token != "{JobTemplateHtml}")
                {
                    PropertyInfo piPrimaryKeyField = dataSource.GetType().GetProperty(token.Replace("{", "").Replace("}", ""));

                    if (piPrimaryKeyField != null)
                    {
                        if ((piPrimaryKeyField.GetValue(dataSource, null)) != null)
                        {
                            if (piPrimaryKeyField.PropertyType != typeof(byte[]))
                            {
                                strHtml = strHtml.Replace(token, (piPrimaryKeyField.GetValue(dataSource, null)).ToString());
                            }
                        }
                        else
                        {
                            strHtml = strHtml.Replace(token, string.Empty);
                        }
                    }
                }
            }

            return strHtml;
        }


        /// <summary>
        /// Get Enums and convert it to Dictionary - This will be helpful for Dropdowns
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IDictionary<int, string> GetEnumForDropDowns<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            var dictionary = new Dictionary<int, string>();

            if (enumerationType.IsEnum)
            {
                foreach (int value in Enum.GetValues(enumerationType))
                {
                    var name = Enum.GetName(enumerationType, value);
                    dictionary.Add(value, name);
                }
            }

            return dictionary;
        }

        public static List<string> AttributeExtract<T>(T objectSource)
        {
            List<string> attributeList = new List<string>();

            Type myObjectType = objectSource.GetType();
            PropertyInfo[] pi = myObjectType.GetProperties();

            foreach (PropertyInfo info in pi)
            {
                //Dim Myattributes As PropertyAttributes = Mypropertyinfo.Attributes
                object[] attributes = info.GetCustomAttributes(false);

                foreach (var attribute in attributes)
                {
                    if (attribute is System.ComponentModel.DataObjectFieldAttribute || attribute is System.ComponentModel.DescriptionAttribute)
                    {
                        attributeList.Add("{" + info.Name + "}");
                    }
                }

            }

            return attributeList;
        }

        public static string RenderToString(Control control)
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            using (var textWriter = new HtmlTextWriter(sw))
            {
                control.RenderControl(textWriter);
            }

            return sb.ToString();
        }

        #endregion


        /*
        private byte[] GeneratePDFFromFormModelXML(string xml)
        {
            string testXML = @"";

            //create instance of CForm_Complete
            CForm_Complete completeForm = (CForm_Complete)BuildManager.CreateInstanceFromVirtualPath("~/CForm_Complete.aspx", typeof(CForm_Complete));
            completeForm.SetXMLContent(testXML);//"Give me the XML string here"

            //Make server to execute and return the output as string
            StringWriter htmlOutput = new StringWriter();
            HttpContext.Current.Server.Execute(completeForm, htmlOutput, false);

            //Process the html to PDF
            byte[] ding_here_is_the_file_in_byte = new PDFCreator().ConvertHTMLToPDF(htmlOutput.ToString());

            return ding_here_is_the_file_in_byte;

            //File.WriteAllBytes(Server.MapPath("/Content/XML/Foo.pdf"), ding_here_is_the_file_in_byte);
        }*/

        public static byte[] SavePDF(string url)
        {
            //Process the html to PDF
            byte[] ding_here_is_the_file_in_byte = new PDFCreator().ConvertURLToPDF(url);

            //ByteArrayToFile(@"C:\Developments\MiniJXT\MiniJXT\JXTPortal.Website\xml\test.pdf", ding_here_is_the_file_in_byte);

            return ding_here_is_the_file_in_byte;

            //File.WriteAllBytes(Server.MapPath("/Content/XML/Foo.pdf"), ding_here_is_the_file_in_byte);
        }

        public static bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // close file stream
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            // error occured, return false
            return false;
        }

        public static bool IsValidUploadFile(Stream filestream)
        {
            try
            {
                UInt32 unMimeType;
                using (var memory = new MemoryStream())
                {
                    filestream.Position = 0;
                    filestream.CopyTo(memory);
                    byte[] byteArray = memory.ToArray();


                    FindMimeFromData(0, null, byteArray, 256, null, 0, out unMimeType, 0);

                    IntPtr pMimeType = new IntPtr(unMimeType);
                    string sMimeTypeFromFile = Marshal.PtrToStringUni(pMimeType);

                    Marshal.FreeCoTaskMem(pMimeType);

                    if (sMimeTypeFromFile != "text/plain" && sMimeTypeFromFile != "text/xml" &&
                        byteArray.Take(4).SequenceEqual(new byte[4] { 37, 80, 68, 70 }) == false &&
                        byteArray.Take(8).SequenceEqual(new byte[8] { 208, 207, 17, 224, 161, 177, 26, 225 }) == false && // doc, xls, ppt
                        byteArray.Take(5).SequenceEqual(new byte[5] { 80, 75, 3, 4, 20 }) == false &&
                        byteArray.Take(8).SequenceEqual(new byte[8] { 137, 80, 78, 71, 13, 10, 26, 10 }) == false && // png
                        byteArray.Take(6).SequenceEqual(new byte[6] { 71, 73, 70, 56, 57, 97 }) == false && // gif
                        byteArray.Take(6).SequenceEqual(new byte[6] { 71, 73, 70, 56, 55, 97 }) == false && // gif 
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 224 }) == false && // jpg
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 225 }) == false &&
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 226 }) == false &&
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 227 }) == false &&
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 232 }) == false &&
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 237 }) == false &&
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 238 }) == false &&
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 219 }) == false &&
                        byteArray.Take(4).SequenceEqual(new byte[4] { 0, 0, 1, 0 }) == false) // ico
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool IsValidUploadImage(string filename, byte[] byteArray, out System.Drawing.Image image, out string contenttype)
        {
            image = null;
            contenttype = "image/gif";
            bool validext = false;
            string strExt = string.Empty;

            if (!string.IsNullOrWhiteSpace(filename))
            {
                strExt = Path.GetExtension(filename).Trim();

                switch (strExt.ToUpper().Trim())
                {
                    case ".GIF":
                    case ".JPG":
                    case ".JPEG":
                    case ".PNG":
                        validext = true;
                        break;
                    default:
                        validext = false;
                        break;
                }

            }


            if (validext || string.IsNullOrWhiteSpace(filename))
            {
                try
                {
                    UInt32 unMimeType;
                    using (var memory = new MemoryStream(byteArray))
                    {
                        FindMimeFromData(0, null, byteArray, 256, null, 0, out unMimeType, 0);

                        IntPtr pMimeType = new IntPtr(unMimeType);
                        string sMimeTypeFromFile = Marshal.PtrToStringUni(pMimeType);

                        Marshal.FreeCoTaskMem(pMimeType);
                        System.Drawing.Imaging.ImageFormat imgformat = System.Drawing.Imaging.ImageFormat.Png;

                        if (byteArray.Take(8).SequenceEqual(new byte[8] { 137, 80, 78, 71, 13, 10, 26, 10 }))
                        {
                            contenttype = "image/png";
                            imgformat = System.Drawing.Imaging.ImageFormat.Png;
                        }
                        else if (byteArray.Take(6).SequenceEqual(new byte[6] { 71, 73, 70, 56, 57, 97 }) ||
                        byteArray.Take(6).SequenceEqual(new byte[6] { 71, 73, 70, 56, 55, 97 }))
                        {
                            contenttype = "image/gif";
                            imgformat = System.Drawing.Imaging.ImageFormat.Gif;
                        }
                        else if (
                            byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 224 }) ||
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 225 }) ||
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 226 }) ||
                            byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 227 }) ||
                            byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 232 }) ||
                            byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 237 }) ||
                            byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 238 }))
                        {
                            contenttype = "image/jpeg";
                            imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        }
                        else
                        {
                            return false;
                        }

                        image = System.Drawing.Image.FromStream(memory);
                        // image.Save(memory, imgformat); 
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static bool IsValidUploadImage(string filename, Stream filestream, out System.Drawing.Image image, out string contenttype)
        {
            image = null;
            contenttype = "image/gif";
            bool validext = false;
            string strExt = string.Empty;

            if (!string.IsNullOrWhiteSpace(filename))
            {
                strExt = Path.GetExtension(filename).Trim();

                switch (strExt.ToUpper().Trim())
                {
                    case ".GIF":
                    case ".JPG":
                    case ".JPEG":
                    case ".PNG":
                        validext = true;
                        break;
                    default:
                        validext = false;
                        break;
                }

            }


            if (validext || string.IsNullOrWhiteSpace(filename))
            {
                try
                {
                    UInt32 unMimeType;
                    using (var memory = new MemoryStream())
                    {
                        filestream.Position = 0;
                        filestream.CopyTo(memory);
                        byte[] byteArray = memory.ToArray();


                        FindMimeFromData(0, null, byteArray, 256, null, 0, out unMimeType, 0);

                        IntPtr pMimeType = new IntPtr(unMimeType);
                        string sMimeTypeFromFile = Marshal.PtrToStringUni(pMimeType);

                        Marshal.FreeCoTaskMem(pMimeType);
                        System.Drawing.Imaging.ImageFormat imgformat = System.Drawing.Imaging.ImageFormat.Png;

                        if (byteArray.Take(8).SequenceEqual(new byte[8] { 137, 80, 78, 71, 13, 10, 26, 10 }))
                        {
                            contenttype = "image/png";
                            imgformat = System.Drawing.Imaging.ImageFormat.Png;
                        }
                        else if (byteArray.Take(6).SequenceEqual(new byte[6] { 71, 73, 70, 56, 57, 97 }) ||
                        byteArray.Take(6).SequenceEqual(new byte[6] { 71, 73, 70, 56, 55, 97 }))
                        {
                            contenttype = "image/gif";
                            imgformat = System.Drawing.Imaging.ImageFormat.Gif;
                        }
                        else if (
                            byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 224 }) ||
                        byteArray.Take(4).SequenceEqual(new byte[4] { 255, 216, 255, 225 }))
                        {
                            contenttype = "image/jpeg";
                            imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        }
                        else
                        {
                            return false;
                        }

                        image = System.Drawing.Image.FromStream(memory);
                        // image.Save(memory, imgformat); 
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
                System.UInt32 pBC,
                [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
                [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
                System.UInt32 cbSize,
                [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
                System.UInt32 dwMimeFlags,
                out System.UInt32 ppwzMimeOut,
                System.UInt32 dwReserverd
        );

        #region XML Import/Export/Process

        public static string ProcessModelToXML<T>(T thisModel)
        {
            string result;

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false);
            settings.Indent = false;
            settings.OmitXmlDeclaration = false;

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, thisModel);
                }
                result = textWriter.ToString();
            }
            return result;
        }

        public static T ProcessXMLFromXmlString<T>(T modelFromXML, string xmlText)
        {
            if (!string.IsNullOrWhiteSpace(xmlText))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (TextReader reader = new StringReader(xmlText))
                {
                    modelFromXML = (T)serializer.Deserialize(reader);
                }
            }

            return modelFromXML;
        }

        #endregion

        public static void ExportAsExcel(ref GridView gridView, DataTable dt)
        {

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "JobApplications.xls"));
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            gridView.AllowPaging = false;
            gridView.DataSource = dt;
            gridView.DataBind();
            if (dt.Rows.Count > 0)
            {

                gridView.RenderControl(htw);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }

        }

        /*
        public static bool IsJobExpired(int? expired, int Expired, DateTime expiryDate)
        {
            if ((expired.HasValue && expired.Value == Expired) || expiryDate < DateTime.Now)
            {
                return true;
            }

            return false;
        }*/
        /*
        public static DataTable ConvertToDatatable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }*/
    }

    public enum BootstrapAlertType
    {
        Success,
        Info,
        Warning,
        Danger
    }
}
