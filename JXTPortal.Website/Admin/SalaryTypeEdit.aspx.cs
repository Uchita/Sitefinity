
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
#endregion

public partial class SalaryTypeEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int salaryTypeId = 0;

    #endregion

    #region Properties

    JXTPortal.SalaryTypeService _salaryTypeService;
    JXTPortal.SalaryTypeService SalaryTypeService
    {
        get
        {
            if (_salaryTypeService == null)
            {
                _salaryTypeService = new JXTPortal.SalaryTypeService();
            }
            return _salaryTypeService;
        }
    }

    private int SalaryTypeID
    {
        get
        {
            if ((Request.QueryString["SalaryTypeId"] != null))
            {
                if (int.TryParse((Request.QueryString["SalaryTypeId"].Trim()), out salaryTypeId))
                {
                    salaryTypeId = Convert.ToInt32(Request.QueryString["SalaryTypeId"]);
                }
                return salaryTypeId;
            }
            return salaryTypeId;
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
        if (SalaryTypeID > 0)
        {
            using (JXTPortal.Entities.SalaryType objSalaryType = SalaryTypeService.GetBySalaryTypeId(SalaryTypeID))
            {
                txtSalaryTypeName.Text = objSalaryType.SalaryTypeName;
                chkSalaryTypeValid.Checked = objSalaryType.Valid;

                txtSalaryTypeName.Enabled = false;
                chkSalaryTypeValid.Enabled = false;
                litDisabledMsg.Visible = true;
                btnSubmit.Visible = false;
            }
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.SalaryType objSalaryType = new JXTPortal.Entities.SalaryType();

            try
            {
                if (SalaryTypeID > 0)
                {
                    objSalaryType = SalaryTypeService.GetBySalaryTypeId(SalaryTypeID);
                    
                }

                objSalaryType.SalaryTypeId = SalaryTypeID;
                objSalaryType.SalaryTypeName = txtSalaryTypeName.Text;
                objSalaryType.Valid = chkSalaryTypeValid.Checked;

                if (SalaryTypeID > 0)
                {
                    SalaryTypeService.Update(objSalaryType);
                }
                else
                {
                    Response.Redirect("salarytype.aspx");

                    // Insert is commented out for webservice purposes - Ditto 21/02/2013
                    // SalaryTypeService.Insert(objSalaryType);
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
            finally
            {
                objSalaryType.Dispose();
            }
            Response.Redirect("salarytype.aspx");

        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("salarytype.aspx");
    }

    #endregion
}


