using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Services.Intefaces;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace JXTNext.Sitefinity.Services.Services
{
    public class JXTNextJobApplicationService : IJobApplicationService
    {
        private static readonly string awsProvider = "private-amazon-s3-provider";
        public string GetOverrideEmail(ref JobApplicationStatus status, ref ApplicantInfo applicantInfo, bool isSocialMedia = false)
        {
            string ovverideEmail = null;
          
            if (SitefinityHelper.IsUserLoggedIn()) // User already logged in
            {
                var currUser = SitefinityHelper.GetUserById(ClaimsManager.GetCurrentIdentity().UserId);
                if (currUser != null)
                {
                    Log.Write("User is already logged In "+ currUser.Email, ConfigurationPolicy.ErrorLog);
                    return currUser.Email;
                }
            }

            // User not looged in
            if (!string.IsNullOrEmpty(applicantInfo.Email))
            {
                Telerik.Sitefinity.Security.Model.User existingUser = SitefinityHelper.GetUserByEmail(applicantInfo.Email);
                
                if (existingUser != null)
                {
                    #region Entered Email exists in Sitefinity User list
                    Log.Write("User is already exists in portal " + existingUser.Email, ConfigurationPolicy.ErrorLog);
                    ovverideEmail = existingUser.Email;
                    return ovverideEmail;
                    #endregion
                }
                else
                {
                    #region Entered email does not exists in sitefinity User list
                    var membershipCreateStatus = SitefinityHelper.CreateUser(applicantInfo.Email, applicantInfo.Password, applicantInfo.FirstName, applicantInfo.LastName, applicantInfo.Email, applicantInfo.PhoneNumber,
                    null, null, true, true);
                    applicantInfo.IsNewUser = true;
                    if (membershipCreateStatus != MembershipCreateStatus.Success)
                    {
                        Log.Write("User is created in portal " + existingUser.Email, ConfigurationPolicy.ErrorLog);
                        status = JobApplicationStatus.NotAbleToCreateUser;
                        return ovverideEmail;
                    }
                    else
                    {
                        //instantiate the Sitefinity user manager
                        //if you have multiple providers you have to pass the provider name as parameter in GetManager("ProviderName") in your case it will be the asp.net membership provider user
                        UserManager userManager = UserManager.GetManager();
                        if (userManager.ValidateUser(applicantInfo.Email, applicantInfo.Password))
                        {
                            //if you need to get the user instance use the out parameter
                            Telerik.Sitefinity.Security.Model.User userToAuthenticate = null;
                            SecurityManager.AuthenticateUser(userManager.Provider.Name, applicantInfo.Email, applicantInfo.Password, false, out userToAuthenticate);
                            if (userToAuthenticate == null)
                            {
                                status = JobApplicationStatus.NotAbleToLoginCreatedUser;
                                return ovverideEmail;
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

            return ovverideEmail;

        }


        public bool DeleteFile(JobApplicationAttachmentUploadItem deletefile)
        {
            return JobApplicationAttachmentUploadItem.DeleteFromAmazonS3("private-amazon-s3-provider", deletefile.AttachmentType, deletefile.Id);
        }


        public List<JobApplicationAttachmentUploadItem> GetFiles(List<JobApplicationAttachmentUploadItem> attachments)
        {
            foreach (var item in attachments)
            {
                item.FileUrl = JobApplicationAttachmentUploadItem.FetchFromAmazonS3("private-amazon-s3-provider", item.AttachmentType, item.Id);
            }
            return attachments;
        }

        public Stream GetFileStreamFromAmazonS3(string srcLibName ,int attachmentType, string id)
        {
            return JobApplicationAttachmentUploadItem.GetFileStreamFromAmazonS3(awsProvider, srcLibName, attachmentType, id);
        }

        public bool UploadFiles(List<JobApplicationAttachmentUploadItem> attachments)
        {
            bool hasFailedUpload = false;
            if(attachments != null && attachments.Count > 0)
            {
                attachments.ForEach(c => JobApplicationAttachmentUploadItem.ProcessFileUpload(ref c));
                hasFailedUpload = attachments.Where(c => c.Status != "Completed").Any();
            }

            return hasFailedUpload;
        }

        public string GetHtmlEmailContent(string emailTemplateId, string emailTemplateProviderName, string itemType)
        {
            string htmlEmailContent = String.Empty;
            if (!String.IsNullOrEmpty(emailTemplateId))
            {
                var dynamicModuleManager = DynamicModuleManager.GetManager(emailTemplateProviderName);
                var emailTemplateType = TypeResolutionService.ResolveType(itemType);
                var emailTemplateItem = dynamicModuleManager.GetDataItem(emailTemplateType, new Guid(emailTemplateId.ToUpper()));
                htmlEmailContent = emailTemplateItem.GetValue("htmlEmailContent").ToString();
            }
            Log.Write("Inside GetHtmlEmailContent method ", ConfigurationPolicy.ErrorLog);
            return htmlEmailContent;
        }

        public string GetHtmlEmailSubject(string emailTemplateId, string emailTemplateProviderName, string itemType)
        {
            string htmlEmailSubject = String.Empty;
            if (!String.IsNullOrEmpty(emailTemplateId))
            {
                var dynamicModuleManager = DynamicModuleManager.GetManager(emailTemplateProviderName);
                var emailTemplateType = TypeResolutionService.ResolveType(itemType);
                var emailTemplateItem = dynamicModuleManager.GetDataItem(emailTemplateType, new Guid(emailTemplateId.ToUpper()));
                htmlEmailSubject = emailTemplateItem.GetValue("Title").ToString();
            }
            Log.Write("Inside GetHtmlEmailContent method ", ConfigurationPolicy.ErrorLog);
            return htmlEmailSubject;
        }


    }
}
