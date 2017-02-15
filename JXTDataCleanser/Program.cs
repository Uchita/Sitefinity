using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using JXTDataCleanser.Models;
using log4net;
using JXTDataCleanser.Logics;
using JXTDataCleanser.Intefaces;

namespace JXTDataCleanser
{
    class Program
    {
        private static ILog _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        /// arg 1: Data Clean Action of an Enum Type DataCleanAction
        /// </param>
        static void Main(string[] args)
        {
            AutoFacContainer.BuildContainer();

            _logger = LogManager.GetLogger(typeof(Program));

            //check action
            string actionValidateError = null;
            bool isValidAction = ValidateActionArguments(args, out actionValidateError);

            if (!isValidAction)
            {
                _logger.Warn("Failed to detect action. Aborting.");
                Console.WriteLine(actionValidateError);
                return;
            }

            if (isValidAction)
            {
                DataCleanAction thisAction = (DataCleanAction)Enum.Parse(typeof(DataCleanAction), args.ElementAt(0), true);
                switch (thisAction)
                {
                    case DataCleanAction.About:
                        WriteAboutToConsole();
                        return;
                    case DataCleanAction.Help:
                        WriteHelpToConsole();
                        return;
                    default:
                        AutoFacContainer.Resolve<Cleanser>().Run(args);
                        break;
                }
            }
        }

        private static bool ValidateActionArguments(string[] inputs, out string errorMsg)
        {
            _logger.Debug("ValidateActionArguments - Arguments[" + String.Join(" ", inputs) + "]");

            string errorMsgHelpDetails = "Use 'program.exe help' for more details.";

            if (inputs.ElementAtOrDefault(0) == null)
            {
                _logger.WarnFormat("No input arguments detected");

                errorMsg = "No arguments found. Use 'program.exe help' for more details.";
                return false;
            }

            //parse first action argument
            _logger.Debug("ValidateActionArguments - Parsing argument[0] [" + inputs.ElementAt(0) + "]");

            DataCleanAction thisAction;
            bool actionValid = Enum.TryParse<DataCleanAction>(inputs.ElementAt(0), true, out thisAction);
            if (!actionValid)
            {
                _logger.WarnFormat("ValidateActionArguments - Invalid action @ argument[0] [" + inputs.ElementAt(0) + "]");

                errorMsg = "Invalid action '" + inputs.ElementAt(0) + "'. " + errorMsgHelpDetails;
                return false;
            }

            _logger.Debug("ValidateActionArguments - Success");
            errorMsg = null;
            return true;
        }

        private static void WriteAboutToConsole()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Seriously... Why would you care about finding out 'about' this app? If you insisted, this was created on the Valentine's day 2017. Happy Valentine's day!");

            Console.WriteLine(sb.ToString());
        }

        private static void WriteHelpToConsole()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Usage: program.exe {action} [{arguments}+]");
            sb.AppendLine("Available actions ({action}): " + (String.Join(" ", Enum.GetValues(typeof(DataCleanAction)))).ToLower() + "\n");

            sb.AppendLine("help: Prints this help message");
            sb.AppendLine("member: Attempt to remove a single member.");
            sb.AppendLine("\tUsage - program.exe member {siteID(int)} {memberID(int)}");

            sb.AppendLine("allmembers: Attempt to remove all members from a site.");
            sb.AppendLine("\tUsage - program.exe allmembers {siteID(int)}");

            sb.AppendLine("Job: Attempt to remove a single job. All relevant data will also be removed (eg applications).");
            sb.AppendLine("\tUsage - program.exe job {siteID(int)} {jobID(int)}");
            
            sb.AppendLine("All Jobs: Attempt to remove all jobs from a site. All relevant data will also be removed (eg applications).");
            sb.AppendLine("\tUsage - program.exe alljobs {siteID(int)}");
            
            Console.WriteLine(sb.ToString());
        }

    }

    public class Cleanser
    {
        IEnumerable<IDataCleanserLogic> _cleansers;
        ILog _logger;

        public Cleanser(IEnumerable<IDataCleanserLogic> cleansers)
        {
            _cleansers = cleansers;
            _logger = LogManager.GetLogger(typeof(Cleanser));
        }

        public void Run(string[] args)
        {
            _logger.Info("Running all applicable data cleansers");
            var cleansers = _cleansers.Where(c => c.CanHandle(args)).ToList();

            _logger.DebugFormat("Found {0} data cleansers to run", cleansers.Count);
            cleansers.ForEach(c => c.Process(args));

            _logger.Info("Finished running all Data cleansers");
        }
    }
}
