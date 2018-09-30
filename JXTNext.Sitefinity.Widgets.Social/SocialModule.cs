using JXTNext.Sitefinity.Widgets.Social.Mvc.Logics;
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
            Bind<IProcessSocialMediaData>().To<ProcessIndeedData>();
            Bind<IProcessSocialMediaData>().To<ProcessSeekData>();
        }
    }
}
