
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Resources
{
    [ObjectInfo("JxtAuthoringResources", ResourceClassId = "JxtAuthoringResources", Title = "JxtAuthoringResourcesTitle", TitlePlural = "AuthoringResourcesTitlePlural", Description = "AuthoringResourcesDescription")]
    public class JxtAuthoringResources : Resource
    {
        [ResourceEntry("Published",
            Value = "Published",
            Description = "phrase: Published",
            LastModified = "2019/04/05")]
        public string Published
        {
            get
            {
                return this["Published"];
            }
        }
        [ResourceEntry("By",
            Value = "By",
            Description = "phrase: By",
            LastModified = "2019/04/05")]
        public string By
        {
            get
            {
                return this["By"];
            }
        }
        [ResourceEntry("Phone",
            Value = "Phone",
            Description = "phrase: Phone",
            LastModified = "2019/04/05")]
        public string Phone
        {
            get
            {
                return this["Phone"];
            }
        }
        [ResourceEntry("Mobile",
            Value = "Mobile",
            Description = "phrase: Mobile",
            LastModified = "2019/04/05")]
        public string Mobile
        {
            get
            {
                return this["Mobile"];
            }
        }
        [ResourceEntry("LinkedIn",
            Value = "LinkedIn",
            Description = "phrase: LinkedIn",
            LastModified = "2019/04/05")]
        public string LinkedIn
        {
            get
            {
                return this["LinkedIn"];
            }
        }
        [ResourceEntry("Twitter",
            Value = "Twitter",
            Description = "phrase: Twitter",
            LastModified = "2019/04/05")]
        public string Twitter
        {
            get
            {
                return this["Twitter"];
            }
        }
        [ResourceEntry("Email",
            Value = "Email",
            Description = "phrase: Email",
            LastModified = "2019/04/05")]
        public string Email
        {
            get
            {
                return this["Email"];
            }
        }
        [ResourceEntry("About",
            Value = "About",
            Description = "phrase: About",
            LastModified = "2019/04/05")]
        public string About
        {
            get
            {
                return this["About"];
            }
        }
        [ResourceEntry("Address",
            Value = "Address",
            Description = "phrase: Address",
            LastModified = "2019/04/05")]
        public string Address
        {
            get
            {
                return this["Address"];
            }
        }

        [ResourceEntry("CurrencySymbol",
            Value = "$",
            Description = "The currency symbol for the current culture.",
            LastModified = "2019/08/05")]
        public string CurrencySymbol
        {
            get
            {
                return this["CurrencySymbol"];
            }
        }
    }
}