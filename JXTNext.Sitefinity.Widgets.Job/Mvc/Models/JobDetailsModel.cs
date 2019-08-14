using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobDetailsViewModel
    {
        public dynamic JobDetails { get; set; }
        public bool JobApplyAvailable { get; set; }
        public string ApplicationAvatarImageUrl { get; set; }
        public OrderedDictionary Classifications { get; set; }
        public OrderedDictionary Locations { get; set; }
        public string ClassificationsRootName { get; set; }
        public string LocationsRootName { get; set; }
        public string ClassificationsSEORouteName { get; set; }
        public string UrlReferral { get; set; }
        public string ApplicationEmail { get; set; }
        public string JobCurrencySymbol { get; set; }

        // CustomData is of Flat JSON, so we are getting the values as .Sublevel[0]
        // Process this until we find the key .Sublevel[0] as null
        public static void ProcessCustomData(string key, Dictionary<string, string> customData, OrderedDictionary ordDict)
        {
            if (!customData.ContainsKey(key + ".Value"))
                return;

            string addOrRemoveText = ".Sublevel[0]";
            string parentKey = key.Remove(key.Length - addOrRemoveText.Length, addOrRemoveText.Length);

            //string childId = customData[parentKey + ".ExternalReference"] + "_" + customData[key + ".ExternalReference"];
            ordDict.Add(customData[key + ".ExternalReference"], customData[key + ".Value"]);
            string nextKey = key + ".SubLevel[0]";

            ProcessCustomData(nextKey, customData, ordDict);
        }

        // We need to append the parent ids to the front end.
        public static void AppendParentIds(OrderedDictionary srcDict, OrderedDictionary destDict)
        {
            if (srcDict != null && destDict != null)
            {
                int i = 1;
                string concatKey = String.Empty;
                foreach (var key in srcDict.Keys)
                {
                    if (i == 1)
                    {
                        destDict.Add(key, srcDict[key]);
                        concatKey = key.ToString();
                    }
                    else
                    {
                        concatKey += "_" + key.ToString();
                        destDict.Add(concatKey, srcDict[key]);
                    }

                    i++;
                }
            }
        }
    }

    public class JobDetailsRolesOptions
    {
        public string RoleName { get; set; }
        public bool IsChecked { get; set; }
    }
}
