using Telerik.Sitefinity.Frontend.Card.Mvc.Models.Card;
using SfImage = Telerik.Sitefinity.Libraries.Model.Image;

namespace JXTNext.Sitefinity.Widgets.Feather.Mvc.Models.Card
{
    public class JXTNextCardViewModel : CardViewModel
    {
        public JXTNextCardViewModel(CardViewModel cardViewModel) : base()
        {
            this.ActionName = cardViewModel.ActionName;
            this.ActionUrl = cardViewModel.ActionUrl;
            this.Heading = cardViewModel.Heading;
            this.ImageAlternativeText = cardViewModel.ImageAlternativeText;
            this.ImageTitle = cardViewModel.ImageTitle;
            this.SelectedSizeUrl = cardViewModel.SelectedSizeUrl;
            this.Description = cardViewModel.Description;
            this.CssClass = cardViewModel.CssClass;
        }

        public SfImage CardImage { get; set; }
    }
}
