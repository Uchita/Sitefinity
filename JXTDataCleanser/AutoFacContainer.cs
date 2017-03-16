using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using JXTDataCleanser.Logics;
using JXTDataCleanser.Intefaces;

namespace JXTDataCleanser
{
    public static class AutoFacContainer
    {
        private static IContainer _ioc;

        public static void BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<Cleanser>().InstancePerLifetimeScope();

            //Logics
            builder.RegisterType<MemberLogic>().AsImplementedInterfaces();
            builder.RegisterType<JobLogic>().AsImplementedInterfaces();

            _ioc = builder.Build();
        }

        public static T Resolve<T>()
        {
            if (_ioc == null)
                BuildContainer();

            return _ioc.Resolve<T>();
        }

    }
}
