using JXTNext.Sitefinity.Widgets.Feather.Mvc.Models.Card;
using System;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Card.Mvc.Models.Card;

namespace JXTNext.Sitefinity.Widgets.Feather
{
    public class Installer
    {
        public static void PreApplicationStart()
        {
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped1;
        }

        private static void Bootstrapper_Bootstrapped1(object sender, EventArgs e)
        {
            FrontendModule.Current.DependencyResolver.Rebind<ICardModel>().To<JXTNextCardModel>();
        }
    }
}
