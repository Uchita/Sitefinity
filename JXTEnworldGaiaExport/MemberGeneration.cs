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

namespace JXTEnworldGaiaExport
{
    internal class MemberGeneration
    {
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
                                        thisCandidateData.Resumes.Add(new Resume
                                        {
                                            Title = item.MemberFileTitle,
                                            FileName = item.MemberFileName,
                                            UploadedDate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", item.LastModifiedDate),
                                            FileContent = Convert.ToBase64String(item.MemberFileContent, 0, item.MemberFileContent.Length)
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
