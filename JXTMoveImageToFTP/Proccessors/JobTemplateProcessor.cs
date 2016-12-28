using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using JXTPortal.Common;
using System.Configuration;
using JXTPortal.Data.Dapper.Entities.Core;
using System.IO;
using System.Drawing;
using JXTPortal.Data.Dapper.Repositories;

namespace JXTMoveImageToFTP.Proccessors
{
    public class JobTemplateProcessor: IProcessor
    {
        ILog _logger;
        IJobTemplatesRepository _repository;
        public JobTemplateProcessor(IJobTemplatesRepository repository)
        {
            _logger = LogManager.GetLogger(typeof(JobTemplateProcessor));
            _repository = repository;
        }

        public int Priority
        {
            get { return 50; }
        }

        public void Begin(IFtpClient ftpClient)
        {
            _logger.Info("Start moving Job Template Logo Binary Data to FTP");

            string errorMsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["JobTemplatesFolder"]);

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

            List<JobTemplatesEntity> jobTemplates = _repository.SelectAll();
            jobTemplates = jobTemplates.Where(j => j.JobTemplateLogo != null && j.JobTemplateLogo.Length > 0 && string.IsNullOrEmpty(j.JobTemplateLogoUrl)).ToList();

            _logger.Info(string.Format("Found {0} job templates to update", jobTemplates.Count()));

            //iterate each site
            foreach (JobTemplatesEntity jobTemplate in jobTemplates)
            {
                _logger.Info(string.Format("Start uploading Job Template Logo for JobTemplateID: {0} Job Template Description: {1}", jobTemplate.JobTemplateID, jobTemplate.JobTemplateDescription));

                MemoryStream ms = new MemoryStream(jobTemplate.JobTemplateLogo);
                string extension = Image.FromStream(ms).GetExtension();
                string newFileName = string.Format("JobTemplates_{0}.{1}", jobTemplate.JobTemplateID, extension);
                string newpath = string.Format("{0}{1}/{2}/{3}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["JobTemplatesFolder"], newFileName);

                // Upload to FTP
                    _logger.Info(string.Format("Uploading file to {0}", newpath));

                ftpClient.UploadFileFromStream(ms, newpath, out errorMsg);

                if (string.IsNullOrWhiteSpace(errorMsg))
                {
                    jobTemplate.JobTemplateLogoUrl = newFileName;

                    _repository.Update(jobTemplate);
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