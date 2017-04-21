using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;



namespace JXTPortal.Website
{
    public partial class GetApplicationFile : System.Web.UI.Page
    {
        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private string privateBucketName = ConfigurationManager.AppSettings["AWSS3PrivateBucketName"];

        public IFileManager FileManagerService { get; set; }

        private string coverLetterFolder;
        private string resumeFolder;

        private int JobApplicationID
        {
            get
            {
                int _jobApplicationID = -1;
                int.TryParse(Request.QueryString["id"], out _jobApplicationID);
                return _jobApplicationID;
            }
        }

        private int DocType
        {
            get
            {
                int _docType = -1;
                int.TryParse(Request.QueryString["doctype"], out _docType);
                return _docType;
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

        private JobsService _jobsService;

        private JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                    _jobsService = new JobsService();
                return _jobsService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionData.Site.IsUsingS3)
            {
                coverLetterFolder = ConfigurationManager.AppSettings["FTPJobApplyCoverLetterUrl"];
                resumeFolder = ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"];

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                coverLetterFolder = ConfigurationManager.AppSettings["AWSS3CoverLetterPath"];
                resumeFolder = ConfigurationManager.AppSettings["AWSS3ResumePath"];
            }

            GetFile();
        }

        private void GetFile()
        {
            
            if (JobApplicationID > 0)
            {
                using (JXTPortal.Entities.JobApplication jobapp = JobApplicationService.GetByJobApplicationId(JobApplicationID))
                {
                    if (jobapp != null)
                    {
                        bool isValid = false;

                        if (SessionData.Member != null)
                        {
                            if (SessionData.Member.MemberId == jobapp.MemberId)
                            {
                                isValid = true;
                            }
                        }

                        if (SessionData.AdvertiserUser != null)
                        {
                            if (JobsService.isAdvertiserJob(jobapp.JobId, jobapp.JobArchiveId))
                            {
                                isValid = true;
                            }
                        }

                        if (isValid)
                        {
                            if (DocType == (int)PortalEnums.JobApplications.DocumentType.CoverLetter)
                            {
                                if (!string.IsNullOrEmpty(jobapp.MemberCoverLetterFile))
                                {
                                    Stream downloadedfile = null;
                                    string errormessage = string.Empty;

                                    downloadedfile = FileManagerService.DownloadFile(privateBucketName, coverLetterFolder, jobapp.MemberCoverLetterFile, out errormessage);

                                    if (string.IsNullOrEmpty(errormessage) && downloadedfile.Length > 0)
                                    {
                                        downloadedfile.Position = 0;
                                        this.Response.ContentType = "application/octet-stream";
                                        this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + jobapp.MemberCoverLetterFile);
                                        this.Response.BinaryWrite(((MemoryStream)downloadedfile).ToArray());
                                        this.Response.End();
                                    }
                                }
                            }
                            else if (DocType == (int)PortalEnums.JobApplications.DocumentType.Resume)
                            {
                                if (!string.IsNullOrEmpty(jobapp.MemberResumeFile))
                                {
                                    Stream downloadedfile = null;
                                    string errormessage = string.Empty;

                                    downloadedfile = FileManagerService.DownloadFile(privateBucketName, resumeFolder, jobapp.MemberResumeFile, out errormessage);

                                    if (string.IsNullOrEmpty(errormessage) && downloadedfile.Length > 0)
                                    {
                                        downloadedfile.Position = 0;
                                        this.Response.ContentType = "application/octet-stream";
                                        this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + jobapp.MemberResumeFile);
                                        this.Response.BinaryWrite(((MemoryStream)downloadedfile).ToArray());
                                        this.Response.End();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
