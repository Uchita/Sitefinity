using JXTNext.Sitefinity.Connector.Options.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job
{
    public class JobDetailsModel
    {
        public string JobID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
    }

    public class JobDetailsFullModel : JobDetailsModel
    {
        public string Description { get; set; }
        public List<JobFilterRoot> Filters { get; set; }

        public bool FakeSearch(string rootID, string ID)
        {
            JobFilterRoot targetRoot = Filters.Where(c => ID == rootID).FirstOrDefault();

            if (targetRoot == null)
                return false;

            return targetRoot.ContainsID(ID);
        }
    }
}
