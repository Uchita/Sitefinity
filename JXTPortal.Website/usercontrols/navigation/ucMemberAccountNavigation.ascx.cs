using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.navigation
{
    public partial class ucMemberAccountNavigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GlobalSettingsService GlobalSettingsService = new GlobalSettingsService();
                JobApplicationTypeService JobApplicationTypeService = new JobApplicationTypeService();
                using (TList<JXTPortal.Entities.GlobalSettings> globalSetting = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                {
                    if (globalSetting.Count > 0)
                    {
                        if (globalSetting[0].JobApplicationTypeId.HasValue)
                        {
                            phDraftJobs.Visible = true;

                        }
                    }
                }
            }
        }
    }
}