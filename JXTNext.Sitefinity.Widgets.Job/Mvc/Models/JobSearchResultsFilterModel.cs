using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobSearchResultsFilterModel
    {
        public List<JobSearchFilterReceiver> Filters { get; set; }
        public string Keywords { get; set; }
        public Consultant ConsultantSearch { get; set; }
        public int Page { get; set; }
        public JobSearchSalaryFilterReceiver Salary { get; set; }
        public string SortBy { get; set; }

        public static bool HasFilters(JobSearchResultsFilterModel filterModel)
        {
            bool hasFilters = false;

            if (filterModel.Filters != null && filterModel.Filters.Count > 0)
            {
                foreach (var filter in filterModel.Filters)
                {
                    if (filter.values != null && filter.values.Count > 0)
                    {
                        hasFilters = true;
                        break;
                    }
                }
            }
            if (filterModel != null && !hasFilters && (!filterModel.Keywords.IsNullOrEmpty() || filterModel.Salary != null))
                hasFilters = true;

            return hasFilters;
        }

        public static JXTNext_SearchJobsRequest ProcessInputToSearchRequest(JobSearchResultsFilterModel filterModel, int? pageSize, int pageSizeDefaultValue = 5)
        {
            JXTNext_SearchJobsRequest request = new JXTNext_SearchJobsRequest();
            if (filterModel != null)
            {
                if (!string.IsNullOrEmpty(filterModel.Keywords))
                    request.KeywordsSearchCriteria = new List<KeywordSearch> { new KeywordSearch { Keyword = filterModel.Keywords } };

                if (filterModel.ConsultantSearch != null && (!string.IsNullOrEmpty(filterModel.ConsultantSearch.Email) || !string.IsNullOrEmpty(filterModel.ConsultantSearch.FirstName) || !string.IsNullOrEmpty(filterModel.ConsultantSearch.LastName)))
                    request.ConsultantSearchCriteria = new ConsultantSearch() { Email = filterModel.ConsultantSearch.Email, FirstName = filterModel.ConsultantSearch.FirstName, LastName = filterModel.ConsultantSearch.LastName };

                List<IClassificationSearch> classificationSearches = new List<IClassificationSearch>();
                bool isFiltersExists = false;
                if (filterModel.Salary != null)
                {
                    isFiltersExists = true;
                    Classification_RangeSearch cateRangeSearch = new Classification_RangeSearch()
                    {
                        ClassificationRootName = filterModel.Salary.RootName,
                        TargetValue = filterModel.Salary.TargetValue,
                        UpperRange = filterModel.Salary.UpperRange,
                        LowerRange = filterModel.Salary.LowerRange
                    };
                    classificationSearches.Add(cateRangeSearch);
                }

                if (filterModel.Filters != null && filterModel.Filters.Count() > 0)
                {
                    isFiltersExists = true;
                    for (int i = 0; i < filterModel.Filters.Count(); i++)
                    {
                        var filter = filterModel.Filters[i];
                        if (filter != null && filter.values != null && filter.values.Count > 0)
                        {
                            Classification_CategorySearch cateSearch = new Classification_CategorySearch
                            {
                                ClassificationRootName = filter.rootId,
                                TargetClassifications = new List<Classification_CategorySearchTarget>()
                            };

                            foreach (var filterItem in filter.values)
                            {
                                var targetCategory = new Classification_CategorySearchTarget() { SubTargets = new List<Classification_CategorySearchTarget>() };
                                ProcessFilterLevels(targetCategory, filterItem);
                                cateSearch.TargetClassifications.Add(targetCategory);
                            }

                            classificationSearches.Add(cateSearch);
                        }
                    }
                }

                if (isFiltersExists)
                    request.ClassificationsSearchCriteria = classificationSearches;

                if (pageSize.HasValue && pageSize.Value > 0)
                    request.PageSize = pageSize.Value;
                else
                    request.PageSize = pageSizeDefaultValue;

                if (filterModel.Page <= 0)
                    filterModel.Page = 1;

                request.PageNumber = filterModel.Page - 1;
            }

            return request;
        }


        public static void ProcessFilterLevels(Classification_CategorySearchTarget catTarget, JobSearchFilterReceiverItem filterItem)
        {
            if (catTarget != null && filterItem != null)
            {
                catTarget.TargetValue = filterItem.ItemID;
                if (filterItem.SubTargets != null && filterItem.SubTargets.Count > 0)
                {
                    foreach (var subItem in filterItem.SubTargets)
                    {
                        Classification_CategorySearchTarget catSubTarget = new Classification_CategorySearchTarget() { SubTargets = new List<Classification_CategorySearchTarget>() };
                        ProcessFilterLevels(catSubTarget, subItem);
                        catTarget.SubTargets.Add(catSubTarget);
                    }
                }
            }
        }

        public static void ProcessFilterLevelsToFlat(JobSearchFilterReceiverItem filterItem, List<string> values)
        {
            if (filterItem != null)
            {
                if (values != null)
                    values.Add(filterItem.ItemID);

                if (filterItem.SubTargets != null && filterItem.SubTargets.Count > 0)
                {
                    foreach (var subItem in filterItem.SubTargets)
                    {
                        ProcessFilterLevelsToFlat(subItem, values);
                    }
                }
            }
        }


        public static SearchSortBy GetSortEnumFromString(string sort)
        {
            SearchSortBy sortBy = SearchSortBy.Recent;

            switch (sort)
            {
                case "Old":
                    sortBy = SearchSortBy.Oldest;
                    break;

                case "A-Z":
                    sortBy = SearchSortBy.A_to_Z;
                    break;

                case "Z-A":
                    sortBy = SearchSortBy.Z_to_A;
                    break;

                case "SalaryHighToLow":
                    sortBy = SearchSortBy.Salary_High_to_Low;
                    break;

                case "SalaryLowToHigh":
                    sortBy = SearchSortBy.Salary_Low_to_High;
                    break;

                case "Recent":
                    sortBy = SearchSortBy.Recent;
                    break;

                default:
                    sortBy = SearchSortBy.Relevance;
                    break;

            }

            return sortBy;
        }

        public static string GetSortStringFromEnum(SearchSortBy sort)
        {
            string sortBy = String.Empty;

            switch (sort)
            {
                case SearchSortBy.Oldest:
                    sortBy = "Old";
                    break;

                case SearchSortBy.A_to_Z:
                    sortBy = "A-Z";
                    break;

                case SearchSortBy.Z_to_A:
                    sortBy = "Z-A";
                    break;

                case SearchSortBy.Salary_High_to_Low:
                    sortBy = "SalaryHighToLow";
                    break;

                case SearchSortBy.Salary_Low_to_High:
                    sortBy = "SalaryLowToHigh";
                    break;

                case SearchSortBy.Recent:
                    sortBy = "Recent";
                    break;
                
                default:
                    sortBy = "Relevance";
                    break;

            }

            return sortBy;
        }

    }

    public class JobSearchFilterReceiver
    {
        public string searchTarget { get; set; }
        public string rootId { get; set; }
        public List<JobSearchFilterReceiverItem> values { get; set; }
    }

    public class JobSearchFilterReceiverItem
    {
        public string ItemID { get; set; }
        public List<JobSearchFilterReceiverItem> SubTargets { get; set; }

    }

    public class JobSearchSalaryFilterReceiver
    {
        public string RootName { get; set; }
        public string TargetValue { get; set; }
        public int UpperRange { get; set; }
        public int LowerRange { get; set; }
    }

    public class Consultant
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }



    public class JobSearchResultsFilterBinder : IModelBinder
    {
        private class FilterNode
        {
            public string RootId { get; set; }
            public List<string> Values { get; set; }
        }
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            HttpRequestBase request = controllerContext.HttpContext.Request;
            string keywords = request.Params["Keywords"];

            int page = 1;
            if (request.Params["Page"] != null)
                page = Int32.Parse(request.Params["Page"]);

            string sortBy = request.Params["SortBy"];

            JobSearchSalaryFilterReceiver salary = null;
            if (request.Params["Salary.TargetValue"] != null && request.Params["Salary.LowerRange"] != null && request.Params["Salary.UpperRange"] != null)
            {
                string salaryTargetValue = request.Params["Salary.TargetValue"];
                int salaryLowerRange = 0;
                Int32.TryParse(request.Params["Salary.LowerRange"], out salaryLowerRange);
                int salaryUpperRange = 0;
                Int32.TryParse(request.Params["Salary.UpperRange"], out salaryUpperRange);
                salary = new JobSearchSalaryFilterReceiver() { RootName = "Salary", TargetValue = salaryTargetValue, LowerRange = salaryLowerRange, UpperRange = salaryUpperRange };
            }

            /*
             * Input samples 
             * Filters[0].rootId = 0
             * Filters[0].values = 1, 1_2, 1_2_3, 1_2_4, 1_3_18
             * Filters[1].rootId = A
             * Filters[1].values = B, B_C, B_C_D, B_C_E
             */

            Dictionary<string, FilterNode> tracker = new Dictionary<string, FilterNode>();

            List<string> filterKeys = request.QueryString.AllKeys.Where(c => c.ToUpper().Contains("FILTERS")).OrderBy(c => c).ToList();
            var reqParams = request.QueryString;
            if (filterKeys == null || filterKeys.Count <= 0)
            {
                filterKeys = request.Params.AllKeys.Where(c => c.ToUpper().Contains("FILTER")).OrderBy(c => c).ToList();
                reqParams = request.Params;
            }

            foreach (string k in filterKeys)
            {
                string thisFilterKey = ExtractFilterNodeID(k);
                if (thisFilterKey != null)
                {
                    if (tracker.Keys.Contains(thisFilterKey))
                    {
                        FilterNode thisNode = tracker[thisFilterKey];
                        if (k.ToUpper().Contains("ROOTID"))
                            thisNode.RootId = reqParams[k];
                        else if (k.ToUpper().Contains("VALUES"))
                            thisNode.Values = reqParams[k].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    }
                    else
                    {
                        FilterNode newNode = new FilterNode();
                        if (k.ToUpper().Contains("ROOTID"))
                            newNode.RootId = reqParams[k];
                        else if (k.ToUpper().Contains("VALUES"))
                            newNode.Values = reqParams[k].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        tracker.Add(thisFilterKey, newNode);
                    }


                }
            }

            /*
             * Output Sample
             * tracker["Filter[0]"] = FilterNode { RootId ="0", Values = ["1","1_2","1_2_3" ]}
             * tracker["Filter[1]"] = FilterNode { RootId = "A", Values = ["B","B_C","B_C_E" ]}            
             */

            //process tracker into target model
            JobSearchResultsFilterModel targetModel = new JobSearchResultsFilterModel() { Keywords = keywords, Page = page, Filters = new List<JobSearchFilterReceiver>(), Salary = salary, SortBy = sortBy };

            foreach (string trackerKey in tracker.Keys)
            {
                FilterNode thisFilterNode = tracker[trackerKey];
                JobSearchFilterReceiver receiver = new JobSearchFilterReceiver { rootId = thisFilterNode.RootId, values = new List<JobSearchFilterReceiverItem>() };
                if (thisFilterNode.Values != null && thisFilterNode.Values.Count() > 0)
                {
                    foreach (string value in thisFilterNode.Values)
                    {
                        AssignNodeRoot(receiver, value);
                    }
                }

                targetModel.Filters.Add(receiver);
            }

            return targetModel;
        }


        private void AssignNodeRoot(JobSearchFilterReceiver root, string input)
        {
            //sample input: A_B_C_D
            List<string> itemIDs = input.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (itemIDs.Count() == 0)
                return;

            if (itemIDs.Count() == 1)
            {
                if (root.values == null)
                {
                    root.values.Add(new JobSearchFilterReceiverItem { ItemID = itemIDs[0] });
                }
                else
                {
                    bool hasMatchingItem = root.values.Where(c => c.ItemID.Equals(itemIDs[0])).Any();
                    if (!hasMatchingItem)
                        root.values.Add(new JobSearchFilterReceiverItem { ItemID = itemIDs[0] });
                }
                return;
            }
            else
            {
                JobSearchFilterReceiverItem nextLevelItem = null;
                if (root.values == null)
                {
                    nextLevelItem = new JobSearchFilterReceiverItem { ItemID = itemIDs[0] };
                    root.values.Add(nextLevelItem);
                }
                else
                {
                    JobSearchFilterReceiverItem matchingItem = root.values.Where(c => c.ItemID.Equals(itemIDs[0])).FirstOrDefault();
                    if (matchingItem == null)
                    {
                        nextLevelItem = new JobSearchFilterReceiverItem { ItemID = itemIDs[0] };
                        root.values.Add(nextLevelItem);
                    }
                    else
                        nextLevelItem = matchingItem;
                }
                if (nextLevelItem != null)
                    AssignNodeRootItem(nextLevelItem, String.Join("_", itemIDs.Skip(1)));
            }
        }

        private void AssignNodeRootItem(JobSearchFilterReceiverItem item, string input)
        {
            //sample input: B_C_D
            List<string> itemIDs = input.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            //create the next level item
            JobSearchFilterReceiverItem itemLevel1 = null;

            if (itemIDs.Count() > 0)
            {
                JobSearchFilterReceiverItem matchingLevel1 = null;
                if (item.SubTargets != null)
                    matchingLevel1 = item.SubTargets.Where(c => c.ItemID.Equals(itemIDs[0])).FirstOrDefault();

                if (matchingLevel1 == null)
                {
                    itemLevel1 = new JobSearchFilterReceiverItem { ItemID = itemIDs[0] };
                    if (item.SubTargets != null)
                        item.SubTargets.Add(itemLevel1);
                    else
                        item.SubTargets = new List<JobSearchFilterReceiverItem> { itemLevel1 };
                }
                else
                    itemLevel1 = matchingLevel1;
            }

            if (itemIDs.Count() == 1)
                return;

            JobSearchFilterReceiverItem itemLevel2 = null;
            if (itemIDs.Count() > 1)
            {
                //create the next level - next level item (2 level down)
                itemLevel2 = new JobSearchFilterReceiverItem { ItemID = itemIDs[1] };

                if (itemLevel1.SubTargets != null)
                    itemLevel1.SubTargets.Add(itemLevel2);
                else
                    itemLevel1.SubTargets = new List<JobSearchFilterReceiverItem> { itemLevel2 };
            }

            if (itemIDs.Count() > 2 && itemLevel2 != null)
                AssignNodeRootItem(itemLevel2, String.Join("_", itemIDs.Skip(2)));
        }



        private string ExtractFilterNodeID(string key)
        {
            string[] keyValues = key.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            if (keyValues != null && keyValues.Count() > 0)
                return keyValues[0];
            else
                return null;
        }
    }


    public class JobTypesDesignerViewModel
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public bool Selected { get; set; }
    }
}