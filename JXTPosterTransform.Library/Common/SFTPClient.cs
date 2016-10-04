using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using WinSCP;
using System.Configuration;
using JXTPosterTransform.Library.Models;

namespace JXTPosterTransform.Library.Common
{
    /*
     FULL Path of the file, File Starts with, FTP hostname, FTP username, FTP password.
     Path of the folder, File Starts with, FTP hostname, FTP username, FTP password.
     
     */
    public class SFTPClient
    {
        public ResponseClass Pull(ClientSetupModels.PullXmlFromSFTP SFTP, string strFilename) // , string strRemotePath, string strFilename, string strFileStartsWith
        {
            ResponseClass responseClass = new ResponseClass();

            if (!string.IsNullOrWhiteSpace(SFTP.Host))
            {
                // Remote XML file - is not an XML throw error
                if (string.IsNullOrWhiteSpace(SFTP.FileStartsWith) && !SFTP.Filename.ToLower().Contains(".xml"))
                {
                    responseClass.strMessage = "Not a valid file, needs to be an XML - " + SFTP.Filename;
                    return responseClass;
                }
                try
                {
                    // If the remote path is empty or null check the root.
                    if (string.IsNullOrWhiteSpace(SFTP.RemotePath)) 
                        SFTP.RemotePath = "/";

                    // Setup session options
                    SessionOptions sessionOptions = new SessionOptions
                    {
                        Protocol = Protocol.Sftp,
                        HostName = SFTP.Host, // "113.192.21.100",
                        UserName = SFTP.Username, //"enworld",
                        Password = SFTP.Password, //"GwOxB5nQQl9e",
                        //SshHostKeyFingerprint = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx",
                    };

                    sessionOptions.GiveUpSecurityAndAcceptAnySshHostKey = true;

                    using (Session session = new Session())
                    {
                        // Connect
                        session.Open(sessionOptions);

                        //string remotePath = "/home/enworld/migration/candidates/"; //home/user/
                        string localPath = ConfigurationManager.AppSettings["FTPTempStorage"];

                        // Get list of files in the directory
                        RemoteDirectoryInfo directoryInfo = session.ListDirectory(SFTP.RemotePath);

                        // Select the most recent file
                        RemoteFileInfo latest = null;

                        if (!string.IsNullOrWhiteSpace(SFTP.FileStartsWith))
                        {
                            latest =
                                directoryInfo.Files
                                    .Where(file => !file.IsDirectory && file.Name.ToLower().Contains(".xml") && file.Name.ToLower().StartsWith(SFTP.FileStartsWith))
                                    .OrderByDescending(file => file.LastWriteTime)
                                    .FirstOrDefault();
                            /*directoryInfo.Files
                                .Where(file => !file.IsDirectory && file.Name.ToLower().Contains(".xml") && file.Name.ToLower().StartsWith("zenergy"))
                                .OrderByDescending(file => file.LastWriteTime)
                                .FirstOrDefault();*/


                            // Any file at all?
                            if (latest == null)
                            {
                                responseClass.strMessage = string.Format("No file found in the path {0} which starts with - {1}", SFTP.RemotePath, SFTP.FileStartsWith);
                                return responseClass;
                            }
                        }
                        else
                        {

                            latest =
                                directoryInfo.Files
                                    .Where(file => !file.IsDirectory && file.Name.Equals(SFTP.Filename))
                                //.OrderByDescending(file => file.LastWriteTime)
                                    .FirstOrDefault();

                            // Any file at all?
                            if (latest == null)
                            {
                                responseClass.strMessage = string.Format("No file found in the path {0} with filename - {1}", SFTP.RemotePath, SFTP.Filename);
                                return responseClass;
                            }

                        }

                        // Download the selected file
                        session.GetFiles(session.EscapeFileMask(SFTP.RemotePath + latest.Name), localPath).Check();

                        responseClass.blnSuccess = true;
                        responseClass.FullFilePath = ConfigurationManager.AppSettings["FTPTempStorage"] + strFilename + "_Raw.xml";

                        // Rename the file
                        Utils.RenameFile(localPath + latest.Name, responseClass.FullFilePath);

                    }

                }
                catch (Exception e)
                {
                    responseClass.strMessage = string.Format("Error while Pulling the file({0}): {1}", SFTP.Filename, e);
                }
            }
            else
            {
                responseClass.strMessage = "The SFTP Host is empty.";
            }

            return responseClass;
        }
    }
}
