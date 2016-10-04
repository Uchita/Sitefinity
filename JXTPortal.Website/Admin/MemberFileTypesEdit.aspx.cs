
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
#endregion

public partial class MemberFileTypesEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int memberFileTypeId = 0;

    #endregion

    #region properties

    JXTPortal.MemberFileTypesService _memberFileTypesService;
    JXTPortal.MemberFileTypesService MemberFileTypesService
    {
        get
        {
            if (_memberFileTypesService == null)
            {
                _memberFileTypesService = new JXTPortal.MemberFileTypesService();
            }
            return _memberFileTypesService;
        }
    }

    private int MemberFileTypeId
    {
        get
        {
            if (Request.QueryString["MemberFileTypeId"] != null)
            {
                if (int.TryParse((Request.QueryString["MemberFileTypeId"].Trim()), out memberFileTypeId))
                {
                    memberFileTypeId = Convert.ToInt32(Request.QueryString["MemberFileTypeId"]);
                }
                return memberFileTypeId;
            }
            return memberFileTypeId;
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
        if (MemberFileTypeId > 0)
        {
            using (JXTPortal.Entities.MemberFileTypes objmemberFileType = MemberFileTypesService.GetByMemberFileTypeId(MemberFileTypeId))
            {
                txtMemberFileTypeName.Text = objmemberFileType.MemberFileTypeName;
                txtMemberFileTypeExtensions.Text = objmemberFileType.MemberFileExtensions;
            }
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.MemberFileTypes objmemberFileType = new JXTPortal.Entities.MemberFileTypes();

            try
            {
                if (MemberFileTypeId > 0)
                {
                    objmemberFileType = MemberFileTypesService.GetByMemberFileTypeId(MemberFileTypeId);
                }

                //objmemberFileType.MemberFileTypeId = MemberFileTypeId;
                objmemberFileType.MemberFileTypeName = txtMemberFileTypeName.Text;
                objmemberFileType.MemberFileExtensions = txtMemberFileTypeExtensions.Text;

                if (MemberFileTypeId > 0)
                {
                    MemberFileTypesService.Update(objmemberFileType);
                }
                else
                {
                    MemberFileTypesService.Insert(objmemberFileType);
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
            finally
            {

            }
            Response.Redirect("memberfiletypes.aspx");

        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("memberfiletypes.aspx");
    }

    #endregion
}


