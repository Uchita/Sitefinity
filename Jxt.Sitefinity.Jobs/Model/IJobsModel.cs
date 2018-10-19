using Jxt.Sitefinity.Jobs.ViewModel;
using System.Collections.Generic;

namespace Jxt.Sitefinity.Jobs.Model
{
    public interface IJobsModel
    {
        JobViewModel Create(JobViewModel job);
        void Delete(int id);
        List<JobViewModel> GetListViewModel();
        JobViewModel GetSingleViewModel(int id);
        JobViewModel Update(JobViewModel job);
    }
}