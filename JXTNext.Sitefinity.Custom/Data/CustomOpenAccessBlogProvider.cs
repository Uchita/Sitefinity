using System;
using Telerik.Sitefinity.Blogs.Model;
using Telerik.Sitefinity.Modules.Blogs.Data;

namespace JXTNext.Sitefinity.Custom.Data
{
    public class CustomOpenAccessBlogProvider : OpenAccessBlogProvider
    {
        /// <summary>
        /// The URL format string for blog items
        /// </summary>
        public string BlogUrlFormat
        {
            get;
            set;
        }

        /// <summary>
        /// The URL format string for blog post items
        /// </summary>
        public string BlogPostUrlFormat
        {
            get;
            set;
        }

        public override string GetUrlFormat(Telerik.Sitefinity.GenericContent.Model.ILocatable item)
        {
            if (item.GetType() == typeof(Blog))
                return this.BlogUrlFormat;

            else if (item.GetType() == typeof(BlogPost))
                return this.BlogPostUrlFormat;

            else
                return base.GetUrlFormat(item);
        }

        protected override void Initialize(string providerName, System.Collections.Specialized.NameValueCollection config, Type managerType)
        {
            base.Initialize(providerName, config, managerType);

            this.BlogUrlFormat = config["blogUrlFormat"];

            if (String.IsNullOrEmpty(this.BlogUrlFormat))
            {
                this.BlogUrlFormat = "/[UrlName]";
            }

            this.BlogPostUrlFormat = config["blogPostUrlFormat"];

            if (String.IsNullOrEmpty(this.BlogPostUrlFormat))
            {
                this.BlogPostUrlFormat = "/[Parent.UrlName]/[UrlName]";
            }
        }
    }
}
