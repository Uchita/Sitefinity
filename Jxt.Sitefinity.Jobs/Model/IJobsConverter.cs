using Jxt.Sitefinity.Jobs.ViewModel;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;

namespace Jxt.Sitefinity.Jobs.Model
{
    public interface IJobsConverter
    {
        JobViewModel Convert(JobDetailsFullModel data);
        JobDetailsFullModel Convert(JobViewModel viewData);
    }
}