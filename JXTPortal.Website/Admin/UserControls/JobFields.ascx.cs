
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
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal;
using AjaxControlToolkit;
using JXTPortal.Website;
using System.Collections.Generic;
using System.Text;
#endregion

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class JobFields : System.Web.UI.UserControl
    {
        #region Declaration

        private int _jobID;
        private int _advertiserid = 0;
        private AdvertiserJobTemplateLogoService _advertiserJobTemplateLogo;
        private SiteWorkTypeService _siteWorkTypeService;
        private SiteSalaryService _siteSalaryService;
        private AdvertisersService _advertisersservice;
        private JobItemsTypeService _jobitemstypeservice;
        private JobTemplatesService _jobtemplatesservice;
        private JobsService _jobsservice;

        private SiteCountriesService _siteCountriesService;
        private SiteLocationService _siteLocationService;
        private SiteAreaService _siteAreaService;
        private SiteProfessionService _siteProfessionService;
        private SiteRolesService _siteRolesService;
        private JobAreaService _jobAreaService;
        private JobRolesService _jobRolesService;
        private AreaService _areaService;
        private RolesService _rolesService;

        #endregion

        #region Properties

        public String strJobHTML = String.Empty;

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

        private int JobAreaID { get; set; }

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

        private SiteSalaryService SiteSalaryService
        {
            get
            {
                if (_siteSalaryService == null)
                {
                    _siteSalaryService = new SiteSalaryService();
                }
                return _siteSalaryService;
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

        #endregion

        #region "User Control Properties"

        public bool IsAdmin { get; set; }

        #endregion

        #region Method

        /*
        //Sample of Language Translation Code
        //Make sure translations are set up in "App_GlobalResources"
         
        public void SetFormValues()
        {
            ltEnquiryName.Text = CommonFunction.GetResourceValue("LabelName");
            ltEnquiryEmail.Text = CommonFunction.GetResourceValue("LabelEmailAddress");
            ltEnquiryPhone.Text = CommonFunction.GetResourceValue("LabelPhone");
            ltEnquiryContent.Text = CommonFunction.GetResourceValue("LabelContent");
            btnSubmit.Text = CommonFunction.GetResourceValue("ButtonSubmit");
        }
         */

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
            ddlAdvertiserJobTemplateLogo.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        }

        private void LoadWorkType()
        {
            List<JXTPortal.Entities.SiteWorkType> siteWorkTypes = SiteWorkTypeService.GetTranslatedWorkTypes();
            dataWorkType.DataSource = siteWorkTypes;
            dataWorkType.DataBind();
            dataWorkType.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));

        }

        private void LoadSalary()
        {
            List<JXTPortal.Entities.SiteSalary> siteSalaries = SiteSalaryService.GetTranslatedSalary();
            dataSalary.DataSource = siteSalaries;
            dataSalary.DataBind();
            dataSalary.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        }

        //private void LoadAdvertiser()
        //{
        //    using (TList<JXTPortal.Entities.Advertisers> advertisers = AdvertisersService.GetBySiteId(SessionData.Site.SiteId))
        //    {
        //        dataAdvertiserId.DataSource = advertisers;
        //        dataAdvertiserId.DataBind();
        //        dataAdvertiserId.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        //    }
        //}

        private void LoadJobItemsType()
        {
            using (TList<JXTPortal.Entities.JobItemsType> jobitemstypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId))
            {
                dataJobItemsTypeId.DataSource = jobitemstypes;
                dataJobItemsTypeId.DataBind();
                dataJobItemsTypeId.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
            }
        }

        private void LoadJobTemplate()
        {
            using (TList<JXTPortal.Entities.JobTemplates> jobtemplates = JobTemplatesService.GetBySiteId(SessionData.Site.SiteId))
            {
                dataJobTemplateID.DataSource = jobtemplates;
                dataJobTemplateID.DataBind();
            }

            dataJobTemplateID.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        }

        private void LoadSiteCountries()
        {
            ddlSiteCountry.DataSource = SiteCountriesService.GetTranslatedCountries();
            ddlSiteCountry.DataTextField = "SiteCountryName";
            ddlSiteCountry.DataValueField = "SiteCountryId";
            ddlSiteCountry.DataBind();
            ddlSiteCountry.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        }

        private void LoadLocation()
        {
            ddlLocation.DataSource = SiteLocationService.GetBySiteId(SessionData.Site.SiteId);
            ddlLocation.DataTextField = "SiteLocationName";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        }

        private void LoadArea()
        {
            ddlArea.DataSource = SiteAreaService.GetTranslatedAreas(Convert.ToInt32(ddlLocation.SelectedValue));
            ddlArea.DataTextField = "SiteAreaName";
            ddlArea.DataValueField = "AreaId";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        }

        private void LoadProfession()
        {
            //we just need to get the data once
            List<JXTPortal.Entities.SiteProfession> siteProfessionList = SiteProfessionService.GetTranslatedProfessions();
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
            ddlProfessionControl.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        }

        private void LoadRoles(int ProfessionId, ref DropDownList ddlRoleControl)
        {
            ddlRoleControl.DataSource = SiteRolesService.GetTranslatedByProfessionID(ProfessionId);
            ddlRoleControl.DataTextField = "SiteRoleName";
            ddlRoleControl.DataValueField = "RoleId";
            ddlRoleControl.DataBind();
            ddlRoleControl.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
        }

        private void LoadJob()
        {
            if (JobID > 0)
            {
                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                {
                    if (job != null && job.SiteId == SessionData.Site.SiteId)
                    {
                        dataApplicationEmailAddress.Text = job.ApplicationEmailAddress;
                        dataWorkType.SelectedValue = job.WorkTypeId.ToString();
                        dataSalary.SelectedValue = job.SalaryId.ToString();
                        dataJobName.Text = job.JobName.ToString();
                        dataDescription.Text = job.Description.ToString();
                        dataFullDescription.Text = job.FullDescription.ToString();
                        dataRefNo.Text = job.RefNo.ToString();
                        dataVisible.Checked = job.Visible;
                        dataDatePosted.Text = job.DatePosted.ToString();
                        dataExpiryDate.Text = job.ExpiryDate.ToString();
                        chkJobExpired.Checked = (job.Expired == null) ? false : (bool)job.Expired;
                        dataJobItemPrice.Text = job.JobItemPrice.ToString();
                        dataBilled.Checked = job.Billed;
                        dataLastModified.Text = job.LastModified.ToString();
                        dataShowSalaryDetails.Checked = job.ShowSalaryDetails;
                        dataSalaryText.Text = job.SalaryText.ToString();
                        //dataAdvertiserId.SelectedValue = job.AdvertiserId.ToString();
                        dataLastModifiedByAdvertiserUserId.Text = job.LastModifiedByAdvertiserUserId.ToString();
                        dataLastModifiedByAdminUserId.Text = job.LastModifiedByAdminUserId.ToString();
                        dataJobItemsTypeId.SelectedValue = job.JobItemTypeId.ToString();
                        dataApplicationMethod.Text = job.ApplicationMethod.ToString();
                        dataTags.Text = job.Tags.ToString();
                        dataJobTemplateID.SelectedValue = job.JobTemplateId.ToString();
                        //dataSearchFieldExtension.Text = job.SearchFieldExtension.ToString();
                        //dataAdvertiserJobTemplateLogoID.Text = job.AdvertiserJobTemplateLogoId.ToString();
                        ddlAdvertiserJobTemplateLogo.SelectedValue = Convert.ToString(job.AdvertiserJobTemplateLogoId);
                        dataRequireLogonForExternalApplications.Checked = job.RequireLogonForExternalApplications;
                        dataShowLocationDetails.Checked = (job.ShowLocationDetails == null) ? false : (bool)job.ShowLocationDetails;
                        dataPublicTransport.Text = job.PublicTransport.ToString();
                        dataAddress.Text = job.Address.ToString();
                        dataContactDetails.Text = job.ContactDetails.ToString();
                        dataJobContactPhone.Text = job.JobContactPhone.ToString();
                        dataJobContactName.Text = job.JobContactName.ToString();
                        dataQualificationsRecognised.Checked = job.QualificationsRecognised;
                        dataResidentOnly.Checked = job.ResidentOnly;
                        dataDocumentLink.Text = job.DocumentLink.ToString();
                        dataBulletPoint1.Text = job.BulletPoint1.ToString();
                        dataBulletPoint2.Text = job.BulletPoint2.ToString();
                        dataBulletPoint3.Text = job.BulletPoint3.ToString();
                        dataHotJob.Checked = job.HotJob;

                        foreach (JXTPortal.Entities.JobArea jobArea in JobAreaService.GetByJobId(job.JobId))
                        {
                            using (JXTPortal.Entities.Area area = AreaService.GetByAreaId(jobArea.AreaId))
                            {
                                CommonFunction.SetDropDownByValue(ddlLocation, area.LocationId.ToString());
                                LoadArea();
                                CommonFunction.SetDropDownByValue(ddlArea, jobArea.AreaId.ToString());
                            }
                        }

                        using (TList<JXTPortal.Entities.JobRoles> jobRoles = JobRolesService.GetByJobId(job.JobId))
                        {
                            if (jobRoles[0] != null)
                            {
                                using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[0].RoleId.Value))
                                {
                                    CommonFunction.SetDropDownByValue(ddlProfession1, role.ProfessionId.ToString());
                                    LoadRoles(role.ProfessionId, ref ddlRole1);
                                    CommonFunction.SetDropDownByValue(ddlRole1, jobRoles[0].RoleId.Value.ToString());
                                }

                            }

                            if (jobRoles.Count > 1 && jobRoles[1] != null)
                            {
                                using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[1].RoleId.Value))
                                {
                                    CommonFunction.SetDropDownByValue(ddlProfession2, role.ProfessionId.ToString());
                                    LoadRoles(role.ProfessionId, ref ddlRole2);
                                    CommonFunction.SetDropDownByValue(ddlRole2, jobRoles[1].RoleId.Value.ToString());
                                }
                            }

                            if (jobRoles.Count > 2 && jobRoles[2] != null)
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

                        Response.Redirect("default.aspx");
                    }
                }
            }
        }


        //private void LoadUI()
        //{
        //    if (IsAdmin)
        //    {
        //        pnlAdvertiser.Visible = true;
        //    }
        //    else
        //    {
        //        pnlAdvertiser.Visible = false;
        //        RequiredFieldValidator1.Enabled = false;
        //    }
        //}

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadWorkType();
                LoadSalary();
                //LoadAdvertiser();
                LoadJobItemsType();
                LoadJobTemplate();

                LoadAdvertiserJobTemplateLogo();

                LoadSiteCountries();
                LoadLocation();
                LoadProfession();
                LoadJob();
                //LoadUI();
                InsertButton.Visible = (JobID == 0);
                UpdateButton.Visible = (JobID > 0);

                if (JobID > 0)
                {
                    chkJobExpired.Enabled = true;
                    ddlProfession1.Enabled = false;
                    ddlProfession2.Enabled = false;
                    ddlProfession3.Enabled = false;
                    ddlRole1.Enabled = false;
                    ddlRole2.Enabled = false;
                    ddlRole3.Enabled = false;
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
            }

            SetFormValues();
        }

        protected void ddlSiteCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLocation();
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

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (JXTPortal.Entities.Jobs job = new JXTPortal.Entities.Jobs())
                {
                    job.JobId = JobID;
                    job.SiteId = SessionData.Site.SiteId;
                    job.DatePosted = DateTime.Now;
                    job.WebServiceProcessed = false;
                    job.WorkTypeId = Convert.ToInt32(dataWorkType.SelectedValue);
                    job.SalaryId = Convert.ToInt32(dataSalary.SelectedValue);
                    job.JobName = dataJobName.Text;
                    job.Description = dataDescription.Text;
                    job.FullDescription = dataFullDescription.Text;
                    job.RefNo = dataRefNo.Text;
                    job.Visible = dataVisible.Checked;
                    job.DatePosted = DateTime.Now;
                    job.Expired = chkJobExpired.Checked;
                    job.JobItemPrice = Convert.ToDecimal(dataJobItemPrice.Text);
                    job.Billed = dataBilled.Checked;
                    job.ShowSalaryDetails = dataShowSalaryDetails.Checked;
                    job.SalaryText = dataSalaryText.Text;
                    job.JobItemTypeId = Convert.ToInt32(dataJobItemsTypeId.SelectedValue);
                    job.ApplicationEmailAddress = dataApplicationEmailAddress.Text;
                    job.ApplicationMethod = (string.IsNullOrEmpty(dataApplicationMethod.Text)) ? (int?)null : Convert.ToInt32(dataApplicationMethod.Text);
                    job.Tags = dataTags.Text;
                    job.JobTemplateId = Convert.ToInt32(dataJobTemplateID.SelectedValue);
                    //job.SearchFieldExtension = dataSearchFieldExtension.Text;
                    //job.AdvertiserJobTemplateLogoId = 
                    //    (string.IsNullOrEmpty(dataAdvertiserJobTemplateLogoID.Text)) ? (int?)null : Convert.ToInt32(dataAdvertiserJobTemplateLogoID.Text);

                    job.AdvertiserJobTemplateLogoId = Convert.ToInt32(ddlAdvertiserJobTemplateLogo.SelectedValue);

                    job.RequireLogonForExternalApplications = dataRequireLogonForExternalApplications.Checked;
                    job.ShowLocationDetails = dataShowLocationDetails.Checked;
                    job.PublicTransport = dataPublicTransport.Text;
                    job.Address = dataAddress.Text;
                    job.ContactDetails = dataContactDetails.Text;
                    job.JobContactPhone = dataJobContactPhone.Text;
                    job.JobContactName = dataJobContactName.Text;
                    job.QualificationsRecognised = dataQualificationsRecognised.Checked;
                    job.ResidentOnly = dataResidentOnly.Checked;
                    job.DocumentLink = dataDocumentLink.Text;
                    job.BulletPoint1 = dataBulletPoint1.Text;
                    job.BulletPoint2 = dataBulletPoint2.Text;
                    job.BulletPoint3 = dataBulletPoint3.Text;
                    job.HotJob = dataHotJob.Checked;
                    job.ExpiryDate = DateTime.Now.AddDays(14);

                    job.JobFriendlyName = Common.Utils.UrlFriendlyName(dataJobName.Text);

                    if (IsAdmin)
                    {
                        job.AdvertiserId = AdvertiserID; //Convert.ToInt32(dataAdvertiserId.SelectedValue);
                        job.LastModifiedByAdminUserId = SessionData.AdminUser.AdminUserId;
                    }
                    else
                    {
                        job.AdvertiserId = SessionData.AdvertiserUser.AdvertiserId;
                        job.LastModifiedByAdvertiserUserId = SessionData.AdvertiserUser.AdvertiserUserId;
                    }

                    if (JobsService.Insert(job))
                    {
                        using (JXTPortal.Entities.JobArea objJobArea = new JXTPortal.Entities.JobArea())
                        {
                            objJobArea.JobId = job.JobId;
                            objJobArea.AreaId = Convert.ToInt32(ddlArea.SelectedValue);

                            if (JobAreaService.Insert(objJobArea))
                            {
                                using (JXTPortal.Entities.JobRoles objJobRoles = new JXTPortal.Entities.JobRoles())
                                {
                                    if (ddlRole1.SelectedValue != "")
                                    {
                                        objJobRoles.JobId = job.JobId;
                                        objJobRoles.RoleId = Convert.ToInt32(ddlRole1.SelectedValue);
                                        JobRolesService.Insert(objJobRoles);
                                    }

                                    if (ddlRole2.SelectedValue != "")
                                    {
                                        objJobRoles.JobId = job.JobId;
                                        objJobRoles.RoleId = Convert.ToInt32(ddlRole2.SelectedValue);
                                        JobRolesService.Insert(objJobRoles);
                                    }

                                    if (ddlRole3.SelectedValue != "")
                                    {
                                        objJobRoles.JobId = job.JobId;
                                        objJobRoles.RoleId = Convert.ToInt32(ddlRole3.SelectedValue);
                                        JobRolesService.Insert(objJobRoles);
                                    }

                                    Response.Redirect("default.aspx");
                                }

                            }
                        }
                    }
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                {
                    job.JobId = JobID;
                    job.SiteId = SessionData.Site.SiteId;

                    job.WorkTypeId = Convert.ToInt32(dataWorkType.SelectedValue);
                    job.SalaryId = Convert.ToInt32(dataSalary.SelectedValue);
                    job.JobName = dataJobName.Text;
                    job.Description = dataDescription.Text;
                    job.FullDescription = dataFullDescription.Text;
                    job.RefNo = dataRefNo.Text;
                    job.Visible = dataVisible.Checked;
                    job.DatePosted = DateTime.Now;
                    job.Expired = chkJobExpired.Checked;
                    job.JobItemPrice = Convert.ToDecimal(dataJobItemPrice.Text);
                    job.Billed = dataBilled.Checked;
                    job.ShowSalaryDetails = dataShowSalaryDetails.Checked;
                    job.SalaryText = dataSalaryText.Text;

                    //job.AdvertiserId = Convert.ToInt32(dataAdvertiserId.SelectedValue);

                    if (IsAdmin)
                    {
                        job.AdvertiserId = AdvertiserID;
                        job.LastModifiedByAdminUserId = SessionData.AdminUser.AdminUserId;
                    }
                    else
                    {
                        job.AdvertiserId = SessionData.AdvertiserUser.AdvertiserId;
                        job.LastModifiedByAdvertiserUserId = SessionData.AdvertiserUser.AdvertiserUserId;
                    }

                    job.JobItemTypeId = Convert.ToInt32(dataJobItemsTypeId.SelectedValue);
                    job.ApplicationEmailAddress = dataApplicationEmailAddress.Text;
                    job.ApplicationMethod = (string.IsNullOrEmpty(dataApplicationMethod.Text)) ? (int?)null : Convert.ToInt32(dataApplicationMethod.Text);
                    job.Tags = dataTags.Text;
                    job.JobTemplateId = Convert.ToInt32(dataJobTemplateID.SelectedValue);
                    //job.SearchFieldExtension = dataSearchFieldExtension.Text;
                    //job.AdvertiserJobTemplateLogoId = 
                    //    (string.IsNullOrEmpty(dataAdvertiserJobTemplateLogoID.Text)) ? (int?)null : Convert.ToInt32(dataAdvertiserJobTemplateLogoID.Text);
                    job.AdvertiserJobTemplateLogoId = Convert.ToInt32(ddlAdvertiserJobTemplateLogo.SelectedValue);
                    job.RequireLogonForExternalApplications = dataRequireLogonForExternalApplications.Checked;
                    job.ShowLocationDetails = dataShowLocationDetails.Checked;
                    job.PublicTransport = dataPublicTransport.Text;
                    job.Address = dataAddress.Text;
                    job.ContactDetails = dataContactDetails.Text;
                    job.JobContactPhone = dataJobContactPhone.Text;
                    job.JobContactName = dataJobContactName.Text;
                    job.QualificationsRecognised = dataQualificationsRecognised.Checked;
                    job.ResidentOnly = dataResidentOnly.Checked;
                    job.DocumentLink = dataDocumentLink.Text;
                    job.BulletPoint1 = dataBulletPoint1.Text;
                    job.BulletPoint2 = dataBulletPoint2.Text;
                    job.BulletPoint3 = dataBulletPoint3.Text;
                    job.HotJob = dataHotJob.Checked;

                    job.JobFriendlyName = Common.Utils.UrlFriendlyName(dataJobName.Text);

                    using (JXTPortal.Entities.JobArea objJobArea = JobAreaService.GetByJobId(job.JobId)[0])
                    {
                        objJobArea.JobId = job.JobId;
                        objJobArea.AreaId = Convert.ToInt32(ddlArea.SelectedValue);

                        if (JobAreaService.Update(objJobArea))
                        {
                            using (TList<JXTPortal.Entities.JobRoles> objJobRoles = JobRolesService.GetByJobId(job.JobId))
                            {
                                if (objJobRoles[0] != null && ddlRole1.SelectedValue != "")
                                {
                                    objJobRoles[0].JobId = job.JobId;
                                    objJobRoles[0].RoleId = Convert.ToInt32(ddlRole1.SelectedValue);
                                    JobRolesService.Update(objJobRoles[0]);
                                }


                                if (ddlRole2.SelectedValue != "")
                                {
                                    if (objJobRoles.Count > 1 && objJobRoles[1] != null)
                                    {
                                        objJobRoles[1].JobId = job.JobId;
                                        objJobRoles[1].RoleId = Convert.ToInt32(ddlRole2.SelectedValue);
                                        JobRolesService.Update(objJobRoles[1]);
                                    }
                                    else
                                    {
                                        using (JXTPortal.Entities.JobRoles jobRole = new JXTPortal.Entities.JobRoles())
                                        {
                                            jobRole.JobId = job.JobId;
                                            jobRole.RoleId = Convert.ToInt32(ddlRole2.SelectedValue);
                                            JobRolesService.Insert(jobRole);
                                        }
                                    }
                                }
                                else
                                {
                                    if (objJobRoles.Count > 1 && objJobRoles[1] != null)
                                        JobRolesService.Delete(objJobRoles[1]);
                                }


                                if (ddlRole3.SelectedValue != "")
                                {
                                    if (objJobRoles.Count > 2 && objJobRoles[2] != null)
                                    {
                                        objJobRoles[2].JobId = job.JobId;
                                        objJobRoles[2].RoleId = Convert.ToInt32(ddlRole3.SelectedValue);
                                        JobRolesService.Update(objJobRoles[2]);
                                    }
                                    else
                                    {
                                        using (JXTPortal.Entities.JobRoles jobRole = new JXTPortal.Entities.JobRoles())
                                        {
                                            jobRole.JobId = job.JobId;
                                            jobRole.RoleId = Convert.ToInt32(ddlRole3.SelectedValue);
                                            JobRolesService.Insert(jobRole);
                                        }
                                    }
                                }
                                else
                                {
                                    if (objJobRoles.Count > 2 && objJobRoles[2] != null)
                                        JobRolesService.Delete(objJobRoles[2]);
                                }

                                if (JobsService.Update(job))
                                {
                                    Response.Redirect("default.aspx");
                                }
                            }

                        }
                    }
                }

            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        public void SetFormValues()
        {
            InsertButton.Text = CommonFunction.GetResourceValue("ButtonInsert");
            UpdateButton.Text = CommonFunction.GetResourceValue("ButtonUpdate");
            CancelButton.Text = CommonFunction.GetResourceValue("ButtonCancel");
        }
    }
}