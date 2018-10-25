using Jxt.Sitefinity.Jobs.Model;
using Jxt.Sitefinity.Jobs.ViewModel;
using Jxt.Sitefinity.Jobs.ViewModel.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace Jxt.Sitefinity.Jobs.Controllers
{
    public class JobsApiController : ApiController
    {
        IJobsModel _jobsModel;

        public JobsApiController()
        {
            DrawDependencies();
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<List<JobViewModel>> Get()
        {
            var vms = _jobsModel.GetListViewModel();
            return this.Json<List<JobViewModel>>(vms, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<JobViewModel> Get(int id)
        {
            var vm = _jobsModel.GetSingleViewModel(id);

            if (vm == null)
            {
                //error
                return null;
            }

            return this.Json<JobViewModel>(vm, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<JobViewModel> Post(JobViewModel vm)
        {
            var createdJob = _jobsModel.Create(vm);
            return this.Json<JobViewModel>(vm, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }

        [System.Web.Mvc.HttpPut]
        public JsonResult<JobViewModel> Put(JobViewModel vm)
        {
            var updatedJob = _jobsModel.Update(vm);
            return this.Json<JobViewModel>(vm, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }

        [System.Web.Mvc.HttpDelete]
        public bool Delete(int id)
        {
            _jobsModel.Delete(id);
            return true;
        }

        private void DrawDependencies()
        {
            _jobsModel = new JobsModel();
        }
    }
}