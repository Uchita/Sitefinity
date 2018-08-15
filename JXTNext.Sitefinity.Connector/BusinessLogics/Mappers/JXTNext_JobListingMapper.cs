using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
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

                ShortDescription = data["ShortDescription"],
                Description = data["FullDescription"],
                ReferenceNo = data["RefNo"],
                CustomData = (data["CustomData"] != null) ? FlattenJson(JObject.Parse((data["CustomData"]).Value)) : null
            };

            return local as T;
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
                    ShortDescription = jobItem["ShortDescription"],
                    Description = jobItem["FullDescription"],
                    ReferenceNo = jobItem["RefNo"],
                    CustomData = (jobItem["CustomData"] != null) ? FlattenJson(new JObject(jobItem["CustomData"])) : null
                };
                jobFullDetails.Add(local);
            }
            return jobFullDetails as List<T>;
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
