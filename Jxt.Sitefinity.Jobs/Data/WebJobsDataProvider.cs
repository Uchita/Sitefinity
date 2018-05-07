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
            this.SuppressSecurityChecks = true;
        }
        
        public override JobListing CreateJobListing()
        {
            return new JobListing();
        }

        public override JobListing CreateJobListing(Guid id)
        {
            return new JobListing() { Id = 1, Title = "Software Developer", Description = "test" };
        }

        public override void DeleteJobListing(JobListing listing)
        {
            //Call JXT NEXT Business Layer
        }

        public override JobListing GetJobListing(Guid id)
        {
            return new JobListing() { Id = 1, Title = "Software Developer", Description = "test" };
        }

        public override IQueryable<JobListing> GetJobListings()
        {
            return new List<JobListing>()
            {
                new JobListing() { Id = 1, Title = "Software Developer", Description = "test" },
                new JobListing() { Id = 2, Title = "UX Architect", Description = "test" },
                new JobListing() { Id = 3, Title = "QA Engineer", Description = "test" }
            }.AsQueryable<JobListing>();
        }

        public override ISecuredObject GetSecurityRoot()
        {
            return this.providerDecorator.GetSecurityRoot();
        }

        public override ISecuredObject GetSecurityRoot(bool create)
        {
            return this.providerDecorator.GetSecurityRoot(create);
        }
    }
}
