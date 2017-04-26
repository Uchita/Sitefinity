using JXTPosterTransform.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WinSCP;

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

                        //string remotePath = "/"; //home/user/
                        string localPath = ConfigurationManager.AppSettings["FTPTempStorage"];

                        // Get list of files in the directory
                        RemoteDirectoryInfo directoryInfo = session.ListDirectory(SFTP.RemotePath);

                        // Select the most recent file
                        List<RemoteFileInfo> remoteFilesList = null;

                        if (!string.IsNullOrWhiteSpace(SFTP.FileStartsWith))
                        {
                            remoteFilesList = directoryInfo.Files
                                                           .Where(file => !file.IsDirectory &&
                                                                           file.Name.ToLower().Contains(".xml") &&
                                                                           file.Name.StartsWith(SFTP.FileStartsWith))
                                                           .OrderByDescending(file => file.LastWriteTime)
                                                           .ToList();
                            // Any file at all?
                            if (remoteFilesList == null)
                            {
                                responseClass.strMessage = string.Format("No file found in the path {0} which starts with - {1}", SFTP.RemotePath, SFTP.FileStartsWith);
                                return responseClass;
                            }
                        }
                        else
                        {
                            remoteFilesList = directoryInfo.Files
                                                           .Where(file => !file.IsDirectory &&
                                                                           file.Name.Equals(SFTP.Filename))
                                                           .ToList();
                            // Any file at all?
                            if (remoteFilesList == null)
                            {
                                responseClass.strMessage = string.Format("No file found in the path {0} with filename - {1}", SFTP.RemotePath, SFTP.Filename);
                                return responseClass;
                            }
                        }

                        List<ResponseClassFtpItem> listResponse = new List<ResponseClassFtpItem>();

                        for (int i = 0; i < remoteFilesList.Count; i++)
                        {
                            ResponseClassFtpItem fileItem = new ResponseClassFtpItem();
                            fileItem.FullFilePath = ConfigurationManager.AppSettings["FTPTempStorage"] + strFilename + i + "_Raw.xml";
                            listResponse.Add(fileItem);

                            session.GetFiles(session.EscapeFileMask(SFTP.RemotePath + remoteFilesList[i].Name), localPath).Check();

                            // Rename the file                          
                            Utils.RenameFile(localPath + remoteFilesList[i].Name, fileItem.FullFilePath);

                            //Remove the file from the FTP remote directory after load to the memory
                            session.RemoveFiles(session.EscapeFileMask(SFTP.RemotePath + remoteFilesList[i].Name));
                        }

                        //Success only when there is at least one file to process
                        if (remoteFilesList.Count > 0)
                        {
                            responseClass.blnSuccess = true;
                        }
                        else
                        {
                            responseClass.strMessage = string.Format("No files found for the query '{0}' ", SFTP.Filename);
                            responseClass.blnSuccess = false;
                        }

                        responseClass.ResponseClassFtpItemList = listResponse;
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