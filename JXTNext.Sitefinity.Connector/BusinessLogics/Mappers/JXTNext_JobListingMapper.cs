using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Mappers
{
    public class JXTNext_JobListingMapper : IJobListingMapper
    {
        public IntegrationMapperType mapperType => IntegrationMapperType.JXTNext;

        public object ConvertToAPIEntity(JobDetailsModel jobDetails)
        {
            return jobDetails;
        }

        public T ConvertToLocalEntity<T>(dynamic data)
        {
            throw new NotImplementedException();
        }
    }
}
