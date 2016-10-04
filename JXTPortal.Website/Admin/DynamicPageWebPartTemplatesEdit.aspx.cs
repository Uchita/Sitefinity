
#region Imports...
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
using JXTPortal;
using JXTPortal.Entities;
#endregion

public partial class DynamicPageWebPartTemplatesEdit : System.Web.UI.Page
{
    #region Declare variables

    private DynamicPageWebPartTemplatesService _dynamicPageWebPartTemplatesService = null;

    #endregion

    #region Properties
    
    private int DynamicPageWebPartTemplateId
    {
        get
        {
            int _dynamicPageWebPartTemplateId = 0;

            if (Request.QueryString["DynamicPageWebPartTemplateId"] != null && Int32.TryParse(Request.QueryString["DynamicPageWebPartTemplateId"], out _dynamicPageWebPartTemplateId))
            {
                _dynamicPageWebPartTemplateId = Convert.ToInt32(Request.QueryString["DynamicPageWebPartTemplateId"]);
            }

            return _dynamicPageWebPartTemplateId;
        }
    }

    private DynamicPageWebPartTemplatesService DynamicPageWebPartTemplatesService
    {
        get
        {
            if (_dynamicPageWebPartTemplatesService == null)
                _dynamicPageWebPartTemplatesService = new DynamicPageWebPartTemplatesService();
            return _dynamicPageWebPartTemplatesService;
        }
    }

    private DynamicPageWebPartTemplatesLinkService _dynamicPageWebPartTemplatesLinkService;

    private DynamicPageWebPartTemplatesLinkService DynamicPageWebPartTemplatesLinkService
    {
        get
        {
            if (_dynamicPageWebPartTemplatesLinkService == null)
            {
                _dynamicPageWebPartTemplatesLinkService = new DynamicPageWebPartTemplatesLinkService();
            }
            return _dynamicPageWebPartTemplatesLinkService;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            LoadWebParts();
    }

    #endregion

    #region Click Event handlers


    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (JXTPortal.Entities.DynamicPageWebPartTemplates webPartTemplates = new JXTPortal.Entities.DynamicPageWebPartTemplates())
        {
            webPartTemplates.DynamicPageWebPartName = txtWebPartTemplateName.Text;
            
            // ****** Check if the Dynamic page exist for the site.

            if (DynamicPageWebPartTemplateId > 0)
            {
                webPartTemplates.DynamicPageWebPartTemplateId = DynamicPageWebPartTemplateId;

                DynamicPageWebPartTemplatesService.Update(webPartTemplates);
            }
            else
            {
                DynamicPageWebPartTemplatesService.Insert(webPartTemplates);
            }
        }

        Response.Redirect("dynamicpagewebparttemplates.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("dynamicpagewebparttemplates.aspx");
    }

    //protected void lnkDeleteFile_Click(object sender, EventArgs e)
    //{
    //    LinkButton lb = (LinkButton)sender;
        
    //    string ids = lb.CommandArgument;
    //    string[] arg = new string[2];
    //    char[] splitter = { ',' };
    //    arg = ids.Split(splitter);

    //    using (JXTPortal.Entities.DynamicPageWebPartTemplatesLink dynamicPageWebPartTemplatesLink = 
    //        DynamicPageWebPartTemplatesLinkService.GetByDynamicPageWebPartTemplateIdSiteWebPartId(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1])))
    //    {
    //        DynamicPageWebPartTemplatesLinkService dynamicPageWebPartTemplatesService = new DynamicPageWebPartTemplatesLinkService();
    //        dynamicPageWebPartTemplatesService.Delete(dynamicPageWebPartTemplatesLink);
    //    }

    //    LoadWebParts();
    //}

    #endregion
    
    #region Methods


    private void LoadWebParts()
    {
        if (DynamicPageWebPartTemplateId > 0)
        {
            using (JXTPortal.Entities.DynamicPageWebPartTemplates webPartTemplates =
                DynamicPageWebPartTemplatesService.GetByDynamicPageWebPartTemplateId(DynamicPageWebPartTemplateId))
            {
                if (webPartTemplates.SiteId == SessionData.Site.SiteId)
                {
                    txtWebPartTemplateName.Text = webPartTemplates.DynamicPageWebPartName;
                    ltlLastModified.Text = webPartTemplates.LastModified.ToString();

                    if (webPartTemplates.LastModified != null)
                        ltlLastModified.Text = ((DateTime)webPartTemplates.LastModified).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                    AdminUsersService objAdminUsers = new AdminUsersService();
                    using (JXTPortal.Entities.AdminUsers adminuser = objAdminUsers.GetByAdminUserId(webPartTemplates.LastModifiedBy))
                    {
                        ltlLastModifiedBy.Text = adminuser.UserName;
                    }

                    //LoadGridSiteWebParts();
                }
            }
        }
    }


    // <summary>
    // Method to Load the Site Web Parts
    /// </summary>
    //protected void LoadGridSiteWebParts()
    //{
    //    SiteWebPartsService siteWebPartsService = new SiteWebPartsService();
    //    using (DataSet dataSetDynamicPage =
    //                    siteWebPartsService.GetByDynamicPageWebPartTemplatesLink(DynamicPageWebPartTemplateId))
    //    {
    //        rptWebParts.DataSource = dataSetDynamicPage.Tables[0];
    //        rptWebParts.DataBind();
    //    }

    //}

    #endregion
    
}


