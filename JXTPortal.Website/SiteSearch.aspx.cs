using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Text;
using System.Data;
using System.Collections;

namespace JXTPortal.Website
{
    public partial class SiteSearch : System.Web.UI.Page
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

        public int sitePageCount
        {
            get
            {
                return Common.Utils.GetAppSettingsInt("SitePaging");
            }
        }


        private int SourceID
        {
            get;
            set;
        }

        string _keyword = string.Empty;
        public string Keyword
        {
            get
            {
                if (string.IsNullOrEmpty(_keyword))
                {
                    _keyword = txtSearchKeyword.Text;
                }

                return _keyword;
            }
            set
            {
                _keyword = value;
                txtSearchKeyword.Text = _keyword;
            }
        }

        int _languageID = -1;
        public int LanguageID
        {

            get
            {
                if (_languageID == -1)
                {
                    _languageID = Convert.ToInt32(ddlLanguage.SelectedValue);
                }
                return _languageID;
            }

            set
            {
                _languageID = value;
                ddlLanguage.SelectedValue = _languageID.ToString();
            }

        }

        #endregion


        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Site Search");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["keywords"] != null && Request.QueryString["language"] != null)
                {
                    Keyword = Request.QueryString["keywords"].ToString();
                    LanguageID = int.Parse(Request.QueryString["language"]);
                    SearchDynamicPages();
                }
                
                LoadLanguages();
            }
            SetFormValues();

        }

        public void SetFormValues()
        {
            btnSearch.Text = CommonFunction.GetResourceValue("ButtonSearch");
            ReqVal_SearchKeyword.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
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

            string kw = Keyword;
            EasyFts fts = new EasyFts();
            kw = fts.ToFtsQuery(Keyword);

            TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetByKeywords(SessionData.Site.SiteId, kw,
                LanguageID, true, sitePageCount, CurrentPage);

            if (dynamicpages.Count > 0)
            {
                pnlSearchResult.Visible = true;
                pnlSearchResultNumbers.Visible = true;

                litResultNumber.Text = Convert.ToString(dynamicpages[0].SourceId);
                totalCount = (int)dynamicpages[0].SourceId;
                

                ArrayList pagelist = new ArrayList();

                if (totalCount % sitePageCount == 0)
                {
                    pageCount = totalCount / sitePageCount;                    
                    if(pageCount > 1)
                        pnlSiteSearchPaging.Visible = true;
                }
                else
                {
                    if (totalCount <= sitePageCount)
                    {
                        pnlSiteSearchPaging.Visible = false;
                    }
                    else
                    {
                        pageCount = (totalCount / sitePageCount) + 1;
                        pnlSiteSearchPaging.Visible = true;
                    }
                }


                SourceID = pageCount;

                List<PagingClass> pagingClassList = new List<PagingClass>();
                PagingClass pagingClass = null;

                for (int i = 1; i <= pageCount; i++)
                {
                    pagingClass = new PagingClass();
                    pagingClass.PageNo = i.ToString();
                    if (CurrentPage == i)
                        pagingClass.Enabled = false;
                    else
                        pagingClass.Enabled = true;

                    pagingClassList.Add(pagingClass);
                }

                rptPage.DataSource = pagingClassList;
                rptPage.DataBind();

                rptSiteSearch.DataSource = dynamicpages;
                rptSiteSearch.DataBind();


            }
            else
            {
                rptSiteSearch.DataSource = null;
                rptSiteSearch.DataBind();
                rptPage.DataSource = null;
                rptPage.DataBind();
                pnlSearchResultNumbers.Visible = true;
                litResultNumber.Text = "0";
            }            
        }

        #endregion

        #region Events

        protected void rptSiteSearch_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltDynamicPageTitle = e.Item.FindControl("ltDynamicPageTitle") as Literal;
                Literal ltDynamicPageSearchField = e.Item.FindControl("ltDynamicPageSearchField") as Literal;
                Literal ltViewPage = e.Item.FindControl("ltViewPage") as Literal;
                HyperLink hlViewPage = e.Item.FindControl("hlViewPage") as HyperLink;

                JXTPortal.Entities.DynamicPages dynamicpage = e.Item.DataItem as JXTPortal.Entities.DynamicPages;

                ltDynamicPageTitle.Text = dynamicpage.PageTitle;
                string strContent = string.Empty;
                strContent = Common.Utils.StripHTML(dynamicpage.PageContent);

                if (strContent.Length > 200)
                    strContent = strContent.Substring(0, 200);
                ltDynamicPageSearchField.Text = strContent.Trim();

                // Clean Script/Style Tags
                string url = DynamicPagesService.GetDynamicPageLink(dynamicpage, string.Empty);
                url = url.Split(new char[] {'\''}, StringSplitOptions.RemoveEmptyEntries)[1];

                hlViewPage.NavigateUrl = url;
                if (dynamicpage.ParentDynamicPageId == 0 && dynamicpage.PageName.ToLower().Contains("homepage"))
                {
                    hlViewPage.NavigateUrl = "~/";
                }
            }
        }

        protected void rptSiteSearch_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
                SearchDynamicPages();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PagingClass pagingClass = e.Item.DataItem as PagingClass;
                LinkButton lbPageNo = (LinkButton)e.Item.FindControl("lbPageNo");

                lbPageNo.CommandArgument = (Convert.ToInt32(pagingClass.PageNo)).ToString();
                lbPageNo.Text = pagingClass.PageNo.ToString();

                pagingClass.Enabled = (Convert.ToInt32(lbPageNo.CommandArgument) != CurrentPage);

                if (!pagingClass.Enabled)
                {
                    lbPageNo.CssClass = "disabled_tnt_pagination";
                    lbPageNo.Enabled = false;
                }
                else
                {
                    lbPageNo.CssClass = "tnt_pagination";
                    lbPageNo.Enabled = true;
                }
                //
            }
            else if (e.Item.ItemType == ListItemType.Header)
            {

                LinkButton lnkButtonPrevious = (LinkButton)e.Item.FindControl("lnkButtonPrevious");
                //Todo - Translation
                lnkButtonPrevious.Text = CommonFunction.GetResourceValue("LabelPrevious");
                if (CurrentPage <= 1)
                {

                    lnkButtonPrevious.CssClass = "disabled_tnt_pagination";
                    lnkButtonPrevious.Enabled = false;
                }
                else
                {
                    lnkButtonPrevious.CommandArgument = (CurrentPage - 1).ToString();
                }

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

                LinkButton lnkButtonNext = (LinkButton)e.Item.FindControl("lnkButtonNext");
                //Todo - Translation
                lnkButtonNext.Text = CommonFunction.GetResourceValue("LabelNext");

                if (CurrentPage >= SourceID)
                {

                    lnkButtonNext.CssClass = "disabled_tnt_pagination";
                    lnkButtonNext.Enabled = false;
                }
                else
                {
                    lnkButtonNext.CommandArgument = (CurrentPage + 1).ToString();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;

            LanguageID = Convert.ToInt32(ddlLanguage.SelectedValue);
            Keyword = txtSearchKeyword.Text.Trim();

            SearchDynamicPages();
        }

        #endregion

        #region Paging Class

        private class PagingClass
        {
            public string PageNo { get; set; }
            public string PageUrl { get; set; }
            public bool Enabled { get; set; }
        }

        #endregion
    }
}
