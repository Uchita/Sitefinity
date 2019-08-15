using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SubmitSalaryViewModel
    {
        public int MaxAnnualMoneyToLeave { get; set; }
        public int MaxHourlyMoneyToLeave { get; set; }
        public string CurrencySymbol { get; set; }

        public SubmitSalaryWidgetModel Widget { get; set; }
        public SubmitSalaryFormModel Form { get; set; }

        public List<SelectListItem> LocationList { get; set; }
        public List<SelectListItem> ClassificationList { get; set; }
        public List<SelectListItem> SubClassificationList { get; set; }
        public List<SelectListItem> JobTypesList { get; set; }
        public List<SelectListItem> YearsOfExperienceList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> GenderList { get; set; }
        public List<SelectListItem> EmployerSizeList { get; set; }
        public List<SelectListItem> PeopleManagedList { get; set; }
        public List<SelectListItem> BenefitList { get; set; }
        public List<SelectListItem> IndustryList { get; set; }
        public List<SelectListItem> MotivatorList { get; set; }
        public List<SelectListItem> CareerMoveList { get; set; }
        public List<SelectListItem> EducationList { get; set; }

        public List<Guid> AnnualSalaryJobTypeList { get; set; }

        public bool AnnualSalariesDropdown { get; set; }
        public List<SelectListItem> AnnualSalariesList { get; set; }

        public bool HourlyRatesDropdown { get; set; }
        public List<SelectListItem> HourlyRatesList { get; set; }

        public bool BonusAmountsDropdown { get; set; }
        public List<SelectListItem> BonusAmountsList { get; set; }

    }
}
