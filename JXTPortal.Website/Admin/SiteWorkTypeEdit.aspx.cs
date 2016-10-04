
#region Imports
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
#endregion

public partial class SiteWorkTypeEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int siteWorkTypeId = 0;

    #endregion

    #region Properties

    JXTPortal.SiteWorkTypeService _siteWorkTypeService;
    JXTPortal.SiteWorkTypeService SiteWorkTypeService
    {
        get
        {
            if (_siteWorkTypeService == null)
            {
                _siteWorkTypeService = new JXTPortal.SiteWorkTypeService();
            }
            return _siteWorkTypeService;
        }
    }

    private int SiteWorkTypeId
    {
        get
        {
            if ((Request.QueryString["SiteWorkTypeId"] != null))
            {
                if (int.TryParse((Request.QueryString["SiteWorkTypeId"].Trim()), out siteWorkTypeId))
                {
                    siteWorkTypeId = Convert.ToInt32(Request.QueryString["SiteWorkTypeId"]);
                }
                return siteWorkTypeId;
            }
            return siteWorkTypeId;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populateWorkTypes();
            loadForm();
        }
    }

    #endregion

    #region Methods

    protected void loadForm()
    {
        if (SiteWorkTypeId > 0)
        {
            using (JXTPortal.Entities.SiteWorkType objSiteWorkType = SiteWorkTypeService.GetBySiteWorkTypeId(SiteWorkTypeId))
            {
                if (objSiteWorkType.SiteId == SessionData.Site.SiteId)
                {
                    ddlWorkTypeID.SelectedValue = Convert.ToString(objSiteWorkType.WorkTypeId);
                    lblAdminSiteWorkTypeSiteID.Text = Convert.ToString(objSiteWorkType.SiteId);
                    txtAdminSiteWorkTypeName.Text = objSiteWorkType.SiteWorkTypeName;
                }
                else
                {
                    Response.Redirect("SiteWorkType.aspx"); 
                }
            }
        }
    }

    protected void populateWorkTypes()
    {
        JXTPortal.WorkTypeService workTypes = new JXTPortal.WorkTypeService();

        TList<JXTPortal.Entities.WorkType> wt = workTypes.GetAll();
        wt.Filter = "Valid = true";
        ddlWorkTypeID.DataSource = wt;
        ddlWorkTypeID.DataTextField = "WorkTypeName";
        ddlWorkTypeID.DataValueField = "WorkTypeID";
        ddlWorkTypeID.DataBind();
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.SiteWorkType objSiteWorkType = new JXTPortal.Entities.SiteWorkType();

            try
            {
                if (SiteWorkTypeId > 0)
                {
                    objSiteWorkType = SiteWorkTypeService.GetBySiteWorkTypeId(SiteWorkTypeId);
                }

                objSiteWorkType.WorkTypeId = Convert.ToInt32(ddlWorkTypeID.SelectedValue);
                objSiteWorkType.SiteWorkTypeName = txtAdminSiteWorkTypeName.Text;
                objSiteWorkType.Valid = chkSiteWorkTypeValid.Checked;

                if (SiteWorkTypeId > 0)
                {
                    SiteWorkTypeService.Update(objSiteWorkType);
                }
                else
                {
                    SiteWorkTypeService.Insert(objSiteWorkType);
                }

            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
            finally
            {
                objSiteWorkType.Dispose();
            }

            Response.Redirect("SiteWorkType.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteWorkType.aspx");
    }

    #endregion
}


