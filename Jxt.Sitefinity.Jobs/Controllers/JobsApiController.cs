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
        public JsonResult<List<JobViewModel>> Get()
        {
            var model = this.GetModel();
            var vms = model.GetListViewModel();
            return this.Json<List<JobViewModel>>(vms, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }

        public JsonResult<JobViewModel> Get(Guid id)
        {
            var model = this.GetModel();
            var vm = model.GetEditViewModel(id);
            return this.Json<JobViewModel>(vm, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver(), Formatting = Formatting.Indented });
        }

        public JsonResult<JobViewModel> Post(JobViewModel vm)
        {
            //To Do: Provide implementation 
            return null;
        }

        public JsonResult<JobViewModel> Put(JobViewModel vm)
        {
            //To Do: Provide implementation 
            return null;
        }
        
        public bool Delete(JobViewModel vm)
        {
            //To Do: Provide implementation 
            return true;
        }
        
        private JobsModel GetModel()
        {
            return new JobsModel();
        }
    }
}
