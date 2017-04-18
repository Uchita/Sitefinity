using JXTPosterTransform.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WinSCP;
using log4net;

namespace JXTPosterTransform.Library.Common
{
    /*
     FULL Path of the file, File Starts with, FTP hostname, FTP username, FTP password.
     Path of the folder, File Starts with, FTP hostname, FTP username, FTP password.     
     */
    public class FTPClient
    {
        public ResponseClass Pull(ClientSetupModels.PullXmlFromFTP FTP, string strFilename) //, string strRemotePath, string strFilename, string strFileStartsWith)
        {
            ResponseClass responseClass = new ResponseClass();
            if (!string.IsNullOrWhiteSpace(FTP.Host))
            {
                // Remote XML file - is not an XML throw error
                if (string.IsNullOrWhiteSpace(FTP.FileStartsWith) && !FTP.Filename.ToLower().Contains(".xml"))
                {
                    responseClass.strMessage = "Not a valid file, needs to be an XML - " + FTP.Filename;
                    return responseClass;
                }

                try
                {
                    // If the remote path is empty or null check the root.
                    if (string.IsNullOrWhiteSpace(FTP.RemotePath))
                        FTP.RemotePath = "/";

                    // Setup session options
                    SessionOptions sessionOptions = new SessionOptions
                    {
                        Protocol = Protocol.Ftp,
                        HostName = FTP.Host, // "jobfeeds.jxt3.net",
                        UserName = FTP.Username, //"jobadder@jobfeeds.jxt3.net",
                        Password = FTP.Password, // "T{04%laAGoLD",
                        //SshHostKeyFingerprint = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx",
                    };

                    using (Session session = new Session())
                    {
                        // Connect
                        session.Open(sessionOptions);

                        //string remotePath = "/"; //home/user/
                        string localPath = ConfigurationManager.AppSettings["FTPTempStorage"];

                        // Get list of files in the directory
                        RemoteDirectoryInfo directoryInfo = session.ListDirectory(FTP.RemotePath);

                        // Select the most recent file
                        List<RemoteFileInfo> remoteFilesList = null;

                        if (!string.IsNullOrWhiteSpace(FTP.FileStartsWith))
                        {
                            remoteFilesList = directoryInfo.Files
                                                           .Where(file => !file.IsDirectory &&
                                                                           file.Name.ToLower().Contains(".xml") &&
                                                                           file.Name.StartsWith(FTP.FileStartsWith))
                                                           .OrderByDescending(file => file.LastWriteTime)
                                                           .ToList();
                            // Any file at all?
                            if (remoteFilesList == null)
                            {
                                responseClass.strMessage = string.Format("No file found in the path {0} which starts with - {1}", FTP.RemotePath, FTP.FileStartsWith);
                                return responseClass;
                            }
                        }
                        else
                        {
                            remoteFilesList = directoryInfo.Files
                                                           .Where(file => !file.IsDirectory &&
                                                                           file.Name.Equals(FTP.Filename))
                                                           .ToList();
                            // Any file at all?
                            if (remoteFilesList == null)
                            {
                                responseClass.strMessage = string.Format("No file found in the path {0} with filename - {1}", FTP.RemotePath, FTP.Filename);
                                return responseClass;
                            }
                        }

                        List<ResponseClassFtpItem> listResponse = new List<ResponseClassFtpItem>();

                        for (int i = 0; i < remoteFilesList.Count; i++)
                        {
                            ResponseClassFtpItem fileItem = new ResponseClassFtpItem();
                            fileItem.FullFilePath = ConfigurationManager.AppSettings["FTPTempStorage"] + strFilename + i + "_Raw.xml";
                            listResponse.Add(fileItem);

                            session.GetFiles(session.EscapeFileMask(FTP.RemotePath + remoteFilesList[i].Name), localPath).Check();

                            // Rename the file                          
                            Utils.RenameFile(localPath + remoteFilesList[i].Name, fileItem.FullFilePath);

                            //Remove the file from the FTP remote directory after load to the memory
                            session.RemoveFiles(session.EscapeFileMask(FTP.RemotePath + remoteFilesList[i].Name));
                        }

                        //Success only when there is at least one file to process
                        if (remoteFilesList.Count > 0)
                        {
                            responseClass.blnSuccess = true;
                        }
                        else
                        {
                            responseClass.strMessage = string.Format("No files found for the query '{0}' ", FTP.Filename);
                            responseClass.blnSuccess = false;
                        }

                        responseClass.ResponseClassFtpItemList = listResponse;
                    }
                }
                catch (Exception e)
                {
                    responseClass.strMessage = string.Format("Error while Pulling the file({0}): {1}", FTP.Filename, e);
                }
            }
            else
            {
                responseClass.strMessage = "The FTP Host is empty.";
            }

            return responseClass;
        }
    }
}