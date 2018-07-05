using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.JobApplication.Mvc.Models.JobApplication
{
    public enum JobApplicationStatus
    {
        Available = 1,
        NotAvailable = 2,
        Applied_Successful = 3,
        Already_Applied = 4,
        Technical_Issue = 5
    }
}
