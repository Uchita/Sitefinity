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
                    responseClass.ResponseXML = Utils.GetXMLFromFileSystem(responseClass.FullFilePath);
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
