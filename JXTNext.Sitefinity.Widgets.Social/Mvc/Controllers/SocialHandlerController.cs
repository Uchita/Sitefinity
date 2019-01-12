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

        public SocialHandlerController(SocialHandlerLogics socialHandlerLogics, IJobApplicationService jobApplicationService, IBusinessLogicsConnector blConnector)
        {
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
                        Log.Write("indeedJsonStringData " + indeedJsonStringData, ConfigurationPolicy.ErrorLog);
                        Log.Write("Request.InputStream length " + Request.InputStream.Length, ConfigurationPolicy.ErrorLog);
                        Log.Write("Request.InputStream position " + Request.InputStream.Position, ConfigurationPolicy.ErrorLog);
                        Log.Write("Request.InputStream can read " + Request.InputStream.CanRead, ConfigurationPolicy.ErrorLog);
                        Log.Write("Request.InputStream CanSeek " + Request.InputStream.CanSeek, ConfigurationPolicy.ErrorLog);
                        Log.Write("Request.InputStream Canwrite " + Request.InputStream.CanWrite, ConfigurationPolicy.ErrorLog);
                    }

                    using (StreamReader reader2 = new StreamReader(Request.InputStream, Encoding.UTF8))
                    {
                        indeedJsonStringData2 = reader.ReadToEnd();
                        Log.Write("indeedJsonStringData2 " + indeedJsonStringData2, ConfigurationPolicy.ErrorLog);
                    }

                    var result = _socialHandlerLogics.ProcessSocialHandlerData(code, state, indeedJsonStringData);

                    if(result != null)
                    {
                        Log.Write("_socialHandlerLogics 'result' not null", ConfigurationPolicy.ErrorLog);
                        Log.Write(result.Success + " " + result.JobId, ConfigurationPolicy.ErrorLog);
                        if(result.Errors != null)
                            Log.Write(result.Errors.FirstOrDefault(), ConfigurationPolicy.ErrorLog);
                    }
                    if (result != null && result.Success == true && result.JobId.HasValue)
                    {
                        // Logging this info for Indeed test
                        Log.Write(result.JobId, ConfigurationPolicy.ErrorLog);

                        JobApplicationStatus status = JobApplicationStatus.Available;
                        if (_jobApplicationService != null)
                        {
                            ApplicantInfo applicantInfo = new ApplicantInfo()
                            {
                                FirstName = result.FirstName,
                                LastName = result.LastName,
                                Email = result.Email,
                                Password = "Password123",
                                PhoneNumber = result.PhoneNumber
                            };
                            var overrideEmail = _jobApplicationService.GetOverrideEmail(ref status, applicantInfo, true);
                            
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

                                // Fetch job details 
                                string ApplicationEmail = string.Empty;
                                string ContactDetails = string.Empty;
                                string CompanyName = string.Empty;
                                if (result.JobId.HasValue)
                                {
                                    IGetJobListingRequest jobListingRequest = new JXTNext_GetJobListingRequest { JobID = result.JobId.Value };
                                    IGetJobListingResponse jobListingResponse = _blConnector.GuestGetJob(jobListingRequest);
                                    ViewBag.JobTitle = jobListingResponse.Job.Title;
                                    ApplicationEmail = jobListingResponse.Job.CustomData["ApplicationMethod.ApplicationEmail"];
                                    ContactDetails = jobListingResponse.Job.CustomData["ContactDetails"];
                                    CompanyName = jobListingResponse.Job.CustomData["CompanyName"];
                                    var JobLocation = jobListingResponse.Job.CustomData["CountryLocationArea[0].Filters[0].Value"];
                                }

                                // End code for fetch job details
                                Log.Write("overrideEmail uploadItem object created", ConfigurationPolicy.ErrorLog);
                                List<JobApplicationAttachmentUploadItem> attachments = new List<JobApplicationAttachmentUploadItem>();
                                attachments.Add(uploadItem);
                                Log.Write("overrideEmail uploadItem attachment added", ConfigurationPolicy.ErrorLog);
                                string resumeAttachmentPath = JobApplicationAttachmentUploadItem.GetAttachmentPath(attachments, JobApplicationAttachmentType.Resume);
                                Log.Write("After resume GetAttachmentPath", ConfigurationPolicy.ErrorLog);
                                string coverletterAttachmentPath = JobApplicationAttachmentUploadItem.GetAttachmentPath(attachments, JobApplicationAttachmentType.Coverletter);
                                Log.Write("After cover letter GetAttachmentPath", ConfigurationPolicy.ErrorLog);

                                string htmlEmailContent = this.GetEmailHtmlContent();
                                string htmlAdvertiserEmailContent = this.GetAdevertiserEmailHtmlContent();
                                Log.Write("After GetHtmlEmailContent", ConfigurationPolicy.ErrorLog);
                                // Email notification settings


                                Stream resumeFileStream = null;
                                Stream coverLetterFileStream = null;

                                string resumeFileName = null;
                                string coverLetterFileName = null;
                                foreach (var item in attachments)
                                {
                                    if (item.AttachmentType == JobApplicationAttachmentType.Resume)
                                    {
                                        resumeFileStream = item.FileStream;
                                        resumeFileName = item.FileName;
                                    }

                                    if (item.AttachmentType == JobApplicationAttachmentType.Coverletter)
                                    {
                                        coverLetterFileName = item.FileName;
                                        coverLetterFileStream = item.FileStream;
                                    }

                                }


                                EmailNotificationSettings advertiserEmailNotificationSettings = new EmailNotificationSettings(new EmailTarget(this.EmailTemplateSenderName, this.EmailTemplateSenderEmailAddress),
                                                                                                                    new EmailTarget(ContactDetails, ApplicationEmail),
                                                                                                                    this.AdvertiserEmailTemplateEmailSubject,
                                                                                                                    htmlAdvertiserEmailContent, resumeFileStream, resumeFileName, coverLetterFileStream, coverLetterFileName);




                                EmailNotificationSettings emailNotificationSettings = new EmailNotificationSettings(new EmailTarget(this.EmailTemplateSenderName, this.EmailTemplateSenderEmailAddress),
                                                                                                    new EmailTarget(SitefinityHelper.GetUserFirstNameById(SitefinityHelper.GetUserByEmail(overrideEmail).Id), overrideEmail),
                                                                                                    this.EmailTemplateEmailSubject,
                                                                                                    htmlEmailContent,null,null,null,null);

                                Log.Write("emailNotificationSettings after: ", ConfigurationPolicy.ErrorLog);
                                // CC and BCC emails
                                if (!this.EmailTemplateCC.IsNullOrEmpty())
                                {
                                    foreach (var ccEmail in this.EmailTemplateCC.Split(';'))
                                    {
                                        emailNotificationSettings.AddCC(String.Empty, ccEmail);
                                        advertiserEmailNotificationSettings.AddCC(String.Empty, ccEmail);
                                    }
                                }

                                if (!this.EmailTemplateBCC.IsNullOrEmpty())
                                {
                                    foreach (var bccEmail in this.EmailTemplateBCC.Split(';'))
                                    {
                                        emailNotificationSettings.AddBCC(String.Empty, bccEmail);
                                        advertiserEmailNotificationSettings.AddBCC(String.Empty, bccEmail);
                                    }
                                }

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
                                        AdvertiserName = ContactDetails,
                                        CompanyName = CompanyName
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
                                    Log.Write("Member application is : " + response.Errors.FirstOrDefault(), ConfigurationPolicy.ErrorLog);
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


            if (!this.JobSearchResultsPageId.IsNullOrEmpty())
                ViewBag.JobSearchResultsUrl = SitefinityHelper.GetPageUrl(this.JobSearchResultsPageId);

            var fullTemplateName = this.templateNamePrefix + this.TemplateName;

            return View(fullTemplateName, viewModel);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        private string GetEmailHtmlContent()
        {
            //return _jobApplicationService.GetHtmlEmailContent("6AB317D4-D674-4636-8481-014BC6F861E1", this.EmailTemplateProviderName, this._itemType);
            return _jobApplicationService.GetHtmlEmailContent(this.EmailTemplateId, this.EmailTemplateProviderName, this._itemType);
        }

        private string GetAdevertiserEmailHtmlContent()
        {
            
            //return _jobApplicationService.GetHtmlEmailContent("3DCBDCE5-F190-4FBA-BE51-074F2E034A04", this.AdvertiserEmailTemplateProviderName, this._itemType);
            return _jobApplicationService.GetHtmlEmailContent(this.AdvertiserEmailTemplateId, this.AdvertiserEmailTemplateProviderName, this._itemType);
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

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private string templateName = "Simple";
        private string templateNamePrefix = "SocialHandler.";
        private string _itemType = "Telerik.Sitefinity.DynamicTypes.Model.StandardEmailTemplate.EmailTemplate";
        private string _emailTemplateProviderName = "OpenAccessProvider";
    }
}