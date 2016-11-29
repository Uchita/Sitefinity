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
            builder.Register(c => new AdvertisersRepository(c.Resolve<IConnectionFactory>(), DEFAULT_CONNECTIONSTRING_KEY)).As<IAdvertisersRepository>();
            builder.Register(c => new AdvertisersService(c.Resolve<IAdvertisersRepository>())).As<IAdvertisersService>();
            builder.Register(c => new JobTemplatesRepository(c.Resolve<IConnectionFactory>(), DEFAULT_CONNECTIONSTRING_KEY)).As<IJobTemplatesRepository>();
            builder.Register(c => new JobTemplatesService(c.Resolve<IJobTemplatesRepository>())).As<IJobTemplatesService>();
            builder.Register(c => new AdvertiserJobTemplateLogoRepository(c.Resolve<IConnectionFactory>(), DEFAULT_CONNECTIONSTRING_KEY)).As<IAdvertiserJobTemplateLogoRepository>();
            builder.Register(c => new AdvertiserJobTemplateLogoService(c.Resolve<IAdvertiserJobTemplateLogoRepository>())).As<IAdvertiserJobTemplateLogoService>();
            builder.Register(c => new MemberFilesRepository(c.Resolve<IConnectionFactory>(), DEFAULT_CONNECTIONSTRING_KEY)).As<IMemberFilesRepository>();
            builder.Register(c => new MemberFilesService(c.Resolve<IMemberFilesRepository>())).As<IMemberFilesService>();
            builder.Register(c => new ConsultantsRepository(c.Resolve<IConnectionFactory>(), DEFAULT_CONNECTIONSTRING_KEY)).As<IConsultantsRepository>();
            builder.Register(c => new ConsultantsService(c.Resolve<IConsultantsRepository>())).As<IConsultantsService>();


            // Register for FTP Client class
            builder.RegisterType<Client>();

            return builder.Build();
        }
    }
}
