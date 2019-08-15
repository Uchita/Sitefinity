using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JXTNext.Sitefinity.SalarySurvey.Helpers;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SubmitSalaryFormModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = FormHelper.RequiredFieldMessage)]
        public Guid CountryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = FormHelper.RequiredFieldMessage)]
        public Guid LocationId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = FormHelper.RequiredFieldMessage)]
        public Guid IndustryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = FormHelper.RequiredFieldMessage)]
        public Guid ClassificationId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = FormHelper.RequiredFieldMessage)]
        public Guid SubClassificationId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = FormHelper.RequiredFieldMessage)]
        public Guid JobTypeId { get; set; }

        [Range(0, 9999999, ErrorMessage = "Value should be between 0 and 9999999")]
        public int? AnnualSalary { get; set; }

        public Guid? AnnualSalaryId { get; set; }

        [Range(0, 9999, ErrorMessage = "Value should be between 0 and 9999")]
        public int? HourlyRate { get; set; }

        public Guid? HourlyRateId { get; set; }

        [Range(0, 9999999, ErrorMessage = "Value should be between 0 and 9999999")]
        public int? BonusAmount { get; set; }

        public Guid? BonusAmountId { get; set; }

        public Guid[] BenefitId { get; set; } = new Guid[0];

        [StringLength(1000)]
        public string BenefitOther { get; set; }

        public Dictionary<string, int?> MotivatorOrder { get; set; } = new Dictionary<string, int?>();

        [StringLength(1000)]
        public string MotivatorOther { get; set; }

        public bool ProfessionalQualification { get; set; }

        public Guid? EducationId { get; set; }

        public Guid? YearsOfExperienceId { get; set; }

        public Guid? PeopleManagedId { get; set; }

        public Guid? EmployerSizeId { get; set; }

        public Guid? GenderId { get; set; }

        [Range(-1, int.MaxValue, ErrorMessage = "Invalid value")]
        public int? MoneyToLeave { get; set; }

        public List<string> BestEmployer { get; set; } = new List<string>();

        public Guid[] CareerMoveId { get; set; } = new Guid[0];

        public bool JobAlert { get; set; }

        public bool SalaryAlert { get; set; }

        public bool ContactRequest { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        public string SalarySurveyAction { get; set; }
    }
}
