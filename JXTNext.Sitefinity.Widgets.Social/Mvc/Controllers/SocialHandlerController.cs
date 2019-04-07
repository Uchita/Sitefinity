using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using System.ComponentModel;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Logics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Services.Intefaces;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Model;
using JXTNext.Sitefinity.Widgets.Social.Mvc.StringResources;
using JXTNext.Sitefinity.Common.Helpers;
using Telerik.Sitefinity.Security.Claims;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication;
using System.IO;
using Telerik.Sitefinity.Abstractions;
using System.Text;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using System.Web.Routing;
using System.Dynamic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Ninject;
using JXTNext.Sitefinity.Common.Models.JobApplication;
using JXTNext.Sitefinity.Common.Extensions;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Controllers
{
    [EnhanceViewEngines]
    [Localization(typeof(SocialHandlerResources))]
    [ControllerToolboxItem(Name = "SocialHandler_MVC", Title = "Social handler", SectionName = "JXTNext.Social", CssClass = SocialHandlerController.WidgetIconCssClass)]
    public class SocialHandlerController : Controller
    {
        SocialHandlerLogics _socialHandlerLogics;
        public string CssClass { get; set; }
        public string TemplateName
        {
            get
            {
                return this.templateName;
            }

            set
            {
                this.templateName = value;
            }
        }

        IJobApplicationService _jobApplicationService;
        IBusinessLogicsConnector _blConnector;
        IProcessSocialMediaData _processSocialMediaSeekData;
        IProcessSocialMediaData _processSocialMediaIndeedData;

        public SocialHandlerController([Named("Indeed")]IProcessSocialMediaData processSocialMediaIndeedData, [Named("Seek")]IProcessSocialMediaData processSocialMediaSeekData, SocialHandlerLogics socialHandlerLogics, IJobApplicationService jobApplicationService, IBusinessLogicsConnector blConnector)
        {
            _processSocialMediaSeekData = processSocialMediaSeekData;
            _processSocialMediaIndeedData = processSocialMediaIndeedData;
            _socialHandlerLogics = socialHandlerLogics;
            _jobApplicationService = jobApplicationService;
            _blConnector = blConnector;
        }

        public ActionResult Index(string code, string state, int? JobId)
        {
            SocialMediaJobViewModel viewModel = new SocialMediaJobViewModel();

            try
            {
                // Logging this info for Indeed test
                Log.Write("Social Handler Index Action Start : ", ConfigurationPolicy.ErrorLog);
                string UrlReferral = null;
                
                // This is the CSS classes enter from More Options
                ViewBag.CssClass = this.CssClass;

                if (string.IsNullOrWhiteSpace(this.TemplateName))
                {
                    this.TemplateName = "SocialHandler.Simple";
                }

                viewModel.Status = JobApplicationStatus.Available;

                if (_socialHandlerLogics != null)
                {
                    Log.Write("_socialHandlerLogics not null", ConfigurationPolicy.ErrorLog);
                    if(Request.InputStream != null)
                        Request.InputStream.Position = 0;

                    StreamReader reader = new StreamReader(Request.InputStream);
                    string indeedJsonStringData = String.Empty;
                    string indeedJsonStringData2 = null;
                    if (reader != null)
                    {
                        indeedJsonStringData = reader.ReadToEnd();
                    }

                    using (StreamReader reader2 = new StreamReader(Request.InputStream, Encoding.UTF8))
                    {
                        indeedJsonStringData2 = reader.ReadToEnd();
                    }
                    SocialMediaProcessedResponse result = null;
                    if (!code.IsNullOrEmpty())
                    {
                        result = _processSocialMediaSeekData.ProcessData(code, state, indeedJsonStringData);
                        if (TempData["source"] != null && !string.IsNullOrWhiteSpace(TempData["source"].ToString()))
                            UrlReferral = TempData["source"].ToString();
                    }
                    else if(code.IsNullOrEmpty() && !indeedJsonStringData.IsNullOrEmpty())
                    {
                        result = _processSocialMediaIndeedData.ProcessData(code, state, indeedJsonStringData);
                        UrlReferral = result.JobSource;
                    }
                    else
                    {
                        Log.Write("Social Handler code,sate and indeed data is null", ConfigurationPolicy.ErrorLog);
                    }
                     
                    //var result = _socialHandlerLogics.ProcessSocialHandlerData(code, state, indeedJsonStringData);

                    if (result != null && result.Success == true && result.JobId.HasValue)
                    {
                        var jobDetails = GetJobDetails(result.JobId.Value);
                        if (result.ResumeLinkNotExists)
                        {
                            if (!jobDetails.JobSEOUrl.IsNullOrEmpty())
                            {
                                return Redirect(string.Format("job-application/{0}/{1}?error=resume", jobDetails.JobSEOUrl, int.Parse(state)));
                            }
                            else
                            {
                                return Redirect(string.Format("job-application/{0}?error=resume", int.Parse(state)));
                            }
                        }

                        JobApplicationStatus status = JobApplicationStatus.Available;
                        if (_jobApplicationService != null)
                        {
                            ApplicantInfo applicantInfo = new ApplicantInfo()
                            {
                                FirstName = result.FirstName,
                                LastName = result.LastName,
                                Email = result.Email,
                                Password = "Password123",
                                PhoneNumber = result.PhoneNumber,
                                IsNewUser = false
                            };

                            string overrideEmail = string.Empty;
                            if (SitefinityHelper.IsUserLoggedIn())
                            {
                                var currUser = SitefinityHelper.GetUserById(ClaimsManager.GetCurrentIdentity().UserId);
                                if (currUser != null)
                                {
                                    Log.Write("User is already logged In " + currUser.Email, ConfigurationPolicy.ErrorLog);
                                    overrideEmail = currUser.Email;
                                }
                                else
                                {
                                    Log.Write("CurUser is null", ConfigurationPolicy.ErrorLog);
                                    overrideEmail = _jobApplicationService.GetOverrideEmail(ref status, ref applicantInfo, true);
                                }
                                Log.Write("SitefinityHelper.IsUserLoggedIn() =" + SitefinityHelper.IsUserLoggedIn(), ConfigurationPolicy.ErrorLog);
                                
                            }
                            else if (!string.IsNullOrEmpty(result.LoginUserEmail))
                            {
                                overrideEmail = result.LoginUserEmail;
                            }
                            else
                            {

                                Log.Write("SitefinityHelper.IsUserLoggedIn() is false ", ConfigurationPolicy.ErrorLog);
                                overrideEmail = _jobApplicationService.GetOverrideEmail(ref status, ref applicantInfo, true);
                            }

                            Log.Write("overrideEmail is : " + overrideEmail, ConfigurationPolicy.ErrorLog);
                            if (overrideEmail != null && status == JobApplicationStatus.Available)
                            {
                                Log.Write("overrideEmail is in: ", ConfigurationPolicy.ErrorLog);
                                // Gather Attachments
                                Guid identifier = Guid.NewGuid();
                                JobApplicationAttachmentUploadItem uploadItem = new JobApplicationAttachmentUploadItem()
                                {
                                    Id = identifier.ToString(),
                                    AttachmentType = JobApplicationAttachmentType.Resume,
                                    FileName = result.FileName,
                                    FileStream = result.FileStream,
                                    PathToAttachment = identifier.ToString() + "_" + result.FileName,
                                    Status = "Ready"
                                };

                                

                                // End code for fetch job details
                                Log.Write("overrideEmail uploadItem object created", ConfigurationPolicy.ErrorLog);
                                List<JobApplicationAttachmentUploadItem> attachments = new List<JobApplicationAttachmentUploadItem>();
                                attachments.Add(uploadItem);
                                Log.Write("overrideEmail uploadItem attachment added", ConfigurationPolicy.ErrorLog);
                                string resumeAttachmentPath = JobApplicationAttachmentUploadItem.GetAttachmentPath(attachments, JobApplicationAttachmentType.Resume);
                                Log.Write("After resume GetAttachmentPath", ConfigurationPolicy.ErrorLog);
                                string coverletterAttachmentPath = JobApplicationAttachmentUploadItem.GetAttachmentPath(attachments, JobApplicationAttachmentType.Coverletter);
                                Log.Write("After cover letter GetAttachmentPath", ConfigurationPolicy.ErrorLog);

                                string htmlEmailContent = this.GetEmailHtmlContent(this.EmailTemplateId);
                                string htmlEmailSubject = this.GetEmailSubject(this.EmailTemplateId);
                                string htmlAdvertiserEmailContent = this.GetEmailHtmlContent(this.AdvertiserEmailTemplateId);
                                string htmlAdvertiserEmailSubject = this.GetEmailSubject(this.AdvertiserEmailTemplateId);
                                
                                Log.Write("After GetHtmlEmailContent", ConfigurationPolicy.ErrorLog);
                                // Email notification settings


                                List<dynamic> emailAttachments = new List<dynamic>();
                                foreach (var item in attachments)
                                {
                                    dynamic emailAttachment = new ExpandoObject();
                                    emailAttachment.FileStream = item.FileStream;
                                    emailAttachment.FileName = item.FileName;
                                    emailAttachments.Add(emailAttachment);
                                }

                                
                                EmailNotificationSettings advertiserEmailNotificationSettings = (this.AdvertiserEmailTemplateId != null) ? 
                                    _createAdvertiserEmailTemplate(
                                        new JobApplicationEmailTemplateModel() {
                                            FromFirstName = result.FirstName,
                                            FromLastName = result.LastName,
                                            FromEmail = overrideEmail,
                                            ToFirstName = jobDetails.ContactDetails.GetFirstName(),
                                            ToLastName = jobDetails.ContactDetails.GetLastName(),
                                            ToEmail = jobDetails.ApplicationEmail,
                                            Subject = SitefinityHelper.GetCurrentSiteEmailTemplateTitle(this.AdvertiserEmailTemplateId),
                                            HtmlContent = SitefinityHelper.GetCurrentSiteEmailTemplateHtmlContent(this.AdvertiserEmailTemplateId),
                                            Attachments = emailAttachments
                                        }) : null;


                               
                                EmailNotificationSettings emailNotificationSettings = (this.EmailTemplateId != null) ?
                                    _createApplicantEmailTemplate(
                                        new JobApplicationEmailTemplateModel()
                                        {
                                            FromFirstName = this.EmailTemplateSenderName,
                                            FromLastName = null,
                                            FromEmail = this.EmailTemplateSenderEmailAddress,
                                            ToFirstName = SitefinityHelper.GetUserFirstNameById(SitefinityHelper.GetUserByEmail(overrideEmail).Id),
                                            ToLastName = null,
                                            ToEmail = overrideEmail,
                                            Subject = SitefinityHelper.GetCurrentSiteEmailTemplateTitle(this.EmailTemplateId),
                                            HtmlContent = SitefinityHelper.GetCurrentSiteEmailTemplateHtmlContent(this.EmailTemplateId),
                                            Attachments = null
                                        }) : null;


                                EmailNotificationSettings registrationNotificationsSettings = (applicantInfo.IsNewUser && this.RegistrationEmailTemplateId != null) ?
                                _createRegistrationEmailTemplate(
                                    new JobApplicationEmailTemplateModel()
                                    {
                                        FromFirstName = this.EmailTemplateSenderName,
                                        FromLastName = null,
                                        FromEmail = this.EmailTemplateSenderEmailAddress,
                                        ToFirstName = applicantInfo.FirstName,
                                        ToLastName = null,
                                        ToEmail = applicantInfo.Email,
                                        Subject = SitefinityHelper.GetCurrentSiteEmailTemplateTitle(this.RegistrationEmailTemplateId),
                                        HtmlContent = SitefinityHelper.GetCurrentSiteEmailTemplateHtmlContent(this.RegistrationEmailTemplateId),
                                        Attachments = null
                                    }) : null;

                                Log.Write("emailNotificationSettings after: ", ConfigurationPolicy.ErrorLog);
                               
                                Log.Write("BL response before: ", ConfigurationPolicy.ErrorLog);

                                //Create Application 
                                IMemberApplicationResponse response = _blConnector.MemberCreateJobApplication(
                                    new JXTNext_MemberApplicationRequest {
                                        ApplyResourceID = result.JobId.Value,
                                        MemberID = 2,
                                        ResumePath = resumeAttachmentPath,
                                        CoverletterPath = coverletterAttachmentPath,
                                        EmailNotification = emailNotificationSettings,
                                        AdvertiserEmailNotification = advertiserEmailNotificationSettings,
                                        AdvertiserName = jobDetails.ContactDetails,
                                        CompanyName = jobDetails.CompanyName,
                                        UrlReferral = UrlReferral,
                                        RegistrationEmailNotification = registrationNotificationsSettings
                                    },
                                    overrideEmail);

                                Log.Write("BL response after: ", ConfigurationPolicy.ErrorLog);
                                
                                if (response.Success && response.ApplicationID.HasValue)
                                {
                                    Log.Write("BL response in: ", ConfigurationPolicy.ErrorLog);
                                    var hasFailedUpload = _jobApplicationService.UploadFiles(attachments);
                                    Log.Write("file upload is : " + hasFailedUpload, ConfigurationPolicy.ErrorLog);
                                    if (hasFailedUpload)
                                    {
                                        viewModel.Status = JobApplicationStatus.Technical_Issue; // Unable to attach files
                                        viewModel.Message = "Unable to attach files to application";
                                    }
                                    else
                                    {
                                        viewModel.Status = JobApplicationStatus.Applied_Successful;
                                        viewModel.Message = "Your application was successfully processed.";
                                        if (!this.JobApplicationSuccessPageId.IsNullOrEmpty())
                                        {
                                            Log.Write("JobApplicationSuccessPageId is not null: ", ConfigurationPolicy.ErrorLog);
                                            var successPageUrl = SitefinityHelper.GetPageUrl(this.JobApplicationSuccessPageId);
                                            Log.Write("successPageUrl : " + successPageUrl, ConfigurationPolicy.ErrorLog);
                                            return Redirect(successPageUrl);
                                        }
                                    }
                                }
                                else
                                {
                                    if (response.Errors.FirstOrDefault().ToLower().Contains("already exists"))
                                    {
                                        if (!jobDetails.JobSEOUrl.IsNullOrEmpty())
                                        {
                                            return Redirect(string.Format("job-application/{0}/{1}?error=exists", jobDetails.JobSEOUrl, result.JobId.Value));
                                        }
                                        else
                                        {
                                            return Redirect(string.Format("job-application/{0}?error=exists", result.JobId.Value));
                                        }
                                    }
                                    viewModel.Status = JobApplicationStatus.Technical_Issue;
                                    viewModel.Message = response.Errors.FirstOrDefault();
                                }
                            }
                            else
                            {
                                Log.Write("overrideEmail is null: ", ConfigurationPolicy.ErrorLog);

                                if (status == JobApplicationStatus.NotAbleToLoginCreatedUser)
                                    viewModel.Message = "Unable to process your job application. Please try logging in and re-apply for the job.";
                                else if (status == JobApplicationStatus.NotAbleToCreateUser)
                                    viewModel.Message = "Unable to create user. Please register from";

                                viewModel.Status = status;
                            }
                        }
                        else
                        {
                            Log.Write("_jobApplicationService is null", ConfigurationPolicy.ErrorLog);
                        }
                    }

                    
                }
            }

            catch(Exception ex)
            {
                Log.Write("Social Handler : Exception Caught" + ex.Message, ConfigurationPolicy.ErrorLog);
            }

            // To catch access denied error for seek
            int jobId;
            if (this.Request.QueryString["error"].ToLower().Contains("denied") && state != null && int.TryParse(state, out jobId))
            {
                var jobDetails = GetJobDetails(jobId);
                if (!jobDetails.JobSEOUrl.IsNullOrEmpty())
                {
                    return Redirect(string.Format("job-application/{0}/{1}?error=denied", jobDetails.JobSEOUrl, jobId));
                }
                else
                {
                    return Redirect(string.Format("job-application/{0}?error=resume", jobId));
                }
            }
            

            if (!this.JobSearchResultsPageId.IsNullOrEmpty())
                ViewBag.JobSearchResultsUrl = SitefinityHelper.GetPageUrl(this.JobSearchResultsPageId);

            var fullTemplateName = this.templateNamePrefix + this.TemplateName;

            return View(fullTemplateName, viewModel);
        }


        private JobDetailsModel GetJobDetails(int jobid)
        {
            IGetJobListingRequest jobListingRequest = new JXTNext_GetJobListingRequest { JobID = jobid };
            IGetJobListingResponse jobListingResponse = _blConnector.GuestGetJob(jobListingRequest);
            ViewBag.JobTitle = jobListingResponse.Job.Title;
            JobDetailsModel jobDetails = new JobDetailsModel();
            jobDetails.ApplicationEmail = jobListingResponse.Job.CustomData["ApplicationMethod.ApplicationEmail"];
            jobDetails.ContactDetails = jobListingResponse.Job.CustomData["ContactDetails"];
            jobDetails.CompanyName = jobListingResponse.Job.CustomData["CompanyName"];
            jobDetails.JobLocation = jobListingResponse.Job.CustomData["CountryLocationArea[0].Filters[0].Value"];
            jobDetails.JobSEOUrl = jobListingResponse.Job?.ClassificationURL;
            return jobDetails;
        }
        
        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }


        private string GetEmailHtmlContent(string emailTemplateId)
        {
            //return _jobApplicationService.GetHtmlEmailContent("6AB317D4-D674-4636-8481-014BC6F861E1", this.EmailTemplateProviderName, this._itemType);
            return _jobApplicationService.GetHtmlEmailContent(emailTemplateId, this.EmailTemplateProviderName, this._itemType);
        }

        private string GetEmailSubject(string emailTemplateId)
        {
            //return _jobApplicationService.GetHtmlEmailContent("6AB317D4-D674-4636-8481-014BC6F861E1", this.EmailTemplateProviderName, this._itemType);
            return _jobApplicationService.GetHtmlEmailSubject(emailTemplateId, this.EmailTemplateProviderName, this._itemType);
        }

        private EmailNotificationSettings _createAdvertiserEmailTemplate(JobApplicationEmailTemplateModel emailTemplate)
        {
            EmailNotificationSettings advertiserEmailTemplate = _addEmailNotificationSettings(emailTemplate);

            // CC and BCC emails
            _addCCToEmailTemplate(ref advertiserEmailTemplate, this.AdvertiserEmailTemplateCC);

            _addCCToEmailTemplate(ref advertiserEmailTemplate, this.AdvertiserEmailTemplateBCC);

            return advertiserEmailTemplate;
        }

        private EmailNotificationSettings _createApplicantEmailTemplate(JobApplicationEmailTemplateModel emailTemplate)
        {
            EmailNotificationSettings applicantEmailTemplate = _addEmailNotificationSettings(emailTemplate);
            // CC and BCC emails
            _addCCToEmailTemplate(ref applicantEmailTemplate, this.EmailTemplateCC);

            _addCCToEmailTemplate(ref applicantEmailTemplate, this.EmailTemplateBCC);

            return applicantEmailTemplate;
        }

        private EmailNotificationSettings _createRegistrationEmailTemplate(JobApplicationEmailTemplateModel emailTemplate)
        {
            EmailNotificationSettings registerEmailTemplate = _addEmailNotificationSettings(emailTemplate);
            // CC and BCC emails
            _addCCToEmailTemplate(ref registerEmailTemplate, this.RegistrationEmailTemplateCC);

            _addCCToEmailTemplate(ref registerEmailTemplate, this.RegistrationEmailTemplateBCC);

            return registerEmailTemplate;
        }

        private EmailNotificationSettings _addEmailNotificationSettings(JobApplicationEmailTemplateModel emailTemplate)
        {
            EmailNotificationSettings emailNotificationSettings  = new EmailNotificationSettings(new EmailTarget(emailTemplate.FromFullName, emailTemplate.FromEmail),
                                                                                                                    new EmailTarget(emailTemplate.ToFullName, emailTemplate.ToEmail),
                                                                                                                    emailTemplate.Subject,
                                                                                                                    emailTemplate.HtmlContent, emailTemplate.Attachments);


            return emailNotificationSettings;
        }

        private void _addCCToEmailTemplate(ref EmailNotificationSettings emailNotificationSettings , string emailTemplateCC)
        {
            if (!emailTemplateCC.IsNullOrEmpty())
            {
                foreach (var ccEmail in emailTemplateCC.Split(';'))
                {
                    emailNotificationSettings?.AddCC(String.Empty, ccEmail);
                }
            }
        }

        private void _addBCCToEmailTemplate(ref EmailNotificationSettings emailNotificationSettings, string emailTemplateBCC)
        {
            if (!emailTemplateBCC.IsNullOrEmpty())
            {
                foreach (var bccEmail in emailTemplateBCC.Split(';'))
                {
                    emailNotificationSettings?.AddBCC(String.Empty, bccEmail);
                }
            }
        }


        public string ItemType
        {
            get { return this._itemType; }
            set { this._itemType = value; }
        }
        public string EmailTemplateProviderName
        {
            get { return _emailTemplateProviderName; }
            set { this._emailTemplateProviderName = value; }
        }
        public string EmailTemplateId { get; set; }
        public string EmailTemplateName { get; set; }
        public string EmailTemplateCC { get; set; }
        public string EmailTemplateBCC { get; set; }
        public string EmailTemplateSenderName { get; set; }
        public string EmailTemplateSenderEmailAddress { get; set; }
        public string EmailTemplateEmailSubject { get; set; }
        public string RegisterPageId { get; set; }
        public string JobApplicationSuccessPageId { get; set; }
        public string JobSearchResultsPageId { get; set; }

        //Job Owner Email template
        public string AdvertiserEmailTemplateProviderName
        {
            get { return _emailTemplateProviderName; }
            set { this._emailTemplateProviderName = value; }
        }
        public string AdvertiserEmailTemplateId { get; set; }
        public string AdvertiserEmailTemplateName { get; set; }
        public string AdvertiserEmailTemplateCC { get; set; }
        public string AdvertiserEmailTemplateBCC { get; set; }
        public string AdvertiserEmailTemplateSenderName { get; set; }
        public string AdvertiserEmailTemplateSenderEmailAddress { get; set; }
        public string AdvertiserEmailTemplateEmailSubject { get; set; }


        public string RegistrationEmailTemplateId { get; set; }
        public string RegistrationEmailTemplateName { get; set; }
        public string RegistrationEmailTemplateCC { get; set; }
        public string RegistrationEmailTemplateBCC { get; set; }
        public string RegistrationEmailTemplateSenderName { get; set; }
        public string RegistrationEmailTemplateSenderEmailAddress { get; set; }
        public string RegistrationEmailTemplateEmailSubject { get; set; }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private string templateName = "Simple";
        private string templateNamePrefix = "SocialHandler.";
        private string _itemType = "Telerik.Sitefinity.DynamicTypes.Model.StandardEmailTemplate.EmailTemplate";
        private string _emailTemplateProviderName = "OpenAccessProvider";

    }
}