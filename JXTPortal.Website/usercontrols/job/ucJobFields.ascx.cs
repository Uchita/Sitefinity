
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal;
using AjaxControlToolkit;
using JXTPortal.Website;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml;
using JXTPortal.Entities.Models;
using JXTPortal.Common;
using JXTPortal.Common;

using JXTPortal.Service.Dapper;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;
using System.Text.RegularExpressions;
#endregion

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class JobFields : System.Web.UI.UserControl
    {
        #region Declaration

        public string MapKey = null;

        private int _jobID;
        private int _advertiserid = 0;
        private int _pending = 0;
        private int _advertiseruserid = 0;
        private GlobalSettingsService _globalSettingsService;
        private AdvertiserJobTemplateLogoService _advertiserJobTemplateLogo;
        private SiteWorkTypeService _siteWorkTypeService;
        private AdvertisersService _advertisersservice;
        private AdvertiserUsersService _advertiserusersservice;
        private AdminUsersService _adminusersservice;
        private JobItemsTypeService _jobitemstypeservice;
        private JobTemplatesService _jobtemplatesservice;
        private JobsService _jobsservice;
        private SiteSalaryTypeService _sitesalarytypeservice;
        private ViewSalaryService _viewsalaryservice = null;
        private IntegrationsService _integrationsService;

        private SiteCountriesService _siteCountriesService;
        private SiteLocationService _siteLocationService;
        private SiteAreaService _siteAreaService;
        private SiteProfessionService _siteProfessionService;
        private SiteRolesService _siteRolesService;
        private JobAreaService _jobAreaService;
        private JobRolesService _jobRolesService;
        private AreaService _areaService;
        private LocationService _locationService;
        private RolesService _rolesService;
        private DynamicPagesService _dynamicPagesService = null;
        private InvoiceService _invoiceService = null;
        private AdvertiserJobPricingService _advertiserJobPricingService = null;
        private SiteLanguagesService _siteLanguagesService = null;
        private JobCustomXmlService _jobcustomxmlService = null;

        //ascx variables
        public bool HasAddressInputValue = false;
        public bool HasLatLngInputValues = false;
        #endregion

        #region Properties

        public string DefaultLangJobNameID
        {
            get
            {
                if (rptLanguagesPanel.Items.Count > 0)
                {
                    return ((TextBox)((JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual)rptLanguagesPanel.Items[0].FindControl("ucJobFieldsMultiLingual")).FindControl("txtJobName")).ClientID;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public String strJobHTML = String.Empty;

        private JobCustomXmlService JobCustomXmlService
        {
            get
            {
                if (_jobcustomxmlService == null)
                {
                    _jobcustomxmlService = new JobCustomXmlService();
                }
                return _jobcustomxmlService;
            }
        }

        private AdvertiserJobPricingService AdvertiserJobPricingService
        {
            get
            {
                if (_advertiserJobPricingService == null)
                {
                    _advertiserJobPricingService = new AdvertiserJobPricingService();
                }
                return _advertiserJobPricingService;
            }
        }

        private InvoiceService InvoiceService
        {
            get
            {
                if (_invoiceService == null)
                {
                    _invoiceService = new InvoiceService();
                }
                return _invoiceService;
            }
        }

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

        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_siteLanguagesService == null)
                {
                    _siteLanguagesService = new SiteLanguagesService();
                }
                return _siteLanguagesService;
            }
        }

        protected int AdvertiserID
        {
            get
            {
                if ((Request.QueryString["AdvertiserID"] != null))
                {
                    if (int.TryParse((Request.QueryString["AdvertiserID"].Trim()), out _advertiserid))
                    {
                        _advertiserid = Convert.ToInt32(Request.QueryString["AdvertiserID"]);
                    }
                    return _advertiserid;
                }

                return _advertiserid;
            }
        }

        protected int Pending
        {
            get
            {
                if ((Request.QueryString["pending"] != null))
                {
                    if (int.TryParse((Request.QueryString["pending"].Trim()), out _pending))
                    {
                        _pending = Convert.ToInt32(Request.QueryString["pending"]);
                    }
                    return _pending;
                }

                return _pending;
            }
        }

        protected int AdvertiserUserID
        {
            get
            {
                if ((Request.QueryString["AdvertiserUserID"] != null))
                {
                    if (int.TryParse((Request.QueryString["AdvertiserUserID"].Trim()), out _advertiseruserid))
                    {
                        _advertiseruserid = Convert.ToInt32(Request.QueryString["AdvertiserUserID"]);
                    }
                    return _advertiseruserid;
                }

                return _advertiseruserid;
            }
        }


        private int JobID
        {
            get
            {
                int _jobID = 0;

                if (int.TryParse(Request.QueryString["JobID"], out _jobID))
                {
                    return _jobID;
                }

                return _jobID;
            }
            set
            {
                _jobID = value;
            }
        }

        private int CopyJobID
        {
            get
            {
                int _jobID = 0;

                if (int.TryParse(Request.QueryString["CopyJobID"], out _jobID))
                {
                    return _jobID;
                }

                return _jobID;
            }
            set
            {
                _jobID = value;
            }
        }

        private bool isRepostJob = false;

        private int JobAreaID { get; set; }

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

        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteWorkTypeService == null)
                {
                    _siteWorkTypeService = new SiteWorkTypeService();
                }
                return _siteWorkTypeService;
            }
        }

        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserusersservice == null)
                {
                    _advertiserusersservice = new AdvertiserUsersService();
                }
                return _advertiserusersservice;
            }
        }

        private AdminUsersService AdminUsersService
        {
            get
            {
                if (_adminusersservice == null)
                {
                    _adminusersservice = new AdminUsersService();
                }
                return _adminusersservice;
            }
        }

        private JobItemsTypeService JobItemsTypeService
        {
            get
            {
                if (_jobitemstypeservice == null)
                {
                    _jobitemstypeservice = new JobItemsTypeService();
                }
                return _jobitemstypeservice;
            }
        }

        private JobTemplatesService JobTemplatesService
        {
            get
            {
                if (_jobtemplatesservice == null)
                {
                    _jobtemplatesservice = new JobTemplatesService();
                }
                return _jobtemplatesservice;
            }
        }

        private JobsService JobsService
        {
            get
            {
                if (_jobsservice == null)
                {
                    _jobsservice = new JobsService();
                }
                return _jobsservice;
            }
        }

        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_siteCountriesService == null)
                    _siteCountriesService = new SiteCountriesService();
                return _siteCountriesService;
            }
        }

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_siteLocationService == null)
                {
                    _siteLocationService = new SiteLocationService();
                }
                return _siteLocationService;
            }
        }

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteAreaService == null)
                    _siteAreaService = new SiteAreaService();
                return _siteAreaService;
            }
        }

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteProfessionService == null)
                    _siteProfessionService = new SiteProfessionService();
                return _siteProfessionService;
            }
        }

        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siteRolesService == null)
                    _siteRolesService = new SiteRolesService();
                return _siteRolesService;
            }
        }

        private JobAreaService JobAreaService
        {
            get
            {
                if (_jobAreaService == null)
                    _jobAreaService = new JobAreaService();
                return _jobAreaService;
            }
        }

        private JobRolesService JobRolesService
        {
            get
            {
                if (_jobRolesService == null)
                    _jobRolesService = new JobRolesService();
                return _jobRolesService;
            }
        }

        private AreaService AreaService
        {
            get
            {
                if (_areaService == null)
                    _areaService = new AreaService();
                return _areaService;
            }
        }

        private LocationService LocationService
        {
            get
            {
                if (_locationService == null)
                    _locationService = new LocationService();
                return _locationService;
            }
        }

        private RolesService RolesService
        {
            get
            {
                if (_rolesService == null)
                    _rolesService = new RolesService();
                return _rolesService;
            }
        }

        private AdvertiserJobTemplateLogoService AdvertiserJobTemplateLogoService
        {
            get
            {
                if (_advertiserJobTemplateLogo == null)
                    _advertiserJobTemplateLogo = new AdvertiserJobTemplateLogoService();
                return _advertiserJobTemplateLogo;
            }
        }

        private SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_sitesalarytypeservice == null)
                    _sitesalarytypeservice = new SiteSalaryTypeService();
                return _sitesalarytypeservice;
            }

        }

        private ViewSalaryService ViewSalaryService
        {
            get
            {
                if (_viewsalaryservice == null)
                    _viewsalaryservice = new ViewSalaryService();
                return _viewsalaryservice;
            }
        }

        private IntegrationsService IntegrationsService
        {
            get
            {
                if (_integrationsService == null)
                {
                    _integrationsService = new IntegrationsService();
                }

                return _integrationsService;
            }
        }

        public IScreeningQuestionsTemplatesService ScreeningQuestionsTemplatesService { get; set; }
        public IJobScreeningQuestionsService JobScreeningQuestionsService { get; set; }
        public IScreeningQuestionsService ScreeningQuestionsService { get; set; }

        #endregion

        #region "User Control Properties"

        public bool IsAdmin { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            revEmailAddress.ValidationExpression = ConfigurationManager.AppSettings["EmailValidationRegex"];
            cal_tbStartDate.Format = SessionData.Site.DateFormat;

            if (!Page.IsPostBack)
            {
                ltLanguageList.Text = string.Empty;
                TList<Entities.SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
                TList<Entities.SiteLanguages> sortedlist = new TList<Entities.SiteLanguages>();

                if (sitelanguages.Count > 0)
                {
                    foreach (Entities.SiteLanguages sitelang in sitelanguages)
                    {
                        if (sitelang.LanguageId == SessionData.Site.DefaultLanguageId)
                        {
                            sortedlist.Insert(0, sitelang);
                        }
                        else
                        {
                            sortedlist.Add(sitelang);
                        }
                    }

                    if (sitelanguages.Count > 1)
                    {
                        phSelectLanguage.Visible = true;

                        for (int i = 0; i < sortedlist.Count; i++)
                        {
                            if (i == 0)
                            {
                                ltLanguageList.Text += string.Format(@"<li class=""tab-link current"" data-tab=""{0}-tab"">{1}</li>", sortedlist[i].LanguageId, sortedlist[i].SiteLanguageName);
                            }
                            else
                            {
                                ltLanguageList.Text += string.Format(@"<li class=""tab-link"" data-tab=""{0}-tab"">{1}</li>", sortedlist[i].LanguageId, sortedlist[i].SiteLanguageName);
                            }
                        }
                    }
                }

                rptLanguagesPanel.DataSource = sortedlist;
                rptLanguagesPanel.DataBind();

                StringBuilder sbMultiLingual = new StringBuilder();
                sbMultiLingual.AppendLine(@"<script type=""text/javascript"">");
                sbMultiLingual.AppendLine(@"function MultiLingualCheck()");
                sbMultiLingual.AppendLine(@"{");

                foreach (RepeaterItem item in rptLanguagesPanel.Items)
                {
                    PlaceHolder phEnableLanguage = item.Controls[1].FindControl("phEnableLanguage") as PlaceHolder;
                    System.Web.UI.HtmlControls.HtmlInputCheckBox cbEnableLanguage = item.Controls[1].FindControl("cbEnableLanguage") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                    TextBox txtJobName = item.Controls[1].FindControl("txtJobName") as TextBox;
                    RequiredFieldValidator ReqVal_JobName = item.Controls[1].FindControl("ReqVal_JobName") as RequiredFieldValidator;
                    TextBox txtDescription = item.Controls[1].FindControl("txtDescription") as TextBox;
                    RequiredFieldValidator ReqVal_Description = item.Controls[1].FindControl("ReqVal_Description") as RequiredFieldValidator;
                    TextBox txtFullDescription = item.Controls[1].FindControl("txtFullDescription") as TextBox;
                    RequiredFieldValidator rvjobFieldFullDescription = item.Controls[1].FindControl("rvjobFieldFullDescription") as RequiredFieldValidator;

                    sbMultiLingual.AppendLine("");
                    sbMultiLingual.AppendLine("if (document.getElementById(\"" + cbEnableLanguage.ClientID + "\"))");
                    sbMultiLingual.AppendLine("{");
                    sbMultiLingual.AppendLine("document.getElementById(\"" + ReqVal_JobName.ClientID + "\").enabled = document.getElementById(\"" + cbEnableLanguage.ClientID + "\").checked; ");
                    sbMultiLingual.AppendLine("document.getElementById(\"" + ReqVal_Description.ClientID + "\").enabled = document.getElementById(\"" + cbEnableLanguage.ClientID + "\").checked; ");
                    sbMultiLingual.AppendLine("document.getElementById(\"" + rvjobFieldFullDescription.ClientID + "\").enabled = document.getElementById(\"" + cbEnableLanguage.ClientID + "\").checked; ");
                    sbMultiLingual.AppendLine("}");
                    sbMultiLingual.AppendLine("else");
                    sbMultiLingual.AppendLine("{");
                    sbMultiLingual.AppendLine("document.getElementById(\"" + ReqVal_JobName.ClientID + "\").enabled = true;");
                    sbMultiLingual.AppendLine("document.getElementById(\"" + ReqVal_Description.ClientID + "\").enabled = true;");
                    sbMultiLingual.AppendLine("document.getElementById(\"" + rvjobFieldFullDescription.ClientID + "\").enabled = true;");
                    sbMultiLingual.AppendLine("}");
                }
                sbMultiLingual.AppendLine(@"}");
                sbMultiLingual.AppendLine(@"</script>");
                ltMultiLingualScript.Text = sbMultiLingual.ToString();


                // ToDo - When we have item price goes live 
                pnlJobItem.Visible = false;

                // Status is not visible by default
                phStatusAction.Visible = false;

                // Only when you are in Admin to display the below fields
                ucSystemDynamicPage.Visible = !IsAdmin;

                if (IsAdmin)
                {
                    // Check if advertiser is valid
                    bool isValid = true;

                    using (Entities.AdvertiserUsers user = AdvertiserUsersService.GetByAdvertiserUserId(AdvertiserUserID))
                    {
                        if (user != null)
                        {
                            if (user.AdvertiserId == AdvertiserID)
                            {
                                using (Entities.Advertisers adv = AdvertisersService.GetByAdvertiserId(AdvertiserID))
                                {
                                    if (adv != null)
                                    {
                                        if (adv.SiteId != SessionData.Site.SiteId)
                                        {
                                            isValid = false;
                                        }
                                    }
                                    else
                                    {
                                        isValid = false;
                                    }
                                }
                            }
                            else
                            {
                                isValid = false;
                            }

                        }
                        else
                        {
                            isValid = false;
                        }
                    }

                    if (!isValid)
                    {
                        Response.Redirect("/admin/advertisers.aspx");
                    }

                    pnlAdvertiser.Visible = (SessionData.AdminUser != null && JobID == 0);
                    pnlCompanyName.Visible = (SessionData.AdminUser != null && JobID > 0);

                    // Show the status
                    if (JobID < 1)
                        phStatusAction.Visible = true;
                }

                imgAdvJobTemplate.Attributes.Add("style", "display:none");
            }


            if (!Page.IsPostBack)
            {
                LoadGoogleMapJS();
                LoadJobType();
                LoadApplicationMethod();
                LoadWorkType();
                LoadSalary();
                LoadAdvertiser();
                LoadJobTemplate();
                LoadAdvertiserJobTemplateLogo();
                LoadLocation();
                LoadArea();
                LoadProfession();
                LoadRoles(0, ref ddlRole1);
                LoadRoles(0, ref ddlRole2);
                LoadRoles(0, ref ddlRole3);
                LoadJobStatus();
                LoadScreeningQuesitonsTemplate();

                LoadJob();
                LoadUI();
                InsertButton.Visible = (JobID == 0);
                UpdateButton.Visible = (JobID > 0);

            }
            else
            {
                ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "SetSalaryProps", "SalaryChange(); $('#txtSalaryLowerBand, #txtSalaryUpperBand').keyup(function () {this.value = this.value.replace(/[^0-9\\.]/g, '');});$('#txtSalaryLowerBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));$('#txtSalaryUpperBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));$('#ddlSalary').change(function () {SalaryChange();$('#txtSalaryLowerBand').focus();});", true);
            }

            if (!Page.IsPostBack)
            {
                SetFormValues();
                LoadCopyJob();
            }


        }

        protected void rptLanguagesPanel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual ucJobFieldsMultiLingual = e.Item.FindControl("ucJobFieldsMultiLingual") as JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual;
                JXTPortal.Entities.SiteLanguages sitelang = e.Item.DataItem as JXTPortal.Entities.SiteLanguages;
                ucJobFieldsMultiLingual.LanguageID = sitelang.LanguageId.ToString();
                ucJobFieldsMultiLingual.LanguageText = sitelang.SiteLanguageName.ToString();
            }
        }

        private void LoadGoogleMapJS()
        {
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            if (integrations != null && integrations.GoogleMap != null)
            {
                //only assign anything to the geocode and address status if there is a server key in the integrations of the site
                if (!string.IsNullOrWhiteSpace(integrations.GoogleMap.ServerKey) && integrations.GoogleMap.Valid)
                {
                    //set key for ascx use
                    MapKey = integrations.GoogleMap.ServerKey;
                }
            }
        }

        private void LoadJobType()
        {
            int advertiseruserid = 0;
            int advertiserid = 0;
            PortalEnums.Advertiser.AccountType accountype = PortalEnums.Advertiser.AccountType.Account;
            if (IsAdmin)
            {
                if (AdvertiserUserID == 0 && JobID > 0)
                {
                    Entities.Jobs job = JobsService.GetByJobId(JobID);
                    if (job != null && job.EnteredByAdvertiserUserId.HasValue)
                    {
                        advertiseruserid = job.EnteredByAdvertiserUserId.Value;
                    }
                }
                else
                {
                    advertiseruserid = AdvertiserUserID;
                }

                if (advertiseruserid > 0)
                {
                    Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(advertiseruserid);

                    advertiserid = advertiseruser.AdvertiserId;
                }
                else
                {
                    advertiserid = AdvertiserID;
                }

                Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(advertiserid);
                accountype = (PortalEnums.Advertiser.AccountType)advertiser.AdvertiserAccountTypeId;
            }
            else
            {
                advertiseruserid = SessionData.AdvertiserUser.AdvertiserUserId;
                advertiserid = SessionData.AdvertiserUser.AdvertiserId;
                accountype = SessionData.AdvertiserUser.AccountType;
            }


            using (DataSet jobcreditlist = InvoiceService.CustomJobCreditList(advertiseruserid))
            {
                ddlJobItemType.Items.Clear();

                foreach (DataRow row in jobcreditlist.Tables[0].Rows)
                {
                    if (SessionData.Site.IsJobBoard && accountype == PortalEnums.Advertiser.AccountType.Credit_Card)
                    {
                        //if (Convert.ToInt32(row["Remaining"]) != 0)
                        //{
                        ddlJobItemType.Items.Add(new ListItem(string.Format("{0} ({1})", row["JobItemTypeDescription"].ToString(), row["Remaining"].ToString()), row["JobItemTypeID"].ToString()));
                        //}
                    }
                    else
                    {
                        ddlJobItemType.Items.Add(new ListItem(row["JobItemTypeDescription"].ToString(), row["JobItemTypeID"].ToString()));
                    }
                }

                if (SessionData.Site.IsJobBoard && ddlJobItemType.Items.Count == 0 && !IsAdmin &&
                        JobID == 0)
                {
                    Response.Redirect("/advertiser/productselect.aspx?nocredit=1");
                }

                // Set Visibility for Premium job type
                // phJobStartDate.Visible = (ddlJobItemType.SelectedValue == ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());
                phInfo.Visible = (ddlJobItemType.SelectedValue == ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());
                cal_tbStartDate.SelectedDate = DateTime.Now;

            }

            // Job Credit Check
            if (SessionData.Site.IsJobBoard)
            {
                phNoJobCredit.Visible = (JobCreditCheck() <= 0 && accountype == PortalEnums.Advertiser.AccountType.Credit_Card);
                if (phNoJobCredit.Visible)
                {
                    string js = "$(function() {$('#chkSaveAsDraft').attr('disabled', true); $('#chkSaveAsDraft').prop('checked', true);});";
                    ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "focusJS", js, true);
                }
                else
                {
                    string js = "$(function() {$('#chkSaveAsDraft').removeAttr('disabled'); $('#chkSaveAsDraft').prop('checked', false);});";
                    ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "focusJS", js, true);
                }

            }
        }

        private void JobValidation(Entities.Jobs job)
        {
            if (JobID > 0)
            {

                // Checking the ownership of the job
                if (SessionData.AdvertiserUser != null)
                {
                    if (job.AdvertiserId != SessionData.AdvertiserUser.AdvertiserId)
                    {
                        Response.Redirect("~/advertiser/default.aspx");
                    }

                    using (TList<Entities.GlobalSettings> globalsettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (globalsettings.Count > 0)
                        {
                            Entities.GlobalSettings globalsetting = globalsettings[0];

                            if (globalsetting.JobScreeningProcess.HasValue)
                            {
                                if (globalsetting.JobScreeningProcess.Value)
                                {
                                    if (job.Expired.HasValue && (job.Expired == (int)PortalEnums.Jobs.JobStatus.Live ||
                    job.Expired == (int)PortalEnums.Jobs.JobStatus.Pending ||
                    job.Expired == (int)PortalEnums.Jobs.JobStatus.Suspended))
                                    {
                                        Response.Redirect("~/advertiser/default.aspx");
                                    }
                                }
                            }
                        }
                    }
                }

                // You can't update the expired job.
                if ((job.Expired.HasValue && job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || (job.Expired != (int)PortalEnums.Jobs.JobStatus.Draft && job.ExpiryDate < DateTime.Now))
                {
                    if (!IsAdmin)
                    {
                        // Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOB_CREATE_SUCCESS, "", "", ""));
                        Response.Redirect("~/advertiser/default.aspx");
                    }
                    else
                    {
                        // it allows the admin users to edit pending jobs
                        if (job.Expired != (int)PortalEnums.Jobs.JobStatus.Pending)
                        {
                            Response.Redirect("~/admin/advertiser/jobsbyadvertiser.aspx?advertiserid=" + AdvertiserID);
                        }
                    }
                }

                // Hide Draft Panel if live, pending, declined or suspended
                if (job.Expired.HasValue && (job.Expired == (int)PortalEnums.Jobs.JobStatus.Live ||
                        job.Expired == (int)PortalEnums.Jobs.JobStatus.Pending ||
                        job.Expired == (int)PortalEnums.Jobs.JobStatus.Declined ||
                        job.Expired == (int)PortalEnums.Jobs.JobStatus.Suspended))
                    DraftButton.Visible = false;

                // Disable Expired checkbox if draft, pending, declined or suspended
                if (job.Expired.HasValue && (job.Expired == (int)PortalEnums.Jobs.JobStatus.Draft ||
                        job.Expired == (int)PortalEnums.Jobs.JobStatus.Pending ||
                        job.Expired == (int)PortalEnums.Jobs.JobStatus.Declined ||
                        job.Expired == (int)PortalEnums.Jobs.JobStatus.Suspended))
                    chkJobExpired.Enabled = false;


                if (IsAdmin && SessionData.AdminUser != null)
                {
                    // When Logged in as Admin can update the fields
                    if (SessionData.AdminUser.isAdminUser)
                    {
                        //pnlAdvertiser.Visible = true;
                        //pnlAdvertiserUser.Visible = true;
                        //ddlAdvertiser.Enabled = true;
                        //ddlAdvertiserUser.Enabled = true;

                        txtFriendlyUrl.Enabled = true;
                        //chkJobExpired.Enabled = true;
                        ddlProfession1.Enabled = true;
                        ddlProfession2.Enabled = true;
                        ddlProfession3.Enabled = true;
                        ddlRole1.Enabled = true;
                        ddlRole2.Enabled = true;
                        ddlRole3.Enabled = true;
                        txtApplicationURL.Enabled = true;

                    }
                    // When Logged in as AdminContenteditor can update the fields
                    else
                    {
                        //pnlAdvertiserUser.Visible = false;
                        //pnlAdvertiser.Visible = false;

                        txtFriendlyUrl.Enabled = false;
                        //chkJobExpired.Enabled = true;
                        using (TList<Entities.JobRoles> jobroles = JobRolesService.GetByJobId(JobID))
                        {
                            if (jobroles.Count > 0)
                            {
                                ddlProfession1.Enabled = false;
                                ddlProfession2.Enabled = false;
                                ddlProfession3.Enabled = false;
                                ddlRole1.Enabled = false;
                                ddlRole2.Enabled = false;
                                ddlRole3.Enabled = false;
                            }
                            else
                            {
                                ddlProfession1.Enabled = true;
                                ddlProfession2.Enabled = true;
                                ddlProfession3.Enabled = true;
                                ddlRole1.Enabled = true;
                                ddlRole2.Enabled = true;
                                ddlRole3.Enabled = true;
                            }
                        }
                    }
                }
                // When Logged in as Advertiser
                else
                {

                    // When Job is live disable the profession and roles
                    if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                    {
                        ddlProfession1.Enabled = false;
                        ddlProfession2.Enabled = false;
                        ddlProfession3.Enabled = false;
                        ddlRole1.Enabled = false;
                        ddlRole2.Enabled = false;
                        ddlRole3.Enabled = false;
                    }
                    else
                    {
                        ddlProfession1.Enabled = true;
                        ddlProfession2.Enabled = true;
                        ddlProfession3.Enabled = true;
                        ddlRole1.Enabled = true;
                        ddlRole2.Enabled = true;
                        ddlRole3.Enabled = true;
                    }

                    //pnlAdvertiser.Visible = false;
                    //pnlAdvertiserUser.Visible = true;
                }
            }
            else
            {
                chkJobExpired.Enabled = false;
                ddlProfession1.Enabled = true;
                ddlProfession2.Enabled = true;
                ddlProfession3.Enabled = true;
                ddlRole1.Enabled = true;
                ddlRole2.Enabled = true;
                ddlRole3.Enabled = true;
            }


            using (TList<Entities.GlobalSettings> gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (gs.Count > 0)
                {
                    // if Site is using Job Screening Process
                    // Check if this job is expired/live/pending/suspended 
                    // then redirect back to advertiser dash board
                    if (gs[0].JobScreeningProcess.HasValue && gs[0].JobScreeningProcess.Value)
                    {
                        // Only if admin or content editor is logged in show the status button
                        if (IsAdmin)
                        {
                            phStatusAction.Visible = true;

                            // If job is expired then remove the status.
                            if (job.Expired.HasValue && job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired)
                            {
                                phStatusAction.Visible = false;
                                //ddlStatus.Items.Remove(ddlStatus.Items.FindByValue(((int)PortalEnums.Jobs.JobStatus.Live).ToString()));
                            }
                        }

                        // Open if the job is draft
                        if (job.Expired.HasValue && job.Expired == (int)PortalEnums.Jobs.JobStatus.Draft)
                        {
                        }
                        // When the Job is live .. you can only make the Job Expire and can't change it to pending or suspended.
                        else if (job.Expired.HasValue && job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                        {
                            ddlStatus.Enabled = false;
                        }
                        // Not in Admin and 
                        else if (!IsAdmin &&
                                    (job.Expired.HasValue &&
                                        (job.Expired == (int)PortalEnums.Jobs.JobStatus.Expired ||
                                            job.Expired == (int)PortalEnums.Jobs.JobStatus.Live ||
                                            job.Expired == (int)PortalEnums.Jobs.JobStatus.Pending ||
                                            job.Expired == (int)PortalEnums.Jobs.JobStatus.Suspended)))
                        {
                            Response.Redirect("~/advertiser/default.aspx");
                        }

                        ddlStatus.SelectedValue = job.Expired.Value.ToString();
                    }
                    else    // If Job screening process is not enabled then hide the Status.
                    {
                        phStatusAction.Visible = false;
                    }
                }
            }
        }

        //#region Method

        private int JobCreditCheck()
        {
            int advertiseruserid = 0;

            if (JobID > 0)
            {
                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                {
                    if (job != null && job.Expired.HasValue && job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Live)
                    {
                        return 1;
                    }
                }
            }

            if (!IsAdmin)
            {
                advertiseruserid = SessionData.AdvertiserUser.AdvertiserUserId;
                if (SessionData.AdvertiserUser.AccountType == PortalEnums.Advertiser.AccountType.Account)
                {
                    return 1;
                }
            }
            else
            {
                if (AdvertiserUserID == 0 && JobID > 0)
                {
                    using (Entities.Jobs job = JobsService.GetByJobId(JobID))
                    {
                        if (job != null && job.EnteredByAdvertiserUserId.HasValue)
                        {
                            advertiseruserid = job.EnteredByAdvertiserUserId.Value;
                        }
                    }
                }
                else
                {
                    advertiseruserid = AdvertiserUserID;
                }

                using (Entities.AdvertiserUsers advuser = AdvertiserUsersService.GetByAdvertiserUserId(advertiseruserid))
                {
                    if (advuser != null)
                    {
                        using (Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(advuser.AdvertiserId))
                        {
                            if (advertiser != null && advertiser.AdvertiserAccountTypeId == (int)PortalEnums.Advertiser.AccountType.Account)
                            {
                                return 1;
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(ddlJobItemType.SelectedValue))
            {
                int count = 0;

                using (DataSet creditds = InvoiceService.CustomCheckJobCreditCount(advertiseruserid, Convert.ToInt32(ddlJobItemType.SelectedValue)))
                {
                    if (creditds.Tables[0].Rows.Count > 0)
                    {
                        count = Convert.ToInt32(creditds.Tables[0].Rows[0][0]);
                    }
                }
                return count;
            }
            else
            {
                return 0;
            }

        }

        private void LoadCopyJob()
        {
            if (JobID == 0 && CopyJobID > 0)
            {
                int jobid = CopyJobID;

                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(CopyJobID))
                {
                    if (job != null && job.SiteId == SessionData.Site.SiteId)
                    {
                        if (SessionData.AdvertiserUser != null)
                        {
                            if (job.AdvertiserId != SessionData.AdvertiserUser.AdvertiserId)
                            {
                                Response.Redirect("~/advertiser/default.aspx");
                            }
                        }


                        DraftButton.Visible = true;
                        ddlAdvertiser.SelectedValue = job.AdvertiserId.ToString();

                        //LoadAdvertiserUser((job.EnteredByAdvertiserUserId.HasValue) ? (int)job.EnteredByAdvertiserUserId : 0);
                        // Disable Friendly Url

                        txtFriendlyUrl.Enabled = true;

                        txtApplicationEmailAddress.Text = job.ApplicationEmailAddress;
                        ddlWorkType.SelectedValue = job.WorkTypeId.ToString();
                        //ddlSalary.SelectedValue = job.SalaryId.ToString();
                        chkShowSalaryRange.Checked = job.ShowSalaryRange;
                        JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual ucJobFieldsMultiLingual = rptLanguagesPanel.Items[0].FindControl("ucJobFieldsMultiLingual") as JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual;
                        ucJobFieldsMultiLingual.JobName = CommonService.DecodeString(job.JobName.ToString());
                        ucJobFieldsMultiLingual.ShortDescription = CommonService.DecodeString(job.Description.ToString());
                        ucJobFieldsMultiLingual.FullDescription = CommonService.DecodeString(job.FullDescription.ToString());

                        TList<Entities.JobCustomXml> jobcustomxmllist = JobCustomXmlService.CustomGetBySiteIDJobIDCustomType(SessionData.Site.SiteId, job.JobId, (int)PortalEnums.Jobs.CustomType.Job);
                        Entities.JobCustomXml jobcustomxml = null;
                        if (jobcustomxmllist.Count > 0) jobcustomxml = jobcustomxmllist[0];

                        if (rptLanguagesPanel.Items.Count > 1 && jobcustomxml != null)
                        {
                            XmlDocument xmldoc = new XmlDocument();
                            xmldoc.LoadXml(jobcustomxml.CustomXml);

                            for (int i = 1; i < rptLanguagesPanel.Items.Count; i++)
                            {
                                JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual ucCustomMultiLingual = rptLanguagesPanel.Items[i].FindControl("ucJobFieldsMultiLingual") as JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual;
                                System.Web.UI.HtmlControls.HtmlInputCheckBox cbEnableLanguage = ucCustomMultiLingual.FindControl("cbEnableLanguage") as System.Web.UI.HtmlControls.HtmlInputCheckBox;

                                foreach (XmlNode xmlnode in xmldoc.SelectNodes("JobDetail"))
                                {
                                    XmlNode langnode = xmldoc.SelectSingleNode("LanguageID");
                                    if (langnode.InnerText == ucCustomMultiLingual.LanguageID.ToString())
                                    {
                                        XmlNode enablednode = xmldoc.GetElementsByTagName("Enabled")[0];
                                        XmlNode jobnamenode = xmldoc.SelectSingleNode("JobName");
                                        XmlNode bulletpoint1 = xmldoc.SelectSingleNode("BulletPoint1");
                                        XmlNode bulletpoint2 = xmldoc.SelectSingleNode("BulletPoint2");
                                        XmlNode bulletpoint3 = xmldoc.SelectSingleNode("BulletPoint3");
                                        XmlNode shortdescription = xmldoc.SelectSingleNode("ShortDescription");
                                        XmlNode fulldescription = xmldoc.SelectSingleNode("FullDescription");

                                        cbEnableLanguage.Checked = Convert.ToBoolean(enablednode.InnerText);
                                        ucCustomMultiLingual.JobName = jobnamenode.InnerText;
                                        ucCustomMultiLingual.BulletPoint1 = bulletpoint1.InnerText;
                                        ucCustomMultiLingual.BulletPoint2 = bulletpoint2.InnerText;
                                        ucCustomMultiLingual.BulletPoint3 = bulletpoint3.InnerText;
                                        ucCustomMultiLingual.ShortDescription = shortdescription.InnerText;
                                        ucCustomMultiLingual.FullDescription = fulldescription.InnerText;
                                    }
                                }
                                // TODO: Retrieving multilingual fields into database

                            }
                        }
                        txtRefNo.Text = job.RefNo.ToString();
                        //chkVisible.Checked = job.Visible;
                        lblDatePosted.Text = job.DatePosted.ToString(SessionData.Site.DateFormat);
                        lblExpiryDate.Text = job.ExpiryDate.ToString(SessionData.Site.DateFormat);
                        chkJobExpired.Checked = (job.Expired.HasValue && job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) ? true : false;
                        txtJobItemPrice.Text = (job.JobItemPrice.HasValue) ? job.JobItemPrice.ToString() : string.Empty;
                        //chkBilled.Checked = job.Billed;
                        lblLastModified.Text = job.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        chkShowSalaryDetails.Checked = job.ShowSalaryDetails;
                        txtSalaryText.Text = (!string.IsNullOrEmpty(job.SalaryText)) ? job.SalaryText.ToString() : string.Empty;

                        // Set the Friendly Url if it is not Set
                        if (!String.IsNullOrEmpty(txtFriendlyUrl.Text.Trim()))
                            txtFriendlyUrl.Text = Common.Utils.UrlFriendlyName(job.JobName);
                        else
                            txtFriendlyUrl.Text = job.JobFriendlyName;
                        txtCompanyName.Text = job.CompanyName;

                        //dataAdvertiserId.SelectedValue = job.AdvertiserId.ToString();

                        if (job.EnteredByAdvertiserUserId != null)
                        {
                            using (Entities.AdvertiserUsers advertiserusers = AdvertiserUsersService.GetByAdvertiserUserId((int)job.EnteredByAdvertiserUserId))
                            {
                                if (advertiserusers != null)
                                    lblPostedByAdvertiserUser.Text = advertiserusers.UserName;
                                else
                                    lblPostedByAdvertiserUser.Text = "";
                            }
                        }
                        else
                        {
                            lblPostedByAdvertiserUser.Text = "";
                        }

                        if (job.LastModifiedByAdvertiserUserId != null)
                        {
                            using (Entities.AdvertiserUsers advertiserusers = AdvertiserUsersService.GetByAdvertiserUserId((int)job.LastModifiedByAdvertiserUserId))
                            {
                                if (advertiserusers != null)
                                    lblLastModifiedByAdvertiserUserId.Text = advertiserusers.UserName;
                                else
                                    lblLastModifiedByAdvertiserUserId.Text = "";
                            }
                        }
                        else
                        {
                            phlastmodifiedByAdvuserID.Visible = false;
                        }

                        if (job.LastModifiedByAdminUserId != null)
                        {
                            using (Entities.AdminUsers adminusers = AdminUsersService.GetByAdminUserId((int)job.LastModifiedByAdminUserId))
                            {
                                if (adminusers != null)
                                    lblLastModifiedByAdminUserId.Text = adminusers.UserName;
                                else
                                    lblLastModifiedByAdminUserId.Text = "";
                            }
                        }
                        else
                        {
                            phLastmodifiedByAdmin.Visible = false;
                        }


                        if (job.JobItemTypeId.HasValue)
                            ddlJobItemType.SelectedValue = job.JobItemTypeId.ToString();

                        ddlApplicationMethod.SelectedValue = job.ApplicationMethod.ToString();

                        if (Convert.ToInt32(ddlApplicationMethod.SelectedValue) == 2)
                            txtApplicationURL.Enabled = true;
                        else
                            txtApplicationURL.Enabled = false;

                        if (job.ApplicationUrl != null)
                        {
                            txtApplicationURL.Text = job.ApplicationUrl.ToString();
                        }

                        if (!string.IsNullOrEmpty(job.Tags))
                            txtTags.Text = job.Tags.ToString();

                        ddlSalary.SelectedValue = job.SalaryTypeId.ToString();
                        //LoadSalaryFrom(job.SalaryTypeId);
                        txtSalaryLowerBand.Text = job.SalaryLowerBand.ToString();
                        //LoadSalaryTo(job.SalaryTypeId, job.CurrencyId, job.SalaryLowerBand);
                        txtSalaryUpperBand.Text = job.SalaryUpperBand.ToString();

                        if (job.JobTemplateId.HasValue)
                        {
                            ddlJobTemplateID.SelectedValue = job.JobTemplateId.ToString();
                            imgAdvJobTemplate.ImageUrl = "/getfile.aspx?jobtemplateid=" + job.JobTemplateId.ToString();

                            imgAdvJobTemplate.Attributes.Add("style", "display:block");
                        }
                        else
                        {
                            imgAdvJobTemplate.Attributes.Add("style", "display:none");
                        }

                        //dataSearchFieldExtension.Text = job.SearchFieldExtension.ToString();
                        //dataAdvertiserJobTemplateLogoID.Text = job.AdvertiserJobTemplateLogoId.ToString();
                        if (job.AdvertiserJobTemplateLogoId.HasValue)
                            ddlAdvertiserJobTemplateLogo.SelectedValue = Convert.ToString(job.AdvertiserJobTemplateLogoId);

                        if (job.ScreeningQuestionsTemplateId.HasValue)
                            ddlScreeningQuestionsTemplate.SelectedValue = Convert.ToString(job.ScreeningQuestionsTemplateId.Value);
                        // chkRequireLogonForExternalApplications.Checked = job.RequireLogonForExternalApplications;
                        chkShowLocationDetails.Checked = (job.ShowLocationDetails == null) ? false : (bool)job.ShowLocationDetails;
                        if (!string.IsNullOrEmpty(job.PublicTransport))
                            txtPublicTransport.Text = job.PublicTransport.ToString();
                        if (!string.IsNullOrEmpty(job.Address))
                        {
                            HasAddressInputValue = true;  //flag for ascx use
                            txtAddress.Text = CommonService.DecodeString(job.Address.ToString());

                            if (job.JobLatitude != null && job.JobLongitude != null)
                            {
                                hfAddressLat.Value = job.JobLatitude.ToString();
                                hfAddressLng.Value = job.JobLongitude.ToString();

                                HasLatLngInputValues = true; //flag for ascx use
                            }
                        }
                        txtContactDetails.Text = job.ContactDetails.ToString();
                        if (!string.IsNullOrEmpty(job.JobContactPhone))
                            txtJobContactPhone.Text = job.JobContactPhone.ToString();
                        if (!string.IsNullOrEmpty(job.JobContactName))
                            txtJobContactName.Text = job.JobContactName.ToString();
                        chkQualificationsRecognised.Checked = job.QualificationsRecognised;
                        chkResidentOnly.Checked = job.ResidentOnly;
                        //txtDocumentLink.Text = job.DocumentLink.ToString();
                        ucJobFieldsMultiLingual.BulletPoint1 = (string.IsNullOrEmpty(job.BulletPoint1)) ? "" : CommonService.DecodeString(job.BulletPoint1.ToString());
                        ucJobFieldsMultiLingual.BulletPoint2 = (string.IsNullOrEmpty(job.BulletPoint2)) ? "" : CommonService.DecodeString(job.BulletPoint2.ToString());
                        ucJobFieldsMultiLingual.BulletPoint3 = (string.IsNullOrEmpty(job.BulletPoint3)) ? "" : CommonService.DecodeString(job.BulletPoint3.ToString());
                        //chkHotJob.Checked = job.HotJob;

                        foreach (JXTPortal.Entities.JobArea jobArea in JobAreaService.GetByJobId(job.JobId))
                        {
                            using (JXTPortal.Entities.Area area = AreaService.GetByAreaId(jobArea.AreaId))
                            {

                                LoadLocation();
                                CommonFunction.SetDropDownByValue(ddlLocation, area.LocationId.ToString());

                                LoadArea();
                                CommonFunction.SetDropDownByValue(ddlArea, jobArea.AreaId.ToString());
                            }
                        }

                        using (TList<JXTPortal.Entities.JobRoles> jobRoles = JobRolesService.GetByJobId(job.JobId))
                        {
                            if (jobRoles.Count > 0 && jobRoles[0] != null)
                            {
                                using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[0].RoleId.Value))
                                {
                                    CommonFunction.SetDropDownByValue(ddlProfession1, role.ProfessionId.ToString());
                                    LoadRoles(role.ProfessionId, ref ddlRole1);
                                    CommonFunction.SetDropDownByValue(ddlRole1, jobRoles[0].RoleId.Value.ToString());
                                }

                            }

                            if (jobRoles.Count > 1 && jobRoles[1] != null && jobRoles[1].RoleId.HasValue)
                            {
                                using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[1].RoleId.Value))
                                {
                                    CommonFunction.SetDropDownByValue(ddlProfession2, role.ProfessionId.ToString());
                                    LoadRoles(role.ProfessionId, ref ddlRole2);
                                    CommonFunction.SetDropDownByValue(ddlRole2, jobRoles[1].RoleId.Value.ToString());
                                }
                            }

                            if (jobRoles.Count > 2 && jobRoles[2] != null && jobRoles[2].RoleId.HasValue)
                            {
                                using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[2].RoleId.Value))
                                {
                                    CommonFunction.SetDropDownByValue(ddlProfession3, role.ProfessionId.ToString());
                                    LoadRoles(role.ProfessionId, ref ddlRole3);
                                    CommonFunction.SetDropDownByValue(ddlRole3, jobRoles[2].RoleId.Value.ToString());
                                }
                            }

                        }
                    }
                    else
                    {
                        //TO DO: redirection after insert/update job
                        Response.Redirect("~/advertiser/default.aspx");
                    }
                }
            }
        }

        private void LoadJobTemplate()
        {
            int aid = 0;

            // When in Admin get the advertiserID from the querystring
            if (SessionData.AdminUser != null && AdvertiserID > 0)
            {
                aid = AdvertiserID;
            }
            else
            {
                // Else get from the session.
                aid = SessionData.AdvertiserUser.AdvertiserId;
            }

            if (aid > 0)
            {
                using (DataSet jobtemplates = JobTemplatesService.GetAdvertiserJobTemplates(SessionData.Site.SiteId, aid))
                {
                    ddlJobTemplateID.DataSource = jobtemplates;
                    ddlJobTemplateID.DataBind();
                }
            }

            //ddlJobTemplateID.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }
        ///*
        //protected void ddlJobTemplateID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlJobTemplateID.SelectedIndex > 0)
        //    {
        //        imgAdvJobTemplate.ImageUrl = Page.ResolveUrl("~/GetFile.aspx") + "?AdvertiserJobTemplateLogoID=" + Convert.ToString(ddlJobTemplateID.SelectedValue); ;
        //    }
        //}
        //*/
        private void LoadAdvertiserJobTemplateLogo()
        {
            if (IsAdmin)
            {
                ddlAdvertiserJobTemplateLogo.DataSource = AdvertiserJobTemplateLogoService.GetByAdvertiserId(AdvertiserID);
            }
            else
            {
                ddlAdvertiserJobTemplateLogo.DataSource = AdvertiserJobTemplateLogoService.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId);
            }
            ddlAdvertiserJobTemplateLogo.DataTextField = "JobLogoName";
            ddlAdvertiserJobTemplateLogo.DataValueField = "AdvertiserJobTemplateLogoID";
            ddlAdvertiserJobTemplateLogo.DataBind();
            //ddlAdvertiserJobTemplateLogo.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
            ddlAdvertiserJobTemplateLogo.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        private void LoadJobStatus()
        {
            ddlStatus.DataSource = Common.Utils.GetEnumForDropDowns<PortalEnums.Jobs.JobStatus>();
            ddlStatus.DataTextField = "Value";
            ddlStatus.DataValueField = "Key";
            ddlStatus.DataBind();

            // Remove the expired from the list
            ddlStatus.Items.Remove(ddlStatus.Items.FindByValue(((int)PortalEnums.Jobs.JobStatus.Expired).ToString()));
            ddlStatus.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), ""));
        }

        private void LoadScreeningQuesitonsTemplate()
        {
            int advertiserId = (IsAdmin) ? AdvertiserID : SessionData.AdvertiserUser.AdvertiserId;
            GlobalSettings globalSetting = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault();
            ddlScreeningQuestionsTemplate.Items.Clear();

           if (globalSetting.EnableScreeningQuestions)
            {
                phScreeningQuestionsTemplates.Visible = true;

                List<ScreeningQuestionsTemplatesEntity> screeningQuestionsTemplates = ScreeningQuestionsTemplatesService.SelectByAdvertiserId(advertiserId);

                ddlScreeningQuestionsTemplate.DataSource = screeningQuestionsTemplates;
                ddlScreeningQuestionsTemplate.DataBind();
            }
            else
            {
                phScreeningQuestionsTemplates.Visible = false;
            }

            ddlScreeningQuestionsTemplate.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), ""));
        }

        protected void ddlScreeningQuestionsTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            phScreeningQuestions.Visible = (ddlScreeningQuestionsTemplate.SelectedIndex != 0);
            if (!string.IsNullOrEmpty(ddlScreeningQuestionsTemplate.SelectedValue))
            {
                List<ScreeningQuestionsEntity> screeningQuestions = ScreeningQuestionsService.SelectByScreeningQuestionsTemplateIdLanguageId(Convert.ToInt32(ddlScreeningQuestionsTemplate.SelectedValue), SessionData.Site.DefaultLanguageId);
                rptScreeningQuestions.DataSource = screeningQuestions;
                rptScreeningQuestions.DataBind();
            }
            else
            {
                rptScreeningQuestions.DataSource = null;
                rptScreeningQuestions.DataBind();
            }
        }

        protected void rptScreeningQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltQuestion = e.Item.FindControl("ltQuestion") as Literal;
                Literal ltOptions = e.Item.FindControl("ltOptions") as Literal;

                ScreeningQuestionsEntity screeningQuestion = e.Item.DataItem as ScreeningQuestionsEntity;

                ltQuestion.Text = HttpUtility.HtmlEncode(screeningQuestion.QuestionTitle);

                StringBuilder options = new StringBuilder();
                Regex regex = new Regex("(\".*?\"|[^\",\\s]+)(?=\\s*,|\\s*$)");
                MatchCollection matches = regex.Matches(screeningQuestion.Options);

                if (screeningQuestion.QuestionType == (int)PortalEnums.Jobs.ScreeningQuestionsType.Dropdown)
                {
                    foreach (Match m in matches)
                    {
                        options.AppendLine(string.Format("<option>{0}</option>", HttpUtility.HtmlEncode(m.Value)));

                        ltOptions.Text = string.Format("<select>{0}</select>", options);
                    }
                }

                if (screeningQuestion.QuestionType == (int)PortalEnums.Jobs.ScreeningQuestionsType.MultiSelect)
                {
                    foreach (Match m in matches)
                    {
                        options.AppendLine(string.Format("<input type=\"checkbox\" name=\"\" value=\"\" disabled>{0}&nbsp;", HttpUtility.HtmlEncode(m.Value)));

                        ltOptions.Text = options.ToString();
                    }
                }

                if (screeningQuestion.QuestionType == (int)PortalEnums.Jobs.ScreeningQuestionsType.RadioButtons)
                {
                    foreach (Match m in matches)
                    {
                        options.AppendLine(string.Format("<input type=\"radio\" name=\"\" value=\"\" disabled>{0}&nbsp;", HttpUtility.HtmlEncode(m.Value)));

                        ltOptions.Text = options.ToString();
                    }
                }
            }
        }

        private void LoadWorkType()
        {
            List<JXTPortal.Entities.SiteWorkType> siteWorkTypes = SiteWorkTypeService.GetTranslatedWorkTypes().OrderBy(siteWorktype => siteWorktype.Sequence).ToList();
            ddlWorkType.DataSource = siteWorkTypes;
            ddlWorkType.DataBind();
            ddlWorkType.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        private void LoadSalary()
        {
            List<Entities.SiteSalaryType> sitesalarytypes = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
            ddlSalary.Items.Clear();

            foreach (Entities.SiteSalaryType sitesalarytype in sitesalarytypes)
            {
                ddlSalary.Items.Add(new ListItem(sitesalarytype.SalaryTypeName, sitesalarytype.SalaryTypeId.ToString()));
            }

            ddlSalary.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));

        }
        ///*
        //private void LoadSalaryFrom(int salarytypeid)
        //{
        //    ddlSalaryFrom.Items.Clear();

        //    VList<ViewSalary> salaryFromList = ViewSalaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, salarytypeid);
        //    foreach (ViewSalary vs in salaryFromList)
        //    {
        //        ListItem li = new ListItem();
        //        li.Value = string.Format("{0};{1}", vs.CurrencyId, vs.Amount);
        //        li.Text = vs.SalaryDisplay;

        //        ddlSalaryFrom.Items.Add(li);
        //    }
        //}

        //private void LoadSalaryTo(int salarytypeid, int currecnyid, decimal amount)
        //{
        //    ddlSalaryTo.Items.Clear();

        //    VList<ViewSalary> salaryToList = ViewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, currecnyid, salarytypeid, amount);
        //    foreach (ViewSalary vs in salaryToList)
        //    {
        //        ListItem li = new ListItem();
        //        li.Value = string.Format("{0};{1}", vs.CurrencyId, vs.Amount);
        //        li.Text = vs.SalaryDisplay;

        //        ddlSalaryTo.Items.Add(li);
        //    }
        //}*/

        ////private void LoadAdvertiser()
        ////{
        ////    using (TList<JXTPortal.Entities.Advertisers> advertisers = AdvertisersService.GetBySiteId(SessionData.Site.SiteId))
        ////    {
        ////        dataAdvertiserId.DataSource = advertisers;
        ////        dataAdvertiserId.DataBind();
        ////        dataAdvertiserId.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        ////    }
        ////}


        private void LoadLocation()
        {
            ddlLocation.Items.Clear();

            SiteCountriesService siteCountriesService = new SiteCountriesService();
            SiteLocationService siteLocationService = new SiteLocationService();
            List<Entities.SiteCountries> siteCountriesList = siteCountriesService.GetTranslatedCountries();

            ddlLocation.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));


            foreach (Entities.SiteCountries siteCountries in siteCountriesList)
            {
                ddlLocation.AddItemGroup(siteCountries.SiteCountryName);

                List<Entities.SiteLocation> filteredList = siteLocationService.GetTranslatedLocationsByCountryID(siteCountries.CountryId);

                foreach (Entities.SiteLocation siteLocation in filteredList)
                {
                    ddlLocation.Items.Add(new ListItem(siteLocation.SiteLocationName, siteLocation.LocationId.ToString()));
                }
            }
        }

        private void LoadArea()
        {
            ddlArea.DataSource = SiteAreaService.GetTranslatedAreas(Convert.ToInt32(ddlLocation.SelectedValue));
            ddlArea.DataTextField = "SiteAreaName";
            ddlArea.DataValueField = "AreaId";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));


            // Salary Currency
            using (Entities.Location location = LocationService.GetByLocationId(Convert.ToInt32(ddlLocation.SelectedValue)))
            {
                if (location != null)
                {
                    using (Entities.SiteCountries siteCountry = SiteCountriesService.GetBySiteIdCountryId(SessionData.Site.SiteId, location.CountryId))
                    {

                        if (siteCountry != null)
                        {
                            ltlLowerCurrency.Text = siteCountry.Currency;
                            ltlUpperCurrency.Text = siteCountry.Currency;
                        }
                    }
                }
            }
        }

        private void LoadProfession()
        {
            //we just need to get the data once
            List<JXTPortal.Entities.SiteProfession>
                siteProfessionList = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.UseCustomProfessionRole).OrderBy(siteProfession => siteProfession.Sequence).ToList();

            LoadProfession(siteProfessionList, ddlProfession1);
            LoadProfession(siteProfessionList, ddlProfession2);
            LoadProfession(siteProfessionList, ddlProfession3);
        }

        private void LoadProfession(List<JXTPortal.Entities.SiteProfession> prof, DropDownList ddlProfessionControl)
        {
            ddlProfessionControl.DataSource = prof;
            ddlProfessionControl.DataTextField = "SiteProfessionName";
            ddlProfessionControl.DataValueField = "ProfessionId";
            ddlProfessionControl.DataBind();
            ddlProfessionControl.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        private void LoadRoles(int ProfessionId, ref DropDownList ddlRoleControl)
        {
            ddlRoleControl.DataSource = SiteRolesService.GetTranslatedByProfessionID(ProfessionId, SessionData.Site.UseCustomProfessionRole).OrderBy(siteRole => siteRole.Sequence).ToList();
            ddlRoleControl.DataTextField = "SiteRoleName";
            ddlRoleControl.DataValueField = "RoleId";
            ddlRoleControl.DataBind();
            ddlRoleControl.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        private void LoadApplicationMethod()
        {
            ddlApplicationMethod.DataSource = CommonFunction.GetEnumFormattedNames<PortalEnums.Jobs.ApplicationMethod>();
            ddlApplicationMethod.DataTextField = "Key";
            ddlApplicationMethod.DataValueField = "Value";
            ddlApplicationMethod.DataBind();
        }

        private void LoadJob()
        {
            /*if (SessionData.AdvertiserUser != null)
            {
                txtApplicationEmailAddress.Text = SessionData.AdvertiserUser.ApplicationEmailAddress;
            }*/

            if (JobID > 0)
            {
                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                {
                    if (IsAdmin)
                    {
                        if (job.SiteId != SessionData.Site.SiteId || job.AdvertiserId != AdvertiserID || job.EnteredByAdvertiserUserId != (int?)AdvertiserUserID)
                        {
                            Response.Redirect("/admin/advertisers.aspx");
                        }
                    }
                    else
                    {
                        if (job.AdvertiserId != SessionData.AdvertiserUser.AdvertiserId)
                        {
                            Response.Redirect("/advertiser/default.aspx");
                        }

                        if (!SessionData.AdvertiserUser.PrimaryAccount && job.EnteredByAdvertiserUserId != SessionData.AdvertiserUser.AdvertiserUserId)
                        {
                            Response.Redirect("/advertiser/default.aspx");
                        }
                    }


                    if (job != null && job.SiteId == SessionData.Site.SiteId)
                    {
                        JobValidation(job);

                        ddlAdvertiser.SelectedValue = job.AdvertiserId.ToString();
                        ddlJobItemType.SelectedValue = job.JobItemTypeId.ToString();

                        if (job.JobItemTypeId == (int)PortalEnums.Jobs.JobItemType.Premium)
                        {
                            // phJobStartDate.Visible = true;
                        }

                        if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                        {
                            ddlJobItemType.Enabled = false;

                            // Set Job Type Drop Down to have selected job type only
                            ddlJobItemType.Items.Clear();
                            TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
                            jobitemtypes.Filter = string.Format("JobItemTypeParentId = {0} AND TotalNumberOfJobs = 1", job.JobItemTypeId);
                            if (jobitemtypes.Count > 0)
                            {
                                ddlJobItemType.Items.Add(new ListItem(jobitemtypes[0].JobItemTypeDescription, jobitemtypes[0].JobItemTypeParentId.ToString()));
                            }

                        }

                        if (job.Expired != (int)PortalEnums.Jobs.JobStatus.Live || job.Expired != (int)PortalEnums.Jobs.JobStatus.Expired)
                        {
                            tbStartDate.Enabled = false;
                            ibStartDate.Enabled = false;
                            rqStartDate.Enabled = false;
                            cvStartDate.Enabled = false;
                        }

                        //LoadAdvertiserUser((job.EnteredByAdvertiserUserId.HasValue) ? (int)job.EnteredByAdvertiserUserId : 0);
                        // Disable Friendly Url

                        txtFriendlyUrl.Enabled = false;

                        txtApplicationEmailAddress.Text = CommonService.DecodeString(job.ApplicationEmailAddress);
                        ddlWorkType.SelectedValue = job.WorkTypeId.ToString();
                        //ddlSalary.SelectedValue = job.SalaryId.ToString();
                        chkShowSalaryRange.Checked = job.ShowSalaryRange;

                        JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual ucJobFieldsMultiLingual = rptLanguagesPanel.Items[0].FindControl("ucJobFieldsMultiLingual") as JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual;
                        ucJobFieldsMultiLingual.JobName = CommonService.DecodeString(job.JobName.ToString());
                        ucJobFieldsMultiLingual.ShortDescription = CommonService.DecodeString(job.Description.ToString());
                        ucJobFieldsMultiLingual.FullDescription = CommonService.DecodeString(job.FullDescription.ToString());

                        TList<Entities.JobCustomXml> jobcustomxmllist = JobCustomXmlService.CustomGetBySiteIDJobIDCustomType(SessionData.Site.SiteId, job.JobId, (int)PortalEnums.Jobs.CustomType.Job);
                        Entities.JobCustomXml jobcustomxml = null;
                        if (jobcustomxmllist.Count > 0) jobcustomxml = jobcustomxmllist[0];

                        if (rptLanguagesPanel.Items.Count > 1 && jobcustomxml != null)
                        {
                            XmlDocument xmldoc = new XmlDocument();
                            xmldoc.LoadXml(jobcustomxml.CustomXml);

                            for (int i = 1; i < rptLanguagesPanel.Items.Count; i++)
                            {
                                JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual ucCustomMultiLingual = rptLanguagesPanel.Items[i].FindControl("ucJobFieldsMultiLingual") as JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual;
                                System.Web.UI.HtmlControls.HtmlInputCheckBox cbEnableLanguage = ucCustomMultiLingual.FindControl("cbEnableLanguage") as System.Web.UI.HtmlControls.HtmlInputCheckBox;

                                foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("JobDetail"))
                                {
                                    XmlNode langnode = xmldoc.GetElementsByTagName("LanguageID")[0];

                                    if (langnode.InnerText == ucCustomMultiLingual.LanguageID.ToString())
                                    {
                                        XmlNode enablednode = xmldoc.GetElementsByTagName("Enabled")[0];
                                        XmlNode jobnamenode = xmldoc.GetElementsByTagName("JobName")[0];
                                        XmlNode bulletpoint1 = xmldoc.GetElementsByTagName("BulletPoint1")[0];
                                        XmlNode bulletpoint2 = xmldoc.GetElementsByTagName("BulletPoint2")[0];
                                        XmlNode bulletpoint3 = xmldoc.GetElementsByTagName("BulletPoint3")[0];
                                        XmlNode shortdescription = xmldoc.GetElementsByTagName("ShortDescription")[0];
                                        XmlNode fulldescription = xmldoc.GetElementsByTagName("FullDescription")[0];


                                        if (enablednode != null)
                                        {
                                            cbEnableLanguage.Checked = Convert.ToBoolean(enablednode.InnerText);
                                        }

                                        ucCustomMultiLingual.JobName = jobnamenode.InnerText;
                                        ucCustomMultiLingual.BulletPoint1 = bulletpoint1.InnerText;
                                        ucCustomMultiLingual.BulletPoint2 = bulletpoint2.InnerText;
                                        ucCustomMultiLingual.BulletPoint3 = bulletpoint3.InnerText;
                                        ucCustomMultiLingual.ShortDescription = shortdescription.InnerText;
                                        ucCustomMultiLingual.FullDescription = fulldescription.InnerText;
                                    }
                                }
                                // TODO: Retrieving multilingual fields into database

                            }
                        }

                        txtRefNo.Text = CommonService.DecodeString(job.RefNo.ToString());
                        //chkVisible.Checked = job.Visible;
                        lblDatePosted.Text = job.DatePosted.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        lblExpiryDate.Text = job.ExpiryDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        chkJobExpired.Checked = (job.Expired.HasValue && job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) ? true : false;
                        txtJobItemPrice.Text = (job.JobItemPrice.HasValue) ? job.JobItemPrice.ToString() : string.Empty;
                        //chkBilled.Checked = job.Billed;
                        lblLastModified.Text = job.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        chkShowSalaryDetails.Checked = job.ShowSalaryDetails;
                        txtSalaryText.Text = (!string.IsNullOrEmpty(job.SalaryText)) ? CommonService.DecodeString(job.SalaryText.ToString()) : string.Empty;

                        // Set the Friendly Url if it is not Set
                        if (!String.IsNullOrEmpty(txtFriendlyUrl.Text.Trim()))
                            txtFriendlyUrl.Text = Common.Utils.UrlFriendlyName(job.JobName);
                        else
                            txtFriendlyUrl.Text = job.JobFriendlyName;
                        txtCompanyName.Text = CommonService.DecodeString(job.CompanyName);

                        //dataAdvertiserId.SelectedValue = job.AdvertiserId.ToString();

                        if (job.EnteredByAdvertiserUserId != null)
                        {
                            using (Entities.AdvertiserUsers advertiserusers = AdvertiserUsersService.GetByAdvertiserUserId((int)job.EnteredByAdvertiserUserId))
                            {
                                if (advertiserusers != null)
                                    lblPostedByAdvertiserUser.Text = CommonService.DecodeString(advertiserusers.UserName);
                                else
                                    lblPostedByAdvertiserUser.Text = "";
                            }
                        }
                        else
                        {
                            lblPostedByAdvertiserUser.Text = "";
                        }

                        if (job.LastModifiedByAdvertiserUserId != null)
                        {
                            using (Entities.AdvertiserUsers advertiserusers = AdvertiserUsersService.GetByAdvertiserUserId((int)job.LastModifiedByAdvertiserUserId))
                            {
                                if (advertiserusers != null)
                                    lblLastModifiedByAdvertiserUserId.Text = CommonService.DecodeString(advertiserusers.UserName);
                                else
                                    lblLastModifiedByAdvertiserUserId.Text = "";
                            }
                        }
                        else
                        {
                            phlastmodifiedByAdvuserID.Visible = false;
                        }

                        if (job.LastModifiedByAdminUserId != null)
                        {
                            using (Entities.AdminUsers adminusers = AdminUsersService.GetByAdminUserId((int)job.LastModifiedByAdminUserId))
                            {
                                if (adminusers != null)
                                    lblLastModifiedByAdminUserId.Text = CommonService.DecodeString(adminusers.UserName);
                                else
                                    lblLastModifiedByAdminUserId.Text = "";
                            }
                        }
                        else
                        {
                            phLastmodifiedByAdmin.Visible = false;
                        }


                        if (job.JobItemTypeId.HasValue)
                            ddlJobItemType.SelectedValue = job.JobItemTypeId.ToString();

                        ddlApplicationMethod.SelectedValue = job.ApplicationMethod.ToString();

                        if (Convert.ToInt32(ddlApplicationMethod.SelectedValue) == 2)
                            txtApplicationURL.Enabled = true;
                        else
                            txtApplicationURL.Enabled = false;

                        if (job.ApplicationUrl != null)
                        {
                            txtApplicationURL.Text = CommonService.DecodeString(job.ApplicationUrl.ToString());
                        }

                        if (!string.IsNullOrEmpty(job.Tags))
                            txtTags.Text = CommonService.DecodeString(job.Tags.ToString());

                        ddlSalary.SelectedValue = job.SalaryTypeId.ToString();
                        //LoadSalaryFrom(job.SalaryTypeId);
                        txtSalaryLowerBand.Text = job.SalaryLowerBand.ToString();
                        //LoadSalaryTo(job.SalaryTypeId, job.CurrencyId, job.SalaryLowerBand);
                        txtSalaryUpperBand.Text = job.SalaryUpperBand.ToString();

                        if (job.JobTemplateId.HasValue)
                        {
                            ddlJobTemplateID.SelectedValue = job.JobTemplateId.ToString();
                            imgAdvJobTemplate.ImageUrl = "/getfile.aspx?jobtemplateid=" + job.JobTemplateId.ToString();

                            imgAdvJobTemplate.Attributes.Add("style", "display:block");
                        }
                        else
                        {
                            imgAdvJobTemplate.Attributes.Add("style", "display:none");
                        }

                        //dataSearchFieldExtension.Text = job.SearchFieldExtension.ToString();
                        //dataAdvertiserJobTemplateLogoID.Text = job.AdvertiserJobTemplateLogoId.ToString();
                        if (job.AdvertiserJobTemplateLogoId.HasValue)
                            ddlAdvertiserJobTemplateLogo.SelectedValue = Convert.ToString(job.AdvertiserJobTemplateLogoId);

                        if (job.ScreeningQuestionsTemplateId.HasValue)
                        {
                            ddlScreeningQuestionsTemplate.SelectedValue = Convert.ToString(job.ScreeningQuestionsTemplateId.Value);
                            ddlScreeningQuestionsTemplate.Enabled = false;
                        }
                        //chkRequireLogonForExternalApplications.Checked = job.RequireLogonForExternalApplications;
                        chkShowLocationDetails.Checked = (job.ShowLocationDetails == null) ? false : (bool)job.ShowLocationDetails;
                        if (!string.IsNullOrEmpty(job.PublicTransport))
                            txtPublicTransport.Text = CommonService.DecodeString(job.PublicTransport.ToString());
                        if (!string.IsNullOrEmpty(job.Address))
                        {
                            HasAddressInputValue = true;  //flag for ascx use
                            txtAddress.Text = CommonService.DecodeString(job.Address.ToString());

                            if (job.JobLatitude != null && job.JobLongitude != null)
                            {
                                hfAddressLat.Value = job.JobLatitude.ToString();
                                hfAddressLng.Value = job.JobLongitude.ToString();

                                HasLatLngInputValues = true; //flag for ascx use
                            }
                        }
                        txtContactDetails.Text = CommonService.DecodeString(job.ContactDetails.ToString());
                        if (!string.IsNullOrEmpty(job.JobContactPhone))
                            txtJobContactPhone.Text = CommonService.DecodeString(job.JobContactPhone.ToString());
                        if (!string.IsNullOrEmpty(job.JobContactName))
                            txtJobContactName.Text = CommonService.DecodeString(job.JobContactName.ToString());
                        chkQualificationsRecognised.Checked = job.QualificationsRecognised;
                        chkResidentOnly.Checked = job.ResidentOnly;
                        //txtDocumentLink.Text = job.DocumentLink.ToString();
                        ucJobFieldsMultiLingual.BulletPoint1 = (string.IsNullOrEmpty(job.BulletPoint1)) ? "" : CommonService.DecodeString(job.BulletPoint1.ToString());
                        ucJobFieldsMultiLingual.BulletPoint2 = (string.IsNullOrEmpty(job.BulletPoint2)) ? "" : CommonService.DecodeString(job.BulletPoint2.ToString());
                        ucJobFieldsMultiLingual.BulletPoint3 = (string.IsNullOrEmpty(job.BulletPoint3)) ? "" : CommonService.DecodeString(job.BulletPoint3.ToString());
                        //chkHotJob.Checked = job.HotJob;
                        isRepostJob = (job.SearchFieldExtension == "Repost");
                        foreach (JXTPortal.Entities.JobArea jobArea in JobAreaService.GetByJobId(job.JobId))
                        {
                            using (JXTPortal.Entities.Area area = AreaService.GetByAreaId(jobArea.AreaId))
                            {

                                LoadLocation();
                                CommonFunction.SetDropDownByValue(ddlLocation, area.LocationId.ToString());

                                LoadArea();
                                CommonFunction.SetDropDownByValue(ddlArea, jobArea.AreaId.ToString());
                            }
                        }

                        using (TList<JXTPortal.Entities.JobRoles> jobRoles = JobRolesService.GetByJobId(job.JobId))
                        {
                            if (jobRoles.Count > 0 && jobRoles[0] != null)
                            {
                                using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[0].RoleId.Value))
                                {
                                    CommonFunction.SetDropDownByValue(ddlProfession1, role.ProfessionId.ToString());
                                    LoadRoles(role.ProfessionId, ref ddlRole1);
                                    CommonFunction.SetDropDownByValue(ddlRole1, jobRoles[0].RoleId.Value.ToString());
                                }

                            }

                            if (jobRoles.Count > 1 && jobRoles[1] != null && jobRoles[1].RoleId.HasValue)
                            {
                                using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[1].RoleId.Value))
                                {
                                    CommonFunction.SetDropDownByValue(ddlProfession2, role.ProfessionId.ToString());
                                    LoadRoles(role.ProfessionId, ref ddlRole2);
                                    CommonFunction.SetDropDownByValue(ddlRole2, jobRoles[1].RoleId.Value.ToString());
                                }
                            }

                            if (jobRoles.Count > 2 && jobRoles[2] != null && jobRoles[2].RoleId.HasValue)
                            {
                                using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[2].RoleId.Value))
                                {
                                    CommonFunction.SetDropDownByValue(ddlProfession3, role.ProfessionId.ToString());
                                    LoadRoles(role.ProfessionId, ref ddlRole3);
                                    CommonFunction.SetDropDownByValue(ddlRole3, jobRoles[2].RoleId.Value.ToString());
                                }
                            }

                        }
                    }
                    else
                    {
                        //TO DO: redirection after insert/update job
                        Response.Redirect("~/advertiser/default.aspx");
                    }
                }
            }
            else
            {
                // When a new JOB then disable the below.
                phPostedBy.Visible = false;
                phlastmodifiedByAdvuserID.Visible = false;
                phLastmodifiedByAdmin.Visible = false;
                chkJobExpired.Enabled = false;
                phPostedDates.Visible = false;
            }
        }

        private void LoadAdvertiser()
        {
            ddlAdvertiser.Items.Clear();

            using (TList<Entities.Advertisers> advertisers = AdvertisersService.GetBySiteId(SessionData.Site.SiteId))
            {
                ddlAdvertiser.DataSource = advertisers;
                ddlAdvertiser.DataBind();

                ddlAdvertiser.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));

                if (AdvertiserID != 0)
                {
                    ddlAdvertiser.SelectedValue = Convert.ToString(AdvertiserID);

                    using (Entities.AdvertiserUsers advertiserusers = AdvertiserUsersService.GetByAdvertiserUserId(AdvertiserUserID))
                    {
                        if (AdvertiserUsersService.IsAdvertiserUserExists(AdvertiserID, AdvertiserUserID))
                        {
                            lblusername.Text = advertiserusers.UserName;
                        }
                        else
                        {
                            pnlAdvertiserUser.Visible = false;
                        }
                    }
                }
            }
        }

        private void LoadUI()
        {
            if (IsAdmin)
            {
                if (AdvertiserID > 0 && AdvertiserUserID > 0 && AdvertiserUsersService.IsAdvertiserUserExists(AdvertiserID, AdvertiserUserID))
                {
                    pnlAdvertiser.Visible = true;
                    pnlAdvertiserUser.Visible = true;
                }
                else if (JobID > 0)
                {
                    pnlAdvertiser.Visible = false;
                    pnlAdvertiserUser.Visible = false;
                }
                else
                {
                    Response.Redirect("~/admin/advertisers.aspx");
                }
            }
            else
            {
                pnlAdvertiser.Visible = false;
                pnlAdvertiserUser.Visible = false;
                ReqVal_Advertiser.Enabled = false;
            }
        }

        private void AssignAddressGeocodes(JXTPortal.Entities.Jobs jobReferenceObj)
        {
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            //defaults
            jobReferenceObj.JobLatitude = null;
            jobReferenceObj.JobLongitude = null;
            jobReferenceObj.AddressStatus = null;

            if (integrations != null && integrations.GoogleMap != null)
            {
                //only assign anything to the geocode and address status if there is a server key in the integrations of the site
                if (!string.IsNullOrWhiteSpace(integrations.GoogleMap.ServerKey) && integrations.GoogleMap.Valid)
                {
                    if (string.IsNullOrWhiteSpace(txtAddress.Text))
                    {
                        jobReferenceObj.AddressStatus = (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Invalid;
                    }
                    else
                    {
                        //assign geocodes if any
                        if (hfAddressLat != null && hfAddressLng != null & !string.IsNullOrWhiteSpace(hfAddressLat.Value) && !string.IsNullOrWhiteSpace(hfAddressLng.Value))
                        {
                            double parseLat = 0, parseLng = 0;
                            if (double.TryParse(hfAddressLat.Value, out parseLat) && double.TryParse(hfAddressLng.Value, out parseLng))
                            {
                                jobReferenceObj.JobLatitude = parseLat;
                                jobReferenceObj.JobLongitude = parseLng;
                                jobReferenceObj.AddressStatus = (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Valid;
                            }
                            else
                            {
                                jobReferenceObj.JobLatitude = null;
                                jobReferenceObj.JobLongitude = null;
                                jobReferenceObj.AddressStatus = (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Queued;
                            }
                        }
                        else
                        {
                            jobReferenceObj.JobLatitude = null;
                            jobReferenceObj.JobLongitude = null;
                            jobReferenceObj.AddressStatus = (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Queued;
                        }
                    }
                }
            }
        }

        //#endregion

        protected void CusValJobProfessionRole_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool valid = true;

            if (ddlRole1.SelectedValue != "0")
            {
                if (ddlRole1.SelectedValue == ddlRole2.SelectedValue)
                {
                    valid = false;
                }

                if (ddlRole1.SelectedValue == ddlRole3.SelectedValue)
                {
                    valid = false;
                }
            }

            if (ddlRole2.SelectedValue != "0")
            {
                if (ddlRole2.SelectedValue == ddlRole1.SelectedValue)
                {
                    valid = false;
                }

                if (ddlRole2.SelectedValue == ddlRole3.SelectedValue)
                {
                    valid = false;
                }
            }

            if (ddlRole3.SelectedValue != "0")
            {
                if (ddlRole3.SelectedValue == ddlRole1.SelectedValue)
                {
                    valid = false;
                }

                if (ddlRole3.SelectedValue == ddlRole2.SelectedValue)
                {
                    valid = false;
                }
            }

            args.IsValid = valid;
        }

        protected void ctmApplicationMethod_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(txtApplicationURL.Text) && Convert.ToInt32(ddlApplicationMethod.SelectedValue) == 2)
            {
                valid = false;
            }

            args.IsValid = valid;
        }

        protected void ddlSiteCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLocation();
            LoadArea();
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArea();
        }

        protected void ddlProfession1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles(Convert.ToInt32(ddlProfession1.SelectedValue), ref ddlRole1);
        }

        protected void ddlProfession2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles(Convert.ToInt32(ddlProfession2.SelectedValue), ref ddlRole2);
        }

        protected void ddlProfession3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles(Convert.ToInt32(ddlProfession3.SelectedValue), ref ddlRole3);
        }

        protected void ddlApplicationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlApplicationMethod.SelectedValue) == 2)
            {
                txtApplicationURL.Enabled = true;
            }
            else
            {
                txtApplicationURL.Enabled = false;
                txtApplicationURL.Text = string.Empty;
            }
        }

        ///*
        //protected void ddlSalary_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadSalaryFrom(Convert.ToInt32(ddlSalary.SelectedValue));
        //    LoadSalaryTo(Convert.ToInt32(ddlSalary.SelectedValue), 0, 0);
        //}

        //protected void ddlSalaryFrom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string result = ddlSalaryFrom.SelectedValue;
        //    string[] parts = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        //    LoadSalaryTo(Convert.ToInt32(ddlSalary.SelectedValue), Convert.ToInt32(parts[0]), Convert.ToDecimal(parts[1]));
        //}*/

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            bool isDraft = (((Button)sender) == DraftButton);

            if (Page.IsValid)
            {
                using (JXTPortal.Entities.Jobs job = new JXTPortal.Entities.Jobs())
                {
                    int daysactive = 30;

                    if (job.JobItemTypeId == (int)PortalEnums.Jobs.JobItemType.Premium)
                    {
                        TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
                        jobitemtypes.Filter = "TotalNumberOfJobs = 1 AND JobItemTypeParentID = " + ddlJobItemType.SelectedValue.ToString();
                        if (jobitemtypes.Count > 0)
                        {
                            daysactive = jobitemtypes[0].DaysActive;
                        }
                    }

                    job.SiteId = SessionData.Site.SiteId;
                    //job.DatePosted = DateTime.Now;
                    job.WebServiceProcessed = false;
                    job.WorkTypeId = Convert.ToInt32(ddlWorkType.SelectedValue);

                    JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual ucJobFieldsMultiLingual = rptLanguagesPanel.Items[0].FindControl("ucJobFieldsMultiLingual") as JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual;

                    job.JobName = CommonService.EncodeString(ucJobFieldsMultiLingual.JobName);
                    job.Description = CommonService.EncodeString(ucJobFieldsMultiLingual.ShortDescription);
                    job.FullDescription = ucJobFieldsMultiLingual.FullDescription;
                    job.RefNo = CommonService.EncodeString(txtRefNo.Text);
                    job.DatePosted = DateTime.Now;
                    job.ExpiryDate = DateTime.Now.AddDays(daysactive);

                    //job.Expired = chkJobExpired.Checked ? (int) PortalEnums.Jobs.JobStatus.Expired : (int) PortalEnums.Jobs.JobStatus.Live;
                    if (!string.IsNullOrEmpty(txtJobItemPrice.Text))
                    {
                        job.JobItemPrice = Convert.ToDecimal(txtJobItemPrice.Text);
                    }

                    //string[] salaryFrom = ddlSalaryFrom.SelectedValue.Split(';');
                    //string[] salaryTo = ddlSalaryTo.SelectedValue.Split(';'); ;
                    job.CurrencyId = 1; // Todo - Currency is not used .. and its hardcoded. - Don't remove this - it breaks the advanced search.
                    job.SalaryLowerBand = (CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text).HasValue ?
                                                CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text).Value : 0);
                    job.SalaryUpperBand = (CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text).HasValue ?
                                                CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text).Value : 0);
                    job.SalaryTypeId = Convert.ToInt32(ddlSalary.SelectedValue);


                    job.ShowSalaryRange = chkShowSalaryRange.Checked;
                    job.ShowSalaryDetails = chkShowSalaryDetails.Checked;
                    job.SalaryText = txtSalaryText.Text;
                    job.JobItemTypeId = Convert.ToInt32(ddlJobItemType.SelectedValue);

                    job.ApplicationEmailAddress = txtApplicationEmailAddress.Text;

                    job.ApplicationMethod = Convert.ToInt32(ddlApplicationMethod.SelectedValue);
                    job.ApplicationUrl = txtApplicationURL.Text;

                    //Upload Method always 1 (Website) as the job is posted manually
                    job.UploadMethod = 1;

                    job.Tags = txtTags.Text;
                    job.JobTemplateId = Convert.ToInt32(ddlJobTemplateID.SelectedValue);
                    //job.SearchFieldExtension = dataSearchFieldExtension.Text;
                    //job.AdvertiserJobTemplateLogoId = 
                    //    (string.IsNullOrEmpty(dataAdvertiserJobTemplateLogoID.Text)) ? (int?)null : Convert.ToInt32(dataAdvertiserJobTemplateLogoID.Text);

                    job.AdvertiserJobTemplateLogoId = Convert.ToInt32(ddlAdvertiserJobTemplateLogo.SelectedValue);
                    job.ScreeningQuestionsTemplateId = (!string.IsNullOrEmpty(ddlScreeningQuestionsTemplate.SelectedValue)) ? Convert.ToInt32(ddlScreeningQuestionsTemplate.SelectedValue) : (int?)null;


                    if (docInput.HasFile)
                    {
                        Entities.AdvertiserJobTemplateLogo objAdvJobTemplateLogo = new JXTPortal.Entities.AdvertiserJobTemplateLogo();
                        objAdvJobTemplateLogo.AdvertiserId = (IsAdmin) ? AdvertiserID : SessionData.AdvertiserUser.AdvertiserId;

                        objAdvJobTemplateLogo.JobLogoName = tbJobLogoName.Text.Trim();

                        AdvertiserJobTemplateLogoService.Insert(objAdvJobTemplateLogo);

                        if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
                        {
                            if (this.docInput.PostedFile != null)
                            {
                                System.Drawing.Image objOriginalImage = null;
                                string contenttype = string.Empty;

                                Utils.IsValidUploadImage(docInput.PostedFile.FileName, docInput.PostedFile.InputStream, out objOriginalImage, out contenttype);
                                System.Drawing.Image objResizedImage = JXTPortal.Common.Utils.ResizeImage(objOriginalImage,
                                    PortalConstants.THUMBNAIL_WIDTH, PortalConstants.THUMBNAIL_HEIGHT);

                                System.IO.MemoryStream objOutputMemorySTream = new System.IO.MemoryStream();
                                objResizedImage.Save(objOutputMemorySTream, objOriginalImage.RawFormat);

                                byte[] abytFile = new byte[Convert.ToInt32(objOutputMemorySTream.Length)];
                                objOutputMemorySTream.Position = 0;
                                objOutputMemorySTream.Read(abytFile, 0, abytFile.Length);

                                FtpClient ftpclient = new FtpClient();
                                string errormessage = string.Empty;
                                string extension = Utils.GetImageExtension(objOriginalImage);
                                ftpclient.Host = ConfigurationManager.AppSettings["FTPFileManager"];
                                ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                                ftpclient.UploadFileFromStream(objOutputMemorySTream, string.Format("{0}/{1}/AdvertiserJobTemplateLogo_{2}.{3}", ftpclient.Host, ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"], objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension), out errormessage);

                                if (string.IsNullOrWhiteSpace(errormessage))
                                {
                                    objAdvJobTemplateLogo.JobTemplateLogoUrl = string.Format("AdvertiserJobTemplateLogo_{0}.{1}", objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension);
                                    AdvertiserJobTemplateLogoService.Update(objAdvJobTemplateLogo);
                                }
                            }

                        }

                        job.AdvertiserJobTemplateLogoId = objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId;
                    }

                    // job.RequireLogonForExternalApplications = chkRequireLogonForExternalApplications.Checked;
                    job.ShowLocationDetails = chkShowLocationDetails.Checked;
                    job.PublicTransport = txtPublicTransport.Text;
                    job.Address = txtAddress.Text;

                    //assign geocodes if any
                    AssignAddressGeocodes(job);

                    job.ContactDetails = CommonService.EncodeString(txtContactDetails.Text);
                    job.JobContactPhone = txtJobContactPhone.Text;
                    job.JobContactName = txtJobContactName.Text;
                    job.QualificationsRecognised = chkQualificationsRecognised.Checked;
                    job.ResidentOnly = chkResidentOnly.Checked;
                    //job.DocumentLink = txtDocumentLink.Text;
                    job.BulletPoint1 = CommonService.EncodeString(ucJobFieldsMultiLingual.BulletPoint1);
                    job.BulletPoint2 = CommonService.EncodeString(ucJobFieldsMultiLingual.BulletPoint2);
                    job.BulletPoint3 = CommonService.EncodeString(ucJobFieldsMultiLingual.BulletPoint3);
                    //job.HotJob = chkHotJob.Checked;

                    job.JobFriendlyName = Common.Utils.UrlFriendlyName(txtFriendlyUrl.Text);


                    // By default the job is in the draft
                    job.Expired = (int)PortalEnums.Jobs.JobStatus.Draft;
                    // If job is checked as Expired.
                    if (chkJobExpired.Checked)
                        job.Expired = (int)PortalEnums.Jobs.JobStatus.Expired;
                    else if (isDraft)
                    {
                        job.Visible = false;
                    }
                    else // Else job is Live by default.
                        job.Visible = true;


                    // Only when in Admin page
                    if (IsAdmin)
                    {
                        job.AdvertiserId = Convert.ToInt32(ddlAdvertiser.SelectedValue);

                        //if (ddlAdvertiserUser.SelectedValue != "0")
                        //{
                        //    job.EnteredByAdvertiserUserId = Convert.ToInt32(ddlAdvertiserUser.SelectedValue);
                        //}

                        job.EnteredByAdvertiserUserId = AdvertiserUserID;

                        job.CompanyName = ddlAdvertiser.SelectedItem.Text;
                        job.LastModifiedByAdminUserId = SessionData.AdminUser.AdminUserId;
                        job.LastModifiedByAdvertiserUserId = (int?)null;


                        // When in Admin update the Status of the job
                        if (!string.IsNullOrWhiteSpace(ddlStatus.SelectedValue) && Convert.ToInt32(ddlStatus.SelectedValue) > -1)
                        {
                            job.Expired = Convert.ToInt32(ddlStatus.SelectedValue);
                            if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                            {
                                job.Visible = true;
                            }
                            // Todo if in Admin job is set to Live.
                            /*if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                                job.Billed = true;*/
                        }

                    }
                    else
                    {
                        job.AdvertiserId = (IsAdmin) ? AdvertiserID : SessionData.AdvertiserUser.AdvertiserId;
                        job.EnteredByAdvertiserUserId = (IsAdmin) ? AdvertiserUserID : SessionData.AdvertiserUser.AdvertiserUserId;

                        using (Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId))
                        {
                            job.CompanyName = advertiser.CompanyName;
                        }
                        job.LastModifiedByAdminUserId = (int?)null;
                        job.LastModifiedByAdvertiserUserId = SessionData.AdvertiserUser.AdvertiserUserId;
                    }
                    /*
                                        job.SearchField = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13}", job.JobName, JXTPortal.Common.Utils.StripHTML(job.Description), JXTPortal.Common.Utils.StripHTML(job.FullDescription),
                                            (ddlProfession1.SelectedIndex == 0) ? "" : ddlProfession1.SelectedValue, (ddlProfession2.SelectedIndex == 0) ? "" : ddlProfession3.SelectedValue, (ddlProfession1.SelectedIndex == 0) ? "" : ddlProfession3.SelectedValue,
                                            (ddlRole1.SelectedIndex == 0) ? "" : ddlRole1.SelectedValue, (ddlRole2.SelectedIndex == 0) ? "" : ddlRole2.SelectedValue, (ddlRole3.SelectedIndex == 0) ? "" : ddlRole3.SelectedValue,
                                            (ddlLocation.SelectedIndex == 0) ? "" : ddlLocation.SelectedValue, (ddlArea.SelectedIndex == 0) ? "" : ddlArea.SelectedValue, (ddlWorkType.SelectedIndex == 0) ? "" : ddlWorkType.SelectedValue, (ddlSalary.SelectedIndex == 0) ? "" : ddlSalary.SelectedValue,
                                            job.CompanyName);
                     */
                    //Strip off html then store in SearchField
                    //Add profession, salarytype, Location, area, work type, salary, company

                    // Check Job Credit before inserting
                    if (SessionData.Site.IsJobBoard && JobCreditCheck() == 0)
                    {
                        job.Expired = (int)PortalEnums.Jobs.JobStatus.Draft;
                    }

                    if (phJobStartDate.Visible)
                    {
                        job.DatePosted = DateTime.ParseExact(tbStartDate.Text, SessionData.Site.DateFormat, null);
                    }

                    if (JobsService.Insert(job))
                    {
                        // Insert Screening Questions into job
                        if (job.ScreeningQuestionsTemplateId.HasValue)
                        {
                            List<ScreeningQuestionsEntity> screeningQuestions = ScreeningQuestionsService.SelectByScreeningQuestionsTemplateId(job.ScreeningQuestionsTemplateId.Value);
                            foreach (ScreeningQuestionsEntity screeningQuestion in screeningQuestions)
                            {
                                if (screeningQuestion.Visible)
                                {
                                    JobScreeningQuestionsService.Insert(new JobScreeningQuestionsEntity { JobId = job.JobId, ScreeningQuestionId = screeningQuestion.ScreeningQuestionId });
                                }
                            }
                        }

                        // Insert MultiLingual

                        if (rptLanguagesPanel.Items.Count > 1)
                        {
                            // TODO: Insert multilingual fields into database
                            string customxml = ConstructJobXML();

                            if (!string.IsNullOrEmpty(customxml))
                            {
                                Entities.JobCustomXml jobcustomxml = new JobCustomXml();
                                jobcustomxml.SiteId = SessionData.Site.SiteId;
                                jobcustomxml.JobId = job.JobId;
                                jobcustomxml.CustomType = (int)PortalEnums.Jobs.CustomType.Job;
                                jobcustomxml.CustomXml = customxml;

                                JobCustomXmlService.Insert(jobcustomxml);
                            }

                        }

                        using (JXTPortal.Entities.JobArea objJobArea = new JXTPortal.Entities.JobArea())
                        {
                            objJobArea.JobId = job.JobId;
                            objJobArea.AreaId = Convert.ToInt32(ddlArea.SelectedValue);

                            if (JobAreaService.Insert(objJobArea))
                            {
                                using (JXTPortal.Entities.JobRoles objJobRoles = new JXTPortal.Entities.JobRoles())
                                {
                                    if (ddlRole1.SelectedValue != "0")
                                    {
                                        objJobRoles.JobId = job.JobId;
                                        objJobRoles.RoleId = (ddlRole1.SelectedValue != "0") ? Convert.ToInt32(ddlRole1.SelectedValue) : (int?)null;
                                        JobRolesService.Insert(objJobRoles);
                                    }

                                    // Ignore job role 2 - 3 if it is premium job
                                    if (job.JobItemTypeId.Value != (int)PortalEnums.Jobs.JobItemType.Premium)
                                    {
                                        if (ddlRole2.SelectedValue != "0")
                                        {
                                            objJobRoles.JobId = job.JobId;
                                            objJobRoles.RoleId = (ddlRole2.SelectedValue != "0") ? Convert.ToInt32(ddlRole2.SelectedValue) : (int?)null;
                                            JobRolesService.Insert(objJobRoles);
                                        }

                                        if (ddlRole3.SelectedValue != "0")
                                        {
                                            objJobRoles.JobId = job.JobId;
                                            objJobRoles.RoleId = (ddlRole3.SelectedValue != "0") ? Convert.ToInt32(ddlRole3.SelectedValue) : (int?)null;
                                            JobRolesService.Insert(objJobRoles);
                                        }
                                    }

                                    // Update for the Search Field
                                    JobsService.Update(job);

                                    /*
                                    if (job.Billed)
                                    {
                                        JobsService.CustomCalculateJobCount(job.SiteId, job.JobId, true);
                                        JobsService.JobX_SubmitQueue(job.JobId);
                                    }*/


                                    //Response.Redirect("~/advertiser/default.aspx");
                                    if (!IsAdmin)
                                    {
                                        // If it is draft job then redirect to the drafts page instead of preview page.
                                        if (!job.Visible)
                                        {
                                            Response.Redirect("~/advertiser/jobsdraft.aspx");
                                        }

                                        Response.Redirect("~/advertiser/jobpreview.aspx?jobid=" + job.JobId.ToString());
                                    }
                                    else
                                    {
                                        /*
                                        // When in Admin which doesn't redirect to the preview page so 
                                        // If job is expired then update the job count.
                                        if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Expired || job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                                        {
                                            // Update the Job count of the website.
                                            JobsService js = new JobsService();
                                            //js.CustomUpdateSiteJobCount(SessionData.Site.SiteId);
                                            
                                            // Update the job counts when expired and live
                                            if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Expired)
                                                JobsService.CustomCalculateJobCount(job.SiteId, job.JobId, false);
                                            else
                                                JobsService.CustomCalculateJobCount(job.SiteId, job.JobId, true);

                                            // Submit to the Jobx queue.
                                            JobsService.JobX_SubmitQueue(job.JobId);
                                        }*/

                                        Response.Redirect("~/admin/advertiser/jobsbyadvertiser.aspx?advertiserid=" + AdvertiserID);
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            bool isDraft = (((Button)sender) == DraftButton);

            if (Page.IsValid)
            {
                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                {
                    if (job == null)
                    {
                        if (IsAdmin)
                        {
                            Response.Redirect("/admin/advertiserusers.aspx");
                        }
                        else
                        {
                            Response.Redirect("/advertiser/default.aspx");
                        }
                    }
                    else
                    {
                        if (job.SiteId != SessionData.Site.SiteId)
                        {
                            if (IsAdmin)
                            {
                                Response.Redirect("/admin/advertisers.aspx");
                            }
                            else
                            {
                                Response.Redirect("/advertiser/default.aspx");
                            }
                        }


                        bool billed = job.Billed;
                        //bool needsUpdateFromDraft = (job.Billed == false && pnlSaveAsDraft.Visible && chkSaveAsDraft.Checked == false);

                        job.JobId = JobID;
                        job.SiteId = SessionData.Site.SiteId;

                        job.WorkTypeId = Convert.ToInt32(ddlWorkType.SelectedValue);

                        JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual ucJobFieldsMultiLingual = rptLanguagesPanel.Items[0].FindControl("ucJobFieldsMultiLingual") as JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual;

                        job.JobName = CommonService.EncodeString(ucJobFieldsMultiLingual.JobName);
                        job.Description = CommonService.EncodeString(ucJobFieldsMultiLingual.ShortDescription);
                        job.FullDescription = ucJobFieldsMultiLingual.FullDescription;
                        job.RefNo = CommonService.EncodeString(txtRefNo.Text);

                        //job.DatePosted = DateTime.Now;
                        job.JobItemPrice = (string.IsNullOrEmpty(txtJobItemPrice.Text)) ? (decimal?)null : Convert.ToDecimal(txtJobItemPrice.Text);

                        //string[] salaryFrom = ddlSalaryFrom.SelectedValue.Split(';');
                        //string[] salaryTo = ddlSalaryTo.SelectedValue.Split(';'); ;
                        job.CurrencyId = 1; // Todo - Currency is not used .. and its hardcoded. - Don't remove this - it breaks the advanced search.

                        job.SalaryLowerBand = (CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text).HasValue ?
                                                    CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text).Value : 0);
                        job.SalaryUpperBand = (CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text).HasValue ?
                                                    CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text).Value : 0);

                        //job.SalaryLowerBand = Convert.ToDecimal(salaryFrom[1]);
                        //job.SalaryUpperBand = Convert.ToDecimal(salaryTo[1]);
                        job.SalaryTypeId = Convert.ToInt32(ddlSalary.SelectedValue);

                        job.ShowSalaryRange = chkShowSalaryRange.Checked;
                        job.ShowSalaryDetails = chkShowSalaryDetails.Checked;

                        job.SalaryText = CommonService.EncodeString(txtSalaryText.Text);


                        // Default values.
                        job.Visible = false;
                        //job.Billed = false;

                        /*
                        // Save it as draft when the check box is checked.
                        if (pnlSaveAsDraft.Visible && chkSaveAsDraft.Checked)
                            job.Visible = false;
                        else
                            job.Visible = true; // means billed = 1 and not a draft.*/


                        if (job.Expired != (int)PortalEnums.Jobs.JobStatus.Live)
                        {
                            job.DatePosted = DateTime.Now;
                            job.ExpiryDate = DateTime.Now.AddDays(30);
                        }

                        // By default the job is in the draft
                        //job.Expired = (int)PortalEnums.Jobs.JobStatus.Draft;
                        // If job is checked as Expired.
                        if (chkJobExpired.Checked)
                            job.Expired = (int)PortalEnums.Jobs.JobStatus.Expired;
                        else if (isDraft)
                        {
                            job.Visible = false;
                            job.Expired = (int)PortalEnums.Jobs.JobStatus.Draft;
                        }
                        else // Else job is Live by default.
                            job.Visible = true;

                        // Only when in Admin page
                        if (IsAdmin)
                        {
                            job.LastModifiedByAdminUserId = SessionData.AdminUser.AdminUserId;
                            job.LastModifiedByAdvertiserUserId = (int?)null;
                            //job.AdvertiserId = Convert.ToInt32(ddlAdvertiser.SelectedValue);

                            // When job screening process is disabled and in the admin make the job live and also check if not expired
                            if (phStatusAction.Visible == false && !chkJobExpired.Checked)
                                job.Expired = (int)PortalEnums.Jobs.JobStatus.Live;



                            // When in Admin update the Status of the job
                            if (!string.IsNullOrWhiteSpace(ddlStatus.SelectedValue) && Convert.ToInt32(ddlStatus.SelectedValue) > -1 && !chkJobExpired.Checked)
                            {
                                job.Expired = Convert.ToInt32(ddlStatus.SelectedValue);

                                /*// Todo if in Admin job is set to Live.
                                if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                                    job.Billed = true;*/
                            }
                        }
                        else
                        {
                            job.LastModifiedByAdminUserId = (int?)null;
                            job.LastModifiedByAdvertiserUserId = (IsAdmin) ? AdvertiserUserID : SessionData.AdvertiserUser.AdvertiserUserId;
                            //job.AdvertiserId = SessionData.AdvertiserUser.AdvertiserId;
                        }


                        job.JobItemTypeId = Convert.ToInt32(ddlJobItemType.SelectedValue);
                        job.ApplicationEmailAddress = CommonService.EncodeString(txtApplicationEmailAddress.Text);

                        job.ApplicationMethod = Convert.ToInt32(ddlApplicationMethod.SelectedValue);
                        job.ApplicationUrl = CommonService.EncodeString(txtApplicationURL.Text);

                        //Upload Method always 1 (Website) as the job is posted manually
                        job.UploadMethod = 1;

                        job.Tags = CommonService.EncodeString(txtTags.Text);
                        job.JobTemplateId = Convert.ToInt32(ddlJobTemplateID.SelectedValue);
                        //job.SearchFieldExtension = dataSearchFieldExtension.Text;
                        //job.AdvertiserJobTemplateLogoId = 
                        //    (string.IsNullOrEmpty(dataAdvertiserJobTemplateLogoID.Text)) ? (int?)null : Convert.ToInt32(dataAdvertiserJobTemplateLogoID.Text);
                        job.AdvertiserJobTemplateLogoId = Convert.ToInt32(ddlAdvertiserJobTemplateLogo.SelectedValue);

                        if (docInput.HasFile)
                        {
                            Entities.AdvertiserJobTemplateLogo objAdvJobTemplateLogo = new JXTPortal.Entities.AdvertiserJobTemplateLogo();
                            objAdvJobTemplateLogo.AdvertiserId = (IsAdmin) ? AdvertiserID : SessionData.AdvertiserUser.AdvertiserId;

                            objAdvJobTemplateLogo.JobLogoName = tbJobLogoName.Text.Trim();

                            AdvertiserJobTemplateLogoService.Insert(objAdvJobTemplateLogo);

                            if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
                            {
                                if (this.docInput.PostedFile != null)
                                {
                                    System.Drawing.Image objOriginalImage = null;
                                    string contenttype = string.Empty;

                                    Utils.IsValidUploadImage(docInput.PostedFile.FileName, docInput.PostedFile.InputStream, out objOriginalImage, out contenttype);
                                    System.Drawing.Image objResizedImage = JXTPortal.Common.Utils.ResizeImage(objOriginalImage,
                                        PortalConstants.THUMBNAIL_WIDTH, PortalConstants.THUMBNAIL_HEIGHT);

                                    System.IO.MemoryStream objOutputMemorySTream = new System.IO.MemoryStream();
                                    objResizedImage.Save(objOutputMemorySTream, objOriginalImage.RawFormat);

                                    byte[] abytFile = new byte[Convert.ToInt32(objOutputMemorySTream.Length)];
                                    objOutputMemorySTream.Position = 0;
                                    objOutputMemorySTream.Read(abytFile, 0, abytFile.Length);

                                    FtpClient ftpclient = new FtpClient();
                                    string errormessage = string.Empty;
                                    string extension = Utils.GetImageExtension(objOriginalImage);
                                    ftpclient.Host = ConfigurationManager.AppSettings["FTPFileManager"];
                                    ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                    ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                                    ftpclient.UploadFileFromStream(objOutputMemorySTream, string.Format("{0}/{1}/AdvertiserJobTemplateLogo_{2}.{3}", ftpclient.Host, ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"], objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension), out errormessage);

                                    if (string.IsNullOrWhiteSpace(errormessage))
                                    {
                                        objAdvJobTemplateLogo.JobTemplateLogoUrl = string.Format("AdvertiserJobTemplateLogo_{0}.{1}", objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension);
                                        AdvertiserJobTemplateLogoService.Update(objAdvJobTemplateLogo);
                                    }
                                }

                            }

                            job.AdvertiserJobTemplateLogoId = objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId;
                        }


                        //job.RequireLogonForExternalApplications = chkRequireLogonForExternalApplications.Checked;
                        job.ShowLocationDetails = chkShowLocationDetails.Checked;
                        job.PublicTransport = CommonService.EncodeString(txtPublicTransport.Text);
                        job.Address = CommonService.EncodeString(txtAddress.Text);

                        //assign geocodes if any
                        AssignAddressGeocodes(job);

                        job.ContactDetails = CommonService.EncodeString(txtContactDetails.Text);
                        job.JobContactPhone = CommonService.EncodeString(txtJobContactPhone.Text);
                        job.JobContactName = CommonService.EncodeString(txtJobContactName.Text);
                        job.QualificationsRecognised = chkQualificationsRecognised.Checked;
                        job.ResidentOnly = chkResidentOnly.Checked;
                        //job.DocumentLink = txtDocumentLink.Text;
                        job.BulletPoint1 = CommonService.EncodeString(ucJobFieldsMultiLingual.BulletPoint1);
                        job.BulletPoint2 = CommonService.EncodeString(ucJobFieldsMultiLingual.BulletPoint2);

                        job.BulletPoint3 = CommonService.EncodeString(ucJobFieldsMultiLingual.BulletPoint3);
                        //job.HotJob = chkHotJob.Checked;

                        job.JobFriendlyName = Common.Utils.UrlFriendlyName(txtFriendlyUrl.Text);

                        if (ddlAdvertiser.SelectedValue != "0")
                        {
                            job.AdvertiserId = Convert.ToInt32(ddlAdvertiser.SelectedValue);
                            job.CompanyName = ddlAdvertiser.SelectedItem.Text;
                        }

                        //if (IsAdmin && ddlAdvertiserUser.SelectedValue != "0")
                        //{
                        //    job.EnteredByAdvertiserUserId = Convert.ToInt32(ddlAdvertiserUser.SelectedValue);
                        //}

                        if (IsAdmin && AdvertiserUserID > 0)
                        {
                            job.EnteredByAdvertiserUserId = AdvertiserUserID;
                        }


                        /*
                        job.SearchField = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13}", job.JobName, JXTPortal.Common.Utils.StripHTML(job.Description), JXTPortal.Common.Utils.StripHTML(job.FullDescription),
                           (ddlProfession1.SelectedIndex == 0) ? "" : ddlProfession1.SelectedValue, (ddlProfession2.SelectedIndex == 0) ? "" : ddlProfession3.SelectedValue, (ddlProfession1.SelectedIndex == 0) ? "" : ddlProfession3.SelectedValue,
                           (ddlRole1.SelectedIndex == 0) ? "" : ddlRole1.SelectedValue, (ddlRole2.SelectedIndex == 0) ? "" : ddlRole2.SelectedValue, (ddlRole3.SelectedIndex == 0) ? "" : ddlRole3.SelectedValue,
                           (ddlLocation.SelectedIndex == 0) ? "" : ddlLocation.SelectedValue, (ddlArea.SelectedIndex == 0) ? "" : ddlArea.SelectedValue, (ddlWorkType.SelectedIndex == 0) ? "" : ddlWorkType.SelectedValue, (ddlSalary.SelectedIndex == 0) ? "" : ddlSalary.SelectedValue,
                           job.CompanyName);
                        */

                        using (TList<JXTPortal.Entities.JobArea> objJobAreas = JobAreaService.GetByJobId(job.JobId))
                        {
                            JXTPortal.Entities.JobArea objJobArea = null;
                            if (objJobAreas.Count > 0)
                            {
                                objJobArea = objJobAreas[0];
                                objJobArea.JobId = job.JobId;
                                objJobArea.AreaId = Convert.ToInt32(ddlArea.SelectedValue);

                                if (JobAreaService.Update(objJobArea))
                                {
                                    using (TList<JXTPortal.Entities.JobRoles> objJobRoles = JobRolesService.GetByJobId(JobID))
                                    {
                                        JobRolesService.Delete(objJobRoles);

                                        JXTPortal.Entities.JobRoles objJobRole = new JXTPortal.Entities.JobRoles();

                                        if (ddlRole1.SelectedValue != "0")
                                        {
                                            objJobRole.JobId = job.JobId;
                                            objJobRole.RoleId = (ddlRole1.SelectedValue != "0") ? Convert.ToInt32(ddlRole1.SelectedValue) : (int?)null;
                                            JobRolesService.Insert(objJobRole);
                                        }

                                        if (ddlRole2.SelectedValue != "0")
                                        {
                                            objJobRole.JobId = job.JobId;
                                            objJobRole.RoleId = (ddlRole2.SelectedValue != "0") ? Convert.ToInt32(ddlRole2.SelectedValue) : (int?)null;
                                            JobRolesService.Insert(objJobRole);
                                        }

                                        if (ddlRole3.SelectedValue != "0")
                                        {
                                            objJobRole.JobId = job.JobId;
                                            objJobRole.RoleId = (ddlRole3.SelectedValue != "0") ? Convert.ToInt32(ddlRole3.SelectedValue) : (int?)null;
                                            JobRolesService.Insert(objJobRole);
                                        }
                                    }


                                    if (JobsService.Update(job))
                                    {
                                        if (rptLanguagesPanel.Items.Count > 1)
                                        {
                                            TList<JobCustomXml> jobcustomxmllist = JobCustomXmlService.CustomGetBySiteIDJobIDCustomType(SessionData.Site.SiteId, job.JobId, (int)PortalEnums.Jobs.CustomType.Job);
                                            JobCustomXml jobcustomxml = null;

                                            if (jobcustomxmllist.Count > 0)
                                            {
                                                jobcustomxml = jobcustomxmllist[0];
                                            }

                                            string customxml = ConstructJobXML();

                                            if (!string.IsNullOrEmpty(customxml))
                                            {
                                                if (jobcustomxml == null)
                                                {
                                                    jobcustomxml = new JobCustomXml();
                                                    jobcustomxml.SiteId = SessionData.Site.SiteId;
                                                    jobcustomxml.JobId = job.JobId;
                                                    jobcustomxml.CustomType = (int)PortalEnums.Jobs.CustomType.Job;
                                                    jobcustomxml.CustomXml = customxml;

                                                    JobCustomXmlService.Insert(jobcustomxml);
                                                }
                                                else
                                                {
                                                    jobcustomxml.CustomXml = customxml;
                                                    JobCustomXmlService.Update(jobcustomxml);
                                                }
                                            }
                                            else
                                            {
                                                if (jobcustomxml != null)
                                                {
                                                    JobCustomXmlService.Delete(jobcustomxml);
                                                }
                                            }

                                        }



                                        if (!IsAdmin)
                                        {
                                            // If it is draft job then redirect to the drafts page instead of preview page.
                                            if (!job.Visible)
                                            {
                                                Response.Redirect("~/advertiser/jobsdraft.aspx");
                                            }

                                            // If the job is expired then redirect to current jobs.
                                            if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Expired)
                                            {
                                                Response.Redirect("~/advertiser/jobscurrent.aspx");
                                                // Archive the job.
                                                //JobsService.JobArchive(job.JobId);
                                            }

                                            // Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOB_CREATE_SUCCESS, "", "", ""));
                                            Response.Redirect("~/advertiser/jobpreview.aspx?jobid=" + job.JobId.ToString());
                                        }
                                        else
                                        {
                                            /*
                                            // When in Admin which doesn't redirect to the preview page so 
                                            // If job is expired then update the job count.
                                            if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Expired || job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                                            {
                                                // Update the Job count of the website.
                                                JobsService js = new JobsService();
                                                //js.CustomUpdateSiteJobCount(SessionData.Site.SiteId);

                                                // Update the job counts when expired and live
                                                if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Expired)
                                                {
                                                    JobsService.CustomCalculateJobCount(job.SiteId, job.JobId, false);
                                                
                                                    // Archive the job.
                                                    JobsService.JobArchive(job.JobId);

                                                }
                                                else
                                                    JobsService.CustomCalculateJobCount(job.SiteId, job.JobId, true);

                                                // Submit to the Jobx queue.
                                                JobsService.JobX_SubmitQueue(job.JobId);
                                            }*/

                                            Response.Redirect("~/admin/advertiser/jobsbyadvertiser.aspx?advertiserid=" + job.AdvertiserId.Value.ToString());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                objJobArea = new JXTPortal.Entities.JobArea();
                                objJobArea.JobId = job.JobId;
                                objJobArea.AreaId = Convert.ToInt32(ddlArea.SelectedValue);

                                if (JobAreaService.Insert(objJobArea))
                                {

                                    if (JobsService.Update(job))
                                    {
                                        if (!IsAdmin)
                                        {
                                            Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOB_CREATE_SUCCESS, "", "", ""));
                                        }
                                        else
                                        {
                                            Response.Redirect("~/admin/advertiser/jobsbyadvertiser.aspx?advertiserid=" + job.AdvertiserId.Value.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                if (JobID == 0 && CopyJobID > 0)
                {
                    Response.Redirect("~/advertiser/jobcurrent.aspx");
                }
                else
                {
                    Response.Redirect("~/advertiser/default.aspx");
                }
            }
            else
            {
                Response.Redirect("~/admin/jobs.aspx");
            }
        }

        private byte[] getArray(HttpPostedFile f)
        {
            int i = 0;
            byte[] b = new byte[f.ContentLength];

            f.InputStream.Read(b, 0, f.ContentLength);

            return b;
        }

        public void SetFormValues()
        {
            InsertButton.Text = CommonFunction.GetResourceValue("ButtonSave");
            UpdateButton.Text = CommonFunction.GetResourceValue("ButtonUpdate");
            CancelButton.Text = CommonFunction.GetResourceValue("ButtonCancel");
            ReqVal_JobItemPrice.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            RangeVal_JobItemPrice.ErrorMessage = CommonFunction.GetResourceValue("LabelPriceRange");
            ReqVal_Advertiser.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            //ReqVal_JobName.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_FriendlyUrl.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_WorkType.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            //ReqVal_Description.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_Salary.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_JobArea.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_Role1.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            CusValJobProfessionRole.ErrorMessage = CommonFunction.GetResourceValue("LabelErrorDuplicateRole");
            ReqVal_ApplicationEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ctmApplicationMethod.ErrorMessage = CommonFunction.GetResourceValue("LabelWarningBlankURL");
            ReqVal_ContactDetails.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqValJobTemplate.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            //rvjobFieldFullDescription.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rfvAdvJobTemplateLogoName.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rfvAdvJobTemplateLogoImage.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rqStartDate.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            revEmailAddress.ErrorMessage = "Invalid email address";

            txtFriendlyUrl.Attributes["placeholder"] = CommonFunction.GetResourceValue("LabelClickToGenerate"); // click to generate ...
            txtSalaryLowerBand.Attributes["placeholder"] = CommonFunction.GetResourceValue("LabelMinimum");
            txtSalaryUpperBand.Attributes["placeholder"] = CommonFunction.GetResourceValue("LabelMaximum");

            InsertButton.Text = CommonFunction.GetResourceValue("LabelSaveJob");
            UpdateButton.Text = CommonFunction.GetResourceValue("LabelUpdate");
            CancelButton.Text = CommonFunction.GetResourceValue("LabelCancel");
            DraftButton.Text = CommonFunction.GetResourceValue("LabelSaveAsDraft");
            btnNewJobLogo.Text = CommonFunction.GetResourceValue("LabelUploadNewLogo");
            LinkButton1.Text = CommonFunction.GetResourceValue("LabelCancel");
        }

        private string ConstructJobXML()
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();

            if (rptLanguagesPanel.Items.Count > 1)
            {
                sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sb.AppendLine("<JobDetails>");
                for (int i = 1; i < rptLanguagesPanel.Items.Count; i++)
                {
                    JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual ucJobFieldsMultiLingual = rptLanguagesPanel.Items[i].FindControl("ucJobFieldsMultiLingual") as JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual;
                    System.Web.UI.HtmlControls.HtmlInputCheckBox cbEnableLanguage = ucJobFieldsMultiLingual.FindControl("cbEnableLanguage") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                    HiddenField hfLanguageID = ucJobFieldsMultiLingual.FindControl("hfLanguageID") as HiddenField;

                    sb.AppendLine("<JobDetail>");

                    sb.AppendLine("<LanguageID>" + hfLanguageID.Value + "</LanguageID>");
                    if (Request[cbEnableLanguage.ClientID.Replace("_", "$")] != null && Request[cbEnableLanguage.ClientID.Replace("_", "$")] == "on")
                    {
                        sb.AppendLine("<Enabled>True</Enabled>");
                    }
                    else
                    {
                        sb.AppendLine("<Enabled>False</Enabled>");
                    }
                    sb.AppendLine("<JobName><![CDATA[" + ucJobFieldsMultiLingual.JobName + "]]></JobName>");
                    sb.AppendLine("<BulletPoint1><![CDATA[" + ucJobFieldsMultiLingual.BulletPoint1 + "]]></BulletPoint1>");
                    sb.AppendLine("<BulletPoint2><![CDATA[" + ucJobFieldsMultiLingual.BulletPoint2 + "]]></BulletPoint2>");
                    sb.AppendLine("<BulletPoint3><![CDATA[" + ucJobFieldsMultiLingual.BulletPoint3 + "]]></BulletPoint3>");
                    sb.AppendLine("<ShortDescription><![CDATA[" + ucJobFieldsMultiLingual.ShortDescription + "]]></ShortDescription>");
                    sb.AppendLine("<FullDescription><![CDATA[" + ucJobFieldsMultiLingual.FullDescription + "]]></FullDescription>");
                    sb.AppendLine("</JobDetail>");
                }

                sb.AppendLine("</JobDetails>");

                result = sb.ToString();
            }

            return result;
        }

        protected void cvalFileName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (hfFileCheck.Value == "1")
            {
                if ((this.docInput.PostedFile != null) && !string.IsNullOrEmpty(this.docInput.PostedFile.FileName))
                {
                    string strExt = Path.GetExtension(docInput.PostedFile.FileName).Trim();

                    switch (strExt.ToUpper().Trim())
                    {
                        case ".GIF":
                        case ".JPG":
                        case ".JPEG":
                        case ".PNG":
                            args.IsValid = true;
                            break;

                        default:
                            if (string.IsNullOrEmpty(strExt))
                            {
                                this.cvalFileName.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageNoExtension");
                                args.IsValid = false;
                                hfFileError.Value = cvalFileName.ClientID;
                            }
                            else
                            {
                                this.cvalFileName.ErrorMessage = String.Format("{0} {1} {2}", CommonFunction.GetResourceValue("ErrorImageExtension"),
                                                string.Format("<strong>{0}</strong>", strExt), CommonFunction.GetResourceValue("ErrorNotAccepted"));
                                //+ String.Format(@"<strong>{0}</strong>", strExt) +                    
                                args.IsValid = false;
                                hfFileError.Value = cvalFileName.ClientID;
                            }
                            break;
                    }
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cvalFile_ServerValidate(System.Object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (hfFileCheck.Value == "1")
            {
                if ((this.docInput.PostedFile != null) && !string.IsNullOrEmpty(this.docInput.PostedFile.FileName))
                {
                    if (docInput.PostedFile.ContentLength == 0)
                    {
                        this.cvalFile.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageInvalidSize");
                        args.IsValid = false;
                        hfFileError.Value = cvalFileName.ClientID;

                    }
                    else if ((docInput.PostedFile.ContentLength / (Math.Pow(1024, 2))) > 1)
                    {
                        this.cvalFile.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageExceed");
                        args.IsValid = false;
                        hfFileError.Value = cvalFileName.ClientID;

                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
                else
                {
                    args.IsValid = false;
                    hfFileError.Value = cvalFileName.ClientID;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ddlJobItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set Visibility for Premium job type
            // phJobStartDate.Visible = (ddlJobItemType.SelectedValue == ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());
            plClassifications.Visible = (ddlJobItemType.SelectedValue != ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());
            phInfo.Visible = (ddlJobItemType.SelectedValue == ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());
            if (SessionData.Site.IsJobBoard)
            {
                PortalEnums.Advertiser.AccountType accounttype = PortalEnums.Advertiser.AccountType.Account;
                Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID);
                accounttype = (IsAdmin) ? (PortalEnums.Advertiser.AccountType)advertiser.AdvertiserAccountTypeId : SessionData.AdvertiserUser.AccountType;

                phNoJobCredit.Visible = (JobCreditCheck() == 0 && accounttype == PortalEnums.Advertiser.AccountType.Credit_Card);

                if (phNoJobCredit.Visible)
                {
                    InsertButton.Visible = false;
                    UpdateButton.Visible = false;
                }
                else
                {
                    InsertButton.Visible = (JobID == 0);
                    UpdateButton.Visible = (JobID > 0);
                }
            }
        }

        protected void cvStartDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(tbStartDate.Text))
            {
                DateTime dt;

                if (DateTime.TryParseExact(tbStartDate.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    if (!string.IsNullOrWhiteSpace(ddlJobItemType.SelectedValue))
                    {
                        using (DataSet ds = AdvertiserJobPricingService.CustomGetByAdvertiserIDJobItemsTypeID(AdvertiserID, Convert.ToInt32(ddlJobItemType.SelectedValue)))
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow advertiserjobpricingrow = ds.Tables[0].Rows[0];
                                if (advertiserjobpricingrow["StartDate"] != DBNull.Value)
                                {
                                    if (dt < Convert.ToDateTime(advertiserjobpricingrow["StartDate"]) || dt > Convert.ToDateTime(advertiserjobpricingrow["ExpiryDate"]))
                                    {
                                        cvStartDate.ErrorMessage = "Date out of range.";

                                        args.IsValid = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                        {
                            cvStartDate.ErrorMessage = "Date out of range.";

                            args.IsValid = false;
                        }
                    }
                }
                else
                {
                    cvStartDate.ErrorMessage = "Invalid Date.";

                    args.IsValid = false;
                }
            }
        }

        protected void DraftButton_Click(object sender, EventArgs e)
        {
            if (InsertButton.Visible)
            {
                InsertButton_Click(sender, e);
            }
            else
            {
                UpdateButton_Click(sender, e);
            }
        }

    }
}
