using System;

namespace JXTNext.Sitefinity.SalarySurvey.Database.Models
{
    public class SearchResult
    {
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }
        public int Records { get; set; }
        public Guid BenefitId { get; set; }
    }
}
