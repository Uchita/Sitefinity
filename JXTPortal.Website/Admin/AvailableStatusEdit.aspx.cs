
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

public partial class AvailableStatusEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int availableStatusId = 0;

    #endregion

    #region Properties

    JXTPortal.AvailableStatusService _availableStatusService;
    JXTPortal.AvailableStatusService AvailableStatusService
    {
        get
        {
            if (_availableStatusService == null)
            {
                _availableStatusService = new JXTPortal.AvailableStatusService();
            }
            return _availableStatusService;
        }
    }

    private int AvailableStatusId
    {
        get
        {
            if ((Request.QueryString["AvailableStatusId"] != null))
            {
                if (int.TryParse((Request.QueryString["AvailableStatusId"].Trim()), out availableStatusId))
                {
                    availableStatusId = Convert.ToInt32(Request.QueryString["AvailableStatusId"]);
                }
                return availableStatusId;
            }
            return availableStatusId;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadForm();
        }
    }

    #endregion

    #region Methods

    protected void loadForm()
    {
        if (AvailableStatusId > 0)
        {
            using (JXTPortal.Entities.AvailableStatus objAvailableStatus = AvailableStatusService.GetByAvailableStatusId(AvailableStatusId))
            {
                //txtAvailableStatusParentID.Text = Convert.ToString(objAvailableStatus.AvailableStatusParentId);
                txtAvailableStatusName.Text = objAvailableStatus.AvailableStatusName;
                chkGlobalTemplate.Checked = objAvailableStatus.GlobalTemplate;
                lblLastModifiedBy.Text = Convert.ToString(objAvailableStatus.LastModifiedBy);
                lblLastModifiedDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", objAvailableStatus.LastModified);

            }
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.AvailableStatus objAvailableStatus = new JXTPortal.Entities.AvailableStatus();

            try
            {
                if (AvailableStatusId > 0)
                {
                    objAvailableStatus = AvailableStatusService.GetByAvailableStatusId(AvailableStatusId);
                }

                objAvailableStatus.AvailableStatusParentId = 0;
                objAvailableStatus.AvailableStatusName = txtAvailableStatusName.Text;

                if (chkGlobalTemplate.Checked == true)
                {
                    objAvailableStatus.SiteId = 1;
                }

                objAvailableStatus.GlobalTemplate = chkGlobalTemplate.Checked;
                objAvailableStatus.LastModified = DateTime.Now;
                objAvailableStatus.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                objAvailableStatus.Sequence = 0;

                if (AvailableStatusId > 0)
                {
                    AvailableStatusService.Update(objAvailableStatus);
                }
                else
                {
                    AvailableStatusService.Insert(objAvailableStatus);
                }

            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
            finally
            {
                objAvailableStatus.Dispose();
            }
            Response.Redirect("availablestatus.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("availablestatus.aspx");
    }
    #endregion
}


