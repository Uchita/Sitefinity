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
using Telerik.Sitefinity.Services;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Services.Intefaces;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [Localization(typeof(JobApplicationResources))]
    [ControllerToolboxItem(Name = "JobApplication_MVC", Title = "Job Application", SectionName = "JXTNext.JobApplication", CssClass = JobApplicationController.WidgetIconCssClass)]
    public class JobApplicationController : Controller
    {
        IBusinessLogicsConnector _blConnector;
        IJobApplicationService _jobApplicationService;
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

        public JobApplicationController(IBusinessLogicsConnector blConnector, IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
            _blConnector = blConnector;
            if (string.IsNullOrWhiteSpace(this.SerializedApplyWithSocialMedia))
                this.SerializedApplyWithSocialMedia = ApplyWithSocialMedia.SerializedSocialMediaInit();
        }


        [RelativeRoute("{*tags}")]
        public ActionResult RouteHandler(string[] tags, int? jobid)
        {
            if (Request.IsAjaxRequest()) // Ajax calls
            {
                if (tags != null && tags.Length > 0)
                {
                    var routePath = tags.FirstOrDefault();
                    if (routePath.ToUpper().Contains("CHECKUSER"))
                    {
                        if (Request.Form["email"] != null)
                        {
                            return CheckUser(Request.Form["email"]);
                        }
                    }
                    else if (routePath.ToUpper().Contains("ISJOBAPPLIED"))
                    {
                        if (Request.Form["jobId"] != null)
                        {
                            int jobId;
                            if (Int32.TryParse(Request.Form["jobId"], out jobId))
                            {
                                return IsJobApplied(jobId);
                            }
                        }
                    }
                    else if (routePath.ToUpper().Contains("VALIDATEUSER"))
                    {
                        if (Request.Form["email"] != null)
                        {
                            return ValidateUser(Request.Form["email"], Request.Form["password"], Convert.ToBoolean(Request.Form["staySignedIn"]), Convert.ToBoolean(Request.Form["isUserLoggedIn"]));
                        }
                    }
                }
            }
            else // Non-Ajax calls
            {
                if (tags != null && tags.Length > 0)
                {
                    string urlRoute = tags.FirstOrDefault();
                    if (urlRoute.ToUpper().Contains("APPLYJOB"))
                    {
                        ApplyJobModel applyJobModel = new ApplyJobModel();
                        applyJobModel.JobId = Convert.ToInt32(Request.Form["JobId"]);
                        applyJobModel.FirstName = Request.Form["FirstName"];
                        applyJobModel.LastName = Request.Form["LastName"];
                        applyJobModel.PhoneNumber = Request.Form["PhoneNumber"];
                        applyJobModel.Email = Request.Form["Email"];
                        applyJobModel.Password = Request.Form["Password"];
                        applyJobModel.UploadFilesResume = Request.Form["UploadFilesResume"];
                        applyJobModel.UploadFilesCoverLetter = Request.Form["UploadFilesCoverLetter"];
                        applyJobModel.UploadFilesDocuments = Request.Form["UploadFilesDocuments"];
                        applyJobModel.ResumeSelectedType = Request.Form["ResumeSelectedType"];
                        applyJobModel.CoverLetterSelectedType = Request.Form["CoverLetterSelectedType"];
                        applyJobModel.DocumentsSelectedType = Request.Form["DocumentsSelectedType"];

                        return ApplyJob(applyJobModel);
                    }

                    string jobIdStr = urlRoute.Substring(0, urlRoute.LastIndexOf('/')).Split('/').Last();
                    if (Int32.TryParse(jobIdStr, out int jobId))
                    {
                        return Index(jobId);
                    }
                }
            }

            // Default redirect to Index action
            return Index(null);

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
            jobApplicationViewModel.ApplyWithSocialMediaInfo = GetSelectedSocialMediaItems();
            bool isUserLoggedIn = false;
            string userEmail = String.Empty;
            string userFirstName = String.Empty;
            var currentIdentity = ClaimsManager.GetCurrentIdentity();

            if (currentIdentity.IsAuthenticated)
            {
                var currUser = SitefinityHelper.GetUserById(currentIdentity.UserId);
                if (currUser != null)
                {
                    userEmail = currUser.Email;
                    userFirstName = SitefinityHelper.GetUserFirstNameById(currUser.Id);
                }

                isUserLoggedIn = true;
            }

            ViewBag.IsUserLoggedIn = isUserLoggedIn;
            ViewBag.UserEmail = userEmail;
            ViewBag.UserFirstName = userFirstName;
            ViewBag.RegisterPageUrl = SitefinityHelper.GetPageUrl(this.RegisterPageId);
            ViewBag.PostBackMessage = TempData["PostBackMessage"];
            if (!this.JobApplicationSuccessPageId.IsNullOrEmpty())
                ViewBag.SuccessPageUrl = SitefinityHelper.GetPageUrl(this.JobApplicationSuccessPageId);

            // These values are required for the Indeed apply
            if(jobid.HasValue)
            {
                IGetJobListingRequest jobListingRequest = new JXTNext_GetJobListingRequest { JobID = jobid.Value };
                IGetJobListingResponse jobListingResponse = _blConnector.GuestGetJob(jobListingRequest);
                ViewBag.JobTitle = jobListingResponse.Job.Title;
                ViewBag.CompanyName = jobListingResponse.Job.CustomData["CompanyName"];
                ViewBag.JobLocation = jobListingResponse.Job.CustomData["CountryLocationArea[0].Filters[0].Value"];
            }

            if (isUserLoggedIn && !string.IsNullOrEmpty(userEmail))
            {
                var response = _blConnector.GetMemberByEmail(userEmail);
                if (response.Member?.ResumeFiles != null)
                {
                    var resumeList = JsonConvert.DeserializeObject<List<ProfileResume>>(response.Member.ResumeFiles);
                    List<SelectListItem> myResumes = new List<SelectListItem>();
                    myResumes.Add(new SelectListItem { Text = "SELECT YOUR CV", Value = "0" });
                    foreach (var item in resumeList)
                    {
                        var datestr = item.UploadDate.ToShortDateString();
                        myResumes.Add(new SelectListItem { Text = datestr + " - " + item.FileFullName, Value = item.Id.ToString() });
                    }
                    ViewBag.ResumeList = myResumes;

                }
            }

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
            var ovverideEmail = applyJobModel.Email;
            // Create user if the user does not exists
            MembershipCreateStatus membershipCreateStatus;
            ViewBag.PostBackMessage = null;
            ViewBag.IsUserLoggedIn = false;

            if (SitefinityHelper.IsUserLoggedIn()) // User already logged in
            {
                var currUser = SitefinityHelper.GetUserById(ClaimsManager.GetCurrentIdentity().UserId);
                if (currUser != null)
                    ovverideEmail = currUser.Email;
            }
            else //user not logged in
            {
                if (!string.IsNullOrEmpty(applyJobModel.Email))
                {
                    Telerik.Sitefinity.Security.Model.User existingUser = SitefinityHelper.GetUserByEmail(applyJobModel.Email);

                    if (existingUser != null)
                    {
                        #region Entered Email exists in Sitefinity User list
                        //instantiate the Sitefinity user manager
                        //if you have multiple providers you have to pass the provider name as parameter in GetManager("ProviderName") in your case it will be the asp.net membership provider user
                        UserManager userManager = UserManager.GetManager();
                        if (userManager.ValidateUser(applyJobModel.Email, applyJobModel.Password))
                        {
                            //if you need to get the user instance use the out parameter
                            Telerik.Sitefinity.Security.Model.User userToAuthenticate = null;
                            SecurityManager.AuthenticateUser(userManager.Provider.Name, applyJobModel.Email, applyJobModel.Password, false, out userToAuthenticate);
                            if (userToAuthenticate == null)
                            {
                                jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.NotAbleToLoginCreatedUser, "Unable to process your job application. Please try logging in and re-apply for the job.");
                                return View("JobApplication.Simple", jobApplicationViewModel);
                            }
                            else
                            {
                                ovverideEmail = userToAuthenticate.Email;
                            }
                        }
                        else
                        {
                            jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.NotAbleToLoginCreatedUser, "Unable to process your job application. Please try logging in and re-apply for the job.");
                            return View("JobApplication.Simple", jobApplicationViewModel);
                        }
                        #endregion
                    }
                    else
                    {
                        #region Entered email does not exists in sitefinity User list
                        membershipCreateStatus = SitefinityHelper.CreateUser(applyJobModel.Email, applyJobModel.Password, applyJobModel.FirstName, applyJobModel.LastName, applyJobModel.Email, applyJobModel.PhoneNumber,
                        null, null, true, true);

                        if (membershipCreateStatus != MembershipCreateStatus.Success)
                        {
                            jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.NotAbleToCreateUser, "Unable to create user. Please register from");
                            return View("JobApplication.Simple", jobApplicationViewModel);
                        }
                        else
                        {
                            //instantiate the Sitefinity user manager
                            //if you have multiple providers you have to pass the provider name as parameter in GetManager("ProviderName") in your case it will be the asp.net membership provider user
                            UserManager userManager = UserManager.GetManager();
                            if (userManager.ValidateUser(applyJobModel.Email, applyJobModel.Password))
                            {
                                //if you need to get the user instance use the out parameter
                                Telerik.Sitefinity.Security.Model.User userToAuthenticate = null;
                                SecurityManager.AuthenticateUser(userManager.Provider.Name, applyJobModel.Email, applyJobModel.Password, false, out userToAuthenticate);
                                if (userToAuthenticate == null)
                                {
                                    jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.NotAbleToLoginCreatedUser, "Unable to process your job application. Please try logging in and re-apply for the job.");
                                    return View("JobApplication.Simple", jobApplicationViewModel);
                                }
                                else
                                {
                                    ovverideEmail = userToAuthenticate.Email;
                                }
                            }
                        }
                        #endregion
                    }
                }
            }


            ViewBag.IsUserLoggedIn = true;
            JobApplicationAttachmentSource sourceResume = GetAttachmentSourceType(applyJobModel.ResumeSelectedType);
            JobApplicationAttachmentSource sourceCoverLetter = GetAttachmentSourceType(applyJobModel.CoverLetterSelectedType);
            JobApplicationAttachmentSource sourceDocuments = GetAttachmentSourceType(applyJobModel.DocumentsSelectedType);


            List<JobApplicationAttachmentUploadItem> attachments = GatherAttachments(sourceResume, sourceCoverLetter, sourceDocuments, applyJobModel.UploadFilesResume, applyJobModel.UploadFilesCoverLetter, applyJobModel.UploadFilesDocuments);
            
            
            string resumeAttachmentPath = GetAttachmentPath(attachments, JobApplicationAttachmentType.Resume).FirstOrDefault();
            string coverletterAttachmentPath = GetAttachmentPath(attachments, JobApplicationAttachmentType.Coverletter).FirstOrDefault();
            List<string> documentsAttachmentPath = GetAttachmentPath(attachments, JobApplicationAttachmentType.Documents);

            #region Email Notification
            // Email Notification Settings
            // In the desinger form those are going to be provided by separator as semicolon(;)
            string htmlEmailContent = this.GetHtmlEmailContent();
            EmailNotificationSettings emailNotificationSettings = new EmailNotificationSettings(new EmailTarget(this.EmailTemplateSenderName, this.EmailTemplateSenderEmailAddress),
                                                                                                new EmailTarget(SitefinityHelper.GetUserFirstNameById(ClaimsManager.GetCurrentIdentity().UserId), ovverideEmail),
                                                                                                this.EmailTemplateEmailSubject,
                                                                                                htmlEmailContent);
            // CC and BCC emails
            if (!this.EmailTemplateCC.IsNullOrEmpty())
            {
                foreach (var ccEmail in this.EmailTemplateCC.Split(';'))
                {
                    emailNotificationSettings.AddCC(String.Empty, ccEmail);
                }
            }

            if (!this.EmailTemplateBCC.IsNullOrEmpty())
            {
                foreach (var bccEmail in this.EmailTemplateBCC.Split(';'))
                {
                    emailNotificationSettings.AddBCC(String.Empty, bccEmail);
                }
            }

            #endregion

            //Create Application 
            IMemberApplicationResponse response = _blConnector.MemberCreateJobApplication(
                new JXTNext_MemberApplicationRequest { ApplyResourceID = applicationResultID, MemberID = memberID, ResumePath = resumeAttachmentPath, CoverletterPath = coverletterAttachmentPath, DocumentsPath = documentsAttachmentPath, EmailNotification = emailNotificationSettings },
                ovverideEmail);

            var isJobApplicationSuccess = false;

            if (response.Success && response.ApplicationID.HasValue)
            {
                //FileUploads
                attachments.ForEach(c => ProcessFileUpload(ref c));

                bool hasFailedUpload = attachments.Where(c => c.Status != "Completed").Any();

                if (hasFailedUpload)
                {
                    //prompt error message for contact
                    //jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.Technical_Issue, "Unable to attach files to application");
                    TempData["PostBackMessage"] = "Unable to attach files to application";
                    return Redirect(Request.UrlReferrer.PathAndQuery);
                }
                else
                {
                    isJobApplicationSuccess = true;
                    jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.Applied_Successful, "Your application was successfully processed");
                }

            }
            else
            {
                TempData["PostBackMessage"] = response.Errors.First();
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }

            #region Redirect to thank you page on success
            // When the job appliction is success we need to redirect to thank you page
            if (isJobApplicationSuccess && !this.JobApplicationSuccessPageId.IsNullOrEmpty())
            {
                var successPageUrl = SitefinityHelper.GetPageUrl(this.JobApplicationSuccessPageId);
                return Redirect(successPageUrl);
            }
            #endregion

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
        public JsonResult ValidateUser(string email, string password, bool staySignedIn, bool isUserLoggedIn)
        {
            bool isUserVerified = true;
            bool isMemberUser = false;
            bool isUserSignedIn = false;
            List<SelectListItem> myResumes = new List<SelectListItem>();
            if (!isUserLoggedIn)
            {
                isUserVerified = SitefinityHelper.IsUserVerified(email, password);
                if (isUserVerified)
                {
                    var user = SitefinityHelper.GetUserByEmail(email);
                    if (user != null)
                    {
                        isMemberUser = SitefinityHelper.IsUserInRole(user, "Member");
                        var memberResponse = _blConnector.GetMemberByEmail(user.Email);
                        if (memberResponse.Member?.ResumeFiles != null)
                        {
                            var resumeList = JsonConvert.DeserializeObject<List<ProfileResume>>(memberResponse.Member.ResumeFiles);
                            
                            myResumes.Add(new SelectListItem { Text = "SELECT YOUR CV", Value = "0" });
                            foreach (var item in resumeList)
                            {
                                var datestr = item.UploadDate.ToShortDateString();
                                myResumes.Add(new SelectListItem { Text = datestr + " - " + item.FileFullName, Value = item.Id.ToString() });
                            }
                        }
                    }
                        
                }

            }
            else
            {
                var currUser = SitefinityHelper.GetUserById(ClaimsManager.GetCurrentIdentity().UserId);
                if (currUser != null)
                    isMemberUser = SitefinityHelper.IsUserInRole(currUser, "Member");
            }

            #region Entered Email exists in JXTNext Member list
            if (isMemberUser)
            {
                //instantiate the Sitefinity user manager
                //if you have multiple providers you have to pass the provider name as parameter in GetManager("ProviderName") in your case it will be the asp.net membership provider user
                UserManager userManager = UserManager.GetManager();
                if (userManager.ValidateUser(email, password))
                {
                    //if you need to get the user instance use the out parameter
                    Telerik.Sitefinity.Security.Model.User userToAuthenticate = null;
                    SecurityManager.AuthenticateUser(userManager.Provider.Name, email, password, staySignedIn, out userToAuthenticate);
                    if (userToAuthenticate != null)
                        isUserSignedIn = true;
                }
            }
            #endregion

            var response = new
            {
                IsUserVerified = isUserVerified,
                IsUserMember = isMemberUser,
                IsUserSignedIn = isUserSignedIn,
                myResumes = JsonConvert.SerializeObject(myResumes)
            };

            return new JsonResult { Data = response };
        }

        [HttpPost]
        public JsonResult IsJobApplied(int jobId)
        {
            bool isJobApplied = false;

            JXTNext_MemberAppliedJobResponse appliedJobresponse = _blConnector.MemberAppliedJobsGet() as JXTNext_MemberAppliedJobResponse;
            if (appliedJobresponse.Success)
            {
                foreach (var item in appliedJobresponse.MemberAppliedJobs)
                {
                    if (item.JobId == jobId)
                    {
                        isJobApplied = true;
                        break;
                    }
                }
            }

            return new JsonResult { Data = isJobApplied };
        }
        private JobApplicationAttachmentSource GetAttachmentSourceType(string sourceType)
        {
            if (sourceType.ToUpper() == "DROPBOX")
                return JobApplicationAttachmentSource.Dropbox;
            if (sourceType.ToUpper() == "GOOGLEDRIVE")
                return JobApplicationAttachmentSource.GoogleDrive;
            if (sourceType.ToUpper() == "SAVED")
                return JobApplicationAttachmentSource.Saved;
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
            var libManagerSecurityCheckStatus = librariesManager.Provider.SuppressSecurityChecks;

            try
            {
                // Make sure that supress the security checks so that everyone can upload the files
                librariesManager.Provider.SuppressSecurityChecks = true;
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
                    string fileExtension = "." + fileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                    librariesManager.Upload(document, fileStream, fileExtension ?? string.Empty);

                    //Recompiles and validates the url of the document.
                    librariesManager.RecompileAndValidateUrls(document);

                    //Save the changes.
                    librariesManager.SaveChanges();

                    //Publish the DocumentLibraries item. The live version acquires new ID.
                    var bag = new Dictionary<string, string>();
                    bag.Add("ContentType", typeof(Document).FullName);

                    // Run with elevatede privilages so that everybody can upload files
                    SystemManager.RunWithElevatedPrivilege(d => WorkflowManager.MessageWorkflow(masterDocumentId, typeof(Document), null, "Publish", false, bag));
                }
            }

            finally
            {
                // Reset the suppress security checks
                librariesManager.Provider.SuppressSecurityChecks = libManagerSecurityCheckStatus;
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
                    },
                    //Documents
                    new JobApplicationAttachmentItem
                    {
                        AttachementType = JobApplicationAttachmentType.Documents,
                        Title = "Documents",
                        Enabled = true,
                        AttachementFileUploadKey = JobApplicationAttachmentSettings.APPLICATION_DOCUMENTS_UPLOAD_KEY,
                        Integrations = null
                    }
                },
                ApplicationMessage = null
            };
        }

        private List<JobApplicationAttachmentUploadItem> GatherAttachments(JobApplicationAttachmentSource sourceResume, JobApplicationAttachmentSource sourceCoverLetter, JobApplicationAttachmentSource sourceDocuments, string uploadFilesResumeJSON, string uploadFilesCoverLetterJSON, string uploadFilesDocumentsJSON)
        {
            List<JobApplicationAttachmentUploadItem> attachmentItems = new List<JobApplicationAttachmentUploadItem>();
            
            if (sourceResume == JobApplicationAttachmentSource.Saved)
            {
                var currentIdentity = ClaimsManager.GetCurrentIdentity();

                if (currentIdentity.IsAuthenticated)
                {
                    var currUser = SitefinityHelper.GetUserById(currentIdentity.UserId);
                    if (currUser != null)
                    {
                        
                        var memberResponse = _blConnector.GetMemberByEmail(currUser.Email);
                        if (memberResponse.Member?.ResumeFiles != null)
                        {
                            var resumeList = JsonConvert.DeserializeObject<List<ProfileResume>>(memberResponse.Member.ResumeFiles);
                            var selectedResume = resumeList.Where(x => x.Id.ToString() == uploadFilesResumeJSON).FirstOrDefault();
                            if (selectedResume != null)
                            {
                                var resumeUploadStream = _jobApplicationService.GetFileStreamFromAmazonS3(JobApplicationAttachmentSettings.PROFILE_RESUME_UPLOAD_KEY, 1, uploadFilesResumeJSON);
                                if (resumeUploadStream != null)
                                {
                                    JobApplicationAttachmentUploadItem item = GatherSavedResumeAttachmentDetails(JobApplicationAttachmentType.Resume, resumeUploadStream, selectedResume.FileFullName);
                                    if (item != null)
                                        attachmentItems.Add(item);
                                }
                            }
                            
                        }
                    }
                }
                
                

            }

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

            if (sourceDocuments == JobApplicationAttachmentSource.Local)
            {
                bool hasDocumentsUpload = Request.Files.AllKeys.Contains(JobApplicationAttachmentSettings.APPLICATION_DOCUMENTS_UPLOAD_KEY);
                if (hasDocumentsUpload)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        if (Request.Files.AllKeys[i] == JobApplicationAttachmentSettings.APPLICATION_DOCUMENTS_UPLOAD_KEY)
                        {
                            JobApplicationAttachmentUploadItem item = GatherAttachmentDetails(JobApplicationAttachmentType.Documents, Request.Files[i]);
                            if (item != null)
                                attachmentItems.Add(item);
                        }
                    }

                }
            }

            // Processing the Resume
            if (sourceResume == JobApplicationAttachmentSource.GoogleDrive)
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

            // Processing Documents
            if (sourceDocuments == JobApplicationAttachmentSource.GoogleDrive)
            {
                var googleDriveModel = JsonConvert.DeserializeObject<List<UploadFilesFormPostModel>>(uploadFilesDocumentsJSON);
                foreach (var googleFile in googleDriveModel)
                {
                    JobApplicationAttachmentUploadItem item = GetAttachementFromGoogleDrive(googleFile, JobApplicationAttachmentType.Documents);
                    attachmentItems.Add(item);
                }
            }

            if (sourceDocuments == JobApplicationAttachmentSource.Dropbox)
            {
                var dropboxDriveModel = JsonConvert.DeserializeObject<List<UploadFilesFormPostModel>>(uploadFilesDocumentsJSON);
                foreach (var dropboxFile in dropboxDriveModel)
                {
                    JobApplicationAttachmentUploadItem item = GetAttachementFromDropbox(dropboxFile, JobApplicationAttachmentType.Documents);
                    attachmentItems.Add(item);
                }                
            }

            return attachmentItems;
        }

        private JobApplicationAttachmentUploadItem GetAttachementFromGoogleDrive(UploadFilesFormPostModel googleFilesInfo, JobApplicationAttachmentType attachmentType)
        {
            GoogleDriveFileHandlerService googleDriveFileHandleService = new GoogleDriveFileHandlerService();
            SiteSettingsHelper siteSettingsHelper = new SiteSettingsHelper();
            string clientId = siteSettingsHelper.GetCurrentSiteGoogleClientId();
            string clientSecret = siteSettingsHelper.GetCurrentSiteGoogleClientSecret();
            GoogleDriveFileHandlerRequestModel baseFileHandle = new GoogleDriveFileHandlerRequestModel()
            {
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

        private List<string> GetAttachmentPath(List<JobApplicationAttachmentUploadItem> attachmentItems, JobApplicationAttachmentType attachmentType)
        {
            List<JobApplicationAttachmentUploadItem> item = attachmentItems.Where(c => c.AttachmentType == attachmentType).ToList();
            List<string> paths = new List<string>();

            foreach (var path in item)
            {
                paths.Add(path.PathToAttachment);
            }

            return paths;
        }

        private JobApplicationAttachmentUploadItem GatherSavedResumeAttachmentDetails(JobApplicationAttachmentType attachmentType, Stream file, string fileName)
        {
            if (file != null )
            {
                Guid identifier = Guid.NewGuid();
                return new JobApplicationAttachmentUploadItem
                {
                    Id = identifier.ToString(),
                    AttachmentType = attachmentType,
                    FileName = fileName,
                    FileStream = file,
                    PathToAttachment = identifier.ToString() + "_" + fileName,
                    Status = "Ready"
                };
            }
            return null;
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
                case JobApplicationAttachmentType.Documents:
                    return JobApplicationAttachmentSettings.APPLICATION_DOCUMENTS_UPLOAD_LIBRARY;
                default:
                    return null;
            }
        }

        private List<ApplyWithSocialMedia> GetSelectedSocialMediaItems()
        {
            var socialMediaLinks = JsonConvert.DeserializeObject<List<ApplyWithSocialMedia>>(this.SerializedApplyWithSocialMedia);
            var selectedLinks = socialMediaLinks.Where(l => l.Selected == true).ToList();

            return selectedLinks;
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
        public string CssClass { get; set; }
        public string SerializedCloudSettingsParams { get; set; }
        public string RegisterPageId { get; set; }
        public string JobApplicationSuccessPageId { get; set; }
        public string SerializedApplyWithSocialMedia { get; set; }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private string templateName = "Simple";
        private string templateNamePrefix = "JobApplication.";
        private string _itemType = "Telerik.Sitefinity.DynamicTypes.Model.StandardEmailTemplate.EmailTemplate";
        private string _emailTemplateProviderName = "OpenAccessProvider";
    }
}