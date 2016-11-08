using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using JXTPortal.Common;
using System.Configuration;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.Core;
using System.Drawing;

namespace JXTMoveImageToFTP
{
    public class Client
    {
        FtpClient ftpClient;
        ISitesRepository sitesRepository { get; set; }
        IAdvertisersRepository advertisersRepository { get; set; }
        IJobTemplatesRepository jobtemplatesRepository { get; set; }
        IAdvertiserJobTemplateLogoRepository advertiserjobtemplatelogoRepository { get; set; }
        IMemberFilesRepository memberfilesRepository { get; set; }
        IConsultantsRepository consultantsRepository { get; set; }

        public Client(ISitesRepository sRepository, IAdvertisersRepository advRepository, IJobTemplatesRepository jtRepository, IAdvertiserJobTemplateLogoRepository ajtlRepository, IMemberFilesRepository mfRepository, IConsultantsRepository cRepository)
        {
            Console.WriteLine("{0} Setting up FTP...", DateTime.Now);
            ftpClient = new FtpClient();
            ftpClient.Host = ConfigurationManager.AppSettings["FTPHost"];
            ftpClient.Username = ConfigurationManager.AppSettings["FTPUsername"];
            ftpClient.Password = ConfigurationManager.AppSettings["FTPPassword"];

            sitesRepository = sRepository;
            advertisersRepository = advRepository;
            jobtemplatesRepository = jtRepository;
            advertiserjobtemplatelogoRepository = ajtlRepository;
            memberfilesRepository = mfRepository;
            consultantsRepository = cRepository;
        }

        private string GetImageExtension(Image img)
        {
            string extension = "bmp";

            if (ImageFormat.Gif.Equals(img.RawFormat))
            {
                extension = "gif";
            }
            else if (ImageFormat.Icon.Equals(img.RawFormat))
            {
                extension = "ico";
            }
            else if (ImageFormat.Jpeg.Equals(img.RawFormat))
            {
                extension = "jpg";
            }
            else if (ImageFormat.Png.Equals(img.RawFormat))
            {
                extension = "png";
            }
            return extension;
        }

        public void ProcessSites()
        {
            Console.WriteLine("{0} Start moving Sites Binary Data to FTP...", DateTime.Now);

            string errormsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"]);
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errormsg))
            {
                // Create Directory
                ftpClient.CreateDirectory(path, out errormsg);
            }

            if (string.IsNullOrWhiteSpace(errormsg))
            {
                // Change to the Sites Directory to make sure the directory exists.
                ftpClient.ChangeDirectory(path, out errormsg);

                if (string.IsNullOrWhiteSpace(errormsg))
                {
                    List<SitesEntity> siteslist = sitesRepository.SelectAll();
                    //iterate each site
                    foreach (SitesEntity site in siteslist)
                    {
                        if (site.SiteAdminLogo != null && site.SiteAdminLogo.Length > 0 && string.IsNullOrEmpty(site.SiteAdminLogoUrl))
                        {
                            Console.WriteLine("{0} Start uploading Site Admin Logo for SiteID: {1} SiteURL: {2} ...", DateTime.Now, site.SiteID, site.SiteURL);

                            MemoryStream ms = new MemoryStream(site.SiteAdminLogo);
                            Image img = Image.FromStream(ms);
                            string extension = GetImageExtension(img);

                            string newpath = string.Format("{0}{1}/{2}/Sites_{3}.{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"], site.SiteID, extension);

                            // Upload to FTP

                            Console.WriteLine("{0} Uploading file to {1}", DateTime.Now, newpath);

                            ftpClient.UploadFileFromStream(ms, newpath, out errormsg);

                            if (string.IsNullOrWhiteSpace(errormsg))
                            {
                                // No Error, Site Logo and URL

                                site.SiteAdminLogoUrl = string.Format("Sites_{0}.{1}", site.SiteID, extension);

                                sitesRepository.Update(site);
                            }
                            else
                            {
                                Console.WriteLine("{0} Upload Error: {1}", DateTime.Now, errormsg);
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("{0} Change Directory Error: {1}", DateTime.Now, errormsg);
                }
            }
            else
            {
                Console.WriteLine("{0} Create Directory Error: {1}", DateTime.Now, errormsg);
            }
        }

        public void ProcessAdvertisers()
        {
            Console.WriteLine("{0} Start moving Advertisers Binary Data to FTP...", DateTime.Now);

            string errormsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertisersFolder"]);
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errormsg))
            {
                // Create Directory
                ftpClient.CreateDirectory(path, out errormsg);
            }

            if (string.IsNullOrWhiteSpace(errormsg))
            {
                // Change to the Sites Directory to make sure the directory exists.
                ftpClient.ChangeDirectory(path, out errormsg);

                if (string.IsNullOrWhiteSpace(errormsg))
                {
                    List<AdvertisersEntity> advertiserslist = advertisersRepository.SelectAll();
                    //iterate each site
                    foreach (AdvertisersEntity advertiser in advertiserslist)
                    {
                        if (advertiser.AdvertiserLogo != null && advertiser.AdvertiserLogo.Length > 0 && string.IsNullOrEmpty(advertiser.AdvertiserLogoUrl))
                        {
                            Console.WriteLine("{0} Start uploading Advertiser Logo for AdvertiserID: {1} Company Name: {2} ...", DateTime.Now, advertiser.AdvertiserID, advertiser.CompanyName);

                            MemoryStream ms = new MemoryStream(advertiser.AdvertiserLogo);
                            Image img = Image.FromStream(ms);
                            string extension = GetImageExtension(img);

                            string newpath = string.Format("{0}{1}/{2}/Advertisers_{3}.{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.SiteID, extension);

                            // Upload to FTP

                            Console.WriteLine("{0} Uploading file to {1}", DateTime.Now, newpath);

                            ftpClient.UploadFileFromStream(ms, newpath, out errormsg);

                            if (string.IsNullOrWhiteSpace(errormsg))
                            {
                                advertiser.AdvertiserLogoUrl = string.Format("Advertisers_{0}.{1}", advertiser.SiteID, extension);
                                
                                advertisersRepository.Update(advertiser);
                            }
                            else
                            {
                                Console.WriteLine("{0} Upload Error: {1}", DateTime.Now, errormsg);
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("{0} Change Directory Error: {1}", DateTime.Now, errormsg);
                }
            }
            else
            {
                Console.WriteLine("{0} Create Directory Error: {1}", DateTime.Now, errormsg);
            }
        }

        public void ProcessAdvertiserJobTemplateLogo()
        {
            Console.WriteLine("{0} Start moving Advertiser Job Template Logo Binary Data to FTP...", DateTime.Now);

            string errormsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"]);
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errormsg))
            {
                // Create Directory
                ftpClient.CreateDirectory(path, out errormsg);
            }

            if (string.IsNullOrWhiteSpace(errormsg))
            {
                // Change to the Sites Directory to make sure the directory exists.
                ftpClient.ChangeDirectory(path, out errormsg);

                if (string.IsNullOrWhiteSpace(errormsg))
                {
                    List<AdvertiserJobTemplateLogoEntity> advertiserjobtemplatelogolist = advertiserjobtemplatelogoRepository.SelectAll();
                    //iterate each site
                    foreach (AdvertiserJobTemplateLogoEntity advertiserjobtemplatelogo in advertiserjobtemplatelogolist)
                    {
                        if (advertiserjobtemplatelogo.JobTemplateLogo != null && advertiserjobtemplatelogo.JobTemplateLogo.Length > 0 && string.IsNullOrEmpty(advertiserjobtemplatelogo.JobTemplateLogoUrl))
                        {
                            Console.WriteLine("{0} Start uploading Advertiser Job Template Logo for AdvertiserJobTemplateLogoID: {1} Job Logo Name: {2} ...", DateTime.Now, advertiserjobtemplatelogo.AdvertiserID, advertiserjobtemplatelogo.JobLogoName);

                            MemoryStream ms = new MemoryStream(advertiserjobtemplatelogo.JobTemplateLogo);
                            Image img = Image.FromStream(ms);
                            string extension = GetImageExtension(img);

                            string newpath = string.Format("{0}{1}/{2}/AdvertiserJobTemplateLogo_{3}.{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"], advertiserjobtemplatelogo.AdvertiserJobTemplateLogoID, extension);

                            // Upload to FTP

                            Console.WriteLine("{0} Uploading file to {1}", DateTime.Now, newpath);

                            ftpClient.UploadFileFromStream(ms, newpath, out errormsg);

                            if (string.IsNullOrWhiteSpace(errormsg))
                            {
                                advertiserjobtemplatelogo.JobTemplateLogoUrl = string.Format("AdvertiserJobTemplateLogo_{0}.{1}", advertiserjobtemplatelogo.AdvertiserJobTemplateLogoID, extension);

                                advertiserjobtemplatelogoRepository.Update(advertiserjobtemplatelogo);
                            }
                            else
                            {
                                Console.WriteLine("{0} Upload Error: {1}", DateTime.Now, errormsg);
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("{0} Change Directory Error: {1}", DateTime.Now, errormsg);
                }
            }
            else
            {
                Console.WriteLine("{0} Create Directory Error: {1}", DateTime.Now, errormsg);
            }
        }

        public void ProcessConsultants()
        {
            Console.WriteLine("{0} Start moving Consultants Binary Data to FTP...", DateTime.Now);

            string errormsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["ConsultantsFolder"]);
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errormsg))
            {
                // Create Directory
                ftpClient.CreateDirectory(path, out errormsg);
            }

            if (string.IsNullOrWhiteSpace(errormsg))
            {
                // Change to the Sites Directory to make sure the directory exists.
                ftpClient.ChangeDirectory(path, out errormsg);

                if (string.IsNullOrWhiteSpace(errormsg))
                {
                    List<ConsultantsEntity> consultantslist = consultantsRepository.SelectAll();
                    //iterate each site
                    foreach (ConsultantsEntity consultant in consultantslist)
                    {
                        if (consultant.ImageURL != null && consultant.ImageURL.Length > 0 && string.IsNullOrEmpty(consultant.ConsultantImageUrl))
                        {
                            Console.WriteLine("{0} Start uploading Consultant Image for ConsultantID: {1} Consultant Name: {2} {3} ...", DateTime.Now, consultant.ConsultantID, consultant.FirstName, consultant.LastName);

                            MemoryStream ms = new MemoryStream(consultant.ImageURL);
                            Image img = Image.FromStream(ms);
                            string extension = GetImageExtension(img);

                            string newpath = string.Format("{0}{1}/{2}/Consultants_{3}.{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["ConsultantsFolder"], consultant.ConsultantID, extension);

                            // Upload to FTP

                            Console.WriteLine("{0} Uploading file to {1}", DateTime.Now, newpath);

                            ftpClient.UploadFileFromStream(ms, newpath, out errormsg);

                            if (string.IsNullOrWhiteSpace(errormsg))
                            {
                                consultant.ConsultantImageUrl = string.Format("Consultants_{0}.{1}", consultant.ConsultantID, extension);

                                consultantsRepository.Update(consultant);
                            }
                            else
                            {
                                Console.WriteLine("{0} Upload Error: {1}", DateTime.Now, errormsg);
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("{0} Change Directory Error: {1}", DateTime.Now, errormsg);
                }
            }
            else
            {
                Console.WriteLine("{0} Create Directory Error: {1}", DateTime.Now, errormsg);
            }
        }

        public void ProcessJobTemplates()
        {
            Console.WriteLine("{0} Start moving Job Template Logo Binary Data to FTP...", DateTime.Now);

            string errormsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["JobTemplatesFolder"]);
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errormsg))
            {
                // Create Directory
                ftpClient.CreateDirectory(path, out errormsg);
            }

            if (string.IsNullOrWhiteSpace(errormsg))
            {
                // Change to the Sites Directory to make sure the directory exists.
                ftpClient.ChangeDirectory(path, out errormsg);

                if (string.IsNullOrWhiteSpace(errormsg))
                {
                    List<JobTemplatesEntity> jobtemplateslist = jobtemplatesRepository.SelectAll();
                    //iterate each site
                    foreach (JobTemplatesEntity jobtemplate in jobtemplateslist)
                    {
                        if (jobtemplate.JobTemplateLogo != null && jobtemplate.JobTemplateLogo.Length > 0 && string.IsNullOrEmpty(jobtemplate.JobTemplateLogoUrl))
                        {
                            Console.WriteLine("{0} Start uploading Job Template Logo for JobTemplateID: {1} Job Template Description: {2} ...", DateTime.Now, jobtemplate.JobTemplateID, jobtemplate.JobTemplateDescription);

                            MemoryStream ms = new MemoryStream(jobtemplate.JobTemplateLogo);
                            Image img = Image.FromStream(ms);
                            string extension = GetImageExtension(img);

                            string newpath = string.Format("{0}{1}/{2}/JobTemplates_{3}.{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["JobTemplatesFolder"], jobtemplate.JobTemplateID, extension);

                            // Upload to FTP

                            Console.WriteLine("{0} Uploading file to {1}", DateTime.Now, newpath);

                            ftpClient.UploadFileFromStream(ms, newpath, out errormsg);

                            if (string.IsNullOrWhiteSpace(errormsg))
                            {
                                jobtemplate.JobTemplateLogoUrl = string.Format("JobTemplates_{0}.{1}", jobtemplate.JobTemplateID, extension);

                                jobtemplatesRepository.Update(jobtemplate);
                            }
                            else
                            {
                                Console.WriteLine("{0} Upload Error: {1}", DateTime.Now, errormsg);
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("{0} Change Directory Error: {1}", DateTime.Now, errormsg);
                }
            }
            else
            {
                Console.WriteLine("{0} Create Directory Error: {1}", DateTime.Now, errormsg);
            }
        }

        public void ProcessMemberFiles()
        {

        }
    }
}
