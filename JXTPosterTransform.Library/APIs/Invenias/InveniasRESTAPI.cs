using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace JXTPosterTransform.Library.APIs.Invenias
{
    public class InveniasRESTAPI
    {
        InveniasSettings _settings;

        public InveniasRESTAPI(string clientID, string username, string password)
        {
            _settings = new InveniasSettings { ClientID = clientID, Username = username, Password = password };
        }

        public InveniaTokenResponse Authenticate(bool SaveTokenToJXTIntegrations)
        {
            string tokenURL = "https://publicapi.invenias.com/token";

            string postData = string.Format("grant_type=password&username={0}&password={1}&client_id={2}", _settings.Username, _settings.Password, _settings.ClientID);
            string tokenResponse = HttpPost(tokenURL, postData, false);

            if (!string.IsNullOrEmpty(tokenResponse))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniaTokenResponse token = (InveniaTokenResponse)ser.Deserialize(tokenResponse, typeof(InveniaTokenResponse));

                _settings.RESTAuthToken = token.access_token;
                //_settings.RESTAuthRefreshToken = token.refresh_token;

                return token;
            }

            return null;
        }

        //public InveniaTokenResponse RefreshToken()
        //{
        //    string tokenURL = "https://publicapi.invenias.com/token";

        //    string postData = string.Format("grant_type=refresh_token&client_id={0}&refresh_token={1}", _settings.ClientID, _settings.RESTAuthRefreshToken);
        //    string tokenResponse = HttpPost(tokenURL, postData, false);

        //    if (!string.IsNullOrEmpty(tokenResponse))
        //    {
        //        JavaScriptSerializer ser = new JavaScriptSerializer();
        //        InveniaTokenResponse token = (InveniaTokenResponse)ser.Deserialize(tokenResponse, typeof(InveniaTokenResponse));

        //        if (token != null)
        //        {
        //            //when calling refresh token, there is no new refresh token returned
        //            //Save it back to integrations
        //            IntegrationsService.InveniasTokenUpdate(_siteID, token.access_token, null);
        //        }

        //        return token;
        //    }

        //    return null;
        //}

        public List<InveniasAdvertisementsValue> AdvertisementsGet()
        {
            string targetURL = "https://publicapi.invenias.com/v1/Advertisements";

            string advertisements = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(advertisements))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniasAdvertisementsRoot token = (InveniasAdvertisementsRoot)ser.Deserialize(advertisements, typeof(InveniasAdvertisementsRoot));

                return token.value;
            }
            return null;
        }

        public List<InveniasAssignmentValue> AssignmentsGet()
        {
            string targetURL = "https://publicapi.invenias.com/v1/Assignments";

            string assignments = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(assignments))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniasAssignmentsRoot token = (InveniasAssignmentsRoot)ser.Deserialize(assignments, typeof(InveniasAssignmentsRoot));

                return token.value;
            }
            return null;
        }

        public List<InveniasAssignmentValue> AdvertisementAssignmentGet(string advertisementID)
        {
            string targetURL = "https://publicapi.invenias.com/v1/Advertisements(" + advertisementID + ")/Assignment";

            string assignment = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(assignment))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniasAssignmentsRoot token = (InveniasAssignmentsRoot)ser.Deserialize(assignment, typeof(InveniasAssignmentsRoot));

                return token.value;
            }
            return null;

        }

        public bool AdvertisementCreate(InveniasAdvertisementsValue ad)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string adJson = ser.Serialize(ad);

            HttpPost("https://publicapi.invenias.com/v1/Advertisements", adJson, true);

            return true;
        }

        public bool AssignmentCreate(InveniasAssignmentValue ad)
        {
            JsonSerializer ser2 = new JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
            string adJson = JsonConvert.SerializeObject(ad, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

            HttpPost("https://publicapi.invenias.com/v1/Assignments", adJson, true);

            return true;
        }

        public bool LocationCreate(InveniasLocationValue loc)
        {
            JsonSerializer ser2 = new JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
            string adJson = JsonConvert.SerializeObject(loc, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

            HttpPost("https://publicapi.invenias.com/v1/Locations", adJson, true);

            return true;
        }

        public List<InveniasLocationValue> LocationsGet()
        {
            string targetURL = "https://publicapi.invenias.com/v1/Locations";

            string locations = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(locations))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniasLocationRoot token = (InveniasLocationRoot)ser.Deserialize(locations, typeof(InveniasLocationRoot));

                return token.value;
            }
            return null;
        }

        public List<InveniasLocationValue> AssignmentLocationsGet(string assignmentID)
        {
            string targetURL = "https://publicapi.invenias.com/v1/Assignments(" + assignmentID + ")/Location";

            string locations = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(locations))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniasLocationRoot token = (InveniasLocationRoot)ser.Deserialize(locations, typeof(InveniasLocationRoot));

                return token.value;
            }
            return null;
        }

        public bool InterimRateCreate(InveniaInterimRatesValue rate)
        {
            JsonSerializer ser2 = new JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
            string rateJson = JsonConvert.SerializeObject(rate, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

            HttpPost("https://publicapi.invenias.com/v1/InterimRates", rateJson, true);

            return true;
        }

        public List<InveniaInterimRatesValue> AssignmentInterimRate(string assignmentID)
        {
            string targetURL = "https://publicapi.invenias.com/v1/Assignments(" + assignmentID + ")/InterimRate";

            string locations = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(locations))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniaInterimRatesRoot token = (InveniaInterimRatesRoot)ser.Deserialize(locations, typeof(InveniaInterimRatesRoot));

                return token.value;
            }
            return null;
        }


        public object InterimRatesGet()
        {
            string targetURL = "https://publicapi.invenias.com/v1/InterimRates";

            string locations = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(locations))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniaInterimRatesRoot token = (InveniaInterimRatesRoot)ser.Deserialize(locations, typeof(InveniaInterimRatesRoot));

                return token.value;
            }
            return null;
        }

        public object CurrencyGet()
        {
            string targetURL = "https://publicapi.invenias.com/v1/Currencies";

            string locations = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(locations))
            {
                //JavaScriptSerializer ser = new JavaScriptSerializer();
                //InveniaInterimRatesRoot token = (InveniaInterimRatesRoot)ser.Deserialize(locations, typeof(InveniaInterimRatesRoot));

                //return token.value;
            }
            return null;
        }


        public bool NonExecPackageCreate(InveniaNonExecPackageValue rate)
        {
            JsonSerializer ser2 = new JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
            string rateJson = JsonConvert.SerializeObject(rate, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

            HttpPost("https://publicapi.invenias.com/v1/NonExecPackages", rateJson, true);

            return true;
        }

        public List<InveniaNonExecPackageValue> AssignmentNonExecPackageGet(string assignmentID)
        {
            string targetURL = "https://publicapi.invenias.com/v1/Assignments(" + assignmentID + ")/NonExecPackage";

            string locations = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(locations))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniaNonExecPackageRoot token = (InveniaNonExecPackageRoot)ser.Deserialize(locations, typeof(InveniaNonExecPackageRoot));

                return token.value;
            }
            return null;
        }

        public bool PermanentPackageCreate(InveniaPermanentPackageValue rate)
        {
            JsonSerializer ser2 = new JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
            string rateJson = JsonConvert.SerializeObject(rate, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

            HttpPost("https://publicapi.invenias.com/v1/PermanentPackages", rateJson, true);

            return true;
        }

        public List<InveniaPermanentPackageValue> AssignmentPermanentPackageGet(string assignmentID)
        {
            string targetURL = "https://publicapi.invenias.com/v1/Assignments(" + assignmentID + ")/PermanentPackage";

            string locations = HttpGet(targetURL, true);

            if (!string.IsNullOrEmpty(locations))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                InveniaPermanentPackageRoot token = (InveniaPermanentPackageRoot)ser.Deserialize(locations, typeof(InveniaPermanentPackageRoot));

                return token.value;
            }
            return null;
        }

        public bool CategoryListEntryCreate(InveniaCategoryListEntryValue entry)
        {
            JsonSerializer ser2 = new JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
            string rateJson = JsonConvert.SerializeObject(entry, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

            HttpPost("https://publicapi.invenias.com/v1/CategoryListEntries", rateJson, true);

            return true;
        }

        public bool CategoryListCreate(InveniaCategoryListValue entry)
        {
            JsonSerializer ser2 = new JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
            string rateJson = JsonConvert.SerializeObject(entry, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

            HttpPost("https://publicapi.invenias.com/v1/CategoryLists", rateJson, true);

            return true;
        }


        public bool RelationCreate(string entity1Name, string entity1ID, string entity2Name, string entity2Ref)
        {
            string request = string.Format("https://publicapi.invenias.com/v1/{0}({1})/{2}/$ref", entity1Name, entity1ID, entity2Name, entity2Ref);

            string data = @"{""@odata.id"":""https://publicapi.invenias.com/v1/" + entity2Name + "s(" + entity2Ref + @")""}";

            HttpPost(request, data, true);

            return true;
        }

        #region HTTP call methods

        public string HttpPost(string URI, string Parameters, bool AuthHeader)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.ContentType = "application/json";
            req.Method = "POST";

            if (AuthHeader)
                req.Headers.Add("Authorization", "Bearer " + _settings.RESTAuthToken);

            // Add parameters to post
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = data.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(data, 0, data.Length);
            os.Close();

            // Do the post and get the response.
            System.Net.WebResponse response = null;

            try
            {
                response = req.GetResponse();
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();
                }
            }

            if (response == null) return null;

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }

        private string HttpGet(string URI, bool AuthHeader)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.Method = "GET";

            if (AuthHeader)
                req.Headers.Add("Authorization", "Bearer " + _settings.RESTAuthToken);

            System.Net.WebResponse response = null;
            try
            {
                response = req.GetResponse();
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();
                }
                response.Close();
                return msg;
            }

            if (response == null)
            {
                response.Close();
                return null;
            }

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }


        #endregion
    }
}
