﻿using System;
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
using log4net;

namespace JXTPosterTransform.Library.Methods
{
    public class PullFromInvenias
    {
        ILog _logger; 
        InveniasRESTAPI _api;
        string _LocationCategoryID;
        string _ProfRoleCategoryID;

        public PullFromInvenias(ClientSetupModels.PullFromInvenias invDetails)
        {
            _logger = LogManager.GetLogger(typeof(PullFromInvenias));
            _LocationCategoryID = invDetails.LocationCategoryListID;
            _ProfRoleCategoryID = invDetails.ProfRoleCategoryListID;
            _api = new InveniasRESTAPI(invDetails.ClientID, invDetails.Username, invDetails.Password);

            _logger.InfoFormat("Attempting authentication to Invenias with ClientID({0})", invDetails.ClientID);
            InveniaTokenResponse tokenResponse = _api.Authenticate(false);
            _logger.InfoFormat("Authentication to Invenias " + (tokenResponse == null ? "FAILED" : "SUCCESS"));
        }


        public List<InveniasPTModel> PosterTransformModelsGet()
        {
            _logger.InfoFormat("Start retreiving data from Invenias...");

            //get all advertisements
            _logger.InfoFormat("Retreiving 'published' / 'unpublished' Advertisements data from Invenias");
            List<InveniasAdvertisementsValue> advertisements = _api.AdvertisementsGet(); //this throws error on Invenias "$filter=Status eq Invenias.Model.Enumerations.AssignmentAdStatus'Published'");
            _logger.InfoFormat("[DONE] Retreiving Advertisements data from Invenias - Count(" + advertisements.Count() + ")");

            //get all locations
            //List<InveniasLocationValue> locations = _api.LocationsGet();

            _logger.InfoFormat("Processing each Advertisements");
            List<InveniasPTModel> pt = new List<InveniasPTModel>();
            List<string> desiredAdStatusType = new List<string> { "PUBLISHED", "UNPUBLISHED" };
            foreach (InveniasAdvertisementsValue ad in advertisements.Where(c=> desiredAdStatusType.Contains(c.Status.ToUpper())))
            {
                _logger.DebugFormat("Advertisement - " + ad.Id);

                InveniasPTModel thisPT = new InveniasPTModel();
                thisPT.advertisement = ad;

                //get description using (NoteField entity)
                InveniaNoteFieldValue noteFieldDescription = _api.EntityGet<InveniaNoteFieldValue>("NoteFields", ad.DescriptionFieldId);
                thisPT.advertisement.AdvertisementDescription = noteFieldDescription == null ? string.Empty : noteFieldDescription.TextBody;
                
                //get CategoryListEntries for this Assignment
                List<InveniaCategoryListEntryValue> categoryEntries = _api.NavigationPropertyGet<InveniaCategoryListEntryValue>("Advertisements", ad.Id, "Categories");

                #region Locations

                JXTCLAModel jxtCLA = new JXTCLAModel();
                InveniaCategoryListEntryValue thirdLevelLocationValue = categoryEntries.Where(c => c.CategoryListId == _LocationCategoryID).FirstOrDefault();
                if (thirdLevelLocationValue != null)
                {
                    jxtCLA.AreaName = thirdLevelLocationValue.Name;
                    //NOTE there are 3 levels
                    //The retreived values is the lowest level, IE we have to get the 2 above
                    InveniaCategoryListEntryValue secondLevelLocationValue = _api.EntityGet<InveniaCategoryListEntryValue>("CategoryListEntries", thirdLevelLocationValue.ParentEntryId);

                    if (secondLevelLocationValue != null)
                    {
                        jxtCLA.LocationName = secondLevelLocationValue.Name;
                        InveniaCategoryListEntryValue firstLevelLocationValue = _api.EntityGet<InveniaCategoryListEntryValue>("CategoryListEntries", secondLevelLocationValue.ParentEntryId);

                        if( firstLevelLocationValue != null )
                            jxtCLA.CountryName = firstLevelLocationValue.Name;

                    }

                    //set locations
                    thisPT.location = jxtCLA;
                }

                #endregion

                #region Prof Roles
                //NOTE there are 2 levels
                //The retreived values is the lowest level

                List<JXTPRModel> jxtPRs = new List<JXTPRModel>();

                //keep track to avoid multiple of the same API call
                List<InveniaCategoryListEntryValue> profValues = new List<InveniaCategoryListEntryValue>();

                List<InveniaCategoryListEntryValue> roleValues = categoryEntries.Where(c => c.CategoryListId == _ProfRoleCategoryID).ToList();
                foreach(InveniaCategoryListEntryValue role in roleValues)
                {
                    JXTPRModel thisPR = new JXTPRModel { RoleName = role.Name };

                    InveniaCategoryListEntryValue firstLevelRoleValue = profValues.Where(c => c.Id == role.ParentEntryId).FirstOrDefault();

                    if (firstLevelRoleValue == null)
                    {
                        firstLevelRoleValue = _api.EntityGet<InveniaCategoryListEntryValue>("CategoryListEntries", role.ParentEntryId);
                        profValues.Add(firstLevelRoleValue);
                    }

                    if (firstLevelRoleValue != null)
                    {
                        thisPR.ProfessionName = firstLevelRoleValue.Name;
                    }

                    jxtPRs.Add(thisPR);
                }

                thisPT.profRole = jxtPRs;

                #endregion

                #region Assignment
                //List<InveniasAssignmentValue> thisAssignments = _api.AdvertisementAssignmentGet(ad.Id);
                List<InveniasAssignmentValue> thisAssignments = _api.NavigationPropertyGet<InveniasAssignmentValue>("Advertisements", ad.Id, "Assignment");

                if (thisAssignments.Any())
                    thisPT.assignment = thisAssignments.First();
                #endregion

                #region Company details

                //get company entity
                List<InveniasCompanyValue> companiesForAd = _api.NavigationPropertyGet<InveniasCompanyValue>("Advertisements", ad.Id, "Company");
                if (companiesForAd != null && companiesForAd.Count() > 0)
                    thisPT.company = companiesForAd.First();

                #endregion

                #region Employment type details
                //get employment type from assignment
                switch (ad.EmploymentType)
                {
                    case "Interim":
                        List<InveniaInterimRatesValue> interim_rates = _api.NavigationPropertyGet<InveniaInterimRatesValue>("Advertisements", ad.Id, "InterimRates");
                        if (interim_rates != null && interim_rates.Any())
                        {
                            thisPT.interim_rate = interim_rates.First();

                            thisPT.SalaryBaseOnPackage_Min = interim_rates.First().PayAmountFrom;
                            thisPT.SalaryBaseOnPackage_Max = interim_rates.First().PayAmountTo;
                            thisPT.SalaryBaseOnPackage_Period = interim_rates.First().Period;
                        }
                        break;

                    case "NonExec":
                        List<InveniaNonExecPackageValue> non_exec_package = _api.NavigationPropertyGet<InveniaNonExecPackageValue>("Advertisements", ad.Id, "NonExecPackages");
                        if (non_exec_package != null && non_exec_package.Any())
                        {
                            thisPT.non_exec_package = non_exec_package.First();

                            thisPT.SalaryBaseOnPackage_Min = non_exec_package.First().AmountFrom;
                            thisPT.SalaryBaseOnPackage_Max = non_exec_package.First().AmountTo;
                            thisPT.SalaryBaseOnPackage_Period = non_exec_package.First().Period;
                        }
                        break;

                    case "Permanent":
                        List<InveniaPermanentPackageValue> perm_package = _api.NavigationPropertyGet<InveniaPermanentPackageValue>("Advertisements", ad.Id, "PermanentPackages");
                        if (perm_package != null && perm_package.Any())
                        {
                            thisPT.perm_package = perm_package.First();

                            thisPT.SalaryBaseOnPackage_Min = perm_package.First().AmountFrom;
                            thisPT.SalaryBaseOnPackage_Max = perm_package.First().AmountTo;
                            thisPT.SalaryBaseOnPackage_Period = perm_package.First().Period;
                        }
                        break;

                }
                #endregion

                pt.Add(thisPT);

                _logger.DebugFormat("[DONE] Advertisement - " + ad.Id);
            }
            _logger.InfoFormat("[DONE] Processing each Advertisements");

            return pt;
        }

        public List<InveniasAdvertisementsValue> AdvertisementsGet()
        {
            return _api.AdvertisementsGet();
        }

        public ResponseClass ProcessInveniaModelToXML(List<InveniasPTModel> adverts, string FTP_FileName)
        {
            _logger.InfoFormat("Processing Invenias Data to XML...");

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
            }
            
            _logger.InfoFormat("[DONE] Processing Invenias Data to XML");

            return responseClass;
        }

    }
}
