using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Configuration;
using JXTPortal.Common;
using JXTPortal.Data.Dapper.Entities.Core;
using System.IO;
using System.Drawing;
using JXTPortal.Data.Dapper.Repositories;

namespace JXTMoveImageToFTP.Proccessors
{
    public class SiteProcessor : IProcessor
    {
        ILog _logger;
        ISitesRepository _sitesRepository;
        public SiteProcessor(ISitesRepository sitesRepository)
        {
            _logger = LogManager.GetLogger(typeof(SiteProcessor));
            _sitesRepository = sitesRepository;
        }

        public int Priority { get { return 10; } }
        public void Begin(IFtpClient ftpClient)
        {
            _logger.Info("Start moving Sites Binary Data to FTP");

            string errorMsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"]);
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errorMsg))
            {
                _logger.Info(string.Format("Creating ftp directory: {0}", path));
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

            //Only migrate sites that have a logo, but not one that has already been migrated
            IEnumerable<SitesEntity> sites = _sitesRepository.SelectAll()
                                                            .Where(site => site.SiteAdminLogo != null && site.SiteAdminLogo.Length > 0 && string.IsNullOrEmpty(site.SiteAdminLogoUrl))
                                                            .ToList();

            _logger.Debug(string.Format("Found {0} sites to migrate the admin logo", sites.Count()));

            foreach (SitesEntity site in sites)
            {
                _logger.Info(string.Format("Start uploading Site Admin Logo for SiteID: {0} SiteURL: {1}", site.SiteID, site.SiteURL));

                MemoryStream ms = new MemoryStream(site.SiteAdminLogo);
                string extension = Image.FromStream(ms).GetExtension();

                string newFileName = string.Format("Sites_{0}.{1}", site.SiteID, extension);
                string newpath = string.Format("{0}{1}/{2}/{3}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"], newFileName);

                // Upload to FTP
                _logger.Info(string.Format("Uploading file to {0}", newpath));

                ftpClient.UploadFileFromStream(ms, newpath, out errorMsg);
                if (string.IsNullOrWhiteSpace(errorMsg))
                {
                    // No Error, Site Logo and URL
                    site.SiteAdminLogoUrl = newFileName;
                    _sitesRepository.Update(site);

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