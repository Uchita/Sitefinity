using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using JXTNext.Sitefinity.Widgets.Job.Mvc.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using System.Dynamic;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using System.ComponentModel;
using Telerik.Sitefinity.Taxonomies.Model;
using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Widgets.Job.Mvc.Logics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources;
using JXTNext.Sitefinity.Common.Constants;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [Localization(typeof(JobFiltersResources))]
    [ControllerToolboxItem(Name = "JobFilters_MVC", Title = "Filters Listing", SectionName = "JXTNext.Job", CssClass = JobFiltersController.WidgetIconCssClass)]
    public class JobFiltersController : Controller
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public JobSearchModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = new JobSearchModel();

                return this.model;
            }
        }


        public string PrefixIdText { get; set; }
        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        private string _templateName;
        public string TemplateName
        {
            get {
                if (string.IsNullOrEmpty(_templateName))
                    _templateName = "T_MultiSelect";
                return _templateName;
            }
            set { _templateName = value; }
        }

        IBusinessLogicsConnector _BLConnector;
        IOptionsConnector _OConnector;

        public JobFiltersController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        // GET: JobFilters
        [HttpGet]
        [RelativeRoute("{param1?}/{param2?}/{param3?}/{param4?}/{param5?}")]
        public ActionResult Index([ModelBinder(typeof(JobSearchResultsFilterBinder))] JobSearchResultsFilterModel filterModel, string jobBoardPageTitle, List<JobFilterRoot> searchResultsFilters, 
            string param1 = null, string param2 = null, string param3 = null, string param4 = null, string param5 = null)
        {
            JobSearchResultsFilterModel.MapFilterSlugsToIds(_OConnector, filterModel);

            dynamic dynamicFilterResponse = null;
            if (filterModel != null && !string.IsNullOrEmpty(filterModel.Keywords))
            {
                filterModel.Keywords = filterModel.Keywords.Trim();
                //filterModel.Keywords = filterModel.Keywords.Trim(charsToTrim);
            }
            if (!string.IsNullOrEmpty(param1) && (param1.ToString().ToLower().Contains("jobs-in-") || param1.ToString().ToLower().Contains("in-")))
            {
                filterModel = SetSidebarFilterModel(param1, param2, param3, param4, param5);
            }

            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            var filtersSelected = filterModel.Filters;
            List<JobFilterRoot> filtersVMList = GetJobSearchResultsFilters(filterModel);
            
            if(filtersSelected != null && filtersSelected.Count > 0)
                ProcessFilters(filtersSelected, filtersVMList);
     
            ViewBag.FilterModel = JsonConvert.SerializeObject(filterModel);
            ViewBag.Keywords = filterModel.Keywords;
            ViewBag.Salary = filterModel.Salary;

            var serializedJobSearchParams = this.SerializedJobSearchParams;
            var prefixIdText = this.PrefixIdText;
            var displayCompanyName = this.DisplayCompanyName;
            var templateName = this.TemplateName;

            // When we are calling it from the job search results controller
            if (!jobBoardPageTitle.IsNullOrEmpty())
            {
                // Getting the widget configuration settings 
                var widgetSettings = JobFiltersLogics.GetWidgetConfigSettings(jobBoardPageTitle, typeof(JobFiltersController).FullName);
                if (widgetSettings != null)
                {
                    serializedJobSearchParams = widgetSettings.Values["SerializedJobSearchParams"];
                    prefixIdText = widgetSettings.Values["PrefixIdText"];
                    displayCompanyName = widgetSettings.Values["DisplayCompanyName"];
                    templateName = widgetSettings.Values["TemplateName"];
                }
            }

            var jobFilterComponents = serializedJobSearchParams == null ? null : JsonConvert.DeserializeObject<List<JobSearchModel>>(serializedJobSearchParams);

            if (jobFilterComponents != null || displayCompanyName)
            {
                if (jobFilterComponents != null)
                {
                    foreach (JobSearchModel item in jobFilterComponents)
                    {
                        FilterData(item.Filters);
                        item.Filters = item.Filters.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
                    }
                }

                var selectedConfigFilters = GetSelecctedFiltersFromConfig(filtersVMList, jobFilterComponents, displayCompanyName);
                AppendParentIds(selectedConfigFilters);
                dynamicFilterResponse = selectedConfigFilters as dynamic;
            }
            else
            {
                AppendParentIds(filtersVMList);
                dynamicFilterResponse = filtersVMList as dynamic;
            }

            ViewBag.PrefixIdsText = prefixIdText == null ? "" : prefixIdText;

            // Why we returning via path?
            // we are going to call the same index action from jobsearchresults controller as well. So from there to identify the correct
            // view, we need to user the virtual path 
            // Telerik.Sitefinity.Frontend.FrontendService service registers a virtual path for each widget assembly and for Telerik.Sitefinity.Frontend
            // The contents of a virtual file inside the Frontend-Assembly path can come from the file system at location ~/[Path] When not found there, 
            // it falls back to retrieving the contents of an embedded resource placed on the same path, inside the specified assembly. 
            // For example, ~/Frontend-Assembly/Telerik.Sitefinity.Frontend/Mvc/Scripts/Angular/angular.min.js
            // https://www.progress.com/documentation/sitefinity-cms/priorities-for-resolving-views-mvc
            return View("~/Frontend-Assembly/Telerik.Sitefinity.Frontend/Mvc/Views/JobFilters/" + templateName + ".cshtml", dynamicFilterResponse);
        }

        private JobSearchResultsFilterModel SetSidebarFilterModel(string param1, string param2, string param3, string param4, string param5)
        {
            var json = string.Empty;

            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);
            var classificationName = string.Empty;
            var countryName = string.Empty;
            var subTarget = new SubTarget();
            var value = new Value();
            var filter = new Models.Filter();
            var filterModelParser = new FilterModelParser();
            var paramSubClassicification = String.Empty;
            var valueList = new List<Value>();
            var filterList = new List<Models.Filter>();
            var list = new List<SubTarget>();

            var query = Request.Url.Query;

            if ((!string.IsNullOrEmpty(Request.QueryString["Classification"]) || !string.IsNullOrEmpty(Request.QueryString["SubClassification"])) ||
                (param1.ToLower().Contains("jobs-in")))
            {
                var numberOfClassifications = 1;

                if (string.IsNullOrEmpty(Request.QueryString["Classification"]) || string.IsNullOrEmpty(Request.QueryString["SubClassification"]))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Classification"]))
                    {
                        numberOfClassifications = Request.QueryString["Classification"].Split(',').Count();
                    }
                }

                while (numberOfClassifications > 0)
                {
                    subTarget = new SubTarget();
                    value = new Value();
                    filter = new Models.Filter();
                    filterModelParser = new FilterModelParser();

                    valueList = new List<Value>();

                    list = new List<SubTarget>();

                    if ((string.IsNullOrEmpty(Request.QueryString["Classification"]) || string.IsNullOrEmpty(Request.QueryString["SubClassification"]))
                        && !((string.IsNullOrEmpty(Request.QueryString["Classification"]) && string.IsNullOrEmpty(Request.QueryString["SubClassification"]))))
                    {
                        if (string.IsNullOrEmpty(Request.QueryString["Classification"]))
                            classificationName = Request.QueryString["SubClassification"].Split(',')[0].Split('/')[0].ToString();
                        else
                            classificationName = Request.QueryString["Classification"].Split(',')[numberOfClassifications - 1];
                    }
                    else
                    {
                        if (param1.ToLower().Contains("jobs-in-"))
                        {
                            classificationName = param1.ToLower().Replace("jobs-in-", string.Empty);

                            if (!string.IsNullOrEmpty(param2) && !param2.ToString().ToLower().Contains("in-"))
                                paramSubClassicification = param2;
                        }
                    }

                    classificationName = Regex.Replace(classificationName.ToUpper(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty);


                    for (int classification = 0; classification < filtersResponse.Filters.Data.Count(); classification++)
                    {
                        if (filtersResponse.Filters.Data[classification].Name.ToUpper() == "CLASSIFICATIONS")
                        {
                            for (int classificationLabel = 0; classificationLabel < filtersResponse.Filters.Data[classification].Filters.Count(); classificationLabel++)
                            {
                                if (Regex.Replace(filtersResponse.Filters.Data[classification].Filters[classificationLabel].Label.ToUpper(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty)
                                    == classificationName)
                                {
                                    value.ItemID = filtersResponse.Filters.Data[classification].Filters[classificationLabel].ID;

                                    for (int classificationFilters = 0; classificationFilters < filtersResponse.Filters.Data[classification].Filters[classificationLabel].Filters.Count(); classificationFilters++)
                                    {
                                        subTarget = new SubTarget();

                                        if (!string.IsNullOrEmpty(query) && string.IsNullOrEmpty(paramSubClassicification))
                                        {
                                            if (Regex.Replace(query.ToUpper(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty).
                                                Contains(
                                               Regex.Replace(filtersResponse.Filters.Data[classification].Filters[classificationLabel].Label.ToUpper(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty).Replace(@"/", "") + @"/" +
                                               Regex.Replace(filtersResponse.Filters.Data[classification].Filters[classificationLabel].Filters[classificationFilters].Label.ToUpper(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty).Replace(@"/", "")
                                                        )
                                                )
                                            {
                                                subTarget.ItemID = filtersResponse.Filters.Data[classification].Filters[classificationLabel].Filters[classificationFilters].ID;
                                                subTarget.SubTargets = filtersResponse.Filters.Data[classification].Filters[classificationLabel].Filters[classificationFilters].Filters;
                                                list.Add(subTarget);
                                            }

                                        }
                                        else
                                        {
                                            if (Regex.Replace(filtersResponse.Filters.Data[classification].Filters[classificationLabel].Filters[classificationFilters].Label.ToUpper().Trim(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty) ==
                                                Regex.Replace(paramSubClassicification.ToUpper().Trim(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty))
                                            {
                                                subTarget.ItemID = filtersResponse.Filters.Data[classification].Filters[classificationLabel].Filters[classificationFilters].ID;
                                                subTarget.SubTargets = filtersResponse.Filters.Data[classification].Filters[classificationLabel].Filters[classificationFilters].Filters;
                                                list.Add(subTarget);
                                            }

                                        }

                                    }
                                    value.SubTargets = list;
                                    valueList.Add(value);
                                }
                            }

                            filter.searchTarget = null;
                            filter.rootId = filtersResponse.Filters.Data[classification].Name;
                            filter.values = valueList;
                            filterList.Add(filter);
                        }
                    }
                    --numberOfClassifications;
                }
            }

            if (param1.ToString().ToLower().Contains("in-") || param2.ToString().ToLower().Contains("in-") || param3.ToString().ToLower().Contains("in-"))
            {

                var paramCountry = String.Empty;
                var paramLocation = String.Empty;

                if (!param1.ToString().ToLower().Contains("jobs-in-") && param1.ToString().ToLower().Contains("in-"))
                {
                    paramCountry = param1;
                    if (!string.IsNullOrEmpty(param2))
                        paramLocation = param2;
                }
                else if (!string.IsNullOrEmpty(param2) && param2.ToString().ToLower().Contains("in-"))
                {
                    paramCountry = param2;
                    if (!string.IsNullOrEmpty(param3))
                        paramLocation = param3;
                }
                else if (!string.IsNullOrEmpty(param3) && param3.ToString().ToLower().Contains("in-"))
                {
                    paramCountry = param3;
                    if (!string.IsNullOrEmpty(param4))
                        paramLocation = param4;
                }

                if (!string.IsNullOrEmpty(paramCountry))
                {
                    subTarget = new SubTarget();
                    value = new Value();
                    filter = new Models.Filter();
                    filterModelParser = new FilterModelParser();

                    valueList = new List<Value>();

                    list = new List<SubTarget>();

                    countryName = Regex.Replace(paramCountry.ToUpper().Replace("IN-", string.Empty), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty);

                    for (int country = 0; country < filtersResponse.Filters.Data.Count(); country++)
                    {
                        if (filtersResponse.Filters.Data[country].Name.ToUpper() == "COUNTRYLOCATIONAREA")
                        {
                            for (int countryLabel = 0; countryLabel < filtersResponse.Filters.Data[country].Filters.Count(); countryLabel++)
                            {
                                if (Regex.Replace(filtersResponse.Filters.Data[country].Filters[countryLabel].Label.ToUpper(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty)
                                    == countryName)
                                {
                                    value.ItemID = filtersResponse.Filters.Data[country].Filters[countryLabel].ID;

                                    for (int countryFilters = 0; countryFilters < filtersResponse.Filters.Data[country].Filters[countryLabel].Filters.Count(); countryFilters++)
                                    {
                                        subTarget = new SubTarget();
                                        if (string.IsNullOrEmpty(paramLocation))
                                        {
                                            if (!string.IsNullOrEmpty(query))
                                            {
                                                if (Regex.Replace(query.ToUpper(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty).
                                                    Contains(
                                                   Regex.Replace(filtersResponse.Filters.Data[country].Filters[countryLabel].Label.ToUpper(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty) + @"/" +
                                                   Regex.Replace(filtersResponse.Filters.Data[country].Filters[countryLabel].Filters[countryFilters].Label.ToUpper(), @"(\s+|-|@| |&|'|\(|\)|<|>|#)", string.Empty)
                                                            )
                                                    )
                                                {
                                                    subTarget.ItemID = filtersResponse.Filters.Data[country].Filters[countryLabel].Filters[countryFilters].ID;
                                                    subTarget.SubTargets = filtersResponse.Filters.Data[country].Filters[countryLabel].Filters[countryFilters].Filters;
                                                    list.Add(subTarget);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (filtersResponse.Filters.Data[country].Filters[countryLabel].Filters[countryFilters].Label.ToUpper().Trim() == paramLocation.ToUpper().Trim())
                                            {
                                                subTarget.ItemID = filtersResponse.Filters.Data[country].Filters[countryLabel].Filters[countryFilters].ID;
                                                subTarget.SubTargets = filtersResponse.Filters.Data[country].Filters[countryLabel].Filters[countryFilters].Filters;
                                                list.Add(subTarget);
                                            }
                                        }

                                    }
                                    value.SubTargets = list;
                                    valueList.Add(value);
                                }
                            }
                            filter.searchTarget = null;
                            filter.rootId = filtersResponse.Filters.Data[country].Name;
                            filter.values = valueList;
                            filterList.Add(filter);
                        }
                    }
                }
            }
            filterModelParser.Filters = filterList;
            filterModelParser.Keywords = Request.QueryString["Keywords"];
            filterModelParser.ConsultantSearch = null;
            filterModelParser.Page = Convert.ToInt32(Request.QueryString["Page"]);
            filterModelParser.Salary = null;
            filterModelParser.SortBy = Request.QueryString["SortBy"];
            filterModelParser.Classification = null;
            filterModelParser.SubClassification = null;
            filterModelParser.Country = null;
            filterModelParser.Location = null;
            filterModelParser.Area = null;
            filterModelParser.WorkType = Request.QueryString["WorkType"];
            filterModelParser.CompanyName = null;
            filterModelParser.SalaryType = Request.QueryString["SalaryType"];
            filterModelParser.SalaryMin = Convert.ToInt32(Request.QueryString["SalaryMin"]);
            filterModelParser.SalaryMax = Convert.ToInt32(Request.QueryString["SalaryMax"]);

            json = new JavaScriptSerializer().Serialize(filterModelParser);

            return JsonConvert.DeserializeObject<JobSearchResultsFilterModel>(json.Trim().TrimEnd('"'));
        }



        private List<JobFilterRoot> GetJobSearchResultsFilters(JobSearchResultsFilterModel filterModel)
        {
            JobSearchSalaryFilterReceiver tempSalary = filterModel.Salary; // Keep salary filters for the view

            filterModel.Filters = null; // Clean up filters & salary for search filters
            filterModel.Salary = null;

            JXTNext_SearchJobsRequest request = JobSearchResultsFilterModel.ProcessInputToSearchRequest(filterModel, 0);
            request.SortBy = JobSearchResultsFilterModel.GetSortEnumFromString(filterModel.SortBy);
            ISearchJobsResponse response = _BLConnector.SearchJobs(request);
            JXTNext_SearchJobsResponse jobResultsList = response as JXTNext_SearchJobsResponse;

            filterModel.Salary = tempSalary; // Put back salary
            if (jobResultsList != null)
                return jobResultsList.SearchResultsFilters;
            else
                return null;
        }

        private void ProcessConfigSubFilters(JobSearchItem configFilterItem, JobFilter newFilter, List<JobFilter> backendJobFilters)
        {
            if (configFilterItem != null && newFilter != null && backendJobFilters != null)
            {
                foreach (var backendFilterItem in backendJobFilters)
                {
                    if(configFilterItem.ID.Equals(backendFilterItem.ID, StringComparison.OrdinalIgnoreCase))
                    {
                        newFilter.ID = backendFilterItem.ID;
                        newFilter.Label = backendFilterItem.Label;
                        newFilter.Count = backendFilterItem.Count;
                        newFilter.Value = backendFilterItem.Value;
                        newFilter.Selected = backendFilterItem.Selected;

                        foreach (var configSubFilterItem in configFilterItem.Filters)
                        {
                            if (backendFilterItem.Filters != null && backendFilterItem.Filters.Count > 0)
                            {
                                var newSubFilter = new JobFilter() { Filters = new List<JobFilter>() };
                                ProcessConfigSubFilters(configSubFilterItem, newSubFilter, backendFilterItem.Filters);
                                newFilter.Filters.Add(newSubFilter);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private List<JobFilterRoot> GetSelecctedFiltersFromConfig(List<JobFilterRoot> filtersVMList, List<JobSearchModel> designerViewModel, bool displayCompanyName)
        {
            List<JobFilterRoot> selectedConfigFilters = new List<JobFilterRoot>();
            if (designerViewModel != null && filtersVMList != null)
            {
                foreach (var item in designerViewModel)
                {
                    foreach (var filterRoot in filtersVMList)
                    {
                        if (item.FilterType.Equals(filterRoot.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            if (item.Filters == null || item.Filters.Count <= 0)
                            {
                                selectedConfigFilters.Add(filterRoot);
                                break;
                            }
                            else
                            {
                                JobFilterRoot rootItem = new JobFilterRoot() { Filters = new List<JobFilter>() };
                                rootItem.ID = filterRoot.ID;
                                rootItem.Name = filterRoot.Name;
                                rootItem.Type = filterRoot.Type;
                                foreach (var configFilterItem in item.Filters)
                                {
                                    var newSubFilter = new JobFilter() { Filters = new List<JobFilter>(), Label = null };
                                    ProcessConfigSubFilters(configFilterItem, newSubFilter, filterRoot.Filters);
                                    if (newSubFilter.Label != null)
                                        rootItem.Filters.Add(newSubFilter);
                                }

                                selectedConfigFilters.Add(rootItem);
                            }
                        }
                    }
                }
            }

            if(displayCompanyName)
            {
                var companyFilter = filtersVMList.Where(item => item.Name == "CompanyName").FirstOrDefault();
                if (companyFilter != null)
                    selectedConfigFilters.Add(companyFilter);
            }

            return selectedConfigFilters;

        }

        static void FilterData(List<JobSearchItem> data)
        {
            if (data == null || data.Count == 0)
                return;

            foreach (JobSearchItem item in data)
            {
                if (item.Filters != null && item.Filters.Count > 0)
                {
                    FilterData(item.Filters);
                    item.Filters = item.Filters.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
                }
            }

            data = data.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
        }



        static void ProcessFiltersIds(List<JobFilter> filters, string parentId, string parentSlug)
        {
            if (filters != null && filters.Count > 0)
            {
                foreach (var filter in filters)
                {
                    filter.ID = parentId + "_" + filter.ID;
                    filter.Slug = parentSlug + GeneralHelper.UrlSlug(filter.Label);
                    if (filter.Filters != null && filter.Filters.Count > 0)
                    {
                        // Organiging by alphbetical order
                        filter.Filters = filter.Filters.OrderBy(x => x.Label).ToList();
                        ProcessFiltersIds(filter.Filters, filter.ID, filter.Slug + JobConstants.FilterHierarchyDelimeter);
                    }
                }
            }
        }

        static void AppendParentIds(List<JobFilterRoot> filtersVMList)
        {
            if (filtersVMList != null && filtersVMList.Count > 0)
            {
                foreach (var filterRoot in filtersVMList)
                {
                    if (filterRoot.Filters != null && filterRoot.Filters.Count > 0)
                    {
                        filterRoot.Filters = filterRoot.Filters.OrderBy(x => x.Label).ToList();
                        foreach (var filter in filterRoot.Filters)
                        {
                            filter.Slug = GeneralHelper.UrlSlug(filter.Label);

                            if (filter.Filters != null && filter.Filters.Count > 0)
                            {
                                // Organiging by alphbetical order
                                filter.Filters = filter.Filters.OrderBy(x => x.Label).ToList();
                                ProcessFiltersIds(filter.Filters, filter.ID, filter.Slug + JobConstants.FilterHierarchyDelimeter);
                            }
                        }
                    }
                }
            }
        }

        static void ProcessFilters(List<JobSearchFilterReceiver> selectedFilters, List<JobFilterRoot> filtersVMList)
        {
            if (selectedFilters != null && selectedFilters.Count > 0)
            {
                foreach (var rootItem in selectedFilters)
                {
                    if (rootItem != null)
                    {
                        if (filtersVMList != null && filtersVMList.Count > 0)
                        {
                            foreach (var filterVMRootItem in filtersVMList)
                            {
                                if (filterVMRootItem.Name == rootItem.rootId)
                                {
                                    if (filterVMRootItem.Filters != null && filterVMRootItem.Filters.Count > 0)
                                    {
                                        foreach (var filterItem in filterVMRootItem.Filters)
                                        {
                                            MergeFilters(filterItem, rootItem.values);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        static bool CheckSubTragets(JobSearchFilterReceiverItem filterRecItem, string Id)
        {
            if(filterRecItem != null)
            {
                if(filterRecItem.ItemID.Equals(Id, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    if(filterRecItem.SubTargets != null && filterRecItem.SubTargets.Count > 0)
                    {
                        foreach(var item in filterRecItem.SubTargets)
                        {
                            if (CheckSubTragets(item, Id))
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        public static void ProcessCategories(HierarchicalTaxon category, JobFilter jobFilter)
        {
            if (category != null && jobFilter != null)
            {
                jobFilter.ID = category.Id.ToString().ToUpper();
                jobFilter.Label = category.Title;
                if (category.Subtaxa != null && category.Subtaxa.Count > 0)
                {
                    foreach (var subTaxon in category.Subtaxa)
                    {
                        var subFilter = new JobFilter() { Filters = new List<JobFilter>() };
                        ProcessCategories(subTaxon, subFilter);
                        jobFilter.Filters.Add(subFilter);
                    }
                }
            }
        }

        public static JobFiltersData GetFiltersData()
        {
            JobFiltersData filtersData = new JobFiltersData() { Data = new List<JobFilterRoot>() };
            var topLovelCategories = SitefinityHelper.GetTopLevelCategories();

            foreach (var taxon in topLovelCategories)
            {
                JobFilterRoot filterRoot = new JobFilterRoot() { Filters = new List<JobFilter>() };
                filterRoot.ID = taxon.Id.ToString().ToUpper();
                filterRoot.Name = taxon.Title;

                var hierarchicalTaxon = taxon as HierarchicalTaxon;
                if (hierarchicalTaxon != null)
                {
                    foreach (var childTaxon in hierarchicalTaxon.Subtaxa)
                    {
                        var jobFilter = new JobFilter() { Filters = new List<JobFilter>() };
                        ProcessCategories(childTaxon, jobFilter);
                        filterRoot.Filters.Add(jobFilter);
                    }
                }

                filtersData.Data.Add(filterRoot);
            }

            return filtersData;
        }

        static void MergeFilters(JobFilter filterItem, List<JobSearchFilterReceiverItem> values)
        {
            if(filterItem != null)
            {
                if (values != null && values.Count > 0)
                {
                    foreach(var item in values)
                    {
                        if(item.ItemID.Equals(filterItem.ID, StringComparison.OrdinalIgnoreCase))
                        {
                            filterItem.Selected = true;
                            break;
                        }

                        if(item.SubTargets != null && item.SubTargets.Count > 0)
                        {
                            foreach(var subItem in item.SubTargets)
                            {
                                if(CheckSubTragets(item, filterItem.ID))
                                {
                                    filterItem.Selected = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (filterItem.Filters != null && filterItem.Filters.Count > 0)
                    {
                        foreach (var item in filterItem.Filters)
                        {
                            MergeFilters(item, values);
                        }
                    }
                }
            }
        }

        public string SerializedJobSearchParams { get; set; }
        public bool DisplayCompanyName { get; set; }

        private string _serializedFilterData;
        public string SerializedFilterData
        {
            get
            {
                if (string.IsNullOrEmpty(_serializedFilterData))
                {
                    //JXTNext_GetJobFiltersRequest filterOptionRequest = new JXTNext_GetJobFiltersRequest { SiteId = 1 };
                    //IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(filterOptionRequest);
                    var filtersData = GetFiltersData();
                    _serializedFilterData = JsonConvert.SerializeObject(filtersData.Data);
                }
                return _serializedFilterData;
            }
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private JobSearchModel model;
    }
}