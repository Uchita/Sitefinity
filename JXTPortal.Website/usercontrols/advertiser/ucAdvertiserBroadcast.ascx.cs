using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.advertiser
{
    
    public partial class ucAdvertiserBroadcast : System.Web.UI.UserControl
    {
        private GlobalSettingsService _GlobalSettingsService;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_GlobalSettingsService == null)
                    _GlobalSettingsService = new GlobalSettingsService();
                return _GlobalSettingsService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucJobsCurrent1.IsBroadcast = true;
            ucJobsPending1.IsBroadcast = true;
            ucJobsDeclined1.IsBroadcast = true;

            // Show pending jobs when job screening process is enabled
            using (TList<Entities.GlobalSettings> globalsettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (globalsettings.Count > 0)
                {
                    Entities.GlobalSettings globalsetting = globalsettings[0];
                    ucJobsPending1.Visible = (globalsetting.JobScreeningProcess.HasValue) ? globalsetting.JobScreeningProcess.Value : false;
                    ucJobsDeclined1.Visible = (globalsetting.JobScreeningProcess.HasValue) ? globalsetting.JobScreeningProcess.Value : false;
                }
            }
        }
    }
}