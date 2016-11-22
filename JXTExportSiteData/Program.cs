using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal;
using System.Data;
using System.Configuration;
using JXTPortal.Entities;
using System.IO;

namespace JXTExportSiteData
{
    class Program
    {
        #region Properties

        private static MembersService _membersService;
        public static MembersService MembersDataService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new JXTPortal.MembersService();
                }
                return _membersService;
            }
        }

        private static MemberFilesService _memberFilesService;
        public static MemberFilesService MembersFileService
        {
            get
            {
                if (_memberFilesService == null)
                {
                    _memberFilesService = new JXTPortal.MemberFilesService();
                }
                return _memberFilesService;
            }
        }

        #endregion

        static void Main(string[] args)
        {
            //https://jxtissues.atlassian.net/browse/JMP-564

            int targetSiteID = int.Parse(System.Configuration.ConfigurationManager.AppSettings["TargetSiteID"]);

            string targetPath = System.Configuration.ConfigurationManager.AppSettings["DestinationPath"];
            string membersCSV_filename = System.Configuration.ConfigurationManager.AppSettings["MembersFileName"];
            string advertisersCSV_filename = System.Configuration.ConfigurationManager.AppSettings["AdvertisersFileName"];

            try
            {
                //Path checks
                if (PathChecks(targetPath, membersCSV_filename, advertisersCSV_filename))
                {
                    GenerateAdvertisersFile(targetSiteID, targetPath, advertisersCSV_filename);

                    GenerateMembersFile(targetSiteID, targetPath, membersCSV_filename);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Application terminated");
            }

        }

        private static bool PathChecks(string folderPath, string memberFileName, string advertiserFileName)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder path '" + folderPath + "' could not be found. Application terminated.");
                return false;
            }

            if (!File.Exists(folderPath + memberFileName))
            {
                Console.WriteLine("Member file path '" + folderPath + memberFileName + "' could not be found. Creating file.");
                FileStream newFile = File.Create(folderPath + memberFileName);
                newFile.Close();
            }

            if (!File.Exists(folderPath + advertiserFileName))
            {
                Console.WriteLine("Advertiser file path '" + folderPath + advertiserFileName + "' could not be found.  Creating file.");
                FileStream newFile = File.Create(folderPath + advertiserFileName);
                newFile.Close();
            }

            return true;
        }

        private static void GenerateAdvertisersFile(int siteID, string destinationPath, string csvFileName)
        {
            Console.WriteLine("Generating Advertiser File...");


            using (TList<Advertisers> adveritsers = new AdvertisersService().Find("SiteID = " + siteID)) //advertisers reference list
            using (TList<AdvertiserUsers> advUsers = new AdvertiserUsersService().GetByUserNameSiteId("", siteID)) //advertiser users lists           
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(destinationPath + csvFileName)) //file write stream
            {
                //display heading
                file.WriteLine("FirstName\tSurname\tEmail\tAccount Type\tCompanyName\tAccount Status\tValidated");

                foreach (AdvertiserUsers u in advUsers)
                {
                    Advertisers thisAdvertiser = (from m in adveritsers where m.AdvertiserId == u.AdvertiserId select m).FirstOrDefault();

                    //more to go here
                    file.WriteLine(
                        string.Format(
                        "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                        u.FirstName, u.Surname, u.Email,
                        (PortalEnums.Advertiser.AccountType)thisAdvertiser.AdvertiserAccountTypeId,
                        thisAdvertiser.CompanyName,
                        (PortalEnums.Advertiser.AccountStatus)thisAdvertiser.AdvertiserAccountStatusId,
                        (!u.Validated.HasValue || !u.Validated.Value) ? "Not Validated" : "Validated"
                        ));
                }
            }
            Console.WriteLine("Advertiser File Generated Successfully...");
        }

        private static void GenerateMembersFile(int siteID, string destinationPath, string csvFileName)
        {
            Console.WriteLine("Generating Member File...");

            using(TList<Members> members = new MembersService().GetBySiteId(siteID))
            {
                //open stream
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(destinationPath + csvFileName))
                {
                    //display heading
                    file.WriteLine("MemberID\tTitle\tFirst Name\tSurname\tUsername\tEmail Address\tCompany\tMobile Phone\tRegistered Date\tLast Modified Date\tLast Logon\tValidated\tResume\tCover Letter");

                    TList<MemberFiles> memberFiles = new TList<MemberFiles>();

                    foreach (Members dr in members)
                    {
                        memberFiles = new TList<MemberFiles>();

                        int thisMemberID = dr.MemberId;
                        try
                        {
                            string thisMemberCSV = string.Format(
                                "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}",
                                thisMemberID,
                                dr.Title,
                                dr.FirstName,
                                dr.Surname,
                                dr.Username,
                                dr.EmailAddress,
                                dr.Company,
                                !string.IsNullOrWhiteSpace(dr.MobilePhone) ? "=\"" + dr.MobilePhone.Trim() + "\"" : string.Empty,
                                dr.RegisteredDate.ToString("dd-MMM-yyyy"),
                                dr.LastModifiedDate.HasValue ? dr.LastModifiedDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                dr.LastLogon.HasValue ? dr.LastLogon.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                dr.Validated ? "Validated" : "Not Validated"
                            );

                            memberFiles = MembersFileService.GetByMemberId(thisMemberID);

                            //Resume
                            {
                                MemberFiles resumeFile = memberFiles.Where(c => c.DocumentTypeId == (int)PortalEnums.Members.MemberFileTypes.Resume).FirstOrDefault();

                                if (resumeFile != null)
                                {
                                    string fileName = thisMemberID.ToString() + "_" + resumeFile.MemberFileName;
                                    System.IO.FileStream _FileStream = new System.IO.FileStream(destinationPath + fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                                    _FileStream.Write(resumeFile.MemberFileContent, 0, resumeFile.MemberFileContent.Length);
                                    _FileStream.Close();
                                    thisMemberCSV += "\t" + fileName;
                                }
                                else
                                    thisMemberCSV += "\t";
                            }

                            //Cover Letter
                            {
                                MemberFiles coverFile = memberFiles.Where(c => c.DocumentTypeId == (int)PortalEnums.Members.MemberFileTypes.CoverLetter).FirstOrDefault();

                                if (coverFile != null)
                                {
                                    string fileName = thisMemberID.ToString() + "_" + coverFile.MemberFileName;
                                    System.IO.FileStream _FileStream = new System.IO.FileStream(destinationPath + fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                                    _FileStream.Write(coverFile.MemberFileContent, 0, coverFile.MemberFileContent.Length);
                                    _FileStream.Close();
                                    thisMemberCSV += "\t" + fileName;
                                }
                                else
                                    thisMemberCSV += "\t";
                            }


                            file.WriteLine(thisMemberCSV);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Failed to generate record for member ID " + thisMemberID + ": " + e.Message);
                            Console.WriteLine(e.StackTrace);
                        }
                    }
                }
            }

            Console.WriteLine("Member File Generated Successfully...");
        }

    }
}
