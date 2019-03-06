using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JXTNext.Sitefinity.Common.Extensions
{
   public static class Extensions
    {

        /// <summary>
        ///  Get the Domain name from the URL
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>Returns domain name as a string</returns>
        public static string GetCurrentDomain(this HttpContextBase httpContext)
        {
            return httpContext.Request.Url.Host.ToLower().Replace("www.", string.Empty);
        }
    }
}
