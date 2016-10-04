

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

public partial class EducationsEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int educationId = 0;

    #endregion

    #region Properties

    JXTPortal.EducationsService _educationsService;
    JXTPortal.EducationsService EducationsService
    {
        get
        {
            if (_educationsService == null)
            {
                _educationsService = new JXTPortal.EducationsService();
            }
            return _educationsService;
        }
    }

    private int EducationId
    {
        get
        {
            if ((Request.QueryString["EducationId"] != null))
            {
                if (int.TryParse((Request.QueryString["EducationId"].Trim()), out educationId))
                {
                    educationId = Convert.ToInt32(Request.QueryString["EducationId"]);
                }
                return educationId;
            }
            return educationId;
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
        if (EducationId > 0)
        {
            using (JXTPortal.Entities.Educations objEducations = EducationsService.GetByEducationId(EducationId))
            {
                //txtEducationParentID.Text = Convert.ToString(objEducations.EducationParentId);
                txtEducationName.Text = objEducations.EducationName;
                lblLastModifiedBy.Text = Convert.ToString(objEducations.LastModifiedBy);
                lblLastModifiedDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", objEducations.LastModified);
                txtEducationSequence.Text = Convert.ToString(objEducations.Sequence);
            }
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.Educations objEducations = new JXTPortal.Entities.Educations();

            try
            {
                if (EducationId > 0)
                {
                    objEducations = EducationsService.GetByEducationId(EducationId);
                }

                objEducations.EducationParentId = 0;
                objEducations.EducationName = txtEducationName.Text;
                objEducations.GlobalTemplate = chkEducationGlobalTemplate.Checked;
                objEducations.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                objEducations.LastModified = DateTime.Now;
                objEducations.Sequence = Convert.ToInt32(txtEducationSequence.Text);

                if (EducationId > 0)
                {
                    EducationsService.Update(objEducations);
                }
                else
                {
                    EducationsService.Insert(objEducations);
                }

            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
            finally
            {
                objEducations.Dispose();
            }
            Response.Redirect("educations.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("educations.aspx");
    }
    #endregion
}


