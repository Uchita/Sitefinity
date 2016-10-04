
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
#endregion

public partial class MemberFilesEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int memberFileID = 0;

    #endregion

    #region Properties

    JXTPortal.MemberFilesService _memberFilesService;

    JXTPortal.MemberFilesService MemberFilesService
    {
        get
        {
            if (_memberFilesService == null)
            {
                _memberFilesService = new JXTPortal.MemberFilesService();
            }
            return _memberFilesService;
        }
    }

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

    JXTPortal.MembersService _membersService;

    JXTPortal.MembersService MembersService
    {
        get
        {
            if (_membersService == null)
            {
                _membersService = new JXTPortal.MembersService();
            }
            return _membersService;
        }
    }

    private int MemberFileId
    {
        get
        {
            if ((Request.QueryString["MemberFileId"] != null))
            {
                if (int.TryParse((Request.QueryString["MemberFileId"].Trim()), out memberFileID))
                {
                    memberFileID = Convert.ToInt32(Request.QueryString["MemberFileId"]);
                }
                return memberFileID;
            }

            return memberFileID;
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
        if (MemberFileId > 0)
        {
            using (JXTPortal.Entities.MemberFiles objMemberFiles = MemberFilesService.GetByMemberFileId(MemberFileId))
            {
                lblMemberID.Text = Convert.ToString(objMemberFiles.MemberId);
                txtMemberFileName.Text = objMemberFiles.MemberFileName;
                txtMemberFileTitle.Text = objMemberFiles.MemberFileTitle;
                lblModifiedDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", objMemberFiles.LastModifiedDate);
                lblMemberFileTypeName.Text = GetMemberFileTypeName(objMemberFiles.MemberFileTypeId);
                lblmemberName.Text = GetMemberName(objMemberFiles.MemberId);
                //txtPrivacyLevelID.Text = Convert.ToString(objMemberFiles.PrivacyLevelId);
            }
        }
        else
        {
            Response.Redirect("memberfiles.aspx");
        }

    }

    protected string GetMemberFileTypeName(int intFileTypeID)
    {
        using (JXTPortal.Entities.MemberFileTypes objMemberFileTypes = MemberFileTypesService.GetByMemberFileTypeId(intFileTypeID))
        {

            if (objMemberFileTypes != null)
            {
                return objMemberFileTypes.MemberFileTypeName;
            }

        }
        return string.Empty;
    }

    protected string GetMemberName(int intMemberID)
    {
        using (JXTPortal.Entities.Members objMember = MembersService.GetByMemberId(intMemberID))
        {

            if (objMember != null)
            {
                return objMember.Username;
            }

        }
        return string.Empty;
    }

    #endregion


    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.MemberFiles objMemberFiles = MemberFilesService.GetByMemberFileId(MemberFileId);

            try
            {
                if (memberFileID > 0)
                {
                    objMemberFiles = MemberFilesService.GetByMemberFileId(MemberFileId); 
                }

                objMemberFiles.MemberFileName = txtMemberFileName.Text;
                objMemberFiles.MemberFileTitle = txtMemberFileTitle.Text;
                objMemberFiles.LastModifiedDate = DateTime.Now;
                //objMemberFiles.PrivacyLevelId = Convert.ToInt32(txtPrivacyLevelID.Text);

                MemberFilesService.Update(objMemberFiles);
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
            finally
            {
                objMemberFiles.Dispose();
            }
            Response.Redirect("memberfiles.aspx");

        }
    }

    #endregion


}


