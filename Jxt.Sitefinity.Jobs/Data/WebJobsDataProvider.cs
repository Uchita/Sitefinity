using Jxt.Sitefinity.Jobs.Data.Model;
using System;
using System.Linq;

namespace Jxt.Sitefinity.Jobs.Data
{
    public class WebJobsDataProvider : JobsDataProviderBase
    {
        public WebJobsDataProvider()
            : base()
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