

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Web.UI.WebControls;
using System.Text;
using JXTPortal.Common;
using System.Text.RegularExpressions;

#endregion

namespace JXTPortal
{
    /// <summary>
    /// An component type implementation of the 'DynamicPages' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class DynamicPagesService : JXTPortal.DynamicPagesServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the DynamicPagesService class.
        /// </summary>
        public DynamicPagesService()
            : base()
        {
        }
        #endregion Constructors

        #region Dynamic Page Urls

        public string GetDynamicPageUrl(string pageName, string level1, string level2, string level3)
        {
            if (!string.IsNullOrEmpty(pageName))
            {
                if (!string.IsNullOrEmpty(level1))
                    level1 += "/";

                if (!string.IsNullOrEmpty(level2))
                    level2 += "/";

                if (!string.IsNullOrEmpty(level3))
                    level3 += "/";

                return string.Format("~/page/{0}{1}{2}{3}/", level1, level2, level3, pageName);
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetDynamicPageLink(DynamicPages dynamicPage, string strClass)
        {
            string url = string.Empty;
            string target = string.Empty;
            if (!string.IsNullOrEmpty(dynamicPage.CustomUrl) && string.IsNullOrEmpty(dynamicPage.CustomUrl) == false)
            {
                url = "/" + dynamicPage.CustomUrl;
            }
            else if (!string.IsNullOrEmpty(dynamicPage.HyperLink.Trim()))
            {
                if (dynamicPage.HyperLink.StartsWith("http://") || dynamicPage.HyperLink.StartsWith("https://") || dynamicPage.HyperLink.StartsWith("/"))
                {
                    url = dynamicPage.HyperLink;
                }
                else
                {
                    url = "/page/" + dynamicPage.HyperLink;
                }
            }
            else
                url = "/page/" + dynamicPage.PageFriendlyName + "/";

            if (dynamicPage.OpenInNewWindow)
                target = " target='_blank'";

            return String.Format("<a href='{0}'{1} {2}>{3}</a>", url, target, strClass, dynamicPage.PageTitle);
        }

        public string GetDynamicPageLinkDS(DataRowView dynamicPageRow, string strClass)
        {
            string url = string.Empty;
            string target = string.Empty;

            if (!string.IsNullOrEmpty(dynamicPageRow["HyperLink"].ToString().Trim()))
                if (dynamicPageRow["HyperLink"].ToString().StartsWith("http://") || dynamicPageRow["HyperLink"].ToString().StartsWith("https://") || dynamicPageRow["HyperLink"].ToString().StartsWith("/"))
                {
                    url = dynamicPageRow["HyperLink"].ToString();
                }
                else
                {
                    url = "/page/" + dynamicPageRow["HyperLink"].ToString();
                }
            else
                url = "/page/" + dynamicPageRow["PageFriendlyName"].ToString() + "/"; ;

            if (Convert.ToBoolean(dynamicPageRow["OpenInNewWindow"]))
                target = " target='_blank'";

            return String.Format("<a href='{0}'{1} {2}>{3}</a>", url, target, strClass, dynamicPageRow["PageTitle"].ToString());
        }

        public string GetDynamicPageUrl(DynamicPages dynamicPage)
        {
            string str = string.Empty;

            if (!string.IsNullOrEmpty(dynamicPage.CustomUrl) && string.IsNullOrEmpty(dynamicPage.CustomUrl) == false)
            {
                str = "/" + dynamicPage.CustomUrl;
            }
            else if (!string.IsNullOrEmpty(dynamicPage.HyperLink.Trim()))
            {
                if (dynamicPage.HyperLink.StartsWith("http://") || dynamicPage.HyperLink.StartsWith("https://") || dynamicPage.HyperLink.StartsWith("/"))
                {
                    str = dynamicPage.HyperLink;
                }
                else
                {
                    str = "/page/" + dynamicPage.HyperLink;
                }
            }
            else
                str = "/page/" + dynamicPage.PageFriendlyName + "/";

            /*else if (!string.IsNullOrEmpty(dynamicPage.HyperLink))
            {
                str = "/page/" + dynamicPage.HyperLink;
            }
            else
            {
                int parentdynamicpageid = dynamicPage.ParentDynamicPageId;

                while (parentdynamicpageid != 0)
                {
                    Entities.DynamicPages dp = GetByDynamicPageId(parentdynamicpageid);
                    str = dp.PageFriendlyName + "/" + str;

                    parentdynamicpageid = dp.ParentDynamicPageId;
                }

                str += dynamicPage.PageFriendlyName;
            }*/

            return str.ToString();
        }

        public string GetDynamicPageFullUrl(string siteurl, DynamicPages dynamicPage, bool blnWWWRedirect, bool blnSSL)
        {
            string str = string.Empty;

            if (!string.IsNullOrEmpty(dynamicPage.CustomUrl) && string.IsNullOrEmpty(dynamicPage.CustomUrl) == false)
            {
                str = "/" + dynamicPage.CustomUrl;
            }
            else if (!string.IsNullOrEmpty(dynamicPage.HyperLink.Trim()))
            {
                if (dynamicPage.HyperLink.StartsWith("http://") || dynamicPage.HyperLink.StartsWith("https://") || dynamicPage.HyperLink.StartsWith("/"))
                {
                    str = dynamicPage.HyperLink;
                }
                else
                {
                    str = "/page/" + dynamicPage.HyperLink;
                }
            }
            else
                str = "/page/" + dynamicPage.PageFriendlyName + "/";


            if (!str.StartsWith("http"))
                str = (blnSSL ? "https://" : "http://") + (blnWWWRedirect ? "www." : string.Empty) + siteurl + str;

            return str;
        }

        #endregion

        #region Dynamic Pages Navigation

        public string CheckForNavigation(int languageID, string strContent)
        {
            return CheckForNavigation(languageID, strContent, string.Empty);
        }

        public string CheckForNavigation(int languageID, string strContent, string pageName)
        {
            String strMatch = @"\[\[(.+?)\]\]";
            MatchCollection matches = Regex.Matches(strContent, strMatch);
            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    switch (capture.Value)
                    {
                        case PortalConstants.DynamicNavigation.TOP_DEFAULT_MENU:
                            strContent = strContent.Replace(PortalConstants.DynamicNavigation.TOP_DEFAULT_MENU,
                                                                LoadNavigation(languageID, true, false, false, "sf-menu"));
                            break;

                        case PortalConstants.DynamicNavigation.TOP_VERTICAL_MENU:
                            strContent = strContent.Replace(PortalConstants.DynamicNavigation.TOP_VERTICAL_MENU,
                                                                LoadNavigation(languageID, true, false, false, "sf-menu sf-vertical"));
                            break;

                        case PortalConstants.DynamicNavigation.TOP_NAVBAR_MENU:
                            strContent = strContent.Replace(PortalConstants.DynamicNavigation.TOP_NAVBAR_MENU,
                                                                LoadNavigation(languageID, true, false, false, "sf-menu sf-navbar", pageName));
                            break;


                        case PortalConstants.DynamicNavigation.LEFT_DEFAULT_MENU:
                            strContent = strContent.Replace(PortalConstants.DynamicNavigation.LEFT_DEFAULT_MENU,
                                                                LoadNavigation(languageID, false, true, false, "sf-menu"));
                            break;

                        case PortalConstants.DynamicNavigation.LEFT_VERTICAL_MENU:
                            strContent = strContent.Replace(PortalConstants.DynamicNavigation.LEFT_VERTICAL_MENU,
                                                                LoadNavigation(languageID, false, true, false, "sf-menu sf-vertical"));
                            break;

                        case PortalConstants.DynamicNavigation.LEFT_NAVBAR_MENU:
                            strContent = strContent.Replace(PortalConstants.DynamicNavigation.LEFT_NAVBAR_MENU,
                                                                LoadNavigation(languageID, false, true, false, "sf-menu sf-navbar"));
                            break;

                        case PortalConstants.DynamicNavigation.FOOTER_DEFAULT_MENU:
                            strContent = strContent.Replace(PortalConstants.DynamicNavigation.FOOTER_DEFAULT_MENU,
                                                                LoadFooterNavigation(languageID, true, "footer-menu"));
                            break;

                        default:
                            break;
                    }
                }
            }

            return strContent;
        }

        public string LoadFooterNavigation(int languageID, bool onFooterNav, string strTag)
        {
            StringBuilder strDynamicPages = new StringBuilder();

            using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList =
                        GetNavigation(SessionData.Site.SiteId, languageID, false, false, onFooterNav))
            {
                // Order by Sequence
                DynamicPagesList.Sort("Sequence");

                strDynamicPages.Append(String.Format("<ul>"));
                for (int i = 0; i < DynamicPagesList.Count; i++)
                {
                    if (DynamicPagesList[i].ParentDynamicPageId == 0 && DynamicPagesList[i].Valid)
                    {
                        strDynamicPages.Append(String.Format(@"<li>{0}</li>", GetDynamicPageLink(DynamicPagesList[i], string.Empty)));
                    }
                }
                strDynamicPages.Append("</ul>");
            }

            return strDynamicPages.ToString();
        }

        public string LoadNavigation(int languageID, bool onMainNavigation, bool onDynamicPageNavigation, bool onFooterNav, string strTag)
        {
            return LoadNavigation(languageID, onMainNavigation, onDynamicPageNavigation, onFooterNav, strTag, string.Empty);
        }

        public string LoadNavigation(int languageID, bool onMainNavigation, bool onDynamicPageNavigation, bool onFooterNav, string strTag, string pageName)
        {
            StringBuilder strDynamicPages = new StringBuilder();
            string strPageLink = string.Empty;

            using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList =
                        GetNavigation(SessionData.Site.SiteId, languageID, onMainNavigation, onDynamicPageNavigation, onFooterNav))
            {

                // Order by Sequence
                DynamicPagesList.Sort("Sequence");

                TList<JXTPortal.Entities.DynamicPages> DynamicPagesList_1 = DynamicPagesList;

                strDynamicPages.Append(String.Format("<ul>"));

                for (int i = 0; i < DynamicPagesList.Count; i++)
                {
                    if (DynamicPagesList[i].ParentDynamicPageId == 0)
                    {
                        string strActive = string.Empty;
                        if (!string.IsNullOrEmpty(pageName))
                        {
                            if (strTag == "sf-menu sf-navbar" && pageName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0].Equals(DynamicPagesList[i].PageFriendlyName))
                            {
                                strActive = " class='topnav-active'";
                            }
                        }

                        strPageLink = String.Format(GetDynamicPageLink(DynamicPagesList[i], strActive));

                        strDynamicPages.Append(String.Format(@"<li>{0}{1}</li>",
                                                            strPageLink,
                                                            GetFirstLevelDynamicPages(DynamicPagesList_1,
                                                            DynamicPagesList[i].DynamicPageId)));

                    }
                }
                strDynamicPages.Append("</ul>");
            }

            return strDynamicPages.ToString();
        }

        private string GetFirstLevelDynamicPages(TList<JXTPortal.Entities.DynamicPages> DynamicPagesList, int parentDynamicPageID)
        {
            StringBuilder strDynamicPages = new StringBuilder();
            Boolean blnRecords = false;

            strDynamicPages.Append("<ul>");
            for (int i = 0; i < DynamicPagesList.Count; i++)
            {

                if (DynamicPagesList[i].ParentDynamicPageId == parentDynamicPageID)
                {
                    blnRecords = true;


                    strDynamicPages.Append(String.Format("<li>{0}{1}</li>",
                            GetDynamicPageLink(DynamicPagesList[i], string.Empty),
                            GetSecondLevelDynamicPages(DynamicPagesList, DynamicPagesList[i].DynamicPageId)));
                }
            }
            strDynamicPages.Append("</ul>");

            if (blnRecords)
            {
                return strDynamicPages.ToString();
            }

            return string.Empty;
        }

        private string GetSecondLevelDynamicPages(TList<JXTPortal.Entities.DynamicPages> DynamicPagesList,
                                                    int parentDynamicPageID)
        {

            StringBuilder strDynamicPages = new StringBuilder();
            Boolean blnRecords = false;

            strDynamicPages.Append("<ul>");
            for (int i = 0; i < DynamicPagesList.Count; i++)
            {
                if (DynamicPagesList[i].ParentDynamicPageId == parentDynamicPageID)
                {
                    blnRecords = true;
                    strDynamicPages.Append(String.Format("<li>{0}</li>",
                            GetDynamicPageLink(DynamicPagesList[i], string.Empty)));

                }
            }
            strDynamicPages.Append("</ul>");

            if (blnRecords)
            {
                return strDynamicPages.ToString();
            }

            return string.Empty;
        }

        #endregion

        public String GetDynamicPageJavascriptCSS(String pageName)
        {
            return GetDynamicPageCSS(pageName) + GetDynamicPageJavascript(pageName);
        }

        /// <summary>
        /// Get Dynamic Page CSS by PageName
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public String GetDynamicPageCSS(String pageName)
        {
            StringBuilder strBuilder = new StringBuilder();
            FilesService filesService = new FilesService();
            using (TList<Files> files = filesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, pageName,
                                                        Convert.ToInt32(PortalEnums.Files.FileTypes.CSS)))
            {
                foreach (Files file in files)
                {
                    strBuilder.Append(String.Format(@"
<link rel='stylesheet' href='{0}' type='text/css' media='screen' />", file.FileSystemName.ToString()));
                }
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Get Dynamic Page Javascript by PageName
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public String GetDynamicPageJavascript(String pageName)
        {
            StringBuilder strBuilder = new StringBuilder();
            FilesService filesService = new FilesService();
            using (TList<Files> files = filesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, pageName,
                                                            Convert.ToInt32(PortalEnums.Files.FileTypes.Javascript)))
            {
                foreach (Files file in files)
                {
                    strBuilder.Append(String.Format(@"
<script type='text/javascript' language='javascript' src='{0}'></script>", file.FileSystemName.ToString()));
                }
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Display the Dynamic Page Containers
        /// </summary>
        /// <param name="dynamicPageWebPartTemplateId"></param>
        /// 

        public void SetDynamicPageWebPartTemplateId(int dynamicPageWebPartTemplateId,
                                                    ref String strHeader, ref String strLeftNavigation,
                                                    ref String strRightNavigation, ref String strFooter, ref String strAboveHeader, ref String strBelowFooter)
        {
            SetDynamicPageWebPartTemplateId(dynamicPageWebPartTemplateId,
                                                    ref strHeader, ref strLeftNavigation,
                                                    ref strRightNavigation, ref strFooter, ref strAboveHeader, ref strBelowFooter, string.Empty);
        }

        public void SetDynamicPageWebPartTemplateId(int dynamicPageWebPartTemplateId,
                                                    ref String strHeader, ref String strLeftNavigation,
                                                    ref String strRightNavigation, ref String strFooter,
                                                    ref String strAboveHeader, ref String strBelowFooter, string pageName)
        {

            strHeader = String.Empty; strLeftNavigation = String.Empty;
            strRightNavigation = String.Empty; strFooter = String.Empty;
            strAboveHeader = String.Empty; strBelowFooter = String.Empty;

            JXTPortal.SiteWebPartsService siteWebPartsService = new SiteWebPartsService();
            using (TList<Entities.SiteWebParts> siteWebParts = siteWebPartsService.GetByDynamicPageContainerID(dynamicPageWebPartTemplateId))
            {
                foreach (Entities.SiteWebParts siteWebPart in siteWebParts)
                {

                    switch (siteWebPart.SiteWebPartTypeId)
                    {
                        case ((int)(Entities.PortalEnums.SiteWebParts.SiteWebPartTypes.Header)):
                            {
                                strHeader = strHeader + siteWebPart.SiteWebPartHtml;
                            }
                            break;
                        case ((int)(Entities.PortalEnums.SiteWebParts.SiteWebPartTypes.LeftNavigation)):
                            {
                                strLeftNavigation = strLeftNavigation + siteWebPart.SiteWebPartHtml;
                            }
                            break;
                        case ((int)(Entities.PortalEnums.SiteWebParts.SiteWebPartTypes.RightNavigation)):
                            {
                                strRightNavigation = strRightNavigation + siteWebPart.SiteWebPartHtml;
                            }
                            break;
                        case ((int)(Entities.PortalEnums.SiteWebParts.SiteWebPartTypes.Footer)):
                            {
                                strFooter = strFooter + siteWebPart.SiteWebPartHtml;
                            }
                            break;
                        case ((int)(Entities.PortalEnums.SiteWebParts.SiteWebPartTypes.AboveHeader)):
                            {
                                strAboveHeader = strAboveHeader + siteWebPart.SiteWebPartHtml;
                            }
                            break;
                        case ((int)(Entities.PortalEnums.SiteWebParts.SiteWebPartTypes.BelowFooter)):
                            {
                                strBelowFooter = strBelowFooter + siteWebPart.SiteWebPartHtml;
                            }
                            break;
                    }
                }
            }


            #region Replace Navigation

            if (!String.IsNullOrEmpty(strHeader))
            {
                strHeader = CheckForNavigation(SessionData.Language.LanguageId, strHeader, pageName);
            }

            if (!String.IsNullOrEmpty(strLeftNavigation))
            {
                strLeftNavigation = CheckForNavigation(SessionData.Language.LanguageId, strLeftNavigation);
            }

            if (!String.IsNullOrEmpty(strRightNavigation))
            {
                strRightNavigation = CheckForNavigation(SessionData.Language.LanguageId, strRightNavigation);
            }

            if (!String.IsNullOrEmpty(strFooter))
            {
                strFooter = CheckForNavigation(SessionData.Language.LanguageId, strFooter);
            }

            if (!String.IsNullOrEmpty(strAboveHeader))
            {
                strAboveHeader = CheckForNavigation(SessionData.Language.LanguageId, strAboveHeader, pageName);
            }

            if (!String.IsNullOrEmpty(strBelowFooter))
            {
                strBelowFooter = CheckForNavigation(SessionData.Language.LanguageId, strBelowFooter);
            }

            #endregion

        }

        public override bool Insert(DynamicPages entity)
        {
            entity.PageName = entity.PageName.Replace("'", "");

            return base.Insert(SearchIndex(entity));
        }

        public override bool Update(DynamicPages entity)
        {
            entity.PageName = entity.PageName.Replace("'", "");

            return base.Update(SearchIndex(entity));
        }

        private DynamicPages SearchIndex(DynamicPages entity)
        {
            if (entity.PageName.Contains("SystemPage"))
            {
                entity.SearchField = null;
                entity.Searchable = false;
            }
            else
            {
                if (entity.Searchable)
                {
                    //Todo - Remove Special characters - Decode the html and remove special characters
                    entity.SearchField = String.Format("{0} {1} {2} {3}",
                                                        Utils.CleanStringSpaces(Utils.StripHTML(Utils.CleanScriptStyleTags(Utils.SpecialCharsSearchField(entity.PageContent)))),
                                                        Utils.SpecialCharsSearchField(entity.PageTitle),
                                                        Utils.SpecialCharsSearchField(entity.PageName),
                                                        Utils.SpecialCharsSearchField(entity.MetaKeywords).Trim());
                }
                else
                    entity.SearchField = string.Empty;
            }
            return entity;
        }

        //TODO
        /*
        public override DynamicPages GetBySiteIdLanguageIdPageFriendlyName(int _siteId, int _languageId, string _pageFriendlyName)
        {
            //TODO: throw the exception
            return base.GetBySiteIdLanguageIdPageFriendlyName(_siteId, _languageId, _pageFriendlyName);
        }

        public DynamicPages GetBySiteIdLanguageIdPageFriendlyName(int _siteId, int _languageId, string _pageFriendlyName, AdminUsers adminUser)
        {
            DynamicPages dynamicPages =  base.GetBySiteIdLanguageIdPageFriendlyName(_siteId, _languageId, _pageFriendlyName);

            if (dynamicPages.Secured && adminUser == null)
            { 
                //security exception
                
            }
        }
        */
    }//End Class

} // end namespace
