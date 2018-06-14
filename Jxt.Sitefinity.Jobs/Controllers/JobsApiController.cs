using Jxt.Sitefinity.Jobs.Model;
using Jxt.Sitefinity.Jobs.ViewModel;
using Jxt.Sitefinity.Jobs.ViewModel.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Jxt.Sitefinity.Jobs.Controllers
{
    public class JobsApiController: ApiController
    {
        [System.Web.Mvc.HttpGet]
        public JsonResult<List<JobViewModel>> Get()
        {
            var model = this.GetModel();
            var vms = model.GetListViewModel();
            return this.Json<List<JobViewModel>>(vms, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<JobViewModel> Get(Guid id)
        {
            var model = this.GetModel();
            var vm = model.GetSingleViewModel(id);
            return this.Json<JobViewModel>(vm, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<JobViewModel> Post(JobViewModel vm)
        {
            var model = this.GetModel();
            var createdJob = model.Create(vm);
            return this.Json<JobViewModel>(vm, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }

        [System.Web.Mvc.HttpPut]
        public JsonResult<JobViewModel> Put(JobViewModel vm)
        {
            var model = this.GetModel();
            var updatedJob = model.Update(vm);
            return this.Json<JobViewModel>(vm, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }
        
        [System.Web.Mvc.HttpDelete]
        public bool Delete(Guid id)
        {
            var model = this.GetModel();
            model.Delete(id);
            return true;
        }
        
        private JobsModel GetModel()
        {
            return new JobsModel();
        }
    }
}
