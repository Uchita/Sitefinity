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
                            bool useFTP = (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"]));
                            string ftpclpath = string.Empty;
                            string ftpresumepath = string.Empty;
                            string ftpusername = string.Empty;
                            string ftppassword = string.Empty;
                            string errormessage = string.Empty;
                            FtpClient ftpclient = new FtpClient();
                            if (useFTP)
                            {
                                ftpclpath = ConfigurationManager.AppSettings["FTPJobApplyCoverLetterUrl"];
                                ftpresumepath = ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"];
                                ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                            }


                            if (DocType == (int)PortalEnums.JobApplications.DocumentType.CoverLetter)
                            {
                                if (!string.IsNullOrEmpty(jobapp.MemberCoverLetterFile))
                                {
                                    if (useFTP)
                                    {
                                        Stream downloadedfile = null;

                                        ftpclient.Host = ftpclpath;
                                        ftpclient.Username = ftpusername;
                                        ftpclient.Password = ftppassword;

                                        ftpclient.DownloadFileToClient(ftpclpath + jobapp.MemberCoverLetterFile, ref downloadedfile, out errormessage);

                                        if (string.IsNullOrEmpty(errormessage) && downloadedfile.Length > 0)
                                        {
                                            this.Response.ContentType = "application/octet-stream";
                                            this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + jobapp.MemberCoverLetterFile);
                                            this.Response.BinaryWrite(((MemoryStream)downloadedfile).ToArray());
                                            this.Response.End();
                                        }
                                    }
                                    else
                                    {

                                        string strFilePath = System.Configuration.ConfigurationManager.AppSettings["ApplicationUploadCoverLetterPaths"];
                                        string strFileFullPath = strFilePath + jobapp.MemberCoverLetterFile;
                                        string strMimeType = Entities.PortalEnums.MimeTypes.GetMimeType(System.IO.Path.GetExtension(strFileFullPath));

                                        if (System.IO.File.Exists(strFileFullPath))
                                        {
                                            // Get the Mime Type of the File
                                            if (strMimeType.Length > 0)
                                                this.Response.ContentType = strMimeType;
                                            else
                                                this.Response.ContentType = "application/octet-stream";

                                            this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + jobapp.MemberCoverLetterFile);
                                            this.Response.BinaryWrite(Utils.DecryptFile(strFileFullPath));
                                            this.Response.End();
                                            //this.Response.Flush();

                                        }
                                    }
                                }
                            }
                            else if (DocType == (int)PortalEnums.JobApplications.DocumentType.Resume)
                            {
                                if (!string.IsNullOrEmpty(jobapp.MemberResumeFile))
                                {
                                    if (useFTP)
                                    {
                                        Stream downloadedfile = null;


                                        ftpclient.Host = ftpresumepath;
                                        ftpclient.Username = ftpusername;
                                        ftpclient.Password = ftppassword;

                                        ftpclient.DownloadFileToClient(ftpresumepath + jobapp.MemberResumeFile, ref downloadedfile, out errormessage);

                                        if (string.IsNullOrEmpty( errormessage) && downloadedfile.Length > 0)
                                        {
                                            this.Response.ContentType = "application/octet-stream";
                                            this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + jobapp.MemberResumeFile);
                                            this.Response.BinaryWrite(((MemoryStream)downloadedfile).ToArray());
                                            this.Response.End();
                                        }
                                    }
                                    else
                                    {
                                        string strFilePath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ApplicationUploadResumePaths"]);
                                        string strFileFullPath = strFilePath + jobapp.MemberResumeFile;
                                        string strMimeType = Entities.PortalEnums.MimeTypes.GetMimeType(System.IO.Path.GetExtension(strFileFullPath));

                                        if (System.IO.File.Exists(strFileFullPath))
                                        {
                                            // Get the Mime Type of the File
                                            if (strMimeType.Length > 0)
                                                this.Response.ContentType = strMimeType;
                                            else
                                                this.Response.ContentType = "application/octet-stream";

                                            this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + jobapp.MemberResumeFile);
                                            this.Response.BinaryWrite(Utils.DecryptFile(strFileFullPath));
                                            this.Response.End();
                                            //this.Response.Flush();

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
}
