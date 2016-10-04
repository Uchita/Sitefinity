
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

public partial class MemberStatusEdit : System.Web.UI.Page
{

    #region Declare variables

    private MemberStatusService _memberStatusService = null;

    #endregion

    #region Properties

    private int MemberStatusId
    {
        get
        {
            int _memberStatusId = 0;

            if (Request.QueryString["MemberStatusId"] != null && Int32.TryParse(Request.QueryString["MemberStatusId"], out _memberStatusId))
            {
                _memberStatusId = Convert.ToInt32(Request.QueryString["MemberStatusId"]);
            }

            return _memberStatusId;
        }
    }

    private MemberStatusService MemberStatusService
    {
        get
        {
            if (_memberStatusService == null)
                _memberStatusService = new MemberStatusService();
            return _memberStatusService;
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
        JXTPortal.Entities.MemberStatus memberStatus = null;

        if (MemberStatusId > 0)
        {
            memberStatus = MemberStatusService.GetByMemberStatusId(MemberStatusId);

            if (memberStatus == null || memberStatus.SiteId != SessionData.Site.SiteId)
                Response.Redirect("/admin/memberstatus.aspx");
        }
        else
            memberStatus = new JXTPortal.Entities.MemberStatus();

        memberStatus.MemberStatusName = txtName.Text;
        memberStatus.Sequence = int.Parse(txtSequence.Text);
        memberStatus.Valid = chkValid.Checked;

        memberStatus.LastModified = DateTime.Now;
        memberStatus.LastModifiedBy = SessionData.AdminUser.AdminUserId;

        if (MemberStatusId > 0)
        {
            MemberStatusService.Update(memberStatus);
        }
        else
        {
            memberStatus.SiteId = SessionData.Site.SiteId;
            MemberStatusService.Insert(memberStatus);
        }

        if (memberStatus != null)
            memberStatus.Dispose();

        Response.Redirect("MemberStatus.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberStatus.aspx");
    }



    #endregion

    #region Methods


    private void LoadWebParts()
    {
        if (MemberStatusId > 0)
        {
            using (JXTPortal.Entities.MemberStatus memberStatus =
                MemberStatusService.GetByMemberStatusId(MemberStatusId))
            {
                if (memberStatus != null && memberStatus.SiteId == SessionData.Site.SiteId)
                {
                    txtName.Text = memberStatus.MemberStatusName;
                    ltlLastModified.Text = memberStatus.LastModified.ToString();
                    txtSequence.Text = memberStatus.Sequence.ToString();
                    chkValid.Checked = memberStatus.Valid;

                    if (memberStatus.LastModified != null)
                        ltlLastModified.Text = ((DateTime)memberStatus.LastModified).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                    AdminUsersService objAdminUsers = new AdminUsersService();
                    using (JXTPortal.Entities.AdminUsers adminuser = objAdminUsers.GetByAdminUserId(memberStatus.LastModifiedBy))
                    {
                        ltlLastModifiedBy.Text = adminuser.UserName;
                    }


                }
                else
                    Response.Redirect("MemberStatus.aspx");

            }
        }
    }


    #endregion

}


