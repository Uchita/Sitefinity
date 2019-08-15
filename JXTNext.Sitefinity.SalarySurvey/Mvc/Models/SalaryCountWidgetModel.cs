/**
 * Model class for the submit salary widget.
 */

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SalaryCountWidgetModel
    {
        public bool LastWeekSalariesEnabled { get; set; }
        public string LastWeekSalariesLabel { get; set; }

        public bool TotalSalariesEnabled { get; set; }
        public string TotalSalariesLabel { get; set; }
    }
}
