using ServiceStack.Text;
using System;
using System.Linq;
using System.Collections.Generic;
using JXTNext.Telemetry;
using SitefinityWebApp.Libraries;
using SitefinityWebApp.Pages;
using SfImage = Telerik.Sitefinity.Libraries.Model.Image;

namespace SitefinityWebApp.Mvc.Models.MultiCard
{
    public class MultiCardModel
    {
        public MultiCardModel()
        {
            this.IsPageSelectMode = true;
            this.BackgroundColor = "#000000";
        }

        public List<CardDetails> Cards
        {
            get
            {
                return JsonSerializer.DeserializeFromString<List<CardDetails>>(this.SerializedCardsList);
            }
        }

        public string SerializedCardsList
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.serializedCardsList))
                    this.serializedCardsList = JsonSerializer.SerializeToString(new List<CardDetails>(0));

                return this.serializedCardsList;
            }

            set
            {
                if (this.serializedCardsList != value)
                {
                    this.serializedCardsList = value;
                }
            }
        }
        
        public string GroupHeader { get; set; }

        public string BackgroundColor { get; set; }

        public Guid ImageId { get; set; }

        public string ImageProviderName { get; set; }

        public Guid LinkedPageId { get; set; }

        public string LinkedUrl { get; set; }

        public bool IsPageSelectMode { get; set; }

        public string PrimaryActionName { get; set; }

        public string CssClass { get; set; }

        public virtual MultiCardViewModel GetViewModel() 
        {
            using (new StatsDPerformanceMeasure("MultiCardModel.GetViewModel"))
            {
                var viewModel = new MultiCardViewModel()
                {
                    GroupHeader = this.GroupHeader,
                    BackgroundColor = this.BackgroundColor,
                    GroupActionName = this.PrimaryActionName,
                    GroupActionUrl = SfPagesHelper.GetLinkedUrl(this.LinkedPageId, this.LinkedUrl, this.IsPageSelectMode),
                    Cards = this.Cards.Select(c => c.ToViewModel()).ToList(),
                    CssClass = this.CssClass
                };
            
                SfImage image;
                if (this.ImageId != Guid.Empty)
                {
                    image = SfImageHelper.GetImage(this.ImageId, this.ImageProviderName); ;
                    if (image != null)
                    {
                        viewModel.SelectedSizeUrl = SfImageHelper.GetSelectedSizeUrl(image);
                        viewModel.ImageAlternativeText = image.AlternativeText;
                        viewModel.ImageTitle = image.Title;
                    }
                }

                return viewModel;
            }
        }

        public bool IsEmpty()
        {
            using (new StatsDPerformanceMeasure("MultiCardModel.IsEmpty"))
            {
                if (this.LinkedPageId == Guid.Empty && string.IsNullOrEmpty(this.LinkedUrl))
                    return true;

                return (
                    this.ImageId == Guid.Empty &&
                    string.IsNullOrEmpty(this.CssClass) &&
                    string.IsNullOrEmpty(this.PrimaryActionName) &&
                    string.IsNullOrEmpty(this.ImageProviderName));
            }
        }

        protected virtual SfImage GetImage()
        {
            using (new StatsDPerformanceMeasure("MultiCardModel.GetImage"))
            {
                return SfImageHelper.GetImage(this.ImageId, this.ImageProviderName);
            }
        }

        protected virtual string GetSelectedSizeUrl(SfImage image)
        {
            using (new StatsDPerformanceMeasure("MultiCardModel.GetSelectedSizeUrl"))
            {
                return SfImageHelper.GetSelectedSizeUrl(image);
            }
        }

        #region Private fields and constants

        private string serializedCardsList = null;

        #endregion
    }
}
