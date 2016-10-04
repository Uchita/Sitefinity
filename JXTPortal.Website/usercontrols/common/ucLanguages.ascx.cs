using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.common
{
    public partial class ucLanguages : System.Web.UI.UserControl
    {
        #region Properties

        private SiteLanguagesService _siteLanguagesService = null;

        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_siteLanguagesService == null)
                {
                    _siteLanguagesService = new SiteLanguagesService();
                }
                return _siteLanguagesService;
            }
        }

        private LanguagesService _languagesService = null;

        private LanguagesService LanguagesService
        {
            get
            {
                if (_languagesService == null)
                {
                    _languagesService = new LanguagesService();
                }
                return _languagesService;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Methods

        /*
        protected void SetLanguages()
        {
            if (SessionData.Language != null && SessionData.Language.LanguageId > 0 && ddlLanguages.SelectedItem != null)
            {
                int intLanguageID = int.Parse(ddlLanguages.SelectedValue);

                if (! intLanguageID.Equals(SessionData.Language.LanguageId))
                {
                    SessionData.Language.LanguageId = intLanguageID;
                    Entities.SiteLanguages sl = SiteLanguagesService.GetBySiteIdLanguageId(SessionData.Site.SiteId, intLanguageID);
                    if (sl != null)
                    {
                        SessionData.Language.LanguageName = sl.SiteLanguageName;
                    }

                    // Redirect to the same page
                    if (Request.UrlReferrer != null && !String.IsNullOrEmpty(Request.UrlReferrer.AbsolutePath))
                    {
                        Response.Redirect(Request.UrlReferrer.PathAndQuery);
                    }
                }
            }



        }*/

        public void GetLanguages()
        {
            // Change the language which comes from session.
            using (TList<Entities.SiteLanguages> siteLanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (siteLanguages.Count > 1)
                {

                    ddlLanguages.DataSource = siteLanguages;
                    ddlLanguages.DataTextField = "SiteLanguageName";
                    ddlLanguages.DataValueField = "LanguageID";
                    ddlLanguages.DataBind();

                    ddlLanguages.SelectedValue = SessionData.Site.DefaultLanguageId.ToString();
                    /*
                    rptLanguages.DataSource = siteLanguages;
                    rptLanguages.DataBind();
                    */

                }
                else
                {
                    ddlLanguages.Visible = false;
                }
            }

        }

        #endregion
        /*
        #region Click Events

        protected void rptLanguages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SelectLanguage")
            {
                int intLanguageID = int.Parse(e.CommandArgument.ToString());

                SessionData.Language.LanguageId = intLanguageID;
                Entities.SiteLanguages sl = SiteLanguagesService.GetBySiteIdLanguageId(SessionData.Site.SiteId, intLanguageID);
                if (sl != null)
                {
                    SessionData.Language.LanguageName = sl.SiteLanguageName;
                }
                

                // Redirect to the same page
                if (Request.UrlReferrer != null && !String.IsNullOrEmpty(Request.UrlReferrer.AbsolutePath))
                {
                    Response.Redirect(Request.UrlReferrer.PathAndQuery);
                }
            }
        }

        #endregion

        */


        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {

            int intLanguageID = int.Parse(ddlLanguages.SelectedValue);

            Entities.Languages lang = LanguagesService.GetByLanguageId(intLanguageID);
            if (lang != null)
            {
                SessionData.Language = lang;
            }

            // Redirect to the same page
            if (Request.UrlReferrer != null && !String.IsNullOrEmpty(Request.UrlReferrer.AbsolutePath))
            {
                //construct the new redirect url
                //This will simply convert the current url /en/page/example -> /{target language code}/page/example
                string urlToRedirect = ConstructNewRedirectURLWithLanguageSpecifier((PortalEnums.Languages.URLLanguage)intLanguageID);

                Response.Redirect(urlToRedirect);

                //Response.Redirect(Request.Url.OriginalString);

                /*
                if (Request.UrlReferrer.ToString().Contains("?"))
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    Response.Redirect(Request.UrlReferrer.AbsolutePath);
                }*/
            }
        }

        private string ConstructNewRedirectURLWithLanguageSpecifier(PortalEnums.Languages.URLLanguage targetLang)
        {
            string[] rawURLSegments = Request.RawUrl.Split(new string[]{ "/" }, StringSplitOptions.RemoveEmptyEntries);
                    
            string newRedirectURLRoute = Request.RawUrl;
            foreach (PortalEnums.Languages.URLLanguage lang in Enum.GetValues(typeof(PortalEnums.Languages.URLLanguage)))
            {
                string thisLang = CommonFunction.GetEnumDescriptionWithoutGetResourceValue(lang);

                if (rawURLSegments.Select(c => c.ToUpper()).Contains(thisLang.ToUpper()))
                {
                    //replace the language url to the target using the description attribute value
                    string targetLangStr = CommonFunction.GetEnumDescriptionWithoutGetResourceValue(targetLang);
                    rawURLSegments[0] = targetLangStr;
                    newRedirectURLRoute = "/" + String.Join("/", rawURLSegments);
                    break;
                }
            }
#if DEBUG
            return Request.Url.GetLeftPart(UriPartial.Scheme) + Request.Url.Authority + newRedirectURLRoute;
#endif

            return Request.Url.GetLeftPart(UriPartial.Scheme) + Request.Url.Host + newRedirectURLRoute;
        }

        protected void ddlLanguages_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetLanguages();

                CommonFunction.SetDropDownByValue(ddlLanguages, SessionData.Language.LanguageId.ToString());
            }
        }

        protected void ddlLanguages_DataBound(object sender, EventArgs e)
        {
            if (ddlLanguages.Items.Count > 0)
            {
                foreach (ListItem li in ddlLanguages.Items)
                {
                    li.Attributes.Add("id", "language_" + li.Value);
                }
            }
        }
    }
}