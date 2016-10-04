using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Collections;

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class DynamicPageSearchFields : System.Web.UI.UserControl
    {
        #region Declarations

        private DynamicPagesService _dynamicPagesService;
        private SiteLanguagesService _siteLanguagesService;

        #endregion

        #region Properties

        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }

                return _dynamicPagesService;
            }
        }

        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_siteLanguagesService == null)
                {
                    _siteLanguagesService = new SiteLanguagesService();
                }

                return _siteLanguagesService;
            }
        }

        public int PageSize
        {
            get
            {
                return Common.Utils.GetAppSettingsInt("SitePaging");                
            }
        }

        public int CurrentPage
        {

            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 1;
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
            litMessage.Text = "";

            if (!Page.IsPostBack)
            {
                LoadLanguages();
            }
        }

        #endregion

        #region Methods

        private void LoadLanguages()
        {
            SiteLanguagesService languageService = new SiteLanguagesService();
            using (TList<JXTPortal.Entities.SiteLanguages> languages = languageService.GetBySiteId(SessionData.Site.SiteId))
            {
                ddlLanguage.DataValueField = "LanguageID";
                ddlLanguage.DataTextField = "SiteLanguageName";

                ddlLanguage.DataSource = languages;
                ddlLanguage.DataBind();
            }
        }

        private void SearchDynamicPages()
        {
            int totalCount = 0;
            int pageCount = 0;            

            TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetByKeywords(SessionData.Site.SiteId, txtSearchKeyword.Text, 
                 Convert.ToInt32(ddlLanguage.SelectedValue), null, PageSize, CurrentPage + 1);

            if (dynamicpages.Count > 0)
            {
                pnlSearchResult.Visible = true;                

                totalCount = (int)dynamicpages[0].SourceId;

                ArrayList pagelist = new ArrayList();

                if (totalCount % PageSize == 0)
                {
                    pageCount = totalCount / PageSize;
                }
                else
                {
                    if (totalCount <= PageSize)
                    {
                        pnlSiteSearchPaging.Visible = false;
                    }
                    else
                    {
                        pnlSiteSearchPaging.Visible = true;
                        pageCount = (totalCount / PageSize) + 1;
                    }
                }

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

                rptDynamicPages.DataSource = dynamicpages;
                rptDynamicPages.DataBind();
            }
            else
            {
                litMessage.Visible = true;
                litMessage.Text = "No Result found";
                rptDynamicPages.DataSource = null;
                rptDynamicPages.DataBind();
                rptPage.DataSource = null;
                rptPage.DataBind();
            }
        }

        #endregion

        #region Events

        protected void rptDynamicPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Response.Redirect("~/admin/DynamicPageRevisions.aspx?code=" + e.CommandArgument.ToString());
            }
        }

        protected void rptDynamicPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbSelect = e.Item.FindControl("lbSelect") as LinkButton;
                Literal ltDynamicPageName = e.Item.FindControl("ltDynamicPageName") as Literal;
                Literal ltDynamicPageTitle = e.Item.FindControl("ltDynamicPageTitle") as Literal;
                Literal ltFriendlyName = e.Item.FindControl("ltFriendlyName") as Literal;
                Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;

                JXTPortal.Entities.DynamicPages dynamicpage = e.Item.DataItem as JXTPortal.Entities.DynamicPages;

                lbSelect.CommandArgument = dynamicpage.PageName;
                ltDynamicPageName.Text = dynamicpage.PageName;
                ltDynamicPageTitle.Text = dynamicpage.PageTitle;
                ltFriendlyName.Text = dynamicpage.PageFriendlyName;
                ltLastModified.Text = dynamicpage.LastModified.ToString(SessionData.Site.DateFormat);
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                SearchDynamicPages();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal litPage = e.Item.FindControl("litPage") as Literal;
                litPage.Text = CommonFunction.GetResourceValue("LabelPage") + ":";
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
                lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.Enabled = false;
                    lbPageNo.Font.Underline = false;
                    lbPageNo.ForeColor = System.Drawing.Color.Black;
                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchDynamicPages();
        }

        #endregion
    }
}