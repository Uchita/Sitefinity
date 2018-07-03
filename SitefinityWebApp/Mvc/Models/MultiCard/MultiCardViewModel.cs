using System.Collections.Generic;
using Telerik.Sitefinity.Frontend.Mvc.Models;

namespace SitefinityWebApp.Mvc.Models.MultiCard
{
    public class MultiCardViewModel : ContentDetailsViewModel
    {
        public string GroupHeader { get; set; }

        public string BackgroundColor { get; set; }

        public string GroupActionName { get; set; }
        
        public string GroupActionUrl { get; set; }

        public string ImageTitle { get; set; }

        public string ImageAlternativeText { get; set; }

        public string SelectedSizeUrl { get; set; }

        public List<CardDetailsView> Cards { get; set; }
    }
}
