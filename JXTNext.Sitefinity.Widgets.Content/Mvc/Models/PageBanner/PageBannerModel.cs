using JXTNext.Sitefinity.Media.Mvc.Helpers;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Web;
using SfImage = Telerik.Sitefinity.Libraries.Model.Image;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Models.PageBanner
{
    /// <summary>
    /// Provides API for working with the page banner.
    /// </summary>
    public class PageBannerModel : IPageBannerModel
    {
        public string Heading { get; set; }

        public bool UsePageTitle { get; set; } = true;

        public bool DisableHeading { get; set; }

        [DynamicLinksContainer]
        public string Description { get; set; }

        public bool UsePageDescription { get; set; } = true;

        public bool DisableDescription { get; set; }

        public Guid ImageId { get; set; }

        /// <inheritdoc />
        public string ImageProviderName { get; set; }

        public string ThumbnailName { get; set; }

        public bool IsHomepage { get; set; }

        public string CssClass { get; set; }

        public string DefaultCssClass { get; set; } = "o-page-banner";

        public virtual PageBannerViewModel GetViewModel()
        {
            var currentSiteNode = SiteMapBase.GetActualCurrentNode();

            var viewModel = new PageBannerViewModel()
            {
                Heading = this.DisableHeading ? string.Empty : this.GetHeading(currentSiteNode),
                Description = this.DisableDescription ? string.Empty : this.GetDescription(currentSiteNode),
                CssClass = String.Format("{0} {1}", this.DefaultCssClass, this.CssClass).Trim(),
                DefaultCssClass = this.DefaultCssClass,
                IsHomepage = this.DetermineHomepage(currentSiteNode)
            };

            SfImage image;
            if (this.ImageId != Guid.Empty)
            {
                image = this.GetImage();
                viewModel.Image = image;
                viewModel.ImageUrl = ImageHelper.GetImageUrl(image,this.ThumbnailName);
            }

            return viewModel;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns></returns>
        protected virtual SfImage GetImage()
        {
            var librariesManager = LibrariesManager.GetManager(this.ImageProviderName);
            return librariesManager.GetImages().Where(i => i.Id == this.ImageId).Where(PredefinedFilters.PublishedItemsFilter<SfImage>()).FirstOrDefault();
        }

        protected virtual bool DetermineHomepage(PageSiteNode node)
        {
            bool flag = false;
            flag = (node == null || this.IsHomepage ? this.IsHomepage : PageSiteNodeExtensions.IsHomePage(node));
            return flag;
        }

        protected virtual string GetHeading(PageSiteNode node)
        {
            string heading = "Example page heading!";

            if (!this.UsePageTitle)
            {
                heading = this.Heading;
            }
            else if (node != null)
            {
                var transaction = Guid.NewGuid();
                var pageManager = PageManager.GetManager();
                var pageData = pageManager.GetPageData(node.PageId);

                heading = pageData.HtmlTitle;
            }
            return heading.IsNullOrWhitespace() ? string.Empty : heading.Trim();
        }

        protected virtual string GetDescription(PageSiteNode node)
        {
            string desc = "This is an example description. This will not show on a published page.";

            if (!this.UsePageDescription)
            {
                desc = this.Description;
            }
            else if (node != null)
            {
                desc = node.Description;
            }
            return desc.IsNullOrWhitespace() ? string.Empty : desc.Trim();
        }

        public bool IsEmpty()
        {
            return (!this.UsePageTitle && string.IsNullOrEmpty(this.Heading));
        }

    }
}
