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
using JXTPortal.Web.UI;
using JXTPortal.Website;
using JXTPortal;
using JXTPortal.Entities;

public partial class TermsAndConditions : System.Web.UI.Page
{
    private DynamicContentService _dynamiccontentservice;
    private DynamicContentService DynamicContentService
    {
        get
        {
            if (_dynamiccontentservice == null)
            {
                _dynamiccontentservice = new DynamicContentService();
            }
            return _dynamiccontentservice;
        }
    }

    private AdminUsersService _adminusersservice;
    private AdminUsersService AdminUsersService
    {
        get
        {
            if (_adminusersservice == null)
            {
                _adminusersservice = new AdminUsersService();
            }
            return _adminusersservice;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMsg.Text = string.Empty;

        if (!Page.IsPostBack)
        {
            LoadTermsAndConditions();
        }
    }

    private void LoadTermsAndConditions()
    {
        TList<DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(SessionData.Site.SiteId);
        foreach (DynamicContent dynamiccontent in dynamiccontents)
        {
            if (dynamiccontent.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions))
            {
                // Advertiser
                cbAdvMarkActive.Checked = dynamiccontent.Active;
                tbAdvertiserTCTitle.Text = dynamiccontent.Title;
                tbAdvertiserTCIntroduction.Text = dynamiccontent.Introduction;
                tbAdvertiserTC.Text = dynamiccontent.Description;
                dataLastModified.Text = dynamiccontent.LastModifiedDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                dataModifiedBy.Text = string.Empty;

                if(dynamiccontent.LastModifiedBy.HasValue)
                {
                     JXTPortal.Entities.AdminUsers adminuser = AdminUsersService.GetByAdminUserId(dynamiccontent.LastModifiedBy.Value);
                    if (adminuser != null)
                    {
                        dataModifiedBy.Text = adminuser.UserName;
                    }
                }
            }

            if (dynamiccontent.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.MemberTermsAndConditions))
            {
                // Member
                cbMemberMarkActive.Checked = dynamiccontent.Active;
                tbMemberTCTitle.Text = dynamiccontent.Title;
                tbMemberTCIntroduction.Text = dynamiccontent.Introduction;
                tbMemberTC.Text = dynamiccontent.Description;
                dataMemberLastModified.Text = dynamiccontent.LastModifiedDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                dataMemberModifiedBy.Text = string.Empty;

                if (dynamiccontent.LastModifiedBy.HasValue)
                {
                    JXTPortal.Entities.AdminUsers adminuser = AdminUsersService.GetByAdminUserId(dynamiccontent.LastModifiedBy.Value);
                    if (adminuser != null)
                    {
                        dataMemberModifiedBy.Text = adminuser.UserName;
                    }
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DynamicContent dynamiccontent = new DynamicContent();
        TList<DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(SessionData.Site.SiteId);
        foreach (DynamicContent dc in dynamiccontents)
        {
            if (dc.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions))
            {
                dynamiccontent = dc;
            }
        }
        dynamiccontent.DynamicContentType = ((int)PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions);
        dynamiccontent.Active = cbAdvMarkActive.Checked;
        dynamiccontent.Title = tbAdvertiserTCTitle.Text;
        dynamiccontent.Introduction = tbAdvertiserTCIntroduction.Text;
        dynamiccontent.Description = tbAdvertiserTC.Text;
        dynamiccontent.LastModifiedDate = DateTime.Now;
        dynamiccontent.LastModifiedBy = SessionData.AdminUser.AdminUserId;

        if (dynamiccontent.DynamicContentId == ((int)PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions))
        {
            DynamicContentService.Insert(dynamiccontent);
        }
        else
        {
            DynamicContentService.Update(dynamiccontent);
        }

        lblErrorMsg.Text = "Advertiser Terms &amp; Conditions have been saved successfully";
        LoadTermsAndConditions();
    }

    protected void btnMemberSubmit_Click(object sender, EventArgs e)
    {
        DynamicContent dynamiccontent = new DynamicContent();
        TList<DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(SessionData.Site.SiteId);
        foreach (DynamicContent dc in dynamiccontents)
        {
            if (dc.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.MemberTermsAndConditions))
            {
                dynamiccontent = dc;
            }
        }
        dynamiccontent.DynamicContentType = ((int)PortalEnums.DynamicContent.DynamicContentType.MemberTermsAndConditions);
        dynamiccontent.Active = cbMemberMarkActive.Checked;
        dynamiccontent.Title = tbMemberTCTitle.Text;
        dynamiccontent.Introduction = tbMemberTCIntroduction.Text;
        dynamiccontent.Description = tbMemberTC.Text;
        dynamiccontent.LastModifiedDate = DateTime.Now;
        dynamiccontent.LastModifiedBy = SessionData.AdminUser.AdminUserId;

        if (dynamiccontent.DynamicContentId == 0)
        {
            DynamicContentService.Insert(dynamiccontent);
        }
        else
        {
            DynamicContentService.Update(dynamiccontent);
        }

        lblErrorMsg.Text = "Candidate Terms &amp; Conditions have been saved successfully";
        LoadTermsAndConditions();
    }
}