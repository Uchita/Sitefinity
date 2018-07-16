using JXTNext.Sitefinity.Common.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobDetailsRolesModel
    {
        public JobDetailsRolesModel()
        {
            if (string.IsNullOrWhiteSpace(this.SerializedJobDetailsRoles))
            {
                var roleOptions = new List<JobDetailsRolesOptions>();
                var roleNames = SitefinityHelper.GetAllRoleNames();
                
                foreach(var roleName in roleNames)
                {
                    roleOptions.Add(new JobDetailsRolesOptions() { RoleName= roleName, IsChecked = false});
                }

                roleOptions.Add(new JobDetailsRolesOptions() { RoleName = "Anonymous", IsChecked = false });

                this.SerializedJobDetailsRoles = JsonConvert.SerializeObject(roleOptions);
            }
        }

        public bool IsJobApplyAvailable()
        {
            List<string> roles = SitefinityHelper.GetCurrentUserRoles();
            var roleOptions = JsonConvert.DeserializeObject<List<JobDetailsRolesOptions>>(this.SerializedJobDetailsRoles);
            List<string> selectedRoles = new List<string>();
            foreach(var roleOpt in roleOptions)
            {
                if (roleOpt.IsChecked == true)
                    selectedRoles.Add(roleOpt.RoleName);
            }
            if(roles.Intersect(selectedRoles).Any())
                return true;
         
            foreach(var roleOpt in roleOptions)
            {
                if (roleOpt.RoleName == "Anonymous" && roleOpt.IsChecked == true)
                    return true;
            }

            return false;
        }

        public virtual string SerializedJobDetailsRoles { get; set; }
    }
}
