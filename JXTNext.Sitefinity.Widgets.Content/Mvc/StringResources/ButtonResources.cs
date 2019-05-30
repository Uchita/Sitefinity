using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources
{
    /// <summary>
    /// Localizable strings for the Blog widget
    /// </summary>
    [ObjectInfo(typeof(ButtonResources), ResourceClassId = "ButtonResources", Title = "ButtonResourcesTitle", Description = "ButtonResourcesDescription")]
    public class ButtonResources : Resource
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogListResources"/> class. 
        /// Initializes new instance of <see cref="BlogListResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public ButtonResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogListResources"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public ButtonResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Meta resources
        /// <summary>
        /// Title for the Button widget resources class.
        /// </summary>
        [ResourceEntry("ButtonResourcesTitle",
            Value = "Button widget resources",
            Description = "Title for the Button widget resources class.",
            LastModified = "2015/09/22")]
        public string ButtonResourcesTitle
        {
            get
            {
                return this["ButtonResourcesTitle"];
            }
        }

        /// <summary>
        /// Description for the Button widget resources class
        /// </summary>
        [ResourceEntry("ButtonResourcesDescription",
            Value = "Localizable strings for the Button widget.",
            Description = "Description for the Button widget resources class",
            LastModified = "2015/09/22")]
        public string ButtonResourcesDescription
        {
            get
            {
                return this["ButtonResourcesDescription"];
            }
        }
        #endregion

        /// <summary>
        /// phrase : Create Button
        /// </summary>
        /// <value>Create Button</value>
        [ResourceEntry("CreateButton",
            Value = "Set button text and link",
            Description = "phrase : Set button text and link",
            LastModified = "2019/05/07")]
        public string CreateButton
        {
            get
            {
                return this["CreateButton"];
            }
        }

        /// <summary>
        /// phrase : Label
        /// </summary>
        /// <value>Label</value>
        [ResourceEntry("ButtonText",
            Value = "Button Text",
            Description = "phrase : Button Text",
            LastModified = "2019/05/07")]
        public string ButtonText
        {
            get
            {
                return this["ButtonText"];
            }
        }

        /// <summary>
        /// phrase : Alignment
        /// </summary>
        /// <value>Alignment</value>
        [ResourceEntry("ButtonAlignment",
            Value = "Alignment",
            Description = "phrase : Alignment",
            LastModified = "2019/04/29")]
        public string ButtonAlignment
        {
            get
            {
                return this["ButtonAlignment"];
            }
        }

        /// <summary>
        /// phrase : Expanded
        /// </summary>
        /// <value>Expanded</value>
        [ResourceEntry("Expanded",
            Value = "Expanded",
            Description = "phrase : Expanded",
            LastModified = "2019/04/29")]
        public string Expanded
        {
            get
            {
                return this["Expanded"];
            }
        }

        /// <summary>
        /// word : Size
        /// </summary>
        /// <value>Expanded</value>
        [ResourceEntry("Size",
            Value = "Size",
            Description = "word : Size",
            LastModified = "2019/04/29")]
        public string Size
        {
            get
            {
                return this["Size"];
            }
        }

        /// <summary>
        /// phrase : Style
        /// </summary>
        /// <value>Style</value>
        [ResourceEntry("ButtonStyle",
            Value = "Style",
            Description = "phrase : Style",
            LastModified = "2019/04/29")]
        public string ButtonStyle
        {
            get
            {
                return this["ButtonStyle"];
            }
        }

        /// <summary>
        /// phrase : Colour
        /// </summary>
        /// <value>Colour</value>
        [ResourceEntry("ButtonColour",
            Value = "Colour",
            Description = "phrase : Colour",
            LastModified = "2019/04/29")]
        public string ButtonColour
        {
            get
            {
                return this["ButtonColour"];
            }
        }

        /// <summary>
        /// phrase: Example: Learn more
        /// </summary>
        /// <value>Example: Learn more</value>
        [ResourceEntry("LearnMore",
            Value = "Example: Learn more",
            Description = "phrase: Example: Learn more",
            LastModified = "2015/10/06")]
        public string LearnMore
        {
            get
            {
                return this["LearnMore"];
            }
        }

        /// <summary>
        /// phrase: Page within the site...
        /// </summary>
        /// <value>Page within the site...</value>
        [ResourceEntry("PageWithinLabel",
            Value = "Page within the site...",
            Description = "phrase: Page within the site...",
            LastModified = "2015/10/06")]
        public string PageWithinLabel
        {
            get
            {
                return this["PageWithinLabel"];
            }
        }

        /// <summary>
        /// phrase: External URL...
        /// </summary>
        /// <value>External URL...</value>
        [ResourceEntry("ExternalUrlLabel",
            Value = "External URL...",
            Description = "phrase: External URL...",
            LastModified = "2015/10/06")]
        public string ExternalUrlLabel
        {
            get
            {
                return this["ExternalUrlLabel"];
            }
        }

        /// <summary>
        /// phrase: Example: https://www.progress.com/sitefinity-cms
        /// </summary>
        /// <value>Example: https://www.progress.com/sitefinity-cms</value>
        [ResourceEntry("ExternalUrlExample",
            Value = "Example: https://www.progress.com/sitefinity-cms",
            Description = "phrase: Example: https://www.progress.com/sitefinity-cms",
            LastModified = "2018/10/12")]
        public string ExternalUrlExample
        {
            get
            {
                return this["ExternalUrlExample"];
            }
        }

        /// <summary>
        /// phrase: Anchor...
        /// </summary>
        /// <value>Anchor...</value>
        [ResourceEntry("AnchorLabel",
            Value = "Anchor...",
            Description = "phrase: Anchor...",
            LastModified = "2019/04/29")]
        public string AnchorLabel
        {
            get
            {
                return this["AnchorLabel"];
            }
        }

        /// <summary>
        /// phrase: Anchor Example: #more-info
        /// </summary>
        /// <value>Anchor Example: #more-info</value>
        [ResourceEntry("AnchorExample",
            Value = "Example: #more-info",
            Description = "phrase: Example: #more-info",
            LastModified = "2019/04/29")]
        public string AnchorExample
        {
            get
            {
                return this["AnchorExample"];
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
        /// word: Style
        /// </summary>
        /// <value>Style</value>
        [ResourceEntry("Style",
            Value = "Style",
            Description = "word: Style",
            LastModified = "2015/09/22")]
        public string Style
        {
            get
            {
                return this["Style"];
            }
        }

        /// phrase : Target
        /// </summary>
        /// <value>Target</value>
        [ResourceEntry("Target",
            Value = "Target",
            Description = "phrase : Target",
            LastModified = "2019/05/07")]
        public string Target
        {
            get
            {
                return this["Target"];
            }
        }
    }
}
