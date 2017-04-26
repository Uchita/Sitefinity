using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using JXTEnworldImport.Models;
using System.Web.Script.Serialization;
using JXTPortal;
using JXTPortal.Data;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXT.Integration.AWS;
using JXTPortal.Core.FileManagement;

namespace JXTEnworldImport
{
    class Program
    {
        private static string _TARGETFOLDER = ConfigurationManager.AppSettings["WorkingPath"];
        private static string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private static string privateBucketName = ConfigurationManager.AppSettings["AWSS3PrivateBucketName"];

        private static string memberFileFolder, memberFileFolderFormat;
        public static IFileManager FileManagerService { get; set; }

        private static MembersService _membersservice;
        private static MembersService MembersService
        {
            get
            {
                if (_membersservice == null)
                    _membersservice = new MembersService();
                return _membersservice;
            }
        }

        private static SiteCountriesService _sitecountriesservice;
        private static SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesservice == null)
                    _sitecountriesservice = new SiteCountriesService();
                return _sitecountriesservice;
            }
        }

        private static MemberFilesService _memberfilesservice;
        private static MemberFilesService MemberFilesService
        {
            get
            {
                if (_memberfilesservice == null)
                    _memberfilesservice = new MemberFilesService();
                return _memberfilesservice;
            }
        }

        private static MemberFileTypesService _memberfiletypesservice;
        private static MemberFileTypesService MemberFileTypesService
        {
            get
            {
                if (_memberfiletypesservice == null)
                    _memberfiletypesservice = new MemberFileTypesService();
                return _memberfiletypesservice;
            }
        }

        private static GlobalSettingsService _globalsettingsservice;
        private static GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalsettingsservice == null)
                    _globalsettingsservice = new GlobalSettingsService();
                return _globalsettingsservice;
            }
        }

        static void Main(string[] args)
        {
            #region pre check processes
            bool preCheckOK = PreProcessChecks();

            if (!preCheckOK)
            {
                Console.WriteLine("=== Program terminated ===");
                return;
            }
            #endregion

            // Load up the reference files we need
            //categories.json
            //certifications.json
            //countries.json
            List<EnworldJson.Countries> countries = new List<EnworldJson.Countries>();
            string[] countrylines = File.ReadAllLines(ConfigurationManager.AppSettings["CountryJSONPath"]);
            foreach (string s in countrylines)
            {
                EnworldJson.Countries enworldCountry = new JavaScriptSerializer().Deserialize<EnworldJson.Countries>(s);
                countries.Add(enworldCountry);
            }
            //currencies.json
            //degrees.json
            //employment_preferences.json
            List<EnworldJson.JobType> jobtypes = new List<EnworldJson.JobType>();
            string[] jobtypelines = File.ReadAllLines(ConfigurationManager.AppSettings["JobTypeJSONPath"]);
            foreach (string s in jobtypelines)
            {
                EnworldJson.JobType enworldJobType = new JavaScriptSerializer().Deserialize<EnworldJson.JobType>(s);
                jobtypes.Add(enworldJobType);
            }

            //genders.json

            //C:\Temp\migration\taxonomies\genders.json
            List<EnworldJson.Gender> genders = new List<EnworldJson.Gender>();
            string[] genderlines = File.ReadAllLines(ConfigurationManager.AppSettings["GenderJSONPath"]);
            foreach (string s in genderlines)
            {
                EnworldJson.Gender enworldGender = new JavaScriptSerializer().Deserialize<EnworldJson.Gender>(s);
                genders.Add(enworldGender);
            }
            //industries.json
            //industry_experiences.json
            //job_function_experiences.json
            //language_levels.json
            List<EnworldJson.LanguageLevel> languages = new List<EnworldJson.LanguageLevel>();
            string[] languagelines = File.ReadAllLines(ConfigurationManager.AppSettings["LanguageLevelJSONPath"]);
            foreach (string s in languagelines)
            {
                EnworldJson.LanguageLevel enworldLanguage = new JavaScriptSerializer().Deserialize<EnworldJson.LanguageLevel>(s);
                languages.Add(enworldLanguage);
            }
            //marital_states.json
            //max_commutes.json
            //preferred_contacts.json
            //regions.json

            List<EnworldJson.Regions> regions = new List<EnworldJson.Regions>();
            string[] regionlines = File.ReadAllLines(ConfigurationManager.AppSettings["RegionsJSONPath"]);
            foreach (string s in regionlines)
            {
                EnworldJson.Regions enworldRegion = new JavaScriptSerializer().Deserialize<EnworldJson.Regions>(s);
                regions.Add(enworldRegion);
            }
            //sites.json
            //skills.json
            //visas.json

            #region For loop processing each file

            foreach (string dirPath in Directory.GetFiles(_TARGETFOLDER))
            {
                if (dirPath.EndsWith(".json"))
                {
                    ProcessFileAtPath(dirPath, genders, languages, countries, regions, jobtypes);
                    break;
                }

            }

            #endregion

        }


        private static bool PreProcessChecks()
        {
            bool workingFolderExists = Directory.Exists(_TARGETFOLDER);
            if (!workingFolderExists)
            {
                Console.WriteLine("Working folder not found.");
                return false;
            }

            bool workingFolderHasFiles = Directory.GetFiles(_TARGETFOLDER).Any();
            if (!workingFolderHasFiles)
            {
                Console.WriteLine("No files found to be processed within the 'Working' folder.");
                return false;
            }

            return true;
        }

        private static string GetGender(string gender, List<EnworldJson.Gender> genders)
        {
            foreach (EnworldJson.Gender g in genders)
            {
                if (gender == g._id["$oid"])
                {
                    return g.description.en;
                }
            }

            return string.Empty;
        }


        private static string GetLangauge(string[] langauge, List<EnworldJson.LanguageLevel> langauges)
        {
            string result = string.Empty;

            foreach (string lang in langauge)
            {
                foreach (EnworldJson.LanguageLevel level in langauges)
                {
                    if (lang == level.public_id)
                    {
                        if (level.parent_id != null)
                        {
                            // Look for parent Langauage
                            foreach (EnworldJson.LanguageLevel parentlevel in langauges)
                            {
                                if (level.parent_id["$oid"] == parentlevel._id["$oid"])
                                {
                                    result += parentlevel.description.en;
                                }
                            }

                            result += " (" + level.description.en + "), ";
                        }
                        else
                        {
                            result += level.description.en + ", ";
                        }
                    }
                }
            }

            return result.TrimEnd(new char[] { ',', ' ' });
        }

        private static void ProcessFileAtPath(string path, List<EnworldJson.Gender> genders, List<EnworldJson.LanguageLevel> languages, List<EnworldJson.Countries> countries, List<EnworldJson.Regions> regions, List<EnworldJson.JobType> jobtypes)
        {
            Console.Write("Processing file: " + path);

            string text = System.IO.File.ReadAllText(path);

            EnworldJson.RootObject[] enworldEntity = new JavaScriptSerializer().Deserialize<EnworldJson.RootObject[]>(text);
            int referringsiteid = Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]);
            int childsiteid = Convert.ToInt32(ConfigurationManager.AppSettings["ChildSiteID"]);

            GlobalSettings globalSetting = GlobalSettingsService.GetBySiteId(childsiteid).FirstOrDefault();

            if (globalSetting != null)
            {
                if (globalSetting.FtpFolderLocation.StartsWith("s3://") == false)
                {
                    memberFileFolder = ConfigurationManager.AppSettings["FTPHost"] + ConfigurationManager.AppSettings["MemberRootFolder"] + "/" + ConfigurationManager.AppSettings["MemberFilesFolder"];
                    memberFileFolderFormat = "{0}/{1}/";

                    string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                    string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                    string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                    FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
                }
                else
                {
                    IAwsS3 s3 = new AwsS3();
                    FileManagerService = new FileManager(s3);
                    memberFileFolder = ConfigurationManager.AppSettings["AWSS3MemberRootFolder"] + ConfigurationManager.AppSettings["AWSS3MemberFilesFolder"];
                    memberFileFolderFormat = "{0}/{1}";
                }
            }
            foreach (EnworldJson.RootObject memberObj in enworldEntity)
            {
                JXTPortal.Client.Salesforce.SalesforceIntegration.SObjRecord jxtmember = new JXTPortal.Client.Salesforce.SalesforceIntegration.SObjRecord();

                jxtmember.Id = memberObj.id;
                jxtmember.FirstName = memberObj.name.first;
                jxtmember.LastName = memberObj.name.last;
                jxtmember.First_Name_Local__c = memberObj.name.first_translated;
                jxtmember.Last_Name_Local__c = memberObj.name.last_translated;
                jxtmember.Email = memberObj.primary_email;
                jxtmember.ts2__EEO_Gender__c = GetGender(memberObj.gender_id, genders);
                jxtmember.Birthdate = memberObj.date_of_birth;
                jxtmember.MobilePhone = memberObj.contact.phone_mobile;
                jxtmember.Phone = memberObj.contact.phone_home;
                jxtmember.Secondary_Email__c = memberObj.contact.email_secondary;
                jxtmember.MailingStreet = memberObj.address.address1 + " " + memberObj.address.address2;
                jxtmember.MailingCity = memberObj.address.city;
                jxtmember.MailingPostalCode = memberObj.address.postal_code;
                jxtmember.MailingState = memberObj.address.region;

                foreach (EnworldJson.Countries country in countries)
                {
                    if (country.iso_code == memberObj.address.country)
                    {
                        jxtmember.MailingCountry = country.description.en.name;
                        break;
                    }
                }

                if (memberObj.language != null)
                {
                    jxtmember.Native_Language__c = GetLangauge(memberObj.language.levels, languages);
                    jxtmember.Second_Language__c = memberObj.language.other;
                    jxtmember.Second_Language_Proficiency__c = string.Empty;
                }

                if (memberObj.employments != null && memberObj.employments.Length > 0)
                {
                    jxtmember.Current_Company__c = memberObj.employments[0].company;
                    jxtmember.Current_Position__c = memberObj.employments[0].position;
                    if (memberObj.employments[0].salary != null)
                    {
                        jxtmember.Current_Fixed_Salary__c = memberObj.employments[0].salary.currency + " " + memberObj.employments[0].salary.amount;
                    }

                    int currentstartyear = Convert.ToInt32(memberObj.employments[0].startDate.Substring(0, 4));
                    int currentstartmonth = Convert.ToInt32(memberObj.employments[0].startDate.Substring(5, 2));
                    int startyear = 0;
                    int startmonth = 0;

                    foreach (EnworldJson.Employment employment in memberObj.employments)
                    {
                        if (employment.startDate != string.Empty)
                        {
                            startyear = Convert.ToInt32(employment.startDate.Substring(0, 4));
                            startmonth = Convert.ToInt32(employment.startDate.Substring(5, 2));

                            if (startyear > currentstartyear || (startyear >= currentstartyear && startmonth > currentstartmonth))
                            {
                                jxtmember.Current_Company__c = employment.company;
                                jxtmember.Current_Position__c = employment.position;
                                currentstartyear = startyear;
                                currentstartmonth = startmonth;

                                if (employment.salary != null)
                                {
                                    jxtmember.Current_Fixed_Salary__c = employment.salary.currency + " " + employment.salary.amount;
                                }
                            }
                        }
                    }
                }

                jxtmember.Industry__c = string.Empty;
                jxtmember.Job_Category__c = string.Empty;
                jxtmember.Job_Functions__c = string.Empty;
                jxtmember.Employment_Type__c = string.Empty;
                jxtmember.Salary_Period__c = string.Empty;
                jxtmember.Current_Fixed_Salary__c = string.Empty;
                jxtmember.Salary_Period__c = string.Empty;

                jxtmember.Desired_Country__c = jxtmember.MailingCountry;
                jxtmember.Desired_Other_Countries__c = string.Empty;
                if (memberObj.desired_position != null)
                {
                    List<string> desiredcountries = new List<string>();

                    foreach (string location in memberObj.desired_position.locations)
                    {
                        foreach (EnworldJson.Regions region in regions)
                        {
                            if (region.public_id == location)
                            {
                                jxtmember.Desired_Locations__c += region.description.en + ",";

                                if (region.parent_id != null)
                                {
                                    foreach (EnworldJson.Regions country in regions)
                                    {
                                        if (country._id["$oid"] == region.parent_id["$oid"])
                                        {
                                            desiredcountries.Add(country.description.en);
                                            break;
                                        }
                                    }
                                }

                                break;
                            }
                        }
                    }

                    if (desiredcountries.Count > 0)
                    {
                        desiredcountries.Sort();
                        jxtmember.Desired_Country__c = desiredcountries[0];

                        foreach (string dc in desiredcountries)
                        {
                            if (dc != jxtmember.Desired_Country__c && jxtmember.Desired_Other_Countries__c.Contains(dc) == false)
                            {
                                jxtmember.Desired_Other_Countries__c += dc + ",";
                            }
                        }

                        jxtmember.Desired_Other_Countries__c = jxtmember.Desired_Other_Countries__c.TrimEnd(new char[] { ',' });
                    }

                    jxtmember.Desired_Locations__c = jxtmember.Desired_Locations__c.TrimEnd(new char[] { ',' });

                    if (memberObj.desired_position.job_types != null && memberObj.desired_position.job_types.Count > 0)
                    {
                        foreach (string s in memberObj.desired_position.job_types)
                        {
                            foreach (EnworldJson.JobType jobtype in jobtypes)
                            {
                                if (s == jobtype.public_id)
                                {
                                    jxtmember.Employment_Type__c += jobtype.description.en + ",";
                                    break;
                                }
                            }
                        }

                        jxtmember.Employment_Type__c = jxtmember.Employment_Type__c.TrimEnd(new char[] { ',' });
                    }
                }

                InsertMember(childsiteid, memberObj, jxtmember);
            }

            Console.WriteLine("\r" + path + " successfully processed");
        }

        private static void InsertMember(int referringsiteid, EnworldJson.RootObject memberObj, JXTPortal.Client.Salesforce.SalesforceIntegration.SObjRecord jxtmember)
        {
            int mastersiteid = Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]);
            JXTPortal.Entities.Members member = MembersService.GetBySiteIdEmailAddress(mastersiteid, memberObj.primary_email);
            try
            {
                // Update the Member
                if (member != null)
                {
                    return;
                }
                else
                {
                    member = new Members();
                    member.RegisteredDate = DateTime.Now;
                }


                member.ExternalMemberId = memberObj.id; // Save the external memberid
                member.SiteId = mastersiteid;
                member.ReferringSiteId = referringsiteid;
                member.FirstName = memberObj.name.first;
                member.Surname = memberObj.name.last;
                member.EmailAddress = memberObj.primary_email;
                member.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                member.Username = memberObj.primary_email; // Username would be the email address
                //member.CountryId = countryid;

                member.Title = "Other"; // If the salutation is not found then default it to Other.

                // According to the API - The API  provides numeric value, map 1= Male,   2= female

                jxtmember.ts2__EEO_Gender__c = "M";
                if (jxtmember.ts2__EEO_Gender__c == "Female")
                    member.Gender = "F";

                //string countryName = string.Empty;



                //// Get the country
                //// Find if the country name from Site is found in the sitecountries.
                int countryid = 1;
                if (!string.IsNullOrWhiteSpace(jxtmember.MailingCountry))
                {
                    using (SiteCountries siteCountry = SiteCountriesService.GetBySiteId(mastersiteid).Where(s => s.SiteCountryName.ToLower() == jxtmember.MailingCountry.ToLower()).FirstOrDefault())
                    {
                        if (siteCountry != null)
                        {
                            countryid = siteCountry.CountryId;
                        }
                        else
                        {
                            // If not set the Global default country set for the site.
                            GlobalSettingsService gservice = new GlobalSettingsService();
                            using (TList<GlobalSettings> gslist = gservice.GetBySiteId(mastersiteid))
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

                member.Password = CommonService.EncryptMD5(ConfigurationManager.AppSettings["NewPassword"]);
                member.ValidateGuid = Guid.NewGuid();
                

                member.SearchField = String.Format("{0} {1}",
                                                       member.FirstName,
                                                       member.Surname);
                member.Valid = true;
                member.Validated = true;
                member.RequiredPasswordChange = true;
                member.LastLogon = DateTime.Now; // When loggin in User - set the last login
                member.LastModifiedDate = DateTime.Now; // Last Updated
                member.CandidateData =  new JavaScriptSerializer().Serialize(jxtmember);

                byte[] bytes = null;
                string filename = string.Empty;

                if (MembersService.Insert(member))
                {
                    Console.WriteLine(string.Format("Member Inserted - ID:{0} Name: {1} {2} Email: {3}", member.MemberId, member.FirstName, member.Surname, member.EmailAddress));
                    if (memberObj.attachments != null && memberObj.attachments.Length > 0)
                    {
                        foreach (EnworldJson.Attachment attachment in memberObj.attachments)
                        {
                            using (MemberFiles objMemberFiles = new MemberFiles())
                            {
                                filename = ConfigurationManager.AppSettings["AttachmentPath"] + "\\" + attachment.id + "\\" + attachment.filename;
                                if(File.Exists(filename))
                                {
                                    bytes = System.IO.File.ReadAllBytes(filename);

                                        objMemberFiles.MemberFileSearchExtension = Path.GetExtension(filename).Trim();
                                        objMemberFiles.MemberFileName = attachment.filename;
                                        objMemberFiles.MemberFileTitle = attachment.displayFilename;
                                        objMemberFiles.MemberId = member.MemberId;
                                        objMemberFiles.MemberFileTypeId = MemberFileTypeID(attachment.filename);
                                        objMemberFiles.DocumentTypeId = (int) PortalEnums.JobApplications.DocumentType.Resume;

                                        MemberFilesService.Insert(objMemberFiles);

                                        string extension = string.Empty;

                                        extension = objMemberFiles.MemberFileSearchExtension;
                                        string filepath = string.Format("MemberFiles_{0}{1}", objMemberFiles.MemberFileId, extension);
                                        string errormessage = string.Empty;

                                        FileManagerService.UploadFile(privateBucketName, string.Format(memberFileFolderFormat, memberFileFolder, objMemberFiles.MemberId), filepath, new MemoryStream(bytes), out errormessage);

                                        MemberFilesService.Update(objMemberFiles);

                                        Console.WriteLine(string.Format("Member File Inserted - ID:{0} File Name:{1} Display Name:{2}", objMemberFiles.MemberFileId, objMemberFiles.MemberFileName, objMemberFiles.MemberFileTitle));
                                }
                            }
                        }

                    }
                }

            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error: {0}\n{1}", ex.Message, ex.StackTrace);
            }

        }

        private static int MemberFileTypeID(string filename)
        {
            int _memberFileTypeID = 0;

            using (TList<MemberFileTypes> objMemberFileTypes = MemberFileTypesService.GetAll())
            {

                MemberFileTypes objMemberFileType = objMemberFileTypes.Find("MemberFileExtensions", System.IO.Path.GetExtension(filename).Trim());

                if (objMemberFileType != null)
                {
                    _memberFileTypeID = objMemberFileType.MemberFileTypeId;
                }

            }
            return _memberFileTypeID;
        }
    }
}
