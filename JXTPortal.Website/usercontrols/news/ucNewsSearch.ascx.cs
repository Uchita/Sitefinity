using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.news
{
    public partial class ucNewsSearch : System.Web.UI.UserControl
    {
        #region Declarations

        private const int MaxDescriptionLength = 255;
        private NewsService _newsService;

        #endregion

        #region Properties

        NewsService NewsService
        {
            get
            {
                if (_newsService == null)
                {
                    _newsService = new NewsService();
                }
                return _newsService;
            }
        }

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

        private int TotalPageCount
        {
            get;
            set;
        }

        #endregion

        #region Page
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Methods

        private void DoSearch()
        {
            int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
            int totalCount = 0;
            TotalPageCount = 0;

            // ToDo - Create SP for News Search
            string filter = string.Format("SiteID = {0} AND SearchField LIKE '%{1}%'", SessionData.Site.SiteId, tbKeyword.Text);
            TList<Entities.News> news = NewsService.GetPaged(filter, string.Empty, CurrentPage, sitePageCount, out totalCount);

            if (totalCount > 0)
            {
                litResultNumber.Text = totalCount.ToString();

                if (totalCount % sitePageCount == 0)
                    TotalPageCount = totalCount / sitePageCount;
                else
                    TotalPageCount = (totalCount / sitePageCount) + 1;
                if (TotalPageCount > 1)
                {
                    List<PagingClass> pagingClassList = new List<PagingClass>();
                    PagingClass pagingClass = null;
                    for (int i = 0; i < TotalPageCount; i++)
                    {
                        pagingClass = new PagingClass();
                        pagingClass.PageNo = i.ToString();
                        if (CurrentPage == i)
                            pagingClass.Enabled = false;
                        else
                            pagingClass.Enabled = true;

                        pagingClassList.Add(pagingClass);
                    }

                    rptPaging.DataSource = pagingClassList;
                    rptPaging.DataBind();
                }
                else
                {
                    rptPaging.Visible = false;
                }

                rptNewsResults.DataSource = news;
                rptNewsResults.DataBind();
                pnlSearchResult.Visible = true;
            }
            else
            {
                litResultNumber.Text = "0";
                rptPaging.DataSource = null;
                rptPaging.DataBind();

                rptNewsResults.DataSource = null;
                rptNewsResults.DataBind();
            }
        }

        #endregion

        #region Events

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        protected void rptNewsResults_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptNewsResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltlNews = e.Item.FindControl("ltlNews") as Literal;
                Entities.News news = e.Item.DataItem as Entities.News;
                string strContent = JXTPortal.Common.Utils.StripHTML(news.Content);
                if (strContent.Length > MaxDescriptionLength)
                {
                    strContent = strContent.Substring(0, MaxDescriptionLength) + "...";
                }

                string strNews = string.Format(@"<div id='job-holder'><div class='job-toplink'>
                <a href='/news/{0}/{1}'>{2}</a></div><div class='job-rightlinks'>
                <span class='dateText'>{3}</span></div>
                <div class='description-text'>{4}</div></div>", news.PageFriendlyName, news.NewsId, news.Subject, news.PostDate.ToString(SessionData.Site.DateFormat), strContent);
                ltlNews.Text = strNews;
            }
        }

        protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PagingClass pagingClass = e.Item.DataItem as PagingClass;
                LinkButton lnkButtonPaging = (LinkButton)e.Item.FindControl("lnkButtonPaging");

                lnkButtonPaging.CommandArgument = (Convert.ToInt32(pagingClass.PageNo) - 1).ToString();
                lnkButtonPaging.Text = pagingClass.PageNo.ToString();

                if (!pagingClass.Enabled)
                {
                    lnkButtonPaging.CssClass = "disabled_tnt_pagination";
                    lnkButtonPaging.Enabled = false;
                }
                //
            }
            else if (e.Item.ItemType == ListItemType.Header)
            {

                LinkButton lnkButtonPrevious = (LinkButton)e.Item.FindControl("lnkButtonPrevious");
                //Todo - Translation
                lnkButtonPrevious.Text = CommonFunction.GetResourceValue("LabelPrevious");
                if (SessionData.JobSearch.PageIndex <= 0)
                {

                    lnkButtonPrevious.CssClass = "disabled_tnt_pagination";
                    lnkButtonPrevious.Enabled = false;
                }
                else
                {
                    lnkButtonPrevious.CommandArgument = (SessionData.JobSearch.PageIndex - 1).ToString();
                }

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

                LinkButton lnkButtonNext = (LinkButton)e.Item.FindControl("lnkButtonNext");
                lnkButtonNext.Text = CommonFunction.GetResourceValue("LabelNext");

                if (SessionData.JobSearch.PageIndex >= TotalPageCount - 1)
                {

                    lnkButtonNext.CssClass = "disabled_tnt_pagination";
                    lnkButtonNext.Enabled = false;
                }
                else
                {
                    lnkButtonNext.CommandArgument = (SessionData.JobSearch.PageIndex + 1).ToString();
                }
            }
        }

        protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("paging"))
            {
                SessionData.JobSearch.PageIndex = Convert.ToInt32(e.CommandArgument.ToString());

                // Search again
                DoSearch();
            }

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