
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

public partial class SiteWebPartsEdit : System.Web.UI.Page
{

    #region Declare variables
    #endregion

    #region Properties

    private int SiteWebPartsID
    {
        get
        {
            int _siteWebPartsID = 0;

            if (Request.QueryString["SiteWebPartID"] != null && Int32.TryParse(Request.QueryString["SiteWebPartID"], out _siteWebPartsID))
            {
                _siteWebPartsID = Convert.ToInt32(Request.QueryString["SiteWebPartID"]);
            }

            return _siteWebPartsID;
        }
    }

    private SiteWebPartsService _siteWebPartsService = null;

    private SiteWebPartsService SiteWebPartsService
    {
        get
        {
            if (_siteWebPartsService == null)
                _siteWebPartsService = new SiteWebPartsService();
            return _siteWebPartsService;
        }
    }

    private SiteWebPartTypesService _siteWebPartTypesService = null;

    private SiteWebPartTypesService SiteWebPartTypesService
    {
        get
        {
            if (_siteWebPartTypesService == null)
                _siteWebPartTypesService = new SiteWebPartTypesService();
            return _siteWebPartTypesService;
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
            Load();
            LoadWebParts();


        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (JXTPortal.Entities.SiteWebParts webPart = new JXTPortal.Entities.SiteWebParts())
        {
            webPart.SiteWebPartTypeId = Convert.ToInt32(ddlWebPartType.SelectedValue);
            webPart.SiteWebPartId = SiteWebPartsID;
            webPart.SiteWebPartHtml = txtWebPartContent.Text.Replace("../", "/");
            webPart.SiteWebPartName = txtWebPartName.Text;
            if (SiteWebPartsID > 0)
            {
                SiteWebPartsService.Update(webPart);
            }
            else
            {
                SiteWebPartsService.Insert(webPart);
            }
        }
        if (((Button)sender).Text == "Save")
            Response.Redirect("sitewebparts.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("sitewebparts.aspx");
    }

    #endregion


    #region Methods

    private void Load()
    {
        ddlWebPartType.Items.Clear();
        ddlWebPartType.DataSource = SiteWebPartTypesService.GetAll();
        ddlWebPartType.DataTextField = "SiteWebPartName";
        ddlWebPartType.DataValueField = "SiteWebPartTypeId";
        ddlWebPartType.DataBind();
    }

    private void LoadWebParts()
    {
        if (SiteWebPartsID > 0)
        {
            using (JXTPortal.Entities.SiteWebParts webPart = SiteWebPartsService.GetBySiteWebPartId(SiteWebPartsID))
            {
                if (webPart.SiteId == SessionData.Site.SiteId)
                {
                    txtWebPartName.Text = webPart.SiteWebPartName;
                    txtWebPartContent.Text = webPart.SiteWebPartHtml.Replace("../", "/");
                    ddlWebPartType.SelectedValue = webPart.SiteWebPartTypeId.ToString();


                    // To display only per Site
                    //DynamicPageWebPartTemplatesLinkDataSource.Parameters.Add("SiteWebPartId", SiteWebPartsID.ToString());

                    //btnDynamicPageWebPartTemplatesLink.Visible = true;
                    //return;
                }
            }
        }
        else
            btnApply.Visible = false;

        //btnDynamicPageWebPartTemplatesLink.Visible = false;
    }

    #endregion

    /*
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("DynamicPageWebPartTemplatesLinkId={0}", GridView1.SelectedDataKey.Values[0]);
        Response.Redirect("DynamicPageWebPartTemplatesLinkEdit.aspx?" + urlParams, true);
    }*/

    protected void btnDynamicPageWebPartTemplatesLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("dynamicpagewebparttemplateslinkedit.aspx?SiteWebPartId=" + Request["SiteWebPartId"].ToString(), true);

    }
}


