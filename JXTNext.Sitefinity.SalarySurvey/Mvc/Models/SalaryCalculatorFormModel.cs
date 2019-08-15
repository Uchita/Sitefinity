using System.ComponentModel.DataAnnotations;
using JXTNext.Sitefinity.SalarySurvey.Helpers;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SalaryCalculatorFormModel
    {
        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        [Range(1, 9999999, ErrorMessage = "Value should be between 1 and 9999999")]
        public int AnnualSalary { get; set; }

        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        [Range(1, 9999999, ErrorMessage = "Value should be between 1 and 9999999")]
        public int IncreasePerYear { get; set; }

        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        [Range(1, 999, ErrorMessage = "Value should be between 1 and 999")]
        public int Years { get; set; }

        [Range(0, 100, ErrorMessage = "Value should be between 0 and 100")]
        public decimal? SuperRate { get; set; }

        public string SalarySurveyAction { get; set; }
    }
}
