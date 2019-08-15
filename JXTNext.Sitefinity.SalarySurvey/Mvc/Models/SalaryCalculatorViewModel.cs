using System.Collections.Generic;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SalaryCalculatorViewModel
    {
        public string CurrencySymbol { get; set; }
        public bool ShowResult { get; set; } = false;

        public decimal ExtraSalary { get; set; }
        public decimal ExtraSuper { get; set; }
        public List<SalaryCalculatorResultModel> Result { get; set; } = new List<SalaryCalculatorResultModel>();

        public SalaryCalculatorWidgetModel Widget { get; set; }
        public SalaryCalculatorFormModel Form { get; set; }
    }
}
