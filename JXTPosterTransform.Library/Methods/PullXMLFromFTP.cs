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
    public class PullXMLFromFTP
    {
        static ILog _logger; 
        public static ResponseClass ProcessXML(ClientSetupModels.PullXmlFromFTP FTP, string strFilename)
        {
            _logger = LogManager.GetLogger(typeof(PullXMLFromFTP));

            _logger.DebugFormat("Attempting to retreive file from FTP:");
            _logger.DebugFormat("\t- Host => " + FTP.Host + ", Remote Path => " + FTP.RemotePath + ", Username => " + FTP.Username);
            _logger.DebugFormat("\t- Params => Filename(" + FTP.Filename + "), FileStartsWith(" + FTP.FileStartsWith + ")");
            
            FTPClient ftpClient = new FTPClient();
            ResponseClass responseClass = ftpClient.Pull(FTP, strFilename);

            _logger.DebugFormat("FTP client responded: " + responseClass.blnSuccess + " - " + responseClass.strMessage);
            
            if (responseClass.blnSuccess)
            {
                try
                {
                    Console.WriteLine("Loading the XML - " + responseClass.FullFilePath);
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
