using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.MasterPages
{
    public partial class DynamicPage : PageBase
    {
        #region Properties

        private GlobalSettingsService _globalSettingsService = null;

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                {
                    _globalSettingsService = new GlobalSettingsService();
                }
                return _globalSettingsService;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Entities.GlobalSettings globalSettings = GlobalSettingsService.GetGlobalSettingBySiteID(SessionData.Site.SiteId);
            if (globalSettings != null)
            {
                if (String.IsNullOrEmpty(globalSettings.SiteDocType) && String.IsNullOrEmpty(ltlDocType.Text))
                    ltlDocType.Text = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";
                else
                    ltlDocType.Text = globalSettings.SiteDocType;
            }
        }
    }
}
