using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Services.Intefaces;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace JXTNext.Sitefinity.Services.Services
{
    public class JXTNextJobApplicationService : IJobApplicationService
    {
        public string GetOverrideEmail(ref JobApplicationStatus status, ApplicantInfo applicantInfo, bool isSocialMedia = false)
        {
            string ovverideEmail = null;
          
            if (SitefinityHelper.IsUserLoggedIn()) // User already logged in
            {
                var currUser = SitefinityHelper.GetUserById(ClaimsManager.GetCurrentIdentity().UserId);
                if (currUser != null)
                {
                    // Logout the current user and login social media user
                    if (isSocialMedia && currUser.Email.ToUpper() != applicantInfo.Email.ToUpper())
                        SitefinityHelper.LogoutCurrentUser();
                    else
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
                    else
                    {
                        status = JobApplicationStatus.NotAbleToLoginCreatedUser;
                        return ovverideEmail;
                    }
                    #endregion
                }
                else
                {
                    #region Entered email does not exists in sitefinity User list
                    var membershipCreateStatus = SitefinityHelper.CreateUser(applicantInfo.Email, applicantInfo.Password, applicantInfo.FirstName, applicantInfo.LastName, applicantInfo.Email, applicantInfo.PhoneNumber,
                    null, null, true, true);

                    if (membershipCreateStatus != MembershipCreateStatus.Success)
                    {
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

            return htmlEmailContent;
        }
    }
}
