using System.ComponentModel.DataAnnotations;
using JXTNext.Sitefinity.SalarySurvey.Helpers;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class GrossNetCalculatorFormModel
    {
        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        [Range(1, 9999999, ErrorMessage = "Value should be between 1 and 9999999")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        [Range(0, 100, ErrorMessage = "Value should be between 0 and 100")]
        public decimal MedicareRate { get; set; }

        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        [Range(0, 100, ErrorMessage = "Value should be between 0 and 100")]
        public decimal SuperRate { get; set; }

        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        [Range(0, 999, ErrorMessage = "Value should be between 1 and 999")]
        public decimal WeeklyHours { get; set; }

        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        public int[] TaxThresholds { get; set; }

        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        public decimal[] TaxRates { get; set; }

        public string SalarySurveyAction { get; set; }
    }
}
