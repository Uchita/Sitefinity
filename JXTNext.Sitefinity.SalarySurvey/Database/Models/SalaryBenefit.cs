using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXTNext.Sitefinity.SalarySurvey.Database.Models
{
    [Table("SalaryBenefit")]
    public class SalaryBenefit
    {
        [Key]
        [Column(Order = 1)]
        public long SalaryId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid BenefitId { get; set; }
    }
}
