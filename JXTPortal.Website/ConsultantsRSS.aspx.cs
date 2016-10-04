using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Text;
using System.Configuration;
using System.Xml;
using JXTPortal.Common;

namespace JXTPortal.Website
{
    //public static class LinqHelper
    //{
    //    public static IQueryable<T> ContainsAny<T>(this IQueryable<T> q, Expression<Func<T, string>> text, params string[] items)
    //    {
    //        Expression<Func<T, bool>> predicate = c => false;
    //        var contains = typeof(String).GetMethod("Contains");
    //        foreach (var item in items)
    //        {
    //            var containsExpression = System.Linq.Expressions.Expression.Call(text.Body, contains, System.Linq.Expressions.Expression.Constant(item, typeof(String)));
    //            var lambda = System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(containsExpression, text.Parameters);
    //            predicate = predicatelambda);
    //        }

    //        return q.Where(predicate);
    //    }
    //}

    public partial class ConsultantsRSS : System.Web.UI.Page
    {
        #region Properties

        private ConsultantsService _ConsultantsService = null;

        public ConsultantsService ConsultantsService
        {

            get
            {
                if (_ConsultantsService == null)
                {
                    _ConsultantsService = new ConsultantsService();
                }
                return _ConsultantsService;
            }
        }

        private bool? _featured = null;

        protected bool? Featured
        {
            get
            {
                if ((Request.QueryString["featured"] != null))
                {
                    if (Request.QueryString["featured"] == "1")
                    {
                        _featured = true;
                    }
                    else if (Request.QueryString["featured"] == "0")
                    {
                        _featured = false;
                    }
                    return _featured;
                }

                return null;
            }
        }

        private string _location = string.Empty;

        protected string Location
        {
            get
            {
                if ((Request.QueryString["location"] != null))
                {
                    if (Request.QueryString["location"] != string.Empty)
                    {
                        _location = Request.QueryString["location"];
                    }
                    return _location;
                }

                return _location;
            }
        }

        private string _category = string.Empty;

        protected string Category
        {
            get
            {
                if ((Request.QueryString["category"] != null))
                {
                    if (Request.QueryString["category"] != string.Empty)
                    {
                        _category = Request.QueryString["category"];
                    }
                    return _category;
                }

                return _category;
            }
        }

        private string _keyword = string.Empty;

        protected string Keyword
        {
            get
            {
                if ((Request.QueryString["keyword"] != null))
                {
                    if (Request.QueryString["keyword"] != string.Empty)
                    {
                        _keyword = Request.QueryString["keyword"];
                    }
                    return _keyword;
                }

                return _keyword;
            }
        }

        private int _id = 0;

        protected int ID
        {
            get
            {
                if ((Request.QueryString["id"] != null))
                {
                    if (Request.QueryString["id"] != string.Empty)
                    {
                        Int32.TryParse(Request.QueryString["id"], out _id);
                    }
                    return _id;
                }

                return _id;
            }
        }

        private int _langid = 1;

        protected int LangID
        {
            get
            {
                if ((Request.QueryString["langid"] != null))
                {
                    if (Request.QueryString["langid"] != string.Empty)
                    {
                        Int32.TryParse(Request.QueryString["langid"], out _langid);
                    }
                    return _langid;
                }
                else
                {
                    _langid = SessionData.Language.LanguageId;
                }

                return _langid;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadConsultants();
        }



        protected void LoadConsultants()
        {
            Response.ContentType = "text/xml";
            // Set the QueryString feeds
            //SetFields();

            StringBuilder strRSS = new StringBuilder();

            /*
            
        <atom:link href='http://www.jobx.com.au/job/rss.aspx' rel='self'/>
             */
            strRSS.Append(String.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
<data>
<consultants>"));



            int count = 0;
            TList<Entities.Consultants> consultants = ConsultantsService.GetPaged(string.Format("SiteID = {0} AND Valid = 1", SessionData.Site.SiteId), "Sequence", 0, Int32.MaxValue, out count);
            TList<Entities.Consultants> filtered = new TList<Entities.Consultants>();

            foreach (Entities.Consultants consultant in consultants)
            {
                bool matches = true;
                if (Featured.HasValue)
                {
                    if (Featured.Value && consultant.FeaturedTeamMember != 1)
                    {
                        matches = false;
                        continue;
                    }

                    if (!Featured.Value && consultant.FeaturedTeamMember != 0)
                    {
                        matches = false;
                        continue;
                    }
                }

                if (!string.IsNullOrWhiteSpace(Category))
                {
                    bool categorymatch = false;

                    string[] splits = Category.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string split in splits)
                    {
                        if (consultant.Categories.ToLower().Contains(split.ToLower()))
                        {
                            categorymatch = true;
                        }
                    }

                    if (!categorymatch)
                    {
                        matches = false;
                        continue;
                    }
                }

                if (!string.IsNullOrWhiteSpace(Location))
                {
                    if (consultant.Location.ToLower().Contains(Location.ToLower()) == false)
                    {
                        matches = false;
                        continue;
                    }
                }

                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    if (consultant.FirstName.ToLower().Contains(Keyword.ToLower()) == false &&
                        consultant.LastName.ToLower().Contains(Keyword.ToLower()) == false &&
                        consultant.Phone.ToLower().Contains(Keyword.ToLower()) == false &&
                        consultant.Mobile.ToLower().Contains(Keyword.ToLower()) == false &&
                        consultant.Email.ToLower().Contains(Keyword.ToLower()) == false &&
                        consultant.PositionTitle.ToLower().Contains(Keyword.ToLower()) == false &&
                        consultant.Categories.ToLower().Contains(Keyword.ToLower()) == false)
                    {
                        matches = false;
                        continue;
                    }
                }

                if (ID > 0)
                {
                    if (consultant.ConsultantId != ID)
                    {
                        matches = false;
                        continue;
                    }
                }

                if (matches)
                {
                    filtered.Add(consultant);
                }
            }


            List<string> categorylist = new List<string>();
            List<string> locationlist = new List<string>();

            foreach (Entities.Consultants consultant in filtered)
            {

                string MultiTitle = string.Empty;
                string MultiFirstName = string.Empty;
                string MultiLastName = string.Empty;
                string MultiPositionTitle = string.Empty;
                string MultiLocation = string.Empty;
                string MultiOfficeLocation = string.Empty;
                string MultiCategories = string.Empty;
                string MultiShortDescription = string.Empty;
                string MultiFullDescription = string.Empty;
                string MultiTestimonial = string.Empty;
                string MultiMetaTitle = string.Empty;
                string MultiMetaKeyword = string.Empty;
                string MultiMetaDescription = string.Empty;

                if (!string.IsNullOrWhiteSpace(consultant.ConsultantsXml))
                {
                    XmlDocument langxml = new XmlDocument();

                    langxml.LoadXml(consultant.ConsultantsXml);

                    XmlNodeList langlist = langxml.GetElementsByTagName("Language");
                    foreach (XmlNode langnode in langlist)
                    {
                        if (langnode.ChildNodes[0].InnerXml == LangID.ToString())
                        {
                            MultiTitle = langnode["Title"].InnerXml;
                            MultiFirstName = langnode["FirstName"].InnerXml;
                            MultiLastName = langnode["LastName"].InnerXml;
                            MultiPositionTitle = langnode["PositionTitle"].InnerXml;
                            MultiLocation = langnode["Location"].InnerXml;
                            MultiOfficeLocation = langnode["OfficeLocation"].InnerXml;
                            MultiCategories = langnode["Categories"].InnerXml;
                            MultiShortDescription = langnode["ShortDescription"].InnerXml;
                            MultiFullDescription = langnode["FullDescription"].InnerXml;
                            MultiTestimonial = langnode["Testimonial"].InnerXml;
                            MultiMetaTitle = langnode["MetaTitle"].InnerXml;
                            MultiMetaKeyword = langnode["MetaKeyword"].InnerXml;
                            MultiMetaDescription = langnode["MetaDescription"].InnerXml;

                            break;
                        }
                    }
                }

                strRSS.Append(String.Format(@"
                <consultant>
                <ConsultantID>{0}</ConsultantID>
                <Title><![CDATA[{1}]]></Title>
                <FirstName><![CDATA[{2}]]></FirstName>
                <LastName><![CDATA[{3}]]></LastName>
                <Email><![CDATA[{4}]]></Email>
                <Phone><![CDATA[{5}]]></Phone>
                <Mobile><![CDATA[{6}]]></Mobile>
                <PositionTitle><![CDATA[{7}]]></PositionTitle>
                <OfficeLocation><![CDATA[{8}]]></OfficeLocation>
                <Categories><![CDATA[{9}]]></Categories>
                <Location><![CDATA[{10}]]></Location>
                <FriendlyURL><![CDATA[{11}]]></FriendlyURL>
                <ShortDescription><![CDATA[{12}]]></ShortDescription>
                <Testimonial><![CDATA[{13}]]></Testimonial>
                <FullDescription><![CDATA[{14}]]></FullDescription>
                <ConsultantData><![CDATA[{15}]]></ConsultantData>
                <LinkedInURL><![CDATA[{16}]]></LinkedInURL>
                <TwitterURL><![CDATA[{17}]]></TwitterURL>
                <FacebookURL><![CDATA[{18}]]></FacebookURL>
                <GoogleURL><![CDATA[{19}]]></GoogleURL>
                <Link><![CDATA[{20}]]></Link>
                <WechatURL><![CDATA[{21}]]></WechatURL>
                <FeaturedTeamMember><![CDATA[{22}]]></FeaturedTeamMember>
                <ImageURL><![CDATA[{23}]]></ImageURL>
                <VideoURL><![CDATA[{24}]]></VideoURL>
                <BlogRSS><![CDATA[{25}]]></BlogRSS>
                <NewsRSS><![CDATA[{26}]]></NewsRSS>
                <JobRSS><![CDATA[{27}]]></JobRSS>
                <TestimonialsRSS><![CDATA[{28}]]></TestimonialsRSS>
                <Valid><![CDATA[{29}]]></Valid>
                <MetaTitle><![CDATA[{30}]]></MetaTitle>
                <MetaDescription><![CDATA[{31}]]></MetaDescription>
                <MetaKeywords><![CDATA[{32}]]></MetaKeywords>
                <LastModified><![CDATA[{33}]]></LastModified>
                <Sequence><![CDATA[{34}]]></Sequence>
                </consultant>",
                consultant.ConsultantId,
                (!string.IsNullOrWhiteSpace(MultiTitle)) ? MultiTitle : consultant.Title,
                (!string.IsNullOrWhiteSpace(MultiFirstName)) ? MultiFirstName : consultant.FirstName,
                (!string.IsNullOrWhiteSpace(MultiLastName)) ? MultiLastName : consultant.LastName,
                consultant.Email,
                consultant.Phone,
                consultant.Mobile,
                (!string.IsNullOrWhiteSpace(MultiPositionTitle)) ? MultiPositionTitle : consultant.PositionTitle,
                (!string.IsNullOrWhiteSpace(MultiOfficeLocation)) ? MultiOfficeLocation : consultant.OfficeLocation,
                (!string.IsNullOrWhiteSpace(MultiCategories)) ? MultiCategories : consultant.Categories,
                (!string.IsNullOrWhiteSpace(MultiLocation)) ? MultiLocation : consultant.Location,
                consultant.FriendlyUrl,
                (!string.IsNullOrWhiteSpace(MultiShortDescription)) ? MultiShortDescription: consultant.ShortDescription,
                (!string.IsNullOrWhiteSpace(MultiTestimonial)) ? MultiTestimonial : consultant.Testimonial,
                (!string.IsNullOrWhiteSpace(MultiFullDescription)) ? MultiFullDescription : consultant.FullDescription,
                consultant.ConsultantData,
                consultant.LinkedInUrl,
                consultant.TwitterUrl,
                consultant.FacebookUrl,
                consultant.GoogleUrl,
                consultant.Link,
                consultant.WechatUrl,
                consultant.FeaturedTeamMember,
                (consultant.ImageUrl != null) ? "/getfile.aspx?consultantid=" + consultant.ConsultantId : string.Empty,
                consultant.VideoUrl,
                consultant.BlogRss,
                consultant.NewsRss,
                consultant.JobRss,
                consultant.TestimonialsRss,
                consultant.Valid,
                (!string.IsNullOrWhiteSpace(MultiMetaTitle)) ? MultiMetaTitle : consultant.MetaTitle,
                (!string.IsNullOrWhiteSpace(MultiMetaDescription)) ? MultiMetaDescription : consultant.MetaDescription,
                (!string.IsNullOrWhiteSpace(MultiMetaKeyword)) ? MultiMetaKeyword : consultant.MetaKeywords,
                consultant.LastModified,
                consultant.Sequence));

                if (string.IsNullOrWhiteSpace(consultant.Location) == false)
                {
                    string[] locs = consultant.Location.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string loc in locs)
                    {
                        if (locationlist.Contains(loc) == false)
                        {
                            locationlist.Add(loc);
                        }
                    }

                    locationlist.Sort();
                }

                if (string.IsNullOrWhiteSpace(consultant.Categories) == false)
                {
                    string[] cats = consultant.Categories.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string cat in cats)
                    {
                        if (categorylist.Contains(cat) == false)
                        {
                            categorylist.Add(cat);
                        }
                    }

                    categorylist.Sort();
                }
            }

            strRSS.Append((@"
    </consultants>
    <locations>"));

            foreach (string loc in locationlist)
            {
                strRSS.Append((@"
    <location><![CDATA[" + loc + "]]></location>"));
            }

            strRSS.Append((@"
    </locations>
    <categories>"));
            foreach (string cat in categorylist)
            {
                strRSS.Append((@"
    <category><![CDATA[" + cat + "]]></category>"));
            }
            strRSS.Append(@"
    </categories>
</data>");
            ltlRSS.Text = strRSS.ToString();
        }
    }
}