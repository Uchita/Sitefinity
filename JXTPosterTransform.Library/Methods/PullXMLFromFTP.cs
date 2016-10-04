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

namespace JXTPosterTransform.Library.Methods
{
    public class PullXMLFromFTP
    {

        public static ResponseClass ProcessXML(ClientSetupModels.PullXmlFromFTP FTP, string strFilename)
        {
            FTPClient ftpClient = new FTPClient();

            ResponseClass responseClass = ftpClient.Pull(FTP, strFilename);

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
