using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.StringResources
{
    [ObjectInfo(typeof(MemberAppliedJobsResources), ResourceClassId = "MemberAppliedJobsResources", Title = "MemberAppliedJobsResourcesTitle", Description = "MemberAppliedJobsResourcesDescription")]
    public class MemberAppliedJobsResources : Resource
    {
        #region Constructions

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        public MemberAppliedJobsResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public MemberAppliedJobsResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets phrase: Where to display details
        /// </summary>
        [ResourceEntry("DisplayJobDetails",
            Value = "Where to display details of the applied job?",
            Description = "phrase : Where to display details of the job")]
        public string DisplayJobDetails
        {
            get
            {
                return this["DisplayJobDetails"];
            }
        }

        /// <summary>
        /// Gets phrase: Where to display details
        /// </summary>
        [ResourceEntry("SelectDetailsPage",
            Value = "Select Job Details Page",
            Description = "phrase : Select Job Details Page")]
        public string SelectDetailsPage
        {
            get
            {
                return this["SelectDetailsPage"];
            }
        }

        /// <summary>
        /// Gets phrase: Applied Jobs' Title
        /// </summary>
        [ResourceEntry("AppliedJobs",
            Value = "Applied jobs",
            Description = "word : Applied jobs title")]
        public string AppliedJobs
        {
            get
            {
                return this["AppliedJobs"];
            }
        }

        /// <summary>
        /// Gets phrase: Job ID
        /// </summary>
        [ResourceEntry("JobId",
            Value = "Job ID",
            Description = "word : Job Id title")]
        public string JobId
        {
            get
            {
                return this["JobId"];
            }
        }

        /// <summary>
        /// Gets phrase: Job Title
        /// </summary>
        [ResourceEntry("JobTitle",
            Value = "Job Title",
            Description = "word : Job Title")]
        public string JobTitle
        {
            get
            {
                return this["JobTitle"];
            }
        }

        /// <summary>
        /// Gets phrase: Date Added
        /// </summary>
        [ResourceEntry("DateAdded",
            Value = "Date Added",
            Description = "word : Date Added")]
        public string DateAdded
        {
            get
            {
                return this["DateAdded"];
            }
        }

        /// <summary>
        /// Gets phrase: No Applied Jobs Message
        /// </summary>
        [ResourceEntry("NoAppliedJobMsg",
            Value = "You currently don't have any applied jobs",
            Description = "word : No applied jobs message")]
        public string NoAppliedJobMsg
        {
            get
            {
                return this["NoAppliedJobMsg"];
            }
        }

        #endregion
    }
}