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
    public class PullXMLFromSFTP
    {

        public static ResponseClass ProcessXML(ClientSetupModels.PullXmlFromSFTP SFTP, string strFilename)
        {
            SFTPClient sftpClient = new SFTPClient();

            ResponseClass responseClass = sftpClient.Pull(SFTP, strFilename); //"/home/enworld/migration/candidates/", "", string.Empty);

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
