using System;
using SitefinityWebApp.Libraries;
using SitefinityWebApp.Pages;
using SfImage = Telerik.Sitefinity.Libraries.Model.Image;

namespace SitefinityWebApp.Mvc.Models.MultiCard
{
    public class CardDetails
    {
        public string Id { get; set; }
        public string Heading { get; set; }

        public string Description { get; set; }

        public Guid LinkedPageId { get; set; }

        public string LinkedUrl { get; set; }

        public bool IsPageSelectMode { get; set; }

        public string ActionName { get; set; }

        public Guid ImageId { get; set; }

        public string ImageProviderName { get; set; }

        public CardDetailsView ToViewModel()
        {
            var cardDetailsView = new CardDetailsView
            {
                Heading = this.Heading,
                Description = this.Description,
                ActionName = this.ActionName,
                ActionUrl = "#"//SfPagesHelper.GetLinkedUrl(this.LinkedPageId, this.LinkedUrl, this.IsPageSelectMode)
            };

            SfImage image;
            if (this.ImageId != Guid.Empty)
            {
                image = SfImageHelper.GetImage(this.ImageId, this.ImageProviderName);
                if (image != null)
                {
                    cardDetailsView.SelectedSizeUrl = SfImageHelper.GetSelectedSizeUrl(image);
                    cardDetailsView.ImageAlternativeText = image.AlternativeText;
                    cardDetailsView.ImageTitle = image.Title;
                }
            }

            return cardDetailsView;
        }
    }
}
