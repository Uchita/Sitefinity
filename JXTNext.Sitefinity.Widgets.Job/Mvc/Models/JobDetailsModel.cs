using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobDetailsViewModel
    {
        public dynamic JobDetails { get; set; }
        public bool JobApplyAvailable { get; set; }
    }

    public class JobDetailsRolesOptions
    {
        public string RoleName { get; set; }
        public bool IsChecked { get; set; }
    }
}
