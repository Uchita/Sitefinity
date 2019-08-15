using System.Collections.Generic;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class GenericAjaxResponseModel
    {
        public const string Global = "global";

        public bool success;
        public Dictionary<string, List<string>> messages;
        public int records;
        public int imported;
    }
}
