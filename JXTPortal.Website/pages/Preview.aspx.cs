using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Web.UI.HtmlControls;
using JXTPortal.Website.usercontrols.navigation;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Text;
using System.Data;

using System.Xml;
using System.Configuration;
namespace JXTPortal.Website.pages
{
    public partial class PagePreview : DefaultBase 
    {
        #region Declare variables
        public string PAGE_TYPE = string.Empty;
        public string PAGE_LINK = string.Empty;

        #endregion

        #region Properties

        private DynamicPagesService _dynamicPagesService = null;

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

        private DynamicPageRevisionsService _dynamiccPageRevisionsService = null;

        private DynamicPageRevisionsService DynamicPageRevisionsService
        {
            get
            {
                if (_dynamiccPageRevisionsService == null)
                {
                    _dynamiccPageRevisionsService = new DynamicPageRevisionsService();
                }
                return _dynamiccPageRevisionsService;
            }
        }

        private RelatedDynamicPagesService _relateddynamicPagesService = null;

        private RelatedDynamicPagesService RelatedDynamicPagesService
        {
            get
            {
                if (_relateddynamicPagesService == null)
                {
                    _relateddynamicPagesService = new RelatedDynamicPagesService();
                }
                return _relateddynamicPagesService;
            }
        }

        private DynamicPageWebPartTemplatesService _dynamicPageWebPartTemplatesService = null;

        public DynamicPageWebPartTemplatesService DynamicPageWebPartTemplatesService
        {

            get
            {
                if (_dynamicPageWebPartTemplatesService == null)
                {
                    _dynamicPageWebPartTemplatesService = new DynamicPageWebPartTemplatesService();
                }
                return _dynamicPageWebPartTemplatesService;
            }
        }

        private DynamicPageWebPartTemplatesLinkService _dynamicPageWebPartTemplatesLinkService = null;

        public DynamicPageWebPartTemplatesLinkService DynamicPageWebPartTemplatesLinkService
        {

            get
            {
                if (_dynamicPageWebPartTemplatesLinkService == null)
                {
                    _dynamicPageWebPartTemplatesLinkService = new DynamicPageWebPartTemplatesLinkService();
                }
                return _dynamicPageWebPartTemplatesLinkService;
            }
        }

        private DynamicpagesCustomWidgetService _DynamicpagesCustomWidgetService = null;

        private DynamicpagesCustomWidgetService DynamicpagesCustomWidgetService
        {
            get
            {
                if (_DynamicpagesCustomWidgetService == null)
                {
                    _DynamicpagesCustomWidgetService = new DynamicpagesCustomWidgetService();
                }
                return _DynamicpagesCustomWidgetService;
            }
        }

        public Guid RevisionCode
        {
            get
            {
                Guid strRevisionCode = Guid.Empty;

                if (!string.IsNullOrWhiteSpace(Request.Params["RevisionCode"]))
                {
                    Guid.TryParse(Request.Params["RevisionCode"], out strRevisionCode);
                }

                return strRevisionCode;
            }
        }

        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadContent();
        }

        #endregion

        #region Click Event handlers
        #endregion

        #region Methods

        //private void CheckPageAccess(Entities.DynamicPages dynamicPage)
        //{

        //    bool isSuperSecured = false;
        //    bool canAccess = false;
        //    // Check if the user has access to this page
        //    try
        //    {
        //        XmlDocument sitexml = new XmlDocument();
        //        sitexml.Load(Server.MapPath("/xml/SiteSecuredPages.xml"));
        //        XmlNodeList sitelist = sitexml.SelectNodes("//site");
        //        foreach (XmlNode site in sitelist)
        //        {
        //            string siteid = site.SelectSingleNode("id").InnerText;
        //            if (siteid == SessionData.Site.SiteId.ToString())
        //            {
        //                XmlNodeList sitepagelist = site.SelectNodes("pages/page");
        //                foreach (XmlNode sitepage in sitepagelist)
        //                {
        //                    if (sitepage.InnerText == dynamicPage.PageFriendlyName)
        //                    {
        //                        isSuperSecured = true;
        //                        break;
        //                    }
        //                }
        //                break;
        //            }
        //        }

        //        if (!isSuperSecured)
        //        {
        //            return;
        //        }

        //        XmlDocument userxml = new XmlDocument();
        //        userxml.Load(Server.MapPath("/xml/UserSecuredPages.xml"));
        //        XmlNodeList userlist = userxml.SelectNodes("//user");
        //        foreach (XmlNode user in userlist)
        //        {
        //            string userid = user.SelectSingleNode("id").InnerText;
        //            if (SessionData.AdminUser != null)
        //            {
        //                if (userid == SessionData.AdminUser.AdminUserId.ToString() && SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ExternalUser)
        //                {
        //                    XmlNodeList userpagelist = user.SelectNodes("pages/page");
        //                    foreach (XmlNode userpage in userpagelist)
        //                    {
        //                        if (userpage.InnerText == dynamicPage.PageFriendlyName)
        //                        {
        //                            canAccess = true;
        //                            break;
        //                        }
        //                    }

        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                Response.Redirect("~/securedcontent/contentlogin.aspx?returnurl=" + Server.UrlEncode(Request.RawUrl));
        //            }
        //        }

        //        if (!canAccess)
        //        {
        //            Response.Redirect("~/securedcontent/contentlogin.aspx?returnurl=" + Server.UrlEncode(Request.RawUrl));
        //        }
        //    }
        //    catch { }
        //}

        private void LoadContent()
        {
            if (SessionData.AdminUser == null)
            {
                Response.Redirect("~/admin/login.aspx" + "?returnurl=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));
            }

            if (RevisionCode != Guid.Empty)
            {
                // Change the language which comes from session.

                TList<JXTPortal.Entities.DynamicPageRevisions> dynamicPages = DynamicPageRevisionsService.CustomGetBySiteIDMappingID(SessionData.Site.SiteId, RevisionCode);
                if (dynamicPages.Count == 0)
                {
                    //Response.Redirect("~/admin/login.aspx" + "?returnurl=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));
                    Response.Redirect("/default.aspx");
                }

                JXTPortal.Entities.DynamicPageRevisions pageRevision = dynamicPages[0];
                dynamicPages.Filter = "LanguageId = " + SessionData.Language.LanguageId.ToString();
                if (dynamicPages.Count > 0)
                {
                    pageRevision = dynamicPages[0];
                }


                if (pageRevision != null)
                {
                    if (pageRevision.Status == (int)PortalEnums.DynamicPage.Status.Published && SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Contributor)
                    {
                        Response.Redirect("/default.aspx");
                    }

                    PAGE_TYPE = ((PortalEnums.DynamicPage.Status)pageRevision.Status).ToString();
                    PAGE_LINK = "/admin/dynamicpagerevisions.aspx?revisioncode=" + pageRevision.MappingId;

                    // Redirect to the overwrite url.
                    if (!String.IsNullOrWhiteSpace(pageRevision.HyperLink) && CommonPage.IsCustomURL == false)
                    {
                        Response.Redirect(pageRevision.HyperLink);
                    }


                    string strHeader = string.Empty, strFooter = string.Empty, strLefNav = string.Empty, strRightNav = string.Empty;
                    string strAboveHeader = string.Empty; string strBelowFooter = string.Empty;
                    PageBase pageBase = new PageBase();

                    //if (pageRevision.GenerateBreadcrumb)
                    //{
                    //    ltBreadcrumb.Text = pageBase.ReplaceWebPartBreadcrumb(string.Empty, dynamicPage, true);
                    //}

                    if (pageRevision.DynamicPageWebPartTemplateId.HasValue)
                    {
                        int dpWebpartTemplateID = pageRevision.DynamicPageWebPartTemplateId.Value;

                        // Check if it is a System Page
                        if (pageRevision.PageName.Contains("SystemPage"))
                        {
                            JXTPortal.Entities.DynamicPages dp = DynamicPagesService.GetBySiteIdPageNameLanguageId(SessionData.Site.SiteId, "SystemPage", SessionData.Language.LanguageId);
                            if (dp != null && dp.DynamicPageWebPartTemplateId.HasValue)
                                dpWebpartTemplateID = dp.DynamicPageWebPartTemplateId.Value;
                        }

                        DynamicPagesService.SetDynamicPageWebPartTemplateId(dpWebpartTemplateID,
                                                                                ref strHeader, ref strLefNav,
                                                                                ref strRightNav, ref strFooter, ref strAboveHeader, ref strBelowFooter, pageRevision.PageFriendlyName);
                    }


                    Entities.DynamicPages dpage = new Entities.DynamicPages();
                    dpage.ParentDynamicPageId = pageRevision.ParentDynamicPageId;
                    dpage.DynamicPageId = pageRevision.DynamicPageId;

                    strAboveHeader = pageBase.ReplaceWebPartBreadcrumb(strAboveHeader, dpage);
                    strBelowFooter = pageBase.ReplaceWebPartBreadcrumb(strBelowFooter, dpage);
                    strHeader = pageBase.ReplaceWebPartBreadcrumb(strHeader, dpage);
                    strFooter = pageBase.ReplaceWebPartBreadcrumb(strFooter, dpage);
                    strLefNav = pageBase.ReplaceWebPartBreadcrumb(strLefNav, dpage);
                    strRightNav = pageBase.ReplaceWebPartBreadcrumb(strRightNav, dpage);


                    // Sign out / Sign In
                    strAboveHeader = pageBase.LoadMemberSignAndOutAndDashboard(strAboveHeader);
                    strBelowFooter = pageBase.LoadMemberSignAndOutAndDashboard(strBelowFooter);
                    strHeader = pageBase.LoadMemberSignAndOutAndDashboard(strHeader);
                    strFooter = pageBase.LoadMemberSignAndOutAndDashboard(strFooter);
                    strLefNav = pageBase.LoadMemberSignAndOutAndDashboard(strLefNav);
                    strRightNav = pageBase.LoadMemberSignAndOutAndDashboard(strRightNav);

                    // Replace login status menu
                    strAboveHeader = pageBase.LoadLoginStatusMenu(strAboveHeader);
                    strBelowFooter = pageBase.LoadLoginStatusMenu(strBelowFooter);
                    strHeader = pageBase.LoadLoginStatusMenu(strHeader);
                    strFooter = pageBase.LoadLoginStatusMenu(strFooter);
                    strLefNav = pageBase.LoadLoginStatusMenu(strLefNav);
                    strRightNav = pageBase.LoadLoginStatusMenu(strRightNav);

                    // Replace member counters
                    strAboveHeader = pageBase.LoadMemberResultCounters(strAboveHeader);
                    strBelowFooter = pageBase.LoadMemberResultCounters(strBelowFooter);
                    strHeader = pageBase.LoadMemberResultCounters(strHeader);
                    strFooter = pageBase.LoadMemberResultCounters(strFooter);
                    strLefNav = pageBase.LoadMemberResultCounters(strLefNav);
                    strRightNav = pageBase.LoadMemberResultCounters(strRightNav);

                    strHeader = LoadRelatedPages(strHeader, dpage);
                    strFooter = LoadRelatedPages(strFooter, dpage);
                    strLefNav = LoadRelatedPages(strLefNav, dpage);
                    strRightNav = LoadRelatedPages(strRightNav, dpage);
                    strAboveHeader = LoadRelatedPages(strAboveHeader, dpage);
                    strBelowFooter = LoadRelatedPages(strBelowFooter, dpage);

                    // Custom Widget
                    strLefNav = pageBase.ReplaceLeftNavWidget(strLefNav, dpage);
                    strRightNav = pageBase.ReplaceRightNavWidget(strRightNav, dpage);


                    // Dynamic Search widget - example {widget-22}
                    ltlAboveHeader.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strAboveHeader);
                    ltlBelowFooter.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strBelowFooter);
                    ltlHeader.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strHeader);
                    strLefNav = CommonAdvancedSearch.GetAdvancedSearchWidget(LoadDynamicNavigation(strLefNav, pageRevision.PageFriendlyName, !string.IsNullOrEmpty(pageRevision.CustomUrl) ? true : false));
                    strRightNav = CommonAdvancedSearch.GetAdvancedSearchWidget(LoadDynamicNavigation(strRightNav, pageRevision.PageFriendlyName, !string.IsNullOrEmpty(pageRevision.CustomUrl) ? true : false));

                    ltlContent.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(pageRevision.PageContent); // Also dynamic content of the page


                    if (!String.IsNullOrEmpty(strLefNav))
                        ltlLeftNavigation.Text = String.Format("<div id='dynamic-side-left-container'>{0}</div><!--end of side-left-->", CommonAdvancedSearch.GetAdvancedSearchWidget(strLefNav));

                    if (!String.IsNullOrEmpty(strRightNav))
                        ltlRightNavigation.Text = String.Format("<div id='dynamic-side-right-container'>{0}</div><!--end of side-right-->", CommonAdvancedSearch.GetAdvancedSearchWidget(strRightNav));

                    if (!String.IsNullOrEmpty(strFooter))
                        ltlFooter.Text = String.Format("{0}<!--end of footer-->", CommonAdvancedSearch.GetAdvancedSearchWidget(strFooter));

                    plHeader.Visible = !string.IsNullOrEmpty(strHeader);
                    plFooter.Visible = !string.IsNullOrEmpty(strFooter);

                    // Load CSS and Javascript
                    ltlCSSAndScripts.Text = DynamicPagesService.GetDynamicPageJavascriptCSS(pageRevision.PageName);

                    SetMetaContentWithFavIcon(ltlMetaContent, null, Page,
                        !string.IsNullOrWhiteSpace(pageRevision.MetaTitle) ? pageRevision.MetaTitle : pageRevision.PageTitle, pageRevision.MetaDescription, pageRevision.MetaKeywords, false, true);
                }
                else
                {
                    //Response.Redirect("~/default.aspx");
                    Server.Transfer("/default.aspx"); // Instead of Response.Redirect .. which is a 302 redirect to 404 page.
                }
            }
            else
            {
                Response.Redirect("/default.aspx");
            }
        }

        /*
        private string ReplaceWebPartBreadcrumb(string text, JXTPortal.Entities.DynamicPages dynamicPage, bool isPageContent = false)
        {
            if (text.Contains(PortalConstants.DynamicNavigation.WEBPART_BREADCRUMB) || isPageContent)
            {
                StringBuilder sb = new StringBuilder();
                TList<Entities.DynamicPages> pagelist = new TList<Entities.DynamicPages>();
                pagelist.Add(dynamicPage);

                if (dynamicPage.ParentDynamicPageId != 0)
                {
                    JXTPortal.Entities.DynamicPages page = DynamicPagesService.GetByDynamicPageId(dynamicPage.ParentDynamicPageId);
                    pagelist.Insert(0, page);

                    if (page.ParentDynamicPageId != 0)
                    {
                        JXTPortal.Entities.DynamicPages parentpage = DynamicPagesService.GetByDynamicPageId(page.ParentDynamicPageId);
                        pagelist.Insert(0, parentpage);
                    }
                }

                for (int i = 0; i < pagelist.Count; i++)
                {
                    if (i == 0)
                    {
                        sb.Append(DynamicPagesService.GetDynamicPageLink(pagelist[i], "class=\"parent\""));
                    }
                    else if (i == 1)
                    {
                        sb.Append(" / " + DynamicPagesService.GetDynamicPageLink(pagelist[i], "class=\"child\""));
                    }
                    else
                    {
                        sb.Append(" / " + DynamicPagesService.GetDynamicPageLink(pagelist[i], "class=\"grandchild\""));
                    }
                }
                if (isPageContent)
                {
                    return "<div class=\"dynamic-breadcrumb\">" + sb.ToString() + "</div>";
                }
                else
                {
                    return text.Replace(PortalConstants.DynamicNavigation.WEBPART_BREADCRUMB, "<div class=\"webpart-breadcrumb\">" + sb.ToString() + "</div>");
                }
            }

            return text;
        }

        private string ReplaceLeftNavWidget(string text, JXTPortal.Entities.DynamicPages dynamicPage)
        {
            if (text.Contains(PortalConstants.DynamicNavigation.CUSTOM_WIDGET_GROUP_LEFT))
            {
                // Retrieve all widgets

                StringBuilder sb = new StringBuilder();

                DataSet ds = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dynamicPage.DynamicPageId, (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sb.AppendLine(string.Format("<div class=\"custom-widget custom-widget-{0} {1}\">\n{2}\n</div>", dr["CustomWidgetID"].ToString(), dr["CustomWidgetCSSSelectorClassName"].ToString(), dr["Content"].ToString()));
                    }
                }

                text = text.Replace(PortalConstants.DynamicNavigation.CUSTOM_WIDGET_GROUP_LEFT, string.Format("<div class=\"custom-widget-group-left\">\n{0}\n</div>", sb.ToString()));
            }

            return text;
        }

        private string ReplaceRightNavWidget(string text, JXTPortal.Entities.DynamicPages dynamicPage)
        {
            if (text.Contains(PortalConstants.DynamicNavigation.CUSTOM_WIDGET_GROUP_RIGHT))
            {
                // Retrieve all widgets

                StringBuilder sb = new StringBuilder();

                DataSet ds = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dynamicPage.DynamicPageId, (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sb.AppendLine(string.Format("<div class=\"custom-widget custom-widget-{0} {1}\">\n{2}\n</div>", dr["CustomWidgetID"].ToString(), dr["CustomWidgetCSSSelectorClassName"].ToString(), dr["Content"].ToString()));
                    }
                }

                text = text.Replace(PortalConstants.DynamicNavigation.CUSTOM_WIDGET_GROUP_RIGHT, string.Format("<div class=\"custom-widget-group-right\">\n{0}\n</div>", sb.ToString()));
            }

            return text;
        }
        */
        private string LoadDynamicNavigation(String strNav, string PageName, bool IsCustomURL)
        {
            if (strNav.Contains(PortalConstants.DynamicNavigation.DYNAMIC_NAVIGATION))
            {
                ucDynamicPageList ucDynamicPageList = (ucDynamicPageList)LoadControl("~/usercontrols/navigation/ucDynamicPageList.ascx");
                strNav = strNav.Replace(PortalConstants.DynamicNavigation.DYNAMIC_NAVIGATION, ucDynamicPageList.SetDynamicPages(PageName, IsCustomURL));
            }

            return strNav;
        }

        private string LoadRelatedPages(String strNav, Entities.DynamicPages dumppage)
        {
            string strtorepalce = string.Empty;


            strtorepalce = string.Empty;

            if (dumppage != null && strNav.Contains(PortalConstants.DynamicNavigation.RELATED_PAGES))
            {
                Entities.DynamicPages page = DynamicPagesService.GetBySiteIdLanguageIdPageFriendlyName(SessionData.Site.SiteId, SessionData.Language.LanguageId, dumppage.PageFriendlyName);
                if (page != null)
                {
                    DataSet ds = RelatedDynamicPagesService.CustomGetByDynamicPageID(page.DynamicPageId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<div id=\"related-links\">\n<ul>");

                        foreach (DataRow relatedpage in ds.Tables[0].Rows)
                        {
                            dumppage.CustomUrl = (relatedpage["CustomUrl"] == null) ? string.Empty : relatedpage["CustomUrl"].ToString();
                            dumppage.HyperLink = (relatedpage["HyperLink"] == null) ? string.Empty : relatedpage["HyperLink"].ToString();
                            dumppage.PageFriendlyName = (relatedpage["PageFriendlyName"] == null) ? string.Empty : relatedpage["PageFriendlyName"].ToString();
                            dumppage.OpenInNewWindow = Convert.ToBoolean(relatedpage["OpenInNewWindow"].ToString());
                            dumppage.PageTitle = (relatedpage["PageTitle"] == null) ? string.Empty : relatedpage["PageTitle"].ToString();

                            sb.AppendFormat("<li>{0}</li>", DynamicPagesService.GetDynamicPageLink(dumppage, string.Empty));
                        }

                        sb.Append("</ul>\n</div>");
                        strtorepalce = sb.ToString();
                    }
                }
            }


            strNav = strNav.Replace(PortalConstants.DynamicNavigation.RELATED_PAGES, strtorepalce);


            return strNav;
        }

        #endregion
    }
}