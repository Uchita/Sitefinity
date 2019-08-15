using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXTNext.Sitefinity.SalarySurvey.Database.Models
{
    [Table("SalaryMotivator")]
    public class SalaryMotivator
    {
        [Key]
        [Column(Order = 1)]
        public long SalaryId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid MotivatorId { get; set; }

        public int? Position { get; set; }
    }
}
