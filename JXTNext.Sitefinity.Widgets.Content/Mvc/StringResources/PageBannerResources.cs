using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources
{
    /// <summary>
    /// Localizable strings for the Blog widget
    /// </summary>
    [ObjectInfo(typeof(PageBannerResources), ResourceClassId = "PageBannerResources", Title = "PageBannerResourcesTitle", Description = "PageBannerResourcesDescription")]
    public class PageBannerResources : Resource
    {
        #region Constructors

        public PageBannerResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PageBannerResources class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public PageBannerResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Meta resources
        /// <summary>
        /// Title for the Page Banner widget resources class.
        /// </summary>
        [ResourceEntry("PageBannerResourcesTitle",
            Value = "Page Banner widget resources",
            Description = "Title for the Page Banner widget resources class.",
            LastModified = "2015/09/22")]
        public string PageBannerResourcesTitle
        {
            get
            {
                return this["PageBannerResourcesTitle"];
            }
        }

        /// <summary>
        /// Description for the Page Banner widget resources class
        /// </summary>
        [ResourceEntry("PageBannerResourcesDescription",
            Value = "Localizable strings for the Page Banner widget.",
            Description = "Description for the Page Banner widget resources class",
            LastModified = "2015/09/22")]
        public string PageBannerResourcesDescription
        {
            get
            {
                return this["PageBannerResourcesDescription"];
            }
        }
        #endregion

        /// <summary>
        /// This phrase is displayed when image was unpublished or has been deleted.
        /// </summary>
        /// <value>An image was not selected or has been deleted. Please select another one.</value>
        [ResourceEntry("ImageWasNotSelectedOrHasBeenDeleted",
            Value = "An image was not selected or has been deleted. Please select another one.",
            Description = "This phrase is displayed when image was unpublished or has been deleted.",
            LastModified = "2015/09/22")]
        public string ImageWasNotSelectedOrHasBeenDeleted
        {
            get
            {
                return this["ImageWasNotSelectedOrHasBeenDeleted"];
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
        /// phrase : CSS classes
        /// </summary>
        /// <value>CSS classes</value>
        [ResourceEntry("DescriptionHtmlElement",
            Value = "Description HTML element",
            Description = "phrase : Description HTML element",
            LastModified = "2019/05/09")]
        public string DescriptionHtmlElement
        {
            get
            {
                return this["DescriptionHtmlElement"];
            }
        }

        /// <summary>
        /// phrase : CSS classes
        /// </summary>
        /// <value>CSS classes</value>
        [ResourceEntry("HeadingHtmlElement",
            Value = "Heading HTML element",
            Description = "phrase : Heading HTML element",
            LastModified = "2019/05/09")]
        public string HeadingHtmlElement
        {
            get
            {
                return this["HeadingHtmlElement"];
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

        /// <summary>
        /// phrase: Create content
        /// </summary>
        /// <value>Create content</value>
        [ResourceEntry("CreateContent",
            Value = "Create content",
            Description = "phrase: Create content",
            LastModified = "2019/04/22")]
        public string CreateContent
        {
            get
            {
                return this["CreateContent"];
            }
        }

        /// <summary>
        /// word: Heading
        /// </summary>
        /// <value>Heading</value>
        [ResourceEntry("Heading",
            Value = "Heading",
            Description = "word: Heading",
            LastModified = "2019/04/22")]
        public string Heading
        {
            get
            {
                return this["Heading"];
            }
        }

        /// <summary>
        /// word: Description
        /// </summary>
        /// <value>Description</value>
        [ResourceEntry("Description",
            Value = "Description",
            Description = "word: Description",
            LastModified = "2019/04/22")]
        public string Description
        {
            get
            {
                return this["Description"];
            }
        }

        /// <summary>
        /// word: Text
        /// </summary>
        /// <value>Text</value>
        [ResourceEntry("Text",
            Value = "Text",
            Description = "word: Text",
            LastModified = "2019/04/22")]
        public string Text
        {
            get
            {
                return this["Text"];
            }
        }

        /// <summary>
        /// word: Image
        /// </summary>
        /// <value>Image</value>
        [ResourceEntry("Image",
            Value = "Image",
            Description = "word: Image",
            LastModified = "2019/04/22")]
        public string Image
        {
            get
            {
                return this["Image"];
            }
        }

        /// <summary>
        /// phrase: Example: Learn more
        /// </summary>
        /// <value>Example: Learn more</value>
        [ResourceEntry("LearnMore",
            Value = "Example: Learn more",
            Description = "phrase: Example: Learn more",
            LastModified = "2019/04/22")]
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
            LastModified = "2019/04/22")]
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
        [ResourceEntry("ExternalURL",
            Value = "External URL...",
            Description = "phrase: External URL...",
            LastModified = "2019/04/22")]
        public string ExternalURL
        {
            get
            {
                return this["ExternalURL"];
            }
        }

        /// <summary>
        /// phrase: Example: https://www.progress.com/sitefinity-cms
        /// </summary>
        /// <value>Example: https://www.progress.com/sitefinity-cms</value>
        [ResourceEntry("Example",
            Value = "Example: https://www.progress.com/sitefinity-cms",
            Description = "phrase: Example: https://www.progress.com/sitefinity-cms",
            LastModified = "2019/04/22")]
        public string Example
        {
            get
            {
                return this["Example"];
            }
        }
    }
}
