using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace JXTNext.Sitefinity.Common.Helpers
{
    public class GeneralHelper
    {
        public static string TrimStringContent(string content, int len)
        {
            string trimSummary = !String.IsNullOrWhiteSpace(content) && content.Length >= len ? content.Substring(0, len) + "..." : content;
            return trimSummary;
        }

        public static string RemoveInlineStyling(string content)
        {
            string resString = Regex.Replace(content, @"<([^>]*)(\sstyle="".+?""(\s|))(.*?)>", "<$1$3>");
            return resString;
        }

        public static string GeneratePassword(int passwordLength)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz@#$&ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, passwordLength)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        

        public static string GetCurrentDomain(HttpContextBase httpContext)
        {
            return httpContext.Request.Url.Host.ToLower().Replace("www.", string.Empty);
        }
    }
}