using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Entities;
using System.Web.Caching;
using System.Web;
using System.IO;
using System.Xml;
using System.Configuration;

namespace JXTPortal
{
    public static class ApplicationService
    {
        public static void JobArchive()
        {
            if (!ApplicationData.JobArchiveCache)
            {
                JobsService jobsService = new JobsService();
                jobsService.JobsPurge();
                jobsService = null;
                
                ApplicationData.JobArchiveCache = true;
            }
        }

        public static XmlDocument GetXMLCache(string fileName)
        { 
           XmlDocument xmldoc = new XmlDocument();
           
            string cacheName = fileName.Replace(ConfigurationManager.AppSettings["XMLFilesPath"], "");
           if (HttpContext.Current.Cache[cacheName] == null)
            {
                if (File.Exists(fileName))
                {
                    xmldoc.Load(fileName);
                }
                HttpContext.Current.Cache.Insert(cacheName, xmldoc, new System.Web.Caching.CacheDependency(fileName));
            }
            else
            {
                xmldoc = (XmlDocument)HttpContext.Current.Cache[cacheName];
            }

            return xmldoc;
        }
    }
}
