using System;
using System.ComponentModel.DataAnnotations;
using JXTNext.Sitefinity.SalarySurvey.Helpers;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SearchSalaryFormModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = FormHelper.RequiredFieldMessage)]
        public Guid JobTypeId { get; set; }

        [StringLength(255)]
        public string JobTitle { get; set; }

        public Guid? CountryId { get; set; }

        public Guid? LocationId { get; set; }

        public Guid? IndustryId { get; set; }

        public Guid? ClassificationId { get; set; }

        public Guid? SubClassificationId { get; set; }

        public Guid? YearsOfExperienceId { get; set; }

        public string SalarySurveyAction { get; set; }

        public int StartSalaryId { get; set; }

        public int EndSalaryId { get; set; }
    }
}
