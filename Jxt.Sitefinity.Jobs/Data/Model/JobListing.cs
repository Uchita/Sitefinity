﻿using Telerik.Sitefinity;

namespace Jxt.Sitefinity.Jobs.Data.Model
{
    [ManagerType("Jxt.Sitefinity.Jobs.JobsManager, Jxt.Sitefinity.Jobs")]
    public class JobListing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}