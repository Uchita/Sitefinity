using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using JXTPortal.Entities;
using System.Data;
using System.Configuration;
using JXTPortal.Common;
using System.IO;

namespace JXTPortal.Website
{
    public partial class GetFile : System.Web.UI.Page
    {
        #region Declare variables

        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private string advertiserFolder, jobTemplateFolder, advertiserJobTemplateLogoFolder, consultantFolder;

        #endregion

        #region Properties
        public IFileManager FileManagerService { get; set; }

        private int AdvertiserID
        {
            get
            {
                int _advertiserID = -1;
                int.TryParse(Request.QueryString["AdvertiserId"], out _advertiserID);
                return _advertiserID;
            }
        }

        private int AdvertiserJobTemplateLogoID
        {
            get
            {
                int _advertiserJobTemplateLogoID = -1;
                int.TryParse(Request.QueryString["AdvertiserJobTemplateLogoID"], out _advertiserJobTemplateLogoID);
                return _advertiserJobTemplateLogoID;
            }
        }

        private int JobTemplateID
        {
            get
            {
                int _jobTemplateThumbID = 1;
                int.TryParse(Request.QueryString["JobTemplateId"], out _jobTemplateThumbID);
                return _jobTemplateThumbID;
            }
        }

        private int FileID
        {
            get
            {
                int _fileID = -1;
                int.TryParse(Request.QueryString["id"], out _fileID);
                return _fileID;
            }
        }

        private int ConsultantID
        {
            get
            {
                int _consultantID = -1;
                int.TryParse(Request.QueryString["consultantid"], out _consultantID);
                return _consultantID;
            }
        }

        private AdvertisersService _advertisersservice;
        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        private AdvertiserJobTemplateLogoService _advertiserJobTemplateLogoService;
        private AdvertiserJobTemplateLogoService AdvertiserJobTemplateLogoService
        {
            get
            {
                if (_advertiserJobTemplateLogoService == null)
                {
                    _advertiserJobTemplateLogoService = new AdvertiserJobTemplateLogoService();
                }
                return _advertiserJobTemplateLogoService;
            }
        }

        private JobTemplatesService _jobTemplatesService;
        private JobTemplatesService JobTemplatesService
        {
            get
            {
                if (_jobTemplatesService == null)
                {
                    _jobTemplatesService = new JobTemplatesService();
                }
                return _jobTemplatesService;
            }
        }

        private ConsultantsService _consultantsService;
        private ConsultantsService ConsultantsService
        {
            get
            {
                if (_consultantsService == null)
                {
                    _consultantsService = new ConsultantsService();
                }
                return _consultantsService;
            }
        }

        private SiteMappingsService _sitemappingsservice = null;
        private SiteMappingsService SiteMappingsService
        {
            get
            {
                if (_sitemappingsservice == null)
                {
                    _sitemappingsservice = new SiteMappingsService();
                }
                return _sitemappingsservice;
            }
        }


        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionData.Site.IsUsingS3)
            {
                advertiserFolder = string.Format("{0}{1}/{2}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertisersFolder"]);
                jobTemplateFolder = string.Format("{0}{1}/{2}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["JobTemplatesFolder"]);
                advertiserJobTemplateLogoFolder = string.Format("{0}{1}/{2}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"]);
                consultantFolder = string.Format("{0}{1}/{2}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["ConsultantsFolder"]);

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                advertiserFolder = ConfigurationManager.AppSettings["AWSS3MediaFolder"] + ConfigurationManager.AppSettings["AWSS3AdvertisersPath"];
                jobTemplateFolder = ConfigurationManager.AppSettings["AWSS3MediaFolder"] + ConfigurationManager.AppSettings["AWSS3JobTemplatesFolder"];
                advertiserJobTemplateLogoFolder = ConfigurationManager.AppSettings["AWSS3MediaFolder"] + ConfigurationManager.AppSettings["AWSS3AdvertiserJobTemplateLogoFolder"];
                consultantFolder = ConfigurationManager.AppSettings["AWSS3MediaFolder"] + ConfigurationManager.AppSettings["AWSS3ConsultantsPath"];
            }

            if (!Page.IsPostBack)
            {
                if (FileID > 0)
                {
                    GetFileByID();
                    //RenderFile(PageFileType.GenericFile, HttpContext.Current.Response, FileID);
                }
                else if (AdvertiserID > 0)
                {
                    CreateAdvertiserLogoImage();
                }
                else if (AdvertiserJobTemplateLogoID > 0)
                {
                    CreateAdvertiserJobTemplateLogo();
                }
                else if (JobTemplateID > 0)
                {
                    CreateAdvertiserJobTemplateThumbnail();
                }
                else if (ConsultantID > 0)
                {
                    CreateConsultantImage();
                }
            }
        }


        #endregion


        #region Methods

        protected void GetFileByID()
        {
            // ToDo - put Try and catch
            //try
            {

                if (FileID > 0)
                {
                    FilesService objfilesService = new FilesService();
                    using (Entities.Files objFile = objfilesService.GetByFileId(FileID))
                    {
                        // SECRUITY - check if part of the site
                        if (objFile != null && SessionData.Site.SiteId == objFile.SiteId)
                        {
                            String strFilePath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FileAndImagePaths"]);
                            String strFileFullPath = strFilePath + objFile.FileSystemName;
                            String strMimeType = Entities.PortalEnums.MimeTypes.GetMimeType(System.IO.Path.GetExtension(strFileFullPath));
                            if (System.IO.File.Exists(strFileFullPath))
                            {
                                // Get the Mime Type of the File
                                if (strMimeType.Length > 0)
                                    this.Response.ContentType = strMimeType;
                                else
                                    this.Response.ContentType = "application/octet-stream";

                                this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + objFile.FileName);
                                this.Response.BinaryWrite(System.IO.File.ReadAllBytes(strFileFullPath));
                                this.Response.Flush();
                                this.Response.End();
                            }
                        }
                    }
                }

            }
            //catch { }

        }

        /// <summary>
        /// Get Advertiser Logo Image
        /// </summary>
        private void CreateAdvertiserLogoImage()
        {
            using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID))
            {
                // SECRUITY - check if part of the site
                DataSet ds = AdvertisersService.CustomGetAllAdvertisers(SessionData.Site.SiteId, AdvertiserID);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (advertiser != null && (string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl) == false || advertiser.AdvertiserLogo != null))
                    {
                        System.Drawing.Image objOriginalImage = null;
                        string contenttype = string.Empty;
                        byte[] advertiserlogo = null;

                        if (!string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl))
                        {
                            string errormessage = string.Empty;
                            Stream ms = null;

                            ms = FileManagerService.DownloadFile(bucketName, advertiserFolder, advertiser.AdvertiserLogoUrl, out errormessage);
                            ms.Position = 0;

                            advertiserlogo = ((MemoryStream)ms).ToArray();
                        }
                        else
                        {
                            advertiserlogo = advertiser.AdvertiserLogo;
                        }

                        if (JXTPortal.Common.Utils.IsValidUploadImage("", advertiserlogo, out objOriginalImage, out contenttype))
                        {
                            Response.ContentType = contenttype;
                        }

                        Response.BinaryWrite(advertiserlogo);
                        Response.End();
                    }
                    else
                    {
                        // Default Advertiser logo image.
                        Response.ContentType = "image/jpeg";
                        System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath("~/images/default-avatar.jpg"), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                        byte[] image = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();
                        Response.BinaryWrite(image);
                        Response.End();
                    }
                }
                else
                {
                    // Default Advertiser logo image.
                    Response.ContentType = "image/jpeg";
                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath("~/images/default-avatar.jpg"), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                    byte[] image = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    Response.BinaryWrite(image);
                    Response.End();
                }


            }

        }
        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        /// <summary>
        /// Get Advertiser Job Template Logo
        /// </summary>
        private void CreateAdvertiserJobTemplateLogo()
        {
            using (JXTPortal.Entities.AdvertiserJobTemplateLogo advertiserJobTemplateLogo =
                AdvertiserJobTemplateLogoService.GetByAdvertiserJobTemplateLogoId(AdvertiserJobTemplateLogoID))
            {
                if (advertiserJobTemplateLogo != null && (string.IsNullOrWhiteSpace(advertiserJobTemplateLogo.JobTemplateLogoUrl) == false || advertiserJobTemplateLogo.JobTemplateLogo != null))
                {
                    using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(advertiserJobTemplateLogo.AdvertiserId))
                    {
                        // SECRUITY - Check if logo if part of the site.
                        DataSet ds = AdvertisersService.CustomGetAllAdvertisers(SessionData.Site.SiteId, advertiserJobTemplateLogo.AdvertiserId);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            System.Drawing.Image objOriginalImage = null;
                            string contenttype = string.Empty;

                            byte[] jobtemplatelogo = null;

                            if (!string.IsNullOrWhiteSpace(advertiserJobTemplateLogo.JobTemplateLogoUrl))
                            {
                                string errormessage = string.Empty;
                                Stream ms = null;

                                ms = FileManagerService.DownloadFile(bucketName, advertiserJobTemplateLogoFolder, advertiserJobTemplateLogo.JobTemplateLogoUrl, out errormessage);

                                ms.Position = 0;

                                jobtemplatelogo = ((MemoryStream)ms).ToArray();

                            }
                            else
                            {
                                jobtemplatelogo = advertiserJobTemplateLogo.JobTemplateLogo;
                            }

                            if (JXTPortal.Common.Utils.IsValidUploadImage("", jobtemplatelogo, out objOriginalImage, out contenttype))
                            {
                                Response.ContentType = contenttype;
                            }

                            Response.BinaryWrite(jobtemplatelogo);
                            Response.End();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get Advertiser Job Template Thumbnail
        /// </summary>
        private void CreateAdvertiserJobTemplateThumbnail()
        {
            using (JXTPortal.Entities.JobTemplates jobTemplate = JobTemplatesService.GetByJobTemplateId(JobTemplateID))
            {
                // Check if part of the site.
                if (jobTemplate != null && (string.IsNullOrWhiteSpace(jobTemplate.JobTemplateLogoUrl) == false || jobTemplate.JobTemplateLogo != null))
                {
                    using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(jobTemplate.AdvertiserId))
                    {
                        // SECRUITY - Check if logo if part of the site.
                        DataSet ds = AdvertisersService.CustomGetAllAdvertisers(SessionData.Site.SiteId, jobTemplate.AdvertiserId);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            System.Drawing.Image objOriginalImage = null;
                            string contenttype = string.Empty;

                            byte[] jobtemplatelogo = null;

                            if (!string.IsNullOrWhiteSpace(jobTemplate.JobTemplateLogoUrl))
                            {
                                string errormessage = string.Empty;
                                string filepath = string.Format("{0}{1}/{2}/{3}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["JobTemplatesFolder"], jobTemplate.JobTemplateLogoUrl);
                                Stream ms = null;

                                FileManagerService.DownloadFile(bucketName, jobTemplateFolder, jobTemplate.JobTemplateLogoUrl, out errormessage);

                                ms.Position = 0;

                                jobtemplatelogo = ((MemoryStream)ms).ToArray();

                            }
                            else
                            {
                                jobtemplatelogo = jobTemplate.JobTemplateLogo;
                            }


                            if (JXTPortal.Common.Utils.IsValidUploadImage("", jobtemplatelogo, out objOriginalImage, out contenttype))
                            {
                                Response.ContentType = contenttype;
                            }

                            Response.BinaryWrite(jobtemplatelogo);
                            Response.End();
                        }
                    }
                }
            }
        }

        private void CreateConsultantImage()
        {
            int count = 0;
            string sSiteId = SessionData.Site.SiteId.ToString();

            using (TList<SiteMappings> sitemappings = SiteMappingsService.GetByMasterSiteId(SessionData.Site.MasterSiteId))
            {
                if (sitemappings.Count > 0)
                {
                    sSiteId += "," + SessionData.Site.MasterSiteId.ToString();

                    foreach (SiteMappings sitemapping in sitemappings)
                    {
                        if (sitemapping.SiteId != SessionData.Site.SiteId)
                        {
                            sSiteId += "," + sitemapping.SiteId.ToString();
                        }
                    }
                }
            }

            using (TList<JXTPortal.Entities.Consultants> consultants = ConsultantsService.GetPaged(string.Format("SiteID IN ({0}) AND Valid = 1 AND ConsultantID = {1}", sSiteId, ConsultantID), "", 0, Int32.MaxValue, out count))
            {
                if (consultants.Count > 0)
                {
                    JXTPortal.Entities.Consultants consultant = consultants[0];
                    if (consultant.ImageUrl != null)
                    {
                        System.Drawing.Image objOriginalImage = null;
                        string contenttype = string.Empty;

                        byte[] consultantimage = null;

                        if (!string.IsNullOrWhiteSpace(consultant.ConsultantImageUrl))
                        {
                            string errormessage = string.Empty;
                            Stream ms = null;

                            ms = FileManagerService.DownloadFile(bucketName, consultantFolder, consultant.ConsultantImageUrl, out errormessage);
                            ms.Position = 0;

                            consultantimage = ((MemoryStream)ms).ToArray();

                        }
                        else
                        {
                            consultantimage = consultant.ImageUrl;
                        }

                        if (JXTPortal.Common.Utils.IsValidUploadImage("", consultantimage, out objOriginalImage, out contenttype))
                        {
                            Response.ContentType = contenttype;
                        }

                        Response.BinaryWrite(consultantimage);
                        Response.End();
                    }
                }
            }
        }

        #endregion

        /*
        private enum PageFileType
        { 
            GenericFile = 1,
            AdvertiserLogo = 2,
            AdvertiserJobTemplateLogo = 3,
            AdvertiserJobTemplateThumbnail = 4
        }

        public void RenderFile(PageFileType type, HttpResponse currentResponse, int Id)
        {
            if (type == PageFileType.GenericFile)
            {
                GetFileByID();
            }
        }
        */

    }
}
