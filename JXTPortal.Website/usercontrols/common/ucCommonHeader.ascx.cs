using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Text;
using System.ComponentModel;

namespace JXTPortal.Website.usercontrols.common
{
    public partial class ucCommonHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LanguageLinksSet();

        }


        private void LanguageLinksSet()
        {
            //Language available for this site
            List<SiteLanguages> siteLanguages;
            {
                SiteLanguagesService _sl = new SiteLanguagesService();
                siteLanguages = _sl.GetBySiteId(SessionData.Site.SiteId).ToList();
                _sl = null; //manaul dump
            } //this should GC
            List<PortalEnums.Languages.URLLanguage> languages = (from lang in siteLanguages select (PortalEnums.Languages.URLLanguage)lang.LanguageId).Distinct().ToList();

            //only add the hreflang if this is a multilingual site
            if (languages.Count() > 1)
            {
                //steal the site's default language from user session other than calling DB
                PortalEnums.Languages.URLLanguage siteDefaultLanguage = (PortalEnums.Languages.URLLanguage)SessionData.Site.DefaultLanguageId;

                StringBuilder sb = new StringBuilder();
                sb.Append("\n\n<!-- Language Links -->\n");

                string processedURL = RequestURLHasLanguageSpecifier() ? ReconstructURLForLanguageRoutes() : HttpContext.Current.Request.RawUrl;

                foreach (PortalEnums.Languages.URLLanguage l in languages)
                {
                    string urlCode = CommonFunction.GetEnumDescription(l);

                    string rawURL;
                    if (siteDefaultLanguage == l)
                    {
                        rawURL = string.Format("{0}://{1}{2}",
                                        HttpContext.Current.Request.Url.Scheme,
                                        HttpContext.Current.Request.Url.Host,
                                        processedURL
                                        );
                    }
                    else
                    {
                        rawURL = string.Format("{0}://{1}/{3}{2}",
                                                            HttpContext.Current.Request.Url.Scheme,
                                                            HttpContext.Current.Request.Url.Host,
                                                            processedURL,
                                                            urlCode
                                                            );
                    }
                    sb.Append("<link rel='alternate' href='" + rawURL + "' hreflang='" + l.ToString().Replace('_', '-') + "' />\n");
                }

                ltlLanguageLinks.Text = sb.ToString();
            }
        }


        private bool RequestURLHasLanguageSpecifier()
        {
            bool hasLanguageSpecifier = false;
            foreach (PortalEnums.Languages.URLLanguage lang in Enum.GetValues(typeof(PortalEnums.Languages.URLLanguage)))
            {
                //use the description attribute value
                string thisLang = CommonFunction.GetEnumDescriptionWithoutGetResourceValue(lang);

                if (Request.RawUrl.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToUpper()).Contains(thisLang.ToString().ToUpper()))
                {
                    hasLanguageSpecifier = true;
                    break;
                }
            }
            return hasLanguageSpecifier;
        }

        private string ReconstructURLForLanguageRoutes()
        {
            //reconstruct the destination request
            List<string> newRoutesList = Request.RawUrl.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            newRoutesList.RemoveAt(0); //remove "EN/"

            string newRoute = "/" + String.Join("/", newRoutesList);
            return newRoute;
        }

    }
}