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

        #endregion
    }
}