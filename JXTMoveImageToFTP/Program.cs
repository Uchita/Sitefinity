using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using JXTPortal.Common;
using Autofac;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;
using System.Reflection;

namespace JXTMoveImageToFTP
{
    class Program
    {
        static void Main(string[] args)
        {
            //1: Configure Container
            ContainerBuilder builder = new ContainerBuilder();
       
            //2: Build Container
            IContainer container = IoCHelper.CreateContainer();

            //3: Build Dependencies
            using (var scope = container.BeginLifetimeScope())
            {
                var ftpclient = scope.Resolve<Client>();

                ftpclient.ProcessSites();
            }
        }

        
    }
}
