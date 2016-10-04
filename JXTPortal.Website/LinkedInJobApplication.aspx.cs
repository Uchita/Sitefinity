using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using JXTPortal.Common;
using JXTPortal.Entities;

namespace JXTPortal.Website
{
    public partial class LinkedInJobApplication : System.Web.UI.Page
    {
        private MembersService _memebrsService;

        private MembersService MembersService
        {
            get
            {
                if (_memebrsService == null)
                    _memebrsService = new MembersService();
                return _memebrsService;
            }
        }

        private JobApplicationService _jobApplicationService;
        private JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                    _jobApplicationService = new JobApplicationService();
                return _jobApplicationService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.InputStream != null && Request.InputStream.Length > 0)
            {
                byte[] buffer = new byte[5000];
                string responseString = string.Empty;
                MemoryStream ms = new MemoryStream();

                while (true)
                {
                    int read = Request.InputStream.Read(buffer, 0, 5000);
                    if (read <= 0)
                    {
                        responseString = Encoding.UTF8.GetString(ms.ToArray());
                        break;
                    }

                    ms.Write(buffer, 0, read);
                }

                ms.Dispose();

                if (!string.IsNullOrEmpty(responseString))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseString);

                    XmlNode root = xmldoc.FirstChild.NextSibling;
                    XmlElement jobElement = root["job"];
                    XmlElement personElement = root["person"];

                    string jobId = jobElement["id"].InnerText;
                    string firstname = personElement["first-name"].InnerText;
                    string lastname = personElement["last-name"].InnerText;
                    string email = personElement["email-address"].InnerText;

                    AssignJobApplicationMemberID(Convert.ToInt32(jobId), email, firstname, lastname);
                }
            }
        }

        private void AssignJobApplicationMemberID(int jobId, string emailaddress, string firstname, string surname)
        {
            JXTPortal.Entities.Members member = null;

            if (SessionData.Member == null)
            {
                member = MembersService.GetBySiteIdEmailAddress(SessionData.Site.SiteId, emailaddress.Trim());
                if (member != null)
                {
                    member.FirstName = firstname;
                    member.Surname = surname;
                    member.SearchField = String.Format("{0} {1} {2}",
                                               member.FirstName,
                                               member.Surname,
                                               member.SearchField);

                    MembersService.Update(member);
                }
            }

            if (member == null)
            {
                member = new JXTPortal.Entities.Members();
                string newpassword = System.Web.Security.Membership.GeneratePassword(10, 0);
                member.FirstName = firstname.Trim();
                member.Surname = surname.Trim();
                member.Username = emailaddress.Trim();
                member.EmailAddress = emailaddress.Trim();
                member.RequiredPasswordChange = true;
                member.EmailFormat = 1;
                member.CountryId = 1;
                member.SiteId = SessionData.Site.SiteId;
                member.ValidateGuid = Guid.NewGuid();
                member.Password = CommonService.EncryptMD5(newpassword);
                member.MonthlyUpdate = true;
                member.Validated = true;
                member.ReferringSiteId = SessionData.Site.SiteId;
                member.SearchField = String.Format("{0} {1}",
                                               member.FirstName,
                                               member.Surname);

                MembersService.Insert(member);

                MailService.SendNewJobApplicationAccount(member, newpassword);
            }

            string strUrlReferral = Utils.GetCookieDomain(Request.Cookies["JobsViewed"], jobId);
            

            using (JXTPortal.Entities.JobApplication jobapp = new JXTPortal.Entities.JobApplication())
            {
                jobapp.ApplicationDate = DateTime.Now;
                jobapp.JobId = jobId;
                jobapp.MemberId = member.MemberId;

                jobapp.JobAppValidateId = new Guid();
                jobapp.SiteIdReferral = SessionData.Site.SiteId;
                jobapp.UrlReferral = strUrlReferral;
                jobapp.FirstName = member.FirstName;
                jobapp.Surname = member.Surname;
                jobapp.EmailAddress = member.EmailAddress;
                jobapp.MobilePhone = member.MobilePhone;
                jobapp.ApplicationStatus = (int)PortalEnums.JobApplications.ApplicationStatus.Applied;
                jobapp.Draft = false;
                JobApplicationService.Insert(jobapp);
            }
        }
    }
}
