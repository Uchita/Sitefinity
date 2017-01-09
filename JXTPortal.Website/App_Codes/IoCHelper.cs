using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using JXTPortal.Data.Dapper.Configuration;
using JXTPortal.Data.Dapper.Factories;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Service.Dapper;
using JXTPortal.Data.SqlClient;
using SectionIO;

namespace JXTPortal.Website.App_Codes
{
    public class IoCHelper
    {
        private const string DEFAULT_CONNECTIONSTRING_KEY = "JXTPortal.Data.ConnectionString";

        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SessionServiceInner>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.Register(c => new DefaultApplicationConfiguration()).As<IApplicationConfiguration>();
            builder.Register(c => new SqlServerConnectionFactory(c.Resolve<IApplicationConfiguration>())).As<IConnectionFactory>();
            builder.Register(c => new KnowledgeBaseCategoryRepository(c.Resolve<IConnectionFactory>(), DEFAULT_CONNECTIONSTRING_KEY)).As<IKnowledgeBaseCategoryRepository>();
            builder.Register(c => new KnowledgeBaseRepository(c.Resolve<IConnectionFactory>(), DEFAULT_CONNECTIONSTRING_KEY)).As<IKnowledgeBaseRepository>();
            builder.Register(c => new SectionIO_API(1295, 2227)).As<ICacheFlusher>();


            builder.Register(c => new KnowledgeBaseService(c.Resolve<IKnowledgeBaseRepository>())).As<IKnowledgeBaseService>();
            builder.Register(c => new KnowledgeBaseCategoryService(c.Resolve<IKnowledgeBaseCategoryRepository>())).As<IKnowledgeBaseCategoryService>();

            builder.RegisterType<SiteLanguageRepository>().WithParameter(new Autofac.NamedParameter("connectionStringName", DEFAULT_CONNECTIONSTRING_KEY)).AsImplementedInterfaces();
            
            builder.RegisterType<SiteLanguageService>().AsImplementedInterfaces();

            return builder.Build();
        }
    }
}