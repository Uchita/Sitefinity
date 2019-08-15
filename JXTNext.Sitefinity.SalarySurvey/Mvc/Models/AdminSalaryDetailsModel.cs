using System;
using System.Collections.Generic;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SalaryDetailsModel
    {
        public long Id { get; set; }
        public string JobTitle { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Industry { get; set; }
        public string Classification { get; set; }
        public string SubClassification { get; set; }
        public string JobType { get; set; }
        public string YearsOfExperience { get; set; }
        public int? HourlyRate { get; set; }
        public int? AnnualSalary { get; set; }
        public bool SuperIncluded { get; set; }
        public int? SuperAmount { get; set; }
        public decimal? SuperPercentage { get; set; }
        public string Sector { get; set; }
        public string Education { get; set; }
        public string PreviousCompany { get; set; }
        public string ReasonForLeaving { get; set; }
        public string CurrentCompany { get; set; }
        public string EmployerSize { get; set; }
        public string PeopleManaged { get; set; }
        public int? BonusAmount { get; set; }
        public int? MoneyToLeave { get; set; }
        public bool ProfessionalQualification { get; set; }
        public bool JobAlert { get; set; }
        public bool SalaryAlert { get; set; }
        public bool ContactRequest { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public bool Verified { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<string> Benefits { get; set; } = new List<string>();
        public List<string> OtherBenefits { get; set; } = new List<string>();
        public List<string> Motivators { get; set; } = new List<string>();
        public List<string> OtherMotivators { get; set; } = new List<string>();
        public List<string> BestEmployers { get; set; } = new List<string>();
        public List<string> CareerMoves { get; set; } = new List<string>();
    }
}
