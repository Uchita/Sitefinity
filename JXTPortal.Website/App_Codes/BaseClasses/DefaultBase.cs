using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPortal.Entities;
using JXTPortal.Website.usercontrols.common;
using System.Web.UI.WebControls;

namespace JXTPortal.Website
{
    public class DefaultBase : System.Web.UI.Page
    {


        public void LoginCheck<T>(string urlReturn, T token)
        {
            if (token == null
                    && this.GetCurrentPageName().ToLower() != "login.aspx")
            {
                Response.Redirect(urlReturn + "?ReturnURL=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));
            }
            else if (token != null && token is AdminUsers)
            {
                //ToDo: get the page name Fransiscus
            }
        }

        public string GetCurrentPageName()
        {
            return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);
        }

        /*
        public void LoadPageContent(ucHeader ucHeader, ucFooter ucFooter,
                                Literal ltlLeftNavigation, Literal ltlRightNavigation,
                                Literal ltlAboveHeader, Literal ltlBelowFooter,
                                Literal ltlMetaContent, Literal ltlDocType, Literal ltlCSSAndScripts, System.Web.UI.Page page, String strPageTitle)
        {

            using (PageBase pageBase = new PageBase())
            {
                // Get the Header, Footer, Meta Content, CSS/ Scripts
                pageBase.LoadPageContent(ucHeader, ucFooter, ltlLeftNavigation, ltlRightNavigation, ltlAboveHeader, ltlBelowFooter, ltlMetaContent, ltlDocType, ltlCSSAndScripts, page, strPageTitle);
            }

        }*/

        public void SetMetaContentWithFavIcon(Literal ltlMetaContent, Literal ltlDocType, System.Web.UI.Page page, String strPageTitle,
                                                String strMetaDescription, String strMetaKeywords, Boolean blnHomepage, Boolean blnPage)
        {
            using (PageBase pageBase = new PageBase())
            {
                // Get the Header, Footer, Meta Content, CSS/ Scripts
                pageBase.SetMetaContentWithFavIcon(ltlMetaContent, ltlDocType, page, 
                                                        strPageTitle,strMetaDescription, strMetaKeywords, blnHomepage, blnPage);
            }
        }


    }
}
