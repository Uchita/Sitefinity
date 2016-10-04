using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.common
{
    public partial class ucSystemDynamicPage : System.Web.UI.UserControl
    {

        #region Properties

        private DynamicPagesService _dynamicPagesService = null;

        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
            }
        }

        public string SetSystemPageCode
        {
            set
            {
                ltlSystemPage.Text = GetContent(value);
            }
        }

        public string Text
        {
            get
            {
                return ltlSystemPage.Text;
            }
            set
            {
                ltlSystemPage.Text = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetContent(string strPageCode)
        {
            if (!String.IsNullOrEmpty(strPageCode) && SessionData.Site != null && SessionData.Language != null)
            {
                // Change the language which comes from session.
                using (JXTPortal.Entities.DynamicPages dynamicPage = DynamicPagesService.GetBySiteIdPageNameLanguageId(SessionData.Site.SiteId, strPageCode, SessionData.Language.LanguageId))
                {
                    if (dynamicPage != null)
                    {
                        return dynamicPage.PageContent;
                    }
                }

                // If System page not found Get content from the Master WL.
                using (JXTPortal.Entities.DynamicPages dynamicPage = DynamicPagesService.GetBySiteIdPageNameLanguageId(JXTPortal.Common.Utils.GetAppSettingsInt("MasterSiteID"), strPageCode, SessionData.Language.LanguageId))
                {
                    if (dynamicPage != null)
                    {
                        return dynamicPage.PageContent;
                    }
                }
            }

            return string.Empty;
        }
    }
}