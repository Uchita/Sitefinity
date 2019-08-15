namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class GrossNetCalculatorWidgetModel
    {
        public string Heading { get; set; }
        public string Introduction { get; set; }

        public string SalaryLabel { get; set; }
        public string SalaryHelp { get; set; }

        public string MedicareLabel { get; set; }
        public string MedicareHelp { get; set; }

        public string SuperannuationLabel { get; set; }
        public string SuperannuationHelp { get; set; }

        public string WeeklyHoursLabel { get; set; }
        public string WeeklyHoursHelp { get; set; }

        public string PayeLabel { get; set; }
        public string PayeHelp { get; set; }

        public string TaxThresholdLabel { get; set; }

        public string TaxRateLabel { get; set; }

        public string ResultPage { get; set; }

        public bool ShowOptions { get; set; }
        public bool ShowMoreLess { get; set; }

        public string SubmitButtonLabel { get; set; }
    }
}
