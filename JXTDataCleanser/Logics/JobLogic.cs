using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTDataCleanser.Intefaces;
using log4net;
using JXTDataCleanser.Models;
using JXTPortal;
using JXTPortal.Entities;

namespace JXTDataCleanser.Logics
{
    public class JobLogic : IDataCleanserLogic
    {
        ILog _logger;

        public JobLogic()
        {
            _logger = LogManager.GetLogger(typeof(JobLogic));
        }

        public bool CanHandle(string[] args)
        {
            string requestedAction = args.ElementAtOrDefault(0);
            if (requestedAction == null)
                return false;

            //check 
            DataCleanAction thisAction;
            bool actionValid = Enum.TryParse<DataCleanAction>(requestedAction, true, out thisAction);
            if (!actionValid || (thisAction != DataCleanAction.Job && thisAction != DataCleanAction.AllJobs))
                return false;

            if (thisAction == DataCleanAction.Job)
            {
                int temp;
                bool siteIDArg = int.TryParse(args.ElementAtOrDefault(1), out temp);
                bool jobIDArg = int.TryParse(args.ElementAtOrDefault(2), out temp);

                if (siteIDArg && jobIDArg)
                    return true;
                return false;
            }
            else if (thisAction == DataCleanAction.AllJobs)
            {
                int temp;
                bool siteIDArg = int.TryParse(args.ElementAtOrDefault(1), out temp);

                if (siteIDArg)
                    return true;
                return false;
            }

            return false;
        }

        public void Process(string[] args)
        {
            //given the "CanHandle" method should have checked, we can assume args data are clean
            DataCleanAction thisAction = (DataCleanAction)Enum.Parse(typeof(DataCleanAction), args[0], true);

            if (thisAction == DataCleanAction.AllJobs)
                CleanBySiteId(int.Parse(args[1]));

            if (thisAction == DataCleanAction.Job)
                CleanById(int.Parse(args[1]), int.Parse(args[2]));
        }


        public void CleanById(int siteId, int id)
        {
            _logger.DebugFormat("Start job removal request, target siteID({0}) JobID({1})", siteId, id);

            try
            {
                JobApplicationNotesService _jobAppNoteService = new JobApplicationNotesService();
                JobApplicationService _jobAppService = new JobApplicationService();
                JobsSavedService _jobSavedService = new JobsSavedService();
                JobViewsService _jobViewService = new JobViewsService();
                JobRolesService _jobRolesService = new JobRolesService();
                JobAreaService _jobAreasService = new JobAreaService();

                JobsService _jobService = new JobsService();

                //check job success
                Jobs thisJob = _jobService.GetByJobId(id);
                if (thisJob != null && thisJob.SiteId == siteId)
                {
                    _logger.DebugFormat("Job found. Attempting delete process...");

                    //Get all job applications for this job
                    TList<JobApplication> thisJobApplications = _jobAppService.GetByJobId(thisJob.JobId);

                    _logger.DebugFormat("{0} Job Applications found. Processing...", thisJobApplications.Count());

                    //Delete all job application notes for all job applications
                    foreach (JobApplication thisJobApp in thisJobApplications)
                    {
                        #region Job Application Notes
                        _logger.DebugFormat("Deleting Job Application Notes...");
                        int jobAppNotesCount = 0;
                        TList<JobApplicationNotes> notes = _jobAppNoteService.GetByJobApplicationId(thisJobApp.JobApplicationId);
                        jobAppNotesCount = notes.Count();
                        _jobAppNoteService.Delete(notes);
                        _logger.DebugFormat("Deleted {0} Job Application Notes", jobAppNotesCount);
                        #endregion
                    }

                    #region Job Applications
                    _logger.DebugFormat("Deleting Job Applications...");
                    int jobAppCount = thisJobApplications.Count();
                    _jobAppService.Delete(thisJobApplications);
                    _logger.DebugFormat("Deleted {0} Job Application", jobAppCount);
                    #endregion

                    #region Member Jobs Saved
                    _logger.DebugFormat("Deleting Jobs Saved...");
                    TList<JobsSaved> memberJobsSaved = _jobSavedService.GetByJobId(thisJob.JobId);
                    int memberJobsSavedCount = memberJobsSaved.Count();
                    _jobSavedService.Delete(memberJobsSaved);
                    _logger.DebugFormat("Deleted {0} Jobs Saved", memberJobsSavedCount);
                    #endregion

                    #region Job Views
                    _logger.DebugFormat("Deleting Job Views...");
                    TList<JobViews> thisJobViews = _jobViewService.GetByJobId(thisJob.JobId);
                    int jobViewsCount = thisJobViews.Count();
                    _jobViewService.Delete(thisJobViews);
                    _logger.DebugFormat("Deleted {0} Job Views", jobViewsCount);
                    #endregion

                    #region Job Roles
                    _logger.DebugFormat("Deleting Job Roles...");
                    TList<JobRoles> thisJobRoles = _jobRolesService.GetByJobId(thisJob.JobId);
                    int jobRolesCount = thisJobRoles.Count();
                    _jobRolesService.Delete(thisJobRoles);
                    _logger.DebugFormat("Deleted {0} Job Roles", jobRolesCount);
                    #endregion

                    #region Job Areas
                    _logger.DebugFormat("Deleting Job Areas...");
                    TList<JobArea> thisJobAreas = _jobAreasService.GetByJobId(thisJob.JobId);
                    int jobAreasCount = thisJobAreas.Count();
                    _jobAreasService.Delete(thisJobAreas);
                    _logger.DebugFormat("Deleted {0} Job Areas", jobRolesCount);
                    #endregion

                    _logger.DebugFormat("Deleting Job...");
                    _jobService.Delete(thisJob);
                    _logger.DebugFormat("Deleted Job successfully");

                    _logger.DebugFormat("Job successfully deleted");
                }
                else
                {
                    _logger.DebugFormat("Job not found. No action taken.");
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            _logger.DebugFormat("Finished job removal request, target siteID({0}) jobID({1})", siteId, id);
        }

        public void CleanBySiteId(int siteId)
        {
            _logger.DebugFormat("Start jobs removal for site request, target siteID({0})", siteId);

            try
            {
                JobsService _js = new JobsService();
                IEnumerable<Jobs> siteJobs = _js.GetBySiteId(siteId);

                if (siteJobs.Count() == 0)
                {
                    _logger.DebugFormat("No jobs found for site. No action taken.");
                }
                else
                {
                    _logger.DebugFormat("Jobs removal starts - Total jobs count {0}", siteJobs.Count());
                    int success = 0, failed = 0;
                    foreach (Jobs thisJob in siteJobs)
                    {
                        try
                        {
                            CleanById(siteId, thisJob.JobId);
                            success++;
                        }
                        catch (Exception e)
                        {
                            _logger.ErrorFormat("Failed to remove Job({0}). Continue.", thisJob.JobId);
                            _logger.Error(e);
                            failed++;
                        }
                    }
                    _logger.DebugFormat("Jobs removal finished - Total({0}) Success({1}) Failed({2})", siteJobs.Count(), success, failed);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            _logger.DebugFormat("Finished jobs removal for site request, target siteID({0})", siteId);

        }

    }
}
