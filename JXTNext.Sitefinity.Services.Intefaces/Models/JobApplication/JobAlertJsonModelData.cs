using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Services.Intefaces.Models.JobAlertJson
{
    public class SearchModel
    {
        public JobAlertJsonModelData search { get; set; }
        public JobAlertViewModel jobAlertViewModelData { get; set; }
    }
    public class JobAlertJsonModelData
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public dynamic FieldSearches { get; set; }
        public dynamic FieldRanges { get; set; }
        public List<KeywordSearchJson> KeywordsSearchCriteria { get; set; } = new List<KeywordSearchJson>();
        public ConsultantSearchJson ConsultantSearchCriteria { get; set; }
        public List<Classification_CategorySearchJson> ClassificationsSearchCriteria { get; set; } = new List<Classification_CategorySearchJson>();

        public SearchSortByJson SortBy { get; set; }

        public bool IsLegacyJobSource { get; set; }
    }

    public enum ClassificationSearchTypeJson
    {
        Undefined,
        Categories,
        Range,
        RefNo
    }

    public interface IClassificationSearchJson
    {
        ClassificationSearchTypeJson SearchType { get; }
    }


    public enum SearchSortByJson
    {
        Recent,
        Oldest,
        A_to_Z,
        Z_to_A,
        Salary_High_to_Low,
        Salary_Low_to_High
    }

    public class KeywordSearchJson
    {
        public string Keyword { get; set; }
    }

    public class ConsultantSearchJson
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Classification_CategorySearchJson
    {
        public string SearchType { get; set; }
        public string ClassificationRootName { get; set; }
        public List<Classification_CategorySearchTargetJson> TargetClassifications { get; set; }
        public string ClassificationRootID { get; set; }
        public int UpperRange { get; set; }
        public int LowerRange { get; set; }
    }

    public class Classification_CategorySearchTargetJson
    {
        public string TargetValue { get; set; }
        public List<Classification_CategorySearchTargetJson> SubTargets { get; set; }
    }
}
