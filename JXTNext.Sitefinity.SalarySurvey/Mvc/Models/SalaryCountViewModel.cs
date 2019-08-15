using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SalaryCountViewModel
    {
        public int LastWeekSalaries { get; set; }
        public int TotalSalaries { get; set; }

        public SalaryCountWidgetModel Widget { get; set; }
    }
}
