using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using JXTPortal.EmailSender;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;

using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Service.Dapper;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;
using JXTPortal.Service.Dapper.Models;

namespace JXTPortal
{
    public static class MailService
    {
        static string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];

        public static IJobApplicationScreeningAnswersService JobApplicationScreeningAnswersService { get; set; }
        public static IFileManager FileManagerService { get; set; }

        private static string coverLetterFolder;
        private static string resumeFolder;
        private static string customFolder;

        static MailService()
        {
            if (SessionData.Site == null || !SessionData.Site.IsUsingS3)
            {
                coverLetterFolder = ConfigurationManager.AppSettings["FTPJobApplyCoverLetterUrl"];
                resumeFolder = ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"];
                customFolder = ConfigurationManager.AppSettings["FTPCustomJobApplications"];

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                coverLetterFolder = ConfigurationManager.AppSettings["AWSS3CoverLetterPath"];
                resumeFolder = ConfigurationManager.AppSettings["AWSS3ResumePath"];
                customFolder = ConfigurationManager.AppSettings["AWSS3CustomJobApplicationsPath"];
            }
        }

        public static void SetJobApplicationScreeningAnswers(IJobApplicationScreeningAnswersService container)
        {
            JobApplicationScreeningAnswersService = container;
        }

        public static void Send(string fromTo, string to, string subject, string message)
        {
            EmailSender().Send(fromTo, to, subject, message);
        }

        public static void SendTestEmail(string toEmail, string subject, string body, string bouncebackemail, bool sendHTML)
        {
            if (!sendHTML)
            {
                Message message = new Message();

                message.Format = Format.Text;
                message.Body = body;
                message.From = new MailAddress("info@jxt.com.au", string.Empty);
                message.Subject = subject;
                message.To = new MailAddress(toEmail, string.Empty);

                EmailSender().Send(message, bouncebackemail);
            }
            else
            {
                Message message = new Message();

                message.Format = Format.Html;
                message.Body = body;
                message.From = new MailAddress("info@jxt.com.au", string.Empty);
                message.Subject = subject;
                message.To = new MailAddress(toEmail, string.Empty);

                EmailSender().Send(message, bouncebackemail);
            }
        }

        public static void SendEnquiryEmail(Entities.Enquiries enquiry, int languageid)
        {
            //{Site}
            //{Name}
            //{Email}
            //{ContactPhone}
            //{Content}
            //{Date}
            //{IpAddress}

            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("ENQUIRY", languageid);
            if (emailtemplate != null)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                Entities.Sites site = _SitesService().GetBySiteId(SessionData.Site.SiteId);
                string siteurl = GetSiteUrl();
                string sitename = site.SiteName;

                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["Site"] = sitename;
                colemailfields["Name"] = enquiry.Name;
                colemailfields["Email"] = enquiry.Email;
                colemailfields["ContactPhone"] = enquiry.ContactPhone;
                colemailfields["Content"] = enquiry.Content;
                colemailfields["Date"] = enquiry.Date.ToString("dd/MM/yyyy");
                colemailfields["IpAddress"] = enquiry.IpAddress;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = Format.Html;
                message.Body = emailtemplate.EmailBodyHtml;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(enquiry.Email, enquiry.Name);

                EmailSender().Send(message);
            }

        }

        /// <summary>
        /// Email send to advertiser to validate the registration
        /// </summary>
        /// <param name="advertiseruser"></param>
        public static void SendAdvertiserRegistration(JXTPortal.Entities.AdvertiserUsers advertiseruser)
        {
            int languageid = (advertiseruser.DefaultLanguageId.HasValue) ? advertiseruser.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;
            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("ADVVALIDATION", languageid);
            if (emailtemplate != null)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();
                string validateurl = "http://" + siteurl + "/advertiser/validate.aspx?user=" + System.Web.HttpUtility.UrlPathEncode(advertiseruser.UserName) + "&validationid=" + advertiseruser.ValidateGuid.ToString();

                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["FIRSTNAME"] = advertiseruser.FirstName;
                colemailfields["LASTNAME"] = advertiseruser.Surname;
                colemailfields["USERNAME"] = advertiseruser.UserName;
                colemailfields["EMAILADDRESS"] = advertiseruser.Email;
                colemailfields["VALIDATEURL"] = validateurl;
                colemailfields["ADVERTISERID"] = advertiseruser.AdvertiserId;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = (Format)advertiseruser.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(advertiseruser.Email, advertiseruser.FirstName + " " + advertiseruser.Surname);

                EmailSender().Send(message);
            }
        }
        /// <summary>
        /// Email send to assigned admin email for advertiser registered notification
        /// </summary>
        /// <param name="advertiseruser"></param>
        /// <param name="advertiser"></param>
        public static void SendNewAdvertiserAlert(JXTPortal.Entities.AdvertiserUsers advertiseruser, JXTPortal.Entities.Advertisers advertiser)
        {
            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("NEWADVALERT", SessionData.Site.DefaultEmailLanguageId);
            if (emailtemplate != null && string.IsNullOrWhiteSpace(emailtemplate.EmailAddressTo) == false)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();

                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["FIRSTNAME"] = advertiseruser.FirstName;
                colemailfields["LASTNAME"] = advertiseruser.Surname;
                colemailfields["USERNAME"] = advertiseruser.UserName;
                colemailfields["EMAILADDRESS"] = advertiseruser.Email;
                colemailfields["ADVERTISERID"] = advertiseruser.AdvertiserId;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();

                colemailfields["COMPANYNAME"] = advertiser.CompanyName;
                colemailfields["BUSINESSNO"] = advertiser.BusinessNumber;
                colemailfields["STREETADDRESS1"] = advertiser.StreetAddress1;
                colemailfields["STREETADDRESS2"] = advertiser.StreetAddress2;
                colemailfields["POSTALADDRESS1"] = advertiser.PostalAddress1;
                colemailfields["POSTALADDRESS2"] = advertiser.PostalAddress2;
                colemailfields["WEBADDRESS"] = advertiser.PostalAddress2;
                colemailfields["PROFILE"] = advertiser.Profile;
                colemailfields["ACCOUNTPAYABLEEMAIL"] = advertiser.AccountsPayableEmail;
                if (string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl))
                {
                    colemailfields["ADVERTIERLOGO"] = (advertiser.AdvertiserLogo != null && advertiser.AdvertiserLogo.Length > 0) ? string.Format("<img src=\"data:image/jpeg;base64,{0}\" />", Convert.ToBase64String(advertiser.AdvertiserLogo)) : string.Empty;
                }
                else
                {
                    string imgurl = string.Empty;

                    imgurl = string.Format("{0}{1}/media/{2}/{3}", (HttpContext.Current.Request.IsSecureConnection) ? "https://" : "http://", siteurl, ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserLogoUrl);

                    colemailfields["ADVERTIERLOGO"] = string.Format("<img src=\"{0}\" />", imgurl);
                }

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = (Format)advertiseruser.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(emailtemplate.EmailAddressTo);

                EmailSender().Send(message);
            }
        }

        /// <summary>
        /// Email send to Primary Advertiser User when Advertiser status is changed and confirmed by admin
        /// </summary>
        /// <param name="advertiseruser"></param>
        /// <param name="advertiser"></param>
        /// <param name="status"></param>
        public static void SendAdvertiserUpdateStatus(JXTPortal.Entities.AdvertiserUsers advertiseruser, JXTPortal.Entities.Advertisers advertiser, string status)
        {
            int languageid = (advertiseruser.DefaultLanguageId.HasValue) ? advertiseruser.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;
            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("ADVUPDATESTATUS", languageid);
            if (emailtemplate != null)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();

                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["FIRSTNAME"] = advertiseruser.FirstName;
                colemailfields["LASTNAME"] = advertiseruser.Surname;
                colemailfields["USERNAME"] = advertiseruser.UserName;
                colemailfields["EMAILADDRESS"] = advertiseruser.Email;
                colemailfields["ADVERTISERID"] = advertiseruser.AdvertiserId;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();

                colemailfields["COMPANYNAME"] = advertiser.CompanyName;
                colemailfields["BUSINESSNO"] = advertiser.BusinessNumber;
                colemailfields["STREETADDRESS1"] = advertiser.StreetAddress1;
                colemailfields["STREETADDRESS2"] = advertiser.StreetAddress2;
                colemailfields["POSTALADDRESS1"] = advertiser.PostalAddress1;
                colemailfields["POSTALADDRESS2"] = advertiser.PostalAddress2;
                colemailfields["WEBADDRESS"] = advertiser.PostalAddress2;
                colemailfields["PROFILE"] = advertiser.Profile;
                colemailfields["STATUS"] = status;
                colemailfields["ACCOUNTPAYABLEEMAIL"] = advertiser.AccountsPayableEmail;
                if (string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl))
                {
                    colemailfields["ADVERTIERLOGO"] = (advertiser.AdvertiserLogo != null && advertiser.AdvertiserLogo.Length > 0) ? string.Format("<img src=\"data:image/jpeg;base64,{0}\" />", Convert.ToBase64String(advertiser.AdvertiserLogo)) : string.Empty;
                }
                else
                {
                    string imgurl = string.Empty;

                    imgurl = string.Format("{0}{1}/media/{2}/{3}", (HttpContext.Current.Request.IsSecureConnection) ? "https://" : "http://", siteurl, ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserLogoUrl);

                    colemailfields["ADVERTIERLOGO"] = string.Format("<img src=\"{0}\" />", imgurl);
                }


                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = (Format)advertiseruser.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(advertiseruser.Email);

                EmailSender().Send(message);
            }
        }

        /// <summary>
        /// Email send to assigned admin email when a job is created
        /// </summary>
        /// <param name="job"></param>
        /// <param name="advertiseremail"></param>
        public static void SendNewJobCreated(Entities.Jobs job, string advertiseremail, int languageid)
        {
            //{COMPANYNAME}{ADVERTISERID}{EMAIL}{JOBID}{JOBTITLE}{JOBDESCRIPTION}{JOBURL}
            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("NEWJOBCREATED", languageid);
            if (emailtemplate != null)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();

                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                colemailfields["COMPANYNAME"] = job.CompanyName;
                colemailfields["ADVERTISERID"] = job.AdvertiserId;
                colemailfields["EMAIL"] = advertiseremail;
                colemailfields["JOBID"] = job.JobId;
                colemailfields["JOBTITLE"] = job.JobName;
                colemailfields["JOBDESCRIPTION"] = job.Description;
                colemailfields["JOBEDITURL"] = string.Format("http://{0}/admin/default.aspx", siteurl);
                //string.Format("http://{0}/admin/jobsedit.aspx?jobid={1}&advertiserid={2}", siteurl, job.JobId, job.AdvertiserId);

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = Format.Html;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;

                // Don't send an email if there no email address set.
                if (!string.IsNullOrWhiteSpace(emailtemplate.EmailAddressTo))
                {
                    message.To = new MailAddress(emailtemplate.EmailAddressTo, emailtemplate.EmailAddressToName);

                    EmailSender().Send(message);
                }
            }
        }

        /// <summary>
        /// Email send to advertiser user on job status updated
        /// </summary>
        /// <param name="job"></param>
        /// <param name="advertiseremail"></param>
        /// <param name="status"></param>
        public static void SendAdvertiserJobStatusResult(Entities.Jobs job, string advertiseremail, string status, int languageid)
        {
            //{COMPANYNAME}{ADVERTISERID}{EMAIL}{JOBID}{JOBTITLE}{JOBDESCRIPTION}{JOBURL}
            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("ADVJOBSTATUSRESULT", languageid);
            if (emailtemplate != null)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();

                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                colemailfields["COMPANYNAME"] = job.CompanyName;
                colemailfields["ADVERTISERID"] = job.AdvertiserId;
                colemailfields["EMAIL"] = advertiseremail;
                colemailfields["JOBID"] = job.JobId;
                colemailfields["JOBTITLE"] = job.JobName;
                colemailfields["JOBDESCRIPTION"] = job.Description;
                colemailfields["JOBEDITURL"] = "http://" + siteurl + "/advertiser/jobcreate.aspx?jobid=" + job.JobId;
                colemailfields["STATUS"] = status;

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = Format.Html;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(advertiseremail);

                EmailSender().Send(message);
            }
        }

        public static void SendNewJobApplicationAccount(JXTPortal.Entities.Members member, string password)
        {
            int languageid = (member.DefaultLanguageId.HasValue) ? member.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;

            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("JOBAPPACC", languageid);
            if (emailtemplate != null)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();

                string validateurl = "http://" + siteurl + "/member/default.aspx";

                colemailfields["FIRSTNAME"] = member.FirstName;
                colemailfields["SURNAME"] = member.Surname;
                colemailfields["EMAILADDRESS"] = member.EmailAddress;
                colemailfields["PASSWORD"] = password;
                colemailfields["MEMBERACCOUNTURL"] = validateurl;
                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = (Format)member.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(member.EmailAddress, member.FirstName + " " + member.Surname);

                EmailSender().Send(message);
            }
        }

        public static void SendMemberRegistration(JXTPortal.Entities.Members member, string password)
        {
            int langageid = 1;
            int siteid = member.SiteId;
            GlobalSettingsService gservice = new GlobalSettingsService();
            using (TList<GlobalSettings> gss = gservice.GetBySiteId(SessionData.Site.SiteId))
            {
                if (gss.Count > 0)
                {
                    if (gss[0].DefaultEmailLanguageId.HasValue)
                    {
                        langageid = gss[0].DefaultEmailLanguageId.Value;
                    }
                }
            }

            // Get email template from the referring site instead of the member site. (ENWORLD)
            if (member.ReferringSiteId.HasValue)
            {
                siteid = member.ReferringSiteId.Value;
            }

            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("CANDVALIDATION", siteid, (member.DefaultLanguageId.HasValue) ? member.DefaultLanguageId.Value : langageid);
            if (emailtemplate != null)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();
                string validateurl = "http://" + siteurl + "/member/validate.aspx?user=" + System.Web.HttpUtility.UrlPathEncode(member.Username) + "&validationid=" + member.ValidateGuid.ToString();

                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["MEMBERID"] = member.MemberId;
                colemailfields["FIRSTNAME"] = member.FirstName;
                colemailfields["LASTNAME"] = member.Surname;
                colemailfields["USERNAME"] = member.Username;
                colemailfields["EMAILADDRESS"] = member.EmailAddress;
                colemailfields["VALIDATEURL"] = validateurl;
                colemailfields["PASSWORD"] = password;
                colemailfields["SiteID"] = siteid.ToString();

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = (Format)member.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(member.EmailAddress, member.FirstName + " " + member.Surname);

                EmailSender().Send(message);
            }
        }

        public static void SendMemberRegistrationToSiteAdmin(JXTPortal.Entities.Members member, string classification, string subclassification, List<HttpPostedFile> files, string strTo)
        {
            int languageid = (member.DefaultLanguageId.HasValue) ? member.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;
            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("CANDREGNOTIFICATION", languageid);
            if (emailtemplate != null)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();

                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["MEMBERFIRSTNAME"] = member.FirstName;
                colemailfields["MEMBERLASTNAME"] = member.Surname;
                colemailfields["MEMBERUSERNAME"] = member.Username;
                colemailfields["MEMBEREMAILADDRESS"] = member.EmailAddress;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                colemailfields["SiteEmailAddress"] = Convert.ToString(strTo.Split(new char[] { ';' })[0]);
                colemailfields["Classifcation"] = classification;
                colemailfields["Subclassifcation"] = subclassification;
                colemailfields["PhoneNumber"] = member.HomePhone;
                colemailfields["Address"] = member.Address1;

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = (Format)member.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(strTo.Split(new char[] { ';' })[0]);

                if (files.Count > 0)
                {
                    foreach (HttpPostedFile file in files)
                    {
                        file.InputStream.Seek(0, SeekOrigin.Begin); //reset stream position
                        message.Attachments.Add(new MessageAttachment(file.FileName, MediaTypeNames.Application.Octet, file.InputStream));
                    }
                }

                if (strTo.Split(new char[] { ';' }).Length > 1)
                {
                    message.Cc = Convert.ToString(strTo.Split(new char[] { ';' })[1]);
                }


                EmailSender().Send(message);
            }

        }

        public static void SendMemberUploadResumeToSiteAdmin(JXTPortal.Entities.Members member, List<HttpPostedFile> files)
        {
            int languageid = (member.DefaultLanguageId.HasValue) ? member.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;
            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("CANDUPLOADNOTIFICATION", languageid);
            if (emailtemplate != null && !string.IsNullOrWhiteSpace(emailtemplate.EmailAddressTo))
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();

                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["MEMBERFIRSTNAME"] = member.FirstName;
                colemailfields["MEMBERLASTNAME"] = member.Surname;
                colemailfields["MEMBERUSERNAME"] = member.Username;
                colemailfields["MEMBEREMAILADDRESS"] = member.EmailAddress;
                colemailfields["MEMBEREXTERNALID"] = string.IsNullOrEmpty(member.ExternalMemberId) ? "N/A" : member.ExternalMemberId;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                colemailfields["SiteEmailAddress"] = Convert.ToString(emailtemplate.EmailAddressTo.Split(new char[] { ';' })[0]);

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = (Format)member.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(emailtemplate.EmailAddressTo.Split(new char[] { ';' })[0]);
                message.Cc = emailtemplate.EmailAddressCc;

                if (files.Count > 0)
                {
                    foreach (HttpPostedFile file in files)
                    {
                        file.InputStream.Seek(0, SeekOrigin.Begin); //reset stream position
                        message.Attachments.Add(new MessageAttachment(file.FileName, MediaTypeNames.Application.Octet, file.InputStream));
                    }
                }

                /*if (strTo.Split(new char[] { ';' }).Length > 1)
                {
                    message.Cc = Convert.ToString(strTo.Split(new char[] { ';' })[1]);
                }*/


                EmailSender().Send(message);
            }

        }

        public static void SendMemberJobApplicationEmail(JXTPortal.Entities.Members member)
        {
            int languageid = (member.DefaultLanguageId.HasValue) ? member.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;

            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("JOBNOTICE4MBR", languageid);

            if (emailtemplate != null)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                string siteurl = GetSiteUrl();
                string strJobTrackURL = "http://" + siteurl + "/member/applicationtracker.aspx";

                colemailfields["FIRSTNAME"] = member.FirstName;
                colemailfields["VIEWTRACKER"] = strJobTrackURL;
                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["RATEADVERTISER"] = strJobTrackURL;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = (Format)member.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.Subject = emailtemplate.EmailSubject;
                message.To = new MailAddress(member.EmailAddress, member.FirstName + " " + member.Surname);

                EmailSender().Send(message);
            }
        }

        public static void SendFriendJobEmail(string SenderName, string SenderEmail, string FriendName, string FriendEmail, string JobMessage, string JobTitle, string JobUrl, int languageid)
        {
            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("JOBFDMESSAGE", languageid);
            SenderName = HttpUtility.HtmlEncode(SenderName);
            FriendName = HttpUtility.HtmlEncode(FriendName);
            JobMessage = HttpUtility.HtmlEncode(JobMessage);
            JobTitle = HttpUtility.HtmlEncode(JobTitle);


            if (emailtemplate != null)
            {
                string siteurl = GetSiteUrl();

                ArrayList fdemails = new ArrayList();
                ArrayList fdnames = new ArrayList();

                string[] friendemails = FriendEmail.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string friendemail in friendemails)
                {
                    if (!string.IsNullOrEmpty(friendemail.Trim()))
                    {
                        fdemails.Add(friendemail.Trim());
                    }
                }

                string[] friendenames = FriendName.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string friendname in friendenames)
                {
                    if (!string.IsNullOrEmpty(friendname.Trim()))
                    {
                        fdnames.Add(friendname.Trim());
                    }
                }

                for (int i = 0; i < fdemails.Count; i++)
                {
                    Message message = new Message();
                    HybridDictionary colemailfields = new HybridDictionary();

                    message.From = new MailAddress(SenderEmail, SenderName);
                    string ToName = "";

                    if (i < fdnames.Count)
                    {
                        ToName = fdnames[i].ToString();
                    }
                    message.Bcc = emailtemplate.EmailAddressBcc;
                    message.To = new MailAddress(fdemails[i].ToString(), ToName);
                    colemailfields["FRIENDNAME"] = (ToName == "") ? "Friend" : ToName;
                    colemailfields["SENDERNAME"] = SenderName;
                    colemailfields["SENDEREMAIL"] = SenderEmail;
                    colemailfields["JOBURL"] = "http://" + siteurl + (JobUrl.Substring(0, 1) != "/" ? "/" : string.Empty) + JobUrl;
                    colemailfields["JOBTITLE"] = JobTitle;
                    colemailfields["JOBMESSAGE"] = JobMessage;
                    colemailfields["URLSUFFIX"] = siteurl;
                    colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                    message.Format = Format.Html;
                    message.Body = emailtemplate.EmailBodyHtml;
                    message.Fields = colemailfields;
                    message.Subject = emailtemplate.EmailSubject;

                    EmailSender().Send(message);
                }
            }
        }

        public static void SendMemberJobEmail(string ToName, string ToEmail, string JobTitle, string JobUrl, int EmailFormat, int languageid)
        {
            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("JOBMBRMESSAGE", languageid);
            ToName = HttpUtility.HtmlEncode(ToName);
            JobTitle = HttpUtility.HtmlEncode(JobTitle);

            if (emailtemplate != null)
            {
                string siteurl = GetSiteUrl();


                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();

                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.To = new MailAddress(ToEmail, ToName);
                colemailfields["MEMBERNAME"] = ToName;
                colemailfields["JOBURL"] = "http://" + siteurl + JobUrl;
                colemailfields["JOBTITLE"] = JobTitle;
                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                message.Format = (Format)EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Fields = colemailfields;
                message.Subject = emailtemplate.EmailSubject;
                EmailSender().Send(message);
            }
        }

        public static void SendAdvertiserJobApplicationEmail(JXTPortal.Entities.Members member, JXTPortal.Entities.JobApplication jobapp, HybridDictionary customEmailFields, int siteid, string jobapplicationemail = "")
        {
            SendAdvertiserJobApplicationEmail(member, jobapp,
                System.Configuration.ConfigurationManager.AppSettings["ApplicationUploadCoverLetterPaths"],
                System.Configuration.ConfigurationManager.AppSettings["ApplicationUploadResumePaths"], customEmailFields, siteid, jobapplicationemail);
        }

        public static void SendAdvertiserJobApplicationEmail(JXTPortal.Entities.Members member, JXTPortal.Entities.JobApplication jobapp,
                                                                string coverletteruploadpath, string resumeuploadpath, HybridDictionary customEmailFields, int siteid, string jobapplicationemail = "")
        {
            int languageid = 1;
            try
            {
                JobsService service = new JobsService();
                System.Data.DataSet ds = service.GetByJobId(jobapp.JobId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int advuserid = Convert.ToInt32(ds.Tables[0].Rows[0]["EnteredByAdvertiserUserID"]);
                    AdvertiserUsersService advuserservice = new AdvertiserUsersService();
                    Entities.AdvertiserUsers advuser = advuserservice.GetByAdvertiserUserId(advuserid);
                    if (advuser.DefaultLanguageId.HasValue)
                    {
                        languageid = advuser.DefaultLanguageId.Value;
                    }
                }
            }
            catch
            {
                return;
            }

            // int languageid = (advertiseruser.DefaultLanguageId.HasValue) ? advertiseruser.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;

            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("JOBNOTICE4ADT", siteid, languageid);

            bool useFTP = (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"]));

            // Checking if the Email Template Exists - Job Application has Job in it
            if (emailtemplate != null && jobapp.JobId.HasValue)
            {
                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();
                Entities.Sites site = _SitesService().GetBySiteId(siteid);
                string siteurl = GetSiteUrl();
                string sitename = site.SiteName;

                JobsService jobs = new JobsService();
                JXTPortal.Entities.Jobs job = jobs.GetByJobId(jobapp.JobId.Value);

                // Screening Questions
                StringBuilder screeingQuestionsAttachment = new StringBuilder();
                StringBuilder screeingQuestionsContent = new StringBuilder();

                JobApplicationScreeningAnswerDetail jobApplicationScreeningAnswerDetail = JobApplicationScreeningAnswersService.SelectByJobApplicationId(jobapp.JobApplicationId);
                if (jobApplicationScreeningAnswerDetail.JobApplicationScreeningAnswers.Count > 0)
                {
                    screeingQuestionsAttachment.AppendLine(string.Format("JobTitle: {0}", job.JobName));
                    screeingQuestionsAttachment.AppendLine(string.Format("Applicant Name: {0} {1}", member.FirstName, member.Surname));
                    screeingQuestionsAttachment.AppendLine(string.Format("Applicant Email: {0}", member.EmailAddress));
                    screeingQuestionsAttachment.AppendLine(string.Format("Date: {0}", jobapp.ApplicationDate.Value.ToString("dd/MM/yyyy")));
                    screeingQuestionsAttachment.AppendLine("\nAnswer\n");

                    foreach (JobApplicationScreeningAnswer answer in jobApplicationScreeningAnswerDetail.JobApplicationScreeningAnswers)
                    {
                        screeingQuestionsAttachment.AppendLine(string.Format("Q. {0}", answer.QuestionTitle));
                        screeingQuestionsAttachment.AppendLine(string.Format("A. {0}\n", answer.Answer));

                        screeingQuestionsContent.AppendLine(string.Format("<strong>Q. {0}</strong><br />", HttpUtility.HtmlEncode(answer.QuestionTitle)));
                        screeingQuestionsContent.AppendLine(string.Format("A. {0}<br /><br />", HttpUtility.HtmlEncode(answer.Answer)));
                    }
                }

                // Use custom jobapplication email address if it has value (for job tracking), otherwise uses email provided in job detail
                if (string.IsNullOrWhiteSpace(jobapplicationemail))
                {
                    jobapplicationemail = job.ApplicationEmailAddress;
                }

                AdvertisersService advs = new AdvertisersService();
                JXTPortal.Entities.Advertisers adv = advs.GetByAdvertiserId((int)job.AdvertiserId);

                colemailfields["COMPANYNAME"] = adv.CompanyName;
                colemailfields["FIRSTNAME"] = member.FirstName;
                colemailfields["LASTNAME"] = member.Surname;
                colemailfields["VIEWDESK"] = "http://" + siteurl + "/advertiser/jobtracker.aspx";
                colemailfields["JOBTITLE"] = job.JobName;
                colemailfields["REFNO"] = job.RefNo;
                colemailfields["EMAIL"] = member.EmailAddress;
                colemailfields["MEMBERPHONE"] = member.MobilePhone;
                //colemailfields["ADVERTISERUSERNAME"] = advertiseruser.UserName;
                colemailfields["ADVERTISERUSERNAME"] = adv.CompanyName;
                colemailfields["ADVERTISEREMAIL"] = job.ApplicationEmailAddress;
                colemailfields["JOBLOCATION"] = ""; // Todo Add Job Location
                colemailfields["SHORTDESCRIPTION"] = job.Description;
                colemailfields["DATEPOSTED"] = job.DatePosted.ToShortDateString();
                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["SiteID"] = siteid.ToString();
                colemailfields["SCREENINGQUESTIONS"] = "http://" + siteurl + "/advertiser/jobtracker.aspx?JobId=" + job.JobId; // Todo Add Job Location
                colemailfields["SCREENINGQUESTIONANSWERS"] = screeingQuestionsContent.ToString();
                //colemailfields["EXTERNALJOBID"] = job.JobExternalId;

                // New fields added
                colemailfields["SiteName"] = sitename;
                colemailfields["URLREFERRAL"] = jobapp.UrlReferral;
                colemailfields["EXTERNALJOBID"] = job.JobExternalId;

                // Replace Custom Fields 
                if (customEmailFields != null && customEmailFields.Count > 0)
                {
                    foreach (DictionaryEntry de in customEmailFields)
                    {
                        colemailfields.Add(de.Key, de.Value);
                    }
                }

                if (!string.IsNullOrEmpty(jobapp.MemberCoverLetterFile))
                {
                    Stream downloadedfile = null;
                    string errormessage = string.Empty;

                    downloadedfile = FileManagerService.DownloadFile(bucketName, coverLetterFolder, jobapp.MemberCoverLetterFile, out errormessage);

                    if (string.IsNullOrEmpty(errormessage) && downloadedfile.Length > 0)
                    {
                        string contenttype = MediaTypeNames.Application.Octet;

                        MessageAttachment clAttachment = new MessageAttachment(jobapp.MemberCoverLetterFile, contenttype, new MemoryStream(((MemoryStream)downloadedfile).ToArray()));
                        message.Attachments.Add(clAttachment);
                        downloadedfile.Dispose();
                    }
                }

                if (!string.IsNullOrEmpty(jobapp.MemberResumeFile))
                {
                    Stream downloadedfile = null;
                    string errormessage = string.Empty;

                    downloadedfile = FileManagerService.DownloadFile(bucketName, resumeFolder, jobapp.MemberResumeFile, out errormessage);

                    if (string.IsNullOrEmpty(errormessage) && downloadedfile.Length > 0)
                    {
                        string contenttype = MediaTypeNames.Application.Octet;

                        MessageAttachment resumeAttachment = new MessageAttachment(jobapp.MemberResumeFile, contenttype, new MemoryStream(((MemoryStream)downloadedfile).ToArray()));
                        message.Attachments.Add(resumeAttachment);
                    }
                }

                // PDF Attachment
                if (!string.IsNullOrEmpty(jobapp.ExternalPdfFilename))
                {
                    Stream downloadedfile = null;
                    string errormessage = string.Empty;

                    downloadedfile = FileManagerService.DownloadFile(bucketName, customFolder, jobapp.MemberCoverLetterFile, out errormessage);

                    if (string.IsNullOrEmpty(errormessage) && downloadedfile.Length > 0)
                    {
                        MessageAttachment clAttachment = new MessageAttachment(jobapp.ExternalPdfFilename, MediaTypeNames.Application.Pdf, new MemoryStream(((MemoryStream)downloadedfile).ToArray()));
                        message.Attachments.Add(clAttachment);
                        downloadedfile.Dispose();
                    }
                }

                if (screeingQuestionsAttachment.Length > 0)
                {
                    string screeingQuestionsString = screeingQuestionsAttachment.ToString();
                    byte[] screeingQuestionsByteArray = System.Text.Encoding.UTF8.GetBytes(screeingQuestionsString);
                    MemoryStream screeingQuestionsStream = new MemoryStream(screeingQuestionsByteArray);

                    MessageAttachment screeningQuestionsAttachment = new MessageAttachment("ScreeningQuestion.txt", MediaTypeNames.Text.Plain, screeingQuestionsStream);
                    message.Attachments.Add(screeningQuestionsAttachment);
                }

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.Format = (Format)member.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Cc = emailtemplate.EmailAddressCc;
                message.Fields = colemailfields;
                message.From = new MailAddress(member.EmailAddress, member.FirstName + " " + member.Surname);
                message.Subject = emailtemplate.EmailSubject.Replace("{URLSUFFIX}", siteurl);
                message.To = new MailAddress(jobapplicationemail);

                EmailSender().Send(message);
            }
        }

        public static void SendAdvertiserForgottenPasswordEmail(JXTPortal.Entities.AdvertiserUsers advertiseruser)
        {
            int languageid = (advertiseruser.DefaultLanguageId.HasValue) ? advertiseruser.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;

            JXTPortal.Entities.EmailTemplates emailtemplate = GetEmailTemplate("ADVFORGOTTENPWD", languageid);

            if (emailtemplate != null)
            {
                string siteurl = GetSiteUrl();


                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();

                message.Bcc = emailtemplate.EmailAddressBcc;
                message.From = new MailAddress(emailtemplate.EmailAddressFrom, emailtemplate.EmailAddressName);
                message.To = new MailAddress(advertiseruser.Email, advertiseruser.FirstName + " " + advertiseruser.Surname);
                colemailfields["FIRSTNAME"] = advertiseruser.FirstName;
                colemailfields["SURNAME"] = advertiseruser.Surname;
                colemailfields["USERNAME"] = advertiseruser.UserName;
                colemailfields["CONFIRMLINK"] = string.Format("http://{0}/advertiser/confirmresetpassword.aspx?advertiseruserid={1}&key={2}", siteurl, advertiseruser.AdvertiserUserId, advertiseruser.ValidateGuid.ToString());
                colemailfields["URLSUFFIX"] = siteurl;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                message.Format = (Format)advertiseruser.EmailFormat;
                message.Body = (message.Format == Format.Html) ? emailtemplate.EmailBodyHtml : emailtemplate.EmailBodyText;
                message.Fields = colemailfields;
                message.Subject = emailtemplate.EmailSubject;

                EmailSender().Send(message);
            }
        }

        public static void SendMemberForgottenPasswordEmail(JXTPortal.Entities.Members member)
        {
            int languageid = (member.DefaultLanguageId.HasValue) ? member.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;
            JXTPortal.Entities.EmailTemplates memberEmailtemplate = GetEmailTemplate("CANDFORGOTTENPWD", languageid);

            if (memberEmailtemplate != null)
            {
                string siteUrl = GetSiteUrl();

                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();

                message.Bcc = memberEmailtemplate.EmailAddressBcc;
                message.From = new MailAddress(memberEmailtemplate.EmailAddressFrom, memberEmailtemplate.EmailAddressName);
                message.To = new MailAddress(member.EmailAddress, member.FirstName + " " + member.Surname);
                colemailfields["FIRSTNAME"] = member.FirstName;
                colemailfields["SURNAME"] = member.Surname;
                colemailfields["USERNAME"] = member.Username;
                colemailfields["CONFIRMLINK"] = string.Format("http://{0}/member/confirmresetpassword.aspx?memberid={1}&key={2}",
                                                                siteUrl, member.MemberId, member.ValidateGuid.ToString());
                colemailfields["URLSUFFIX"] = siteUrl;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                message.Format = (Format)member.EmailFormat;
                message.Body = (message.Format == Format.Html) ? memberEmailtemplate.EmailBodyHtml : memberEmailtemplate.EmailBodyText;
                message.Fields = colemailfields;
                message.Subject = memberEmailtemplate.EmailSubject;

                EmailSender().Send(message);
            }
        }

        public static void SendPaymentConfirmationEmail(JXTPortal.Entities.AdvertiserUsers advertiseruser, int orderid, byte[] file)
        {
            int languageid = (advertiseruser.DefaultLanguageId.HasValue) ? advertiseruser.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId;
            JXTPortal.Entities.EmailTemplates memberEmailtemplate = GetEmailTemplate("PAYMENTCONFIRM", languageid);


            if (memberEmailtemplate != null)
            {
                string siteUrl = GetSiteUrl();

                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();

                message.Bcc = memberEmailtemplate.EmailAddressBcc;
                message.From = new MailAddress(memberEmailtemplate.EmailAddressFrom, memberEmailtemplate.EmailAddressName);
                message.To = new MailAddress(advertiseruser.Email);
                colemailfields["ORDERNO"] = orderid.ToString();
                //colemailfields["SURNAME"] = member.Surname;
                //colemailfields["USERNAME"] = member.Username;
                //colemailfields["CONFIRMLINK"] = string.Format("http://{0}/member/confirmresetpassword.aspx?memberid={1}&key={2}",
                //                                                siteUrl, member.MemberId, member.ValidateGuid.ToString());
                colemailfields["URLSUFFIX"] = siteUrl;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                colemailfields["SITENAME"] = SessionData.Site.SiteName.ToString();
                //message.Format = (Format)member.EmailFormat;
                message.Body = (message.Format == Format.Html) ? memberEmailtemplate.EmailBodyHtml : memberEmailtemplate.EmailBodyText;
                message.Fields = colemailfields;
                string subject = memberEmailtemplate.EmailSubject;


                message.Subject = memberEmailtemplate.EmailSubject.Replace("{ORDERNO}", orderid.ToString()).Replace("{SITENAME}", SessionData.Site.SiteName);
                if (file != null)
                {
                    string pdffilename = string.Format("invoices_{0}.pdf", orderid);
                    message.Attachments.Add(new MessageAttachment(pdffilename, MediaTypeNames.Application.Pdf, new MemoryStream(file)));
                }
                EmailSender().Send(message);
            }
        }

        public static void SendAdminPageRevision(string pageTitle, string lastModifiedName, string pageLink, int languageid)
        {
            JXTPortal.Entities.EmailTemplates memberEmailtemplate = GetEmailTemplate("ADMIN_PAGE_REVISION", languageid);

            //only send this email if there is an email address to 
            if (memberEmailtemplate != null && !string.IsNullOrWhiteSpace(memberEmailtemplate.EmailAddressTo))
            {
                string siteUrl = GetSiteUrl();

                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();

                message.Bcc = memberEmailtemplate.EmailAddressBcc;
                message.From = new MailAddress(memberEmailtemplate.EmailAddressFrom, memberEmailtemplate.EmailAddressName);
                message.To = new MailAddress(memberEmailtemplate.EmailAddressTo);

                message.To = new MailAddress(memberEmailtemplate.EmailAddressTo, memberEmailtemplate.EmailAddressToName);

                // {PAGE_TITLE} {NAME} {LAST_MODIFIED_BY_NAME} {PAGE_LINK} {SITENAME} {URLSUFFIX} {SiteID}
                colemailfields["PAGE_TITLE"] = pageTitle;
                colemailfields["NAME"] = memberEmailtemplate.EmailAddressToName;
                colemailfields["LAST_MODIFIED_BY_NAME"] = lastModifiedName;
                colemailfields["PAGE_LINK"] = pageLink;

                colemailfields["URLSUFFIX"] = siteUrl;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                colemailfields["SITENAME"] = SessionData.Site.SiteName.ToString();
                message.Format = Format.Html;
                message.Body = memberEmailtemplate.EmailBodyHtml;
                message.Fields = colemailfields;
                message.Subject = memberEmailtemplate.EmailSubject;

                EmailSender().Send(message);

            }
        }

        public static void SendContributorPageRevision(string toEmail, string pageTitle, string reviewStatus, string contributorName, string lastModifiedName, string comments, string pageLink, int languageid)
        {
            JXTPortal.Entities.EmailTemplates memberEmailtemplate = GetEmailTemplate("CONTRIBUTOR_PAGE_REVISION", languageid);


            if (memberEmailtemplate != null)
            {
                string siteUrl = GetSiteUrl();

                Message message = new Message();
                HybridDictionary colemailfields = new HybridDictionary();

                message.Bcc = memberEmailtemplate.EmailAddressBcc;
                message.From = new MailAddress(memberEmailtemplate.EmailAddressFrom, memberEmailtemplate.EmailAddressName);
                message.To = new MailAddress(toEmail);
                // {PAGE_TITLE} {REVIEW_STATUS} {NAME} {LAST_MODIFIED_BY_NAME} {COMMENTS} {PAGE_LINK} {SITENAME} {URLSUFFIX} {SiteID}
                colemailfields["PAGE_TITLE"] = pageTitle;
                colemailfields["REVIEW_STATUS"] = reviewStatus;
                colemailfields["NAME"] = contributorName;
                colemailfields["LAST_MODIFIED_BY_NAME"] = lastModifiedName;
                colemailfields["COMMENTS"] = comments;
                colemailfields["PAGE_LINK"] = pageLink;

                colemailfields["URLSUFFIX"] = siteUrl;
                colemailfields["SiteID"] = SessionData.Site.SiteId.ToString();
                colemailfields["SITENAME"] = SessionData.Site.SiteName.ToString();
                message.Format = Format.Html;
                message.Body = memberEmailtemplate.EmailBodyHtml;
                message.Fields = colemailfields;
                message.Subject = memberEmailtemplate.EmailSubject;

                EmailSender().Send(message);
            }
        }

        private static JXTPortal.Entities.EmailTemplates GetEmailTemplate(string emailcode, int languageid)
        {
            JXTPortal.Entities.EmailTemplates emailtemplate = null;
            using (TList<JXTPortal.Entities.EmailTemplates> emailtemplateList = _EmailTemplatesService().GetBySiteIdEmailCode(SessionData.Site.SiteId, emailcode))
            {
                if (emailtemplateList.Count > 0)
                {
                    foreach (JXTPortal.Entities.EmailTemplates emailtemplates in emailtemplateList)
                    {
                        if (emailtemplates.LanguageId == languageid)
                        {
                            emailtemplate = emailtemplates;
                            break;
                        }
                    }

                    if (emailtemplate == null)
                    {
                        emailtemplate = emailtemplateList[0];
                    }
                }
            }
            return emailtemplate;
        }

        private static JXTPortal.Entities.EmailTemplates GetEmailTemplate(string emailcode, int SiteId, int languageid)
        {
            JXTPortal.Entities.EmailTemplates emailtemplate = null;
            using (TList<JXTPortal.Entities.EmailTemplates> emailtemplateList = _EmailTemplatesService().GetBySiteIdEmailCode(SiteId, emailcode))
            {
                if (emailtemplateList.Count > 0)
                {
                    foreach (JXTPortal.Entities.EmailTemplates emailtemplates in emailtemplateList)
                    {
                        if (emailtemplates.LanguageId == languageid)
                        {
                            emailtemplate = emailtemplates;
                            break;
                        }
                    }

                    if (emailtemplate == null)
                    {
                        emailtemplate = emailtemplateList[0];
                    }
                }
            }
            return emailtemplate;
        }

        private static EmailTemplatesService _EmailTemplatesService()
        {
            return (new EmailTemplatesService());
        }

        private static SitesService _SitesService()
        {
            return (new SitesService());
        }

        private static string GetSiteUrl()
        {

            if (HttpContext.Current.Request.Url.Host.StartsWith("www.m.") || HttpContext.Current.Request.Url.Host.StartsWith("m."))
            {
                // mobile site
                string url = string.Empty;
                using (Sites site = _SitesService().GetBySiteId(SessionData.Site.SiteId))
                {
                    if (site != null)
                    {
                        url = site.SiteUrl;
                    }
                }

                return url;
            }
            else
            {
                return HttpContext.Current.Request.Url.Host;
            }
        }

        public static SmtpSender EmailSender()
        {
            Configuration config = null;
            if (HttpContext.Current == null)
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            else
            {
                config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            }
            MailSettingsSectionGroup mailConfiguration = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            SmtpSender mailObject = null;

            if (mailConfiguration.Smtp.DeliveryMethod == SmtpDeliveryMethod.Network)
            {

                mailObject = new SmtpSender(mailConfiguration.Smtp.Network.Host);

                mailObject.Port = mailConfiguration.Smtp.Network.Port;
                if (!mailConfiguration.Smtp.Network.DefaultCredentials)
                {
                    mailObject.UserName = mailConfiguration.Smtp.Network.UserName;
                    mailObject.Password = mailConfiguration.Smtp.Network.Password;
                }
            }
            else if (mailConfiguration.Smtp.DeliveryMethod == SmtpDeliveryMethod.SpecifiedPickupDirectory)
            {
                mailObject = new SmtpSender(mailConfiguration.Smtp.DeliveryMethod, mailConfiguration.Smtp.SpecifiedPickupDirectory.PickupDirectoryLocation);
            }

            return mailObject;
        }
    }
}
