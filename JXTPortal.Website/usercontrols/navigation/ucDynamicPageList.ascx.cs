using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Text;
using JXTPortal.Common;

namespace JXTPortal.Website.usercontrols.navigation
{
    public partial class ucDynamicPageList : System.Web.UI.UserControl
    {

        #region Declare variables

        private DynamicPagesService _dynamicPagesService;
        string strSelectedpage = string.Empty;
        string _PageName = CommonPage.PageName;
        #endregion

        #region Properties
        
        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null) _dynamicPagesService = new DynamicPagesService();
                return _dynamicPagesService;
            }
        }

        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            //SetDynamicPages(CommonPage.PageName, CommonPage.IsCustomURL);
        }

        #endregion

        #region Methods

        public string SetDynamicPages(string PageName, bool IsCustomURL)
        {
            _PageName = PageName;

            // If Pagename Exists and its not a System Page
            if (PageName.Length > 0)
            {
                int pageID = 0;
                if (IsCustomURL)
                {
                    using (TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        foreach (JXTPortal.Entities.DynamicPages dynamicpage in dynamicpages)
                        {
                            if (dynamicpage.LanguageId == SessionData.Language.LanguageId && string.IsNullOrEmpty(dynamicpage.CustomUrl) == false
                                && dynamicpage.CustomUrl.TrimEnd(new char[] { '/' }) == PageName.TrimEnd(new char[] { '/' }))
                            {
                                PageName = dynamicpage.PageFriendlyName;
                                break;
                            }
                        }
                    }
                }

                using (JXTPortal.Entities.DynamicPages dynamicPage = DynamicPagesService.GetBySiteIdLanguageIdPageFriendlyName(SessionData.Site.SiteId, SessionData.Language.LanguageId, PageName))
                {
                    if (dynamicPage != null && dynamicPage.DynamicPageId > 0
                            && (!dynamicPage.PageName.ToLower().Contains(Utils.GetAppSettings("DefaultPageCodeForLayout").ToLower())))
                    {
                        pageID = dynamicPage.DynamicPageId;
                    }
                }

                if (pageID > 0)
                {
                    StringBuilder strDynamicPages = new StringBuilder();
                    string strActive = string.Empty;

                    using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList =
                                DynamicPagesService.GetHierarchyByChild(SessionData.Site.SiteId, SessionData.Language.LanguageId, pageID))
                    {
                        DynamicPagesList.Filter = "Valid = true";
                        string strPageLink = string.Empty;

                        // Order by Sequence
                        DynamicPagesList.Sort("Sequence");

                        TList<JXTPortal.Entities.DynamicPages> DynamicPagesList_1 = DynamicPagesList;

                        strDynamicPages.Append("<ul>");

                        for (int i = 0; i < DynamicPagesList.Count; i++)
                        {
                            if (DynamicPagesList[i].ParentDynamicPageId == 0)
                            {
                                if (PageName.Equals(DynamicPagesList[i].PageFriendlyName))
                                {
                                    strActive = " class='leftnav-active'";
                                    strSelectedpage = DynamicPagesList[i].PageTitle;
                                }
                                else
                                    strActive = string.Empty;

                                strPageLink = String.Format(DynamicPagesService.GetDynamicPageLink(DynamicPagesList[i], strActive));

                                strDynamicPages.Append(String.Format(@"<li>{0}{1}</li>",
                                                                    strPageLink,
                                                                    GetFirstLevelDynamicPages(DynamicPagesList_1,
                                                                    DynamicPagesList[i].DynamicPageId)));

                            }


                        }
                        strDynamicPages.Append("</ul>");
                    }

                    return String.Format(@"{0}", strDynamicPages.ToString());
                    
                }
            }

            return string.Empty;
        }

        private string GetFirstLevelDynamicPages(TList<JXTPortal.Entities.DynamicPages> DynamicPagesList, int parentDynamicPageID)
        {
            StringBuilder strDynamicPages = new StringBuilder();
            string strActive = string.Empty;
            Boolean blnRecords = false;

            strDynamicPages.Append("<ul>");
            for (int i=0; i < DynamicPagesList.Count; i++)
            {

                if (DynamicPagesList[i].ParentDynamicPageId == parentDynamicPageID)
                {
                    blnRecords = true;

                    if (_PageName.Equals(DynamicPagesList[i].PageFriendlyName))
                    {
                        strActive = " class='leftnav-active'";
                        strSelectedpage = DynamicPagesList[i].PageTitle;
                    }
                    else
                        strActive = string.Empty;
                    
                    strDynamicPages.Append(String.Format("<li>{0}{1}</li>",
                            DynamicPagesService.GetDynamicPageLink(DynamicPagesList[i], strActive),
                            GetSecondLevelDynamicPages(DynamicPagesList, DynamicPagesList[i].DynamicPageId)));

                    strActive = string.Empty;
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
            string strActive = string.Empty;
            Boolean blnRecords = false;

            strDynamicPages.Append("<ul>");
            for (int i = 0; i < DynamicPagesList.Count; i++)
            {
                if (DynamicPagesList[i].ParentDynamicPageId == parentDynamicPageID)
                {

                    if (_PageName.Equals(DynamicPagesList[i].PageFriendlyName))
                    {
                        strActive = " class='leftnav-active'";
                        strSelectedpage = DynamicPagesList[i].PageTitle;
                    }
                    else
                        strActive = string.Empty;

                    blnRecords = true;
                    strDynamicPages.Append(String.Format("<li>{0}</li>",
                            DynamicPagesService.GetDynamicPageLink(DynamicPagesList[i], strActive)));

                    strActive = string.Empty;
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

    }
}