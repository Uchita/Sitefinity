using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Configuration;

namespace JXTPostDataToFTP.Models
{
    public class MemberXMLModel
    {
        //TODO RENAME the variables

        public MemberProfile Profile { get; set; }
        public List<MemberFile> Files { get; set; }
        public List<MemberWorkExperience_Directorship> Directorships { get; set; }
        public List<MemberWorkExperience> WorkExperiences { get; set; }
        public List<MemberEducations> Educations { get; set; }
        public List<MemberCertificate> Certifications { get; set; }
        public List<MemberLicense> Licenses { get; set; }
        public List<MemberRolePreferences> RolePreferences { get; set; }
        public List<MemberLanguage> Languages { get; set; }
        public List<MemberReference> References { get; set; }

        public List<MemberCustomQuestion> CustomQuestions { get; set; }

        public MemberXMLModel()
        { }

        public MemberXMLModel(SiteSettingReferences referenceData, DataRow drProfile, DataRow[] drFiles, DataRow[] drDirectorships, DataRow[] drWorkExperiences,
                                DataRow[] drEducations, DataRow[] drCertifications, DataRow[] drLicenses, DataRow[] drRolePreferences, DataRow[] drLanguages, DataRow[] drReferences, int? completedpercentage, string dateformat)
        {

            #region Profile

            Profile = new MemberProfile
            {
                MemberID = drProfile["MemberID"].ToString(),
                SiteID = drProfile["SiteID"].ToString(),
                Username = drProfile["Username"].ToString(),
                Password = drProfile["Password"].ToString(),
                Title = drProfile["Title"].ToString(),
                FirstName = drProfile["FirstName"].ToString(),
                Surname = drProfile["Surname"].ToString(),
                EmailAddress = drProfile["EmailAddress"].ToString(),
                Company = drProfile["Company"].ToString(),
                Position = drProfile["Position"].ToString(),
                HomePhone = !string.IsNullOrEmpty(drProfile["HomePhone"].ToString()) ? drProfile["HomePhone"].ToString().Trim() : null,
                WorkPhone = !string.IsNullOrEmpty(drProfile["WorkPhone"].ToString()) ? drProfile["WorkPhone"].ToString().Trim() : null,
                MobilePhone = !string.IsNullOrEmpty(drProfile["MobilePhone"].ToString()) ? drProfile["MobilePhone"].ToString().Trim() : null,
                Fax = drProfile["Fax"].ToString(),
                Address1 = drProfile["Address1"].ToString(),
                Address2 = drProfile["Address2"].ToString(),
                LocationID = drProfile["LocationID"].ToString(),
                AreaID = drProfile["AreaID"].ToString(),
                CountryID = drProfile["CountryID"].ToString(),
                PreferredCategoryID = drProfile["PreferredCategoryID"].ToString(),
                PreferredSubCategoryID = drProfile["PreferredSubCategoryID"].ToString(),
                PreferredSalaryID = drProfile["PreferredSalaryID"].ToString(),
                Subscribed = drProfile["Subscribed"].ToString(),
                MonthlyUpdate = drProfile["MonthlyUpdate"].ToString(),
                ReferringMemberID = drProfile["ReferringMemberID"].ToString(),
                LastModifiedDate = !string.IsNullOrEmpty(drProfile["LastModifiedDate"].ToString()) ? ((DateTime)drProfile["LastModifiedDate"]).ToString(dateformat).Trim() : string.Empty,
                Valid = drProfile["Valid"].ToString(),
                EmailFormat = drProfile["EmailFormat"].ToString(),
                LastLogon = drProfile["LastLogon"].ToString(),
                DateOfBirth = !string.IsNullOrEmpty(drProfile["DateOfBirth"].ToString()) ? ((DateTime)drProfile["DateOfBirth"]).ToString(dateformat).Trim() : string.Empty,
                Gender = drProfile["Gender"].ToString(),
                Tags = drProfile["Tags"].ToString(),
                Validated = drProfile["Validated"].ToString(),
                ValidateGUID = drProfile["ValidateGUID"].ToString(),
                MemberURLExtension = drProfile["MemberURLExtension"].ToString(),
                WebsiteURL = drProfile["WebsiteURL"].ToString(),
                AvailabilityID = drProfile["AvailabilityID"].ToString(),
                AvailabilityFromDate = !string.IsNullOrEmpty(drProfile["AvailabilityFromDate"].ToString()) ? ((DateTime)drProfile["AvailabilityFromDate"]).ToString(dateformat).Trim() : string.Empty,
                MySpaceHeading = drProfile["MySpaceHeading"].ToString(),
                MySpaceContent = drProfile["MySpaceContent"].ToString(),
                URLReferrer = drProfile["URLReferrer"].ToString(),
                RequiredPasswordChange = drProfile["RequiredPasswordChange"].ToString(),
                PreferredJobTitle = drProfile["PreferredJobTitle"].ToString(),
                PreferredAvailability = drProfile["PreferredAvailability"].ToString(),
                PreferredAvailabilityType = drProfile["PreferredAvailabilityType"].ToString(),
                PreferredSalaryFrom = drProfile["PreferredSalaryFrom"].ToString(),
                PreferredSalaryTo = drProfile["PreferredSalaryTo"].ToString(),
                CurrentSalaryFrom = drProfile["CurrentSalaryFrom"].ToString(),
                CurrentSalaryTo = drProfile["CurrentSalaryTo"].ToString(),
                LookingFor = drProfile["LookingFor"].ToString(),
                Experience = drProfile["Experience"].ToString(),
                Skills = drProfile["Skills"].ToString(),
                Reasons = drProfile["Reasons"].ToString(),
                Comments = drProfile["Comments"].ToString(),
                ProfileType = drProfile["ProfileType"].ToString(),
                EducationID = drProfile["EducationID"].ToString(),
                SearchField = drProfile["SearchField"].ToString(),
                RegisteredDate = !string.IsNullOrEmpty(drProfile["RegisteredDate"].ToString()) ? ((DateTime)drProfile["RegisteredDate"]).ToString(dateformat).Trim() : string.Empty,
                States = drProfile["States"].ToString(),
                Suburb = drProfile["Suburb"].ToString(),
                PostCode = drProfile["PostCode"].ToString(),
                ProfilePicture = drProfile["ProfilePicture"].ToString(),
                ShortBio = drProfile["ShortBio"].ToString(),
                WorkTypeID = drProfile["WorkTypeID"].ToString(),
                Memberships = drProfile["Memberships"].ToString(),
                MemberStatusID = drProfile["MemberStatusID"].ToString(),
                LinkedInAccessToken = drProfile["LinkedInAccessToken"].ToString(),
                ExternalMemberID = drProfile["ExternalMemberID"].ToString(),
                PassportNo = drProfile["PassportNo"].ToString(),
                MailingAddress1 = drProfile["MailingAddress1"].ToString(),
                MailingAddress2 = drProfile["MailingAddress2"].ToString(),
                MailingStates = drProfile["MailingStates"].ToString(),
                MailingSuburb = drProfile["MailingSuburb"].ToString(),
                MailingPostCode = drProfile["MailingPostCode"].ToString(),
                MailingCountryID = drProfile["MailingCountryID"].ToString(),
                LoginAttempts = drProfile["LoginAttempts"].ToString(),
                LastAttemptDate = !string.IsNullOrEmpty(drProfile["LastAttemptDate"].ToString()) ? ((DateTime)drProfile["LastAttemptDate"]).ToString(dateformat).Trim() : string.Empty,
                Status = drProfile["Status"].ToString(),
                LastTermsAndConditionsDate = !string.IsNullOrEmpty(drProfile["LastTermsAndConditionsDate"].ToString()) ? ((DateTime)drProfile["LastTermsAndConditionsDate"]).ToString(dateformat).Trim() : string.Empty,
                DefaultLanguageId = drProfile["DefaultLanguageId"].ToString(),
                ReferringSiteID = drProfile["ReferringSiteID"].ToString(),
                MultiLingualFirstName = drProfile["MultiLingualFirstName"].ToString(),
                MultiLingualSurame = drProfile["MultiLingualSurame"].ToString(),
                SecondaryEmail = drProfile["SecondaryEmail"].ToString(),
                CandidateData = drProfile["CandidateData"].ToString(),
                EligibleToWorkIn = drProfile["EligibleToWorkIn"].ToString(),
                ReferenceUponRequest = drProfile["ReferenceUponRequest"].ToString(),
                PreferredLine = drProfile["PreferredLine"].ToString(),
                VideoURL = drProfile["VideoURL"].ToString(),
                CompletedPercentage = (completedpercentage.HasValue) ? completedpercentage.Value.ToString() : string.Empty,
                ProfileDataXML = drProfile["ProfileDataXML"].ToString(),
                Abbr = drProfile["Abbr"].ToString(),
                MemberFilesCount = drProfile["MemberFilesCount"].ToString()

            };
            #endregion

            #region Member Files

            List<MemberFile> memberFiles = new List<MemberFile>();

            Files = new List<MemberFile>();

            foreach (DataRow thisDR in drFiles)
            {
                MemberFile thisFile = new MemberFile
                {
                    MemberFileID = thisDR["MemberFileID"].ToString(),
                    MemberID = thisDR["MemberID"].ToString(),
                    MemberFileTypeID = thisDR["MemberFileTypeID"].ToString(),
                    MemberFileName = thisDR["MemberFileName"].ToString(),
                    MemberFileSearchExtension = thisDR["MemberFileSearchExtension"].ToString(),
                    MemberFileTitle = thisDR["MemberFileTitle"].ToString(),
                    LastModifiedDate = !string.IsNullOrEmpty(thisDR["LastModifiedDate"].ToString()) ? ((DateTime)thisDR["LastModifiedDate"]).ToString(dateformat).Trim() : string.Empty
                };
                memberFiles.Add(thisFile);
            }

            //select 
            Files.AddRange(memberFiles.Where(c => c.MemberFileTypeID == "1").OrderByDescending(s => s.MemberFileID).Take(3).ToList());
            Files.AddRange(memberFiles.Where(c => c.MemberFileTypeID == "2").OrderByDescending(s => s.MemberFileID).Take(3).ToList());


            #endregion

            #region Directorships

            Directorships = new List<MemberWorkExperience_Directorship>();

            foreach (DataRow thisDR in drDirectorships)
            {
                MemberWorkExperience_Directorship thisDirectorship = new MemberWorkExperience_Directorship
                {
                    MemberPositionId = thisDR["MemberPositionId"].ToString(),
                    LinkedInInternalPositionId = thisDR["LinkedInInternalPositionId"].ToString(),
                    Title = thisDR["Title"].ToString(),
                    Summary = thisDR["Summary"].ToString(),
                    CompanyId = thisDR["CompanyId"].ToString(),
                    CompanyName = thisDR["CompanyName"].ToString(),
                    CompanyIndustry = thisDR["CompanyIndustry"].ToString(),
                    StartMonth = thisDR["StartMonth"].ToString(),
                    StartYear = thisDR["StartYear"].ToString(),
                    EndMonth = thisDR["EndMonth"].ToString(),
                    EndYear = thisDR["EndYear"].ToString(),
                    IsCurrent = thisDR["IsCurrent"].ToString(),
                    MemberID = thisDR["MemberID"].ToString(),
                    OrganisationWebsite = thisDR["OrganisationWebsite"].ToString(),
                    ResponsibilitiesAndAchievements = thisDR["ResponsibilitiesAndAchievements"].ToString(),
                    TypeOfDirectorship = thisDR["TypeOfDirectorship"].ToString(),
                    AdditionalRolesAndResponsibilities = thisDR["AdditionalRolesAndResponsibilities"].ToString(),
                    IsDirectorship = thisDR["IsDirectorship"].ToString(),
                    City = thisDR["City"].ToString(),
                    CountryID = thisDR["CountryID"].ToString(),
                };
                Directorships.Add(thisDirectorship);
            }

            #endregion

            #region Work Experience

            WorkExperiences = new List<MemberWorkExperience>();

            foreach (DataRow thisDR in drWorkExperiences)
            {
                MemberWorkExperience thisExperience = new MemberWorkExperience
                {
                    MemberPositionId = thisDR["MemberPositionId"].ToString(),
                    LinkedInInternalPositionId = thisDR["LinkedInInternalPositionId"].ToString(),
                    Title = thisDR["Title"].ToString(),
                    Summary = thisDR["Summary"].ToString(),
                    CompanyId = thisDR["CompanyId"].ToString(),
                    CompanyName = thisDR["CompanyName"].ToString(),
                    CompanyIndustry = thisDR["CompanyIndustry"].ToString(),
                    StartMonth = thisDR["StartMonth"].ToString(),
                    StartYear = thisDR["StartYear"].ToString(),
                    EndMonth = thisDR["EndMonth"].ToString(),
                    EndYear = thisDR["EndYear"].ToString(),
                    IsCurrent = thisDR["IsCurrent"].ToString(),
                    MemberID = thisDR["MemberID"].ToString(),
                    OrganisationWebsite = thisDR["OrganisationWebsite"].ToString(),
                    ResponsibilitiesAndAchievements = thisDR["ResponsibilitiesAndAchievements"].ToString(),
                    TypeOfDirectorship = thisDR["TypeOfDirectorship"].ToString(),
                    AdditionalRolesAndResponsibilities = thisDR["AdditionalRolesAndResponsibilities"].ToString(),
                    IsDirectorship = thisDR["IsDirectorship"].ToString(),
                    City = thisDR["City"].ToString(),
                    CountryID = thisDR["CountryID"].ToString(),
                };
                WorkExperiences.Add(thisExperience);
            }

            #endregion

            #region Educations

            Educations = new List<MemberEducations>();

            foreach (DataRow thisDR in drEducations)
            {
                MemberEducations thisEducation = new MemberEducations
                {
                    MemberQualificationId = thisDR["MemberQualificationId"].ToString(),
                    LinkedInInternalEducationId = thisDR["LinkedInInternalEducationId"].ToString(),
                    SchoolName = thisDR["SchoolName"].ToString(),
                    FieldOfStudy = thisDR["FieldOfStudy"].ToString(),
                    StartYear = thisDR["StartYear"].ToString(),
                    EndYear = thisDR["EndYear"].ToString(),
                    Degree = thisDR["Degree"].ToString(),
                    Activities = thisDR["Activities"].ToString(),
                    Notes = thisDR["Notes"].ToString(),
                    MemberID = thisDR["MemberID"].ToString(),
                    City = thisDR["City"].ToString(),
                    CountryID = thisDR["CountryID"].ToString(),
                    QualificationLevelID = thisDR["QualificationLevelID"].ToString(),
                    QualificationLevelOther = thisDR["QualificationLevelOther"].ToString(),
                    Major = thisDR["Major"].ToString(),
                    Present = thisDR["Present"].ToString(),
                    StartMonth = thisDR["StartMonth"].ToString(),
                    EndMonth = thisDR["EndMonth"].ToString()
                };
                Educations.Add(thisEducation);
            }

            #endregion

            #region Certificates

            Certifications = new List<MemberCertificate>();

            foreach (DataRow thisDR in drCertifications)
            {
                MemberCertificate thisCert = new MemberCertificate
                {
                    MemberCertificateMembershipID = thisDR["MemberCertificateMembershipID"].ToString(),
                    MemberID = thisDR["MemberID"].ToString(),
                    MemberCertificateMembershipName = thisDR["MemberCertificateMembershipName"].ToString(),
                    CertificationAuthority = thisDR["CertificationAuthority"].ToString(),
                    LicenseNumber = thisDR["LicenseNumber"].ToString(),
                    CertificationURL = thisDR["CertificationURL"].ToString(),
                    StartMonth = thisDR["StartMonth"].ToString(),
                    StartYear = thisDR["StartYear"].ToString(),
                    EndMonth = thisDR["EndMonth"].ToString(),
                    EndYear = thisDR["EndYear"].ToString(),
                    DoesnotExpire = thisDR["DoesnotExpire"].ToString(),
                    LastModifiedDate = thisDR["LastModifiedDate"].ToString()
                };
                Certifications.Add(thisCert);
            }

            #endregion

            #region Licenses

            Licenses = new List<MemberLicense>();

            foreach (DataRow thisDR in drLicenses)
            {
                MemberLicense thisLicense = new MemberLicense
                {
                    MemberLicenseID = thisDR["MemberLicenseID"].ToString(),
                    MemberID = thisDR["MemberID"].ToString(),
                    MemberLicenseName = thisDR["MemberLicenseName"].ToString(),
                    LicenseType = thisDR["LicenseType"].ToString(),
                    IssueDate = thisDR["IssueDate"].ToString(),
                    ExpiryDate = thisDR["ExpiryDate"].ToString(),
                    CountryID = thisDR["CountryID"].ToString(),
                    State = thisDR["State"].ToString(),
                    DoesNotExpire = thisDR["DoesNotExpire"].ToString(),
                    LastModifiedDate = thisDR["LastModifiedDate"].ToString()
                };
                Licenses.Add(thisLicense);
            }

            #endregion

            #region Role Preferences

            RolePreferences = new List<MemberRolePreferences>();

            foreach (DataRow thisDR in drRolePreferences)
            {
                MemberRolePreferences thisRP = new MemberRolePreferences
                {
                    MemberID = thisDR["MemberID"].ToString(),
                    WorkTypeID = thisDR["WorkTypeID"].ToString(),
                    WorkTypeValue = !string.IsNullOrEmpty(thisDR["WorkTypeValue"].ToString()) ? thisDR["WorkTypeValue"].ToString().Trim().TrimEnd(',') : null,
                    PreferredSalaryID = thisDR["PreferredSalaryID"].ToString(),
                    PreferredSalaryValue = thisDR["PreferredSalaryValue"].ToString(),
                    PreferredSalaryFrom = thisDR["PreferredSalaryFrom"].ToString(),
                    PreferredSalaryTo = thisDR["PreferredSalaryTo"].ToString(),
                    PreferredCategoryID = thisDR["PreferredCategoryID"].ToString(),
                    PreferredCategoryValue = thisDR["PreferredCategoryValue"].ToString(),
                    PreferredSubCategoryID = thisDR["PreferredSubCategoryID"].ToString(),
                    PreferredSubCategoryValue = !string.IsNullOrEmpty(thisDR["PreferredSubCategoryValue"].ToString()) ? thisDR["PreferredSubCategoryValue"].ToString().Trim().TrimEnd(',') : null,
                    LocationID = thisDR["LocationID"].ToString(),
                    LocationValue = !string.IsNullOrEmpty(thisDR["LocationValue"].ToString()) ? thisDR["LocationValue"].ToString().Trim().TrimEnd(',') : null,
                    AreaID = thisDR["AreaID"].ToString(),
                    AreaValue = !string.IsNullOrEmpty(thisDR["AreaValue"].ToString()) ? thisDR["AreaValue"].ToString().Trim().TrimEnd(',') : null,
                    EligibleToWorkIn = thisDR["EligibleToWorkIn"].ToString(),
                    EligibleToWorkInValue = !string.IsNullOrEmpty(thisDR["EligibleToWorkInValue"].ToString()) ? thisDR["EligibleToWorkInValue"].ToString().Trim().TrimEnd(',') : null
                };
                RolePreferences.Add(thisRP);
            }

            #endregion

            #region Languages

            Languages = new List<MemberLanguage>();

            foreach (DataRow thisDR in drLanguages)
            {
                MemberLanguage thisLanguage = new MemberLanguage
                {
                    MemberLanguageID = thisDR["MemberLanguageID"].ToString(),
                    MemberID = thisDR["MemberID"].ToString(),
                    Langauges = thisDR["Langauges"].ToString(),
                    Profieciency = thisDR["Profieciency"].ToString(),
                    LastModifiedDate = !string.IsNullOrEmpty(thisDR["LastModifiedDate"].ToString()) ? ((DateTime)thisDR["LastModifiedDate"]).ToString(dateformat).Trim() : string.Empty
                };
                Languages.Add(thisLanguage);
            }

            #endregion

            #region References

            References = new List<MemberReference>();

            foreach (DataRow thisDR in drReferences)
            {
                MemberReference thisRef = new MemberReference
                {
                    MemberReferenceID = thisDR["MemberReferenceID"].ToString(),
                    MemberID = thisDR["MemberID"].ToString(),
                    MemberReferenceName = thisDR["MemberReferenceName"].ToString(),
                    JobTitle = thisDR["JobTitle"].ToString(),
                    Company = thisDR["Company"].ToString(),
                    Phone = thisDR["Phone"].ToString(),
                    Relationship = thisDR["Relationship"].ToString(),
                    ReferenceEmail = thisDR["ReferenceEmail"].ToString(),
                    LastModifiedDate = !string.IsNullOrEmpty(thisDR["LastModifiedDate"].ToString()) ? ((DateTime)thisDR["LastModifiedDate"]).ToString(dateformat).Trim() : string.Empty
                };
                References.Add(thisRef);
            }

            #endregion

        }

        public static class StaticSiteReference
        {
            public static SiteSettingReferences _RefData = new SiteSettingReferences();

            public static void SetRefData(SiteSettingReferences referenceData)
            {
                _RefData = referenceData;
            }

            public static string GetCountryReference(int id)
            {
                return _RefData.countries.Where(c => c.id == id).Select(c => c.name).FirstOrDefault();
            }

            public static string GetLocationReference(int id)
            {
                List<ReferenceItem> aaa = _RefData.locations.OrderBy(c => c.id).ToList();
                return _RefData.locations.Where(c => c.id == id).Select(c => c.name).FirstOrDefault();
            }

            public static string GetAreaReference(int id)
            {
                return _RefData.areas.Where(c => c.id == id).Select(c => c.name).FirstOrDefault();
            }

            public static string GetProfessionReference(int id)
            {
                return _RefData.professions.Where(c => c.id == id).Select(c => c.name).FirstOrDefault();
            }

            public static string GetRoleReference(int id)
            {
                return _RefData.roles.Where(c => c.id == id).Select(c => c.name).FirstOrDefault();
            }

            public static string GetSalaryTypeReference(int id)
            {
                return _RefData.salary_type.Where(c => c.id == id).Select(c => c.name).FirstOrDefault();
            }

            public static string GetWorkTypeReference(int id)
            {
                return _RefData.work_type.Where(c => c.id == id).Select(c => c.name).FirstOrDefault();
            }

            public static string GetSiteURL()
            {
                return _RefData.siteURL;
            }

            public static string GetSiteCountryCode()
            {
                return _RefData.siteCountryCode;
            }
        }

        public class MemberProfile
        {
            public string MemberID { get; set; }
            public string ExternalMemberID { get; set; }
            [XmlIgnore]
            public string SiteID { get; set; }
            [XmlIgnore]
            public string Username { get; set; }
            [XmlIgnore]
            public string Password { get; set; }
            public string Title { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string MultiLingualFirstName { get; set; }
            public string MultiLingualSurame { get; set; }
            public string EmailAddress { get; set; }
            public string SecondaryEmail { get; set; }
            [XmlIgnore]
            public string Company { get; set; }
            [XmlIgnore]
            public string Position { get; set; }
            public string HomePhone { get; set; } //Spaces
            public string WorkPhone { get; set; } //Spaces
            public string MobilePhone { get; set; } //Spaces
            [XmlIgnore]
            public string Fax { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string States { get; set; } // **
            public string Suburb { get; set; }
            public string PostCode { get; set; }
            [XmlIgnore]
            public string CountryID { get; set; }
            public string CountryName { get { return string.IsNullOrEmpty(CountryID) ? null : StaticSiteReference.GetCountryReference(int.Parse(CountryID)); } set { } }

            public string MailingAddress1 { get; set; }
            public string MailingAddress2 { get; set; }
            public string MailingStates { get; set; }
            public string MailingSuburb { get; set; }
            public string MailingPostCode { get; set; }
            [XmlIgnore]
            public string MailingCountryID { get; set; }
            public string MailingCountryName { get { return string.IsNullOrEmpty(MailingCountryID) ? null : StaticSiteReference.GetCountryReference(int.Parse(MailingCountryID)); } set { } }
            [XmlIgnore]
            public string LocationID { get; set; }
            [XmlIgnore]
            public string LocationName { get { return string.IsNullOrEmpty(LocationID) ? null : StaticSiteReference.GetLocationReference(int.Parse(LocationID)); } set { } }

            [XmlIgnore]
            public string AreaID { get; set; }
            [XmlIgnore]
            public string AreaName
            {
                get
                {
                    //csv value
                    List<string> areaIDs = AreaID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<string> areaNames = new List<string>();

                    foreach (string aID in areaIDs)
                    {
                        areaNames.Add(StaticSiteReference.GetAreaReference(int.Parse(aID)));
                    }

                    return areaNames.Count() == 0 ? null : String.Join(", ", areaNames);
                }
                set { }
            }

            [XmlIgnore]
            public string PreferredCategoryID { get; set; }
            [XmlIgnore]
            public string PreferredCategoryName { get { return string.IsNullOrEmpty(PreferredCategoryID) ? null : StaticSiteReference.GetProfessionReference(int.Parse(PreferredCategoryID)); } set { } }

            [XmlIgnore]
            public string PreferredSubCategoryID { get; set; }
            [XmlIgnore]
            public string PreferredSubCategoryName
            {
                get
                {
                    //csv value
                    List<string> subCateIDs = PreferredSubCategoryID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<string> subCateNames = new List<string>();

                    foreach (string sID in subCateIDs)
                    {
                        subCateNames.Add(StaticSiteReference.GetAreaReference(int.Parse(sID)));
                    }

                    return subCateNames.Count() == 0 ? null : String.Join(", ", subCateNames);
                }
                set { }
            }

            [XmlIgnore]
            public string PreferredSalaryID { get; set; }
            [XmlIgnore]
            public string PreferredSalaryName { get { return string.IsNullOrEmpty(PreferredSalaryID) ? null : StaticSiteReference.GetSalaryTypeReference(int.Parse(PreferredSalaryID)); } set { } }

            [XmlIgnore]
            public string Subscribed { get; set; }
            [XmlIgnore]
            public string MonthlyUpdate { get; set; }
            [XmlIgnore]
            public string ReferringMemberID { get; set; }
            public string LastModifiedDate { get; set; }
            [XmlIgnore]
            public string Valid { get; set; }
            [XmlIgnore]
            public string EmailFormat { get; set; }
            public string EmailFormatName
            {
                get
                {
                    if (string.IsNullOrEmpty(EmailFormat))
                        return null;

                    JXTPortal.Entities.PortalEnums.Email.EmailFormat thisStatus;
                    bool enumParseSuccess = Enum.TryParse<JXTPortal.Entities.PortalEnums.Email.EmailFormat>(EmailFormat, out thisStatus);

                    if (enumParseSuccess)
                        return thisStatus.ToString();
                    else
                        return null;
                }
                set { }
            }
            [XmlIgnore]
            public string LastLogon { get; set; }
            public string DateOfBirth { get; set; }
            public string Gender { get; set; }
            [XmlIgnore]
            public string Tags { get; set; }
            public string Validated { get; set; }
            [XmlIgnore]
            public string ValidateGUID { get; set; }
            [XmlIgnore]
            public string MemberURLExtension { get; set; }
            [XmlIgnore]
            public string WebsiteURL { get; set; }
            [XmlIgnore]
            public string AvailabilityID { get; set; }
            public string SeekingStatus
            {
                get
                {
                    if (string.IsNullOrEmpty(AvailabilityID))
                        return null;

                    JXTPortal.Entities.PortalEnums.Members.CurrentlySeeking thisStatus;
                    bool enumParseSuccess = Enum.TryParse<JXTPortal.Entities.PortalEnums.Members.CurrentlySeeking>(AvailabilityID, out thisStatus);

                    if (enumParseSuccess)
                        return thisStatus.ToString();
                    else
                        return null;
                }
                set { }
            }

            public string AvailabilityFromDate { get; set; }
            [XmlIgnore]
            public string MySpaceHeading { get; set; }
            [XmlIgnore]
            public string MySpaceContent { get; set; }
            [XmlIgnore]
            public string URLReferrer { get; set; }
            [XmlIgnore]
            public string RequiredPasswordChange { get; set; }
            public string PreferredJobTitle { get; set; } //headline (heading change)
            [XmlIgnore]
            public string PreferredAvailability { get; set; }
            [XmlIgnore]
            public string PreferredAvailabilityType { get; set; }
            [XmlIgnore]
            public string PreferredSalaryFrom { get; set; }
            [XmlIgnore]
            public string PreferredSalaryTo { get; set; }
            [XmlIgnore]
            public string CurrentSalaryFrom { get; set; }
            [XmlIgnore]
            public string CurrentSalaryTo { get; set; }
            [XmlIgnore]
            public string LookingFor { get; set; } //
            [XmlIgnore]
            public string Experience { get; set; } //
            private string _Skills;
            public string Skills { get { return string.IsNullOrEmpty(_Skills) ? null : String.Join(", ", _Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries)); } set { _Skills = value; } }
            [XmlIgnore]
            public string Reasons { get; set; }
            [XmlIgnore]
            public string Comments { get; set; }
            [XmlIgnore]
            public string ProfileType { get; set; }
            [XmlIgnore]
            public string EducationID { get; set; } // **
            [XmlIgnore]
            public string SearchField { get; set; }
            public string RegisteredDate { get; set; }

            private string _ProfilePicture; //TODO: SiteURl app settings
            public string ProfilePicture { get { return !string.IsNullOrEmpty(_ProfilePicture) ? (StaticSiteReference.GetSiteURL() + ConfigurationManager.AppSettings["MemberUploadPicturePaths"] + _ProfilePicture) : null; } set { _ProfilePicture = value; } }

            public string ShortBio { get; set; }
            [XmlIgnore]
            public string WorkTypeID { get; set; }
            [XmlIgnore]
            public string WorkTypeName
            {
                get
                {
                    //csv value
                    List<string> workTypeIDs = WorkTypeID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<string> workTypeNames = new List<string>();

                    foreach (string wID in workTypeIDs)
                    {
                        workTypeNames.Add(StaticSiteReference.GetWorkTypeReference(int.Parse(wID)));
                    }

                    return workTypeNames.Count() == 0 ? null : String.Join(", ", workTypeNames);
                }
                set { }
            }

            [XmlIgnore]
            public string Memberships { get; set; }
            [XmlIgnore]
            public string MemberStatusID { get; set; }
            [XmlIgnore]
            public string LinkedInAccessToken { get; set; }
            public string PassportNo { get; set; }
            [XmlIgnore]
            public string LoginAttempts { get; set; }
            [XmlIgnore]
            public string LastAttemptDate { get; set; }
            [XmlIgnore]
            public string Status { get; set; }
            
            public string LastTermsAndConditionsDate { get; set; }
            [XmlIgnore]
            public string DefaultLanguageId { get; set; }
            [XmlIgnore]
            public string DefaultLanguageName
            {
                get
                {
                    if (string.IsNullOrEmpty(DefaultLanguageId))
                        return null;

                    JXTPortal.Entities.PortalEnums.Languages.Language thisLang;
                    bool enumParseSuccess = Enum.TryParse<JXTPortal.Entities.PortalEnums.Languages.Language>(DefaultLanguageId, out thisLang);

                    if (enumParseSuccess)
                        return thisLang.ToString();
                    else
                        return null;
                }
                set { }
            }
            [XmlIgnore]
            public string ReferringSiteID { get; set; }
            [XmlIgnore]
            public string CandidateData { get; set; }
            [XmlIgnore]
            public string EligibleToWorkIn { get; set; }
            public string ReferenceUponRequest { get; set; }
            [XmlIgnore]
            public string PreferredLine { get; set; }
            public string PreferredLineName
            {
                get
                {
                    if (string.IsNullOrEmpty(PreferredLine))
                        return null;

                    if (PreferredLine == "1")
                        return "Home Phone";
                    else if (PreferredLine == "2")
                        return "Mobile Phone";

                    return null;
                }
                set { }
            }
            public string VideoURL { get; set; }
            public string CompletedPercentage { get; set; }
            [XmlIgnore]
            public string ProfileDataXML { get; set; }
            [XmlIgnore]
            public string Abbr { get; set; }
            [XmlIgnore]
            public string MemberFilesCount { get; set; }

        }

        public class MemberFile
        {
            public string MemberFileID { get; set; }
            public string MemberID { get; set; }
            public string MemberFileTypeID { get; set; }
            public string MemberFileTypeName
            {
                get
                {
                    if (string.IsNullOrEmpty(MemberFileTypeID))
                        return null;

                    JXTPortal.Entities.PortalEnums.Members.MemberFileTypes thisFile;
                    bool enumParseSuccess = Enum.TryParse<JXTPortal.Entities.PortalEnums.Members.MemberFileTypes>(MemberFileTypeID, out thisFile);

                    if (enumParseSuccess)
                        return thisFile.ToString();
                    else
                        return null;
                }
                set { }
            }

            public string MemberFileName { get; set; }
            [XmlIgnore]
            public string MemberFileSearchExtension { get; set; }
            public string MemberFileTitle { get; set; }
            public string LastModifiedDate { get; set; }
            public string Base64FileContent { get; set; }
        }

        public class MemberWorkExperience_Directorship
        {
            public string MemberPositionId { get; set; }
            public string MemberID { get; set; }
            [XmlIgnore]
            public string LinkedInInternalPositionId { get; set; }
            public string Title { get; set; }
            public string Summary { get; set; }
            [XmlIgnore]
            public string CompanyId { get; set; }
            public string CompanyName { get; set; }
            [XmlIgnore]
            public string CompanyIndustry { get; set; }
            public string StartMonth { get; set; }
            public string StartYear { get; set; }
            public string EndMonth { get; set; }
            public string EndYear { get; set; }
            public string IsCurrent { get; set; }
            public string OrganisationWebsite { get; set; }
            public string ResponsibilitiesAndAchievements { get; set; }
            public string TypeOfDirectorship { get; set; }
            public string AdditionalRolesAndResponsibilities { get; set; }
            [XmlIgnore]
            public string IsDirectorship { get; set; }
            [XmlIgnore]
            public string City { get; set; }
            [XmlIgnore]
            public string CountryID { get; set; }
            [XmlIgnore]
            public string CountryName { get { return string.IsNullOrEmpty(CountryID) ? null : StaticSiteReference.GetCountryReference(int.Parse(CountryID)); } set { } }
        }

        public class MemberWorkExperience
        {
            public string MemberPositionId { get; set; }
            public string MemberID { get; set; }
            [XmlIgnore]
            public string LinkedInInternalPositionId { get; set; }
            public string Title { get; set; }
            public string Summary { get; set; }
            [XmlIgnore]
            public string CompanyId { get; set; }
            public string CompanyName { get; set; }
            [XmlIgnore]
            public string CompanyIndustry { get; set; }
            public string StartMonth { get; set; }
            public string StartYear { get; set; }
            public string EndMonth { get; set; }
            public string EndYear { get; set; }
            public string IsCurrent { get; set; }
            [XmlIgnore]
            public string OrganisationWebsite { get; set; }
            [XmlIgnore]
            public string ResponsibilitiesAndAchievements { get; set; }
            [XmlIgnore]
            public string TypeOfDirectorship { get; set; }
            [XmlIgnore]
            public string AdditionalRolesAndResponsibilities { get; set; }
            [XmlIgnore]
            public string IsDirectorship { get; set; }
            public string City { get; set; }
            [XmlIgnore]
            public string CountryID { get; set; }
            public string CountryName { get { return string.IsNullOrEmpty(CountryID) ? null : StaticSiteReference.GetCountryReference(int.Parse(CountryID)); } set { } }
        }

        public class MemberEducations
        {
            public string MemberQualificationId { get; set; }
            public string MemberID { get; set; }
            [XmlIgnore]
            public string LinkedInInternalEducationId { get; set; }
            public string SchoolName { get; set; }
            [XmlIgnore]
            public string FieldOfStudy { get; set; }
            public string StartYear { get; set; }
            public string EndYear { get; set; }
            public string Degree { get; set; }
            [XmlIgnore]
            public string Activities { get; set; }
            [XmlIgnore]
            public string Notes { get; set; }
            public string City { get; set; }
            [XmlIgnore]
            public string CountryID { get; set; }
            public string CountryName { get { return string.IsNullOrEmpty(CountryID) ? null : StaticSiteReference.GetCountryReference(int.Parse(CountryID)); } set { } }
            [XmlIgnore]
            public string QualificationLevelID { get; set; }
            public string QualificationLevelName
            {
                get
                {
                    if (string.IsNullOrEmpty(QualificationLevelID))
                        return null;

                    JXTPortal.Entities.PortalEnums.Members.QualificationLevel thisQLevel;
                    bool enumParseSuccess = Enum.TryParse<JXTPortal.Entities.PortalEnums.Members.QualificationLevel>(QualificationLevelID, out thisQLevel);

                    if (enumParseSuccess)
                        return thisQLevel.ToString();
                    else
                        return null;
                }
                set { }
            }
            public string QualificationLevelOther { get; set; }
            [XmlIgnore]
            public string Major { get; set; }
            public string Present { get; set; }
            public string StartMonth { get; set; }
            public string EndMonth { get; set; }
        }

        public class MemberCertificate
        {
            public string MemberCertificateMembershipID { get; set; }
            public string MemberID { get; set; }
            public string MemberCertificateMembershipName { get; set; }
            public string CertificationAuthority { get; set; }
            public string LicenseNumber { get; set; }
            public string CertificationURL { get; set; }
            public string StartMonth { get; set; }
            public string StartYear { get; set; }
            public string EndMonth { get; set; }
            public string EndYear { get; set; }
            public string DoesnotExpire { get; set; }
            [XmlIgnore]
            public string LastModifiedDate { get; set; }

        }

        public class MemberLicense
        {

            public string MemberLicenseID { get; set; }
            public string MemberID { get; set; }
            public string MemberLicenseName { get; set; }
            public string LicenseType { get; set; }
            public string IssueDate { get; set; }
            public string ExpiryDate { get; set; }
            [XmlIgnore]
            public string CountryID { get; set; }
            public string CountryName { get { return string.IsNullOrEmpty(CountryID) ? null : StaticSiteReference.GetCountryReference(int.Parse(CountryID)); } set { } }
            public string State { get; set; }
            public string DoesNotExpire { get; set; }
            [XmlIgnore]
            public string LastModifiedDate { get; set; }


        }

        public class MemberRolePreferences
        {
            public string MemberID { get; set; }
            [XmlIgnore]
            public string WorkTypeID { get; set; }
            public string WorkTypeValue { get; set; }
            [XmlIgnore]
            public string PreferredSalaryID { get; set; }
            public string PreferredSalaryValue { get; set; }
            public string PreferredSalaryFrom { get; set; }
            public string PreferredSalaryTo { get; set; }
            [XmlIgnore]
            public string PreferredCategoryID { get; set; }
            public string PreferredCategoryValue { get; set; }
            [XmlIgnore]
            public string PreferredSubCategoryID { get; set; }
            public string PreferredSubCategoryValue { get; set; }
            [XmlIgnore]
            public string LocationID { get; set; }
            public string LocationValue { get; set; }
            [XmlIgnore]
            public string AreaID { get; set; }
            public string AreaValue { get; set; }
            [XmlIgnore]
            public string EligibleToWorkIn { get; set; }
            public string EligibleToWorkInValue { get; set; }
        }

        public class MemberLanguage
        {
            public string MemberLanguageID { get; set; }
            public string MemberID { get; set; }
            public string Langauges { get; set; }

            [XmlIgnore]
            public string Profieciency { get; set; } //TODO get from enum
            public string ProfieciencyName
            {
                get
                {
                    if (string.IsNullOrEmpty(Profieciency))
                        return null;

                    JXTPortal.Entities.PortalEnums.Members.LanguagesProfieciency thisStatus;
                    bool enumParseSuccess = Enum.TryParse<JXTPortal.Entities.PortalEnums.Members.LanguagesProfieciency>(Profieciency, out thisStatus);

                    if (enumParseSuccess)
                        return thisStatus.ToString();
                    else
                        return null;
                }
                set { }
            }
            [XmlIgnore]
            public string LastModifiedDate { get; set; }
        }

        public class MemberReference
        {
            public string MemberReferenceID { get; set; }
            public string MemberID { get; set; }
            public string MemberReferenceName { get; set; }
            public string JobTitle { get; set; }
            public string Company { get; set; }
            public string Phone { get; set; }
            [XmlIgnore]
            public string Relationship { get; set; }
            public string ReferenceRelationship
            {
                get
                {
                    if (string.IsNullOrEmpty(Relationship))
                        return null;

                    JXTPortal.Entities.PortalEnums.Members.ReferencesRelationship thisStatus;
                    bool enumParseSuccess = Enum.TryParse<JXTPortal.Entities.PortalEnums.Members.ReferencesRelationship>(Relationship, out thisStatus);

                    if (enumParseSuccess)
                        return thisStatus.ToString();
                    else
                        return null;
                }
                set { }
            }
            [XmlIgnore]
            public string LastModifiedDate { get; set; }
            public string ReferenceEmail { get; set; }
        }

        public class MemberCustomQuestion
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int MemberID { get; set; }
            [XmlIgnore]
            public string Type { get; set; }
            [XmlIgnore]
            public List<string> Parameters { get; set; }
            [XmlIgnore]
            public int Sequence { get; set; }
            [XmlIgnore]
            public bool Mandatory { get; set; }
            [XmlIgnore]
            public int Status { get; set; }
            [XmlIgnore]
            public string _Answers { get; set; }
            public string Answers
            {
                get
                {

                    if (string.IsNullOrEmpty(_Answers))
                        return null;

                    switch (Type.ToLower())
                    {
                        case "dropdown":
                        case "multiselect":
                        case "radio":
                            List<string> convertedAnswersStr = new List<string>();
                            string[] answersInt = _Answers.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (string ans in answersInt)
                            {
                                int thisAnswerInt = int.Parse(ans.Trim());

                                convertedAnswersStr.Add(Parameters[thisAnswerInt - 1]);
                            }

                            return String.Join(",", convertedAnswersStr);

                        default:
                            return _Answers;
                    }

                    return null;
                }
                set { }
            }
            [XmlIgnore]
            public string TempAnswer { get; set; }
            [XmlIgnore]
            public bool IsError { get; set; }
        }

    }





    public class ReferenceItem
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class SiteSettingReferences
    {
        public List<ReferenceItem> countries { get; set; }
        public List<ReferenceItem> locations { get; set; }
        public List<ReferenceItem> areas { get; set; }

        public List<ReferenceItem> professions { get; set; }
        public List<ReferenceItem> roles { get; set; }

        public List<ReferenceItem> salary_type { get; set; }
        public List<ReferenceItem> work_type { get; set; }

        public string siteURL { get; set; }
        public string siteCountryCode { get; set; }

        public SiteSettingReferences()
        {
            countries = new List<ReferenceItem>();
            locations = new List<ReferenceItem>();
            areas = new List<ReferenceItem>();
            professions = new List<ReferenceItem>();
            roles = new List<ReferenceItem>();
            salary_type = new List<ReferenceItem>();
            work_type = new List<ReferenceItem>();
        }

    }


}
