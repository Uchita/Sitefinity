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
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Multisite;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Helpers;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Model;
using System.Web.Security;
using JXTNext.SocialMedia.Services.LinkedIn;

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
                            result.UrlReferral = TempData["source"].ToString();
                    }
                    else if (code.IsNullOrEmpty() && !indeedJsonStringData.IsNullOrEmpty())
                    {
                        result = _processSocialMediaIndeedData.ProcessData(code, state, indeedJsonStringData);
                        result.UrlReferral = result.JobSource;
                    }
                    else
                    {
                        Log.Write("Social Handler code,sate and indeed data is null", ConfigurationPolicy.ErrorLog);
                    }


                    var jobDetails = GetJobDetails(result.JobId.Value);
                    //var result = _socialHandlerLogics.ProcessSocialHandlerData(code, state, indeedJsonStringData);
                    if (result != null && result.ResumeLinkNotExists)
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


                    if (result != null && result.Success == true && result.JobId.HasValue)
                    {
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

                                //Create Application 
                                var response = CreateJobApplication(result, jobDetails, applicantInfo, overrideEmail);
                                
                                if (response.MemberApplicationResponse.Success && response.MemberApplicationResponse.ApplicationID.HasValue)
                                {
                                    if (!response.FilesUploaded)
                                    {
                                        viewModel.Status = response.Status; // Unable to attach files
                                        viewModel.Message = response.Message;
                                    }
                                    else
                                    {
                                        viewModel.Status = response.Status;
                                        viewModel.Message = response.Message;
                                        if (!this.JobApplicationSuccessPageId.IsNullOrEmpty())
                                        {
                                            Log.Write("JobApplicationSuccessPageId is not null: ", ConfigurationPolicy.ErrorLog);
                                            var successPageUrl = SfPageHelper.GetPageUrlById(JobApplicationSuccessPageId.IsNullOrWhitespace() ? Guid.Empty : new Guid(JobApplicationSuccessPageId));
                                            Log.Write("successPageUrl : " + successPageUrl, ConfigurationPolicy.ErrorLog);
                                            return Redirect(successPageUrl);
                                        }
                                    }
                                }
                                else
                                {
                                    if (viewModel.Status == JobApplicationStatus.Already_Applied)
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
                                    viewModel.Status = response.Status;
                                    viewModel.Message = response.Message;
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
            if (!string.IsNullOrEmpty(this.Request.QueryString["error"])  && this.Request.QueryString["error"].ToLower().Contains("denied") && state != null && int.TryParse(state, out jobId))
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
                ViewBag.JobSearchResultsUrl = SfPageHelper.GetPageUrlById(JobSearchResultsPageId.IsNullOrWhitespace() ? Guid.Empty : new Guid(JobSearchResultsPageId));

            var fullTemplateName = this.templateNamePrefix + this.TemplateName;

            return View(fullTemplateName, viewModel);
        }

        #region LinkedIn

        /// <summary>
        /// Action to handle LinkedIn sign-in.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult LinkedInSignIn(LinkedInSignInRequest request)
        {
            LinkedInSignInViewModel viewModel;
            string urlReferral = null;
            if (TempData["source"] != null)
            {
                urlReferral = TempData["source"].ToString();
            }

            if (string.IsNullOrEmpty(request.Error))
            {
                viewModel = HandleLinkedInSignIn(request);

                if (viewModel.Error == null)
                {
                    TempData["Urlreferal"] = urlReferral;

                    // try to redirect to the last page
                    if (!string.IsNullOrWhiteSpace(request.Redirect))
                    {
                        if (request.Redirect == LinkedInHelper.ActionJobApply)
                        {
                            if (int.TryParse(request.Data, out int jobId))
                            {
                                return Redirect(GetJobApplicationUrl(jobId, "ShowLinkedIn=1"));
                            }
                        }
                        else
                        {
                            var uriBuilder = new UriBuilder(request.Redirect);

                            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                            query["ShowLinkedIn"] = "1";

                            uriBuilder.Query = query.ToString();

                            return Redirect(uriBuilder.ToString());
                        }
                    }

                    // redirect to home page
                    return Redirect("/");
                }
            }
            else
            {
                if (request.Error == "user_cancelled_login" || request.Error == "user_cancelled_authorize")
                {
                    // try to redirect to the last page.
                    if (!string.IsNullOrWhiteSpace(request.Redirect))
                    {
                        TempData["Urlreferal"] = urlReferral;

                        if (request.Redirect == LinkedInHelper.ActionJobApply)
                        {
                            if (int.TryParse(request.Data, out int jobId))
                            {
                                return Redirect(GetJobApplicationUrl(jobId));
                            }
                        }
                        else
                        {
                            return Redirect(request.Redirect);
                        }
                    }
                }

                viewModel = new LinkedInSignInViewModel
                {
                    Error = request.ErrorDescription ?? Request.QueryString.Get("error_description")
                };
            }

            // set the back url based on the action.
            // this will handle the unexpected errors.
            if (request.Redirect == LinkedInHelper.ActionJobApply)
            {
                if (int.TryParse(request.Data, out int jobId))
                {
                    viewModel.BackUrl = GetJobApplicationUrl(jobId);
                }
            }

            return View(viewModel);
        }

        /// <summary>
        /// Action to handle job application with LinkedIn.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="profileJson"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LinkedInApply(int jobId, string profileJson)
        {
            var response = new LinkedInApplyResponse();

            // user must be logged in to apply for a job
            if (!SitefinityHelper.IsUserLoggedIn())
            {
                response.Errors.Add("You must be logged in to apply for a job.");

                return Json(response);
            }

            // check whether requested job exist or not
            var jobDetails = GetJobDetails(jobId);
            if (jobDetails == null)
            {
                response.Errors.Add("Job does not exist.");

                return Json(response);
            }

            // process the submitted LinkedIn data
            var processLinkedInData = new ProcessLinkedInData();
            var result = processLinkedInData.ProcessData(null, null, profileJson);
            if (result == null || !result.Success)
            {
                response.Errors = result.Errors;

                return Json(response);
            }

            result.JobId = jobId;
            if(TempData["Urlreferal"] != null)
            {
                result.UrlReferral = TempData["Urlreferal"].ToString();
            }
            

            var viewModel = new SocialMediaJobViewModel
            {
                Status = JobApplicationStatus.Available
            };

            ApplicantInfo applicantInfo = new ApplicantInfo()
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                IsNewUser = false
            };

            // create the job application and redirect to success page if possible
            var applicationResponse = CreateJobApplication(result, jobDetails, applicantInfo, result.Email);
            if (applicationResponse.Status == JobApplicationStatus.Applied_Successful)
            {
                response.Success = true;
                response.Messages.Add(applicationResponse.Message);

                if (!string.IsNullOrEmpty(this.JobApplicationSuccessPageId))
                {
                    response.RedirectUrl = SfPageHelper.GetPageUrlById(new Guid(JobApplicationSuccessPageId));              
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(applicationResponse.Message))
                {
                    response.Errors.Add("An unexpected error occurred while processing your request. Please try again.");
                }
                else
                {
                    response.Errors.Add(applicationResponse.Message);
                }
            }

            return Json(response);
        }

        /// <summary>
        /// Handle sign-in with LinkedIn.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private LinkedInSignInViewModel HandleLinkedInSignIn(LinkedInSignInRequest request)
        {
            var viewModel = new LinkedInSignInViewModel();

            if (SitefinityHelper.IsUserLoggedIn())
            {
                return viewModel;
            }

            if (!LinkedInHelper.IsValidState(request.State))
            {
                viewModel.Error = "The response from LinkedIn is in invalid state. Please go back and try again.";

                return viewModel;
            }

            var redirectUrl = LinkedInHelper.CreateSignInRedirectUrl(request.Redirect, request.Data);

            try
            {
                var accessTokenResponse = LinkedInHelper.GetAccessTokenFromAuthorisationCode(request.Code, redirectUrl);

                if (string.IsNullOrEmpty(accessTokenResponse.Error))
                {
                    if (!CreateUserFromLinkedInProfileData(accessTokenResponse.AccessToken))
                    {
                        viewModel.Error = "There was some problem while sign-in. Please go back and try again.";
                    }
                }
                else
                {
                    viewModel.Error = accessTokenResponse.Error;
                }
            }
            catch (Exception err)
            {
                viewModel.Error = "There was some problem during authentication with LinkedIn. Please go back and try again.";

                Log.Write(err);
            }

            return viewModel;
        }

        /// <summary>
        /// Create user from the LinkedIn profile data.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private bool CreateUserFromLinkedInProfileData(string accessToken)
        {
            // get the email address from the profile
            var emailAddress = LinkedInHelper.GetProfileEmailAddress(accessToken);
            if (string.IsNullOrEmpty(emailAddress))
            {
                Log.Write("LinkedIn: Email address not present in the response.");

                return false;
            }

            // if an account already exist then authenticate
            var existingUser = SitefinityHelper.GetUserByEmail(emailAddress);
            if (existingUser != null)
            {
                
                if (!AuthenticateUser(emailAddress))
                {
                    Log.Write("LinkedIn: Unable to authenticate user using the email address.");

                    return false;
                }

                return true;
            }

            // at this point create a new account

            var profile = LinkedInHelper.GetProfile(accessToken);

            var membershipCreateStatus = SitefinityHelper.CreateUser(
                emailAddress,
                System.Web.Security.Membership.GeneratePassword(12, 2),
                profile.FirstName,
                profile.LastName,
                emailAddress,
                null,
                null,
                null,
                true,
                true
            );

            if (membershipCreateStatus != MembershipCreateStatus.Success)
            {
                Log.Write("LinkedIn: Unable to create user account.");

                return false;
            }

            if (!AuthenticateUser(emailAddress))
            {
                Log.Write("LinkedIn: Unable to authenticate user using the email address after registration.");

                return false;
            }

            return true;
        }

        #endregion

        /// <summary>
        /// Authenticate a user by email address.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        private bool AuthenticateUser(string emailAddress)
        {
            // check user exist in the JXT Next database
            Telerik.Sitefinity.Security.Model.User existingUser = SitefinityHelper.GetUserByEmail(emailAddress);
            var memberResponse = _blConnector.GetMemberByEmail(emailAddress);
            if (memberResponse.Member == null)
            {
                UserProfileManager userProfileManager = UserProfileManager.GetManager();
                UserProfile profile = userProfileManager.GetUserProfile(existingUser.Id, typeof(SitefinityProfile).FullName);
                var fName = Telerik.Sitefinity.Model.DataExtensions.GetValue(profile, "FirstName");
                var lName = Telerik.Sitefinity.Model.DataExtensions.GetValue(profile, "LastName");
                JXTNext_MemberRegister memberReg = new JXTNext_MemberRegister
                {
                    Email = emailAddress,
                    FirstName = fName.ToString(),
                    LastName = lName.ToString(),
                    Password = existingUser.Password
                };

                if (_blConnector.MemberRegister(memberReg, out string errorMessage))
                {
                    Log.Write("User created JXT next DB" + existingUser.Email, ConfigurationPolicy.ErrorLog);
                }
            }
            // end of the code for the user check in the JXT Next DB
            var userManager = UserManager.GetManager();
            SecurityManager.AuthenticateUser(userManager.Provider.Name, emailAddress, false, out User user);

            return user != null;
        }

        /// <summary>
        /// Get the URL of the job application.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private string GetJobApplicationUrl(int jobId, string query = null)
        {
            if (query != null)
            {
                query = "?" + query;
            }

            var jobDetails = GetJobDetails(jobId);

            if (jobDetails.JobSEOUrl.IsNullOrEmpty())
            {
                return string.Format("/job-application/{0}{1}", jobId, query);
            }
            else
            {
                return string.Format("/job-application/{0}/{1}{2}", jobDetails.JobSEOUrl, jobId, query);
            }
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

        private CreateJobApplicationResponse CreateJobApplication(
            SocialMediaProcessedResponse result, 
            JobDetailsModel jobDetails, 
            ApplicantInfo applicantInfo,
            string overrideEmail)
        {
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
                                        new JobApplicationEmailTemplateModel()
                                        {
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
            var response = _blConnector.MemberCreateJobApplication(
                new JXTNext_MemberApplicationRequest
                {
                    ApplyResourceID = result.JobId.Value,
                    MemberID = 2,
                    ResumePath = resumeAttachmentPath,
                    CoverletterPath = coverletterAttachmentPath,
                    EmailNotification = emailNotificationSettings,
                    AdvertiserEmailNotification = advertiserEmailNotificationSettings,
                    AdvertiserName = jobDetails.ContactDetails,
                    CompanyName = jobDetails.CompanyName,
                    UrlReferral = result.UrlReferral,
                    RegistrationEmailNotification = registrationNotificationsSettings
                },
                overrideEmail);

            Log.Write("BL response after: ", ConfigurationPolicy.ErrorLog);

            var createJobApplicationResponse = new CreateJobApplicationResponse {
                MemberApplicationResponse = response
            };

            if (response.Success && response.ApplicationID.HasValue)
            {
                Log.Write("BL response in: ", ConfigurationPolicy.ErrorLog);
                var hasFailedUpload = _jobApplicationService.UploadFiles(attachments);
                Log.Write("file upload is : " + hasFailedUpload, ConfigurationPolicy.ErrorLog);
                if (hasFailedUpload)
                {
                    createJobApplicationResponse.FilesUploaded = false;
                    createJobApplicationResponse.Status = JobApplicationStatus.Technical_Issue; // Unable to attach files
                    createJobApplicationResponse.Message = "Unable to attach files to application";
                }
                else
                {
                    createJobApplicationResponse.FilesUploaded = true;
                    createJobApplicationResponse.Status = JobApplicationStatus.Applied_Successful;
                    createJobApplicationResponse.Message = "Your application was successfully processed.";                    
                }
            }
            else
            {
                if (response.Errors.FirstOrDefault().ToLower().Contains("already exists"))
                {
                    createJobApplicationResponse.Status = JobApplicationStatus.Already_Applied;
                    createJobApplicationResponse.Message = "You have already applied to this job.";
                }
                else
                {
                    createJobApplicationResponse.Status = JobApplicationStatus.Technical_Issue;
                    createJobApplicationResponse.Message = response.Errors.FirstOrDefault();
                }
            }

            return createJobApplicationResponse;
        }

        private string GetEmailHtmlContent(string emailTemplateId)
        {
            //return _jobApplicationService.GetHtmlEmailContent("6AB317D4-D674-4636-8481-014BC6F861E1", this.EmailTemplateProviderName, this._itemType);
            return SitefinityHelper.GetCurrentSiteEmailTemplateHtmlContent(emailTemplateId);
        }

        private string GetEmailSubject(string emailTemplateId)
        {
            //return _jobApplicationService.GetHtmlEmailContent("6AB317D4-D674-4636-8481-014BC6F861E1", this.EmailTemplateProviderName, this._itemType);
            return SitefinityHelper.GetCurrentSiteEmailTemplateTitle(emailTemplateId);
        }

        

        public string ItemType
        {
            get { return this._itemType; }
            set { this._itemType = value; }
        }
        public string EmailTemplateProviderName
        {
            get {
                return SitefinityHelper.GetCurrentSiteEmailTemplateProviderName();
            }
            
        }



        private EmailNotificationSettings _createAdvertiserEmailTemplate(JobApplicationEmailTemplateModel emailTemplate)
        {
            EmailNotificationSettings advertiserEmailTemplate = _addEmailNotificationSettings(emailTemplate);

            // CC and BCC emails
            _addCCToEmailTemplate(ref advertiserEmailTemplate, this.AdvertiserEmailTemplateCC);

            _addBCCToEmailTemplate(ref advertiserEmailTemplate, this.AdvertiserEmailTemplateBCC);

            return advertiserEmailTemplate;
        }

        private EmailNotificationSettings _createApplicantEmailTemplate(JobApplicationEmailTemplateModel emailTemplate)
        {
            EmailNotificationSettings applicantEmailTemplate = _addEmailNotificationSettings(emailTemplate);
            // CC and BCC emails
            _addCCToEmailTemplate(ref applicantEmailTemplate, this.EmailTemplateCC);

            _addBCCToEmailTemplate(ref applicantEmailTemplate, this.EmailTemplateBCC);

            return applicantEmailTemplate;
        }

        private EmailNotificationSettings _createRegistrationEmailTemplate(JobApplicationEmailTemplateModel emailTemplate)
        {
            EmailNotificationSettings registerEmailTemplate = _addEmailNotificationSettings(emailTemplate);
            // CC and BCC emails
            _addCCToEmailTemplate(ref registerEmailTemplate, this.RegistrationEmailTemplateCC);

            _addBCCToEmailTemplate(ref registerEmailTemplate, this.RegistrationEmailTemplateBCC);

            return registerEmailTemplate;
        }

        private EmailNotificationSettings _addEmailNotificationSettings(JobApplicationEmailTemplateModel emailTemplate)
        {
            EmailNotificationSettings emailNotificationSettings = new EmailNotificationSettings(new EmailTarget(emailTemplate.FromFullName, emailTemplate.FromEmail),
                                                                                                                    new EmailTarget(emailTemplate.ToFullName, emailTemplate.ToEmail),
                                                                                                                    emailTemplate.Subject,
                                                                                                                    emailTemplate.HtmlContent, emailTemplate.Attachments);


            return emailNotificationSettings;
        }

        private void _addCCToEmailTemplate(ref EmailNotificationSettings emailNotificationSettings, string emailTemplateCC)
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
