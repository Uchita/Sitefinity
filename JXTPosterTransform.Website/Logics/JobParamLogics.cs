using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPortal;
using JXTPosterTransform.Data;
using JXTPosterTransform.Library.Services;
using JXTPortal.Entities;
using JXTPosterTransform.Website.Models;
using System.Net;
using System.Text;
using System.IO;
using JXTPosterTransform.Library.Models;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Configuration;

namespace JXTPosterTransform.Website.Logics
{
    public class JobParamLogics
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

        #endregion

        public List<JobTemplateAvailable> JobTemplateAvailableMappingGetByClientID(int clientID, out string errorMsg)
        {
            Client thisClient = PTClientService.ClientDetailsGet(clientID);
            ClientSetup thisClientFirstSetup = PTClientService.ClientSetupsForClientGet(thisClient.ClientId).OrderBy(c => c.ClientSetupId).FirstOrDefault();

            if (thisClient == null || thisClientFirstSetup == null)
            {
                //ERROR
                errorMsg = "Client/Client Setup record not found";
                return null;
            }
            else
            {
                int? clientSiteID = thisClient.SiteId;
                //get site available job templates from webservice

                DefaultResponse defaults = AvailableDataGet(thisClientFirstSetup.AdvertiserUsername, thisClientFirstSetup.AdvertiserPassword, thisClientFirstSetup.AdvertiserId.ToString());

                if (defaults != null && defaults.ResponseCode.ToLower() == "success")
                {
                    errorMsg = null;
                    return (from t in defaults.DefaultList.JobTemplates select new JobTemplateAvailable { MapToJobTemplateID = int.Parse(t.JobTemplateID), MapToJobTemplateDescription = t.JobTemplateDescription }).OrderBy(c=>c.MapToJobTemplateDescription).ToList();
                }

                errorMsg = "Failed to retreive default list - " + defaults.ResponseCode;
                return null;
            }
        }

        public List<JobTemplateLogoAvailable> JobTemplateLogosAvailableMappingGetByClientID(int clientID, out string errorMsg)
        {
            Client thisClient = PTClientService.ClientDetailsGet(clientID);
            ClientSetup thisClientFirstSetup = PTClientService.ClientSetupsForClientGet(thisClient.ClientId).OrderBy(c => c.ClientSetupId).FirstOrDefault();

            if (thisClient == null || thisClientFirstSetup == null)
            {
                //ERROR
                errorMsg = "Client/Client Setup record not found";
                return null;
            }
            else
            {
                int? clientSiteID = thisClient.SiteId;
                //get site available job templates from webservice

                DefaultResponse defaults = AvailableDataGet(thisClientFirstSetup.AdvertiserUsername, thisClientFirstSetup.AdvertiserPassword, thisClientFirstSetup.AdvertiserId.ToString());

                if (defaults != null && defaults.ResponseCode.ToLower() == "success")
                {
                    errorMsg = null;
                    return (from t in defaults.DefaultList.AdvertiserJobTemplateLogos select new JobTemplateLogoAvailable { MapToJobTemplateLogoID = int.Parse(t.AdvertiserJobTemplateLogoID), MapToJobTemplateLogoDescription = t.LogoName }).OrderBy(c=>c.MapToJobTemplateLogoDescription).ToList();
                }

                errorMsg = "Failed to retreive default list - " + defaults.ResponseCode;
                return null;
            }
        }

        public List<WorkTypeAvailable> WorkTypesAvailableMappingGetByClientID(int clientID, out string errorMsg)
        {
            Client thisClient = PTClientService.ClientDetailsGet(clientID);
            ClientSetup thisClientFirstSetup = PTClientService.ClientSetupsForClientGet(thisClient.ClientId).OrderBy(c => c.ClientSetupId).FirstOrDefault();

            if (thisClient == null || thisClientFirstSetup == null)
            {
                //ERROR
                errorMsg = "Client/Client Setup record not found";
                return null;
            }
            else
            {
                int? clientSiteID = thisClient.SiteId;
                //get site available job templates from webservice

                DefaultResponse defaults = AvailableDataGet(thisClientFirstSetup.AdvertiserUsername, thisClientFirstSetup.AdvertiserPassword, thisClientFirstSetup.AdvertiserId.ToString());

                if (defaults != null && defaults.ResponseCode.ToLower() == "success")
                {
                    errorMsg = null;
                    return (from t in defaults.DefaultList.WorkTypes select new WorkTypeAvailable { MapToWorkTypeID = int.Parse(t.WorkTypeID), MapToWorkTypeDescription = t.WorkTypeName }).OrderBy(c=>c.MapToWorkTypeDescription).ToList();
                }

                errorMsg = "Failed to retreive default list - " + defaults.ResponseCode;
                return null;
            }
        }

        public List<SalaryTypeAvailable> SalaryTypesAvailableMappingGetByClientID(int clientID, out string errorMsg)
        {
            Client thisClient = PTClientService.ClientDetailsGet(clientID);
            ClientSetup thisClientFirstSetup = PTClientService.ClientSetupsForClientGet(thisClient.ClientId).OrderBy(c => c.ClientSetupId).FirstOrDefault();

            if (thisClient == null || thisClientFirstSetup == null)
            {
                //ERROR
                errorMsg = "Client/Client Setup record not found";
                return null;
            }
            else
            {
                int? clientSiteID = thisClient.SiteId;
                //get site available job templates from webservice

                DefaultResponse defaults = AvailableDataGet(thisClientFirstSetup.AdvertiserUsername, thisClientFirstSetup.AdvertiserPassword, thisClientFirstSetup.AdvertiserId.ToString());

                if (defaults != null && defaults.ResponseCode.ToLower() == "success")
                {
                    errorMsg = null;
                    return (from t in defaults.DefaultList.SalaryTypes select new SalaryTypeAvailable { MapToSalaryTypeID = int.Parse(t.SalaryTypeID), MapToSalaryTypeDescription = t.SalaryTypeName }).ToList();
                }

                errorMsg = "Failed to retreive default list - " + defaults.ResponseCode;
                return null;
            }
        }

        public List<PRItem> PRAvailableMappingGetByClientID(int clientID, out string errorMsg)
        {
            Client thisClient = PTClientService.ClientDetailsGet(clientID);
            ClientSetup thisClientFirstSetup = PTClientService.ClientSetupsForClientGet(thisClient.ClientId).OrderBy(c => c.ClientSetupId).FirstOrDefault();

            if (thisClient == null)
            {
                //ERROR
                errorMsg = "Client/Client Setup record not found";
                return null;
            }
            else
            {
                int? clientSiteID = thisClient.SiteId;
                //get site available job templates from webservice

                DefaultResponse defaults = AvailableDataGet(thisClientFirstSetup.AdvertiserUsername, thisClientFirstSetup.AdvertiserPassword, thisClientFirstSetup.AdvertiserId.ToString());

                if (defaults != null && defaults.ResponseCode.ToLower() == "success")
                {
                    errorMsg = null;
                    List<PRItem> profRoles = new List<PRItem>();

                    List<int> profIDs = defaults.DefaultList.ProfessionRoles.Select(c => int.Parse(c.ProfessionID)).Distinct().ToList();

                    foreach (int pID in profIDs)
                    {
                        PRItem thisProf = new PRItem { id = pID, description = defaults.DefaultList.ProfessionRoles.Where(c => int.Parse(c.ProfessionID) == pID).Select(c => c.ProfessionName).FirstOrDefault(), childs = new List<PRItem>() };

                        List<int> roleIDs = defaults.DefaultList.ProfessionRoles.Where(c => int.Parse(c.ProfessionID) == pID).Select(c => int.Parse(c.RoleID)).Distinct().ToList();

                        foreach (int rID in roleIDs)
                        {
                            PRItem thisRole = new PRItem { id = rID, description = defaults.DefaultList.ProfessionRoles.Where(c => int.Parse(c.RoleID) == rID).Select(c => c.RoleName).FirstOrDefault(), childs = new List<PRItem>() };

                            thisProf.childs.Add(thisRole);
                        }

                        //sort
                        thisProf.childs = thisProf.childs.OrderBy(c => c.description).ToList();

                        profRoles.Add(thisProf);
                    }

                    return profRoles.OrderBy(c=>c.description).ToList();
                }

                errorMsg = "Failed to retreive default list - " + defaults.ResponseCode;
                return null;
            }
        }

        public List<CLAItem> CLAAvailableMappingGetByClientID(int clientID, out string errorMsg)
        {
            Client thisClient = PTClientService.ClientDetailsGet(clientID);
            ClientSetup thisClientFirstSetup = PTClientService.ClientSetupsForClientGet(thisClient.ClientId).OrderBy(c => c.ClientSetupId).FirstOrDefault();

            if (thisClient == null)
            {
                //ERROR
                errorMsg = "Client/Client Setup record not found";
                return null;
            }
            else
            {
                int? clientSiteID = thisClient.SiteId;
                //get site available job templates from webservice

                DefaultResponse defaults = AvailableDataGet(thisClientFirstSetup.AdvertiserUsername, thisClientFirstSetup.AdvertiserPassword, thisClientFirstSetup.AdvertiserId.ToString());

                if (defaults != null && defaults.ResponseCode.ToLower() == "success")
                {
                    errorMsg = null;
                    List<CLAItem> countryLocAreas = new List<CLAItem>();

                    List<int> countryListIDs = defaults.DefaultList.CountryLocationAreas.Select(c=>int.Parse(c.CountryID)).Distinct().ToList();

                    foreach(int countryID in countryListIDs)
                    {
                        CLAItem thisCountry = new CLAItem{ id = countryID, description = defaults.DefaultList.CountryLocationAreas.Where(c=>int.Parse(c.CountryID) == countryID).Select(c=>c.CountryName).FirstOrDefault(), childs = new List<CLAItem>() };

                        List<int> locationListIDs = defaults.DefaultList.CountryLocationAreas.Where(c=>int.Parse(c.CountryID) == countryID).Select(c=>int.Parse(c.LocationID)).Distinct().ToList();

                        foreach(int locationID in locationListIDs)
                        {
                            CLAItem thisLocation = new CLAItem {id = locationID, description = defaults.DefaultList.CountryLocationAreas.Where(c=>int.Parse(c.LocationID) == locationID).Select(c=>c.LocationName).FirstOrDefault(), childs = new List<CLAItem>() };

                            //AREAs
                            foreach(DefaultList.CountryLocationArea area in defaults.DefaultList.CountryLocationAreas.Where(c=>int.Parse(c.CountryID) == countryID && int.Parse(c.LocationID) == locationID).ToList())
                            {
                                CLAItem thisArea = new CLAItem  {id = int.Parse(area.AreaID), description = area.AreaName };

                                thisLocation.childs.Add(thisArea);
                            }

                            //sort
                            thisLocation.childs = thisLocation.childs.OrderBy(c => c.description).ToList();

                            thisCountry.childs.Add(thisLocation);
                        }

                        //sort
                        thisCountry.childs = thisCountry.childs.OrderBy(c => c.description).ToList();

                        countryLocAreas.Add(thisCountry);
                    }

                    return countryLocAreas.OrderBy(c=>c.description).ToList();
                }

                errorMsg = "Failed to retreive default list - " + defaults.ResponseCode; 
                return null;
            }
        }


        private DefaultResponse AvailableDataGet(string username, string password, string advertiserID)
        {
            try
            {
                string targetPath = ConfigurationManager.AppSettings["WebServiceEndPoint"];//"http://webservice.mini.jxt.com.au/Get/DefaultList?format=json";

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

                JavaScriptSerializer ser = new JavaScriptSerializer();
                DefaultResponse resultList = (DefaultResponse)ser.Deserialize<DefaultResponse>(responseFromServer);

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