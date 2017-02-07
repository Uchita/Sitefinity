using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using log4net;
using Tamir.SharpSsh;

namespace JXTPostDataToFTP
{
    public interface IFileUploader
    {
        bool UploadFiles(SitesXML siteXML, List<FileNames> filesToUpload);
    }

    internal class FileUploader : IFileUploader
    {
        ILog _logger = LogManager.GetLogger(typeof(FileUploader));

        public bool UploadFiles(SitesXML siteXML, List<FileNames> filesToUpload)
        {
            if (siteXML.sftp)
            {
                return UploadFilesToSFTP(siteXML, filesToUpload);
            }
            else
            {
                return UploadFilesToFTP(siteXML, filesToUpload);
            }
        }

        private bool UploadFilesToSFTP(SitesXML siteXML, List<FileNames> filesToUpload)
        {
            int totalFiles = filesToUpload.Count;
            _logger.InfoFormat("uploading {0} files, via SFTP", totalFiles);

            Sftp sftp = null;

            int successCount = 0;
            try
            {
                sftp = new Sftp(siteXML.host, siteXML.username, siteXML.password);
                sftp.Connect();

                foreach (FileNames fileNames in filesToUpload)
                {
                    if (File.Exists(fileNames.fromFilename))
                    {
                        // Upload a file
                        _logger.DebugFormat("Uploading: {0}", fileNames.fromFilename);
                        sftp.Put(fileNames.fromFilename, (siteXML.folderPath != null ? siteXML.folderPath : string.Empty) + fileNames.toFilename);
                        _logger.InfoFormat("Uploaded: {0}", fileNames.fromFilename);

                        // Delete file
                        File.Delete(fileNames.fromFilename);
                        _logger.InfoFormat("Removed temporary file: {0}", fileNames.fromFilename);
                        successCount++;
                    }
                    else
                    {
                        _logger.WarnFormat("File not found: {0}", fileNames.fromFilename);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            finally
            {
                if (sftp != null)
                {
                    sftp.Close();
                }
            }

            return successCount == totalFiles;
        }

        private bool UploadFilesToFTP(SitesXML siteXML, List<FileNames> filesToUpload)
        {
            int totalFiles = filesToUpload.Count;
            _logger.InfoFormat("uploading {0} files, via FTP", totalFiles);

            int successCount = 0;

            foreach (FileNames fileNames in filesToUpload)
            {
                if (UploadFileToFTP(siteXML, fileNames.fromFilename, fileNames.toFilename))
                {
                    successCount++;
                }
            }

            _logger.InfoFormat("Successfully uploaded {0} files");

            return successCount == totalFiles;
        }

        private bool UploadFileToFTP(SitesXML siteXML, string sourceFile, string destFile)
        {
            _logger.DebugFormat("Attempting to upload {0}", sourceFile);

            FtpWebRequest request = null;
            FileInfo fileInfo = null;

            if (!File.Exists(sourceFile))
            {
                _logger.WarnFormat("File not found: {0}", sourceFile);
                return false;
            }

            try
            {
                request = (FtpWebRequest)WebRequest.Create(string.Format("{0}/{1}", siteXML.host, destFile));
                request.Credentials = new NetworkCredential(siteXML.username, siteXML.password);
                request.Proxy = null;
                request.KeepAlive = true;

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;

                _logger.InfoFormat("Uploading file", sourceFile);

                fileInfo = new FileInfo(sourceFile);
                request.ContentLength = fileInfo.Length;

                int buffLength = 16384;
                byte[] buff = new byte[buffLength];

                // Upload this file
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
                _logger.InfoFormat("File Uploaded: {0}" + destFile);

                // Delete file
                File.Delete(sourceFile);
                _logger.InfoFormat("Deleted Temporary File: {0} " + sourceFile);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
            return true;
        }
    }
}
