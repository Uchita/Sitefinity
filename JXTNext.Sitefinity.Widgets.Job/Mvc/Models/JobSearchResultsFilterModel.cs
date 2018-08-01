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
        public int Page { get; set; }
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

            /*
             * Input samples 
             * Filters[0].rootId = 0
             * Filters[0].values = 1, 1_2, 1_2_3, 1_2_4, 1_3_18
             * Filters[1].rootId = A
             * Filters[1].values = B, B_C, B_C_D, B_C_E
             */

            Dictionary<string, FilterNode> tracker = new Dictionary<string, FilterNode>();

            List<string> filterKeys = request.QueryString.AllKeys.Where(c => c.ToUpper().Contains("FILTERS")).OrderBy(c=>c).ToList();
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
            JobSearchResultsFilterModel targetModel = new JobSearchResultsFilterModel() { Keywords = keywords, Page = page, Filters = new List<JobSearchFilterReceiver>()};

            foreach(string trackerKey in tracker.Keys)
            {
                FilterNode thisFilterNode = tracker[trackerKey];
                JobSearchFilterReceiver receiver = new JobSearchFilterReceiver { rootId = thisFilterNode.RootId, values = new List<JobSearchFilterReceiverItem>() };
                if( thisFilterNode.Values != null && thisFilterNode.Values.Count() > 0)
                { 
                    foreach(string value in thisFilterNode.Values)
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

            if( itemIDs.Count() == 1)
            {
                if (root.values == null)
                { 
                    root.values.Add(new JobSearchFilterReceiverItem { ItemID = itemIDs[0] });
                }
                else
                {
                    bool hasMatchingItem = root.values.Where(c => c.ItemID.Equals(itemIDs[0])).Any();
                    if(!hasMatchingItem )
                        root.values.Add(new JobSearchFilterReceiverItem { ItemID = itemIDs[0] });
                }
                return;
            }
            else
            {
                JobSearchFilterReceiverItem nextLevelItem =  null;
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
                if( nextLevelItem != null)
                    AssignNodeRootItem(nextLevelItem, String.Join("_", itemIDs.Skip(1)));
            }
        }

        private void AssignNodeRootItem(JobSearchFilterReceiverItem item, string input)
        {
            //sample input: B_C_D
            List<string> itemIDs = input.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            //create the next level item
            JobSearchFilterReceiverItem itemLevel1 = null;

            if( itemIDs.Count() > 0)
            {
                JobSearchFilterReceiverItem matchingLevel1 = null;
                if(item.SubTargets != null)
                    matchingLevel1 = item.SubTargets.Where(c=>c.ItemID.Equals(itemIDs[0])).FirstOrDefault();

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