using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal;
using JXTPortal.Entities;
using System.Web.Script.Serialization;
using System.Data;
using System.Configuration;
using System.IO;
using JXTPortal.Common;
using JXTPortal.Core.FileManagement;
using JXT.Integration.AWS;

namespace JXTEnworldGaiaExport
{
    internal class MemberGeneration
    {
        private static string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];

        private static string memberFileFolder;
        public static IFileManager FileManagerService { get; set; }

        private static GlobalSettingsService _GlobalSettingsService = null;
        private static GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_GlobalSettingsService == null)
                {
                    _GlobalSettingsService = new GlobalSettingsService();
                }
                return _GlobalSettingsService;
            }
        }

        public static bool Start(int masterSiteID, string referringSiteIDs, DateTime lastExecutedDate, out List<UploadTracker> memberTrackers)
        {
            memberTrackers = new List<UploadTracker>();

            try
            {
                MembersService _ms = new MembersService();

                DataSet ds = null;
                DataTable dtMembers = null;
                DataTable dtMemberFiles = null;

                ds = _ms.CustomGetNewValidMembers(masterSiteID, lastExecutedDate);
                dtMembers = ds.Tables[0];
                dtMemberFiles = ds.Tables[1];
                // For each member
                foreach (DataRow drMember in dtMembers.Rows)
                {
                    if (referringSiteIDs.Contains(" " + drMember["ReferringSiteID"] + " "))
                    {
                        UploadTracker newTracker = new UploadTracker();

                        int CandidateID = int.Parse(drMember["MemberID"].ToString());// 386297; // 386316;

                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Generating JSON: Candidate #" + CandidateID);

                        Members thisMember = _ms.GetByMemberId(CandidateID);

                        GlobalSettings globalSetting = GlobalSettingsService.GetBySiteId(thisMember.SiteId).FirstOrDefault();

                        if (globalSetting != null)
                        {
                            if (globalSetting.FtpFolderLocation.StartsWith("s3://") == false)
                            {
                                memberFileFolder = ConfigurationManager.AppSettings["FTPHost"] + ConfigurationManager.AppSettings["MemberRootFolder"] + "/" + ConfigurationManager.AppSettings["MemberFilesFolder"];

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
                            }
                        }

                        //Deserialize member candidate data into a GaiaExportFormat class
                        GaiaExportFormat thisCandidateData = new GaiaExportFormat();

                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        if (!string.IsNullOrEmpty(thisMember.CandidateData))
                        {
                            thisCandidateData = ser.Deserialize<GaiaExportFormat>(thisMember.CandidateData);

                            thisCandidateData.Secondary_Email__c = thisMember.SecondaryEmail;

                            thisCandidateData.Domain = ""; // Todo domain

                            //get resumes
                            MemberFilesService _service = new MemberFilesService();

                            using (TList<MemberFiles> memberFiles = _service.GetByMemberId(thisMember.MemberId))
                            {
                                if (memberFiles != null)
                                {
                                    thisCandidateData.Resumes = new List<Resume>();

                                    foreach (var item in memberFiles)
                                    {
                                        string errormessage = string.Empty;

                                        byte[] memberfilecontent = null;

                                        if (!string.IsNullOrWhiteSpace(item.MemberFileUrl))
                                        {
                                            Stream ms = null;
                                            ms = FileManagerService.DownloadFile(bucketName, string.Format("{0}/{1}", memberFileFolder, item.MemberId), item.MemberFileUrl, out errormessage);
                                            ms.Position = 0;

                                            memberfilecontent = ((MemoryStream)ms).ToArray();
                                        }
                                        else
                                        {
                                            memberfilecontent = item.MemberFileContent;
                                        }

                                        thisCandidateData.Resumes.Add(new Resume
                                        {
                                            Title = item.MemberFileTitle,
                                            FileName = item.MemberFileName,
                                            UploadedDate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", item.LastModifiedDate),
                                            FileContent = Convert.ToBase64String(memberfilecontent, 0, item.MemberFileContent.Length)
                                        });
                                    }
                                }
                            }

                            thisCandidateData.JXTMemberID = thisMember.MemberId;
                            thisCandidateData.LastModifiedDate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                            thisCandidateData.CreatedDate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                            thisCandidateData.Validated = thisMember.Validated;

                            string newJson = ser.Serialize(thisCandidateData);

                            //Save to temp
                            string tempPath = ConfigurationManager.AppSettings["FileTempPath"] + "/Member_" + CandidateID + ".json";
                            FileStream fs = File.Create(tempPath);
                            byte[] info = new UTF8Encoding(true).GetBytes(newJson);
                            fs.Write(info, 0, info.Length);
                            fs.Close();

                            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Generating JSON: Candidate #" + CandidateID + " Success");

                            newTracker.itemID = CandidateID;
                            newTracker.filePath = ConfigurationManager.AppSettings["FileTempPath"] + "/";
                            newTracker.fileName = "Member_" + CandidateID + ".json";
                            memberTrackers.Add(newTracker);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] JSON Generation Failed: " + e.Message);
                return false;
            }
        }

    }
        
}
