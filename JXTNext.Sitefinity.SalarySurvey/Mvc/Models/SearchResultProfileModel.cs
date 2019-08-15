using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JXTNext.Sitefinity.SalarySurvey.Helpers;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SearchResultProfileModel
    {
        public string ProfileTitle { get; set; }

        public string JobTitle { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Industry { get; set; }
        public string Classification { get; set; }
        public string SubClassification { get; set; }
        public string JobType { get; set; }
        public int? Remuneration { get; set; }
        public int? HourlyRate { get; set; }
        public int? AnnualSalary { get; set; }
        public int? SuperAmount { get; set; }
        public int? BonusAmount { get; set; }
        public string YearsOfExperience { get; set; }
        public bool ProfessionalQualification { get; set; }
        public string Education { get; set; }
        public string PeopleManaged { get; set; }
        public string EmployerSize { get; set; }
        public int? MoneyToLeave { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Benefits { get; set; } = new List<string>();

    }
}
