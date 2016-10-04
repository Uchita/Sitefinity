using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using JXTPortal.Entities;
using System.Text.RegularExpressions;
using System.Web;

namespace JXTPortal.JobApplications.PeopleProfile
{
    public static class ServiceDottIntegration
    {
        private static string EncrpytionKey = ConfigurationManager.AppSettings["ServiceDottIntegrationEncryptKey"];
        private static string PeopleProfilerSiteID = ConfigurationManager.AppSettings["ServiceDottIntegrationIDs"];

        public static string ExternalApplicationLinkGet(string applicationURL, string email, string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(PeopleProfilerSiteID) && PeopleProfilerSiteID.Contains(" " + SessionData.Site.SiteId + " "))
            {
                //if logged in user
                if (!string.IsNullOrEmpty(email))
                {
                    string encrpyedEmail = HttpUtility.UrlEncode(CommonService.EncryptTripleDES(email, EncrpytionKey));
                    string encrpyedFName = HttpUtility.UrlEncode(CommonService.EncryptTripleDES(firstName, EncrpytionKey));
                    string encrpyedLName = HttpUtility.UrlEncode(CommonService.EncryptTripleDES(lastName, EncrpytionKey));

                    if (applicationURL.Contains("?"))
                        return string.Format("{0}&e={1}&f={2}&l={3}", applicationURL, encrpyedEmail, encrpyedFName, encrpyedLName);
                    else
                        return string.Format("{0}?e={1}&f={2}&l={3}", applicationURL, encrpyedEmail, encrpyedFName, encrpyedLName);

                    //if (applicationURL.Contains("?"))
                    //    return string.Format("{0}&e={1}&f={2}&l={3}&d={4}", applicationURL, encrpyedEmail, encrpyedFName, encrpyedLName, DateTime.Now.Ticks);
                    //else
                    //    return string.Format("{0}?e={1}&f={2}&l={3}&d={4}", applicationURL, encrpyedEmail, encrpyedFName, encrpyedLName, DateTime.Now.Ticks);
                }
            }

            return applicationURL;
        }

        public static string Encrypt(string input)
        {
            return CommonService.EncryptTripleDES(input, EncrpytionKey);
        }

        public static string Decrypt(string input)
        {
            return CommonService.DecryptTripleDES(input, EncrpytionKey);
        }

        public static string RegisterMember(string encryptedEmail, string encryptedFirstName, string encryptedLastName)
        {
            if (!string.IsNullOrWhiteSpace(PeopleProfilerSiteID) && PeopleProfilerSiteID.Contains(" " + SessionData.Site.SiteId + " "))
            {
                if (string.IsNullOrEmpty(encryptedEmail))
                    return "e parameter can not be empty";
                if (string.IsNullOrEmpty(encryptedFirstName))
                    return "f parameter can not be empty";
                if (string.IsNullOrEmpty(encryptedLastName))
                    return "l parameter can not be empty";

                MembersService member_service = new MembersService();
                string decryptedEmail = string.Empty;
                bool emailFormatValid = EmailDecrypt(encryptedEmail, out decryptedEmail);
                string decryptedFirstName = ServiceDottIntegration.Decrypt(encryptedFirstName);
                string decryptedLastName = ServiceDottIntegration.Decrypt(encryptedLastName);

                //decrypt error check
                if (string.IsNullOrEmpty(decryptedFirstName))
                    return "First name could not be decrypted";

                //decrypt error check
                if (string.IsNullOrEmpty(encryptedLastName))
                    return "Last name could not be decrypted";

                //decrypt error check
                if (emailFormatValid)
                {
                    bool emailValid = EmailAddressValid(member_service, decryptedEmail);

                    if (emailValid)
                    {
                        //string registerResult = RegisterMemberToDatabase(member_service, decryptedEmail, decryptedFirstName, decryptedLastName);

                        //return registerResult;
                        return "Email address not found";
                    }
                    else
                        return "Email address already exists";
                }
                else
                    return "Email address format invalid";
            }
            else
                return "";
        }

        public static bool EmailDecrypt(string encryptedEmail, out string actualEmail)
        {
            string decryptedEmail = ServiceDottIntegration.Decrypt(encryptedEmail);

            string email_regEx = @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$";
            Regex regex = new Regex(email_regEx);
            Match emailMatch = regex.Match(decryptedEmail);

            actualEmail = decryptedEmail;

            if (emailMatch.Success)
                return true;
            else
                return false;
        }

        private static bool EmailAddressValid(MembersService service, string email)
        {
            bool emailValid = false;
            using (JXTPortal.Entities.Members thisMember = service.GetBySiteIdEmailAddress(SessionData.Site.SiteId, email))
            {
                if (thisMember == null)
                    emailValid = true;
            }
            return emailValid;
        }
        /*
        private static string RegisterMemberToDatabase(MembersService service, string email, string firstName, string lastName)
        {
            try
            {
                using (JXTPortal.Entities.Members objMembers = new JXTPortal.Entities.Members())
                {
                    objMembers.SiteId = SessionData.Site.SiteId;
                    objMembers.FirstName = firstName.Trim();
                    objMembers.Surname = lastName.Trim();
                    objMembers.EmailAddress = email.Trim();
                    objMembers.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                    objMembers.Username = email.Trim();

                    int siteDefaultCountryID = 1;
                    GlobalSettingsService gs = new GlobalSettingsService();
                    using (TList<GlobalSettings> gslist = gs.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (gslist.Count > 0)
                        {
                            if (gslist[0].DefaultCountryId.HasValue)
                            {
                                siteDefaultCountryID = gslist[0].DefaultCountryId.Value;
                            }
                        }
                    }

                    objMembers.CountryId = siteDefaultCountryID;
                    string newPassword = System.Web.Security.Membership.GeneratePassword(10, 0);
                    objMembers.Password = CommonService.EncryptMD5(newPassword);
                    objMembers.ValidateGuid = Guid.NewGuid();
                    objMembers.SearchField = String.Format("{0} {1}", objMembers.FirstName, objMembers.Surname);
                    service.Insert(objMembers);

                    //Send confirmation email
                    MailService.SendMemberRegistration(objMembers, newPassword);

                    //jobAlert.MemberId = objMembers.MemberId;
                    //jobAlert.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                }

                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }*/

    }
}
