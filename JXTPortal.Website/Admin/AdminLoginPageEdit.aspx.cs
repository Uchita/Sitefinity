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
using System.Linq;
using JXTPortal.Web.UI;
using JXTPortal.Website;
using JXTPortal;
using JXTPortal.Entities;

public partial class AdminLoginPageEdit : System.Web.UI.Page
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
            LoadPageContent();
        }
    }

    private void LoadPageContent()
    {
        using (TList<DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"])))
        {

            using (DynamicContent target = dynamiccontents.Where(c => c.DynamicContentType == (int)PortalEnums.DynamicContent.DynamicContentType.AdminLoginContent).FirstOrDefault())
            {

                if (target != null)
                {
                    tbLoginContent.Text = target.Description;
                    dataLastModified.Text = target.LastModifiedDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    dataModifiedBy.Text = string.Empty;

                    if (target.LastModifiedBy.HasValue)
                    {
                        using (JXTPortal.Entities.AdminUsers adminuser = AdminUsersService.GetByAdminUserId(target.LastModifiedBy.Value))
                        {
                            if (adminuser != null)
                            {
                                dataModifiedBy.Text = adminuser.UserName;
                            }
                        }
                    }
                }
            }
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DynamicContent dynamiccontent;
        using (TList<DynamicContent> dynamiccontentsForSite = DynamicContentService.GetBySiteId(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"])))
        {

            dynamiccontent = dynamiccontentsForSite.Where(c => c.DynamicContentType == (int)PortalEnums.DynamicContent.DynamicContentType.AdminLoginContent).FirstOrDefault();

            if (dynamiccontent == null)
            {
                dynamiccontent = new DynamicContent();
                dynamiccontent.DynamicContentType = ((int)PortalEnums.DynamicContent.DynamicContentType.AdminLoginContent);
                dynamiccontent.Active = true;
            }

            dynamiccontent.SiteId = Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]);
            //dynamiccontent.Title = tbAdvertiserTCTitle.Text;
            //dynamiccontent.Introduction = tbAdvertiserTCIntroduction.Text;
            dynamiccontent.Description = tbLoginContent.Text;
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

        }

        lblErrorMsg.Text = "Admin login page contents have been saved successfully";
        LoadPageContent();
    }

}