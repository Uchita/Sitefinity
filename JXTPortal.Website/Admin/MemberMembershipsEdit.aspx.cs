
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

public partial class MemberMembershipsEdit : System.Web.UI.Page
{
    #region Declare variables

    private MemberMembershipsService _memberMembershipsService = null;

    #endregion

    #region Properties

    private int MemberMembershipsId
    {
        get
        {
            int _memberMembershipsId = 0;

            if (Request.QueryString["MemberMembershipsId"] != null && Int32.TryParse(Request.QueryString["MemberMembershipsId"], out _memberMembershipsId))
            {
                _memberMembershipsId = Convert.ToInt32(Request.QueryString["MemberMembershipsId"]);
            }

            return _memberMembershipsId;
        }
    }

    private MemberMembershipsService MemberMembershipsService
    {
        get
        {
            if (_memberMembershipsService == null)
                _memberMembershipsService = new MemberMembershipsService();
            return _memberMembershipsService;
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

        JXTPortal.Entities.MemberMemberships memberMemberships = null;

        if (MemberMembershipsId > 0)
        {
            memberMemberships = MemberMembershipsService.GetByMemberMembershipsId(MemberMembershipsId);

            if (memberMemberships == null || memberMemberships.SiteId != SessionData.Site.SiteId)
                Response.Redirect("/admin/membermemberships.aspx");
        }
        else
            memberMemberships = new JXTPortal.Entities.MemberMemberships();

        memberMemberships.MemberMembershipsName = txtMembershipsName.Text;
        memberMemberships.Sequence = int.Parse(txtSequence.Text);
        memberMemberships.Valid = chkValid.Checked;

        memberMemberships.LastModified = DateTime.Now;
        memberMemberships.LastModifiedBy = SessionData.AdminUser.AdminUserId;

        if (MemberMembershipsId > 0)
        {
            MemberMembershipsService.Update(memberMemberships);
        }
        else
        {
            memberMemberships.SiteId = SessionData.Site.SiteId;
            MemberMembershipsService.Insert(memberMemberships);
        }

        if (memberMemberships != null)
            memberMemberships.Dispose();

        Response.Redirect("MemberMemberships.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberMemberships.aspx");
    }



    #endregion

    #region Methods


    private void LoadWebParts()
    {
        if (MemberMembershipsId > 0)
        {
            using (JXTPortal.Entities.MemberMemberships memberMemberships =
                MemberMembershipsService.GetByMemberMembershipsId(MemberMembershipsId))
            {
                if (memberMemberships != null && memberMemberships.SiteId == SessionData.Site.SiteId)
                {
                    txtMembershipsName.Text = memberMemberships.MemberMembershipsName;
                    ltlLastModified.Text = memberMemberships.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    txtSequence.Text = memberMemberships.Sequence.ToString();
                    chkValid.Checked = memberMemberships.Valid;

                    if (memberMemberships.LastModified != null)
                        ltlLastModified.Text = ((DateTime)memberMemberships.LastModified).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                    AdminUsersService objAdminUsers = new AdminUsersService();
                    using (JXTPortal.Entities.AdminUsers adminuser = objAdminUsers.GetByAdminUserId(memberMemberships.LastModifiedBy))
                    {
                        ltlLastModifiedBy.Text = adminuser.UserName;
                    }


                }
                else
                    Response.Redirect("MemberMemberships.aspx");

            }
        }
    }


    #endregion

}


