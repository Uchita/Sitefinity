using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources
{
    [ObjectInfo(typeof(JobFiltersResources), ResourceClassId = "JobFiltersResources", Title = "JobFiltersResourcesTitle", Description = "JobFiltersResourcesDescription")]
    public class JobFiltersResources : Resource
    {
        #region Constructions

        /// <summary>
        /// Initializes a new instance of the <see cref="JobFiltersResources" /> class.
        /// </summary>
        public JobFiltersResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobFiltersResources" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public JobFiltersResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets phrase: Classifications'label text?
        /// </summary>
        [ResourceEntry("Classifications",
            Value = "Classifications",
            Description = "word : Classifications'label text")]
        public string Classifications
        {
            get
            {
                return this["Classifications"];
            }
        }

        /// <summary>
        /// Gets phrase: Keywords' label text?
        /// </summary>
        [ResourceEntry("Keywords",
            Value = "Keywords",
            Description = "word : Keywords' label text")]
        public string Keywords
        {
            get
            {
                return this["Keywords"];
            }
        }

        /// <summary>
        /// Gets phrase: Location's label text?
        /// </summary>
        [ResourceEntry("Location",
            Value = "Location",
            Description = "word : Location's label text")]
        public string Location
        {
            get
            {
                return this["Location"];
            }
        }

        /// <summary>
        /// Gets phrase: Work type's label text?
        /// </summary>
        [ResourceEntry("WorkType",
            Value = "Work Type",
            Description = "word : Work type's label text")]
        public string WorkType
        {
            get
            {
                return this["WorkType"];
            }
        }
        
        #endregion
    }
}