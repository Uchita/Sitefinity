using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Web;
using System.Xml;
using System.Configuration;

namespace JXTPortal.Entities
{
    public static class ApplicationData
    {
        private const int CacheExpiryInMinutes = 1;

        public static bool JobArchiveCache 
        {
            get { 
                bool isArchived = true;
                if (HttpContext.Current.Cache["JobArchived"] == null)
                    isArchived = false;
                else
                    isArchived = (bool)HttpContext.Current.Cache["JobArchived"];
                return isArchived;
            }
            set 
            {
                HttpContext.Current.Cache.Insert("JobArchived", value, null, DateTime.Now.AddMinutes(CacheExpiryInMinutes), TimeSpan.Zero);
            }
        }
    }
}
