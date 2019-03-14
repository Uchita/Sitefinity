using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Mappers
{
    public class JXTNext_JobListingMapper : IJobListingMapper
    {
        public IntegrationMapperType mapperType => IntegrationMapperType.JXTNext;


        public object ConvertToAPIEntity(JobDetailsModel jobDetails)
        {
            return jobDetails;
        }

        public T ConvertToLocalEntity<T>(dynamic data) where T : class
        {
            JobDetailsFullModel local = new JobDetailsFullModel
            {
                JobID = data["Id"],
                Title = data["Name"],

                CompanyId = data["CompanyId"],
                UserId = data["UserId"],
                AdvertiserUserId = data["AdvertiserUserId"],
                DateCreated = data["DateCreated"],
                ExpiryDate = data["ExpiryDate"],
                Status = data["Status"],
                Address = data["Address"],
                AddressLatitude = data["AddressLatitude"],
                AddressLongtitude = data["AddressLongtitude"],
                IsDeleted = data["IsDeleted"],
                ShortDescription = data["ShortDescription"],
                Description = data["FullDescription"],
                ReferenceNo = data["RefNo"],
                CustomData = (data["CustomData"] != null) ? FlattenJson(JObject.Parse((data["CustomData"]).Value)) : null,
                ClassificationURL = ProcessClassificationSEOString((data["CustomData"] != null) ? FlattenJson(JObject.Parse((data["CustomData"]).Value)) : null, Convert.ToString(data["Name"]))
            };

            return local as T;
        }

        public List<T> ConvertSearchResultsFiltersToLocal<T>(dynamic searchData) where T : class
        {
            List<JobFilterRoot> jobFullDetails = new List<JobFilterRoot>();

            foreach (dynamic jobItem in searchData)
            {
                //target: JobDetailsFullModel
                JobFilterRoot local = new JobFilterRoot
                {
                    ID = jobItem["ID"],
                    Name = jobItem["Name"],
                    Type = jobItem["Type"],
                    Filters = JsonConvert.DeserializeObject<List<JobFilter>>(jobItem["Filters"].ToString())
            };
                jobFullDetails.Add(local);
            }
            return jobFullDetails as List<T>;
        }

        public List<T> ConvertSearchResultsToLocal<T>(dynamic searchData) where T : class
        {
            List<JobDetailsFullModel> jobFullDetails = new List<JobDetailsFullModel>();

            foreach (dynamic jobItem in searchData)
            {
                //target: JobDetailsFullModel
                JobDetailsFullModel local = new JobDetailsFullModel
                {
                    JobID = jobItem["Id"],
                    Title = jobItem["Name"],
                    DateCreated = jobItem["DateCreated"],
                    ExpiryDate = jobItem["ExpiryDate"],
                    ShortDescription = jobItem["ShortDescription"],
                    Description = jobItem["FullDescription"],
                    ReferenceNo = jobItem["RefNo"],
                    CustomData = (jobItem["CustomData"] != null) ? FlattenJson(new JObject(jobItem["CustomData"])) : null,
                    ClassificationURL = ProcessClassificationSEOString((jobItem["CustomData"] != null) ? FlattenJson(new JObject(jobItem["CustomData"])) : null, Convert.ToString(jobItem["Name"]))
                };
                jobFullDetails.Add(local);
            }
            return jobFullDetails as List<T>;
        }

        private string ProcessClassificationSEOString(Dictionary<string, string> CustomData,string title)
        {
            OrderedDictionary classifOrdDict = new OrderedDictionary();
            classifOrdDict.Add(CustomData["Classifications[0].Filters[0].ExternalReference"], CustomData["Classifications[0].Filters[0].Value"]);
            string parentClassificationsKey = "Classifications[0].Filters[0].SubLevel[0]";
            ProcessCustomData(parentClassificationsKey, CustomData, classifOrdDict);
            OrderedDictionary classifParentIdsOrdDict = new OrderedDictionary();
            AppendParentIds(classifOrdDict, classifParentIdsOrdDict);

            // Getting the SEO route name for classifications
            List<string> seoString = new List<string>();
            foreach (var key in classifParentIdsOrdDict.Keys)
            {
                string value = classifParentIdsOrdDict[key].ToString();
                string SEOString = Regex.Replace(value, @"([^\w]+)", "-");
                seoString.Add(SEOString + "-jobs");
            }
            seoString.Add(Regex.Replace(title + "-job", @"([^\w]+)", "-"));
            return String.Join("/", seoString);

        }


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


        public void ProcessCustomData(string key, Dictionary<string, string> customData, OrderedDictionary ordDict)
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


        private Dictionary<string, string> FlattenJson(JObject jObject)
        {
            return jObject.Descendants()
                .Where(j => j.Children().Count() == 0)
                .Aggregate(
                    new Dictionary<string, string>(),
                    (props, jtoken) =>
                    {
                        props.Add(jtoken.Path, jtoken.ToString());
                        return props;
                    });
        }

    }
}
