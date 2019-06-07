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

        /// <summary>
        /// phrase: Facebook
        /// </summary>
        /// <value>Facebook</value>
        [ResourceEntry("FacebookLabel",
            Value = "Facebook",
            Description = "phrase: Facebook",
            LastModified = "2019/05/27")]
        public string FacebookLabel
        {
            get
            {
                return this["FacebookLabel"];
            }
        }

        /// <summary>
        /// phrase: Share on Facebook
        /// </summary>
        /// <value>Share on Facebook</value>
        [ResourceEntry("FacebookTitle",
            Value = "Share on Facebook",
            Description = "phrase: Share on Facebook",
            LastModified = "2019/05/27")]
        public string FacebookTitle
        {
            get
            {
                return this["FacebookTitle"];
            }
        }

        /// <summary>
        /// phrase: Twitter
        /// </summary>
        /// <value>Twitter</value>
        [ResourceEntry("TwitterLabel",
            Value = "Twitter",
            Description = "phrase: Twitter",
            LastModified = "2019/05/27")]
        public string TwitterLabel
        {
            get
            {
                return this["TwitterLabel"];
            }
        }

        /// <summary>
        /// phrase: Share on Twitter
        /// </summary>
        /// <value>Share on Twitter</value>
        [ResourceEntry("TwitterTitle",
            Value = "Share on Twitter",
            Description = "phrase: Share on Twitter",
            LastModified = "2019/05/27")]
        public string TwitterTitle
        {
            get
            {
                return this["TwitterTitle"];
            }
        }

        /// <summary>
        /// phrase: LinkedIn
        /// </summary>
        /// <value>LinkedIn</value>
        [ResourceEntry("LinkedInLabel",
            Value = "LinkedIn",
            Description = "phrase: LinkedIn",
            LastModified = "2019/05/27")]
        public string LinkedInLabel
        {
            get
            {
                return this["LinkedInLabel"];
            }
        }

        /// <summary>
        /// phrase: Share on LinkedIn
        /// </summary>
        /// <value>Share on LinkedIn</value>
        [ResourceEntry("LinkedInTitle",
            Value = "Share on LinkedIn",
            Description = "phrase: Share on LinkedIn",
            LastModified = "2019/05/27")]
        public string LinkedInTitle
        {
            get
            {
                return this["LinkedInTitle"];
            }
        }

        /// <summary>
        /// phrase: WeChat
        /// </summary>
        /// <value>WeChat</value>
        [ResourceEntry("WeChatLabel",
            Value = "WeChat",
            Description = "phrase: WeChat",
            LastModified = "2019/05/27")]
        public string WeChatLabel
        {
            get
            {
                return this["WeChatLabel"];
            }
        }

        /// <summary>
        /// phrase: Share on WeChat
        /// </summary>
        /// <value>Share on WeChat</value>
        [ResourceEntry("WeChatTitle",
            Value = "Share on WeChat",
            Description = "phrase: Share on WeChat",
            LastModified = "2019/05/27")]
        public string WeChatTitle
        {
            get
            {
                return this["WeChatTitle"];
            }
        }
    }
}
