using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.SalarySurvey
{
    /// <summary>
    /// Localizable strings for the SalarySurvey module
    /// </summary>
    [ObjectInfo("SalarySurveyResources", ResourceClassId = "SalarySurveyResources", Title = "SalarySurveyResourcesTitle", TitlePlural = "SalarySurveyResourcesTitlePlural", Description = "SalarySurveyResourcesDescription")]
    public class SalarySurveyResources : Resource
    {
        #region Construction
        
        /// <summary>
        /// Initializes new instance of <see cref="SalarySurveyResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public SalarySurveyResources()
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="SalarySurveyResources"/> class with the provided <see cref="ResourceDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider"><see cref="ResourceDataProvider"/></param>
        public SalarySurveyResources(ResourceDataProvider dataProvider) : base(dataProvider)
        {
        }
        
        #endregion

        #region Class Description
        
        /// <summary>
        /// SalarySurvey Resources
        /// </summary>
        [ResourceEntry("SalarySurveyResourcesTitle",
            Value = "SalarySurvey module labels",
            Description = "The title of this class.",
            LastModified = "2018/10/10")]
        public string SalarySurveyResourcesTitle
        {
            get
            {
                return this["SalarySurveyResourcesTitle"];
            }
        }

        /// <summary>
        /// SalarySurvey Resources Title plural
        /// </summary>
        [ResourceEntry("SalarySurveyResourcesTitlePlural",
            Value = "SalarySurvey module labels",
            Description = "The title plural of this class.",
            LastModified = "2018/10/10")]
        public string SalarySurveyResourcesTitlePlural
        {
            get
            {
                return this["SalarySurveyResourcesTitlePlural"];
            }
        }

        /// <summary>
        /// Contains localizable resources for SalarySurvey module.
        /// </summary>
        [ResourceEntry("SalarySurveyResourcesDescription",
            Value = "Contains localizable resources for SalarySurvey module.",
            Description = "The description of this class.",
            LastModified = "2018/10/10")]
        public string SalarySurveyResourcesDescription
        {
            get
            {
                return this["SalarySurveyResourcesDescription"];
            }
        }

        #endregion
    }
}
