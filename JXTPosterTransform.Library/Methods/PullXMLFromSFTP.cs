using JXTPosterTransform.Library.Common;
using JXTPosterTransform.Library.Models;
using System;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Net;
using System.IO;
using JXTPosterTransform.Library.Common;
using WinSCP;
using System.Configuration;
using JXTPosterTransform.Library.Models;
using log4net;

namespace JXTPosterTransform.Library.Methods
{
    public class PullXMLFromSFTP
    {
        static ILog _logger; 

        public static ResponseClass ProcessXML(ClientSetupModels.PullXmlFromSFTP SFTP, string strFilename)
        {
            _logger = LogManager.GetLogger(typeof(PullXMLFromFTP));

            _logger.DebugFormat("Attempting to retreive file using SFTP:");
            _logger.DebugFormat("\t- Host => " + SFTP.Host + ", Remote Path => " + SFTP.RemotePath + ", Username => " + SFTP.Username);
            _logger.DebugFormat("\t- Params => Filename(" + SFTP.Filename + "), FileStartsWith(" + SFTP.FileStartsWith + ")");
            
            SFTPClient sftpClient = new SFTPClient();
            ResponseClass responseClass = sftpClient.Pull(SFTP, strFilename); //"/home/enworld/migration/candidates/", "", string.Empty);

            _logger.DebugFormat("SFTP client responded: " + responseClass.blnSuccess + " - " + responseClass.strMessage);

            if (responseClass.blnSuccess)
            {
                try
                {
                    if (responseClass.ResponseClassFtpItemList.Count > 0)
                    {
                        for (int i = 0; i < responseClass.ResponseClassFtpItemList.Count; i++)
                        {
                            Console.WriteLine("Loading the XML - " + responseClass.ResponseClassFtpItemList[i].FullFilePath);
                            responseClass.ResponseClassFtpItemList[i].ResponseXML = Utils.GetXMLFromFileSystem(responseClass.ResponseClassFtpItemList[i].FullFilePath);

                            //Delete the file temporary after load all xml file to the memory
                            File.Delete(responseClass.ResponseClassFtpItemList[i].FullFilePath);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Loading the XML - " + responseClass.FullFilePath);
                        responseClass.ResponseXML = Utils.GetXMLFromFileSystem(responseClass.FullFilePath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can't find the downloaded file - " + responseClass.FullFilePath);
                }
            }

            return responseClass;
        }
    }
}