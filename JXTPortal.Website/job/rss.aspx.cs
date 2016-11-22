using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using JXTPortal.Entities;
using System.Configuration;
using JXTPortal.Common;

namespace JXTPortal.Website.job
{
    public partial class rss : System.Web.UI.Page
    {
        #region Declarations

        string keywords = string.Empty;
        int? professionID, countryID, locationID, currencyID, worktypeID, salarytypeID, advertiserID;
        decimal? salaryLowerBand, salaryUpperBand;
        string roleIDs = string.Empty, areaIDs = string.Empty, jobTypes = string.Empty;
        int _max = 0;
        bool? _hotjob = (bool?)null;
        bool? _addlocation = (bool?)null;
        bool? _addworktype = (bool?)null;
        bool? _addprofession = (bool?)null;

        #endregion

        #region Properties

        private int Max
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["max"]))
                {
                    int.TryParse(Request.QueryString["max"], out _max);
                }
                return _max;
            }
        }

        private bool? HotJob
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["hotjob"]))
                {
                    try
                    {
                        _hotjob = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["hotjob"]));
                    }
                    catch (Exception ex) { }
                }

                return _hotjob;
            }
        }

        private bool? AddLocation
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["addlocation"]))
                {
                    try
                    {
                        _addlocation = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["addlocation"]));
                    }
                    catch (Exception ex) { }
                }

                return _addlocation;
            }
        }

        private bool AddLocationToTitle
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["addlocationtotitle"]) & Request.QueryString["addlocationtotitle"] == "1")
                {
                    return true;
                }

                return false;
            }
        }

        private bool? AddWorktype
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["addworktype"]))
                {
                    try
                    {
                        _addworktype = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["addworktype"]));
                    }
                    catch (Exception ex) { }
                }

                return _addworktype;
            }
        }

        private bool? AddProfession
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["addprofession"]))
                {
                    try
                    {
                        _addprofession = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["addprofession"]));
                    }
                    catch (Exception ex) { }
                }

                return _addprofession;
            }
        }

        public int? PagingCount
        {
            get
            {
                return CommonFunction.GetInt(ConfigurationManager.AppSettings["AdvancedSearchPaging"]);
            }
        }

        private ViewJobSearchService _viewJobSearchService = null;

        public ViewJobSearchService ViewJobSearchService
        {

            get
            {
                if (_viewJobSearchService == null)
                {
                    _viewJobSearchService = new ViewJobSearchService();
                }
                return _viewJobSearchService;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadJobRSS();
        }

        protected void LoadJobRSS()
        {
            Response.ContentType = "text/xml";
            // Set the QueryString feeds
            SetFields();

            StringBuilder strRSS = new StringBuilder();

            /*
            
        <atom:link href='http://www.jobx.com.au/job/rss.aspx' rel='self'/>
             */
            strRSS.Append(String.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
                                        <rss version=""2.0"">
                                            <channel>
                                                <title>{0} RSS</title>
                                                <link>http://{0}/</link>
                                                <description>{1}</description>
                                                <language>en</language>
                                                <copyright>Copyright {2} {3}</copyright>
                                                <lastBuildDate>{4}</lastBuildDate>
                                                <generator>{3} RSS generator</generator>
                                                <managingEditor>webmaster@jobx.com.au</managingEditor>
                                                <webMaster>webmaster@jobx.com.au</webMaster>
                                                <image>
                                                    <title>{3}</title>
                                                    <url>http://{0}/Admin/GetAdminLogo.aspx?SiteID={5}</url>
                                                    <link>http://{0}/</link>
                                                    <description>{3} logo</description>
                                                </image>
                                        ",
                                         SessionData.Site.SiteUrl,
                                         HttpUtility.HtmlEncode(SessionData.Site.SiteDescription),
                                         DateTime.Today.Year,
                                         HttpUtility.HtmlEncode(SessionData.Site.SiteName),
                                         String.Format("{0:R}", DateTime.Now), SessionData.Site.SiteId));

            //Set PagingCount 50 jobs as per request - it was based on advancedsearch paging
            string kw = string.Empty;

            // Check the keywords or if there is a campaign

            EasyFts fts = new EasyFts();
            kw = fts.ToFtsQuery(HttpUtility.UrlDecode(keywords));

            using (VList<ViewJobSearch> viewJobSearchList = ViewJobSearchService.GetBySearchFilter(
                                                    kw,
                                                    SessionData.Site.SiteId, advertiserID,
                                                    currencyID, salaryLowerBand, salaryUpperBand, salarytypeID, worktypeID,
                                                    professionID, roleIDs,
                                                    countryID, locationID, areaIDs, null,
                                                    SessionData.JobSearch.PageIndex, 50, string.Empty, ConvertJobTypesToParam(jobTypes)))
            {
                int index = 1;

                //Filter for RSS hotjobs
                if (HotJob.HasValue)
                {
                    viewJobSearchList.Filter = "HotJob = " + HotJob.Value.ToString().ToLower();
                }

                foreach (ViewJobSearch viewJob in viewJobSearchList)
                {
                    string description = HttpUtility.HtmlEncode(viewJob.Description);

                    if (AddProfession.HasValue)
                    {
                        description += HttpUtility.HtmlEncode(string.Format("<div class='xmlProfession'><span class='xmlBoldTitle'><strong>{0}</strong></span></div>", viewJob.SiteProfessionName));
                    }


                    if (AddLocation.HasValue)
                    {
                        description += HttpUtility.HtmlEncode(string.Format("<div class='xmlLocation'><span class='xmlBoldTitle'><strong>{0}</strong></span></div>", viewJob.LocationName));
                    }

                    if (AddWorktype.HasValue)
                    {
                        description += HttpUtility.HtmlEncode(string.Format("<div class='xmlWorktype'><span class='xmlBoldTitle'><strong>{0}</strong></span></div>", viewJob.WorkTypeName));
                    }


                    strRSS.Append(String.Format(@"
                                                <item>
                                                    <title>{0}</title>
                                                    <description>{1}</description>
                                                    <link>http://{2}{3}</link>
                                                    <author>{4}</author>
                                                    <category>{5}</category>
                                                    <pubDate>{6}</pubDate>
                                                </item>
                                                ",
                                                 (AddLocationToTitle) ? HttpUtility.HtmlEncode(viewJob.JobName) + " in " + HttpUtility.HtmlEncode(viewJob.LocationName) :
                                                                                HttpUtility.HtmlEncode(viewJob.JobName),
                                                 description,
                                                 (SessionData.Site.WWWRedirect ? "www." : string.Empty) + SessionData.Site.SiteUrl,
                                                 Utils.GetJobUrl(viewJob.JobId, viewJob.JobFriendlyName),
                                                 HttpUtility.HtmlEncode(viewJob.AdvertiserName),
                                                 HttpUtility.HtmlEncode(viewJob.SiteProfessionName),
                                                 String.Format("{0:" + SessionData.Site.DateFormat + "}", viewJob.DatePosted)));

                    if (Max > 0 && index == Max) break;
                    index++;
                }

            }

            strRSS.Append((@"
                                </channel> 
                            </rss>"));

            //<%#String.Format("{0:R}",DateTime.Now%>

            ltlRSS.Text = strRSS.ToString();
        }

        public void SetFields()
        {
            keywords = Request.QueryString["keywords"];

            SessionData.JobSearch.PageIndex = 0;
            professionID = CommonFunction.GetInt(Request.QueryString["professionid"]);

            if (!String.IsNullOrEmpty(Request.QueryString["roleIDs"]))
                roleIDs = (Utils.CheckIDArray(Request.QueryString["roleIDs"])) ? Request.QueryString["roleIDs"] : string.Empty;

            countryID = CommonFunction.GetInt(Request.QueryString["countryID"]);
            locationID = CommonFunction.GetInt(Request.QueryString["locationID"]);
            if (!String.IsNullOrEmpty(Request.QueryString["areaIDs"]))
                areaIDs = (Utils.CheckIDArray(Request.QueryString["areaIDs"])) ? Request.QueryString["areaIDs"] : string.Empty;
            currencyID = CommonFunction.GetInt(Request.QueryString["currencyID"]);
            worktypeID = CommonFunction.GetInt(Request.QueryString["workTypeID"]);
            salarytypeID = CommonFunction.GetInt(Request.QueryString["salaryID"]);
            salaryLowerBand = CommonFunction.GetDecimal(Request.QueryString["salaryLowerBand"]);
            salaryUpperBand = CommonFunction.GetDecimal(Request.QueryString["salaryUpperBand"]);
            advertiserID = CommonFunction.GetInt(Request.QueryString["advertiserID"]);
            if (!String.IsNullOrEmpty(Request.QueryString["jobtype"]))
            {
                jobTypes = Request.QueryString["jobtype"];
            }
        }

        private string ConvertJobTypesToParam(string jobtypes)
        {
            string[] splits = jobtypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string result = string.Empty;
            string[] typenames = Enum.GetNames(typeof(PortalEnums.Jobs.JobItemType));
            int[] typevalues = (int[])Enum.GetValues(typeof(PortalEnums.Jobs.JobItemType));

            if (splits.Length > 0)
            {
                foreach (string s in splits)
                {
                    for (int i = 0; i < typenames.Length; i++)
                    {
                        if (typenames[i].ToLower() == s.ToLower())
                        {
                            result += typevalues[i].ToString() + ",";
                            break;
                        }
                    }
                }

                return result.TrimEnd(new char[] { ',' });
            }
            else
            {
                return result;
            }
        }
    }
}
