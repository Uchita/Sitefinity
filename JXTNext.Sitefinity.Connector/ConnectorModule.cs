using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.Options;
using Ninject.Modules;

namespace JXTNext.Sitefinity.Connector
{
    public class ConnectorModule : NinjectModule
    {
        public ConnectorModule()
        {

        }

        public override void Load()
        {
            Bind<IJobListingMapper>().To<JXTNext_JobListingMapper>();
            Bind<IMemberMapper>().To<JXTNext_MemberMapper>();

            Bind<IBusinessLogicsConnector>().To<JXTNextBusinessLogicsConnector>();
            
            Bind<IOptionsConnector>().To<JXTNextOptionsConnector>();            
        }
    }
}
