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
    }
}