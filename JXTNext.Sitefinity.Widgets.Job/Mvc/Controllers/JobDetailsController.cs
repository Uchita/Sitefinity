using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using JXTNext.Sitefinity.Common.Helpers;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using JXTNext.Sitefinity.Widgets.Job.Mvc.Models;
using System.ComponentModel;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure;
using System.Web;
using Telerik.Sitefinity.Abstractions;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "JobDetails_MVC", Title = "Details", SectionName = "JXTNext.Job", CssClass = JobDetailsController.WidgetIconCssClass)]
    public class JobDetailsController : Controller
    {

       
        // All these properties are bind to the designer form 
        // Same will be displayed in the Advanced section of the designer form as text boxes
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public JobDetailsRolesModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = new JobDetailsRolesModel();

                return this.model;
            }
        }

        IBusinessLogicsConnector _BLConnector;
        IOptionsConnector _OConnector;

        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        public string TemplateName
        {
            get
            {
                return this.templateName;
            }

            set
            {
                this.templateName = value;
            }
        }

        public JobDetailsController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        [RelativeRoute("{*tags}")]
        public ActionResult RouteHandler(string[] tags, int? jobid)
        {
            if (Request.IsAjaxRequest()) // Ajax calls
            {
                if (tags != null && tags.Length > 0)
                {
                    var routePath = tags.FirstOrDefault();
                    if (routePath.ToUpper().Contains("GETALLSAVEDJOBS"))
                    {
                        return GetAllSavedJobs();
                    }
                    else if (routePath.ToUpper().Contains("SAVEJOB") || routePath.ToUpper().Contains("REMOVESAVEDJOB"))
                    {
                        if (Request.Form["JobId"] != null)
                        {
                            int jobId;
                            if (Int32.TryParse(Request.Form["JobId"], out jobId))
                            {
                                if (routePath.ToUpper().Contains("SAVEJOB"))
                                    return SaveJob(jobId);
                                else if(routePath.ToUpper().Contains("REMOVESAVEDJOB"))
                                    return RemoveSavedJob(jobId);
                            }
                        }
                    }
                }
            }
            else // Non-Ajax calls
            {
                if (jobid.HasValue)
                    return Index(jobid.Value);

                if (tags != null && tags.Length > 0)
                {
                    string urlRoute = tags.FirstOrDefault();
                    string jobIdStr = urlRoute.Substring(0, urlRoute.LastIndexOf('/')).Split('/').Last();
                    int jobId;
                    if (Int32.TryParse(jobIdStr, out jobId))
                    {
                        return Index(jobId);
                    }
                }
            }

            // Default redirect to Index action
            return Index(null);

        }


        // GET: JobDetails
        public ActionResult Index(int? jobId)
        {
            JobDetailsViewModel viewModel = new JobDetailsViewModel();
            if (jobId.HasValue)
            {

                // Get job source or url referral

                string UrlReferral = string.Empty;
                if (!string.IsNullOrWhiteSpace(Request.QueryString["SRC"]))
                    UrlReferral = Request.QueryString["SRC"];
                else if (!string.IsNullOrWhiteSpace(Request.QueryString["src"]))
                    UrlReferral = Request.QueryString["src"];
                else
                    UrlReferral = this.GetCookieDomain(Request.Cookies["JobsViewed"], jobId.Value);

                viewModel.UrlReferral = UrlReferral;
                Log.Write($" viewModel.UrlReferral  : " + viewModel.UrlReferral, ConfigurationPolicy.ErrorLog);

                IGetJobListingRequest jobListingRequest = new JXTNext_GetJobListingRequest { JobID = jobId.Value };
                IGetJobListingResponse jobListingResponse = _BLConnector.GuestGetJob(jobListingRequest);

                viewModel.JobDetails = jobListingResponse.Job;

                // Getting Consultant Avatar Image Url from Sitefinity 
                viewModel.ApplicationEmail = jobListingResponse.Job.CustomData["ApplicationMethod.ApplicationEmail"];
                var user = SitefinityHelper.GetUserByEmail(jobListingResponse.Job.CustomData["ApplicationMethod.ApplicationEmail"]);
                if (user != null && user.Id != Guid.Empty)
                    viewModel.ApplicationAvatarImageUrl = SitefinityHelper.GetUserAvatarUrlById(user.Id);

                if (this.Model.IsJobApplyAvailable())
                    viewModel.JobApplyAvailable = true;

                // Processing Classifications
                OrderedDictionary classifOrdDict = new OrderedDictionary();
                classifOrdDict.Add(jobListingResponse.Job.CustomData["Classifications[0].Filters[0].ExternalReference"], jobListingResponse.Job.CustomData["Classifications[0].Filters[0].Value"]);
                string parentClassificationsKey = "Classifications[0].Filters[0].SubLevel[0]";
                JobDetailsViewModel.ProcessCustomData(parentClassificationsKey, jobListingResponse.Job.CustomData, classifOrdDict);
                OrderedDictionary classifParentIdsOrdDict = new OrderedDictionary();
                JobDetailsViewModel.AppendParentIds(classifOrdDict, classifParentIdsOrdDict);

                var bull = jobListingResponse.Job.CustomData["Bulletpoints.BulletPoint1"];

                // Processing Locations
                OrderedDictionary locOrdDict = new OrderedDictionary();
                locOrdDict.Add(jobListingResponse.Job.CustomData["CountryLocationArea[0].Filters[0].ExternalReference"], jobListingResponse.Job.CustomData["CountryLocationArea[0].Filters[0].Value"]);
                string parentLocKey = "CountryLocationArea[0].Filters[0].SubLevel[0]";
                JobDetailsViewModel.ProcessCustomData(parentLocKey, jobListingResponse.Job.CustomData, locOrdDict);
                OrderedDictionary locParentIdsOrdDict = new OrderedDictionary();
                JobDetailsViewModel.AppendParentIds(locOrdDict, locParentIdsOrdDict);

                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(ConversionHelper.GetDateTimeFromUnix(jobListingResponse.Job.DateCreated), TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time"));
                DateTime utcTime = ConversionHelper.GetDateTimeFromUnix(jobListingResponse.Job.DateCreated);
                DateTime elocalTime;
                DateTime eutcTime = new DateTime();
                TimeSpan offset = localTime - utcTime;
                TimeSpan eoffset = new TimeSpan();


                if (jobListingResponse.Job.ExpiryDate.HasValue)
                {
                    elocalTime = TimeZoneInfo.ConvertTimeFromUtc(ConversionHelper.GetDateTimeFromUnix(jobListingResponse.Job.ExpiryDate.Value), TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time"));
                    eutcTime = ConversionHelper.GetDateTimeFromUnix(jobListingResponse.Job.ExpiryDate.Value);
                    eoffset = elocalTime - eutcTime;
                }

                viewModel.Classifications = classifParentIdsOrdDict;
                viewModel.Locations = locParentIdsOrdDict;
                viewModel.ClassificationsRootName = "Classifications";
                viewModel.LocationsRootName = "CountryLocationArea";

                // Getting the SEO route name for classifications
                List<string> seoString = new List<string>();
                foreach (var key in classifParentIdsOrdDict.Keys)
                {
                    string value = classifParentIdsOrdDict[key].ToString();
                    string SEOString = Regex.Replace(value, @"([^\w]+)", "-");
                    seoString.Add(SEOString);
                }

                viewModel.ClassificationsSEORouteName = String.Join("/", seoString); 

                ViewBag.CssClass = this.CssClass;
                ViewBag.JobApplicationPageUrl = SitefinityHelper.GetPageUrl(this.JobApplicationPageId);
                ViewBag.JobResultsPageUrl = SitefinityHelper.GetPageUrl(this.JobResultsPageId);
                ViewBag.EmailJobPageUrl = SitefinityHelper.GetPageUrl(this.EmailJobPageId);
                ViewBag.GoogleForJobs = ReplaceToken(GoogleForJobsTemplate, JsonConvert.SerializeObject(new
                {
                    CurrencySymbol = "$",
                    SalaryLowerBand = jobListingResponse.Job.CustomData.ContainsKey("Salaries[0].Filters[0].Min") ? jobListingResponse.Job.CustomData["Salaries[0].Filters[0].Min"] : null,
                    SalaryUpperBand = jobListingResponse.Job.CustomData.ContainsKey("Salaries[0].Filters[0].Max") ? jobListingResponse.Job.CustomData["Salaries[0].Filters[0].Max"] : null,
                    FullDescription = jobListingResponse.Job.Description,
                    Description = jobListingResponse.Job.ShortDescription,
                    AdvertiserCompanyName = jobListingResponse.Job.CustomData.ContainsKey("CompanyName") ? jobListingResponse.Job.CustomData["CompanyName"] : null,
                    ProfessionName = jobListingResponse.Job.CustomData.ContainsKey("Classifications[0].Filters[0].Value") ? jobListingResponse.Job.CustomData["Classifications[0].Filters[0].Value"] : null,
                    LocationName = jobListingResponse.Job.CustomData.ContainsKey("CountryLocationArea[0].Filters[0].Value") ? jobListingResponse.Job.CustomData["CountryLocationArea[0].Filters[0].Value"] : null,
                    AreaName = jobListingResponse.Job.CustomData.ContainsKey("CountryLocationArea[0].Filters[0].SubLevel[0].Value") ? jobListingResponse.Job.CustomData["CountryLocationArea[0].Filters[0].SubLevel[0].Value"] : null,
                    JobName = jobListingResponse.Job.Title,
                    DatePosted = string.Format("|{0}+{1}|", utcTime.ToString("yyyy-MM-ddThh:mm:ss"), offset.Hours.ToString("00") + ":" + offset.Minutes.ToString("00")),
                    ExpiryDate = (jobListingResponse.Job.ExpiryDate.HasValue) ? string.Format("|{0}+{1}|", eutcTime.ToString("yyyy-MM-ddThh:mm:ss"), eoffset.Hours.ToString("00") + ":" + eoffset.Minutes.ToString("00")) : string.Empty,
                    Address = jobListingResponse.Job.Address
                }));
                var fullTemplateName = this.templateNamePrefix + this.TemplateName;
                // If it is null make sure that pass empty string , because html attrubutes will not work properly.
                viewModel.JobDetails.Address = viewModel.JobDetails.Address == null ? "" : viewModel.JobDetails.Address;
                viewModel.JobDetails.AddressLatitude = viewModel.JobDetails.AddressLatitude == null ? "" : viewModel.JobDetails.AddressLatitude;
                viewModel.JobDetails.AddressLongtitude = viewModel.JobDetails.AddressLongtitude == null ? "" : viewModel.JobDetails.AddressLongtitude;

                #region Check job already applied
                ViewBag.IsJobApplied = false;
                JXTNext_MemberAppliedJobResponse response = _BLConnector.MemberAppliedJobsGet() as JXTNext_MemberAppliedJobResponse;
                if(response.Success)
                {
                    foreach (var item in response.MemberAppliedJobs)
                    {
                        if(item.JobId == jobId.Value)
                        {
                            ViewBag.IsJobApplied = true;
                            break;
                        }
                    }
                }
                #endregion
                var meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Attributes.Add("property", "og:title");
                meta.Content = jobListingResponse.Job.Title;
                
                // Get the current page handler in order to access the page header
                var pageHandler = this.HttpContext.CurrentHandler.GetPageHandler();
                pageHandler.Header.Controls.Add(meta);
                return View(fullTemplateName, viewModel);
            }

            return Content("No job has been selected");
        }

        [HttpPost]
        public JsonResult SaveJob(int JobId)
        {
            JXTNext_MemberSaveJobRequest request = new JXTNext_MemberSaveJobRequest() { JobId = JobId };
            JXTNext_MemberSaveJobResponse response = _BLConnector.MemberSaveJob(request) as JXTNext_MemberSaveJobResponse;

            return new JsonResult { Data = response };
        }

        [HttpPost]
        public JsonResult RemoveSavedJob(int JobId)
        {
            JXTNext_MemberSaveJobResponse response = _BLConnector.MemberDeleteSavedJob(JobId) as JXTNext_MemberSaveJobResponse;
            return new JsonResult { Data = response };
        }

        [HttpPost]
        public JsonResult GetAllSavedJobs()
        {
            JXTNext_MemberGetSavedJobResponse response = _BLConnector.MemberGetSavedJobs() as JXTNext_MemberGetSavedJobResponse;
            return new JsonResult { Data = response };
        }
        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        public string ReplaceToken(string origin, string json)
        {
            JObject obj = JsonConvert.DeserializeObject<JObject>(json);

            foreach (var item in obj)
            {
                if (JToken.Parse(JsonConvert.ToString(item.Value.ToString())).Type == JTokenType.String)
                {
                    origin = origin.Replace("{" + item.Key + "}", JsonConvert.ToString(item.Value.ToString().Trim(new char[] { '|' })));
                }
            }

            origin = Regex.Replace(origin, @"{[^{?!\n}]+}", "\"\"");

            return origin;
        }

        public string GetCookieDomain(HttpCookie httpCookie, int jobid)
        {
            string cookieDomain;
            if (httpCookie != null)
            {
                string jobviewedcookie = httpCookie.Value;
                string[] jobviewed = jobviewedcookie.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] tempjobids = null;
                string tempjobid = string.Empty;
                foreach (string viewed in jobviewed)
                {
                    // Retrieve Job ID
                    tempjobids = viewed.Split(new char[] { '|' });
                    tempjobid = tempjobids[0];

                    // if Job ID matches
                    if (tempjobid == jobid.ToString())
                    {
                        if (tempjobids.Length == 2)
                        {
                            // Retrieve Domain
                            cookieDomain = tempjobids[1];
                        }
                    }
                }
            }

            // If the referrer doesn't exists then its always the domain the user is in.
            cookieDomain = HttpContext.Request.Url.Host.ToLower().Replace("www.", string.Empty);
            // If the referrer doesn't exists then its always the domain the user is in.
            return cookieDomain;
        }



        internal const string WidgetIconCssClass = "sfMvcIcn";
        public string CssClass { get; set; }
        private JobDetailsRolesModel model;
        public string JobApplicationPageId { get; set; }
        public string JobResultsPageId { get; set; }
        public string EmailJobPageId { get; set; }
        public object GetDateTimeFromUnix { get; private set; }

        private string templateName = "Simple";
        private string templateNamePrefix = "JobDetails.";
        internal const string GoogleForJobsTemplate = @"<script type='application/ld+json'>
                                                        {
                                                            ""@context"": ""http://schema.org"",
                                                            ""@type"": ""JobPosting"",                
                                                            ""jobBenefits"": """",
                                                            ""datePosted"": {DatePosted},
                                                            ""description"": {FullDescription},
                                                            ""disambiguatingDescription"": {Description},
                                                            ""image"": {AdvertiserLogo},
                                                            ""educationRequirements"": """",
                                                            ""hiringOrganization"":{AdvertiserCompanyName},
                                                            ""experienceRequirements"": """",
                                                            ""incentiveCompensation"": """",
                                                            ""occupationalCategory"": {ProfessionName},
                                                            ""jobLocation"": {
                                                                ""@type"": ""Place"",
                                                                ""address"": {
                                                                    ""@type"": ""PostalAddress"",
                                                                    ""streetAddress"": {Address},
                                                                    ""addressLocality"": {LocationName},
                                                                    ""addressRegion"": {AreaName}
                                                                }
                                                            },
                                                            ""baseSalary"": {
                                                                ""@type"": ""MonetaryAmount"",
                                                                ""minValue"": {SalaryLowerBand},
                                                                ""maxValue"": {SalaryUpperBand},
                                                                ""currency"": {CurrencySymbol}
                                                            },
                                                            ""salaryCurrency"": {CurrencySymbol},
                                                            ""skills"": """",
                                                            ""specialCommitments"": """",
                                                            ""title"": {JobName},
                                                            ""validThrough"": {ExpiryDate},
                                                            ""workHours"": """",
                                                            ""url"": {Canonical}
                                                        }
                                                        </script>";
    }
}