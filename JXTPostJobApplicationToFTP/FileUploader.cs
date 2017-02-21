using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Tamir.SharpSsh;
using log4net;

namespace JXTPostJobApplicationToFTP
{
    public class FileUploader : IFileUploader
    {
        ILog _logger;

        public FileUploader()
        {
            _logger = LogManager.GetLogger(typeof(FileUploader));

        }
       
        public bool UploadApplicationFiles(SitesXML siteXML, List<FileNames> filesToUpload)
        {
            if (siteXML.sftp)
                return UploadTempFilesToSFTP(siteXML, filesToUpload);
            else
                return UploadTempFilesToFTP(siteXML, filesToUpload);
        }

        public bool UploadFiles(SitesXML siteXML, List<FileNames> filesToUpload)
        {
            if (siteXML.sftp)
                return UploadTempFilesToSFTP(siteXML, filesToUpload);
            else
                return UploadTempFilesToFTP(siteXML, filesToUpload);
        }

        /// <summary>
        /// Upload xml and applications to FTP.
        /// </summary>
        /// <param name="siteXML"></param>
        /// <param name="filesToUpload"></param>
        /// <param name="JobApplicationID"></param>
        /// <param name="errormessage"></param>
        /// <returns></returns>
        private bool UploadTempFilesToFTP(SitesXML siteXML, List<FileNames> filesToUpload)
        {
            FtpWebRequest request = null;
            FileInfo fileInfo = null;
            foreach (FileNames fileNames in filesToUpload)
            {
                try
                {
                    request = (FtpWebRequest)WebRequest.Create(string.Format("{0}/{1}", siteXML.host, fileNames.toFilename));
                    request.Credentials = new NetworkCredential(siteXML.username, siteXML.password);
                    request.Proxy = null;
                    request.KeepAlive = true;

                    //FtpWebRequest request = GetRequest(Path.GetFileName(path));
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.UseBinary = true;

                    fileInfo = new FileInfo(fileNames.fromFilename);
                    request.ContentLength = fileInfo.Length;

                    // Create buffer for file contents
                    int buffLength = 16384;
                    byte[] buff = new byte[buffLength];

                    // Upload this file
                    _logger.InfoFormat("Uploading: {0}", fileNames.toFilename);

                    using (FileStream instream = fileInfo.OpenRead())
                    {
                        using (Stream outstream = request.GetRequestStream())
                        {
                            int bytesRead = instream.Read(buff, 0, buffLength);
                            while (bytesRead > 0)
                            {
                                outstream.Write(buff, 0, bytesRead);
                                bytesRead = instream.Read(buff, 0, buffLength);
                            }
                            outstream.Close();
                        }
                        instream.Close();
                    }

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();

                    _logger.InfoFormat("Finished Uploading: {0}", fileNames.toFilename);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return false;
                }
            }
            return true;
        }

        private bool UploadTempFilesToSFTP(SitesXML siteXML, List<FileNames> filesToUpload)
        {
            bool result = true;
            Sftp sftp = null;
            try
            {
                // Create instance for Sftp to upload given files using given credentials
                sftp = new Sftp(siteXML.host, siteXML.username, siteXML.password);
                
                sftp.Connect();

                foreach (FileNames fileNames in filesToUpload)
                {
                    if (File.Exists(fileNames.fromFilename))
                    {
                        _logger.InfoFormat("Uploading: {0}", fileNames.toFilename);

                        // Upload a file
                        sftp.Put(fileNames.fromFilename, (siteXML.folderPath != null ? siteXML.folderPath : string.Empty) + fileNames.toFilename);
                      
                        _logger.InfoFormat("Finished Uploading: {0}", fileNames.toFilename);
                    }
                    else
                    {
                        _logger.WarnFormat("File Not Found: ", fileNames.toFilename);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                result = false;
            }
            finally
            {
                if (sftp != null)
                {
                    sftp.Close();
                }
            }

            return result;
        }
    }
}
