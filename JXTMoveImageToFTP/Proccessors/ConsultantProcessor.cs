using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Common;
using System.Configuration;
using JXTPortal.Data.Dapper.Entities.Core;
using System.IO;
using System.Drawing;

namespace JXTMoveImageToFTP.Proccessors
{
    public class ConsultantProcessor: IProcessor
    {
        ILog _logger;
        IConsultantsRepository _repository;
        public ConsultantProcessor(IConsultantsRepository repository)
        {
            _logger = LogManager.GetLogger(typeof(ConsultantProcessor));
            _repository = repository;
        }

        public int Priority
        {
            get { return 40; }
        }

        public void Begin(IFtpClient ftpClient)
        {
            _logger.Info("Start moving Consultants Binary Data to FTP");

            string errorMsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["ConsultantsFolder"]);
            
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errorMsg))
            {
                _logger.Debug(string.Format("Creating FTP directory: {0}", path));

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

            List<ConsultantsEntity> consultants = _repository.SelectAll();
            consultants = consultants.Where(c => c.ImageURL != null && c.ImageURL.Length > 0 && string.IsNullOrEmpty(c.ConsultantImageUrl)).ToList();

            _logger.Info(string.Format("Found {0} consultants to update", consultants.Count()));
            
            //iterate each site
            foreach (ConsultantsEntity consultant in consultants)
            {
                _logger.Info(string.Format("Start uploading Consultant Image for ConsultantID: {0} Consultant Name: {1} {2}", consultant.ConsultantID, consultant.FirstName, consultant.LastName));

                MemoryStream ms = new MemoryStream(consultant.ImageURL);
                        
                string extension = Image.FromStream(ms).GetExtension();
                string newFileName = string.Format("Consultants_{0}.{1}", consultant.ConsultantID, extension);
                string newpath = string.Format("{0}{1}/{2}/{3}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["ConsultantsFolder"],newFileName);

                // Upload to FTP
                    _logger.Info(string.Format("Uploading file to {0}", newpath));

                ftpClient.UploadFileFromStream(ms, newpath, out errorMsg);

                if (string.IsNullOrWhiteSpace(errorMsg))
                {
                    consultant.ConsultantImageUrl = newFileName;

                    _repository.Update(consultant);
                    _logger.Info(string.Format("Successfully uploaded file to {0}", newFileName));
                }
                else
                {
                    _logger.Warn(string.Format("Upload Error: {0}", errorMsg));
                }
            }
        }
    }}