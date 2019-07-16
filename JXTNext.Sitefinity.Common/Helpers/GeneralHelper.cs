using System;
using System.Linq;
using System.Text.RegularExpressions;


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

        /// <summary>
        /// Convert a string to it's slug form.
        /// This may require review.
        /// see - https://gist.github.com/joancaron/8436664
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UrlSlug(string value)
        {
            var slug = value;

            // first to lower case 
            slug = slug.ToLowerInvariant();

            // replace spaces, slashes
            slug = Regex.Replace(slug, @"[\s\/&]", "-", RegexOptions.Compiled);

            // remove invalid chars 
            slug = Regex.Replace(slug, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

            // trim dashes from end 
            slug = slug.Trim('-', '_');

            // replace double occurences of - or \_ 
            slug = Regex.Replace(slug, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            // just a fallback; return the text as it is
            if (string.IsNullOrWhiteSpace(slug))
            {
                slug = value.Replace('/', '-');
            }

            return slug;
        }
    }
}