using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Text;

namespace JXTPortal.Website.widgets
{
    public partial class WidgetSiteSearch : System.Web.UI.Page
    {
        #region Properties

        private const string _KEYWORDS = "{Keywords}";
        private const string _LANGUAGES = "{Languages}";

        Entities.WidgetContainers widgetContainer = null;

        public String strHTML = String.Empty;

        private int WidgetID
        {
            get
            {
                int _WidgetID = 0;

                if (Request.QueryString["WidgetID"] != null && Int32.TryParse(Request.QueryString["WidgetID"], out _WidgetID))
                {
                    _WidgetID = Convert.ToInt32(Request.QueryString["WidgetID"]);
                }

                return _WidgetID;
            }
        }

        private WidgetContainersService _widgetContainersService;
        private WidgetContainersService WidgetContainersService
        {
            get
            {
                if (_widgetContainersService == null) _widgetContainersService = new WidgetContainersService();
                return _widgetContainersService;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSearch();

                // Set the Control contents
                SetKeywords();
                SetLanguages();

                // Replaced html contents
                ltlSearch.Text = strHTML; 
            }

        }

        protected void LoadSearch()
        {

            if (WidgetID > 0)
            {

                using (widgetContainer = WidgetContainersService.GetByWidgetId(WidgetID))
                {
                    if (widgetContainer != null && widgetContainer.SiteId == SessionData.Site.SiteId)
                    {
                        strHTML = widgetContainer.SiteHtml;

                        #region Javascript and CSS

                        if (!String.IsNullOrEmpty(widgetContainer.Javascript))
                        {
                            ltlJavascript.Text = String.Format(@"

{0}

", widgetContainer.Javascript);
                        }

                        if (!String.IsNullOrEmpty(widgetContainer.SearchCss))
                        {
                            ltlCSS.Text = String.Format(@"

{0}

", widgetContainer.SearchCss);
                        }

                        #endregion
                    }
                }
            }
        }

        #region Load Content

        protected void SetKeywords()
        {
            if (FindKeyword(_KEYWORDS))
            {
                strHTML = strHTML.Replace(_KEYWORDS, string.Format(@"<input id='keywords' type='text' class='form-textbox' placeholder='{0}' />", CommonFunction.GetResourceValue("LabelSearchTheSite")));
            }
        }

        protected void SetLanguages()
        {
            if (FindKeyword(_LANGUAGES))
            {
                strHTML = strHTML.Replace(_LANGUAGES, GetLanguages());
            }
        }

        #endregion


        private string GetLanguages()
        {
            StringBuilder strBuilder = new StringBuilder();

            SiteLanguagesService languageService = new SiteLanguagesService();
            using (TList<SiteLanguages> languages = languageService.GetBySiteId(SessionData.Site.SiteId))
            {
                strBuilder.Append("<select name='language' id='language'>");
                foreach (SiteLanguages language in languages)
                {
                    strBuilder.Append(String.Format("<option value='{0}'{2}>{1}</option>", language.LanguageId, language.SiteLanguageName, SessionData.Language.LanguageId == language.LanguageId ? "selected=selected" : ""));

                }
                strBuilder.Append("</select>");
            }
            
            return strBuilder.ToString();
        }


        private Boolean FindKeyword(String strKeyword)
        {
            if (strHTML.IndexOf(strKeyword) > 0)
                return true;

            return false;
        }
    }
}
