using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPosterTransform.Data;

namespace JXTPosterTransform.Library.Services
{
    public class PT_ClientService : IDisposable    
    {
        private PosterTransformEntities _context = new PosterTransformEntities();

        public Client ClientGetByClientSetupID(int setupID)
        {
            return (from setup in _context.ClientSetups
                    join client in _context.Clients on setup.ClientId equals client.ClientId
                    where setup.ClientSetupId == setupID
                    select client).FirstOrDefault();
        }

        public ClientSetup ClientSetupGetBySetupID(int setupID)
        {
            return (from m in _context.ClientSetups where m.ClientSetupId == setupID select m).FirstOrDefault();
        }

        public List<Client> ClientsListGet()
        {
            return _context.Clients.ToList();
        }

        public List<Client> ClientsListGet(List<int> clientIDs)
        {
            return _context.Clients.Where(c=> clientIDs.Contains(c.ClientId)).ToList();
        }

        public Client ClientDetailsGet(int clientID)
        {
            return _context.Clients.Where(c => c.ClientId == clientID).FirstOrDefault();
        }

        public bool ClientProfileCreate(string name, string description, int siteID, int valid, int modifiedByUserID)
        {
            Client thisClient = new Client();

            thisClient.ClientName = name;
            thisClient.ClientDescription = description;
            thisClient.SiteId = siteID;
            thisClient.Valid = valid;
            thisClient.LastModifiedBy = modifiedByUserID;
            thisClient.LastModifiedDate = DateTime.Now;
            thisClient.CreatedDate = DateTime.Now;

            _context.Clients.AddObject(thisClient);
            _context.SaveChanges();

            return true;

        }

        public bool ClientProfileUpdate(int clientID, string name, string description, int siteID, int valid, int modifiedByUserID)
        {
            Client thisClient = ClientDetailsGet(clientID);

            if (thisClient != null)
            {
                thisClient.ClientName = name;
                thisClient.ClientDescription = description;
                thisClient.SiteId = siteID;
                thisClient.Valid = valid;
                thisClient.LastModifiedBy = modifiedByUserID;
                thisClient.LastModifiedDate = DateTime.Now;

                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public List<int> ClientIDHasClientSetups()
        {
            return (from c in _context.Clients
             join s in _context.ClientSetups on c.ClientId equals s.ClientId
             select c.ClientId).Distinct().ToList();
        }

        public List<ClientSetup> ClientSetupsForClientGet(int clientID)
        {
            return (from m in _context.ClientSetups where m.ClientId == clientID select m).ToList();
        }

        public List<ClientSetup> ClientSetupsForStatusGet(int status)
        {
            return (from m in _context.ClientSetups where m.Valid == status select m).ToList();
        }

        public List<ClientSetup> ClientSetupsGetBySetupID(List<int> clientSetupIDs)
        {
            return (from m in _context.ClientSetups where clientSetupIDs.Contains(m.ClientSetupId) select m).ToList();
        }

        public bool ClientSetupRecordCreate(string name, string desc, int clientID,
            int ptID, int setupType, string jsonCredentials, int timeslot, int advertiserID, string advertiserUsername, string advertiserPassword, bool archiveMissingJobs,
            int valid, bool useJXTMappings, int modifiedBy)
        {
            ClientSetup thisSetup = new ClientSetup();

            thisSetup.ClientSetupName = name;
            thisSetup.ClientSetupDescription = desc;
            thisSetup.ClientId = clientID;
            thisSetup.ClientSetupType = setupType;
            thisSetup.ClientSetupTypeCredentials = jsonCredentials;
            thisSetup.TimeSlot = timeslot;
            thisSetup.PosterTransformId = ptID;
            thisSetup.AdvertiserId = advertiserID;
            thisSetup.AdvertiserUsername = advertiserUsername;
            thisSetup.AdvertiserPassword = advertiserPassword;
            thisSetup.ArchiveMissingJobs = archiveMissingJobs;
            thisSetup.Valid = valid;
            thisSetup.UseJXTSiteMappings = useJXTMappings;
            thisSetup.LastModifiedBy = modifiedBy;
            thisSetup.LastModifiedDate = DateTime.Now;
            thisSetup.CreatedDate = DateTime.Now;

            _context.ClientSetups.AddObject(thisSetup);
            _context.SaveChanges();
            return true;

        }

        public bool ClientSetupRecordUpdate(int setupID, string name, string desc,
            int ptID, int setupType, string jsonCredentials, int timeslot, int advertiserID, string advertiserUsername, string advertiserPassword, bool archiveMissingJobs,
            int valid, bool useJXTMappings, int modifiedBy)
        {
            ClientSetup thisSetup = (from m in _context.ClientSetups where m.ClientSetupId == setupID select m).FirstOrDefault();

            if (thisSetup != null)
            {
                thisSetup.ClientSetupName = name;
                thisSetup.ClientSetupDescription = desc;
                thisSetup.ClientSetupType = setupType;
                thisSetup.ClientSetupTypeCredentials = jsonCredentials;
                thisSetup.TimeSlot = timeslot;
                thisSetup.PosterTransformId = ptID;
                thisSetup.AdvertiserId = advertiserID;
                thisSetup.AdvertiserUsername = advertiserUsername;

                if (!string.IsNullOrEmpty(advertiserPassword))
                    thisSetup.AdvertiserPassword = advertiserPassword;

                thisSetup.ArchiveMissingJobs = archiveMissingJobs;

                thisSetup.UseJXTSiteMappings = useJXTMappings;
                thisSetup.Valid = valid;
                thisSetup.LastModifiedBy = modifiedBy;
                thisSetup.LastModifiedDate = DateTime.Now;

                _context.SaveChanges();
                return true;
            }


            return false;
        }

        public bool ClientSetupSetupCredentialsUpdate(int setupID, string setupCredentials)
        {
            ClientSetup thisSetup = (from m in _context.ClientSetups where m.ClientSetupId == setupID select m).FirstOrDefault();

            if (thisSetup != null)
            {
                thisSetup.ClientSetupTypeCredentials = setupCredentials;
                _context.SaveChanges();
                return true;
            }

            return false;
        }


        public List<ClientSetupLog> ClientSetupLogsListingGet()
        {
            return _context.ClientSetupLogs.OrderByDescending(c=>c.ClientSetupLogId).ToList();
        }

        public List<ClientSetupLog> ClientSetupLogsListingGet(int setupID)
        {
            return _context.ClientSetupLogs.Where(c => c.ClientSetupId == setupID).OrderByDescending(c=>c.ClientSetupLogId).ToList();
        }

        public List<ClientSetupLog> ClientSetupLogsListingGet(List<int> setupIDs)
        {
            return _context.ClientSetupLogs.Where(c => setupIDs.Contains(c.ClientSetupId)).OrderByDescending(c => c.ClientSetupLogId).ToList();
        }

        
        public ClientSetupLog ClientSetupLogGet(int logID)
        {
            return _context.ClientSetupLogs.Where(c => c.ClientSetupLogId == logID).FirstOrDefault();
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
    }
}
