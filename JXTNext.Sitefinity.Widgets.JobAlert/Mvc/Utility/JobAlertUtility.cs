namespace JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Utility
{
    using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="JobAlertUtility" />
    /// </summary>
    public static class JobAlertUtility
    {
        /// <summary>
        /// Defines the CategoryString
        /// </summary>
        private readonly static string CategoryString = "Categories";

        /// <summary>
        /// Defines the SalaryString
        /// </summary>
        private readonly static string SalaryString = "Salary";

        /// <summary>
        /// Defines the CompanyString
        /// </summary>
        private readonly static string CompanyString = "CompanyName";

        /// <summary>
        /// Defines the RangeString
        /// </summary>
        private readonly static string RangeString = "Range";

        /// <summary>
        /// The _mapToClassificationData
        /// </summary>
        /// <param name="filter">The filter<see cref="JobAlertEditFilterRootItem"/></param>
        /// <param name="model">The model<see cref="JobAlertViewModel"/></param>
        /// <returns>The <see cref="dynamic"/></returns>
        private static dynamic _mapToClassificationData(JobAlertEditFilterRootItem filter, JobAlertViewModel model)
        {
            if (filter.Name != null && filter.Name.ToLower() != SalaryString.ToLower())
            {
                dynamic classification = new ExpandoObject();
                classification.SearchType = CategoryString;
                classification.ClassificationRootName = filter.Name;

                var subTargets = filter.Filters
                    .Select(x => MapJobAlertFilterToClassification(x))
                    .Where(x => x != null)
                    .ToList();
                if (subTargets != null && subTargets.Count > 0)
                {
                    classification.TargetClassifications = subTargets;
                    return classification;
                }
            }
            return null;
        }

        /// <summary>
        /// The _mapToSearchModel
        /// </summary>
        /// <param name="filtersVMList">The filtersVMList<see cref="List{JobAlertEditFilterRootItem}"/></param>
        /// <param name="model">The model<see cref="JobAlertViewModel"/></param>
        /// <returns>The <see cref="dynamic"/></returns>
        private static dynamic _mapToSearchModel(List<JobAlertEditFilterRootItem> filtersVMList, JobAlertViewModel model)
        {
            dynamic json = new ExpandoObject();
            json.FieldRanges = null;
            json.FieldSearches = null;
            json.ClassificationsSearchCriteria = new List<dynamic>();
            json.KeywordsSearchCriteria = new List<dynamic>();
            var companyFilter = filtersVMList.Where(x => x.Name.ToLower() == CompanyString.ToLower()).FirstOrDefault();
            if (companyFilter != null && companyFilter.Filters != null && companyFilter.Filters.Count > 0)
            {
                var companyFieldSearch = new List<dynamic>();
                foreach (var filter in companyFilter.Filters)
                {
                    if (filter.Selected)
                    {
                        dynamic company = new ExpandoObject();
                        company.CompanyId = filter.ID;
                        companyFieldSearch.Add(company);
                    }
                }
                if (companyFieldSearch.Count > 0)
                {
                    json.FieldSearches = companyFieldSearch;
                }
            }

            foreach (var filter in filtersVMList)
            {
                var classificationData = _mapToClassificationData(filter, model);
                if (classificationData != null && filter.Name.ToLower() != CompanyString.ToLower())
                {
                    json.ClassificationsSearchCriteria.Add(classificationData);
                }
            }

            if (model.Salary != null)
            {
                dynamic classification = new ExpandoObject();
                classification.SearchType = RangeString;
                classification.ClassificationRootName = SalaryString;
                classification.TargetValue = model.Salary.TargetValue;
                classification.UpperRange = model.Salary.UpperRange;
                classification.LowerRange = model.Salary.LowerRange;
                json.ClassificationsSearchCriteria.Add(classification);
            }

            if (model != null && !String.IsNullOrWhiteSpace(model.Keywords))
            {
                model.Keywords.Split(',').ToList().ForEach(x => json.KeywordsSearchCriteria.Add(new { Keyword = x }));
            }
            else
            {
                json.KeywordsSearchCriteria = null;
            }
            return json;
        }

        /// <summary>
        /// The MapJobAlertFilterToClassification
        /// </summary>
        /// <param name="filterItem">The filterItem<see cref="JobAlertEditFilterItem"/></param>
        /// <returns>The <see cref="dynamic"/></returns>
        internal static dynamic MapJobAlertFilterToClassification(JobAlertEditFilterItem filterItem)
        {
            if (filterItem != null && filterItem.Selected)
            {
                dynamic obj = new ExpandoObject();
                obj.TargetValue = filterItem.ID;


                if (filterItem.Filters != null && filterItem.Filters.Count > 0)
                {
                    obj.SubTargets = new List<dynamic>();
                    foreach (var item in filterItem.Filters)
                    {
                        dynamic temp = new ExpandoObject();
                        var subTargets = MapJobAlertFilterToClassification(item);
                        if (subTargets != null)
                        {
                            obj.SubTargets.Add(subTargets);
                        }
                    }
                }
                return obj;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The MergeFilters
        /// </summary>
        /// <param name="filterItem">The filterItem<see cref="JobAlertEditFilterItem"/></param>
        /// <param name="values">The values<see cref="List{string}"/></param>
        internal static void MergeFilters(JobAlertEditFilterItem filterItem, List<string> values)
        {
            if (filterItem != null)
            {
                if (values != null && values.Count > 0)
                {
                    if (values.Contains(filterItem.ID))
                    {
                        filterItem.Selected = true;
                        values.Remove(filterItem.ID);
                    }
                    else
                    {
                        return;
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

        /// <summary>
        /// The ConvertJobAlertViewModelToSearchModel
        /// </summary>
        /// <param name="model">The model<see cref="JobAlertViewModel"/></param>
        /// <param name="filtersVMList">The filtersVMList<see cref="List{JobAlertEditFilterRootItem}"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string ConvertJobAlertViewModelToSearchModel(JobAlertViewModel model, List<JobAlertEditFilterRootItem> filtersVMList)
        {
            JobAlertEditFilterRootItem dest = new JobAlertEditFilterRootItem();
            if (model.SalaryStringify != null)
            {
                model.Salary = JsonConvert.DeserializeObject<JobAlertSalaryFilterReceiver>(model.SalaryStringify);
            }

            var alertViewModel = JsonConvert.SerializeObject(model);


            if (model.Filters != null && model.Filters.Count > 0)
            {
                foreach (var rootItem in model.Filters)
                {
                    if (rootItem != null)
                    {
                        if (filtersVMList != null && filtersVMList.Count > 0)
                        {
                            foreach (var filterVMRootItem in filtersVMList)
                            {
                                if (filterVMRootItem.Name == rootItem.RootId)
                                {
                                    if (filterVMRootItem.Filters != null && filterVMRootItem.Filters.Count > 0)
                                    {
                                        foreach (var filterItem in filterVMRootItem.Filters)
                                        {
                                            MergeFilters(filterItem, rootItem.Values);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            dynamic searchModel = new ExpandoObject();
            searchModel.search = _mapToSearchModel(filtersVMList, model);
            if (alertViewModel != null)
            {
                searchModel.jobAlertViewModelData = JsonConvert.DeserializeObject<JobAlertViewModel>(alertViewModel);
            }
            else
            {
                searchModel.jobAlertViewModelData = null;
            }
            return JsonConvert.SerializeObject(searchModel);
        }
    }
}
