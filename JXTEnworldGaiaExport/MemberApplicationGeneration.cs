using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web.Script.Serialization;

namespace JXTEnworldGaiaExport
{
    internal class MemberApplicationGeneration
    {
        internal static bool Start(int masterSiteID, string lastJobApplicationID, out List<UploadTracker> applicationTrackers)
        {
            applicationTrackers = new List<UploadTracker>();
            try
            {
                DataSet jobApplicationDS = new DataSet();
                DataTable dt;
                JobApplicationService jobApplicationService = new JobApplicationService();

                if (!string.IsNullOrWhiteSpace(lastJobApplicationID))
                    jobApplicationDS = jobApplicationService.CustomGetNewJobApplications(masterSiteID, int.Parse(lastJobApplicationID), null);
                else
                    jobApplicationDS = jobApplicationService.CustomGetNewJobApplications(masterSiteID, null, null);

                dt = jobApplicationDS.Tables[0];

                foreach (DataRow drApplication in dt.Rows)
                {
                    try
                    {
                        string strResumeFileName = string.Empty;
                        string strCoverLetterFileName = string.Empty;

                        string strApplicationID = drApplication["JobApplicationID"].ToString();
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Application ID about to be uploaded:" + strApplicationID);


                        //string filename = "CountryCode_KellyJobReferenceNumber_JXTJobID_JXTJobApplicationID_Resume.Extension";

                        List<FileNames> filesToUpload = new List<FileNames>();

                        // If there is a Resume
                        if (drApplication["MemberResumeFile"] != null && !string.IsNullOrWhiteSpace(drApplication["MemberResumeFile"].ToString()))
                        {
                            /*strResumeFileName =                            
                            string.Format("{0}_{1}_{2}_{3}_Resume{4}",
                                                                    drApplication["Abbr"].ToString(),
                                                                    drApplication["RefNo"].ToString().Trim(),
                                                                    drApplication["JobID"].ToString(),
                                                                    drApplication["JobApplicationID"].ToString(),
                                                                    Path.GetExtension(ConfigurationManager.AppSettings["ResumeFolder"] + drApplication["MemberResumeFile"].ToString()));
                            */
                            filesToUpload.Add(new FileNames(drApplication["JobApplicationID"].ToString(), ConfigurationManager.AppSettings["ResumeFolder"] + drApplication["MemberResumeFile"].ToString(), drApplication["MemberResumeFile"].ToString()));
                        }
                        else
                            strResumeFileName = string.Empty;

                        // If there is a Coverletter
                        //if (drApplication["MemberCoverLetterFile"] != null && !string.IsNullOrWhiteSpace(drApplication["MemberCoverLetterFile"].ToString()))
                        //{
                        //    strCoverLetterFileName = string.Format("{0}_{1}_{2}_{3}_Coverletter{4}",
                        //                                            drApplication["Abbr"].ToString(),
                        //                                            drApplication["RefNo"].ToString().Trim(),
                        //                                            drApplication["JobID"].ToString(),
                        //                                            drApplication["JobApplicationID"].ToString(),
                        //                                            Path.GetExtension(ConfigurationManager.AppSettings["CoverletterFolder"] + drApplication["MemberCoverLetterFile"].ToString()));

                        //    filesToUpload.Add(new FileNames(drApplication["JobApplicationID"].ToString(), ConfigurationManager.AppSettings["CoverletterFolder"] + drApplication["MemberCoverLetterFile"].ToString(), strCoverLetterFileName));
                        //}
                        //else
                        //    strCoverLetterFileName = string.Empty;


                        Application thisApp = new Application
                        {
                            //JXTMemberID = int.Parse(drApplication["MemberID"].ToString()),
                            refno = drApplication["RefNo"].ToString().Trim(),
                            applicationid = drApplication["JobApplicationID"].ToString(),
                            date = "yyyy-MM-dd hh:mm:ss",
                            firstname = drApplication["FirstName"] != null ? drApplication["FirstName"].ToString() : string.Empty,
                            lastname = drApplication["Surname"] != null ? drApplication["Surname"].ToString() : string.Empty,
                            email = drApplication["EmailAddress"] != null ? drApplication["EmailAddress"].ToString() : string.Empty,
                            resume = new List<Resume>()
                        };

                        foreach (FileNames resumeFileName in filesToUpload)
                        {
                            byte[] fileByte = File.ReadAllBytes(resumeFileName.fromFilename);

                            //Note we only sending FileName and FileContent for applications
                            thisApp.resume.Add(new Resume
                            {
                                FileName = resumeFileName.toFilename, /* NOTE we used the "toFileName" as the file title assigned above */
                                FileContent = Convert.ToBase64String(fileByte, 0, fileByte.Length)
                            });
                        }

                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        string newJson = ser.Serialize(thisApp);

                        //Save to temp
                        string tempPath = ConfigurationManager.AppSettings["FileTempPath"] + "/Application_" + drApplication["JobApplicationID"] + ".json";
                        FileStream fs = File.Create(tempPath);
                        byte[] info = new UTF8Encoding(true).GetBytes(newJson);
                        fs.Write(info, 0, info.Length);
                        fs.Close();

                        UploadTracker newTracker = new UploadTracker
                        {
                            itemID = int.Parse(strApplicationID),
                            filePath = ConfigurationManager.AppSettings["FileTempPath"] + "/",
                            fileName = "Application_" + drApplication["JobApplicationID"] + ".json"
                        };
                        applicationTrackers.Add(newTracker);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: " + ex.Message);

                        //int exceptionID = LogExceptionAndEmail(siteXML, strApplicationID, ex);

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
