﻿using Jxt.Sitefinity.Jobs.ViewModel;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;

namespace Jxt.Sitefinity.Jobs.Model
{
    public class JXTNext_JobsConverter : IJobsConverter
    {
        public JobViewModel Convert(JobDetailsFullModel data)
        {
            return new JobViewModel
            {
                Id = data.JobID,
                Title = data.Title,
                Description = data.Description,
            };
        }

        public JobDetailsFullModel Convert(JobViewModel viewData)
        {
            return new JobDetailsFullModel
            {
                JobID = viewData.Id,
                Title = viewData.Title,
                Description = viewData.Description,
                ShortDescription = viewData.Description
            };
        }
    }
}