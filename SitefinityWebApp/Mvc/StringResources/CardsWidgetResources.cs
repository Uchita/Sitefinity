using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace SitefinityWebApp.Mvc.StringResources
{
    [ObjectInfo(typeof(CardsWidgetResources), ResourceClassId = "JXTWidgetResources", Title = "JXTWidgetResourcesTitle", Description = "JXTWidgetResourcesDescription")]
    public class CardsWidgetResources : Resource
    {
        #region Constructors
        public CardsWidgetResources()
        {
        }

        public CardsWidgetResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Meta resources

        [ResourceEntry("JXTWidgetResourcesTitle",
            Value = "JXT widget resources",
            Description = "Title for the JXT widget resources class.",
            LastModified = "2018/06/27")]
        public string JXTWidgetResourcesTitle
        {
            get
            {
                return this["JXTWidgetResourcesTitle"];
            }
        }

        [ResourceEntry("JXTWidgetResourcesDescription",
            Value = "Localizable strings for the JXT widgets.",
            Description = "Description for the JXT widget resources class",
            LastModified = "2018/06/27")]
        public string JXTWidgetResourcesDescription
        {
            get
            {
                return this["JXTWidgetResourcesDescription"];
            }
        }
        #endregion

        [ResourceEntry("WhichLinkToBeUsed",
            Value = "Which link to be used?",
            Description = "phrase: Which link to be used?",
            LastModified = "2018/06/27")]
        public string WhichLinkToBeUsed
        {
            get
            {
                return this["WhichLinkToBeUsed"];
            }
        }

        [ResourceEntry("PageWithinLabel",
            Value = "Page within the site...",
            Description = "phrase: Page within the site...",
            LastModified = "2018/06/27")]
        public string PageWithinLabel
        {
            get
            {
                return this["PageWithinLabel"];
            }
        }

        [ResourceEntry("ExternalURL",
            Value = "External URL...",
            Description = "phrase: External URL...",
            LastModified = "2018/06/27")]
        public string ExternalURL
        {
            get
            {
                return this["ExternalURL"];
            }
        }

        [ResourceEntry("ExampleUrl",
            Value = "Example: http://google.com",
            Description = "phrase: Example: http://google.com",
            LastModified = "2018/06/27")]
        public string ExampleUrl
        {
            get
            {
                return this["ExampleUrl"];
            }
        }

        [ResourceEntry("CreateContent",
            Value = "Create content",
            Description = "phrase: Create content",
            LastModified = "2018/06/27")]
        public string CreateContent
        {
            get
            {
                return this["CreateContent"];
            }
        }

        [ResourceEntry("Heading",
            Value = "Heading",
            Description = "word: Heading",
            LastModified = "2018/06/27")]
        public string Heading
        {
            get
            {
                return this["Heading"];
            }
        }

        [ResourceEntry("Description",
            Value = "Description",
            Description = "word: Description",
            LastModified = "2018/06/27")]
        public string Description
        {
            get
            {
                return this["Description"];
            }
        }

        [ResourceEntry("Image",
            Value = "Image",
            Description = "word: Image",
            LastModified = "2018/06/27")]
        public string Image
        {
            get
            {
                return this["Image"];
            }
        }

        [ResourceEntry("ActionName",
            Value = "Action name",
            Description = "phrase: Action name",
            LastModified = "2018/06/27")]
        public string ActionName
        {
            get
            {
                return this["ActionName"];
            }
        }

        [ResourceEntry("ExampleDiscover",
            Value = "Example: Discover",
            Description = "phrase: Example: Discover",
            LastModified = "2018/06/27")]
        public string ExampleDiscover
        {
            get
            {
                return this["ExampleDiscover"];
            }
        }

        [ResourceEntry("MoreOptions",
            Value = "More options",
            Description = "phrase : More options",
            LastModified = "2018/06/27")]
        public string MoreOptions
        {
            get
            {
                return this["MoreOptions"];
            }
        }

        [ResourceEntry("Template",
            Value = "Template",
            Description = " word: Template",
            LastModified = "2018/06/27")]
        public string Template
        {
            get
            {
                return this["Template"];
            }
        }

        [ResourceEntry("CssClasses",
            Value = "CSS classes",
            Description = "phrase : CSS classes",
            LastModified = "2018/06/27")]
        public string CssClasses
        {
            get
            {
                return this["CssClasses"];
            }
        }
                
        [ResourceEntry("SelectCallToActionLink",
            Value = "Select Call To Action link",
            Description = "phrase: Select Call To Action link",
            LastModified = "2018/06/27")]
        public string SelectCallToActionLink
        {
            get
            {
                return this["SelectCallToActionLink"];
            }
        }

        [ResourceEntry("BackgroundImage",
            Value = "Background image",
            Description = "phrase: Background Image",
            LastModified = "2018/06/27")]
        public string BackgroundImage
        {
            get
            {
                return this["BackgroundImage"];
            }
        }

        [ResourceEntry("PrimaryAction",
            Value = "Primary action",
            Description = "phrase: Primary action",
            LastModified = "2018/06/27")]
        public string PrimaryAction
        {
            get
            {
                return this["PrimaryAction"];
            }
        }

        [ResourceEntry("LearnMore",
            Value = "Learn more",
            Description = "phrase: Learn more",
            LastModified = "2018/06/27")]
        public string LearnMore
        {
            get
            {
                return this["LearnMore"];
            }
        }

        [ResourceEntry("ExampleLearnMore",
            Value = "Example: Learn more",
            Description = "phrase: Example: Learn more",
            LastModified = "2018/06/27")]
        public string ExampleLearnMore
        {
            get
            {
                return this["ExampleLearnMore"];
            }
        }

        [ResourceEntry("LinkTo",
            Value = "Link to...",
            Description = "phrase: Link to...",
            LastModified = "2018/06/27")]
        public string LinkTo
        {
            get
            {
                return this["LinkTo"];
            }
        }

        [ResourceEntry("Label",
            Value = "Label",
            Description = "word: Label",
            LastModified = "2018/06/27")]
        public string Label
        {
            get
            {
                return this["Label"];
            }
        }

        [ResourceEntry("BackgroundColor",
            Value = "Background color",
            Description = "phrase: Background color",
            LastModified = "2018/06/27")]
        public string BackgroundColor
        {
            get
            {
                return this["BackgroundColor"];
            }
        }

        [ResourceEntry("General",
            Value = "General",
            Description = "word: General",
            LastModified = "2018/06/27")]
        public string General
        {
            get
            {
                return this["General"];
            }
        }

        [ResourceEntry("Cards",
            Value = "Cards",
            Description = "word: Cards",
            LastModified = "2018/06/27")]
        public string Cards
        {
            get
            {
                return this["Cards"];
            }
        }

        [ResourceEntry("Text",
            Value = "Text",
            Description = "word: Text",
            LastModified = "2018/06/28")]
        public string Text
        {
            get
            {
                return this["Text"];
            }
        }

        [ResourceEntry("AddCard",
            Value = "Add card",
            Description = "phrase: Add card",
            LastModified = "2018/06/28")]
        public string AddCard
        {
            get
            {
                return this["AddCard"];
            }
        }

        [ResourceEntry("DoneAdding",
            Value = "Done adding",
            Description = "phrase: Done adding",
            LastModified = "2018/06/28")]
        public string DoneAdding
        {
            get
            {
                return this["DoneAdding"];
            }
        }

        [ResourceEntry("Cancel",
            Value = "Cancel",
            Description = "word: Cancel",
            LastModified = "2018/06/28")]
        public string Cancel
        {
            get
            {
                return this["Cancel"];
            }
        }

        [ResourceEntry("Card",
            Value = "Card",
            Description = "word: Card",
            LastModified = "2018/06/28")]
        public string Card
        {
            get
            {
                return this["Card"];
            }
        }

        [ResourceEntry("GroupHeading",
            Value = "Group heading",
            Description = "phrase: Group heading",
            LastModified = "2018/06/28")]
        public string GroupHeading
        {
            get
            {
                return this["GroupHeading"];
            }
        }

    }
}
