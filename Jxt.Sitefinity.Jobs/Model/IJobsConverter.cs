using Jxt.Sitefinity.Jobs.ViewModel;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jxt.Sitefinity.Jobs.Model
{
    public interface IJobsConverter
    {
        JobViewModel Convert(JobDetailsFullModel data);
        JobDetailsFullModel Convert(JobViewModel viewData);
    }
}
