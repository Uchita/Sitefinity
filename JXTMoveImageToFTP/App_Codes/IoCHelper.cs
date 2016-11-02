using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using JXTPortal.Data.Dapper.Configuration;
using JXTPortal.Data.Dapper.Factories;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Service.Dapper;

namespace JXTMoveImageToFTP
{
    public class IoCHelper
    {
        private const string DEFAULT_CONNECTIONSTRING_KEY = "JXTPortal.Data.ConnectionString";

        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new DefaultApplicationConfiguration()).As<IApplicationConfiguration>();
            builder.Register(c => new SqlServerConnectionFactory(c.Resolve<IApplicationConfiguration>())).As<IConnectionFactory>();
            builder.Register(c => new SitesRepository(c.Resolve<IConnectionFactory>(), DEFAULT_CONNECTIONSTRING_KEY)).As<ISitesRepository>();

            builder.Register(c => new SitesService(c.Resolve<ISitesRepository>())).As<ISitesService>();
            builder.Register(c => new AdvertisersService(c.Resolve<IAdvertisersRepository>())).As<IAdvertisersService>();
            builder.Register(c => new JobTemplatesService(c.Resolve<IJobTemplatesRepository>())).As<IJobTemplatesService>();


            // Register for FTP Client class
            builder.RegisterType<Client>();

            return builder.Build();
        }
    }
}
