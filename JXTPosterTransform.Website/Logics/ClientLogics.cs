using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPosterTransform.Library.Services;
using JXTPosterTransform.Data;
using JXTPosterTransform.Website.Models;
using JXTPosterTransform.Library.Common;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using JXTPosterTransform.Library.Models;

namespace JXTPosterTransform.Website.Logics
{
    public class ClientLogics
    {
        #region Services Connections

        private PT_ClientService _ptClientService;
        private PT_ClientService PTClientService
        {
            get
            {
                if (_ptClientService == null)
                    _ptClientService = new PT_ClientService();
                return _ptClientService;
            }
        }

        private PT_PosterTransformService _ptPosterTransformService;
        private PT_PosterTransformService PTPosterTransformService
        {
            get
            {
                if (_ptPosterTransformService == null)
                    _ptPosterTransformService = new PT_PosterTransformService();
                return _ptPosterTransformService;
            }
        }

        #endregion

        public List<ClientDisplayModel> ClientListingGet()
        {
            List<Client> clients = PTClientService.ClientsListGet();
            List<int> clientIDsWithClientSetups = PTClientService.ClientIDHasClientSetups();

            return (from c in clients
                    select new ClientDisplayModel
                    {
                        clientID = c.ClientId,
                        createdDate = c.CreatedDate,
                        description = c.ClientDescription,
                        //webURL = c.WebUrl,
                        lastModifiedBy = c.LastModifiedBy,
                        lastModifiedDate = c.LastModifiedDate,
                        name = c.ClientName,
                        siteID = c.SiteId.Value,
                        valid = (PTCommonEnums.Client.Valid)c.Valid,
                        hasClientSetups = clientIDsWithClientSetups.Contains(c.ClientId)
                    }).ToList();
        }

        public List<ClientDisplayModel> ClientListingGet(PTCommonEnums.Client.Valid? statusFilter, int countPerPage, int page, out int count)
        {
            List<Client> clients = PTClientService.ClientsListGet();
            List<int> clientIDsWithClientSetups = PTClientService.ClientIDHasClientSetups();

            List<ClientDisplayModel> results = (from c in clients
                                                where statusFilter == null ? true : ( c.Valid == (int) statusFilter )
                                                select new ClientDisplayModel
                                                {
                                                    clientID = c.ClientId,
                                                    createdDate = c.CreatedDate,
                                                    description = c.ClientDescription,
                                                    //webURL = c.WebUrl,
                                                    lastModifiedBy = c.LastModifiedBy,
                                                    lastModifiedDate = c.LastModifiedDate,
                                                    name = c.ClientName,
                                                    siteID = c.SiteId.Value,
                                                    valid = (PTCommonEnums.Client.Valid)c.Valid,
                                                    hasClientSetups = clientIDsWithClientSetups.Contains(c.ClientId)
                                                }).ToList();

            count = results.Count();

            return results.Skip(countPerPage * (page - 1)).Take(countPerPage).ToList();

        }


        public ClientDisplayModel ClientProfileGet(int clientID)
        {
            Client thisClient = PTClientService.ClientDetailsGet(clientID);

            return new ClientDisplayModel
                    {
                        clientID = thisClient.ClientId,
                        createdDate = thisClient.CreatedDate,
                        description = thisClient.ClientDescription,
                        lastModifiedBy = thisClient.LastModifiedBy,
                        lastModifiedDate = thisClient.LastModifiedDate,
                        name = thisClient.ClientName,
                        siteID = thisClient.SiteId.Value,
                        valid = (PTCommonEnums.Client.Valid)thisClient.Valid,
                        hasClientSetups = thisClient.ClientSetups.Any()
                    };
        }

        public bool ClientProfileDetailsUpdate(ClientDisplayModel client, out string errorMsg)
        {
            bool updateSuccess;

            if (client.clientID == 0) //create
                updateSuccess = PTClientService.ClientProfileCreate(client.name, client.description, client.siteID, (int)client.valid, 0);
            else
                updateSuccess = PTClientService.ClientProfileUpdate(client.clientID, client.name, client.description, client.siteID, (int)client.valid, 0);

            if (updateSuccess)
            {
                errorMsg = null;
                return true;
            }
            else
            {
                errorMsg = "Client not found or failed to create client.";
                return false;
            }

        }

        public List<ClientSetupDisplayModel> ClientSetupsGet(int clientID)
        {
            List<ClientSetup> setups = PTClientService.ClientSetupsForClientGet(clientID);

            return (from m in setups
                    select new ClientSetupDisplayModel
                    {
                        advertiserID = m.AdvertiserId,
                        //advertiserPassword
                        advertiserUsername = m.AdvertiserUsername,
                        clientID = m.ClientId,
                        //posterTransformID = m.PosterTransformId.Value,
                        setupDescription = m.ClientSetupDescription,
                        setupID = m.ClientSetupId,
                        setupName = m.ClientSetupName,
                        setupType = (PTCommonEnums.ClientSetup.ClientSetupType)m.ClientSetupType,
                        setupTypeText = FrontEndHelper.GetEnumDescription(((PTCommonEnums.ClientSetup.ClientSetupType)m.ClientSetupType)),
                        setupTypeCredentials = m.ClientSetupTypeCredentials,
                        timeslot = m.TimeSlot,
                        validStatus = (PTCommonEnums.ClientSetup.Valid)m.Valid

                    }).ToList();

        }


        public List<ClientSetupDisplayModel> ClientSetupsAllActiveGet()
        {
            List<ClientSetup> setups = PTClientService.ClientSetupsForStatusGet((int)PTCommonEnums.ClientSetup.Valid.Valid);

            return (from m in setups
                    select new ClientSetupDisplayModel
                    {
                        advertiserID = m.AdvertiserId,
                        //advertiserPassword
                        advertiserUsername = m.AdvertiserUsername,
                        clientID = m.ClientId,
                        clientName = m.Client.ClientName,
                        posterTransformID = m.PosterTransformId.Value,
                        posterTransformName = m.PosterTransform.PosterTransformName,
                        setupDescription = m.ClientSetupDescription,
                        setupID = m.ClientSetupId,
                        setupName = m.ClientSetupName,
                        setupType = (PTCommonEnums.ClientSetup.ClientSetupType)m.ClientSetupType,
                        setupTypeText = FrontEndHelper.GetEnumDescription(((PTCommonEnums.ClientSetup.ClientSetupType)m.ClientSetupType)),
                        setupTypeCredentials = m.ClientSetupTypeCredentials,
                        timeslot = m.TimeSlot,
                        validStatus = (PTCommonEnums.ClientSetup.Valid)m.Valid

                    }).ToList();

        }


        public ClientSetupDisplayModel ClientSetupGetByID(int? setupID, int? preselectedClientID)
        {
            List<PosterTransform> pt = PTPosterTransformService.PosterTransformAllGet();

            if (setupID == null)
            {
                ClientSetupDisplayModel newModel = new ClientSetupDisplayModel();

                Client thisClient = PTClientService.ClientDetailsGet(preselectedClientID.Value);
                if (preselectedClientID != null && thisClient != null)
                {
                    newModel.clientID = thisClient.ClientId;
                    newModel.clientName = thisClient.ClientName;
                }

                newModel.available_PT = (from m in pt
                                         where (PTCommonEnums.PosterTransform.Valid)m.Valid == PTCommonEnums.PosterTransform.Valid.Valid
                                         select new PosterTransformModel
                             {
                                 //lastModified = pt.LastModifiedDate.Value,
                                 //lastModifiedBy = pt.LastModifiedBy.Value,
                                 PTDesc = m.PosterTransformDescription,
                                 PTID = m.PosterTransformId,
                                 PTName = m.PosterTransformName,
                                 PTValid = (PTCommonEnums.PosterTransform.Valid)m.Valid,
                                 testXML = m.TestXML,
                                 XSL = m.PosterTransformXSL
                             }).ToList();
                return newModel;
            }
            else
            {
                ClientSetup setup = PTClientService.ClientSetupGetBySetupID(setupID.Value);

                ClientSetupDisplayModel thisSetupDetails = new ClientSetupDisplayModel
                        {
                            advertiserID = setup.AdvertiserId,
                            advertiserPassword = setup.AdvertiserPassword,
                            advertiserUsername = setup.AdvertiserUsername,
                            ArchiveMissingJobs = setup.ArchiveMissingJobs,
                            clientID = setup.ClientId,
                            clientName = setup.Client.ClientName,

                            posterTransformID = setup.PosterTransformId,
                            available_PT = (from m in pt
                                            where (PTCommonEnums.PosterTransform.Valid)m.Valid == PTCommonEnums.PosterTransform.Valid.Valid
                                            select new PosterTransformModel
                                {
                                    //lastModified = pt.LastModifiedDate.Value,
                                    //lastModifiedBy = pt.LastModifiedBy.Value,
                                    PTDesc = m.PosterTransformDescription,
                                    PTID = m.PosterTransformId,
                                    PTName = m.PosterTransformName,
                                    PTValid = (PTCommonEnums.PosterTransform.Valid)m.Valid,
                                    testXML = m.TestXML,
                                    XSL = m.PosterTransformXSL
                                }).ToList(),

                            setupDescription = setup.ClientSetupDescription,
                            setupID = setup.ClientSetupId,
                            setupName = setup.ClientSetupName,
                            setupType = (PTCommonEnums.ClientSetup.ClientSetupType)setup.ClientSetupType,
                            //setupTypeCredentials = setup.ClientSetupTypeCredentials,
                            timeslot = setup.TimeSlot,
                            validStatus = (PTCommonEnums.ClientSetup.Valid)setup.Valid

                        };

                try
                {
                    //process the setup type credentials
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    switch ((PTCommonEnums.ClientSetup.ClientSetupType)setup.ClientSetupType)
                    {
                        case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromUrl:
                            thisSetupDetails.PullXmlFromUrl = jss.Deserialize<ClientSetupModels.PullXmlFromUrl>(setup.ClientSetupTypeCredentials);
                            break;
                        case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromUrlWithAuth:
                            thisSetupDetails.PullXmlFromUrlWithAuth = jss.Deserialize<ClientSetupModels.PullXmlFromUrlWithAuth>(setup.ClientSetupTypeCredentials);
                            break;
                        case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromFTP:
                            thisSetupDetails.PullXmlFromFTP = jss.Deserialize<ClientSetupModels.PullXmlFromFTP>(setup.ClientSetupTypeCredentials);
                            break;
                        case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromSFTP:
                            thisSetupDetails.PullXmlFromSFTP = jss.Deserialize<ClientSetupModels.PullXmlFromSFTP>(setup.ClientSetupTypeCredentials);
                            break;
                        case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromRGF:
                            thisSetupDetails.PullXmlRGF = jss.Deserialize<ClientSetupModels.PullXmlFromSalesforceRGF>(setup.ClientSetupTypeCredentials);
                            break;
                        case PTCommonEnums.ClientSetup.ClientSetupType.PullFromInvenias:
                            thisSetupDetails.PullFromInvenias = jss.Deserialize<ClientSetupModels.PullFromInvenias>(setup.ClientSetupTypeCredentials);
                            break;
                        case PTCommonEnums.ClientSetup.ClientSetupType.PullJsonFromUrl:
                            thisSetupDetails.PullJsonFromUrl = jss.Deserialize<ClientSetupModels.PullJsonFromUrl>(setup.ClientSetupTypeCredentials);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    //ignore
                }

                return thisSetupDetails;
            }
        }

        public bool ClientSetupUpdateByID(ClientSetupDisplayModel setupDetails)
        {
            bool updateClientSetupSuccess;

            //process the setup type credentials
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string setupTypeCredentials = null;
            switch (setupDetails.setupType)
            {
                case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromUrl:
                    setupTypeCredentials = jss.Serialize(setupDetails.PullXmlFromUrl);
                    break;
                case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromUrlWithAuth:
                    setupTypeCredentials = jss.Serialize(setupDetails.PullXmlFromUrlWithAuth);
                    break;
                case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromFTP:
                    setupTypeCredentials = jss.Serialize(setupDetails.PullXmlFromFTP);
                    break;
                case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromSFTP:
                    setupTypeCredentials = jss.Serialize(setupDetails.PullXmlFromSFTP);
                    break;
                case PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromRGF:
                    setupTypeCredentials = jss.Serialize(setupDetails.PullXmlRGF);
                    break;
                case PTCommonEnums.ClientSetup.ClientSetupType.PullFromInvenias:
                    setupTypeCredentials = jss.Serialize(setupDetails.PullFromInvenias);
                    break;
                case PTCommonEnums.ClientSetup.ClientSetupType.PullJsonFromUrl:
                    setupTypeCredentials = jss.Serialize(setupDetails.PullJsonFromUrl);
                    break;
                default:
                    break;
            }

            if (setupDetails.setupID == null)
            {
                updateClientSetupSuccess = PTClientService.ClientSetupRecordCreate(
                                    setupDetails.setupName,
                                    setupDetails.setupDescription,
                                    setupDetails.clientID,
                                    setupDetails.posterTransformID.Value,
                                    (int)setupDetails.setupType,
                                    setupTypeCredentials,
                                    setupDetails.timeslot,
                                    setupDetails.advertiserID.Value,
                                    setupDetails.advertiserUsername,
                                    setupDetails.advertiserPassword,
                                    setupDetails.ArchiveMissingJobs,
                                    (int)setupDetails.validStatus,
                                    0);
            }
            else
            {
                updateClientSetupSuccess = PTClientService.ClientSetupRecordUpdate(
                                    setupDetails.setupID.Value,
                                    setupDetails.setupName,
                                    setupDetails.setupDescription,
                                    setupDetails.posterTransformID.Value,
                                    (int)setupDetails.setupType,
                                    setupTypeCredentials,
                                    setupDetails.timeslot,
                                    setupDetails.advertiserID.Value,
                                    setupDetails.advertiserUsername,
                                    setupDetails.advertiserPassword,
                                    setupDetails.ArchiveMissingJobs,
                                    (int)setupDetails.validStatus,
                                    0);
            }

            return updateClientSetupSuccess;

        }

        public List<ClientSetupLogDisplayModel> ClientSetupLogsAllGet(int countPerPage, int page, out int count)
        {
            List<ClientSetupLog> logs = PTClientService.ClientSetupLogsListingGet();

            List<ClientSetupLogDisplayModel> results = (from m in logs
                    select new ClientSetupLogDisplayModel
                    {
                        ClientSetupLogId = m.ClientSetupLogId,
                        ClientId = m.ClientId,
                        ClientName = m.Client.ClientName,
                        ClientSetupId = m.ClientSetupId,
                        ClientSetupName = m.ClientSetup.ClientSetupName,
                        PosterTransformId = m.PosterTransformId,
                        PosterTransformName = m.PosterTransform.PosterTransformName,
                        CreatedDate = m.CreatedDate,
                        FinishedDate = m.FinishedDate,
                        RawDataFileName = m.RawData,
                        RequestDataFileName = m.RequestData,
                        ResponseDataFileName = m.ResponseData,
                        Failed = m.Failed
                    }).ToList();
            count = results.Count();
            return results.Skip(countPerPage * (page - 1)).Take(countPerPage).ToList();
        }



        public List<ClientSetupLogDisplayModel> ClientSetupLogsGetByClientID(int clientID, int countPerPage, int page, out int count)
        {
            List<ClientSetup> setups = PTClientService.ClientSetupsForClientGet(clientID);

            List<ClientSetupLog> logs = PTClientService.ClientSetupLogsListingGet(setups.Select(c=>c.ClientSetupId).ToList());

            List<ClientSetupLogDisplayModel> results = (from m in logs
                    select new ClientSetupLogDisplayModel
                    {
                        ClientSetupLogId = m.ClientSetupLogId,
                        ClientId = m.ClientId,
                        ClientName = m.Client.ClientName,
                        ClientSetupId = m.ClientSetupId,
                        ClientSetupName = m.ClientSetup.ClientSetupName,
                        PosterTransformId = m.PosterTransformId,
                        PosterTransformName = m.PosterTransform.PosterTransformName,
                        CreatedDate = m.CreatedDate,
                        FinishedDate = m.FinishedDate,
                        RawDataFileName = m.RawData,
                        RequestDataFileName = m.RequestData,
                        ResponseDataFileName = m.ResponseData,
                        Failed = m.Failed
                    }).ToList();

            count = results.Count();
            return results.Skip(countPerPage * (page - 1)).Take(countPerPage).ToList();
        }


        public List<ClientSetupLogDisplayModel> ClientSetupLogsGetBySetupID(int setupID, int countPerPage, int page, out int count)
        {
            List<ClientSetupLog> logs = PTClientService.ClientSetupLogsListingGet(setupID);
            //List<Client> clients = PTClientService.ClientsListGet(logs.Select(c => c.ClientId).Distinct().ToList());
            //List<ClientSetup> clientSetups = PTClientService.ClientSetupsGetBySetupID(logs.Select(c => c.ClientSetupId).Distinct().ToList());

            List<ClientSetupLogDisplayModel> results = (from m in logs
                                                        select new ClientSetupLogDisplayModel
                                                        {
                                                            ClientSetupLogId = m.ClientSetupLogId,
                                                            ClientId = m.ClientId,
                                                            ClientName = m.Client.ClientName,
                                                            ClientSetupId = m.ClientSetupId,
                                                            ClientSetupName = m.ClientSetup.ClientSetupName,
                                                            PosterTransformId = m.PosterTransformId,
                                                            PosterTransformName = m.PosterTransform.PosterTransformName,
                                                            CreatedDate = m.CreatedDate,
                                                            FinishedDate = m.FinishedDate,
                                                            RawDataFileName = m.RawData,
                                                            RequestDataFileName = m.RequestData,
                                                            ResponseDataFileName = m.ResponseData,
                                                            Failed = m.Failed
                                                        }).ToList();

            count = results.Count();
            return results.Skip(countPerPage * (page-1)).Take(countPerPage).ToList();;
        }

        public ClientSetupLogDisplayModel ClientSetupLogDetailsGetByID(int logID)
        {
            ClientSetupLog log = PTClientService.ClientSetupLogGet(logID);

            ClientSetupLogDisplayModel returnModel = new ClientSetupLogDisplayModel
                    {
                        ClientSetupLogId = log.ClientSetupLogId,
                        ClientId = log.ClientId,
                        ClientName = log.Client.ClientName,
                        ClientSetupId = log.ClientSetupId,
                        ClientSetupName = log.ClientSetup.ClientSetupName,
                        PosterTransformId = log.PosterTransformId,
                        PosterTransformName = log.PosterTransform.PosterTransformName,
                        CreatedDate = log.CreatedDate,
                        FinishedDate = log.FinishedDate,
                        RawDataFileName = log.RawData,
                        RequestDataFileName = log.RequestData,
                        ResponseDataFileName = log.ResponseData,
                        Failed = log.Failed
                    };

            return returnModel;

        }
    }
}