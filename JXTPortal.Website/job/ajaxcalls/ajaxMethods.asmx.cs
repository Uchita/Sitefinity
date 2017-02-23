using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Web.Script.Services;
using JXTPortal.Entities;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using JXTPortal.JobApplications.PeopleProfile;
using System.Configuration;
using JXTPortal.Common;
using log4net;

namespace JXTPortal.Website.job.ajaxcalls
{
    /// <summary>
    /// Summary description for ajaxMethods
    /// </summary>
    [WebService(Namespace = "http://www.jobx.com.au/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ajaxMethods : System.Web.Services.WebService
    {
        ILog _logger;

        public ajaxMethods()
        {
            _logger = LogManager.GetLogger(typeof(ajaxMethods));
        }
        #region Properties

        private SiteRolesService _siteRolesService;
        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siteRolesService == null)
                    _siteRolesService = new SiteRolesService();
                return _siteRolesService;
            }
        }
        private ViewJobSearchService _viewJobSearchService = null;

        public ViewJobSearchService ViewJobSearchService
        {

            get
            {
                if (_viewJobSearchService == null)
                {
                    _viewJobSearchService = new ViewJobSearchService();
                }
                return _viewJobSearchService;
            }
        }

        private AdvertisersService _advertisersService = null;

        public AdvertisersService AdvertisersService
        {

            get
            {
                if (_advertisersService == null)
                {
                    _advertisersService = new AdvertisersService();
                }
                return _advertisersService;
            }
        }

        #endregion

        [WebMethod]
        public string GetDate()
        {
            System.Threading.Thread.Sleep(2000);
            return DateTime.Now.ToString();
        }

        #region Advanced Search

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public string GetRoles(string ProfessionId, string IsDynamicWidget = "")
        {
            int intProfessionId;
            if (int.TryParse(ProfessionId, out intProfessionId) && intProfessionId > 0)
            {

                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<div id='divRoleID{1}'><select class='form-dropdown' id=\"{0}{1}\">", "roleIDs", IsDynamicWidget);
                SiteRolesService siteRolesService = new SiteRolesService();
                List<Entities.SiteRoles> siteRolesList = siteRolesService.GetTranslatedByProfessionID(intProfessionId, SessionData.Site.UseCustomProfessionRole);

                if (siteRolesList != null && siteRolesList.Count > 0)
                {

                    //IEnumerable<Entities.SiteRoles> srs = siteRolesList.Where(s => s.TotalJobs > 0);
                    //strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>- All SubClassifications -</option>");
                    strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>" + CommonFunction.GetResourceValue("LabelAllSubClassifications") + "</option>");

                    foreach (Entities.SiteRoles siteRole in siteRolesList.OrderBy(s => s.SiteRoleName))
                    {
                        if (siteRole.SiteRoleName == "")
                        {
                            strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED>{1}</option>", siteRole.RoleId.ToString(), siteRole.SiteRoleName);
                        }
                        else
                        {
                            strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", siteRole.RoleId.ToString(), siteRole.SiteRoleName);
                        }
                    }
                    strSelectHtml.Append("</select></div>");

                }

                return strSelectHtml.ToString();
            }


            //return @"<div id='divRoleID'><select class='form-dropdown' id='roleIDs'><option value='-1'>- Select a Classification First -</option></select></div>";
            return @"<div id='divRoleID" + IsDynamicWidget + "'><select class='form-dropdown' id='roleIDs" + IsDynamicWidget + "'><option value='-1'>" + CommonFunction.GetResourceValue("LabelSelectClassificationFirst") + "</option></select></div>";
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public object GetRolesJson(string ProfessionId)
        {
            int intProfessionId;
            List<GenericClass> GenericClassList = new List<GenericClass>();

            if (int.TryParse(ProfessionId, out intProfessionId) && intProfessionId > 0)
            {
                SiteRolesService siteRolesService = new SiteRolesService();
                List<Entities.SiteRoles> siteRolesList = siteRolesService.GetTranslatedByProfessionID(intProfessionId, SessionData.Site.UseCustomProfessionRole);

                GenericClassList = (from s in siteRolesList select new GenericClass { ID = s.RoleId, Value = s.SiteRoleName }).ToList<GenericClass>();
            }

            GenericClassList.Insert(0, new GenericClass(-1, CommonFunction.GetResourceValue("LabelAllSubClassifications")));

            return GenericClassList;
        }

        [WebMethod(EnableSession = true)]

        public string GetLocations(string DefaultLocationID, [Optional] string IsDynamicWidget, [Optional] string CountryID)
        {
            StringBuilder strSelectHtml = new StringBuilder();
            strSelectHtml.AppendFormat("<div id='divLocation{1}'><select class='form-dropdown' id=\"{0}{1}\">", "locationID", IsDynamicWidget);
            SiteCountriesService siteCountriesService = new SiteCountriesService();
            SiteLocationService siteLocationService = new SiteLocationService();
            List<Entities.SiteCountries> siteCountriesList = siteCountriesService.GetTranslatedCountries();
            if (CountryID != "-1")
            {
                siteCountriesList = siteCountriesList.Where(x => x.CountryId == Convert.ToInt32(CountryID)).ToList();
            }

            strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED data-placeholdertag=''>" + CommonFunction.GetResourceValue("LabelAllLocation") + "</option>");

            foreach (Entities.SiteCountries siteCountries in siteCountriesList)
            {
                strSelectHtml.AppendFormat("<optgroup label=\"{0}\">", HttpUtility.HtmlEncode(siteCountries.SiteCountryName));
                List<Entities.SiteLocation> filteredList = siteLocationService.GetTranslatedLocationsByCountryID(siteCountries.CountryId);

                foreach (Entities.SiteLocation siteLocation in filteredList)
                {
                    if (!String.IsNullOrEmpty(DefaultLocationID) && siteLocation.LocationId.ToString() == DefaultLocationID)
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED data-placeholdertag='{2}'>{1}</option>", siteLocation.LocationId.ToString(), siteLocation.SiteLocationName, siteCountries.Currency);
                    }
                    else
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" data-placeholdertag='{2}'>{1}</option>", siteLocation.LocationId.ToString(), siteLocation.SiteLocationName, siteCountries.Currency);
                    }
                }
            }

            strSelectHtml.Append(@"</select></div>
<script>
    $('#locationID" + IsDynamicWidget + @"').change(function() {
        
        $('.divSalaryCurrency" + IsDynamicWidget + @"').html($('#locationID" + IsDynamicWidget + @" option:selected').data('placeholdertag') + ' ');
        var blnLocationSelected = ($('#locationID" + IsDynamicWidget + @" option:selected').val() > 0);

        if ($('#hfCountryCount').val() != '1') {
            $('#salaryID" + IsDynamicWidget + @"').prop('disabled', blnLocationSelected);
            $('#salarylowerband" + IsDynamicWidget + @"').prop('disabled', blnLocationSelected);
            $('#salaryupperband" + IsDynamicWidget + @"').prop('disabled', blnLocationSelected);
        }	
        else
        {
            $('#salaryID" + IsDynamicWidget + @"').removeProp('disabled');
            $('#salarylowerband" + IsDynamicWidget + @"').removeProp('disabled');
            $('#salaryupperband" + IsDynamicWidget + @"').removeProp('disabled');
        }

        $('#divArea" + IsDynamicWidget + @"').html(""<img src='/images/loading.gif' alt='loading' />"");
        $('#divAreaDropDown" + IsDynamicWidget + @"').html(""<img src='/images/loading.gif' alt='loading' />"");

        var locationID = '';
        $('#locationID" + IsDynamicWidget + @" option:selected').each(function() {
            locationID += $(this).val();
        });


        $.ajax({
            type: 'POST',
            cache: false,
            url: '/job/ajaxcalls/ajaxmethods.asmx/GetAreas',
            data: ""{'LocationId':"" + locationID + "", IsDynamicWidget: '" + IsDynamicWidget + @"'}"",
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function(msg) {
                // Replace the div's content with the page method's return.
                $(""#divArea" + IsDynamicWidget + @""").html(msg.d);
            },
            fail: function() {
                // Replace the div's content with the page method's return.
                $(""#divArea" + IsDynamicWidget + @""").html(""It didn't work"");
            }
        });

        $.ajax({
            type: 'POST',
            cache: false,
            url: '/job/ajaxcalls/ajaxmethods.asmx/GetAreasDropDown',
            data: ""{'LocationId':"" + locationID + "", IsDynamicWidget: '" + IsDynamicWidget + @"'}"",
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function(msg) {
                // Replace the div's content with the page method's return.
                $(""#divAreaDropDown" + IsDynamicWidget + @""").html(msg.d);
            },
            fail: function() {
                // Replace the div's content with the page method's return.
                $(""#divAreaDropDown" + IsDynamicWidget + @""").html(""It didn't work"");
            }
        });

    });


    $('#locationID" + IsDynamicWidget + @"').change();
</script>");

            return strSelectHtml.ToString();
        }


        [WebMethod(EnableSession = true)]
        public string GetAreas(string LocationId, [Optional] string IsDynamicWidget)
        {

            int intLocationId;
            if (int.TryParse(LocationId, out intLocationId) && intLocationId > 0)
            {

                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<div id='divArea{1}'><select class='form-dropdown' id=\"{0}{1}\" multiple='multiple' size='4'>", "areaIDs", IsDynamicWidget);
                SiteAreaService siteAreaService = new SiteAreaService();
                List<Entities.SiteArea> siteAreaList = siteAreaService.GetTranslatedAreas(intLocationId); //intAreaId

                //strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>- All Areas -</option>");
                strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>" + CommonFunction.GetResourceValue("LabelAllArea") + "</option>");

                foreach (Entities.SiteArea siteArea in siteAreaList)
                {
                    if (siteArea.SiteAreaName == "")
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED>{1}</option>", siteArea.AreaId.ToString(), siteArea.SiteAreaName);
                    }
                    else
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", siteArea.AreaId.ToString(), siteArea.SiteAreaName);
                    }
                }
                strSelectHtml.Append("</select></div>");

                return strSelectHtml.ToString();
            }

            //return @"<div id='divArea'><select class='form-dropdown' id='areaIDs' multiple='multiple' size='4'><option value='-1'>- Select a Location First -</option></select></div>";
            return @"<div id='divArea" + IsDynamicWidget + "'><select class='form-dropdown' id='areaIDs" + IsDynamicWidget + "' multiple='multiple' size='4'><option value='-1'>" + CommonFunction.GetResourceValue("LabelSelectLocationFirst") + "</option></select></div>";
        }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public object GetAreasJson(string LocationId)
        {
            int intLocationId;
            if (int.TryParse(LocationId, out intLocationId) && intLocationId > 0)
            {
                SiteAreaService siteAreaService = new SiteAreaService();
                List<Entities.SiteArea> siteAreaList = siteAreaService.GetTranslatedAreas(intLocationId); //intAreaId

                List<GenericClass> GenericClassList = (from s in siteAreaList select new GenericClass { ID = s.AreaId, Value = s.SiteAreaName }).ToList<GenericClass>();

                GenericClassList.Insert(0, new GenericClass(-1, CommonFunction.GetResourceValue("LabelAllArea")));

                return GenericClassList;
            }

            return string.Empty;
        }

        /*
        [WebMethod(EnableSession = true)]
        public string GetSalaryRangeFrom(int salaryTypeid, string SalaryValueSet, string IsDynamicWidget = "")
        {
            string[] valueset = SalaryValueSet.Split(';');
            int currencyId = Convert.ToInt32(valueset[0]);
            decimal amount = Convert.ToDecimal(valueset[1]);

            StringBuilder strSelectHtml = new StringBuilder();
            strSelectHtml.AppendFormat("<select class='form-dropdown' id=\"{0}\" onchange=\"SalaryFromChange();\">", "salarylowerband" + IsDynamicWidget);
            ViewSalaryService viewSalaryService = new ViewSalaryService();
            VList<ViewSalary> salaryFromList = viewSalaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, salaryTypeid);

            foreach (ViewSalary salary in salaryFromList)
            {
                strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", string.Format("{0};{1}", salary.CurrencyId, salary.Amount), salary.SalaryDisplay);
            }

            strSelectHtml.Append("</select>");
            viewSalaryService = null;
            return strSelectHtml.ToString();

        }

        [WebMethod(EnableSession = true)]
        public string GetSalaryRangeTo(int salaryTypeid, string SalaryValueSet, string IsDynamicWidget = "")
        {
            string[] valueset = SalaryValueSet.Split(';');
            int currencyId = Convert.ToInt32(valueset[0]);
            decimal amount = Convert.ToDecimal(valueset[1]);

            StringBuilder strSelectHtml = new StringBuilder();
            strSelectHtml.AppendFormat("<select class='form-dropdown' id=\"{0}\">", "salaryupperband" + IsDynamicWidget);
            ViewSalaryService viewSalaryService = new ViewSalaryService();
            VList<ViewSalary> salaryToList = viewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, currencyId, salaryTypeid, amount);
            int count = salaryToList.Count;
            int i = 0;

            foreach (ViewSalary salary in salaryToList)
            {
                string strSelected = string.Empty;
                if (i == count - 1)
                {
                    strSelected = " selected";
                }

                strSelectHtml.AppendFormat("<option value=\"{0}\"{2}>{1}</option>", string.Format("{0};{1}", salary.CurrencyId, salary.Amount), salary.SalaryDisplay, strSelected);
                i++;
            }

            strSelectHtml.Append("</select>");
            viewSalaryService = null;
            return strSelectHtml.ToString();

        }*/

        [WebMethod(EnableSession = true)]
        public string GetAreasDropDown(string LocationId, [Optional] string IsDynamicWidget)
        {

            int intLocationId;
            if (int.TryParse(LocationId, out intLocationId) && intLocationId > 0)
            {

                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<div id='divAreaDropDown{1}'><select class='form-dropdown' id=\"{0}{1}\">", "areaIDs", IsDynamicWidget);
                SiteAreaService siteAreaService = new SiteAreaService();
                List<Entities.SiteArea> siteAreaList = siteAreaService.GetTranslatedAreas(intLocationId); //intAreaId

                //strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>- All Areas -</option>");
                strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>" + CommonFunction.GetResourceValue("LabelAllArea") + "</option>");

                foreach (Entities.SiteArea siteArea in siteAreaList)
                {
                    if (siteArea.SiteAreaName == "")
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED>{1}</option>", siteArea.AreaId.ToString(), siteArea.SiteAreaName);
                    }
                    else
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", siteArea.AreaId.ToString(), siteArea.SiteAreaName);
                    }
                }
                strSelectHtml.Append("</select></div>");

                return strSelectHtml.ToString();
            }

            //return @"<div id='divArea'><select class='form-dropdown' id='areaIDs' multiple='multiple' size='4'><option value='-1'>- Select a Location First -</option></select></div>";
            return @"<div id='divAreaDropDown" + IsDynamicWidget + "'><select class='form-dropdown' id='areaIDs" + IsDynamicWidget + "'><option value='-1'>" + CommonFunction.GetResourceValue("LabelSelectLocationFirst") + "</option></select></div>";
        }

        #endregion

        #region Member Methods - Save Job

        [WebMethod(EnableSession = true)]
        public object SaveJobForMember(string JobID)
        {

            // Only when User is logged in 
            if (Entities.SessionData.Member != null)
            {
                //System.Threading.Thread.Sleep(3000);
                int intJobID;
                if (int.TryParse(JobID, out intJobID) && intJobID > 0)
                {
                    JobsSavedService JobsSavedService = new JobsSavedService();

                    String strAction = String.Empty;
                    String strMessage = String.Empty;

                    // Delete the job if already saved.
                    Boolean blnResult = JobsSavedService.SavedJobForMember(intJobID, true, ref strAction);

                    switch (strAction)
                    {
                        case "Saved":
                            strMessage = CommonFunction.GetResourceValue("LabelJobSaved");
                            break;
                        case "Deleted":
                            strMessage = CommonFunction.GetResourceValue("LinkButtonSaveJob");
                            break;
                        default:
                            break;
                    }

                    return new { Success = true, Action = strAction, Message = strMessage };

                    //return strMessage;
                }
            }
            else
            {
                return new { Success = false, Action = "Login", Message = string.Empty };
                //return "Login"; //CommonFunction.GetResourceValue("LabelNeedLogin")
            }


            return string.Empty;
        }

        [WebMethod(EnableSession = true)]
        public string IsMemberLoggedIn()
        {
            return (SessionData.Member == null) ? "false" : "true";
        }

        [WebMethod(EnableSession = true)]
        public string SaveJobAlert(string CreateAlertName, string SearchString, bool isJobAlert)
        {
            // Only when User is logged in 
            if (Entities.SessionData.Member != null)
            {
                try
                {
                    JobAlertsService jobalertservice = new JobAlertsService();
                    Entities.JobAlerts jobalert = new JobAlerts();
                    jobalert.AlertActive = isJobAlert;
                    jobalert.JobAlertName = CreateAlertName;
                    jobalert.LastModified = DateTime.Now;
                    jobalert.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                    jobalert.MemberId = SessionData.Member.MemberId;
                    jobalert.PrimaryAlert = false;
                    jobalert.SiteId = SessionData.Site.SiteId;

                    if (!string.IsNullOrEmpty(SearchString))
                    {
                        string[] filter = SearchString.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string line in filter)
                        {
                            string[] seg = line.Split(new char[] { '^' });
                            string commandname = seg[0];
                            string id = seg[1];
                            string text = seg[2];

                            switch (commandname)
                            {
                                case "-1":
                                    {
                                        // Remove Keywords
                                        jobalert.SearchKeywords = text;
                                    }
                                    break;
                                case "0":
                                    {
                                        // Remove Profession
                                        jobalert.ProfessionId = id;
                                    }
                                    break;
                                case "1":
                                    {
                                        // Remove Roles
                                        jobalert.SearchRoleIds = id;
                                    }
                                    break;
                                case "2":
                                    {
                                        // Remove Location
                                        jobalert.LocationId = id;
                                    }
                                    break;
                                case "3":
                                    {
                                        // Remove Area
                                        jobalert.AreaIds = id;
                                    }
                                    break;
                                case "4":
                                    {
                                        // Remove Work type
                                        jobalert.WorkTypeIds = id;
                                    }
                                    break;
                                case "6":
                                    {
                                        Regex digitsOnly = new Regex(@"[^\d\.]");

                                        jobalert.SalaryTypeId = Convert.ToInt32(id);
                                        if (text.Contains("From"))
                                        {
                                            string[] nums = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                            jobalert.SalaryLowerBand = Convert.ToDecimal(digitsOnly.Replace(nums[4].Trim(), ""));
                                        }
                                        else if (text.Contains('-'))
                                        {
                                            string[] nums = text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                                            jobalert.SalaryLowerBand = Convert.ToDecimal(digitsOnly.Replace(nums[1].Trim(), ""));
                                            jobalert.SalaryUpperBand = Convert.ToDecimal(digitsOnly.Replace(nums[2].Trim(), ""));
                                        }
                                        else if (text.StartsWith("To"))
                                        {
                                            string[] nums = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                            jobalert.SalaryUpperBand = Convert.ToDecimal(digitsOnly.Replace(nums[2].Trim(), ""));
                                        }
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                    jobalertservice.Insert(jobalert);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.GetBaseException());
                    return "Error";
                }
            }
            else
            {
                return "NeedLogin";
            }


            return "Success";
        }

        #endregion

        #region Search Results Google Map

        //[WebMethod(EnableSession = true)]
        //public object GoogleMapCenterPointGet(string searchAddress)
        //{
        //    //retrieve address input
        //    var geoData = RetrieveFormatedAddress(searchAddress, "AIzaSyBPUNy8Yc-hHd-gJg7C4mFfft4ek3PYBYU");

        //    return new { Success = true, GeoData = geoData };
        //}

        [WebMethod(EnableSession = true)]
        public object JobsForGoogleMapGet(string CampaignName, System.Double? northEastLat, System.Double? northEastLng, System.Double? southWestLat, System.Double? southWestLng)
        {

            if (!string.IsNullOrWhiteSpace(CampaignName))
            {
                if (!String.IsNullOrEmpty(CampaignName))
                {
                    // Change the language which comes from session.
                    DynamicPagesService DynamicPagesService = new JXTPortal.DynamicPagesService();

                    using (JXTPortal.Entities.DynamicPages dynamicPage = DynamicPagesService.GetBySiteIdLanguageIdPageFriendlyName(SessionData.Site.SiteId, SessionData.Language.LanguageId, CampaignName))
                    {
                        if (dynamicPage != null && dynamicPage.Valid)
                            CampaignName = dynamicPage.PageTitle;   // Page title has the campaign keywords                            
                        else
                            CampaignName = string.Empty;
                    }
                }
            }

            string kw = string.Empty;

            // Check the keywords or if there is a campaign
            EasyFts fts = new EasyFts();
            if (!String.IsNullOrEmpty(CampaignName))
                kw = fts.ToFtsQuery(CampaignName);
            if (!String.IsNullOrEmpty(SessionData.JobSearch.Keywords))
                kw = fts.ToFtsQuery(SessionData.JobSearch.Keywords);

            List<object> returnResults = new List<object>();
            // STANDARD / STAND OUT JOBS
            using (VList<ViewJobSearch> viewJobSearch = ViewJobSearchService.GetBySearchFilterGoogleMap(
                                                    kw,
                                                    SessionData.Site.SiteId, SessionData.JobSearch.AdvertiserID,
                                                    SessionData.JobSearch.CurrencyID, SessionData.JobSearch.SalaryLowerBand, SessionData.JobSearch.SalaryUpperBand,
                                                    SessionData.JobSearch.SalaryTypeID, SessionData.JobSearch.WorkTypeID,
                                                    !string.IsNullOrWhiteSpace(SessionData.JobSearch.ProfessionID) ? Convert.ToInt32(SessionData.JobSearch.ProfessionID) : (int?)null,
                                                    SessionData.JobSearch.RoleIDs,
                                                    SessionData.JobSearch.CountryID,
                                                    !string.IsNullOrWhiteSpace(SessionData.JobSearch.LocationID) ? Convert.ToInt32(SessionData.JobSearch.LocationID) : (int?)null,
                                                    SessionData.JobSearch.AreaIDs,
                                                    null,
                                                    null,
                                                    northEastLat,
                                                    northEastLng,
                                                    southWestLat,
                                                    southWestLng))
            {
                foreach (ViewJobSearch s in viewJobSearch)
                {
                    string logourl = string.Empty;
                    if (s.HasAdvertiserLogo == 1)
                        logourl = String.Format(@"/getfile.aspx?advertiserid={0}", s.AdvertiserId.Value);
                    if (s.HasAdvertiserLogo == 2)
                    {
                        using (Entities.Advertisers adv = AdvertisersService.GetByAdvertiserId(s.AdvertiserId.Value))
                            logourl = String.Format(@"/media/{0}/{1}", ConfigurationManager.AppSettings["AdvertisersFolder"], adv.AdvertiserLogoUrl);
                    }
                   
                    var thisJob = 
                        new { 
                            jobLink = Utils.GetJobUrl(s.JobId, s.JobFriendlyName),
                            jobName = s.JobName,
                            //companyName = s.CompanyName,
                            advertiserName = s.AdvertiserName,
                            hasAdvertiserLogo = s.HasAdvertiserLogo > 0,
                            advertiserLogo = logourl,
                            salaryShow = s.ShowSalaryRange,
                            salaryFrom = s.ShowSalaryRange ? s.SalaryLowerBand : 0,
                            salaryTo = s.ShowSalaryRange ? s.SalaryUpperBand : 0,
                            currencySymbol = s.CurrencySymbol,
                            salaryDisplayName = s.SalaryTypeName,
                            position = s.SiteProfessionName + " > " + s.SiteRoleName ,
                            lat = s.JobLatitude, 
                            lng = s.JobLongitude };
                    returnResults.Add(thisJob);
                }
            }

            return new { Success = true, Data = returnResults };
        }

        private object RetrieveFormatedAddress(string address, string googleSecret)
        {
            if (string.IsNullOrWhiteSpace(address))
                return null;

            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key={1}&sensor=false", address, googleSecret);

            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                string strGeoXML = wc.DownloadString(requestUri);

                /*wc.DownloadStringCompleted +=
                  new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                wc.DownloadStringAsync(new Uri(requestUri));*/

                var doc = new System.Xml.XmlDocument();
                doc.LoadXml(strGeoXML);

                var xmlElm = System.Xml.Linq.XElement.Parse(strGeoXML);


                // Check status
                System.Xml.XmlNode status = doc.SelectSingleNode("/GeocodeResponse/status");
                if (status != null && status.InnerText == "OK")           //ZERO_RESULTS - address not found
                {
                        // Get location details
                        System.Xml.XmlNodeList GeoResponseList = doc.SelectNodes("/GeocodeResponse/result");

                        if (GeoResponseList != null && GeoResponseList.Count > 0)
                        {
                            var geoData = new
                            {
                                lat = GeoResponseList[0].SelectSingleNode("geometry/location/lat").InnerText,
                                lng = GeoResponseList[0].SelectSingleNode("geometry/location/lng").InnerText
                            };
                            return geoData;
                        }
                }
            }
            return null;
        }

        private int GetLocationScore(string location_type)
        {
            switch (location_type)
            {
                case "ROOFTOP":
                    return 9;
                case "RANGE_INTERPOLATED":
                    return 7;

                case "GEOMETRIC_CENTER":
                    return 6;

                case "APPROXIMATE":
                    return 4;

                default:
                    return 0;

            }
        }
        #endregion

        #region Service Dott Integration Member Register

        /// <summary>
        /// Check if the member is logged in, Encrypted email address is sent.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string IsMemberLoggedInByE(string e)
        {
            if (SessionData.Member != null)
            {

                try
                {
                    string urlDecodedE = HttpUtility.UrlDecode(e);  // Email

                    if (!string.IsNullOrWhiteSpace(urlDecodedE))
                    {
                        string decryptedEmail = string.Empty;
                        bool emailFormatValid = ServiceDottIntegration.EmailDecrypt(urlDecodedE, out decryptedEmail);

                        if (emailFormatValid && decryptedEmail.ToLower().Equals(SessionData.Member.EmailAddress.ToLower()))
                            return "Logged in";
                    }
                }
                catch 
                {

                }
            }

            return "Not Logged in";
        }

        [WebMethod(EnableSession = true)]
        public string RegisterMember(string e, string f, string l)
        {
            try
            {
                string urlDecodedE = HttpUtility.UrlDecode(e);  // Email
                string urlDecodedF = HttpUtility.UrlDecode(f);  // First name
                string urlDecodedL = HttpUtility.UrlDecode(l);  // Last name

                string registerResult = ServiceDottIntegration.RegisterMember(urlDecodedE, urlDecodedF, urlDecodedL);
                return registerResult;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetBaseException());
                return "Error";
            }
        }

        #endregion


    }

    public class GenericClass
    {
        private int _id;
        private string _value;

        public int ID { get { return _id; } set { _id = value; } }
        public string Value { get { return _value; } set { _value = value; } }

        public GenericClass()
        {
        }

        public GenericClass(int _id, string _value)
        {
            this._id = _id;
            this._value = _value;
        }

    }
}
