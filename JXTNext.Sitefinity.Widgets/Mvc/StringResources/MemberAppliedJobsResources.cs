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

        #endregion
    }
}