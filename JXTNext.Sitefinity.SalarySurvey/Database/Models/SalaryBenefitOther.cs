using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXTNext.Sitefinity.SalarySurvey.Database.Models
{
    [Table("SalaryBenefitOther")]
    public class SalaryBenefitOther
    {
        [Key]
        public long Id { get; set; }

        public long SalaryId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }
    }
}
