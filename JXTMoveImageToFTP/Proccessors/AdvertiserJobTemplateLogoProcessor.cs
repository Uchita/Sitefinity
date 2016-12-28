using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using JXTPortal.Common;
using System.Configuration;
using System.IO;
using System.Drawing;
using JXTPortal.Data.Dapper.Entities.Core;
using JXTPortal.Data.Dapper.Repositories;

namespace JXTMoveImageToFTP.Proccessors
{
    public class AdvertiserJobTemplateLogoProcessor : IProcessor
    {
        ILog _logger;
        IAdvertiserJobTemplateLogoRepository _repository;
        public AdvertiserJobTemplateLogoProcessor(IAdvertiserJobTemplateLogoRepository repository)
        {
            _logger = LogManager.GetLogger(typeof(AdvertiserJobTemplateLogoProcessor));
            _repository = repository;
        }

        public string Type { get { return "AdvertiserJobTemplateLogo"; } }

        public int Priority
        {
            get { return 30; }
        }

        public void Begin(IFtpClient ftpClient)
        {
            _logger.Info("Start moving Advertiser Job Template Logo Binary Data to FTP");

            string errorMsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"]);
           
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errorMsg))
            {
                 _logger.Debug(string.Format("Creating new FTP Directory: {0}", path));
                // Create Directory
                ftpClient.CreateDirectory(path, out errorMsg);
            }

            if (!string.IsNullOrWhiteSpace(errorMsg))
            { 
                _logger.Warn(string.Format("Create Directory Error: {0}", errorMsg));
                return;
            }

            // Change to the Sites Directory to make sure the directory exists.
            ftpClient.ChangeDirectory(path, out errorMsg);

            if (!string.IsNullOrWhiteSpace(errorMsg))
            {
                _logger.Warn(string.Format("Change Directory Error: {0}", errorMsg));
                return;
            }

            List<AdvertiserJobTemplateLogoEntity> advertiserjobtemplatelogolist = _repository.SelectAll();

            advertiserjobtemplatelogolist = advertiserjobtemplatelogolist.Where(a => a.JobTemplateLogo != null && a.JobTemplateLogo.Length > 0 && string.IsNullOrEmpty(a.JobTemplateLogoUrl)).ToList();

            _logger.Info(string.Format("Found {0} advertiser job template logo to update", advertiserjobtemplatelogolist.Count()));
            //iterate each site
            foreach (AdvertiserJobTemplateLogoEntity advertiserjobtemplatelogo in advertiserjobtemplatelogolist)
            {
                _logger.Info(string.Format("Start uploading Advertiser Job Template Logo for AdvertiserJobTemplateLogoID: {0} Job Logo Name: {1}", advertiserjobtemplatelogo.AdvertiserID, advertiserjobtemplatelogo.JobLogoName));

                MemoryStream ms = new MemoryStream(advertiserjobtemplatelogo.JobTemplateLogo);
                string extension = Image.FromStream(ms).GetExtension();
                string newFileName = string.Format("AdvertiserJobTemplateLogo_{0}.{1}", advertiserjobtemplatelogo.AdvertiserJobTemplateLogoID, extension); 
                string newpath = string.Format("{0}{1}/{2}/{3}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"],newFileName);

                // Upload to FTP
                _logger.Info(string.Format("Uploading file to {0}", newpath));

                ftpClient.UploadFileFromStream(ms, newpath, out errorMsg);

                if (string.IsNullOrWhiteSpace(errorMsg))
                {
                    advertiserjobtemplatelogo.JobTemplateLogoUrl =newFileName;

                    _repository.Update(advertiserjobtemplatelogo);
                    _logger.Info(string.Format("successfully Saved image {0}", newFileName));
                }
                else
                {
                    _logger.Warn(string.Format(" Upload Error: {0}", errorMsg));
                }
            }
        }
    }
}