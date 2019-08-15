using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
Left columns as in MySQL DB
----------------------------------------
benefits	            varchar	    255
current_role_duration	tinyint	    3
last_salary_increase	float	    0
industry_id	            int	        10
ideal_salary	        int	        10
price_name	            int	        10
money_to_leave	        int	        10
gender	                char	    1
job_alert	            tinyint	    1
terms_and_conditions	tinyint	    1
*/

namespace JXTNext.Sitefinity.SalarySurvey.Database.Models
{
    [Table("Salary")]
    public class Salary
    {
        [Key]
        public long Id { get; set; }

        [Index("IX_SalaryAlert", 1)]
        public long SiteId { get; set; }

        [MaxLength(255)]
        public string JobTitle { get; set; }

        public Guid CountryId { get; set; }

        public Guid LocationId { get; set; }

        public Guid IndustryId { get; set; }

        public Guid ClassificationId { get; set; }

        public Guid SubClassificationId { get; set; }

        public Guid JobTypeId { get; set; }

        public Guid? YearsOfExperienceId { get; set; }

        public int? HourlyRate { get; set; }

        public int? AnnualSalary { get; set; }

        public bool SuperIncluded { get; set; }

        public int? SuperAmount { get; set; }

        public decimal? SuperPercentage { get; set; }

        public Guid? SectorId { get; set; }

        public Guid? EducationId { get; set; }

        [MaxLength(255)]
        public string PreviousCompany { get; set; }

        public string ReasonForLeaving { get; set; }

        [MaxLength(255)]
        public string CurrentCompany { get; set; }

        public Guid? EmployerSizeId { get; set; }

        public Guid? PeopleManagedId { get; set; }

        public int? BonusAmount { get; set; }

        public int? MoneyToLeave { get; set; }

        public bool ProfessionalQualification { get; set; }

        public bool JobAlert { get; set; }

        [Index("IX_SalaryAlert", 3)]
        public bool SalaryAlert { get; set; }

        public bool ContactRequest { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        public Guid? GenderId { get; set; }

        [DefaultValue("false")]
        [Index("IX_SalaryAlert", 2)]
        public bool Verified { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? AlertSentDate { get; set; }

        public long? AlertLastSalaryId { get; set; }

        public virtual Site Site { get; set; }

        public IList<SalaryBenefit> Benefits { get; set; }

        public IList<SalaryBenefitOther> OtherBenefits { get; set; }

        public IList<SalaryMotivator> Motivators { get; set; }

        public IList<SalaryMotivatorOther> OtherMotivators { get; set; }

        public IList<SalaryBestEmployer> BestEmployers { get; set; }

        public IList<SalaryCareerMove> CareerMoves { get; set; }
    }
}
