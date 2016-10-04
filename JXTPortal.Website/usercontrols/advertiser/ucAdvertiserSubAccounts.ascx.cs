using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Collections;
using System.Configuration;


namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class ucAdvertiserSubAccounts : System.Web.UI.UserControl
    {
        #region Declarations

        private string selectbtntext = "Select";

        #endregion

        #region Properties

        public int CurrentPage
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

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Entities.SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            if (!Page.IsPostBack)
            {
                LoadSubAccounts();
            }

            SetFormValues();
        }

        #endregion

        #region Methods

        private void LoadSubAccounts()
        {
            AdvertiserUsersService aus = new AdvertiserUsersService();
            TList<Entities.AdvertiserUsers> au = aus.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId);
            au.ApplyFilter(delegate(Entities.AdvertiserUsers auser) { return auser.PrimaryAccount == false; });

            int intSitePaging = Common.Utils.GetAppSettingsInt("SitePaging");

            PagedDataSource pds = new PagedDataSource();
            pds.CurrentPageIndex = CurrentPage;
            pds.AllowPaging = true;
            pds.PageSize = intSitePaging;
            pds.DataSource = au;
            
            ArrayList pagelist = new ArrayList();

            int pageCount = 0;

            if (au.Count % intSitePaging == 0)
                pageCount = au.Count / intSitePaging;
            else
                pageCount = (au.Count / intSitePaging) + 1;

            for (int i = 0; i < pageCount; i++)
            {
                pagelist.Add(i);
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

            if (au.Count == 0)
            {
                litMessage.Text = CommonFunction.GetResourceValue("LabelNoResultFound");
            }
            else
            {
                rptSubAccounts.DataSource = pds;
                rptSubAccounts.DataBind();
            }
        }

        private void SetFormValues()
        {

            btnAdvertiserUsers.Text = CommonFunction.GetResourceValue("ButtonAdvertiserUsers");
            
            //selectbtntext = CommonFunction.GetResourceValue("ButtonSelect");

            //Literal litPage = rptPage.Controls[0].FindControl("litPage") as Literal;
            //if (litPage != null)
            //    litPage.Text = CommonFunction.GetResourceValue("LabelPage");
            
        }

        #endregion

        #region Events

        protected void rptSubAccounts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string urlParams = string.Format("AdvertiserUserId={0}", e.CommandArgument);
                Response.Redirect("edit.aspx?" + urlParams, true);
            }
        }

        protected void rptSubAccounts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbSelect = e.Item.FindControl("lbSelect") as LinkButton;
                Label lblUserName = e.Item.FindControl("lblUserName") as Label;
                Label lblFirstName = e.Item.FindControl("lblFirstName") as Label;
                Label lblSurame = e.Item.FindControl("lblSurame") as Label;
                Label lblEmail = e.Item.FindControl("lblEmail") as Label;
                CheckBox cbNewsletter = e.Item.FindControl("cbNewsletter") as CheckBox;
                CheckBox cbValidated = e.Item.FindControl("cbValidated") as CheckBox;
                Label lblLastModified = e.Item.FindControl("lblLastModified") as Label;

                lbSelect.Text = selectbtntext;

                using (JXTPortal.Entities.AdvertiserUsers advertiseruser = e.Item.DataItem as JXTPortal.Entities.AdvertiserUsers)
                {
                    lbSelect.Text = CommonFunction.GetResourceValue("LabelSelect");
                    lbSelect.CommandArgument = advertiseruser.AdvertiserUserId.ToString();
                    lblUserName.Text = advertiseruser.UserName;
                    lblFirstName.Text = advertiseruser.FirstName;
                    lblSurame.Text = advertiseruser.Surname;
                    lblEmail.Text = advertiseruser.Email;
                    cbNewsletter.Checked = advertiseruser.Newsletter;
                    cbValidated.Checked = (advertiseruser.Validated == null) ? false : (bool)advertiseruser.Validated;
                    lblLastModified.Text = (advertiseruser.LastModified == null) ? "" : advertiseruser.LastModified.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                }
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                ((JXTPortal.Website.advertiser.edit)Page).SelectedTabIndex = 1;
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                LoadSubAccounts();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
                lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.CssClass = "active_tnt_link";
                }
            }
        }

        #endregion
    }
}