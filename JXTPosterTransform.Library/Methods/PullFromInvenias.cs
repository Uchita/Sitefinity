using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using JXTPosterTransform.Library.Common;
using System.Configuration;
using JXTPosterTransform.Library.Models;
using System.IO;
using JXTPosterTransform.Library.APIs.Invenias;

namespace JXTPosterTransform.Library.Methods
{
    public class PullFromInvenias
    {
        InveniasRESTAPI _api;

        public PullFromInvenias(ClientSetupModels.PullFromInvenias invDetails)
        {
            _api = new InveniasRESTAPI(invDetails.ClientID, invDetails.Username, invDetails.Password);
            _api.Authenticate();
        }

        public List<InveniasAdvertisementsValue> AdvertisementsGet()
        {
            return _api.AdvertisementsGet();
        }

        public ResponseClass ProcessInveniaModelToXML(List<InveniasAdvertisementsValue> adverts, string FTP_FileName)
        {
            ResponseClass responseClass = new ResponseClass();

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<InveniasAdvertisementsValue>));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = false;
            settings.OmitXmlDeclaration = false;
            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, adverts);
                }
                responseClass.ResponseXML = textWriter.ToString();

                // Save the Raw XML
                System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + FTP_FileName + "_Raw.xml", responseClass.ResponseXML);

                // Success to get the XML.
                responseClass.blnSuccess = true;

                /*else
                {
                    responseClass.strMessage = "Can't find the file from URL - " + XMLwithAuth.Host;
                    Console.WriteLine(responseClass.strMessage);
                }*/
            }
            return responseClass;
        }

    }
}
