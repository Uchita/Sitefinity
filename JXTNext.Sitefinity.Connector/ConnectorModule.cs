using Autofac;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector
{
    public class ConnectorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JXTNextBusinessLogicsConnector>().AsImplementedInterfaces();
            builder.RegisterType<TestBusinessLogicsConnector>().AsImplementedInterfaces();

            builder.RegisterType<JXTNextOptionsConnector>().AsImplementedInterfaces();
            builder.RegisterType<TestOptionsConnector>().AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
