using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Text;
using System.Configuration;
using JXTPortal.Common;

namespace JXTPortal.Website
{
    public partial class NewsRss : System.Web.UI.Page
    {
        #region Properties

        private const int MaxDescriptionLength = 255;

        private NewsService _NewsService = null;

        public NewsService NewsService
        {

            get
            {
                if (_NewsService == null)
                {
                    _NewsService = new NewsService();
                }
                return _NewsService;
            }
        }

        private NewsCategoriesService _NewsCategoriesService = null;

        public NewsCategoriesService NewsCategoriesService
        {

            get
            {
                if (_NewsCategoriesService == null)
                {
                    _NewsCategoriesService = new NewsCategoriesService();
                }
                return _NewsCategoriesService;
            }
        }

        private SitesService _sitesService = null;

        public SitesService SitesService
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

        private string _category = string.Empty;

        protected string Category
        {
            get
            {
                if ((Request.QueryString["category"] != null))
                {
                    if (Request.QueryString["category"] != null)
                    {
                        _category = Request.QueryString["category"];
                    }
                    return _category;
                }

                return _category;
            }
        }


        private int _newsCategoryID;
        protected int NewsCategoryID
        {
            get
            {
                if ((Request.QueryString["categoryid"] != null))
                {
                    if (int.TryParse((Request.QueryString["categoryid"].Trim()), out _newsCategoryID))
                    {
                        _newsCategoryID = Convert.ToInt32(Request.QueryString["categoryid"]);
                    }
                    return _newsCategoryID;
                }

                return _newsCategoryID;
            }
        }
        private string _keywords;
        private string _categories;
        private string _newstype = string.Empty;
        private string _industry;
        private string _sortby = string.Empty;
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

                return _categories;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNewsRSS();
        }

        protected void LoadNewsRSS()
        {
            Response.ContentType = "text/xml";
            // Set the QueryString feeds
            //SetFields();

            StringBuilder strRSS = new StringBuilder();

            /*
            
        <atom:link href='http://www.jobx.com.au/job/rss.aspx' rel='self'/>
             */
            string url = string.Empty;
            using (Entities.Sites site = SitesService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (!string.IsNullOrWhiteSpace(site.SiteAdminLogoUrl))
                {
                    url = string.Format("http://{0}/media/{1}/{2}", SessionData.Site.SiteUrl, ConfigurationManager.AppSettings["SitesFolder"], site.SiteAdminLogoUrl);
                }
                else
                {
                    url = string.Format("http://{0}/Admin/GetAdminLogo.aspx?SiteID={1}", SessionData.Site.SiteUrl, SessionData.Site.SiteId);
                }
            }

            strRSS.Append(String.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
<rss version=""2.0"">
    <channel>
        <title>{0} News RSS</title>
        <link>http://{0}/</link>
        <description>{1}</description>
        <language>en</language>
        <copyright>Copyright {2} {3}</copyright>
        <lastBuildDate>{4}</lastBuildDate>
        <generator>{3} News RSS generator</generator>
        <managingEditor>webmaster@jobx.com.au</managingEditor>
        <webMaster>webmaster@jobx.com.au</webMaster>
        <image>
            <title>{3}</title>
            <url>{5}</url>
            <link>http://{0}/</link>
            <description>{3} logo</description>
        </image>
", SessionData.Site.SiteUrl, HttpUtility.HtmlEncode(SessionData.Site.SiteDescription), DateTime.Today.Year, HttpUtility.HtmlEncode(SessionData.Site.SiteName),
    String.Format("{0:R}", DateTime.Now), url));

            TList<JXTPortal.Entities.NewsCategories> NewsCategoryList;
            int total = 0;
            NewsCategoryList = NewsCategoriesService.GetPaged(string.Format("SiteID = {0} AND Valid = 1", SessionData.Site.SiteId), "", 0, Int32.MaxValue, out total);

            int newscategoryid = 0;
            foreach (JXTPortal.Entities.NewsCategories category in NewsCategoryList)
            {
                if (category.PageFriendlyName == Category)
                {
                    newscategoryid = category.NewsCategoryId;

                    break;
                }
            }
            using (TList<JXTPortal.Entities.News> news = NewsService.CustomGetNews(SessionData.Site.SiteId, (newscategoryid > 0) ? newscategoryid : (int?)null, Keywords, string.Empty))
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

                foreach (Entities.News n in result)
                {
                    string categoryName = NewsCategoryList.Where(c=>c.NewsCategoryId == n.NewsCategoryId).Select(c=>c.NewsCategoryName).FirstOrDefault();

                    strRSS.Append(String.Format(@"
<item>
    <title>{0}</title>
    <description>{1}</description>
    <link>http://www.{2}/news/{3}/{4}/</link>
    <category>{5}</category>
    <categoryName>{8}</categoryName>
    <pubDate>{6}</pubDate>
    <imageurl>{7}</imageurl>
</item>
", 
 HttpUtility.HtmlEncode(n.Subject).Trim(), 
 HttpUtility.HtmlEncode(n.MetaDescription).Trim(),
 SessionData.Site.SiteUrl, 
 n.PageFriendlyName, 
 n.NewsId, 
 n.NewsCategoryId,
 String.Format("{0:"+SessionData.Site.DateFormat +" hh:mm:ss tt}", n.PostDate), 
 HttpUtility.HtmlEncode(n.ImageUrl),
 string.IsNullOrEmpty(categoryName) ? string.Empty : HttpUtility.HtmlEncode(categoryName)
 ));


                }


            }

            strRSS.Append((@"
    </channel> 
</rss>"));

            ltlRSS.Text = strRSS.ToString();
        }


    }
}
