using System;
using System.Collections.Generic;
using Jxt.Sitefinity.Jobs.ViewModel;

namespace Jxt.Sitefinity.Jobs.Model
{
    public interface IJobsModel
    {
        JobViewModel Create(JobViewModel job);
        void Delete(Guid id);
        List<JobViewModel> GetListViewModel();
        JobViewModel GetSingleViewModel(int id);
        JobViewModel Update(JobViewModel job);
    }
}