using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector
{
    public class ConnectorModule : NinjectModule
    {
        public ConnectorModule()
        {

        }

        public override void Load()
        {
            Bind<IBusinessLogicsConnector>().To<JXTNextBusinessLogicsConnector>();
            Bind<IBusinessLogicsConnector>().To<TestBusinessLogicsConnector>();

            Bind<IOptionsConnector>().To<JXTNextOptionsConnector>();
            Bind<IOptionsConnector>().To<TestOptionsConnector>();
        }
    }
}
