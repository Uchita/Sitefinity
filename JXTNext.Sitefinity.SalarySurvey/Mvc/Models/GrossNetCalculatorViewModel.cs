using System.Collections.Generic;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class GrossNetCalculatorViewModel
    {
        public string CurrencySymbol { get; set; }
        public bool ShowResult { get; set; } = false;
        public decimal SuperRate { get; set; }
        public decimal MedicareRate { get; set; }
        public int WeeklyHours { get; set; }
        public Dictionary<int, decimal> TaxBrackets { get; set; }

        public decimal HourlyBeforeTax { get; set; }
        public decimal HourlyTax { get; set; }
        public decimal HourlyMedicare { get; set; }
        public decimal HourlySuper { get; set; }
        public decimal HourlyAfterTax { get; set; }

        public decimal WeeklyBeforeTax { get; set; }
        public decimal WeeklyTax { get; set; }
        public decimal WeeklyMedicare { get; set; }
        public decimal WeeklySuper { get; set; }
        public decimal WeeklyAfterTax { get; set; }

        public decimal FortnightlyBeforeTax { get; set; }
        public decimal FortnightlyTax { get; set; }
        public decimal FortnightlyMedicare { get; set; }
        public decimal FortnightlySuper { get; set; }
        public decimal FortnightlyAfterTax { get; set; }

        public decimal MonthlyBeforeTax { get; set; }
        public decimal MonthlyTax { get; set; }
        public decimal MonthlyMedicare { get; set; }
        public decimal MonthlySuper { get; set; }
        public decimal MonthlyAfterTax { get; set; }

        public decimal YearlyBeforeTax { get; set; }
        public decimal YearlyTax { get; set; }
        public decimal YearlyMedicare { get; set; }
        public decimal YearlySuper { get; set; }
        public decimal YearlyAfterTax { get; set; }

        public GrossNetCalculatorWidgetModel Widget { get; set; }
        public GrossNetCalculatorFormModel Form { get; set; }
    }
}
