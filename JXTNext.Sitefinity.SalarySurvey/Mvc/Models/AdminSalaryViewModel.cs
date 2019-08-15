using System.Collections.Generic;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class AdminSalaryViewModel
    {       
        public SalaryDetailsModel Salary { get; set; }

        public List<SalaryDetailsModel> Salaries { get; set; } = new List<SalaryDetailsModel>();
        public int StartRecord { get; set; }
        public int EndRecord { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public string CurrentPageUrl { get; set; }

        public AdminSalaryWidgetModel Widget { get; set; }
    }
}
