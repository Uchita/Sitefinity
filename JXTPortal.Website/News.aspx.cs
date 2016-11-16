using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.ComponentModel;
using System.Text;

using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website
{
    public partial class News : System.Web.UI.Page
    {
        #region Declarations

        private NewsService _newsservice;
        private NewsCategoriesService _newscategoriesservice;
        private NewsTypeService _newstypeservice;
        private NewsIndustryService _newsindustryservice;
        private GlobalSettingsService _globalsettingsservice;
        private int _newsid;
        private int _year;
        private int _month;
        private int _day;
        private string _keywords;
        private string _subject;
        private string _category;
        private string _categories;
        private string _newstype = string.Empty;
        private string _industry;
        private string _sortby = string.Empty;
        private TList<JXTPortal.Entities.NewsType> NewsTypeList;
        private TList<JXTPortal.Entities.NewsIndustry> NewsIndustryList;
        private TList<JXTPortal.Entities.NewsCategories> NewsCategoryList;
        private int TotalPages;
        #endregion

        #region Properties

        private NewsService NewsService
        {
            get
            {
                if (_newsservice == null)
                {
                    _newsservice = new NewsService();
                }
                return _newsservice;
            }
        }

        private NewsCategoriesService NewsCategoriesService
        {
            get
            {
                if (_newscategoriesservice == null)
                {
                    _newscategoriesservice = new NewsCategoriesService();
                }
                return _newscategoriesservice;
            }
        }

        private NewsTypeService NewsTypeService
        {
            get
            {
                if (_newstypeservice == null)
                {
                    _newstypeservice = new NewsTypeService();
                }
                return _newstypeservice;
            }
        }

        private NewsIndustryService NewsIndustryService
        {
            get
            {
                if (_newsindustryservice == null)
                {
                    _newsindustryservice = new NewsIndustryService();
                }
                return _newsindustryservice;
            }
        }

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalsettingsservice == null)
                {
                    _globalsettingsservice = new GlobalSettingsService();
                }
                return _globalsettingsservice;
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

        protected int NewsID
        {
            get
            {
                if ((Request.QueryString["newsid"] != null))
                {
                    if (int.TryParse((Request.QueryString["newsid"].Trim()), out _newsid))
                    {
                        _newsid = Convert.ToInt32(Request.QueryString["newsid"]);
                    }
                    return _newsid;
                }

                return _newsid;
            }
        }

        protected int Year
        {
            get
            {
                if ((Request.QueryString["year"] != null))
                {
                    if (int.TryParse((Request.QueryString["year"].Trim()), out _year))
                    {
                        _year = Convert.ToInt32(Request.QueryString["year"]);
                    }
                    return _year;
                }

                return _year;
            }
        }

        protected int Month
        {
            get
            {
                if ((Request.QueryString["month"] != null))
                {
                    if (int.TryParse((Request.QueryString["month"].Trim()), out _month))
                    {
                        _month = Convert.ToInt32(Request.QueryString["month"]);
                    }
                    return _month;
                }

                return _month;
            }
        }

        protected int Day
        {
            get
            {
                if ((Request.QueryString["day"] != null))
                {
                    if (int.TryParse((Request.QueryString["day"].Trim()), out _day))
                    {
                        _day = Convert.ToInt32(Request.QueryString["day"]);
                    }
                    return _day;
                }

                return _day;
            }
        }

        protected string Subject
        {
            get
            {
                if ((Request.QueryString["subject"] != null))
                {
                    if (Request.QueryString["subject"] != null)
                    {
                        _subject = Request.QueryString["subject"];
                    }
                    return _subject;
                }

                return _subject;
            }
        }

        protected string Category
        {
            get
            {
                if ((Request.QueryString["category"] != null))
                {
                    if (Request.QueryString["category"] != null)
                    {
                        _category = Request.QueryString["category"];
                        _category = _category.Replace("/", "");
                    }
                    return _category;
                }

                return _category;
            }
        }

        protected string Categories
        {
            get
            {
                if ((Request.QueryString["categories"] != null))
                {
                    if (Request.QueryString["categories"] != null)
                    {
                        _categories = Request.QueryString["categories"];
                    }
                    return _categories;
                }

                return _subject;
            }
        }

        protected string NewsTypes
        {
            get
            {
                if (Request.QueryString["newstypes"] != null)
                {
                    _newstype = Request.QueryString["newstypes"];
                }
                return _newstype;
            }
        }

        protected string NewsIndustries
        {
            get
            {
                if ((Request.QueryString["newsindustries"] != null))
                {
                    _industry = Request.QueryString["newsindustries"];
                    return _industry;
                }

                return _industry;
            }
        }

        protected string SortBy
        {
            get
            {
                if ((Request.QueryString["sortby"] != null))
                {
                    _industry = Request.QueryString["sortby"];
                    return _industry;
                }

                return _industry;
            }
        }

        protected string Keywords
        {
            get
            {
                if ((Request.QueryString["keywords"] != null))
                {
                    _keywords = Request.QueryString["keywords"];
                    return _keywords;
                }

                return _keywords;
            }
        }


        #endregion

        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.Action = Request.RawUrl;
            LoadNewsType();
            LoadNewsCategory();
            LoadNewsIndustry();

            hlNewsRss.NavigateUrl = "/newsrss.aspx" + Request.Url.Query;
            aSortLatest.InnerText = CommonFunction.GetResourceValue("LabelLatest");
            aSortOldest.InnerText = CommonFunction.GetResourceValue("LabelOldest");
            aSortAZ.InnerText = CommonFunction.GetResourceValue("LabelAZ");
            aSortZA.InnerText = CommonFunction.GetResourceValue("LabelZA");

            if (!Page.IsPostBack)
            {
                if (NewsID > 0)
                {
                    LoadNewsArticle();
                }
                else
                {
                    SetNewsMeta();
                    LoadAllNews();

                    tbKeywords.Text = Keywords;
                }

                if (string.IsNullOrWhiteSpace(SortBy) || SortBy == "latest")
                {
                    aSortLatest.Attributes.Add("class", "active");
                    ltSortBy.Text = aSortLatest.InnerText;
                }

                if (SortBy == "oldest")
                {
                    aSortOldest.Attributes.Add("class", "active");
                    ltSortBy.Text = aSortOldest.InnerText;
                }

                if (SortBy == "az")
                {
                    aSortAZ.Attributes.Add("class", "active");
                    ltSortBy.Text = aSortAZ.InnerText;
                }

                if (SortBy == "za")
                {
                    aSortZA.Attributes.Add("class", "active");
                    ltSortBy.Text = aSortZA.InnerText;
                }
            }
            else
            {
                string filter = string.Empty;
                string selectedCategories = hfCategories.Value.Trim(new char[] { ',' });
                string selectedTypes = hfNewsType.Value.Trim(new char[] { ',' });
                string selectedIndustries = hfNewsIndustry.Value.Trim(new char[] { ',' });
                string sortby = hfSortBy.Value;

                if (string.IsNullOrWhiteSpace(sortby))
                    return;

                filter = "sortby=" + sortby;

                if (!string.IsNullOrWhiteSpace(tbKeywords.Text))
                {
                    filter += "&keywords=" + HttpUtility.UrlEncode(tbKeywords.Text);
                }

                if (!string.IsNullOrWhiteSpace(selectedCategories))
                {
                    filter += "&categories=" + selectedCategories;
                }

                if (!string.IsNullOrWhiteSpace(selectedTypes))
                {
                    filter += "&newstypes=" + selectedTypes;
                }

                if (!string.IsNullOrWhiteSpace(selectedIndustries))
                {
                    filter += "&newsindustries=" + selectedIndustries;
                }

                Response.Redirect(string.Format("~/news.aspx?{0}", filter), true);
            }
        }

        private void LoadNewsType()
        {
            int total = 0;
            NewsTypeList = NewsTypeService.GetPaged(string.Format("SiteID = {0} AND GlobalTemplate = 0", SessionData.Site.SiteId), "Sequence", 0, Int32.MaxValue, out total);

            rptType.DataSource = NewsTypeList;
            rptType.DataBind();
            phRefineType.Visible = (NewsTypeList.Count > 0);
        }

        protected void rptType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlAnchor lbType = e.Item.FindControl("lbType") as HtmlAnchor;
                HiddenField hfNewsTypeID = e.Item.FindControl("hfNewsTypeID") as HiddenField;
                Entities.NewsType newstype = e.Item.DataItem as Entities.NewsType;

                lbType.InnerHtml = HttpUtility.HtmlEncode(newstype.NewsTypeName);
                hfNewsTypeID.Value = newstype.NewsTypeId.ToString();

                if (!string.IsNullOrWhiteSpace(NewsTypes))
                {
                    string[] splits = NewsTypes.Split(new char[] { ',' });
                    foreach (string s in splits)
                    {
                        if (newstype.NewsTypeId.ToString() == s)
                        {
                            lbType.Attributes.Add("class", "active");
                            break;
                        }
                    }
                }
            }


        }

        private void LoadNewsIndustry()
        {
            int total = 0;
            NewsIndustryList = NewsIndustryService.GetPaged(string.Format("SiteID = {0} AND GlobalTemplate = 0", SessionData.Site.SiteId), "Sequence", 0, Int32.MaxValue, out total);

            rptIndustries.DataSource = NewsIndustryList;
            rptIndustries.DataBind();

            phRefineIndustry.Visible = (NewsIndustryList.Count > 0);

        }

        protected void rptIndustries_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlAnchor lbIndustry = e.Item.FindControl("lbIndustry") as HtmlAnchor;
                HiddenField hfNewsIndustryID = e.Item.FindControl("hfNewsIndustryID") as HiddenField;

                Entities.NewsIndustry newsindustry = e.Item.DataItem as Entities.NewsIndustry;

                lbIndustry.InnerHtml = HttpUtility.HtmlEncode(newsindustry.NewsIndustryName);
                hfNewsIndustryID.Value = newsindustry.NewsIndustryId.ToString();

                if (!string.IsNullOrWhiteSpace(NewsIndustries))
                {
                    string[] splits = NewsIndustries.Split(new char[] { ',' });
                    foreach (string s in splits)
                    {
                        if (newsindustry.NewsIndustryId.ToString() == s)
                        {
                            lbIndustry.Attributes.Add("class", "active");
                            break;
                        }
                    }
                }
            }

        }

        private void LoadNewsCategory()
        {
            int total = 0;
            NewsCategoryList = NewsCategoriesService.GetPaged(string.Format("SiteID = {0} AND Valid = 1", SessionData.Site.SiteId), "Sequence", 0, Int32.MaxValue, out total);

            rptCategories.DataSource = NewsCategoryList;
            rptCategories.DataBind();

            phRefineCategory.Visible = (NewsCategoryList.Count > 0);
        }

        protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlAnchor lbCategory = e.Item.FindControl("lbCategory") as HtmlAnchor;
                HiddenField hfNewsCategoryID = e.Item.FindControl("hfNewsCategoryID") as HiddenField;
                Entities.NewsCategories newscategory = e.Item.DataItem as Entities.NewsCategories;

                lbCategory.InnerHtml = HttpUtility.HtmlEncode(newscategory.NewsCategoryName);
                hfNewsCategoryID.Value = newscategory.NewsCategoryId.ToString();


                if (!string.IsNullOrWhiteSpace(Categories))
                {
                    string[] splits = Categories.Split(new char[] { ',' });
                    foreach (string s in splits)
                    {
                        if (newscategory.NewsCategoryId.ToString() == s)
                        {
                            lbCategory.Attributes.Add("class", "active");
                            break;
                        }
                    }
                }

                if (Category == newscategory.PageFriendlyName)
                {
                    lbCategory.Attributes.Add("class", "active");
                }
            }
        }

        protected void lbRefine_Click(object sender, EventArgs e)
        {

        }

        private void SetNewsMeta()
        {
            TList<GlobalSettings> settings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId);
            if (settings.Count > 0)
            {
                GlobalSettings globalSettings = settings[0];

                Literal ltlMetaContent = Page.Master.FindControl("ltlMetaContent") as Literal;
                string strMetaDescription = globalSettings.DefaultDescription;
                string strMetaKeywords = globalSettings.DefaultKeywords;

                StringBuilder sb = new StringBuilder(ltlMetaContent.Text);
                string s = string.Format(@"
                                            <meta name=""description"" content=""{0}"" />
                                            <meta name=""keywords"" content=""{1}"" />", Utils.RemoveMetaSpecialCharacters(strMetaDescription, JXTPortal.Entities.SessionData.Language.LanguageId), Utils.RemoveMetaSpecialCharacters(strMetaKeywords, JXTPortal.Entities.SessionData.Language.LanguageId));

                ltlMetaContent.Text = sb.AppendLine(s).ToString();
            }
        }

        #endregion

        #region Methods

        private void LoadNewsArticle()
        {
            mvNews.ActiveViewIndex = 1;
            using (JXTPortal.Entities.News news = NewsService.GetByNewsId(NewsID))
            {
                if (news != null && (news.SiteId == SessionData.Site.SiteId))
                {
                    if ((news.Valid.HasValue && news.Valid.Value == true) || news.Valid.HasValue == false)
                    {
                        // Page Title
                        CommonPage.SetBrowserPageTitle(Page, !string.IsNullOrWhiteSpace(news.MetaTitle) ? news.MetaTitle : news.Subject);

                        ltDetailArticleStartTag.Text = "<article class=\"jxt-news-item jxt-has-image\" itemscope=\"\" itemtype=\"http://schema.org/NewsArticle\">";
                        string url = string.Format("/news/{0}/{1}/", news.PageFriendlyName, news.NewsId);
                        ltDetailSubject.Text = ltDetailSubject.Text = news.Subject;
                        ltDetailBreadcrumb.Text = string.Format("<a itemprop='item' href='{0}'><span itemprop='name'>{1}</span></a>", url, news.Subject);
                        /*phDetailImage.Visible = false;
                        if (string.IsNullOrWhiteSpace(news.ImageUrl))
                        {
                            ltDetailArticleStartTag.Text = "<article class=\"jxt-news-item\" itemscope=\"\" itemtype=\"http://schema.org/NewsArticle\">";
                        }
                        else
                        {
                            phDetailImage.Visible = true;
                        }*/
                        ltDetailMeta.Text = string.Format("<meta itemprop=\"mainEntityOfPage\" content=\"{0}\" />", ((Request.IsSecureConnection) ? "https://" : "http://") + Request.Url.Host + url);

                        //imgDetailNews.ImageUrl = news.ImageUrl;
                        ltDetailDescription.Text = news.Content.Trim();
                        if (!string.IsNullOrWhiteSpace(news.NewsTypeIds))
                        {
                            string[] typesplit = news.NewsTypeIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            if (typesplit.Length > 0)
                            {
                                foreach (string type in typesplit)
                                {
                                    foreach (JXTPortal.Entities.NewsType newstype in NewsTypeList)
                                    {
                                        if (newstype.NewsTypeId.ToString() == type)
                                        {
                                            if (!string.IsNullOrWhiteSpace(newstype.ImageUrl))
                                            {
                                                ltDetailNewsType.Text += string.Format("<a href=\"/news.aspx?newstypes={0}\"><img src=\"{1}\" alt=\"{2}\">{3}</a>", newstype.NewsTypeId, newstype.ImageUrl, newstype.NewsTypeName.Replace("\"", ""), HttpUtility.HtmlEncode(newstype.NewsTypeName));
                                            }
                                            else
                                            {
                                                ltDetailNewsType.Text += string.Format("<a href=\"/news.aspx?newstypes={0}\">{1}</a>", newstype.NewsTypeId, HttpUtility.HtmlEncode(newstype.NewsTypeName));
                                            }

                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                phDetailNewsType.Visible = false;
                            }
                        }
                        else
                        {
                            phDetailNewsType.Visible = false;
                        }

                        foreach (Entities.NewsCategories newscategory in NewsCategoryList)
                        {
                            if (newscategory.NewsCategoryId == news.NewsCategoryId)
                            {
                                ltDetailCategory.Text = string.Format("<a href=\"/news/category/{0}/\">{1}</a>", newscategory.PageFriendlyName, HttpUtility.HtmlEncode(newscategory.NewsCategoryName));

                                LoadRelatedNews(news.NewsCategoryId);
                                break;
                            }
                        }
                        ltDetailDatePublished.Text = news.PostDate.ToString(SessionData.Site.DateFormat);

                        if (news.LastModified.HasValue)
                        {
                            ltDetailDateModified.Text = news.LastModified.Value.ToString(SessionData.Site.DateFormat);
                        }

                        ltDetailAuthor.Text = HttpUtility.HtmlEncode(news.Author);
                        if (string.IsNullOrWhiteSpace(news.Author)) phDetailAuthor.Visible = false;
                        ltDetailSiteName.Text = HttpUtility.HtmlEncode(SessionData.Site.SiteName);
                        ltDetailSiteImage.Text = string.Format(@"<figure itemprop=""logo"" itemscope="""" itemtype=""https://schema.org/ImageObject"">
									            <img src=""{0}"" alt=""{1}"">
									            <meta itemprop=""url"" content=""{0}"">
								            </figure>", "/GetAdminLogo.aspx?SiteID=" + SessionData.Site.SiteId.ToString(), SessionData.Site.SiteName.Replace("\"", ""));
                        //Social Media Share

                        string fbherf = string.Format("http://www.facebook.com/share.php?u={0}", Server.UrlEncode("http://" + SessionData.Site.SiteUrl + url));
                        string twhref = string.Format("http://twitter.com/intent/tweet?text={0}", Server.UrlEncode("Current Viewing: " + "http://" + SessionData.Site.SiteUrl + url));
                        string lnhref = string.Format("http://www.linkedin.com/shareArticle?mini=true&amp;url={0}&amp;title={1}&amp;source={2}",
                                                        "http://" + SessionData.Site.SiteUrl + url, Server.UrlEncode(news.Subject), Server.UrlEncode(SessionData.Site.SiteName));
                        string googlePlusHref = string.Format("https://plus.google.com/share?url={0}", Server.UrlEncode("http://" + SessionData.Site.SiteUrl + url));

                        ltShare.Text = string.Format(@"<div class='jxt-news-item-share'>
						<ul>
                <li><a href='{0}' target='_blank' title='Facebook'><i class='fa fa-facebook'></i></a></li>
                <li><a href='{1}' target='_blank' title='Twitter'><i class='fa fa-twitter'></i></a></li>
                <li><a href='{2}' target='_blank' title='LinkedIn'><i class='fa fa-linkedin'></i></a></li>
                <li><a href='{3}' target='_blank' title='Google Plus'><i class='fa fa-google-plus'></i></a></li>

                        </ul>
					</div>", fbherf, twhref, lnhref, googlePlusHref);
                    }
                }
                else
                {
                    Response.Redirect("~/news/");
                }
            }
        }


        private void LoadRelatedNews(int newscategoryid)
        {
            using (TList<JXTPortal.Entities.News> news = NewsService.CustomGetNews(SessionData.Site.SiteId, newscategoryid, string.Empty, string.Empty))
            {
                var result = news.Where(n => n.NewsId != NewsID);
                result = result.OrderByDescending(n => n.PostDate);
                var topresult = result.Take(2);

                rptRelatedArticles.DataSource = topresult;
                rptRelatedArticles.DataBind();

                phRelatedArticles.Visible = (topresult.ToList().Count > 0);
            }
        }

        protected void rptRelatedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltSubject = e.Item.FindControl("ltSubject") as Literal;
                Literal ltDescription = e.Item.FindControl("ltDescription") as Literal;
                HyperLink hlReadMore = e.Item.FindControl("hlReadMore") as HyperLink;

                Entities.News news = e.Item.DataItem as Entities.News;

                String strContent = string.Empty;
                strContent = Common.Utils.StripHTML(news.Content);
                if (strContent.Length > 100)
                {
                    if (strContent.IndexOf(" ", 100) > 0)
                        strContent = strContent.Substring(0, strContent.IndexOf(" ", 100)) + " ...";
                    else
                        strContent = strContent.Substring(0, 100) + " ...";
                }
                ltDescription.Text = strContent.Trim();

                string url = string.Format("/news/{0}/{1}/", news.PageFriendlyName, news.NewsId);
                hlReadMore.NavigateUrl = url;

                ltSubject.Text = "<a href='" + url + "' itemprop='mainEntityOfPage' rel='bookmark'>" + news.Subject;
            }
        }
        private void LoadAllNews()
        {
            // Page Title
            CommonPage.SetBrowserPageTitle(Page, "News");
            mvNews.ActiveViewIndex = 0;

            // Add canonical url - /news/
            string canonicalUrl = string.Format("{0}://{1}/news/", (SessionData.Site.EnableSsl ? "https" : "http"), (SessionData.Site.WWWRedirect ? "www." : string.Empty) + SessionData.Site.SiteUrl);
            Literal ltCanonicalUrl = new Literal() { Text = @"<link rel=""canonical"" href=""" + canonicalUrl.Replace("\"", "") + @""" />" };
            Page.Header.Controls.Add(ltCanonicalUrl);

            int intSitePaging = Common.Utils.GetAppSettingsInt("SitePaging");
            int totalCount = 0;

            // ToDo - Change the SP to a custom for sorting
            //using (TList<JXTPortal.Entities.News> news = NewsService.Find(string.Format("SiteID = {0} AND PostDate <= "{1}" AND Valid = true", SessionData.Site.SiteId, DateTime.Now.ToString("yyyy-MM-dd")), CurrentPage * intSitePaging, intSitePaging, out totalCount))

            int newscategoryid = 0;
            foreach (JXTPortal.Entities.NewsCategories category in NewsCategoryList)
            {
                if (category.PageFriendlyName == Category)
                {
                    newscategoryid = category.NewsCategoryId;

                    break;
                }
            }

            string strKeywords = Keywords;
            if (!String.IsNullOrEmpty(strKeywords))
            {
                EasyFts fts = new EasyFts();
                strKeywords = fts.ToFtsQuery(strKeywords);
            }

            using (TList<JXTPortal.Entities.News> news = NewsService.CustomGetNews(SessionData.Site.SiteId, (newscategoryid > 0) ? newscategoryid : (int?)null, strKeywords, string.Empty))
            {
                System.Collections.Generic.IEnumerable<Entities.News> result = null;
                TList<JXTPortal.Entities.News> filterednews = new TList<Entities.News>();
                if (!string.IsNullOrWhiteSpace(NewsTypes))
                {
                    foreach (Entities.News n in news)
                    {
                        if (!string.IsNullOrWhiteSpace(n.NewsTypeIds))
                        {
                            string[] splits = NewsTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            string[] nsplits = n.NewsTypeIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            bool found = false;
                            foreach (string s in splits)
                            {
                                foreach (string ns in nsplits)
                                {
                                    if (s == ns)
                                    {
                                        found = true;
                                        filterednews.Add(n);
                                        break;
                                    }
                                }

                                if (found) break;
                            }
                        }

                    }
                }
                else
                {
                    filterednews = news;
                }

                result = filterednews.Where(n => n.SiteId != 0);
                if (!string.IsNullOrWhiteSpace(NewsIndustries))
                {
                    string[] splits = NewsIndustries.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    result = result.Where(n => splits.Contains(n.NewsIndustryId.ToString()));
                }

                if (!string.IsNullOrWhiteSpace(Categories))
                {
                    string[] splits = Categories.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    result = result.Where(n => splits.Contains(n.NewsCategoryId.ToString()));
                }

                if (string.IsNullOrWhiteSpace(SortBy) || SortBy == "latest")
                {
                    result = result.OrderByDescending(n => n.PostDate);
                }
                else
                {
                    if (SortBy == "oldest")
                    {
                        result = result.OrderBy(n => n.PostDate);
                    }

                    if (SortBy == "az")
                    {
                        result = result.OrderBy(n => n.Subject);
                    }

                    if (SortBy == "za")
                    {
                        result = result.OrderByDescending(n => n.Subject);
                    }
                }
                int count = result.ToList().Count;
                if (!string.IsNullOrWhiteSpace(SortBy))
                {
                    //ltRefineResult.Text = "<p class='jxt-news-refine-summary'>" + CommonFunction.GetResourceValue("LabelShowing") + " <span>" + count.ToString() + "</span> " + CommonFunction.GetResourceValue("LabelResults") + ((string.IsNullOrWhiteSpace(Keywords)) ? "" : " for <strong>&ldquo;" + HttpUtility.HtmlEncode(Keywords) + "&rdquo;</strong>") + "</p>";
                    //Showing <span>{0}</span> results for <strong>{1}</strong>
                    ltRefineResult.Text = "<p class='jxt-news-refine-summary'>" + String.Format(CommonFunction.GetResourceValue("LabelNewsResultsCount"),
                            CommonFunction.GetResourceValue("LabelShowing"),
                            "<span>" + count.ToString() + "</span>",
                            CommonFunction.GetResourceValue("LabelResults"),
                            ((string.IsNullOrWhiteSpace(Keywords)) ? string.Empty : ( CommonFunction.GetResourceValue("LabelFor") + " <strong>&ldquo;" + HttpUtility.HtmlEncode(Keywords) + "&rdquo;</strong>"))) 
                        
                        + "</p>";

                }
                result = result.Skip(intSitePaging * CurrentPage).Take(intSitePaging);
                //PagedDataSource pds = new PagedDataSource();
                //pds.CurrentPageIndex = CurrentPage;
                //pds.AllowPaging = true;
                //pds.PageSize = intSitePaging;
                //pds.DataSource = news;

                rptNews.DataSource = result;
                rptNews.DataBind();

                if (news != null && count > 0)
                {
                    rptNews.Visible = true;
                    LoadPaging(count, intSitePaging);
                }
                else
                {
                    rptNews.Visible = false;
                    // ltNoResult.Visible = true;
                }

                //News Breadcrumbs
                // ltNewsBreadcrumbs.Text = "<a href="" + Request.RawUrl + "">" + "news" + "</a>";
            }
        }

        private void LoadPaging(int totalCount, int intSitePaging)
        {
            ArrayList pagelist = new ArrayList();

            int pageCount = 0;

            if (totalCount % intSitePaging == 0)
                pageCount = totalCount / intSitePaging;
            else
                pageCount = (totalCount / intSitePaging) + 1;

            TotalPages = pageCount;

            if (CurrentPage == 0) // First Page
            {
                for (int i = 0; i < pageCount && i < 3; i++)
                {
                    pagelist.Add(i);
                }
            }
            else
            {
                if (CurrentPage == TotalPages - 1) // Last Page
                {
                    int StartPage = TotalPages - 3;
                    if (StartPage < 0)
                    {
                        StartPage = 0;
                    }

                    for (int i = StartPage; i < pageCount && i >= 0; i++)
                    {
                        pagelist.Add(i);
                    }
                }
            }

            if (CurrentPage != 0 && CurrentPage != TotalPages - 1)
            {
                for (int i = CurrentPage - 1; i <= CurrentPage + 1 && i < TotalPages && i >= 0; i++)
                {
                    pagelist.Add(i);
                }
            }

            if (pagelist.Count > 1)
            {
                rptNewsPages.DataSource = pagelist;
                rptNewsPages.DataBind();
                rptNewsPages.Visible = true;
            }
            else
            {
                rptNewsPages.Visible = false;
            }
        }


        #endregion

        #region Event

        protected void rptNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                JXTPortal.Entities.News news = e.Item.DataItem as JXTPortal.Entities.News;

                Literal ltArticleStartTag = e.Item.FindControl("ltArticleStartTag") as Literal;
                HyperLink hlNewsTitle = e.Item.FindControl("hlNewsTitle") as HyperLink;
                PlaceHolder plImage = e.Item.FindControl("plImage") as PlaceHolder;
                Literal ltMeta = e.Item.FindControl("ltMeta") as Literal;
                Literal ltDescription = e.Item.FindControl("ltDescription") as Literal;
                Literal ltPostType = e.Item.FindControl("ltPostType") as Literal;
                Literal ltNewsCategory = e.Item.FindControl("ltNewsCategory") as Literal;
                Literal ltDatePublished = e.Item.FindControl("ltDatePublished") as Literal;
                Literal ltDateModified = e.Item.FindControl("ltDateModified") as Literal;
                Literal ltAuthor = e.Item.FindControl("ltAuthor") as Literal;
                Literal ltSiteName = e.Item.FindControl("ltSiteName") as Literal;
                Literal ltSiteImage = e.Item.FindControl("ltSiteImage") as Literal;
                PlaceHolder phNewsType = e.Item.FindControl("phNewsType") as PlaceHolder;
                PlaceHolder phNewsCategory = e.Item.FindControl("phNewsCategory") as PlaceHolder;
                PlaceHolder phAuthor = e.Item.FindControl("phAuthor") as PlaceHolder;

                ltArticleStartTag.Text = "<article class=\"jxt-news-item jxt-has-image\" itemscope=\"\" itemtype=\"http://schema.org/NewsArticle\">";
                hlNewsTitle.Text = news.Subject;
                string url = string.Format("/news/{0}/{1}/", news.PageFriendlyName, news.NewsId);
                hlNewsTitle.NavigateUrl = url;

                if (string.IsNullOrWhiteSpace(news.ImageUrl))
                {
                    ltArticleStartTag.Text = "<article class=\"jxt-news-item\" itemscope=\"\" itemtype=\"http://schema.org/NewsArticle\">";
                }
                else
                {
                    plImage.Visible = true;
                }
                ltMeta.Text = string.Format("<img src=\"{0}\" alt=\"{1}\" /><meta itemprop=\"url\" content=\"{0}\" />", news.ImageUrl, news.Subject.Replace("\"", ""));
                String strContent = string.Empty;
                strContent = Common.Utils.StripHTML(news.Content);
                if (strContent.Length > 200)
                {
                    if (strContent.IndexOf(" ", 200) > 0)
                        strContent = strContent.Substring(0, strContent.IndexOfAny(new char[] { ' ', '\n', '　', '。', '，' }, 200)) + " ..."; // Added Chinese charaters for cut off the string
                    else
                        strContent = strContent.Substring(0, 200) + " ...";
                }
                ltDescription.Text = strContent.Trim();
                if (!string.IsNullOrWhiteSpace(news.NewsTypeIds))
                {
                    string[] typesplit = news.NewsTypeIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (typesplit.Length > 0)
                    {
                        foreach (string type in typesplit)
                        {
                            foreach (JXTPortal.Entities.NewsType newstype in NewsTypeList)
                            {
                                if (newstype.NewsTypeId.ToString() == type)
                                {
                                    if (!string.IsNullOrWhiteSpace(newstype.ImageUrl))
                                    {
                                        ltPostType.Text += string.Format("<a href=\"/news.aspx?newstype={0}\"><img src=\"{1}\" alt=\"{2}\">{3}</a>", newstype.NewsTypeId, newstype.ImageUrl, newstype.NewsTypeName.Replace("\"", ""), HttpUtility.HtmlEncode(newstype.NewsTypeName));
                                    }
                                    else
                                    {
                                        ltPostType.Text += string.Format("<a href=\"/news.aspx?newstypes={0}\">{1}</a>", newstype.NewsTypeId, HttpUtility.HtmlEncode(newstype.NewsTypeName));
                                    }

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        phNewsType.Visible = false;
                    }
                }
                else
                {
                    phNewsType.Visible = false;
                }

                foreach (Entities.NewsCategories newscategory in NewsCategoryList)
                {
                    if (newscategory.NewsCategoryId == news.NewsCategoryId)
                    {
                        ltNewsCategory.Text = string.Format("<a href=\"/news/category/{0}/\">{1}</a>", newscategory.PageFriendlyName, HttpUtility.HtmlEncode(newscategory.NewsCategoryName));
                        break;
                    }
                }
                ltDatePublished.Text = news.PostDate.ToString(SessionData.Site.DateFormat);

                if (news.LastModified.HasValue)
                {
                    ltDateModified.Text = news.LastModified.Value.ToString(SessionData.Site.DateFormat);
                }

                ltAuthor.Text = HttpUtility.HtmlEncode(news.Author);
                if (string.IsNullOrWhiteSpace(news.Author)) phAuthor.Visible = false;
                ltSiteName.Text = HttpUtility.HtmlEncode(SessionData.Site.SiteName);
                ltSiteImage.Text = string.Format(@"<figure itemprop=""logo"" itemscope="""" itemtype=""https://schema.org/ImageObject"">
									            <img src=""{0}"" alt=""{1}"">
									            <meta itemprop=""url"" content=""{0}"">
								            </figure>", "/GetAdminLogo.aspx?SiteID=" + SessionData.Site.SiteId.ToString(), SessionData.Site.SiteName.Replace("\"", ""));


            }
        }


        #endregion

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                LinkButton lbPrevious = e.Item.FindControl("lbPrevious") as LinkButton;
                LinkButton lbNext = e.Item.FindControl("lbNext") as LinkButton;
                LinkButton lbFirst = e.Item.FindControl("lbFirst") as LinkButton;
                PlaceHolder phDots = e.Item.FindControl("phDots") as PlaceHolder;

                if (CurrentPage > 0)
                {
                    lbPrevious.CommandArgument = (CurrentPage - 1).ToString();
                }
                else
                {
                    lbPrevious.CommandArgument = "0";
                }

                if (CurrentPage == TotalPages - 1)
                {
                    lbNext.CommandArgument = (TotalPages - 1).ToString();
                }
                else
                {
                    lbNext.CommandArgument = (CurrentPage + 1).ToString();
                }

                lbFirst.CommandArgument = "0";

                lbFirst.Visible = (TotalPages > 3 && CurrentPage >= 2);
                phDots.Visible = (TotalPages > 3 && CurrentPage >= 2);
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
                Literal ltPage = e.Item.FindControl("ltPage") as Literal;

                ltPage.Text = "<li>";
                lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    ltPage.Text = "<li class=\"active\">";

                    lbPageNo.Enabled = false;
                    lbPageNo.Font.Underline = false;
                }
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                PlaceHolder phDots = e.Item.FindControl("phDots") as PlaceHolder;
                LinkButton lbLastPage = e.Item.FindControl("lbLastPage") as LinkButton;
                lbLastPage.Text = TotalPages.ToString();
                lbLastPage.CommandArgument = (TotalPages - 1).ToString();

                lbLastPage.Visible = (TotalPages > 3 && CurrentPage < TotalPages - 2);
                phDots.Visible = (TotalPages > 3 && CurrentPage < TotalPages - 2);
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);

                if (NewsID <= 0)
                {
                    LoadAllNews();
                }
            }
        }
    }
}
