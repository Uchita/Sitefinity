using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace Jxt.Sitefinity.Jobs.Localization
{
    [ObjectInfo(typeof(JobsResources), Title = "JobsTitle", Description = "JobsDescription")]
    public class JobsResources : Resource
    {
        public JobsResources()
        { }

        public JobsResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        { }

        [ResourceEntry("JobsTitle",
                       Value = "Jobs",
                       Description = "The title of this class.",
                       LastModified = "2018/04/30")]
        public string JobsTitle
        {
            get
            {
                return this["JobsTitle"];
            }
        }

        [ResourceEntry("JobsDescription",
                       Value = "Contains localizable resources for Jobs module labels.",
                       Description = "The description of this class.",
                       LastModified = "2018/04/30")]
        public string JobsDescription
        {
            get
            {
                return this["JobsDescription"];
            }
        }

        [ResourceEntry("JobsTitlePlural",
            Value = "Jobs",
            Description = "The title plural of this class.",
            LastModified = "2018/04/30")]
        public string JobsTitlePlural
        {
            get
            {
                return this["JobsTitlePlural"];
            }
        }
    }
}