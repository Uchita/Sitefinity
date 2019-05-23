using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.StringResources
{
    /// <summary>
    /// Localizable strings for the Blog widget
    /// </summary>
    [ObjectInfo(typeof(AddThisResources), ResourceClassId = "AddThisResources", Title = "AddThisResourcesTitle", Description = "AddThisResourcesDescription")]
    public class AddThisResources : Resource
    {
        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogListResources"/> class. 
        /// Initializes new instance of <see cref="BlogListResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public AddThisResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogListResources"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public AddThisResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        
        #endregion

        #region Meta resources
        
        /// <summary>
        /// Title for the AddThis widget resources class.
        /// </summary>
        [ResourceEntry("AddThisResourcesTitle",
            Value = "AddThis widget resources",
            Description = "Title for the AddThis widget resources class.",
            LastModified = "2015/09/22")]
        public string AddThisResourcesTitle
        {
            get
            {
                return this["AddThisResourcesTitle"];
            }
        }

        /// <summary>
        /// Description for the AddThis widget resources class
        /// </summary>
        [ResourceEntry("AddThisResourcesDescription",
            Value = "Localizable strings for the AddThis widget.",
            Description = "Description for the AddThis widget resources class",
            LastModified = "2015/09/22")]
        public string AddThisResourcesDescription
        {
            get
            {
                return this["AddThisResourcesDescription"];
            }
        }

        #endregion

        /// <summary>
        /// phrase : AddThis Settings
        /// </summary>
        /// <value>AddThis Settings</value>
        [ResourceEntry("AddThisSettings",
            Value = "AddThis Settings",
            Description = "phrase : AddThis Settings",
            LastModified = "2019/05/22")]
        public string AddThisSettings
        {
            get
            {
                return this["AddThisSettings"];
            }
        }
        
        /// <summary>
        /// phrase : More options
        /// </summary>
        /// <value>More options</value>
        [ResourceEntry("MoreOptions",
            Value = "More options",
            Description = "phrase : More options",
            LastModified = "2015/09/22")]
        public string MoreOptions
        {
            get
            {
                return this["MoreOptions"];
            }
        }

        /// <summary>
        /// word: Template
        /// </summary>
        /// <value>Template</value>
        [ResourceEntry("Template",
            Value = "Template",
            Description = " word: Template",
            LastModified = "2015/09/22")]
        public string Template
        {
            get
            {
                return this["Template"];
            }
        }

        /// <summary>
        /// phrase : CSS classes
        /// </summary>
        /// <value>CSS classes</value>
        [ResourceEntry("CssClasses",
            Value = "CSS classes",
            Description = "phrase : CSS classes",
            LastModified = "2015/09/22")]
        public string CssClasses
        {
            get
            {
                return this["CssClasses"];
            }
        }

        /// <summary>
        /// phrase: Setup services
        /// </summary>
        /// <value>Setup services</value>
        [ResourceEntry("SetupServices",
            Value = "Setup services",
            Description = "phrase: Setup services",
            LastModified = "2019/05/20")]
        public string SetupServices
        {
            get
            {
                return this["SetupServices"];
            }
        }
    }
}
