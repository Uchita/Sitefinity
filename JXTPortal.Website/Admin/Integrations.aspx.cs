using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using JXTPortal.Entities;
using System.Web.Script.Serialization;
using JXTPortal.Entities.Models;
using JXTPortal.Common;
using JXTPortal.Client.Bullhorn;

namespace JXTPortal.Website.Admin
{
    public partial class Integrations : System.Web.UI.Page
    {
        private IntegrationsService _integrationsService;
        private IntegrationsService IntegrationsService
        {
            get
            {
                if (_integrationsService == null)
                {
                    _integrationsService = new IntegrationsService();
                }

                return _integrationsService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdminUser == null)
            {
                Response.Redirect("~/admin/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            //check if it is a redirect back from BH
            if (Request["bh"] != null)
            {
                string errorMsg = null;
                bool success = ProcessBullhornRedirect(out errorMsg);

                if(success)
                    ltlMessage.Text = "Token updated successfully";
                else
                    ltlMessage.Text = errorMsg;

                //redirect and remove the query strings
                //Response.Redirect(Request.Url.AbsolutePath);
                //return;
            }



            if (Page.IsPostBack)
            {
                AdminIntegrations.Integrations model = ProcessSettingsToModel();

                string errorMsgs = string.Empty;
                bool success = UpdateIntegrationSettings(model, out errorMsgs);

                if (success)
                    ltlMessage.Text = Common.Utils.MessageDisplayWrapper("Integration settings updated successfully", BootstrapAlertType.Success);
                else
                    ltlMessage.Text = Common.Utils.MessageDisplayWrapper(errorMsgs, BootstrapAlertType.Danger);

            }

            LoadForm();

        }

        private void LoadForm()
        {
            //get site's integrations
            List<Entities.Integrations> siteIntegrations = IntegrationsService.GetBySiteId(SessionData.Site.SiteId).ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");

            sb.Append(GenerateHTML(typeof(AdminIntegrations.Facebook), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Facebook).FirstOrDefault()));

            //sb.Append(GenerateHTML(typeof(AdminIntegrations.Twitter), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Twitter).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.Google), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Google).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.GoogleMap), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.GoogleMap).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.Indeed), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Indeed).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.Dropbox), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Dropbox).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.GoogleDrive), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.GoogleDrive).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.Seek), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Seek).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.Salesforce), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Salesforce).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.Bullhorn), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Bullhorn).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.BullhornOnBoardingSSO), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.BullhornOnBoardingSSO).FirstOrDefault()));

            sb.Append(GenerateHTML(typeof(AdminIntegrations.Invenias), siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Invenias).FirstOrDefault()));

            //Check for Bullhorns integrations
            //List<Entities.Integrations> bullhorn_integrations = siteIntegrations.Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.BullHorn).ToList();

            //if (bullhorn_integrations.Count() > 0)
            //{
            //    //print each integrations
            //}

            //sb.Append(GenerateHTMLMultiple(typeof(AdminIntegrations.Bullhorn), null, 1));
            //sb.Append(GenerateHTMLMultiple(typeof(AdminIntegrations.Bullhorn), null, 2));


            //finally append an empty bullhorn integration input
            //sb.Append(GenerateHTMLMultiple(typeof(AdminIntegrations.Bullhorn), null, 0)); //use 0 for new one



            sb.Append("</ul>");

            DynamicForm.Controls.Add(new LiteralControl(sb.ToString()));
        }

        private bool UpdateIntegrationSettings(AdminIntegrations.Integrations newValues, out string errorMsgs)
        {
            //get site's integrations
            List<Entities.Integrations> siteIntegrations = IntegrationsService.GetBySiteId(SessionData.Site.SiteId).ToList();

            errorMsgs = string.Empty;

            foreach (PropertyInfo pInfo in newValues.GetType().GetProperties())
            {
                PortalEnums.SocialMedia.SocialMediaType thisType;
                if (Enum.TryParse<PortalEnums.SocialMedia.SocialMediaType>(pInfo.Name, out thisType))
                {
                    object thisSettingObject = pInfo.GetValue(newValues, null);

                    if (thisSettingObject != null)
                    {
                        //parse into json
                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        string jsonString = ser.Serialize(thisSettingObject);

                        //Try find existing
                        Entities.Integrations thisIntegration = siteIntegrations.Where(i => (PortalEnums.SocialMedia.SocialMediaType)i.IntegrationType == thisType).FirstOrDefault();

                        bool fieldsHaveValues = AnyFieldsHaveValue(thisSettingObject);

                        //Update if exisiting found
                        if (thisIntegration != null)
                        {
                            //condition: if existing found and we are updating to nothing (ie removing), we delete the row
                            if (!fieldsHaveValues)
                            {
                                IntegrationsService.Delete(thisIntegration);
                            }
                            else
                            {
                                thisIntegration.JsonText = jsonString;

                                thisIntegration.Valid = (bool)thisSettingObject.GetType().GetProperty("Valid").GetValue(thisSettingObject, null);

                                IntegrationsService.Update(thisIntegration);
                            }
                        }
                        else //Create new one
                        {
                            //only if the any of the fields have values
                            if (fieldsHaveValues)
                            {
                                thisIntegration = new Entities.Integrations();
                                thisIntegration.IntegrationType = (int)thisType;
                                thisIntegration.JsonText = jsonString;
                                thisIntegration.SiteId = SessionData.Site.SiteId;

                                if (fieldsHaveValues)
                                    thisIntegration.Valid = (bool)thisSettingObject.GetType().GetProperty("Valid").GetValue(thisSettingObject, null);
                                else
                                    thisIntegration.Valid = false;

                                thisIntegration.CreatedDate = DateTime.Now;

                                IntegrationsService.Insert(thisIntegration);
                            }
                        }
                    }
                }
                else
                {
                    //ERROR
                    errorMsgs += "Integration settings update failed for " + pInfo.Name + "<br/>";
                }
            }
            return string.IsNullOrWhiteSpace(errorMsgs);
        }

        private AdminIntegrations.Integrations ProcessSettingsToModel()
        {
            AdminIntegrations.Integrations model = new AdminIntegrations.Integrations
            {
                Facebook = (AdminIntegrations.Facebook)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.Facebook)),
                //Twitter = (AdminIntegrations.Twitter)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.Twitter)),
                Google = (AdminIntegrations.Google)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.Google)),
                GoogleMap = (AdminIntegrations.GoogleMap)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.GoogleMap)),
                Indeed = (AdminIntegrations.Indeed)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.Indeed)),
                Seek = (AdminIntegrations.Seek)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.Seek)),
                Dropbox = (AdminIntegrations.Dropbox)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.Dropbox)),
                GoogleDrive = (AdminIntegrations.GoogleDrive)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.GoogleDrive)),
                Salesforce = (AdminIntegrations.Salesforce)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.Salesforce)),
                Bullhorn = (AdminIntegrations.Bullhorn)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.Bullhorn)),
                BullhornOnBoardingSSO = (AdminIntegrations.BullhornOnBoardingSSO)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.BullhornOnBoardingSSO)),
                Invenias = (AdminIntegrations.Invenias)ProcessSubmittedSettingsForType(typeof(AdminIntegrations.Invenias)),
            };

            return model;
        }

        //private object ProcessSubmittedSettingsForTypeMultiple(Type integrationType)
        //{
        //    for (int i = 0; ; i++)
        //    {

        //    }
        //    return null;
        //    //object obj = (object)Activator.CreateInstance(integrationType);

        //    //foreach (PropertyInfo pInfo in obj.GetType().GetProperties())
        //    //{
        //    //    string requestStr = obj.GetType().Name + "." + pInfo.Name;

        //    //    if (pInfo.PropertyType == typeof(string))
        //    //    {
        //    //        string reqValue = Request[requestStr];
        //    //        pInfo.SetValue(obj, Convert.ChangeType(reqValue, pInfo.PropertyType), null);
        //    //    }
        //    //    else if (pInfo.PropertyType == typeof(bool))
        //    //    {
        //    //        //if checkbox is checked the Request["xx"] value is "on", otherwise its null
        //    //        bool reqValue = false;
        //    //        if (Request[requestStr] != null && Request[requestStr].Equals("on"))
        //    //            reqValue = true;
        //    //        pInfo.SetValue(obj, Convert.ChangeType(reqValue, pInfo.PropertyType), null);
        //    //    }


        //    //}
        //    //return obj;
        //}

        private object ProcessSubmittedSettingsForType(Type integrationType)
        {
            object obj = (object)Activator.CreateInstance(integrationType);

            foreach (PropertyInfo pInfo in obj.GetType().GetProperties())
            {
                string requestStr = obj.GetType().Name + "." + pInfo.Name;

                if (pInfo.PropertyType == typeof(string) )
                {
                    string reqValue = Request[requestStr];
                    pInfo.SetValue(obj, Convert.ChangeType(reqValue, pInfo.PropertyType), null);
                }
                else if (pInfo.PropertyType == typeof(int))
                {
                    string reqValue = Request[requestStr];
                    int thisInt;
                    bool success = int.TryParse(reqValue, out thisInt);
                    if( success )
                        pInfo.SetValue(obj, thisInt, null);
                    else
                        pInfo.SetValue(obj, 0, null);
                }
                else if (pInfo.PropertyType == typeof(bool))
                {
                    //if checkbox is checked the Request["xx"] value is "on", otherwise its null
                    bool reqValue = false;
                    if (Request[requestStr] != null && Request[requestStr].Equals("on"))
                        reqValue = true;
                    pInfo.SetValue(obj, Convert.ChangeType(reqValue, pInfo.PropertyType), null);
                }


            }
            return obj;
        }

        private bool AnyFieldsHaveValue(object integrationObj)
        {
            bool anyHasValues = false;
            foreach (PropertyInfo pInfo in integrationObj.GetType().GetProperties())
            {
                string requestStr = integrationObj.GetType().Name + "." + pInfo.Name;

                if (pInfo.PropertyType == typeof(string))
                {
                    string reqValue = Request[requestStr];
                    if (!string.IsNullOrEmpty(reqValue))
                    {
                        anyHasValues = true;
                        break;
                    }
                }
            }
            return anyHasValues;
        }

        private string GenerateHTML(Type integrationType, Entities.Integrations model)
        {
            //Generate properties dynamically
            object obj = (object)Activator.CreateInstance(integrationType);
            Dictionary<string, object> existingIntegrationData = null;

            //process existing integration data
            if (model != null)
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                existingIntegrationData = (Dictionary<string, object>)ser.Deserialize(model.JsonText, typeof(object));
            }

            StringBuilder sb = new StringBuilder();

            DescriptionAttribute classAttr = obj.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

            //Generate Title
            sb.Append(@"<li><h3>" + (classAttr != null ? classAttr.Description : obj.GetType().Name) + "</h3></li>");

            foreach (PropertyInfo pInfo in obj.GetType().GetProperties())
            {
                //get description attribute
                DescriptionAttribute descAttr = pInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
                //get ReadOnly attribute
                ReadOnlyAttribute readonlyAttr = pInfo.GetCustomAttributes(typeof(ReadOnlyAttribute), false).FirstOrDefault() as ReadOnlyAttribute;
                //button attribute
                IncludeButtonAttribute includeBtnAttr = pInfo.GetCustomAttributes(typeof(IncludeButtonAttribute), false).FirstOrDefault() as IncludeButtonAttribute;

                //process readonly attribute
                string readonlyText = string.Empty;
                if (readonlyAttr != null && readonlyAttr.IsReadOnly)
                    readonlyText = "readonly";

                //string properties
                if (pInfo.PropertyType == typeof(string) || pInfo.PropertyType == typeof(int))
                {
                    sb.Append(@"<li class=""form-line"">");
                    sb.Append(@"<label class=""form-label-left"">" + (descAttr != null ? descAttr.Description : pInfo.Name) + @"</label>");

                    sb.Append(@"<div class=""form-input"">");

                    string tbID = obj.GetType().Name + "." + pInfo.Name;

                    //find existing data value
                    string dataValue = string.Empty;
                    if (existingIntegrationData != null && existingIntegrationData.Keys.Contains(pInfo.Name))
                    {
                        if (existingIntegrationData[pInfo.Name] == null)
                            dataValue = string.Empty;
                        else
                            dataValue = existingIntegrationData[pInfo.Name].ToString();
                    }
                    sb.Append(@"<input type=""text"" ID=""" + tbID + @""" name=""" + tbID + @""" TextMode=""SingleLine"" style=""width:500px"" value=""" + dataValue + @""" autocomplete=""off"" " + readonlyText + "/>");

                    if (includeBtnAttr != null)
                    {
                        sb.Append(String.Format(@"<div><input type=""button"" runat=""server"" class=""{0}"" onclick=""{1}"" value=""{2}"" /></div>", includeBtnAttr.CssClass, includeBtnAttr.ButtonOnClick, includeBtnAttr.ButtonText));
                    }

                    sb.Append(@"</div>");
                }
                else if (pInfo.PropertyType == typeof(bool))
                {
                    sb.Append(@"<li class=""form-line"">");
                    sb.Append(@"<label class=""form-label-left"">" + (descAttr != null ? descAttr.Description : pInfo.Name) + @"</label>");

                    sb.Append(@"<div class=""form-input"">");

                    string tbID = obj.GetType().Name + "." + pInfo.Name;

                    string checkedValue;
                        
                    //check if the property is the Valid flag 
                    if( pInfo.Name == "Valid" )
                        checkedValue = model != null && model.Valid ? @"checked=""checked""" : string.Empty;
                    else
                    {
                        bool thisValue = false;
                        //otherwise here is other bool types values
                        if (existingIntegrationData != null && existingIntegrationData.Keys.Contains(pInfo.Name))
                        {
                            thisValue = bool.Parse(existingIntegrationData[pInfo.Name].ToString());
                        }
                        checkedValue = thisValue ? @"checked=""checked""" : string.Empty;
                    }
                    sb.Append(@"<input type=""checkbox"" ID=""" + tbID + @""" name=""" + tbID + @""" " + checkedValue + @" autocomplete=""off"" " + readonlyText + "/>");

                    if (includeBtnAttr != null)
                    {
                        sb.Append(String.Format(@"<div><input type=""button"" runat=""server"" class=""{0}"" onclick=""{1}"" value=""{2}"" /></div>", includeBtnAttr.CssClass, includeBtnAttr.ButtonOnClick, includeBtnAttr.ButtonText));
                    }

                    sb.Append(@"</div>");
                }

                sb.Append(@"</li>");
            }

            //Extra for BH integration
            if (integrationType == typeof(AdminIntegrations.Bullhorn))
            {
                if (existingIntegrationData != null && existingIntegrationData.Keys.Contains("EnableAdvertiserSync"))
                {
                    bool bhAdvertiserSyncEnabled = (bool)existingIntegrationData["EnableAdvertiserSync"];

                    if (bhAdvertiserSyncEnabled)
                    {
                        sb.Append(@"<li class=""form-line""><label class=""form-label-left"">Integration Mappings</label><div class=""form-input""><a href=""/admin/bullhorn/advertisersmapping.aspx"">Bullhorn Advertiser/AdvertiserUser Mapping</a></div></li>");
                    }

                }
            }

            return sb.ToString();
        }

        private string GenerateHTMLMultiple(Type integrationType, Entities.Integrations model, int integer_identifier)
        {
            //Generate properties dynamically
            object obj = (object)Activator.CreateInstance(integrationType);
            Dictionary<string, object> existingIntegrationData = null;

            //process existing integration data
            if (model != null)
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                existingIntegrationData = (Dictionary<string, object>)ser.Deserialize(model.JsonText, typeof(object));
            }

            StringBuilder sb = new StringBuilder();

            DescriptionAttribute classAttr = obj.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

            //Generate Title
            sb.Append(@"<li><h3>" + (classAttr != null ? classAttr.Description : obj.GetType().Name) + "</h3></li>");

            foreach (PropertyInfo pInfo in obj.GetType().GetProperties())
            {
                //get description attribute
                DescriptionAttribute descAttr = pInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

                //string properties
                if (pInfo.PropertyType == typeof(string))
                {
                    sb.Append(@"<li class=""form-line"">");
                    sb.Append(@"<label class=""form-label-left"">" + (descAttr != null ? descAttr.Description : pInfo.Name) + @"</label>");

                    sb.Append(@"<div class=""form-input"">");

                    string tbID = obj.GetType().Name + "." + pInfo.Name;

                    //find existing data value
                    string dataValue = string.Empty;
                    if (existingIntegrationData != null && existingIntegrationData.Keys.Contains(pInfo.Name))
                    {
                        dataValue = existingIntegrationData[pInfo.Name].ToString();
                    }
                    sb.Append(@"<input type=""text"" ID=""" + tbID + "_" + integer_identifier + @""" name=""" + tbID + "_" + integer_identifier + @""" TextMode=""SingleLine"" style=""width:500px"" value=""" + dataValue + @""" autocomplete=""off""/>");

                    sb.Append(@"</div>");
                }
                else if (pInfo.PropertyType == typeof(bool))
                {
                    sb.Append(@"<li class=""form-line"">");
                    sb.Append(@"<label class=""form-label-left"">" + (descAttr != null ? descAttr.Description : pInfo.Name) + @"</label>");

                    sb.Append(@"<div class=""form-input"">");

                    string tbID = obj.GetType().Name + "." + pInfo.Name;

                    string checkedValue = model != null && model.Valid ? @"checked=""checked""" : string.Empty;

                    sb.Append(@"<input type=""checkbox"" ID=""" + tbID + "_" + integer_identifier + @""" name=""" + tbID + "_" + integer_identifier + @""" " + checkedValue + @" autocomplete=""off"" />");

                    sb.Append(@"</div>");
                }

                sb.Append(@"</li>");
            }
            return sb.ToString();
        }

        #region BullHorn Speicific

        private AdminIntegrations.Bullhorn BullhornIntegrationsGet()
        {
            //get site's integrations
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            return integrations.Bullhorn;
        }

        private bool ProcessBullhornRedirect(out string errorMsg)
        {
            string bhCode = Request["code"];
            string bhError = Request["error"];
            string bhErrorDesc = Request["error_description"];

            if (string.IsNullOrEmpty(bhCode))
            {
                errorMsg = "Authentication failed. No authorization code detected.";
                return false;
            }

            AdminIntegrations.Bullhorn bullhornSettings = BullhornIntegrationsGet();

            if (bullhornSettings == null 
                || string.IsNullOrEmpty(bullhornSettings.ClientKey)
                || string.IsNullOrEmpty(bullhornSettings.ClientSecret)
                || string.IsNullOrEmpty(bullhornSettings.ClientUsername)
                || string.IsNullOrEmpty(bullhornSettings.ClientPassword)                
                )
            {
                errorMsg = "Incomplete Bullhorn settings: Client Key, Client Secret, Login Username and Login Password is required";
                return false;
            }

            // Consumer Key + Secret from SFDC account
            string clientKey = bullhornSettings.ClientKey;
            string clientSecret = bullhornSettings.ClientSecret;

            // Consumer logins
            string clientUsername = bullhornSettings.ClientUsername;
            string clientPassword = bullhornSettings.ClientPassword;

            // Redirect URL configured in SFDC account
            HttpRequest currentReq = HttpContext.Current.Request;
            string hostName = currentReq.IsLocal ? currentReq.Url.Authority : currentReq.Url.Host;
            string redirectURL = String.Format("{0}://{1}/{2}", (currentReq.IsSecureConnection ? "https" : "http"), hostName, "admin/integrations.aspx?bh=1");

            BullhornRESTAPI bhapi = new BullhornRESTAPI(clientKey, clientSecret, redirectURL, clientUsername, clientPassword, !bullhornSettings.isLive);

            string jsonToken = null;
            bool tokenGetSuccess = bhapi.GetTokenWithAuthorizeCode(bhCode, out jsonToken);

            if (tokenGetSuccess == false)
            {
                errorMsg = "Failed to exchange code to token";
                return false;
            }

            JavaScriptSerializer ser = new JavaScriptSerializer();
            JXTPortal.Client.Bullhorn.BullhornRESTAPI.AuthorizeToken thisToken = ser.Deserialize<JXTPortal.Client.Bullhorn.BullhornRESTAPI.AuthorizeToken>(jsonToken);

            bool tokenUpdate = IntegrationsService.BullhornRESTTokenUpdate(SessionData.Site.SiteId, thisToken.access_token, thisToken.refresh_token);

            if (tokenUpdate == false)
            {
                errorMsg = "Failed to update token details";
                return false;
            }

            errorMsg = null;
            return true;
        }

        [System.Web.Services.WebMethod]
        public static object BullhornTokenResetURLGet()
        {
            //get site's integrations
            IntegrationsService iService = new IntegrationsService();
            AdminIntegrations.Integrations integrations = iService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            //dump
            iService = null;

            AdminIntegrations.Bullhorn bullhornSettings = integrations.Bullhorn;

            if (bullhornSettings == null 
                || string.IsNullOrEmpty(bullhornSettings.ClientKey)
                || string.IsNullOrEmpty(bullhornSettings.ClientSecret)
                || string.IsNullOrEmpty(bullhornSettings.ClientUsername)
                || string.IsNullOrEmpty(bullhornSettings.ClientPassword)                
                )
            {
                return new { Success = false, Message = "Incomplete Bullhorn settings: Client Key, Client Secret, Login Username and Login Password is required. You may need to save your existing details before resetting the tokens." }; 
            }
            // Consumer Key, Secret from SFDC account
            string clientKey = bullhornSettings.ClientKey;
            string clientSecret = bullhornSettings.ClientSecret;

            // Consumer logins
            string clientUsername = bullhornSettings.ClientUsername;
            string clientPassword = bullhornSettings.ClientPassword;

            // Redirect URL configured in SFDC account
            HttpRequest currentReq = HttpContext.Current.Request;

            string hostName = currentReq.IsLocal ? currentReq.Url.Authority : currentReq.Url.Host;
            string redirectURL = String.Format("{0}://{1}/{2}", (currentReq.IsSecureConnection ? "https" : "http"), hostName, "admin/integrations.aspx?bh=1");

            //Live logins
            //======================
            //clientUsername = "JXTAPI";
            //clientPassword = "301_perth";

            BullhornRESTAPI bhapi = new BullhornRESTAPI(clientKey, clientSecret, redirectURL, clientUsername, clientPassword, !bullhornSettings.isLive);

            string BHAuthorizeURL = bhapi.GetAuthorizeUrl();

            return new { Success = true, BHURL = BHAuthorizeURL }; 

        }


        #endregion
    }




}