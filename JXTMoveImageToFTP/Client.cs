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

        public void ProcessAdvertisers()
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
                        if (site.SiteAdminLogo != null && site.SiteAdminLogo.Length > 0)
                        {
                            Console.WriteLine("{0} Start uploading Site Admin Logo for SiteID: {1} SiteURL: {2} ...", DateTime.Now, site.SiteID, site.SiteURL);

                            MemoryStream ms = new MemoryStream(site.SiteAdminLogo);
                            Image img = Image.FromStream(ms);
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

                            string newpath = string.Format("{0}{1}/{2}/Sites_{3}.{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"], site.SiteID, extension);

                            // Upload to FTP

                            Console.WriteLine("{0} Uploading file to {1}", DateTime.Now, newpath);

                            ftpClient.UploadFileFromStream(ms, newpath, out errormsg);

                            if (string.IsNullOrWhiteSpace(errormsg))
                            {
                                // No Error, Site Logo and URL

                                site.SiteAdminLogoURL = string.Format("Sites_{0}.{1}", site.SiteID, extension);
                                // site.SiteAdminLogo = null;

                                sitesRepository.Update(site);
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("{0} Error: {1}", DateTime.Now, errormsg);
                }
            }
            else
            {
                Console.WriteLine("{0} Error: {1}", DateTime.Now, errormsg);
            }
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
                        if (site.SiteAdminLogo != null && site.SiteAdminLogo.Length > 0)
                        {
                            Console.WriteLine("{0} Start uploading Site Admin Logo for SiteID: {1} SiteURL: {2} ...", DateTime.Now, site.SiteID, site.SiteURL);

                            MemoryStream ms = new MemoryStream(site.SiteAdminLogo);
                            Image img = Image.FromStream(ms);
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

                            string newpath = string.Format("{0}{1}/{2}/Sites_{3}.{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"], site.SiteID, extension);

                            // Upload to FTP

                            Console.WriteLine("{0} Uploading file to {1}", DateTime.Now, newpath);

                            ftpClient.UploadFileFromStream(ms, newpath, out errormsg);

                            if (string.IsNullOrWhiteSpace(errormsg))
                            {
                                // No Error, Site Logo and URL

                                site.SiteAdminLogoURL = string.Format("Sites_{0}.{1}", site.SiteID, extension);
                                // site.SiteAdminLogo = null;

                                sitesRepository.Update(site);
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("{0} Error: {1}", DateTime.Now, errormsg);
                }
            }
            else
            {
                Console.WriteLine("{0} Error: {1}", DateTime.Now, errormsg);
            }
        }
    }
}
