using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace JXTPortal.Website
{   
    public static class CommonPage
    {
        public static int CampaignSequenceNumber = -99999;

        public static string PageName
        {
            get
            {
                string pageCode = string.Empty;

                if (HttpContext.Current.Request.QueryString["code"] != null && !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["code"]))
                {
                    pageCode = HttpContext.Current.Request.QueryString["code"];
                }
                int index = pageCode.IndexOf('?');
                if (index > -1)
                {
                    pageCode = pageCode.Substring(0, index);
                }
                pageCode = pageCode.TrimEnd(new char[] { '/' });
                return pageCode;

            }
        }

        public static bool IsCustomURL
        {
            get
            {
                bool isCustomURL = false;

                if (HttpContext.Current.Request.QueryString["customurl"] != null && HttpContext.Current.Request.QueryString["customurl"] == "1")
                {
                    isCustomURL = true;
                }

                return isCustomURL;

            }
        }

        public static int LanguageID
        {
            get
            {
                int languageID = 1;

                if (HttpContext.Current.Request.QueryString["languageid"] != null && 
                    !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["languageid"]) &&
                    Int32.TryParse(HttpContext.Current.Request.QueryString["languageid"], out languageID))
                {
                    languageID = Convert.ToInt32(HttpContext.Current.Request.QueryString["languageid"]);
                }

                return languageID;

            }
        }


        public static void SetBrowserPageTitle(System.Web.UI.Page page, String strTitle)
        {
            if (!String.IsNullOrEmpty(page.Header.Title))
                page.Header.Title = String.Format(page.Header.Title, strTitle);
            else
                page.Header.Title = strTitle;

            HtmlMeta meta = new HtmlMeta();
            meta.Attributes["property"] = "og:title";
            meta.Content = page.Header.Title.Trim();
            page.Header.Controls.Add(meta);

        }

        public static void SetBrowserPageDescription(System.Web.UI.Page page, String strDescription)
        {
            // Overwrite the description
            page.Header.Description = strDescription;

            HtmlMeta meta = new HtmlMeta();
            meta.Attributes["property"] = "og:description";
            meta.Content = strDescription;
            page.Header.Controls.Add(meta);
        }


        public static void SetBrowserMetaInformation(System.Web.UI.Page page, String strTitle, string strDescription, string strMetaKeywords)
        {
            HtmlMeta meta = new HtmlMeta();
            if (!string.IsNullOrWhiteSpace(strTitle))
            {
                if (!String.IsNullOrEmpty(page.Header.Title))
                    page.Header.Title = String.Format(page.Header.Title, strTitle);
                else
                    page.Header.Title = strTitle;

                meta.Attributes["property"] = "og:title";
                meta.Content = page.Header.Title.Trim();
                page.Header.Controls.Add(meta);
            }

            if (!string.IsNullOrWhiteSpace(strDescription))
            {
                //page.MetaDescription = strDescription;
                page.Header.Description = strDescription;

                meta = new HtmlMeta();
                meta.Attributes["property"] = "og:description";
                meta.Content = strDescription;
                page.Header.Controls.Add(meta);
            }



            if (!string.IsNullOrWhiteSpace(strMetaKeywords))
            {
                //page.MetaKeywords = strMetaKeywords;
                page.Header.Keywords = strMetaKeywords;
            }
        }

        /// <summary>
        ///  Ignore the Local host .. only on live and staging.
        /// </summary>
        public static void IsSSL()
        {
            // Ignore the Local host .. only on live and staging.
            if (JXTPortal.Entities.SessionData.Site.EnableSsl && !HttpContext.Current.Request.IsSecureConnection) // && !HttpContext.Current.Request.IsLocal
            {
                string redirectUrl = "https://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
                HttpContext.Current.Response.Redirect(redirectUrl, false);
                //HttpContext.ApplicationInstance.CompleteRequest();
            }
        }

    }
}
