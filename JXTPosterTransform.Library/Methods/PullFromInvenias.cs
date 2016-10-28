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
            _api.Authenticate(false);
        }


        public List<InveniasPTModel> PosterTransformModelsGet()
        {
            //get all advertisements
            List<InveniasAdvertisementsValue> advertisements = _api.AdvertisementsGet();
            //get all locations
            //List<InveniasLocationValue> locations = _api.LocationsGet();

            List<InveniasPTModel> pt = new List<InveniasPTModel>();

            foreach (InveniasAdvertisementsValue ad in advertisements)
            {
                InveniasPTModel thisPT = new InveniasPTModel();
                thisPT.advertisement = ad;

                //get category item (Advertisement->Categories)

                //get Assignment Location
                List<InveniasAssignmentValue> thisAssignments = _api.AdvertisementAssignmentGet(ad.Id);

                if (thisAssignments.Any())
                {
                    thisPT.assignment = thisAssignments.First();

                    List<InveniasLocationValue> locations = _api.AssignmentLocationsGet(thisAssignments.First().Id);

                    if (locations.Any())
                    {
                        thisPT.location = locations.First();
                    }

                    //get employment type from assignment
                    if (thisAssignments.First().IsContract)
                    {
                        List<InveniaInterimRatesValue> interim_rates = _api.AssignmentInterimRate(thisAssignments.First().Id);
                        if (interim_rates != null && interim_rates.Any())
                        {
                            thisPT.interim_rate = interim_rates.First();

                            thisPT.SalaryBaseOnPackage_Min = interim_rates.First().PayAmountFrom;
                            thisPT.SalaryBaseOnPackage_Max = interim_rates.First().PayAmountTo;
                        }
                    }
                    else if (thisAssignments.First().IsNonExec)
                    {
                        List<InveniaNonExecPackageValue> non_exec_package = _api.AssignmentNonExecPackageGet(thisAssignments.First().Id);
                        if (non_exec_package != null && non_exec_package.Any())
                        {
                            thisPT.non_exec_package = non_exec_package.First();

                            thisPT.SalaryBaseOnPackage_Min = non_exec_package.First().AmountFrom;
                            thisPT.SalaryBaseOnPackage_Max = non_exec_package.First().AmountTo;
                        }
                    }
                    else if (thisAssignments.First().IsPermanent)
                    {
                        List<InveniaPermanentPackageValue> perm_package = _api.AssignmentPermanentPackageGet(thisAssignments.First().Id);
                        if (perm_package != null && perm_package.Any())
                        {
                            thisPT.perm_package = perm_package.First();

                            thisPT.SalaryBaseOnPackage_Min = perm_package.First().AmountFrom;
                            thisPT.SalaryBaseOnPackage_Max = perm_package.First().AmountTo;
                        }
                    }

                }

                pt.Add(thisPT);
            }

            return pt;
        }

        public List<InveniasAdvertisementsValue> AdvertisementsGet()
        {
            return _api.AdvertisementsGet();
        }

        public ResponseClass ProcessInveniaModelToXML(List<InveniasPTModel> adverts, string FTP_FileName)
        {
            ResponseClass responseClass = new ResponseClass();

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<InveniasPTModel>));

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
