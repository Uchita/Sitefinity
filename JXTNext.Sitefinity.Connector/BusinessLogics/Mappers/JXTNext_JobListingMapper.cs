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
            //target: JobDetailsFullModel
            JobDetailsFullModel local = new JobDetailsFullModel
            {
                JobID = data["Id"],
                Title = data["Name"],
                ShortDescription = data["ShortDescription"],
                Description = data["FullDescription"],                
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
                };
                jobFullDetails.Add(local);
            }
            return jobFullDetails as List<T>;
        }

    }
}
