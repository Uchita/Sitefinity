using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int AdvertiserUserId { get; set; }
        public long DateCreated { get; set; }
        public string DateCreated_Representation { get => DateCreated == 0 ? string.Empty : ConversionHelper.GetDateTimeFromUnix(DateCreated).ToShortDateString(); }
        public long? ExpiryDate { get; set; }
        public int Status { get; set; }
        public string Address { get; set; }
        public float AddressLatitude { get; set; }
        public float AddressLongtitude { get; set; }
        public OrderedDictionary Classifications { get; set; }
        public string ClassificationsRootName { get; set; }
        public string ClassificationsSEORouteName { get; set; }

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
