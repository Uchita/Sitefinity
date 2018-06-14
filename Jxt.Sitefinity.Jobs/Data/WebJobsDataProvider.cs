using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jxt.Sitefinity.Jobs.Data.Model;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data.Decorators;
using Telerik.Sitefinity.Modules.GenericContent.Data;
using Telerik.Sitefinity.Security.Model;

namespace Jxt.Sitefinity.Jobs.Data
{
    public class WebJobsDataProvider : JobsDataProviderBase
    {
        public WebJobsDataProvider()
            :base()
        {
        }
        
        public override JobListing CreateJobListing()
        {
            throw new NotSupportedException();
        }

        public override JobListing CreateJobListing(Guid id)
        {
            throw new NotSupportedException();
        }

        public override void DeleteJobListing(JobListing listing)
        {
            throw new NotSupportedException();
        }

        public override JobListing GetJobListing(Guid id)
        {
            throw new NotSupportedException();
        }

        public override IQueryable<JobListing> GetJobListings()
        {
            throw new NotSupportedException();
        }
    }
}
