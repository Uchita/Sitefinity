

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Linq;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using JXTPortal.Custom;
using log4net;

#endregion

namespace JXTPortal
{
    /// <summary>
    /// An component type implementation of the 'Members' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class MembersService : JXTPortal.MembersServiceBase
    {
        private ISessionService _sessionService;
        private ILog _logger;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the MembersService class.
        /// </summary>
        public MembersService()
            : base()
        {
            _logger = LogManager.GetLogger(typeof(MembersService));
        }
        #endregion Constructors

        public override bool Insert(Members entity)
        {
            entity.RegisteredDate = DateTime.Now.Date;
            entity.LastModifiedDate = DateTime.Now;
            return base.Insert(entity);
        }

        public override bool Update(Members entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            return base.Update(entity);
        }

        /// <summary>
        /// Get member either based on email address or username
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="userNameOrEmail"></param>
        /// <returns></returns>
        public Members GetBySiteIdEmailAddressOrUserName(int siteId, string userNameOrEmail)
        {
            Members member = null;

            //try to get based on the email first
            member = GetBySiteIdEmailAddress(siteId, userNameOrEmail);

            //get based on the username
            if (member == null)
                member = GetBySiteIdUsername(siteId, userNameOrEmail);

            return member;
        }

        public bool SetMemberCandidateData(int memberID, string jsonObj)
        {
            Members thisMember = GetByMemberId(memberID);

            thisMember.CandidateData = jsonObj;

            return Update(thisMember);
        }

        public Members SocialMediaUserHandler(string externalID, string email, string firstName, string lastName, out bool newMemberCreated, out string newMemberPassword)
        {
            newMemberCreated = false;
            newMemberPassword = null;
            bool existingFound = false;
            Entities.Members thisMember = null;

            using (Entities.Members existingMember = GetBySiteIdEmailAddress(SessionData.Site.SiteId, email))
            {
                if (existingMember != null) //log user in
                {
                    existingFound = true;
                    //updates firstname and last name
                    existingMember.FirstName = firstName;
                    existingMember.Surname = lastName;
                    existingMember.ExternalMemberId = externalID;

                    //email address is trustable (valid)
                    existingMember.Validated = true;

                    Update(existingMember);

                    thisMember = existingMember;
                }
            }

            //if no existing record found
            if (!existingFound)
            {
                //register user
                using (JXTPortal.Entities.Members objMembers = new JXTPortal.Entities.Members())
                {
                    string newPassword = System.Web.Security.Membership.GeneratePassword(10, 0);
                    newMemberPassword = newPassword;

                    objMembers.SiteId = SessionData.Site.SiteId;
                    objMembers.Username = email;
                    objMembers.Password = CommonService.EncryptMD5(newPassword);
                    objMembers.EmailAddress = email;
                    objMembers.FirstName = firstName;
                    objMembers.Surname = lastName;
                    objMembers.ExternalMemberId = externalID;
                    objMembers.Validated = true;
                    objMembers.Valid = true;
                    objMembers.RequiredPasswordChange = false;
                    objMembers.MonthlyUpdate = true;

                    using (TList<GlobalSettings> gslist = new GlobalSettingsService().GetBySiteId(SessionData.Site.SiteId))
                    {
                        objMembers.CountryId = gslist[0].DefaultCountryId.Value;
                    }

                    objMembers.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                    objMembers.ValidateGuid = Guid.NewGuid();
                    objMembers.SearchField = String.Format("{0} {1} {2}",
                                               objMembers.FirstName,
                                               objMembers.Surname,
                                               string.Empty // ddlCountry.SelectedItem.Text
                                               );

                    //Insert into Members
                    Insert(objMembers);

                    thisMember = objMembers;
                    newMemberCreated = true;
                }

            }
            return thisMember;
        }

        public bool MemberAccountClosure(int memberID)
        {
            Entities.Members member = GetByMemberId(memberID);

            //if (member.Status != (int) PortalEnums.Members.UserStatus.Valid) //active user
            //    return false;

            //personal details
            member.FirstName = member.MemberId.ToString();
            member.Surname = member.MemberId.ToString();
            member.Username = member.MemberId.ToString();
            member.EmailAddress = member.MemberId.ToString();
            member.HomePhone = string.Empty;
            member.MobilePhone = string.Empty;
            member.Fax = string.Empty;
            member.ProfilePicture = string.Empty;

            //others
            member.Company = string.Empty;
            member.Position = string.Empty;
            member.PassportNo = string.Empty;

            //addressess
            member.Address1 = string.Empty;
            member.Address2 = string.Empty;
            member.MailingAddress1 = string.Empty;
            member.MailingAddress2 = string.Empty;

            //update account status
            member.Status = (int)PortalEnums.Members.UserStatus.Closed;

            // member validation is false
            member.Validated = false;

            //submit
            Update(member);

            return true;
        }

        /// <summary>
        /// Searching within a Site using External Member ID, if not found, then search by Email Address.
        /// </summary>
        /// <param name="siteID"></param>
        /// <param name="externalMemberID"></param>
        /// <param name="emailAddress"></param>
        public Members GetBySiteIDExternalIDThenEmail(int siteID, string externalMemberID, string emailAddress)
        {
            List<Members> membersWithExternalID = base.Find("siteID = " + siteID + " AND ExternalMemberID = " + externalMemberID + " AND Status = 0").ToList();

            if (membersWithExternalID.Count() > 1)
                throw new Exception("More than 1 member with the same external ID - " + externalMemberID);

            if (membersWithExternalID.Count() == 1)
                return membersWithExternalID.First();

            //no member found with external ID, now look for email address
            Members memberWithEmailAddress = GetBySiteIdEmailAddress(siteID, emailAddress);

            return memberWithEmailAddress;
        }


        #region Save Member

        public bool SaveMemberAndLogin(int siteid, string externalMemberId, string title, string firstname, string surname, string emailaddress, string gender, ref int memberid, ref string errormsg)
        {
            MembersService service = new MembersService();
            SiteCountriesService siteCountriesService = new SiteCountriesService();

            // Set the hardcoded titles which we accept.
            List<string> titleList = new List<string>();
            titleList.Add("Mr");
            titleList.Add("Mrs");
            titleList.Add("Ms");
            titleList.Add("Miss");
            titleList.Add("Dr");
            titleList.Add("Professor");
            titleList.Add("Other");

            bool blnNewMember = false;
            bool blnValid = true;

            JXTPortal.Entities.Members member = service.GetBySiteIdEmailAddress(siteid, emailaddress);
            try
            {
                // Update the Member
                if (member != null)
                {

                    /*
                    // Login Orgin is missing
                    member.Valid = true;
                    member.RequiredPasswordChange = false;
                    member.FirstName = firstname;
                    member.Surname = surname;
                    service.Update(member);

                    SessionService.RemoveAdvertiserUser();
                    SessionService.SetMember(member);

                    return true;*/
                }
                else
                {
                    // Create a new Member
                    blnNewMember = true;

                    member = new Members();
                    member.RegisteredDate = DateTime.Now;
                }


                member.ExternalMemberId = externalMemberId; // Save the external memberid
                member.SiteId = siteid;
                member.FirstName = firstname;
                member.Surname = surname;
                member.EmailAddress = emailaddress;
                member.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                member.Username = emailaddress; // Username would be the email address
                //member.CountryId = countryid;

                // Assign the title
                if (titleList.Contains(title))
                    member.Title = title;
                else
                    member.Title = "Other"; // If the salutation is not found then default it to Other.

                // According to the API - The API  provides numeric value, map 1= Male,   2= female
                if (gender == "2" || gender == "Female")
                    member.Gender = "F";
                else
                    member.Gender = "M";

                string countryName = string.Empty;



                // Get the country
                // Find if the country name from Site is found in the sitecountries.
                int countryid = 1;
                if (!string.IsNullOrWhiteSpace(countryName))
                {
                    using (SiteCountries siteCountry = siteCountriesService.GetBySiteId(siteid).Where(s => s.SiteCountryName.ToLower() == countryName.ToLower()).FirstOrDefault())
                    {
                        if (siteCountry != null)
                        {
                            countryid = siteCountry.CountryId;
                        }
                        else
                        {
                            // If not set the Global default country set for the site.
                            GlobalSettingsService gservice = new GlobalSettingsService();
                            using (TList<GlobalSettings> gslist = gservice.GetBySiteId(siteid))
                            {
                                if (gslist.Count > 0)
                                {
                                    if (gslist[0].DefaultCountryId.HasValue)
                                    {
                                        countryid = gslist[0].DefaultCountryId.Value;
                                    }
                                }
                            }
                        }
                    }
                }

                member.CountryId = countryid;

                // Only create the password only when a new member
                if (blnNewMember)
                {
                    string newpassword = System.Web.Security.Membership.GeneratePassword(10, 0);
                    member.Password = CommonService.EncryptMD5(newpassword);
                    member.ValidateGuid = Guid.NewGuid();
                }

                member.SearchField = String.Format("{0} {1}",
                                                       member.FirstName,
                                                       member.Surname);
                member.Valid = true;
                member.Validated = true;
                member.LastLogon = DateTime.Now; // When loggin in User - set the last login
                member.LastModifiedDate = DateTime.Now; // Last Updated
                member.RequiredPasswordChange = false; // Don't change the password when you login.

                // Save the user
                if (blnNewMember)
                    service.Insert(member);
                else
                    service.Update(member);

                // Logout the advertiser and login the member
                _sessionService.RemoveAdvertiserUser();
                _sessionService.SetMember(member);

            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                blnValid = false;
                errormsg = ex.Message;
            }
            finally
            {
                member.Dispose();
            }

            return blnValid;
        }

        #endregion

        #region Enworld
        public bool UpdateMemberSecondaryEmail(int memberID, int siteID, string secondEmail, bool updateMemberDataField)
        {
            Members thisMember = GetByMemberId(memberID);
            {
                thisMember.SecondaryEmail = secondEmail;

                if (updateMemberDataField)
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();

                    JXTPortal.Client.Salesforce.SalesforceIntegration.SObjRecord thisCandidateData;
                    if (string.IsNullOrEmpty(thisMember.CandidateData))
                    {
                        thisCandidateData = new Client.Salesforce.SalesforceIntegration.SObjRecord();
                        thisCandidateData.Secondary_Email__c = secondEmail;
                    }
                    else
                    {
                        thisCandidateData = ser.Deserialize<JXTPortal.Client.Salesforce.SalesforceIntegration.SObjRecord>(thisMember.CandidateData);
                        thisCandidateData.Secondary_Email__c = secondEmail;
                    }

                    string newJson = ser.Serialize(thisCandidateData);
                    thisMember.CandidateData = newJson;
                }

                base.Update(thisMember);

                return true;
            }

        }

        public Client.Salesforce.SalesforceIntegration.SObjRecord CandidateDataGet(int memberID, int siteID)
        {
            Entities.Members member = GetByMemberId(memberID);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            return ser.Deserialize<Client.Salesforce.SalesforceIntegration.SObjRecord>(member.CandidateData);
        }

        public bool CandidateDataUpdate(int memberID, int siteID, Client.Salesforce.SalesforceIntegration.SObjRecord thisCandData)
        {
            Entities.Members member = GetByMemberId(memberID);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            member.CandidateData = ser.Serialize(thisCandData);
            member.LastModifiedDate = DateTime.Now;

            Update(member);

            return true;
        }
        #endregion
    }//End Class

} // end namespace
