using System.Collections.Generic;
using System.Web.Mvc;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SearchSalaryViewModel
    {
        public string CurrencySymbol { get; set; }
        public bool AnnualSalary { get; set; } = true;
        public bool ShowResult { get; set; } = false;
        public string EditSearchUrl { get; set; }
        public string SalaryLabel { get; set; } = "Annual Salary";

        public string JobType { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Industry { get; set; }
        public string Classification { get; set; }
        public string SubClassification { get; set; }
        public string YearsOfExperience { get; set; }

        public int Records { get; set; }
        public int MedianMin { get; set; }
        public int MedianLower { get; set; }
        public int Median { get; set; }
        public int MedianUpper { get; set; }
        public int MedianMax { get; set; }
        public int MedianBonus { get; set; }
        public int MedianSuper { get; set; }
        public int PackageMedian { get; set; }
        public int MedianMoneyToLeave { get; set; }
        public decimal PeopleWithBonus { get; set; }
        public decimal PeopleWithSuper { get; set; }

        public Dictionary<string, SearchResultBenefitModel> BenefitPercentages { get; set; } = new Dictionary<string, SearchResultBenefitModel>();
        public List<SearchResultProfileModel> LatestSalaries { get; set; } = new List<SearchResultProfileModel>();

        public List<SelectListItem> JobTypeList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> LocationList { get; set; }
        public List<SelectListItem> IndustryList { get; set; }
        public List<SelectListItem> ClassificationList { get; set; }
        public List<SelectListItem> SubClassificationList { get; set; }
        public List<SelectListItem> YearsOfExperienceList { get; set; }

        public SearchSalaryWidgetModel Widget { get; set; }
        public SearchSalaryFormModel Form { get; set; }
    }
}
