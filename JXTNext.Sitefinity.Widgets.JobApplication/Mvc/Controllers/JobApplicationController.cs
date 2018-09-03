using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.JobApplication.Mvc.Models.JobApplication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Workflow;
using JXTNext.FileHandler.FileHandlerServices.Google_Drive;
using JXTNext.FileHandler.FileHandlerServices.Dropbox;
using JXTNext.FileHandler.Models.Base;
using JXTNext.FileHandler.Models.Google_Drive;
using JXTNext.FileHandler.Models.Dropbox;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using System.Web.Security;
using Telerik.Sitefinity.Security.Model;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [Localization(typeof(JobApplicationResources))]
    [ControllerToolboxItem(Name = "JobApplication_MVC", Title = "Job Application", SectionName = "JXTNext.JobApplication", CssClass = JobApplicationController.WidgetIconCssClass)]
    public class JobApplicationController : Controller
    {
        IBusinessLogicsConnector _blConnector;

        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
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

        public JobApplicationController(IBusinessLogicsConnector blConnector)
        {
            _blConnector = blConnector;
        }

        // GET: JobApplication
        [HttpGet]
        public ActionResult Index(int? jobid)
        {
            JobApplicationViewModel jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.Available, "Upload your files to Apply");
            ViewBag.CssClass = this.CssClass;
            var uploadFileInfo = this.SerializedCloudSettingsParams == null ? null : JsonConvert.DeserializeObject<JobApplicationUploadFilesModel>(this.SerializedCloudSettingsParams);

            jobApplicationViewModel.UploadFiles = uploadFileInfo;
            jobApplicationViewModel.JobId = jobid.HasValue ? jobid.Value : 0;
            bool isUserLoggedIn = false;
            string userEmail = String.Empty;
            User user = null;
            var currentIdentity = ClaimsManager.GetCurrentIdentity();

            if (currentIdentity.IsAuthenticated)
            {
                var currUser = SitefinityHelper.GetUserById(currentIdentity.UserId);
                if (user != null)
                {
                    userEmail = currUser.Email;
                    user = currUser;
                }

                isUserLoggedIn = true;
            }

            ViewBag.IsUserLoggedIn = isUserLoggedIn;
            ViewBag.UserEmail = userEmail;
            ViewBag.User = user;
            ViewBag.RegisterPageUrl = SitefinityHelper.GetPageUrl(this.RegisterPageId);

            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            return View(fullTemplateName, jobApplicationViewModel);
        }

        [HttpPost]
        public ActionResult ApplyJob(ApplyJobModel applyJobModel)
        {
            int applicationResultID = applyJobModel.JobId;
            int memberID = 2;
            JobApplicationViewModel jobApplicationViewModel;
            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            // Create user if the user does not exists
            MembershipCreateStatus membershipCreateStatus;
            if (SitefinityHelper.GetUserByEmail(applyJobModel.Email) == null)
            {
                membershipCreateStatus = SitefinityHelper.CreateUser(applyJobModel.Email, applyJobModel.Password, applyJobModel.FirstName, applyJobModel.LastName, applyJobModel.Email, applyJobModel.PhoneNumber,
                    null, null, true);

                if (membershipCreateStatus != MembershipCreateStatus.Success)
                {
                    jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.NotAbleToCreateUser, "Unable to create user. Please register from");
                    return View("JobApplication.Simple", jobApplicationViewModel);
                }
            }
            
            JobApplicationAttachmentSource sourceResume = GetAttachmentSourceType(applyJobModel.ResumeSelectedType);
            JobApplicationAttachmentSource sourceCoverLetter = GetAttachmentSourceType(applyJobModel.CoverLetterSelectedType);
           
            List<JobApplicationAttachmentUploadItem> attachments = GatherAttachments(sourceResume, sourceCoverLetter, applyJobModel.UploadFilesResume, applyJobModel.UploadFilesCoverLetter);

            string resumeAttachmentPath = GetAttachmentPath(attachments, JobApplicationAttachmentType.Resume);
            string coverletterAttachmentPath = GetAttachmentPath(attachments, JobApplicationAttachmentType.Coverletter);

            // Email Notification Settings
            // In the desinger form those are going to be provided by separator as semicolon(;)
            
            List<string> ccEmails = (!this.EmailTemplateCC.IsNullOrEmpty()) ? this.EmailTemplateCC.Split(';').ToList() : null;
            List<string> bccEmails = (!this.EmailTemplateBCC.IsNullOrEmpty()) ? this.EmailTemplateBCC.Split(';').ToList() : null;
            string htmlEmailContent = this.GetHtmlEmailContent();
            EmailNotificationSettings emailNotificationSettings = new EmailNotificationSettings(this.EmailTemplateFromName, ccEmails, bccEmails, htmlEmailContent);

             //instantiate the Sitefinity user manager
            //if you have multiple providers you have to pass the provider name as parameter in GetManager("ProviderName") in your case it will be the asp.net membership provider user
            UserManager userManager = UserManager.GetManager();
            if (userManager.ValidateUser("DFDFD@JXT.COM", "Password123"))
            {
                //if you need to get the user instance use the out parameter
                Telerik.Sitefinity.Security.Model.User userToAuthenticate = null;
                SecurityManager.AuthenticateUser(userManager.Provider.Name, "DFDFD@JXT.COM", "Password123", false, out userToAuthenticate);
            }

            //Create Application 
            IMemberApplicationResponse response = _blConnector.MemberCreateJobApplication(
                new JXTNext_MemberApplicationRequest { ApplyResourceID = applicationResultID, MemberID = memberID, ResumePath = resumeAttachmentPath, CoverletterPath = coverletterAttachmentPath, EmailNotification = emailNotificationSettings }
                , "DFDFD@JXT.COM");

            if (response.Success && response.ApplicationID.HasValue)
            {
                //FileUploads
                attachments.ForEach(c => ProcessFileUpload(ref c));

                bool hasFailedUpload = attachments.Where(c => c.Status != "Completed").Any();

                if (hasFailedUpload)
                    //prompt error message for contact
                    jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.Technical_Issue, "Unable to attach files to application");
                else
                    jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.Applied_Successful, "Your application was successfully processed");

            }
            else
            {
                jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.NotAvailable, response.Errors.First() );
            }

            return View("JobApplication.Simple", jobApplicationViewModel);
        }

        [HttpPost]
        public JsonResult CheckUser(string email)
        {
            var user = SitefinityHelper.GetUserByEmail(email);
            bool isUserExists = false;

            if (user != null)
                isUserExists = true;

            return new JsonResult { Data = isUserExists };
        }

        [HttpPost]
        public JsonResult ValidateUser(string email, string password)
        {
            bool isUserVerified = SitefinityHelper.IsUserVerified(email, password);
            return new JsonResult { Data = isUserVerified };
        }

        private JobApplicationAttachmentSource GetAttachmentSourceType(string sourceType)
        {
            if (sourceType.ToUpper() == "DROPBOX")
                return JobApplicationAttachmentSource.Dropbox;
            if (sourceType.ToUpper() == "GOOGLEDRIVE")
                return JobApplicationAttachmentSource.GoogleDrive;

            return JobApplicationAttachmentSource.Local;
            
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        private string GetHtmlEmailContent()
        {
            string htmlEmailContent = String.Empty;
            if (!String.IsNullOrEmpty(this.EmailTemplateId))
            {
                var dynamicModuleManager = DynamicModuleManager.GetManager(this._emailTemplateProviderName);
                var emailTemplateType = TypeResolutionService.ResolveType(this._itemType);
                var emailTemplateItem = dynamicModuleManager.GetDataItem(emailTemplateType, new Guid(this.EmailTemplateId.ToUpper()));
                htmlEmailContent = emailTemplateItem.GetValue("htmlEmailContent").ToString();
            }

            return htmlEmailContent;
        }

        private void FetchFromAmazonS3(string providerName, string libraryName, string itemTitle)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(providerName);
            var docLibs = librariesManager.GetDocumentLibraries();

            foreach (var lib in docLibs)
            {
                if (lib.Title.ToLower() == libraryName)
                {
                    var document = lib.Items().Where(item => item.Title == itemTitle).FirstOrDefault();
                    var stream = librariesManager.Download(document);
                }
            }
        }

        private void UploadToAmazonS3(Guid masterDocumentId, string providerName, string libName, string fileName, Stream fileStream)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(providerName);
            Document document = librariesManager.GetDocuments().Where(i => i.Id == masterDocumentId).FirstOrDefault();

            if (document == null)
            {
                //The document is created as master. The masterDocumentId is assigned to the master version.
                document = librariesManager.CreateDocument(masterDocumentId);

                //Set the parent document library.
                DocumentLibrary documentLibrary = librariesManager.GetDocumentLibraries().Where(d => d.Title == libName).SingleOrDefault();
                document.Parent = documentLibrary;

                //Set the properties of the document.
                string documentTitle = masterDocumentId.ToString() + "_" + fileName;
                document.Title = documentTitle;
                document.DateCreated = DateTime.UtcNow;
                document.PublicationDate = DateTime.UtcNow;
                document.LastModified = DateTime.UtcNow;
                document.UrlName = Regex.Replace(documentTitle.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                document.MediaFileUrlName = Regex.Replace(documentTitle.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                document.ApprovalWorkflowState = "Published";

                //Upload the document file.
                string fileExtension = fileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                librariesManager.Upload(document, fileStream, fileExtension ?? string.Empty);

                //Recompiles and validates the url of the document.
                librariesManager.RecompileAndValidateUrls(document);

                //Save the changes.
                librariesManager.SaveChanges();

                //Publish the DocumentLibraries item. The live version acquires new ID.
                var bag = new Dictionary<string, string>();
                bag.Add("ContentType", typeof(Document).FullName);
                WorkflowManager.MessageWorkflow(masterDocumentId, typeof(Document), null, "Publish", false, bag);
            }
        }

        private JobApplicationViewModel GetJobApplicationConfigurations(JobApplicationStatus status, string message)
        {
            return new JobApplicationViewModel
            {
                ApplicationTitle = message,
                ApplicationStatus = status,
                ApplicationAttachments = new List<JobApplicationAttachmentItem>
                {
                    //Resume
                    new JobApplicationAttachmentItem
                    {
                        AttachementType = JobApplicationAttachmentType.Resume,
                        Title = "Resume",
                        Enabled = true,
                        AttachementFileUploadKey = JobApplicationAttachmentSettings.APPLICATION_RESUME_UPLOAD_KEY,
                        Integrations = null
                    },
                    //Coverletter
                    new JobApplicationAttachmentItem
                    {
                        AttachementType = JobApplicationAttachmentType.Coverletter,
                        Title = "Cover Letter",
                        Enabled = true,
                        AttachementFileUploadKey = JobApplicationAttachmentSettings.APPLICATION_COVERLETTER_UPLOAD_KEY,
                        Integrations = null
                    }
                },
                ApplicationMessage = null
            };
        }

        private List<JobApplicationAttachmentUploadItem> GatherAttachments(JobApplicationAttachmentSource sourceResume, JobApplicationAttachmentSource sourceCoverLetter, string uploadFilesResumeJSON, string uploadFilesCoverLetterJSON)
        {
            List<JobApplicationAttachmentUploadItem> attachmentItems = new List<JobApplicationAttachmentUploadItem>();

            if (sourceResume == JobApplicationAttachmentSource.Local)
            {
                bool hasResumeUpload = Request.Files.AllKeys.Contains(JobApplicationAttachmentSettings.APPLICATION_RESUME_UPLOAD_KEY);
                if (hasResumeUpload)
                {
                    JobApplicationAttachmentUploadItem item = GatherAttachmentDetails(JobApplicationAttachmentType.Resume, Request.Files[JobApplicationAttachmentSettings.APPLICATION_RESUME_UPLOAD_KEY]);
                    if (item != null)
                        attachmentItems.Add(item);
                }
            }

            if (sourceCoverLetter == JobApplicationAttachmentSource.Local)
            {
                bool hasCoverletterUpload = Request.Files.AllKeys.Contains(JobApplicationAttachmentSettings.APPLICATION_COVERLETTER_UPLOAD_KEY);
                if (hasCoverletterUpload)
                {
                    JobApplicationAttachmentUploadItem item = GatherAttachmentDetails(JobApplicationAttachmentType.Coverletter, Request.Files[JobApplicationAttachmentSettings.APPLICATION_COVERLETTER_UPLOAD_KEY]);
                    if (item != null)
                        attachmentItems.Add(item);
                }
            }

            // Processing the Resume
            if(sourceResume == JobApplicationAttachmentSource.GoogleDrive)
            {
                var googleDriveModel = JsonConvert.DeserializeObject<UploadFilesFormPostModel>(uploadFilesResumeJSON);
                JobApplicationAttachmentUploadItem item = GetAttachementFromGoogleDrive(googleDriveModel, JobApplicationAttachmentType.Resume);
                attachmentItems.Add(item);
            }

            if (sourceResume == JobApplicationAttachmentSource.Dropbox)
            {
                var dropboxDriveModel = JsonConvert.DeserializeObject<UploadFilesFormPostModel>(uploadFilesResumeJSON);
                JobApplicationAttachmentUploadItem item = GetAttachementFromDropbox(dropboxDriveModel, JobApplicationAttachmentType.Resume);
                attachmentItems.Add(item);
            }

            // Processing Cover Letter
            if (sourceCoverLetter == JobApplicationAttachmentSource.GoogleDrive)
            {
                var googleDriveModel = JsonConvert.DeserializeObject<UploadFilesFormPostModel>(uploadFilesCoverLetterJSON);
                JobApplicationAttachmentUploadItem item = GetAttachementFromGoogleDrive(googleDriveModel, JobApplicationAttachmentType.Coverletter);
                attachmentItems.Add(item);
            }

            if (sourceCoverLetter == JobApplicationAttachmentSource.Dropbox)
            {
                var dropboxDriveModel = JsonConvert.DeserializeObject<UploadFilesFormPostModel>(uploadFilesCoverLetterJSON);
                JobApplicationAttachmentUploadItem item = GetAttachementFromDropbox(dropboxDriveModel, JobApplicationAttachmentType.Coverletter);
                attachmentItems.Add(item);
            }

            return attachmentItems;
        }

        private JobApplicationAttachmentUploadItem GetAttachementFromGoogleDrive(UploadFilesFormPostModel googleFilesInfo, JobApplicationAttachmentType attachmentType)
        {
            GoogleDriveFileHandlerService googleDriveFileHandleService = new GoogleDriveFileHandlerService();
            SiteSettingsHelper siteSettingsHelper = new SiteSettingsHelper();
            string clientId = siteSettingsHelper.GetCurrentSiteGoogleClientId();
            string clientSecret = siteSettingsHelper.GetCurrentSiteGoogleClientSecret();
            GoogleDriveFileHandlerRequestModel baseFileHandle = new GoogleDriveFileHandlerRequestModel() {
                ClientId = clientId,
                ClientSecret = clientSecret,
                OAuthToken = googleFilesInfo.AuthToken,
                FileId = googleFilesInfo.Field,
                FileName = googleFilesInfo.FileName,
                FileUrl = googleFilesInfo.UrlPath,
                MimeType = googleFilesInfo.MIMEType
            };

            JobApplicationAttachmentUploadItem item = null;
            var googleFileResonse = googleDriveFileHandleService.ProcessFileDownload<GoogleDriveFileHandlerResponseModel, GoogleDriveFileHandlerRequestModel>(baseFileHandle);

            if (googleFileResonse.FileSuccessStatus)
            {
                Guid identifier = Guid.NewGuid();
                item = new JobApplicationAttachmentUploadItem
                {
                    Id = identifier.ToString(),
                    AttachmentType = attachmentType,
                    FileName = googleFilesInfo.FileName,
                    FileStream = googleFileResonse.FileStream,
                    PathToAttachment = identifier.ToString() + "_" + googleFilesInfo.FileName,
                    Status = "Ready"
                };
            }

            return item;
        }

        private JobApplicationAttachmentUploadItem GetAttachementFromDropbox(UploadFilesFormPostModel dropboxFilesInfo, JobApplicationAttachmentType attachmentType)
        {
            DropboxFileHandlerService dropboxFileHandleService = new DropboxFileHandlerService();
            DropboxFileHandlerRequestModel baseFileHandle = new DropboxFileHandlerRequestModel()
            {
                FileName = dropboxFilesInfo.FileName,
                FileUrl = dropboxFilesInfo.UrlPath
            };

            var dropboxFileResonse = dropboxFileHandleService.ProcessFileDownload<DropboxFileHandlerResponseModel, DropboxFileHandlerRequestModel>(baseFileHandle);
            JobApplicationAttachmentUploadItem item = null;
            if (dropboxFileResonse.FileSuccessStatus)
            {
                Guid identifier = Guid.NewGuid();
                item = new JobApplicationAttachmentUploadItem
                {
                    Id = identifier.ToString(),
                    AttachmentType = attachmentType,
                    FileName = dropboxFilesInfo.FileName,
                    FileStream = dropboxFileResonse.FileStream,
                    PathToAttachment = identifier.ToString() + "_" + dropboxFilesInfo.FileName,
                    Status = "Ready"
                };
            }

            return item;
        }

        private string GetAttachmentPath(List<JobApplicationAttachmentUploadItem> attachmentItems, JobApplicationAttachmentType attachmentType)
        {
            JobApplicationAttachmentUploadItem item = attachmentItems.Where(c => c.AttachmentType == attachmentType).FirstOrDefault();
            if (item == null)
                return null;
            return item.PathToAttachment;
        }

        private JobApplicationAttachmentUploadItem GatherAttachmentDetails(JobApplicationAttachmentType attachmentType, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                Guid identifier = Guid.NewGuid();
                return new JobApplicationAttachmentUploadItem
                {
                    Id = identifier.ToString(),
                    AttachmentType = attachmentType,
                    FileName = file.FileName,
                    FileStream = file.InputStream,
                    PathToAttachment = identifier.ToString() + "_" + file.FileName,
                    Status = "Ready"
                };
            }
            return null;
        }

        private void ProcessFileUpload(ref JobApplicationAttachmentUploadItem uploadItem)
        {
            var libName = FileUploadLibraryGet(uploadItem.AttachmentType);

            try
            {
                UploadToAmazonS3(Guid.Parse(uploadItem.Id), "private-amazon-s3-provider", libName, uploadItem.PathToAttachment, uploadItem.FileStream);
                uploadItem.Status = "Completed";
            }
            catch (Exception ex)
            {
                uploadItem.Status = "Failed";
                uploadItem.Message = ex.Message;
            }
        }

        private string FileUploadLibraryGet(JobApplicationAttachmentType attachmentType)
        {
            switch (attachmentType)
            {
                case JobApplicationAttachmentType.Resume:
                    return JobApplicationAttachmentSettings.APPLICATION_RESUME_UPLOAD_LIBRARY;
                case JobApplicationAttachmentType.Coverletter:
                    return JobApplicationAttachmentSettings.APPLICATION_COVERLETTER_UPLOAD_LIBRARY;
                default:
                    return null;
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
        public string EmailTemplateFromName { get; set; }
        public string CssClass { get; set; }
        public string SerializedCloudSettingsParams { get; set; }
        public string RegisterPageId { get; set; }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private string templateName = "Simple";
        private string templateNamePrefix = "JobApplication.";
        private string _itemType = "Telerik.Sitefinity.DynamicTypes.Model.StandardEmailTemplate.EmailTemplate";
        private string _emailTemplateProviderName = "OpenAccessProvider";
    }
}