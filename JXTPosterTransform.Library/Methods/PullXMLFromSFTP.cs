using JXTPosterTransform.Library.Common;
using JXTPosterTransform.Library.Models;
using System;
using System.IO;

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