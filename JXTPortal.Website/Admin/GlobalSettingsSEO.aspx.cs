
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using JXTPortal.Web.UI;
using JXTPortal.Data;
using JXTPortal.Entities;
using JXTPortal;
using System.Linq;
#endregion

namespace JXTPortal.Website.Admin
{
    public partial class GlobalSettingsSEO : System.Web.UI.Page
    {
        #region Declaration

        //private int _globalsettingid = 0;
        private int _siteID = 0;
        private GlobalSettingsService _globalsettingsservice;
        private DynamicPagesService _dynamicPagesService;
        private SiteCountriesService _siteCountriesService;
        private JobItemsTypeService _jobItemTypeService;
        #endregion

        #region Properties

        private int SiteID
        {
            get
            {
                if ((Request.QueryString["SiteId"] != null))
                {
                    if (int.TryParse((Request.QueryString["SiteId"].Trim()), out _siteID))
                    {
                        _siteID = Convert.ToInt32(Request.QueryString["SiteId"]);
                    }
                    return _siteID;
                }

                return _siteID;
            }
            set { _siteID = value; }
        }

        public GlobalSettingsService GlobalSettingsService
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

        public DynamicPagesService DynamicPagesService
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

        public SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_siteCountriesService == null)
                {
                    _siteCountriesService = new SiteCountriesService();
                }
                return _siteCountriesService;
            }
        }

        public JobItemsTypeService JobItemTypeService
        {
            get
            {
                if (_jobItemTypeService == null)
                {
                    _jobItemTypeService = new JobItemsTypeService();
                }
                return _jobItemTypeService;
            }
        }


        #endregion

        #region Page Events
        /// <summary>
        /// Method to Load Everything needed by GlobalSettings
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteID == 0)
            {
                SiteID = SessionData.Site.SiteId;
            }
            ltlMessage.Text = string.Empty;

            if (!Page.IsPostBack)
            {
                //LoadSites();
                //LoadBlankHomePageDynamicPage();
                LoadGlobalSetting();

            }
        }

        #endregion

        #region Click Events

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                JXTPortal.Entities.GlobalSettings globalSetting = null;

                if (SiteID > 0)
                    globalSetting = GlobalSettingsService.GetGlobalSettingBySiteID(SiteID);
                else
                    globalSetting = new JXTPortal.Entities.GlobalSettings();

                //globalSetting.GlobalSettingId = GlobalSettingId;
                globalSetting.SiteId = SiteID; //Convert.ToInt32(dataSite.SelectedValue);

                bool siteTypeChanged = false;

                // Approval Process Settings
                
                globalSetting.PrivateMembers = false;
                globalSetting.PrivateCompanies = false;
                globalSetting.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                globalSetting.LastModified = DateTime.Now;

                globalSetting.GoogleTagManager = tbGoogleTagManager.Text;
                globalSetting.GoogleAnalytics = tbGoogleAnalytics.Text;
                globalSetting.GoogleWebMaster = tbGoogleWebMaster.Text;

                globalSetting.PageTitlePrefix = dataPageTitlePrefix.Text;
                globalSetting.PageTitleSuffix = dataPageTitleSuffix.Text;
                globalSetting.DefaultTitle = dataDefaultTitle.Text;
                globalSetting.HomeTitle = dataHomeTitle.Text;
                globalSetting.DefaultDescription = dataDescription.Text;
                globalSetting.HomeDescription = dataHomeDescription.Text;
                globalSetting.DefaultKeywords = dataDefaultKeywords.Text;
                globalSetting.HomeKeywords = dataHomeKeywords.Text;
                globalSetting.FtpFolderLocation = dataFTPFolder.Text.TrimStart(new char[] { '/' }).TrimEnd(new char[] { '/' });
                globalSetting.ShowFaceBookButton = false;

                if (pnlMeta.Visible)
                {
                    globalSetting.MetaTags = txtMetaTags.Text.Trim();
                    globalSetting.SystemMetaTags = txtSystemPages.Text.Trim();
                }
                globalSetting.ShowTwitterButton = false;
                globalSetting.ShowJobAlertButton = false;
                globalSetting.ShowLinkedInButton = false;
                //globalSetting.CurrencySymbol = dataCurrencySymbol.Text.Trim();

                if (SiteID > 0)
                    GlobalSettingsService.Update(globalSetting);
                else
                    GlobalSettingsService.Insert(globalSetting);

                SessionData.Site.DefaultLanguageId = globalSetting.DefaultLanguageId;

                globalSetting.Dispose();

                //reassign the site object in the session
                if (siteTypeChanged)
                {
                    SitesService ss = new SitesService();
                    SessionService.SetSite(ss.FindSite(SessionData.Site.SiteId, string.Empty));
                    //dispose
                    ss = null;
                }

                AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "CharaterCount", "CharaterCount(\"dataDefaultTitle\", \"spTitleCount\", 69); CharaterCount(\"dataDescription\", \"spDescriptionCount\", 160); CharaterCount(\"dataDefaultKeywords\", \"spKeywordsCount\", 256);" +
                "CharaterCount(\"dataHomeTitle\", \"spHomeCount\", 69); CharaterCount(\"dataHomeDescription\", \"spHomeDescriptionCount\", 160); CharaterCount(\"dataHomeKeywords\", \"spHomeKeywordsCount\", 256);", true);

                if (((Button)sender).Text == "Update")
                {
                    ltlMessage.Text = "Global Settings saved successfully";
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
        #endregion

        #region Methods


        private void LoadGlobalSetting()
        {
            if (SiteID > 0)
            {
                // If the Content Editor doesnt have permission to access the page.
                if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor && SiteID != SessionData.Site.SiteId)
                {
                    Response.Redirect("default.aspx");
                }

                using (TList<JXTPortal.Entities.GlobalSettings> globalSetting = GlobalSettingsService.GetBySiteId(SiteID))
                {
                    //dataSite.SelectedValue = globalSetting.SiteId.ToString();
                    if (globalSetting.Count > 0)
                    {
                        AdminUsersService aus = new AdminUsersService();
                        using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(globalSetting[0].LastModifiedBy))
                        {
                            lblLastModifiedBy.Text = adminuser.UserName;
                        }
                        lblLastModified.Text = globalSetting[0].LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                        tbGoogleTagManager.Text = globalSetting[0].GoogleTagManager;
                        tbGoogleAnalytics.Text = globalSetting[0].GoogleAnalytics;
                        tbGoogleWebMaster.Text = globalSetting[0].GoogleWebMaster;

                        dataPageTitlePrefix.Text = globalSetting[0].PageTitlePrefix;
                        dataPageTitleSuffix.Text = globalSetting[0].PageTitleSuffix;
                        dataDefaultTitle.Text = globalSetting[0].DefaultTitle;
                        dataHomeTitle.Text = globalSetting[0].HomeTitle;
                        dataDescription.Text = globalSetting[0].DefaultDescription;
                        dataHomeDescription.Text = globalSetting[0].HomeDescription;
                        dataDefaultKeywords.Text = globalSetting[0].DefaultKeywords;
                        dataHomeKeywords.Text = globalSetting[0].HomeKeywords;
                        dataFTPFolder.Text = globalSetting[0].FtpFolderLocation;
                        //dataBlankHomePageDynamicPage.SelectedValue = globalSetting.BlankHomePageDynamicPageId.ToString();
                        txtMetaTags.Text = globalSetting[0].MetaTags;
                        txtSystemPages.Text = globalSetting[0].SystemMetaTags;
                        // cbAdvertiserApprovalProcess.Checked = (globalSetting[0].AdvertiserApprovalProcess.HasValue) ? true : false; // TODO Naveen change this //globalSetting[0].AdvertiserApprovalProcess.Value : false;

                    }
                }

            }
        }

        #endregion


        protected void cvMetaTags2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (txtSystemPages.Text.Length <= 2000);
        }

        protected void cvPageTitlePrefix_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (dataPageTitlePrefix.Text.Length <= 510);
        }

        protected void cvPageTitleSuffix_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (dataPageTitleSuffix.Text.Length <= 510);
        }

        protected void cvHomeTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (dataHomeTitle.Text.Length <= 510);
        }

        protected void cvHomeDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (dataHomeDescription.Text.Length <= 510);
        }

        protected void cvHomeKeywords_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (dataHomeKeywords.Text.Length <= 510);
        }

        protected void cvDefaultTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (dataDefaultTitle.Text.Length <= 510);
        }

        protected void cvDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (dataDescription.Text.Length <= 510);
        }

        protected void cvDefaultKeywords_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (dataDefaultKeywords.Text.Length <= 510);
        }

    }
}




