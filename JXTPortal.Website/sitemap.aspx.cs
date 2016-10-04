using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

using JXTPortal.Entities;
using System.Text;

namespace JXTPortal.Website
{
    public partial class sitemap : System.Web.UI.Page
    {
        #region Declaration

        DynamicPagesService _dynamicpagesService;
        string CurrentParentName = "";
        string CurrentChildName = "";
        string CurrentGrandChildName = "";
        #endregion

        #region Properties

        DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicpagesService == null)
                {
                    _dynamicpagesService = new DynamicPagesService();
                }
                return _dynamicpagesService;
            }
        }

        public string StrPageName
        {
            get
            {
                string strPageName = "";

                if (!String.IsNullOrEmpty(CommonPage.PageName))
                {
                    string[] strPageNames = CommonPage.PageName.Split(new char[] { '/' });
                    strPageName = strPageNames[strPageNames.Length - 1];
                }

                return strPageName;
            }
        }

        #endregion

        #region Page
        protected void Page_Init(object sender, EventArgs e)
        {
            //CommonPage.SetBrowserPageTitle(Page, "Site Map");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string strTest = LoadNavigation();
            litSiteMap.Text = strTest;
        }
        #endregion

        #region Methods

        public string LoadNavigation()
        {
            StringBuilder strDynamicPages = new StringBuilder();
            using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList =
                        DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, SessionData.Language.LanguageId, 0, true, true, true))
            {
                // Order by Sequence
                DynamicPagesList.Sort("Sequence");

                strDynamicPages.Append("<ul>");

                int intLevel = 0;
                int blnStep = 0;

                foreach (JXTPortal.Entities.DynamicPages item in DynamicPagesList)
                {
                    if (item.ParentDynamicPageId == 0)
                    {
                        strDynamicPages.Append("<li>");
                        strDynamicPages.Append(DynamicPagesService.GetDynamicPageLink(item, string.Empty));
                        strDynamicPages.Append(GetSecondLevelDynamicPages(DynamicPagesList, item.DynamicPageId));
                        strDynamicPages.Append("</li>");
                    }
                }
                strDynamicPages.Append("</ul>");

                return strDynamicPages.ToString();
            }
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
                            DynamicPagesService.GetDynamicPageLink(DynamicPagesList[i], string.Empty)));

                    strDynamicPages.Append(GetSecondLevelDynamicPages(DynamicPagesList, DynamicPagesList[i].DynamicPageId));
                }
            }
            strDynamicPages.Append("</ul>");

            if (blnRecords)
            {
                return strDynamicPages.ToString();
            }

            return string.Empty;
        }

        private string GetThirdLevelDynamicPages(TList<JXTPortal.Entities.DynamicPages> DynamicPagesList,
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
                            DynamicPagesService.GetDynamicPageLink(DynamicPagesList[i], string.Empty)));
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
