using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlertJson;
using Newtonsoft.Json;

namespace JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Utility
{
    public static class JobAlertUtility
    {
        private readonly static string CategoryString = "Categories";
        private readonly static string SalaryString = "Salary";
        private readonly static string CompanyString = "CompanyName";
        private readonly static string RangeString = "Range";
        private static dynamic _mapToClassificationData(JobAlertEditFilterRootItem filter, JobAlertViewModel model)
        {
            if (filter.Name.ToLower() != SalaryString.ToLower())
            {
                dynamic classification = new ExpandoObject();
                classification.SearchType = CategoryString;
                classification.ClassificationRootName = filter.Name;

                var subTargets = filter.Filters
                    .Select(x => MapJobAlertFilterToClassification(x))
                    .Where(x => x != null)
                    .ToList();
                if (subTargets != null && subTargets.Count != 0)
                {
                    classification.TargetClassifications = subTargets;
                }

                return classification;
            }
            else
            {
                return null;
            }
            
        }


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
                if(companyFieldSearch.Count > 0)
                {
                    json.FieldSearches = companyFieldSearch;
                }
                
            }
            
            
            foreach (var filter in filtersVMList)
            {
                var classificationData = _mapToClassificationData(filter,model);
                if(classificationData != null && filter.Name.ToLower() != CompanyString.ToLower())
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

            if (model.Keywords != null && model.Keywords.Length > 0)
            {
                model.Keywords.Split(',').ToList().ForEach(x => json.KeywordsSearchCriteria.Add(new { Keyword = x }));
            }
            else
            {
                json.KeywordsSearchCriteria = null;
            }
            

            return json;
        }


        static dynamic MapJobAlertFilterToClassification(JobAlertEditFilterItem filterItem)
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
                        if(subTargets != null)
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

        static void MergeFilters(JobAlertEditFilterItem filterItem, List<string> values)
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


        public static string ConvertJobAlertViewModelToSearchModel(JobAlertViewModel model, List<JobAlertEditFilterRootItem> filtersVMList)
        {
            JobAlertEditFilterRootItem dest = new JobAlertEditFilterRootItem();
            if(model.SalaryStringify != null)
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
            if(alertViewModel != null)
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
