using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Abstractions.Indexing;

namespace JXTPortal.Document
{
    public class JobSearchIndex : AbstractIndexCreationTask<JobDocument>
    {
        public JobSearchIndex()
        {
            Map = JobDocument => from job in JobDocument
                            select new { job.Id };
            //Index(x => x.Name, FieldIndexing.Analyzed);
        }
    }

}
