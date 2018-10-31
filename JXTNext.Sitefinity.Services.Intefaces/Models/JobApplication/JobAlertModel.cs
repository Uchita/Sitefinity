using JXTNext.FileHandler.FileHandlerServices.Dropbox;
using JXTNext.FileHandler.Models.Dropbox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Workflow;

namespace JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert
{
    public class JobAlertViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool EmailAlerts { get; set; }
        public long LastModifiedTime { get; set; }
        public string Keywords { get; set; }
        public List<JobAlertFilters> Filters { get; set; }
        public string SalaryStringify { get; set; }
        public JobAlertSalaryFilterReceiver Salary { get; set; }
        public JobAlertStatus Status { get; set; }
    }

    public class CreateAsJobAlertFilterModel
    {
        public string Keywords { get; set; }
        public List<JobAlertFilters> Filters { get; set; }
        public JobAlertSalaryFilterReceiver Salary { get; set; }
    }

    public class JobAlertFilters
    {
        public string RootId { get; set; }
        public List<string> Values { get; set; }
    }

    public class JobAlertEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool EmailAlerts { get; set; }
        public string Keywords { get; set; }
        public JobAlertSalaryFilterReceiver Salary { get; set; }
        public List<JobAlertEditFilterRootItem> Data { get; set; }
    }

    public class JobAlertEditFilterRootItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<JobAlertEditFilterItem> Filters { get; set; }
    }

    public class JobAlertEditFilterItem
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public bool Selected { get; set; }
        public List<JobAlertEditFilterItem> Filters { get; set; }
    }

    public class JobAlertSalaryFilterReceiver
    {
        public string RootName { get; set; }
        public string TargetValue { get; set; }
        public int UpperRange { get; set; }
        public int LowerRange { get; set; }
    }

    public enum JobAlertStatus
    {
        AVAILABLE = 0,
        SUCCESS = 1,
        CREATE_FAILED = 2,
        UPDATE_FAILED = 3,
        DELETE_FAILED = 4
    }
}
