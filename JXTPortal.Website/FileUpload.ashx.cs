using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using JXTPortal.Common;
using JXTPortal.Entities;
using System.Web.Script.Serialization;
using JXTPortal.JobApplications.Models;

namespace JXTPortal.Website
{
    /// <summary>
    /// Summary description for FileUploadTest
    /// </summary>
    public class FileUploadTest : IHttpHandler, IRequiresSessionState
    {
        private string resumeFolder;

        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        public IFileManager FileManagerService { get; set; }
        
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

        private class ViewDataUploadFilesResult
        {
            public string ReturnString { get; set; }
        }

        private void SetOutput(ref HttpContext context, string strResult)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var rk = new System.Collections.Generic.List<ViewDataUploadFilesResult>();
            rk.Add(new ViewDataUploadFilesResult() { ReturnString = strResult });

            var uploadedFiles = new { files = rk.ToArray() };
            var jsonObj = js.Serialize(uploadedFiles);
            context.Response.Write(jsonObj.ToString());
        }

        public void ProcessRequest(HttpContext context)
        {
            if (!SessionData.Site.IsUsingS3)
            {
                resumeFolder = ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"];

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                resumeFolder = ConfigurationManager.AppSettings["AWSS3ResumePath"];
            }

            context.Response.ContentType = "text/plain";//"application/json";

            int jobappid = 0;
            int jobid = 0;


            if (SessionData.Member == null)
            {
                SetOutput(ref context, "You need to be logged in to upload the file.");
                //context.Response.Write("You need to be logged in to upload the file.");

                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Params["jobid"]) && int.TryParse(context.Request.Params["jobid"], out jobid)
                    && !string.IsNullOrEmpty(context.Request.Params["type"]))
            {
                /*AicdSponsorshipModel cFormModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

                if (cFormModel == null)
                {
                    SetOutput(ref context, "Your Session has expired, Reloading the application now.");
                    return;
                }

                // Save it as a Draft.
                job.application.aicd_scholarship.SaveDraft(cFormModel, false);*/

                using (TList<JobApplication> jobApplicationList = JobApplicationService.CustomGetByJobIdMemberId(jobid, SessionData.Member.MemberId))
                {
                    if (jobApplicationList != null && jobApplicationList.Count > 0 && jobApplicationList[0].Draft == true)
                    {
                        jobappid = jobApplicationList[0].JobApplicationId;
                    }
                }

                if (jobappid < 1)
                {
                    SetOutput(ref context, "Your Session has expired, Reloading the application now.");
                    return;
                }


                Entities.JobApplication jobapp = JobApplicationService.GetByJobApplicationId(jobappid);

                if (context.Request.Files.Count > 0 && jobapp != null)
                {

                    HttpFileCollection files = context.Request.Files;

                    if (files.Count > 0)
                    {
                        HttpPostedFile file = files[0];
                        string fname = file.FileName;

                        if ((file.ContentLength / (Math.Pow(1024, 2))) > 1)
                        {
                            SetOutput(ref context, "The file uploaded exceeds the maximum 1Mb limit.");
                            
                            return;
                        }

                        foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                        {
                            fname = System.IO.Path.GetFileName(fname).Trim().Replace(c.ToString(), "");
                        }
                        string extension = System.IO.Path.GetExtension(fname).Trim();

                        bool found = false;

                        foreach (string ext in ConfigurationManager.AppSettings["ApplicationFileTypes"].Split(new char[] { ',' }))
                        {
                            if (ext == extension)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            SetOutput(ref context, "Please upload a valid file.");
                            //context.Response.Write("Please upload a valid file.");

                            return;
                        }

                        // Upload to FTP

                        Regex r = new Regex("(?:[^a-z0-9.]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
                        string errormessage = string.Empty;

                        switch (context.Request.Params["type"])
                        {
                            case "resume":
                                {
                                    jobapp.MemberResumeFile = string.Format("{0}_Resume_{1}", jobappid, r.Replace(fname, "_"));
                                    
                                    FileManagerService.UploadFile(bucketName, resumeFolder, jobapp.MemberResumeFile, file.InputStream, out errormessage);
                                    
                                    if (string.IsNullOrEmpty(errormessage))
                                    {
                                        if (JobApplicationService.Update(jobapp))
                                        {
                                            SetOutput(ref context, "");
                                            //context.Response.Write(""); //"Resume Uploaded Successfully!"
                                        }
                                        else
                                        {
                                            SetOutput(ref context, "There was an error uploading the file, please try again.");
                                            //context.Response.Write("There was an error uploading the file, please try again.");
                                        }
                                    }
                                    else
                                    {
                                        context.Response.Write(errormessage);
                                    }

                                    break;
                                }

                            default:
                                break;
                        }

                    }

                }
                else
                {
                    SetOutput(ref context, "Application not found, please refresh the page.");
                    //context.Response.Write("Application not found, please refresh the page.");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}