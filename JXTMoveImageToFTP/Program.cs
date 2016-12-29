using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using JXTPortal.Common;
using Autofac;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;
using System.Reflection;
using log4net;

namespace JXTMoveImageToFTP
{
    class Program
    {
        static ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            IContainer container = IoCHelper.CreateContainer();
            logger.Info("Configured IoC");

            using (var scope = container.BeginLifetimeScope())
            {
                List<IProcessor> processors = scope.Resolve<IEnumerable<IProcessor>>().OrderBy(p => p.Priority).ToList();

                if (args == null || args.Count() < 1)
                {
                    Console.WriteLine("Default behaviour: Debug mode and Batched processing (1000)");
                    Console.WriteLine("Arguments:" );
                    Console.WriteLine("'Live': To use live FTP and DB");
                    Console.WriteLine("'Full': To skip the Batch processing");

                    Console.WriteLine("------ Processors available to apply -------");

                    processors.ForEach(p => Console.WriteLine(p.Type));
                    return;
                }

                bool isDebug = IsDebugMode(args);
                logger.Info(string.Format("Running in {0} mode", isDebug ? "DEBUG" : "LIVE"));

                bool isBatched = IsBatchedRun(args);
                int? batchSize = isBatched ? Convert.ToInt32(ConfigurationManager.AppSettings["DefaultBatchSize"]) : (int?)null;
                
                logger.Info(string.Format("Running in {0} mode. Batch size is {1}", isBatched ? "BATCHED" : "FULL", batchSize));
                
                IEnumerable<string> requestedProcessors = FindProcessorsToRun(args);
                var processorsToRun = processors.Where(p => requestedProcessors.Contains(p.Type.ToLower())).ToList();
                if (!processorsToRun.Any())
                {
                    Console.WriteLine("No Valid Processors were selected. Please select from the list below");
                    Console.WriteLine("------ Processors available to apply -------");

                    processors.ForEach(p => Console.WriteLine(p.Type));
                }

                logger.Info(string.Format("Found {0} processors", processorsToRun.Count()));

                processorsToRun.ForEach(p => p.Begin(batchSize, isDebug));
            }
        }

        static bool IsDebugMode(string[] args)
        {
            bool isLive = args.Any(a => string.Equals(a, "Live", StringComparison.InvariantCultureIgnoreCase));

            return !isLive;
        }

        static bool IsBatchedRun(string[] args)
        {
            bool isFull = args.Any(a => string.Equals(a, "Full", StringComparison.InvariantCultureIgnoreCase));

            return !isFull;
        }

        static IEnumerable<string> FindProcessorsToRun(string[] args)
        {
            var results = args.Where(a => !string.Equals(a, "Live", StringComparison.InvariantCultureIgnoreCase))
                              .Where(a => !string.Equals(a, "Full", StringComparison.InvariantCultureIgnoreCase));
            return results.Select(p => p.ToLower()).ToList(); ;
        }
    }
}
