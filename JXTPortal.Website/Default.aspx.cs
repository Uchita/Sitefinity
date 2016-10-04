#region Using Directives
using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using JXTPortal.Entities;
#endregion

namespace JXTPortal.Website
{
    [CLSCompliant(false)]
    public partial class _Default : DefaultBase
    {

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

        private GlobalSettingsService _globalSettingsService = null;

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                {
                    _globalSettingsService = new GlobalSettingsService();
                }
                return _globalSettingsService;
            }
        }
        #endregion

        /// <summary>
        /// Handles the Load event of the Page class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Todo Remove
            //if (Request.QueryString["code"] != "" && !string.IsNullOrWhiteSpace(Request.QueryString["code"]))
            //    Response.Redirect("~/member/aicd/login.aspx?code=" + Request.QueryString["code"]);

            if (!Page.IsPostBack)
            {
                SetContent();
            }

            // ToDo - Enable View state disable for the controls
        }

        protected void SetContent()
        {
            if (SessionData.Site != null && SessionData.Language != null)
            {
                using (TList<JXTPortal.Entities.GlobalSettings> globalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                {
                    if (globalSettings.Count > 0 && globalSettings[0].DefaultDynamicPageId.HasValue)
                    {
                        using (TList<Entities.DynamicPages> dynamicPage =
                                            DynamicPagesService.GetByDynamicPageIdLanguageId(
                                                SessionData.Site.SiteId,
                                                globalSettings[0].DefaultDynamicPageId.Value,
                                                SessionData.Language.LanguageId))
                        {
                            if (dynamicPage.Count > 0)
                            {
                                string strHeader = string.Empty, strFooter = string.Empty, strLefNav = string.Empty, strRightNav = string.Empty;
                                string strAboveHeader = string.Empty; string strBelowFooter = string.Empty;

                                ltlContent.Text = CommonAdvancedSearch.GetAdvancedSearchWidget((dynamicPage[0].PageContent));

                                if (dynamicPage[0].DynamicPageWebPartTemplateId.HasValue)
                                {
                                    DynamicPagesService.SetDynamicPageWebPartTemplateId(dynamicPage[0].DynamicPageWebPartTemplateId.Value,
                                                                                            ref strHeader, ref strLefNav,
                                                                                            ref strRightNav, ref strFooter, ref strAboveHeader, ref strBelowFooter, CommonPage.PageName);
                                }

                                SetMetaContentWithFavIcon(ltlMetaContent, null, Page, dynamicPage[0].PageTitle, string.Empty, string.Empty, true, false);

                                // Dynamic Search widget - example {widget-22}
                                ltlHeader.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strHeader);
                                ltlLeftNavigation.Text = string.Empty;
                                ltlRightNavigation.Text = string.Empty;
                                ltlAboveHeader.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strAboveHeader);
                                ltlBelowFooter.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strBelowFooter);


                                PageBase pageBase = new PageBase();

                                //replace sign in/out for member dashboard
                                ltlHeader.Text = pageBase.LoadMemberSignAndOutAndDashboard(ltlHeader.Text);
                                ltlAboveHeader.Text = pageBase.LoadMemberSignAndOutAndDashboard(ltlAboveHeader.Text);
                                ltlBelowFooter.Text = pageBase.LoadMemberSignAndOutAndDashboard(ltlBelowFooter.Text);

                                // Replace login status menu
                                ltlHeader.Text = pageBase.LoadLoginStatusMenu(ltlHeader.Text);
                                ltlAboveHeader.Text = pageBase.LoadLoginStatusMenu(ltlAboveHeader.Text);
                                ltlBelowFooter.Text = pageBase.LoadLoginStatusMenu(ltlBelowFooter.Text);

                                // Replace member counters
                                ltlHeader.Text = pageBase.LoadMemberResultCounters(ltlHeader.Text);
                                ltlAboveHeader.Text = pageBase.LoadMemberResultCounters(ltlAboveHeader.Text);
                                ltlBelowFooter.Text = pageBase.LoadMemberResultCounters(ltlBelowFooter.Text);

                                // Remove Breadcrumbs from Homepage
                                ltlHeader.Text = ltlHeader.Text.Replace(PortalConstants.DynamicNavigation.WEBPART_BREADCRUMB, string.Empty);
                                ltlAboveHeader.Text = ltlAboveHeader.Text.Replace(PortalConstants.DynamicNavigation.WEBPART_BREADCRUMB, string.Empty);
                                ltlBelowFooter.Text = ltlBelowFooter.Text.Replace(PortalConstants.DynamicNavigation.WEBPART_BREADCRUMB, string.Empty);


                                plHeader.Visible = !string.IsNullOrEmpty(strHeader);

                                if (!String.IsNullOrEmpty(strFooter))
                                    ltlFooter.Text = String.Format("<div id='footer'>{0}</div><!--end of footer-->", CommonAdvancedSearch.GetAdvancedSearchWidget(strFooter));

                                // Don't display Left and Right Navigation
                                /*
                                if (!String.IsNullOrEmpty(ltlLeftNavigation.Text))
                                    ltlLeftNavigation.Text = String.Format("<div id='side-left'>{0}</div><!--end of side left-->", ltlLeftNavigation.Text);

                                if (!String.IsNullOrEmpty(ltlRightNavigation.Text))
                                    ltlRightNavigation.Text = String.Format("<div id='side-right'>{0}</div><!--end of side-right-->", ltlRightNavigation.Text);
                                */

                                // Load CSS and Javascript
                                ltlCSSAndScripts.Text = DynamicPagesService.GetDynamicPageJavascriptCSS(dynamicPage[0].PageName);
                            }
                        }
                    }
                }
            }

        }

    }
}
