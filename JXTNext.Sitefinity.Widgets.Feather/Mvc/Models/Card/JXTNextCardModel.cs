using Telerik.Sitefinity.Frontend.Card.Mvc.Models.Card;

namespace JXTNext.Sitefinity.Widgets.Feather.Mvc.Models.Card
{
    public class JXTNextCardModel : CardModel
    {
        public JXTNextCardModel()
            : base()
        {
        }


        public override CardViewModel GetViewModel()
        {
            var viewModel = new JXTNextCardViewModel(base.GetViewModel())
            {
                CardImage = GetImage()
            };

            return viewModel;
        }
    }
}
