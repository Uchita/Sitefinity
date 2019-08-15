using System.ComponentModel.DataAnnotations;
using JXTNext.Sitefinity.SalarySurvey.Helpers;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class SearchResultBenefitModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Records { get; set; }
        public decimal Percentage { get; set; }
    }
}
