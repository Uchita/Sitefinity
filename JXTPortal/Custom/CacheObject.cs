using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Web;
using JXTPortal.Entities;

namespace JXTPortal
{
    public class CacheObject
    {
        public const string CACHE_301_REDIRECTS_KEY = "301_Redirects";

        public static int GET_REDIRECT_CACHE_TIME
        {
            get
            {
                return int.Parse(System.Configuration.ConfigurationManager.AppSettings["301RedirectCacheTime"]);
            }
        }

        public static string GET_REDIRECT_PATH
        {
            get
            {
                if (SessionData.Site != null)
                    return System.Configuration.ConfigurationManager.AppSettings["301RedirectUrlFolder"] + "Site.xml";

                return string.Empty;
            }
        }

        public void SetCacheRedirects()
        {
            CacheRedirectXML CacheRedirectXML = new CacheRedirectXML();
            CacheRedirectXML.blnRefresh = false;

            if (!string.IsNullOrWhiteSpace(GET_REDIRECT_PATH) && File.Exists(GET_REDIRECT_PATH))
            {

                string XML = File.ReadAllText(GET_REDIRECT_PATH);

                var serializer = new XmlSerializer(typeof(RedirectRoot));
                using (var reader = new StringReader(XML))
                {
                    try
                    {
                        RedirectRoot redirectRoot = (RedirectRoot)serializer.Deserialize(reader);
                        if (redirectRoot != null && redirectRoot.redirections != null && redirectRoot.redirections.Count() > 0)
                        {
                            CacheRedirectXML.blnRefresh = true;
                            CacheRedirectXML.redirection = redirectRoot.redirections;
                        }
                    }
                    catch (Exception ex)
                    {
                        //throw ex;           // TODO
                    } // Could not be deserialized to this type.
                }
            }
            
            HttpContext.Current.Cache.Remove(CACHE_301_REDIRECTS_KEY);

            HttpContext.Current.Cache.Insert(CACHE_301_REDIRECTS_KEY, CacheRedirectXML, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(GET_REDIRECT_CACHE_TIME));
        }


        public redirection[] GetCacheRedirects()
        {
            CacheRedirectXML redirectRoot = (CacheRedirectXML)HttpContext.Current.Cache[CACHE_301_REDIRECTS_KEY];

            if (redirectRoot != null && redirectRoot.redirection != null && redirectRoot.redirection.Count() > 0)
                return redirectRoot.redirection;

            // Refresh from the file.
            SetCacheRedirects();

            redirectRoot = (CacheRedirectXML)HttpContext.Current.Cache[CACHE_301_REDIRECTS_KEY];

            if (redirectRoot != null && redirectRoot.redirection != null && redirectRoot.redirection.Count() > 0)
                return redirectRoot.redirection;


            return null;
        }

        public string FindCacheRedirect(string fromUrl)
        {
            if (!string.IsNullOrWhiteSpace(fromUrl))
            {
                fromUrl = fromUrl.ToLower();
                redirection[] redirectList = GetCacheRedirects();

                if (redirectList != null)
                {
                    redirection r = redirectList.Where(s => s.from.ToLower() == fromUrl).FirstOrDefault();

                    if (r != null)
                        return r.to;
                }
            }

            return string.Empty;

        }


    }


    public class CacheRedirectXML
    {
        public bool blnRefresh { get; set; }

        public redirection[] redirection { get; set; }

    }

    #region XML Serialized Class

    [XmlRoot("root"), XmlType("root")]
    public class RedirectRoot
    {
        public redirection[] redirections { get; set; }
    }

    //[XmlType("redirection")]
    public class redirection
    {
        [XmlElement("from")]
        public string from { get; set; }

        [XmlElement("to")]
        public string to { get; set; }
    }

    #endregion

}
