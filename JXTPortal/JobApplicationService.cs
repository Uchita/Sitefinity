using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using JXTPortal.Common;
using JXTPortal.Entities;
using log4net;
using NotesFor.HtmlToOpenXml;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace JXTPortal
{
    /// <summary>
    /// An component type implementation of the 'JobApplication' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class JobApplicationService : JXTPortal.JobApplicationServiceBase
    {
        private ILog _logger;
        private string resumeFolder;
        private string customFolder;
        string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the JobApplicationService class.
        /// </summary>
        public JobApplicationService()
            : base()
        {
            _logger = LogManager.GetLogger(typeof(MembersService));

            if (SessionData.Site == null || !SessionData.Site.IsUsingS3)
            {
                resumeFolder = ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"];
                customFolder = ConfigurationManager.AppSettings["FTPCustomJobApplications"];

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                resumeFolder = ConfigurationManager.AppSettings["AWSS3ResumePath"];
                customFolder = ConfigurationManager.AppSettings["AWSS3CustomJobApplicationsPath"];
            }
        }
        #endregion Constructors


        #region Properties

        private JobsService _JobsService;
        private JobsService JobsService
        {
            get
            {
                if (_JobsService == null)
                    _JobsService = new JobsService();
                return _JobsService;
            }
        }

        private GlobalSettingsService _GlobalSettingsService;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_GlobalSettingsService == null)
                    _GlobalSettingsService = new GlobalSettingsService();
                return _GlobalSettingsService;
            }
        }
        private MembersService _memebrsService;
        private MembersService MembersService
        {
            get
            {
                if (_memebrsService == null)
                    _memebrsService = new MembersService();
                return _memebrsService;
            }
        }

        public IFileManager FileManagerService { get; set; }


        #endregion

        public void ProcessRequest(HttpContext context)
        {
            int jobappid = 0;


            if (SessionData.Member == null)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("You need to be logged in to upload the file.");

                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Params["JobAppID"]) && int.TryParse(context.Request.Params["JobAppID"], out jobappid)
                    && !string.IsNullOrEmpty(context.Request.Params["type"]))
            {


                Entities.JobApplication jobapp = GetByJobApplicationId(jobappid);

                if (context.Request.Files.Count > 0 && jobapp != null)
                {

                    HttpFileCollection files = context.Request.Files;

                    if (files.Count > 0)
                    {
                        HttpPostedFile file = files[0];
                        string fname = context.Server.MapPath("~/uploads/" + file.FileName);


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
                            context.Response.ContentType = "text/plain";
                            context.Response.Write("Please upload a valid file.");

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

                                    context.Response.ContentType = "text/plain";
                                    if (string.IsNullOrEmpty(errormessage))
                                    {
                                        if (Update(jobapp))
                                        {
                                            context.Response.Write(""); //"Resume Uploaded Successfully!"
                                        }
                                        else
                                        {
                                            context.Response.ContentType = "text/plain";
                                            context.Response.Write("false");
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
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Failed");
                }
            }
        }


        public bool ApplyJobWithCustomApplication(HttpRequest Request, int JobID, ref int? JobApplicationID,
                                                    string strCustomQuestionaireXML, string strCustomApplicationFormXML,
                                                    HttpPostedFile memberResume, bool blnDraft, string strPDFurl, ref string strErrorMessage)
        {
            Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);

            bool blnSuccess = false;

            // Check existing member
            if (member != null)
            {
                Regex r = new Regex("(?:[^a-z0-9.]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);


                if (!JobApplicationID.HasValue)
                {

                    using (JobApplication jobapp = new JobApplication())
                    {
                        string strUrlReferral = Utils.GetCookieDomain(Request.Cookies["JobsViewed"], JobID);

                        jobapp.ApplicationDate = DateTime.Now;
                        jobapp.JobId = JobID;
                        jobapp.MemberId = member.MemberId;
                        jobapp.Draft = blnDraft;

                        if (!string.IsNullOrWhiteSpace(strCustomQuestionaireXML))
                            jobapp.CustomQuestionnaireXml = strCustomQuestionaireXML;

                        jobapp.JobAppValidateId = new Guid();
                        jobapp.SiteIdReferral = SessionData.Site.SiteId;
                        jobapp.UrlReferral = strUrlReferral;
                        jobapp.FirstName = member.FirstName;
                        jobapp.Surname = member.Surname;
                        jobapp.EmailAddress = member.EmailAddress;
                        jobapp.MobilePhone = member.MobilePhone;
                        jobapp.ApplicationStatus = (int)PortalEnums.JobApplications.ApplicationStatus.Applied;

                        // Update the Job Application Type ID from Global settings.

                        using (TList<JXTPortal.Entities.GlobalSettings> globalSetting = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                        {
                            if (globalSetting.Count > 0)
                            {
                                if (globalSetting[0].JobApplicationTypeId.HasValue)
                                {
                                    jobapp.JobApplicationTypeId = globalSetting[0].JobApplicationTypeId.Value;
                                }
                            }
                        }

                        Insert(jobapp);
                        JobApplicationID = jobapp.JobApplicationId;

                    }


                }


                using (JobApplication jobApplication = GetByJobApplicationId(JobApplicationID.Value))
                {
                    if (jobApplication != null)
                    {
                        jobApplication.FirstName = member.FirstName;
                        jobApplication.Surname = member.Surname;
                        jobApplication.EmailAddress = member.EmailAddress;
                        jobApplication.MobilePhone = member.MobilePhone;

                        jobApplication.Draft = blnDraft;
                        jobApplication.ApplicationDate = DateTime.Now;

                        if (!string.IsNullOrWhiteSpace(strCustomQuestionaireXML))
                            jobApplication.CustomQuestionnaireXml = strCustomQuestionaireXML;

                        // If Resume file is uploaded.
                        if (memberResume != null)
                            jobApplication.MemberResumeFile = string.Format("{0}_Resume_{1}", JobApplicationID.Value, r.Replace(memberResume.FileName, "_"));

                        jobApplication.ExternalXmlFilename = JobApplicationID.ToString() + ".xml";

                        // Set the PDF url.
                        strPDFurl = "http://" + HttpContext.Current.Request.Url.Host + "/job/application/doc/aicd_scholarship_doc.aspx?appid=" + JobApplicationID.ToString();

                        Update(jobApplication); // Update twice to save the custom questions in the table.

                        // When not draft
                        if (UploadJobApplicationXMLAndGeneratePDF(JobApplicationID.Value, strCustomApplicationFormXML, blnDraft ? false : true, strPDFurl) && !blnDraft)
                        {
                            jobApplication.ExternalPdfFilename = JobApplicationID.ToString() + ".docx";
                        }

                        if (Update(jobApplication))
                        {

                            // Send the Emails when not a draft
                            if (!blnDraft)
                            {
                                int siteid = SessionData.Site.SiteId;
                                using (Entities.Jobs job = JobsService.GetByJobId(JobID))
                                {
                                    if (job != null)
                                    {
                                        siteid = job.SiteId;
                                    }
                                }

                                // Todo - Send the PDF in the email also also
                                MailService.SendMemberJobApplicationEmail(member);
                                MailService.SendAdvertiserJobApplicationEmail(member, jobApplication, new HybridDictionary(), siteid);
                            }

                            //Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBAPPLY_SUCCESS, "", "", ""));
                            blnSuccess = true;
                        }
                    }

                }




            }


            return blnSuccess;
        }

        public string ReadXMLFromFTP(string xmlFileName)
        {
            string fileContents = string.Empty;

            if (!string.IsNullOrWhiteSpace(xmlFileName))
            {
                bool useFTP = (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"]));
                string ftpcustompath = string.Empty;

                string errormessage = string.Empty;
                Stream downloadedfile = null;

                downloadedfile = FileManagerService.DownloadFile(bucketName, customFolder, xmlFileName, out errormessage);

                //CREATE A TXT READER (COULD BE BINARY OR ANY OTHER TYPE YOU NEED)
                if (downloadedfile != null)
                {
                    downloadedfile.Position = 0;
                    using (System.IO.TextReader tmpReader = new System.IO.StreamReader(downloadedfile))
                    {
                        //STORE THE FILE CONTENTS INTO A STRING
                        fileContents = tmpReader.ReadToEnd();
                    }
                }
            }

            return fileContents;
        }
        private bool UploadJobApplicationXMLAndGeneratePDF(int jobApplicationID, string strXML, bool blnGeneratePDF, string strPDFurl)
        {

            string strPDFName = jobApplicationID.ToString() + ".docx";
            string strXMLName = jobApplicationID.ToString() + ".xml";

            string errormessage = string.Empty;

            Regex r = new Regex("(?:[^a-z0-9.]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            // Upload XML to the App Server
            byte[] byteArray = Encoding.ASCII.GetBytes(strXML);
            MemoryStream xmlStream = new MemoryStream(byteArray);

            FileManagerService.UploadFile(bucketName, customFolder, strXMLName, xmlStream, out errormessage);

            if (!string.IsNullOrWhiteSpace(errormessage))
                return false;

            // When complete Generate the PDF from XML and upload the PDF
            if (blnGeneratePDF)
            {
                try
                {
                    // Todo - Future - according to the type of Form .. generate the PDF.

                    // Todo - Generate XML to PDF .. get the byte[]

                    System.Net.WebClient client = new System.Net.WebClient();
                    string html = client.DownloadString(strPDFurl);

                    using (MemoryStream generatedDocument = new MemoryStream())
                    {
                        using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                        {
                            MainDocumentPart mainPart = package.MainDocumentPart;
                            if (mainPart == null)
                            {
                                mainPart = package.AddMainDocumentPart();
                                new Document(new Body()).Save(mainPart);
                            }

                            HtmlConverter converter = new HtmlConverter(mainPart);
                            Body body = mainPart.Document.Body;

                            var paragraphs = converter.Parse(html);
                            for (int i = 0; i < paragraphs.Count; i++)
                            {
                                body.Append(paragraphs[i]);
                            }

                            mainPart.Document.Save();
                        }

                        byteArray = generatedDocument.ToArray();
                    }

                    xmlStream = new MemoryStream(byteArray);

                    FileManagerService.UploadFile(bucketName, customFolder, strPDFName, xmlStream, out errormessage);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }

            return true;
        }


    }//End Class

} // end namespace
