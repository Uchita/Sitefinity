using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job
{
    public class JobDetailsModel
    {
        [JsonProperty(PropertyName = "id")]
        public int JobID { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "shortDescription")]
        public string ShortDescription { get; set; }
    }

    public class JobDetailsFullModel : JobDetailsModel
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        public List<JobFilterRoot> Filters { get; set; }
        public string ReferenceNo { get; set; }
        public Dictionary<string, string> CustomData { get; set; }

        public bool FakeSearch(string rootID, string ID)
        {
            JobFilterRoot targetRoot = Filters.Where(c => c.ID == rootID).FirstOrDefault();

            if (targetRoot == null)
                return false;

            return targetRoot.ContainsID(ID);
        }
    }
}
