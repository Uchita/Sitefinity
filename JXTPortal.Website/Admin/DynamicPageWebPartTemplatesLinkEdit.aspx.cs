
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
using JXTPortal.Entities;
using JXTPortal;
#endregion

public partial class DynamicPageWebPartTemplatesLinkEdit : System.Web.UI.Page
{
    #region Declare variables

    private DynamicPageWebPartTemplatesLinkService _dynamicPageWebPartTemplatesLinkService = null;

    #endregion

    #region Properties

    private int? SiteWebPartId
    {
        get
        {
            int _siteWebPartId = 0;

            if (Request.QueryString["SiteWebPartId"] != null && Int32.TryParse(Request.QueryString["SiteWebPartId"], out _siteWebPartId))
            {
                _siteWebPartId = Convert.ToInt32(Request.QueryString["SiteWebPartId"]);

                return _siteWebPartId;
            }

            return null;
        }
    }

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

    private int DynamicPageWebPartTemplatesLinkId
    {
        get
        {
            int _dynamicPageWebPartTemplatesLinkId = 0;

            if (Request.QueryString["DynamicPageWebPartTemplatesLinkId"] != null && Int32.TryParse(Request.QueryString["DynamicPageWebPartTemplatesLinkId"], out _dynamicPageWebPartTemplatesLinkId))
            {
                _dynamicPageWebPartTemplatesLinkId = Convert.ToInt32(Request.QueryString["DynamicPageWebPartTemplatesLinkId"]);
            }

            return _dynamicPageWebPartTemplatesLinkId;
        }
    }


    private DynamicPageWebPartTemplatesLinkService DynamicPageWebPartTemplatesLinkService
    {
        get
        {
            if (_dynamicPageWebPartTemplatesLinkService == null)
                _dynamicPageWebPartTemplatesLinkService = new DynamicPageWebPartTemplatesLinkService();
            return _dynamicPageWebPartTemplatesLinkService;
        }
    }

    #endregion

    #region Constructors
    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadDynamicPageWebPartTemplates();
            LoadSiteWebParts();

            if (DynamicPageWebPartTemplatesLinkId > 0)
            {
                LoadDynamicPageWebPartTemplatesLink();
            }
        }

        // Display the List of Web Parts which are linked to the Container

        DynamicPageWebPartTemplatesLink1.Visible = (ddlWebPartTemplate.SelectedIndex > 0);
        if (DynamicPageWebPartTemplatesLink1.Visible)
        {
            DynamicPageWebPartTemplatesLink1.DynamicPageWebPartTemplateId = Convert.ToInt32(ddlWebPartTemplate.SelectedValue);
            DynamicPageWebPartTemplatesLink1.LoadGridSiteWebParts();
        }


    }

    #endregion

    #region Click Event handlers

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid && ddlSiteWebParts.SelectedIndex > -1 && ddlWebPartTemplate.SelectedIndex > 0)
        {
            try
            {
                if (DynamicPageWebPartTemplatesLinkId > 0)
                {
                    // Update News Category
                    using (JXTPortal.Entities.DynamicPageWebPartTemplatesLink dpWpTemplatesLink
                                = DynamicPageWebPartTemplatesLinkService.GetByDynamicPageWebPartTemplatesLinkId(DynamicPageWebPartTemplatesLinkId))
                    {
                        dpWpTemplatesLink.DynamicPageWebPartTemplateId = int.Parse(ddlWebPartTemplate.SelectedValue);
                        dpWpTemplatesLink.SiteWebPartId = int.Parse(ddlSiteWebParts.SelectedValue);
                        dpWpTemplatesLink.Sequence = int.Parse(txtSequence.Text);

                        DynamicPageWebPartTemplatesLinkService.Update(dpWpTemplatesLink);
                    }
                }
                else
                {
                    // Save News Category
                    using (JXTPortal.Entities.DynamicPageWebPartTemplatesLink dpWpTemplatesLink = new JXTPortal.Entities.DynamicPageWebPartTemplatesLink())
                    {
                        dpWpTemplatesLink.DynamicPageWebPartTemplateId = int.Parse(ddlWebPartTemplate.SelectedValue);
                        dpWpTemplatesLink.SiteWebPartId = int.Parse(ddlSiteWebParts.SelectedValue);
                        dpWpTemplatesLink.Sequence = int.Parse(txtSequence.Text);

                        DynamicPageWebPartTemplatesLinkService.Insert(dpWpTemplatesLink);

                    }
                }

                // Load the Grid
                DynamicPageWebPartTemplatesLink1.LoadGridSiteWebParts();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot insert"))
                    ltlMessage.Text = "Web Part already added";
                else
                    ltlMessage.Text = ex.Message;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DynamicPageWebPartTemplates.aspx");
    }

    #endregion

    #region Methods

    /// <summary>
    /// Method to Load the 
    /// </summary>
    protected void LoadDynamicPageWebPartTemplates()
    {
        JXTPortal.DynamicPageWebPartTemplatesService dynamicPageWebPartTemplatesService = new JXTPortal.DynamicPageWebPartTemplatesService();

        using (TList<JXTPortal.Entities.DynamicPageWebPartTemplates> dynamicPageWebPartTemplates = dynamicPageWebPartTemplatesService.GetBySiteId(SessionData.Site.SiteId))
        {
            ddlWebPartTemplate.DataSource = dynamicPageWebPartTemplates;
            ddlWebPartTemplate.DataTextField = "DynamicPageWebPartName";
            ddlWebPartTemplate.DataValueField = "DynamicPageWebPartTemplateID";
            ddlWebPartTemplate.DataBind();

            ListItem listItem = new ListItem(" - Select Item - ", "");
            ddlWebPartTemplate.Items.Insert(0, listItem);

            if (dynamicPageWebPartTemplates.Count > 0)
            {
                if (DynamicPageWebPartTemplateId > 0)
                {
                    ddlWebPartTemplate.SelectedValue = DynamicPageWebPartTemplateId.ToString();
                    ddlWebPartTemplate.Enabled = false;
                }
                else
                    ddlWebPartTemplate.SelectedIndex = 0;
            }
        }


    }

    /// <summary>
    /// Method to Load the Site Web Parts
    /// </summary>
    protected void LoadSiteWebParts()
    {
        JXTPortal.SiteWebPartsService siteWebPartsService = new JXTPortal.SiteWebPartsService();

        using (TList<JXTPortal.Entities.SiteWebParts> siteWebParts = siteWebPartsService.GetBySiteId(SessionData.Site.SiteId))
        {
            ddlSiteWebParts.DataSource = siteWebParts;
            ddlSiteWebParts.DataTextField = "SiteWebPartName";
            ddlSiteWebParts.DataValueField = "SiteWebPartID";
            ddlSiteWebParts.DataBind();

            ListItem listItems = new ListItem(" - Select Template - ", "");
            ddlSiteWebParts.Items.Insert(0, listItems);

            if (siteWebParts.Count > 0)
            {
                // Check if There is Query String SiteWebPartId then set the selected value
                if (SiteWebPartId.HasValue)
                    ddlSiteWebParts.SelectedValue = SiteWebPartId.Value.ToString();
                else
                    ddlSiteWebParts.SelectedIndex = 0;
            }
        }

    }

    protected void LoadDynamicPageWebPartTemplatesLink()
    {
        using (JXTPortal.Entities.DynamicPageWebPartTemplatesLink dpWpTemplatesLink =
                    DynamicPageWebPartTemplatesLinkService.GetByDynamicPageWebPartTemplatesLinkId(DynamicPageWebPartTemplatesLinkId))
        {
            ddlSiteWebParts.SelectedValue = dpWpTemplatesLink.SiteWebPartId.ToString();
            ddlWebPartTemplate.SelectedValue = dpWpTemplatesLink.DynamicPageWebPartTemplateId.ToString();
            txtSequence.Text = dpWpTemplatesLink.Sequence.ToString();
        }

    }

    /// <summary>
    /// Method to Load the Site Web Parts
    /// </summary>
    //protected void LoadGridSiteWebParts()
    //{
    //    int intSelectedValue = int.Parse(ddlWebPartTemplate.SelectedValue);

    //    SiteWebPartsService siteWebPartsService = new SiteWebPartsService();

    //    using (DataSet dataSetDynamicPage =
    //                    siteWebPartsService.GetByDynamicPageWebPartTemplatesLink(intSelectedValue))
    //    {
    //        rptWebParts.DataSource = dataSetDynamicPage.Tables[0];
    //        rptWebParts.DataBind();

    //    }

    //}

    #endregion



}


