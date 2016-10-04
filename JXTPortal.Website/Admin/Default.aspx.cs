using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Collections.Generic;


public partial class Admin_Default : System.Web.UI.Page
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
        using (TList<GlobalSettings> globalsettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
        {
            if (globalsettings.Count > 0)
            {
                GlobalSettings globalsetting = globalsettings[0];

                if (globalsetting.JobScreeningProcess.HasValue && globalsetting.JobScreeningProcess.Value == true)
                {
                    ucJobsPending1.Visible = globalsetting.JobScreeningProcess.Value;
                }
                else
                    ucJobsPending1.Visible = false;
            }
        }

        Panel tableFooter = ucJobsPending1.FindControl("tableFooter") as Panel;
        tableFooter.Visible = false;
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        //dynamic pages        
        if (SessionData.AdminUser != null)
        {
            PortalEnums.Admin.AdminRole currentRole = (PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId;
            if (currentRole == PortalEnums.Admin.AdminRole.Administrator
                || currentRole == PortalEnums.Admin.AdminRole.ContentEditor
                //|| currentRole == PortalEnums.Admin.AdminRole.SuperAdministrator
                || currentRole == PortalEnums.Admin.AdminRole.Contributor)
            {
                //only Pending list will be visible

                ucDynamicPageStatusListing1.Visible = true;

                //hide drafts always
                Panel draftList = ucDynamicPageStatusListing1.FindControl("DraftPanel") as Panel;
                draftList.Visible = false;

                //only show pending if there are pending pages
                Repeater pendingList = ucDynamicPageStatusListing1.FindControl("rptPendingsList") as Repeater;
                if (pendingList.DataSource == null || ((List<JXTPortal.Website.Admin.UserControls.DynamicPagesStatusListing.DynamicPageRevisionDispModel>)pendingList.DataSource).Count == 0)
                {
                    Panel pendingPanel = ucDynamicPageStatusListing1.FindControl("PendingPanel") as Panel;
                    pendingPanel.Visible = false;
                }

            }
        }

    }

}
