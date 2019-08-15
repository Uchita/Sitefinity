using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXTNext.Sitefinity.SalarySurvey.Database.Models
{
    [Table("SalaryMotivatorOther")]
    public class SalaryMotivatorOther
    {
        [Key]
        public long Id { get; set; }

        public long SalaryId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public int? Position { get; set; }
    }
}
