using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPosterTransform.Library.Common;
using System.IO;
using System.Xml.Serialization;
using JXTPosterTransform.Library.Models;
using JXTPosterTransform.Data;
using System.Web.Script.Serialization;
using JXTPosterTransform.Website.Logics;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Xml;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using JXTPosterTransform.Library.Methods;
using JXTPosterTransform.Library.APIs.Invenias;
using log4net;
using log4net.Core;

namespace JXTPosterTransform.Library.Services
{
    public class TransformationService : IDisposable
    {
        ILog _logger;
        private PosterTransformEntities _context = new PosterTransformEntities();
        JavaScriptSerializer jss = new JavaScriptSerializer();

        bool enableShortDescriptionPullFromFullDescription = false;

        public TransformationService()
        {
            _logger = LogManager.GetLogger(typeof(TransformationService));
        }

        public void DoTransformationWithMappings(int setupId)
        {
            _logger.InfoFormat("Transformation Service Started with setupId " + setupId);
            List<GetAllClientSetupsToRun_Result> clientSetupsList = null;

            if (setupId > 0)
                clientSetupsList = _context.GetAllClientSetupsToRun().Where(s => s.ClientSetupId == setupId).ToList();
            else
                clientSetupsList = _context.GetAllClientSetupsToRun().ToList();

            if (clientSetupsList == null || clientSetupsList.Count() == 0)
            {
                _logger.InfoFormat("No Clients Setup found to process. Exiting.", clientSetupsList.Count());
                return;
            }

            _logger.InfoFormat("Total of {0} Clients Setup found to process", clientSetupsList.Count());

            ResponseClass JobPostResponse = null;
            IEnumerable<Job> JobsToArchive = null;
            DateTime dtStartTime = DateTime.Now;
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N");

            try
            {
                foreach (GetAllClientSetupsToRun_Result thisSetupItem in clientSetupsList)
                {
                    Console.WriteLine("Process started for Client - {0}, Client Setup - {1}, Setup Type - {2}", thisSetupItem.ClientName, thisSetupItem.ClientSetupName, thisSetupItem.ClientSetupType.ToString());
                    _logger.InfoFormat("Process started for Client - {0}, Client Setup - {1}, Setup Type - {2}", thisSetupItem.ClientName, thisSetupItem.ClientSetupName, thisSetupItem.ClientSetupType.ToString());

                    dtStartTime = DateTime.Now;     // Set the start time
                    fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N");   // Set a new file name

                    JobPostResponse = new ResponseClass();

                    //below are for PullXmlFromRGF ONLY
                    long nextScheduledTimestamp = 0;
                    JXTPosterTransform.Library.Methods.Client.PullJsonFromRGF.RGFJobBoardDataRoot rgfData = null;

                    bool postRequired = false;
                    // Find the type of Client setup Type and get credentials                    
                    _logger.InfoFormat("[START] Data retreival");
                    switch (thisSetupItem.ClientSetupType)
                    {
                        case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromFTP):
                            {
                                ClientSetupModels.PullXmlFromFTP FTP = jss.Deserialize<ClientSetupModels.PullXmlFromFTP>(thisSetupItem.ClientSetupTypeCredentials);
                                JobPostResponse = Methods.PullXMLFromFTP.ProcessXML(FTP, fileName);
                                postRequired = JobPostResponse.blnSuccess;
                                break;
                            }
                        case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromSFTP):
                            {
                                ClientSetupModels.PullXmlFromSFTP SFTP = jss.Deserialize<ClientSetupModels.PullXmlFromSFTP>(thisSetupItem.ClientSetupTypeCredentials);
                                JobPostResponse = Methods.PullXMLFromSFTP.ProcessXML(SFTP, fileName);
                                postRequired = JobPostResponse.blnSuccess;
                                break;
                            }
                        case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromUrl):
                            {
                                ClientSetupModels.PullXmlFromUrl URL = jss.Deserialize<ClientSetupModels.PullXmlFromUrl>(thisSetupItem.ClientSetupTypeCredentials);
                                JobPostResponse = Methods.PullXMLFromURL.ProcessXML(URL.URL, fileName);
                                postRequired = JobPostResponse.blnSuccess;
                                break;
                            }
                        case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromUrlWithAuth):
                            {
                                ClientSetupModels.PullXmlFromUrlWithAuth XmlAuth = jss.Deserialize<ClientSetupModels.PullXmlFromUrlWithAuth>(thisSetupItem.ClientSetupTypeCredentials);
                                JobPostResponse = Methods.PullXMLWithWebAuthentication.ProcessXML(XmlAuth, fileName);
                                postRequired = JobPostResponse.blnSuccess;
                                break;
                            }
                        case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullFromInvenias):
                            {
                                ClientSetupModels.PullFromInvenias invAuth = jss.Deserialize<ClientSetupModels.PullFromInvenias>(thisSetupItem.ClientSetupTypeCredentials);
                                PullFromInvenias inveniaLogic = new PullFromInvenias(invAuth);
                                List<InveniasPTModel> ptModel = inveniaLogic.PosterTransformModelsGet();
                                JobPostResponse = inveniaLogic.ProcessInveniaModelToXML(ptModel.Where(c => c.advertisement.Status.ToUpper() == "PUBLISHED").ToList(), fileName);
                                JobsToArchive = ptModel.Where(c => c.advertisement.Status.ToUpper() == "UNPUBLISHED").Select(c=> new Job { ReferenceNo = c.advertisement.Id });
                                postRequired = JobPostResponse.blnSuccess;
                                break;
                            }
                        case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullJsonFromUrl):
                            {
                                //only enabled for this for now incase it breaks any other things
                                enableShortDescriptionPullFromFullDescription = true;
                                ClientSetupModels.PullJsonFromUrl jsonAuth = jss.Deserialize<ClientSetupModels.PullJsonFromUrl>(thisSetupItem.ClientSetupTypeCredentials);
                                JobPostResponse = Methods.PullJsonFromURL.ProcessJsonToXML(jsonAuth.URL, fileName);
                                postRequired = JobPostResponse.blnSuccess;
                                break;
                            }
                        case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromRGF):
                            {
                                #region RGF (SF)
                                ClientSetupModels.PullXmlFromSalesforceRGF XmlAuthRGF = jss.Deserialize<ClientSetupModels.PullXmlFromSalesforceRGF>(thisSetupItem.ClientSetupTypeCredentials);
                                long epochTime = ((long)((new DateTime(2016, 01, 01, 11, 0, 0)).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds);

                                //set this value for update later
                                nextScheduledTimestamp = ((long)((DateTime.UtcNow.AddMinutes(-5)) - new DateTime(1970, 1, 1)).TotalSeconds);

                                Methods.Client.PullJsonFromRGF rgfLogic = new Methods.Client.PullJsonFromRGF(XmlAuthRGF);

                                rgfData = rgfLogic.ProcessXML(XmlAuthRGF.JobBoardName, XmlAuthRGF.Host, XmlAuthRGF.Timestamp ?? epochTime, XmlAuthRGF.ApplicationURL, XmlAuthRGF.StripJobTitle);

                                if (rgfData.success)
                                {
                                    int count = 0, fileCount = 1;

                                    bool postSuccess = true;
                                    for (count = 0; count < rgfData.jobBoards.jobboardlisting.upserted.Count();)
                                    {
                                        string thisFileName = fileName + "-" + fileCount;
                                        JXTPosterTransform.Library.Methods.Client.PullJsonFromRGF.RGFJobBoardDataRoot currentQueue = DeepClone<JXTPosterTransform.Library.Methods.Client.PullJsonFromRGF.RGFJobBoardDataRoot>(rgfData);
                                        currentQueue.jobBoards.jobboardlisting.upserted = currentQueue.jobBoards.jobboardlisting.upserted.Skip(count).Take(200).ToList();

                                        JobPostResponse = rgfLogic.ProcessRGFModelToXML(currentQueue, thisFileName);

                                        // Get the Credentials AND Pull the XML     AND     Post to JXT platform Webservice                            
                                        bool thisPostSuccess = PostTransformationWithMappings(thisSetupItem, JobPostResponse.ResponseXML, thisFileName, dtStartTime);

                                        if (!thisPostSuccess)
                                            postSuccess = false;

                                        count += currentQueue.jobBoards.jobboardlisting.upserted.Count();
                                        fileCount++;
                                    }

                                    bool jobsArchiveSuccess = ArchiveRGFJobs(thisSetupItem, rgfData);

                                    // Set the values - TODO move to a seperate function
                                    if (postSuccess && jobsArchiveSuccess)
                                    {
                                        // update the timestamp
                                        PT_ClientService clientService = new PT_ClientService();
                                        ClientSetup thisSetupToBeUpdated = clientService.ClientSetupGetBySetupID(thisSetupItem.ClientSetupId);
                                        if (thisSetupToBeUpdated != null)
                                        {
                                            //get setup credentials from json
                                            ClientSetupModels.PullXmlFromSalesforceRGF thisSetupCredentials = jss.Deserialize<ClientSetupModels.PullXmlFromSalesforceRGF>(thisSetupToBeUpdated.ClientSetupTypeCredentials);
                                            //assign new timestamp
                                            thisSetupCredentials.Timestamp = nextScheduledTimestamp;
                                            //serialize back to json again
                                            string newSetupCredentials = jss.Serialize(thisSetupCredentials);
                                            //update
                                            clientService.ClientSetupSetupCredentialsUpdate(thisSetupItem.ClientSetupId, newSetupCredentials);
                                        }
                                    }
                                }
                                postRequired = false;
                                #endregion
                                break;
                            }
                        default:
                            break;
                    }
                    _logger.InfoFormat("[DONE] Data retreival");
                    _logger.DebugFormat("Post to JXT WebServices required: " + postRequired);
                    if (postRequired)
                    {
                        #region Process Job Post Requests
                        if (JobPostResponse == null)
                        {
                            _logger.DebugFormat("No job posts data to be processed...");
                            _logger.DebugFormat("-- Ignoring process");
                        }
                        else
                        {
                            // Get the Credentials AND Pull the XML     AND     Post to JXT platform Webservice                            
                            _logger.DebugFormat("[START] Post Job Post request to JXT WebServices");
                            PostTransformationWithMappings(thisSetupItem, JobPostResponse.ResponseXML, fileName, dtStartTime);
                            _logger.DebugFormat("[DONE] Post Job Post request to JXT WebServices");
                        }
                        #endregion

                        #region Process Job Archive Requests
                        if (JobsToArchive == null || JobsToArchive.Count() == 0)
                        {
                            _logger.DebugFormat("No job archives data to be processed...");
                            _logger.DebugFormat("-- Ignoring process");
                        }
                        else
                        {
                            // Get the Credentials AND Pull the XML     AND     Post to JXT platform Webservice                            
                            _logger.DebugFormat("[START] Post Archive Request to JXT WebServices");
                            ProcessArchiveJobs(thisSetupItem, JobsToArchive);
                            _logger.DebugFormat("[DONE] Post Archive Request to JXT WebServices");
                        }
                        #endregion

                    }
                    else
                    {
                        // Error display
                        Console.WriteLine(JobPostResponse.strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message); // TODO
                Console.WriteLine("Error - " + ex.StackTrace); // TODO
                Console.WriteLine("Error - " + ex.InnerException); // TODO
            }
            // Save the Response Log
        }

        public bool PostTransformationWithMappings(GetAllClientSetupsToRun_Result clientSetup, string xml, string fileName, DateTime dtStartTime)
        {
            bool useJXTSiteMapping = clientSetup.UseJXTSiteMappings;
            bool blnSuccess = false;

            _logger.InfoFormat("[START] Transforming XML");
            _logger.DebugFormat("============\nOriginal XML:============\n" + xml);
            string TransformedXML = Utils.TransformXML(clientSetup.PosterTransformXSL, xml);
            _logger.DebugFormat("============\nTransformed XML:============\n" + TransformedXML);
            _logger.InfoFormat("[DONE] Transforming XML");

            // Do the mapping 
            _logger.InfoFormat("Use JXT Site Mappings: " + useJXTSiteMapping);
            if (useJXTSiteMapping)
            {
                #region use JXT platform and directly mappings
                _logger.InfoFormat("[START] Requesting mapping data from JXT site");
                _logger.InfoFormat("\t- AdvertiserUsername(" + clientSetup.AdvertiserUsername + "), AdvertiserId(" + clientSetup.AdvertiserId + ")");
                DefaultResponse defaults = AvailableDataJXTPlatformGet(clientSetup.AdvertiserUsername, clientSetup.AdvertiserPassword, clientSetup.AdvertiserId.ToString());
                _logger.InfoFormat("[DONE] Requesting mapping data from JXT site");

                var serializer = new XmlSerializer(typeof(JobPostRequest));
                using (var reader = new StringReader(TransformedXML))
                {
                    try
                    {
                        JobPostRequest jobListings = (JobPostRequest)serializer.Deserialize(reader);
                        if (jobListings != null)
                        {
                            jobListings.AdvertiserId = clientSetup.AdvertiserId.Value;
                            jobListings.UserName = clientSetup.AdvertiserUsername;
                            jobListings.Password = clientSetup.AdvertiserPassword;
                            jobListings.ArchiveMissingJobs = clientSetup.ArchiveMissingJobs;

                            if (enableShortDescriptionPullFromFullDescription)
                            {
                                int trimLength = 1000; //shortDescription max length is 1000
                                foreach (JobListing job in jobListings.Listings.Where(c => string.IsNullOrEmpty(c.ShortDescription)))
                                {
                                    if (!string.IsNullOrEmpty(job.JobFullDescription))
                                    {
                                        string strContent = Common.Utils.StripHTML(job.JobFullDescription);
                                        if (strContent.Length > trimLength)
                                        {
                                            strContent = strContent.Substring(0, trimLength - 3) + "...";
                                        }
                                        job.ShortDescription = strContent;
                                    }
                                }
                            }

                            _logger.InfoFormat("[START] Process mappings with JXT site mapping data");
                            // Mappings
                            MappingsLogic MappingsLogic = new MappingsLogic();
                            foreach (JobListing job in jobListings.Listings)
                            {
                                _logger.DebugFormat("JobListing - ReferenceNo({0})", job.ReferenceNo);

                                #region CLA Maps
                                DefaultList.CountryLocationArea matchingLocationArea = defaults.DefaultList.CountryLocationAreas.Where(c =>
                                                    c.AreaName == job.ListingClassification.Area
                                                    && c.LocationName == job.ListingClassification.Location
                                                    && c.CountryName == job.ListingClassification.Country).FirstOrDefault();

                                if (matchingLocationArea != null)
                                {
                                    job.ListingClassification.Country = matchingLocationArea.CountryID;
                                    job.ListingClassification.Location = matchingLocationArea.LocationID;
                                    job.ListingClassification.Area = matchingLocationArea.AreaID;
                                }
                                #endregion

                                #region Job Template Logo

                                DefaultList.AdvertiserJobTemplateLogo matchingJobTemplateLogo = defaults.DefaultList.AdvertiserJobTemplateLogos.Where(c =>
                                                    c.AdvertiserJobTemplateLogoID == job.AdvertiserJobTemplateLogoID).FirstOrDefault();

                                if (matchingJobTemplateLogo != null)
                                {
                                    job.AdvertiserJobTemplateLogoID = matchingJobTemplateLogo.AdvertiserJobTemplateLogoID;
                                }

                                #endregion

                                #region Job Template

                                DefaultList.JobTemplate matchingJobTemplate = defaults.DefaultList.JobTemplates.Where(c =>
                                                    c.JobTemplateID == job.JobTemplateID).FirstOrDefault();

                                if (matchingJobTemplateLogo != null)
                                {
                                    job.JobTemplateID = matchingJobTemplate.JobTemplateID;
                                }

                                #endregion

                                #region Prof Role match

                                if (job.Categories != null)
                                {
                                    for (int i = 0; i < job.Categories.Count; i++)
                                    {
                                        Category thisCate = job.Categories[i];
                                        DefaultList.ProfessionRole matchingProfRole = defaults.DefaultList.ProfessionRoles.Where(c =>
                                                                            c.ProfessionName == thisCate.Classification
                                                                            && c.RoleName == thisCate.SubClassification).FirstOrDefault();

                                        if (matchingProfRole != null)
                                        {
                                            thisCate.Classification = matchingProfRole.ProfessionID;
                                            thisCate.SubClassification = matchingProfRole.RoleID;
                                        }
                                    }
                                }

                                #endregion

                                #region Work Type match

                                DefaultList.WorkType matchingWorkType = defaults.DefaultList.WorkTypes.Where(c =>
                                                                            c.WorkTypeName == job.ListingClassification.WorkType).FirstOrDefault();

                                if (matchingWorkType != null)
                                {
                                    job.ListingClassification.WorkType = matchingWorkType.WorkTypeID;
                                }

                                #endregion

                                #region Salary Type match

                                //Salary types are not available in the webservice default request
                                //therefore no mathcing can be done

                                #endregion
                            }
                            _logger.InfoFormat("[DONE] Process mappings with JXT site mapping data");


                            _logger.DebugFormat("[START] Serializing processed xml");
                            serializer = new XmlSerializer(typeof(JobPostRequest));
                            using (Utf8StringWriter sww = new Utf8StringWriter())
                            using (XmlWriter writer = XmlWriter.Create(sww))
                            {
                                serializer.Serialize(writer, jobListings); //, ns

                                TransformedXML = sww.ToString(); // Your XML
                            }
                            _logger.DebugFormat("[DONE] Serializing processed xml");

                            // Save the transformed XML
                            System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + fileName + "_Request.xml", TransformedXML);

                            string jobResponse = string.Empty;

                            // Only post when they are jobs - if not don't post.
                            if (jobListings != null && jobListings.Listings != null && jobListings.Listings.Count > 0)
                            {
                                _logger.InfoFormat("[START] Posting to JXT WebServices @ {0}", ConfigurationManager.AppSettings["WebserviceURL"]);
                                jobResponse = Process(TransformedXML, ConfigurationManager.AppSettings["WebserviceURL"]);
                                _logger.InfoFormat("[DONE] Posting to JXT WebServices @ {0}", ConfigurationManager.AppSettings["WebserviceURL"]);
                            }
                            else
                            {
                                _logger.InfoFormat("No jobs to post to JXT WebServices");
                                jobResponse = "No jobs to post";
                            }

                            // Save the response XML
                            System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + fileName + "_Response.xml", jobResponse);

                            blnSuccess = true;

                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.InfoFormat("[ERROR] Exception");
                        _logger.Debug(ex);

                        Console.WriteLine("Error - " + ex.Message); // TODO
                        Console.WriteLine("Error - " + ex.StackTrace); // TODO
                        Console.WriteLine("Error - " + ex.InnerException); // TODO
                    }
                }

                #endregion
            }
            else
            {
                #region Use JIP defined Mappings
                _logger.InfoFormat("[START] Process mappings with JIP defined mappings");

                var serializer = new XmlSerializer(typeof(JobPostRequest));
                using (var reader = new StringReader(TransformedXML))
                {
                    try
                    {
                        JobPostRequest jobListings = (JobPostRequest)serializer.Deserialize(reader);
                        if (jobListings != null)
                        {
                            jobListings.AdvertiserId = clientSetup.AdvertiserId.Value;
                            jobListings.UserName = clientSetup.AdvertiserUsername;
                            jobListings.Password = clientSetup.AdvertiserPassword;
                            jobListings.ArchiveMissingJobs = clientSetup.ArchiveMissingJobs;

                            if (enableShortDescriptionPullFromFullDescription)
                            {
                                int trimLength = 1000; //shortDescription max length is 1000
                                foreach (JobListing job in jobListings.Listings.Where(c => string.IsNullOrEmpty(c.ShortDescription)))
                                {
                                    if (!string.IsNullOrEmpty(job.JobFullDescription))
                                    {
                                        string strContent = Common.Utils.StripHTML(job.JobFullDescription);
                                        if (strContent.Length > trimLength)
                                        {
                                            strContent = strContent.Substring(0, trimLength - 3) + "...";
                                        }
                                        job.ShortDescription = strContent;
                                    }
                                }
                            }

                            // Mappings
                            MappingsLogic MappingsLogic = new MappingsLogic();
                            string errorMsg = string.Empty;
                            MappingsXMLModel MappingsXMLModel = MappingsLogic.ClientMappingsGet(clientSetup.ClientId, clientSetup.ClientSetupId, out errorMsg);
                            if (!string.IsNullOrWhiteSpace(errorMsg))
                            {
                                Console.WriteLine(errorMsg);
                                return false;
                            }

                            foreach (var item in MappingsXMLModel.CLAMaps)
                            {

                                if (!string.IsNullOrWhiteSpace(item.ClientCountryID) && !string.IsNullOrWhiteSpace(item.ClientLocationID) && !string.IsNullOrWhiteSpace(item.ClientAreaID))
                                {
                                    foreach (var job in jobListings.Listings)
                                    {

                                        if (job.ListingClassification.Country == item.ClientCountryID
                                                                        && job.ListingClassification.Location == item.ClientLocationID
                                                                        && job.ListingClassification.Area == item.ClientAreaID)
                                        {
                                            job.ListingClassification.Country = item.MapToCountryID.ToString();
                                            job.ListingClassification.Location = item.MapToLocationID.ToString();
                                            job.ListingClassification.Area = item.MapToAreaID.ToString();
                                        }

                                    }
                                    /*
                                    jobListings.Listings.Where(w => w.ListingClassification.Country == item.ClientCountryID
                                                                    && w.ListingClassification.Location == item.ClientLocationID
                                                                    && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                            .ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());

                                    jobListings.Listings.Where(w => w.ListingClassification.Country == item.ClientCountryID
                                                                    && w.ListingClassification.Location == item.ClientLocationID
                                                                    && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                            .ForEach(i => i.ListingClassification.Location = item.MapToLocationID.ToString());

                                    jobListings.Listings.Where(w => w.ListingClassification.Country == item.ClientCountryID
                                                                    && w.ListingClassification.Location == item.ClientLocationID
                                                                    && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                             .ForEach(i => i.ListingClassification.Area = item.MapToAreaID.ToString());*/
                                    //.ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());
                                }
                                else if (!string.IsNullOrWhiteSpace(item.ClientLocationID) && !string.IsNullOrWhiteSpace(item.ClientAreaID))
                                {
                                    foreach (var job in jobListings.Listings)
                                    {

                                        if (job.ListingClassification.Location == item.ClientLocationID
                                                                        && job.ListingClassification.Area == item.ClientAreaID)
                                        {
                                            job.ListingClassification.Country = item.MapToCountryID.ToString();
                                            job.ListingClassification.Location = item.MapToLocationID.ToString();
                                            job.ListingClassification.Area = item.MapToAreaID.ToString();
                                        }

                                    }
                                    /*
                                    jobListings.Listings.Where(w => w.ListingClassification.Location == item.ClientLocationID
                                                                    && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                        .ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());

                                    jobListings.Listings.Where(w => w.ListingClassification.Location == item.ClientLocationID
                                                                    && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                        .ForEach(i => i.ListingClassification.Location = item.MapToLocationID.ToString());

                                    jobListings.Listings.Where(w => w.ListingClassification.Location == item.ClientLocationID
                                                                    && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                        .ForEach(i => i.ListingClassification.Area = item.MapToAreaID.ToString());*/
                                }
                                else if (!string.IsNullOrWhiteSpace(item.ClientCountryID) && !string.IsNullOrWhiteSpace(item.ClientLocationID))
                                {
                                    foreach (var job in jobListings.Listings)
                                    {

                                        if (job.ListingClassification.Location == item.ClientLocationID
                                                                        && job.ListingClassification.Country == item.ClientCountryID)
                                        {
                                            job.ListingClassification.Country = item.MapToCountryID.ToString();
                                            job.ListingClassification.Location = item.MapToLocationID.ToString();
                                            job.ListingClassification.Area = item.MapToAreaID.ToString();
                                        }

                                    }

                                }
                                else if (!string.IsNullOrWhiteSpace(item.ClientAreaID))
                                {
                                    foreach (var job in jobListings.Listings)
                                    {

                                        if (job.ListingClassification.Area == item.ClientAreaID)
                                        {
                                            job.ListingClassification.Country = item.MapToCountryID.ToString();
                                            job.ListingClassification.Location = item.MapToLocationID.ToString();
                                            job.ListingClassification.Area = item.MapToAreaID.ToString();
                                        }

                                    }
                                    /*
                                    jobListings.Listings.Where(w => w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                        .ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());
                                    jobListings.Listings.Where(w => w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                         .ForEach(i => i.ListingClassification.Location = item.MapToLocationID.ToString());
                                    jobListings.Listings.Where(w => w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                        .ForEach(i => i.ListingClassification.Area = item.MapToAreaID.ToString());*/
                                    //.ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());
                                }
                                else if (!string.IsNullOrWhiteSpace(item.ClientLocationID))
                                {
                                    foreach (var job in jobListings.Listings)
                                    {

                                        if (job.ListingClassification.Location == item.ClientLocationID)
                                        {
                                            job.ListingClassification.Country = item.MapToCountryID.ToString();
                                            job.ListingClassification.Location = item.MapToLocationID.ToString();
                                            job.ListingClassification.Area = item.MapToAreaID.ToString();
                                        }

                                    }
                                }
                                else if (!string.IsNullOrWhiteSpace(item.ClientCountryID))
                                {
                                    foreach (var job in jobListings.Listings)
                                    {

                                        if (job.ListingClassification.Country == item.ClientCountryID)
                                        {
                                            job.ListingClassification.Country = item.MapToCountryID.ToString();
                                            job.ListingClassification.Location = item.MapToLocationID.ToString();
                                            job.ListingClassification.Area = item.MapToAreaID.ToString();
                                        }

                                    }
                                }

                            }
                            if (MappingsXMLModel.JobTemplateLogoMaps != null)
                            {
                                foreach (var item in MappingsXMLModel.JobTemplateLogoMaps)
                                {
                                    jobListings.Listings.Where(w => w.AdvertiserJobTemplateLogoID == item.ClientJobTemplateLogoID).ToList()
                                                            .ForEach(i => i.AdvertiserJobTemplateLogoID = item.MapToJobTemplateLogoID.ToString());
                                }
                            }

                            /*
                            // Default mappings
                            JobTemplateMap jobTemplateDefaultMapping = MappingsXMLModel.JobTemplateMaps.Where(s => s.isDefaultSetting == true).FirstOrDefault();
                            if (jobTemplateDefaultMapping != null)
                            {
                                jobListings.Listings.Where(w => w.JobTemplateID.Contains != item.ClientJobTemplateID).ToList()
                                                    .ForEach(i => i.JobTemplateID = item.MapToJobTemplateID.ToString());
                            }
                            */

                            if (MappingsXMLModel.JobTemplateMaps != null)
                            {
                                foreach (var item in MappingsXMLModel.JobTemplateMaps)
                                {

                                    jobListings.Listings.Where(w => w.JobTemplateID == item.ClientJobTemplateID).ToList()
                                                            .ForEach(i => i.JobTemplateID = item.MapToJobTemplateID.ToString());
                                }
                            }
                            foreach (var item in MappingsXMLModel.ProfRoleMaps)
                            {
                                // Need ProfessionID
                                /*foreach (var item in jobListings.Listings)
                                {

                                }*/
                                /*
                                jobListings.Listings.Where(w => w.ListingClassification.Country == item.ClientCountryID
                                                                && w.ListingClassification.Location == item.ClientLocationID
                                                                && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                        .Select(c => { c.ListingClassification.Country = item.MapToCountryID.ToString(); return c; })
                                                        .Select(c => { c.ListingClassification.Location = item.MapToLocationID.ToString(); return c; })
                                                        .Select(c => { c.ListingClassification.Area = item.MapToAreaID.ToString(); return c; });*/



                                foreach (var job in jobListings.Listings)
                                {
                                    if (job.Categories != null)
                                    {
                                        for (int i = 0; i < job.Categories.Count; i++)
                                        {
                                            if (!string.IsNullOrWhiteSpace(job.Categories[i].Classification) &&
                                                !string.IsNullOrWhiteSpace(job.Categories[i].SubClassification) &&
                                                job.Categories[i].Classification == item.ClientProfessionID
                                                                    && job.Categories[i].SubClassification == item.ClientRoleID)
                                            {
                                                job.Categories[i].Classification = item.MapToProfessionID.ToString();
                                                job.Categories[i].SubClassification = item.MapToRoleID.ToString();
                                            }
                                            else if (!string.IsNullOrWhiteSpace(job.Categories[i].Classification) &&
                                                job.Categories[i].Classification == item.ClientProfessionID)
                                            {
                                                job.Categories[i].Classification = item.MapToProfessionID.ToString();
                                                job.Categories[i].SubClassification = item.MapToRoleID.ToString();
                                            }
                                            else if (!string.IsNullOrWhiteSpace(job.Categories[i].SubClassification) &&
                                                    job.Categories[i].SubClassification == item.ClientRoleID)
                                            {
                                                job.Categories[i].Classification = item.MapToProfessionID.ToString();
                                                job.Categories[i].SubClassification = item.MapToRoleID.ToString();
                                            }
                                        }

                                    }

                                    /*
                                    job.Categories.Where(w => w.Classification == item.ClientProfessionID
                                                                    && w.SubClassification == item.ClientRoleID).ToList()
                                                        .ForEach(i => i.Classification = item.MapToProfessionID.ToString());

                                    job.Categories.Where(w => w.Classification == item.ClientProfessionID
                                                                    && w.SubClassification == item.ClientRoleID).ToList()
                                                        .ForEach(i => i.SubClassification = item.MapToRoleID.ToString());*/
                                }
                            }
                            foreach (var item in MappingsXMLModel.WorkTypeMaps)
                            {
                                jobListings.Listings.Where(w => w.ListingClassification.WorkType == item.ClientWorkTypeID).ToList()
                                                        .ForEach(i => i.ListingClassification.WorkType = item.MapToWorkTypeID.ToString());

                            }

                            //foreach (var job in jobListings.Listings)
                            //{
                            //    job.ListingClassification.Country = "265";
                            //    job.ListingClassification.Location = "465";
                            //    job.ListingClassification.Area = "2235";

                            //    job.Categories.First().Classification = "3";
                            //    job.Categories.First().SubClassification = "1";
                            //}

                            // TODO Salary Types

                            // TODO LOW - Job Ad Type
                            // TODO LOW - Job application Type

                            serializer = new XmlSerializer(typeof(JobPostRequest));
                            //string transformedXML = string.Empty;

                            using (Utf8StringWriter sww = new Utf8StringWriter())
                            using (XmlWriter writer = XmlWriter.Create(sww))
                            {
                                serializer.Serialize(writer, jobListings); //, ns

                                TransformedXML = sww.ToString(); // Your XML
                            }

                            // Save the transformed XML
                            System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + fileName + "_Request.xml", TransformedXML);

                            string jobResponse = string.Empty;

                            // Only post when they are jobs - if not don't post.
                            if (jobListings != null && jobListings.Listings != null && jobListings.Listings.Count > 0)
                                jobResponse = Process(TransformedXML, ConfigurationManager.AppSettings["WebserviceURL"]);
                            else
                                jobResponse = "No jobs to post";

                            // Save the response XML
                            System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + fileName + "_Response.xml", jobResponse);

                            blnSuccess = true;

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message); // TODO
                        Console.WriteLine("Error - " + ex.StackTrace); // TODO
                        Console.WriteLine("Error - " + ex.InnerException); // TODO
                    }

                }
                _logger.InfoFormat("[DONE] Process mappings with JIP defined mappings");
                #endregion
            }

            // Save the POST XML.
            using (ClientSetupLogService _service = new ClientSetupLogService())
            {
                _service.CreateClientSetupLog(clientSetup, fileName + "_Raw.xml", fileName + "_Request.xml", fileName + "_Response.xml", dtStartTime);
            }

            return blnSuccess;
        }

        public bool ArchiveRGFJobs(GetAllClientSetupsToRun_Result clientSetup, JXTPosterTransform.Library.Methods.Client.PullJsonFromRGF.RGFJobBoardDataRoot data)
        {

            if (data == null || data.jobBoards == null || data.jobBoards.jobboardlisting == null)
                return true;

            var listings = data.jobBoards.jobboardlisting.upserted.Where(c => c.status.ToLower() == "unposted").Select(c => new Job { ReferenceNo = c.id }).ToList(); //(from m in data.jobBoards.jobboardlisting.removedIds select new Job { ReferenceNo = m }).ToList();

            if (!listings.Any())
                return true;

            return ProcessArchiveJobs(clientSetup, listings);
        }

        public bool ProcessArchiveJobs(GetAllClientSetupsToRun_Result clientSetup, IEnumerable<Job> listings)
        {
            ArchiveJobRequest archiveJobRequest = new ArchiveJobRequest();
            archiveJobRequest.AdvertiserId = clientSetup.AdvertiserId.Value;
            archiveJobRequest.UserName = clientSetup.AdvertiserUsername;
            archiveJobRequest.Password = clientSetup.AdvertiserPassword;
            archiveJobRequest.Listings = listings.ToList();

            string xmlToService = null;
            var serializer = new XmlSerializer(typeof(ArchiveJobRequest));
            try
            {
                using (Utf8StringWriter sww = new Utf8StringWriter())
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    serializer.Serialize(writer, archiveJobRequest); //, ns

                    xmlToService = sww.ToString(); // Your XML
                }

                Process(xmlToService, ConfigurationManager.AppSettings["WebserviceArchiveURL"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message); // TODO
                Console.WriteLine("Error - " + ex.StackTrace); // TODO
                Console.WriteLine("Error - " + ex.InnerException); // TODO
                return false;
            }

            return true;
        }

        public string Process(string xml, string serviceURL)
        {

            string Response = string.Empty;

            try
            {
                string uri = serviceURL;
                //Console.WriteLine(serviceURL);

                HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                req.KeepAlive = false;
                req.Method = "POST";
                req.Timeout = 500000;
                //if (("POST,PUT").Split(',').Contains(Method.ToUpper()))
                {
                    //Console.WriteLine("Enter XML FilePath:");
                    //string FilePath = Console.ReadLine();
                    //content = (File.OpenText(@FilePath)).ReadToEnd();

                    byte[] buffer = Encoding.UTF8.GetBytes(xml);
                    req.ContentLength = buffer.Length;
                    req.ContentType = "text/xml";
                    Stream PostData = req.GetRequestStream();
                    PostData.Write(buffer, 0, buffer.Length);
                    PostData.Close();
                }

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

                Encoding enc = System.Text.Encoding.GetEncoding(1252);
                StreamReader loResponseStream =
                new StreamReader(resp.GetResponseStream(), enc);

                Response = loResponseStream.ReadToEnd();

                loResponseStream.Close();
                resp.Close();

                //Console.WriteLine(Response);
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    if (httpResponse != null && response != null)
                    {
                        Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        using (Stream data = response.GetResponseStream())
                        using (var reader = new StreamReader(data))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                    }
                }

                Console.WriteLine("Error - " + e.Message); // TODO
                Console.WriteLine("Error - " + e.StackTrace); // TODO
                Console.WriteLine("Error - " + e.InnerException); // TODO
            }

            return Response;

            /*
            HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(coreURL);
            //Method type
            POSTRequest.Method = "PUT";
            // Data type - message body coming in xml
            POSTRequest.ContentType = "application/x-www-form-urlencoded";
            POSTRequest.KeepAlive = false;
            POSTRequest.Timeout = 5000;

            Stream POSTstream = POSTRequest.GetRequestStream();
            POSTstream.Close();
            //Get response from server
            HttpWebResponse POSTResponse = (HttpWebResponse)POSTRequest.GetResponse();
            StreamReader reader = new StreamReader(POSTResponse.GetResponseStream(), Encoding.UTF8);
            Console.WriteLine("Response");
            Console.WriteLine(reader.ReadToEnd().ToString());
            */
            /*
                // Create HttpClient instance to use for the app 
                HttpClient aClient = new HttpClient();

                // Uri is where we are posting to: 
                Uri theUri = new Uri(accountDetail.MiniJxtRestApi);
                aClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string payload = JsonConvert.SerializeObject(listings, Formatting.Indented);

                // use the Http client to POST some content ( ‘theContent’ not yet defined). 
                var response = await aClient.PostAsync(accountDetail.MiniJxtRestApi, new StringContent(payload, Encoding.UTF8, "application/json"));

                string contentResponse = await response.Content.ReadAsStringAsync();

                JobResponse jobResponse = JObject.Parse(contentResponse).ToObject<JobResponse>();
                return jobResponse;*/
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        #endregion

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }

        public DefaultResponse AvailableDataJXTPlatformGet(string username, string password, string advertiserID)
        {
            try
            {
                string targetPath = ConfigurationManager.AppSettings["WebServiceEndPoint"] + "?format=json";//"http://webservice.mini.jxt.com.au/Get/DefaultList?format={0}";
                _logger.DebugFormat("Request target path: {0}", targetPath);

                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create(targetPath);
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = string.Format(@"<DefaultRequest xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.servicestack.net/types""><UserName xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">{0}</UserName><Password xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">{1}</Password><AdvertiserId>{2}</AdvertiserId></DefaultRequest>", username, password, advertiserID);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/xml";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                _logger.DebugFormat("==========Server response==========\n{0}", responseFromServer);

                _logger.InfoFormat("Deserializing data");
                JavaScriptSerializer ser = new JavaScriptSerializer();
                DefaultResponse resultList = (DefaultResponse)ser.Deserialize<DefaultResponse>(responseFromServer);
                _logger.InfoFormat("Deserializing data completed");

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

                return resultList;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
