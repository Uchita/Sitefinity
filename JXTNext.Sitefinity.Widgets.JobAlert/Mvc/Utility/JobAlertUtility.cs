using System;
using System.Collections.Generic;
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
        private readonly static string RangeString = "Range";
        private static Classification_CategorySearchJson _mapToClassificationData(JobAlertEditFilterRootItem filter)
        {
            Classification_CategorySearchJson classification = new Classification_CategorySearchJson();
            classification.SearchType = CategoryString;
            classification.ClassificationRootName = filter.Name;
            classification.TargetClassifications = filter.Filters
                .Select(x => MapJobAlertFilterToClassification(x))
                .ToList();
            return classification;
        }


        private static JobAlertJsonModelData _mapToSearchModel(List<JobAlertEditFilterRootItem> filtersVMList, JobAlertViewModel model)
        {

            JobAlertJsonModelData json = new JobAlertJsonModelData();
            json.FieldRanges = null;
            json.FieldSearches = null;
            foreach (var filter in filtersVMList)
            {
                var classificationData = _mapToClassificationData(filter);
                if(classificationData != null)
                {
                    json.ClassificationsSearchCriteria.Add(classificationData);
                }
                else
                {
                    json.ClassificationsSearchCriteria = null;
                }
            }

            if(model.Salary != null)
            {
                json.ClassificationsSearchCriteria.Add(new Classification_CategorySearchJson()
                {
                    SearchType = RangeString,
                    TargetClassifications = null,
                    ClassificationRootID = model.Salary.TargetValue,
                    UpperRange = model.Salary.UpperRange,
                    LowerRange = model.Salary.LowerRange
                });
            }
            

            model.Keywords?.Split(',').ToList().ForEach(x => json.KeywordsSearchCriteria.Add(new KeywordSearchJson() { Keyword = x }));


            return json;
        }


        static Classification_CategorySearchTargetJson MapJobAlertFilterToClassification(JobAlertEditFilterItem filterItem)
        {
            
            if (filterItem != null)
            {
                Classification_CategorySearchTargetJson obj = new Classification_CategorySearchTargetJson();
                obj.TargetValue = filterItem.ID;
                

                if (filterItem.Filters != null && filterItem.Filters.Count > 0)
                {
                    obj.SubTargets = new List<Classification_CategorySearchTargetJson>();
                    foreach (var item in filterItem.Filters)
                    {
                        Classification_CategorySearchTargetJson temp = new Classification_CategorySearchTargetJson();
                        
                        obj.SubTargets.Add(MapJobAlertFilterToClassification(item));
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

            SearchModel searchModel = new SearchModel();
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
