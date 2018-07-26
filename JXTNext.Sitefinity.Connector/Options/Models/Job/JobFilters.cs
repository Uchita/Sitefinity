using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.Options.Models.Job
{
    public class JobFiltersData
    {
        public List<JobFilterRoot> Data { get; set; }
    }

    public class JobFilterRoot
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<JobFilter> Filters { get; set; }

        public bool ContainsID(string targetID)
        {
            foreach (JobFilter f in Filters)
            {
                if (f.ContainsID(targetID))
                    return true;
            }
            return false;
        }
    }

    public class JobFilter
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public int Count { get; set; }
        public bool Selected { get; set; }
        public List<JobFilter> Filters { get; set; }

        public bool ContainsID(string targetID)
        {
            if (targetID == ID)
                return true;

            if (Filters != null)
            {
                foreach (JobFilter f in Filters)
                {
                    return f.ContainsID(targetID);
                }
            }
            return false;
        }
    }


}