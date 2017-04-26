using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;


namespace JXTPortal.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidContent(this string text, bool acceptNewLine = false)
        {
            string ContentValidationRegex = ConfigurationManager.AppSettings["ContentValidationRegex"];
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }

            if (!acceptNewLine)
            {
                return Regex.IsMatch(text, ContentValidationRegex);
            }
            else
            {
                var newline = "\n";
                return Regex.IsMatch(text.Replace(newline, ""), ContentValidationRegex);
            }
        }
    }
}
