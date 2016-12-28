using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using JXTPortal.Data.Dapper.Repositories;
using System.Configuration;
using JXTPortal.Common;
using JXTPortal.Data.Dapper.Entities.Core;
using System.IO;
using System.Drawing;

namespace JXTMoveImageToFTP.Proccessors
{
    public class AdvertiserProcessor : IProcessor
    {
        ILog _logger;
        IAdvertisersRepository _advertiserRepository;
        public AdvertiserProcessor(IAdvertisersRepository advertiserRepository)
        {
            _logger = LogManager.GetLogger(typeof(SiteProcessor));
            _advertiserRepository = advertiserRepository;
        }

        public string Type { get { return "Advertiser"; } }

        public int Priority
        {
            get { return 20; }
        }

        public void Begin(IFtpClient ftpClient)
        {
            _logger.Info("Start moving Advertisers Binary Data to FTP");
            
            string errorMsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertisersFolder"]);
           
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errorMsg))
            {
                _logger.Debug(string.Format("Creating FTP Directory: {0}", path));
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

            List<AdvertisersEntity> advertisers = _advertiserRepository.SelectAll();

            advertisers = advertisers.Where(advertiser => advertiser.AdvertiserLogo != null && advertiser.AdvertiserLogo.Length > 0 && string.IsNullOrEmpty(advertiser.AdvertiserLogoUrl)).ToList();
            _logger.Info(string.Format("Found {0} advertisers to migrate", advertisers.Count()));

            //iterate each site
            foreach (AdvertisersEntity advertiser in advertisers)
            {
                _logger.Info(string.Format("Start uploading Advertiser Logo for AdvertiserID: {0} Company Name: {1}", advertiser.AdvertiserID, advertiser.CompanyName));

                MemoryStream ms = new MemoryStream(advertiser.AdvertiserLogo);
                string extension = Image.FromStream(ms).GetExtension();
                string newFileName = string.Format("Advertisers_{0}.{1}", advertiser.SiteID, extension);
                string newpath = string.Format("{0}{1}/{2}/{3}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertisersFolder"], newFileName);

                // Upload to FTP
                _logger.Info(string.Format("Uploading file to {0}", newpath));

                ftpClient.UploadFileFromStream(ms, newpath, out errorMsg);

                if (string.IsNullOrWhiteSpace(errorMsg))
                {
                    advertiser.AdvertiserLogoUrl = newFileName;
                                
                    _advertiserRepository.Update(advertiser);
                    _logger.Info(string.Format("Successfully uploaded file to {0}", newFileName));
                }
                else
                {
                    _logger.Warn(string.Format("Upload Error: {0}", errorMsg));
                }
            }
        }
    }
}