
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
    public partial class GlobalSettingsEdit : System.Web.UI.Page
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

            cbUseCustomProfessionRoles.Enabled = (SiteID == 0);
            pnlMeta.Visible = (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser);
            pnlLinkedIn.Visible = (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser);
            phProcess.Visible = (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser);
            //pnlGoogle.Visible = (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser);
            //pnlFacebook.Visible = (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser);
            if (!Page.IsPostBack)
            {
                //LoadSites();
                LoadLanguages();
                LoadCountries();
                LoadJobApplicationTypes();
                //LoadBlankHomePageDynamicPage();
                SetAdvertiserApprovalProcess();
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
                {
                    SecruityCheck();
                    globalSetting = GlobalSettingsService.GetGlobalSettingBySiteID(SiteID);
                }
                else
                    globalSetting = new JXTPortal.Entities.GlobalSettings();

                //globalSetting.GlobalSettingId = GlobalSettingId;
                globalSetting.SiteId = SiteID; //Convert.ToInt32(dataSite.SelectedValue);

                bool siteTypeChanged = false;

                if (globalSetting.SiteType != Convert.ToInt32(ddlSiteType.SelectedValue))
                    siteTypeChanged = true;

                globalSetting.SiteType = Convert.ToInt32(ddlSiteType.SelectedValue);
                globalSetting.JobExpiryNotification = cbJobExpiryNotification.Checked;
                // Approval Process Settings
                if (globalSetting.SiteType == (int)PortalEnums.Admin.SiteType.Recruiter)
                {
                    if (cbAdvertiserApprovalProcess.Checked)
                    {
                        globalSetting.AdvertiserApprovalProcess = (int)PortalEnums.Admin.AdvertiserApproval.AllApprovalProcess;
                    }
                    else
                    {
                        globalSetting.AdvertiserApprovalProcess = (int)PortalEnums.Admin.AdvertiserApproval.AutoApproved;
                    }
                }
                else
                {
                    globalSetting.AdvertiserApprovalProcess = Convert.ToInt32(ddlAdvertiserApprovalProcess.SelectedValue);
                }

                globalSetting.GlobalDateFormat = ddlDateFormat.SelectedValue;

                globalSetting.DefaultLanguageId = Convert.ToInt32(dataLanguage.SelectedValue);
                globalSetting.DefaultEmailLanguageId = Convert.ToInt32(ddlDefaultEmailLanguage.SelectedValue);
                globalSetting.DefaultCountryId = Convert.ToInt32(dataCountry.SelectedValue);
                if (dataDynamicPage.SelectedItem == null)
                    globalSetting.DefaultDynamicPageId = null;
                else
                    globalSetting.DefaultDynamicPageId = Convert.ToInt32(dataDynamicPage.SelectedValue);

                globalSetting.PublicJobsSearch = dataPublicJobSearch.Checked;
                //globalSetting.PublicMembersSearch = dataPublicMembersSearch.Checked;
                //globalSetting.PublicCompaniesSearch = dataPublicCompaniesSearch.Checked;
                globalSetting.PublicSponsoredAdverts = false;
                globalSetting.EnableSsl = cbSSLEnabled.Checked;
                globalSetting.PrivateJobs = dataPrivateJobs.Checked;
                globalSetting.PrivateMembers = false;
                globalSetting.PrivateCompanies = false;
                globalSetting.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                globalSetting.LastModified = DateTime.Now;

                globalSetting.GoogleTagManager = tbGoogleTagManager.Text;
                globalSetting.GoogleAnalytics= tbGoogleAnalytics.Text;
                globalSetting.GoogleWebMaster= tbGoogleWebMaster.Text;

                globalSetting.PageTitlePrefix = dataPageTitlePrefix.Text;
                globalSetting.PageTitleSuffix = dataPageTitleSuffix.Text;
                globalSetting.DefaultTitle = dataDefaultTitle.Text;
                globalSetting.HomeTitle = dataHomeTitle.Text;
                globalSetting.DefaultDescription = dataDescription.Text;
                globalSetting.HomeDescription = dataHomeDescription.Text;
                globalSetting.DefaultKeywords = dataDefaultKeywords.Text;
                globalSetting.HomeKeywords = dataHomeKeywords.Text;
                globalSetting.FtpFolderLocation = dataFTPFolder.Text.TrimStart(new char[] {'/'}).TrimEnd(new char[] {'/'});
                globalSetting.ShowFaceBookButton = false;
                globalSetting.PrivacySettings = dataPrivacySettings.Text;
                globalSetting.UseCustomProfessionRole = cbUseCustomProfessionRoles.Checked;
                globalSetting.GenerateJobXml = chkGenerateJobXML.Checked;
                globalSetting.JobScreeningProcess = cbJobScreeningProcess.Checked;
                // globalSetting.AdvertiserApprovalProcess = 0; //cbAdvertiserApprovalProcess.Checked; // TODO NAVEEN Change this
                
                globalSetting.IsPrivateSite = chkPrivateSite.Checked;
                if (chkPrivateSite.Checked)
                    globalSetting.PrivateRedirectUrl = txtPrivateRedirectUrl.Text;
                else
                    globalSetting.PrivateRedirectUrl = string.Empty;

                //People Search Settings
                globalSetting.EnablePeopleSearch = cbPeopleSearchCB.Checked;

                globalSetting.EnableJobCustomQuestionnaire = chkEnableJobCustomQuestionnaire.Checked;
                if (Convert.ToInt32(ddlJobApplicationTypeID.SelectedValue) > 0)
                    globalSetting.JobApplicationTypeId =  Convert.ToInt32(ddlJobApplicationTypeID.SelectedValue);
                else
                    globalSetting.JobApplicationTypeId = null;
                

                if (pnlMeta.Visible)
                {
                    globalSetting.MetaTags = txtMetaTags.Text.Trim();
                    globalSetting.SystemMetaTags = txtSystemPages.Text.Trim();
                }
                globalSetting.UseAdvertiserFilter = (dataUseAdvertiserFilter.Checked) ? 1 : 0;
                globalSetting.ShowTwitterButton = false;
                globalSetting.ShowJobAlertButton = false;
                globalSetting.ShowLinkedInButton = false;
                //globalSetting.CurrencySymbol = dataCurrencySymbol.Text.Trim();

                globalSetting.SiteDocType = dataSiteDocType.Text;
                globalSetting.MemberRegistrationNotification = txtSiteEmailMemberRegistration.Text;
                //globalSetting.SiteFavIconId = (dataSiteFavIcon.Text == "") ? (int?)null : Convert.ToInt32(dataSiteFavIcon.Text);
                globalSetting.LinkedInApi = (string.IsNullOrEmpty(tbLinkedInAPI.Text)) ? string.Empty : tbLinkedInAPI.Text;
                globalSetting.LinkedInApiSecret = (string.IsNullOrEmpty(tbLinkedInAPISecret.Text)) ? string.Empty : tbLinkedInAPISecret.Text;
                globalSetting.LinkedInLogo = (string.IsNullOrEmpty(tbLinkedInLogo.Text)) ? string.Empty : tbLinkedInLogo.Text;
                globalSetting.LinkedInCompanyId = (string.IsNullOrEmpty(tbLinkedInCompanyID.Text)) ? (int?)null : Convert.ToInt32(tbLinkedInCompanyID.Text);
                globalSetting.LinkedInEmail = (string.IsNullOrEmpty(tbLinkedInEmail.Text)) ? string.Empty : tbLinkedInEmail.Text;

                //globalSetting.GoogleClientId = (string.IsNullOrEmpty(tbGoogleClientID.Text)) ? string.Empty : tbGoogleClientID.Text;
                //globalSetting.GoogleClientSecret = (string.IsNullOrEmpty(tbGoogleClientSecret.Text)) ? string.Empty : tbGoogleClientSecret.Text;

                //globalSetting.FacebookAppId = (string.IsNullOrEmpty(tbFacebookAppID.Text)) ? string.Empty : tbFacebookAppID.Text;
                //globalSetting.FacebookAppSecret = (string.IsNullOrEmpty(tbFacebookAppSecret.Text)) ? string.Empty : tbFacebookAppSecret.Text;

                globalSetting.WwwRedirect = dataWWWRedirect.Checked;

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
                    Response.Redirect("~/Admin/SitesEdit.aspx?SiteId=" + SiteID);
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
        #endregion

        #region Methods

        private void LoadLanguages()
        {
            SiteLanguagesService languageService = new SiteLanguagesService();
            using (TList<JXTPortal.Entities.SiteLanguages> languages = languageService.GetBySiteId(SessionData.Site.SiteId))
            {
                dataLanguage.DataValueField = "LanguageID";
                dataLanguage.DataTextField = "SiteLanguageName";

                dataLanguage.DataSource = languages;
                dataLanguage.DataBind();

                ddlDefaultEmailLanguage.DataValueField = "LanguageID";
                ddlDefaultEmailLanguage.DataTextField = "SiteLanguageName";

                ddlDefaultEmailLanguage.DataSource = languages;
                ddlDefaultEmailLanguage.DataBind();
            }
            dataLanguage.Items.Insert(0, new ListItem(" Please Choose ...", "0"));

            ddlDefaultEmailLanguage.Items.Insert(0, new ListItem(" Please Choose ...", "0"));
        }

        private void LoadJobApplicationTypes()
        {
            JobApplicationTypeService service = new JobApplicationTypeService();
            using (TList<JXTPortal.Entities.JobApplicationType> items = service.GetAll())
            {
                ddlJobApplicationTypeID.DataValueField = "JobApplicationTypeID";
                ddlJobApplicationTypeID.DataTextField = "JobApplicationTypeName";

                ddlJobApplicationTypeID.DataSource = items;
                ddlJobApplicationTypeID.DataBind();
            }
            ddlJobApplicationTypeID.Items.Insert(0, new ListItem(" Please Choose ...", "0"));
        }
        private void LoadCountries()
        {

            TList<JXTPortal.Entities.SiteCountries> siteCountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId);

            dataCountry.DataTextField = "SiteCountryName";
            dataCountry.DataValueField = "CountryID";
            dataCountry.DataSource = siteCountries;
            dataCountry.DataBind();
        }

        private void LoadDynamicPages()
        {
            dataDynamicPage.Items.Clear();

            TList<JXTPortal.Entities.DynamicPages> siteDynamicPages = DynamicPagesService.GetHierarchy(SiteID > 0 ? SiteID : SessionData.Site.SiteId,
                                                                                            Convert.ToInt32(dataLanguage.SelectedValue), 0, null, true, false);
            siteDynamicPages.Sort("Sequence");
            dataDynamicPage.AppendDataBoundItems = true;
            //dataDynamicPage.Items.Add(new ListItem("-Empty-", "0"));
            dataDynamicPage.DataSource = siteDynamicPages;
            dataDynamicPage.DataTextField = "PageTitle";
            dataDynamicPage.DataValueField = "DynamicPageID";
            dataDynamicPage.DataBind();
            dataDynamicPage.Items.Insert(0, new ListItem(" Please Choose ...", "0"));
        }

        private void SecruityCheck()
        {
            if (SiteID > 0)
            {
                // If the Content Editor doesnt have permission to access the page.
                if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor && SiteID != SessionData.Site.SiteId)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        private void LoadGlobalSetting()
        {
            if (SiteID > 0)
            {
                SecruityCheck();

                using (TList<JXTPortal.Entities.GlobalSettings> globalSetting = GlobalSettingsService.GetBySiteId(SiteID))
                {
                    //dataSite.SelectedValue = globalSetting.SiteId.ToString();
                    if (globalSetting.Count > 0)
                    {
                        CommonFunction.SetDropDownByValue(ddlSiteType, globalSetting[0].SiteType.ToString());
                        cbAdvertiserApprovalProcess.Checked = (globalSetting[0].AdvertiserApprovalProcess == (int)PortalEnums.Admin.AdvertiserApproval.AllApprovalProcess);
                        ddlAdvertiserApprovalProcess.SelectedValue = globalSetting[0].AdvertiserApprovalProcess.ToString();
                        CommonFunction.SetDropDownByValue(dataLanguage, globalSetting[0].DefaultLanguageId.ToString());
                        CommonFunction.SetDropDownByValue(ddlDefaultEmailLanguage, globalSetting[0].DefaultEmailLanguageId.ToString());
                        CommonFunction.SetDropDownByValue(dataCountry, globalSetting[0].DefaultCountryId.ToString());
                        cbJobExpiryNotification.Checked = globalSetting[0].JobExpiryNotification;
                        SetAdvertiserApprovalProcess();
                        LoadDynamicPages();

                        CommonFunction.SetDropDownByValue(dataDynamicPage, globalSetting[0].DefaultDynamicPageId.ToString());

                        dataPublicJobSearch.Checked = globalSetting[0].PublicJobsSearch;
                        dataPrivateJobs.Checked = globalSetting[0].PrivateJobs;
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
                        cbSSLEnabled.Checked = globalSetting[0].EnableSsl;
                        dataWWWRedirect.Checked = globalSetting[0].WwwRedirect;
                        dataDescription.Text = globalSetting[0].DefaultDescription;
                        dataHomeDescription.Text = globalSetting[0].HomeDescription;
                        dataDefaultKeywords.Text = globalSetting[0].DefaultKeywords;
                        dataHomeKeywords.Text = globalSetting[0].HomeKeywords;
                        dataFTPFolder.Text = globalSetting[0].FtpFolderLocation;
                        //dataBlankHomePageDynamicPage.SelectedValue = globalSetting.BlankHomePageDynamicPageId.ToString();
                        txtMetaTags.Text = globalSetting[0].MetaTags;
                        txtSystemPages.Text = globalSetting[0].SystemMetaTags;
                        dataUseAdvertiserFilter.Checked = (globalSetting[0].UseAdvertiserFilter == 1) ? true : false;
                        dataPrivacySettings.Text = globalSetting[0].PrivacySettings;
                        cbUseCustomProfessionRoles.Checked = globalSetting[0].UseCustomProfessionRole;
                        chkGenerateJobXML.Checked = globalSetting[0].GenerateJobXml;
                        cbJobScreeningProcess.Checked = (globalSetting[0].JobScreeningProcess.HasValue)?globalSetting[0].JobScreeningProcess.Value:false;
                        // cbAdvertiserApprovalProcess.Checked = (globalSetting[0].AdvertiserApprovalProcess.HasValue) ? true : false; // TODO Naveen change this //globalSetting[0].AdvertiserApprovalProcess.Value : false;
                        ddlDateFormat.SelectedValue = globalSetting[0].GlobalDateFormat;

                        chkPrivateSite.Checked = globalSetting[0].IsPrivateSite.HasValue ? globalSetting[0].IsPrivateSite.Value : false;
                        if (chkPrivateSite.Checked)
                            txtPrivateRedirectUrl.Text = globalSetting[0].PrivateRedirectUrl;

                        //People Search Settings
                        cbPeopleSearchCB.Checked = globalSetting[0].EnablePeopleSearch;

                        chkEnableJobCustomQuestionnaire.Checked = globalSetting[0].EnableJobCustomQuestionnaire.HasValue ? globalSetting[0].EnableJobCustomQuestionnaire.Value : false;
                        if (globalSetting[0].JobApplicationTypeId.HasValue)
                            CommonFunction.SetDropDownByValue(ddlJobApplicationTypeID, globalSetting[0].JobApplicationTypeId.ToString());
                        
                        if (cbUseCustomProfessionRoles.Checked)
                        {
                            dataPrivateJobs.Checked = true;
                            dataPrivateJobs.Enabled = false;
                            dataPublicJobSearch.Enabled = false;
                            dataUseAdvertiserFilter.Enabled = false;
                        }

                        //if (globalSetting[0].SiteFavIconId.HasValue)
                        //    dataSiteFavIcon.Text = globalSetting[0].SiteFavIconId.Value.ToString();

                        dataSiteDocType.Text = globalSetting[0].SiteDocType;

                        txtSiteEmailMemberRegistration.Text = globalSetting[0].MemberRegistrationNotification;

                        if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
                        {
                            dataDynamicPage.Enabled = false;
                            dataLanguage.Enabled = false;
                            dataPrivateJobs.Enabled = false;
                            dataPublicJobSearch.Enabled = false;
                            dataPrivateJobs.Enabled = false;
                            dataFTPFolder.Enabled = false;
                            txtMetaTags.Enabled = false;
                            txtSystemPages.Enabled = false;
                            dataUseAdvertiserFilter.Enabled = false;
                            dataSiteDocType.Enabled = false;
                            hypLinkAdvertiserFilter.Visible = false;
                            chkGenerateJobXML.Enabled = false;
                            chkPrivateSite.Enabled = false;
                            chkEnableJobCustomQuestionnaire.Enabled = false;
                            ddlJobApplicationTypeID.Enabled = false;
                            txtPrivateRedirectUrl.Enabled = false;
                        }

                        tbLinkedInAPI.Text = (string.IsNullOrEmpty(globalSetting[0].LinkedInApi)) ? string.Empty : globalSetting[0].LinkedInApi;
                        tbLinkedInAPISecret.Text = (string.IsNullOrEmpty(globalSetting[0].LinkedInApiSecret)) ? string.Empty : globalSetting[0].LinkedInApiSecret;
                        tbLinkedInLogo.Text = (string.IsNullOrEmpty(globalSetting[0].LinkedInLogo)) ? string.Empty : globalSetting[0].LinkedInLogo;
                        tbLinkedInCompanyID.Text = (!globalSetting[0].LinkedInCompanyId.HasValue) ? string.Empty : globalSetting[0].LinkedInCompanyId.ToString();
                        tbLinkedInEmail.Text = (string.IsNullOrEmpty(globalSetting[0].LinkedInEmail)) ? string.Empty : globalSetting[0].LinkedInEmail;

                        //tbGoogleClientID.Text = (string.IsNullOrEmpty(globalSetting[0].GoogleClientId)) ? string.Empty : globalSetting[0].GoogleClientId;
                        //tbGoogleClientSecret.Text = (string.IsNullOrEmpty(globalSetting[0].GoogleClientSecret)) ? string.Empty : globalSetting[0].GoogleClientSecret;

                        //tbFacebookAppID.Text = (string.IsNullOrEmpty(globalSetting[0].FacebookAppId)) ? string.Empty : globalSetting[0].FacebookAppId;
                        //tbFacebookAppSecret.Text = (string.IsNullOrEmpty(globalSetting[0].FacebookAppSecret)) ? string.Empty : globalSetting[0].FacebookAppSecret;
                    }
                }

            }
        }

        #endregion

        protected void ctmEmailMemberRegistration_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string values = txtSiteEmailMemberRegistration.Text.Trim();
            string[] email = values.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < email.Length; i++)
            {
                if (!string.IsNullOrEmpty(values.Trim()))
                {
                    if (JXTPortal.Common.Utils.VerifyEmail(email[i]) == false)
                    {
                        args.IsValid = false;
                        Page.SetFocus(txtSiteEmailMemberRegistration);
                        ctmEmailMemberRegistration.ErrorMessage = "Invalid Email Address";
                        return;
                    }
                    else if (email.Length > 2)
                    {
                        args.IsValid = false;
                        Page.SetFocus(txtSiteEmailMemberRegistration);
                        ctmEmailMemberRegistration.ErrorMessage = "Only 2 email addresses allowed";
                        return;
                    }
                }
            }
        }

        protected void cvMetaTags2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (txtSystemPages.Text.Length <= 2000);
        }

        protected void dataLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDynamicPages();
        }

        protected void cbUseCustomProfessionRoles_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseCustomProfessionRoles.Checked)
            {
                dataPrivateJobs.Checked = true;
            }

            dataPrivateJobs.Enabled = !cbUseCustomProfessionRoles.Checked;
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

        protected void ddlSiteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAdvertiserApprovalProcess();
        }

        private void SetAdvertiserApprovalProcess()
        {
            if (ddlSiteType.SelectedValue == ((int)PortalEnums.Admin.SiteType.JobBoard).ToString())
            {
                phRecruiterOption.Visible = false;
                phJobBoardOption.Visible = true;
            }
            else
            {
                phRecruiterOption.Visible = true;
                phJobBoardOption.Visible = false;
            }
        }
    }
}




