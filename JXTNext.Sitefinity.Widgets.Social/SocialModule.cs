using JXTNext.Sitefinity.Widgets.Social.Mvc.Logics;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models.AddThis;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Social
{
    public class SocialModule : NinjectModule
    {
        public SocialModule()
        {

        }

        public override void Load()
        {
            Bind<SocialHandlerLogics>().To<SocialHandlerLogics>();
            Bind<IProcessSocialMediaData>().To<ProcessIndeedData>().Named("Indeed");
            Bind<IProcessSocialMediaData>().To<ProcessSeekData>().Named("Seek");

            Bind<IAddThisModel>().To<AddThisModel>();
        }
    }
}
