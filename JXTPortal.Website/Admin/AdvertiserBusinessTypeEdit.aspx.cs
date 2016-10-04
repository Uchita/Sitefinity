
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


public partial class AdvertiserBusinessTypeEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int advertiserbusinesstypeId = 0;

    #endregion

    #region Properties

    JXTPortal.AdvertiserBusinessTypeService _businesstypeService;
    JXTPortal.AdvertiserBusinessTypeService AdvertiserBusinessTypeService
    {
        get
        {
            if (_businesstypeService == null)
            {
                _businesstypeService = new JXTPortal.AdvertiserBusinessTypeService();
            }
            return _businesstypeService;
        }
    }

    private int AdvertiserBusinessTypeId
    {
        get
        {
            if ((Request.QueryString["AdvertiserBusinessTypeId"] != null))
            {
                if (int.TryParse((Request.QueryString["AdvertiserBusinessTypeId"].Trim()), out advertiserbusinesstypeId))
                {
                    advertiserbusinesstypeId = Convert.ToInt32(Request.QueryString["AdvertiserBusinessTypeId"]);
                }
                return advertiserbusinesstypeId;
            }
            return advertiserbusinesstypeId;
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
        if (AdvertiserBusinessTypeId > 0)
        {
            using (JXTPortal.Entities.AdvertiserBusinessType objBusinessType = AdvertiserBusinessTypeService.GetByAdvertiserBusinessTypeId(AdvertiserBusinessTypeId))
            {
                if (objBusinessType.GlobalTemplate)
                {
                    //txtEducationParentID.Text = Convert.ToString(objEducations.EducationParentId);
                    txtBusinessTypeName.Text = objBusinessType.AdvertiserBusinessTypeName;
                    lblLastModifiedBy.Text = Convert.ToString(objBusinessType.LastModifiedBy);
                    lblLastModifiedDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", objBusinessType.LastModifiedDate);
                    txtBusinessTypeSequence.Text = Convert.ToString(objBusinessType.Sequence);
                }
            }
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.AdvertiserBusinessType objBusinessType = new JXTPortal.Entities.AdvertiserBusinessType();
            bool isupdate = true;

            try
            {
                if (AdvertiserBusinessTypeId > 0)
                {
                    objBusinessType = AdvertiserBusinessTypeService.GetByAdvertiserBusinessTypeId(AdvertiserBusinessTypeId);
                    if (objBusinessType != null && objBusinessType.GlobalTemplate == false)
                    {
                        isupdate = false;
                    }
                }

                objBusinessType.BusinessTypeParentId = (int?)null;
                objBusinessType.AdvertiserBusinessTypeName = txtBusinessTypeName.Text;
                objBusinessType.GlobalTemplate = chkBusinessTypeGlobalTemplate.Checked;
                objBusinessType.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                objBusinessType.LastModifiedDate = DateTime.Now;
                objBusinessType.Sequence = Convert.ToInt32(txtBusinessTypeSequence.Text);

                if (AdvertiserBusinessTypeId > 0 && isupdate)
                {
                    AdvertiserBusinessTypeService.Update(objBusinessType);
                }
                else
                {
                    AdvertiserBusinessTypeService.Insert(objBusinessType);
                }

            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
            finally
            {
                objBusinessType.Dispose();
            }
            Response.Redirect("advertiserbusinesstype.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("advertiserbusinesstype.aspx");
    }
    #endregion
}


