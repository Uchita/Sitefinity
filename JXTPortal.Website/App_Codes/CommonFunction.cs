using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;
using System.Configuration;
using System.Text.RegularExpressions;
using JXTPortal.Entities;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using JXTPortal.Entities.Custom;

namespace JXTPortal.Website
{
    public static class CommonFunction
    {
        // ToDO: Move this methods to JXTPortal.Common
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

        public static byte[] Compress(byte[] input)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (ICSharpCode.SharpZipLib.Zip.Compression.Streams.DeflaterOutputStream stream =
                            new ICSharpCode.SharpZipLib.Zip.Compression.Streams.DeflaterOutputStream(memory, new Deflater(Deflater.BEST_COMPRESSION), 131072))
                {
                    stream.Write(input, 0, input.Length);
                    stream.Flush();
                    stream.Close();
                }

                return memory.ToArray();
            }
        }

        public static byte[] Decompress(byte[] Bytes)
        {
            MemoryStream memory = new MemoryStream();

            using (ICSharpCode.SharpZipLib.Zip.Compression.Streams.InflaterInputStream stream =
                new ICSharpCode.SharpZipLib.Zip.Compression.Streams.InflaterInputStream(new MemoryStream(Bytes)))
            {
                byte[] writeData = new byte[4096];
                int size;

                while (true)
                {
                    size = stream.Read(writeData, 0, writeData.Length);
                    if (size > 0)
                    {
                        memory.Write(writeData, 0, size);
                    }
                    else break;
                }
                // stream.Close();
            }
            return memory.ToArray();
        }

        public static bool VerifyEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                string strRegex = ConfigurationManager.AppSettings["EmailValidationRegex"];
                Regex re = new Regex(strRegex);

                return re.IsMatch(email);
            }

            return false;
        }

        public static bool CheckExtension(string filename)
        {
            bool found = false;
            string extList = ConfigurationManager.AppSettings["ApplicationFileTypes"];
            string[] exts = extList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ext in exts)
            {
                if (filename.ToLower().EndsWith(ext))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        /*
        public static string UrlFriendlyName(string url)
        {
            url = url.Replace("/", "").Replace("+", "plus").Replace(" ", "").Replace("&", "and").Replace(":", "").Replace(";", "").Replace("\\", "").Replace(",", "").Replace("(", "-").Replace(")", "-").Replace("'", "-").Replace("'", "").Replace("-", "-").Replace(".", "-").Replace("!", "-").Replace("?", "-").Replace(">", "-");
            url = url.ToLower();
            return url;
        }
        */

        public static bool CompareLists(List<int> listA, List<int> listB)
        {
            if (listA.Count != listB.Count) return false;

            for (int i = 0; i < listA.Count; i++)
            {
                if (listA[i] == listB[i])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }


        public static String GetResourceValue(String field)
        {
            String strGlobalResource = string.Empty;

            if (SessionData.Language != null)
            {
                object ResourceFileObj = null;

                //try get from specified resource file
                string customResourceFileName = SessionData.Site.ResourceFileNameMappingGet(SessionData.Language.LanguageId);
                if (!string.IsNullOrEmpty(customResourceFileName))
                {
                    //this won't throw exception as I am not casting the object to anything
                    ResourceFileObj = HttpContext.GetGlobalResourceObject(customResourceFileName, field);
                }

                //try get default resource file
                if(ResourceFileObj == null)
                {
                    String language = "language_" + SessionData.Language.LanguageId.ToString();

                    //same here no exception catched needed
                    ResourceFileObj = HttpContext.GetGlobalResourceObject(language, field);
                }

                if (ResourceFileObj != null)
                {
                    try
                    {
                        strGlobalResource = (String)ResourceFileObj;
                    }
                    catch
                    {
                        //strGlobalResource = "Could not find global resource.";
                    }
                }
                else
                    strGlobalResource = field;
            }

            return strGlobalResource;
        }


        public static string[] GetTranslatedValuesForArray(string[] str)
        {
            string[] strNewValues = new string[str.Length];

            for (int i = 0; i < strNewValues.Length; i++)
            {
                strNewValues[i] = CommonFunction.GetResourceValue(str[i]);
            }

            return strNewValues;
        }

        public static string GetListBoxByValue(System.Web.UI.WebControls.ListBox lstBox)
        {
            string values = string.Empty;

            foreach (System.Web.UI.WebControls.ListItem listItem in lstBox.Items)
            {
                if (listItem.Selected)
                {
                    if (String.IsNullOrEmpty(values))
                        values = listItem.Value;
                    else
                        values = values + "," + listItem.Value;
                }
            }
            return values;
        }

        public static void SetListBoxByValue(System.Web.UI.WebControls.ListBox lstBox, String value)
        {
            lstBox.ClearSelection();
            if (!String.IsNullOrEmpty(value.Trim()))
            {
                System.Web.UI.WebControls.ListItem item = null;
                string[] strValues = value.Trim().Split(',');
                foreach (string strValue in strValues)
                {
                    if (!strValue.Equals("0"))
                    {
                        item = lstBox.Items.FindByValue(strValue);
                        if (item != null)
                        {
                            lstBox.Items.FindByValue(strValue).Selected = true;
                        }
                    }
                }
            }
        }

        public static void SetDropDownByValue(System.Web.UI.WebControls.DropDownList ddlDropDown, String value)
        {
            ddlDropDown.ClearSelection();
            if (!String.IsNullOrEmpty(value.Trim()))
            {
                System.Web.UI.WebControls.ListItem item = ddlDropDown.Items.FindByValue(value);
                if (item != null)
                {
                    ddlDropDown.Items.FindByValue(value).Selected = true;
                }
            }
        }

        public static void SetDropDownByText(System.Web.UI.WebControls.DropDownList ddlDropDown, String value)
        {
            ddlDropDown.ClearSelection();
            if (!String.IsNullOrEmpty(value.Trim()))
            {
                System.Web.UI.WebControls.ListItem item = ddlDropDown.Items.FindByText(value);
                if (item != null)
                {
                    ddlDropDown.Items.FindByText(value).Selected = true;
                }
            }
        }

        public static string GetString(String strRequest)
        {
            string pageCode = string.Empty;

            if (HttpContext.Current.Request.QueryString[strRequest] != null && !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[strRequest]))
            {
                pageCode = HttpContext.Current.Request.QueryString[strRequest];
            }

            return pageCode;
        }

        /// <summary>
        /// Get Int from String else Return Null
        /// </summary>
        /// <param name="strString"></param>
        /// <returns></returns>
        public static int? GetInt(String strString)
        {
            if (!String.IsNullOrEmpty(strString))
            {
                int i;

                if (int.TryParse(strString, out i))
                {
                    return i;
                }
            }

            return null;
        }

        public static decimal? GetDecimal(String strString)
        {
            if (!String.IsNullOrEmpty(strString))
            {
                decimal i;

                if (decimal.TryParse(strString, out i))
                {
                    return i;
                }
            }

            return null;
        }

        public static int? GetSalaryCurrencyID(String strString)
        {
            int? currencyId = null;
            int currency = 0;
            if (!string.IsNullOrEmpty(strString))
            {
                string[] result = strString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (int.TryParse(result[0], out currency))
                {
                    currencyId = currency;
                }
            }

            return currencyId;
        }

        public static decimal? GetSalaryAmount(String strString)
        {
            decimal? amount = null;
            decimal temp = 0;

            if (!string.IsNullOrEmpty(strString))
            {
                string[] result = strString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (result.Length > 1)
                {
                    if (Decimal.TryParse(result[1], out temp))
                    {
                        amount = (decimal)temp;
                    }
                }
            }

            return amount;
        }


        public static decimal? GetSalaryDecimalAmount(String strString)
        {
            decimal? amount = null;
            decimal temp = 0;

            if (!string.IsNullOrEmpty(strString))
            {
                if (Decimal.TryParse(strString, out temp))
                {
                    amount = (decimal)temp;
                }
            }

            return amount;
        }

        #region Enum Functions

        public static string GetEnumDescription(Enum currentEnum)
        {
            string description = String.Empty;
            DescriptionAttribute da;

            FieldInfo fi = currentEnum.GetType().
                        GetField(currentEnum.ToString());
            da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            if (da != null)
                description = da.Description;
            else
                description = currentEnum.ToString();

            return GetResourceValue(description);
        }

        //This function returns the actual description of the enum without passing through to the GetResouceValue in the resources
        public static string GetEnumDescriptionWithoutGetResourceValue(Enum currentEnum)
        {
            string description = String.Empty;
            DescriptionAttribute da;

            FieldInfo fi = currentEnum.GetType().
                        GetField(currentEnum.ToString());
            da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            if (da != null)
                description = da.Description;
            else
                description = currentEnum.ToString();

            return description;
        }


        public static Dictionary<string, int> GetEnumFormattedNames<TEnum>()
        {
            return GetEnumFormattedNames<TEnum>(false);
        }

        public static Dictionary<string, int> GetEnumFormattedNames<TEnum>(bool orderBySequenceAttribute)
        {
            var enumType = typeof(TEnum);
            if (enumType == typeof(Enum))
                throw new ArgumentException("typeof(TEnum) == System.Enum", "TEnum");

            if (!(enumType.IsEnum))
                throw new ArgumentException(String.Format("typeof({0}).IsEnum == false", enumType), "TEnum");

            //List<string> formattedNames = new List<string>();
            var list = Enum.GetValues(enumType).OfType<TEnum>().ToList<TEnum>();
            var listNames = Enum.GetNames(enumType);

            //get all details including sequence
            List<Tuple<string, int, int>> tEnumValues = new List<Tuple<string, int, int>>();
            for (int i = 0; i < list.Count; i++)
            {
                FieldInfo fi = list[i].GetType().GetField(list[i].ToString());
                SequenceAttribute sa = (SequenceAttribute)Attribute.GetCustomAttribute(fi, typeof(SequenceAttribute));

                tEnumValues.Add(new Tuple<string,int,int>(GetEnumDescription(list[i] as Enum), (int)Enum.Parse(enumType, listNames[i]), sa == null ? 0 : sa.SequenceNumber));
            }

            //place it back to varieable
            Dictionary<string, int> dicFormattedValues = new Dictionary<string, int>();
            foreach(Tuple<string,int,int> enumDetail in tEnumValues.OrderBy(c => c.Item3).ToList())
            {
                dicFormattedValues.Add(enumDetail.Item1, enumDetail.Item2);
            }

            /*
        foreach (TEnum item in list)
        {
            formattedNames.Add(GetEnumDescription(item as Enum));
        }

            
            foreach (var item in Enum.GetNames(enumType))
            {
                dicFormattedValues.Add(GetEnumDescription(((TEnum)item) as Enum), (int)Enum.Parse(enumType, item));
            }
            */
            return dicFormattedValues;
        }

        #endregion


    }
}
