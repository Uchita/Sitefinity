using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Website.usercontrols.common;
using System.Text;
using System.Data;
using System.Xml;
using JXTPortal.Entities;

namespace JXTPortal.Website
{
    public partial class ConsultantProfile : DefaultBase
    {
        #region "Properties"

        ConsultantsService _consultantsService;
        ConsultantsService ConsultantsService
        {
            get
            {
                if (_consultantsService == null)
                {
                    _consultantsService = new ConsultantsService();
                }
                return _consultantsService;
            }
        }

        private string _consultantname = string.Empty;

        protected string ConsultantName
        {
            get
            {
                if ((Request.QueryString["consultantname"] != null))
                {
                    if (Request.QueryString["consultantname"] != string.Empty)
                    {
                        _consultantname = Request.QueryString["consultantname"];
                    }
                    return _consultantname;
                }

                return _consultantname;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.Action = Request.RawUrl;

            if (!string.IsNullOrWhiteSpace(ConsultantName))
            {
                int count = 0;

                TList<Consultants> consultants = ConsultantsService.GetPaged(string.Format("SiteID = {0} AND Valid = 1 AND FriendlyURL = '{1}'", SessionData.Site.SiteId, ConsultantName.Replace("'", "''")), "", 0, Int32.MaxValue, out count);
                if (consultants.Count == 1)
                {
                    Consultants consultant = consultants[0];

                    // Load Template from dynamic page
                    ucSystemDynamicPage ucSystemDynamicPage = new ucSystemDynamicPage();
                    string strContent = ucSystemDynamicPage.GetContent("SystemPage_ConsultantProfile");
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
                            if (langnode.ChildNodes[0].InnerXml == SessionData.Language.LanguageId.ToString())
                            {
                                MultiTitle = langnode["Title"].InnerText;
                                MultiFirstName = langnode["FirstName"].InnerText;
                                MultiLastName = langnode["LastName"].InnerText;
                                MultiPositionTitle = langnode["PositionTitle"].InnerText;
                                MultiLocation = langnode["Location"].InnerText;
                                MultiOfficeLocation = langnode["OfficeLocation"].InnerText;
                                MultiCategories = langnode["Categories"].InnerText;
                                MultiShortDescription = langnode["ShortDescription"].InnerText;
                                MultiFullDescription = langnode["FullDescription"].InnerText;
                                MultiTestimonial = langnode["Testimonial"].InnerText;
                                MultiMetaTitle = langnode["MetaTitle"].InnerText;
                                MultiMetaKeyword = langnode["MetaKeyword"].InnerText;
                                MultiMetaDescription = langnode["MetaDescription"].InnerText;

                                break;
                            }
                        }
                    }

                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_CONSULTANTID, HttpUtility.HtmlEncode(consultant.ConsultantId.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_SITEID, HttpUtility.HtmlEncode(consultant.SiteId.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_TITLE, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiTitle)) ? MultiTitle : consultant.Title.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_FIRSTNAME, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiFirstName)) ? MultiFirstName : consultant.FirstName.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_LASTNAME, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiLastName)) ? MultiLastName : consultant.LastName.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_EMAIL, HttpUtility.HtmlEncode(consultant.Email.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_PHONE, HttpUtility.HtmlEncode(consultant.Phone.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_MOBILE, HttpUtility.HtmlEncode(consultant.Mobile.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_POSITIONTITLE, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiPositionTitle)) ? MultiPositionTitle : consultant.PositionTitle.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_OFFICELOCATION, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiOfficeLocation)) ? MultiOfficeLocation : consultant.OfficeLocation.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_CATEGORIES, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiCategories)) ? MultiCategories : consultant.Categories.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_LOCATION, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiLocation)) ? MultiLocation : consultant.Location.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_FRIENDLYURL, HttpUtility.HtmlEncode(consultant.FriendlyUrl.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_SHORTDESCRIPTION, (!string.IsNullOrWhiteSpace(MultiShortDescription)) ? MultiShortDescription : consultant.ShortDescription.ToString());
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_TESTIMONIAL, (!string.IsNullOrWhiteSpace(MultiTestimonial)) ? MultiTestimonial : consultant.Testimonial.ToString());
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_FULLDESCRIPTION, (!string.IsNullOrWhiteSpace(MultiFullDescription)) ? MultiFullDescription : consultant.FullDescription.ToString());
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_LINKEDINURL, HttpUtility.HtmlEncode(consultant.LinkedInUrl.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_TWITTERURL, HttpUtility.HtmlEncode(consultant.TwitterUrl.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_FACEBOOKURL, HttpUtility.HtmlEncode(consultant.FacebookUrl.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_GOOGLEURL, HttpUtility.HtmlEncode(consultant.GoogleUrl.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_LINK, HttpUtility.HtmlEncode(consultant.Link.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_WECHATURL, HttpUtility.HtmlEncode(consultant.WechatUrl.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_FEATUREDTEAMMEMBER, HttpUtility.HtmlEncode(consultant.FeaturedTeamMember.ToString()));

                    if (consultant.ImageUrl != null)
                    {
                        strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_IMAGEURL, "/getfile.aspx?consultantid=" + consultant.ConsultantId.ToString());
                    }
                    else
                    {
                        strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_IMAGEURL, string.Empty);
                    }

                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_VIDEOURL, HttpUtility.HtmlEncode(consultant.VideoUrl.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_BLOGRSS, HttpUtility.HtmlEncode(consultant.BlogRss.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_NEWSRSS, HttpUtility.HtmlEncode(consultant.NewsRss.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_JOBRSS, HttpUtility.HtmlEncode(consultant.JobRss.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_TESTIMONIALSRSS, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiTestimonial)) ? MultiTestimonial : consultant.TestimonialsRss.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_VALID, HttpUtility.HtmlEncode(consultant.Valid.ToString()));

                    string thisMetaTitle = HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiMetaTitle)) ? MultiMetaTitle : consultant.MetaTitle.ToString());
                    string thisMetaDesc = HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiMetaDescription)) ? MultiMetaDescription : consultant.MetaDescription.ToString());
                    string thisMetaKeyword = HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiMetaKeyword)) ? MultiMetaKeyword : consultant.MetaKeywords.ToString());
                    
                    //strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_METATITLE, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiMetaTitle)) ? MultiMetaTitle : consultant.MetaTitle.ToString()));
                    //strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_METADESCRIPTION, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiMetaDescription)) ? MultiMetaDescription : consultant.MetaDescription.ToString()));
                    //strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_METAKEYWORDS, HttpUtility.HtmlEncode((!string.IsNullOrWhiteSpace(MultiMetaKeyword)) ? MultiMetaKeyword : consultant.MetaKeywords.ToString()));

                    //SetMetaContentWithFavIcon(ltlMetaContent, null, Page, thisMetaTitle, thisMetaDesc, thisMetaKeyword, false, true);
                    //SetMetaContentWithFavIcon(Master.FindControl("ltlMetaContent") as Literal, null, Page, (string.IsNullOrWhiteSpace(thisMetaTitle)) ? consultant.FirstName : consultant.MetaTitle, consultant.MetaDescription, consultant.MetaKeywords, false, true);
                    SetMetaContentWithFavIcon(Master.FindControl("ltlMetaContent") as Literal, null, Page, thisMetaTitle, thisMetaDesc, thisMetaKeyword, false, true);
                    

                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_LASTMODIFIEDBY, HttpUtility.HtmlEncode(consultant.LastModifiedBy.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_LASTMODIFIED, HttpUtility.HtmlEncode(consultant.LastModified.ToString()));
                    strContent = strContent.Replace(PortalConstants.ConsultantData.CONSULTANT_SEQUENCE, HttpUtility.HtmlEncode(consultant.Sequence.ToString()));

                    ltlSystemDynamicPage.Text = strContent;
                }
                else
                {
                    Response.Redirect("/default.aspx");
                }
            }
            else
            {
                Response.Redirect("/default.aspx");
            }
        }
    }
}