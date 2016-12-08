using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace JXTPortal.Website.Admin.reports
{
    public partial class MemberActivity : System.Web.UI.Page
    {
        #region Declarations
        MembersService _membersService;
        SitesService _sitesService;
        #endregion

        #region Properties

        private int CurrentPage
        {

            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }

            set
            {
                this.ViewState["CurrentPage"] = value;
            }


        }
        private int _siteID
        {
            get
            {
                if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser == false)
                {
                    return Convert.ToInt32(SessionData.Site.SiteId);
                }

                if (ddlSite.SelectedItem != null && ddlSite.SelectedValue.Length > 0 && Convert.ToInt32(ddlSite.SelectedValue) > 0)
                {
                    return Convert.ToInt32(ddlSite.SelectedValue);
                }
                return 0;
            }
        }

        MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }
                return _membersService;
            }
        }

        SitesService SitesService
        {
            get
            {
                if (_sitesService == null)
                {
                    _sitesService = new SitesService();
                }
                return _sitesService;
            }
        }

        protected string DateFormat
        {
            get { return SessionData.Site.DateFormat; }
        }
        #endregion

        #region Page
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSite();
            }

            if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != 1)
                pnlSite.Visible = false;

            LoadMemberActivity();
        }
        #endregion

        #region Methods
        private void LoadSite()
        {
            List<JXTPortal.Entities.Sites> sites = new List<JXTPortal.Entities.Sites>();

            if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser == true)
            {
                sites = SitesService.GetAll().OrderBy(s => s.SiteName).ToList();
            }
            else
            {
                sites.Add(SitesService.GetBySiteId(SessionData.Site.SiteId));
                pnlSite.Visible = false;
            }

            ddlSite.DataSource = sites;
            ddlSite.DataTextField = "SiteName";
            ddlSite.DataValueField = "SiteID";
            ddlSite.DataBind();

            ddlSite.Items.Insert(0, new ListItem("-All-", "0"));
            ddlSite.SelectedValue = SessionData.Site.SiteId.ToString();
        }

        private void LoadMemberActivity()
        {
            int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");
            int totalCount = 0;
            int pageCount = 0;

            TList<Entities.Members> members = MembersService.GetPaged("SiteID = " + _siteID.ToString(), "LastModifiedDate DESC, MemberID DESC", CurrentPage, sitePageCount, out totalCount);
            rptMemberActivity.DataSource = members;
            rptMemberActivity.DataBind();

            if (totalCount > 0)
            {
                ArrayList pagelist = new ArrayList();

                if (totalCount % sitePageCount == 0)
                    pageCount = totalCount / sitePageCount;
                else
                    pageCount = (totalCount / sitePageCount) + 1;


                if (CurrentPage >= 10)
                {
                    pagelist.Add("previous");
                }

                int index = (CurrentPage == 0) ? 0 : (CurrentPage) / 10 * 10;
                for (int i = index; i < pageCount; i++)
                {
                    pagelist.Add(i.ToString());

                    if ((i % 10) == 9 && (i < pageCount - 1))
                    {
                        pagelist.Add("next");
                        break;
                    }

                }

                if (pagelist.Count > 1)
                {
                    rptPage.DataSource = pagelist;
                    rptPage.DataBind();
                    rptPage.Visible = true;
                }
                else
                {
                    rptPage.Visible = false;
                }
            }
            else
            {
                rptMemberActivity.Visible = false;
                rptPage.Visible = false;
                lblErrorMsg.Visible = true;
            }
        }
        #endregion

        #region Events
        protected void rptMemberActivity_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hlMember = e.Item.FindControl("hlMember") as HyperLink;
                Literal ltFirstName = e.Item.FindControl("ltFirstName") as Literal;
                Literal ltSurname = e.Item.FindControl("ltSurname") as Literal;
                Literal ltEmail = e.Item.FindControl("ltEmail") as Literal;
                Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;
                Literal ltLastLogon = e.Item.FindControl("ltLastLogon") as Literal;
                Literal ltRegisteredDate = e.Item.FindControl("ltRegisteredDate") as Literal;

                Entities.Members member = e.Item.DataItem as Entities.Members;

                hlMember.Text = member.MemberId.ToString();
                hlMember.NavigateUrl = "/admin/membersedit.aspx?memberid=" + member.MemberId.ToString();
                ltFirstName.Text = HttpUtility.HtmlEncode(member.FirstName);
                ltSurname.Text = HttpUtility.HtmlEncode(member.Surname);
                ltEmail.Text = HttpUtility.HtmlEncode(member.EmailAddress);
                ltLastModified.Text = (member.LastModifiedDate.HasValue) ? member.LastModifiedDate.Value.ToString(DateFormat) : string.Empty;
                ltLastLogon.Text = (member.LastLogon.HasValue) ? member.LastLogon.Value.ToString(DateFormat) : string.Empty;
                ltRegisteredDate.Text = member.RegisteredDate.ToString(DateFormat);
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;

                if (e.Item.DataItem.ToString() == "previous")
                {
                    lbPageNo.Text = "...";
                    lbPageNo.CommandArgument = "prev";
                }
                else if (e.Item.DataItem.ToString() == "next")
                {
                    lbPageNo.Text = "...";
                    lbPageNo.CommandArgument = "next";
                }
                else
                {
                    lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                    lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();
                }

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.Enabled = false;
                    lbPageNo.Font.Underline = false;
                    lbPageNo.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                if (e.CommandArgument.ToString() == "prev")
                {
                    CurrentPage = ((CurrentPage) / 10 * 10 - 1);
                }
                else if (e.CommandArgument.ToString() == "next")
                {
                    CurrentPage = ((CurrentPage + 10) / 10 * 10);
                }
                else
                {
                    CurrentPage = Convert.ToInt32(e.CommandArgument);
                }
                LoadMemberActivity();
            }
        }

        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMemberActivity();
        }

        #endregion

    }
}