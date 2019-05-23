using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.StringResources
{
    [ObjectInfo(typeof(MemberSavedJobsResources), ResourceClassId = "MemberSavedJobsResources", Title = "MemberSavedJobsResourcesTitle", Description = "MemberSavedJobsResourcesDescription")]
    public class MemberSavedJobsResources : Resource
    {
        #region Constructions

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        public MemberSavedJobsResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public MemberSavedJobsResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets phrase: Where to display details
        /// </summary>
        [ResourceEntry("DisplayJobDetails",
            Value = "Where to display details of the saved job?",
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
        /// Gets phrase: Saved Jobs' Title
        /// </summary>
        [ResourceEntry("SavedJobs",
            Value = "Saved jobs",
            Description = "word : Saved jobs title")]
        public string SavedJobs
        {
            get
            {
                return this["SavedJobs"];
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
        /// Gets phrase: Actions Title
        /// </summary>
        [ResourceEntry("Actions",
            Value = "Actions",
            Description = "word : Actions Title")]
        public string Actions
        {
            get
            {
                return this["Actions"];
            }
        }

        /// <summary>
        /// Gets phrase: No Saved Jobs Message
        /// </summary>
        [ResourceEntry("NoSavedJobs",
            Value = "You currently don't have any saved jobs",
            Description = "word : No saved jobs message")]
        public string NoSavedJobs
        {
            get
            {
                return this["NoSavedJobs"];
            }
        }

        /// <summary>
        /// Gets phrase: Remove confirmation message
        /// </summary>
        [ResourceEntry("RemoveConfirm",
            Value = "Are you sure you want to remove this saved job?",
            Description = "word : Remove confirmation message")]
        public string RemoveConfirm
        {
            get
            {
                return this["RemoveConfirm"];
            }
        }

        #endregion
    }
}